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
        con.ConnectionString = "Server=localhost;Initial catalog=DERMOCARE;Integrated security=true";
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select dname from DoctorMaster where username=@un and password=@pwd";
        cmd.Parameters.AddWithValue("@un", txtusername.Text);
        cmd.Parameters.AddWithValue("@pwd", txtpwd.Text);
        cmd.Connection = con;
        Object obj = cmd.ExecuteScalar();
        con.Close();

        if (obj == null)
        {
            lblmsg.Text = "Invalid Username or Password";
        }
        else
        {
            Session.Add("un", txtusername.Text);
            Response.Redirect("Doctor\\Default.aspx");

        }


    }
    }
