using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    string s = ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;
    //for login
    protected void btn_register_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spAdminInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txt_name.Text);
                cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cmd.Parameters.AddWithValue("@password", txt_pass.Text);
                try
                {
                    con.Open();
                    int value = (int)cmd.ExecuteScalar();
                    if (value == 1)
                    {

                        MessageBoxShow();
                        //Response.Redirect("~/admin/login.aspx");
                        pnl_warning.Visible = true;
                        lbl_warning.Text = "YOU CAN GO AND LOGIN NOW WITH YOUR EMAIL AND PASSWORD!!!";

                        
                    }
                    else if(value == -1)
                    {
                        pnl_warning.Visible = true;
                        lbl_warning.Text = "Email already exists..use another email</br>";
                    }
                    else
                    {
                        pnl_warning.Visible = true;
                        lbl_warning.Text = "Use correct email and password</br>";
                    }

                }
                catch (Exception ex)
                {
                    pnl_warning.Visible = true;
                    lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                }
            }
        }
        else
        {
            pnl_warning.Visible = true;
            lbl_warning.Text = "Please fill all the requirements";
        }

    }

    private void MessageBoxShow()
    {

        Response.Write("<script>alert('Successful')</script>");
    }
}