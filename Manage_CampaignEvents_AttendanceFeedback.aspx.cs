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

public partial class Manage_CampaignEvents_AttendanceFeedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");
                //BindCampaign();
                BindAcademicYear();
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
    
    protected void btnCloseSearchCriteria_ServerClick(object sender, System.EventArgs e)
    {
        ControlVisibility("Result");
        Clear_Error_Success_Box();
    }
       
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (ddlCampaign.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Campaign");
            return;
        }

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        
        DataSet ds = ProductController.Get_CampaignDetailByPKey(6, UserID, ddlCampaign.SelectedValue);
        if (ds.Tables[1].Rows.Count > 0)
        {
            ControlVisibility("Result");
            
            lblCampaignType_Result1.Text = ds.Tables[0].Rows[0]["Camp_Type"].ToString();
            lblCampaignName_Result1.Text = ds.Tables[0].Rows[0]["Camp_Name"].ToString();
            lblCampaignStatus_Result1.Text = ds.Tables[0].Rows[0]["CampaignStatus"].ToString();
            lblTargetAudience_Result1.Text = ds.Tables[0].Rows[0]["Target_Audience"].ToString();
            lblCampSponsor_Result1.Text = ds.Tables[0].Rows[0]["Campaign_Sponsor"].ToString();
            lblCampSponsoDesc_Result1.Text = ds.Tables[0].Rows[0]["Sponsor_Description"].ToString();
            lblExpectedCloseDate_Result1.Text = ds.Tables[0].Rows[0]["ExpectedCloseDate"].ToString();
            lblTotalAssignedCampaignContacts_Result1.Text = ds.Tables[0].Rows[0]["TotalCampaignContacts"].ToString();

            dlCampaignEvents.DataSource = ds.Tables[1];
            dlCampaignEvents.DataBind();
        }
        else
        {
            //Show_Error_Success_Box("E", "No Events found for this Campaign.");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'No Events found for this Campaign',class_name: 'gritter-error'});});</script>", false);
            return;
        }

    }

    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }
       
    protected void btnCloseAssign_Click(object sender, EventArgs e)
    {
        ControlVisibility("Result");
        Clear_Error_Success_Box();
    }

    protected void chkAttendanceAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlEventAttendance.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            chkitemck.Checked = s.Checked;
        }
        Clear_Error_Success_Box();
    }

    protected void dlCampaignEvents_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        Clear_Error_Success_Box();
        Label lblCampaignId = (Label)e.Item.FindControl("lblCampaignId");

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        if (e.CommandName == "Event_Attendance")
        {
            DataSet ds = ProductController.Get_CampaignEvents_Contacts(3, UserID, "", "", "", "", "0", lblCampaignId.Text, e.CommandArgument.ToString());

            if (ds.Tables[1].Rows.Count > 0)
            {
                ControlVisibility("EventAttendance");

                lblCampaignEventName.Text = ds.Tables[0].Rows[0]["Event_Name"].ToString();
                lblCampaignEventPeriod.Text = ds.Tables[0].Rows[0]["CampaignEventPeriodDesc"].ToString();

                dlEventAttendance.DataSource = ds.Tables[1];
                dlEventAttendance.DataBind();
            }
            else
            {
                //Show_Error_Success_Box("E", "Contacts not found for this Campaign Event");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Contacts not found for this Campaign Event',class_name: 'gritter-error'});});</script>", false);
                return;
            }
        }//End of if (e.CommandName == "Event_Attendance")
        else if (e.CommandName == "Event_Feedback")
        {
            DataSet ds = ProductController.Get_CampaignEvents_Contacts(4, UserID, "", "", "", "", "0", lblCampaignId.Text, e.CommandArgument.ToString());

            if (ds.Tables[1].Rows.Count > 1)
            {
                ControlVisibility("EventFeedback");

                lblCampaignEventName1.Text = ds.Tables[0].Rows[0]["Event_Name"].ToString();
                lblCampaignEventPeriod1.Text = ds.Tables[0].Rows[0]["CampaignEventPeriodDesc"].ToString();

                dlEventFeedback.DataSource = ds.Tables[1];
                dlEventFeedback.DataBind();

                int i = 0;
                string FeedbackId1 = "", FeedbackId2 = "", FeedbackId3 = "";

                foreach (DataListItem dtlItem in dlEventFeedback.Items)
                {
                    Label lblCampaignEventId = (Label)dtlItem.FindControl("lblCampaignEventId");
                    Label lblCampaignFeedback1 = (Label)dtlItem.FindControl("lblCampaignFeedback1");
                    Label lblCampaignFeedbackID1 = (Label)dtlItem.FindControl("lblCampaignFeedbackID1");
                    DropDownList ddlFeedBackValue1 = (DropDownList)dtlItem.FindControl("ddlFeedBackValue1");
                    Label lblCampaignFeedbackValue1 = (Label)dtlItem.FindControl("lblCampaignFeedbackValue1");
                    Label lblCampaignFeedback2 = (Label)dtlItem.FindControl("lblCampaignFeedback2");
                    Label lblCampaignFeedbackID2 = (Label)dtlItem.FindControl("lblCampaignFeedbackID2");
                    DropDownList ddlFeedBackValue2 = (DropDownList)dtlItem.FindControl("ddlFeedBackValue2");
                    Label lblCampaignFeedbackValue2 = (Label)dtlItem.FindControl("lblCampaignFeedbackValue2");
                    Label lblCampaignFeedback3 = (Label)dtlItem.FindControl("lblCampaignFeedback3");
                    Label lblCampaignFeedbackID3 = (Label)dtlItem.FindControl("lblCampaignFeedbackID3");
                    DropDownList ddlFeedBackValue3 = (DropDownList)dtlItem.FindControl("ddlFeedBackValue3");
                    Label lblCampaignFeedbackValue3 = (Label)dtlItem.FindControl("lblCampaignFeedbackValue3");


                    if (i == 0)
                    {
                        lblCampaignFeedback1.Visible = true;
                        lblCampaignFeedback2.Visible = true;
                        lblCampaignFeedback3.Visible = true;
                        ddlFeedBackValue1.Visible = false;
                        ddlFeedBackValue2.Visible = false;
                        ddlFeedBackValue3.Visible = false;

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            lblCampaignFeedback1.Text = ds.Tables[2].Rows[0]["Feedback_Header"].ToString();
                            lblCampaignFeedbackID1.Text = ds.Tables[2].Rows[0]["Campaign_Event_Feedback_Id"].ToString();
                            FeedbackId1 = lblCampaignFeedbackID1.Text;
                        }
                        if (ds.Tables[2].Rows.Count > 1)
                        {
                            lblCampaignFeedback2.Text = ds.Tables[2].Rows[1]["Feedback_Header"].ToString();
                            lblCampaignFeedbackID2.Text = ds.Tables[2].Rows[1]["Campaign_Event_Feedback_Id"].ToString();
                            FeedbackId2 = lblCampaignFeedbackID2.Text;
                        }
                        if (ds.Tables[2].Rows.Count > 2)
                        {
                            lblCampaignFeedback3.Text = ds.Tables[2].Rows[2]["Feedback_Header"].ToString();
                            lblCampaignFeedbackID3.Text = ds.Tables[2].Rows[2]["Campaign_Event_Feedback_Id"].ToString();
                            FeedbackId3 = lblCampaignFeedbackID3.Text;
                        }
                    }
                    else
                    {
                        DataSet dsFeedbackValue = null;
                        if ((FeedbackId1 != "") && (FeedbackId1 != "0"))
                        {
                            lblCampaignFeedbackID1.Text = FeedbackId1;
                            dsFeedbackValue = GetFeedbackValueDetail(lblCampaignEventId.Text, lblCampaignId.Text, FeedbackId1);

                            ddlFeedBackValue1.DataSource = dsFeedbackValue.Tables[0];
                            ddlFeedBackValue1.DataTextField = "CampaignEventFeedbackValue";
                            ddlFeedBackValue1.DataValueField = "FeedbackValueId";
                            ddlFeedBackValue1.DataBind();

                            ddlFeedBackValue1.Items.Insert(0, "Select");
                            ddlFeedBackValue1.SelectedIndex = 0;

                            if ((lblCampaignFeedbackValue1.Text != "") && (lblCampaignFeedbackValue1.Text != "0"))
                            {
                                ddlFeedBackValue1.SelectedValue = lblCampaignFeedbackValue1.Text;
                            }
                        }
                        else
                        {
                            ddlFeedBackValue1.Items.Insert(0, "Select");
                            ddlFeedBackValue1.SelectedIndex = 0;
                            ddlFeedBackValue1.Visible = false;
                        }
                        //Second Feedback Header
                        if ((FeedbackId2 != "") && (FeedbackId2 != "0"))
                        {
                            lblCampaignFeedbackID2.Text = FeedbackId2;
                            dsFeedbackValue = GetFeedbackValueDetail(lblCampaignEventId.Text, lblCampaignId.Text, FeedbackId2);

                            ddlFeedBackValue2.DataSource = dsFeedbackValue.Tables[0];
                            ddlFeedBackValue2.DataTextField = "CampaignEventFeedbackValue";
                            ddlFeedBackValue2.DataValueField = "FeedbackValueId";
                            ddlFeedBackValue2.DataBind();

                            ddlFeedBackValue2.Items.Insert(0, "Select");
                            ddlFeedBackValue2.SelectedIndex = 0;

                            if ((lblCampaignFeedbackValue2.Text != "") && (lblCampaignFeedbackValue2.Text != "0"))
                            {
                                ddlFeedBackValue2.SelectedValue = lblCampaignFeedbackValue2.Text;
                            }
                        }
                        else
                        {
                            ddlFeedBackValue2.Items.Insert(0, "Select");
                            ddlFeedBackValue2.SelectedIndex = 0;
                            ddlFeedBackValue2.Visible = false;
                        }
                        //Third Feedback Header
                        if ((FeedbackId3 != "") && (FeedbackId3 != "0"))
                        {
                            lblCampaignFeedbackID3.Text = FeedbackId3;

                            dsFeedbackValue = GetFeedbackValueDetail(lblCampaignEventId.Text, lblCampaignId.Text, FeedbackId3);

                            ddlFeedBackValue3.DataSource = dsFeedbackValue.Tables[0];
                            ddlFeedBackValue3.DataTextField = "CampaignEventFeedbackValue";
                            ddlFeedBackValue3.DataValueField = "FeedbackValueId";
                            ddlFeedBackValue3.DataBind();

                            ddlFeedBackValue3.Items.Insert(0, "Select");
                            ddlFeedBackValue3.SelectedIndex = 0;

                            if ((lblCampaignFeedbackValue3.Text != "") && (lblCampaignFeedbackValue3.Text != "0"))
                            {
                                ddlFeedBackValue3.SelectedValue = lblCampaignFeedbackValue3.Text;
                            }
                        }
                        else
                        {
                            ddlFeedBackValue3.Items.Insert(0, "Select");
                            ddlFeedBackValue3.SelectedIndex = 0;
                            ddlFeedBackValue3.Visible = false;
                        }
                    }

                    //ddlFeedBack.DataSource = ds.Tables[2];
                    //ddlFeedBack.DataTextField = "Feedback_Header";
                    //ddlFeedBack.DataValueField = "Campaign_Event_Feedback_Id";
                    //ddlFeedBack.DataBind();

                    //ddlFeedBack.Items.Insert(0, "Select");
                    //ddlFeedBack.SelectedIndex = 0;

                    //ddlFeedBack.SelectedValue = lblCampaignFeedbackd.Text;
                    i++;
                }
            }
            else
            {
                //Show_Error_Success_Box("E", "Contacts not found for this Campaign Event");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Contacts not found for this Campaign Event',class_name: 'gritter-error'});});</script>", false);
                return;
            }
        }//End of if (e.CommandName == "Event_Feedback")
    }
    
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ddlCampaign.SelectedIndex = 0;
        Clear_Error_Success_Box();
    }

    protected void BtnCloseAttendance_Click(object sender, EventArgs e)
    {
        ControlVisibility("Result");
        Clear_Error_Success_Box();
    }
    protected void BtnCloseFeedback_Click(object sender, EventArgs e)
    {
        ControlVisibility("Result");
        Clear_Error_Success_Box();
    }

    protected void btnAllStudAttend_Save_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        string XMLData = "<EventAttendances>",AttendStatus="";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        foreach (DataListItem dtlItem in dlEventAttendance.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            Label lblCampaignId = (Label)dtlItem.FindControl("lblCampaignId");
            Label lblCampaignEventId = (Label)dtlItem.FindControl("lblCampaignEventId");
            Label lblCon_Id = (Label)dtlItem.FindControl("lblCon_Id");

            if (chkitemck.Checked == true)
                AttendStatus = "P";
            else
                AttendStatus = "A";

            XMLData = XMLData + "<EventStudAttendance><CampaignId>" + lblCampaignId.Text + "</CampaignId><CampaignEventId>" + lblCampaignEventId.Text + "</CampaignEventId><Con_Id>" + lblCon_Id.Text + "</Con_Id><AttendStatus>" + AttendStatus + "</AttendStatus><UserID>" + UserID + "</UserID></EventStudAttendance>";
        }

        XMLData =XMLData + "</EventAttendances>";

        DataSet ds = ProductController.Insert_UPdate_CampaignEvents_Student_Attendance_Feedback("1", XMLData);

        if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() == "1")
        {
            Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
            return;
        }
        else
        {
            Show_Error_Success_Box("E", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
            return;
        }

    }

    protected void ddlFeedBack_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlList = (DropDownList)sender;
        DataListItem row = (DataListItem)ddlList.NamingContainer;

        Label lblCampaignId = (Label)row.FindControl("lblCampaignId");
        Label lblCampaignEventId = (Label)row.FindControl("lblCampaignEventId");
        DropDownList ddlFeedBack = (DropDownList)row.FindControl("ddlFeedBack");
        DropDownList ddlFeedBackValue = (DropDownList)row.FindControl("ddlFeedBackValue");

        if (!string.IsNullOrEmpty(ddlFeedBack.SelectedValue))
        {
            ////Bind Feedback  Vale           
            DataSet dsFeedbackValue = GetFeedbackValueDetail(lblCampaignEventId.Text, lblCampaignId.Text, ddlFeedBack.SelectedValue);

            ddlFeedBackValue.DataSource = dsFeedbackValue.Tables[0];
            ddlFeedBackValue.DataTextField = "CampaignEventFeedbackValue";
            ddlFeedBackValue.DataValueField = "FeedbackValueId";
            ddlFeedBackValue.DataBind();

            ddlFeedBackValue.Items.Insert(0, "Select");
            ddlFeedBackValue.SelectedIndex = 0;
        }
    }
    protected void btnAllStudFeed_Save_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        string XMLData = "<EventFeedback>", AttendStatus = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int ErrorRecord = 0, SaveRecord = 0, i=0;
        string FeedbackId1 = "", FeedbackValue1 = "", FeedbackId2 = "", FeedbackValue2 = "", FeedbackId3 = "", FeedbackValue3 = "";

        foreach (DataListItem dtlItem in dlEventFeedback.Items)
        {
            Label lblCampaignId = (Label)dtlItem.FindControl("lblCampaignId");
            Label lblCampaignEventId = (Label)dtlItem.FindControl("lblCampaignEventId");
            Label lblCon_Id = (Label)dtlItem.FindControl("lblCon_Id");
            Label lblCampaignFeedbackID1 = (Label)dtlItem.FindControl("lblCampaignFeedbackID1");
            DropDownList ddlFeedBackValue1 = (DropDownList)dtlItem.FindControl("ddlFeedBackValue1");
            Label lblCampaignFeedbackID2 = (Label)dtlItem.FindControl("lblCampaignFeedbackID2");
            DropDownList ddlFeedBackValue2 = (DropDownList)dtlItem.FindControl("ddlFeedBackValue2");
            Label lblCampaignFeedbackID3 = (Label)dtlItem.FindControl("lblCampaignFeedbackID3");
            DropDownList ddlFeedBackValue3 = (DropDownList)dtlItem.FindControl("ddlFeedBackValue3");

            if (i == 0)
            {
                FeedbackId1 = lblCampaignFeedbackID1.Text;
                FeedbackId2 = lblCampaignFeedbackID2.Text;
                FeedbackId3 = lblCampaignFeedbackID3.Text;
            }
            else
            {
                FeedbackValue1 = "";
                FeedbackValue2 = "";
                FeedbackValue3 = "";                

                if (ddlFeedBackValue1.SelectedIndex != 0)
                {
                    FeedbackValue1 = ddlFeedBackValue1.SelectedValue;
                }
                if (ddlFeedBackValue2.SelectedIndex != 0)
                {
                    FeedbackValue2 = ddlFeedBackValue2.SelectedValue;
                }
                if (ddlFeedBackValue3.SelectedIndex != 0)
                {
                    FeedbackValue3 = ddlFeedBackValue3.SelectedValue;
                }

                XMLData = XMLData + "<EventStudFeedback><CampaignId>" + lblCampaignId.Text + "</CampaignId><CampaignEventId>" + lblCampaignEventId.Text + "</CampaignEventId><Con_Id>" + lblCon_Id.Text + "</Con_Id><FeedBackId1>" + FeedbackId1 + "</FeedBackId1><FeedBackValue1>" + FeedbackValue1 + "</FeedBackValue1><FeedBackId2>" + FeedbackId2 + "</FeedBackId2><FeedBackValue2>" + FeedbackValue2 + "</FeedBackValue2><FeedBackId3>" + FeedbackId3 + "</FeedBackId3><FeedBackValue3>" + FeedbackValue3 + "</FeedBackValue3><UserID>" + UserID + "</UserID></EventStudFeedback>";
            }
            i++;
        }

        XMLData = XMLData + "</EventFeedback>";

        if (XMLData == "<EventFeedback></EventFeedback>")
        {
            return;
        }

        DataSet ds = ProductController.Insert_UPdate_CampaignEvents_Student_Attendance_Feedback("2", XMLData);

        if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() == "1")
        {            
            Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
            return;
        }
        else
        {
            Show_Error_Success_Box("E", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
            return;
        }

    }

    #endregion

    #region Function

    private static DataSet GetFeedbackValueDetail(string EventId, string CampaignId, string FeedbackId)
    {
        return ProductController.Get_CampaignFeedbackValueByPKey(7, "", CampaignId, EventId, FeedbackId);
    }
  
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivSearch.Visible = true;
            DivResultPanel.Visible = false;
            BtnShowSearchPanel.Visible = false;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }        
        else if (Mode == "Result")
        {
            DivSearch.Visible = false;
            DivResultPanel.Visible = true;
            divEventDetail.Visible = true;
            divEventAttendance.Visible = false;
            divEventFeedback.Visible = false;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
        else if (Mode == "EventAttendance")
        {
            divEventAttendance.Visible = true;            
            divEventFeedback.Visible = false;
            divEventDetail.Visible = false;
        }
        else if (Mode == "EventFeedback")
        {
            divEventAttendance.Visible = false;            
            divEventFeedback.Visible = true;
            divEventDetail.Visible = false;
        }
    }

    private void BindCampaign()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds = ProductController.GetUser_Role_Campaign(8, UserID, "", "",ddlAcadYear.SelectedValue,"");
        ddlCampaign.DataSource = ds.Tables[0];
        ddlCampaign.DataTextField = "Camp_Name";
        ddlCampaign.DataValueField = "Campaign_Id";
        ddlCampaign.DataBind();
        ddlCampaign.Items.Insert(0, "Select");
        ddlCampaign.SelectedIndex = 0;
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        ddlAcadYear.Items.Insert(0, "Select");
        ddlAcadYear.SelectedIndex = 0;
        //BindDDL(ddlAddAcadYear, ds, "Acad_Year", "Acad_Year");
        //ddlAddAcadYear.Items.Insert(0, "Select");
        //ddlAddAcadYear.SelectedIndex = 0;
        //BindDDL(DDLAcadYear_seruch, ds, "Acad_Year", "Acad_Year");
        //DDLAcadYear_seruch.Items.Insert(0, "Select");
        //DDLAcadYear_seruch.SelectedIndex = 0;

    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindCampaign();
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
        
    #endregion       
}