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
    public class BL_TAREO
    {
        public int Mant_Insert_Trabajos(BE_TAREO oBE)
        {
            try
            {
                return new DA_TAREO().Mant_Insert_Trabajos(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BE_TAREO> f_actividadesPersona_tareo(BE_TAREO obj)
        {
            return new DA_TAREO().f_actividadesPersona_tareo_D(obj);
        }
        public DataTable actividadesPersona_tareo(int IDE_EMPRESA, string CCENTRO, int TIPO, string FECHA, string DES_DNI, int IDE_TAREA)
        {
            try
            {
                return new DA_TAREO().Get_actividadesPersona_tareo_D(IDE_EMPRESA,  CCENTRO,  TIPO,  FECHA,  DES_DNI, IDE_TAREA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_TAREO_PERSONA_ID(int IDE_EMPRESA, string CCENTRO, int TIPO, string FECHA, string DES_DNI, int IDE_TAREA)
        {
            try
            {
                return new DA_TAREO().SP_OBTENER_TAREO_PERSONA_ID(IDE_EMPRESA, CCENTRO, TIPO, FECHA, DES_DNI, IDE_TAREA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable AsistenciaPersonal_tareo(int IDE_EMPRESA, string CCENTRO, string FECHA, string DES_DNI)
        {
            try
            {
                return new DA_TAREO().Get_AsistenciaPersonal_tareo(IDE_EMPRESA, CCENTRO, FECHA, DES_DNI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable EliminarTareo_Personal(int IDE_EMPRESA, string CCENTRO, string FECHA, string DES_DNI)
        {
            try
            {
                return new DA_TAREO().Get_EliminarTareo_Personal(IDE_EMPRESA, CCENTRO, FECHA, DES_DNI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_ELIMINAR_TAREO_PERSONA(int IDE_EMPRESA, string CCENTRO, string FECHA, string DES_DNI,string CAPATAZ)
        {
            try
            {
                return new DA_TAREO().SP_ELIMINAR_TAREO_PERSONA(IDE_EMPRESA, CCENTRO, FECHA, DES_DNI, CAPATAZ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarTareo_fecha(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().Get_ListarTareo_fecha(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////////migracion WCF
        public DataTable WCF_ASIGNACION_TAREO(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().Get_WCF_ASIGNACION_TAREO(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_CuadroAcumulado(int IDE_EMPRESA, string CCENTRO, string FECHA, string CAPATAZ)
        {
            try
            {
                return new DA_TAREO().Get_Listar_CuadroAcumulado(IDE_EMPRESA, CCENTRO, FECHA, CAPATAZ );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarPersonal_SinTareo(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().ListarPersonal_SinTareo(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 Insertar_ASISTENCIA(BE_ASISTENCIA_PERSONAL obj)
        {

            try
            {
                return new DA_TAREO().INS_ASISTENCIA_PERSONAL(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Tareo_fecha(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().Get_Tareo_fecha(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable UpdateMigracion(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().UpdateMigracion(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ExcesoHrs_Personal(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().Get_ExcesoHrs_Personal(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Indicadores_Tareo(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().Get_Indicadores_Tareo(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable REPORTE_CONTROL_AVANCES(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().REPORTE_CONTROL_AVANCES(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LISTA_ESTRUCTURAS_POR_TIPO( string CCENTRO, int tipo)
        {
            try
            {
                return new DA_TAREO().LISTA_ESTRUCTURAS_POR_TIPO(CCENTRO, tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspSEL_M_TAREA_ESTRUCTURA_POR_TAREA(int IDE_TAREA, string CCENTRO, string ID_FRENTE, string DET_TAREA)
        {
            try
            {
                return new DA_TAREO().uspSEL_M_TAREA_ESTRUCTURA_POR_TAREA(IDE_TAREA, CCENTRO,  ID_FRENTE, DET_TAREA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable InsertarKardex(int ID_ESTRUCTURA, string DESCRIPCION, int ENTRADA, int SALIDA, string CENTRO, string USUARIO, string FECHA_TAREO, int IDE_TAREO)
        {
            try
            {
                return new DA_TAREO().InsertarKardex(ID_ESTRUCTURA, DESCRIPCION, ENTRADA, SALIDA, CENTRO, USUARIO, FECHA_TAREO, IDE_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mant_Insert_Estructura(BE_M_ESTRUCTURA_INSUMO oBE)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().Mant_Insert_Estructura(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mant_Insert_Estructura_ING(BE_M_ESTRUCTURA_INSUMO oBE)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().Mant_Insert_Estructura_ING(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LISTA_ESTRUCTURAS_CONSUMO(string CCENTRO, int ESTRUCTURA,string FECHA, int IDE_TAREA,string DSC_AREA)
        {
            try
            {
                return new DA_TAREO().LISTA_ESTRUCTURAS_CONSUMO(CCENTRO,  ESTRUCTURA,  FECHA,  IDE_TAREA, DSC_AREA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LISTA_ESTRUCTURAS_CONSUMO_ING(string CCENTRO, int ESTRUCTURA, string FECHA, string IDE_TAREA, string DSC_AREA, string IDE_INGENIERO)
        {
            try
            {
                return new DA_TAREO().LISTA_ESTRUCTURAS_CONSUMO_ING(CCENTRO, ESTRUCTURA, FECHA, IDE_TAREA, DSC_AREA, IDE_INGENIERO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspINSERT_TAREO_DIA(string FECHA, string CCENTRO)
        {
            try
            {
                return new DA_TAREO().uspINSERT_TAREO_DIA(FECHA,CCENTRO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_INSTAR_GESTOR_TAREO_DETALLE(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().SP_INSTAR_GESTOR_TAREO_DETALLE(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_INSTAR_GESTOR_TAREO(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().SP_INSTAR_GESTOR_TAREO(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GENERAR_TAREO_NO_LABORABLE(int IDE_EMPRESA, string CCENTRO, string FECHA, string USER, string DIA)
        {
            try
            {
                return new DA_TAREO().SP_GENERAR_TAREO_NO_LABORABLE(IDE_EMPRESA, CCENTRO, FECHA, USER, DIA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CORREO_CIERRE_TAREO_DIA(string CCENTRO, string FECHA, string user)
        {
            try
            {
                return new DA_TAREO().SP_CORREO_CIERRE_TAREO_DIA(CCENTRO, FECHA, user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspWCF_SELECT_PERIODO(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().uspWCF_SELECT_PERIODO(IDE_EMPRESA,CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspWCF_SELECT_PERIODO_SKEX(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().uspWCF_SELECT_PERIODO_SKEX(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspUPD_TAREO_LIMPIAR_MIGRACION( string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().uspUPD_TAREO_LIMPIAR_MIGRACION( CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspWCF_TAREO_LIMPIAR_MIGRACION_GESTOR(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().uspWCF_TAREO_LIMPIAR_MIGRACION_GESTOR(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GENERAR_TAREO_FERIADO(int IDE_EMPRESA, string CCENTRO, string FECHA, string USER, string DIA)
        {
            try
            {
                return new DA_TAREO().SP_GENERAR_TAREO_FERIADO(IDE_EMPRESA, CCENTRO, FECHA, USER, DIA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_INSTAR_GESTOR_TAREO_DETALLE_DOMINICAL(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().SP_INSTAR_GESTOR_TAREO_DETALLE_DOMINICAL(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CARGA_ULTIMA_CUADRILLA( string CCENTRO, string FECHA, string IDE_CAPATAZ, string ING_INGENIERO, int TIPO, string FECHA_ATERIOR)
        {
            try
            {
                return new DA_TAREO().SP_CARGA_ULTIMA_CUADRILLA( CCENTRO, FECHA, IDE_CAPATAZ, ING_INGENIERO, TIPO , FECHA_ATERIOR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_ELIMINAR_TAREO_CUADRILLA_VARIOS(int IDE_EMPRESA, string CCENTRO, string FECHA, string DES_DNI, string CAPATAZ, string ING_CAMPO)
        {
            try
            {
                return new DA_TAREO().SP_ELIMINAR_TAREO_CUADRILLA_VARIOS(IDE_EMPRESA, CCENTRO, FECHA, DES_DNI, CAPATAZ, ING_CAMPO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspDEL_TAREO_PERSONA_ID(int IDE_TRABAJO)
        {
            try
            {
                return new DA_TAREO().uspDEL_TAREO_PERSONA_ID(IDE_TRABAJO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GENERAR_TAREO_CONSOLIDADO( string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().SP_GENERAR_TAREO_CONSOLIDADO( CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GENERAR_TAREO_CONSOLIDADO_DETALLE(string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_TAREO().SP_GENERAR_TAREO_CONSOLIDADO_DETALLE(CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
