using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using BusinessEntity;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using DataAccess;
using Microsoft.Practices.EnterpriseLibrary.Logging;
namespace BusinessLogic
{
    public class BL_FUNCIONES
    {
        DataAccess.DA_FUNCIONES obj_modulo = new DataAccess.DA_FUNCIONES();

        public static void f_llenar_menu(System.Windows.Forms.MenuStrip mnu_principal, int pPerfil)
        {
            BusinessEntity.BE_TBPERFIL obj_user_E = new BE_TBPERFIL();
            obj_user_E.IdPerfil = pPerfil;

            DataTable dtDatos = SetModXUsuario(pPerfil);
            int count = Convert.ToInt32(dtDatos.Rows.Count);
            if (dtDatos != null) f_Menus(0, dtDatos.DefaultView, null, mnu_principal, count);

        }
        public static DataTable SetModXUsuario(int pPerfil)
        {
            return new DA_FUNCIONES().ListarMenu_DA(pPerfil);
        }
        public static void f_Menus(int icodpadre, DataView dvdatos, System.Windows.Forms.ToolStripMenuItem mnuMenuItem, System.Windows.Forms.MenuStrip mnu_principal, int count)
        {

            String sfiltro = "";
            if (icodpadre > 0) sfiltro = " = " + icodpadre.ToString();
            else sfiltro = " is null ";

            System.Windows.Forms.ToolStripMenuItem mnuchild = new System.Windows.Forms.ToolStripMenuItem();
            DataView dvsubmenu = new DataView(dvdatos.Table, "icodprogramapadre" + sfiltro, "Posicion", DataViewRowState.OriginalRows);


            for (int i = 0; i < dvsubmenu.Count; i++)
            {
                Boolean bencontro = false;
                if (Boolean.Parse(dvsubmenu[i]["Habilitado"].ToString())) bencontro = true;
                else
                {
                    bencontro = f_ExistePrograma(int.Parse(dvsubmenu[i]["IdOpcion"].ToString()), dvdatos, bencontro);
                }
                if (bencontro == true)
                {
                    mnuchild = new System.Windows.Forms.ToolStripMenuItem();
                    mnuchild.Name = dvsubmenu[i]["Url"].ToString();
                    mnuchild.Text = dvsubmenu[i]["NombreOpcion"].ToString();
                    mnuchild.Tag = dvsubmenu[i]["Url"].ToString();

                    ((System.Windows.Forms.ToolStripDropDownMenu)(mnuchild.DropDown)).ShowImageMargin = false;
                    ((System.Windows.Forms.ToolStripDropDownMenu)(mnuchild.DropDown)).ShowCheckMargin = true;

                    System.Windows.Forms.ToolStripItem oToolStripItem = (System.Windows.Forms.ToolStripItem)mnuchild;

                    if (icodpadre == 0)
                        mnu_principal.Items.Add(oToolStripItem);
                
                    else
                    {
                        mnuMenuItem.DropDownItems.Add(oToolStripItem);
                    }
                    f_Menus(int.Parse(dvsubmenu[i]["IdOpcion"].ToString()), dvdatos, mnuchild, null, count);

                }
            }

        }
        public static Boolean f_ExistePrograma(int icodpadre, DataView dvdatos, Boolean bencontro)
        {
            String sfiltro = "";
            if (icodpadre > 0) sfiltro = " = " + icodpadre.ToString();
            else sfiltro = " is null ";
            bencontro = false;
            DataView dv = new DataView(dvdatos.Table, "icodprogramapadre" + sfiltro, "Posicion", DataViewRowState.OriginalRows);
            for (int i = 0; i < dv.Count; i++)
            {
                if (Boolean.Parse(dv[i]["Habilitado"].ToString()))
                {
                    return true;
                }
                else { bencontro = f_ExistePrograma(int.Parse(dv[i]["IdOpcion"].ToString()), dvdatos, bencontro); }
                if (bencontro == true) return true;
            }
            return false;
        }
        public DataTable ListarPeriodoFecha(int tipo ,int anio ,int mes)
        {
            try
            {
                return new DA_FUNCIONES().Get_ListarPeriodoFecha(tipo,  anio,  mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarPeriodoFecha_bd(int tipo, string fecha)
        {
            try
            {
                return new DA_FUNCIONES().Get_ListarPeriodoFecha_bd(tipo, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarCesos(int IdEmpresa)
        {
            try
            {
                return new DA_FUNCIONES().Get_ListarCesos(IdEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_ActividadTarea(int tipo,string proyecto, string idactividad, string det_tarea, int empresa, int archivo)
        {
            try
            {
                return new DA_FUNCIONES().GetListar_ActividadTarea(tipo,  proyecto, idactividad,  det_tarea, empresa, archivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable USP_OBTENER_TODAS_TAREAS_PROYECTO(int tipo, string proyecto, string idactividad, string det_tarea, int empresa, int archivo)
        {
            try
            {
                return new DA_FUNCIONES().USP_OBTENER_TODAS_TAREAS_PROYECTO(tipo, proyecto, idactividad, det_tarea, empresa, archivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable ListarParametros(string tabla, string campo)
        {
            try
            {
                return new DA_FUNCIONES().Get_ListarParametros(tabla, campo );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BE_TBPARAMETROS> f_list_Parametros(BE_TBPARAMETROS obj)
        {
            return new DA_FUNCIONES().f_list_Parametros_D(obj);
        }
        public DataTable ListarBonificacion(string cc, int empresa)
        {
            try
            {
                return new DA_FUNCIONES().Get_ListarBonificacion(cc, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarHrasJorandas( string fecha,int empresa, string diaNombre, string centro)
        {
            try
            {
                return new DA_FUNCIONES().Get_ListarHrasJorandas(fecha, empresa, diaNombre,centro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarEmpresaPerfil(int perfil, string usuario)
        {
            try
            {
                return new DA_FUNCIONES().Get_ListarEmpresaPerfil(perfil, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarCesosPerfil(int perfil, string usuario ,int IdEmpresa)
        {
            try
            {
                return new DA_FUNCIONES().Get_ListarCesosPerfil(perfil, usuario, IdEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarEstadoDiario(string tabla, string campo, int empresa, string centro, string fecha, string diaNombre)
        {
            try
            {
                return new DA_FUNCIONES().ListarEstadoDiario(tabla, campo, empresa,  centro,  fecha, diaNombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BE_TBPARAMETROS> f_list_EstadoDiario(BE_TBPARAMETROS obj)
        {
            return new DA_FUNCIONES().f_list_EstadoDiario_D(obj);
        }
        public DataTable uspSEL_EMPRESA()
        {
            return new DA_FUNCIONES().uspSEL_EMPRESA();
        }
        public DataTable uspSEL_EMPRESA_ID(string IDE_FECHA)
        {
            return new DA_FUNCIONES().uspSEL_EMPRESA_ID(IDE_FECHA);
        }

        public DataTable ListarEmpresaPerfil_Tareo_Emp(int perfil, string usuario)
        {
            try
            {
                return new DA_FUNCIONES().ListarEmpresaPerfil_Tareo_Emp(perfil, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
   

}
