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
    public class DA_TAREO_EMPLEADO
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();

        public DataTable SP_CONSULTAR_EMPLEADOS(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_EMPLEADOS", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_EXPORTAR_TAREO_EMP(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_EXPORTAR_TAREO_EMP", IDE_EMPRESA, MES, anio, UBICACION);

        }


        public DataTable SP_IMPORTAR_EMPLEADOS(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_IMPORTAR_EMPLEADOS", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_CERRAR_TAREO_EMP(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CERRAR_TAREO_EMP", IDE_EMPRESA, MES, anio, UBICACION);

        }


        public DataTable SP_ACTUALIZAR_TB_EMP(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ACTUALIZAR_TB_EMP", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_ACTUALIZAR_TB_EMP_DESCANSO_MEDICO(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ACTUALIZAR_TB_EMP_DESCANSO_MEDICO", IDE_EMPRESA, MES, anio, UBICACION);

        }
        public DataTable SP_INS_DESCANSO_MEDICO(string IDE_EMPRESA,string dni, string ubi, DateTime fec_ini, DateTime fec_fin, string tip_desc, string tip_inc, string obs, string can_dias)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INS_DESCANSO_MEDICO", IDE_EMPRESA, dni, ubi, fec_ini, fec_fin, tip_desc, tip_inc, obs, can_dias);

        }        

        public DataTable SP_CONSULTAR_UBICACIONES(string ID_USUARIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_UBICACIONES", ID_USUARIO);

        }

        public DataTable SP_CONSULTAR_UBICACIONES_DM(string ID_USUARIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_UBICACIONES_DM", ID_USUARIO);

        }

        public DataTable SP_CONSULTAR_PERSONAL(string ubi)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_PERSONAL", ubi);

        }
        public DataTable SP_INSERT_NEW_PERSONAL(string mes, string anio, string ubi, string DNI)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INSERT_NEW_PERSONAL", mes,anio,ubi,DNI);

        }

        public DataTable SP_CONSULTAR_NOMBRE(string dni)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_NOMBRE", dni);

        }

        public DataTable SP_VERIFICAR_ESTADO_TAREOEMP(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VERIFICAR_ESTADO_TAREOEMP", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_ACTUALIZAR_UBICACION(string dni, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ACTUALIZAR_UBICACION", dni, MES, anio, UBICACION);

        }

        public DataTable SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO_DNI(string IDE_EMPRESA, string dni,string ubi)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO_DNI", IDE_EMPRESA, dni,ubi);

        }
        public DataTable SP_CONSULTAR_CANT_DIAS_DESCANSO_MEDICO_DNI(string IDE_EMPRESA, string dni, string ubi)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_CANT_DIAS_DESCANSO_MEDICO_DNI", IDE_EMPRESA, dni, ubi);

        }
        public DataTable SP_CONSULTAR_LISTA_DESCANSO_MEDICO_DNI(string IDE_EMPRESA, string dni, string ubi)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_LISTA_DESCANSO_MEDICO_DNI", IDE_EMPRESA, dni, ubi);

        }
        
        public DataTable SP_REPORTE_EMPLEADOS_DESCANSO_MEDICO(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_EMPLEADOS_DESCANSO_MEDICO", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_CONSULTAR_UBICACIONES_TAREO_EMP(string ID_USUARIO, string emp)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_UBICACIONES_TAREO_EMP", ID_USUARIO, emp);

        }

        public DataTable SP_DESMOVILIZACIONES_UBICACION(string MES, string anio, string UBICACION, string empresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_DESMOVILIZACIONES_UBICACION", MES, anio, UBICACION, empresa);

        }

        public DataTable SP_GRABAR_EMP_HISTORICO_MOVI(string mes, string anio, string ubi, string emp, string fin, string inicio, string empresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_EMP_HISTORICO_MOVI", mes, anio, ubi, emp, fin, inicio, empresa);

        }
        public DataTable SP_CORREO_MOVIMIENTO_UBICACION_PERSONAL(string nombre, string ubicacion, string dni, string mes, string empresa, string des_ubi)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CORREO_MOVIMIENTO_UBICACION_PERSONAL", nombre, ubicacion, dni, mes, empresa, des_ubi);

        }
        public DataTable SP_CONSULTAR_EMP_DESMOVILIZADOS(string mes, string anio, string ubi)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_EMP_DESMOVILIZADOS", mes, anio, ubi);

        }
        public DataTable SP_VERIFICAR_ULT_DESMOVILIZACION(string mes, string anio, string ubi, string emp, string fin, string inicio, string empresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VERIFICAR_ULT_DESMOVILIZACION", mes, anio, ubi, emp, fin, inicio, empresa);

        }

        public DataTable SP_VERIFICAR_RANGO_FECHAS(string mes, string anio, string ubi, string emp, string fin, string inicio, string empresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VERIFICAR_RANGO_FECHAS", mes, anio, ubi, emp, fin, inicio, empresa);

        }

        public DataTable SP_CERRAR_PERIODO_EMPLEADOS(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CERRAR_TAREO_EMP", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_REPORTE_EMPLEADOS(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_EMPLEADOS", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_REPORTE_EMPLEADOS_DETALLE(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_EMPLEADOS_DETALLE", IDE_EMPRESA, MES, anio, UBICACION);

        }

        public DataTable SP_DESMOVILIZACIONES_UBICACION_TODAS(string MES, string anio, string UBICACION, string empresa)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_DESMOVILIZACIONES_UBICACION_TODAS", MES, anio, UBICACION, empresa);

        }



        public DataTable SP_CONSULTAR_JUNTA(string junta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_JUNTA", junta);

        }
        public DataTable SP_GRABAR_JUNTA(string junta, string juntan, string area, string serv, string line, string train)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_JUNTA", junta, juntan, area, serv, line, train);

        }
        public DataTable SP_GRABAR_JUNTA_NUEVA(string junta, string juntan, string area, string serv, string line, string train, string matc, string joint)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_JUNTA_NUEVA", junta, juntan, area, serv, line, train, matc, joint);

        }

    }
}
