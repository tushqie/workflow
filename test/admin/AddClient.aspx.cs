using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AddClient : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpClientPersonTomeet.Items.Insert(0, "SELECT HERE");
        }
    }

    protected void btncontactperson_Click(object sender, EventArgs e)
    {
        if ((txtcontactpersonname.Text != "")&& (txtcontactpersonphone.Text != "")&& (txtcontactpersonemail.Text != ""))
        {
            string s = ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spAddContactPerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cname", drpClientPersonTomeet.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@cperson", txtcontactpersonname.Text);
                cmd.Parameters.AddWithValue("@cemail", txtcontactpersonemail.Text);
                cmd.Parameters.AddWithValue("@cphone", txtcontactpersonphone.Text);

                try
                {
                    con.Open();
                    int value = cmd.ExecuteNonQuery(); // as procedure return number
                    if (value > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Contact Person Added Succesfully');", true);
                        // Response.Redirect("~/demo/adminfront.aspx");
                    }
                    else if(value == -1)
                    {
                        txtcontactpersonname.Focus();
                        panel_addamin_warning.Visible = true;
                        lbl_addaminwarning.Text = "This Person name is already in use for this Client";
                    }

                }
                catch (Exception ex)
                {
                    txtcontactpersonname.Focus();
                    panel_addamin_warning.Visible = true;
                    lbl_addaminwarning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                }
            }
        }
        else
        {
            txtloc.Focus();
            panel_addamin_warning.Visible = true;
            lbl_addaminwarning.Text = "Please fill all the requirements";
        }
    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
           
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spClientRegisterinsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@location", txtloc.Text);
                cmd.Parameters.AddWithValue("@amount", txtamount.Text);
                cmd.Parameters.AddWithValue("@task", txttask.Text);

                try
                {
                    con.Open();
                    int value = (int)cmd.ExecuteScalar(); // as procedure return number
                    if (value == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Client Added Succesfully');", true);
                        // Response.Redirect("~/demo/adminfront.aspx");
                    }
                    else
                    {
                        txtname.Focus();
                        //panel_addamin_warning.Visible = true;
                        //lbl_addaminwarning.Text = "CLIENT's name is already in use";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('CLIENT's name is already in use');", true);
                    }

                }
                catch (Exception ex)
                {
                    txtloc.Focus();
                    panel_addamin_warning.Visible = true;
                    lbl_addaminwarning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                }
            }
        }
        catch
        {
            txtloc.Focus();
            panel_addamin_warning.Visible = true;
            lbl_addaminwarning.Text = "Please fill all the requirements";
        }
    }
}