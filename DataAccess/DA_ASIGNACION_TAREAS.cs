using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using BusinessEntity;
using UserCode;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Conexion;
using System.Configuration;

namespace DataAccess
{
    public  class DA_ASIGNACION_TAREAS
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public DataTable Get_Listar_ActividadAsignadas(string IDE_EMPRESA, string IDE_CECOS, string COD_PROYECTO, string FEC_TAREO, string IDE_CAPATAZ,string IDE_INGCAMPO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ASIGNACION_TAREAS_POR_FECHA", IDE_EMPRESA, IDE_CECOS, COD_PROYECTO, FEC_TAREO, IDE_CAPATAZ, IDE_INGCAMPO);
        }
        public DataTable SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(string IDE_EMPRESA, string IDE_CECOS, string COD_PROYECTO, string FEC_TAREO, string IDE_CAPATAZ, string IDE_INGCAMPO, int disciplina)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA", IDE_EMPRESA, IDE_CECOS, COD_PROYECTO, FEC_TAREO, IDE_CAPATAZ, IDE_INGCAMPO, disciplina);
        }
        public DataTable Get_Listar_PersonalCategoria(string P_PROYECTO, int IDE_EMPRESA, string  ID_CATEGORIA, string IDE_CAPATAZ)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_CATEGORIA", P_PROYECTO, IDE_EMPRESA, ID_CATEGORIA, IDE_CAPATAZ);
        }
        public DataTable Get_EliminarTareas(int id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspDEL_TAREO_POR_ID", id);
        }
        public DataTable Get_ConsultarTareasRealizadas(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CONSULTAR_TAREAS_POR_FECHA", IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
        }
        public DataTable Get_obtener_PersonalCategoria(string P_PROYECTO, int IDE_EMPRESA, string  ID_CATEGORIA, string IDE_CAPATAZ, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_X_FECHA", P_PROYECTO, IDE_EMPRESA, ID_CATEGORIA, IDE_CAPATAZ, FECHA);
        }

        public DataTable SP_OBTENER_EQUIPO_TRABAJO_TAREO(string P_PROYECTO, string FLG_ESTADO, string TIPO, string IDE_PERSONAL, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_EQUIPO_TRABAJO_TAREO", P_PROYECTO, FLG_ESTADO, TIPO, IDE_PERSONAL, FECHA);
        }

        public DataTable uspASIGNAR_CAMBIO_CUADRILLA(string IDE_CAPATAZ,
        string IDE_ING_NUEVO,
        string IDE_ING_ANTIGUO,
        string CENTRO,
        string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspASIGNAR_CAMBIO_CUADRILLA", IDE_CAPATAZ,
            IDE_ING_NUEVO,
            IDE_ING_ANTIGUO,
            CENTRO,
            FECHA);
        }

        public DataTable SP_OBTENER_PERSONAL_TODO_X_FECHA(string P_PROYECTO, int IDE_EMPRESA,  string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_TODO_X_FECHA", P_PROYECTO, IDE_EMPRESA, FECHA);
        }

        public DataTable USP_OBTENER_EQUIPO_TRABAJO_CAPATAZ(string P_PROYECTO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.USP_OBTENER_EQUIPO_TRABAJO_CAPATAZ", P_PROYECTO, FECHA);
        }


        public DataTable SP_OBTENER_PLANILLA_PERSONAL_OBRERO(string P_PROYECTO, int IDE_EMPRESA, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PLANILLA_PERSONAL_OBRERO", P_PROYECTO, IDE_EMPRESA, FECHA);
        }
        public DataTable Get_Tareo_x_persona(string centro, int empresa, string fecha, string personal, string capataz, string ing)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_TAREO_PERSONA", centro, empresa, fecha, personal, capataz, ing );
        }

        public DataTable USP_ACTUALIZAR_RESPONSABLES(string centro, string fecha, string personal, string capataz, string ing)
        {
            return oUtilitarios.EjecutaDatatable("dbo.USP_ACTUALIZAR_RESPONSABLES", centro,  fecha, personal, capataz, ing);
        }

        public DataTable Get_Lista_Personal_tareas_x_fecha(string P_PROYECTO, int IDE_EMPRESA, string IDE_CAPATAZ, string FECHA,string dateString, string ingeniero)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_TAREADO_FECHA", P_PROYECTO, IDE_EMPRESA, IDE_CAPATAZ, FECHA, dateString, ingeniero);
        }
        public DataTable SP_OBTENER_PERSONAL_TAREADO_FECHA_WS(string P_PROYECTO, int IDE_EMPRESA,string IDE_INGCAMPO, string IDE_CAPATAZ, string FECHA, string dateString, int verTotal)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_TAREADO_FECHA_WS", P_PROYECTO, IDE_EMPRESA, IDE_INGCAMPO, IDE_CAPATAZ, FECHA, dateString, verTotal);
        }
        public DataTable SP_OBTENER_CUADRILLA_X_FECHA_directo(string P_PROYECTO, int IDE_EMPRESA, string IDE_INGCAMPO, string IDE_CAPATAZ, string FECHA, string dateString, int verTotal)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_CUADRILLA_X_FECHA_directo", P_PROYECTO, IDE_EMPRESA, IDE_INGCAMPO, IDE_CAPATAZ, FECHA, dateString, verTotal);
        }

        public DataTable OBTENER_PERSONAL_RESPONSABLES_TAREO(string P_PROYECTO, int IDE_EMPRESA, string FECHA, int Tipo, string ide_personal)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_RESPONSABLES_TAREO", P_PROYECTO, IDE_EMPRESA, FECHA, Tipo, ide_personal);
        }
        public DataTable SEL_M_ESTRUCTURA_INSUMO_POR_FECHA(string P_PROYECTO, string FECHA, string CAPATAZ)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_M_ESTRUCTURA_INSUMO_POR_FECHA", P_PROYECTO, FECHA, CAPATAZ);
        }
        public DataTable SEL_M_ESTRUCTURA_INSUMO_POR_FECHA_CABECERA(string P_PROYECTO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_M_ESTRUCTURA_INSUMO_POR_FECHA_CABECERA", P_PROYECTO, FECHA);
        }
        public DataTable SEL_ASIGNACION_TAREAS_FECHA_ING(string IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, string IDE_INGCAMPO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ASIGNACION_TAREAS_FECHA_ING", IDE_EMPRESA, IDE_CECOS, FEC_TAREO, IDE_INGCAMPO);
        }
        public DataTable LISTAR_M_PARTIDA_CONTROL_MARCA_CENTRO(string IDE_CECOS, string CODIGO_AREA, int IDE_DISCIPLINA, string DET_TAREA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_LISTAR_M_PARTIDA_CONTROL_MARCA_CENTRO", IDE_CECOS, CODIGO_AREA, IDE_DISCIPLINA, DET_TAREA);
        }
        public List<BE_ASIGNACION_TAREAS> f_list_SEL_ASIGNACION_TAREAS_FECHA_ING(BE_ASIGNACION_TAREAS Xobj)
        {
            List<BE_ASIGNACION_TAREAS> Lista_Tarea_E = new List<BE_ASIGNACION_TAREAS>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("uspSEL_ASIGNACION_TAREAS_FECHA_ING", cn);
                SqlDataReader drd;
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 99999;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDE_EMPRESA", SqlDbType.Int)).Value = Xobj.IDE_EMPRESA;
                    cmd.Parameters.Add(new SqlParameter("@IDE_CECOS", SqlDbType.VarChar, 200)).Value = Xobj.CENTRO_COSTO;
                    cmd.Parameters.Add(new SqlParameter("@FEC_TAREO", SqlDbType.VarChar, 200)).Value = Xobj.FECHA_TAREO;
                    cmd.Parameters.Add(new SqlParameter("@IDE_INGCAMPO", SqlDbType.VarChar, 100)).Value = Xobj.IDE_INGCAMPO;
        
                    drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    if (drd != null)
                    {
                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                BE_ASIGNACION_TAREAS obj_E = new BE_ASIGNACION_TAREAS();
                                obj_E.CENTRO_COSTO = (drd["IDE_CECOS"] == DBNull.Value) ? ("") : ((string)drd["IDE_CECOS"]).Trim();
                                obj_E.FECHA_TAREO = (drd["FEC_TAREO"] == DBNull.Value) ? ("") : ((string)drd["FEC_TAREO"]).Trim();
                                obj_E.DET_TAREA = (drd["DET_TAREA"] == DBNull.Value) ? ("") : ((string)drd["DET_TAREA"]).Trim();
                                obj_E.ID_FRENTE = (drd["ID_FRENTE"] == DBNull.Value) ? ("") : ((string)drd["ID_FRENTE"]).Trim();
                                obj_E.DES_TAREA = (drd["DES_TAREA"] == DBNull.Value) ? ("") : ((string)drd["DES_TAREA"]).Trim();
                                obj_E.IDE_INGCAMPO = (drd["IDE_INGCAMPO"] == DBNull.Value) ? ("") : ((string)drd["IDE_INGCAMPO"]).Trim();
                                obj_E.CODIGO_AREA = (drd["CODIGO_AREA"] == DBNull.Value) ? ("") : ((string)drd["CODIGO_AREA"]).Trim();
                                obj_E.CODIGO_MARCA = (drd["CODIGO_MARCA"] == DBNull.Value) ? ("") : ((string)drd["CODIGO_MARCA"]).Trim();
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
        public DataTable SP_RPT_LISTAR_CUADRILLA_TAREO_PERSONAL(string IDE_CECOS, string IDE_PADRE, string FECHA, int NUEVO, string IDE_INGCAMPO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_RPT_LISTAR_CUADRILLA_TAREO_PERSONAL", IDE_CECOS, IDE_PADRE, FECHA, NUEVO, IDE_INGCAMPO);
        }
        public DataTable SP_OBTENER_PERSONAL_TAREO(string IDE_CECOS, int PERSONAL, string IDE_INGCAMPO, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_TAREO", IDE_CECOS, PERSONAL, IDE_INGCAMPO, FECHA);
        }
    }
}
