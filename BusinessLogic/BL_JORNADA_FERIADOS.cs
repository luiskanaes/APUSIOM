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
    public class BL_JORNADA_FERIADOS
    {
        public int Mant_Insert_diasFeriados(BE_JORNADA_FERIADOS oBE)
        {
            try
            {
                return new DA_JORNADA_FERIADOS().Mant_Insert_diasFeriados(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspSEL_JORNADA_FERIADOS_CENTRO( int ANIO, int MES, string CENTRO_COSTO)
        {
            try
            {
                return new DA_JORNADA_FERIADOS().uspSEL_JORNADA_FERIADOS_CENTRO(ANIO, MES, CENTRO_COSTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspDEL_DIA_FERIADOS_CENTRO(string fecha, string CENTRO_COSTO)
        {
            try
            {
                return new DA_JORNADA_FERIADOS().uspDEL_DIA_FERIADOS_CENTRO(fecha, CENTRO_COSTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CALENDARIO_TAREO(int ANIO, int MES, string CENTRO_COSTO)
        {
            try
            {
                return new DA_JORNADA_FERIADOS().SP_CALENDARIO_TAREO(ANIO, MES, CENTRO_COSTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
