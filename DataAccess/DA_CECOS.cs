using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using BusinessEntity;
using UserCode;
using System.Data.SqlClient;
using DataAccess.Conexion;
using System.Configuration;

namespace DataAccess
{
    public  class DA_CECOS
    {
        //CONEXION BASE DE DATOS CGO
        UtilCGO oUtilitarios = new UtilCGO();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitariosTareo = new Util();
        public DataTable SEL_CECOS_POR_CATEGORIA_EMPRESA(string categoria, string ip)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CECOS_POR_CATEGORIA_EMPRESA", categoria,  ip);
        }
        public DataTable uspDELETE_LOG_SOLPED_USER_REGISTRO( string ip)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspDELETE_LOG_SOLPED_USER_REGISTRO",  ip);
        }
        public DataTable uspCONSULTAR_LOG_SOLPED_USER(string ip)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspCONSULTAR_LOG_SOLPED_USER", ip);
        }
        public DataTable SEL_CECOS_CENTRO_LOGISTICO(string sociedad,string imputacion)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_CECOS_CENTRO_LOGISTICO", sociedad, imputacion);
        }
        public DataTable SEL_GRUPO_COMPRAS( string obra)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_GRUPO_COMPRAS", obra);
        }
        public DataTable uspSEL_CECOS_RRHH( int empresa)
        {
            return oUtilitariosTareo.EjecutaDatatable("dbo.uspSEL_CECOS", empresa);
        }
        public DataTable USP_EMPRESAS()
        {
            return oUtilitariosTareo.EjecutaDatatable("dbo.USP_EMPRESAS");
        }

        public int uspINS_CECOS(BE_CECOS oBESOl)
        {
            object[] Parametros = new[] {
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.ID ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.COD_PROYECTO ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.DESCRIPCION ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.NOMBRE_CORTO ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.IDE_EMPRESA ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.FLG_ESTADO ,tgSQLFieldType.NUMERIC),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.FLG_CORREO ,tgSQLFieldType.NUMERIC),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.CLIENTE ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.UBICACION ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.T_STANDAR ,tgSQLFieldType.NUMERIC),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.T_PERSONZALIZADO ,tgSQLFieldType.NUMERIC),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.COD_PLANILLA ,tgSQLFieldType.TEXT),


            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_CECOS", Parametros));
        }
        public DataTable uspSEL_CECOS_POR_ID(string ID)
        {
            return oUtilitariosTareo.EjecutaDatatable("uspSEL_CECOS_POR_ID", ID);
        }
        public int uspINS_JORNADAS(BE_JORNADAS oBESOl)
        {
            object[] Parametros = new[] {
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.IDE_HORARIOS ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.DES_DIA ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.NRO_DIA ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.HORAS_TRABAJO ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.CCOSTO ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.IDE_EMPRESA ,tgSQLFieldType.TEXT),
                    (object)UC_FormWeb.mSQLFieldOrNull(oBESOl.FLG_100 ,tgSQLFieldType.BOOLEAN),

            };

            return Convert.ToInt32(new Util().ExecuteScalar("uspINS_JORNADAS", Parametros));
        }
        public DataTable uspSEL_JORNADAS_POR_CC(string CCOSTO)
        {
            return oUtilitariosTareo.EjecutaDatatable("uspSEL_JORNADAS_POR_CC", CCOSTO);
        }

    }
}
