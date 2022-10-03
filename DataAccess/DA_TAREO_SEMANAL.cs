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
    public class DA_TAREO_SEMANAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();

        public DataTable SP_CONSULTAR_VERSION(string IDE_EMPRESA, string IDE_CECOS, string ANIO, string MES)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_VERSION", IDE_EMPRESA, IDE_CECOS, ANIO, MES);

        }
        public DataTable SP_CONSULTAR_VERSION_ANIO(string IDE_EMPRESA, string IDE_CECOS, string ANIO, string MES, string COD_TIPO_PLANILLA)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_VERSION_ANIO", IDE_EMPRESA, IDE_CECOS, ANIO, MES, COD_TIPO_PLANILLA);

        }

        public DataTable SP_CONSULTAR_TAREO_SEMANAL(string IDE_EMPRESA, string IDE_CECOS, string Version, string ANIO, string MES)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_TAREO_SEMANAL", IDE_EMPRESA,  IDE_CECOS, Version,  ANIO, MES);

        } 

        public DataTable SP_CONSULTAR_ESTADO_MIGRACION(string IDE_EMPRESA, string IDE_CECOS, string VERSION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_SEL_CAB_MIGRACION_TAREO", IDE_EMPRESA, IDE_CECOS, VERSION);

        }
        public DataTable SP_CONSULTAR_ESTADO_MIGRACION_REINTEGRO(string IDE_EMPRESA, string IDE_CECOS, string ANIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_SEL_CAB_MIGRACION_REINTEGRO_MOD", IDE_EMPRESA, IDE_CECOS, ANIO);

        }
        

        public DataTable SP_GENERAR_TAREO_SEMANAL(string IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, string Anio, string Mes)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_TAREO_SEMANAL", IDE_EMPRESA, IDE_CECOS, FEC_TAREO,Anio,Mes);

        }
        public DataTable SP_MIGRAR_REINTEGRO_MOD(string IDE_EMPRESA, string IDE_CECOS, string anio, string feC_ini, string feC_fin)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_MIGRAR_REINTEGRO_MOD", IDE_EMPRESA, IDE_CECOS, anio, feC_ini, feC_fin);

        }
        

        public DataTable SP_VALIDAR_CIERRE_TAREO(string IDE_EMPRESA, string IDE_CECOS, string NUM_VERSION, string Anio, string Mes)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VALIDAR_CIERRE_TAREO", IDE_EMPRESA, IDE_CECOS, NUM_VERSION, Anio, Mes);

        }

        public DataTable SP_VALIDAR_CIERRE_REINTEGRO_MOD(string IDE_EMPRESA, string IDE_CECOS, string Anio)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VALIDAR_CIERRE_REINTEGRO_MOD", IDE_EMPRESA, IDE_CECOS, Anio);

        }

        public DataTable SP_MIGRAR_TAREO_SEMANAL(string IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO, string Anio, string Mes)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_MIGRAR_TAREO_SEMANAL", IDE_EMPRESA, IDE_CECOS, FEC_TAREO, Anio, Mes);

        }

        public DataTable SP_VALIDAR_ELIMINAR_MIGRACION(string IDE_EMPRESA, string IDE_CECOS, string VERSION, string ANIO, string MES)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VALIDAR_ELIMINAR_MIGRACION", IDE_EMPRESA, IDE_CECOS, VERSION, ANIO, MES);

        }
        public DataTable SP_VALIDAR_ELIMINAR_MIGRACION_REINTEGRO(string IDE_EMPRESA, string IDE_CECOS, string ANIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VALIDAR_ELIMINAR_MIGRACION_REINTEGRO", IDE_EMPRESA, IDE_CECOS, ANIO);

        }

        public DataTable SP_ELIMINAR_MIGRACION(string IDE_EMPRESA, string IDE_CECOS, string VERSION, string ANIO, string MES)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ELIMINAR_MIGRACION", IDE_EMPRESA, IDE_CECOS, VERSION, ANIO, MES);

        }
        public DataTable SP_ELIMINAR_MIGRACION_REINTEGRO(string IDE_EMPRESA, string IDE_CECOS, string ANIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ELIMINAR_MIGRACION_REINTEGRO", IDE_EMPRESA, IDE_CECOS, ANIO);

        }
    }
}
