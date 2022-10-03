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
    public partial class frmAsociarPersonal : Form
    {
        public frmAsociarPersonal()
        {
            InitializeComponent();
            ListarEmpresa();
           
           
        }

        private void frmAsociarPersonal_Load(object sender, EventArgs e)
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
                ListarPersonaIng();
                
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }
        protected void ListarPersonaIng()
        {
            BL_PERSONAL obj = new BL_PERSONAL();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.Listar_Personal_x_Categoria(cboCentroCosto.SelectedValue.ToString (), Convert.ToInt32 (cboEmpresa.SelectedValue ), "INGENIERO");
            if (dtResultado.Rows.Count > 0)
            {

                cboIngeniero.ValueMember = "ID_PERSONAL";
                cboIngeniero.DisplayMember = "NOMBRES";
                cboIngeniero.DataSource = dtResultado;
                listarPersonal();
                
                ListarResponsable();
            }
            else
            {
               
                    dgvPersonal.Rows.Clear();
                    dgvPersonal.Refresh();
                    //dgvPersonal.DataSource = null;
                    dgvPersonal.Columns.Clear();
                    cboIngeniero.DataSource = null;
                    cboIngeniero.Items.Clear(); 
            }
        }
     

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje ="El personal seleccionado asume labores a partir de la " + dateTareo.Value.Date.ToString("dd/MM/yyyy"); 
            DialogResult respuesta = MessageBox.Show(mensaje + Environment.NewLine + "¿Desea continuar?", "Grabar registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                BL_PERSONAL obj = new BL_PERSONAL();
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dgvPersonal.Rows)
                {
                    DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(cellSelecion.Value))
                    {
                        rowSelected.Add(row);
                    }
                }

                foreach (DataGridViewRow row in rowSelected)
                {
                    dvdCapataz.Rows.Add(new object[] {false,
                                                    row.Cells["Nombre"].Value,
                                                    row.Cells["idePersonal"].Value});

                    obj.AsignarResponsable(row.Cells["idePersonal"].Value.ToString(), cboIngeniero.SelectedValue.ToString(), 1, Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString());
                    obj.uspINS_EQUIPO_TRABAJO(0, cboCentroCosto.SelectedValue.ToString(), cboIngeniero.SelectedValue.ToString(), row.Cells["idePersonal"].Value.ToString(), 1, dateTareo.Value.Date.ToString("dd/MM/yyyy"), "");


                    dgvPersonal.Rows.Remove(row);
                }

                Cantidad();
            }

            
        }
        private void btnquitar_Click(object sender, EventArgs e)
        {
            string mensaje = "El personal seleccionado dejara el grupo y su último dia de trabajo será " + dateFin.Value.Date.ToString("dd/MM/yyyy")+ Environment.NewLine+
                "Advertencia: se eliminará todo su cuadrilla de trabajo";

            DialogResult respuesta = MessageBox.Show(mensaje + Environment.NewLine + "¿Desea continuar?", "Actualizar registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                BL_PERSONAL obj = new BL_PERSONAL();
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dvdCapataz.Rows)
                {
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
                                                    row.Cells["idePersonal"].Value});

                    obj.AsignarResponsable(row.Cells["idePersonal"].Value.ToString(), cboIngeniero.SelectedValue.ToString(), 2, Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString());
                    obj.uspINS_EQUIPO_TRABAJO(0, cboCentroCosto.SelectedValue.ToString(), cboIngeniero.SelectedValue.ToString(), row.Cells["idePersonal"].Value.ToString(), 0, "", dateFin.Value.Date.ToString("dd/MM/yyyy"));



                    dvdCapataz.Rows.Remove(row);
                }
                Cantidad();
            }
            
        }
        protected void listarPersonal()
        {

            BL_PERSONAL objPersona = new BL_PERSONAL();


            dvdCapataz.Rows.Clear();
            dvdCapataz.Refresh();
            dvdCapataz.DataSource = null;
            dvdCapataz.Columns.Clear();

            dvdCapataz.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.ToolTipText = "Disponible";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Seleccion";
            dvdCapataz.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Responsable de Cuadrilla";
            colNombre.Width = 280;
            dvdCapataz.Columns.Insert(1, colNombre);

            DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
            colIdPersona.Name = "idePersonal";
            colIdPersona.HeaderText = "idePersonal";
            colIdPersona.Width = 30;
            dvdCapataz.Columns.Insert(2, colIdPersona);

            dvdCapataz.Columns["idePersonal"].Visible = false;


            DataGridViewTextBoxColumn colInicio = new DataGridViewTextBoxColumn();
            colInicio.Name = "Nombre";
            colInicio.HeaderText = "Inicio";
            colInicio.Width = 70;
            dvdCapataz.Columns.Insert(3, colInicio);

            BL_PERSONAL obj = new BL_PERSONAL();
            DataTable dtResul = new DataTable();
            try
            {
                //dtResul = obj.Listar_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "RESPONSABLE CUADRILLA", cboIngeniero.SelectedValue.ToString());
                txtCantidadAsignada.Text = string.Empty ;
              
                dtResul = obj.SP_OBTENER_EQUIPO_TRABAJO(cboCentroCosto.SelectedValue.ToString(), "1", cboIngeniero.SelectedValue.ToString(),2);

                if (dtResul.Rows.Count > 0)
                {
                    txtCantidadAsignada.Text = dtResul.Rows.Count.ToString();
                    string FLG_LIBRE, Personal, IDE_PERSONAL, FECHA_INICIO;
                    string[] Xrow;
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        FLG_LIBRE = dtResul.Rows[i]["SELECCIONAR"].ToString();
                        Personal = dtResul.Rows[i]["NOMBRES"].ToString();
                        IDE_PERSONAL = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                        FECHA_INICIO = dtResul.Rows[i]["FECHA_INICIO"].ToString();
                        Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (), Personal, IDE_PERSONAL,FECHA_INICIO};
                        dvdCapataz.Rows.Add(Xrow);
                    }
                }
            }

            catch (Exception ex)
            {

            }
        }
        protected void ListarResponsable()
        {

            BL_PERSONAL objPersona = new BL_PERSONAL();


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

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Responsable de Cuadrilla";
            colNombre.Width = 300;
            dgvPersonal.Columns.Insert(1, colNombre);

            DataGridViewTextBoxColumn colIdPersona = new DataGridViewTextBoxColumn();
            colIdPersona.Name = "idePersonal";
            colIdPersona.HeaderText = "idePersonal";
            colIdPersona.Width = 30;
            dgvPersonal.Columns.Insert(2, colIdPersona);

            DataGridViewTextBoxColumn colAsignado = new DataGridViewTextBoxColumn();
            colAsignado.Name = "ideAsignado";
            colAsignado.HeaderText = "ideAsignado";
            colAsignado.Width = 30;
            dgvPersonal.Columns.Insert(3, colAsignado);

            dgvPersonal.Columns["idePersonal"].Visible = false;
            dgvPersonal.Columns["ideAsignado"].Visible = false;

            BL_PERSONAL obj = new BL_PERSONAL();
            
            try
            {
                int cantidadDisponible = 0;
                int cantidadAsignado = 0;
                DataTable dtResul = new DataTable();
                dtResul = obj.Listar_Personal_x_Categoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "RESPONSABLE CUADRILLA");
                //dtResul = obj.SP_OBTENER_EQUIPO_TRABAJO(cboCentroCosto.SelectedValue.ToString(), "", cboIngeniero.SelectedValue.ToString(),1);

                if (dtResul.Rows.Count > 0)
                {
                 
                    string FLG_LIBRE, Personal, IDE_PERSONAL, ASIGNADO;
                    string[] Xrow;
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        FLG_LIBRE = dtResul.Rows[i]["SELECCIONAR"].ToString();
                        Personal = dtResul.Rows[i]["NOMBRES"].ToString();
                        IDE_PERSONAL = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                        ASIGNADO = dtResul.Rows[i]["ASIGNADO"].ToString();
                        Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (), Personal, IDE_PERSONAL,ASIGNADO};
                        dgvPersonal.Rows.Add(Xrow);
                    }

                    foreach (DataGridViewRow row in dgvPersonal.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["ideAsignado"].Value) == 0)// asignado
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

                lblAsignado.Text = "Asignados (" + cantidadAsignado.ToString() + ")";
                lblDisponible.Text = "Disponibles (" + cantidadDisponible.ToString() + ")";

            }

            catch (Exception ex)
            {

            }
        }
        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPersonal();
            ListarResponsable();
            
        }

 

        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarPersonaIng();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarPersonal();//asignados
            ListarResponsable();
        }
        protected void Cantidad()
        {
            int cantidadDisponible = 0;
            int cantidadAsignado = 0;
            foreach (DataGridViewRow row in dgvPersonal.Rows)
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
            txtCantidadAsignada.Text = dvdCapataz.Rows.Count.ToString();
        }
    }
}
