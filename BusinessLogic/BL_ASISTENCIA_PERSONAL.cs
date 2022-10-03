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
    public class BL_ASISTENCIA_PERSONAL
    {
        public int Mant_Insert_Asistencias(BE_ASISTENCIA_PERSONAL oBE)
        {
            try
            {
                return new DA_ASISTENCIA_PERSONAL().Mant_Insert_Asistencia(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BE_ASISTENCIA_PERSONAL> f_list_Asistencia(BE_ASISTENCIA_PERSONAL obj)
        {
            return new DA_ASISTENCIA_PERSONAL().f_list_Asistencia_D(obj);
        }
        public DataTable ListarAsistencia_fecha(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            try
            {
                return new DA_ASISTENCIA_PERSONAL().Get_ListarAsistencia_fecha(IDE_EMPRESA, CCENTRO, FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
