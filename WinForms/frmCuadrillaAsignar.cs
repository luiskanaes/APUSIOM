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
    public partial class frmCuadrillaAsignar : Form
    {
        public int varfNuevo;
        public frmCuadrillaAsignar()
        {
            InitializeComponent();

            btnUltima.BackColor = Color.FromArgb(249, 39, 39);
            btnUltima.ForeColor = Color.FromArgb(255, 255, 255);
            btnUltima.Font = new Font(btnUltima.Font.Name, btnUltima.Font.Size, FontStyle.Bold);


            btnFecha.BackColor = Color.FromArgb(249, 39, 39);
            btnFecha.ForeColor = Color.FromArgb(255, 255, 255);
            btnFecha.Font = new Font(btnFecha.Font.Name, btnFecha.Font.Size, FontStyle.Bold);

            txtIngeniero.Text = frmControlTareoDigitacion.obj_Tareas_E.NOMBRE_INGCAMPO.ToString();
            txtResponsable.Text = frmControlTareoDigitacion.obj_Tareas_E.NOMBRE_CAPATAZ.ToString();
        }

        private void frmCuadrillaAsignar_Load(object sender, EventArgs e)
        {
           
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            cargarCuadrillas(1);
        }

        protected void cargarCuadrillas(int TIPO )
        {
            //---@TIPO SI 1 CONSULTA ULTIMA CUADRILLA
            //--  @TIPO ES 0 CONSULTA FECHA
            string mensaje = string.Empty;
            if (TIPO == 1)
            {
                mensaje = "¿Desea cargar última cuadrilla de trabajo ";
            }
            else
            {
                mensaje = "¿Desea cargar cuadrilla de trabajo de fecha " + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");
            }


            DialogResult respuesta = MessageBox.Show(mensaje  + " ?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                BL_TAREO obj = new BL_TAREO();
                BL_CUADRILLA objCuadrilla = new BL_CUADRILLA();
                DataTable dtResulTareo = new DataTable();

                dtResulTareo = obj.SP_CARGA_ULTIMA_CUADRILLA(
                    frmControlTareoDigitacion.obj_Tareas_E.CENTRO_COSTO,
                    frmControlTareoDigitacion.obj_Tareas_E.FECHA_TAREO,
                    frmControlTareoDigitacion.obj_Tareas_E.IDE_CAPATAZ,
                    frmControlTareoDigitacion.obj_Tareas_E.IDE_INGCAMPO,
                    TIPO ,
                    dateTimePicker1.Value.Date.ToString("dd/MM/yyyy")
                    );

                objCuadrilla.SP_OBTENER_CUADRILLA_X_FECHA(
                     frmControlTareoDigitacion.obj_Tareas_E.CENTRO_COSTO, 
                     Convert.ToInt32(frmControlTareoDigitacion.obj_Tareas_E.IDE_EMPRESA),
                     frmControlTareoDigitacion.obj_Tareas_E.IDE_CAPATAZ,
                     frmControlTareoDigitacion.obj_Tareas_E.FECHA_TAREO,
                     frmControlTareoDigitacion.obj_Tareas_E.IDE_INGCAMPO,
                     frmControlTareoDigitacion.obj_Tareas_E.NOMBRE_DIA
                    );


                if (dtResulTareo.Rows.Count > 0)
                {
                    varfNuevo++;
                    MessageBox.Show("Actualización satisfactoria", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Existen problema con el llenado de cuadrilla", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            cargarCuadrillas(0);
        }
    }
}
