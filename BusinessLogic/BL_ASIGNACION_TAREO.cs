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
    public  class BL_ASIGNACION_TAREO
    {
        public int Mant_Insert_Tareo(BE_ASIGNACION_TAREO oBE)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().Mant_Insert_Tareo(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mant_Insert_TareasActividades(BE_ASIGNACION_TAREAS oBE)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().Mant_Insert_TareasActividades(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_TareoFecha(int IDE_EMPRESA , string IDE_CECOS , string FEC_TAREO)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().Get_Listar_TareoFecha(IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CerrarTareo_fecha(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, int ESTADO)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().CerrarTareo_fecha(IDE_EMPRESA, IDE_CECOS, FEC_TAREO, ESTADO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC(string IDE_CECOS, string FEC_TAREO)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC( IDE_CECOS, FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspINS_ASIGNACION_TAREAS_WS(string IDE_CECOS, string FEC_TAREO, string IDE_INGCAMPO, string IDE_CAPATAZ, string IDE_ACTIVIDAD, string USUARIO_REGISTRO)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().uspINS_ASIGNACION_TAREAS_WS(IDE_CECOS,  FEC_TAREO,  IDE_INGCAMPO,  IDE_CAPATAZ,  IDE_ACTIVIDAD,  USUARIO_REGISTRO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable uspINS_ASIGNACION_TAREAS_DIRECTO(string IDE_CECOS, string FEC_TAREO, string IDE_INGCAMPO, string IDE_CAPATAZ, string IDE_ACTIVIDAD, string USUARIO_REGISTRO,string TIPO_ARCHIVO,string IDE_TAREO_ASIGNACION)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().uspINS_ASIGNACION_TAREAS_DIRECTO(IDE_CECOS, FEC_TAREO, IDE_INGCAMPO, IDE_CAPATAZ, IDE_ACTIVIDAD, USUARIO_REGISTRO, TIPO_ARCHIVO, IDE_TAREO_ASIGNACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_INSERT_ASIGNACION_TAREO(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, string USUARIO, string DIA_NOMBRE)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().SP_INSERT_ASIGNACION_TAREO(IDE_EMPRESA, IDE_CECOS, FEC_TAREO,  USUARIO,  DIA_NOMBRE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_FLG_100( string IDE_CECOS, string DIA)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().SP_CONSULTAR_FLG_100( IDE_CECOS, DIA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CERRAR_DIA_TRABAJO(string IDE_CECOS, string FECHA)
        {
            try
            {
                return new DA_ASIGNACION_TAREO().SP_CERRAR_DIA_TRABAJO(IDE_CECOS, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
