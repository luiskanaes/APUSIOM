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
    public class BL_TAREO_SEMANAL
    {

        public DataTable SP_CONSULTAR_VERSION(string IDE_EMPRESA, string IDE_CECOS, string Anio, string Mes)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_CONSULTAR_VERSION(IDE_EMPRESA, IDE_CECOS, Anio,Mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_VERSION_ANIO(string IDE_EMPRESA, string IDE_CECOS, string Anio, string Mes, string COD_TIPO_PLANILLA)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_CONSULTAR_VERSION_ANIO(IDE_EMPRESA, IDE_CECOS, Anio, Mes, COD_TIPO_PLANILLA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataTable SP_VALIDAR_ELIMINAR_MIGRACION(string IDE_EMPRESA, string IDE_CECOS, string Anio)
        //{
        //    try
        //    {
        //        return new DA_TAREO_SEMANAL().SP_VALIDAR_ELIMINAR_MIGRACION(IDE_EMPRESA, IDE_CECOS, Anio);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public DataTable SP_VALIDAR_ELIMINAR_MIGRACION(string IDE_EMPRESA, string IDE_CECOS, string Version, string Anio, string Mes)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_VALIDAR_ELIMINAR_MIGRACION(IDE_EMPRESA, IDE_CECOS, Version, Anio, Mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_VALIDAR_ELIMINAR_MIGRACION_REINTEGRO(string IDE_EMPRESA, string IDE_CECOS, string Anio )
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_VALIDAR_ELIMINAR_MIGRACION_REINTEGRO(IDE_EMPRESA, IDE_CECOS, Anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_ELIMINAR_MIGRACION(string IDE_EMPRESA, string IDE_CECOS, string Version, string Anio, string Mes)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_ELIMINAR_MIGRACION(IDE_EMPRESA, IDE_CECOS, Version, Anio, Mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SP_ELIMINAR_MIGRACION_REINTEGRO(string IDE_EMPRESA, string IDE_CECOS, string Anio )
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_ELIMINAR_MIGRACION_REINTEGRO(IDE_EMPRESA, IDE_CECOS, Anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_TAREO_SEMANAL(string IDE_EMPRESA, string IDE_CECOS, string Version, string Anio, string Mes)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_CONSULTAR_TAREO_SEMANAL(IDE_EMPRESA, IDE_CECOS, Version, Anio, Mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_ESTADO_MIGRACION(string IDE_EMPRESA, string IDE_CECOS, string VERSION)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_CONSULTAR_ESTADO_MIGRACION(IDE_EMPRESA, IDE_CECOS, VERSION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
 public DataTable SP_CONSULTAR_ESTADO_MIGRACION_REINTEGRO(string IDE_EMPRESA, string IDE_CECOS, string ANIO)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_CONSULTAR_ESTADO_MIGRACION_REINTEGRO(IDE_EMPRESA, IDE_CECOS, ANIO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GENERAR_TAREO_SEMANAL(string IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, string Anio, string Mes)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_GENERAR_TAREO_SEMANAL(IDE_EMPRESA, FEC_TAREO, IDE_CECOS,Anio,Mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_MIGRAR_REINTEGRO_MOD(string IDE_EMPRESA, string IDE_CECOS, string anio, string fec_ini, string feC_fin)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_MIGRAR_REINTEGRO_MOD(IDE_EMPRESA,IDE_CECOS, anio, fec_ini, feC_fin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
        public DataTable SP_VALIDAR_CIERRE_TAREO(string IDE_EMPRESA, string IDE_CECOS, string NUM_VERSION, string Anio, string Mes)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_VALIDAR_CIERRE_TAREO(IDE_EMPRESA, IDE_CECOS, NUM_VERSION, Anio, Mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_VALIDAR_CIERRE_REINTEGRO_MOD(string IDE_EMPRESA, string IDE_CECOS, string Anio)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_VALIDAR_CIERRE_REINTEGRO_MOD(IDE_EMPRESA, IDE_CECOS, Anio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public DataTable SP_MIGRAR_TAREO_SEMANAL(string IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, string Anio, string Mes)
        {
            try
            {
                return new DA_TAREO_SEMANAL().SP_MIGRAR_TAREO_SEMANAL(IDE_EMPRESA, FEC_TAREO, IDE_CECOS, Anio, Mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
