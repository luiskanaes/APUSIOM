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
namespace DataAccess
{
    public class DA_ASIGNACION_TAREO
    {
        Util oUtilitarios = new Util();
        public int Mant_Insert_Tareo(BE_ASIGNACION_TAREO oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREO_ASIGNACION ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_CECOS   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.INT_ANIO  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.INT_MES  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.INT_SEM  ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.COD_PROYECTO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FEC_TAREO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_CLIENTE  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_UBICACIONES   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FLG_ESTADO   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRO    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TURNO    ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.NOMBRE_DIA     ,tgSQLFieldType.TEXT ),
            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_ASIGNACION_TAREO", Parametros));
        }
        public int Mant_Insert_TareasActividades(BE_ASIGNACION_TAREAS oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREA ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREO_ASIGNACION ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ITEM_ACTIVIDAD   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_ACTIVIDAD  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DET_TAREA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_FRENTE  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CTA_COSTO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_TAREA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_UNIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.HORA_INICIO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.HORA_FIN   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.PROGRAMADO   ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.EJECUTADO   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FLG_ESTADO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.OBSERVACIONES   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_AREAS    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRO    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_INGCAMPO    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_CAPATAZ    ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.RETRABAJO    ,tgSQLFieldType.BOOLEAN  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_ACTIVIDAD    ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_FRENTE    ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.PK_TAREA     ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_DISCIPLINA     ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.SECTOR      ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.NRO_FOLIO      ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.SI      ,tgSQLFieldType.TEXT  ),
            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_ASIGNACION_TAREAS", Parametros));
        }
        public DataTable Get_Listar_TareoFecha(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ASIGNACION_TAREO_POR_FECHA", IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
        }
        public DataTable CerrarTareo_fecha(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, int ESTADO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_ASIGNACION_TAREO_PROCESAR", IDE_EMPRESA, IDE_CECOS, FEC_TAREO, ESTADO );
        }
        public int Mant_Insert_Estructura(BE_M_ESTRUCTURA_INSUMO oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_INSUMO ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESTRUCTURA ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DESCRIPCION   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.EJECUTADO  ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_TAREO  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREA   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRO  ,tgSQLFieldType.TEXT ),

            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_M_ESTRUCTURA_INSUMO", Parametros));
        }
        public int Mant_Insert_Estructura_ING(BE_M_ESTRUCTURA_INSUMO oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_INSUMO ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESTRUCTURA ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DESCRIPCION   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.EJECUTADO  ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_TAREO  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.PK_TAREA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.USUARIO_REGISTRO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_INGENIERO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_TAREA  ,tgSQLFieldType.TEXT ),

            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_M_ESTRUCTURA_INSUMO_ING", Parametros));
        }
        public DataTable SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC( string IDE_CECOS, string FEC_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC", IDE_CECOS, FEC_TAREO);
        }
        public DataTable uspINS_ASIGNACION_TAREAS_WS(string IDE_CECOS, string FEC_TAREO, string IDE_INGCAMPO, string IDE_CAPATAZ, string IDE_ACTIVIDAD, string USUARIO_REGISTRO)
        { 
            return oUtilitarios.EjecutaDatatable("dbo.uspINS_ASIGNACION_TAREAS_WS", IDE_CECOS, FEC_TAREO, IDE_INGCAMPO, IDE_CAPATAZ, IDE_ACTIVIDAD, USUARIO_REGISTRO);
        }

        public DataTable uspINS_ASIGNACION_TAREAS_DIRECTO(string IDE_CECOS, string FEC_TAREO, string IDE_INGCAMPO, string IDE_CAPATAZ, string IDE_ACTIVIDAD, string USUARIO_REGISTRO,string TIPO_ARCHIVO,string  IDE_TAREO_ASIGNACION )
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspINS_ASIGNACION_TAREAS_DIRECTO", IDE_CECOS, FEC_TAREO, IDE_INGCAMPO, IDE_CAPATAZ, IDE_ACTIVIDAD, USUARIO_REGISTRO, TIPO_ARCHIVO, IDE_TAREO_ASIGNACION);
        }


        public DataTable SP_INSERT_ASIGNACION_TAREO(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, string USUARIO, string DIA_NOMBRE)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INSERT_ASIGNACION_TAREO", IDE_EMPRESA, IDE_CECOS, FEC_TAREO, USUARIO, DIA_NOMBRE);
        }

        public DataTable SP_CONSULTAR_FLG_100(string IDE_CECOS, string DIA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_FLG_100",  IDE_CECOS, DIA);
        }

        public DataTable SP_CERRAR_DIA_TRABAJO(string IDE_CECOS, string FECHA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CERRAR_DIA_TRABAJO", IDE_CECOS, FECHA);
        }
    }
}
