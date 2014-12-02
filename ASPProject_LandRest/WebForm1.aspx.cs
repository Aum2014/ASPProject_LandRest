using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ASPProject_LandRest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            SqlConnection objConn = null;
            string strConnString = null;
            StringBuilder strSQL = default(StringBuilder);
            SqlCommand objCmd = null;
            int intCount = 0;

            //*** Open Connection ***'
            strConnString = "Server=AUMFER-PC\\SQLEXPRESS;Initial Catalog=Rest;Integrated Security=True";
            objConn = new SqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();

            //*** Check Login ***'
            strSQL = new StringBuilder();
            strSQL.Append(" SELECT COUNT(*) FROM Customer ");
            strSQL.Append(" WHERE C_UserName = @sUsername ");
            strSQL.Append(" AND C_PassWord = @sPassword ");
            objCmd = new SqlCommand(strSQL.ToString(), objConn);
            objCmd.Parameters.Add("@sUsername", SqlDbType.VarChar).Value = this.txtUsername.Text;
            objCmd.Parameters.Add("@sPassword", SqlDbType.VarChar).Value = this.txtPassword.Text;
            intCount = (int)objCmd.ExecuteScalar();

            objConn.Close();
            objConn = null;

            if (intCount <= 0)
            {
                this.lblStatus.ForeColor = System.Drawing.Color.Red;
                this.lblStatus.Text = "Username or Password wrong!";
            }
            else
            {
                Session["strUsername"] = this.txtUsername.Text;
                Response.Redirect("WebForm3.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }
    }
}