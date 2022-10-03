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
    public partial class FotoReportVarios : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        public int varFoto;
        public int varQR;
        public FotoReportVarios()
        {
            InitializeComponent();
            rpt_Cuadro();
        }

        private void FotoReportVarios_Load(object sender, EventArgs e)
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
                this.ReportViewer1.LocalReport.EnableExternalImages = true;

                //dsCustomers.Rows[0]["FLG_ESTADO"].ToString();
                //dsCustomers.Rows[0]["FLG_ESTADO"].ToString();



                //String DirectorioFile = ConfigurationManager.AppSettings["FOTOS"];

                ReportViewer1.LocalReport.DataSources.Clear();

                //string FilePath1 = "file:" + System.Configuration.ConfigurationManager.AppSettings["FOTOS"] + "FOTOS\\" + Fotocheck.obj_personal_E.FOTO.ToString();
                //string FilePath2 = "file:" + System.Configuration.ConfigurationManager.AppSettings["FOTOS"] + "QR\\" + Fotocheck.obj_personal_E.FOTOCHECK.ToString();

                //ReportParameter[] param = new ReportParameter[2];

                //param[0] = new ReportParameter("Path", FilePath1, true);
                //param[1] = new ReportParameter("Path2", FilePath2, true);


                //ReportViewer1.LocalReport.SetParameters(param);
                ReportViewer1.Update();
                ReportViewer1.RefreshReport();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.Show();



            }
            else
            {

                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
        private DataTable GetData()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("USP_PERSONAL_FOTOCHECK", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;

            cmd.Parameters.Add("@CCENTRO", SqlDbType.VarChar, 100).Value = Fotocheck.obj_personal_E.CENTRO_COSTO.ToString();
            cmd.Parameters.Add("@TIPO_TRABAJADOR", SqlDbType.VarChar, 100).Value = Fotocheck.obj_personal_E.TIPO_TRABAJADOR.ToString();
            cmd.Parameters.Add("@FLG_FOTOCHECK", SqlDbType.VarChar, 100).Value = string.Empty;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }


    }
}
