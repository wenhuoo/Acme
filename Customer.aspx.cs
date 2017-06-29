using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Acme
{
    public partial class Customer : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();

        public void Clear()
        {
            txtCustID.Text = "";
            txtFName.Text = "";
            txtSName.Text = "";
            txtAge.Text = "";
            txtCity.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtConEmail.Text = "";
            rdlGender.ClearSelection();
            lblMessage.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCustomer"].ConnectionString);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR! " + ex.ToString();
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();

                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetMaxID";
                command.Connection.Open();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                int maxID = 0;
                DataRow dr = table.Rows[0];
                if (dr.IsNull(0))
                {
                    maxID = 1;
                } else {
                    maxID = table.Rows[0].Field<int>("CustID") + 1;
                }
                txtCustID.Text = maxID.ToString();
                 
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR! " + ex.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddNew";
                command.Connection.Open();

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@CustID";
                paramID.SqlDbType = SqlDbType.Int;
                paramID.Direction = ParameterDirection.Input;
                paramID.Value = txtCustID.Text;
                command.Parameters.Add(paramID);

                SqlParameter paramFN = new SqlParameter();
                paramFN.ParameterName = "@Firstname";
                paramFN.SqlDbType = SqlDbType.VarChar;
                paramFN.Direction = ParameterDirection.Input;
                paramFN.Value = txtFName.Text;
                command.Parameters.Add(paramFN);

                SqlParameter paramSN = new SqlParameter();
                paramSN.ParameterName = "@Surname";
                paramSN.SqlDbType = SqlDbType.VarChar;
                paramSN.Direction = ParameterDirection.Input;
                paramSN.Value = txtSName.Text;
                command.Parameters.Add(paramSN);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.SqlDbType = SqlDbType.VarChar;
                paramGender.Direction = ParameterDirection.Input;
                paramGender.Value = rdlGender.SelectedValue;
                command.Parameters.Add(paramGender);

                SqlParameter paramAge = new SqlParameter();
                paramAge.ParameterName = "@Age";
                paramAge.SqlDbType = SqlDbType.Int;
                paramAge.Direction = ParameterDirection.Input;
                paramAge.Value = Convert.ToInt32(txtAge.Text);
                command.Parameters.Add(paramAge);

                SqlParameter paramAdd1 = new SqlParameter();
                paramAdd1.ParameterName = "@Address1";
                paramAdd1.SqlDbType = SqlDbType.VarChar;
                paramAdd1.Direction = ParameterDirection.Input;
                paramAdd1.Value = txtAdd1.Text;
                command.Parameters.Add(paramAdd1);

                SqlParameter paramAdd2 = new SqlParameter();
                paramAdd2.ParameterName = "@Address2";
                paramAdd2.SqlDbType = SqlDbType.VarChar;
                paramAdd2.Direction = ParameterDirection.Input;
                paramAdd2.Value = txtAdd2.Text;
                command.Parameters.Add(paramAdd2);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.SqlDbType = SqlDbType.VarChar;
                paramCity.Direction = ParameterDirection.Input;
                paramCity.Value = txtCity.Text;
                command.Parameters.Add(paramCity);

                SqlParameter paramPhone = new SqlParameter();
                paramPhone.ParameterName = "@Phone";
                paramPhone.SqlDbType = SqlDbType.VarChar;
                paramPhone.Direction = ParameterDirection.Input;
                paramPhone.Value = txtPhone.Text;
                command.Parameters.Add(paramPhone);

                SqlParameter paramMobile = new SqlParameter();
                paramMobile.ParameterName = "@Mobile";
                paramMobile.SqlDbType = SqlDbType.VarChar;
                paramMobile.Direction = ParameterDirection.Input;
                paramMobile.Value = txtMobile.Text;
                command.Parameters.Add(paramMobile);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.SqlDbType = SqlDbType.VarChar;
                paramEmail.Direction = ParameterDirection.Input;
                paramEmail.Value = txtEmail.Text;
                command.Parameters.Add(paramEmail);

                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();

                command.Connection.Close();
                Clear();
                lblMessage.Text = "Record Added!";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateCust";
                command.Connection.Open();

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@CustomerID";
                paramID.SqlDbType = SqlDbType.Int;
                paramID.Direction = ParameterDirection.Input;
                paramID.Value = txtCustID.Text;
                command.Parameters.Add(paramID);

                SqlParameter paramFN = new SqlParameter();
                paramFN.ParameterName = "@Firstname";
                paramFN.SqlDbType = SqlDbType.VarChar;
                paramFN.Direction = ParameterDirection.Input;
                paramFN.Value = txtFName.Text;
                command.Parameters.Add(paramFN);

                SqlParameter paramSN = new SqlParameter();
                paramSN.ParameterName = "@Surname";
                paramSN.SqlDbType = SqlDbType.VarChar;
                paramSN.Direction = ParameterDirection.Input;
                paramSN.Value = txtSName.Text;
                command.Parameters.Add(paramSN);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.SqlDbType = SqlDbType.VarChar;
                paramGender.Direction = ParameterDirection.Input;
                DataSet ds = new DataSet();
                paramGender.Value = rdlGender.SelectedValue;
                command.Parameters.Add(paramGender);

                SqlParameter paramAge = new SqlParameter();
                paramAge.ParameterName = "@Age";
                paramAge.SqlDbType = SqlDbType.Int;
                paramAge.Direction = ParameterDirection.Input;
                paramAge.Value = Convert.ToInt32(txtAge.Text);
                command.Parameters.Add(paramAge);

                SqlParameter paramAdd1 = new SqlParameter();
                paramAdd1.ParameterName = "@Address1";
                paramAdd1.SqlDbType = SqlDbType.VarChar;
                paramAdd1.Direction = ParameterDirection.Input;
                paramAdd1.Value = txtSName.Text;
                command.Parameters.Add(paramAdd1);

                SqlParameter paramAdd2 = new SqlParameter();
                paramAdd2.ParameterName = "@Address2";
                paramAdd2.SqlDbType = SqlDbType.VarChar;
                paramAdd2.Direction = ParameterDirection.Input;
                paramAdd2.Value = txtSName.Text;
                command.Parameters.Add(paramAdd2);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.SqlDbType = SqlDbType.VarChar;
                paramCity.Direction = ParameterDirection.Input;
                paramCity.Value = txtSName.Text;
                command.Parameters.Add(paramCity);

                SqlParameter paramPhone = new SqlParameter();
                paramPhone.ParameterName = "@Phone";
                paramPhone.SqlDbType = SqlDbType.VarChar;
                paramPhone.Direction = ParameterDirection.Input;
                paramPhone.Value = txtSName.Text;
                command.Parameters.Add(paramPhone);

                SqlParameter paramMobile = new SqlParameter();
                paramMobile.ParameterName = "@Mobile";
                paramMobile.SqlDbType = SqlDbType.VarChar;
                paramMobile.Direction = ParameterDirection.Input;
                paramMobile.Value = txtSName.Text;
                command.Parameters.Add(paramMobile);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.SqlDbType = SqlDbType.VarChar;
                paramEmail.Direction = ParameterDirection.Input;
                paramEmail.Value = txtSName.Text;
                command.Parameters.Add(paramEmail);

                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();

                command.Connection.Close();
                Clear();
                lblMessage.Text = "Record Updated!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR! " + ex.ToString();
            }
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RetrieveCust";
                command.Connection.Open();
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = txtCustID.Text;
                command.Parameters.Add(param);

                adapter.SelectCommand = command;
                adapter.Fill(table);

                txtFName.Text = table.Rows[0].Field<string>("Firstname");
                txtFName.DataBind();
                txtSName.Text = table.Rows[0].Field<string>("Surname");
                txtSName.DataBind();

                DataSet ds = new DataSet();
                rdlGender.SelectedValue = table.Rows[0].Field<string>("Gender");
                rdlGender.DataBind();

                txtAge.Text = table.Rows[0].Field<int>("Age").ToString();
                txtAge.DataBind();
                txtAdd1.Text = table.Rows[0].Field<string>("Address1");
                txtAdd1.DataBind();
                txtAdd2.Text = table.Rows[0].Field<string>("Address2");
                txtAdd2.DataBind();
                txtCity.Text = table.Rows[0].Field<string>("City");
                txtCity.DataBind();
                txtPhone.Text = table.Rows[0].Field<string>("Phone");
                txtPhone.DataBind();
                txtMobile.Text = table.Rows[0].Field<string>("Mobile");
                txtMobile.DataBind();
                txtEmail.Text = table.Rows[0].Field<string>("Email");
                txtEmail.DataBind();

                command.Connection.Close();

            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR! ";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM Customer WHERE CustID = " + txtCustID.Text;
                command.Connection.Open();

                adapter.DeleteCommand = command;
                adapter.DeleteCommand.ExecuteNonQuery();

                command.Connection.Close();
                Clear();
                lblMessage.Text = "Record Deleted!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR! ";
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

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}