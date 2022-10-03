using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BusinessEntity;
using UserCode;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Conexion;
using System.Configuration;

namespace DataAccess
{
    public class DA_JORNADA_FERIADOS
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public int Mant_Insert_diasFeriados(BE_JORNADA_FERIADOS oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_FERIADO ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_CRIPCION   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO_COSTO  ,tgSQLFieldType.TEXT  ),

            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_JORNADA_FERIADOS", Parametros));
        }
        public DataTable uspSEL_JORNADA_FERIADOS_CENTRO(int ANIO, int MES, string CENTRO_COSTO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_JORNADA_FERIADOS_CENTRO", ANIO, MES, CENTRO_COSTO);
        }
        public DataTable uspDEL_DIA_FERIADOS_CENTRO(string fecha, string CENTRO_COSTO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspDEL_DIA_FERIADOS_CENTRO", fecha, CENTRO_COSTO);
        }
        public DataTable SP_CALENDARIO_TAREO(int ANIO, int MES, string CENTRO_COSTO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CALENDARIO_TAREO", ANIO, MES, CENTRO_COSTO);
        }
    }
}
