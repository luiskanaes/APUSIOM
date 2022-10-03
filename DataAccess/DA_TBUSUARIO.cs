using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using BusinessEntity;
using UserCode;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Conexion;

namespace DataAccess
{
    public class DA_TBUSUARIO
    {
        Util oUtilitarios = new Util();

        public DataTable f_LogeoUsuario_D(BE_TBUSUARIO obj_user_E)
        {
            return oUtilitarios.EjecutaDatatable("dbo.USP_USUARIO_LOGIN", obj_user_E.IDE_USUARIO, obj_user_E.DES_PASSWORD);
        }
        public DataTable SP_UPDATE_CONTRASENIA(string DES_PASSWORD, string IDE_USUARIO)
        {
            return oUtilitarios.EjecutaDatatable("dbo.SP_UPDATE_CONTRASENIA", DES_PASSWORD, IDE_USUARIO);
        }
    }
}
