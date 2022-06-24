using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class ForgotPassword : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //for login
    protected void btn_register_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spUpdateForgotPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", txt_email.Text);
                cmd.Parameters.AddWithValue("@password", txt_pass.Text);
                try
                {
                    con.Open();
                    int value = (int)cmd.ExecuteNonQuery();
                    if (value == 1)
                    {

                        MessageBoxShow();
                        //Response.Redirect("~/admin/login.aspx");
                    }
                    else
                    {
                        pnl_warning.Visible = true;
                        lbl_warning.Text = "Use correct email ..please check well</br>";
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