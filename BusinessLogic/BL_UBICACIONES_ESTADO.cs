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
    public class BL_UBICACIONES_ESTADO
    {
        public int uspINS_UBICACIONES_ESTADO(BE_UBICACIONES_ESTADO oBE)
        {
            try
            {
                return new DA_UBICACIONES_ESTADO().uspINS_UBICACIONES_ESTADO(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspSEL_UBICACIONES_ESTADO_POR_UBICACION(string IDE_UBICACION, string ESTADO)
        {
            return new DA_UBICACIONES_ESTADO().uspSEL_UBICACIONES_ESTADO_POR_UBICACION(IDE_UBICACION, ESTADO);
        }
        public DataTable uspSEL_UBICACIONES_ESTADO_POR_ID(string IDE_ESTADO)
        {
            return new DA_UBICACIONES_ESTADO().uspSEL_UBICACIONES_ESTADO_POR_ID(IDE_ESTADO);
        }
        public List<BE_UBICACIONES_ESTADO> f_list_EstadoDiario(BE_UBICACIONES_ESTADO obj)
        {
            return new DA_UBICACIONES_ESTADO().f_list_EstadoDiario_D(obj);
        }
    }
}
