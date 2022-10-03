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
    public class DA_CONTROL_AVANCE
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public List<BE_CABECERA> f_list_TareProyecto_D(BE_CABECERA Xobj)
        {
            List<BE_CABECERA> Lista_Tarea_E = new List<BE_CABECERA>();
           
            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER_TAREAS_PROYECTO", cn);
                SqlDataReader drd;
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 99999;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@TIPO", SqlDbType.Int)).Value = Xobj.TIPO;
                    cmd.Parameters.Add(new SqlParameter("@IP_PROYECTO", SqlDbType.VarChar, 200)).Value = Xobj.ID_PROYECTO;
                    cmd.Parameters.Add(new SqlParameter("@IDE_ACTIVIDAD", SqlDbType.VarChar, 200)).Value = Xobj.IDE_ACTIVIDAD;
                    cmd.Parameters.Add(new SqlParameter("@ID_TAREA", SqlDbType.VarChar, 100)).Value = Xobj.ID_TAREA ;
                    cmd.Parameters.Add(new SqlParameter("@IDE_EMPRESA", SqlDbType.Int )).Value = Xobj.IDE_EMPRESA ;
                    cmd.Parameters.Add(new SqlParameter("@TIPO_ARCHIVO", SqlDbType.Int)).Value = Xobj.TIPO_ARCHIVO;
                    drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (drd != null)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                BE_CABECERA obj_E = new BE_CABECERA();
                                obj_E.ID_PROYECTO = (drd["ID_PROYECTO"] == DBNull.Value) ? ("") : ((string)drd["ID_PROYECTO"]).Trim();
                                obj_E.IDE_ACTIVIDAD = (drd["IDE_ACTIVIDAD"] == DBNull.Value) ? ("") : ((string)drd["IDE_ACTIVIDAD"]).Trim();
                                obj_E.DES_ACTIVIDAD = (drd["DES_ACTIVIDAD"] == DBNull.Value) ? ("") : ((string)drd["DES_ACTIVIDAD"]).Trim();
                                obj_E.ID_TAREA = (drd["ID_TAREA"] == DBNull.Value) ? ("") : ((string)drd["ID_TAREA"]).Trim();
                                obj_E.DES_TAREA = (drd["DES_TAREA"] == DBNull.Value) ? ("") : ((string)drd["DES_TAREA"]).Trim();
                                obj_E.ID_FRENTE = (drd["ID_FRENTE"] == DBNull.Value) ? ("") : ((string)drd["ID_FRENTE"]).Trim();
                                obj_E.DES_FRENTE = (drd["DES_FRENTE"] == DBNull.Value) ? ("") : ((string)drd["DES_FRENTE"]).Trim();
                                obj_E.CTA_COSTO = (drd["CTA_COSTO"] == DBNull.Value) ? ("") : ((string)drd["CTA_COSTO"]).Trim();
                                obj_E.DES_UNIDAD = (drd["des_unidad"] == DBNull.Value) ? ("") : ((string)drd["des_unidad"]).Trim();
                                obj_E.DESCRIPCION = (drd["DESCRIPCION"] == DBNull.Value) ? ("") : ((string)drd["DESCRIPCION"]).Trim();
                                obj_E.CODIGO_TAREA = (drd["CODIGO_TAREA"] == DBNull.Value) ? ("") : ((string)drd["CODIGO_TAREA"]).Trim();
                                obj_E.PK_TAREA = (drd["PK_TAREA"] == DBNull.Value) ? 0 : ((int)drd["PK_TAREA"]);
                                Lista_Tarea_E.Add(obj_E);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Lista_Tarea_E;
            }
        }
    }
}
