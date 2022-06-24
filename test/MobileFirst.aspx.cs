using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

public partial class MobileFirst : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;
    //for login

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_loggedInUser.Text = Session["loggedInUser"].ToString();
        Label1.Text = DateTime.Now.Year.ToString();
        lblemail.Visible = false;
        lblperson.Visible = false;
        lble.Visible = false;
        lblph.Visible = false;
        lblcp.Visible = false;
        drpcontactperson.Visible = false;
        drptask.Visible = false;
        Button1.Visible = false;
        txtdate.Visible = false;

        if (!IsPostBack)
        {
            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" +
            //    gdvSearch.ClientID + "', 400, 910 , 40 ,false); </script>", false);   //MakeStaticHeader is controlling gdvContainer
            lblcp.Visible = false;
            lble.Visible = false;
            lblph.Visible = false;
            drpcontactperson.Visible = false;
            drptask.Visible = false;
            Button1.Visible = false;
            txtdate.Visible = false;

            using (SqlConnection conn = new SqlConnection(s))
            {
                conn.Open();

                SqlCommand cmdd = new SqlCommand("spClientselect", conn);
                cmdd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmdd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                try
                {
                    drpclientname.DataTextField = "name";
                    drpclientname.DataValueField = "id";
                    drpclientname.DataSource = dt;
                    drpclientname.DataBind();

                    drpclientname.Items.Insert(0, "SELECT");
                }
                catch (Exception ex)
                {
                    pnl_warning.Visible = true;
                    lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                }
            }

            FillGridPerStaff();

            totalperstaffrecordsabovegrid();
        }

        totalperstaffrecordsabovegrid();

    }

    private void totalperstaffrecordsabovegrid()
    {
        using (SqlConnection cn = new SqlConnection(s))
        {
            cn.Open();

            SqlCommand cdd = new SqlCommand("spEachStaffPostingsTotal", cn);
            cdd.CommandType = CommandType.StoredProcedure;
            cdd.Parameters.AddWithValue("@fn", Session["loggedInUser"]);
            SqlDataAdapter ap = new SqlDataAdapter(cdd);
            DataTable dst = new DataTable();
            ap.Fill(dst);

            try
            {
                if (dst.Rows.Count > 0)
                {
                    txttotalrec.Text = "Total Record(s) :  " + dst.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                pnl_warning.Visible = true;
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;

            }
        }
    }


    //protected void ShowModal(object sender, EventArgs e) 
    //{
    //    string title = "WORKFLOW APP";
    //    string body = "Successful";
    //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowModal('"+title+ "','" + body + "');", true);
    //}

    private void FillGridPerStaff()
    {
        using (SqlConnection cn = new SqlConnection(s))
        {
            cn.Open();

            SqlCommand cdd = new SqlCommand("spEachStaffPostingsGridSort", cn);
            cdd.CommandType = CommandType.StoredProcedure;
            cdd.CommandType = CommandType.StoredProcedure;
            cdd.Parameters.AddWithValue("@fn", Session["loggedInUser"]);
            SqlDataAdapter dp = new SqlDataAdapter(cdd);
            DataTable dst = new DataTable();
            dp.Fill(dst);
            try
            {

                if (dst.Rows.Count > 0)
                {
                    gdvSearch.DataSource = dst;
                    //Session["MasterTableRecords"] = dst;
                    gdvSearch.DataBind();                  

                    int i = 0;
                    foreach (GridViewRow row in gdvSearch.Rows)
                    {
                        if (row.Cells[7].Text.Contains("Pending"))
                        {
                            i = i + 1;
                            row.ForeColor = System.Drawing.Color.Red;

                        }
                        else
                        {
                            i = i + 1;
                            row.ForeColor = System.Drawing.Color.Green;
                        }

                    }

                    foreach (GridViewRow row in gdvSearch.Rows)
                    {

                        if (row.Cells[7].Text != "Pending")
                        {
                            row.Cells[8].Controls.Clear();
                            Image approveIcon = new Image();
                            approveIcon.ImageUrl = "assets/logo/approve.png";
                            approveIcon.ToolTip = "Approved Already";
                            row.Cells[8].Controls.Add(approveIcon);
                        }
                    }
                }
                else
                {
                    dst.Rows.Add(dst.NewRow());
                    gdvSearch.DataSource = dst;
                    gdvSearch.DataBind();
                    gdvSearch.Rows[0].Cells.Clear();
                    gdvSearch.Rows[0].Cells.Add(new TableCell());
                    gdvSearch.Rows[0].Cells[0].ColumnSpan = dst.Columns.Count;
                    gdvSearch.Rows[0].Cells[0].Text = "NO RECORDS FOUND!!! TRY AND POST";
                    gdvSearch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gdvSearch.Rows[0].ForeColor = System.Drawing.Color.Red;
                }

              

            }
            catch (Exception ex)
            {
                pnl_warning.Visible = true;
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                
            }
        }

    }

    public void Search(object sender, EventArgs e)
{
    //this.BindGrid();
    string constr = ConfigurationManager.ConnectionStrings["sekat"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand())
        {

            if (txtSearch.Text.Length > 0)
            {
                    SqlCommand cmmd = new SqlCommand("spSearchAmount", con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "SELECT * FROM master WHERE client_amount LIKE '%' + @ContactName + '%'";
                    
                cmmd.Connection = con;
                cmmd.Parameters.AddWithValue("@a", txtSearch.Text.Trim());
                    cmmd.Parameters.AddWithValue("@fn", Session["loggedInUser"].ToString());
                    DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmmd))
                {
                    sda.Fill(dt);
                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>RemoveGRIDVIEWHeight('" +
                        //gdvSearch.ClientID + "', 0); </script>", false);
                        //gdvSearch.DataSourceID = "";

                        if (dt.Rows.Count > 0)
                        {
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();

                            int i = 0;
                            foreach (GridViewRow row in gdvSearch.Rows)
                            {
                                if (row.Cells[7].Text.Contains("Pending"))
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Green;
                                    row.Cells[8].Controls.Clear();
                                    Image approveIcon = new Image();
                                    approveIcon.ImageUrl = "assets/logo/approve.png";
                                    approveIcon.ToolTip = "Approved Already";
                                    row.Cells[8].Controls.Add(approveIcon);
                                }
                            } 
                        }
                        else
                        {
                            dt.Rows.Add(dt.NewRow());
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();
                            gdvSearch.Rows[0].Cells.Clear();
                            gdvSearch.Rows[0].Cells.Add(new TableCell());
                            gdvSearch.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                            gdvSearch.Rows[0].Cells[0].Text = "NO DATA FOUND IN DATABASE!!!";
                            gdvSearch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                            gdvSearch.Rows[0].ForeColor = System.Drawing.Color.Red;
                        }

                    }
                txtSearch.Text = "";
            }
            else if (txtClient.Text.Length > 0)
            {
                    SqlCommand cmmd = new SqlCommand("spSearchClient", con);
                    cmmd.CommandType = CommandType.StoredProcedure;

                cmmd.Connection = con;
                cmmd.Parameters.AddWithValue("@c", txtClient.Text.Trim());
                    cmmd.Parameters.AddWithValue("@fn", Session["loggedInUser"].ToString());
                    DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmmd))
                {
                    sda.Fill(dt);
                       
                        if (dt.Rows.Count > 0)
                        {
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();

                            int i = 0;
                            foreach (GridViewRow row in gdvSearch.Rows)
                            {
                                if (row.Cells[7].Text.Contains("Pending"))
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Green;
                                    row.Cells[8].Controls.Clear();
                                    Image approveIcon = new Image();
                                    approveIcon.ImageUrl = "assets/logo/approve.png";
                                    approveIcon.ToolTip = "Approved Already";
                                    row.Cells[8].Controls.Add(approveIcon);
                                }
                            }
                        }
                        else
                        {
                            dt.Rows.Add(dt.NewRow());
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();
                            gdvSearch.Rows[0].Cells.Clear();
                            gdvSearch.Rows[0].Cells.Add(new TableCell());
                            gdvSearch.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                            gdvSearch.Rows[0].Cells[0].Text = "NO DATA FOUND IN DATABASE!!!";
                            gdvSearch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                            gdvSearch.Rows[0].ForeColor = System.Drawing.Color.Red;
                        }

                    }
                txtClient.Text = "";
            }
            else if (txtStaff.Text.Length > 0)
            {
                    SqlCommand cmmd = new SqlCommand("spSearchStaff", con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                   
                cmmd.Connection = con;
                cmmd.Parameters.AddWithValue("@textbox", txtStaff.Text.Trim());
                cmmd.Parameters.AddWithValue("@fn", Session["loggedInUser"].ToString());
                    DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmmd))
                {
                    sda.Fill(dt);
                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>RemoveGRIDVIEWHeight('" +
                        //gdvSearch.ClientID + "', 0); </script>", false);
                        //gdvSearch.DataSourceID = "";
                        if (dt.Rows.Count > 0)
                        {
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();

                            int i = 0;
                            foreach (GridViewRow row in gdvSearch.Rows)
                            {
                                if (row.Cells[7].Text.Contains("Pending"))
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Green;
                                    row.Cells[8].Controls.Clear();
                                    Image approveIcon = new Image();
                                    approveIcon.ImageUrl = "assets/logo/approve.png";
                                    approveIcon.ToolTip = "Approved Already";
                                    row.Cells[8].Controls.Add(approveIcon);
                                }
                            }
                        }
                        else
                        {
                            dt.Rows.Add(dt.NewRow());
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();
                            gdvSearch.Rows[0].Cells.Clear();
                            gdvSearch.Rows[0].Cells.Add(new TableCell());
                            gdvSearch.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                            gdvSearch.Rows[0].Cells[0].Text = "NO DATA FOUND IN DATABASE!!!";
                            gdvSearch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                            gdvSearch.Rows[0].ForeColor = System.Drawing.Color.Red;
                        }
                    }
                txtStaff.Text = "";
            }
            else if (txtApprovedby.Text.Length > 0)
            {
                    SqlCommand cmmd = new SqlCommand("spSearchApproval", con);
                    cmmd.CommandType = CommandType.StoredProcedure;                  

                cmmd.Connection = con;
                cmmd.Parameters.AddWithValue("@ab", txtApprovedby.Text.Trim());
                cmmd.Parameters.AddWithValue("@fn", Session["loggedInUser"].ToString());
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmmd))
                {
                    sda.Fill(dt);
                   
                        if (dt.Rows.Count > 0)
                        {
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();

                            int i = 0;
                            foreach (GridViewRow row in gdvSearch.Rows)
                            {
                                if (row.Cells[7].Text.Contains("Pending"))
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Green;
                                
                                        row.Cells[8].Controls.Clear();
                                        Image approveIcon = new Image();
                                        approveIcon.ImageUrl = "assets/logo/approve.png";
                                        approveIcon.ToolTip = "Approved Already";
                                        row.Cells[8].Controls.Add(approveIcon);
                                    
                                }
                            }
                        }
                        else
                        {
                            dt.Rows.Add(dt.NewRow());
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();
                            gdvSearch.Rows[0].Cells.Clear();
                            gdvSearch.Rows[0].Cells.Add(new TableCell());
                            gdvSearch.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                            gdvSearch.Rows[0].Cells[0].Text = "NO DATA FOUND IN DATABASE!!!";
                            gdvSearch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                            gdvSearch.Rows[0].ForeColor = System.Drawing.Color.Red;
                        } 
                        //        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" +
                          //gdvSearch.ClientID + "', 400, 910 , 40 ,false); </script>", false);
                          //string savedID = dt.Rows.Count.ToString();
                          //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('" + savedID + "');", true);
                          //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + savedID + "');", true);
                    }
                txtApprovedby.Text = "";
            }
            else if (txtdateapplied.Text.Length > 0)
            {
                    SqlCommand cmmd = new SqlCommand("spSearchApplied", con);
                    cmmd.CommandType = CommandType.StoredProcedure;
  
                cmmd.Connection = con;
                cmmd.Parameters.AddWithValue("@ad", txtdateapplied.Text.Trim());
                cmmd.Parameters.AddWithValue("@fn", Session["loggedInUser"].ToString());
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmmd))
                {
                    sda.Fill(dt);                       

                        if (dt.Rows.Count > 0)
                        {
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();

                            int i = 0;
                            foreach (GridViewRow row in gdvSearch.Rows)
                            {
                                if (row.Cells[7].Text.Contains("Pending"))
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Green;
                                    row.Cells[8].Controls.Clear();
                                    Image approveIcon = new Image();
                                    approveIcon.ImageUrl = "assets/logo/approve.png";
                                    approveIcon.ToolTip = "Approved Already";
                                    row.Cells[8].Controls.Add(approveIcon);
                                }
                            }
                        }
                        else
                        {
                            dt.Rows.Add(dt.NewRow());
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();
                            gdvSearch.Rows[0].Cells.Clear();
                            gdvSearch.Rows[0].Cells.Add(new TableCell());
                            gdvSearch.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                            gdvSearch.Rows[0].Cells[0].Text = "NO DATA FOUND IN DATABASE!!!";
                            gdvSearch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                            gdvSearch.Rows[0].ForeColor = System.Drawing.Color.Red;
                        }

                    }
                txtdateapplied.Text = "";
            }
            else if (txttask.Text.Length > 0)
            {
                    SqlCommand cmmd = new SqlCommand("spSearchTask", con);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "SELECT * FROM master WHERE client_task LIKE '%' + @ContactName + '%'";

                    cmmd.Connection = con;
                    cmmd.Parameters.AddWithValue("@fn", Session["loggedInUser"].ToString());
                    cmmd.Parameters.AddWithValue("@ct", txttask.Text.Trim());
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmmd))
                {
                    sda.Fill(dt);
                
                        if (dt.Rows.Count > 0)
                        {
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();

                            int i = 0;
                            foreach (GridViewRow row in gdvSearch.Rows)
                            {
                                if (row.Cells[7].Text.Contains("Pending"))
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    i = i + 1;
                                    row.ForeColor = System.Drawing.Color.Green;
                                    row.Cells[8].Controls.Clear();
                                    Image approveIcon = new Image();
                                    approveIcon.ImageUrl = "assets/logo/approve.png";
                                    approveIcon.ToolTip = "Approved Already";
                                    row.Cells[8].Controls.Add(approveIcon);
                                }
                            }

                        }
                        else
                        {
                            dt.Rows.Add(dt.NewRow());
                            gdvSearch.DataSource = dt;
                            gdvSearch.DataBind();
                            gdvSearch.Rows[0].Cells.Clear();
                            gdvSearch.Rows[0].Cells.Add(new TableCell());
                            gdvSearch.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                            gdvSearch.Rows[0].Cells[0].Text = "NO DATA FOUND IN DATABASE!!!";
                            gdvSearch.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                            gdvSearch.Rows[0].ForeColor = System.Drawing.Color.Red;
                        }
                        txttask.Text = "";
                       
                }
                    
            }
            else
            {
                //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>RemoveGRIDVIEWHeight('" +
                //gdvSearch.ClientID + "', 0); </script>", false);

                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();

                    SqlCommand cmmd = new SqlCommand("spSearchDefault", conn);
                    cmmd.CommandType = CommandType.StoredProcedure;
                    cmmd.Parameters.AddWithValue("@fn", Session["loggedInUser"].ToString());
                    SqlDataAdapter adp = new SqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    try
                    {
                        //gdvSearch.DataSourceID = null;
                        gdvSearch.DataSource = dt;
                        gdvSearch.DataBind();

                        int i = 0;
                        foreach (GridViewRow row in gdvSearch.Rows)
                        {
                            if (row.Cells[7].Text.Contains("Pending"))
                            {
                                i = i + 1;
                                row.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                i = i + 1;
                                row.ForeColor = System.Drawing.Color.Green;
                            }
                        }

                        foreach (GridViewRow row in gdvSearch.Rows)
                        {
                            //row.Cells[7].Text.Contains("Pending")
                          if (row.Cells[7].Text != "Pending")
                          {
                                row.Cells[8].Controls.Clear();
                                Image approveIcon = new Image();
                                approveIcon.ImageUrl = "assets/logo/approve.png";
                                    approveIcon.ToolTip = "Approved Already";
                                    row.Cells[8].Controls.Add(approveIcon);
                          }
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
}

//private void BindGrid()
//{
//    try
//    {

//        using (SqlConnection con = new SqlConnection(s))
//        {
//            SqlCommand cmd = new SqlCommand("masterEditTrail", con);
//            cmd.CommandType = CommandType.StoredProcedure;

//            SqlDataAdapter sqa = new SqlDataAdapter(cmd);
//            DataTable dt = new DataTable();
//            sqa.Fill(dt);

//            con.Open();
//            int value = (int)cmd.ExecuteNonQuery();
//            if (value == -1)
//            {
//                gdvSearch.DataSource = dt;
//                gdvSearch.DataBind();

//                //StringBuilder sb = new StringBuilder();
//                //sb.Append("<div class=\"table-wrapper-scroll-y my-custom-scrollbar dtHorizontalExampleWrapper mx-5 my-5\">");
//                //sb.Append("<table style=\"background-color:maroon\" class=\"table table-responsive table-bordered table-striped mb - 0\">");

//                ////Response.Write("<script>alert('Task Posted to Admin Successful...Check back later to see if you will be approved')</script>");

//                //sb.Append("<thead>");
//                //sb.Append("<tr>");
//                //foreach (DataColumn dtc in dt.Columns)
//                //{
//                //    sb.Append("<th>");
//                //    sb.Append(dtc.ColumnName.ToUpper());
//                //    sb.Append("</th>");
//                //}
//                //sb.Append("</tr>");
//                //sb.Append("</thead>");

//                //DataRow[] result = dt.Select();
//                ////selecting the records one by one by looping
//                //foreach (DataRow dr in result)
//                //{
//                //    sb.Append("<tr>");
//                //    foreach (DataColumn dtc in dt.Columns)
//                //    {
//                //        sb.Append("<th>");
//                //        sb.Append(dr[dtc.ColumnName].ToString());
//                //        sb.Append("</th>");
//                //    }

//                //    sb.Append("</tr>");
//                //}
//                ////end of selecting records one by one 
//                //sb.Append("</table>");
//                //sb.Append("</div>");
//                ////string savedID = sb.ToString();
//                ////ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('" + savedID + "');", true);
//                ////ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + savedID + "');", true);
//                //pnlstringBuilderShow.Controls.Add(new Label { Text = sb.ToString() });


//                con.Close();
//            }
//        }


//    }
//    catch (Exception ex)
//    {
//        //pnl_warning.Visible = true;
//        lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;

//    }
//}


public void gdvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
{
    totalperstaffrecordsabovegrid();
    ImageButton img = (ImageButton)e.Row.FindControl("imgB");
    if (img != null)
    {
        img.Attributes.Add("ROW_INDEX", e.Row.RowIndex.ToString());
            
    }

    if (e.Row.RowType == DataControlRowType.DataRow)
    {

        if (txtSearch.Text != "")
        {

            string seachtext = txtSearch.Text.Trim();
            int[] colsToCheck = new int[] { 1, 2, 3, 4, 5, 6, 7 };// columns to be searched [ zero based index ]
            for (int i = 0; i < colsToCheck.Length; i++)
            {
                int colIndex = colsToCheck[i];
                e.Row.Cells[colIndex].Text = Regex.Replace(e.Row.Cells[colIndex].Text, seachtext, delegate (Match match)
                {
                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);
                }, RegexOptions.IgnoreCase);
            }

        }
        else if (txtClient.Text != "")
        {
            string seachtext = txtClient.Text.Trim();
            // int[] colsToCheck = new int[] { 0, 1, 2 };  // columns to be searched [ zero based index ]
            int[] colsToCheck = new int[] { 1, 2, 4, 5, 6, 7 };
            for (int i = 0; i < colsToCheck.Length; i++)
            {
                int colIndex = colsToCheck[i];
                e.Row.Cells[colIndex].Text = Regex.Replace(e.Row.Cells[colIndex].Text, seachtext, delegate (Match match)
                {
                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);
                }, RegexOptions.IgnoreCase);
            }
        }
        else if (txtdateapplied.Text != "")
        {
            string seachtext = txtdateapplied.Text.Trim();
            // int[] colsToCheck = new int[] { 0, 1, 2 };  // columns to be searched [ zero based index ]
            int[] colsToCheck = new int[] { 1, 2, 4, 5, 6, 7 };
            for (int i = 0; i < colsToCheck.Length; i++)
            {
                int colIndex = colsToCheck[i];
                e.Row.Cells[colIndex].Text = Regex.Replace(e.Row.Cells[colIndex].Text, seachtext, delegate (Match match)
                {
                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);
                }, RegexOptions.IgnoreCase);
            }
        }
        else if (txtStaff.Text != "")
        {
            string seachtext = txtStaff.Text.Trim();
            // int[] colsToCheck = new int[] { 0, 1, 2 };  // columns to be searched [ zero based index ]
            int[] colsToCheck = new int[] { 1, 2, 4, 5, 6, 7 };
            for (int i = 0; i < colsToCheck.Length; i++)
            {
                int colIndex = colsToCheck[i];
                e.Row.Cells[colIndex].Text = Regex.Replace(e.Row.Cells[colIndex].Text, seachtext, delegate (Match match)
                {
                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);
                }, RegexOptions.IgnoreCase);
            }
        }
        else if (txtApprovedby.Text != "")
        {
            string seachtext = txtApprovedby.Text.Trim();
            // int[] colsToCheck = new int[] { 0, 1, 2 };  // columns to be searched [ zero based index ]
            int[] colsToCheck = new int[] { 1, 2, 4, 5, 6, 7 };
            for (int i = 0; i < colsToCheck.Length; i++)
            {
                int colIndex = colsToCheck[i];
                e.Row.Cells[colIndex].Text = Regex.Replace(e.Row.Cells[colIndex].Text, seachtext, delegate (Match match)
                {
                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);
                }, RegexOptions.IgnoreCase);
            }
        }
        else if (txttask.Text != "")
        {
            string seachtext = txttask.Text.Trim();
            // int[] colsToCheck = new int[] { 0, 1, 2 };  // columns to be searched [ zero based index ]
            int[] colsToCheck = new int[] { 1, 2, 4, 5, 6, 7 };
            for (int i = 0; i < colsToCheck.Length; i++)
            {
                int colIndex = colsToCheck[i];
                e.Row.Cells[colIndex].Text = Regex.Replace(e.Row.Cells[colIndex].Text, seachtext, delegate (Match match)
                {
                    return string.Format("<span style = 'background-color:yellow'>{0}</span>", match.Value);
                }, RegexOptions.IgnoreCase);
            }
        }

    }
}

protected void drpclientname_SelectedIndexChanged(object sender, EventArgs e)
{
    using (SqlConnection connect = new SqlConnection(s))
    {
        connect.Open();

        SqlCommand cam = new SqlCommand("spDropdownIndexValuePicked", connect);
        cam.CommandType = CommandType.StoredProcedure;
        cam.Parameters.AddWithValue("@clientnameselected", drpclientname.SelectedItem.Text);

        SqlDataAdapter aadp = new SqlDataAdapter(cam);
        DataTable dat = new DataTable();
        aadp.Fill(dat);
        try
        {
                if (dat.Rows.Count > 0)
                {
                    txtaddress.Text = dat.Rows[0]["location"].ToString();
                    txtclientfee.Text = dat.Rows[0]["amount"].ToString();

                    lblcp.Visible = true;
                    drpcontactperson.Visible = true;
                    txtaddress.ReadOnly = true;

                    SqlConnection coect = new SqlConnection(s);
                    SqlCommand camm = new SqlCommand("spPopulateContactDropdown", coect);
                    camm.CommandType = CommandType.StoredProcedure;
                    camm.Parameters.AddWithValue("@cn", drpclientname.SelectedItem.Text);
                    SqlDataAdapter ap = new SqlDataAdapter(camm);
                    DataTable daat = new DataTable();
                    ap.Fill(daat);

                    drpcontactperson.DataTextField = "contact_person";
                    drpcontactperson.DataValueField = "id";
                    drpcontactperson.DataSource = daat;
                    drpcontactperson.DataBind();

                    drpcontactperson.Items.Insert(0, "SELECT");
                    lblperson.Visible = false;
                    lblemail.Visible = false;
                   
                    FillGridPerStaff();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Client Has Not Been Registered!!! Contact Admin');", true);

                }
            //lblemail.Text = daat.Rows[0]["email"].ToString();
            //lblperson.Text = daat.Rows[0]["phone"].ToString();

            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>RemoveGRIDVIEWHeight('" +
            //       gdvSearch.ClientID + "', 0); </script>", false);

        }
        catch (Exception ex)
        {
                pnl_warning.Visible = true;
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
        }

    }


}

protected void drpcontactperson_SelectedIndexChanged(object sender, EventArgs e)
{
    SqlConnection coect = new SqlConnection(s);
        SqlCommand cam = new SqlCommand("spGetContactPersonPerClientChosen", coect);
        cam.CommandType = CommandType.StoredProcedure;
        cam.Parameters.AddWithValue("@cn", drpcontactperson.SelectedItem.Text);
       
   
    SqlDataAdapter ap = new SqlDataAdapter(cam);
    DataTable daat = new DataTable();
    ap.Fill(daat);

        if(daat.Rows.Count > 0)
        {
            lblemail.Visible = true;
            lblperson.Visible = true;
            lble.Visible = true;
            lblph.Visible = true;
            lblemail.Text = daat.Rows[0]["email"].ToString();
            lblperson.Text = daat.Rows[0]["phone"].ToString();
            lblcp.Visible = true;
            drpcontactperson.Visible = true;
            drptask.Visible = true;
            txtdate.Visible = true;
            Button1.Visible = true;
            FillGridPerStaff();
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Contact Does not exist | Has Not Been Registered!!! Contact Admin');", true);

        }

    }

protected void Button1_Click(object sender, EventArgs e)
{
    using (SqlConnection connect = new SqlConnection(s))
    {
            SqlConnection coect = new SqlConnection(s);
            SqlCommand cam = new SqlCommand("spMasterInsertSortPendingFirst", coect);
            cam.CommandType = CommandType.StoredProcedure;
            cam.Parameters.AddWithValue("@fn", Session["loggedInUser"]);
            cam.Parameters.AddWithValue("@cn", drpclientname.SelectedItem.Text);
            cam.Parameters.AddWithValue("@cl", txtaddress.Text);
            cam.Parameters.AddWithValue("@ca", txtclientfee.Text);
            cam.Parameters.AddWithValue("@ct", drptask.SelectedItem.Text);
            cam.Parameters.AddWithValue("@ad", txtdate.Text);

                coect.Open();

                int sus = cam.ExecuteNonQuery();
                try
                {

                    if (sus == 1)
                    {
                        FillGridPerStaff();

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Posted Successfully!!!');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Fill the necessary boxes!!!');", true);
                    }


                }
                catch (Exception ex)
                {
                    pnl_warning.Visible = true;
                    lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                } 
           
    }
}

protected void imgB_Click(object sender, ImageClickEventArgs e)
{
        int isdeleted = 0;
     
        int rowIndex = Convert.ToInt32(((ImageButton)sender).Attributes["ROW_INDEX"].ToString());

        int id = Convert.ToInt32(gdvSearch.DataKeys[rowIndex].Value);
        
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
                connect.Close();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Row Deleted Succesfully');", true);
                    //gdvSearch.DataSource = Session["MasterTableRecords"];
                    FillGridPerStaff();
                }

        }
        catch (Exception ex)
        {
                pnl_warning.Visible = true;
                lbl_warning.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
        }
    }
    //}
}

protected void link_loginout_Click(object sender, EventArgs e)
{
    if (link_loginout.Text == "Log out")
    {
        Response.Cookies["admin_cookies"].Expires = DateTime.Now.AddYears(-1);
        Session.Clear();
            Application.Lock();
            Application["TotalOnlineUsers"] = (int)Application["TotalOnlineUsers"] - 1;
            Application.UnLock();
            Response.Redirect("~/admin/Login.aspx");
    }
    else
    {
        link_loginout.Text = "Log in";
    }
}

    protected void gdvSearch_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int isdeleted = 0;
        //string id = gdvSearch.SelectedDataKey.Value.ToString();
        GridViewRow id = (GridViewRow)gdvSearch.Rows[e.RowIndex];
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
                    connect.Close();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showAlert", "alert('Row Deleted Succesfully');", true);
                    //gdvSearch.DataSource = Session["MasterTableRecords"];
                    FillGridPerStaff();
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