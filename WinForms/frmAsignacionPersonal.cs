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
    public partial class frmAsignacionPersonal : Form
    {
        DataTable dtResulDisponible;
        public static BE_ASIGNACION_TAREAS obj_asignacion_E;
        DataView dv;
        public frmAsignacionPersonal()
        {
            InitializeComponent();
            ListarEmpresa();
            ListarCategoria();
        }

        private void frmAsignacionPersonal_Load(object sender, EventArgs e)
        {

        }
        protected void ListarCategoria()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarParametros("PERSONAL", "IDE_GRUPO");
            if (dtResultado.Rows.Count > 0)
            {

                cboCategoria.ValueMember = "IDE_PARAMETRO";
                cboCategoria.DisplayMember = "DES_ASUNTO";
                cboCategoria.DataSource = dtResultado;

            }
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
                ListarCesos();
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
                //listarCuadrilla();
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarPersonalCategoria();
            listarCuadrilla();
           
        }
        private BE_PERSONAL f_datos(int estado, string TIPO_TRABAJADOR)
        {
            BE_PERSONAL Obj = new BE_PERSONAL();
            Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            Obj.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            Obj.TIPO_TRABAJADOR = TIPO_TRABAJADOR;
            return Obj;
        }
        protected void listarCuadrilla()
        {
            BE_PERSONAL obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();
            string TipoTrabajador = string.Empty;
            if (rdoEmpleado.Checked )
            {
                TipoTrabajador = "01";
            }
            else
            {
                TipoTrabajador = "02";
            }


            obj = f_datos(0, TipoTrabajador);

            dgvCuadrilla.Rows.Clear();
            dgvCuadrilla.Refresh();
            dgvCuadrilla.DataSource = null;
            dgvCuadrilla.Columns.Clear();

            dgvCuadrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Seleccion";
            dgvCuadrilla.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Personal";
            colNombre.Width = 300;
            dgvCuadrilla.Columns.Insert(1, colNombre);



            DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
            colIdPersona.Name = "idePersonal";
            colIdPersona.HeaderText = "idePersonal";
            colIdPersona.Width = 30;
            dgvCuadrilla.Columns.Insert(2, colIdPersona);

            DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
            colCategoria.Name = "Categoria";
            colCategoria.HeaderText = "Categoria";
            colCategoria.Width = 120;
            dgvCuadrilla.Columns.Insert(3, colCategoria);


            DataGridViewTextBoxColumn colAsignado = new DataGridViewTextBoxColumn();
            colAsignado.Name = "ideAsignado";
            colAsignado.HeaderText = "ideAsignado";
            colAsignado.Width = 30;
            dgvCuadrilla.Columns.Insert(4, colAsignado);

            if (rdoObreros.Checked)
            {
                dgvCuadrilla.Columns["Categoria"].Visible = true ;
            }
            else
            {
                dgvCuadrilla.Columns["Categoria"].Visible = false ;
            }

            dgvCuadrilla.Columns["ideAsignado"].Visible = false;
            dgvCuadrilla.Columns["idePersonal"].Visible = false;

            DataTable dtResultado = new DataTable();
            dtResultado = objPersona.Listar_PersonalCC(obj);
            dtResulDisponible = objPersona.Listar_PersonalCC(obj);
            dv = dtResulDisponible.DefaultView;
            int cantidadDisponible = 0;
            int cantidadAsignado = 0;
            int cantidad = dtResulDisponible.Rows.Count;
            if (dtResultado.Rows.Count > 0)
            {
                string FLG_LIBRE, Personal, IDE_PERSONAL, CATEGORIA, IDE_ASIGNADO;
                string[] Xrow;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    FLG_LIBRE = dtResultado.Rows[i]["SELECCIONAR"].ToString();
                    Personal = dtResultado.Rows[i]["Personal"].ToString();
                    IDE_PERSONAL = dtResultado.Rows[i]["IDE_PERSONAL"].ToString();
                    IDE_ASIGNADO = dtResultado.Rows[i]["Asignado"].ToString();
                    CATEGORIA = dtResultado.Rows[i]["CATEGORIA"].ToString();
                    Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (), Personal, IDE_PERSONAL,CATEGORIA, IDE_ASIGNADO
                };
                    dgvCuadrilla.Rows.Add(Xrow);
                }


                foreach (DataGridViewRow row in dgvCuadrilla.Rows)
                {
                    if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 0)// asignado a categoria
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        cantidadDisponible++;

                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);

                        cantidadAsignado++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Falta migracion personal, ingresar a la opcion 'MIGRAR PERSONAL' ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            lblAsignado.Text = "Asignados (" + cantidadAsignado.ToString() + ")" ;
            lblDisponible.Text = "Disponibles (" + cantidadDisponible.ToString() + ")";

        }
        protected void Cantidad()
        {
            int cantidadDisponible = 0;
            int cantidadAsignado = 0;
            foreach (DataGridViewRow row in dgvCuadrilla.Rows)
            {
                if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 0)// asignado a categoria
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    cantidadDisponible++;

                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);

                    cantidadAsignado++;
                }
            }
            lblAsignado.Text = "Asignados (" + cantidadAsignado.ToString() + ")";
            lblDisponible.Text = "Disponibles (" + cantidadDisponible.ToString() + ")";
            txtCantidadAsignada.Text = dgvPersonal.Rows.Count.ToString();
        }
        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            int cantidad = dtResulDisponible.Rows.Count;
            //DataTable dt = dtResulDisponible as DataTable;
            dv = dtResulDisponible.DefaultView;
            dv.RowFilter = "Personal LIKE '%" + txtApellidos.Text + "%'";
            //dgvPersonal.DataSource = dv;

            dgvCuadrilla.Rows.Clear();
            dgvCuadrilla.Refresh();
            dgvCuadrilla.DataSource = null;
            dgvCuadrilla.Columns.Clear();

            dgvCuadrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.ToolTipText = "Disponible";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Seleccion";
            dgvCuadrilla.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Personal Disponible";
            colNombre.Width = 300;
            dgvCuadrilla.Columns.Insert(1, colNombre);

            DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
            colCategoria.Name = "Categoria";
            colCategoria.HeaderText = "Categoria";
            colCategoria.Width = 120;
            dgvCuadrilla.Columns.Insert(2, colCategoria);

            DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
            colIdPersona.Name = "idePersonal";
            colIdPersona.HeaderText = "idePersonal";
            colIdPersona.Width = 30;
            dgvCuadrilla.Columns.Insert(3, colIdPersona);

            DataGridViewTextBoxColumn colAsignado = new DataGridViewTextBoxColumn();
            colAsignado.Name = "ideAsignado";
            colAsignado.HeaderText = "ideAsignado";
            colAsignado.Width = 30;
            dgvCuadrilla.Columns.Insert(4, colAsignado);


            if (rdoObreros.Checked)
            {
                dgvCuadrilla.Columns["Categoria"].Visible = true;
            }
            else
            {
                dgvCuadrilla.Columns["Categoria"].Visible = false ;
            }

            dgvCuadrilla.Columns["idePersonal"].Visible = false;
            dgvCuadrilla.Columns["ideAsignado"].Visible = false;

            string FLG_LIBRE, Personal, CATEGORIA, IDE_PERSONAL, IDE_ASIGNADO;
            string[] Xrow;
            for (int i = 0; i < dv.Count; i++)
            {
                FLG_LIBRE = dv[i]["SELECCIONAR"].ToString();
                Personal = dv[i]["Personal"].ToString();
                IDE_PERSONAL = dv[i]["IDE_PERSONAL"].ToString();
                CATEGORIA = dv[i]["CATEGORIA"].ToString();
                IDE_ASIGNADO = dv[i]["Asignado"].ToString();
                Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (), Personal,CATEGORIA, IDE_PERSONAL,IDE_ASIGNADO
                };
                dgvCuadrilla.Rows.Add(Xrow);
                //dgvPersonal.DataSource = dv;
            }
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
            foreach (DataGridViewRow row in dgvCuadrilla.Rows)
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


            foreach (DataGridViewRow row in rowSelected)
            {
                dgvPersonal.Rows.Add(new object[] {false,
                                                    row.Cells["Nombre"].Value,
                                                    row.Cells["idePersonal"].Value,
                                                    row.Cells["Categoria"].Value});
                obj.UpdateCategoria(
                        Convert.ToInt32(row.Cells["idePersonal"].Value.ToString()),
                        Convert.ToInt32(cboCategoria.SelectedValue),
                        cboCentroCosto.SelectedValue.ToString () 
                        );

                dgvCuadrilla.Rows.Remove(row);
            }
            Cantidad();
        }
        protected void listarPersonalCategoria()
        {
            BE_PERSONAL Obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();

            Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            Obj.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            Obj.IDE_GRUPO = Convert.ToInt32(cboCategoria.SelectedValue.ToString());

            dgvPersonal.Rows.Clear();
            dgvPersonal.Refresh();
            dgvPersonal.DataSource = null;
            dgvPersonal.Columns.Clear();

            dgvPersonal.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.ToolTipText = "Disponible";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Quitar";
            dgvPersonal.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Personal";
            colNombre.Width = 300;
            dgvPersonal.Columns.Insert(1, colNombre);

            DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
            colIdPersona.Name = "idePersonal";
            colIdPersona.HeaderText = "idePersonal";
            colIdPersona.Width = 30;
            dgvPersonal.Columns.Insert(2, colIdPersona);


            DataGridViewTextBoxColumn colCATEGORIA = new DataGridViewTextBoxColumn();
            colCATEGORIA.Name = "Categoria";
            colCATEGORIA.HeaderText = "Categoria";
            colCATEGORIA.Width = 120;
            dgvPersonal.Columns.Insert(3, colCATEGORIA);


            if (cboCategoria.SelectedIndex == 0)
            {
                dgvPersonal.Columns["Categoria"].Visible = false;
            }
            else
            {
                dgvPersonal.Columns["Categoria"].Visible = true ;
            }

            dgvPersonal.Columns["idePersonal"].Visible = false;

            DataTable dtResultado = new DataTable();
            dtResultado = objPersona.Listar_PersonalGrupo(Obj);
            if (dtResultado.Rows.Count > 0)
            {
                txtCantidadAsignada.Text = dtResultado.Rows.Count.ToString();
                string FLG_LIBRE, Personal, IDE_PERSONAL, CATEGORIA;
                string[] Xrow;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    FLG_LIBRE = dtResultado.Rows[i]["SELECCIONAR"].ToString();// Convert.ToString(i + 1);
                    Personal = dtResultado.Rows[i]["Personal"].ToString();
                    IDE_PERSONAL = dtResultado.Rows[i]["IDE_PERSONAL"].ToString();
                    CATEGORIA = dtResultado.Rows[i]["CATEGORIA"].ToString();

                    Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (), Personal, IDE_PERSONAL,CATEGORIA
                };
                    dgvPersonal.Rows.Add(Xrow);
                }
            }
            else
            {
                txtCantidadAsignada.Text = string.Empty;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("El personal seleccionado tendra como último día de trabajo la fecha " + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy") + ", continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                if (cboCategoria.SelectedIndex == 0)
                {
                    QuitarPersonal();
                }
                else if (cboCategoria.SelectedIndex == 1)
                {
                    QuitarPersonal();
                }
            }
              
        }
        protected void QuitarPersonal()
        {
            BL_PERSONAL obj = new BL_PERSONAL();
            BL_ASIGNACION_TAREAS objAsignacion = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgvPersonal.Rows)
            {
                DataGridViewCheckBoxCell cellSelecion = row.Cells["Quitar"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    rowSelected.Add(row);
                }
            }

            foreach (DataGridViewRow row in rowSelected)
            {


                dtResultado = obj.uspREVISAR_EQUIPO_TRABAJO(Convert.ToInt32(row.Cells["idePersonal"].Value.ToString()), Convert.ToInt32( cboCategoria.SelectedValue), cboCentroCosto.SelectedValue.ToString());
                if (dtResultado.Rows.Count > 0)
                {
                    if ( Convert.ToInt32( dtResultado.Rows[0]["CANTIDAD"].ToString()) == 0)
                    {
                        obj.uspRITERAR_EQUIPO_TRABAJO(Convert.ToInt32(row.Cells["idePersonal"].Value.ToString()), Convert.ToInt32(cboCategoria.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));

                        dgvCuadrilla.Rows.Add(new object[] {false,
                                                    row.Cells["Nombre"].Value,
                                                    row.Cells["idePersonal"].Value,
                                                    row.Cells["Categoria"].Value});
                        dgvPersonal.Rows.Remove(row);

                       
                    }
                    else
                    {
                        string Msg= "El Sr. " + row.Cells["Nombre"].Value.ToString() + Environment.NewLine + " tiene personal a su cargo";
                        DialogResult respuesta = MessageBox.Show(Msg + Environment.NewLine + "¿Desea continuar con la eliminación de cargo o dar clic en el botón delegar cuadrilla?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (respuesta == DialogResult.Yes)
                        {
                            obj.uspRITERAR_EQUIPO_TRABAJO(Convert.ToInt32(row.Cells["idePersonal"].Value.ToString()), Convert.ToInt32(cboCategoria.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));

                            dgvCuadrilla.Rows.Add(new object[] {false,
                                                    row.Cells["Nombre"].Value,
                                                    row.Cells["idePersonal"].Value,
                                                    row.Cells["Categoria"].Value});
                            dgvPersonal.Rows.Remove(row);
                        }
                           
                    }
                }
            }
            Cantidad();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPersonalCategoria();
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            new frmAsociarPersonal().ShowDialog();
        }

        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listarCuadrilla();
                listarPersonalCategoria();
            }
            catch (Exception ex)
            { }
        }

        private void rdoObreros_CheckedChanged(object sender, EventArgs e)
        {
            listarCuadrilla();
            listarPersonalCategoria();
        }

        private void rdoEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            listarCuadrilla();
            listarPersonalCategoria();
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            obj_asignacion_E = new BE_ASIGNACION_TAREAS();
            obj_asignacion_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            obj_asignacion_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
           


            frmLiberarResponsable f2 = new frmLiberarResponsable(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
            if (f2.varfMigracion > 0)
            {
                listarPersonalCategoria();
                listarCuadrilla();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            new frmAsociarPersonal().ShowDialog();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            obj_asignacion_E = new BE_ASIGNACION_TAREAS();
            obj_asignacion_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            obj_asignacion_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();



            frmAsignarNuevoResponsable f2 = new frmAsignarNuevoResponsable(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
            if (f2.varfMigracion > 0)
            {
                listarPersonalCategoria();
                listarCuadrilla();
            }
        }

        private void btnCambio_Click(object sender, EventArgs e)
        {
            obj_asignacion_E = new BE_ASIGNACION_TAREAS();
            obj_asignacion_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            obj_asignacion_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();



            frmCambiarResponsables f2 = new frmCambiarResponsables(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
            //if (f2.varfNuevo > 0)
            //{
            //    //listarPersonalCategoria();
            //    //listarCuadrilla();
            //}
        }
    }
}
