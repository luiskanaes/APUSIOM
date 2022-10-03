using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.TareoPersonal;

namespace WinForms
{
    public partial class frmDesmovilizacionTareo : Form
    {
        public frmDesmovilizacionTareo()
        {
        InitializeComponent();

            lblNombres.Text = frmTareo_Empleados.DNI +" - "+ frmTareo_Empleados.NOMBRES; 
            string dni;
            dni = frmTareo_Empleados.DNI;
            

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (verificarUltDesmovilizacion() == 0) {

                return;
            }

            

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable(); 
            dtResultado = obj.SP_GRABAR_EMP_HISTORICO_MOVI(frmTareo_Empleados.MES, frmTareo_Empleados.ANIO, "016", frmTareo_Empleados.DNI, "31/01/9999" , dtpFechaDesmovilizacion.Text, frmTareo_Empleados.EMPRESA);
            if (dtResultado.Rows.Count > 0)
            {

               obj.SP_CORREO_MOVIMIENTO_UBICACION_PERSONAL(frmTareo_Empleados.NOMBRES, "DESMOVILIZADO DE OBRA TEMPORAL",frmTareo_Empleados.DNI, frmTareo_Empleados.MES,frmTareo_Empleados.EMPRESA,frmTareo_Empleados.DES_UBI);

            }
                this.Close();
        }

        int   verificarUltDesmovilizacion()
        {

            int flg = 0;
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();

            if (DateTime.Parse(dtpFechaDesmovilizacion.Text.ToString()).Month.ToString() == (frmTareo_Empleados.MES))
            {


            }
            else
            {
                MessageBox.Show("Fecha no corresponde al mes de trabajo...");
                flg = 0;
                return flg;
            }

            dtResultado = obj.SP_VERIFICAR_ULT_DESMOVILIZACION(frmTareo_Empleados.MES, frmTareo_Empleados.ANIO, "016", frmTareo_Empleados.DNI, "31/01/9999", dtpFechaDesmovilizacion.Text, frmTareo_Empleados.EMPRESA);
            if (dtResultado.Rows[0]["FLAG"].ToString() == "1")
            {
                MessageBox.Show("Empleado cambio de ubicación: DESMOVILIZADO DE OBRA TEMPORAL");
                flg = 1;
            }
            if (dtResultado.Rows[0]["FLAG"].ToString() == "0")
            {

                MessageBox.Show("No se puede cambiar de ubicación debido a que su ultima ubicación es : " + (dtResultado.Rows[0]["NOM_SUCURSAL"].ToString()));
                flg = 0;
                

            }

            return flg;
            
        }

        private void dtpFechaDesmovilizacion_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
