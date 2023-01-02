using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using ShoppingCart.BL;
using System.Web.UI.DataVisualization.Charting;
using System.Text;
using InfoSoftGlobal;

public partial class Pending_Accounts_Reasonwise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                try
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string UserID = cookie.Values["UserID"];
                    string UserName = cookie.Values["UserName"];
                    divErrormessage.Visible = false;
                    BindAcademicYear();
                    BindDivision();
                    

                    if (Request["Year"] != null)
                    {
                        string Year = Request["Year"];
                        ddlAcadYear.SelectedValue = Year;
                    }
                    if (Request["Division"] != null)
                    {                        
                        string Division = Request["Division"];
                        ddldivision.SelectedValue = Division;                        
                    }
                    BindCenter();
                    if (Request["Center"] != null)
                    {
                        string Center = Request["Center"];
                        ddlcenter.SelectedValue = Center;
                    }
                    lblPageNumber.Text = "1";

                    BindPendingAccounts_Reasonwise();
                }
                catch { }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;
        BindCenter();

    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //if (ddldivision.SelectedIndex == 0)
        //{
        //    BindCenter();
        //    ddlcenter.Items.Clear();
        //    ddlcenter.Items.Insert(0, "All");
        //    ddlcenter.SelectedIndex = 0;

        //}
        //else
        //{
            BindCenter();
            ddlcenter.SelectedIndex = 0;
            string year = ddlAcadYear.SelectedValue;
            string division = ddldivision.SelectedItem.Text;
            string divisioncode = ddldivision.SelectedValue;
            string centercode = ddlcenter.SelectedValue;
            lblPageNumber.Text = "1";
            BindPendingAccounts_Reasonwise();
            //BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
        //}
    }

    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", "MT");
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }

    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        BindPendingAccounts_Reasonwise();
        lblPageNumber.Text = "1";
        //BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
    }


    private void BindAcademicYear()
    {
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        ddlAcadYear.SelectedIndex = 0;
        //BindAccountSummary();
    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string year = ddlAcadYear.SelectedValue;
        lblPageNumber.Text = "1";
        BindPendingAccounts_Reasonwise();
    }

    private void BindPendingAccounts_Reasonwise()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string AcadYear = ddlAcadYear.SelectedValue;
        //string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        DataSet ds = ProductController.GetPendingAdmission_Reasonwise(UserID, AcadYear, divisioncode, centercode,lblPageNumber.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            divsearchresults.Visible = true;
            divErrormessage.Visible = false;

            dlPendingAccountReasonwise.DataSource = ds.Tables[0];
            dlPendingAccountReasonwise.DataBind();
            dlPendingAccountReasonwise.Visible = true;

            lblTotalPendingAccounts.Text = ds.Tables[0].Rows.Count.ToString();

            lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
            lblTotalPendingAccounts.Text = ds.Tables[2].Rows[0]["TotalRecords"].ToString();


            if (Convert.ToInt32(lblTotalPendingAccounts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                btnStud_NextRecord.Visible = true;
            else
                btnStud_NextRecord.Visible = false;

            if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                btnStud_PrevRecord.Visible = false;
            else
                btnStud_PrevRecord.Visible = true;
            
            //pnlSave2.Update();

            //foreach (RepeaterItem dtlItem in dlPendingAccountReasonwise.Items)
            foreach (DataListItem dtlItem in dlPendingAccountReasonwise.Items)            
            {
                Label lblPending_ReasonId = (Label)dtlItem.FindControl("lblPending_ReasonId");
                DropDownList ddlPending_Reason = (DropDownList)dtlItem.FindControl("ddlPending_Reason");

                ddlPending_Reason.DataSource = ds.Tables[1];
                ddlPending_Reason.DataTextField = "PendingReason";
                ddlPending_Reason.DataValueField = "PendingReason_Id";
                ddlPending_Reason.DataBind();

                ddlPending_Reason.Items.Insert(0, "Select");
                ddlPending_Reason.SelectedIndex = 0;

                ddlPending_Reason.SelectedValue = lblPending_ReasonId.Text;                
            }
        }
        else
        {
            dlPendingAccountReasonwise.Visible = false;
            divErrormessage.Visible = true;
            divsearchresults.Visible = false;
        }
    }
    //protected void dlPendingAccountReasonwise_ItemCommand(object source, RepeaterCommandEventArgs e)    
    protected void dlPendingAccountReasonwise_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)    
    {     
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        if (e.CommandName == "Save")
        {
            Label lblSuccess = (Label)e.Item.FindControl("lblSuccess");
            Label lblSBEntryCode = (Label)e.Item.FindControl("lblSBEntryCode");
            DropDownList ddlPending_Reason = (DropDownList)e.Item.FindControl("ddlPending_Reason");
            TextBox txtremarks = (TextBox)e.Item.FindControl("txtremarks");
            System.Web.UI.HtmlControls.HtmlInputText txtExpectedCloseDate = (System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("txtExpectedCloseDate");
            
            HtmlAnchor lbl_DLError = (HtmlAnchor)e.Item.FindControl("lbl_DLError");
            Panel icon_Error = (Panel)e.Item.FindControl("icon_Error");
            
            icon_Error.Visible = false;
            lblSuccess.Visible = false;

            if (ddlPending_Reason.SelectedIndex == 0)
            {
                lbl_DLError.Title = "Select Pending Reason";
                icon_Error.Visible = true;
                return;
            }
            if (txtExpectedCloseDate.Value == "")
            {
                lbl_DLError.Title = "Select Expected close date";
                icon_Error.Visible = true;
                return;
            }

            if (txtremarks.Text == "")
            {
                lbl_DLError.Title = "Enter Remark";
                icon_Error.Visible = true;
                return;
            }

            DataSet ds = ProductController.InsertUpdate_PendingAdmission_Reason(UserID, lblSBEntryCode.Text, ddlPending_Reason.SelectedValue, txtExpectedCloseDate.Value,txtremarks.Text);

            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["ErrorSaveFlag"].ToString() == "-1")//if any error come
                {
                    lbl_DLError.Title = ds.Tables[0].Rows[0]["ErroSaveMessage"].ToString();
                    icon_Error.Visible = true;
                    return;
                }
                else  //Save message
                {
                    lblSuccess.Visible = true;
                    lblSuccess.Text = ds.Tables[0].Rows[0]["ErroSaveMessage"].ToString();
                }
            }
        }
    }

    //protected void Button_Click(object sender, EventArgs e)
    //{
    //    //Get the reference of the clicked button.
    //    Button button = (sender as Button);

    //    //Get the command argument
    //    string commandArgument = button.CommandArgument;

    //    //Get the Repeater Item reference
    //    RepeaterItem item = button.NamingContainer as RepeaterItem;

    //    //Get the repeater item index
    //    //int index = item.ItemIndex;
        

    //}

    protected void btnStud_NextRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
            BindPendingAccounts_Reasonwise();    
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void btnStud_PrevRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
            BindPendingAccounts_Reasonwise();    
        }
        catch (Exception ex)
        {
            
        }
    }
    











}