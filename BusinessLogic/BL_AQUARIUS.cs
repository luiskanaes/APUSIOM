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
   public  class BL_AQUARIUS
    {

        public DataTable SP_PLA_RPT_CMO_DETALLE_VARIOS_DETALLE_V3(string V_COD_EMPRESA,
                        string V_ANO_PROCESO,
                        string V_NUM_VERSION,
                        string V_COD_TIPO_PLANILLA)
        {
            try
            {
                return new DA_AQUARIUS().SP_PLA_RPT_CMO_DETALLE_VARIOS_DETALLE_V3(V_COD_EMPRESA,
                         V_ANO_PROCESO,
                         V_NUM_VERSION,
                         V_COD_TIPO_PLANILLA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
