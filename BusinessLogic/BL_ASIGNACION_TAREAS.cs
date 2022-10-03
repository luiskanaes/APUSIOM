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
   public  class BL_ASIGNACION_TAREAS

    {
        public DataTable Listar_ActividadAsignadas(string IDE_EMPRESA, string IDE_CECOS, string COD_PROYECTO, string FEC_TAREO, string IDE_CAPATAZ, string IDE_INGCAMPO)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_Listar_ActividadAsignadas(IDE_EMPRESA, IDE_CECOS, COD_PROYECTO, FEC_TAREO, IDE_CAPATAZ, IDE_INGCAMPO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(string IDE_EMPRESA, string IDE_CECOS, string COD_PROYECTO, string FEC_TAREO, string IDE_CAPATAZ, string IDE_INGCAMPO, int disciplina)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(IDE_EMPRESA, IDE_CECOS, COD_PROYECTO, FEC_TAREO, IDE_CAPATAZ, IDE_INGCAMPO, disciplina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_PersonalCategoria(string P_PROYECTO, int IDE_EMPRESA, string ID_CATEGORIA, string IDE_CAPATAZ)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_Listar_PersonalCategoria(P_PROYECTO, IDE_EMPRESA, ID_CATEGORIA, IDE_CAPATAZ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable EliminarTareas(int id)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_EliminarTareas(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ConsultarTareasRealizadas(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_ConsultarTareasRealizadas(IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable obtener_PersonalCategoria(string P_PROYECTO, int IDE_EMPRESA, string ID_CATEGORIA, string IDE_CAPATAZ, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_obtener_PersonalCategoria(P_PROYECTO, IDE_EMPRESA, ID_CATEGORIA, IDE_CAPATAZ, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_EQUIPO_TRABAJO_TAREO(string P_PROYECTO, string  FLG_ESTADO, string TIPO, string IDE_PERSONAL, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_OBTENER_EQUIPO_TRABAJO_TAREO(P_PROYECTO, FLG_ESTADO, TIPO, IDE_PERSONAL, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable uspASIGNAR_CAMBIO_CUADRILLA(string IDE_CAPATAZ,
        string IDE_ING_NUEVO,
        string IDE_ING_ANTIGUO,
        string CENTRO,
        string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().uspASIGNAR_CAMBIO_CUADRILLA(IDE_CAPATAZ,
            IDE_ING_NUEVO,
            IDE_ING_ANTIGUO,
            CENTRO,
            FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_OBTENER_PERSONAL_TODO_X_FECHA(string P_PROYECTO, int IDE_EMPRESA, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_OBTENER_PERSONAL_TODO_X_FECHA(P_PROYECTO, IDE_EMPRESA, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable USP_OBTENER_EQUIPO_TRABAJO_CAPATAZ(string P_PROYECTO, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().USP_OBTENER_EQUIPO_TRABAJO_CAPATAZ(P_PROYECTO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_PLANILLA_PERSONAL_OBRERO(string P_PROYECTO, int IDE_EMPRESA, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_OBTENER_PLANILLA_PERSONAL_OBRERO(P_PROYECTO, IDE_EMPRESA, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Tareo_x_persona(string centro, int empresa, string fecha, string personal, string capataz, string ing)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_Tareo_x_persona(centro, empresa, fecha, personal, capataz, ing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable USP_ACTUALIZAR_RESPONSABLES(string centro, string fecha, string personal, string capataz, string ing)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().USP_ACTUALIZAR_RESPONSABLES(centro, fecha, personal, capataz, ing);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Lista_Personal_tareas_x_fecha(string P_PROYECTO, int IDE_EMPRESA, string IDE_CAPATAZ, string FECHA, string dateString, string ingeniero)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().Get_Lista_Personal_tareas_x_fecha(P_PROYECTO, IDE_EMPRESA, IDE_CAPATAZ, FECHA, dateString, ingeniero);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public DataTable SP_OBTENER_PERSONAL_TAREADO_FECHA_WS(string P_PROYECTO, int IDE_EMPRESA,string IDE_INGCAMPO, string IDE_CAPATAZ, string FECHA, string dateString, int verTotal)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_OBTENER_PERSONAL_TAREADO_FECHA_WS(P_PROYECTO, IDE_EMPRESA, IDE_INGCAMPO, IDE_CAPATAZ, FECHA, dateString, verTotal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_OBTENER_CUADRILLA_X_FECHA_directo(string P_PROYECTO, int IDE_EMPRESA, string IDE_INGCAMPO, string IDE_CAPATAZ, string FECHA, string dateString, int verTotal)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_OBTENER_CUADRILLA_X_FECHA_directo(P_PROYECTO, IDE_EMPRESA, IDE_INGCAMPO, IDE_CAPATAZ, FECHA, dateString, verTotal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable OBTENER_PERSONAL_RESPONSABLES_TAREO(string P_PROYECTO, int IDE_EMPRESA, string FECHA, int Tipo, string Ide_personal)
                {
            try
            {
                return new DA_ASIGNACION_TAREAS().OBTENER_PERSONAL_RESPONSABLES_TAREO(P_PROYECTO, IDE_EMPRESA, FECHA, Tipo, Ide_personal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_M_ESTRUCTURA_INSUMO_POR_FECHA(string P_PROYECTO, string FECHA, string CAPATAZ)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SEL_M_ESTRUCTURA_INSUMO_POR_FECHA(P_PROYECTO, FECHA, CAPATAZ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_M_ESTRUCTURA_INSUMO_POR_FECHA_CABECERA(string P_PROYECTO, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SEL_M_ESTRUCTURA_INSUMO_POR_FECHA_CABECERA(P_PROYECTO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_ASIGNACION_TAREAS_FECHA_ING(string IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, string IDE_INGCAMPO)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SEL_ASIGNACION_TAREAS_FECHA_ING(IDE_EMPRESA, IDE_CECOS, FEC_TAREO, IDE_INGCAMPO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BE_ASIGNACION_TAREAS> f_list_SEL_ASIGNACION_TAREAS_FECHA_ING(BE_ASIGNACION_TAREAS obj)
        {
            return new DA_ASIGNACION_TAREAS().f_list_SEL_ASIGNACION_TAREAS_FECHA_ING(obj);
        }
        public DataTable LISTAR_M_PARTIDA_CONTROL_MARCA_CENTRO(string IDE_CECOS, string CODIGO_AREA, int IDE_DISCIPLINA, string DET_TAREA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().LISTAR_M_PARTIDA_CONTROL_MARCA_CENTRO(IDE_CECOS, CODIGO_AREA, IDE_DISCIPLINA, DET_TAREA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_RPT_LISTAR_CUADRILLA_TAREO_PERSONAL(string IDE_CECOS, string IDE_PADRE, string FECHA, int NUEVO, string IDE_INGCAMPO)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_RPT_LISTAR_CUADRILLA_TAREO_PERSONAL(IDE_CECOS, IDE_PADRE, FECHA, NUEVO, IDE_INGCAMPO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_PERSONAL_TAREO(string IDE_CECOS, int PERSONAL, string IDE_INGCAMPO, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREAS().SP_OBTENER_PERSONAL_TAREO(IDE_CECOS, PERSONAL, IDE_INGCAMPO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
