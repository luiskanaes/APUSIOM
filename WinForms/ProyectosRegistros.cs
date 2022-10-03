using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;


namespace WinForms
{
    public partial class ProyectosRegistros : Form
    {
        string IDE_EMPRESA = string.Empty;
        public ProyectosRegistros()
        {
            InitializeComponent();
            ListarEmpresa("");
            cargasEstados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea grabar proyecto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                if (txtCodigo.Text.Trim()== string.Empty )
                {
                    MessageBox.Show("Ingresar codigo de proyecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtNombre.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingresar nombre de proyecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (cboEmpresa.SelectedValue.ToString() == string.Empty)
                {
                    MessageBox.Show("Seleccionar empresa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if( Convert.ToDecimal( txtTotal.Text)<=48)
                    {
                        Guardar();
                    }
                    else
                    {
                        MessageBox.Show("Total de horas excede las 48hrs semanales", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    
                }

            }
        }
        protected void Guardar()
        {
            string COD_IDE_EMPRESA = string.IsNullOrEmpty(IDE_EMPRESA.ToString()) ? cboEmpresa.SelectedValue.ToString() : IDE_EMPRESA.ToString();
            BE_CECOS oBESol = new BE_CECOS();
            oBESol.ID = txtCodigo.Text.Trim();  
            oBESol.COD_PROYECTO =   string.Empty    ;
            oBESol.DESCRIPCION =  txtNombre.Text.Trim();
            oBESol.NOMBRE_CORTO =  string.Empty    ;
            oBESol.IDE_EMPRESA = Convert.ToInt32(COD_IDE_EMPRESA)   ;
            oBESol.FLG_ESTADO = Convert.ToInt32(cboEstado.SelectedValue);
            oBESol.FLG_CORREO = 1;
            oBESol.CLIENTE = string.Empty;
            oBESol.UBICACION = string.Empty;
           
            int T_STANDAR = 0;
            if (checkStandar.Checked)
            {
                T_STANDAR = 1;
            }

            int T_PERSONZALIZADO = 0;
            if (checkPersonalizado.Checked)
            {
                T_PERSONZALIZADO = 1;
            }
          
            oBESol.T_STANDAR = T_STANDAR;
            oBESol.T_PERSONZALIZADO = T_PERSONZALIZADO;
            oBESol.COD_PLANILLA = txtCodPlanilla.Text.Trim();
            int rpta = 0;
            rpta = new BL_CECOS().uspINS_CECOS(oBESol);
            if (rpta > 0)
            {

                GuardarJornada(txtCodigo.Text.Trim(), COD_IDE_EMPRESA, 1, txtLun.Text.Trim(), string.IsNullOrEmpty(checkBox1.Checked.ToString()) ? "0" : checkBox1.Checked.ToString());
                GuardarJornada(txtCodigo.Text.Trim(), COD_IDE_EMPRESA, 2, txtMar.Text.Trim(), string.IsNullOrEmpty(checkBox2.Checked.ToString()) ? "0" : checkBox2.Checked.ToString());
                GuardarJornada(txtCodigo.Text.Trim(), COD_IDE_EMPRESA, 3, txtMie.Text.Trim(), string.IsNullOrEmpty(checkBox3.Checked.ToString()) ? "0" : checkBox3.Checked.ToString());
                GuardarJornada(txtCodigo.Text.Trim(), COD_IDE_EMPRESA, 4, txtJuev.Text.Trim(), string.IsNullOrEmpty(checkBox4.Checked.ToString()) ? "0" : checkBox4.Checked.ToString());
                GuardarJornada(txtCodigo.Text.Trim(), COD_IDE_EMPRESA, 5, txtVie.Text.Trim(), string.IsNullOrEmpty(checkBox5.Checked.ToString()) ? "0" : checkBox5.Checked.ToString());
                GuardarJornada(txtCodigo.Text.Trim(), COD_IDE_EMPRESA, 6, txtSab.Text.Trim(), string.IsNullOrEmpty(checkBox6.Checked.ToString()) ? "0" : checkBox6.Checked.ToString());
                GuardarJornada(txtCodigo.Text.Trim(), COD_IDE_EMPRESA, 7, txtDom.Text.Trim(), string.IsNullOrEmpty(checkBox7.Checked.ToString()) ? "0" : checkBox7.Checked.ToString());
                MessageBox.Show("Registro correcto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listarDatos();
            }
        }
        protected void GuardarJornada(string CCOSTO, string IDE_EMPRESA, int NRO_DIA, string HORAS_TRABAJO, string   FLG_100)
        {
            BE_JORNADAS oBE = new BE_JORNADAS();
            oBE.IDE_HORARIOS = 0;
            oBE.DES_DIA =   string.Empty   ;
            oBE.NRO_DIA = NRO_DIA;
            oBE.HORAS_TRABAJO = Convert.ToDecimal(string.IsNullOrEmpty(HORAS_TRABAJO) ? "0" :  HORAS_TRABAJO);
            oBE.CCOSTO = CCOSTO;
            oBE.IDE_EMPRESA =Convert.ToInt32( IDE_EMPRESA);
            oBE.FLG_100 = Convert.ToBoolean(FLG_100);
            int rpta = 0;
            rpta = new BL_CECOS().uspINS_JORNADAS(oBE);
        }
        private void ProyectosRegistros_Load(object sender, EventArgs e)
        {
            //ListarEmpresa("");
            //cargasEstados();
        }
        protected void ListarEmpresa(string empresa)
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.uspSEL_EMPRESA_ID(empresa);
            if (dtResultado.Rows.Count > 0)
            {
                cboEmpresa.ValueMember = "ID_EMPRESA";
                cboEmpresa.DisplayMember = "SOCIEDAD_EMPRESA";
                cboEmpresa.DataSource = dtResultado;

            }
            
        }
        private void cargasEstados()
        {
            cboEstado.DataSource = new BindingSource(Estado, null);
            cboEstado.DisplayMember = "Value";
            cboEstado.ValueMember = "Key";
            cboEstado.SelectedIndex = 0;
            //cboEstado.SelectedValue = 1;
        }
        public static Dictionary<int, string> Estado = new Dictionary<int, string>()
        {
            {1 ,"HABILITADO"},
            {0 ,"BLQOUEADO"}
        };

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarDatos();
        }
        protected void listarDatos()
        {

            BL_CECOS obj = new BL_CECOS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.uspSEL_CECOS_POR_ID(txtCodigo.Text.Trim());
            if (dtResultado.Rows.Count > 0)
            {

                txtCodigo.Text = dtResultado.Rows[0]["ID"].ToString();
                txtNombre.Text = dtResultado.Rows[0]["DESCRIPCION"].ToString();
                txtCodPlanilla.Text = dtResultado.Rows[0]["cod_planilla"].ToString();
                string estado = dtResultado.Rows[0]["FLG_ESTADO"].ToString();
                IDE_EMPRESA = dtResultado.Rows[0]["IDE_EMPRESA"].ToString();
                ListarEmpresa(IDE_EMPRESA);
           
                cboEmpresa.SelectedValue = IDE_EMPRESA;
                cboEmpresa.SelectedIndex = 0;

                if (estado == "True")
                {
                    cboEstado.SelectedIndex = 0;
                }
                else
                {
                    cboEstado.SelectedIndex = 1;
                }


                string T_STANDAR = dtResultado.Rows[0]["T_STANDAR"].ToString();
                if (T_STANDAR == "1")
                {
                    checkStandar.Checked=true;
                }
                else
                {
                    checkStandar.Checked = false;
                }

                string T_PERSONZALIZADO = dtResultado.Rows[0]["T_PERSONZALIZADO"].ToString();
                if (T_PERSONZALIZADO == "1")
                {
                    checkPersonalizado.Checked = true;
                }
                else
                {
                    checkPersonalizado.Checked = false;
                }

            }


            DataTable dt = new DataTable();
            dt = obj.uspSEL_JORNADAS_POR_CC(txtCodigo.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                txtLun.Text = dt.Rows[0]["HORAS_TRABAJO"].ToString();
                txtMar.Text = dt.Rows[1]["HORAS_TRABAJO"].ToString();
                txtMie.Text = dt.Rows[2]["HORAS_TRABAJO"].ToString();
                txtJuev.Text = dt.Rows[3]["HORAS_TRABAJO"].ToString();
                txtVie.Text = dt.Rows[4]["HORAS_TRABAJO"].ToString();
                txtSab.Text = dt.Rows[5]["HORAS_TRABAJO"].ToString();
                txtDom.Text = dt.Rows[6]["HORAS_TRABAJO"].ToString();

                checkBox1.Checked = Convert.ToBoolean(dt.Rows[0]["FLG_100"].ToString());
                checkBox2.Checked = Convert.ToBoolean(dt.Rows[1]["FLG_100"].ToString());
                checkBox3.Checked = Convert.ToBoolean(dt.Rows[2]["FLG_100"].ToString());
                checkBox4.Checked = Convert.ToBoolean(dt.Rows[3]["FLG_100"].ToString());
                checkBox5.Checked = Convert.ToBoolean(dt.Rows[4]["FLG_100"].ToString());
                checkBox6.Checked = Convert.ToBoolean(dt.Rows[5]["FLG_100"].ToString());
                checkBox7.Checked = Convert.ToBoolean(dt.Rows[6]["FLG_100"].ToString());
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            decimal isNumber = 0;
            e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
        }
        private void txtLun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Si deseas, puedes permitir numeros decimales (o float)
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Si deseas, puedes permitir numeros decimales (o float)
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Si deseas, puedes permitir numeros decimales (o float)
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtJuev_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Si deseas, puedes permitir numeros decimales (o float)
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtVie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Si deseas, puedes permitir numeros decimales (o float)
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Si deseas, puedes permitir numeros decimales (o float)
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            //suma();
        }

        private void txtDom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Si deseas, puedes permitir numeros decimales (o float)
            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtTotal.Text = "0";
            checkPersonalizado.Checked = false;
            checkStandar.Checked = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = true ;


            IDE_EMPRESA = string.Empty;
            ListarEmpresa("");
            cargasEstados();
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;

            txtLun.Text = string.Empty;
            txtMar.Text = string.Empty;
            txtMie.Text = string.Empty;
            txtJuev.Text = string.Empty;
            txtVie.Text = string.Empty;
            txtSab.Text = string.Empty;
            txtDom.Text = string.Empty;
        }

        private void txtLun_TextChanged(object sender, EventArgs e)
        {

            suma();
        }

        private void txtMar_TextChanged(object sender, EventArgs e)
        {
            suma();
        }

        private void txtMie_TextChanged(object sender, EventArgs e)
        {
            suma();
        }

        private void txtJuev_TextChanged(object sender, EventArgs e)
        {
            suma();
        }

        private void txtVie_TextChanged(object sender, EventArgs e)
        {
            suma();
        }

        private void txtSab_TextChanged(object sender, EventArgs e)
        {
            suma();
        }

        private void txtDom_TextChanged(object sender, EventArgs e)
        {
            suma();
        }

        protected void suma()
        {
            decimal lun=  Convert.ToDecimal(string.IsNullOrEmpty(txtLun.Text) ? "0" : txtLun.Text);
            decimal mar = Convert.ToDecimal(string.IsNullOrEmpty(txtMar.Text) ? "0" : txtMar.Text);
            decimal mier = Convert.ToDecimal(string.IsNullOrEmpty(txtMie.Text) ? "0" : txtMie.Text);
            decimal jue = Convert.ToDecimal(string.IsNullOrEmpty(txtJuev.Text) ? "0" : txtJuev.Text);
            decimal vie = Convert.ToDecimal(string.IsNullOrEmpty(txtVie.Text) ? "0" : txtVie.Text);
            decimal sab = Convert.ToDecimal(string.IsNullOrEmpty(txtSab.Text) ? "0" : txtSab.Text);
            decimal dom = Convert.ToDecimal(string.IsNullOrEmpty(txtDom.Text) ? "0" : txtDom.Text);

            decimal total = lun + mar + mier + jue + vie + sab + dom;

            if (checkBox1.Checked )
            {
                total = total - lun;
            }

            if (checkBox2.Checked)
            {
                total = total - mar ;
            }

            if (checkBox3.Checked)
            {
                total = total - mier ;
            }

            if (checkBox4.Checked)
            {
                total = total - jue ;
            }

            if (checkBox5.Checked)
            {
                total = total - vie ;
            }

            if (checkBox6.Checked)
            {
                total = total - sab;
            }

            if (checkBox7.Checked)
            {
                total = total - dom;
            }

            txtTotal.Text = total.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtLun.Text = "0";
            suma();
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtMar.Text = "0";
            suma();
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            txtMie.Text = "0";
            suma();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            txtJuev.Text = "0";
            suma();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            txtVie.Text = "0";
            suma();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            txtSab.Text = "0";
            suma();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            txtDom.Text = "0";
            suma();
        }
    }
}
