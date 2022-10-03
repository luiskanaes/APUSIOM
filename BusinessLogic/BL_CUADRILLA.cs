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
    public class BL_CUADRILLA
    {
        public DataTable uspSEL_TAREO_FECHA(string IDE_EMPRESA, string CCENTRO, string FECHA_TAREO)
        {
            return new DA_CUADRILLA().uspSEL_TAREO_FECHA(IDE_EMPRESA, CCENTRO, FECHA_TAREO);
        }

        public DataTable SP_LISTAR_CUADRILLA_OBRERO(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            try
            {
                return new DA_CUADRILLA().SP_LISTAR_CUADRILLA_OBRERO(IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_CUADRILLA_X_FECHA(string IDE_CECOS, int IDE_EMPRESA, string CAPATAZ , string FECHA, string IDE_ING ,string DIA_NOMBRE)
        {
            try
            {
                return new DA_CUADRILLA().SP_OBTENER_CUADRILLA_X_FECHA(IDE_CECOS, IDE_EMPRESA, CAPATAZ, FECHA, IDE_ING, DIA_NOMBRE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable USP_CONSULTAR_CUADRILLA_X_FECHA(string IDE_CECOS  , string CAPATAZ, string FECHA, string IDE_ING, string DIA_NOMBRE)
        {
            try
            {
                return new DA_CUADRILLA().USP_CONSULTAR_CUADRILLA_X_FECHA(IDE_CECOS, CAPATAZ, FECHA, IDE_ING, DIA_NOMBRE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_OBTENER_CUADRILLA_X_FECHA_WS(string IDE_CECOS, int IDE_EMPRESA,string IDE_INGCAMPO, string CAPATAZ, string FECHA, int verTotal)
        {
            try
            {
                return new DA_CUADRILLA().SP_OBTENER_CUADRILLA_X_FECHA_WS(IDE_CECOS, IDE_EMPRESA, IDE_INGCAMPO, CAPATAZ, FECHA, verTotal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_OBTENER_CUADRILLA_X_FECHA_directo(string IDE_CECOS, int IDE_EMPRESA, string IDE_INGCAMPO, string CAPATAZ, string FECHA,string DIA, int verTotal)
        {
            try
            {
                return new DA_CUADRILLA().SP_OBTENER_CUADRILLA_X_FECHA_directo(IDE_CECOS, IDE_EMPRESA, IDE_INGCAMPO, CAPATAZ, FECHA, DIA,verTotal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_PERSONAL_TAREADO_ID_WS(string IDE_CECOS, string FECHA, string IDE_PERSONAL)
        {
            try
            {
                return new DA_CUADRILLA().SP_OBTENER_PERSONAL_TAREADO_ID_WS(IDE_CECOS, FECHA, IDE_PERSONAL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable USP_OBTENER_PERSONAL_DNI_VARIOS(string IDE_CECOS, string IDE_PERSONAL)
        {
            try
            {
                return new DA_CUADRILLA().USP_OBTENER_PERSONAL_DNI_VARIOS(IDE_CECOS, IDE_PERSONAL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
