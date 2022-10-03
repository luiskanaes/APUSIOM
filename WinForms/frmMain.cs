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
namespace WinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                BusinessLogic.BL_FUNCIONES.f_llenar_menu(menuPrincipal, frmLogin.obj_perfil_E.IdPerfil);

                SetDatosPublicos( ls_error);
                foreach (ToolStripMenuItem option in menuPrincipal.Items) this.SetOnclick(option);

            }
            else
            {
                MessageBox.Show(ls_error);
            }

        }



        private void SetDatosPublicos(string ls_error)
        {
            string x = ls_error;
            ts_Usuario.Text = "Usuario: " + frmLogin.obj_user_E.DES_NOMBRE_USUARIO;
            lblServer.Text = "Ambiente : " + frmLogin.obj_user_E.SERVER + " (" + ls_error + ")"; ;
        }
        public void SetOnclick(ToolStripMenuItem option)
        {
            foreach (ToolStripItem i in option.DropDownItems)
                if (i is ToolStripMenuItem)
                {
                    if (!string.IsNullOrEmpty(i.Name.ToString())) i.Click += new EventHandler(MenuClick);
                    SetOnclick((ToolStripMenuItem)i);
                }

            if (option.Name.ToString() == "SALIR") option.Click += new EventHandler(MenuClick);

        }
        private void MenuClick(object sender, EventArgs e)
        {
            //

            string sFormName = ((ToolStripMenuItem)sender).Tag.ToString();

            if (sFormName == "SALIR")
            {
                this.frmMain_FormClosing(sender, new FormClosingEventArgs(new CloseReason(), true));
            }
            else
            {


                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

                Form frm = (Form)asm.CreateInstance(sFormName);
                cheCarForm(frm, this);
                //frm.MdiParent = this;
                //frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                //frm.Show();

            }


        }

        private bool IsFormOpen(Type formType)
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType().Name == form.Name)
                    return true;
            return false;
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!frmLogin.bSalir)
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea Salir del Sistema?", "Salir de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    new frmLogin().CerrarAplicativo();
                }
            }
        }
        public void cheCarForm(Form frmhijo, Form frmpapa)
        {
            bool cargado = false;
            foreach (Form llamado in frmpapa.MdiChildren)
            {
                if (llamado.Text == frmhijo.Text)
                {

                    llamado.Activate(); //Activar el form y,
                    return; //Salir de la función;

                    //cargado = true;
                    //break;
                }

            }
            if (!cargado)
            {
                frmhijo.MdiParent = frmpapa;
                frmhijo.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frmhijo.Show();
            }
        }
       
    }
}
