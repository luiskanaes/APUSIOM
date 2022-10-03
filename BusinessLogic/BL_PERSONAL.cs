using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using DataAccess;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using UserCode;
using System.Web;
namespace BusinessLogic
{
    public  class BL_PERSONAL
    {
        public DataTable Listar_disponibilidadPersonal(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_disponibilidadPersonal(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_PersonalCC(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_PersonalCC(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspSEL_PERSONAL_EMPRESA_CC_TIPO(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().uspSEL_PERSONAL_EMPRESA_CC_TIPO(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_Personal_Estados(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_Personal_Estados(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_PersonalGrupo(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_PersonalGrupo(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable AsignarPersonal(string centro,int idPersona, int empresa, int estado, string capataz, string ingeniero, string fecha)
        {
            try
            {
                return new DA_PERSONAL().Get_AsignarPersonal(centro, idPersona, empresa, estado, capataz,ingeniero,fecha );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable AsignarPersonal_dni(string centro, string  idPersona, int empresa, int estado, string capataz, string ingeniero, string fecha)
        {
            try
            {
                return new DA_PERSONAL().Get_AsignarPersonal_DNI(centro, idPersona, empresa, estado, capataz, ingeniero, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mant_Insert_Trabajadores_WCF(BE_PERSONAL oBE)
        {
            try
            {
                return new DA_PERSONAL().Mant_Insert_Trabajadores_WCF(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mant_Insert_Trabajadores_WCF_DNI(BE_PERSONAL oBE)
        {
            try
            {
                return new DA_PERSONAL().Mant_Insert_Trabajadores_WCF_DNI(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable UpdateCategoria(int idPersona, int categoria, string centro)
        {
            try
            {
                return new DA_PERSONAL().UpdateCategoria( idPersona, categoria, centro );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspREVISAR_EQUIPO_TRABAJO(int idPersona, int categoria, string centro)
        {
            try
            {
                return new DA_PERSONAL().uspREVISAR_EQUIPO_TRABAJO(idPersona, categoria, centro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspRITERAR_EQUIPO_TRABAJO(int idPersona, int categoria, string centro,string fecha)
        {
            try
            {
                return new DA_PERSONAL().uspRITERAR_EQUIPO_TRABAJO(idPersona, categoria, centro, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_Personal_x_Categoria(string Centro, int empresa, string grupo)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_Personal_x_Categoria(Centro, empresa, grupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable AsignarResponsable(string idPersona, string ingeniero, int tipo, int empresa, string centro)
        {
            try
            {
                return new DA_PERSONAL().AsignarResponsable(idPersona, ingeniero, tipo, empresa , centro );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Update_EstadoPersonal( int empresa, string centro,string TipoPersona)
        {
            try
            {
                return new DA_PERSONAL().Update_EstadoPersonal( empresa, centro, TipoPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable UpdateEstadoPersonal(string centro, int idPersona, int empresa, int estado, string fecha)
        {
            try
            {
                return new DA_PERSONAL().Get_UpdateEstadoPersonal(centro, idPersona, empresa, estado, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_PERSONAL(string Centro)
        {
            try
            {
                return new DA_PERSONAL().SP_OBTENER_PERSONAL(Centro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspUPD_PERSONAL_CATEGORIA_CAMBIO(int idPersona,int idPersonaNuevo, int categoria, string centro, string fecha, int idObrero, string fecha_nueva)
        {
            try
            {
                return new DA_PERSONAL().uspUPD_PERSONAL_CATEGORIA_CAMBIO(idPersona, idPersonaNuevo,categoria, centro, fecha, idObrero, fecha_nueva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_OBTENER_PERSONAL_ASIGNADO(string CENTRO_COSTO, string IDE_CAPATAZ, string FECHA, string IDE_INGCAMPO, string IDE_CATEGORIA)
        {
            try
            {
                return new DA_PERSONAL().SP_OBTENER_PERSONAL_ASIGNADO(CENTRO_COSTO, IDE_CAPATAZ, FECHA, IDE_INGCAMPO, IDE_CATEGORIA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_OBTENER_EQUIPO_TRABAJO(string P_PROYECTO, string  FLG_ESTADO, string IDE_PERSONAL, int TIPO)
        {
            try
            {
                return new DA_PERSONAL().SP_OBTENER_EQUIPO_TRABAJO(P_PROYECTO, FLG_ESTADO,  IDE_PERSONAL, TIPO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable uspINS_EQUIPO_TRABAJO(int IDE_EQUIPO ,string  CCENTRO,string  IDE_INGCAMPO ,string  IDE_CAPATAZ , int FLG_ESTADO , string FECHA_INICIO, string FECHA_FIN)
        {
            try
            {
                return new DA_PERSONAL().uspINS_EQUIPO_TRABAJO(IDE_EQUIPO, CCENTRO, IDE_INGCAMPO, IDE_CAPATAZ, FLG_ESTADO, FECHA_INICIO, FECHA_FIN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspDELETE_EQUIPO_TRABAJO(string CENTRO_COSTO, string IDE_CAPATAZ, string FECHA, string IDE_INGCAMPO)
        {
            try
            {
                return new DA_PERSONAL().uspDELETE_EQUIPO_TRABAJO(CENTRO_COSTO, IDE_CAPATAZ, FECHA, IDE_INGCAMPO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int uspWCF_INS_PERSONAL_EMPLEADO(BE_PERSONAL oBE)
        {
            try
            {
                return new DA_PERSONAL().uspWCF_INS_PERSONAL_EMPLEADO(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Get_PersonalGestorDNI(Int32 IDE_EMPRESA, string CENTRO_COSTO, string DNI)
        {
            DA_PERSONAL  objData = new DA_PERSONAL();
            return objData.Get_ListarPersonalGestorDNI(IDE_EMPRESA, CENTRO_COSTO, DNI);
        }
        public DataTable Get_PersonalGestorDNI_SKEX(Int32 IDE_EMPRESA, string CENTRO_COSTO, string DNI)
        {
            DA_PERSONAL objData = new DA_PERSONAL();
            return objData.Get_ListarPersonalGestorDNI_SKEX(IDE_EMPRESA, CENTRO_COSTO, DNI);
        }
        public DataTable Get_PersonalGestor(Int32 IDE_EMPRESA, string CENTRO_COSTO, string TIPO_PERSONA)
        {
            DA_PERSONAL objData = new DA_PERSONAL();
            return objData.Get_ListarPersonalGestor(IDE_EMPRESA, CENTRO_COSTO, TIPO_PERSONA);
        }

        public DataTable SP_OBTENER_PERSONAL_x_DNI(string IDE_EMPRESA, string P_PROYECTO, string DNI)
        {
            try
            {
                return new DA_PERSONAL().SP_OBTENER_PERSONAL_x_DNI(IDE_EMPRESA,P_PROYECTO, DNI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspASIGNAR_NUEVO_RESPONSABLE(int idPersona, int idPersonaNuevo, string centro, string fecha, string fecha_nueva)
        {
            try
            {
                return new DA_PERSONAL().uspASIGNAR_NUEVO_RESPONSABLE(idPersona, idPersonaNuevo, centro, fecha, fecha_nueva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable USP_PERSONAL_FOTOCHECK(string CCENTRO, string TIPO_TRABAJADOR, string FLG_FOTOCHECK)
        {
            return new DA_PERSONAL().USP_PERSONAL_FOTOCHECK(CCENTRO, TIPO_TRABAJADOR, FLG_FOTOCHECK);
        }

        public DataTable USP_ACTUALIZAR_FOTOS(string IDE_PERSONAL, string FOTO_RUTA, string FOTO, string FOTOCHECK)
        {
            return new DA_PERSONAL().USP_ACTUALIZAR_FOTOS(IDE_PERSONAL, FOTO_RUTA, FOTO, FOTOCHECK);
        }
        public DataTable USP_PERSONAL_FOTOCHECK_ID(string IDE_PERSONAL)
        {
            return new DA_PERSONAL().USP_PERSONAL_FOTOCHECK_ID(IDE_PERSONAL);
        }

    }
}
