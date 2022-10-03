using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;


namespace WinForms
{
    public partial class frmRegistroNuevaJunta : Form
    {
        public frmRegistroNuevaJunta()
        {
            InitializeComponent();
            cargarUbicacion();
            cargarTipoJunta();
            btnGrabar.Visible = false;
        }
             
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_DATOS_NUEVO_REGISTRO_JUNTAS("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text,txtNroJunta.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgJunta.DataSource = dtResultado;
                dgJunta.AutoResizeColumns();
                dgJunta.Visible = true;
                dgJuntaNueva.DataSource = null;
            }
            else
            {   
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                dgJunta.DataSource= null;                 
                txtNuevaJunta.Text = ""; return;                
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if(txtNuevaJunta.Text == "")
            {

                MessageBox.Show("INGRESE LA NUEVA JUNTA", "Advertencia", MessageBoxButtons.OK);
                return;

            }

            DataTable dtResultado = new DataTable();
            BL_MARCAS obj = new BL_MARCAS();
            dtResultado = obj.SP_VERIFICAR_DATOS_NUEVO_JUNTA("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtNroJunta.Text, txtNuevaJunta.Text);

            if (dtResultado.Rows[0]["TOTAL"].ToString() == "1")
            {
                MessageBox.Show("LA JUNTA " + txtNroJunta.Text + txtNuevaJunta.Text + " YA EXISTE FAVOR DE VERIFICAR", "ADVERTENCIA", MessageBoxButtons.OK);
                return;
            }
            else {
                dtResultado = null;
            }

            //if (dgJunta.Rows.Count == 2)
            //{
            BL_MARCAS obj2 = new BL_MARCAS();
                DataTable dtResultado2 = new DataTable();
                dtResultado2 = obj2.SP_GENERAR_DATOS_NUEVO_REGISTRO_JUNTAS("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtNroJunta.Text, txtNuevaJunta.Text,cboTipoJunta.SelectedValue.ToString(),cboUbicacion.SelectedValue.ToString());

                if (dtResultado2.Rows.Count > 0)
                {
                    dgJuntaNueva.DataSource = dtResultado2;
                    dgJuntaNueva.AutoResizeColumns();
                    dgJuntaNueva.Visible = true;
                    btnGrabar.Visible = true;
            }
                else {
                    dgJuntaNueva.DataSource = null;
                }

            //}
            //else
            //{
            //    MessageBox.Show("La lista superior solo debe contener una fila para poder generar la siguiente junta","Advertencia", MessageBoxButtons.OK);
            //}
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtDiametro.Text.Equals("")) {
                MessageBox.Show("INGRESE EL DIAMETRO DE LA JUNTA", "ADVERTENCIA", MessageBoxButtons.OK);
                return;
            }

            DataTable dtResultado = new DataTable();
            BL_MARCAS obj = new BL_MARCAS();
            dtResultado = obj.SP_VERIFICAR_DATOS_NUEVO_JUNTA("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtNroJunta.Text, txtNuevaJunta.Text);

            if (dtResultado.Rows[0]["TOTAL"].ToString() == "1")
            {
                MessageBox.Show("LA JUNTA " + txtNroJunta.Text + txtNuevaJunta.Text + " YA EXISTE FAVOR DE VERIFICAR", "ADVERTENCIA", MessageBoxButtons.OK);
                return;
            }
            else {
            dtResultado = null;
            }

            dtResultado = obj.SP_GRABAR_DATOS_NUEVO_JUNTA("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtNroJunta.Text, txtNuevaJunta.Text, cboTipoJunta.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(),txtDiametro.Text);

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show("Registro exitoso!!!", "OK", MessageBoxButtons.OK);
                dgJuntaNueva.DataSource = null;
                txtNuevaJunta.Text = "";
                txtDiametro.Text = "";
                btnGrabar.Visible = false;
            }
            else {
                dgJuntaNueva.DataSource = null;
            }

            dtResultado = null;

            dtResultado = obj.SP_CONSULTAR_DATOS_NUEVO_REGISTRO_JUNTAS("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtNroJunta.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgJunta.DataSource = dtResultado;
                dgJunta.AutoResizeColumns();
                dgJunta.Visible = true;
                dgJuntaNueva.DataSource = null;
            }
            else
            {
                dgJunta.DataSource = null;
                txtNuevaJunta.Text = "";
                txtDiametro.Text = "";
            }
        }

        private void frmRegistroNuevaJunta_Load(object sender, EventArgs e)
        {

        }

        private void cargarTipoJunta()
        {
            cboTipoJunta.DataSource = new BindingSource(TipoJunta, null);
            cboTipoJunta.DisplayMember = "Value";
            cboTipoJunta.ValueMember = "Value";
        }

        public static Dictionary<int, string> TipoJunta = new Dictionary<int, string>()
        {
            {1,"BW"},
            {2,"SW"},
            {3,"TH"},
            {4,"FJ"},
            {5,"BR"},
            {6,"RJ"},
            {7,"SW0"},
            {8,"RP"} ,
            {9,"SP"}

        };

        private void cargarUbicacion()
        {
            cboUbicacion.DataSource = new BindingSource(Ubicacion, null);
            cboUbicacion.DisplayMember = "Value";
            cboUbicacion.ValueMember = "Value";
        }

        public static Dictionary<int, string> Ubicacion = new Dictionary<int, string>()
        {
            {1,"FW"},
            {2,"WS"} 
        };

        private void txtNuevaJunta_TextChanged(object sender, EventArgs e)
        {
            btnGrabar.Visible = false;
        }
    }
}
