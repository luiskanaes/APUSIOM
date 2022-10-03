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

using System.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace WinForms
{
    public partial class frmTareoSemanal : Form
    {
        public frmTareoSemanal()
        {
            InitializeComponent();
            ListarEmpresa();
            lblEstado.Visible = false;
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
                ListarCecos();
                //cboAnio.SelectedIndex = 1;
                cboMes.SelectedIndex = 0;
            }
        }
        protected void ListarCecos()
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_TAREO_SEMANAL obj = new BL_TAREO_SEMANAL();
            DataTable dtResultado = new DataTable();

            if (cboVersion.SelectedItem == null) {

                MessageBox.Show("Debe seleccionar un rango de Fecha (Version)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            if (cboAnio.SelectedValue != null && cboMes.SelectedItem != null)
            {
                dtResultado = obj.SP_CONSULTAR_ESTADO_MIGRACION(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboVersion.SelectedValue.ToString());

            }
            if (dtResultado.Rows.Count > 0)
            {
                btnGenerar.Visible = false;
                btnMigrar.Visible = false;
                btnEliminar.Visible = true;
                lblEstado.Visible = true;
                lblEstado.Text = "MIGRADO";

                DataTable dtResultado_Migrado = new DataTable();
                dtResultado_Migrado = obj.SP_CONSULTAR_TAREO_SEMANAL(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboVersion.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboMes.SelectedItem.ToString());
              
                if (dtResultado_Migrado.Rows.Count > 0)
                {

                    //gridDetalle.Rows.Clear();
                    //gridDetalle.Columns.Clear();
                    //gridDetalle.Refresh();
                    gridDetalle.DataSource = dtResultado_Migrado;
                    gridDetalle.AutoResizeColumns();
                    gridDetalle.Visible = true;
                    btnExcel.Visible = true;

                }

            }
            else {
                btnGenerar.Visible = true;
                lblEstado.Visible = true;
                lblEstado.Text = "PENDIENTE DE MIGRACION";
                gridDetalle.DataSource = null;
            }
            

            /* BL_TAREO_SEMANAL obj = new BL_TAREO_SEMANAL();
            DataTable dtResultado = new DataTable();            

            dtResultado = obj.SP_CONSULTAR_TAREO_SEMANAL(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO, "");
            if (dtResultado.Rows.Count > 0)
            {
                gridDetalle.DataSource = dtResultado;
            }

           
            foreach (DataGridViewRow row in gridDetalle.Rows)
            {
                if (Convert.ToInt32(row.Cells["Dni"].Value) % 2 == 0)
                {

                    row.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            gridDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;*/
        }

        private void dateTareo_ValueChanged(object sender, EventArgs e)
        {
            ListarVersion();
        }

        private void ListarVersion()
        {
            BL_TAREO_SEMANAL obj = new BL_TAREO_SEMANAL();
            DataTable dtResultado = new DataTable();
            if (cboAnio.SelectedValue != null && cboMes.SelectedItem != null)
            {
                dtResultado = obj.SP_CONSULTAR_VERSION(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(),"0" + cboMes.SelectedItem.ToString());

            }
            if (dtResultado.Rows.Count > 0)
            {
                cboVersion.ValueMember = "ID";
                cboVersion.DisplayMember = "DSC";
                cboVersion.DataSource = dtResultado;
            }
            else {
                cboVersion.DataSource = null;
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            BL_TAREO_SEMANAL obj = new BL_TAREO_SEMANAL();
            DataTable dtResultado_tareo_generar = new DataTable();

            DataTable dtResultado_validar = new DataTable();


            dtResultado_validar = obj.SP_VALIDAR_CIERRE_TAREO(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboVersion.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), "0" + cboMes.SelectedItem.ToString());

            if (dtResultado_validar.Rows[0]["VALIDACION"].ToString() == "0")
            {
                gridDetalle.DataSource = null;
                MessageBox.Show("Faltan cerrar dias, favor de cerrar los dias antes de Generar Data  Opción : OPERACIONES / CIERRE TAREO.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }             


            dtResultado_tareo_generar = obj.SP_GENERAR_TAREO_SEMANAL(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboVersion.SelectedValue.ToString(),cboAnio.SelectedValue.ToString(),"0"+cboMes.SelectedItem.ToString());

            if (dtResultado_tareo_generar.Rows[0]["TOTAL_GENERADO"].ToString() == "0")
            {
                gridDetalle.DataSource = null;
                MessageBox.Show("No existe data para generar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                lblEstado.Text = "GENERADO";
                btnMigrar.Visible = true;
                btnExcel.Visible = true;   
            }


            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_TAREO_SEMANAL(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboVersion.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboMes.SelectedItem.ToString());
            gridDetalle.DataSource = null;
            if (dtResultado.Rows.Count > 0)
            {
 
                gridDetalle.Rows.Clear();
                gridDetalle.Columns.Clear();
                gridDetalle.Refresh();
                gridDetalle.DataSource = dtResultado;
                gridDetalle.AutoResizeColumns();
                gridDetalle.Visible = true;
                
            }
        }

        private void cboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarVersion();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMes.SelectedItem != null)
            {ListarVersion();
            } 
        }

        private void btnMigrar_Click(object sender, EventArgs e)
        {
            BL_TAREO_SEMANAL obj = new BL_TAREO_SEMANAL();
            DataTable dtResultado_tareo_generar = new DataTable();
            dtResultado_tareo_generar = obj.SP_MIGRAR_TAREO_SEMANAL(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboVersion.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(),"0"+ cboMes.SelectedItem.ToString());

            if (dtResultado_tareo_generar.Rows[0]["TOTAL_MIGRADO"].ToString() == "0")
            {
                gridDetalle.DataSource = null;
                MessageBox.Show("No existe data para migrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                lblEstado.Text = "MIGRADO";
                btnMigrar.Visible = false;
                btnGenerar.Visible = false;
                btnEliminar.Visible = true;
                MessageBox.Show("Periodo Migrado: " +  cboAnio.SelectedValue.ToString() +"/"+ cboMes.SelectedItem.ToString() + " Version:" +cboVersion.SelectedValue.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridDetalle.DataSource = null;
            btnGenerar.Visible = false;
            btnMigrar.Visible = false;
            btnEliminar.Visible = false;
            btnExcel.Visible = false;
        }

        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMes.SelectedItem != null)
            {
                ListarVersion();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BL_TAREO_SEMANAL obj = new BL_TAREO_SEMANAL();
            DataTable dtResultado_validar_eliminar = new DataTable();
            dtResultado_validar_eliminar = obj.SP_VALIDAR_ELIMINAR_MIGRACION(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboVersion.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), "0" + cboMes.SelectedItem.ToString());

            if (dtResultado_validar_eliminar.Rows[0]["TRANSFERIDO"].ToString() == "0")
            {

                DataTable dtResultado_eliminar = new DataTable();
                dtResultado_eliminar = obj.SP_ELIMINAR_MIGRACION(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), cboVersion.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), "0" + cboMes.SelectedItem.ToString());
                btnGenerar.Visible = true;
                lblEstado.Visible = true;
                lblEstado.Text = "PENDIENTE DE MIGRACION";
                gridDetalle.DataSource = null;
                btnEliminar.Visible = false;
            }
            else
            {
                MessageBox.Show("El periodo se encuentra transferido, Eliminar la transferencia desde el Sisplan", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(gridDetalle, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount ; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void frmTareoSemanal_Load(object sender, EventArgs e)
        {
            Anios();
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCecos();
        }
        protected void Anios()
        {


            DataTable dtResultado = new DataTable();
            dtResultado = GetTableAnio();
            if (dtResultado.Rows.Count > 0)
            {
                cboAnio.ValueMember = "ANIO";
                cboAnio.DisplayMember = "ANIO1";
                cboAnio.DataSource = dtResultado;
                ListarVersion();
            }
        }
        static DataTable GetTableAnio()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("ANIO", typeof(int));
            table.Columns.Add("ANIO1", typeof(string));

            int anio = 0;
            int anioActual = 0;
            anio = DateTime.Today.Year + 1;
            anioActual = DateTime.Today.Year;
            for (int i = 0; i < 5; i++)
            {
                anio = anioActual - i;
                table.Rows.Add(anio, anio);


            }

            return table;
        }
    }
}
