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
    public class DA_CABECERA
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public int Mant_Insert_ActividadPlaner(BE_CABECERA oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.PK_TAREA ,tgSQLFieldType.NUMERIC  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_PROYECTO ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_ACTIVIDAD   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_ACTIVIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_TAREA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_TAREA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_UNIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CTA_COSTO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_FRENTE  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DES_FRENTE   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.HORAS_HOMBRE  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.METRADOS   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.HORAS_HOMBRE_M  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.METRADOS_M   ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.TIPO_ARCHIVO   ,tgSQLFieldType.TEXT ),


            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_CABECERA", Parametros));
        }
        public DataTable ListarProgramacion(string centro, int empresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CABECERA_POR_CC", centro, empresa);
        }

         public DataTable ListarProgramacion_Disciplina(string centro, int empresa, int disciplina)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CABECERA_POR_CC_DISCIPLINA", centro, empresa, disciplina);
        }
        
    }
}
