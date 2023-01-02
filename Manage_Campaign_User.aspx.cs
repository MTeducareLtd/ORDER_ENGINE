using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Configuration;

public partial class Manage_Campaign_User : System.Web.UI.Page
{
    DataTable dtCorrectEntry = new DataTable();
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");
                BindCampaign();
                //BindCampaignDetail();
                //ddlCampaignTypeSearch_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = ex.ToString();
            }
        }
    }

    #region Events



    protected void dlStudContact_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            
            Label lblConId = (Label)e.Item.FindControl("lblConId");            
            Label lblCampaignID = (Label)e.Item.FindControl("lblCampaignID");
            Label lblConCenterFlag = (Label)e.Item.FindControl("lblConCenterFlag");
            Label lblLead_Code = (Label)e.Item.FindControl("lblLead_Code");
            Label lblOpp_Code = (Label)e.Item.FindControl("lblOpp_Code");

            if (lblConCenterFlag.Text=="1")
            {
                ((HtmlAnchor)e.Item.FindControl("btnConvertToLead")).HRef = "ContactCenter_Convert_Contact_To_Lead.aspx?&Con_id=" + lblConId.Text + "&Campaign_Id=" + lblCampaignID.Text;
                ((HtmlAnchor)e.Item.FindControl("btnConvertToOpportunity")).HRef = "ContactCenter_Convert_Lead_To_Opportunity.aspx?&Lead_Code=" + lblLead_Code.Text;
                ((HtmlAnchor)e.Item.FindControl("btnorder")).HRef = "ContactCenter_Manage_Order.aspx?&Opportunity_Code=" + lblOpp_Code.Text;
            }
            else
            {
                ((HtmlAnchor)e.Item.FindControl("btnConvertToLead")).HRef = "Convert_Contact_To_Lead.aspx?&Con_id=" + lblConId.Text + "&Campaign_Id=" + lblCampaignID.Text;
                ((HtmlAnchor)e.Item.FindControl("btnConvertToOpportunity")).HRef = "Convert_Lead_To_Opportunity.aspx?&Lead_Code=" + lblLead_Code.Text;
                ((HtmlAnchor)e.Item.FindControl("btnorder")).HRef = "Manage_Order.aspx?&Opportunity_Code=" + lblOpp_Code.Text;
            }
            //e.Item.BackColor = System.Drawing.Color.LightGreen;
            //e.Item.Attributes.Add("cssclass", "green");
        }
    }

    //protected void btnContactsSave_Click(object sender, EventArgs e)
    //{
    //    Clear_Error_Success_Box();
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string Contacts_Id_Add = "",RowNum="";

    //    foreach (DataListItem item in dlStudContact.Items)
    //    {
    //        CheckBox chk1 = (CheckBox)item.FindControl("chk1");
    //        Label lblConId = (Label)item.FindControl("lblConId");
    //        Label lblRowNum = (Label)item.FindControl("lblRowNum");
    //        if (chk1.Checked == true)
    //        {
    //            Contacts_Id_Add = Contacts_Id_Add + lblConId.Text + ",";
    //        }           
    //        RowNum = lblRowNum.Text ;
    //    }

    //    if (Contacts_Id_Add == "")
    //    {
    //        Show_Error_Success_Box("E", "Select Atleast one Contacts");
    //        return;
    //    }
        
    //    DataSet ds = ProductController.Insert_UPdate_Campaign_Contacts("1", lblPkey.Text, Contacts_Id_Add, UserID);

    //    if (btnStud_NextRecord.Visible == true)
    //    {
    //        btnStud_NextRecord_ServerClick(sender, e);
    //    }
    //    else if (btnStud_PrevRecord.Visible == true)
    //    {
    //        btnStud_PrevRecord_ServerClick(sender, e);
    //    }
    //    else
    //    {
    //        divResultContact.Visible = false;
    //    }

    //    Show_Error_Success_Box("S", "Contacts Add successfully for this Campaign");
        
    //    //if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(RowNum))
    //    //{
    //    //    btnStud_NextRecord_ServerClick(sender, e);
    //    //}
    //    //else
    //    //{

    //    //}
    //}


    //protected void ddlCampaignTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    DataSet ds = ProductController.GetUser_Role_Campaign(8, UserID, ddlCampaignTypeSearch.SelectedValue, "");
    //    ddlCampaign.DataSource = ds.Tables[0];
    //    ddlCampaign.DataTextField = "Camp_Name";
    //    ddlCampaign.DataValueField = "Campaign_Id";
    //    ddlCampaign.DataBind();
    //    ddlCampaign.Items.Insert(0, "Select");
    //    ddlCampaign.SelectedIndex = 0;
    //}

    protected void btnCloseSearchCriteria_ServerClick(object sender, System.EventArgs e)
    {
        ControlVisibility("Result");
        Clear_Error_Success_Box();
    }

    protected void btnStud_NextRecord_ServerClick(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
                
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        //PageNumber = PageNumber + 1;
        lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();

        DataSet ds = ProductController.Get_Campaign_Assigned_Student(1, UserID, "", ddlCampaign.SelectedValue, txtstudentnamesearch.Text.Trim(),txthandphonesearch.Text.Trim(), txtInstitutionName.Text.Trim(),lblPageNumber.Text);
        dlStudContact.DataSource = ds.Tables[0];
        dlStudContact.DataBind();
        pnltimer.Update();
        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();

        //foreach (DataList row in dlStudContact.Row)
        //if (Convert.ToInt32(row.Cells[7].Value) < Convert.ToInt32(row.Cells[10].Value))
        //{
        //    row.DefaultCellStyle.BackColor = Color.Red;
        //}

        if (ds.Tables[0].Rows.Count > 0)
        {            
            lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
            lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

            if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                btnStud_NextRecord.Visible = true;
            else
                btnStud_NextRecord.Visible = false;

            if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                btnStud_PrevRecord.Visible = false;
            else
                btnStud_PrevRecord.Visible = true;
        }
        else
        {
            lblActualRecordCount.Text = "0";
            lblTotalContacts.Text = "0";
            lblTotalContacts2.Text = "Contacts Total No of Records: 0" ;
            btnStud_NextRecord.Visible = false;           
            btnStud_PrevRecord.Visible = false;
            Show_Error_Success_Box("E", "Contacts Not Found");
            return;
        }        
    }

    protected void btnStud_PrevRecord_ServerClick(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();         
        

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
        DataSet ds = ProductController.Get_Campaign_Assigned_Student(1, UserID, "", ddlCampaign.SelectedValue,txtstudentnamesearch.Text.Trim(),txthandphonesearch.Text.Trim(),txtInstitutionName.Text.Trim(), lblPageNumber.Text);
        dlStudContact.DataSource = ds.Tables[0];
        dlStudContact.DataBind();
        pnltimer.Update();
        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
            lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

            if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                btnStud_NextRecord.Visible = true;
            else
                btnStud_NextRecord.Visible = false;

            if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                btnStud_PrevRecord.Visible = false;
            else
                btnStud_PrevRecord.Visible = true;
        }
        else
        {
            lblActualRecordCount.Text = "0";
            lblTotalContacts.Text = "0";
            lblTotalContacts2.Text = "Contacts Total No of Records: 0";
            btnStud_NextRecord.Visible = false;
            btnStud_PrevRecord.Visible = false;
            Show_Error_Success_Box("E", "Contacts Not Found");
            return;
        }
    }


    protected void chkAllStud_CheckedChanged(object sender, EventArgs e)
    {
        //int rowcount=

        try
        {
            CheckBox s = sender as CheckBox;
            foreach (DataListItem dtlItem in dlStudContact.Items)
            {
                CheckBox chk1 = (CheckBox)dtlItem.FindControl("chk1");
                chk1.Checked = s.Checked;
            }
            Clear_Error_Success_Box();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }


    protected void btnContactsBack_Click(object sender, EventArgs e)
    {
       // divSearchContact.Visible = true;
        divResultContact.Visible = false;

    }

    

    

   
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }
    protected void btnSearchByNameHandphone_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        //PageNumber = PageNumber + 1;
        lblPageNumber.Text = "1";

        DataSet ds = ProductController.Get_Campaign_Assigned_Student(1, UserID, "", ddlCampaign.SelectedValue, txtstudentnamesearch.Text.Trim(), txthandphonesearch.Text.Trim(), txtInstitutionName.Text.Trim(), "1");
        if (ds.Tables[0].Rows.Count > 0)
        {
        dlStudContact.DataSource = ds.Tables[0];
        dlStudContact.DataBind();
        pnltimer.Update();
        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();

        lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
        lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
        lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

        if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
            btnStud_NextRecord.Visible = true;
        else
            btnStud_NextRecord.Visible = false;

        if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
            btnStud_PrevRecord.Visible = false;
        else
            btnStud_PrevRecord.Visible = true;
        }
        else
        {
            Show_Error_Success_Box("E", "Contacts Not Found");
            return;
        }        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (ddlCampaignTypeSearch.SelectedIndex == 0)
        //{
        //    Show_Error_Success_Box("E","Select Campaign Type");
        //    return;
        //}

        if (ddlCampaign.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Campaign");
            return;
        }
        txtstudentnamesearch.Text = "";
        txthandphonesearch.Text = "";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds = ProductController.Get_Campaign_Assigned_Student(1, UserID, "", ddlCampaign.SelectedValue, "","","","1");

        if (ds.Tables[0].Rows.Count > 0)
        {
            ControlVisibility("Result");

            lblCampaignID.Text = ddlCampaign.SelectedValue;
            dlStudContact.DataSource = ds.Tables[0];
            dlStudContact.DataBind();
            pnltimer.Update();
            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();

            lblPageNumber.Text = "1";
            lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblTotalAssignedCampaignContacts_Result.Text = ds.Tables[3].Rows[0]["Campaign_AssignedContacts"].ToString();
            lblTotalAssignedContactsUser_Result.Text = ds.Tables[3].Rows[0]["AssignedContactsUser"].ToString();
            lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
            btnStud_PrevRecord.Visible = false;
            if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                btnStud_NextRecord.Visible = true;
            else
                btnStud_NextRecord.Visible = false;


            lblCampaignType_Result.Text = ds.Tables[2].Rows[0]["Camp_Type"].ToString();
            lblCampaignName_Result.Text = ds.Tables[2].Rows[0]["Camp_Name"].ToString();
            lblCampaignStatus_Result.Text = ds.Tables[2].Rows[0]["CampaignStatus"].ToString();
            lblTargetAudience_Result.Text = ds.Tables[2].Rows[0]["Target_Audience"].ToString();
            lblCampSponsor_Result.Text = ds.Tables[2].Rows[0]["Campaign_Sponsor"].ToString();
            lblCampSponsoDesc_Result.Text = ds.Tables[2].Rows[0]["Sponsor_Description"].ToString();
            lblExpectedCloseDate_Result.Text = ds.Tables[2].Rows[0]["ExpectedCloseDate"].ToString();
        }
        else
        {
            Show_Error_Success_Box("E", "Contacts not assign to this Campaign");
            return;
        }

    }

    protected void btnRefreshCon_ServerClick(object sender, System.EventArgs e)
    {
        refreshGrid_studentAssign();
    }
    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }

    protected void dlStudContact_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Enroll")
            {
                //System.Threading.Thread.Sleep(100)
                string Opportunity_Code = e.CommandArgument.ToString();
                //string Opportunityid = e.CommandArgument.ToString();
                lbloppurid.Text = Opportunity_Code;
                //Response.Redirect("Enrollment.aspx?&Opportunity_Code=" + Opportunity_Code);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("$('#Div1').modal('show');");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
            return;
        }
    }

    protected void btnyes_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Oppurid = "";
        string Enrollon = "";
        //string studentid = "";
        //int flag = 0;
        Oppurid = lbloppurid.Text;
        Enrollon = txtappsubmitdate.Value;
        //flag = 4;
        //ProductController.Block(UserID, Oppurid, flag);
        string Student_id = ClsEnrollment.enrollstudent1(Enrollon, UserID, Oppurid, "");
        refreshGrid_studentAssign();
    }

    protected void btnno_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Blocklead').modal('hide') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Div1').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);        
    }
    protected void ddlCampaignTypeAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    
    
    protected void btnCloseAssign_Click(object sender, EventArgs e)
    {
        ControlVisibility("Result");
    }

    protected void btnStud_AddToCampaign_ServerClick(object sender, System.EventArgs e)
    {
        string PreLeadId = "";
        //foreach (DataListItem dtlItem in dlGridDisplay_Pending.Items)
        //{
        //    CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
        //    Label lblStudentPreLeadID = (Label)dtlItem.FindControl("lblStudentPreLeadID");
        //    if (chkitemck.Checked == true)
        //    {
        //        PreLeadId = PreLeadId + lblStudentPreLeadID.Text + ",";
        //    }
        //}
        if (PreLeadId == "")
        {
            Show_Error_Success_Box("E", "Select Atleast One Student...!");
            return;
        }

        PreLeadId = Common.RemoveComma(PreLeadId);


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        DataSet ds = ProductController.Insert_Delete_Campaign_Contact(1, UserID, lblPkey.Text, PreLeadId);
        //if (ds != null)
        //{
        //    Clear_Error_Success_Box();
        //    dlGridDisplay_Pending.DataSource = ds.Tables[0];
        //    dlGridDisplay_Pending.DataBind();
        //    lblPendingRecCnt.Text = ds.Tables[0].Rows.Count.ToString();

        //    dlGridDisplay_Selected.DataSource = ds.Tables[1];
        //    dlGridDisplay_Selected.DataBind();
        //    lblCurrentRecCnt.Text = ds.Tables[1].Rows.Count.ToString();
        //}
    }

    protected void btnStud_RemoveFromCampaign_ServerClick(object sender, System.EventArgs e)
    {
        string PreLeadId = "";
        //foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
        //{
        //    CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
        //    Label lblStudentPreLeadID = (Label)dtlItem.FindControl("lblStudentPreLeadID");
        //    if (chkitemck.Checked == true)
        //    {
        //        PreLeadId = PreLeadId + lblStudentPreLeadID.Text + ",";
        //    }
        //}
        if (PreLeadId == "")
        {
            Show_Error_Success_Box("E", "Select Atleast One Student...!");
            return;
        }

        PreLeadId = Common.RemoveComma(PreLeadId);


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        DataSet ds = ProductController.Insert_Delete_Campaign_Contact(2, UserID, lblPkey.Text, PreLeadId);
        //if (ds != null)
        //{
        //    Clear_Error_Success_Box();
        //    dlGridDisplay_Pending.DataSource = ds.Tables[0];
        //    dlGridDisplay_Pending.DataBind();
        //    lblPendingRecCnt.Text = ds.Tables[0].Rows.Count.ToString();

        //    dlGridDisplay_Selected.DataSource = ds.Tables[1];
        //    dlGridDisplay_Selected.DataBind();
        //    lblCurrentRecCnt.Text = ds.Tables[1].Rows.Count.ToString();
        //}
    }

    public void All_Student_ChkBox_Selected(object sender, System.EventArgs e)
    {
        ////Change checked status of a hidden check box
        //chkStudentAllHidden.Checked = !(chkStudentAllHidden.Checked);

        ////Set checked status of hidden check box to items in grid
        //foreach (DataListItem dtlItem in dlGridDisplay_Pending.Items)
        //{
        //    CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");

        //    chkitemck.Checked = chkStudentAllHidden.Checked;
        //}

    }

    public void All_Student_ChkBox_Selected_Sel(object sender, System.EventArgs e)
    {
        ////Change checked status of a hidden check box
        //chkStudentAllHidden_Sel.Checked = !(chkStudentAllHidden_Sel.Checked);

        ////Set checked status of hidden check box to items in grid
        //foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
        //{
        //    CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");

        //    chkitemck.Checked = chkStudentAllHidden_Sel.Checked;
        //}

    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        
        DataSet ds = ProductController.Get_Campaign_Assigned_Student(1, UserID, "", ddlCampaign.SelectedValue, txtstudentnamesearch.Text.Trim(), txthandphonesearch.Text.Trim(),txtInstitutionName.Text.Trim(), lblPageNumber.Text);
        dlStudContact.DataSource = ds.Tables[0];
        dlStudContact.DataBind();
        pnltimer.Update();
        

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
            lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

            if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                btnStud_NextRecord.Visible = true;
            else
                btnStud_NextRecord.Visible = false;

            if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                btnStud_PrevRecord.Visible = false;
            else
                btnStud_PrevRecord.Visible = true;
        }
        else
        {
            lblActualRecordCount.Text = "0";
            lblTotalContacts.Text = "0";
            lblTotalContacts2.Text = "Contacts Total No of Records: 0";
            btnStud_NextRecord.Visible = false;
            btnStud_PrevRecord.Visible = false;
            
            return;
        }
    }

    #endregion

    #region Function
    private void refreshGrid_studentAssign()
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            //PageNumber = PageNumber + 1;

            DataSet ds = ProductController.Get_Campaign_Assigned_Student(1, UserID, "", ddlCampaign.SelectedValue, txtstudentnamesearch.Text.Trim(), txthandphonesearch.Text.Trim(),txtInstitutionName.Text.Trim(), lblPageNumber.Text);
            dlStudContact.DataSource = ds.Tables[0];
            dlStudContact.DataBind();
            pnltimer.Update();
            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
                lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

                if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                    btnStud_NextRecord.Visible = true;
                else
                    btnStud_NextRecord.Visible = false;

                if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                    btnStud_PrevRecord.Visible = false;
                else
                    btnStud_PrevRecord.Visible = true;
            }
            else
            {
                lblActualRecordCount.Text = "0";
                lblTotalContacts.Text = "0";
                lblTotalContacts2.Text = "Contacts Total No of Records: 0";
                btnStud_NextRecord.Visible = false;
                btnStud_PrevRecord.Visible = false;
                Show_Error_Success_Box("E", "Contacts Not Found");
                return;
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivSearch.Visible = true;
           // DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            //DivAssignStudent.Visible = false;
            //BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = false;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
        if (Mode == "Add")
        {
            DivSearch.Visible = false;
           // DivAddPanel.Visible = true;
            DivResultPanel.Visible = false;
            //DivAssignStudent.Visible = false;
           // BtnAdd.Visible = false;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;

            //Clear Add Panel
            
            //for (int cnt = 0; cnt <= ddlCampaignDataSourceAdd.Items.Count - 1; cnt++)
            //{
            //    if (ddlCampaignDataSourceAdd.Items[cnt].Selected == true)
            //    {
            //        ddlCampaignDataSourceAdd.Items[cnt].Selected = false;
            //    }
            //}
            
            //txtResourceStartDate.Value = "";
            //txtResourceEndDate.Value = "";
            //txtSourceAdd.Text = "";
            //txtResourceAproxCoastAdd.Text = "";
        }
        if (Mode == "Result")
        {
            DivSearch.Visible = false;
            //DivAddPanel.Visible = false;
            DivResultPanel.Visible = true;
            //DivAssignStudent.Visible = false;
            //BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
        if (Mode == "AssignStudent")
        {
            DivSearch.Visible = false;
           // DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            //DivAssignStudent.Visible = true;
           // BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
    }

    private void BindCampaign()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds = ProductController.GetUser_Role_Campaign(8, UserID, "", "","","");
        ddlCampaign.DataSource = ds.Tables[0];
        ddlCampaign.DataTextField = "Camp_Name";
        ddlCampaign.DataValueField = "Campaign_Id";
        ddlCampaign.DataBind();
        ddlCampaign.Items.Insert(0, "Select");
        ddlCampaign.SelectedIndex = 0;
    }


    /// <summary>
    /// Show Error or success box on top base on boxtype and Error code
    /// </summary>
    /// <param name="BoxType">BoxType</param>
    /// <param name="Error_Code">Error_Code</param>
    private void Show_Error_Success_Box(string BoxType, string Error_Code)
    {
        if (BoxType == "E")
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
        else
        {
            Msg_Success.Visible = true;
            Msg_Error.Visible = false;
            lblSuccess.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
    }

    /// <summary>
    /// Clear Error Success Box
    /// </summary>
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    /// <summary>
    /// Fill List box and assign value and Text
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="ds"></param>
    /// <param name="txtField"></param>
    /// <param name="valField"></param>
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    


    //private void BindCampaignDetail()
    //{        
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];

    //    DataSet ds = ProductController.GetUser_Role_Campaign(1, UserID,"","");

        //ddlCampaignTypeAdd.DataSource = ds.Tables[0];
        //ddlCampaignTypeAdd.DataTextField = "Desc";
        //ddlCampaignTypeAdd.DataValueField = "ID";
        //ddlCampaignTypeAdd.DataBind();
        //ddlCampaignTypeAdd.Items.Insert(0, "Select");
        //ddlCampaignTypeAdd.SelectedIndex = 0;

        //ddlCampaignTypeSearch.DataSource = ds.Tables[0];
        //ddlCampaignTypeSearch.DataTextField = "Desc";
        //ddlCampaignTypeSearch.DataValueField = "ID";
        //ddlCampaignTypeSearch.DataBind();
        //ddlCampaignTypeSearch.Items.Insert(0, "Select");
        //ddlCampaignTypeSearch.SelectedIndex = 0;
        

        //ddlCampaignStatusAdd.DataSource = ds.Tables[1];
        //ddlCampaignStatusAdd.DataTextField = "Desc";
        //ddlCampaignStatusAdd.DataValueField = "ID";
        //ddlCampaignStatusAdd.DataBind();
        //ddlCampaignStatusAdd.Items.Insert(0, "Select");
        //ddlCampaignStatusAdd.SelectedIndex = 0;

        //ddlCampaignSponsorAdd.DataSource = ds.Tables[2];
        //ddlCampaignSponsorAdd.DataTextField = "Desc";
        //ddlCampaignSponsorAdd.DataValueField = "ID";
        //ddlCampaignSponsorAdd.DataBind();
        //ddlCampaignSponsorAdd.Items.Insert(0, "Select");
        //ddlCampaignSponsorAdd.SelectedIndex = 0;


        //ddlCampaignOwnerAdd.DataSource = ds.Tables[3];
        //ddlCampaignOwnerAdd.DataTextField = "User_Display_Name";
        //ddlCampaignOwnerAdd.DataValueField = "User_Code";
        //ddlCampaignOwnerAdd.DataBind();
        //ddlCampaignOwnerAdd.Items.Insert(0, "Select");
        //ddlCampaignOwnerAdd.SelectedIndex = 0;

        //ddlAssignedToAdd.DataSource = ds.Tables[3];
        //ddlAssignedToAdd.DataTextField = "User_Display_Name";
        //ddlAssignedToAdd.DataValueField = "User_Code";
        //ddlAssignedToAdd.DataBind();

        //ddlCampaignDataSourceAdd.DataSource = ds.Tables[4];
        //ddlCampaignDataSourceAdd.DataTextField = "Import_File_Name";
        //ddlCampaignDataSourceAdd.DataValueField = "Import_Run_No";
        //ddlCampaignDataSourceAdd.DataBind();

        //ddlRoleAdd.DataSource = ds.Tables[5];
        //ddlRoleAdd.DataTextField = "Role";
        //ddlRoleAdd.DataValueField = "Role_Id";
        //ddlRoleAdd.DataBind();
        //ddlRoleAdd.Items.Insert(0, "Select");
        //ddlRoleAdd.SelectedIndex = 0;

        //DataSet ds1 = ds.Tables[0].ToString();
        //BindDDL(ddlCampaignTypeAdd, ds, "Zone_Name", "Zone_Code");
    //}

    protected string setClass(int CallStatus)
    {
        string classToApply = string.Empty;
        if (CallStatus == 1)
        {
            classToApply = "~/Images/Processing.gif";
        }
        else if (CallStatus == 2)
        {
            classToApply = "~/Images/Processing.gif";
        }
        else
            classToApply = "~/Images/Processing.gif";
        return classToApply;
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int quantity = int.Parse(e.Row.Cells[0].Text);

            foreach (TableCell cell in e.Row.Cells)
            {
                if (quantity == 1)
                {
                    cell.BackColor = System.Drawing.Color.Red;
                }
                if (quantity > 0 && quantity <= 50)
                {
                    cell.BackColor = System.Drawing.Color.Yellow;
                }
                //if (quantity > 50 && quantity <= 100)
                //{
                //    cell.BackColor = Color.Orange;
                //}
            }
        }
    }

    #endregion







}