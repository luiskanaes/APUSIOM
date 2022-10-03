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

namespace WinForms
{
    public partial class frmAsignarNuevoResponsable : Form
    {
        public int varfMigracion;
        public frmAsignarNuevoResponsable()
        {
            InitializeComponent();
        }

        private void frmAsignarNuevoResponsable_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if(txtDni1.Text.Trim()!= string.Empty )
            {
                BL_PERSONAL obj = new BL_PERSONAL();
                DataTable dtResultado = new DataTable();
                dtResultado = obj.SP_OBTENER_PERSONAL_x_DNI(frmAsignacionPersonal.obj_asignacion_E.IDE_EMPRESA.ToString(), frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO, txtDni1.Text.Trim());
                if (dtResultado.Rows.Count > 0)
                {
                    txtpersonal1.Text= dtResultado.Rows[0]["NOMBRES"].ToString();
                    txtcargo1.Text = dtResultado.Rows[0]["GRUPO"].ToString();
                    lblCodigo1.Text = dtResultado.Rows[0]["IDE_PERSONAL"].ToString();
                }
                else
                {
                    MessageBox.Show("No existe personal", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingresar Dni", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtDni2.Text.Trim() != string.Empty)
            {
                BL_PERSONAL obj = new BL_PERSONAL();
                DataTable dtResultado = new DataTable();
                dtResultado = obj.SP_OBTENER_PERSONAL_x_DNI(frmAsignacionPersonal.obj_asignacion_E.IDE_EMPRESA.ToString(), frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO, txtDni2.Text.Trim());
                if (dtResultado.Rows.Count > 0)
                {
                    txtpersonal2.Text = dtResultado.Rows[0]["NOMBRES"].ToString();
                    txtcargo2.Text = dtResultado.Rows[0]["GRUPO"].ToString();
                    lblCodigo2.Text = dtResultado.Rows[0]["IDE_PERSONAL"].ToString();
                }
                else
                {
                    MessageBox.Show("No existe personal", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingresar Dni", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if ((isInt32(lblCodigo1.Text )==false) )
            {
                MessageBox.Show("Faltar consultar datos del personal a retirar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ( (isInt32(lblCodigo2.Text) == false))
            {
                MessageBox.Show("Faltar consultar datos del personal nuevo", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Desea realizar la asignación?" + " " + Environment.NewLine +
                                   "RESUMEN" + Environment.NewLine + Environment.NewLine +
                                   "El Sr. " + txtpersonal1.Text + ", dejara su cargo el día " + date1.Value.Date.ToString("dd/MM/yyyy") + Environment.NewLine +
                                   "y a partir de la fecha " + date2.Value.Date.ToString("dd/MM/yyyy") + " el Sr. " + txtpersonal2.Text +  " asume responsabilidades. "
                                   , "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    BL_PERSONAL objPersona = new BL_PERSONAL();
                    objPersona.uspASIGNAR_NUEVO_RESPONSABLE(
                        Convert.ToInt32(lblCodigo1.Text),
                        Convert.ToInt32(lblCodigo2.Text),
                     
                        frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO,
                        date1.Value.Date.ToString("dd/MM/yyyy"),
                        date2.Value.Date.ToString("dd/MM/yyyy")
                        );


                    MessageBox.Show("Asignación satisfactoria", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

               
        }
        public bool isInt32(String num)
        {
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
