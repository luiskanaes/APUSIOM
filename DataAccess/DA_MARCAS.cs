using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Conexion;


namespace DataAccess
{
    public class DA_MARCAS
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();

        public DataTable SP_CONSULTAR_DATOS(string ceco, string unit, string line, string train, string servicio, string finicio, string ffin, string indfecha, string iv, string filtro, string txtfiltro, string indValidos, string indValidosProgramar)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS", ceco, unit, line, train, servicio, finicio, ffin, indfecha, iv, filtro, txtfiltro, indValidos, indValidosProgramar);
        }
        public DataTable SP_CONSULTAR_DATOS_COTIZACION(string codigoSiom, string grupo, string descripcion, string unidadMedida)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_COTIZACION", codigoSiom, grupo, descripcion, unidadMedida);
        }
        public DataTable SP_CONSULTAR_DATOS_INGENIERIA(string codigoSiom, string grupo, string descripcion, string unidadMedida)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_INGENIERIA", codigoSiom, grupo, descripcion, unidadMedida);
        }

        public DataTable SP_CONSULTAR_COLUMNAS_ANTES(string col_1, string col_x)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_ANTES", col_1, col_x);
        }
        public DataTable SP_CONSULTAR_COLUMNAS_ANTES_SPOOL(string col_1, string col_x)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_ANTES_SPOOL", col_1, col_x);
        }

        public DataTable SP_CONSULTAR_REPORTE_BASE_ENSAYOS_PENDIENTES(string ceco, string cboFiltro, string txtFiltro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REPORTE_BASE_ENSAYOS_PENDIENTES", ceco, cboFiltro, txtFiltro);
        }
        public DataTable SP_CONSULTAR_REPORTES(string nombrereporte)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REPORTES", nombrereporte);
        }

        public DataTable SP_CONSULTAR_REPORTES_CS(string nombrereporte)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REPORTES_CS", nombrereporte);
        }
        public DataTable SP_CONSULTAR_REPORTES_SPOOL(string nombrereporte)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REPORTES_SPOOL", nombrereporte);
        }

        public DataTable SP_CONSULTAR_DATOS_SPOOL(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_SPOOL", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }
        public DataTable SP_CONSULTAR_DATOS_ALMACEN(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_ALMACEN", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }
        public DataTable SP_CONSULTAR_DATOS_SERIVICIO_PINTURA(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_SERIVICIO_PINTURA", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }
        public DataTable SP_CONSULTAR_DATOS_SERVICIO_TRACEADO(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_SERVICIO_TRACEADO", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }

        public DataTable SP_CONSULTAR_DATOS_SERVICIO_AISLAMIENTO(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_SERVICIO_AISLAMIENTO", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }

        public DataTable SP_CONSULTAR_DATOS_AVANCE(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string familia)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_AVANCE", ceco, unit, line, train, servicio, filtro, txtfiltro, familia);
        }

        public DataTable SP_CONSULTAR_DATOS_ENSAYOS_PENDIENTES(string ceco, string unit, string line, string train, string servicio, string conIv, string conRtrat, string tipEnsayo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_ENSAYOS_PENDIENTES", ceco, unit, line, train, servicio, conIv, conRtrat, tipEnsayo);
        }

        public DataTable SP_CONSULTAR_DATOS_REGISTRO_JUNTAS(string mina, string llave, string material, string plano, string producto)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_REGISTRO_JUNTAS", mina, llave, material, plano, producto);
        }
        public DataTable SP_CONSULTAR_DATOS_REGISTRO_ENSAYOS(string ceco, string unit, string line, string train, string servicio, string filtro, string txtfiltro, string tipo_ensayo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_REGISTRO_ENSAYOS", ceco, unit, line, train, servicio, filtro, txtfiltro, tipo_ensayo);
        }

        public DataTable SP_CONSULTAR_DATOS_NUEVO_REGISTRO_JUNTAS(string ceco, string unit, string line, string train, string servicio, string nrojunta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_NUEVO_REGISTRO_JUNTAS", ceco, unit, line, train, servicio, nrojunta);
        }
        public DataTable SP_GENERAR_DATOS_NUEVO_REGISTRO_JUNTAS(string ceco, string unit, string line, string train, string servicio, string nrojunta, string nuevajunta, string tipoJunta, string ubicacion)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_DATOS_NUEVO_REGISTRO_JUNTAS", ceco, unit, line, train, servicio, nrojunta, nuevajunta, tipoJunta, ubicacion);
        }
        public DataTable SP_GRABAR_DATOS_NUEVO_JUNTA(string ceco, string unit, string line, string train, string servicio, string nrojunta, string nuevajunta, string tipoJunta, string ubicacion, string diametro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_DATOS_NUEVO_JUNTA", ceco, unit, line, train, servicio, nrojunta, nuevajunta, tipoJunta, ubicacion, diametro);
        }
        public DataTable SP_VERIFICAR_DATOS_NUEVO_JUNTA(string ceco, string unit, string line, string train, string servicio, string nrojunta, string nuevajunta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VERIFICAR_DATOS_NUEVO_JUNTA", ceco, unit, line, train, servicio, nrojunta, nuevajunta);
        }

        public DataTable SP_CONSULTAR_COLUMNAS_EDITABLES(string ceco, string USUARIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_EDITABLES", ceco, USUARIO);

        }
        public DataTable SP_CONSULTAR_COLUMNAS_VISIBLES(string ceco, string USUARIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_VISIBLES", ceco, USUARIO);
        }

        public DataTable SP_GUARDAR_DATOS(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS", ceco, id);
        }

        public DataTable SP_GUARDAR_COLUMNAS(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_COLUMNAS", col, id);
        }

        public DataTable SP_GUARDAR_COLUMNAS_SPOOL(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_COLUMNAS_SPOOL", col, id);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_ALMACEN(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_ALMACEN", col, id);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_PINTURA(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_SERVICIO_PINTURA", col, id);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_TRACEADO(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_SERVICIO_TRACEADO", col, id);
        }


        public DataTable SP_GUARDAR_DATOS_REGISTRO_SERVICIO_AISLAMIENTO(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_SERVICIO_AISLAMIENTO", col, id);
        }

        public DataTable SP_GUARDAR_DATOS_REGISTRO_AVANCE(string col, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_AVANCE", col, id);
        }

        public DataTable SP_GUARDAR_DATOS_PAQUETES_PRUEBA(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_PAQUETES_PRUEBA", ceco, id);
        }

        public DataTable SP_GUARDAR_DATOS_REGISTRO_JUNTAS(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_JUNTAS", ceco, id);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_ENSAYOS(string ceco, string id, string tipo_ensayo, string col_e)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_ENSAYOS_v2", ceco, id, tipo_ensayo, col_e);
        }
        public DataTable SP_GUARDAR_DATOS_REGISTRO_ENSAYOS_PENDIENTES(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_ENSAYOS_PENDIENTES", ceco, id);
        }

        public DataTable SP_GUARDAR_DATOS_REGISTRO_SPOOLS(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REGISTRO_SPOOLS", ceco, id);
        }


        public DataTable SP_GUARDAR_DATOS_IV(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_IV", ceco, id);
        }
        public DataTable SP_GUARDAR_DATOS_REPORTE_SOLDADURAS(string ceco, string id)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GUARDAR_DATOS_REPORTE_SOLDADURAS", ceco, id);
        }

        public DataTable SP_REPORTE_SOLDADURAS(string unit, string service, string line, string train, string dtpInicio, string dtpFin, string dtpInicioIV, string dtpFinIV, string dtpInicioReporte, string dtpFinReporte, string chkSinFechaSoldadura, string chkSinFechaIV, string chkSinFechaReporte)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_SOLDADURAS", unit, service, line, train, dtpInicio, dtpFin, dtpInicioIV, dtpFinIV, dtpInicioReporte, dtpFinReporte, chkSinFechaSoldadura, chkSinFechaIV, chkSinFechaReporte);
        }

        public DataTable SP_REPORTE_IV(string unit, string line, string train, string dtpInicio, string dtpFin, string servicio, string pendientes, string sfecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_IV", unit, line, train, dtpInicio, dtpFin, servicio, pendientes, sfecha);
        }

        public DataTable SP_REPORTE_IV_EXPORTAR(string unit, string line, string train, string dtpInicio, string dtpFin, string servicio, string pendientes, string sfecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_IV_EXPORTAR", unit, line, train, dtpInicio, dtpFin, servicio, pendientes, sfecha);
        }

        public DataTable SP_REPORTE_PIP35(string unidad, string tipojunta, string tipoensayo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_REPORTE_PIP35", unidad, tipojunta, tipoensayo);
        }

        public DataTable SP_CONSULTAR_FILTROS(string unidad)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_FILTROS", unidad);
        }

        public DataTable SP_CONSULTAR_CODIGO_SIOM(string codigo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_CODIGO_SIOM", codigo);
        }


        public DataTable SP_CONSULTAR_MONTO_TOTAL_POR_CODIGO_SIOM(string codigo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_MONTO_TOTAL_POR_CODIGO_SIOM", codigo);
        }
        public DataTable SP_CONSULTAR_REV_POR_CODIGO_SIOM(string codigo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_REV_POR_CODIGO_SIOM", codigo);
        }
        public DataTable SP_CONSULTAR_PARA_CARGAR(string codigo, string RevisionPlano, string PrecioFinal, string FactorFinal, string Cantidad, string RealizadoPor, string fecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_PARA_CARGAR", codigo, RevisionPlano, PrecioFinal, FactorFinal, Cantidad, RealizadoPor, fecha);
        }
        public DataTable SP_INSERTAR_COTIZACION(string codigo_siom, string precio, string factor, string cantidad, string cliente, string cod_cotizacion, string realizadopor, string fechacoti)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INSERTAR_COTIZACION", codigo_siom, precio, factor, cantidad, cliente, cod_cotizacion, realizadopor, fechacoti);
        }
        public DataTable SP_INSERTAR_NUEVO_METRADO(String COL_2, String COL_3, String COL_4, String COL_5, String COL_6, String COL_7, String COL_8, String COL_9, String COL_10, String COL_11, String COL_12, String COL_13, String COL_14, String COL_15, String COL_16, String COL_17, String COL_18, String COL_19, String COL_20, String COL_21, String COL_22, String COL_23)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_INSERTAR_NUEVO_METRADO", COL_2, COL_3, COL_4, COL_5, COL_6, COL_7, COL_8, COL_9, COL_10, COL_11, COL_12, COL_13, COL_14, COL_15, COL_16, COL_17, COL_18, COL_19, COL_20, COL_21, COL_22, COL_23);
        }

        public DataTable SP_CONSULTAR_OC_CODIGO_SIOM(string codigo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_OC_CODIGO_SIOM", codigo);
        }
        public DataTable SP_CONSULTAR_COTIZACIONES_CODIGO_SIOM(string codigo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COTIZACIONES_CODIGO_SIOM", codigo);
        }
        public DataTable SP_CONSULTAR_FACTOR_POR_CODIGO_SIOM(string codigo)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_FACTOR_POR_CODIGO_SIOM", codigo);
        }

        public DataTable SP_CONSULTAR_FILTROS_SPOOL(string unidad)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_FILTROS_SPOOL", unidad);
        }


        public DataTable SP_CONSULTAR_PAQUETES_PRUEBA(string ceco, string unit, string line, string train, string servicio, string paquete, string filtro, string txtfiltro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_PAQUETES_PRUEBA", ceco, unit, line, train, servicio, paquete, filtro, txtfiltro);
        }


        public DataTable SP_CONSULTAR_PAQUETES_PRUEBA_FORMATO_TR(string ceco, string unit, string line, string train, string servicio, string paquete, string filtro, string txtfiltro)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_PAQUETES_PRUEBA_FORMATO_TR", ceco, unit, line, train, servicio, paquete, filtro, txtfiltro);
        }

        public DataTable SP_CONSULTAR_DOCUMENTOS_JUNTA(string junta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DOCUMENTOS_JUNTA", junta);
        }

        public DataTable SP_CONSULTAR_COLUMNAS_PIP35()
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_PIP35");
        }
        public DataTable SP_CONSULTAR_COLUMNAS_SPOOLS()
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_COLUMNAS_SPOOLS");
        }
        public DataTable SP_GRABAR_NUEVO_ISOMETRICO(string junta, string unidad, string servicio, string line, string train)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_NUEVO_ISOMETRICO", junta, unidad, servicio, line, train);
        }
        public DataTable SP_CONSULTAR_DATOS_NUEVO_REGISTRO_SPOOLS(string ceco, string unit, string line, string train, string servicio, string nrojunta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_DATOS_NUEVO_REGISTRO_SPOOLS", ceco, unit, line, train, servicio, nrojunta);
        }

        public DataTable SP_VERIFICAR_DATOS_NUEVO_SPOOL(string ceco, string unit, string line, string train, string servicio, string nuevajunta)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_VERIFICAR_DATOS_NUEVO_SPOOL", ceco, unit, line, train, servicio, nuevajunta);
        }

        public DataTable SP_GENERAR_DATOS_NUEVO_REGISTRO_SPOOL(string ceco, string unit, string line, string train, string servicio, string nuevajunta, string tipoJunta, string ubicacion)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GENERAR_DATOS_NUEVO_REGISTRO_SPOOL", ceco, unit, line, train, servicio, nuevajunta, tipoJunta, ubicacion);
        }

        public DataTable SP_GRABAR_DATOS_NUEVO_SPOOL(string ceco, string unit, string line, string train, string servicio, string nuevajunta, string tipoJunta, string ubicacion)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_GRABAR_DATOS_NUEVO_SPOOL", ceco, unit, line, train, servicio, nuevajunta, tipoJunta, ubicacion);
        }
        public DataTable SP_CONSULTAR_TESTPACK(string ceco, string unit, string servicio, string line, string train, string tp)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_CONSULTAR_TESTPACK", ceco, unit, servicio, line, train, tp);
        }
        public DataTable SP_ACTUALIZAR_TESTPACK(string ceco, string unit, string servicio, string line, string train, string tp, string estado, string fecha)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_ACTUALIZAR_TESTPACK", ceco, unit, servicio, line, train, tp, estado, fecha);
        }


    }
}
