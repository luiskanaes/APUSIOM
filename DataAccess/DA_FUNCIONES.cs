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
    public class DA_FUNCIONES
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public DataTable ListarMenu_DA(int pPerfil)
        {
            return oUtilitarios.EjecutaDatatable("dbo.usp_SeleccionarMenuPrincipal", pPerfil);
        }
        public DataTable Get_ListarPeriodoFecha(int tipo, int anio, int mes)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERIODO", tipo, anio, mes);
        }
        public DataTable Get_ListarPeriodoFecha_bd(int tipo, string fecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_LISTAR_FECHA", tipo, fecha);
        }
        public DataTable Get_ListarCesos(int idEmpresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CECOS_POR_EMPRESA", idEmpresa);
        }
        public DataTable GetListar_ActividadTarea(int tipo, string proyecto, string idactividad, string det_tarea, int empresa, int archivo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_TAREAS_PROYECTO", tipo, proyecto, idactividad, det_tarea, empresa, archivo);
        }

        public DataTable USP_OBTENER_TODAS_TAREAS_PROYECTO(int tipo, string proyecto, string idactividad, string det_tarea, int empresa, int archivo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.USP_OBTENER_TODAS_TAREAS_PROYECTO", tipo, proyecto, idactividad, det_tarea, empresa, archivo);
        }

        public DataTable Get_ListarParametros(string tabla, string campo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_TBPARAMETROS", tabla,campo );
        }
        public List<BE_TBPARAMETROS> f_list_Parametros_D(BE_TBPARAMETROS Xobj)
        {
            List<BE_TBPARAMETROS> Lista_Parametros_E = new List<BE_TBPARAMETROS>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("uspSEL_TBPARAMETROS", cn);
                SqlDataReader drd;
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 99999;
                    cmd.CommandType = CommandType.StoredProcedure;
               
                    cmd.Parameters.Add(new SqlParameter("@DES_TABLA", SqlDbType.VarChar, 50)).Value = Xobj.DES_TABLA;
                    cmd.Parameters.Add(new SqlParameter("@DES_CAMPO", SqlDbType.VarChar, 50)).Value = Xobj.DES_CAMPO;
                   

                    drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (drd != null)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                BE_TBPARAMETROS obj_E = new BE_TBPARAMETROS();
                               
                                obj_E.DES_TABLA = (drd["DES_TABLA"] == DBNull.Value) ? ("") : ((string)drd["DES_TABLA"]).Trim();
                                obj_E.DES_CAMPO = (drd["DES_CAMPO"] == DBNull.Value) ? ("") : ((string)drd["DES_CAMPO"]).Trim();
                                obj_E.DES_ASUNTO = (drd["DES_ASUNTO"] == DBNull.Value) ? ("") : ((string)drd["DES_ASUNTO"]).Trim();
                                obj_E.IDE_PARAMETRO = (drd["IDE_PARAMETRO"] == DBNull.Value) ? (0) : ((int)drd["IDE_PARAMETRO"]);
                                obj_E.DES_ABREVIADO = (drd["DES_ABREVIADO"] == DBNull.Value) ? ("") : ((string)drd["DES_ABREVIADO"]).Trim();
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
        public DataTable Get_ListarBonificacion(string cc, int empresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CECOS_BONIFICACION", cc, empresa);
        }
        public DataTable Get_ListarHrasJorandas( string fecha,int empresa, string diaNombre, string centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_JORNADA_FERIADOS", fecha, empresa, diaNombre, centro);
        }
        public DataTable Get_ListarEmpresaPerfil(int perfil, string usuario)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_EMPRESA_PERFIL", perfil, usuario);
        }
        public DataTable Get_ListarCesosPerfil(int perfil, string usuario, int IdEmpresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CECOS_POR_PERFIL", perfil,  usuario,  IdEmpresa);
        }
        public DataTable ListarEstadoDiario(string tabla, string campo,int empresa, string centro, string fecha, string diaNombre)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ESTADOS_DIARIO_DIA", tabla, campo, empresa, centro, fecha, diaNombre);
        }

        public DataTable uspSEL_EMPRESA( )
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_EMPRESA" );
        }

        public DataTable uspSEL_EMPRESA_ID(string IDE_FECHA)
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_EMPRESA_ID", IDE_FECHA);
        }

        public List<BE_TBPARAMETROS> f_list_EstadoDiario_D(BE_TBPARAMETROS Xobj)
        {
            List<BE_TBPARAMETROS> Lista_Parametros_E = new List<BE_TBPARAMETROS>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("uspSEL_ESTADOS_DIARIO_DIA", cn);
                SqlDataReader drd;
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 99999;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@DES_TABLA", SqlDbType.VarChar, 50)).Value = Xobj.DES_TABLA;
                    cmd.Parameters.Add(new SqlParameter("@DES_CAMPO", SqlDbType.VarChar, 50)).Value = Xobj.DES_CAMPO;
                    cmd.Parameters.Add(new SqlParameter("@IDE_EMPRESA", SqlDbType.Int )).Value = Xobj.IDE_EMPRESA ;
                    cmd.Parameters.Add(new SqlParameter("@CCENTRO ", SqlDbType.VarChar, 50)).Value = Xobj.CENTRO_COSTO ;
                    cmd.Parameters.Add(new SqlParameter("@FECHA", SqlDbType.VarChar, 50)).Value = Xobj.FECHA ;
                    cmd.Parameters.Add(new SqlParameter("@DIA", SqlDbType.VarChar, 50)).Value = Xobj.DES_CAMPO;
                    drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (drd != null)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                BE_TBPARAMETROS obj_E = new BE_TBPARAMETROS();

                                obj_E.DES_TABLA = (drd["DES_TABLA"] == DBNull.Value) ? ("") : ((string)drd["DES_TABLA"]).Trim();
                                obj_E.DES_CAMPO = (drd["DES_CAMPO"] == DBNull.Value) ? ("") : ((string)drd["DES_CAMPO"]).Trim();
                                obj_E.DES_ASUNTO = (drd["DES_ASUNTO"] == DBNull.Value) ? ("") : ((string)drd["DES_ASUNTO"]).Trim();
                                obj_E.IDE_PARAMETRO = (drd["IDE_PARAMETRO"] == DBNull.Value) ? (0) : ((int)drd["IDE_PARAMETRO"]);
                                obj_E.DES_ABREVIADO = (drd["DES_ABREVIADO"] == DBNull.Value) ? ("") : ((string)drd["DES_ABREVIADO"]).Trim();
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

        public DataTable ListarEmpresaPerfil_Tareo_Emp(int perfil, string usuario)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_EMPRESA_PERFIL_Tareo_Emp", perfil, usuario);
        }
    }
}
