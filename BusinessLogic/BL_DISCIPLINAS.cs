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
    public class BL_DISCIPLINAS
    {
        public DataTable SEL_DISCIPLINAS_POR_DISCIPLINA(int IDE_DISCIPLINA, string CENTRO_COSTO)
        {
            try
            {
                return new DA_DISCIPLINAS().SEL_DISCIPLINAS_POR_DISCIPLINA(IDE_DISCIPLINA,  CENTRO_COSTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_DISCIPLINAS_ESTRUCTURA(int IDE_DISCIPLINA, string CENTRO_COSTO)
        {
            try
            {
                return new DA_DISCIPLINAS().SEL_DISCIPLINAS_ESTRUCTURA(IDE_DISCIPLINA,  CENTRO_COSTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SEL_DISCIPLINAS_POR_CENTRO_COSTO(string  CENTRO_COSTO)
        {
            try
            {
                return new DA_DISCIPLINAS().uspSEL_DISCIPLINAS_POR_CENTRO_COSTO(CENTRO_COSTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspSEL_TIPO_TAREO_POR_CENTRO_COSTO(string CENTRO_COSTO)
        {
            try
            {
                return new DA_DISCIPLINAS().uspSEL_TIPO_TAREO_POR_CENTRO_COSTO(CENTRO_COSTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
