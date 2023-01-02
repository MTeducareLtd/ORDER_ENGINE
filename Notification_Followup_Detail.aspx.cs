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


public partial class Notification_Followup_Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                lblPageNumber.Text = "1";
                BindNotification_FollowupDetail();
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


    protected void btnStud_NextRecord_ServerClick(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
        lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
        BindNotification_FollowupDetail();
    }

    protected void btnStud_PrevRecord_ServerClick(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
        lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
        BindNotification_FollowupDetail();        
    }




    #endregion

    #region Function



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

    private void BindNotification_FollowupDetail()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        if (Request["flag"] != null)
        {
            DataSet ds = ProductController.Get_Notification_Followup_Detail(UserID, lblPageNumber.Text, Request["flag"].ToString());
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (Request["flag"].ToString() == "1")
                    {
                        lblNotificationName.Text = "Followup Not done In Lead";
                        lblHeader_Add.Text = "Followup Not done In Lead";
                        dlFollowupNotDoneInLead.Visible = true;
                        dlOverdueFollowupInLead.Visible = false;
                        dlFollowupNotDoneInOpportunity.Visible = false;
                        dlOverdueFollowupInOpportunity.Visible = false;
                        dlFollowupNotDoneInLead.DataSource = ds.Tables[0];
                        dlFollowupNotDoneInLead.DataBind();
                        lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                        lblTotalContacts2.Text = "Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
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
                            btnStud_NextRecord.Visible = false;
                            btnStud_PrevRecord.Visible = false;
                        }
                    }
                    else if (Request["flag"].ToString() == "2")  //Overdue Followup In Lead Detail
                    {
                        lblNotificationName.Text = "Overdue Followup In Lead Detail";
                        lblHeader_Add.Text = "Overdue Followup In Lead Detail";
                        dlFollowupNotDoneInLead.Visible = false;
                        dlOverdueFollowupInLead.Visible = true;
                        dlFollowupNotDoneInOpportunity.Visible = false;
                        dlOverdueFollowupInOpportunity.Visible = false;
                        dlOverdueFollowupInLead.DataSource = ds.Tables[0];
                        dlOverdueFollowupInLead.DataBind();
                        lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                        lblTotalContacts2.Text = "Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
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
                            btnStud_NextRecord.Visible = false;
                            btnStud_PrevRecord.Visible = false;
                        }
                    }
                    else if (Request["flag"].ToString() == "3")  //Followup Not done In Opportunity
                    {
                        lblNotificationName.Text = "Followup Not done In Opportunity";
                        lblHeader_Add.Text = "Followup Not done In Opportunity";
                        dlFollowupNotDoneInLead.Visible = false;
                        dlOverdueFollowupInLead.Visible = false;
                        dlFollowupNotDoneInOpportunity.Visible = true;
                        dlOverdueFollowupInOpportunity.Visible = false;
                        dlFollowupNotDoneInOpportunity.DataSource = ds.Tables[0];
                        dlFollowupNotDoneInOpportunity.DataBind();
                        lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                        lblTotalContacts2.Text = "Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
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
                            btnStud_NextRecord.Visible = false;
                            btnStud_PrevRecord.Visible = false;
                        }
                    }
                    else if (Request["flag"].ToString() == "4")  //Overdue Followup In Opportunity
                    {
                        lblNotificationName.Text = "Overdue Followup In Opportunity";
                        lblHeader_Add.Text = "Overdue Followup In Opportunity";
                        dlFollowupNotDoneInLead.Visible = false;
                        dlOverdueFollowupInLead.Visible = false;
                        dlFollowupNotDoneInOpportunity.Visible = false;
                        dlOverdueFollowupInOpportunity.Visible = true;
                        dlOverdueFollowupInOpportunity.DataSource = ds.Tables[0];
                        dlOverdueFollowupInOpportunity.DataBind();
                        lblTotalContacts.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();
                        lblTotalContacts2.Text = "Total No of Records: " + ds.Tables[1].Rows[0]["TotalRecords"].ToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
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
                            btnStud_NextRecord.Visible = false;
                            btnStud_PrevRecord.Visible = false;
                        }
                    }
                }
            }
        }
       
    }

       #endregion







    
}