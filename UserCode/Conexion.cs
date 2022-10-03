using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace UserCode
{
    public class Conexion
    {
        

        public bool ProbarConexion(ref string as_error)
        {


            SqlConnection lsql_conexion = new SqlConnection();
            lsql_conexion.ConnectionString = ConfigurationManager
                    .ConnectionStrings["Conexion"].ConnectionString;

            try
            {
                as_error = lsql_conexion.DataSource + " - " + lsql_conexion.Database;
                lsql_conexion.Open();
                return true;
            }
            catch (SqlException e)
            {
                as_error = "No se pudo establecer la conexión a la base de datos. Error: " + e.Message.ToString();

                lsql_conexion.Close();
                return false;
            }
            finally
            {
                if (lsql_conexion != null)
                {
                    lsql_conexion.Close();
                }
            }
        }
    }
}
