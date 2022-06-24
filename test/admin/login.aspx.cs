using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_login : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnlogin.CssClass = "confirmLink";
        btnlogin.CssClass = "btn btn-primary btn-block";
    }
   
    //for login
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spAdminlogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@admin_email", txt_email.Text);
                cmd.Parameters.AddWithValue("@password", txt_pass.Text);
                try
                {
                    con.Open();
                    int value = (int)cmd.ExecuteScalar();
                    if (value == 1)
                    {
                        if (chk_remember.Checked)
                        {
                            HttpCookie user = new HttpCookie("admin_cookies"); //creating cookie object where user_cookies is cookie name
                            user["adminemail"] = txt_email.Text; // cookie content
                            user.Expires = DateTime.Now.AddYears(3); // give the time/duration of cookie
                            Response.Cookies.Add(user); // it gives the response in browser
                            
                            login();
                        }
                        else
                        {
                         
                            login();
                        }
                       
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

    private void login()
    {
        string roleid = "0";
        Session["adminemail"] = txt_email.Text;
        using (SqlConnection conn = new SqlConnection(s))
        {
            conn.Open();

            SqlCommand cmdd = new SqlCommand("spSessionLoggedinUser", conn);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@admin_email", txt_email.Text);
            SqlDataAdapter adp = new SqlDataAdapter(cmdd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            try
            {
                int valuee = (int)cmdd.ExecuteNonQuery();
                if (valuee == -1)
                {
                    txtLoggedIN.Text = dt.Rows[0]["admin_name"].ToString();
                    txtroleid.Text = dt.Rows[0]["roleid"].ToString();
                    Session["loggedInUser"] = txtLoggedIN.Text;
                    
                    if (roleid != txtroleid.Text)          //admin or not
                    {



                        //Response.Write("<script>alert('Successful')</script>");

                        Response.Redirect("~/demo/adminfront.aspx");

                    }
                    else
                    {
                        //Response.Redirect("~/staffside.aspx");
                        //Response.Redirect("../Default.aspx");
                        Response.Redirect("../MobileFirst.aspx");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                pnl_warning.Visible = true;
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }

    }


}