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
using System.Configuration;

namespace DataAccess
{
    public class DA_DISCIPLINAS
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        Util oUtilitarios = new Util();
        public DataTable SEL_DISCIPLINAS_POR_DISCIPLINA(int IDE_DISCIPLINA, string CENTRO_COSTO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_DISCIPLINAS_POR_DISCIPLINA", IDE_DISCIPLINA, CENTRO_COSTO);
        }
        public DataTable SEL_DISCIPLINAS_ESTRUCTURA(int IDE_DISCIPLINA, string CENTRO_COSTO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_DISCIPLINAS_ESTRUCTURA", IDE_DISCIPLINA, CENTRO_COSTO);
        }
        public DataTable uspSEL_DISCIPLINAS_POR_CENTRO_COSTO(string CENTRO_COSTO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_DISCIPLINAS_POR_CENTRO_COSTO", CENTRO_COSTO);
        }
        public DataTable uspSEL_TIPO_TAREO_POR_CENTRO_COSTO(string CENTRO_COSTO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.uspSEL_TIPO_TAREO_POR_CENTRO_COSTO", CENTRO_COSTO);
        }
    }
}
