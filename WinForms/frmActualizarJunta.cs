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


namespace WinForms
{
    public partial class frmActualizarJunta : Form
    {
        public frmActualizarJunta()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_JUNTA(txtJunta.Text.Trim());

            if (dtResultado.Rows.Count > 0)
            {
                txtJuntaNueva.Text = dtResultado.Rows[0]["JuntaNueva"].ToString();
                txtArea.Text = dtResultado.Rows[0]["Area"].ToString();
                txtServicio.Text = dtResultado.Rows[0]["Servicio"].ToString();
                txtLinea.Text = dtResultado.Rows[0]["Linea"].ToString();
                txtTrain.Text = dtResultado.Rows[0]["Train"].ToString();
                
            }
            else
            {
                MessageBox.Show("JUNTA NO EXISTE");
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            string junta,juntanueva, area, serv, line, train;

            junta = txtJunta.Text;
            juntanueva = txtJuntaNueva.Text;
            area = txtArea.Text;
            serv = txtServicio.Text;
            line = txtLinea.Text; 
            train = txtTrain.Text;

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_GRABAR_JUNTA(txtJunta.Text.Trim(), juntanueva, area, serv, line, train);

            if (dtResultado.Rows[0]["VALOR"].ToString().Equals( "1"))
            {
                
                MessageBox.Show("JUNTA GRABADA"); limpiar();
            }
            else
            {
                MessageBox.Show("LA JUNTA EXISTE EN LA BD");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string junta, juntanueva, area, serv, line, train,matc,jtype;

            junta = "nueva";
            juntanueva = txtJuntaNueva2.Text;
            area = txtArea2.Text;
            serv = txtServicio2.Text;
            line = txtLinea2.Text;
            train = txtTrain2.Text;
            matc = txtMat.Text;
            jtype = txtJoint.Text;

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();

            if (validarcampos() == 1)
            {

                dtResultado = obj.SP_GRABAR_JUNTA_NUEVA(junta, juntanueva, area, serv, line, train,matc,jtype);
                if (dtResultado.Rows[0]["VALOR"].ToString().Equals("1"))
                {
                    MessageBox.Show("JUNTA GRABADA"); limpiar();
                }
                else
                {
                    MessageBox.Show("LA JUNTA EXISTE EN LA BD");
                }
            }
            else {

                MessageBox.Show("Debe llenar todos los campos");

            }
                                  
            
        }

        int validarcampos()
        {
            string  juntanueva, area, serv, line, train;

            juntanueva = txtJuntaNueva2.Text;
            area = txtArea2.Text;
            serv = txtServicio2.Text;
            line = txtLinea2.Text;
            train = txtTrain2.Text;
            if (juntanueva.Equals("")) {
                return 0;
            }
            if (juntanueva.Equals(""))
            {
                return 0;
            }
            if (area.Equals(""))
            {
                return 0;
            }
            if (serv.Equals(""))
            {
                return 0;
            }
            if (line.Equals(""))
            {
                return 0;
            }
            if (train.Equals(""))
            {
                return 0;
            }
            return 1;

        }

        void limpiar() {

            txtJunta.Text = "";
            txtJuntaNueva.Text = "";
            txtArea.Text = "";
            txtServicio.Text = "";
            txtLinea.Text = "";
            txtTrain.Text = "";
             
            txtJuntaNueva2.Text = "";
            txtArea2.Text = "";
            txtServicio2.Text = "";
            txtLinea2.Text = "";
            txtTrain2.Text = "";
            txtMat.Text = "";
            txtJoint.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
