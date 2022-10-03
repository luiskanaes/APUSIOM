using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;

namespace WinForms
{
    public partial class frmLogin : Form
    {
        public static BE_TBUSUARIO obj_user_E;
        public static BE_TBPERFIL obj_perfil_E;
        public static bool bSalir = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            int anio = DateTime.Now.Year;
            lblMensaje.Text = "SIOM - Copyright © " + Convert.ToString(anio);// + " SSK Ingeniería y Construcción SAC";
            txtUsuario.CharacterCasing = CharacterCasing.Upper;
            this.ActiveControl = txtUsuario;
            SetDefault(btnIngresar);

            timer1.Start();
        }
             private void SetDefault(Button btnDefault)
        {
            this.AcceptButton = btnDefault;
        }
        private void validarTXT(TextBox txt, String msg, CancelEventArgs e)
        {
            if (txt.Text == "")
            {
                errorProvider1.SetError(txt, msg);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txt, "");
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            validarTXT(txtUsuario, "Debe ingresar su usuario", e);
        }


        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            validarTXT(txtPassword, "Debe ingresar su contraseña", e);
        }
        public void CerrarAplicativo()
        {
            frmLogin.bSalir = true;
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                if (this.ValidateChildren())
                {
                    BL_TBUSUARIO obj_user_B = new BL_TBUSUARIO();
                    BE_TBUSUARIO oBE_Usuario = new BE_TBUSUARIO();
                    string pMesajeResp = string.Empty;

                    oBE_Usuario.IDE_USUARIO = txtUsuario.Text;
                    oBE_Usuario.DES_PASSWORD = txtPassword.Text;


                    string pMessageServer = string.Empty;
                    DialogResult respuesta = new DialogResult();
                    DataTable dtResultado = new DataTable();

                    dtResultado = obj_user_B.f_LogeoUsuario_B(oBE_Usuario);
                    if (dtResultado.Rows.Count == 0)
                    {
                        respuesta = MessageBox.Show("Datos Incorrectos!!", ".:: Login ::.", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        if (respuesta != DialogResult.Retry)
                        {
                            this.Close();
                            Application.Exit();
                        }
                    }
                    else
                    {
                        obj_user_E = new BE_TBUSUARIO();
                        obj_perfil_E = new BE_TBPERFIL();
                        obj_perfil_E.IdPerfil = Convert.ToInt32(dtResultado.Rows[0]["IdPerfil"].ToString());
                        obj_perfil_E.Descripcion = dtResultado.Rows[0]["Descripcion"].ToString();
                        obj_user_E.IDE_USUARIO = dtResultado.Rows[0]["IDE_USUARIO"].ToString();
                        obj_user_E.DES_NOMBRE_USUARIO = dtResultado.Rows[0]["DES_NOMBRE_USUARIO"].ToString();
                        obj_user_E.IDE_EMPRESA = Convert.ToInt32(dtResultado.Rows[0]["IDE_EMPRESA"].ToString());
                        obj_user_E.CCOSTO = dtResultado.Rows[0]["CCOSTO"].ToString();
                        //obj_user_E.SERVER  = dtResultado.Rows[0]["SERVER"].ToString();
                        this.Hide();
                        //frmEfecto f = new frmEfecto();
                        //f.Hide();
                        new frmMain().ShowDialog();
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar los campos obligatorios", "Falta Ingresar Campos Obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {

                MessageBox.Show(ls_error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
         
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .01;
            //frmEfecto f = new frmEfecto();
            //f.Opacity = f.Opacity - .01;
            if (this.Opacity == 1)
            {
                //frmEfecto f = new frmEfecto();
                //f.Hide();
                timer1.Stop();
               
            }
        }
    }
}
