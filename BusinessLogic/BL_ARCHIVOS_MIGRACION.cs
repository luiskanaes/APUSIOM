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
    public class BL_ARCHIVOS_MIGRACION
    {
        public int Mant_Insert_File(BE_ARCHIVOS_MIGRACION oBE)
        {
            try
            {
                return new DA_ARCHIVOS_MIGRACION().Mant_Insert_File(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ARCHIVOS_MIGRACION_POR_OBRA_FECHA(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            try
            {
                return new DA_ARCHIVOS_MIGRACION().Get_ARCHIVOS_MIGRACION_POR_OBRA_FECHA(IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
