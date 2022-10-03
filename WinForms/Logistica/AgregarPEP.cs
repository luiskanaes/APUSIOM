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
namespace WinForms.Logistica
{
    public partial class AgregarPEP : Form
    {
        public int varfNuevo;
        public AgregarPEP()
        {
            InitializeComponent();
            Pep();
            txtMaterial.Text = Solped.obj_SOLPED_E.MATERIAL;
             
        }

        private void AgregarPEP_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BL_LOG_SOLPED obj = new BL_LOG_SOLPED();
            DataTable dtResultado = new DataTable();
            if (ddl.SelectedValue.ToString () != string.Empty)

            {
                dtResultado = obj.uspUPDATE_LOG_MATERIALES_PEP(txtMaterial.Text, ddl.SelectedValue.ToString (), "", frmLogin.obj_user_E.IDE_USUARIO);

                if ( Convert.ToInt32 ( dtResultado.Rows[0]["ID"].ToString()) > 0)
                {
                    varfNuevo++;
                    MessageBox.Show("Registro satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
              
            }
        }
        protected void Pep()
        {
            BL_LOG_SOLPED obj = new BL_LOG_SOLPED();
            DataTable dtResultado = new DataTable();

            
            dtResultado = obj.uspSEL_PEP_CTA_CONTABLE();
            if (dtResultado.Rows.Count > 0)
            {
                ddl.DisplayMember = dtResultado.Columns["PEP"].ToString(); ;
                ddl.ValueMember = dtResultado.Columns["PEP"].ToString();
                ddl.DataSource = dtResultado;

            }
        }
    }
}
