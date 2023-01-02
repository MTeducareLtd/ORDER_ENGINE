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


public partial class Campaign_Events : System.Web.UI.Page
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
                string CampaignId = Request["CampaignId"];
                lblCampaignId.Text = CampaignId;
                CampaignDetail(lblCampaignId.Text);
                BindConDivision();
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

    protected void dlGridEvents_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {               
        Label lblCampaignEventName = (Label)e.Item.FindControl("lblCampaignEventName");
        Label lblDLCampaignEventPeriod = (Label)e.Item.FindControl("lblDLCampaignEventPeriod");
        Label lblDLAttendance = (Label)e.Item.FindControl("lblDLAttendance");
        Label lblDLFeedBack = (Label)e.Item.FindControl("lblDLFeedBack");

        TextBox txtCampaignEventName = (TextBox)e.Item.FindControl("txtCampaignEventName");
        System.Web.UI.HtmlControls.HtmlInputText txtCampaignEventPeriod = (System.Web.UI.HtmlControls.HtmlInputText)e.Item.FindControl("txtCampaignEventPeriod");
        CheckBox chkAttendance = (CheckBox)e.Item.FindControl("chkAttendance");
        CheckBox chkFeedBack = (CheckBox)e.Item.FindControl("chkFeedBack");

        HtmlAnchor lbl_DLError = (HtmlAnchor)e.Item.FindControl("lbl_DLError");
        LinkButton lnkDLEdit = (LinkButton)e.Item.FindControl("lnkDLEdit");
        LinkButton lnkDLSave = (LinkButton)e.Item.FindControl("lnkDLSave");
        //LinkButton lnkDLFeedback = (LinkButton)e.Item.FindControl("lnkDLFeedback");
        LinkButton lnkDLAddStudent_Events = (LinkButton)e.Item.FindControl("lnkDLAddStudent_Events");
                
        Panel icon_Error = (Panel)e.Item.FindControl("icon_Error");
        icon_Error.Visible = false;

        if (e.CommandName == "Save")
        {
            if (txtCampaignEventName.Text == "")
            {
                lbl_DLError.Title = "Enter Campaign event name";
                icon_Error.Visible = true;
                return;
            }
            if (txtCampaignEventPeriod.Value == "")
            {
                lbl_DLError.Title = "Enter Campaign event period";
                icon_Error.Visible = true;
                return;
            }
            string AttendanceFlag = "0", FeedbackFlag = "0";
            if (chkAttendance.Checked == true)
            {
                AttendanceFlag = "1";
            }
            if (chkFeedBack.Checked == true)
            {
                FeedbackFlag = "1";
            }

            string CampaignEventPeriod = "", CampaignEvent_SDate = "", CampaignEvent_EDate = "";
            CampaignEventPeriod = txtCampaignEventPeriod.Value;
            CampaignEvent_SDate = CampaignEventPeriod.Substring(0, 10);
            CampaignEvent_EDate = CampaignEventPeriod.Substring(13, 10);

            //
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = ProductController.InsertUpdate_CampaignEvents("1", UserID, lblCampaignId.Text, e.CommandArgument.ToString(), txtCampaignEventName.Text,
                        CampaignEvent_SDate, CampaignEvent_EDate, AttendanceFlag, FeedbackFlag);

            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["ErrorSaveFlag"].ToString() == "-1")
                {
                    lbl_DLError.Title = ds.Tables[0].Rows[0]["ErroSaveMessage"].ToString();
                    icon_Error.Visible = true;
                    return;
                }
                else
                {
                    CampaignDetail(lblCampaignId.Text);
                }
            }
        }//end if (e.CommandName == "Save")
        else if (e.CommandName == "Edit")
        {
            txtCampaignEventName.Visible = true;
            txtCampaignEventPeriod.Visible = true;
            chkAttendance.Visible = true;
            chkFeedBack.Visible = true;
            lnkDLSave.Visible = true;

            lblCampaignEventName.Visible = false;
            lblDLCampaignEventPeriod.Visible = false;
            lblDLAttendance.Visible = false;
            lblDLFeedBack.Visible = false;
            lnkDLEdit.Visible = false;
            //lnkDLFeedback.Visible = false;
            lnkDLAddStudent_Events.Visible = false;

        }//end else if (e.CommandName == "Edit")
        else if (e.CommandName == "AddStudent_Event")
        {
            lblEventName.Text = lblCampaignEventName.Text;
            lblEventPeriod.Text = lblDLCampaignEventPeriod.Text;
            lblCampaignEventId.Text = e.CommandArgument.ToString();

            //dtCorrectEntry = null;
            var _with1 = dtCorrectEntry;
            _with1.Columns.Add("ColumnName");
            _with1.Columns.Add("Condition");
            _with1.Columns.Add("Value");
            _with1.Columns.Add("RowNumber");
            _with1.Columns.Add("Operator");
            _with1.Columns.Add("CenterCode");
            _with1.Columns.Add("Div_Code");
            _with1.Columns.Add("Stream_Code");

            i = 0;
            //DataRow NewRow = null;
            //NewRow = dtCorrectEntry.NewRow();
            //NewRow["ColumnValue"] = "";
            //NewRow["RowNumber"] = "";

            // dtCorrectEntry.Rows.Add(NewRow);
            dlFillData.DataSource = dtCorrectEntry;
            dlFillData.DataBind();

            divCampaignEventAllDetail.Visible = false;
            DivAssignStudentForCampaignToEvent.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;

            divSearchContact.Visible = true;
            divResultContact.Visible = false;

            btnReset_Click(source, e);
            optAllCriteria.Checked = true;
            optAnyCriteria.Checked = false;
            lblPageNumber.Text = "1";
            GetAllCampaignAssignedContacts();

        }//end else if (e.CommandName == "AddStudent_Event")
    }

    protected void dlGridEvents_Feedback_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        Label lblCampaignFeedbackId = (Label)e.Item.FindControl("lblCampaignFeedbackId");
        Label lblCampaignEventName = (Label)e.Item.FindControl("lblCampaignEventName");
        DropDownList ddlEvent = (DropDownList)e.Item.FindControl("ddlEvent");
        TextBox txtCampaignEventFeedback = (TextBox)e.Item.FindControl("txtCampaignEventFeedback");
        Label lblDLCampaignEventFeedback = (Label)e.Item.FindControl("lblDLCampaignEventFeedback");

        HtmlAnchor lbl_DLError = (HtmlAnchor)e.Item.FindControl("lbl_DLError");
        LinkButton lnkDLEdit = (LinkButton)e.Item.FindControl("lnkDLEdit");
        LinkButton lnkDLSave = (LinkButton)e.Item.FindControl("lnkDLSave");

        Panel icon_Error = (Panel)e.Item.FindControl("icon_Error");
        icon_Error.Visible = false;

        if (e.CommandName == "Save")
        {
            if (ddlEvent.SelectedIndex == 0)
            {
                lbl_DLError.Title = "Select Event";
                icon_Error.Visible = true;
                return;
            }

            if (txtCampaignEventFeedback.Text.Trim() == "")
            {
                lbl_DLError.Title = "Enter Feedback Header";
                icon_Error.Visible = true;
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = ProductController.InsertUpdate_CampaignEvents_Feedback("1", UserID, lblCampaignId.Text,ddlEvent.SelectedValue,e.CommandArgument.ToString(),txtCampaignEventFeedback.Text);

            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["ErrorSaveFlag"].ToString() == "-1")
                {
                    lbl_DLError.Title = ds.Tables[0].Rows[0]["ErroSaveMessage"].ToString();
                    icon_Error.Visible = true;
                    return;
                }
                else
                {
                    CampaignDetail(lblCampaignId.Text); 
                }
            }

        }//end if (e.CommandName == "Save")
        else if (e.CommandName == "Edit")
        {
            ddlEvent.Visible = true;
            txtCampaignEventFeedback.Visible = true;
            lnkDLSave.Visible = true;

            lblCampaignEventName.Visible = false;
            lblDLCampaignEventFeedback.Visible = false;
            lnkDLEdit.Visible = false;
        }//end else if (e.CommandName == "Edit")
    }

    protected void dlGridEvents_FeedbackValue_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {

        Label lblCampaignFeedbackValueId = (Label)e.Item.FindControl("lblCampaignFeedbackValueId");
        Label lblCampaignFeedbackId = (Label)e.Item.FindControl("lblCampaignFeedbackId");
        Label lblCampaignEventName = (Label)e.Item.FindControl("lblCampaignEventName");
        Label lblDLCampaignEventFeedback = (Label)e.Item.FindControl("lblDLCampaignEventFeedback");
        Label lblDLCampaignEventFeedbackValue = (Label)e.Item.FindControl("lblDLCampaignEventFeedbackValue");
        DropDownList ddlEvent = (DropDownList)e.Item.FindControl("ddlEvent");
        DropDownList ddlFeedBack = (DropDownList)e.Item.FindControl("ddlFeedBack");
        TextBox txtCampaignEventFeedbackValue = (TextBox)e.Item.FindControl("txtCampaignEventFeedbackValue");
        

        HtmlAnchor lbl_DLError = (HtmlAnchor)e.Item.FindControl("lbl_DLError");
        LinkButton lnkDLEdit = (LinkButton)e.Item.FindControl("lnkDLEdit");
        LinkButton lnkDLSave = (LinkButton)e.Item.FindControl("lnkDLSave");

        Panel icon_Error = (Panel)e.Item.FindControl("icon_Error");
        icon_Error.Visible = false;

        if (e.CommandName == "Save")
        {
            if (ddlEvent.SelectedIndex == 0)
            {
                lbl_DLError.Title = "Select Event";
                icon_Error.Visible = true;
                return;
            }

            if (ddlFeedBack.SelectedIndex == 0)
            {
                lbl_DLError.Title = "Select Feedback";
                icon_Error.Visible = true;
                return;
            }

            if (txtCampaignEventFeedbackValue.Text.Trim() == "")
            {
                lbl_DLError.Title = "Enter Feedback Value";
                icon_Error.Visible = true;
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = ProductController.InsertUpdate_CampaignEvents_Feedback_Values("1", UserID, lblCampaignId.Text, ddlEvent.SelectedValue, ddlFeedBack.SelectedValue ,e.CommandArgument.ToString(), txtCampaignEventFeedbackValue.Text);

            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["ErrorSaveFlag"].ToString() == "-1")
                {
                    lbl_DLError.Title = ds.Tables[0].Rows[0]["ErroSaveMessage"].ToString();
                    icon_Error.Visible = true;
                    return;
                }
                else
                {
                    CampaignDetail(lblCampaignId.Text);
                }
            }

        }//end if (e.CommandName == "Save")
        else if (e.CommandName == "Edit")
        {
            ddlEvent.Visible = true;
            ddlFeedBack.Visible = true;
            txtCampaignEventFeedbackValue.Visible = true;
            lnkDLSave.Visible = true;

            lblCampaignEventName.Visible = false;
            lblDLCampaignEventFeedback.Visible = false;
            lblDLCampaignEventFeedbackValue.Visible = false;
            lnkDLEdit.Visible = false;
        }//end else if (e.CommandName == "Edit")
    }

    protected void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlList = (DropDownList)sender;
        DataListItem row = (DataListItem)ddlList.NamingContainer;

        DropDownList ddlEvent = (DropDownList)row.FindControl("ddlEvent");
        DropDownList ddlFeedBack = (DropDownList)row.FindControl("ddlFeedBack");

        if (!string.IsNullOrEmpty(ddlEvent.SelectedValue)) 
        {
            ////Bind Feedback             
            DataSet dsFeedback = GetFeedbackDetail(ddlEvent.SelectedValue, lblCampaignId.Text);

            ddlFeedBack.DataSource = dsFeedback.Tables[0];
            ddlFeedBack.DataTextField = "Feedback_Header";
            ddlFeedBack.DataValueField = "Campaign_Event_Feedback_Id";
            ddlFeedBack.DataBind();

            ddlFeedBack.Items.Insert(0, "Select");
            ddlFeedBack.SelectedIndex = 0;
        }
    }

    protected void btnCloseSearchCriteria_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
           // ControlVisibility("Result");
            DivAssignStudentForCampaignToEvent.Visible = false;
            divCampaignEventAllDetail.Visible = true;

            Clear_Error_Success_Box();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnCloseCampaignEvent_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            Response.Redirect("Campaign_Detail.aspx");
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void ddlColumnNames_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        try
        {
            ddlValue.Enabled = true;
            trAcadYear.Visible = false;
            trDivision.Visible = false;
            trCenter.Visible = false;
            trStream.Visible = false;
            BindAll_Condition();
            if (ddlColumnNames.SelectedValue == "Contact_Source")
            {
                txtValue.Visible = false;
                ddlValue.Visible = true;
                ContactSource();
            }
            else if (ddlColumnNames.SelectedValue == "Contact_Type")
            {
                txtValue.Visible = false;
                ddlValue.Visible = true;
                ddlValue.Enabled = false;
                ContactType();
            }
            else if (ddlColumnNames.SelectedValue == "Customer_Type")
            {
                txtValue.Visible = false;
                ddlValue.Visible = true;
                CustomerType();
            }
            else if (ddlColumnNames.SelectedValue == "Standard")
            {
                txtValue.Visible = false;
                ddlValue.Visible = true;
                Current_Studying();
            }
            else if (ddlColumnNames.SelectedValue == "Year_Of_Passing")
            {
                txtValue.Visible = false;
                ddlValue.Visible = true;
                Yearofpassing();
            }
            else if (ddlColumnNames.SelectedValue == "Excel_Upload")
            {
                txtValue.Visible = false;
                ddlValue.Visible = true;
                GetExcelName();
            }
            else if (ddlColumnNames.SelectedValue == "Contacts")
            {
                txtValue.Visible = false;
                ddlValue.Visible = true;
                trAcadYear.Visible = true;
                trDivision.Visible = true;
                trCenter.Visible = true;
                trStream.Visible = false;
                GetContacts();
                BindContacts_Condition();
            }
            else
            {
                txtValue.Visible = true;
                ddlValue.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void ddlValue_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        try
        {

            if ((ddlValue.SelectedValue == "Account") || (ddlValue.SelectedValue == "Opportunity"))
            {
                trStream.Visible = true;
            }
            else
            {
                trStream.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    protected void btnContactsSave_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            
            string Contacts_Id_Add = "", XMLData = "<EventContact>";
            
            foreach (DataListItem item in dlStudContact.Items)
            {
                CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                Label lblConId = (Label)item.FindControl("lblConId");
                Label lblRecord_No = (Label)item.FindControl("lblRecord_No");
                Label lblRowNum = (Label)item.FindControl("lblRowNum");

                if ((chk1.Checked == true) && (chk1.Visible == true))
                {
                    Contacts_Id_Add = Contacts_Id_Add + lblConId.Text + ",";
                    XMLData = XMLData + "<AssignEventContacts><Campaign_Event_Id>" + lblCampaignEventId.Text + "</Campaign_Event_Id><Contact_Id>" + lblConId.Text + "</Contact_Id><Record_No>" + lblRecord_No.Text + "</Record_No></AssignEventContacts>";
                }
            }

            if (Contacts_Id_Add == "")
            {
                // Show_Error_Success_Box("E", "Select Atleast one Contacts");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Atleast one Contacts',class_name: 'gritter-error'});});</script>", false);
                // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Select Atleast one Contacts');", true);
                return;
            }

            XMLData = XMLData + "</EventContact>";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = ProductController.Insert_UPdate_Campaign_Events_Contacts_Assignment("1", lblCampaignId.Text, XMLData, UserID);

            

            if (btnStud_NextRecord.Visible == true)
            {
                lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
                btnStud_NextRecord_ServerClick(sender, e);
            }
            else if (btnStud_PrevRecord.Visible == true)
            {
                lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
                btnStud_PrevRecord_ServerClick(sender, e);
            }
            else
            {
                string Operator = "";
                //divResultContact.Visible = false;
                foreach (DataListItem item in dlFillData.Items)
                {
                    Operator = "1";
                }

                if (Operator == "")
                {
                    GetAllCampaignAssignedContacts();
                }
                else
                {
                    btnFindContacts_Click(sender, e);
                }
                
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() == "1")
                    Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
                else
                    Show_Error_Success_Box("E", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
            }

            //if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(RowNum))
            //{
            //    btnStud_NextRecord_ServerClick(sender, e);
            //}
            //else
            //{

            //}
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnFindContacts_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            string Opearator1 = "", ColName = "", Opearator2 = "", Value = "";

            foreach (DataListItem item in dlFillData.Items)
            {
                Label lblOperator = (Label)item.FindControl("lblOperator");
                Label lblColName = (Label)item.FindControl("lblColName");
                Label lblCondition = (Label)item.FindControl("lblCondition");
                Label lblValue = (Label)item.FindControl("lblValue");
                Label lblRowNumber = (Label)item.FindControl("lblRowNumber");
                Label lblCenterCode = (Label)item.FindControl("lblCenterCode");
                Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                Label lblStreamCode = (Label)item.FindControl("lblStreamCode");
                Opearator1 = Opearator1 + lblOperator.Text + ",";
                ColName = ColName + lblColName.Text + ",";
                Opearator2 = Opearator2 + lblCondition.Text + ",";
                if (lblColName.Text == "Contacts")
                {
                    if (lblValue.Text.Substring(0, 4) == "Lead")
                    {
                        Value = Value + lblValue.Text.Substring(0, 45) + lblCenterCode.Text + "',";
                    }
                    else if (lblValue.Text.Substring(0, 11) == "Opportunity")
                    {
                        if (lblStreamCode.Text == "All")
                        {
                            Value = Value + lblValue.Text.Substring(0, 52) + lblCenterCode.Text + "',";
                        }
                        else
                        {
                            Value = Value + lblValue.Text.Substring(0, 52) + lblCenterCode.Text + "' and StreamCode='" + lblStreamCode.Text + "',";
                        }
                    }
                    else if (lblValue.Text.Substring(0, 7) == "Account")
                    {
                        if (lblStreamCode.Text == "All")
                        {
                            Value = Value + lblValue.Text.Substring(0, 48) + lblCenterCode.Text + "',";
                        }
                        else
                        {
                            Value = Value + lblValue.Text.Substring(0, 48) + lblCenterCode.Text + "' and StreamCode='" + lblStreamCode.Text + "',";
                        }

                    }
                }
                else
                {
                    Value = Value + lblValue.Text + ",";
                }
            }

            if (Opearator1 == "")
            {
                Show_Error_Success_Box("E", "First Select Search Criteria");
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            lblPageNumber.Text = "1";
            DataSet ds = ProductController.Get_CampaignEvents_Contacts(1, UserID, Value, Opearator2, ColName, Opearator1, lblPageNumber.Text, lblCampaignId.Text, lblCampaignEventId.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //divSearchContact.Visible = false;
                divResultContact.Visible = true;
                dlStudContact.DataSource = ds.Tables[0];
                dlStudContact.DataBind();
                lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
                btnStud_PrevRecord.Visible = false;
                if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                    btnStud_NextRecord.Visible = true;
                else
                    btnStud_NextRecord.Visible = false;
            }
            else
            {
                Show_Error_Success_Box("E", "Contacts Not Found");
                return;
            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }


    protected void btnStud_NextRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            string Opearator1 = "", ColName = "", Opearator2 = "", Value = "";

            foreach (DataListItem item in dlFillData.Items)
            {
                Label lblOperator = (Label)item.FindControl("lblOperator");
                Label lblColName = (Label)item.FindControl("lblColName");
                Label lblCondition = (Label)item.FindControl("lblCondition");
                Label lblValue = (Label)item.FindControl("lblValue");
                Label lblRowNumber = (Label)item.FindControl("lblRowNumber");
                Label lblCenterCode = (Label)item.FindControl("lblCenterCode");
                Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                Label lblStreamCode = (Label)item.FindControl("lblStreamCode");

                Opearator1 = Opearator1 + lblOperator.Text + ",";
                ColName = ColName + lblColName.Text + ",";
                Opearator2 = Opearator2 + lblCondition.Text + ",";
                if (lblColName.Text == "Contacts")
                {
                    if (lblValue.Text.Substring(0, 4) == "Lead")
                    {
                        Value = lblValue.Text.Substring(0, 45) + lblCenterCode.Text + "'";
                    }
                    else if (lblValue.Text.Substring(0, 11) == "Opportunity")
                    {
                        if (lblStreamCode.Text == "All")
                        {
                            Value = Value + lblValue.Text.Substring(0, 52) + lblCenterCode.Text + "',";
                        }
                        else
                        {
                            Value = Value + lblValue.Text.Substring(0, 52) + lblCenterCode.Text + "' and StreamCode='" + lblStreamCode.Text + "',";
                        }
                    }
                    else if (lblValue.Text.Substring(0, 7) == "Account")
                    {
                        if (lblStreamCode.Text == "All")
                        {
                            Value = Value + lblValue.Text.Substring(0, 48) + lblCenterCode.Text + "',";
                        }
                        else
                        {
                            Value = Value + lblValue.Text.Substring(0, 48) + lblCenterCode.Text + "' and StreamCode='" + lblStreamCode.Text + "',";
                        }

                    }
                }
                else
                {
                    Value = Value + lblValue.Text + ",";
                }
            }

            if (Opearator1 == "")
            {
                lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
                GetAllCampaignAssignedContacts();                
                //Show_Error_Success_Box("E", "First Select Search Criteria");
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            //PageNumber = PageNumber + 1;
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
            //DataSet ds = ProductController.Get_Campaign_Contacts(1, UserID, Value, Opearator2, ColName, Opearator1, lblPageNumber.Text, lblPkey.Text);
            DataSet ds = ProductController.Get_CampaignEvents_Contacts(1, UserID, Value, Opearator2, ColName, Opearator1, lblPageNumber.Text, lblCampaignId.Text, lblCampaignEventId.Text);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            dlStudContact.DataSource = ds.Tables[0];
            dlStudContact.DataBind();
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
            //}
            //else
            //{
            //    Show_Error_Success_Box("E", "Contacts Not Found");
            //    return;
            //}        
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnStud_PrevRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            string Opearator1 = "", ColName = "", Opearator2 = "", Value = "";

            foreach (DataListItem item in dlFillData.Items)
            {
                Label lblOperator = (Label)item.FindControl("lblOperator");
                Label lblColName = (Label)item.FindControl("lblColName");
                Label lblCondition = (Label)item.FindControl("lblCondition");
                Label lblValue = (Label)item.FindControl("lblValue");
                Label lblRowNumber = (Label)item.FindControl("lblRowNumber");
                Label lblCenterCode = (Label)item.FindControl("lblCenterCode");
                Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                Label lblStreamCode = (Label)item.FindControl("lblStreamCode");

                Opearator1 = Opearator1 + lblOperator.Text + ",";
                ColName = ColName + lblColName.Text + ",";
                Opearator2 = Opearator2 + lblCondition.Text + ",";
                if (lblColName.Text == "Contacts")
                {
                    if (lblValue.Text.Substring(0, 4) == "Lead")
                    {
                        Value = lblValue.Text.Substring(0, 45) + lblCenterCode.Text + "'";
                    }
                    else if (lblValue.Text.Substring(0, 11) == "Opportunity")
                    {
                        if (lblStreamCode.Text == "All")
                        {
                            Value = Value + lblValue.Text.Substring(0, 52) + lblCenterCode.Text + "',";
                        }
                        else
                        {
                            Value = Value + lblValue.Text.Substring(0, 52) + lblCenterCode.Text + "' and StreamCode='" + lblStreamCode.Text + "',";
                        }
                    }
                    else if (lblValue.Text.Substring(0, 7) == "Account")
                    {
                        if (lblStreamCode.Text == "All")
                        {
                            Value = Value + lblValue.Text.Substring(0, 48) + lblCenterCode.Text + "',";
                        }
                        else
                        {
                            Value = Value + lblValue.Text.Substring(0, 48) + lblCenterCode.Text + "' and StreamCode='" + lblStreamCode.Text + "',";
                        }

                    }
                }
                else
                {
                    Value = Value + lblValue.Text + ",";
                }
            }

            if (Opearator1 == "")
            {
                lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
                GetAllCampaignAssignedContacts(); 
                //Show_Error_Success_Box("E", "First Select Search Criteria");
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
            //DataSet ds = ProductController.Get_Campaign_Contacts(1, UserID, Value, Opearator2, ColName, Opearator1, lblPageNumber.Text, lblPkey.Text);
            DataSet ds = ProductController.Get_CampaignEvents_Contacts(1, UserID, Value, Opearator2, ColName, Opearator1, lblPageNumber.Text, lblCampaignId.Text, lblCampaignEventId.Text);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            dlStudContact.DataSource = ds.Tables[0];
            dlStudContact.DataBind();
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
            //}
            //else
            //{
            //    Show_Error_Success_Box("E", "Contacts Not Found");
            //    return;
            //}
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
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
                if (chk1.Visible == true)
                {
                    chk1.Checked = s.Checked;
                }
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
        divSearchContact.Visible = true;
        divResultContact.Visible = false;

    }

    protected void btnAddStud_Click(object sender, EventArgs e)
    {
        try
        {
            divResultContact.Visible = false;
            Clear_Error_Success_Box();
            if (ddlColumnNames.SelectedValue == "Select")
            {
                Show_Error_Success_Box("E", "Select Column Name");
                return;
            }
            if (ddlCondition.SelectedValue == "Select")
            {
                Show_Error_Success_Box("E", "Select Condition");
                return;
            }
            if ((ddlColumnNames.SelectedValue == "Contact_Source") || (ddlColumnNames.SelectedValue == "Contact_Type") || (ddlColumnNames.SelectedValue == "Customer_Type") || (ddlColumnNames.SelectedValue == "Standard") || (ddlColumnNames.SelectedValue == "Year_Of_Passing") || (ddlColumnNames.SelectedValue == "Excel_Upload"))
            {
                if (ddlValue.SelectedValue == "Select")
                {
                    Show_Error_Success_Box("E", "Select Value");
                    return;
                }
            }
            else if (ddlColumnNames.SelectedValue == "Contacts")
            {
                if (ddlValue.SelectedValue == "Select")
                {
                    Show_Error_Success_Box("E", "Select Value");
                    return;
                }
                if (ddlAcadYear.SelectedValue == "Select")
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    return;
                }
                if (ddlDivision.SelectedValue == "Select")
                {
                    Show_Error_Success_Box("E", "Select Division");
                    return;
                }
                if (ddlCenter.SelectedValue == "Select")
                {
                    Show_Error_Success_Box("E", "Select Center");
                    return;
                }
            }
            else if (txtValue.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Value");
                return;
            }
            DataRow NewRow = null;
            var _with1 = dtCorrectEntry;
            if (btnAddStud.Text == "+ Add")
            {
                _with1.Columns.Add("ColumnName");
                _with1.Columns.Add("Condition");
                _with1.Columns.Add("Value");
                _with1.Columns.Add("RowNumber");
                _with1.Columns.Add("Operator");
                _with1.Columns.Add("CenterCode");
                _with1.Columns.Add("Div_Code");
                _with1.Columns.Add("Stream_Code");

                i = 1;

                foreach (DataListItem item in dlFillData.Items)
                {
                    NewRow = dtCorrectEntry.NewRow();

                    //Label lblOperator = (Label)item.FindControl("lblOperator");
                    Label lblColName = (Label)item.FindControl("lblColName");
                    Label lblCondition = (Label)item.FindControl("lblCondition");
                    Label lblValue = (Label)item.FindControl("lblValue");
                    Label lblCenterCode = (Label)item.FindControl("lblCenterCode");
                    Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                    Label lblStreamCode = (Label)item.FindControl("lblStreamCode");

                    NewRow = dtCorrectEntry.NewRow();

                    NewRow["ColumnName"] = lblColName.Text;
                    NewRow["Condition"] = lblCondition.Text;
                    NewRow["Value"] = lblValue.Text;
                    NewRow["RowNumber"] = i.ToString();
                    NewRow["Operator"] = "";

                    if (lblColName.Text == "Contacts")
                    {
                        NewRow["CenterCode"] = lblCenterCode.Text;
                        NewRow["Div_Code"] = lblDivisionCode.Text;
                        NewRow["Stream_Code"] = lblStreamCode.Text;
                    }
                    else
                    {
                        NewRow["CenterCode"] = "";
                        NewRow["Div_Code"] = "";
                        NewRow["Stream_Code"] = "";
                    }

                    dtCorrectEntry.Rows.Add(NewRow);
                    i++;

                }

                NewRow = dtCorrectEntry.NewRow();

                NewRow["ColumnName"] = ddlColumnNames.SelectedValue;
                NewRow["Condition"] = ddlCondition.SelectedValue;

                if ((ddlColumnNames.SelectedValue == "Contact_Source") || (ddlColumnNames.SelectedValue == "Contact_Type") || (ddlColumnNames.SelectedValue == "Customer_Type") || (ddlColumnNames.SelectedValue == "Standard") || (ddlColumnNames.SelectedValue == "Year_Of_Passing") || (ddlColumnNames.SelectedValue == "Excel_Upload"))
                {
                    NewRow["Value"] = ddlValue.SelectedItem.ToString();
                    NewRow["CenterCode"] = "";
                    NewRow["Div_Code"] = "";
                    NewRow["Stream_Code"] = "";
                }
                else if (ddlColumnNames.SelectedValue == "Contacts")
                {
                    if ((ddlValue.SelectedValue == "Account") || (ddlValue.SelectedValue == "Opportunity"))
                    {
                        NewRow["Value"] = ddlValue.SelectedItem.ToString() + " where Acad_Year='" + ddlAcadYear.SelectedValue + "' and Center='" + ddlCenter.SelectedItem.ToString() + "' and Stream='" + ddlStream.SelectedItem.ToString() + "'";
                        NewRow["CenterCode"] = ddlCenter.SelectedValue;
                        NewRow["Div_Code"] = ddlDivision.SelectedValue;
                        NewRow["Stream_Code"] = ddlStream.SelectedValue;
                    }
                    else
                    {
                        NewRow["Value"] = ddlValue.SelectedItem.ToString() + " where Acad_Year='" + ddlAcadYear.SelectedValue + "' and Center='" + ddlCenter.SelectedItem.ToString() + "'";
                        NewRow["CenterCode"] = ddlCenter.SelectedValue;
                        NewRow["Div_Code"] = ddlDivision.SelectedValue;
                        NewRow["Stream_Code"] = "";
                    }
                }
                else
                {
                    NewRow["Value"] = txtValue.Text.Trim();
                    NewRow["CenterCode"] = "";
                    NewRow["Div_Code"] = "";
                    NewRow["Stream_Code"] = "";
                }
                NewRow["RowNumber"] = i.ToString();
                NewRow["Operator"] = "";

                dtCorrectEntry.Rows.Add(NewRow);

                if (dtCorrectEntry.Rows.Count > 1)
                {
                    for (int j = 0; j < dtCorrectEntry.Rows.Count; j++)
                    {
                        if (j != 0)
                        {
                            if (optAnyCriteria.Checked == true)
                            {
                                dtCorrectEntry.Rows[j]["Operator"] = "OR";
                            }
                            else
                            {
                                dtCorrectEntry.Rows[j]["Operator"] = "AND";
                            }
                        }
                    }
                }

                dlFillData.DataSource = dtCorrectEntry;
                dlFillData.DataBind();
                btnReset_Click(sender, e);
            }
            else if (btnAddStud.Text == "Save")
            {
                _with1.Columns.Add("ColumnName");
                _with1.Columns.Add("Condition");
                _with1.Columns.Add("Value");
                _with1.Columns.Add("RowNumber");
                _with1.Columns.Add("Operator");
                _with1.Columns.Add("CenterCode");
                _with1.Columns.Add("Div_Code");
                _with1.Columns.Add("Stream_Code");

                i = 1;

                foreach (DataListItem item in dlFillData.Items)
                {
                    NewRow = dtCorrectEntry.NewRow();

                    //Label lblOperator = (Label)item.FindControl("lblOperator");
                    Label lblColName = (Label)item.FindControl("lblColName");
                    Label lblCondition = (Label)item.FindControl("lblCondition");
                    Label lblValue = (Label)item.FindControl("lblValue");
                    Label lblRowNumber = (Label)item.FindControl("lblRowNumber");
                    Label lblCenterCode = (Label)item.FindControl("lblCenterCode");
                    Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                    Label lblStreamCode = (Label)item.FindControl("lblStreamCode");

                    NewRow = dtCorrectEntry.NewRow();
                    if (lblPKey_RowNumber.Text == lblRowNumber.Text)
                    {
                        NewRow["ColumnName"] = ddlColumnNames.SelectedValue;
                        NewRow["Condition"] = ddlCondition.SelectedValue;
                        if ((ddlColumnNames.SelectedValue == "Contact_Source") || (ddlColumnNames.SelectedValue == "Contact_Type") || (ddlColumnNames.SelectedValue == "Customer_Type") || (ddlColumnNames.SelectedValue == "Standard") || (ddlColumnNames.SelectedValue == "Year_Of_Passing") || (ddlColumnNames.SelectedValue == "Excel_Upload"))
                        {
                            NewRow["Value"] = ddlValue.SelectedItem.ToString();
                            NewRow["CenterCode"] = "";
                            NewRow["Div_Code"] = "";
                            NewRow["Stream_Code"] = "";
                        }
                        else if (ddlColumnNames.SelectedValue == "Contacts")
                        {
                            if ((ddlValue.SelectedValue == "Account") || (ddlValue.SelectedValue == "Opportunity"))
                            {
                                NewRow["Value"] = ddlValue.SelectedItem.ToString() + " where Acad_Year='" + ddlAcadYear.SelectedValue + "' and Center='" + ddlCenter.SelectedItem.ToString() + "' and Strem='" + ddlStream.SelectedItem.ToString() + "'";
                                NewRow["CenterCode"] = ddlCenter.SelectedValue;
                                NewRow["Div_Code"] = ddlDivision.SelectedValue;
                                NewRow["Stream_Code"] = ddlStream.SelectedValue;
                            }
                            else
                            {
                                NewRow["Value"] = ddlValue.SelectedItem.ToString() + " where Acad_Year='" + ddlAcadYear.SelectedValue + "' and Center='" + ddlCenter.SelectedItem.ToString() + "'";
                                NewRow["CenterCode"] = ddlCenter.SelectedValue;
                                NewRow["Div_Code"] = ddlDivision.SelectedValue;
                                NewRow["Stream_Code"] = "";
                            }
                        }
                        else
                        {
                            NewRow["Value"] = txtValue.Text.Trim();
                            NewRow["CenterCode"] = "";
                            NewRow["Div_Code"] = "";
                            NewRow["Stream_Code"] = "";
                        }
                        NewRow["RowNumber"] = i.ToString();
                        NewRow["Operator"] = "";
                    }
                    else
                    {
                        NewRow["ColumnName"] = lblColName.Text;
                        NewRow["Condition"] = lblCondition.Text;
                        NewRow["Value"] = lblValue.Text;
                        NewRow["RowNumber"] = i.ToString();
                        NewRow["Operator"] = "";
                        NewRow["CenterCode"] = lblCenterCode.Text;
                        NewRow["Div_Code"] = lblDivisionCode.Text;
                        NewRow["Stream_Code"] = lblStreamCode.Text;
                    }
                    dtCorrectEntry.Rows.Add(NewRow);
                    i++;

                }

                if (dtCorrectEntry.Rows.Count > 1)
                {
                    for (int j = 0; j < dtCorrectEntry.Rows.Count; j++)
                    {
                        if (j != 0)
                        {
                            if (optAnyCriteria.Checked == true)
                            {
                                dtCorrectEntry.Rows[j]["Operator"] = "OR";
                            }
                            else
                            {
                                dtCorrectEntry.Rows[j]["Operator"] = "AND";
                            }
                        }
                    }
                }

                dlFillData.DataSource = dtCorrectEntry;
                dlFillData.DataBind();
                btnReset_Click(sender, e);
                btnAddStud.Text = "+ Add";
                lblPKey_RowNumber.Text = "";
            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        try
        {
            if ((ddlValue.SelectedValue == "Account") || (ddlValue.SelectedValue == "Opportunity"))
            {
                if (ddlAcadYear.SelectedValue == "Select")
                {
                    try
                    {
                        ddlStream.Items.Clear();
                    }
                    catch { }
                    ddlStream.Items.Insert(0, "Select");
                }
                else if (ddlCenter.SelectedValue == "Select")
                {
                    try
                    {
                        ddlStream.Items.Clear();
                    }
                    catch { }
                    ddlStream.Items.Insert(0, "Select");
                }
                else
                {
                    BindStream();
                }
            }
            else
            {
                try
                {
                    ddlStream.Items.Clear();
                }
                catch { }

                ddlStream.Items.Insert(0, "Select");

            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        try
        {
            BindCenter_AssignStudentSearch();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }


    protected void ddlCenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        try
        {
            if ((ddlValue.SelectedValue == "Account") || (ddlValue.SelectedValue == "Opportunity"))
            {
                if (ddlAcadYear.SelectedValue == "Select")
                {
                    try
                    {
                        ddlStream.Items.Clear();
                    }
                    catch { }
                    ddlStream.Items.Insert(0, "Select");
                }
                else if (ddlCenter.SelectedValue == "Select")
                {
                    try
                    {
                        ddlStream.Items.Clear();
                    }
                    catch { }
                    ddlStream.Items.Insert(0, "Select");
                }
                else
                {
                    BindStream();
                }
            }
            else
            {
                try
                {
                    ddlStream.Items.Clear();
                }
                catch { }

                ddlStream.Items.Insert(0, "Select");

            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            ddlColumnNames.SelectedIndex = 0;
            ddlCondition.SelectedIndex = 0;
            txtValue.Text = "";
            lblPKey_RowNumber.Text = "";
            btnAddStud.Text = "+ Add";
            txtValue.Visible = true;
            ddlValue.Visible = false;
            trAcadYear.Visible = false;
            trDivision.Visible = false;
            trCenter.Visible = false;
            trStream.Visible = false;
            ddlAcadYear.SelectedIndex = 0;
            ddlDivision.SelectedIndex = 0;
            ddlCenter.SelectedIndex = 0;
            BindAll_Condition();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnClearAllCriteria_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            var _with1 = dtCorrectEntry;
            _with1.Columns.Add("ColumnName");
            _with1.Columns.Add("Condition");
            _with1.Columns.Add("Value");
            _with1.Columns.Add("RowNumber");
            _with1.Columns.Add("Operator");
            _with1.Columns.Add("CenterCode");
            _with1.Columns.Add("Div_Code");
            _with1.Columns.Add("Stream_Code");

            dlFillData.DataSource = dtCorrectEntry;
            dlFillData.DataBind();

            btnAddStud.Text = "+ Add";

            divResultContact.Visible = false;
            lblPageNumber.Text = "1";
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void dlFillData_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Remove")
            {
                DataRow NewRow = null;
                var _with1 = dtCorrectEntry;
                _with1.Columns.Add("ColumnName");
                _with1.Columns.Add("Condition");
                _with1.Columns.Add("Value");
                _with1.Columns.Add("RowNumber");
                _with1.Columns.Add("Operator");
                _with1.Columns.Add("CenterCode");
                _with1.Columns.Add("Div_Code");
                _with1.Columns.Add("Stream_Code");

                i = 1;

                foreach (DataListItem item in dlFillData.Items)
                {
                    NewRow = dtCorrectEntry.NewRow();

                    //Label lblOperator = (Label)item.FindControl("lblOperator");
                    Label lblColName = (Label)item.FindControl("lblColName");
                    Label lblCondition = (Label)item.FindControl("lblCondition");
                    Label lblValue = (Label)item.FindControl("lblValue");
                    Label lblRowNumber = (Label)item.FindControl("lblRowNumber");
                    Label lblCenterCode = (Label)item.FindControl("lblCenterCode");
                    Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                    Label lblStreamCode = (Label)item.FindControl("lblStreamCode");

                    if (lblRowNumber.Text != e.CommandArgument.ToString())
                    {
                        NewRow = dtCorrectEntry.NewRow();

                        NewRow["ColumnName"] = lblColName.Text;
                        NewRow["Condition"] = lblCondition.Text;
                        NewRow["Value"] = lblValue.Text;
                        NewRow["RowNumber"] = i.ToString();
                        NewRow["Operator"] = "";
                        NewRow["CenterCode"] = lblCenterCode.Text;
                        NewRow["Div_Code"] = lblDivisionCode.Text;
                        NewRow["Stream_Code"] = lblStreamCode.Text;

                        dtCorrectEntry.Rows.Add(NewRow);
                        i++;
                    }
                }

                if (dtCorrectEntry.Rows.Count > 1)
                {
                    for (int j = 0; j < dtCorrectEntry.Rows.Count; j++)
                    {
                        if (j != 0)
                        {
                            if (optAnyCriteria.Checked == true)
                            {
                                dtCorrectEntry.Rows[j]["Operator"] = "OR";
                            }
                            else
                            {
                                dtCorrectEntry.Rows[j]["Operator"] = "AND";
                            }
                        }
                    }
                }

                dlFillData.DataSource = dtCorrectEntry;
                dlFillData.DataBind();
                divResultContact.Visible = false;
                btnReset_Click(source, e);
            }
            else if (e.CommandName == "Edit")
            {

                foreach (DataListItem item in dlFillData.Items)
                {

                    //Label lblOperator = (Label)item.FindControl("lblOperator");
                    Label lblColName = (Label)item.FindControl("lblColName");
                    Label lblCondition = (Label)item.FindControl("lblCondition");
                    Label lblValue = (Label)item.FindControl("lblValue");
                    Label lblRowNumber = (Label)item.FindControl("lblRowNumber");
                    Label lblCenterCode = (Label)item.FindControl("lblCenterCode");
                    Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                    Label lblStreamCode = (Label)item.FindControl("lblStreamCode");

                    if (lblRowNumber.Text == e.CommandArgument.ToString())
                    {
                        ddlColumnNames.SelectedValue = lblColName.Text;
                        ddlColumnNames_SelectedIndexChanged(source, e);
                        ddlCondition.SelectedValue = lblCondition.Text;
                        if ((ddlColumnNames.SelectedValue == "Contact_Source") || (ddlColumnNames.SelectedValue == "Contact_Type") || (ddlColumnNames.SelectedValue == "Customer_Type") || (ddlColumnNames.SelectedValue == "Standard") || (ddlColumnNames.SelectedValue == "Year_Of_Passing") || (ddlColumnNames.SelectedValue == "Excel_Upload"))
                        {
                            ddlValue.SelectedItem.Text = lblValue.Text;
                        }
                        else if (ddlColumnNames.SelectedValue == "Contacts")
                        {
                            try
                            {
                                if (lblValue.Text.Substring(0, 4) == "Lead")
                                {
                                    ddlValue.SelectedIndex = 1;
                                    if (lblValue.Text.Substring(11, 9) == "Acad_Year")
                                    {
                                        ddlAcadYear.SelectedValue = lblValue.Text.Substring(22, 9);
                                    }
                                    if (lblDivisionCode.Text != "")
                                    {
                                        ddlDivision.SelectedValue = lblDivisionCode.Text;
                                        BindCenter_AssignStudentSearch();
                                    }
                                    else
                                    {
                                        ddlDivision.SelectedIndex = 0;
                                        BindCenter_AssignStudentSearch();
                                    }
                                    if (lblCenterCode.Text != "")
                                    {
                                        ddlCenter.SelectedValue = lblCenterCode.Text;
                                    }
                                    else
                                    {
                                        ddlCenter.SelectedIndex = 0;
                                    }
                                    trStream.Visible = false;
                                }
                                else if (lblValue.Text.Substring(0, 11) == "Opportunity")
                                {
                                    ddlValue.SelectedIndex = 2;
                                    if (lblValue.Text.Substring(18, 9) == "Acad_Year")
                                    {
                                        ddlAcadYear.SelectedValue = lblValue.Text.Substring(29, 9);
                                    }
                                    if (lblDivisionCode.Text != "")
                                    {
                                        ddlDivision.SelectedValue = lblDivisionCode.Text;
                                        BindCenter_AssignStudentSearch();
                                    }
                                    else
                                    {
                                        ddlDivision.SelectedIndex = 0;
                                        BindCenter_AssignStudentSearch();
                                    }
                                    if (lblCenterCode.Text != "")
                                    {
                                        ddlCenter.SelectedValue = lblCenterCode.Text;
                                    }
                                    else
                                    {
                                        ddlCenter.SelectedIndex = 0;
                                    }
                                    trStream.Visible = true;
                                    BindStream();
                                    ddlStream.SelectedValue = lblStreamCode.Text;

                                }
                                else if (lblValue.Text.Substring(0, 7) == "Account")
                                {
                                    ddlValue.SelectedIndex = 3;
                                    if (lblValue.Text.Substring(14, 9) == "Acad_Year")
                                    {
                                        ddlAcadYear.SelectedValue = lblValue.Text.Substring(25, 9);
                                    }
                                    if (lblDivisionCode.Text != "")
                                    {
                                        ddlDivision.SelectedValue = lblDivisionCode.Text;
                                        BindCenter_AssignStudentSearch();
                                    }
                                    else
                                    {
                                        ddlDivision.SelectedIndex = 0;
                                        BindCenter_AssignStudentSearch();
                                    }
                                    if (lblCenterCode.Text != "")
                                    {
                                        ddlCenter.SelectedValue = lblCenterCode.Text;
                                    }
                                    else
                                    {
                                        ddlCenter.SelectedIndex = 0;
                                    }
                                    trStream.Visible = true;
                                    BindStream();
                                    ddlStream.SelectedValue = lblStreamCode.Text;
                                }
                                else
                                {
                                    ddlValue.SelectedIndex = 0;
                                }
                            }
                            catch { }

                        }
                        else
                        {
                            txtValue.Text = lblValue.Text;
                        }
                        btnAddStud.Text = "Save";
                        lblPKey_RowNumber.Text = lblRowNumber.Text;
                        divResultContact.Visible = false;
                        return;
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void optAnyCriteria_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            FillTempGrid();
            divResultContact.Visible = false;
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void optAllCriteria_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            FillTempGrid();
            divResultContact.Visible = false;
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }


    #endregion

    #region Function

    private void BindAll_Condition()
    {
        ddlCondition.Items.Clear();
        ddlCondition.Items.Insert(0, "Select");
        ddlCondition.Items.Insert(1, "Is");
        ddlCondition.Items.Insert(2, "Is Not");
        ddlCondition.Items.Insert(3, "Contains");
        ddlCondition.Items.Insert(4, "Does Not Contains");
        ddlCondition.Items.Insert(5, "Starts with");
        ddlCondition.Items.Insert(6, "Ends With");
        ddlCondition.SelectedIndex = 0;
    }

    private void ContactSource()
    {
        DataSet ds = ProductController.GetallactiveleadSource();
        BindDDL(ddlValue, ds, "Description", "ID");
        ddlValue.Items.Insert(0, "Select");
        ddlValue.SelectedIndex = 0;
    }

    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactTypeinrelation();
        BindDDL(ddlValue, ds, "Description", "ID");
        ddlValue.Items.Insert(0, "Select");
        ddlValue.SelectedIndex = 0;
        ddlValue.SelectedValue = "01";
    }

    private void CustomerType()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlValue, ds, "Description", "Cust_Grp");
        ddlValue.Items.Insert(0, "Select");
        ddlValue.SelectedIndex = 0;
    }

    private void Current_Studying()
    {
        DataSet ds = ProductController.GetallCurrentStudyingin("%%");
        BindDDL(ddlValue, ds, "Description", "ID");
        this.ddlValue.Items.Insert(0, "Select");
        this.ddlValue.SelectedIndex = 0;
    }

    private void Yearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlValue, ds, "Description", "ID");
        ddlValue.Items.Insert(0, "Select");
        ddlValue.SelectedIndex = 0;
    }

    private void GetExcelName()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds = ProductController.Get_Contacts_ExcelUpLoad_ExcelName(UserID, "1");
        BindDDL(ddlValue, ds, "Description", "ID");
        ddlValue.Items.Insert(0, "Select");
        ddlValue.SelectedIndex = 0;
    }

    private void GetContacts()
    {
        try
        {
            ddlValue.Items.Clear();
        }
        catch { }
        ddlValue.Items.Insert(0, "Select");
        ddlValue.Items.Insert(1, "Lead");
        ddlValue.Items.Insert(2, "Opportunity");
        ddlValue.Items.Insert(3, "Account");
        ddlValue.SelectedIndex = 0;
    }

    private void BindContacts_Condition()
    {
        ddlCondition.Items.Clear();
        ddlCondition.Items.Insert(0, "Select");
        ddlCondition.Items.Insert(1, "In");
        ddlCondition.Items.Insert(2, "Not In");
        ddlCondition.SelectedIndex = 0;
    }

    private void BindCenter_AssignStudentSearch()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(11, UserID, ddlDivision.SelectedValue, "", "MT");
        BindDDL(ddlCenter, ds, "center_name", "center_code");
        ddlCenter.Items.Insert(0, "Select");
        ddlCenter.SelectedIndex = 0;
        try
        {
            ddlStream.Items.Clear();
        }
        catch { }
        ddlStream.Items.Insert(0, "Select");

    }

    private void FillTempGrid()
    {
        DataRow NewRow = null;
        var _with1 = dtCorrectEntry;
        _with1.Columns.Add("ColumnName");
        _with1.Columns.Add("Condition");
        _with1.Columns.Add("Value");
        _with1.Columns.Add("RowNumber");
        _with1.Columns.Add("Operator");
        _with1.Columns.Add("CenterCode");
        _with1.Columns.Add("Div_Code");
        _with1.Columns.Add("Stream_Code");

        i = 1;

        foreach (DataListItem item in dlFillData.Items)
        {
            NewRow = dtCorrectEntry.NewRow();

            //Label lblOperator = (Label)item.FindControl("lblOperator");
            Label lblColName = (Label)item.FindControl("lblColName");
            Label lblCondition = (Label)item.FindControl("lblCondition");
            Label lblValue = (Label)item.FindControl("lblValue");
            Label lblCenterCode = (Label)item.FindControl("lblCenterCode");
            Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
            Label lblStreamCode = (Label)item.FindControl("lblStreamCode");
            // Label lblRowNumber = (Label)item.FindControl("lblRowNumber");

            NewRow = dtCorrectEntry.NewRow();

            NewRow["ColumnName"] = lblColName.Text;
            NewRow["Condition"] = lblCondition.Text;
            NewRow["Value"] = lblValue.Text;
            NewRow["RowNumber"] = i.ToString();
            NewRow["Operator"] = "";
            NewRow["CenterCode"] = lblCenterCode.Text;
            NewRow["Div_Code"] = lblDivisionCode.Text;
            NewRow["Stream_Code"] = lblStreamCode.Text;

            dtCorrectEntry.Rows.Add(NewRow);
            i++;

        }

        if (dtCorrectEntry.Rows.Count > 1)
        {
            for (int j = 0; j < dtCorrectEntry.Rows.Count; j++)
            {
                if (j != 0)
                {
                    if (optAnyCriteria.Checked == true)
                    {
                        dtCorrectEntry.Rows[j]["Operator"] = "OR";
                    }
                    else
                    {
                        dtCorrectEntry.Rows[j]["Operator"] = "AND";
                    }
                }
            }
        }

        dlFillData.DataSource = dtCorrectEntry;
        dlFillData.DataBind();

    }

    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllStreamby_Center_AcademicYear(ddlCenter.SelectedValue, ddlAcadYear.SelectedValue);
        BindDDL(ddlStream, ds, "Stream_Sdesc", "Stream_Code");
        ddlStream.Items.Insert(0, "All");
        ddlStream.SelectedIndex = 0;
    }

    private void BindConDivision()
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(8, UserID, "", "", "MT");
            BindDDL(ddlDivision, ds, "Division_Name", "Division_Code");
            ddlDivision.Items.Insert(0, "Select");
            ddlDivision.SelectedIndex = 0;
            ddlCenter.Items.Clear();
            ddlCenter.Items.Insert(0, "Select");
            ddlCenter.SelectedIndex = 0;
        }
        catch
        {
            ddlCenter.Items.Insert(0, "Select");
            ddlCenter.SelectedIndex = 0;
        }
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
    }


    private void CampaignDetail(string CampaignId)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        DataSet ds = ProductController.Get_CampaignDetailByPKey(4, UserID, CampaignId);
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count == 0)
            {
                Show_Error_Success_Box("E", "Campaign not found or you are not owner for this campaign.");
                divCampaignDetail.Visible = false;
                divCampaignEventFeedbackDetail.Visible = false;
                divCampaignEventDetails.Visible = false;
                divCampaignEventFeedbackValue.Visible = false;
                return;
            }

            lblCampaignType_Result.Text = ds.Tables[0].Rows[0]["Camp_Type"].ToString();
            lblCampaignName_Result.Text = ds.Tables[0].Rows[0]["Camp_Name"].ToString();
            lblCampaignStatus_Result.Text = ds.Tables[0].Rows[0]["CampaignStatus"].ToString();
            lblTargetAudience_Result.Text = ds.Tables[0].Rows[0]["Target_Audience"].ToString();
            lblCampSponsor_Result.Text = ds.Tables[0].Rows[0]["Campaign_Sponsor"].ToString();
            lblCampSponsoDesc_Result.Text = ds.Tables[0].Rows[0]["Sponsor_Description"].ToString();
            lblExpectedCloseDate_Result.Text = ds.Tables[0].Rows[0]["ExpectedCloseDate"].ToString();
            lblCountCampaignContact_Result.Text = ds.Tables[1].Rows[0]["TotalCampaignContacts"].ToString();
            lblCampaignUserAgent_Result.Text = ds.Tables[0].Rows[0]["AgentName"].ToString();

            dlGridEvents.DataSource = ds.Tables[2];
            dlGridEvents.DataBind();
            //Bind Feedback detail
            if (ds.Tables[4].Rows.Count > 0)
            {
                divCampaignEventFeedbackDetail.Visible = true;
                dlGridEvents_Feedback.DataSource = ds.Tables[3];
                dlGridEvents_Feedback.DataBind();

                foreach (DataListItem dtlItem in dlGridEvents_Feedback.Items)
                {
                    Label lblCampaignEventId = (Label)dtlItem.FindControl("lblCampaignEventId");
                    Label lblCampaignFeedbackId = (Label)dtlItem.FindControl("lblCampaignFeedbackId");                    
                    DropDownList ddlEvent = (DropDownList)dtlItem.FindControl("ddlEvent");

                    ddlEvent.DataSource = ds.Tables[4];
                    ddlEvent.DataTextField = "Event_Name";
                    ddlEvent.DataValueField = "Campaign_Event_Id";
                    ddlEvent.DataBind();

                    ddlEvent.Items.Insert(0, "Select");
                    ddlEvent.SelectedIndex = 0;

                    ddlEvent.SelectedValue = lblCampaignEventId.Text;
                    if (lblCampaignFeedbackId.Text == "")
                    {
                        ddlEvent.Visible = true;
                    }
                }
                //Bind Feedback value detail
                if (ds.Tables[3].Rows.Count > 0)
                {
                    divCampaignEventFeedbackValue.Visible = true;
                    dlGridEvents_FeedbackValue.DataSource = ds.Tables[5];
                    dlGridEvents_FeedbackValue.DataBind();

                    foreach (DataListItem dtlItem in dlGridEvents_FeedbackValue.Items)
                    {
                        Label lblCampaignEventId = (Label)dtlItem.FindControl("lblCampaignEventId");
                        Label lblCampaignFeedbackId = (Label)dtlItem.FindControl("lblCampaignFeedbackId");
                        Label lblCampaignFeedbackValueId = (Label)dtlItem.FindControl("lblCampaignFeedbackValueId");                        
                        DropDownList ddlEvent = (DropDownList)dtlItem.FindControl("ddlEvent");
                        DropDownList ddlFeedBack = (DropDownList)dtlItem.FindControl("ddlFeedBack");

                        ddlEvent.DataSource = ds.Tables[4];
                        ddlEvent.DataTextField = "Event_Name";
                        ddlEvent.DataValueField = "Campaign_Event_Id";
                        ddlEvent.DataBind();

                        ddlEvent.Items.Insert(0, "Select");
                        ddlEvent.SelectedIndex = 0;

                        ddlEvent.SelectedValue = lblCampaignEventId.Text;

                        if (lblCampaignFeedbackValueId.Text == "")
                        {
                            ddlEvent.Visible = true;
                            ddlFeedBack.Visible = true;

                            ddlFeedBack.Items.Insert(0, "Select");
                            ddlFeedBack.SelectedIndex = 0;
                            //ddlEvent_SelectedIndexChanged(s,e);
                            
                        }
                        else
                        {
                            DataSet dsFeedback= GetFeedbackDetail(ddlEvent.SelectedValue, lblCampaignId.Text);

                            ddlFeedBack.DataSource = dsFeedback.Tables[0];
                            ddlFeedBack.DataTextField = "Feedback_Header";
                            ddlFeedBack.DataValueField = "Campaign_Event_Feedback_Id";
                            ddlFeedBack.DataBind();

                            ddlFeedBack.Items.Insert(0, "Select");
                            ddlFeedBack.SelectedIndex = 0;

                            ddlFeedBack.SelectedValue = lblCampaignFeedbackId.Text;
                        }

                    }
                }
                else
                {
                    divCampaignEventFeedbackValue.Visible = false;
                }
                //Complete Bind Feedback value detail
            }
            else
            {
                divCampaignEventFeedbackDetail.Visible = false;
                divCampaignEventFeedbackValue.Visible = false;
            }
            //Complete Bind Feedback detail

        }
    }

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {            
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
        if (Mode == "Add")
        {
            
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
        
    }

    private static DataSet GetFeedbackDetail(string EventId, string CampaignId)
    {
        //DataSet ds = ProductController.Get_CampaignFeedbackDetailByPKey(5, "", CampaignId, EventId);
        return ProductController.Get_CampaignFeedbackDetailByPKey(5, "", CampaignId, EventId);
    }

    private void GetAllCampaignAssignedContacts()
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        DataSet ds = ProductController.Get_CampaignEvents_Contacts(2, UserID, "", "", "", "", lblPageNumber.Text, lblCampaignId.Text, lblCampaignEventId.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //divSearchContact.Visible = false;
            divResultContact.Visible = true;
            dlStudContact.DataSource = ds.Tables[0];
            dlStudContact.DataBind();
            lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
            lblEventAssignedContacts.Text = ds.Tables[1].Rows[0]["Campaign_Event_Contacts"].ToString();
            btnStud_PrevRecord.Visible = false;
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