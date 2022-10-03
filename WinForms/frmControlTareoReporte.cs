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
  
    public partial class frmControlTareoReporte : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        public frmControlTareoReporte()
        {
            InitializeComponent();
            ListarEmpresa();
            this.ReportViewer1.RefreshReport();
            //rpt_Cuadro();
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
        private void frmControlTareoReporte_Load(object sender, EventArgs e)
        {

            this.ReportViewer1.RefreshReport();
        }
        protected void rpt_Cuadro(string fecha, string centro, string capataz)
        {
            this.ReportViewer1.Refresh();


            DataTable dsCustomers = GetData(fecha ,centro ,capataz );
            ReportDataSource datasource = new ReportDataSource("DsTareoDiario", dsCustomers);

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
        private DataTable GetData(string fecha, string centro, string capataz)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("uspRPT_TAREO_DIARIO_CUADRILLA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            //cmd.Parameters.Add("@IDE_EMPRESA", SqlDbType.Int).Value = Convert.ToInt32(cboEmpresa.SelectedValue);
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = fecha ;
            cmd.Parameters.Add("@CCENTRO", SqlDbType.VarChar, 10).Value = centro  ;
            cmd.Parameters.Add("@IDE_CAPATAZ", SqlDbType.VarChar, 10).Value = capataz;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarIngenieros();
        }
        protected void ListarIngenieros()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateFecha.Value.Date.ToString("dd/MM/yyyy"), 1,"");
            if (dtResultado.Rows.Count > 0)
            {
                cboIngeniero.ValueMember = "ID_PERSONAL";
                cboIngeniero.DisplayMember = "NOMBRES";
                cboIngeniero.DataSource = dtResultado;
                ListarCapataz();
            }
            
        }
        protected void ListarCapataz()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            
            dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateFecha.Value.Date.ToString("dd/MM/yyyy"), 2,cboIngeniero.SelectedValue.ToString ()  );
            if (dtResultado.Rows.Count > 0)
            {
                cboCapataz.ValueMember = "ID_PERSONAL";
                cboCapataz.DisplayMember = "NOMBRES";
                cboCapataz.DataSource = dtResultado;
            }
        }

        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCapataz();
        }

        private void cboCapataz_SelectedIndexChanged(object sender, EventArgs e)
        {
            rpt_Cuadro(dateFecha.Value.Date.ToString("dd/MM/yyyy"), cboCentroCosto.SelectedValue.ToString(), cboCapataz.SelectedValue.ToString());
        }
    }
}
