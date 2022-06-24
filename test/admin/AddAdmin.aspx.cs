using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AddAdmin : System.Web.UI.Page
{
    string s = System.Configuration.ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnaddrole_Click(object sender, EventArgs e)
    {
  
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spRolesCreation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rname", txtrole.Text);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Role Created Succesfully');", true);
                        
                    }
                    else
                    {
                        //txtrolelevel.Focus();
                        panel_resetpass_warning.Visible = true;
                        lbl_resetpasswarning.Text = "Rolename already exists in Database</br> ";
                    }
                }
                catch (Exception ex)
                {
                    //txtrolelevel.Focus();
                    panel_resetpass_warning.Visible = true;
                    lbl_resetpasswarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            } // end of using 
        
 
    }

    protected void drprolename_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtrole.Text = drprolename.SelectedItem.Text;
    }


    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("spUserLevelPrivileges", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rid", drpAddUserPrivilege.SelectedIndex);
            cmd.Parameters.AddWithValue("@user", drpSelectUserFromDB.SelectedItem.Text);
            try
            {
                con.Open();
                int i = (int)cmd.ExecuteNonQuery();
                if (i > 0)
                {                    
                   
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('User Added To Role Succesfully');", true);
                }
                else
                {
                    //txtrolelevel.Focus();
                    panel_resetpass_warning.Visible = true;
                    lbl_resetpasswarning.Text = "Error in updating user privileges and level</br> ";
                }
            }
            catch (Exception ex)
            {
                //txtrolelevel.Focus();
                panel_resetpass_warning.Visible = true;
                lbl_resetpasswarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
            }
        } // end of using 

    }
}