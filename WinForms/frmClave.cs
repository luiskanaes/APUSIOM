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
    public partial class frmClave : Form
    {
        public frmClave()
        {
            InitializeComponent();
        }

        private void frmClave_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea actulizar contraseña?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                if (txtpass1.Text == string.Empty)
                {
                    MessageBox.Show("Ingresar contraseña nueva", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtpass1.Text == string.Empty)
                {
                    MessageBox.Show("Ingresar confirmación de contraseña nueva", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(txtpass1.Text != txtpass2.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BL_TBUSUARIO obj = new BL_TBUSUARIO();
                    DataTable dtResultado = new DataTable();
                    dtResultado = obj.SP_UPDATE_CONTRASENIA(txtpass1.Text.Trim(), frmLogin.obj_user_E.IDE_USUARIO);

                    MessageBox.Show("Contraseña actualizada", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
