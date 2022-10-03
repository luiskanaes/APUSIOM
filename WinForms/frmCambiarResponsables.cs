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
    public partial class frmCambiarResponsables : Form
    {
        public frmCambiarResponsables()
        {
            InitializeComponent();
            Ing();
            //ListarCapataz();
        }

        private void frmCambiarResponsables_Load(object sender, EventArgs e)
        {

        }
        protected void Ing()
        {
            DateTime today = DateTime.Today;


            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(
                frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO, 
                "1", 
                "1", 
                string.Empty ,
                today.ToString("dd/MM/yyyy")
                );
            if (dtResultado.Rows.Count > 0)
            {
                cboIngeniero.ValueMember = "ID_PERSONAL";
                cboIngeniero.DisplayMember = "NOMBRES";
                cboIngeniero.DataSource = dtResultado;

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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lblCodigo2.Text == string.Empty )
            {
                MessageBox.Show("Faltar consultar datos del personal nuevo", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Desea realizar el cambio de cuadrilla?" + " " + Environment.NewLine +
                                   "RESUMEN" + Environment.NewLine + Environment.NewLine +
                                   "El Sr. " + cboCapataces.Text + ", con fecha " + date2.Value.Date.ToString("dd/MM/yyyy") + Environment.NewLine +
                                   "pasará al grupo del Sr. " + txtpersonal2.Text 
                                   , "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    BL_ASIGNACION_TAREAS  objPersona = new BL_ASIGNACION_TAREAS();
                    objPersona.uspASIGNAR_CAMBIO_CUADRILLA(
                        cboCapataces.SelectedValue.ToString() ,
                        txtDni2.Text.Trim (),
                        cboIngeniero.SelectedValue.ToString(),
                        frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO,
                        date2.Value.Date.ToString("dd/MM/yyyy")
                        );


                    MessageBox.Show("Asignación satisfactoria", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCapataz();
        }
        protected void ListarCapataz()
        {
            DateTime today = DateTime.Today;


            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(
               frmAsignacionPersonal.obj_asignacion_E.CENTRO_COSTO,
               "1",
               "2",
               cboIngeniero.SelectedValue.ToString(),
               today.ToString("dd/MM/yyyy")
               );


            if (dtResultado.Rows.Count > 0)
            {
                cboCapataces.Visible = true;
                cboCapataces.ValueMember = "ID_PERSONAL";
                cboCapataces.DisplayMember = "NOMBRES";
                cboCapataces.DataSource = dtResultado;
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
    }
}
