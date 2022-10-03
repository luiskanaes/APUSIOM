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
    public partial class Rpt_HistotialHH : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        public Rpt_HistotialHH()
        {
            InitializeComponent();
            ListarEmpresa();
        }

        private void Rpt_HistotialHH_Load(object sender, EventArgs e)
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

        
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            rpt_Cuadro();
        }

        private void cboEmpresa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ListarCesos();
        }
        protected void rpt_Cuadro()
        {
            this.ReportViewer1.Refresh();


            DataTable dsCustomers = GetData();
            DataTable dsCustomers2 = GetDataTotal();
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsCustomers2);

            if (dsCustomers.Rows.Count > 0)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
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
            SqlCommand cmd = new SqlCommand("SP_RPT_TAREO_HISTORICO_PERSONAL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            //cmd.Parameters.Add("@IDE_EMPRESA", SqlDbType.Int).Value = Convert.ToInt32(cboEmpresa.SelectedValue);
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = cboCentroCosto.SelectedValue.ToString();
            cmd.Parameters.Add("@INICIO", SqlDbType.VarChar, 10).Value = dateFecha.Value.Date.ToString("dd/MM/yyyy");
            cmd.Parameters.Add("@TERMINO", SqlDbType.VarChar, 10).Value = dateFechaTermino.Value.Date.ToString("dd/MM/yyyy");
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 10).Value = txtDni.Text.Trim();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
        private DataTable GetDataTotal()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_RPT_TAREO_TOTAL_PERSONAL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            //cmd.Parameters.Add("@IDE_EMPRESA", SqlDbType.Int).Value = Convert.ToInt32(cboEmpresa.SelectedValue);
            cmd.Parameters.Add("@CENTRO_COSTO", SqlDbType.VarChar, 10).Value = cboCentroCosto.SelectedValue.ToString();
            cmd.Parameters.Add("@INICIO", SqlDbType.VarChar, 10).Value = dateFecha.Value.Date.ToString("dd/MM/yyyy");
            cmd.Parameters.Add("@TERMINO", SqlDbType.VarChar, 10).Value = dateFechaTermino.Value.Date.ToString("dd/MM/yyyy");
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 10).Value = txtDni.Text.Trim();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
    }
}
