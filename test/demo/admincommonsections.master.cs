using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admincommonsections : System.Web.UI.MasterPage
{
    string s = System.Configuration.ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        DateTime now = DateTime.Now;
        Label2.Text = now.ToString("yyyy");

        HttpCookie admincookie = Request.Cookies["admin_cookies"];
        if (Session["adminemail"] != null || admincookie != null)
        {
            link_loginout.Text = "Log out";
            Label1.Text = Session["loggedInUser"].ToString();
        }
        else
        {
            link_loginout.Text = "Log in";
            Response.Redirect("~/admin/login.aspx");
        }
        totalpending();
        totalclients();
        totalonlineusers();
    }

    private void totalclients()
    {
        using (SqlConnection cn = new SqlConnection(s))
        {
            cn.Open();

            SqlCommand cdd = new SqlCommand("spClientselectCount", cn);
            cdd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ap = new SqlDataAdapter(cdd);
            DataTable dst = new DataTable();
            ap.Fill(dst);
            try
            {

                lbltotalClients.Text = dst.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                //lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }

    }

    private void totalpending()
    {
        using (SqlConnection cn = new SqlConnection(s))
        {
            cn.Open();

            SqlCommand cdd = new SqlCommand("spAllPendingReporting", cn);
            cdd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ap = new SqlDataAdapter(cdd);
            DataTable dst = new DataTable();
            ap.Fill(dst);
            try
            {
               
                lbltotalPending.Text = dst.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }
    }

    private void totalonlineusers()
    {
        lbltotalRegistered.Text = Application["TotalOnlineUsers"].ToString();
    }

    protected void link_loginout_Click(object sender, EventArgs e)
    {
        if (link_loginout.Text == "Log out")
        {
            Response.Cookies["admin_cookies"].Expires = DateTime.Now.AddYears(-1);
    //        Session.Clear();
            //Application.Lock();
            //Application["TotalOnlineUsers"] = (int)Application["TotalOnlineUsers"] - 1;
            //Application.UnLock();
            Response.Redirect("~/admin/Login.aspx");
        }
        else
        {
            link_loginout.Text = "Log in";
        }
    }
}
