using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessEntity;
namespace BusinessLogic
{
    public class BL_CECOS
    {
        public DataTable SEL_CECOS_POR_CATEGORIA_EMPRESA(string  categoria, string ip)
        {
            try
            {
                return new DA_CECOS().SEL_CECOS_POR_CATEGORIA_EMPRESA(categoria , ip);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspDELETE_LOG_SOLPED_USER_REGISTRO( string ip)
        {
            try
            {
                return new DA_CECOS().uspDELETE_LOG_SOLPED_USER_REGISTRO( ip);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspCONSULTAR_LOG_SOLPED_USER(string ip)
        {
            try
            {
                return new DA_CECOS().uspCONSULTAR_LOG_SOLPED_USER(ip);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_CECOS_CENTRO_LOGISTICO( string sociedad, string imputacion )
        {
            try
            {
                return new DA_CECOS().SEL_CECOS_CENTRO_LOGISTICO(sociedad, imputacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_GRUPO_COMPRAS(string obra)
        {
            try
            {
                return new DA_CECOS().SEL_GRUPO_COMPRAS(obra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspSEL_CECOS_RRHH( int empresa)
        {
            try
            {
                return new DA_CECOS().uspSEL_CECOS_RRHH(empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable USP_EMPRESAS()
        {
            try
            {
                return new DA_CECOS().USP_EMPRESAS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int uspINS_CECOS(BE_CECOS oBE)
        {
            try
            {
                return new DA_CECOS().uspINS_CECOS(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspSEL_CECOS_POR_ID(string ID)
        {
            return new DA_CECOS().uspSEL_CECOS_POR_ID(ID);
        }
        public int uspINS_JORNADAS(BE_JORNADAS oBE)
        {
            try
            {
                return new DA_CECOS().uspINS_JORNADAS(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspSEL_JORNADAS_POR_CC(string CCOSTO)
        {
            return new DA_CECOS().uspSEL_JORNADAS_POR_CC(CCOSTO);
        }

    }
}
