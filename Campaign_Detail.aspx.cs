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


public partial class Campaign_Detail : System.Web.UI.Page
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
                BindCompany();
                BindAcademicYear();
                BindConDivision();
                //BindCenter_AssignStudentSearch();

                BindCampaignDetail();
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

    protected void btnSendsmsstd_Click(object sender, System.EventArgs e)
    {
        try
        {
            lblSMSError.Text = "";
            if (txtsmsstd.Text.Length <= 17)//if message Detail not insert then display error 
            {
                lblSMSError.Text = "Enter SMS";
                return;
            }

            if (txtsmsstd.Text.Length >= 801) //if message legth is greater than 155 character then display error 
            {
                lblSMSError.Text = "SMS Legth is Greater than 800 character's";
                return;
            }

            string Contacts_Id = "", MobileNo = "";
            foreach (DataListItem item in dlStudContact_SMS.Items)
            {
                CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                Label lblConId = (Label)item.FindControl("lblConId");
                Label lblMobileNo = (Label)item.FindControl("lblMobileNo");

                if ((chk1.Checked == true))
                {
                    if (lblMobileNo.Text != "")
                    {
                        Contacts_Id = Contacts_Id + lblConId.Text + ",";
                        MobileNo = MobileNo + lblMobileNo.Text + ",";
                    }
                }
            }

            //call sp 

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            if (lblSMSSendFlag.Text == "0")
            {
                DataSet ds1 = ProductController.Insert_SMS_Campaign(1, UserID, lblPkey.Text, Contacts_Id, MobileNo, txtsmsstd.Text.Trim());
                if (ds1.Tables[0].Rows[0]["Result"].ToString() == "1")
                {
                    lblSMSSendFlag.Text = "1";
                    Show_Error_Success_Box("S", "Message send successfully...!");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "CloseModalSms();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "CloseModalSms();", true);
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

    protected void btnDeleteStud_NextRecord_ServerClick(object sender, EventArgs e)
    {
        lblDeleteRecPageNumber.Text = (Convert.ToInt32(lblDeleteRecPageNumber.Text) + 1).ToString();
        Campaign_Detail_Delete_Contacts();

    }

    protected void btnDeleteStud_PrevRecord_ServerClick(object sender, EventArgs e)
    {
        lblDeleteRecPageNumber.Text = (Convert.ToInt32(lblDeleteRecPageNumber.Text) - 1).ToString();
        Campaign_Detail_Delete_Contacts();
    }

    protected void btnContactsSave_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string Contacts_Id_Add = "", RowNum = "";



            foreach (DataListItem item in dlStudContact.Items)
            {
                CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                Label lblConId = (Label)item.FindControl("lblConId");
                Label lblRowNum = (Label)item.FindControl("lblRowNum");
                //if (chk1.Visible == true)
                //   {
                //       chk1.Checked = s.Checked;
                //   }

                if ((chk1.Checked == true) && (chk1.Visible == true))
                {
                    Contacts_Id_Add = Contacts_Id_Add + lblConId.Text + ",";
                }
                RowNum = lblRowNum.Text;
            }

            if (Contacts_Id_Add == "")
            {
                // Show_Error_Success_Box("E", "Select Atleast one Contacts");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Atleast one Contacts',class_name: 'gritter-error'});});</script>", false);
                // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Select Atleast one Contacts');", true);
                return;
            }
            string AgentCode = "";
            for (int cnt = 0; cnt <= ddlUser_StudentAssign.Items.Count - 1; cnt++)
            {
                if (ddlUser_StudentAssign.Items[cnt].Selected == true)
                {
                    AgentCode = AgentCode + ddlUser_StudentAssign.Items[cnt].Value + ",";
                }
            }

            if (AgentCode == "")
            {
                //Show_Error_Success_Box("E", "Select Atleast one User/Agent");

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Atleast one User/Agent',class_name: 'gritter-error'});});</script>", false);
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Select Atleast one User/Agent');", true);
                return;
            }


            DataSet ds = ProductController.Insert_UPdate_Campaign_Contacts("1", lblPkey.Text, Contacts_Id_Add, UserID, AgentCode);

            if (btnStud_NextRecord.Visible == true)
            {
                btnStud_NextRecord_ServerClick(sender, e);
            }
            else if (btnStud_PrevRecord.Visible == true)
            {
                btnStud_PrevRecord_ServerClick(sender, e);
            }
            else
            {
                divResultContact.Visible = false;
            }

            Show_Error_Success_Box("S", "Contacts Add successfully for this Campaign");

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
            DataSet ds = ProductController.Get_Campaign_Contacts(1, UserID, Value, Opearator2, ColName, Opearator1, lblPageNumber.Text, lblPkey.Text);
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


    protected void btnCloseSearchCriteria_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            ControlVisibility("Result");
            Clear_Error_Success_Box();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnDCloseSearchCriteria_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            ControlVisibility("Result");
            Clear_Error_Success_Box();
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
                Show_Error_Success_Box("E", "First Select Search Criteria");
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            //PageNumber = PageNumber + 1;
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
            DataSet ds = ProductController.Get_Campaign_Contacts(1, UserID, Value, Opearator2, ColName, Opearator1, lblPageNumber.Text, lblPkey.Text);
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
                Show_Error_Success_Box("E", "First Select Search Criteria");
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
            DataSet ds = ProductController.Get_Campaign_Contacts(1, UserID, Value, Opearator2, ColName, Opearator1, lblPageNumber.Text, lblPkey.Text);
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

    protected void btnAssignedStud_NextRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            //PageNumber = PageNumber + 1;
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
            DataSet ds = null;
            if (ddlAction.SelectedValue == "Assign Contacts")
            {
                ds = ProductController.Get_Campaign_Assigned_Student(3, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
            }
            else
            {
                ds = ProductController.Get_Campaign_Assigned_Student(2, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                divRemoveReassignContactslist.Visible = true;
                dlAssignCampaignContacts.DataSource = ds.Tables[0];
                dlAssignCampaignContacts.DataBind();

                lblAssignedActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
                lblAssignedTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                lblAssignedTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

                if (Convert.ToInt32(lblAssignedTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                    btnAssignedStud_NextRecord.Visible = true;
                else
                    btnAssignedStud_NextRecord.Visible = false;

                if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                    btnAssignedStud_PrevRecord.Visible = false;
                else
                    btnAssignedStud_PrevRecord.Visible = true;
            }
            else
            {
                Show_Error_Success_Box("E", "Contacts Not Found");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Contacts not Found.',class_name: 'gritter-error'});});</script>", false);
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

    protected void btnAssignedStud_PrevRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            //PageNumber = PageNumber + 1;
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
            // DataSet ds = ProductController.Get_Campaign_Assigned_Student(2, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", lblPageNumber.Text);
            DataSet ds = null;
            if (ddlAction.SelectedValue == "Assign Contacts")
            {
                ds = ProductController.Get_Campaign_Assigned_Student(3, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
            }
            else
            {
                ds = ProductController.Get_Campaign_Assigned_Student(2, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                divRemoveReassignContactslist.Visible = true;
                dlAssignCampaignContacts.DataSource = ds.Tables[0];
                dlAssignCampaignContacts.DataBind();
                ////
                //lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
                //lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                //lblTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

                //if (Convert.ToInt32(lblTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                //    btnStud_NextRecord.Visible = true;
                //else
                //    btnStud_NextRecord.Visible = false;

                //if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                //    btnStud_PrevRecord.Visible = false;
                //else
                //    btnStud_PrevRecord.Visible = true;
                ////

                lblAssignedActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
                lblAssignedTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                lblAssignedTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

                if (Convert.ToInt32(lblAssignedTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                    btnAssignedStud_NextRecord.Visible = true;
                else
                    btnAssignedStud_NextRecord.Visible = false;

                if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                    btnAssignedStud_PrevRecord.Visible = false;
                else
                    btnAssignedStud_PrevRecord.Visible = true;
            }
            else
            {
                Show_Error_Success_Box("E", "Contacts Not Found");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Contacts not Found.',class_name: 'gritter-error'});});</script>", false);
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

    protected void chkAllCampaignStud_CheckedChanged(object sender, EventArgs e)
    {
        //int rowcount=
        try
        {
            CheckBox s = sender as CheckBox;
            foreach (DataListItem dtlItem in dlCampaignContacts.Items)
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

    protected void chkAllStud_SMS_CheckedChanged(object sender, EventArgs e)
    {
        //int rowcount=

        try
        {
            CheckBox s = sender as CheckBox;
            foreach (DataListItem dtlItem in dlStudContact_SMS.Items)
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


    protected void chkAllAssignCampaignStud_CheckedChanged(object sender, EventArgs e)
    {
        //int rowcount=

        try
        {
            CheckBox s = sender as CheckBox;
            foreach (DataListItem dtlItem in dlAssignCampaignContacts.Items)
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

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ControlVisibility("Add");
            lblPkey.Text = "";
            lblHeader_Add.Text = "Add Campaign Detail";
            // tblDataSourceRemoveError.Visible = false;
            trCampActual.Visible = false;
            tdCampActualROI.Visible = false;
            btnSaveCampaignDetail.Visible = true;


            //DataRow NewRow = null;

        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        try
        {
            ControlVisibility("Search");
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCampaignTypeSearch.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Type");
                return;
            }
            if (DDLAcadYear_seruch.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                return;
            }
            if (DDLCampaignStatus.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Status");
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            DataSet ds = ProductController.GetUser_Role_Campaign(7, UserID, ddlCampaignTypeSearch.SelectedValue, txtCampaignNameSearch.Text.Trim(), DDLAcadYear_seruch.SelectedValue,DDLCampaignStatus.SelectedValue);
            ControlVisibility("Result");


            //DataTable table1 = new DataTable();
            //table1.Columns.Add("Camp_Type");
            //table1.Columns.Add("Camp_Name");
            //table1.Columns.Add("ExpectedCloseDate");
            //table1.Columns.Add("Campaign_Id");

            //table1.Rows.Add();
            //table1.Rows[0]["Camp_Type"] = "SMS";
            //table1.Rows[0]["Camp_Name"] = "Test";
            //table1.Rows[0]["ExpectedCloseDate"] = "12 Dec 2015";
            //table1.Rows[0]["Campaign_Id"] = "123456";

            //dlDisplay.DataSource = table1;
            dlDisplay.DataSource = ds.Tables[0];
            dlDisplay.DataBind();
            lbltotalcount.Text = ds.Tables[0].Rows.Count.ToString();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }
    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCampaignTypeSearch.SelectedIndex == 0)
            {
                ControlVisibility("Search");
            }
            else
            {
                btnSearch_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void dlDisplay_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                ControlVisibility("Add");
                //tblDataSourceRemoveError.Visible = true;
                trCampActual.Visible = false;
                tdCampActualROI.Visible = false;
                lblHeader_Add.Text = "Edit Campaign Detail";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                lblPkey.Text = e.CommandArgument.ToString();
                DataSet ds = ProductController.Get_CampaignDetailByPKey(1, UserID, e.CommandArgument.ToString());
                if (ds != null)
                {
                    if (ds.Tables[0].Rows[0]["CampaignClose_Flag"].ToString() == "1")
                    {
                        trCampActual.Visible = true;
                        tdCampActualROI.Visible = true;
                        btnSaveCampaignDetail.Visible = false;
                    }
                    ddlCampaignTypeAdd.SelectedValue = ds.Tables[0].Rows[0]["Campaign_Type"].ToString();
                    txtCampaignNameAdd.Text = ds.Tables[0].Rows[0]["Camp_Name"].ToString();
                    ddlCampaignStatusAdd.SelectedValue = ds.Tables[0].Rows[0]["Campaign_Status"].ToString();
                    txtTargetAudienceAdd.Text = ds.Tables[0].Rows[0]["Target_Audience"].ToString();
                    ddlCampaignSponsorAdd.SelectedValue = ds.Tables[0].Rows[0]["Campaign_Sponsor"].ToString();
                    txtSponsorDescAdd.Text = ds.Tables[0].Rows[0]["Sponsor_Description"].ToString();
                    txtExpectedCloseDate.Value = ds.Tables[0].Rows[0]["ExpectedCloseDate"].ToString();
                    txtTargetSizeAdd.Text = ds.Tables[0].Rows[0]["Target_Size"].ToString();
                    //txtNumSentAdd.Text = ds.Tables[0].Rows[0]["Num_Sent"].ToString();
                    ddlCampaignOwnerAdd.SelectedValue = ds.Tables[0].Rows[0]["Campaign_Owner"].ToString();
                    ddlAddAcadYear.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();



                    ////Fill selected Excel Sheet
                    //if (ds.Tables[1].Rows.Count > 0)
                    //{
                    //    for (int cnt = 0; cnt <= ds.Tables[1].Rows.Count - 1; cnt++)
                    //    {
                    //        for (int rcnt = 0; rcnt <= ddlCampaignDataSourceAdd.Items.Count - 1; rcnt++)
                    //        {
                    //            if (ddlCampaignDataSourceAdd.Items[rcnt].Value == ds.Tables[1].Rows[cnt]["Import_Run_No"].ToString())
                    //            {
                    //                ddlCampaignDataSourceAdd.Items[rcnt].Selected = true;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}

                    ddlCompanyAdd.SelectedValue = ds.Tables[0].Rows[0]["Company_Code"].ToString();
                    ddlCompanyAdd_SelectedIndexChanged(source, e);
                    //Fill selected Division,Zone,Center
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        //Fill selected Division
                        for (int cnt = 0; cnt <= ds.Tables[2].Rows.Count - 1; cnt++)
                        {
                            for (int rcnt = 0; rcnt <= ddlDivisionAdd.Items.Count - 1; rcnt++)
                            {
                                if (ddlDivisionAdd.Items[rcnt].Value == ds.Tables[2].Rows[cnt]["Division_Code"].ToString())
                                {
                                    ddlDivisionAdd.Items[rcnt].Selected = true;
                                    break;
                                }
                            }
                        }
                        ddlDivisionAdd_SelectedIndexChanged(source, e);
                        //Fill selected Zone
                        for (int cnt = 0; cnt <= ds.Tables[2].Rows.Count - 1; cnt++)
                        {
                            for (int rcnt = 0; rcnt <= ddlZoneAdd.Items.Count - 1; rcnt++)
                            {
                                if (ddlZoneAdd.Items[rcnt].Value == ds.Tables[2].Rows[cnt]["Zone_Code"].ToString())
                                {
                                    ddlZoneAdd.Items[rcnt].Selected = true;
                                    break;
                                }
                            }
                        }
                        ddlZoneAdd_SelectedIndexChanged(source, e);
                        //Fill selected Center
                        for (int cnt = 0; cnt <= ds.Tables[2].Rows.Count - 1; cnt++)
                        {
                            for (int rcnt = 0; rcnt <= ddlCenterAdd.Items.Count - 1; rcnt++)
                            {
                                if (ddlCenterAdd.Items[rcnt].Value == ds.Tables[2].Rows[cnt]["Center_Code"].ToString())
                                {
                                    ddlCenterAdd.Items[rcnt].Selected = true;
                                    break;
                                }
                            }
                        }
                    }

                    ddlRoleAdd.SelectedValue = ds.Tables[0].Rows[0]["Role_Code"].ToString();

                    //Fill Assigned To User
                    for (int cnt = 0; cnt <= ds.Tables[3].Rows.Count - 1; cnt++)
                    {
                        for (int rcnt = 0; rcnt <= ddlAssignedToAdd.Items.Count - 1; rcnt++)
                        {
                            if (ddlAssignedToAdd.Items[rcnt].Value == ds.Tables[3].Rows[cnt]["Assigned_To"].ToString())
                            {
                                ddlAssignedToAdd.Items[rcnt].Selected = true;
                                break;
                            }
                        }
                    }

                    txtProductAdd.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    txtBudgetCoastAdd.Text = ds.Tables[0].Rows[0]["Budget_Coast"].ToString();
                    txtActualCoastAdd.Text = ds.Tables[0].Rows[0]["Actual_Coast"].ToString();
                    txtExpectedResponseAdd.Text = ds.Tables[0].Rows[0]["Expected_Response"].ToString();
                    txtExpectedRevenueAdd.Text = ds.Tables[0].Rows[0]["Expected_Revenue"].ToString();
                    txtExpectedSalescountAdd.Text = ds.Tables[0].Rows[0]["Expected_SalesCount"].ToString();
                    txtActualSalesCountAdd.Text = ds.Tables[0].Rows[0]["Actual_SalesCount"].ToString();
                    txtExpectedResponseCountAdd.Text = ds.Tables[0].Rows[0]["Expected_ResponseCount"].ToString();
                    txtActualResponseCountAdd.Text = ds.Tables[0].Rows[0]["Actual_ResponseCount"].ToString();
                    txtExpectedROIAdd.Text = ds.Tables[0].Rows[0]["Expected_ROI"].ToString();
                    txtActualROIAdd.Text = ds.Tables[0].Rows[0]["Actual_ROI"].ToString();
                    //txtResourceStartDate.Value = ds.Tables[0].Rows[0]["Resourse_StartDate"].ToString();
                    //txtResourceEndDate.Value = ds.Tables[0].Rows[0]["Resourse_EndDate"].ToString();
                    //txtSourceAdd.Text = ds.Tables[0].Rows[0]["Source"].ToString();
                    //txtResourceAproxCoastAdd.Text = ds.Tables[0].Rows[0]["AproxCoast"].ToString();
                }

            }
            else if (e.CommandName == "Assign")
            {
                ControlVisibility("AssignStudent");
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                lblPkey.Text = e.CommandArgument.ToString();
                DataSet ds = ProductController.Get_CampaignDetailByPKey(2, UserID, e.CommandArgument.ToString());
                if (ds != null)
                {
                    lblCampaignType_Result.Text = ds.Tables[0].Rows[0]["Camp_Type"].ToString();
                    lblCampaignName_Result.Text = ds.Tables[0].Rows[0]["Camp_Name"].ToString();
                    lblCampaignStatus_Result.Text = ds.Tables[0].Rows[0]["CampaignStatus"].ToString();
                    lblTargetAudience_Result.Text = ds.Tables[0].Rows[0]["Target_Audience"].ToString();
                    lblCampSponsor_Result.Text = ds.Tables[0].Rows[0]["Campaign_Sponsor"].ToString();
                    lblCampSponsoDesc_Result.Text = ds.Tables[0].Rows[0]["Sponsor_Description"].ToString();
                    lblExpectedCloseDate_Result.Text = ds.Tables[0].Rows[0]["ExpectedCloseDate"].ToString();
                    // lblExcelFile_Result.Text = ds.Tables[0].Rows[0]["ExcelName"].ToString();
                    lblCountCampaignContact_Result.Text = ds.Tables[1].Rows[0]["TotalCampaignContacts"].ToString();


                    ddlUser_StudentAssign.DataSource = ds.Tables[2];
                    ddlUser_StudentAssign.DataTextField = "UserName";
                    ddlUser_StudentAssign.DataValueField = "Assigned_To";
                    ddlUser_StudentAssign.DataBind();


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

                    divSearchContact.Visible = true;
                    divResultContact.Visible = false;

                    btnReset_Click(source, e);
                    optAllCriteria.Checked = true;
                    optAnyCriteria.Checked = false;
                    //if (ds.Tables[1].Rows.Count < ds.Tables[2].Rows.Count)
                    //{
                    //    dlGridDisplay_Pending.DataSource = ds.Tables[1];
                    //    dlGridDisplay_Pending.DataBind();
                    //    lblPendingRecCnt.Text = ds.Tables[1].Rows.Count.ToString();

                    //    dlGridDisplay_Selected.DataSource = ds.Tables[2];
                    //    ds.Dispose();
                    //    dlGridDisplay_Selected.DataBind();
                    //    lblCurrentRecCnt.Text = ds.Tables[2].Rows.Count.ToString();

                    //}
                    //else
                    //{
                    //    dlGridDisplay_Selected.DataSource = ds.Tables[2];                    
                    //    dlGridDisplay_Selected.DataBind();
                    //    lblCurrentRecCnt.Text = ds.Tables[2].Rows.Count.ToString();

                    //    dlGridDisplay_Pending.DataSource = ds.Tables[1];
                    //    ds.Dispose();
                    //    dlGridDisplay_Pending.DataBind();
                    //    lblPendingRecCnt.Text = ds.Tables[1].Rows.Count.ToString();
                    //}
                }

            }
            else if (e.CommandName == "RemoveCampaignContacts")//Remove Campaign Contacts
            {

                txtstudentnamesearch.Text = "";
                txthandphonesearch.Text = "";
                lblDeleteRecPageNumber.Text = "1";
                lblPkey.Text = e.CommandArgument.ToString();

                ControlVisibility("RemoveCampaignContacts");
                Campaign_Detail_Delete_Contacts();

            }
            else if (e.CommandName == "RemoveUserAssignment")//Remove Or Reassign Campaign Contacts User Assignment
            {
                ControlVisibility("RemoveReassignUserAssignment");
                trReassignedUser.Visible = false;
                ddlAction.SelectedIndex = 0;
                btnSearchAssignedContacts.Visible = true;
                btnSearchAssignedContacts1.Visible = false;

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                lblPkey.Text = e.CommandArgument.ToString();
                DataSet ds = ProductController.Get_CampaignDetailByPKey(2, UserID, e.CommandArgument.ToString());
                if (ds != null)
                {
                    lblCampaignTypeResult1.Text = ds.Tables[0].Rows[0]["Camp_Type"].ToString();
                    lblCampaignNameResult1.Text = ds.Tables[0].Rows[0]["Camp_Name"].ToString();
                    lblCampaignStatusResult1.Text = ds.Tables[0].Rows[0]["CampaignStatus"].ToString();
                    lblCampaignTargetAudienceResult1.Text = ds.Tables[0].Rows[0]["Target_Audience"].ToString();
                    lblCampaignSponsorResult1.Text = ds.Tables[0].Rows[0]["Campaign_Sponsor"].ToString();
                    lblCampaignSponsorDescResult1.Text = ds.Tables[0].Rows[0]["Sponsor_Description"].ToString();
                    lblCampaignExpectedCloseDateResult1.Text = ds.Tables[0].Rows[0]["ExpectedCloseDate"].ToString();
                    // lblExcelFile_Result.Text = ds.Tables[0].Rows[0]["ExcelName"].ToString();
                    lblCampaignAssignedContactsResult1.Text = ds.Tables[1].Rows[0]["TotalCampaignContacts"].ToString();


                    ddlAssignedCampUser.DataSource = ds.Tables[2];
                    ddlAssignedCampUser.DataTextField = "UserName";
                    ddlAssignedCampUser.DataValueField = "Assigned_To";
                    ddlAssignedCampUser.DataBind();
                    ddlAssignedCampUser.Items.Insert(0, "Select");
                    ddlAssignedCampUser.SelectedIndex = 0;

                    ddlReassignedUser.DataSource = ds.Tables[2];
                    ddlReassignedUser.DataTextField = "UserName";
                    ddlReassignedUser.DataValueField = "Assigned_To";
                    ddlReassignedUser.DataBind();
                    ddlReassignedUser.Items.Insert(0, "Select");
                    ddlReassignedUser.SelectedIndex = 0;
                }
            }
            else if (e.CommandName == "CloseCampaign")
            {
                ControlVisibility("Add");
                btnSaveCampaignDetail.Visible = true;
                //tblDataSourceRemoveError.Visible = true;
                trCampActual.Visible = true;
                tdCampActualROI.Visible = true;
                lblHeader_Add.Text = "Close Campaign";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                lblPkey.Text = e.CommandArgument.ToString();
                DataSet ds = ProductController.Get_CampaignDetailByPKey(1, UserID, e.CommandArgument.ToString());
                if (ds != null)
                {
                    ddlCampaignTypeAdd.SelectedValue = ds.Tables[0].Rows[0]["Campaign_Type"].ToString();
                    txtCampaignNameAdd.Text = ds.Tables[0].Rows[0]["Camp_Name"].ToString();
                    ddlCampaignStatusAdd.SelectedValue = ds.Tables[0].Rows[0]["Campaign_Status"].ToString();
                    txtTargetAudienceAdd.Text = ds.Tables[0].Rows[0]["Target_Audience"].ToString();
                    ddlCampaignSponsorAdd.SelectedValue = ds.Tables[0].Rows[0]["Campaign_Sponsor"].ToString();
                    txtSponsorDescAdd.Text = ds.Tables[0].Rows[0]["Sponsor_Description"].ToString();
                    txtExpectedCloseDate.Value = ds.Tables[0].Rows[0]["ExpectedCloseDate"].ToString();
                    txtTargetSizeAdd.Text = ds.Tables[0].Rows[0]["Target_Size"].ToString();
                    //txtNumSentAdd.Text = ds.Tables[0].Rows[0]["Num_Sent"].ToString();
                    ddlCampaignOwnerAdd.SelectedValue = ds.Tables[0].Rows[0]["Campaign_Owner"].ToString();
                    ddlAddAcadYear.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();

                    //Fill selected Excel Sheet
                    //if (ds.Tables[1].Rows.Count > 0)
                    //{
                    //    for (int cnt = 0; cnt <= ds.Tables[1].Rows.Count - 1; cnt++)
                    //    {
                    //        for (int rcnt = 0; rcnt <= ddlCampaignDataSourceAdd.Items.Count - 1; rcnt++)
                    //        {
                    //            if (ddlCampaignDataSourceAdd.Items[rcnt].Value == ds.Tables[1].Rows[cnt]["Import_Run_No"].ToString())
                    //            {
                    //                ddlCampaignDataSourceAdd.Items[rcnt].Selected = true;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}

                    ddlCompanyAdd.SelectedValue = ds.Tables[0].Rows[0]["Company_Code"].ToString();
                    ddlCompanyAdd_SelectedIndexChanged(source, e);
                    //Fill selected Division,Zone,Center
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        //Fill selected Division
                        for (int cnt = 0; cnt <= ds.Tables[2].Rows.Count - 1; cnt++)
                        {
                            for (int rcnt = 0; rcnt <= ddlDivisionAdd.Items.Count - 1; rcnt++)
                            {
                                if (ddlDivisionAdd.Items[rcnt].Value == ds.Tables[2].Rows[cnt]["Division_Code"].ToString())
                                {
                                    ddlDivisionAdd.Items[rcnt].Selected = true;
                                    break;
                                }
                            }
                        }
                        ddlDivisionAdd_SelectedIndexChanged(source, e);
                        //Fill selected Zone
                        for (int cnt = 0; cnt <= ds.Tables[2].Rows.Count - 1; cnt++)
                        {
                            for (int rcnt = 0; rcnt <= ddlZoneAdd.Items.Count - 1; rcnt++)
                            {
                                if (ddlZoneAdd.Items[rcnt].Value == ds.Tables[2].Rows[cnt]["Zone_Code"].ToString())
                                {
                                    ddlZoneAdd.Items[rcnt].Selected = true;
                                    break;
                                }
                            }
                        }
                        ddlZoneAdd_SelectedIndexChanged(source, e);
                        //Fill selected Center
                        for (int cnt = 0; cnt <= ds.Tables[2].Rows.Count - 1; cnt++)
                        {
                            for (int rcnt = 0; rcnt <= ddlCenterAdd.Items.Count - 1; rcnt++)
                            {
                                if (ddlCenterAdd.Items[rcnt].Value == ds.Tables[2].Rows[cnt]["Center_Code"].ToString())
                                {
                                    ddlCenterAdd.Items[rcnt].Selected = true;
                                    break;
                                }
                            }
                        }
                    }

                    ddlRoleAdd.SelectedValue = ds.Tables[0].Rows[0]["Role_Code"].ToString();

                    //Fill Assigned To User
                    for (int cnt = 0; cnt <= ds.Tables[3].Rows.Count - 1; cnt++)
                    {
                        for (int rcnt = 0; rcnt <= ddlAssignedToAdd.Items.Count - 1; rcnt++)
                        {
                            if (ddlAssignedToAdd.Items[rcnt].Value == ds.Tables[3].Rows[cnt]["Assigned_To"].ToString())
                            {
                                ddlAssignedToAdd.Items[rcnt].Selected = true;
                                break;
                            }
                        }
                    }

                    txtProductAdd.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    txtBudgetCoastAdd.Text = ds.Tables[0].Rows[0]["Budget_Coast"].ToString();
                    txtActualCoastAdd.Text = ds.Tables[0].Rows[0]["Actual_Coast"].ToString();
                    txtExpectedResponseAdd.Text = ds.Tables[0].Rows[0]["Expected_Response"].ToString();
                    txtExpectedRevenueAdd.Text = ds.Tables[0].Rows[0]["Expected_Revenue"].ToString();
                    txtExpectedSalescountAdd.Text = ds.Tables[0].Rows[0]["Expected_SalesCount"].ToString();
                    txtActualSalesCountAdd.Text = ds.Tables[0].Rows[0]["Actual_SalesCount"].ToString();
                    txtExpectedResponseCountAdd.Text = ds.Tables[0].Rows[0]["Expected_ResponseCount"].ToString();
                    txtActualResponseCountAdd.Text = ds.Tables[0].Rows[0]["Actual_ResponseCount"].ToString();
                    txtExpectedROIAdd.Text = ds.Tables[0].Rows[0]["Expected_ROI"].ToString();
                    txtActualROIAdd.Text = ds.Tables[0].Rows[0]["Actual_ROI"].ToString();
                    //txtResourceStartDate.Value = ds.Tables[0].Rows[0]["Resourse_StartDate"].ToString();
                    //txtResourceEndDate.Value = ds.Tables[0].Rows[0]["Resourse_EndDate"].ToString();
                    //txtSourceAdd.Text = ds.Tables[0].Rows[0]["Source"].ToString();
                    //txtResourceAproxCoastAdd.Text = ds.Tables[0].Rows[0]["AproxCoast"].ToString();
                }
            }
            else if (e.CommandName == "CampaignSMS")
            {
                HttpCookie cookie1 = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID1 = cookie1.Values["UserID"];
                lblPkey.Text = e.CommandArgument.ToString();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalSms();", true);

                DataSet ds = ProductController.Get_CampaignDetailByPKey(3, UserID1, e.CommandArgument.ToString());
                if (ds != null)
                {
                    ControlVisibility("CampaignSMS");
                    lblSMSCampignType.Text = ds.Tables[0].Rows[0]["Camp_Type"].ToString();
                    lblSMSCampignName.Text = ds.Tables[0].Rows[0]["Camp_Name"].ToString();
                    lblSMSCampignStatus.Text = ds.Tables[0].Rows[0]["CampaignStatus"].ToString();
                    lblSMSCampignTargetAudience.Text = ds.Tables[0].Rows[0]["Target_Audience"].ToString();
                    lblSMSCampignSponsor.Text = ds.Tables[0].Rows[0]["Campaign_Sponsor"].ToString();
                    lblSMSCampignSponsorDesc.Text = ds.Tables[0].Rows[0]["Sponsor_Description"].ToString();
                    lblSMSCampignExpectedCloseDate.Text = ds.Tables[0].Rows[0]["ExpectedCloseDate"].ToString();
                    lblSMSCampignAssignedContatcts.Text = ds.Tables[0].Rows[0]["Total_Contacts"].ToString();
                    lblSMSCampignUser.Text = ds.Tables[0].Rows[0]["Agent"].ToString();

                    dlStudContact_SMS.DataSource = ds.Tables[1];
                    dlStudContact_SMS.DataBind();

                }
                else
                {
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblerror.Text = "Record Not found...!";
                }

            }
            else if (e.CommandName == "CampaignEvent")
            {
                HttpCookie cookie1 = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID1 = cookie1.Values["UserID"];
                lblPkey.Text = e.CommandArgument.ToString();
                Response.Redirect("Campaign_Events.aspx?CampaignId=" + e.CommandArgument.ToString());
            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnSearchAssignedContacts_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            if (ddlAssignedCampUser.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Assigned campaign User");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Assigned campaign User.',class_name: 'gritter-error'});});</script>", false);
                return;
            }

            if (ddlAction.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Action(Reassign or Remove)");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Action (Reassign or Remove)',class_name: 'gritter-error'});});</script>", false);
                return;
            }

            CampaignAgentAssignedStudent();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void ddlCampaignTypeAdd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlCompanyAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindDivision();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }
    protected void ddlDivisionAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            BindZone();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }
    protected void ddlZoneAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindCenter();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnSaveCampaignDetail_Click(object sender, EventArgs e)
    {
        try
        {

            string Zone = "", Center = "", AssignedTo = "", UserId = "", Excel_Import_Run_No = "", Division_Code = "";

            if (ddlCampaignTypeAdd.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Type");
                return;
            }
            if (txtCampaignNameAdd.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Campaign Name");
                txtCampaignNameAdd.Focus();
                return;
            }
            if (ddlCampaignStatusAdd.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Status");
                return;
            }
            if (ddlCampaignStatusAdd.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Status");
                return;
            }
            if (txtTargetAudienceAdd.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Target Audience");
                txtTargetAudienceAdd.Focus();
                return;
            }
            if (ddlCampaignSponsorAdd.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Sponsor");
                return;
            }
            if (txtExpectedCloseDate.Value == "")
            {
                Show_Error_Success_Box("E", "Enter Expected Close Date");
                return;
            }
            if (txtTargetSizeAdd.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Target Size");
                return;
            }
            if (ddlCampaignOwnerAdd.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Campaign Owner");
                return;
            }

            //for (int cnt = 0; cnt <= ddlCampaignDataSourceAdd.Items.Count - 1; cnt++)
            //{
            //    if (ddlCampaignDataSourceAdd.Items[cnt].Selected == true)
            //    {
            //        Excel_Import_Run_No = Excel_Import_Run_No + ddlCampaignDataSourceAdd.Items[cnt].Value + ",";
            //    }
            //}

            //if (Excel_Import_Run_No == "")
            //{
            //    Show_Error_Success_Box("E", "Select Atleast One Data Source");
            //    return;
            //}


            if (ddlCompanyAdd.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Company");
                return;
            }

            for (int cnt = 0; cnt <= ddlDivisionAdd.Items.Count - 1; cnt++)
            {
                if (ddlDivisionAdd.Items[cnt].Selected == true)
                {
                    Division_Code = Division_Code + ddlDivisionAdd.Items[cnt].Value + ",";
                }
            }

            if (Division_Code == "")
            {
                Show_Error_Success_Box("E", "Select Atleast One Division");
                return;
            }

            for (int cnt = 0; cnt <= ddlZoneAdd.Items.Count - 1; cnt++)
            {
                if (ddlZoneAdd.Items[cnt].Selected == true)
                {
                    Zone = Zone + ddlZoneAdd.Items[cnt].Value + ",";
                }
            }

            if (Zone == "")
            {
                Show_Error_Success_Box("E", "Select Atleast One Zone");
                return;
            }

            for (int cnt = 0; cnt <= ddlCenterAdd.Items.Count - 1; cnt++)
            {
                if (ddlCenterAdd.Items[cnt].Selected == true)
                {
                    Center = Center + ddlCenterAdd.Items[cnt].Value + ",";
                }
            }

            if (Center == "")
            {
                Show_Error_Success_Box("E", "Select Atleast One Center");
                return;
            }

            if (ddlAddAcadYear.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                return;
            }
            //if (ddlRoleAdd.SelectedIndex == 0)
            //{
            //    Show_Error_Success_Box("E", "Select Role");
            //    return;
            //}

            for (int cnt = 0; cnt <= ddlAssignedToAdd.Items.Count - 1; cnt++)
            {
                if (ddlAssignedToAdd.Items[cnt].Selected == true)
                {
                    AssignedTo = AssignedTo + ddlAssignedToAdd.Items[cnt].Value + ",";
                }
            }

            if (AssignedTo == "")
            {
                Show_Error_Success_Box("E", "Select Atleast One User Assign to this Campaign");
                return;
            }

            if (txtProductAdd.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Product Name");
                txtProductAdd.Focus();
                return;
            }

            if (txtBudgetCoastAdd.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Campaign Budget Cost");
                txtBudgetCoastAdd.Focus();
                return;
            }

            if (txtExpectedResponseAdd.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Campaign Expected Response");
                txtExpectedResponseAdd.Focus();
                return;
            }

            if (txtExpectedRevenueAdd.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Campaign Expected Revenue(Rs.)");
                txtExpectedRevenueAdd.Focus();
                return;
            }

            if (txtExpectedSalescountAdd.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Campaign Expected Sales Count");
                txtExpectedSalescountAdd.Focus();
                return;
            }

            if (txtExpectedResponseCountAdd.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Campaign Expected Responce Count");
                txtExpectedResponseCountAdd.Focus();
                return;
            }//
            if (txtExpectedROIAdd.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Campaign Expected ROI(Return On Investment)");
                txtExpectedROIAdd.Focus();
                return;
            }

            //if (txtResourceStartDate.Value== "")
            //{
            //    Show_Error_Success_Box("E", "Enter Campaign Start Date");
            //    return;
            //}

            //if (txtResourceEndDate.Value == "")
            //{
            //    Show_Error_Success_Box("E", "Enter Campaign End Date");
            //    return;
            //}

            //if (txtSourceAdd.Text == "")
            //{
            //    Show_Error_Success_Box("E", "Enter Source");
            //    txtSourceAdd.Focus();
            //    return;
            //}

            //if (txtResourceAproxCoastAdd.Text == "")
            //{
            //    Show_Error_Success_Box("E", "Enter Resource Approx. Cost");
            //    txtResourceAproxCoastAdd.Focus();
            //    return;
            //}

            if (trCampActual.Visible == true)
            {

                if (txtActualCoastAdd.Text == "")
                {
                    Show_Error_Success_Box("E", "Enter Actual Cost");
                    txtActualCoastAdd.Focus();
                    return;
                }
                if (txtActualSalesCountAdd.Text == "")
                {
                    Show_Error_Success_Box("E", "Enter Actual Sales Count");
                    txtActualSalesCountAdd.Focus();
                    return;
                }
                if (txtActualResponseCountAdd.Text == "")
                {
                    Show_Error_Success_Box("E", "Enter Actual Response Count");
                    txtActualResponseCountAdd.Focus();
                    return;
                }
                if (txtActualROIAdd.Text == "")
                {
                    Show_Error_Success_Box("E", "Enter Actual ROI(Return On Investment)");
                    txtActualROIAdd.Focus();
                    return;
                }

            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            UserId = cookie.Values["UserID"];
            DataSet ds = null;
            if (lblPkey.Text == "")//Create a New Campaign
            {
                ds = ProductController.Insert_Update_CampaignDetail(1, lblPkey.Text, ddlCampaignTypeAdd.SelectedValue, txtCampaignNameAdd.Text.Trim(), ddlCampaignStatusAdd.SelectedValue, txtTargetAudienceAdd.Text.Trim(), ddlCampaignSponsorAdd.SelectedValue,
                                txtSponsorDescAdd.Text.Trim(), txtExpectedCloseDate.Value, txtTargetSizeAdd.Text.Trim(), "", ddlCampaignOwnerAdd.SelectedValue, ddlCompanyAdd.SelectedValue, Division_Code, Zone, Center, ddlRoleAdd.SelectedValue, txtProductAdd.Text.Trim(),
                                AssignedTo, txtBudgetCoastAdd.Text.Trim(), txtActualCoastAdd.Text.Trim(), txtExpectedResponseAdd.Text.Trim(), txtExpectedRevenueAdd.Text.Trim(), txtExpectedSalescountAdd.Text.Trim(), txtActualSalesCountAdd.Text.Trim(), txtExpectedResponseCountAdd.Text,
                                txtActualResponseCountAdd.Text.Trim(), txtExpectedROIAdd.Text.Trim(), txtActualROIAdd.Text.Trim(), "", "", "", "",
                                UserId, Excel_Import_Run_No, ddlAddAcadYear.SelectedValue);
            }
            else if ((lblPkey.Text != "") && (trCampActual.Visible == false)) //Update Existing Campaign
            {
                ds = ProductController.Insert_Update_CampaignDetail(2, lblPkey.Text, ddlCampaignTypeAdd.SelectedValue, txtCampaignNameAdd.Text.Trim(), ddlCampaignStatusAdd.SelectedValue, txtTargetAudienceAdd.Text.Trim(), ddlCampaignSponsorAdd.SelectedValue,
                               txtSponsorDescAdd.Text.Trim(), txtExpectedCloseDate.Value, txtTargetSizeAdd.Text.Trim(), "", ddlCampaignOwnerAdd.SelectedValue, ddlCompanyAdd.SelectedValue, Division_Code, Zone, Center, ddlRoleAdd.SelectedValue, txtProductAdd.Text.Trim(),
                               AssignedTo, txtBudgetCoastAdd.Text.Trim(), txtActualCoastAdd.Text.Trim(), txtExpectedResponseAdd.Text.Trim(), txtExpectedRevenueAdd.Text.Trim(), txtExpectedSalescountAdd.Text.Trim(), txtActualSalesCountAdd.Text.Trim(), txtExpectedResponseCountAdd.Text,
                               txtActualResponseCountAdd.Text.Trim(), txtExpectedROIAdd.Text.Trim(), txtActualROIAdd.Text.Trim(), "", "", "", "",
                               UserId, Excel_Import_Run_No, ddlAddAcadYear.SelectedValue);
            }
            else if ((lblPkey.Text != "") && (trCampActual.Visible == true)) //Update Existing Campaign
            {
                ds = ProductController.Insert_Update_CampaignDetail(3, lblPkey.Text, ddlCampaignTypeAdd.SelectedValue, txtCampaignNameAdd.Text.Trim(), ddlCampaignStatusAdd.SelectedValue, txtTargetAudienceAdd.Text.Trim(), ddlCampaignSponsorAdd.SelectedValue,
                               txtSponsorDescAdd.Text.Trim(), txtExpectedCloseDate.Value, txtTargetSizeAdd.Text.Trim(), "", ddlCampaignOwnerAdd.SelectedValue, ddlCompanyAdd.SelectedValue, Division_Code, Zone, Center, ddlRoleAdd.SelectedValue, txtProductAdd.Text.Trim(),
                               AssignedTo, txtBudgetCoastAdd.Text.Trim(), txtActualCoastAdd.Text.Trim(), txtExpectedResponseAdd.Text.Trim(), txtExpectedRevenueAdd.Text.Trim(), txtExpectedSalescountAdd.Text.Trim(), txtActualSalesCountAdd.Text.Trim(), txtExpectedResponseCountAdd.Text,
                               txtActualResponseCountAdd.Text.Trim(), txtExpectedROIAdd.Text.Trim(), txtActualROIAdd.Text.Trim(), "", "", "", "",
                               UserId, Excel_Import_Run_No, ddlAddAcadYear.SelectedValue);
            }
            if (ds.Tables[0].Rows[0]["Result"].ToString() == "-1")
            {
                Show_Error_Success_Box("E", "Duplicate Campaign Name");
                return;
            }
            else if (ds.Tables[0].Rows[0]["Result"].ToString() == "2")
            {
                ControlVisibility("Search");
                Show_Error_Success_Box("S", "Campaign Closed Successfully...!");
            }
            else
            {
                //ControlVisibility("Search");
                txtCampaignNameAdd.Text = "";
                Show_Error_Success_Box("S", "Record Saved Successfully...!");
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    protected void btnCloseAssign_Click(object sender, EventArgs e)
    {
        try
        {
            ControlVisibility("Result");
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnStud_AddToCampaign_ServerClick(object sender, System.EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnStud_RemoveFromCampaign_ServerClick(object sender, System.EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    public void All_Student_ChkBox_Selected(object sender, System.EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    public void All_Student_ChkBox_Selected_Sel(object sender, System.EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }

    }


    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ddlCampaignTypeSearch.SelectedIndex = 0;
            txtCampaignNameSearch.Text = "";
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnSearchByNameHandphone_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        lblDeleteRecPageNumber.Text = "1";
        Campaign_Detail_Delete_Contacts();
    }
    protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            divRemoveReassignContactslist.Visible = false;
            if (ddlAction.SelectedValue == "Assign Contacts")
            {
                trReassignedUser.Visible = false;
                btnSearchAssignedContacts.Visible = true;
                btnSearchAssignedContacts1.Visible = false;
                btnContactsRemove_Reassign.Text = "Assign Contacts";
            }
            else if (ddlAction.SelectedValue == "Reassign")
            {
                trReassignedUser.Visible = true;
                btnSearchAssignedContacts.Visible = false;
                btnSearchAssignedContacts1.Visible = true;
                btnContactsRemove_Reassign.Text = "Reassign";
            }
            else if (ddlAction.SelectedValue == "Remove")
            {
                trReassignedUser.Visible = false;
                btnSearchAssignedContacts.Visible = true;
                btnSearchAssignedContacts1.Visible = false;
                btnContactsRemove_Reassign.Text = "Remove";
            }
            else
            {
                trReassignedUser.Visible = false;
                btnSearchAssignedContacts.Visible = true;
                btnSearchAssignedContacts1.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void ddlAssignedCampUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            divRemoveReassignContactslist.Visible = false;
            if (ddlAction.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Action(Assign or Reassign or Remove)");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Action (Assign Or Reassign or Remove)',class_name: 'gritter-error'});});</script>", false);
                return;
            }
            CampaignAgentAssignedStudent();
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void btnContactsRemove_Reassign_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlAction.SelectedValue == "Assign Contacts")
            {
                if (ddlAssignedCampUser.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Assigned User");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Assigned User',class_name: 'gritter-error'});});</script>", false);
                    return;
                }
                string Contacts_Id = "", PKeyRecordId = "";
                foreach (DataListItem item in dlAssignCampaignContacts.Items)
                {
                    CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                    Label lblConId = (Label)item.FindControl("lblConId");
                    Label lblPKeyRecordId = (Label)item.FindControl("lblPKeyRecordId");

                    if ((chk1.Checked == true) && (chk1.Visible == true))
                    {
                        Contacts_Id = Contacts_Id + lblConId.Text + ",";
                        PKeyRecordId = PKeyRecordId + lblPKeyRecordId.Text + ",";
                    }
                }

                if (Contacts_Id == "")
                {
                    Show_Error_Success_Box("E", "Select atleast one contacts");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select atleast one contacts',class_name: 'gritter-error'});});</script>", false);
                    return;
                }

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                DataSet dsassign = ProductController.Campaign_RemoveOrReassignContactsToUser(3, UserID, lblPkey.Text, ddlAssignedCampUser.SelectedValue, "", Contacts_Id, PKeyRecordId);
                if (dsassign.Tables[0].Rows.Count > 0)
                {
                    if (dsassign.Tables[0].Rows[0]["Result"].ToString() == "1")
                    {
                        Show_Error_Success_Box("S", "Contacts Assigned Successfully...!");
                        DataSet ds = null;
                        if (ddlAction.SelectedValue == "Assign Contacts")
                        {
                            ds = ProductController.Get_Campaign_Assigned_Student(3, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
                        }
                        else
                        {
                            ds = ProductController.Get_Campaign_Assigned_Student(2, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            divRemoveReassignContactslist.Visible = true;
                            dlAssignCampaignContacts.DataSource = ds.Tables[0];
                            dlAssignCampaignContacts.DataBind();

                            lblAssignedTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                            lblAssignedTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                            lblAssignedActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
                            if (lblPageNumber.Text == "1")
                            {
                                btnAssignedStud_PrevRecord.Visible = false;
                            }
                            else
                            {
                                btnAssignedStud_PrevRecord.Visible = true;
                            }
                            if (Convert.ToInt32(lblAssignedTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                                btnAssignedStud_NextRecord.Visible = true;
                            else
                                btnAssignedStud_NextRecord.Visible = false;
                        }

                    }
                }

            }//close assigned Contacts if condition
            else if (ddlAction.SelectedValue == "Reassign")
            {
                if (ddlAssignedCampUser.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Assigned User");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Assigned User',class_name: 'gritter-error'});});</script>", false);
                    return;
                }
                if (ddlReassignedUser.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Reassigned User");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Reassigned User',class_name: 'gritter-error'});});</script>", false);
                    return;
                }
                if (ddlAssignedCampUser.SelectedValue == ddlReassignedUser.SelectedValue)
                {
                    Show_Error_Success_Box("E", "Reassigned User and Assigned User is Same");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Reassigned User and Assigned User is Same',class_name: 'gritter-error'});});</script>", false);
                    return;
                }

                string Contacts_Id = "", PKeyRecordId = "";
                foreach (DataListItem item in dlAssignCampaignContacts.Items)
                {
                    CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                    Label lblConId = (Label)item.FindControl("lblConId");
                    Label lblPKeyRecordId = (Label)item.FindControl("lblPKeyRecordId");

                    if ((chk1.Checked == true) && (chk1.Visible == true))
                    {
                        Contacts_Id = Contacts_Id + lblConId.Text + ",";
                        PKeyRecordId = PKeyRecordId + lblPKeyRecordId.Text + ",";
                    }
                }

                if (Contacts_Id == "")
                {
                    Show_Error_Success_Box("E", "Select atleast one contacts");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select atleast one contacts',class_name: 'gritter-error'});});</script>", false);
                    return;
                }

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                DataSet dsReassign = ProductController.Campaign_RemoveOrReassignContactsToUser(2, UserID, lblPkey.Text, ddlAssignedCampUser.SelectedValue, ddlReassignedUser.SelectedValue, Contacts_Id, PKeyRecordId);
                if (dsReassign.Tables[0].Rows.Count > 0)//Error Reassigned Record List
                {
                    for (int i = 0; i < dsReassign.Tables[0].Rows.Count; i++)
                    {
                        foreach (DataListItem item in dlAssignCampaignContacts.Items)
                        {
                            Label lblPKeyRecordId = (Label)item.FindControl("lblPKeyRecordId");

                            if (lblPKeyRecordId.Text == dsReassign.Tables[0].Rows[i]["PKeyRecordID"].ToString()) ////Error Record display Error
                            {
                                Label lblRecordStatus = (Label)item.FindControl("lblRecordStatus");
                                lblRecordStatus.Text = "This contact is already been asssigned to the user/agent selected";//because this contact is already assigend for this user
                                lblRecordStatus.CssClass = "red";
                                break;
                            }
                        }
                    }
                    foreach (DataListItem item in dlAssignCampaignContacts.Items)
                    {
                        Label lblRecordStatus = (Label)item.FindControl("lblRecordStatus");
                        CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                        if ((lblRecordStatus.Text == "") && (chk1.Checked == true) && (chk1.Visible == true))//if the Assigned contact successfully then display message Contact Assigned
                        {
                            lblRecordStatus.Text = "Contact Assigned";
                            lblRecordStatus.CssClass = "green";
                            chk1.Visible = false;
                        }
                    }

                }
                else //if all records Ressigned successfully
                {
                    //Record Assigned successfully
                    Show_Error_Success_Box("S", "Contacts Reassigned Successfully...!");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Reassigned Message', text: 'Contacts Reassigned Successfully...!',class_name: 'gritter-success'});});</script>", false);

                    if ((btnAssignedStud_NextRecord.Visible == false) && (btnAssignedStud_PrevRecord.Visible == false))
                    {
                        divRemoveReassignContactslist.Visible = false;
                        return;
                    }
                    else if (btnAssignedStud_NextRecord.Visible == false)
                    {
                        lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
                    }
                    DataSet ds = ProductController.Get_Campaign_Assigned_Student(2, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        divRemoveReassignContactslist.Visible = true;
                        dlAssignCampaignContacts.DataSource = ds.Tables[0];
                        dlAssignCampaignContacts.DataBind();

                        lblAssignedTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                        lblAssignedTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                        lblAssignedActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
                        btnAssignedStud_PrevRecord.Visible = false;
                        if (Convert.ToInt32(lblAssignedTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                            btnAssignedStud_NextRecord.Visible = true;
                        else
                            btnAssignedStud_NextRecord.Visible = false;

                        if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                            btnAssignedStud_PrevRecord.Visible = false;
                        else
                            btnAssignedStud_PrevRecord.Visible = true;
                    }
                    else//the record is not found
                    {
                        divRemoveReassignContactslist.Visible = false;
                        //Show_Error_Success_Box("E", "Contacts Not Found");
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Contacts not Found.',class_name: 'gritter-error'});});</script>", false);
                        return;
                    }
                }

            }  //close Reassigned Contacts if condition
            else if (ddlAction.SelectedValue == "Remove")
            {
                if (ddlAssignedCampUser.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Assigned User");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Assigned User',class_name: 'gritter-error'});});</script>", false);
                    return;
                }

                string Contacts_Id = "", PKeyRecordId = "";
                foreach (DataListItem item in dlAssignCampaignContacts.Items)
                {
                    CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                    Label lblConId = (Label)item.FindControl("lblConId");
                    Label lblPKeyRecordId = (Label)item.FindControl("lblPKeyRecordId");

                    if ((chk1.Checked == true) && (chk1.Visible == true))
                    {
                        Contacts_Id = Contacts_Id + lblConId.Text + ",";
                        PKeyRecordId = PKeyRecordId + lblPKeyRecordId.Text + ",";
                    }
                    //RowNum = lblRowNum.Text;
                }

                if (Contacts_Id == "")
                {
                    Show_Error_Success_Box("E", "Select atleast one contacts");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select atleast one contacts',class_name: 'gritter-error'});});</script>", false);
                    return;
                }
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                DataSet dsDelete = ProductController.Campaign_RemoveOrReassignContactsToUser(1, UserID, lblPkey.Text, ddlAssignedCampUser.SelectedValue, "", Contacts_Id, PKeyRecordId);
                if (dsDelete.Tables[0].Rows.Count > 0)//Error Record List
                {
                    for (int i = 0; i < dsDelete.Tables[0].Rows.Count; i++)
                    {
                        foreach (DataListItem item in dlAssignCampaignContacts.Items)
                        {
                            Label lblPKeyRecordId = (Label)item.FindControl("lblPKeyRecordId");

                            if (lblPKeyRecordId.Text == dsDelete.Tables[0].Rows[i]["PKeyRecordID"].ToString()) ////Error Record display Error
                            {
                                Label lblRecordStatus = (Label)item.FindControl("lblRecordStatus");
                                lblRecordStatus.Text = "Cannot Remove contact, try Reassigning";//because this contact is assigend only for one user
                                lblRecordStatus.CssClass = "red";
                                break;
                            }
                        }
                    }
                    foreach (DataListItem item in dlAssignCampaignContacts.Items)
                    {
                        Label lblRecordStatus = (Label)item.FindControl("lblRecordStatus");
                        CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                        if ((lblRecordStatus.Text == "") && (chk1.Checked == true) && (chk1.Visible == true))//if the Delete Record successfully then display message
                        {
                            lblRecordStatus.Text = "Delete";
                            lblRecordStatus.CssClass = "green";
                            chk1.Visible = false;
                        }
                    }
                }
                else  //If the all contacts are deleted
                {
                    Show_Error_Success_Box("S", "Contacts Deleted Successfully...!");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Delete Message', text: 'Contacts Deleted Successfully...!',class_name: 'gritter-success'});});</script>", false);

                    if ((btnAssignedStud_NextRecord.Visible == false) && (btnAssignedStud_PrevRecord.Visible == false))
                    {
                        divRemoveReassignContactslist.Visible = false;
                        return;
                    }
                    else if (btnAssignedStud_NextRecord.Visible == false)
                    {
                        lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
                    }
                    DataSet ds = ProductController.Get_Campaign_Assigned_Student(2, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        divRemoveReassignContactslist.Visible = true;
                        dlAssignCampaignContacts.DataSource = ds.Tables[0];
                        dlAssignCampaignContacts.DataBind();

                        lblAssignedTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                        lblAssignedTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                        lblAssignedActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
                        btnAssignedStud_PrevRecord.Visible = false;
                        if (Convert.ToInt32(lblAssignedTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                            btnAssignedStud_NextRecord.Visible = true;
                        else
                            btnAssignedStud_NextRecord.Visible = false;

                        if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                            btnAssignedStud_PrevRecord.Visible = false;
                        else
                            btnAssignedStud_PrevRecord.Visible = true;
                    }
                    else//the record is not found
                    {
                        divRemoveReassignContactslist.Visible = false;
                        //Show_Error_Success_Box("E", "Contacts Not Found");
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Contacts not Found.',class_name: 'gritter-error'});});</script>", false);
                        return;
                    }
                }
            }  //close Remove Contacts if
            else
            {
                Show_Error_Success_Box("E", "Select Action");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Select Action',class_name: 'gritter-error'});});</script>", false);
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

    protected void Linkbtnstdnm_Click(object sender, System.EventArgs e)
    {
        txtsmsstd.Text = "Dear [Full NAME]";
    }

    protected void Linkbtnstdfnm_Click(object sender, System.EventArgs e)
    {
        txtsmsstd.Text = "Dear [First NAME]";
    }

    protected void btnContactsSendSMS_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            string Contacts_Id = "";
            foreach (DataListItem item in dlStudContact_SMS.Items)
            {
                CheckBox chk1 = (CheckBox)item.FindControl("chk1");
                Label lblConId = (Label)item.FindControl("lblConId");
                Label lblMobileNo = (Label)item.FindControl("lblMobileNo");

                if ((chk1.Checked == true))
                {
                    if (lblMobileNo.Text != "")
                    {
                        Contacts_Id = Contacts_Id + lblConId.Text + ",";
                        //MobileNo = MobileNo + lblMobileNo.Text + ",";
                    }
                }
                //RowNum = lblRowNum.Text;
            }

            if (Contacts_Id == "")
            {
                Show_Error_Success_Box("E", "Select atleast one Contact");
                return;
            }
            lblSMSError.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalSms();", true);
            txtsmsstd.Text = "Dear [First Name]";
            lblSMSSendFlag.Text = "0";
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    protected void btnContactsSendSMSBack_Click(object sender, EventArgs e)
    {
        try
        {
            ControlVisibility("Result");
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    protected void btnDeleteCampaignContacts_Click(object sender, EventArgs e)
    {
        string ConId = "";
        foreach (DataListItem item in dlCampaignContacts.Items)
        {
            CheckBox chk1 = (CheckBox)item.FindControl("chk1");

            if ((chk1.Checked == true))
            {
                Label lblConId = (Label)item.FindControl("lblConId");
                ConId = ConId + lblConId.Text + ",";
            }
        }

        if (ConId == "")
        {
            Show_Error_Success_Box("E", "Select atleast one record");
            return;
        }

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        DataSet ds = ProductController.Delete_Campaign_PendingContacts(UserID, lblPkey.Text, ConId, "1");
        if (ds != null)
        {
            if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
            {
                if ((btnDeleteStud_NextRecord.Visible == false) && (btnDeleteStud_PrevRecord.Visible == true))
                {
                    lblDeleteRecPageNumber.Text = (Convert.ToInt32(lblDeleteRecPageNumber.Text) - 1).ToString();
                }
                Campaign_Detail_Delete_Contacts();
                Show_Error_Success_Box("S", "Record Deleted successfully.");
            }
        }
    }
    #endregion

    #region Function



    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivSearch.Visible = true;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivAssignStudent.Visible = false;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = false;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            DivRemoveUserAssignment.Visible = false;
            DivCampaignSMS.Visible = false;
            DivRemoveCampaignContacts.Visible = false;
        }
        if (Mode == "Add")
        {
            DivSearch.Visible = false;
            DivAddPanel.Visible = true;
            DivResultPanel.Visible = false;
            DivAssignStudent.Visible = false;
            BtnAdd.Visible = false;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            DivRemoveUserAssignment.Visible = false;
            DivCampaignSMS.Visible = false;
            DivRemoveCampaignContacts.Visible = false;
            //Clear Add Panel
            ddlCampaignTypeAdd.SelectedIndex = 0;
            txtCampaignNameAdd.Text = "";
            //ddlCampaignStatusAdd.SelectedIndex = 0;
            ddlCampaignStatusAdd.SelectedValue = "02";
            txtTargetAudienceAdd.Text = "";
            ddlCampaignSponsorAdd.SelectedIndex = 0;
            txtSponsorDescAdd.Text = "";
            txtExpectedCloseDate.Value = "";
            txtTargetSizeAdd.Text = "";
            //txtNumSentAdd.Text = "";
            ddlCampaignOwnerAdd.SelectedIndex = 0;
            ddlAddAcadYear.SelectedIndex = 0;
            //for (int cnt = 0; cnt <= ddlCampaignDataSourceAdd.Items.Count - 1; cnt++)
            //{
            //    if (ddlCampaignDataSourceAdd.Items[cnt].Selected == true)
            //    {
            //        ddlCampaignDataSourceAdd.Items[cnt].Selected = false;
            //    }
            //}
            ddlCompanyAdd.SelectedIndex = 0;
            ddlDivisionAdd.Items.Clear();
            ddlZoneAdd.Items.Clear();
            ddlCenterAdd.Items.Clear();
            ddlRoleAdd.SelectedIndex = 0;
            for (int cnt = 0; cnt <= ddlAssignedToAdd.Items.Count - 1; cnt++)
            {
                if (ddlAssignedToAdd.Items[cnt].Selected == true)
                {
                    ddlAssignedToAdd.Items[cnt].Selected = false;
                }
            }
            txtProductAdd.Text = "";
            txtBudgetCoastAdd.Text = "";
            txtActualCoastAdd.Text = "";
            txtExpectedResponseAdd.Text = "";
            txtExpectedRevenueAdd.Text = "";
            txtExpectedSalescountAdd.Text = "";
            txtActualSalesCountAdd.Text = "";
            txtExpectedResponseCountAdd.Text = "";
            txtActualResponseCountAdd.Text = "";
            txtExpectedROIAdd.Text = "";
            txtActualROIAdd.Text = "";
            //txtResourceStartDate.Value = "";
            //txtResourceEndDate.Value = "";
            //txtSourceAdd.Text = "";
            //txtResourceAproxCoastAdd.Text = "";
        }
        if (Mode == "Result")
        {
            DivSearch.Visible = false;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = true;
            DivAssignStudent.Visible = false;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            DivRemoveUserAssignment.Visible = false;
            DivCampaignSMS.Visible = false;
            DivRemoveCampaignContacts.Visible = false;
            DivRemoveCampaignContacts.Visible = false;
        }
        if (Mode == "AssignStudent")
        {
            DivSearch.Visible = false;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivAssignStudent.Visible = true;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            DivRemoveUserAssignment.Visible = false;
            DivCampaignSMS.Visible = false;
            DivRemoveCampaignContacts.Visible = false;
        }
        if (Mode == "RemoveReassignUserAssignment")
        {
            DivSearch.Visible = false;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivAssignStudent.Visible = false;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            DivRemoveUserAssignment.Visible = true;
            divRemoveReassignContactslist.Visible = false;
            DivCampaignSMS.Visible = false;
            DivRemoveCampaignContacts.Visible = false;
        }
        if (Mode == "RemoveCampaignContacts")
        {
            DivSearch.Visible = false;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivAssignStudent.Visible = false;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            DivRemoveUserAssignment.Visible = false;
            divRemoveReassignContactslist.Visible = false;
            DivCampaignSMS.Visible = false;
            DivRemoveCampaignContacts.Visible = true;
            txtstudentnamesearch.Text = "";
            txthandphonesearch.Text = "";
            btnDeleteStud_NextRecord.Visible = false;
            btnDeleteStud_PrevRecord.Visible = false;
        }
        if (Mode == "CampaignSMS")
        {
            DivSearch.Visible = false;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivAssignStudent.Visible = false;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            DivRemoveUserAssignment.Visible = false;
            divRemoveReassignContactslist.Visible = false;
            DivCampaignSMS.Visible = true;
            DivRemoveCampaignContacts.Visible = false;
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

    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlCompanyAdd, ds, "Company_Name", "Company_Code");
        ddlCompanyAdd.Items.Insert(0, "Select");
        ddlCompanyAdd.SelectedIndex = 0;
    }

    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlCompanyAdd.SelectedValue);
        //BindDDL(ddlDivisionAdd, ds, "Division_Name", "Division_Code");
        //ddlDivisionAdd.Items.Insert(0, "Select");
        //ddlDivisionAdd.SelectedIndex = 0;
        BindListBox(ddlDivisionAdd, ds, "Division_Name", "Division_Code");
    }

    private void BindZone()
    {
        ddlZoneAdd.Items.Clear();
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Division_Code = "";
        for (int cnt = 0; cnt <= ddlDivisionAdd.Items.Count - 1; cnt++)
        {
            if (ddlDivisionAdd.Items[cnt].Selected == true)
            {
                Division_Code = Division_Code + ddlDivisionAdd.Items[cnt].Value + ",";
            }
        }
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center_Campaign(2, UserID, Division_Code, "", ddlCompanyAdd.SelectedValue);
        //BindDDL(ddlZoneAdd, ds, "Zone_Name", "Zone_Code");        
        //ddlZoneAdd.Items.Insert(0, "Select");
        //ddlZoneAdd.SelectedIndex = 0;
        BindListBox(ddlZoneAdd, ds, "Zone_Name", "Zone_Code");
    }

    private void BindCenter()
    {
        ddlCenterAdd.Items.Clear();
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string ZoneCode = "";
        string Division_Code = "";

        for (int cnt = 0; cnt <= ddlDivisionAdd.Items.Count - 1; cnt++)
        {
            if (ddlDivisionAdd.Items[cnt].Selected == true)
            {
                Division_Code = Division_Code + ddlDivisionAdd.Items[cnt].Value + ",";
            }
        }

        for (int cnt = 0; cnt <= ddlZoneAdd.Items.Count - 1; cnt++)
        {
            if (ddlZoneAdd.Items[cnt].Selected == true)
            {
                ZoneCode = ZoneCode + ddlZoneAdd.Items[cnt].Value + ",";
            }
        }

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center_Campaign(1, UserID, Division_Code, ZoneCode, ddlCompanyAdd.SelectedValue);
        BindListBox(ddlCenterAdd, ds, "Center_name", "Center_Code");
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

    private void BindCampaignDetail()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Role_Campaign(1, UserID, "", "","","");

        ddlCampaignTypeAdd.DataSource = ds.Tables[0];
        ddlCampaignTypeAdd.DataTextField = "Desc";
        ddlCampaignTypeAdd.DataValueField = "ID";
        ddlCampaignTypeAdd.DataBind();
        ddlCampaignTypeAdd.Items.Insert(0, "Select");
        ddlCampaignTypeAdd.SelectedIndex = 0;

        ddlCampaignTypeSearch.DataSource = ds.Tables[0];
        ddlCampaignTypeSearch.DataTextField = "Desc";
        ddlCampaignTypeSearch.DataValueField = "ID";
        ddlCampaignTypeSearch.DataBind();
        ddlCampaignTypeSearch.Items.Insert(0, "");
        ddlCampaignTypeSearch.Items.Insert(1, "All");
        ddlCampaignTypeSearch.SelectedIndex = 0;


        ddlCampaignStatusAdd.DataSource = ds.Tables[1];
        ddlCampaignStatusAdd.DataTextField = "Desc";
        ddlCampaignStatusAdd.DataValueField = "ID";
        ddlCampaignStatusAdd.DataBind();
        ddlCampaignStatusAdd.Items.Insert(0, "Select");

        ddlCampaignStatusAdd.SelectedIndex = 0;

        DDLCampaignStatus.DataSource = ds.Tables[1];
        DDLCampaignStatus.DataTextField = "Desc";
        DDLCampaignStatus.DataValueField = "ID";
        DDLCampaignStatus.DataBind();
        DDLCampaignStatus.Items.Insert(0, "Select");
        DDLCampaignStatus.Items.Insert(1, "All");
        DDLCampaignStatus.SelectedIndex = 0;

        ddlCampaignSponsorAdd.DataSource = ds.Tables[2];
        ddlCampaignSponsorAdd.DataTextField = "Desc";
        ddlCampaignSponsorAdd.DataValueField = "ID";
        ddlCampaignSponsorAdd.DataBind();
        ddlCampaignSponsorAdd.Items.Insert(0, "Select");
        ddlCampaignSponsorAdd.SelectedIndex = 0;


        ddlCampaignOwnerAdd.DataSource = ds.Tables[3];
        ddlCampaignOwnerAdd.DataTextField = "User_Display_Name";
        ddlCampaignOwnerAdd.DataValueField = "User_Code";
        ddlCampaignOwnerAdd.DataBind();
        ddlCampaignOwnerAdd.Items.Insert(0, "Select");
        ddlCampaignOwnerAdd.SelectedIndex = 0;

        ddlAssignedToAdd.DataSource = ds.Tables[3];
        ddlAssignedToAdd.DataTextField = "User_Display_Name";
        ddlAssignedToAdd.DataValueField = "User_Code";
        ddlAssignedToAdd.DataBind();

        //ddlCampaignDataSourceAdd.DataSource = ds.Tables[4];
        //ddlCampaignDataSourceAdd.DataTextField = "Import_File_Name";
        //ddlCampaignDataSourceAdd.DataValueField = "Import_Run_No";
        //ddlCampaignDataSourceAdd.DataBind();

        ddlRoleAdd.DataSource = ds.Tables[5];
        ddlRoleAdd.DataTextField = "Role";
        ddlRoleAdd.DataValueField = "Role_Id";
        ddlRoleAdd.DataBind();
        ddlRoleAdd.Items.Insert(0, "Select");
        ddlRoleAdd.SelectedIndex = 0;

        //DataSet ds1 = ds.Tables[0].ToString();
        //BindDDL(ddlCampaignTypeAdd, ds, "Zone_Name", "Zone_Code");
    }


    private void Campaign_Detail_Delete_Contacts()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        dlCampaignContacts.DataSource = null;
        dlCampaignContacts.DataBind();

        DataSet ds = ProductController.Get_Campaign_Detail_PendingContacts(UserID, lblPkey.Text, txtstudentnamesearch.Text.Trim(), txthandphonesearch.Text.Trim(), lblDeleteRecPageNumber.Text, "1");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                lblCampaignTypeResult2.Text = ds.Tables[0].Rows[0]["Camp_Type"].ToString();
                lblCampaignNameResult2.Text = ds.Tables[0].Rows[0]["Camp_Name"].ToString();
                lblCampaignStatusResult2.Text = ds.Tables[0].Rows[0]["CampaignStatus"].ToString();
                lblCampaignTargetAudienceResult2.Text = ds.Tables[0].Rows[0]["Target_Audience"].ToString();
                lblCampaignSponsorResult2.Text = ds.Tables[0].Rows[0]["Campaign_Sponsor"].ToString();
                lblCampaignSponsorDescResult2.Text = ds.Tables[0].Rows[0]["Sponsor_Description"].ToString();
                lblCampaignExpectedCloseDateResult2.Text = ds.Tables[0].Rows[0]["ExpectedCloseDate"].ToString();
                lblTotalCampaignContactsResult2.Text = ds.Tables[0].Rows[0]["TotalCampaign_Contacts"].ToString();
                lblPendingCampaignContactsResult2.Text = ds.Tables[0].Rows[0]["TotalPendingContacts"].ToString();

                dlCampaignContacts.DataSource = ds.Tables[1];
                dlCampaignContacts.DataBind();

                lblTotalDContacts.Text = ds.Tables[2].Rows[0]["TotalSearchedContacts"].ToString();
                if (ds.Tables[2].Rows[0]["Prevbuttonflag"].ToString() == "1")
                    btnDeleteStud_PrevRecord.Visible = true;
                else
                    btnDeleteStud_PrevRecord.Visible = false;

                if (ds.Tables[2].Rows[0]["Nextbuttonflag"].ToString() == "1")
                    btnDeleteStud_NextRecord.Visible = true;
                else
                    btnDeleteStud_NextRecord.Visible = false;
            }
        }
        else
        {
            dlCampaignContacts.DataSource = null;
            dlCampaignContacts.DataBind();
        }
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

    private void CampaignAgentAssignedStudent()
    {
        // HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        //string UserID = cookie.Values["UserID"];
        lblPageNumber.Text = "1";
        DataSet ds = null;
        if (ddlAction.SelectedValue == "Assign Contacts")
        {
            ds = ProductController.Get_Campaign_Assigned_Student(3, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
        }
        else
        {
            ds = ProductController.Get_Campaign_Assigned_Student(2, ddlAssignedCampUser.SelectedValue, "", lblPkey.Text, "", "", "", lblPageNumber.Text);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            divRemoveReassignContactslist.Visible = true;
            dlAssignCampaignContacts.DataSource = ds.Tables[0];
            dlAssignCampaignContacts.DataBind();

            lblAssignedTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblAssignedTotalContacts2.Text = "Contacts Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();
            lblAssignedActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
            btnAssignedStud_PrevRecord.Visible = false;
            if (Convert.ToInt32(lblAssignedTotalContacts.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                btnAssignedStud_NextRecord.Visible = true;
            else
                btnAssignedStud_NextRecord.Visible = false;
        }
        else
        {
            Show_Error_Success_Box("E", "Contacts Not Found");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Contacts not Found.',class_name: 'gritter-error'});});</script>", false);
            return;
        }

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

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        ddlAcadYear.Items.Insert(0, "Select");
        ddlAcadYear.SelectedIndex = 0;
        BindDDL(ddlAddAcadYear, ds, "Acad_Year", "Acad_Year");
        ddlAddAcadYear.Items.Insert(0, "Select");
        ddlAddAcadYear.SelectedIndex = 0;
        BindDDL(DDLAcadYear_seruch, ds, "Acad_Year", "Acad_Year");
        DDLAcadYear_seruch.Items.Insert(0, "Select");
        DDLAcadYear_seruch.SelectedIndex = 0;
        
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

    private void BindContacts_Condition()
    {
        ddlCondition.Items.Clear();
        ddlCondition.Items.Insert(0, "Select");
        ddlCondition.Items.Insert(1, "In");
        ddlCondition.Items.Insert(2, "Not In");
        ddlCondition.SelectedIndex = 0;
    }
    #endregion









}