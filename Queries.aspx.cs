using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Acme
{
    public partial class Queries : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR! " + ex.ToString();
            }
        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCustomer"].ConnectionString);
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = txtSQL.Text;
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                gvResult.DataSource = reader;
                gvResult.DataBind();

                reader.Dispose();
                command.Dispose();
                conn.Dispose();
            }
            catch(Exception ex)
            {
                lblMessage.Text = "ERROR! " + ex.ToString();
            }
        }

        private void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie setTheme = Request.Cookies.Get("UserSelectedTheme");
            if (setTheme != null)
            {
                Page.Theme = setTheme.Value;
            }
        }
    }
}