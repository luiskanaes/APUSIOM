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
   
    public partial class FotoReportId : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        public int varFoto;
        public int varQR;
        public FotoReportId()
        {
            InitializeComponent();
            rpt_Cuadro();
        }

        private void FotoReportId_Load(object sender, EventArgs e)
        {

            this.ReportViewer1.RefreshReport();
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

                String DirectorioFile = ConfigurationManager.AppSettings["FOTOS"];

                ReportViewer1.LocalReport.DataSources.Clear();

                string FilePath1 = "file:" + System.Configuration.ConfigurationManager.AppSettings["FOTOS"] + "FOTOS\\" + Fotocheck.obj_personal_E.FOTO.ToString();
                string FilePath2 = "file:" + System.Configuration.ConfigurationManager.AppSettings["FOTOS"] + "QR\\" + Fotocheck.obj_personal_E.FOTOCHECK.ToString();


                ReportParameter[] param = new ReportParameter[2];

                param[0] = new ReportParameter("Path",FilePath1, true);
                param[1] = new ReportParameter("Path2", FilePath2, true);
                ReportViewer1.LocalReport.SetParameters(param);
                ReportViewer1.Update();
                ReportViewer1.RefreshReport();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.Show();

                


                //string v_mimetype;
                //string v_encoding;
                //string extension;
                //string[] v_streamids;
                //Microsoft.Reporting.WinForms.Warning[] warnings;
                //string FileName =  Fotocheck.obj_personal_E.NOMBRE_COMPLETO.ToString();

                //Microsoft.Reporting.WinForms.LocalReport objRDLC = new Microsoft.Reporting.WinForms.LocalReport();
                //objRDLC.DataSources.Clear();
                //byte[] byteViewer = ReportViewer1.LocalReport.Render("PDF", null, out v_mimetype, out v_encoding, out extension, out v_streamids, out warnings);

                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                //saveFileDialog1.Filter = "JPEG|*.jpg|Mapa de Bits|*.bmp|Gif|*.gif|PNG|*.png";
                //saveFileDialog1.FilterIndex = 1;
                //saveFileDialog1.RestoreDirectory = true;
                //saveFileDialog1.FileName = FileName;
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                //    newFile.Write(byteViewer, 0, byteViewer.Length);
                //    newFile.Close();
                //}
            }
            else
            {
               
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
        private DataTable GetData()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("USP_PERSONAL_FOTOCHECK_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;

            cmd.Parameters.Add("@IDE_PERSONAL", SqlDbType.VarChar, 100).Value = Fotocheck.obj_personal_E.IDE_PERSONAL.ToString();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }

       

       
    }
}
