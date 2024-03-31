using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI; 
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Server=DESKTOP-AJ9CFSH; Initial Catalog=DERMOCARE; Integrated Security=true ";
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select adhar from PatientMaster where  username= @un AND password=@pwd ";

        cmd.Parameters.AddWithValue("@un", txtusername.Text);
        cmd.Parameters.AddWithValue("@pwd", txtpwd.Text);

        cmd.Connection = con;
        Object obj = cmd.ExecuteScalar();


        if (obj == null)
        {
            lblmsg.Text = "Invalid user";
        }
        else
        {

            {
                Session.Add("u", txtusername.Text);
                Session.Add("p", txtpwd.Text);
                Response.Redirect("Patient//Default.aspx");
            }
            {


            }
            con.Close();





        }
    }
}