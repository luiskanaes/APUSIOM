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
    public partial class frmHHDiario : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        public frmHHDiario()
        {
            InitializeComponent();
            ListarEmpresa();
            this.ReportViewer1.RefreshReport();
        }

        private void frmHHDiario_Load(object sender, EventArgs e)
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
                cboCentroCosto.Visible = true ;
                cboCentroCosto.ValueMember = "ID";
                cboCentroCosto.DisplayMember = "CECOS";
                cboCentroCosto.DataSource = dtResultado;

            }
            else
            {
                cboCentroCosto.Visible = false;
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            rpt_Cuadro(dateFecha.Value.Date.ToString("dd/MM/yyyy"), cboCentroCosto.SelectedValue.ToString());
        }
        protected void rpt_Cuadro(string fecha, string centro)
        {
            this.ReportViewer1.Refresh();


            DataTable ds1 = GetDataSP_RPT_TAREO_PARTE(centro, fecha);
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds1);

            DataTable ds2 = GetDataSP_RPT_TAREO_ACTIVIDADES_DIA(centro, fecha);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds2);

            DataTable ds3= GetDataSP_RPT_TAREO_DEL_DIA(centro, fecha);
            ReportDataSource datasource3 = new ReportDataSource("DataSet3", ds3);

            DataTable ds4 = GetDataSP_RPT_DETALLE_HH_CATEGORIA(centro, fecha);
            ReportDataSource datasource4 = new ReportDataSource("DataSet4", ds4);

            DataTable ds5 = GetSP_RPT_TOTAL_HH_TRABAJADAS_DISCIPLINA(centro, fecha);
            ReportDataSource datasource5 = new ReportDataSource("DataSet5", ds5);

            if (ds1.Rows.Count > 0)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
                ReportViewer1.LocalReport.DataSources.Add(datasource4);
                ReportViewer1.LocalReport.DataSources.Add(datasource5);

                ReportViewer1.RefreshReport();
                ReportViewer1.Show();
            }
            else
            {
                ReportViewer1.Visible = false;
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
        private DataTable GetDataSP_RPT_TAREO_DEL_DIA( string centro, string fecha)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_RPT_TAREO_DEL_DIA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = centro;
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = fecha;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);
            return dt;
        }
        private DataTable GetDataSP_RPT_TAREO_PARTE(string centro, string fecha)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_RPT_TAREO_PARTE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = centro;
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = fecha;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);
            return dt;
        }
        private DataTable GetDataSP_RPT_TAREO_ACTIVIDADES_DIA(string centro, string fecha)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_RPT_TAREO_ACTIVIDADES_DIA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = centro;
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = fecha;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);
            return dt;
        }
        private DataTable GetDataSP_RPT_DETALLE_HH_CATEGORIA(string centro, string fecha)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_RPT_DETALLE_HH_CATEGORIA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = centro;
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = fecha;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);
            return dt;
        }
        private DataTable GetSP_RPT_TOTAL_HH_TRABAJADAS_DISCIPLINA(string centro, string fecha)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_RPT_TOTAL_HH_TRABAJADAS_DISCIPLINA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = centro;
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = fecha;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);
            return dt;
        }
    }
}
