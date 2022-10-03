using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using BusinessEntity;
using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class BL_TBUSUARIO
    {
        public DataTable f_LogeoUsuario_B(BE_TBUSUARIO obj_user_E)
        {
            try
            {
                return new DA_TBUSUARIO().f_LogeoUsuario_D(obj_user_E);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_UPDATE_CONTRASENIA(string DES_PASSWORD, string IDE_USUARIO)
        {
            try
            {
                return new DA_TBUSUARIO().SP_UPDATE_CONTRASENIA(DES_PASSWORD, IDE_USUARIO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
