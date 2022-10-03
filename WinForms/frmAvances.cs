using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using Microsoft.Reporting.WinForms;
using UserCode;
namespace WinForms
{
    public partial class frmAvances : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        public frmAvances()
        {
            InitializeComponent();
            ListarEmpresa();
            this.ReportViewer1.RefreshReport();
        }

        private void frmAvances_Load(object sender, EventArgs e)
        {

            this.ReportViewer1.RefreshReport();
    
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
        protected void rpt_Cuadro()
        {
            this.ReportViewer1.Refresh();
           

            DataTable dsCustomers = GetData();
            ReportDataSource datasource = new ReportDataSource("DsTareo", dsCustomers);
           
            if (dsCustomers.Rows.Count > 0)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.RefreshReport();
                ReportViewer1.Show();
            }
            else
            {
                ReportViewer1.Visible = false;
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
        protected void grilla()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DataTable dsCustomers = GetData();
            if (dsCustomers.Rows.Count > 0)
            {
                dataGridView1.ColumnCount = 12;

                dataGridView1.Columns[0].Name = "Centro";
                dataGridView1.Columns[1].Name = "Fecha";
                dataGridView1.Columns[2].Name = "Dni Ingeniero";
                dataGridView1.Columns[3].Name = "Ingeniero de Campo";

                dataGridView1.Columns[4].Name = "Dni Responsable";
                dataGridView1.Columns[5].Name = "Responsable Cuadrilla";

                
                dataGridView1.Columns[6].Name = "Centro Costo";
                dataGridView1.Columns[7].Name = "Tarea";
                dataGridView1.Columns[8].Name = "Total HH";
                dataGridView1.Columns[9].Name = "Total Programado";
                dataGridView1.Columns[10].Name = "Total Ejecutado";
                dataGridView1.Columns[11].Name = "ID";

                dataGridView1.Columns[3].Width = 300;
                dataGridView1.Columns[5].Width = 300;
                dataGridView1.Columns[7].Width = 300;

                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[11].Visible = false;
                string CENTRO, FECHA, IDE_INGCAMPO, NOMBRE_ING, IDE_CAPATAZ, NOMBRE_CAPATAZ, CTA_COSTO, DES_TAREA, TOTAL_HH, PROGRAMADO, EJECUTADO, ID;
                string[] row;
                for (int i = 0; i < dsCustomers.Rows.Count; i++)
                {

                    CENTRO = dsCustomers.Rows[i]["CENTRO"].ToString();
                    FECHA = dsCustomers.Rows[i]["FECHA"].ToString();
                    IDE_INGCAMPO = dsCustomers.Rows[i]["IDE_INGCAMPO"].ToString();
                    NOMBRE_ING = dsCustomers.Rows[i]["NOMBRE_ING"].ToString();
                    IDE_CAPATAZ = dsCustomers.Rows[i]["IDE_CAPATAZ"].ToString();
                    NOMBRE_CAPATAZ = dsCustomers.Rows[i]["NOMBRE_CAPATAZ"].ToString();

                    CTA_COSTO = dsCustomers.Rows[i]["CTA_COSTO"].ToString();
                    DES_TAREA = dsCustomers.Rows[i]["DES_TAREA"].ToString();
                    TOTAL_HH = dsCustomers.Rows[i]["TOTAL_HH"].ToString();
                    PROGRAMADO = dsCustomers.Rows[i]["PROGRAMADO"].ToString();
                    EJECUTADO = dsCustomers.Rows[i]["EJECUTADO"].ToString();
                    ID= dsCustomers.Rows[i]["ID"].ToString();
                    row = new string[] {
                CENTRO , FECHA, IDE_INGCAMPO,    NOMBRE_ING, IDE_CAPATAZ, NOMBRE_CAPATAZ , CTA_COSTO,   DES_TAREA   , TOTAL_HH ,PROGRAMADO , EJECUTADO,ID

                };

                    dataGridView1.Rows.Add(row);
                }


                foreach (DataGridViewRow xrow in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(xrow.Cells["ID"].Value) % 2 == 0)
                    {

                        xrow.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                    }
                    else
                    {
                        xrow.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            else
            {
                MessageBox.Show("No se encuentra información", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private DataTable GetData()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_REPORTE_CONTROL_AVANCES", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            cmd.Parameters.Add("@IDE_EMPRESA", SqlDbType.Int).Value = Convert.ToInt32(cboEmpresa.SelectedValue);
            cmd.Parameters.Add("@CCENTRO", SqlDbType.VarChar,10).Value = cboCentroCosto.SelectedValue.ToString();
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = dateFecha.Value.Date.ToString("dd/MM/yyyy");
            cmd.Parameters.Add("@FECHA_TERMINO", SqlDbType.VarChar, 10).Value = dateFechaTermino.Value.Date.ToString("dd/MM/yyyy");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
          
            //BL_TAREO Xobj = new BL_TAREO();
            //DataTable dtResultado = new DataTable();
            //dtResultado = Xobj.REPORTE_CONTROL_AVANCES(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateFecha.Value.Date.ToString("dd/MM/yyyy"));
            rpt_Cuadro();
            //grilla();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dataGridView1, sfd.FileName); // Here dataGridview1 is your grid view name
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
            for (int i = 0; i < dGV.RowCount - 1; i++)
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

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }
    }
}
