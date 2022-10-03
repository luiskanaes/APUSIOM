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
    public class DA_ASISTENCIA_PERSONAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public int Mant_Insert_Asistencia(BE_ASISTENCIA_PERSONAL oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_ASISTENCIA ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_PERSONAL ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FEC_ASISTENCIA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CCENTRO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRA  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_ESTADO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.SUPERVISOR    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.Work_Group    ,tgSQLFieldType.TEXT ),
            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_ASISTENCIA_PERSONAL", Parametros));
        }
        public List<BE_ASISTENCIA_PERSONAL> f_list_Asistencia_D(BE_ASISTENCIA_PERSONAL Xobj)
        {
            List<BE_ASISTENCIA_PERSONAL> Lista_Asistencia_E = new List<BE_ASISTENCIA_PERSONAL>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("uspSEL_ASISTENCIA_PERSONAL_FECHA", cn);
                SqlDataReader drd;
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 99999;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDE_EMPRESA", SqlDbType.Int)).Value = Xobj.IDE_EMPRESA;
                    cmd.Parameters.Add(new SqlParameter("@CCENTRO", SqlDbType.VarChar, 200)).Value = Xobj.CCENTRO;
                    cmd.Parameters.Add(new SqlParameter("@FEC_ASISTENCIA", SqlDbType.VarChar, 200)).Value = Xobj.FEC_ASISTENCIA;
                    drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (drd != null)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                BE_ASISTENCIA_PERSONAL obj_E = new BE_ASISTENCIA_PERSONAL();
                                obj_E.IDE_PERSONAL = (drd["IDE_PERSONAL"] == DBNull.Value) ? ("") : ((string)drd["IDE_PERSONAL"]).Trim();
                                
                                obj_E.ESTADO_DIARIO = (drd["ESTADO_DIARIO"] == DBNull.Value) ? ("") : ((string)drd["ESTADO_DIARIO"]).Trim();
                                obj_E.CCENTRO = (drd["CCENTRO"] == DBNull.Value) ? ("") : ((string)drd["CCENTRO"]).Trim();
                                obj_E.IDE_EMPRESA = (drd["IDE_EMPRESA"] == DBNull.Value) ? (1) : ((int)drd["IDE_EMPRESA"]);
                                obj_E.FEC_ASISTENCIA = (drd["FEC_ASISTENCIA"] == DBNull.Value) ? ("") : ((string)drd["FEC_ASISTENCIA"]).Trim();
                                obj_E.IDE_ESTADO = (drd["IDE_ESTADO"] == DBNull.Value) ? ("") : ((string)drd["IDE_ESTADO"]).Trim();
                                Lista_Asistencia_E.Add(obj_E);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Lista_Asistencia_E;
            }
        }
        public DataTable Get_ListarAsistencia_fecha(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ASISTENCIA_PERSONAL_FECHA", IDE_EMPRESA, CCENTRO, FECHA);
        }
    }
}
