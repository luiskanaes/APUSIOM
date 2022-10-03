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
    public class DA_CUADRILLA
    {
        Util oUtilitarios = new Util();

        public DataTable uspSEL_TAREO_FECHA(string IDE_EMPRESA, string CCENTRO, string FECHA_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("uspSEL_TAREO_FECHA", IDE_EMPRESA, CCENTRO, FECHA_TAREO);
        }

        public DataTable SP_LISTAR_CUADRILLA_OBRERO(int IDE_EMPRESA, string IDE_CECOS, string FEC_TAREO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_LISTAR_CUADRILLA_OBRERO", IDE_EMPRESA, IDE_CECOS, FEC_TAREO);
        }
        public DataTable SP_OBTENER_CUADRILLA_X_FECHA(string IDE_CECOS, int IDE_EMPRESA, string CAPATAZ, string FECHA, string IDE_ING, string DIA_NOMBRE)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_CUADRILLA_X_FECHA", IDE_CECOS, IDE_EMPRESA, CAPATAZ, FECHA, IDE_ING, DIA_NOMBRE);
        }
        public DataTable USP_CONSULTAR_CUADRILLA_X_FECHA(string IDE_CECOS, string CAPATAZ, string FECHA, string IDE_ING, string DIA_NOMBRE)
        {
            return oUtilitarios.EjecutaDatatable("dbo.USP_CONSULTAR_CUADRILLA_X_FECHA", IDE_CECOS, CAPATAZ, FECHA, IDE_ING, DIA_NOMBRE);
        }
        public DataTable SP_OBTENER_CUADRILLA_X_FECHA_WS(string IDE_CECOS, int IDE_EMPRESA,string IDE_INGCAMPO, string CAPATAZ, string FECHA, int verTotal)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_CUADRILLA_X_FECHA_WS", IDE_CECOS, IDE_EMPRESA, IDE_INGCAMPO, CAPATAZ, FECHA, verTotal);
        }
        public DataTable SP_OBTENER_CUADRILLA_X_FECHA_directo(string IDE_CECOS, int IDE_EMPRESA, string IDE_INGCAMPO, string CAPATAZ, string FECHA,string DIA, int verTotal)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_CUADRILLA_X_FECHA_directo", IDE_CECOS, IDE_EMPRESA, IDE_INGCAMPO, CAPATAZ, FECHA,DIA, verTotal);
        }

        public DataTable SP_OBTENER_PERSONAL_TAREADO_ID_WS(string IDE_CECOS, string FECHA, string IDE_PERSONAL)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_OBTENER_PERSONAL_TAREADO_ID_WS", IDE_CECOS, FECHA, IDE_PERSONAL);
        }
        public DataTable USP_OBTENER_PERSONAL_DNI_VARIOS(string IDE_CECOS , string IDE_PERSONAL)
        {
            return oUtilitarios.EjecutaDatatable("dbo.USP_OBTENER_PERSONAL_DNI_VARIOS", IDE_CECOS, IDE_PERSONAL);
        }
    }
}
