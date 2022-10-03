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
    public partial class frmMovilizarEmp : Form
    {
        public frmMovilizarEmp()
        {
            InitializeComponent();

            lblNombres.Text = frmDesmovilizarEmp.DNI + " - " + frmDesmovilizarEmp.NOMBRES;
            string dni;
            dni = frmDesmovilizarEmp.DNI;
            ListarEmpresa();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_GRABAR_EMP_HISTORICO_MOVI(frmDesmovilizarEmp.MES, frmDesmovilizarEmp.ANIO, cboUbicacion.SelectedValue.ToString() , frmDesmovilizarEmp.DNI, "31/01/9999", dtpFechaDesmovilizacion.Text, frmDesmovilizarEmp.EMPRESA);
            if (dtResultado.Rows.Count > 0)
            {
                if (cboUbicacion.SelectedValue.ToString().Equals(dtResultado.Rows[0]["cod_sucursal"].ToString()))
                {
                    MessageBox.Show("Se movilizo a  la ubicacion " + dtResultado.Rows[0]["nom_sucursal"].ToString());
                    //obj.SP_CORREO_MOVIMIENTO_UBICACION_PERSONAL(frmDesmovilizarEmp.NOMBRES, cboUbicacion.Text.ToString());
                }
                else { MessageBox.Show("No se puede movilizar debido a que se encuentra en la ubicacion " + dtResultado.Rows[0]["nom_sucursal"].ToString()); }


            }
            this.Close();
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
