using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class demo_adminfront : System.Web.UI.Page
{
    string s = System.Configuration.ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Insert(0, "Select");

            populategrid();
           
            totalrecordsabovegrid();
        }

        totalrecordsabovegrid();

    }

    public void totalrecordsabovegrid()
    {
        using (SqlConnection cgn = new SqlConnection(s))
        {
            cgn.Open();

            SqlCommand cgd = new SqlCommand("masterEditTrail", cgn);
            cgd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ap = new SqlDataAdapter(cgd);
            DataTable dt = new DataTable();
            ap.Fill(dt);
            
            try
            {
                if (dt.Rows.Count > 0)
                {
                    txttotalrec.Text = "Total Record(s) :  " + dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {

                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;

            }
        }
    }


    private void populategrid()
    {
        using (SqlConnection cn = new SqlConnection(s))
        {
            cn.Open();
           
            SqlCommand cdd = new SqlCommand("spMasterSortbyPendingONTop", cn);
            cdd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ap = new SqlDataAdapter(cdd);
            DataTable dst = new DataTable();
            ap.Fill(dst);
            try
            {
                if (dst.Rows.Count > 0)
                {
                    //Session["KeepDThere"] = dst;
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('" + ab + "');", true);
                    gdvAdmin.DataSource = dst;
                    gdvAdmin.DataBind();                  

                }
                else
                {
                    dst.Rows.Add(dst.NewRow());
                    gdvAdmin.DataSource = dst;
                    gdvAdmin.DataBind();
                    gdvAdmin.Rows[0].Cells.Clear();
                    gdvAdmin.Rows[0].Cells.Add(new TableCell());
                    gdvAdmin.Rows[0].Cells[0].ColumnSpan = dst.Columns.Count;
                    gdvAdmin.Rows[0].Cells[0].Text = "<strong>DATABASE IS STILL FRESH SO NO DATA FOUND IN DATABASE!!! </strong> TABLES WILL BE FILLED WHEN ALL STAFF START POSTING";
                    gdvAdmin.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;                    
                    gdvAdmin.Rows[0].ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex)
            {
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }
    }
                  

    protected void SearchGrid_Click(object sender, EventArgs e)
    {
        
        using (SqlConnection conn = new SqlConnection(s))
        {

            SqlCommand cdd = new SqlCommand();
            cdd.Connection = conn;

            StringBuilder sb = new StringBuilder("select * from master where 1 = 1");

           // SqlCommand cdd = new SqlCommand("select * from master where [" + DropDownList1.SelectedItem.Text +
              //  "] ='" + txtsearch.Text + "'", conn);
            
            if(DropDownList1.SelectedItem.Text == "fullname")
            {
                sb.Append(" and fullname=@fn order by case approved_by when 'Pending' then approved_by end desc");
                SqlParameter param = new SqlParameter("@fn", txtsearch.Text);
                cdd.Parameters.Add(param);
            }
            else if(DropDownList1.SelectedItem.Text == "client_task")
            {
                sb.Append(" and client_task=@ct order by case approved_by when 'Pending' then approved_by end desc");
                SqlParameter param = new SqlParameter("@ct", txtsearch.Text);
                cdd.Parameters.Add(param);
            }
            else if (DropDownList1.SelectedItem.Text == "client_amount")
            {
                sb.Append(" and client_amount=@ca order by case approved_by when 'Pending' then approved_by end desc");
                SqlParameter param = new SqlParameter("@ca", txtsearch.Text.ToString());
                cdd.Parameters.Add(param);
            }
            else if (DropDownList1.SelectedItem.Text == "applied_date")
            {
                sb.Append(" and applied_date=@ad order by case approved_by when 'Pending' then approved_by end desc");
                SqlParameter param = new SqlParameter("@ad", txtsearch.Text);
                cdd.Parameters.Add(param);
            }
            else if (DropDownList1.SelectedItem.Text == "approved_by")
            {
                sb.Append(" and approved_by=@ab order by case approved_by when 'Pending' then approved_by end desc");
                SqlParameter param = new SqlParameter("@ab", txtsearch.Text);
                cdd.Parameters.Add(param);
            }
            else if (DropDownList1.SelectedItem.Text == "client_name")
            {
                sb.Append(" and client_name=@cn order by case approved_by when 'Pending' then approved_by end desc");
                SqlParameter param = new SqlParameter("@cn", txtsearch.Text);
                cdd.Parameters.Add(param);
            }

            cdd.CommandText = sb.ToString();
            cdd.CommandType = CommandType.Text;
            SqlDataAdapter adp = new SqlDataAdapter(cdd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
                     
            try
            {

                if (dt.Rows.Count > 0)
                {
                    
                    gdvAdmin.DataSource = dt;
                    gdvAdmin.DataBind();
                    //System.Threading.Thread.Sleep(5000);
                    //gdvAdmin.Visible = true;
                    foreach (GridViewRow row in gdvAdmin.Rows)
                    {
                        Label id = (Label)row.FindControl("lblid");
                        Label fn = (Label)row.FindControl("lblfn");
                        Label cn = (Label)row.FindControl("lblcn");
                        Label cl = (Label)row.FindControl("lblcl");
                        Label ca = (Label)row.FindControl("lblca");
                        Label ct = (Label)row.FindControl("lblct");
                        Label ad = (Label)row.FindControl("lblad");
                        Label ab = (Label)row.FindControl("lblab");
                        if (fn.Text != "")
                        {

                            string seachtext = fn.Text.Trim();
                            int[] colsToCheck = new int[] { 1, 2, 3, 4, 5, 6, 7 };// columns to be searched [ zero based index ]

                            for (int i = 0; i < colsToCheck.Length; i++)
                            {
                                int colIndex = colsToCheck[i];
                                fn.Text = Regex.Replace(fn.Text, seachtext, delegate (Match match)
                                {

                                    //return string.Format("<span style = 'background-color:yellow;color:red'>{0}</span>", match.Value);
                                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);

                                }, RegexOptions.IgnoreCase);


                            }

                        }
                        if (ct.Text != "")
                        {

                            string seachtext = ct.Text.Trim();
                            int[] colsToCheck = new int[] { 1, 2, 3, 4, 5, 6, 7 };// columns to be searched [ zero based index ]

                            for (int i = 0; i < colsToCheck.Length; i++)
                            {
                                int colIndex = colsToCheck[i];
                                ct.Text = Regex.Replace(ct.Text, seachtext, delegate (Match match)
                                {

                                    //return string.Format("<span style = 'background-color:yellow;color:red'>{0}</span>", match.Value);
                                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);

                                }, RegexOptions.IgnoreCase);


                            }

                        }
                        if (ca.Text != "")
                        {

                            string seachtext = ca.Text.Trim();
                            int[] colsToCheck = new int[] { 1, 2, 3, 4, 5, 6, 7 };// columns to be searched [ zero based index ]

                            for (int i = 0; i < colsToCheck.Length; i++)
                            {
                                int colIndex = colsToCheck[i];
                                ca.Text = Regex.Replace(ca.Text, seachtext, delegate (Match match)
                                {

                                    //return string.Format("<span style = 'background-color:yellow;color:red'>{0}</span>", match.Value);
                                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);

                                }, RegexOptions.IgnoreCase);


                            }

                        }
                        if (ad.Text != "")
                        {

                            string seachtext = ad.Text.Trim();
                            int[] colsToCheck = new int[] { 1, 2, 3, 4, 5, 6, 7 };// columns to be searched [ zero based index ]

                            for (int i = 0; i < colsToCheck.Length; i++)
                            {
                                int colIndex = colsToCheck[i];
                                ad.Text = Regex.Replace(ad.Text, seachtext, delegate (Match match)
                                {

                                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);
                                    //return string.Format("<span style = 'background-color:yellow;color:red'>{0}</span>", match.Value);

                                }, RegexOptions.IgnoreCase);


                            }

                        }
                    } 

                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    gdvAdmin.DataSource = dt;
                    gdvAdmin.DataBind();
                    gdvAdmin.Rows[0].Cells.Clear();
                    gdvAdmin.Rows[0].Cells.Add(new TableCell());
                    gdvAdmin.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                    gdvAdmin.Rows[0].Cells[0].Text = "NO DATA FOUND IN DATABASE!!!";
                    gdvAdmin.Rows[0].Cells[0].ForeColor = Color.OrangeRed;
                    //gdvAdmin.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }

            }
            catch (Exception ex)
            {
                pnl_warning.Visible = true;
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }



        }
    }

    protected void gdvAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        totalrecordsabovegrid();
        ImageButton img = (ImageButton)e.Row.FindControl("imgB");
        if (img != null)
        {
            img.Attributes.Add("ROW_INDEX", e.Row.RowIndex.ToString());
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label id = (Label)e.Row.FindControl("lblid");
            Label fn = (Label)e.Row.FindControl("lblfn");
            Label cn = (Label)e.Row.FindControl("lblcn");
            Label cl = (Label)e.Row.FindControl("lblcl");
            Label ca = (Label)e.Row.FindControl("lblca");
            Label ct = (Label)e.Row.FindControl("lblct");
            Label ad = (Label)e.Row.FindControl("lblad");
            Label ab = (Label)e.Row.FindControl("lblab");

            if (ab.Text == "Pending")
            {
                id.Style.Add("color", "red");
                fn.Style.Add("color", "red");
                cn.Style.Add("color", "red");
                cl.Style.Add("color", "red");
                ca.Style.Add("color", "red");
                ct.Style.Add("color", "red");
                ad.Style.Add("color", "red");
                ab.Style.Add("color", "red");
            }
            else if (ab.Text != "Pending")
            {
                id.Style.Add("color", "green");
                fn.Style.Add("color", "green");
                cn.Style.Add("color", "green");
                cl.Style.Add("color", "green");
                ca.Style.Add("color", "green");
                ct.Style.Add("color", "green");
                ad.Style.Add("color", "green");
                ab.Style.Add("color", "green");

                //e.Row.Cells[8].Controls.Clear();
                ImageButton aab = (ImageButton)e.Row.FindControl("imgB");
                aab.ImageUrl = "../assets/logo/approve.png";
                aab.Enabled = false;
                aab.ToolTip = "ALREADY APPROVED!!!";
                e.Row.Cells[8].Controls.Add(aab);

            }

            
        }

    }

    protected void imgB_Click(object sender, ImageClickEventArgs e)
    {
        int isdeleted = 0;
        //string id = gdvAdmin.SelectedDataKey.Value.ToString();
        //for (int i = 0; i < gdvAdmin.Rows.Count - 1; i++)
        //{
        int rowIndex = Convert.ToInt32(((ImageButton)sender).Attributes["ROW_INDEX"].ToString());
        int id = Convert.ToInt32(gdvAdmin.DataKeys[rowIndex].Value);

        using (SqlConnection connect = new SqlConnection(s))
        {
            connect.Open();

            SqlCommand cam = new SqlCommand("spMasterDeleteUsingImageIcon", connect);
            cam.CommandType = CommandType.StoredProcedure;
            cam.Parameters.AddWithValue("@id", id);
            //     connect.Open();
            try
            {
                isdeleted = cam.ExecuteNonQuery();
                if (isdeleted > 0)
                {
                    totalrecordsabovegrid();
                    connect.Close();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Row Deleted Succesfully');", true);
                    //gdvAdmin.DataSource = Session["MasterTableRecords"];
                    //populategrid();
                    
                }

            }
            catch (Exception ex)
            {
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }
        //}
    }


    protected void gdvAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvAdmin.EditIndex = -1;
        populategrid();

    }

    protected void gdvAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        using (SqlConnection cn = new SqlConnection(s))
        {
            cn.Open();

            SqlCommand cdd = new SqlCommand("spUpdateMasterSortbyPendingONTop", cn);
            cdd.CommandType = CommandType.StoredProcedure;
            cdd.Parameters.AddWithValue("@fullname", (gdvAdmin.Rows[e.RowIndex].FindControl("txtfn") as TextBox).Text.Trim());
            cdd.Parameters.AddWithValue("@cn", (gdvAdmin.Rows[e.RowIndex].FindControl("txtcn") as TextBox).Text.Trim());
            cdd.Parameters.AddWithValue("@cl", (gdvAdmin.Rows[e.RowIndex].FindControl("txtcl") as TextBox).Text.Trim());
            cdd.Parameters.AddWithValue("@ca", (gdvAdmin.Rows[e.RowIndex].FindControl("txtca") as TextBox).Text.Trim());
            cdd.Parameters.AddWithValue("@ct", (gdvAdmin.Rows[e.RowIndex].FindControl("txtct") as TextBox).Text.Trim());
            cdd.Parameters.AddWithValue("@ad", (gdvAdmin.Rows[e.RowIndex].FindControl("txtad") as TextBox).Text.Trim());
            cdd.Parameters.AddWithValue("@ab", (gdvAdmin.Rows[e.RowIndex].FindControl("txtab") as TextBox).Text.Trim());
            cdd.Parameters.AddWithValue("@id", (Convert.ToInt32(gdvAdmin.DataKeys[e.RowIndex].Value)));

            try
            {
                int success = cdd.ExecuteNonQuery();
                if (success > 0)
                {
                    gdvAdmin.EditIndex = -1;
                
                    populategrid();
                    cn.Close();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Record Updated Successfully!!!');", true);
                    totalrecordsabovegrid();

                }

            }
            catch (Exception ex)
            {
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }
    }

    protected void gdvAdmin_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvAdmin.EditIndex = e.NewEditIndex;
        populategrid();

    }

    protected void gdvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("AddNew"))
        {
            using (SqlConnection cn = new SqlConnection(s))
            {

                cn.Open();

                SqlCommand cdd = new SqlCommand("spMasterInsertSortPendingFirst", cn);
                cdd.CommandType = CommandType.StoredProcedure;
                cdd.Parameters.AddWithValue("@fn", (gdvAdmin.FooterRow.FindControl("txtfnf") as TextBox).Text.Trim());
                cdd.Parameters.AddWithValue("@cn", (gdvAdmin.FooterRow.FindControl("txtcnf") as TextBox).Text.Trim());
                cdd.Parameters.AddWithValue("@cl", (gdvAdmin.FooterRow.FindControl("txtclf") as TextBox).Text.Trim());
                cdd.Parameters.AddWithValue("@ca", (gdvAdmin.FooterRow.FindControl("txtcaf") as TextBox).Text.Trim());
                cdd.Parameters.AddWithValue("@ct", (gdvAdmin.FooterRow.FindControl("txtctf") as TextBox).Text.Trim());
                cdd.Parameters.AddWithValue("@ad", (gdvAdmin.FooterRow.FindControl("txtadf") as TextBox).Text.Trim());
                cdd.Parameters.AddWithValue("@ab", (gdvAdmin.FooterRow.FindControl("txtabf") as TextBox).Text.Trim());


                try
                {
                    int success = 0;
                     success = cdd.ExecuteNonQuery();
                    if (success > 0)
                    {
                        populategrid();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('New Record Added Successfully!!!');", true);
                        cn.Close();
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

}