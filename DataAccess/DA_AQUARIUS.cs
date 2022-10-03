using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using UserCode;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using DataAccess.Conexion;
using System.Configuration;

namespace DataAccess
{
    public class DA_AQUARIUS
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSisplan"].ToString());
    
        UtilSisplan oUtilitarios = new UtilSisplan();

        public DataTable SP_PLA_RPT_CMO_DETALLE_VARIOS_DETALLE_V3(string V_COD_EMPRESA,
                        string V_ANO_PROCESO,
                        string V_NUM_VERSION,
                        string V_COD_TIPO_PLANILLA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_PLA_RPT_CMO_DETALLE_VARIOS_DETALLE_V3", V_COD_EMPRESA,
                         V_ANO_PROCESO,
                         V_NUM_VERSION,
                         V_COD_TIPO_PLANILLA);

        }
    }
}
