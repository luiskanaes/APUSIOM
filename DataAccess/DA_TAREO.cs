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
    public class DA_TAREO
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public int Mant_Insert_Trabajos(BE_TAREO oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TRABAJO ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREA ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_DNI   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.HORA_EMPLEADA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_INGCAMPO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_CAPATAZ  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FLG_ESTADO   ,tgSQLFieldType.BOOLEAN ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.TIPO   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CCENTRO    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_BONIFICACION     ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_ASISTENCIA     ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_CATEGORIA      ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESPECIALIDAD     ,tgSQLFieldType.TEXT ),


            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_TAREO", Parametros));
        }
        public List<BE_TAREO> f_actividadesPersona_tareo_D(BE_TAREO Xobj)
        {
            List<BE_TAREO> Lista_Tareo_E = new List<BE_TAREO>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER_TAREO_PERSONA", cn);
                SqlDataReader drd;
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 99999;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDE_EMPRESA", SqlDbType.Int)).Value = Xobj.IDE_EMPRESA;
                    cmd.Parameters.Add(new SqlParameter("@CCENTRO", SqlDbType.VarChar, 50)).Value = Xobj.CCENTRO;
                    cmd.Parameters.Add(new SqlParameter("@TIPO ", SqlDbType.Int)).Value = Xobj.TIPO;
                    cmd.Parameters.Add(new SqlParameter("@FECHA", SqlDbType.VarChar, 10)).Value = Xobj.FECHA;
                    cmd.Parameters.Add(new SqlParameter("@DES_DNI", SqlDbType.VarChar, 10)).Value = Xobj.DES_DNI;

                    drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (drd != null)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                BE_TAREO obj_E = new BE_TAREO();

                                obj_E.IDE_TAREA = (drd["IDE_TAREA"] == DBNull.Value) ? (0) : ((int)drd["IDE_TAREA"]);
                                obj_E.HORA_EMPLEADA = (drd["HORA_EMPLEADA"] == DBNull.Value) ? (0) : ((decimal)drd["HORA_EMPLEADA"]);
                                obj_E.ITEM_ACTIVIDAD = (drd["ITEM_ACTIVIDAD"] == DBNull.Value) ? ("") : ((string)drd["ITEM_ACTIVIDAD"]).Trim();
                                Lista_Tareo_E.Add(obj_E);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Lista_Tareo_E;
            }
        }
        public Int32 INS_ASISTENCIA_PERSONAL(BE_ASISTENCIA_PERSONAL obj)
        {
          
            Int32 RowsAffected = 0;
            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("WCF_uspINS_ASISTENCIA_PERSONAL", cn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 99999;

                    cmd.Parameters.AddWithValue("IDE_PERSONAL ", obj.IDE_PERSONAL == null ? "" : obj.IDE_PERSONAL);
                    cmd.Parameters.AddWithValue("FEC_ASISTENCIA", obj.FEC_ASISTENCIA == null ? "" : obj.FEC_ASISTENCIA);
                    cmd.Parameters.AddWithValue("IDE_ESTADO", obj.IDE_ESTADO == null ? "" : obj.IDE_ESTADO);
                    cmd.Parameters.AddWithValue("ESTADO_DIARIO", obj.ESTADO_DIARIO == null ? "" : obj.ESTADO_DIARIO);
                    cmd.Parameters.AddWithValue("CCENTRO", obj.CCENTRO == null ? "" : obj.CCENTRO);
                    cmd.Parameters.AddWithValue("IDE_EMPRESA", obj.IDE_EMPRESA.ToString() == null ? 1 : obj.IDE_EMPRESA);
                    cmd.Parameters.AddWithValue("USUARIO_REGISTRA", obj.USUARIO_REGISTRA == null ? "" : obj.USUARIO_REGISTRA);
                    cmd.Parameters.AddWithValue("CANTIDAD", obj.CANTIDAD == null ? "" : obj.CANTIDAD);
                    cmd.Parameters.AddWithValue("CANTIDAD_ASISTENCIA", obj.CANTIDAD_ASISTENCIA == null ? "" : obj.CANTIDAD_ASISTENCIA);
                    RowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return RowsAffected;
            }


        }
        public DataTable Get_actividadesPersona_tareo_D(int IDE_EMPRESA, string CCENTRO, int TIPO, string FECHA, string DES_DNI, int IDE_TAREA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_TAREO_PERSONA", IDE_EMPRESA, CCENTRO, TIPO, FECHA, DES_DNI, IDE_TAREA);
        }
        public DataTable SP_OBTENER_TAREO_PERSONA_ID(int IDE_EMPRESA, string CCENTRO, int TIPO, string FECHA, string DES_DNI, int IDE_TAREA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_TAREO_PERSONA_ID", IDE_EMPRESA, CCENTRO, TIPO, FECHA, DES_DNI, IDE_TAREA);
        }
        public DataTable Get_AsistenciaPersonal_tareo(int IDE_EMPRESA, string CCENTRO,  string FECHA, string DES_DNI)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_ESTADO_DIARIO_PERSONA", IDE_EMPRESA, CCENTRO, FECHA, DES_DNI);
        }
        public DataTable Get_EliminarTareo_Personal(int IDE_EMPRESA, string CCENTRO, string FECHA, string DES_DNI)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspDEL_TAREO_PERSONA", IDE_EMPRESA, CCENTRO, FECHA, DES_DNI);
        }
        public DataTable Get_ListarTareo_fecha(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INSTAR_GESTOR_TAREO", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable Get_WCF_ASIGNACION_TAREO(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspWCFSEL_ASIGNACION_TAREO_POR_FECHA", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable Get_Listar_CuadroAcumulado(int IDE_EMPRESA, string CCENTRO, string FECHA,string CAPATAZ)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_LISTAR_ACUMULADO_TAREO", IDE_EMPRESA, CCENTRO, FECHA,CAPATAZ );
        }
        public DataTable ListarPersonal_SinTareo(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_SIN_TAREO", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable Get_Tareo_fecha(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_TAREO_FECHA", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable UpdateMigracion(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_TAREO_MIGRACION", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable Get_ExcesoHrs_Personal(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_EXCESO_TAREO", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable Get_Indicadores_Tareo(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_INDICADORES_TAREO", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable REPORTE_CONTROL_AVANCES(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_CONTROL_AVANCES", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable LISTA_ESTRUCTURAS_POR_TIPO(string CCENTRO, int tipo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_M_LISTA_ESTRUCTURAS_POR_TIPO", CCENTRO, tipo);
        }
        public DataTable uspSEL_M_TAREA_ESTRUCTURA_POR_TAREA(int IDE_TAREA, string CCENTRO, string ID_FRENTE,string DET_TAREA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_M_TAREA_ESTRUCTURA_POR_TAREA", IDE_TAREA, CCENTRO, ID_FRENTE, DET_TAREA);
        }
        public DataTable InsertarKardex(int ID_ESTRUCTURA, string DESCRIPCION,int ENTRADA , int SALIDA, string CENTRO, string USUARIO,string FECHA_TAREO, int IDE_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.spr_InsertarKardex", ID_ESTRUCTURA,  DESCRIPCION,  ENTRADA,  SALIDA,  CENTRO,  USUARIO, FECHA_TAREO,  IDE_TAREO);
        }
        public DataTable LISTA_ESTRUCTURAS_CONSUMO(string CCENTRO, int ESTRUCTURA, string FECHA, int IDE_TAREA, string DSC_AREA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_M_LISTA_ESTRUCTURAS_CONSUMO", CCENTRO, ESTRUCTURA, FECHA, IDE_TAREA, DSC_AREA);
        }
        public DataTable LISTA_ESTRUCTURAS_CONSUMO_ING(string CCENTRO, int ESTRUCTURA, string FECHA, string  IDE_TAREA, string DSC_AREA, string IDE_INGENIERO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_M_LISTA_ESTRUCTURAS_CONSUMO_ING", CCENTRO, ESTRUCTURA, FECHA, IDE_TAREA, DSC_AREA, IDE_INGENIERO);
        }
        public DataTable SP_ELIMINAR_TAREO_PERSONA(int IDE_EMPRESA, string CCENTRO, string FECHA, string DES_DNI,string CAPATAZ)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ELIMINAR_TAREO_PERSONA", IDE_EMPRESA, CCENTRO, FECHA, DES_DNI, CAPATAZ);
        }
        public DataTable uspINSERT_TAREO_DIA(string FECHA, string CCENTRO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspINSERT_TAREO_DIA", FECHA, CCENTRO);
        }
        public DataTable SP_INSTAR_GESTOR_TAREO_DETALLE(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INSTAR_GESTOR_TAREO_DETALLE", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable SP_INSTAR_GESTOR_TAREO_DETALLE_DOMINICAL(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INSTAR_GESTOR_TAREO_DETALLE_DOMINICAL", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable SP_INSTAR_GESTOR_TAREO(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INSTAR_GESTOR_TAREO", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable SP_GENERAR_TAREO_NO_LABORABLE(int IDE_EMPRESA, string CCENTRO, string FECHA, string USER, string DIA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_TAREO_NO_LABORABLE", IDE_EMPRESA, CCENTRO, FECHA, USER, DIA);
        }
        public DataTable SP_CORREO_CIERRE_TAREO_DIA(string CCENTRO, string FECHA, string user)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CORREO_CIERRE_TAREO_DIA",  CCENTRO, FECHA, user);
        }
        public DataTable uspWCF_SELECT_PERIODO(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspWCF_SELECT_PERIODO", IDE_EMPRESA,CCENTRO, FECHA);
        }
        public DataTable uspWCF_SELECT_PERIODO_SKEX(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspWCF_SELECT_PERIODO_SKEX", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable uspUPD_TAREO_LIMPIAR_MIGRACION( string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_TAREO_LIMPIAR_MIGRACION",  CCENTRO, FECHA);
        }
        public DataTable uspWCF_TAREO_LIMPIAR_MIGRACION_GESTOR(int IDE_EMPRESA, string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspWCF_TAREO_LIMPIAR_MIGRACION_GESTOR", IDE_EMPRESA, CCENTRO, FECHA);
        }
        public DataTable SP_GENERAR_TAREO_FERIADO(int IDE_EMPRESA, string CCENTRO, string FECHA, string USER, string DIA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_TAREO_FERIADO", IDE_EMPRESA, CCENTRO, FECHA, USER, DIA);
        }
        public DataTable SP_CARGA_ULTIMA_CUADRILLA(string CCENTRO, string FECHA, string IDE_CAPATAZ, string ING_INGENIERO, int TIPO, string FECHA_ATERIOR)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CARGA_ULTIMA_CUADRILLA",  CCENTRO, FECHA, IDE_CAPATAZ, ING_INGENIERO, TIPO, FECHA_ATERIOR);
        }
        public DataTable SP_ELIMINAR_TAREO_CUADRILLA_VARIOS(int IDE_EMPRESA, string CCENTRO, string FECHA, string DES_DNI, string CAPATAZ, string  ING_CAMPO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ELIMINAR_TAREO_CUADRILLA_VARIOS", IDE_EMPRESA, CCENTRO, FECHA, DES_DNI, CAPATAZ, ING_CAMPO);
        }
        public DataTable uspDEL_TAREO_PERSONA_ID(int IDE_TRABAJO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspDEL_TAREO_PERSONA_ID", IDE_TRABAJO);
        }
        public DataTable SP_GENERAR_TAREO_CONSOLIDADO(string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_TAREO_CONSOLIDADO", CCENTRO,FECHA );
        }
        public DataTable SP_GENERAR_TAREO_CONSOLIDADO_DETALLE(string CCENTRO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_TAREO_CONSOLIDADO_DETALLE", CCENTRO, FECHA);
        }

    }
}
