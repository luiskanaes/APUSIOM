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
namespace WinForms
{
    public partial class frmLiberarResponsable : Form
    {
        public int varfMigracion;
        public frmLiberarResponsable()
        {
            InitializeComponent();
            ListarCategoria();
            listarCuadrilla();
        }

        private void frmLiberarResponsable_Load(object sender, EventArgs e)
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

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPersonalCategoria();
            
        }
        protected void listarPersonalCategoria()
        {
            BE_PERSONAL Obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();

            Obj.IDE_EMPRESA = Convert.ToInt32(frmAsignacionPersonal.obj_asignacion_E.IDE_EMPRESA);
            Obj.CENTRO_COSTO = frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO ;
            Obj.IDE_GRUPO = Convert.ToInt32(cboCategoria.SelectedValue.ToString());



            BL_PERSONAL obj = new BL_PERSONAL();
            DataTable dtResul = new DataTable();

            if (cboCategoria.SelectedIndex == 0)
            {
                cboPersonal.Visible = true;
                rdoObreros.Enabled = false;
                rdoEmpleado.Checked = true;

                dtResul = obj.SP_OBTENER_EQUIPO_TRABAJO(frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO, "1", "", 1);
            }
            else if (cboCategoria.SelectedIndex == 1)
            {
                cboPersonal.Visible = true;
                rdoObreros.Enabled = true;

                dtResul = obj.SP_OBTENER_EQUIPO_TRABAJO(frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO, "1", "", 2);
            }
            else
            {
                cboPersonal.Visible = true;
                rdoObreros.Enabled = false;
                rdoObreros.Enabled = true;
            }

            if (dtResul.Rows.Count > 0)
            {
                cboPersonal.Visible = true;
                cboPersonal.ValueMember = "IDE_PERSONAL";
                cboPersonal.DisplayMember = "NOMBRES";
                cboPersonal.DataSource = dtResul;


            }
        }

        private void rdoEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            listarCuadrilla();
         
        }

        private void rdoObreros_CheckedChanged(object sender, EventArgs e)
        {
            listarCuadrilla();
           
        }
        private BE_PERSONAL f_datos(int estado, string TIPO_TRABAJADOR)
        {
            BE_PERSONAL Obj = new BE_PERSONAL();
            Obj.IDE_EMPRESA = Convert.ToInt32(frmAsignacionPersonal.obj_asignacion_E.IDE_EMPRESA);
            Obj.CENTRO_COSTO = frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO;
            Obj.TIPO_TRABAJADOR = TIPO_TRABAJADOR;
            return Obj;
        }
        protected void listarCuadrilla()
        {
            BE_PERSONAL obj = new BE_PERSONAL();
            BL_PERSONAL objPersona = new BL_PERSONAL();
            string TipoTrabajador = string.Empty;
            if (rdoEmpleado.Checked)
            {
                TipoTrabajador = "01";
            }
            else
            {
                TipoTrabajador = "02";
            }

            DataTable dtResultado = new DataTable();
            obj = f_datos(0, TipoTrabajador);
            dtResultado = objPersona.uspSEL_PERSONAL_EMPRESA_CC_TIPO(obj);
            if (dtResultado.Rows.Count > 0)
            {
                cboNuevoEncargado.Visible = true;
                cboNuevoEncargado.ValueMember = "IDE_PERSONAL";
                cboNuevoEncargado.DisplayMember = "Personal";
                cboNuevoEncargado.DataSource = dtResultado;

            }
            else
            {
                cboNuevoEncargado.Visible = false;
            }

        }

     

        private void btnBuscar_Click(object sender, EventArgs e)
        {//MI CUADRILLA

            CargarPersonal_a_Liberar();
            //NUEVO
            cargarPersonalAsignado();
        }
        protected void CargarPersonal_a_Liberar()
        {
            string IDE_CAPATAZ, IDE_INGCAMPO, FECHA;
            FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");

            if (cboCategoria.SelectedIndex == 0)
            {

                IDE_CAPATAZ = "";
                IDE_INGCAMPO = cboPersonal.SelectedValue.ToString();

                listarCuadrillaTrabajo(IDE_CAPATAZ, IDE_INGCAMPO, FECHA);
            }
            else if (cboCategoria.SelectedIndex == 1)
            {
                IDE_INGCAMPO = "";
                IDE_CAPATAZ = cboPersonal.SelectedValue.ToString();

                listarCuadrillaTrabajo(IDE_CAPATAZ, IDE_INGCAMPO, FECHA);
            }

          
            else
            {
                MessageBox.Show("Operación no permitida", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
        protected void listarCuadrillaTrabajo(string IDE_CAPATAZ, string IDE_INGCAMPO, string FECHA)
        {
           
            BL_PERSONAL objPersona = new BL_PERSONAL();
           

            dgvCuadrilla.Rows.Clear();
            dgvCuadrilla.Refresh();
            dgvCuadrilla.DataSource = null;
            dgvCuadrilla.Columns.Clear();

            dgvCuadrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Seleccionar";
            dgvCuadrilla.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colOrden = new DataGridViewTextBoxColumn();
            colOrden.Name = "Row";
            colOrden.HeaderText = "N°";
            colOrden.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colOrden.Width = 50;
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


            DataTable dtResultado = new DataTable();
            dtResultado = objPersona.SP_OBTENER_PERSONAL_ASIGNADO(
                frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO,
                IDE_CAPATAZ, 
                FECHA,
                IDE_INGCAMPO,
                cboCategoria.SelectedValue.ToString()
                );
            if (dtResultado.Rows.Count > 0)
            {
                string FLG_LIBRE, Row, Personal, IDE_PERSONAL;
                string[] Xrow;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    FLG_LIBRE = dtResultado.Rows[i]["SELECCIONAR"].ToString();
                    Personal = dtResultado.Rows[i]["Personal"].ToString();
                    IDE_PERSONAL = dtResultado.Rows[i]["IDE_PERSONAL"].ToString();
                 
                    Row = dtResultado.Rows[i]["Row"].ToString();
                    Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (),Row, Personal, IDE_PERSONAL, 
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedIndex == 2)
            {
                MessageBox.Show("Categoria no permitida", "Advertencia Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Desea realizar la asignación?" + " " + Environment.NewLine +
                    "A partir de la fecha " + dateFechaAsigna.Value.Date.ToString("dd/MM/yyyy") + " el Sr. " + Environment.NewLine +
                    cboNuevoEncargado.Text + " " + Environment.NewLine + " asume responsabilidades. "
                    , "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    agregar();
                }
            }
        }
        protected void agregar()
        {
            BL_PERSONAL objPersona = new BL_PERSONAL();
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
                DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccionar"] as DataGridViewCheckBoxCell;

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
                //dgvCuadrilla.Rows.Add(new object[] {false,
                //                                    row.Cells["Nombre"].Value,
                //                                    row.Cells["idePersonal"].Value});
          

                        objPersona.uspUPD_PERSONAL_CATEGORIA_CAMBIO(
                        Convert.ToInt32(cboPersonal.SelectedValue.ToString()),
                        Convert.ToInt32(cboNuevoEncargado.SelectedValue.ToString()),
                        Convert.ToInt32(cboCategoria.SelectedValue.ToString()),
                        frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO,
                        dateTareo.Value.Date.ToString("dd/MM/yyyy"),
                        Convert.ToInt32(row.Cells["idePersonal"].Value.ToString()),
                        dateFechaAsigna.Value.Date.ToString("dd/MM/yyyy")
                        );
            }


            /////////////////////////////////////////

            cargarPersonalAsignado();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int IDE_EMPRESA = Convert.ToInt32(frmAsignacionPersonal.obj_asignacion_E.IDE_EMPRESA);
            string CENTRO_COSTO = frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO;
          

            BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
            DataTable dtResultado = new DataTable();
            int rpta;


            dtResultado = obj.Listar_TareoFecha(IDE_EMPRESA, CENTRO_COSTO, dateFechaAsigna.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {
                string FLG_ESTADO = dtResultado.Rows[0]["FLG_ESTADO"].ToString(); 
                if (FLG_ESTADO == "0")
                {
                    //cerrado
                    MessageBox.Show("No se puede realizar esta operación, fecha de tareo cerrada", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    quitarResposanle();
                }
            }
            else
            {
                quitarResposanle();
                //abierto
            }
          
        }
        protected void quitarResposanle()
        {
            string IDE_CAPATAZ, IDE_INGCAMPO, FECHA;
            FECHA = dateFechaAsigna.Value.Date.ToString("dd/MM/yyyy");
            int IDE_EMPRESA = Convert.ToInt32(frmAsignacionPersonal.obj_asignacion_E.IDE_EMPRESA);
            string CENTRO_COSTO = frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO;

            if (rdoEmpleado.Checked==true)
            {
                IDE_CAPATAZ = "";
                IDE_INGCAMPO = cboNuevoEncargado.SelectedValue.ToString();
                BL_PERSONAL objPersona = new BL_PERSONAL();

                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();

                //
                // Se recorre ca registro de la grilla de origen
                //
                foreach (DataGridViewRow row in dgvNuevo.Rows)
                {
                    //
                    // Se recupera el campo que representa el checkbox, y se valida la seleccion
                    // agregandola a la lista temporal
                    //
                    DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccionar"] as DataGridViewCheckBoxCell;

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

                    objPersona.uspDELETE_EQUIPO_TRABAJO(
                    CENTRO_COSTO,
                    row.Cells["idePersonal"].Value.ToString(),
                    dateFechaAsigna.Value.Date.ToString("dd/MM/yyyy"),
                    cboNuevoEncargado.SelectedValue.ToString()
                    );
                }

                cargarPersonalAsignado();
            }

            else if (rdoObreros.Checked == true)
            {
                IDE_INGCAMPO = "";
                IDE_CAPATAZ = cboNuevoEncargado.SelectedValue.ToString();

                cargarPersonalAsignado();
            }
            
        }
        protected void cargarPersonalAsignado()
        {

            try
            {
                string IDE_CAPATAZ, IDE_INGCAMPO, FECHA;
                FECHA = dateFechaAsigna.Value.Date.ToString("dd/MM/yyyy");

                if (cboCategoria.SelectedIndex == 0)
                {
                    IDE_CAPATAZ = "";
                    IDE_INGCAMPO = cboNuevoEncargado.SelectedValue.ToString();
                    ListaPersonalAsignado(IDE_CAPATAZ, IDE_INGCAMPO, FECHA);
                }
                else if (cboCategoria.SelectedIndex == 1)
                {
                    IDE_INGCAMPO = "";
                    IDE_CAPATAZ = cboNuevoEncargado.SelectedValue.ToString();
                    ListaPersonalAsignado(IDE_CAPATAZ, IDE_INGCAMPO, FECHA);
                }
                else
                {
                    MessageBox.Show("Operación no permitida", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {

            }
            
        }
        protected void ListaPersonalAsignado(string IDE_CAPATAZ, string IDE_INGCAMPO, string FECHA)
        {

            BL_PERSONAL objPersona = new BL_PERSONAL();


            dgvNuevo.Rows.Clear();
            dgvNuevo.Refresh();
            dgvNuevo.DataSource = null;
            dgvNuevo.Columns.Clear();

            dgvNuevo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Seleccionar";
            dgvNuevo.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colOrden = new DataGridViewTextBoxColumn();
            colOrden.Name = "Row";
            colOrden.HeaderText = "N°";
            colOrden.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colOrden.Width = 50;
            dgvNuevo.Columns.Insert(1, colOrden);


            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Personal";
            colNombre.Width = 300;
            dgvNuevo.Columns.Insert(2, colNombre);

            DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
            colIdPersona.Name = "idePersonal";
            colIdPersona.HeaderText = "idePersonal";
            colIdPersona.Width = 30;
            dgvNuevo.Columns.Insert(3, colIdPersona);
            dgvNuevo.Columns["idePersonal"].Visible = false;


            DataTable dtResultado = new DataTable();
            dtResultado = objPersona.SP_OBTENER_PERSONAL_ASIGNADO(
                frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO,
                IDE_CAPATAZ,
                FECHA,
                IDE_INGCAMPO,
                cboCategoria.SelectedValue.ToString()
                );
            if (dtResultado.Rows.Count > 0)
            {
                string FLG_LIBRE, Row, Personal, IDE_PERSONAL;
                string[] Xrow;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    FLG_LIBRE = dtResultado.Rows[i]["SELECCIONAR"].ToString();
                    Personal = dtResultado.Rows[i]["Personal"].ToString();
                    IDE_PERSONAL = dtResultado.Rows[i]["IDE_PERSONAL"].ToString();

                    Row = dtResultado.Rows[i]["Row"].ToString();
                    Xrow = new string[] {
                       Convert.ToBoolean("FALSE").ToString (),Row, Personal, IDE_PERSONAL,
                    };
                    dgvNuevo.Rows.Add(Xrow);
                }

            }
            else
            {
                dgvNuevo.Rows.Clear();
                dgvNuevo.Refresh();
                dgvNuevo.DataSource = null;
                dgvNuevo.Columns.Clear();
            }

        }

        private void cboNuevoEncargado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPersonalAsignado();
        }

        private void dateFechaAsigna_ValueChanged(object sender, EventArgs e)
        {
            cargarPersonalAsignado();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            cargarPersonalAsignado();
        }

        private void cboPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPersonal_a_Liberar();
           
        }
    }
    
}
