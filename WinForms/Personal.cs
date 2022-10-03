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
    public partial class Personal : Form
    {
        DataTable dtResulDisponible;
        string tipoPersonal;
        DataView dv;
        public Personal()
        {
            InitializeComponent();
            ListarEmpresa();
            Etiqueta();
            ListarEstados();
            cboEstado.SelectedIndex = 0;
        }

        private void Personal_Load(object sender, EventArgs e)
        {

        }

        private void ListarEstados()
        {
            //Vaciar comboBox para que los items que vamos a añadir no se repitan
            cboEstado.Items.Clear();

            //Incluir dos items Hombre y Mujer
            cboEstado.Items.Add(new KeyValuePair<string, string>("1", "PERSONAL ACTIVO"));
            cboEstado.Items.Add(new KeyValuePair<string, string>("2", "PERSONAL BLOQUEADO"));
        }
       
        protected void Etiqueta()
        {
            if (cboEstado.SelectedIndex ==0  )
            {
                btnEstados.Text = "Bloquear Personal".ToUpper();
               
               

            }
            else
            {
                btnEstados.Text = "Habilitar Personal".ToUpper();
               
               

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

            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void btnlistarPersonal_Click(object sender, EventArgs e)
        {
            tipoPersonal = "01";
            listarCuadrilla("01");
            Etiqueta();
        }

        private void btnListarObreros_Click(object sender, EventArgs e)
        {
            tipoPersonal = "02";
            listarCuadrilla("02");
            Etiqueta();
        }
        protected void EstructuraGrilla()
        {
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

            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Nro";
            colItem.HeaderText = "Nro";
            colItem.Width = 50;
            colItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuadrilla.Columns.Insert(1, colItem);

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

            DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
            colCategoria.Name = "Categoria";
            colCategoria.HeaderText = "Categoria";
            colCategoria.Width = 120;
            dgvCuadrilla.Columns.Insert(4, colCategoria);

            DataGridViewTextBoxColumn colEspecialidad = new DataGridViewTextBoxColumn();
            colEspecialidad.Name = "Especialidad";
            colEspecialidad.HeaderText = "Especialidad";
            colEspecialidad.Width = 120;
            dgvCuadrilla.Columns.Insert(5, colEspecialidad);


            DataGridViewTextBoxColumn colAsignado = new DataGridViewTextBoxColumn();
            colAsignado.Name = "ideAsignado";
            colAsignado.HeaderText = "ideAsignado";
            colAsignado.Width = 30;
            dgvCuadrilla.Columns.Insert(6, colAsignado);


            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
            colEstado.Name = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.Width = 80;
            colEstado.DefaultCellStyle.BackColor = Color.Yellow;
            colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuadrilla.Columns.Insert(7, colEstado);

            DataGridViewTextBoxColumn colCapataz = new DataGridViewTextBoxColumn();
            colCapataz.Name = "Capataz";
            colCapataz.HeaderText = "Capataz";
            colCapataz.Width = 300;

            dgvCuadrilla.Columns.Insert(8, colCapataz);

            DataGridViewTextBoxColumn colFECHA_INGRESO = new DataGridViewTextBoxColumn();
            colFECHA_INGRESO.Name = "FECHA_INGRESO";
            colFECHA_INGRESO.HeaderText = "Fec. Ingreso";
            colFECHA_INGRESO.Width = 120;
            colFECHA_INGRESO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuadrilla.Columns.Insert(9, colFECHA_INGRESO);


            DataGridViewTextBoxColumn colFECHA_CESE = new DataGridViewTextBoxColumn();
            colFECHA_CESE.Name = "FECHA_INGRESO";
            colFECHA_CESE.HeaderText = "Fec. Cese";
            colFECHA_CESE.Width = 120;
            colFECHA_CESE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuadrilla.Columns.Insert(10, colFECHA_CESE);


        }
        protected void listarCuadrilla(string TipoTrabajador)
        {
            BE_PERSONAL Obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();

       
            Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            Obj.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            Obj.TIPO_TRABAJADOR = TipoTrabajador;

            Boolean FLG_ESTADOS = true;
            if (cboEstado.SelectedIndex==1)
            {
                FLG_ESTADOS = false;
            }

            Obj.FLG_ESTADOS = FLG_ESTADOS;

            EstructuraGrilla();

            if (TipoTrabajador == "02")
            {
                dgvCuadrilla.Columns["Categoria"].Visible = true;
                dgvCuadrilla.Columns["Especialidad"].Visible = true;
                dgvCuadrilla.Columns["Capataz"].Visible = true;
            }
            else
            {
                dgvCuadrilla.Columns["Categoria"].Visible = false;
                dgvCuadrilla.Columns["Especialidad"].Visible = false;
                dgvCuadrilla.Columns["Capataz"].Visible = false;
            }

            dgvCuadrilla.Columns["ideAsignado"].Visible = false;
            dgvCuadrilla.Columns["idePersonal"].Visible = false;

            DataTable dtResultado = new DataTable();
            dtResultado = objPersona.Listar_Personal_Estados(Obj);
            dtResulDisponible = objPersona.Listar_Personal_Estados(Obj);
            dv = dtResulDisponible.DefaultView;

            int cantidad = dtResulDisponible.Rows.Count;
            if (dtResultado.Rows.Count > 0)
            {
                string FLG_LIBRE,ROW, Personal, IDE_PERSONAL, CATEGORIA, ESPECIALIDAD, IDE_ASIGNADO, ESTADO,CAPATAZ, FECHA_INGRESO, FECHA_CESE;
                string[] Xrow;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    FLG_LIBRE = dtResultado.Rows[i]["SELECCIONAR"].ToString();
                    Personal = dtResultado.Rows[i]["Personal"].ToString();
                    IDE_PERSONAL = dtResultado.Rows[i]["IDE_PERSONAL"].ToString();
                    IDE_ASIGNADO = dtResultado.Rows[i]["Asignado"].ToString();
                    CATEGORIA = dtResultado.Rows[i]["CATEGORIA"].ToString();
                    ESPECIALIDAD = dtResultado.Rows[i]["ESPECIALIDAD"].ToString();
                    ESTADO = dtResultado.Rows[i]["Estado"].ToString();
                    ROW = dtResultado.Rows[i]["Row"].ToString();
                    CAPATAZ = dtResultado.Rows[i]["NOMBRE_CAPATAZ"].ToString();
                    FECHA_INGRESO = dtResultado.Rows[i]["FECHA_INGRESO"].ToString();
                    FECHA_CESE = dtResultado.Rows[i]["FECHA_CESE"].ToString();
                    Xrow = new string[] {
                       Convert.ToBoolean(FLG_LIBRE).ToString (), ROW,Personal, IDE_PERSONAL,CATEGORIA,ESPECIALIDAD, IDE_ASIGNADO,ESTADO,CAPATAZ,FECHA_INGRESO,FECHA_CESE
                };
                    dgvCuadrilla.Rows.Add(Xrow);
                }


                Cantidad();
            }
            else
            {
                MessageBox.Show("No registra Informacion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            

        }
        protected void Cantidad()
        {
            int cantidadDisponible = 0;
            int cantidadAsignado = 0;

            foreach (DataGridViewRow row in dgvCuadrilla.Rows)
            {
                if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 1)// libres
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
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnEstados_Click(object sender, EventArgs e)
        {

            int estado = 1;
            string mensaje = string.Empty;
            if (cboEstado.SelectedIndex==0)
            {
                estado = 0;
                mensaje = "¿Desea bloquear personal con fecha " + dateLiquidado.Value.Date.ToString("dd/MM/yyyy") + "?";
            }
            else
            {
                estado = 1;
                mensaje = "¿Desea habilitar personal con fecha " + dateLiquidado.Value.Date.ToString("dd/MM/yyyy") + "?" ;
            }

            DialogResult respuesta = MessageBox.Show(mensaje, "Grabar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {

                int cantidad = 0;
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

                //
                // Se agrega el item seleccionado a la grilla de destino
                // eliminando la fila de la grilla original
                //
                foreach (DataGridViewRow row in rowSelected)
                {
                    cantidad++;
                    obj.UpdateEstadoPersonal(
                            cboCentroCosto.SelectedValue.ToString(),
                            Convert.ToInt32(row.Cells["idePersonal"].Value.ToString()),
                            Convert.ToInt32(cboEmpresa.SelectedValue),
                            estado,
                            dateLiquidado.Value.Date.ToString("dd/MM/yyyy")
                            );

                    dgvCuadrilla.Rows.Remove(row);
                }

                if (cantidad > 0)
                {
                    listarCuadrilla(tipoPersonal);
                    MessageBox.Show("Actualización correcta", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Falta seleccionar personal", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void checkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTodos.Checked  == false )
            {
                foreach (DataGridViewRow row in dgvCuadrilla.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value == chk.TrueValue)
                    {
                        chk.Value = chk.FalseValue;
                    }
                    else
                    {
                        chk.Value = chk.TrueValue;
                    }
                }
                //checkTodos.Checked = false;
                //checkTodos.Checked = 0;
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dgvCuadrilla.Rows)
                {
                    dgvCuadrilla.Rows[row.Index].SetValues(true);
                }
                //checkTodos.Checked = true;
                //chkInt = dgvCuadrilla.Rows.Count;
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = dtResulDisponible as DataTable;
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Personal LIKE '%" + txtApellidos.Text + "%'";

            EstructuraGrilla();

            if (tipoPersonal == "02")
            {
                dgvCuadrilla.Columns["Categoria"].Visible = true;
                dgvCuadrilla.Columns["Especialidad"].Visible = true;
                dgvCuadrilla.Columns["Capataz"].Visible = true;
            }
            else
            {
                dgvCuadrilla.Columns["Categoria"].Visible = false;
                dgvCuadrilla.Columns["Especialidad"].Visible = false;
                dgvCuadrilla.Columns["Capataz"].Visible = false;
            }

            dgvCuadrilla.Columns["ideAsignado"].Visible = false;
            dgvCuadrilla.Columns["idePersonal"].Visible = false;

          string FLG_LIBRE, ROW, Personal, IDE_PERSONAL, CATEGORIA, ESPECIALIDAD, IDE_ASIGNADO, ESTADO, CAPATAZ;
                string[] Xrow;
                for (int i = 0; i < dv.Count; i++)
                {
                    FLG_LIBRE = dv[i]["SELECCIONAR"].ToString();
                    Personal = dv[i]["Personal"].ToString();
                    IDE_PERSONAL = dv[i]["IDE_PERSONAL"].ToString();
                    IDE_ASIGNADO = dv[i]["Asignado"].ToString();
                    CATEGORIA = dv[i]["CATEGORIA"].ToString();
                    ESPECIALIDAD = dv[i]["ESPECIALIDAD"].ToString();
                    ESTADO = dv[i]["Estado"].ToString();
                    ROW = dv[i]["Row"].ToString();
                    CAPATAZ = dv[i]["NOMBRE_CAPATAZ"].ToString();
                    Xrow = new string[] {
                       Convert.ToBoolean(FLG_LIBRE).ToString (), ROW,Personal, IDE_PERSONAL,CATEGORIA,ESPECIALIDAD, IDE_ASIGNADO,ESTADO,CAPATAZ
                };
                    dgvCuadrilla.Rows.Add(Xrow);
                }


                Cantidad();
            
        }

     

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Etiqueta();
        }
    }
}
