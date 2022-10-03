using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Tareo : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridView1.DataSource = GetData();
                GridView1.DataBind();
            }
        }
        private DataTable GetData()
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("sp_listar_gestion_cambio", con);
            cmd.CommandType = CommandType.StoredProcedure;
   
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
    }
}