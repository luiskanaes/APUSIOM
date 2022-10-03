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
namespace WinForms.Logistica
{
    public partial class RptSolped : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionCGO"].ToString());
        public RptSolped()
        {
            InitializeComponent();
            rpt_Cuadro();
        }

        private void RptSolped_Load(object sender, EventArgs e)
        {

            this.ReportViewer1.RefreshReport();
        }
        protected void rpt_Cuadro()
        {
            this.ReportViewer1.Refresh();


            DataTable dsCustomers = GetData();
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers);

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
        private DataTable GetData()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("uspINS_SOLPED_LISTA_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@COD_PEDIDO", SqlDbType.VarChar, 20).Value = "";
            cmd.Parameters.Add("@IDE_SOLICITUD", SqlDbType.Int).Value = Convert.ToInt32(Solped.obj_SOLPED_E.IDE_SOLICITUD );

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
    }
}
