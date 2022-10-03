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
    public class DA_PERSONAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public DataTable Get_Listar_disponibilidadPersonal(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_POR_DISPONIBILIDAD", obj.FLG_LIBRE , obj.IDE_CAPATAZ, obj.IDE_EMPRESA , obj.CENTRO_COSTO , obj.FECHA , obj.IDE_INGENIERO);
        }
        public DataTable Get_Listar_PersonalCC(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_EMPRESA_CC", obj.IDE_EMPRESA, obj.CENTRO_COSTO, obj.TIPO_TRABAJADOR );
        }
        public DataTable uspSEL_PERSONAL_EMPRESA_CC_TIPO(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_EMPRESA_CC_TIPO", obj.IDE_EMPRESA, obj.CENTRO_COSTO, obj.TIPO_TRABAJADOR);
        }
        public DataTable Get_Listar_Personal_Estados(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_EMPRESA_ESTADO", obj.IDE_EMPRESA, obj.CENTRO_COSTO, obj.TIPO_TRABAJADOR, obj.FLG_ESTADOS );
        }
        public DataTable Get_Listar_PersonalGrupo(BE_PERSONAL obj)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_PERSONAL_EMPRESA_GRUPO", obj.IDE_EMPRESA, obj.CENTRO_COSTO, obj.IDE_GRUPO );
        }
        public DataTable Get_AsignarPersonal(string centro, int idPersona, int empresa, int estado, string capataz,string  ingeniero, string fecha )
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_ASIGNAR_PERSONAL", centro, idPersona, empresa, estado, capataz,ingeniero, fecha);
        }
        public DataTable Get_AsignarPersonal_DNI(string centro, string  idPersona, int empresa, int estado, string capataz, string ingeniero, string fecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_ASIGNAR_PERSONAL_DNI", centro, idPersona, empresa, estado, capataz, ingeniero, fecha);
        }
        public int Mant_Insert_Trabajadores_WCF(BE_PERSONAL oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO_COSTO ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.NOMBRES ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_PATERNO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_MATERNO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DOCUMENTO_IDENTIFICACION  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.TIPO_TRABAJADOR  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_CATEGORIA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESPECIALIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_INGRESO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.COD_PERSONAL  ,tgSQLFieldType.TEXT ),
            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspWCF_INS_PERSONAL", Parametros));
        }
        public int Mant_Insert_Trabajadores_WCF_DNI(BE_PERSONAL oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO_COSTO ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.NOMBRES ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_PATERNO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_MATERNO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DOCUMENTO_IDENTIFICACION  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.TIPO_TRABAJADOR  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_CATEGORIA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESPECIALIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_INGRESO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.COD_PERSONAL  ,tgSQLFieldType.TEXT ),

            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspWCF_INS_PERSONAL_DNI", Parametros));
        }
        public DataTable UpdateCategoria(int idPersona, int categoria, string centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_PERSONAL_CATEGORIA", idPersona, categoria, centro);
        }
        public DataTable uspREVISAR_EQUIPO_TRABAJO(int idPersona, int categoria, string centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspREVISAR_EQUIPO_TRABAJO", idPersona, categoria, centro);
        }
        public DataTable uspRITERAR_EQUIPO_TRABAJO(int idPersona, int categoria, string centro,string fecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspRITERAR_EQUIPO_TRABAJO", idPersona, categoria, centro, fecha);
        }
        public DataTable Get_Listar_Personal_x_Categoria(string Centro, int empresa, string grupo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_CATEGORIA_GRUPO", Centro, empresa , grupo);
        }
        public DataTable AsignarResponsable(string  idPersona, string ingeniero, int tipo, int empresa, string centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_PERSONAL_ENCARGADO", idPersona, ingeniero, tipo, empresa, centro);
        }
        public DataTable Update_EstadoPersonal( int empresa, string centro,string TipoPersona)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspWCF_UPD_PERSONAL_ESTADO", empresa, centro, TipoPersona);
        }
        public DataTable Get_UpdateEstadoPersonal(string centro, int idPersona, int empresa, int estado, string fecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_ESTADO_PERSONAL", centro, idPersona, empresa, estado, fecha);
        }
        public DataTable SP_OBTENER_PERSONAL(string Centro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL", Centro);
        }
        public DataTable uspUPD_PERSONAL_CATEGORIA_CAMBIO(int idPersona, int idPersonaNuevo, int categoria, string centro, string fecha, int idObrero, string fecha_nueva)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspUPD_PERSONAL_CATEGORIA_CAMBIO", idPersona, idPersonaNuevo,categoria, centro, fecha, idObrero, fecha_nueva);
        }
        public DataTable SP_OBTENER_PERSONAL_ASIGNADO(string CENTRO_COSTO, string IDE_CAPATAZ, string FECHA, string IDE_INGCAMPO, string IDE_CATEGORIA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_ASIGNADO", CENTRO_COSTO, IDE_CAPATAZ, FECHA, IDE_INGCAMPO, IDE_CATEGORIA);
        }
        public DataTable SP_OBTENER_EQUIPO_TRABAJO(string P_PROYECTO, string  FLG_ESTADO, string IDE_PERSONAL, int TIPO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_EQUIPO_TRABAJO", P_PROYECTO, FLG_ESTADO, IDE_PERSONAL, TIPO);
        }
        public DataTable uspINS_EQUIPO_TRABAJO(int IDE_EQUIPO, string CCENTRO, string IDE_INGCAMPO, string IDE_CAPATAZ, int FLG_ESTADO, string FECHA_INICIO,string  FECHA_FIN)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspINS_EQUIPO_TRABAJO", IDE_EQUIPO, CCENTRO, IDE_INGCAMPO, IDE_CAPATAZ, FLG_ESTADO, FECHA_INICIO , FECHA_FIN);
        }
        public DataTable uspDELETE_EQUIPO_TRABAJO(string CENTRO_COSTO, string IDE_CAPATAZ, string FECHA, string IDE_INGCAMPO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspDELETE_EQUIPO_TRABAJO", CENTRO_COSTO, IDE_CAPATAZ, FECHA, IDE_INGCAMPO);
        }
        public int uspWCF_INS_PERSONAL_EMPLEADO(BE_PERSONAL oBE)
        {
            object[] Parametros = new[] {
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CENTRO_COSTO ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.NOMBRES ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_PATERNO   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.APELLIDO_MATERNO  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DOCUMENTO_IDENTIFICACION  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.TIPO_TRABAJADOR  ,tgSQLFieldType.TEXT  ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_CATEGORIA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.ID_ESPECIALIDAD  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.IDE_EMPRESA  ,tgSQLFieldType.NUMERIC ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.FECHA_INGRESO  ,tgSQLFieldType.TEXT ),

                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CODIGO_SISPLAN  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.COD_AREA   ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DESCRIPCION_AREA  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.COD_SUCURSAL  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.DESCRIPCION_SUCURSAL  ,tgSQLFieldType.TEXT ),
                                        (object)UC_FormWeb.mSQLFieldOrNull(oBE.CARGO  ,tgSQLFieldType.TEXT ),
            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspWCF_INS_PERSONAL_EMPLEADO", Parametros));
        }
        public DataTable Get_ListarPersonalGestorDNI(Int32 IDE_EMPRESA, string CENTRO_COSTO, string DNI)
        {

          

            using (cn)
            {
                cn.Open();

                DataSet dataset = new DataSet();
                SqlCommand cmd = new SqlCommand("uspWCF_SELECT_TRABAJADOR_DNI", cn);
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IDE_EMPRESA", SqlDbType.VarChar, 10).Value = IDE_EMPRESA;
                    cmd.Parameters.Add("CENTRO_COSTO", SqlDbType.VarChar, 10).Value = CENTRO_COSTO;
                    cmd.Parameters.Add("DNI", SqlDbType.VarChar, 10).Value = DNI;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
        public DataTable Get_ListarPersonalGestorDNI_SKEX(Int32 IDE_EMPRESA, string CENTRO_COSTO, string DNI)
        {

            

            using (cn)
            {
                cn.Open();

                DataSet dataset = new DataSet();
                SqlCommand cmd = new SqlCommand("uspWCF_SELECT_TRABAJADOR_DNI_SKEX", cn);
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IDE_EMPRESA", SqlDbType.VarChar, 10).Value = IDE_EMPRESA;
                    cmd.Parameters.Add("CENTRO_COSTO", SqlDbType.VarChar, 10).Value = CENTRO_COSTO;
                    cmd.Parameters.Add("DNI", SqlDbType.VarChar, 10).Value = DNI;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
        public DataTable Get_ListarPersonalGestor(Int32 IDE_EMPRESA, string CENTRO_COSTO, string TIPO_PERSONA)
        {
            using (cn)
            {
                cn.Open();

                DataSet dataset = new DataSet();
                SqlCommand cmd = new SqlCommand("uspWCF_SELECT_TRABAJADOR", cn);
                try
                {
                    cmd.Transaction = null;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IDE_EMPRESA", SqlDbType.VarChar, 10).Value = IDE_EMPRESA;
                    cmd.Parameters.Add("CENTRO_COSTO", SqlDbType.VarChar, 10).Value = CENTRO_COSTO;
                    cmd.Parameters.Add("TIPO_PERSONA", SqlDbType.VarChar, 10).Value = TIPO_PERSONA;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }

        public DataTable SP_OBTENER_PERSONAL_x_DNI(string IDE_EMPRESA, string P_PROYECTO, string DNI)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_x_DNI", IDE_EMPRESA, P_PROYECTO, DNI);
        }
        public DataTable uspASIGNAR_NUEVO_RESPONSABLE(int idPersona, int idPersonaNuevo, string centro, string fecha, string fecha_nueva)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspASIGNAR_NUEVO_RESPONSABLE", idPersona, idPersonaNuevo, centro, fecha, fecha_nueva);
        }

        public DataTable USP_PERSONAL_FOTOCHECK(string CCENTRO, string TIPO_TRABAJADOR, string FLG_FOTOCHECK)
        {
            return oUtilitarios.EjecutaDatatable("USP_PERSONAL_FOTOCHECK", CCENTRO, TIPO_TRABAJADOR, FLG_FOTOCHECK);
        }
        public DataTable USP_ACTUALIZAR_FOTOS(string IDE_PERSONAL, string FOTO_RUTA, string FOTO, string FOTOCHECK)
        {
            return oUtilitarios.EjecutaDatatable("USP_ACTUALIZAR_FOTOS", IDE_PERSONAL, FOTO_RUTA, FOTO, FOTOCHECK);
        }
        public DataTable USP_PERSONAL_FOTOCHECK_ID(string IDE_PERSONAL)
        {
            return oUtilitarios.EjecutaDatatable("USP_PERSONAL_FOTOCHECK_ID", IDE_PERSONAL);
        }

    }
}
