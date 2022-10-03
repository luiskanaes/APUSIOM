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
    public partial class Rpt_ManoObra : Form
    {
        DataView dv;
        DataTable dtResultadoEmpresa;
        DataTable dtResultadoCecos;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSisplan"].ToString());
        public Rpt_ManoObra()
        {
            InitializeComponent();
            ListarEmpresa();
            Anios();
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
        private void Rpt_ManoObra_Load(object sender, EventArgs e)
        {

            this.ReportViewer1.RefreshReport();
        }

        protected void ListarEmpresa()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            
            dtResultadoEmpresa = obj.ListarEmpresaPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultadoEmpresa.Rows.Count > 0)
            {
                //TxtCodSisplan.Text = dtResultado.Rows[0]["COD_AQUARIUS"].ToString();

                cboEmpresa.ValueMember = "ID";
                cboEmpresa.DisplayMember = "DESCRIPCION";
                cboEmpresa.DataSource = dtResultadoEmpresa;

               

                CodSisplan();
                ListarCesos();
            }
        }

        protected void CodSisplan()
        {
            dv = new DataView(dtResultadoEmpresa);
            int registros = dv.Count;

            string expression = "ID  = '" + cboEmpresa.SelectedValue + "'";
            dv.RowFilter = expression;

            foreach (DataRowView rowView in dv)
            {

                TxtCodSisplan.Text = ((rowView["COD_AQUARIUS"]).ToString());

            }
        }
        protected void ListarCesos()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();

            dtResultadoCecos = obj.ListarCesosPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO, Convert.ToInt32(cboEmpresa.SelectedValue));
            if (dtResultadoCecos.Rows.Count > 0)
            {
                cboCentroCosto.ValueMember = "ID";
                cboCentroCosto.DisplayMember = "CECOS";
                cboCentroCosto.DataSource = dtResultadoCecos;
                DatosProyecto();
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodSisplan();
            ListarCesos();
            ListarPeriodo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string PERIODOS = string.Empty;
            foreach (var item in checkedListBox1.CheckedItems)
            {
                var row = (item as DataRowView).Row;

                PERIODOS += row["ID"].ToString() + ",";

                
            }

            if (PERIODOS != string.Empty)
            {
                rpt_Cuadro(PERIODOS);
            }
            else
            {
                MessageBox.Show("Seleccionar periodos a consultar", "MENSAJE ICSK");
            }
        }


        protected void rpt_Cuadro(string V_NUM_VERSION)
        {
            this.ReportViewer1.Refresh();


            DataTable dsCustomers = GetData(V_NUM_VERSION);
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
              
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }

        private DataTable GetData(string V_NUM_VERSION)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_PLA_RPT_CMO_DETALLE_VARIOS_MANO_OBRA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;

            cmd.Parameters.Add("@V_COD_EMPRESA", SqlDbType.VarChar, 10).Value = cboEmpresa.SelectedValue;
            cmd.Parameters.Add("@V_ANO_PROCESO", SqlDbType.VarChar, 10).Value = cboAnio.SelectedValue;
            cmd.Parameters.Add("@V_NUM_VERSION ", SqlDbType.VarChar,100).Value = V_NUM_VERSION;
            cmd.Parameters.Add("@V_COD_TIPO_PLANILLA  ", SqlDbType.VarChar,100).Value = txtPlanilla.Text.Trim();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
        protected void DatosProyecto()
        {
            dv = new DataView(dtResultadoCecos);
            int registros = dv.Count;

            string expression = "ID  = '" + cboCentroCosto.SelectedValue + "'";
            dv.RowFilter = expression;

            foreach (DataRowView rowView in dv)
            {

                txtPlanilla.Text = ((rowView["cod_planilla"]).ToString());

            }
        }

        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosProyecto();
            ListarPeriodo();
        }

        private void cboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarPeriodo();
        }

        protected void ListarPeriodo()
        {


            BL_TAREO_SEMANAL obj = new BL_TAREO_SEMANAL();
            DataTable dtResultado = new DataTable();
            if (cboAnio.SelectedValue != null)
            {
                dtResultado = obj.SP_CONSULTAR_VERSION_ANIO(cboEmpresa.SelectedValue.ToString(), 
                    cboCentroCosto.SelectedValue.ToString(), 
                    cboAnio.SelectedValue.ToString(), "0" + string.Empty, txtPlanilla.Text.Trim());

            }

            if (dtResultado.Rows.Count > 0)
            {
                checkedListBox1.DataSource = dtResultado;
                checkedListBox1.ValueMember = "ID";
                checkedListBox1.DisplayMember = "DSC";

            }
            else
            {
                checkedListBox1.DataSource = null;
            } 


            

        }
    }
}
