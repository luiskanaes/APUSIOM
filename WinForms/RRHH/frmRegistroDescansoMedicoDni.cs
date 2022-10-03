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


namespace WinForms.RRHH
{
    public partial class frmRegistroDescansoMedicoDni : Form
    {
        public frmRegistroDescansoMedicoDni()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarEmpleados();
            buscarCantidadDiaDM();
            buscarListaDM();
            
        }
        private void buscarListaDM()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_LISTA_DESCANSO_MEDICO_DNI("0001", txtDni.Text, cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {
                gbLista.Visible = true;
                dgDescansos.DataSource = dtResultado;
                dgDescansos.AutoResizeColumns();
                dgDescansos.Visible = true;

            }
            else
            {
                gbLista.Visible = false;
                lblDiasSub.Text = "0";
                lblDiasDm.Text = "0";
            }
        }
        private void buscarCantidadDiaDM() {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_CANT_DIAS_DESCANSO_MEDICO_DNI("0001", txtDni.Text, cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {
                lblDiasSub.Text = dtResultado.Rows[0]["DiasSub"].ToString();
                lblDiasDm.Text = dtResultado.Rows[0]["DiasDm"].ToString();

            }
            else
            {
                lblDiasSub.Text = "0";
                lblDiasDm.Text = "0";
            }
        }
        private void buscarEmpleados()
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO_DNI("0001", txtDni.Text, cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {
                LBL_PERSONAL.Text = dtResultado.Rows[0]["NOMBRE"].ToString();
                txtCat.Text = dtResultado.Rows[0]["DES_TIPO_PLANILLA"].ToString();
                txtFecIng.Text = dtResultado.Rows[0]["FEC_INGRESO"].ToString();
                txtFecNac.Text = dtResultado.Rows[0]["FEC_NACIMIENTO"].ToString();
                txtUbi.Text = dtResultado.Rows[0]["ceco"].ToString();
                LBL_PERSONAL.Visible = true;
                btnGrabar.Visible = true;
            }
            else
            {
                MessageBox.Show("Personal no existe o esta en otra Ubicación"); limpiarCampos();
            }
        }

        private void frmRegistroDescansoMedicoDni_Load(object sender, EventArgs e)
        {
            cargaUbicaciones();
            tipoDescanso();
            tipoIncidente();
        }
        private void cargaUbicaciones()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_UBICACIONES_DM("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboUbicacion.ValueMember = "ID";
                cboUbicacion.DisplayMember = "DESCRIPCION";
                cboUbicacion.DataSource = dtResultado;

            }

        }
        public void tipoDescanso()
        {
            DataTable dtResultado = new DataTable();
            dtResultado = new BL_FUNCIONES().ListarParametros("DESCANSO_MEDICO", "ID_TIPO_DESCANSO");

            if (dtResultado.Rows.Count > 0)
            {

                cboTipoDescanso.ValueMember = "IDE_PARAMETRO";
                cboTipoDescanso.DisplayMember = "DES_ASUNTO";
                cboTipoDescanso.DataSource = dtResultado;

            }


        }
        public void tipoIncidente()
        {
            DataTable dtResultado = new DataTable();
            dtResultado = new BL_FUNCIONES().ListarParametros("DESCANSO_MEDICO", "ID_TIPO_INCIDENCIA");

            if (dtResultado.Rows.Count > 0)
            {

                cboTipoIncidencia.ValueMember = "IDE_PARAMETRO";
                cboTipoIncidencia.DisplayMember = "DES_ASUNTO";
                cboTipoIncidencia.DataSource = dtResultado;

            }

        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {

        }

        private void dtpFin_Leave(object sender, EventArgs e)
        {

        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            validarFechas();
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            validarFechas();
        }

        int validarFechas()
        {
            DateTime fechaIni = dtpInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date;

            if (fechaIni > fechaFin)
            {
                MessageBox.Show("La fecha fin no puede ser mayor a la fecha inicio");
                return 0;
            }
            int cuantosDiasPrestado;
            TimeSpan diferencia;
            diferencia = (fechaFin) - (fechaIni);
            cuantosDiasPrestado = diferencia.Days + 1;
            this.lblDias.Text = Convert.ToString(cuantosDiasPrestado);
            return 1;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validarFechas() == 0) {
                return;
            };

            DialogResult respuesta = MessageBox.Show("¿Desea guardar el descanso medico?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {

                BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
                DataTable dtResultado = new DataTable();

                ////////////////////////////////////////////////////////////////////////////////////
                string dni = txtDni.Text;
                string ubi = cboUbicacion.SelectedValue.ToString();
                DateTime fec_ini = dtpInicio.Value.Date;
                DateTime fec_fin = dtpFin.Value.Date;
                string tip_desc = cboTipoDescanso.SelectedValue.ToString();
                string tip_inc = cboTipoIncidencia.SelectedValue.ToString();
                string obs = txtObs.Text;
                string can_dias = lblDias.Text;

                dtResultado = obj.SP_INS_DESCANSO_MEDICO("0001", dni, ubi, fec_ini, fec_fin, tip_desc, tip_inc, obs, can_dias);

                MessageBox.Show("Descanso medico Registrado.");
                limpiarCampos();

            }



        }

        private void limpiarCampos() {
            txtDni.Text = "";
            LBL_PERSONAL.Text = "";
            txtObs.Text = "";
            lblDiasDm.Text = "";
            lblDiasSub.Text = "";
            btnGrabar.Visible = false;
            txtFecIng.Text = "";
            txtFecNac.Text = "";
            txtCat.Text = "";
            txtUbi.Text = "";
            dgDescansos.Visible = false;

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSustento_Click(object sender, EventArgs e)
        {
            String DirectorioFile = ConfigurationManager.AppSettings["DESCANSO_MEDICO"];

            string a = txtDni.Text;

            // crear carpeta por anio

            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();

            DirectorioFile = DirectorioFile + yy;//+ "-" // + cboMes.SelectedValue.ToString();

            //  crear carpeta 

            DirectorioFile = DirectorioFile + "-" + a;

            bool exists = System.IO.Directory.Exists(DirectorioFile);

            if (!exists)
                System.IO.Directory.CreateDirectory(DirectorioFile);

            OpenFileDialog openFileDialogCSV = new OpenFileDialog();

            openFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();
            //openFileDialogCSV.Filter = "(*.*)|*.*";
            openFileDialogCSV.FilterIndex = 1;
            openFileDialogCSV.RestoreDirectory = true;

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                this.txtFileToImport.Text = openFileDialogCSV.FileName.ToString();
                //System.IO.File.Copy(this.txtFileToImport.Text, targetPath);
                File.Copy(txtFileToImport.Text, Path.Combine(DirectorioFile, Path.GetFileName(txtFileToImport.Text)), true);

                MessageBox.Show("Archivo guardado en la ruta :" + DirectorioFile, "Archivo");


            }
        }       
       
    }
}
