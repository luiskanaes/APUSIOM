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
    public class DA_ARCHIVOS_MIGRACION
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public int Mant_Insert_File(BE_ARCHIVOS_MIGRACION oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_ENVIO ,tgSQLFieldType.NUMERIC),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ARCHIVO ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.RUTA_FILE   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO_COSTO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_ENVIA  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_TAREO  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FLG_ENVIO  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.TIPO_FILE   ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FILE_ZIPEADO    ,tgSQLFieldType.TEXT  ),

            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_ARCHIVOS_MIGRACION", Parametros));
        }
        public DataTable Get_ARCHIVOS_MIGRACION_POR_OBRA_FECHA(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ARCHIVOS_MIGRACION_POR_OBRA_FECHA", IDE_EMPRESA, IDE_CECOS, FEC_TAREO);

        }
    }
}
