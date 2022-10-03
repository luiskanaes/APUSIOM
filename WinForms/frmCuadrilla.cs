using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;

namespace WinForms
{
    public partial class frmCuadrilla : Form
    {
        string  idEmpresa = string.Empty ;
        string  idCentro = string.Empty;
        string  idfecha = string.Empty;
        DataTable dtResulDisponible ;
        public int varfNuevo;
        public static BE_ASIGNACION_TAREO objTareo;
        public frmCuadrilla()
        {
            InitializeComponent();

            btnVarios.BackColor = Color.FromArgb(249, 39, 39);
            btnVarios.ForeColor = Color.FromArgb(255, 255, 255);
            btnVarios.Font = new Font(btnVarios.Font.Name, btnVarios.Font.Size, FontStyle.Bold);

            try
            {
                idEmpresa = frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA;
                idCentro = frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS ;
                idfecha = frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO.ToString();
                if (idfecha!= string.Empty )
                {
                    dateFecha.Value = Convert.ToDateTime(frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);
                }

            }
            catch (Exception ex)
            {

            }
            ListarEmpresa();
            //listarPersonalDisponible();

        }
        private void frmCuadrilla_Load(object sender, EventArgs e)
        {

        }

        protected void ListarEmpresa()
        {

            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarEmpresaPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboEmpresa.ValueMember = "ID";
                cboEmpresa.DisplayMember = "DESCRIPCION";
                cboEmpresa.DataSource = dtResultado;
               
                if (idEmpresa != string.Empty)
                {
                    cboEmpresa.SelectedValue = idEmpresa;
                    ListarCesos();
                }
                else
                {
                    ListarCesos();
                }
            }

            
            
        }
        protected void ListarCesos()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarCesosPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO, Convert.ToInt32(cboEmpresa.SelectedValue));
            if (dtResultado.Rows.Count > 0)
            {
                cboCentroCosto.ValueMember = "ID";
                cboCentroCosto.DisplayMember = "CECOS";
                cboCentroCosto.DataSource = dtResultado;

                if (idCentro != string.Empty)
                {
                    cboCentroCosto.SelectedValue = idCentro;
                    ListarIngenieros();
                }
                else
                {
                    ListarIngenieros();
                }

                
            }
            listarPersonalDisponible();
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }
        protected void ListarIngenieros()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            //dtResultado = obj.Listar_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "INGENIERO", null);
            dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(cboCentroCosto.SelectedValue.ToString(), "1", "1", "", dateFecha.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {
                cboIngeniero.Visible = true ;
                cboIngeniero.ValueMember = "ID_PERSONAL";
                cboIngeniero.DisplayMember = "NOMBRES";
                cboIngeniero.DataSource = dtResultado;
                ListarCapataz();
                //listarPersonalDisponible();
            }
            else
            {
                cboIngeniero.Visible = false;
                cboCapataz.Visible = false;
            }
        }
        protected void ListarCapataz()
        {
           
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
           
            DataTable dtResultado = new DataTable();
            //dtResultado = obj.Listar_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "RESPONSABLE CUADRILLA", cboIngeniero.SelectedValue.ToString());
            dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(cboCentroCosto.SelectedValue.ToString(), "1", "2", cboIngeniero.SelectedValue.ToString(), dateFecha.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {
                cboCapataz.Visible = true ;
                cboCapataz.ValueMember = "ID_PERSONAL";
                cboCapataz.DisplayMember = "NOMBRES";
                cboCapataz.DataSource = dtResultado;

                listarCuadrilla();
            }
            else
            {
                cboCapataz.Visible = false;

                MessageBox.Show("No existen responsables de cuadrillas asignados al" + Environment.NewLine +
                    "Sr. " + cboIngeniero.Text + " " + Environment.NewLine +
                    "Ingresar Opción : Configuración -> Asignación de responsables", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarIngenieros();
            //listarPersonalDisponible();
        }
        private void cboCapataz_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listarCuadrilla();
                listarPersonalDisponible();
            }
            catch (Exception ex)
            {

            }
        }
        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCapataz();
        }
       

        private BE_PERSONAL f_datos(int estado)
        {
            BE_PERSONAL Obj = new BE_PERSONAL();
            
               
                Obj.FLG_LIBRE = estado;
                Obj.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();
                Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
                Obj.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
                Obj.FECHA = dateFecha.Value.Date.ToString("dd/MM/yyyy");
                Obj.IDE_INGENIERO = cboIngeniero.SelectedValue.ToString();


            return Obj;
        }
        protected void listarPersonalDisponible()
        {
            BE_PERSONAL obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();
            obj = f_datos(1);
           
            dgvPersonal.Rows.Clear();
            dgvPersonal.Refresh();
            dgvPersonal.DataSource = null;
            dgvPersonal.Columns.Clear();

            dgvPersonal.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.ToolTipText = "Disponible";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Seleccion";
            dgvPersonal.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Nro";
            colItem.HeaderText = "N°";
            colItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colItem.Width = 30;
            
            dgvPersonal.Columns.Insert(1, colItem);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Personal Disponible";
            colNombre.Width = 300;
            dgvPersonal.Columns.Insert(2, colNombre);

            DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
            colCategoria.Name = "Categoria";
            colCategoria.HeaderText = "Categoria";
            colCategoria.Width = 140;
            dgvPersonal.Columns.Insert(3, colCategoria);

            
            DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
            colIdPersona.Name = "idePersonal";
            colIdPersona.HeaderText = "idePersonal";
            colIdPersona.Width = 30;
            colIdPersona.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(4, colIdPersona);

            DataGridViewTextBoxColumn colAsignado = new DataGridViewTextBoxColumn();
            colAsignado.Name = "ideAsignado";
            colAsignado.HeaderText = "ideAsignado";
            colAsignado.Width = 30;
            dgvPersonal.Columns.Insert(5, colAsignado);

            dgvPersonal.Columns["ideAsignado"].Visible = false;
            dgvPersonal.Columns["idePersonal"].Visible = false;

            dtResulDisponible = new DataTable();
            dtResulDisponible = objPersona.Listar_disponibilidadPersonal(obj);
            try
            {
                if (dtResulDisponible.Rows.Count > 0)
                {
                    string FLG_LIBRE, ITEM, Personal, CATEGORIA, IDE_PERSONAL, ASIGNADO;
                    string[] Xrow;
                    for (int i = 0; i < dtResulDisponible.Rows.Count; i++)
                    {
                        FLG_LIBRE = dtResulDisponible.Rows[i]["SELECCIONAR"].ToString();// Convert.ToString(i + 1);
                        Personal = dtResulDisponible.Rows[i]["Personal"].ToString();
                        IDE_PERSONAL = dtResulDisponible.Rows[i]["IDE_PERSONAL"].ToString();
                        ASIGNADO = dtResulDisponible.Rows[i]["CantidadAsignacion"].ToString();
                        ITEM = dtResulDisponible.Rows[i]["ITEM"].ToString();
                        CATEGORIA = dtResulDisponible.Rows[i]["CATEGORIA"].ToString();
                        Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (),ITEM, Personal,CATEGORIA, IDE_PERSONAL,ASIGNADO
                        };
                        dgvPersonal.Rows.Add(Xrow);
                    }
                }
                else
                {
                    MessageBox.Show("Falta definir responsable de cuadrilla, ingresar a la opcion 'ASIGNACION DE RESPONSABLES' ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falta definir responsable de cuadrilla, ingresar a la opcion 'ASIGNACION DE RESPONSABLES' ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            //foreach (DataGridViewRow row in dgvPersonal.Rows)
            //{
            //    if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 0)// asignado a cuadrilla
            //    {
            //        row.DefaultCellStyle.BackColor = Color.White;
            //    }
            //    else if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 1)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            //    }
            //    else
            //    {
            //        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 195, 0);
            //    }
            //}
            Cantidad();

        }

        protected void listarCuadrilla()
        {
            BE_PERSONAL obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();
            obj = f_datos(0);

            //obj.FLG_LIBRE = 0;
            //obj.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();
            //obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            //obj.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            //obj.FECHA = dateFecha.Value.Date.ToString("dd/MM/yyyy");


            dgvCuadrilla.Rows.Clear();
            dgvCuadrilla.Refresh();
            dgvCuadrilla.DataSource = null;
            dgvCuadrilla.Columns.Clear();

            dgvCuadrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Quitar";
            dgvCuadrilla.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colOrden = new DataGridViewTextBoxColumn();
            colOrden.Name = "Row";
            colOrden.HeaderText = "N°";
            colOrden.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colOrden.Width = 30;
            dgvCuadrilla.Columns.Insert(1, colOrden);


            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Personal";
            colNombre.Width = 300;
            dgvCuadrilla.Columns.Insert(2, colNombre);

            DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
            colIdPersona.Name = "idePersonal";
            colIdPersona.HeaderText = "idePersonal";
            colIdPersona.Width = 30;
            dgvCuadrilla.Columns.Insert(3, colIdPersona);
            dgvCuadrilla.Columns["idePersonal"].Visible = false;



            DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
            colCategoria.Name = "Categoria";
            colCategoria.HeaderText = "Categoria";
            colCategoria.Width = 140;
            dgvCuadrilla.Columns.Insert(4, colCategoria);

            


            DataTable dtResultado = new DataTable();
            dtResultado = objPersona.Listar_disponibilidadPersonal(obj);
            if (dtResultado.Rows.Count > 0)
            {
                string FLG_LIBRE, Row,Personal, IDE_PERSONAL, CATEGORIA;
                string[] Xrow;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    FLG_LIBRE = dtResultado.Rows[i]["SELECCIONAR"].ToString();
                    Personal = dtResultado.Rows[i]["Personal"].ToString();
                    IDE_PERSONAL = dtResultado.Rows[i]["IDE_PERSONAL"].ToString();
                    CATEGORIA = dtResultado.Rows[i]["CATEGORIA"].ToString();
                    Row = dtResultado.Rows[i]["Row"].ToString();
                    Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (),Row, Personal, IDE_PERSONAL,CATEGORIA //,Convert.ToBoolean(ASIGNADO).ToString ()
                    };
                    dgvCuadrilla.Rows.Add(Xrow);
                }

            }
            else
            {
                dgvCuadrilla.Rows.Clear();
                dgvCuadrilla.Refresh();
                dgvCuadrilla.DataSource = null;
                dgvCuadrilla.Columns.Clear();
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            BL_PERSONAL obj = new BL_PERSONAL();
            BL_ASIGNACION_TAREAS objAsignacion = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            //
            // Se define una lista temporal de registro seleccionados
            //
            List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();

            //
            // Se recorre ca registro de la grilla de origen
            //
            foreach (DataGridViewRow row in dgvCuadrilla.Rows)
            {
                //
                // Se recupera el campo que representa el checkbox, y se valida la seleccion
                // agregandola a la lista temporal
                //
                DataGridViewCheckBoxCell cellSelecion = row.Cells["Quitar"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    rowSelected.Add(row);
                }
            }

            //
            // Se agrega el item seleccionado a la grilla de destino
            // eliminando la fila de la grilla original
            //
            foreach (DataGridViewRow row in rowSelected)
            {
                dgvPersonal.Rows.Add(new object[] {false,
                                                    row.Cells["Nombre"].Value,
                                                    row.Cells["idePersonal"].Value});


                dtResultado = objAsignacion.Tareo_x_persona(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateFecha.Value.Date.ToString("dd/MM/yyyy"), row.Cells["idePersonal"].Value.ToString(), cboCapataz.SelectedValue.ToString(), cboIngeniero.SelectedValue.ToString());

                if ( dtResultado.Rows.Count == 0)
                {
                    obj.AsignarPersonal(
                        cboCentroCosto.SelectedValue.ToString(),
                        Convert.ToInt32(row.Cells["idePersonal"].Value.ToString()),
                        Convert.ToInt32(cboEmpresa.SelectedValue),
                        1,//para liberar
                        cboCapataz.SelectedValue.ToString(),
                        cboIngeniero.SelectedValue.ToString(),
                        dateFecha.Value.Date.ToString("dd/MM/yyyy"));
                    varfNuevo++;
                    dgvCuadrilla.Rows.Remove(row);
                }
                else
                {
                    MessageBox.Show( "El Sr. " + row.Cells["Nombre"].Value.ToString () + Environment.NewLine + " tiene tareo registrado" , "Advertencia Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            listarPersonalDisponible();
            Cantidad();

        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            BL_PERSONAL obj = new BL_PERSONAL();
            //
            // Se define una lista temporal de registro seleccionados
            //
            List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();

            //
            // Se recorre ca registro de la grilla de origen
            //
            foreach (DataGridViewRow row in dgvPersonal.Rows)
            {
                //
                // Se recupera el campo que representa el checkbox, y se valida la seleccion
                // agregandola a la lista temporal
                //
                DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    rowSelected.Add(row);
                }
            }

            //
            // Se agrega el item seleccionado a la grilla de destino
            // eliminando la fila de la grilla original
            //
            foreach (DataGridViewRow row in rowSelected)
            {
                dgvCuadrilla.Rows.Add(new object[] {false,
                                                    row.Cells["Nombre"].Value,
                                                    row.Cells["idePersonal"].Value});
                obj.AsignarPersonal(
                        cboCentroCosto.SelectedValue.ToString(),
                        Convert.ToInt32(row.Cells["idePersonal"].Value.ToString()),
                        Convert.ToInt32(cboEmpresa.SelectedValue), 
                        0,//Asignar
                        cboCapataz.SelectedValue.ToString () ,
                        cboIngeniero.SelectedValue.ToString(),
                        dateFecha.Value.Date.ToString("dd/MM/yyyy"));
                varfNuevo++;
                dgvPersonal.Rows.Remove(row);
            }


            /////////////////////////////////////////

            BL_CUADRILLA objCuadrilla = new BL_CUADRILLA();
            DataTable dtResultado = new DataTable();
            dtResultado = objCuadrilla.SP_LISTAR_CUADRILLA_OBRERO(Convert.ToInt32 (cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateFecha.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {
                objTareo = new BE_ASIGNACION_TAREO();
                objTareo.IDE_EMPRESA = cboEmpresa.SelectedValue.ToString();
                objTareo.IDE_CECOS = cboCentroCosto.SelectedValue.ToString();
                objTareo.FEC_TAREO = dateFecha.Value.Date.ToString("dd/MM/yyyy");

                frmCuadrillaObrero f2 = new frmCuadrillaObrero(); //creamos un objeto del formulario hijo
                DialogResult res = f2.ShowDialog();
                if (f2.varCuadrilla > 0)
                {
                    listarCuadrilla();
                    Cantidad();
                }
                else
                {
                    listarCuadrilla();
                    Cantidad();
                }
            }
            
            else
            {
                listarCuadrilla();
                Cantidad();
            }
            //////////////////////////////////////

            //listarCuadrilla();
            //Cantidad();
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            //if (txtApellidos.Text != string.Empty)
            //{
                DataTable dt = dtResulDisponible as DataTable;
                DataView dv = dt.DefaultView;
                dv.RowFilter = "Personal LIKE '%" + txtApellidos.Text + "%'";
                //dgvPersonal.DataSource = dv;

                dgvPersonal.Rows.Clear();
                dgvPersonal.Refresh();
                dgvPersonal.DataSource = null;
                dgvPersonal.Columns.Clear();

                dgvPersonal.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "Item";
                checkBoxColumn.ToolTipText = "Disponible";
                checkBoxColumn.Width = 50;
                checkBoxColumn.Name = "Seleccion";
                dgvPersonal.Columns.Insert(0, checkBoxColumn);

                DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                colItem.Name = "Nro";
                colItem.HeaderText = "N°";
                colItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colItem.Width = 30;

                dgvPersonal.Columns.Insert(1, colItem);

                DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.Name = "Nombre";
                colNombre.HeaderText = "Personal Disponible";
                colNombre.Width = 300;
                dgvPersonal.Columns.Insert(2, colNombre);

               

                DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
                colCategoria.Name = "Categoria";
                colCategoria.HeaderText = "Categoria";
                colCategoria.Width = 140;
                dgvPersonal.Columns.Insert(3, colCategoria);

                DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
                colIdPersona.Name = "idePersonal";
                colIdPersona.HeaderText = "idePersonal";
                colIdPersona.Width = 30;
                dgvPersonal.Columns.Insert(4, colIdPersona);

                DataGridViewTextBoxColumn colAsignado = new DataGridViewTextBoxColumn();
                colAsignado.Name = "ideAsignado";
                colAsignado.HeaderText = "ideAsignado";
                colAsignado.Width = 30;
                dgvPersonal.Columns.Insert(5, colAsignado);

                dgvPersonal.Columns["ideAsignado"].Visible = false;
                dgvPersonal.Columns["idePersonal"].Visible = false;
                string FLG_LIBRE, ITEM, Personal, CATEGORIA, IDE_PERSONAL, ASIGNADO;

            string[] Xrow;
                for (int i = 0; i < dv.Count ; i++)
                {
                    FLG_LIBRE = dv[i]["SELECCIONAR"].ToString();
                    Personal = dv[i]["Personal"].ToString();
                    IDE_PERSONAL = dv[i]["IDE_PERSONAL"].ToString();
                    ASIGNADO = dv[i]["CantidadAsignacion"].ToString();
                    ITEM = dtResulDisponible.Rows[i]["ITEM"].ToString();
                    CATEGORIA = dtResulDisponible.Rows[i]["CATEGORIA"].ToString();
                Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (),ITEM, Personal,CATEGORIA, IDE_PERSONAL,ASIGNADO
                };
                    dgvPersonal.Rows.Add(Xrow);
                    //dgvPersonal.DataSource = dv;
                }


            foreach (DataGridViewRow row in dgvPersonal.Rows)
            {
                if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 0)// asignado a cuadrilla
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                else if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 195, 0);
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            listarPersonalDisponible();
            listarCuadrilla();
        }
        protected void Cantidad()
        {
            int cantidadDisponible = 0;
            int cantidadAsignado = 0;
            int cantidadAsignadoVarios = 0;
            foreach (DataGridViewRow row in dgvPersonal.Rows)
            {
                if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 0)// asignado a cuadrilla
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    cantidadDisponible ++;
                }
                else if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                    cantidadAsignado++;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
                    cantidadAsignadoVarios++;
                }
            }
            lblAsignado.Text = "Asignados (" + cantidadAsignado.ToString() + ")";
            lblAsignadoVarios.Text = "Asignados Varios (" + cantidadAsignadoVarios.ToString() + ")";
            lblDisponible.Text = "Disponibles (" + cantidadDisponible.ToString() + ")";
            txtCantidadAsignada.Text = dgvCuadrilla.Rows.Count.ToString();
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            listarPersonalDisponible();
            listarCuadrilla();

        }

        private void frmCuadrilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            idEmpresa =string.Empty ;
            idCentro = string.Empty;
            idfecha = string.Empty;
        }

        private void btnVarios_Click(object sender, EventArgs e)
        {
            BL_CUADRILLA objCuadrilla = new BL_CUADRILLA();
            DataTable dtResultado = new DataTable();
            dtResultado = objCuadrilla.SP_LISTAR_CUADRILLA_OBRERO(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateFecha.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {
                objTareo = new BE_ASIGNACION_TAREO();
                objTareo.IDE_EMPRESA = cboEmpresa.SelectedValue.ToString();
                objTareo.IDE_CECOS = cboCentroCosto.SelectedValue.ToString();
                objTareo.FEC_TAREO = dateFecha.Value.Date.ToString("dd/MM/yyyy");

                frmCuadrillaObrero f2 = new frmCuadrillaObrero(); //creamos un objeto del formulario hijo
                DialogResult res = f2.ShowDialog();
                if (f2.varCuadrilla > 0)
                {
                    listarCuadrilla();
                    Cantidad();
                }
                else
                {
                    listarCuadrilla();
                    Cantidad();
                }
            }
            else
            {

                MessageBox.Show("No existe personal en más de una cuadrilla " + dateFecha.Value.Date.ToString("dd/MM/yyyy"), "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
