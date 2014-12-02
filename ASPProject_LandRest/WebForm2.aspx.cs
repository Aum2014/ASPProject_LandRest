using System;
using System.Data;
using System.Data.SqlClient;

namespace ASPProject_LandRest
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection objConn = new SqlConnection();
            SqlCommand objCmd = new SqlCommand();
            String strConnString, strSQL;

            strConnString = "Server=AUMFER-PC\\SQLEXPRESS;Initial Catalog=Rest;Integrated Security=True";
            strSQL = "INSERT INTO Customer (C_Name,C_LastName,C_Email,C_Sex,C_PhoneNumber,C_UserName,C_PassWord,C_Address,C_RentRoom,C_Count) " +
            " VALUES " +
            " ('" + this.TextBox1.Text + "','" + this.TextBox2.Text + "','" + this.TextBox7.Text + "','" + this.TextBox4.Text + "','" + this.TextBox5.Text + "','" + this.TextBox6.Text + "','" + this.TextBox3.Text + "','" + this.TextBox8.Text + "','" + this.TextBox9.Text + "','" + this.TextBox10.Text + "')";

            objConn.ConnectionString = strConnString;
            objConn.Open();
            objCmd.Connection = objConn;
            objCmd.CommandText = strSQL;
            objCmd.CommandType = CommandType.Text;

            try
            {
                objCmd.ExecuteNonQuery();
                this.lblStatus.Text = "Record Inserted";
                this.lblStatus.Visible = true;
            }
            catch (Exception ex)
            {
                this.lblStatus.Visible = true;
                this.lblStatus.Text = "Record can not insert Error (" + ex.Message + ")";
            }

            objConn.Close();
            objConn = null;
            }

        

       
        }
    }
