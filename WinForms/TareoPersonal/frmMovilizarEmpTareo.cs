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

namespace WinForms.TareoPersonal
{
    public partial class frmMovilizarEmpTareo : Form
    {
        public frmMovilizarEmpTareo()
        {
            InitializeComponent();

            lblNombres.Text = frmTareo_Empleados.DNI + " - " + frmTareo_Empleados.NOMBRES;
            string dni;
            dni = frmTareo_Empleados.DNI;
            ListarEmpresa();
        
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();

            if (verificarUltimaUbicacion() == 1) {
                dtResultado = obj.SP_GRABAR_EMP_HISTORICO_MOVI(frmTareo_Empleados.MES, frmTareo_Empleados.ANIO, cboUbicacion.SelectedValue.ToString(), frmTareo_Empleados.DNI, "31/01/9999", dtpFechaDesmovilizacion.Text, frmTareo_Empleados.EMPRESA);

                obj.SP_CORREO_MOVIMIENTO_UBICACION_PERSONAL(frmTareo_Empleados.NOMBRES, cboUbicacion.Text.ToString(),frmTareo_Empleados.DNI,frmTareo_Empleados.MES, frmTareo_Empleados.EMPRESA,frmTareo_Empleados.DES_UBI);
            }

            //if (dtResultado.Rows.Count > 0)
            //{
            //    MessageBox.Show("Empleado Movilizado a la ubicación: " + cboUbicacion.Text.ToString());
            //}
            //else {
            //    //MessageBox.Show("No se puede movilizar debido a que se encuentra en la ubicacion " );
            //}

            this.Close();
        }
        int   verificarUltimaUbicacion()
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            DataTable dtResultadoFechas = new DataTable();
            int flg = 0;
            //verificarUltimaUbicacion();

            dtResultadoFechas = obj.SP_VERIFICAR_RANGO_FECHAS(frmTareo_Empleados.MES, frmTareo_Empleados.ANIO, cboUbicacion.SelectedValue.ToString(), frmTareo_Empleados.DNI, "31/01/9999", dtpFechaDesmovilizacion.Text, frmTareo_Empleados.EMPRESA);

            if (DateTime.Parse(dtpFechaDesmovilizacion.Text.ToString()).Month.ToString() == (frmTareo_Empleados.MES))
            {


            }
            else
            {
                MessageBox.Show("Fecha no corresponde al mes de trabajo...");
                flg = 0;
                return flg;
            }

            if (dtResultadoFechas.Rows[0]["FLAG"].ToString() == "1")
            {
                MessageBox.Show("Rango de fechas invalido verificar...");
                flg = 0;
                return flg;
            }
            if (dtResultadoFechas.Rows[0]["FLAG"].ToString() == "0")
            {

            

            }


            dtResultado = obj.SP_VERIFICAR_ULT_DESMOVILIZACION(frmTareo_Empleados.MES, frmTareo_Empleados.ANIO, cboUbicacion.SelectedValue.ToString(), frmTareo_Empleados.DNI, "31/01/9999", dtpFechaDesmovilizacion.Text, frmTareo_Empleados.EMPRESA);
     

            if (dtResultado.Rows[0]["FLAG"].ToString() == "1")
            {
                MessageBox.Show("Empleado cambio de ubicación: " + (dtResultado.Rows[0]["NOM_SUCURSAL"].ToString()));
                flg = 1;
            }
            if (dtResultado.Rows[0]["FLAG"].ToString() == "0")
            {

                MessageBox.Show("No se puede cambiar de ubicación debido a que su ultima ubicación es : " + (dtResultado.Rows[0]["NOM_SUCURSAL"].ToString()));
                flg = 0;


            }

            return flg;
        }

        protected void ListarEmpresa()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarEmpresaPerfil_Tareo_Emp(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboEmpresa.ValueMember = "ID";
                cboEmpresa.DisplayMember = "DESCRIPCION";
                cboEmpresa.DataSource = dtResultado;
                // ListarCesos();
                cargaUbicaciones();
            }
        }
        private void cargaUbicaciones()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_UBICACIONES_TAREO_EMP(frmLogin.obj_user_E.IDE_USUARIO, cboEmpresa.SelectedValue.ToString());//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboUbicacion.ValueMember = "ID";
                cboUbicacion.DisplayMember = "DESCRIPCION";
                cboUbicacion.DataSource = dtResultado;

            }

        }
    }
}
