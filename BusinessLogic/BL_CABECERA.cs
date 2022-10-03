using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BusinessEntity;
using DataAccess;
using System.Data;
namespace BusinessLogic
{
    public class BL_CABECERA
    {
        public int Mant_Insert_ActividadPlaner(BE_CABECERA oBE)
        {
            try
            {
                return new DA_CABECERA().Mant_Insert_ActividadPlaner(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarProgramacion(string  centro, int empresa)
        {
            try
            {
                return new DA_CABECERA().ListarProgramacion(centro, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarProgramacion_Disciplina(string centro, int empresa, int disciplina)
        {
            try
            {
                return new DA_CABECERA().ListarProgramacion_Disciplina(centro, empresa, disciplina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
