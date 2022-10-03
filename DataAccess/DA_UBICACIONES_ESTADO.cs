using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using BusinessEntity;
using UserCode;
using System.Data.SqlClient;
using DataAccess.Conexion;
using System.Configuration;

namespace DataAccess
{
   public class DA_UBICACIONES_ESTADO
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public int uspINS_UBICACIONES_ESTADO(BE_UBICACIONES_ESTADO oBESOl)
        {
            object[] Parametros = new[] {
                (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.IDE_ESTADO ,tgSQLFieldType.TEXT),
                (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.IDE_UBICACION ,tgSQLFieldType.TEXT),
                (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.DESCRIPCION ,tgSQLFieldType.TEXT),
                (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.ABREVIATURA ,tgSQLFieldType.TEXT),
                (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.COLOR_FONDO ,tgSQLFieldType.TEXT),
                (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.FLG_ESTADO ,tgSQLFieldType.TEXT),
                (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.FLG_PRESENTE ,tgSQLFieldType.TEXT),


            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_UBICACIONES_ESTADO", Parametros));
        }
        public DataTable uspSEL_UBICACIONES_ESTADO_POR_UBICACION(string IDE_UBICACION, string ESTADO)
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_UBICACIONES_ESTADO_POR_UBICACION", IDE_UBICACION, ESTADO);
        }

        public DataTable uspSEL_UBICACIONES_ESTADO_POR_ID(string IDE_ESTADO)
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_UBICACIONES_ESTADO_POR_ID", IDE_ESTADO);
        }
        public List<BE_UBICACIONES_ESTADO> f_list_EstadoDiario_D(BE_UBICACIONES_ESTADO Xobj)
        {
            List<BE_UBICACIONES_ESTADO> Lista_Parametros_E = new List<BE_UBICACIONES_ESTADO>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("uspSEL_UBICACIONES_ESTADO_POR_UBICACION", cn);
                SqlDataReader drd;
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 99999;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDE_UBICACION ", SqlDbType.VarChar, 50)).Value = Xobj.IDE_UBICACION;
                    cmd.Parameters.Add(new SqlParameter("@FLG_ESTADO", SqlDbType.VarChar, 50)).Value = Xobj.FLG_ESTADO;
                    drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (drd != null)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                BE_UBICACIONES_ESTADO obj_E = new BE_UBICACIONES_ESTADO();

                                obj_E.IDE_UBICACION = (drd["IDE_UBICACION"] == DBNull.Value) ? ("") : ((string)drd["IDE_UBICACION"]).Trim();
                                obj_E.COLOR_FONDO = (drd["COLOR_FONDO"] == DBNull.Value) ? ("") : ((string)drd["COLOR_FONDO"]).Trim();
                                obj_E.ABREVIATURA = (drd["ABREVIATURA"] == DBNull.Value) ? ("") : ((string)drd["ABREVIATURA"]).Trim();
                               
                                Lista_Parametros_E.Add(obj_E);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Lista_Parametros_E;
            }
        }
    }
}
