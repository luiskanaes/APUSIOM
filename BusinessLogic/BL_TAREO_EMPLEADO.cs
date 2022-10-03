using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using DataAccess;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using UserCode;
using System.Web;

namespace BusinessLogic
{
    public class BL_TAREO_EMPLEADO
    {

        public DataTable SP_CONSULTAR_EMPLEADOS(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_EMPLEADOS(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_EXPORTAR_TAREO_EMP(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_EXPORTAR_TAREO_EMP(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_IMPORTAR_EMPLEADOS(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_IMPORTAR_EMPLEADOS(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CERRAR_TAREO_EMP(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CERRAR_TAREO_EMP(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public DataTable SP_ACTUALIZAR_TB_EMP(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_ACTUALIZAR_TB_EMP(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_ACTUALIZAR_TB_EMP_DESCANSO_MEDICO(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_ACTUALIZAR_TB_EMP_DESCANSO_MEDICO(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_INS_DESCANSO_MEDICO(string IDE_EMPRESA, string dni, string ubi, DateTime fec_ini, DateTime fec_fin, string tip_desc, string tip_inc, string obs, string can_dias)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_INS_DESCANSO_MEDICO(IDE_EMPRESA, dni, ubi, fec_ini, fec_fin, tip_desc, tip_inc, obs, can_dias);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable SP_CONSULTAR_UBICACIONES(string id_usuario)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_UBICACIONES(id_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_UBICACIONES_DM(string id_usuario)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_UBICACIONES_DM(id_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_PERSONAL(string ubi)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_PERSONAL(ubi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_INSERT_NEW_PERSONAL(string mes, string anio, string ubi, string DNI)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_INSERT_NEW_PERSONAL(mes, anio, ubi, DNI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SP_CONSULTAR_NOMBRE(string dni)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_NOMBRE(dni);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_ACTUALIZAR_UBICACION(string dni, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_ACTUALIZAR_UBICACION(dni, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_VERIFICAR_ESTADO_TAREOEMP(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_VERIFICAR_ESTADO_TAREOEMP(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO_DNI(string IDE_EMPRESA,string dni, string ubi)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO_DNI(IDE_EMPRESA, dni,ubi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_CANT_DIAS_DESCANSO_MEDICO_DNI(string IDE_EMPRESA, string dni, string ubi)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_CANT_DIAS_DESCANSO_MEDICO_DNI(IDE_EMPRESA, dni, ubi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_LISTA_DESCANSO_MEDICO_DNI(string IDE_EMPRESA, string dni, string ubi)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_LISTA_DESCANSO_MEDICO_DNI(IDE_EMPRESA, dni, ubi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public DataTable SP_REPORTE_EMPLEADOS_DESCANSO_MEDICO(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_REPORTE_EMPLEADOS_DESCANSO_MEDICO(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CONSULTAR_UBICACIONES_TAREO_EMP(string id_usuario, string emp)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_UBICACIONES_TAREO_EMP(id_usuario, emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_DESMOVILIZACIONES_UBICACION(string MES, string anio, string UBICACION, string empresa)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_DESMOVILIZACIONES_UBICACION(MES, anio, UBICACION, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GRABAR_EMP_HISTORICO_MOVI(string mes, string anio, string ubi, string emp, string fin, string inicio, string empresa)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_GRABAR_EMP_HISTORICO_MOVI(mes, anio, ubi, emp, fin, inicio, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CORREO_MOVIMIENTO_UBICACION_PERSONAL(string nombres, string ubicacion, string dni, string mes, string empresa, string des_ubi)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CORREO_MOVIMIENTO_UBICACION_PERSONAL(nombres, ubicacion, dni, mes, empresa, des_ubi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_CONSULTAR_EMP_DESMOVILIZADOS(string mes, string anio, string ubi)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_EMP_DESMOVILIZADOS(mes, anio, ubi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_VERIFICAR_ULT_DESMOVILIZACION(string mes, string anio, string ubi, string emp, string fin, string inicio, string empresa)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_VERIFICAR_ULT_DESMOVILIZACION(mes, anio, ubi, emp, fin, inicio, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_VERIFICAR_RANGO_FECHAS(string mes, string anio, string ubi, string emp, string fin, string inicio, string empresa)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_VERIFICAR_RANGO_FECHAS(mes, anio, ubi, emp, fin, inicio, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_CERRAR_PERIODO_EMPLEADOS(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CERRAR_PERIODO_EMPLEADOS(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_REPORTE_EMPLEADOS(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_REPORTE_EMPLEADOS(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_REPORTE_EMPLEADOS_DETALLE(string IDE_EMPRESA, string MES, string anio, string UBICACION)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_REPORTE_EMPLEADOS_DETALLE(IDE_EMPRESA, MES, anio, UBICACION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_DESMOVILIZACIONES_UBICACION_TODAS(string MES, string anio, string UBICACION, string empresa)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_DESMOVILIZACIONES_UBICACION_TODAS(MES, anio, UBICACION, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public DataTable SP_CONSULTAR_JUNTA(string junta)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_CONSULTAR_JUNTA(junta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_GRABAR_JUNTA(string junta, string juntan, string area, string serv, string line, string train)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_GRABAR_JUNTA(junta, juntan, area, serv, line, train);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SP_GRABAR_JUNTA_NUEVA(string junta, string juntan, string area, string serv, string line, string train, string matc, string joint)
        {
            try
            {
                return new DA_TAREO_EMPLEADO().SP_GRABAR_JUNTA_NUEVA(junta, juntan, area, serv, line, train, matc, joint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
