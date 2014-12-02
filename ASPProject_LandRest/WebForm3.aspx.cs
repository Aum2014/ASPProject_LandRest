using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ASPProject_LandRest
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //*** Check login Status ***//
            if (Convert.ToString(Session["strUsername"]) == "")
            {
                Response.Redirect("WebForm1.aspx");
                Response.End();
            }

            ViewDataInf();
        }

        protected void ViewDataInf()
        {
            SqlConnection objConn = null;
            string strConnString = null;
            StringBuilder strSQL = default(StringBuilder);
            SqlCommand objCmd = null;
            SqlDataAdapter dtAdapter = null;
            DataTable dt = null;
            DataSet ds = new DataSet();

            //*** Open Connection ***'
            strConnString = "Server=AUMFER-PC\\SQLEXPRESS;Initial Catalog=Rest;Integrated Security=True";
            objConn = new SqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();

            strSQL = new StringBuilder();
            strSQL.Append(" SELECT * FROM Customer ");
            strSQL.Append(" WHERE C_UserName = @sUsername ");

            objCmd = new SqlCommand(strSQL.ToString(), objConn);
            objCmd.Parameters.Add("@sUsername", SqlDbType.VarChar).Value = Session["strUsername"];

            dtAdapter = new SqlDataAdapter();
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(ds);

            dt = ds.Tables[0];

            dtAdapter = null;
            objConn.Close();
            objConn = null;

            if (dt.Rows.Count > 0)
            {
                this.lbluser.Text = dt.Rows[0]["C_UserName"].ToString();
                this.lblpass.Text = dt.Rows[0]["C_PassWord"].ToString();
                this.lblname.Text = dt.Rows[0]["C_Name"].ToString();
                this.lbllast.Text = dt.Rows[0]["C_LastName"].ToString();
                this.lblroom.Text = dt.Rows[0]["C_RentRoom"].ToString();
                this.lblcount.Text = dt.Rows[0]["C_Count"].ToString();
              
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("WebForm1.aspx");
        }
    }
}