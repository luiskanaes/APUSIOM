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
using WinForms.SvTareo;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace WinForms.TareoPersonal
{
    public partial class frmDesmovilizarEmp : Form
    {
        public static string DNI;
        public static string NOMBRES;
        public static string MES;
        public static string ANIO; public static string EMPRESA;

        public frmDesmovilizarEmp()
        {
            InitializeComponent();
            ListarEmpresa();

        

    }
        protected void ListarEmpresa()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarEmpresaPerfil_Tareo_Emp(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboEmpresa.ValueMember = "ID";
                cboEmpresa.DisplayMember = "DESCRIPCION";
                cboEmpresa.DataSource = dtResultado; cargasMeses();
                // ListarCesos();
                //cargaUbicaciones();
            }
        }

        //private void cargasAnios()
        //{
        //    cboAnio.DataSource = new BindingSource(anios, null);
        //    cboAnio.DisplayMember = "Value";
        //    cboAnio.ValueMember = "Key";
        //    cboAnio.SelectedValue = 2018;

        //}

        //public static Dictionary<int, string> anios = new Dictionary<int, string>()
        //{
        //    //{2017,"2017"},
        //    {2018,"2018"},
        //    {2019,"2019"},
        //    {2020,"2020"},
        //    {2020,"2021"}
        //};

        public static Dictionary<int, string> meses = new Dictionary<int, string>()
        {
            {1,"ENERO"},
            {2,"FEBRERO"},
            {3,"MARZO"},
            {4,"ABRIL"},
            {5,"MAYO"},
            {6,"JUNIO"},
            {7,"JULIO"},
            {8,"AGOSTO"},
            {9,"SEPTIEMBRE"},
            {10,"OCTUBRE"},
            {11,"NOVIEMBRE"},
            {12,"DICIEMBRE"}
        };

        

        private void cargasMeses()
        {
            cboMes.DataSource = new BindingSource(meses, null);
            cboMes.DisplayMember = "Value";
            cboMes.ValueMember = "Key";
            cboMes.SelectedValue = 1;

        }



       

        private void frmDesmovilizarEmp_Load(object sender, EventArgs e)
        {

        }

        private void dgDesmovilizados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string DNI;


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable(); DataTable dtResultado2 = new DataTable();
            dtResultado2 = obj.SP_CONSULTAR_EMP_DESMOVILIZADOS(cboMes.SelectedValue.ToString(), cboAnio.Text.ToString(), cboEmpresa.SelectedValue.ToString());//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado2.Rows.Count > 0)
            {

                dgDesmovilizados.DataSource = dtResultado2;
                //dgDesmovilizados.AutoResizeColumns();
                dgDesmovilizados.Visible = true;

            }

        }

       

        private void dgDesmovilizados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgDesmovilizados_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DNI = dgDesmovilizados.Rows[0].Cells[0].Value.ToString();
            NOMBRES = dgDesmovilizados.Rows[0].Cells[3].Value.ToString();
            MES = cboMes.SelectedValue.ToString();
            ANIO = cboAnio.Text.ToString();
            EMPRESA = cboEmpresa.SelectedValue.ToString();

            //new frmMovilizarEmp().ShowDialog();
        }
    }
}
