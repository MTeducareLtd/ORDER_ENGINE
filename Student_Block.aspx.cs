using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Net.Http;
using LMSIntegration;
using System.Net.Http.Headers;

public partial class Student_Block : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ControlVisibility("Search");

            //BindDivision();
        }
    }
    #endregion

    #region Methods


    /// <summary>
    /// Fill drop down list and assign value and Text
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="ds"></param>
    /// <param name="txtField"></param>
    /// <param name="valField"></param>
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

    //private void BindDivision()
    //{

    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
    //    BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
    //    ddldivision.Items.Insert(0, "Select");
    //    ddldivision.SelectedIndex = 0;

    //}
    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindAcademicYear();
    }
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindCenter();
    }
    //private void BindCenter()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", "MT");
    //    BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
    //    ddlcenter.Items.Insert(0, "All");
    //    ddlcenter.SelectedIndex = 0;
    //}
    // protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindStream();
    //}
    //private void BindAcademicYear()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetAllAcadyear();
    //    BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
    //    ddlacademicyear.Items.Insert(0, "Select");
    //    //ddlacademicyear.SelectedIndex = 0;
    //    //if (ds.Tables[0].Rows.Count > 0)
    //    //{
    //    //    ddlacademicyear.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
    //    //}
    //}
    //private void BindStream()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue);
    //    BindListBox(ddlstreamname, ds, "Stream_Sdesc", "Stream_Code");
    //    ddlstreamname.Items.Insert(0, "All");
    //    ddlstreamname.SelectedIndex = 0;
    //}

    //private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    //{
    //    ddl.DataSource = ds;
    //    ddl.DataTextField = txtField;
    //    ddl.DataValueField = valField;
    //    ddl.DataBind();
    //}

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


    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            BtnShowSearchPanel.Visible = false;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }

    }






    /// <summary>
    /// Bind search  Datalist
    /// </summary>
    private void FillGrid()
    {
        try
        {
            Clear_Error_Success_Box();
            ControlVisibility("Result");

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = PaymentController.Get_studentForRoboassesplusBlock(Txtsbentrycode.Text, "", "");
            if (ds != null)
            {
                dlGridDisplay.DataSource = ds;
                dlGridDisplay.DataBind();
            }



            if (ds != null)
            {
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        lbltotalcount.Text = (ds.Tables[0].Rows.Count).ToString();
                    }
                    else
                    {
                        lbltotalcount.Text = "0";
                    }
                }
                else
                {
                    lbltotalcount.Text = "0";
                }
            }
            else
            {
                lbltotalcount.Text = "0";
            }


            //foreach (DataListItem dtlItem in dlGridDisplay.Items)
            //{
            //    DropDownList ddlAction = (DropDownList)dtlItem.FindControl("ddlAction");
            //    DropDownList DDLRemarks = (DropDownList)dtlItem.FindControl("DDLRemarks");
            //    Label lblStatus = (Label)dtlItem.FindControl("lblStatus");
            //    Label lblPayModeCode = (Label)dtlItem.FindControl("lblPayModeCode");

            //    if (lblStatus.Text == "01")//Pending
            //    {
            //        ddlAction.Items.Add("Select");
            //        //ddlAction.Items.Add("Deposited");
            //        ddlAction.Items.Add("Blocked");
            //        DDLRemarks.Items.Add("Select");
            //        DDLRemarks.Items.Add("Change In Parents Account");
            //        DDLRemarks.Items.Add("Admission Cancellation");
            //        DDLRemarks.Items.Add("Refund");

            //    }
            //    //else if (lblStatus.Text == "04")//Deposited
            //    //{
            //    //    if (lblPayModeCode.Text == "04")//if Pay mode is CREDIT / DEBIT CARD
            //    //    {
            //    //        ddlAction.Items.Add("Select");
            //    //        ddlAction.Items.Add("Cleared");
            //    //        ddlAction.Items.Add("Bounced");
            //    //        ddlAction.Items.Add("Blocked");
            //    //    }
            //    //    else
            //    //    {
            //    //        ddlAction.Items.Add("Select");
            //    //        ddlAction.Items.Add("Cleared");
            //    //        ddlAction.Items.Add("Bounced");
            //    //        // ddlAction.Items.Add("Blocked");
            //    //    }
            //    //}
            //}
        }
        catch (Exception ex)
        {

            Show_Error_Success_Box("E", ex.ToString());
            UpdatePanelMsgBox.Update();
            return;
        }
    }

    #endregion



    #region Event's


    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {

    }

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }


    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        FillGrid();
    }

    //protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    if (ddlpaymode.SelectedValue == "01")//CHEQUE
    //    {
    //        trChequeTransaction.Visible = true;
    //        lblChTrNo.Text = "Cheque No";
    //        lblChTrStatus.Text = "Cheque Status";
    //    }
    //    else if (ddlpaymode.SelectedValue == "02")//DEMAND DRAFT
    //    {
    //        trChequeTransaction.Visible = true;
    //        lblChTrNo.Text = "DD No";
    //        lblChTrStatus.Text = "DD Status";
    //    }
    //    else if (ddlpaymode.SelectedValue == "04")//CREDIT / DEBIT CARD
    //    {
    //        trChequeTransaction.Visible = true;
    //        lblChTrNo.Text = "Transaction No";
    //        lblChTrStatus.Text = "Transaction Status";
    //    }
    //    else if (ddlpaymode.SelectedValue == "05")//CREDIT / DEBIT CARD
    //    {
    //        trChequeTransaction.Visible = true;
    //        lblChTrNo.Text = "Transaction No";
    //        lblChTrStatus.Text = "Transaction Status";
    //    }
    //    else
    //    {
    //        trChequeTransaction.Visible = false;
    //    }
    //}


    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox s = sender as CheckBox;
            //Set checked status of hidden check box to items in grid
            foreach (DataListItem dtlItem in dlGridDisplay.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
                if (chkitemck.Visible == true)
                {
                    TextBox txtAmount = (TextBox)dtlItem.FindControl("txtAmount");
                    TextBox txtremarks = (TextBox)dtlItem.FindControl("txtremarks");
                    Label lblErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");
                    Label lblamt = (Label)dtlItem.FindControl("lblamt");

                    chkitemck.Checked = s.Checked;
                    if (s.Checked == true)
                    {
                        txtAmount.Visible = true;
                        txtremarks.Visible = true;
                        lblamt.Visible = false;
                    }
                    else
                    {
                        txtAmount.Visible = false;
                        txtremarks.Visible = false;
                        lblamt.Visible = true;
                        txtAmount.Text = "";
                        txtremarks.Text = "";
                        lblErrorSaveMessage.Text = "";
                    }

                }
            }
            Clear_Error_Success_Box();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    protected void chkCheck_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox s = sender as CheckBox;
            dynamic row = (DataListItem)s.NamingContainer;
            TextBox txtAmount = row.FindControl("txtAmount");
            TextBox txtremarks = row.FindControl("txtremarks");
            Label lblamt = row.FindControl("lblamt");
            Label lblErrorSaveMessage = row.FindControl("lblErrorSaveMessage");

            if (s.Checked == true)
            {
                txtAmount.Visible = true;
                txtremarks.Visible = true;
                lblamt.Visible = false;
            }
            else
            {
                txtAmount.Visible = false;
                txtremarks.Visible = false;
                lblamt.Visible = true;
                txtAmount.Text = "";
                txtremarks.Text = "";
                lblErrorSaveMessage.Text = "";
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    protected void BtnstuentacitveInactivesave_ServerClick(object sender, EventArgs e)
    {


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        //string XMLData = "<Payments>";
        //int i = 0, j = 0;
        foreach (DataListItem dtlItem in dlGridDisplay.Items)
        {

            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

            if (chkCheck.Checked == true)
            {
                //i = 1;
                TextBox SPID = (TextBox)dtlItem.FindControl("lblspi");
                TextBox STUDENTNAME = (TextBox)dtlItem.FindControl("lblStudentName");
                TextBox CENTERCODE = (TextBox)dtlItem.FindControl("LblCenterCode");
                TextBox SBENTRYCODE = (TextBox)dtlItem.FindControl("LBLSBENTRYCODE");


                {



                    DataSet ds = new DataSet();
                    ds = PaymentController.Update_insert_student_BLOCK_data(Ddlstudentstatus.SelectedValue, txtCenterremarks.Text, SPID.Text, SBENTRYCODE.Text, CENTERCODE.Text,STUDENTNAME.Text, UserID);
                    if (ds != null)
                    {
                        //Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");
                        if (ds.Tables[0].Rows[0]["ErrorSaveId"].ToString() == "-2") //Error Record
                        {
                            //lblErrorSaveMessage.CssClass = "red";
                            //lblErrorSaveMessage.Text = ds.Tables[0].Rows[0]["lblErrorSaveMessage"].ToString();
                        }
                        else if (ds.Tables[0].Rows[0]["ErrorSaveId"].ToString() == "1") //Save Record
                        {
                            //lblErrorSaveMessage.CssClass = "green";
                            //lblErrorSaveMessage.Text = ds.Tables[0].Rows[0]["lblErrorSaveMessage"].ToString();

                        }

                    }
                }
            }
        }

        //if (i == 1 && j == 0)//if the Error is not come and atleast one Record is selected then save
        //{
        //    XMLData = XMLData + "</Payments>";
        //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        //    string Created_By = cookie.Values["UserID"];
        //    DataSet ds = new DataSet();
        //    ds = PaymentController.Update_Cheque_Management_blocked_cheque(XMLData, Created_By, "1");
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count != 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                int k = 0;
        //                while (ds.Tables[0].Rows.Count > k)
        //                {
        //                    foreach (DataListItem dtlItem in dlGridDisplay.Items)
        //                    {
        //                        Label lblRowNum = (Label)dtlItem.FindControl("lblRowNo");
        //                        if (lblRowNum.Text.Trim() == ds.Tables[0].Rows[k]["RowNum"].ToString())
        //                        {
        //                            Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");
        //                            if (ds.Tables[0].Rows[k]["ErrorSaveId"].ToString() == "-2") //Error Record
        //                            {
        //                                lbErrorSaveMessage.CssClass = "red";
        //                                lbErrorSaveMessage.Text = ds.Tables[0].Rows[k]["ErrorSaveMessage"].ToString();
        //                            }
        //                            else if (ds.Tables[0].Rows[k]["ErrorSaveId"].ToString() == "1") //Save Record
        //                            {
        //                                lbErrorSaveMessage.CssClass = "green";
        //                                lbErrorSaveMessage.Text = ds.Tables[0].Rows[k]["ErrorSaveMessage"].ToString();

        //                            }
        //                            break;
        //                        }
        //                    }
        //                    k++;
        //                }
        //            }
        //        }
        //    }
        //}
    }
    protected void dlGridDisplay_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Ledger")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalstatusMessage();", true);
        }

    }

    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#BlockStudent').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalRegistrationMessagehide();", false);
    }


    //send to LMS
    private void Send_Details_LMS(string Partner_Code)
    {
        string Response_Status_Code = "";
        string Response_Return_Phrase = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        try
        {
            DataSet dsdetails = ProductController.GET_PARTNER_DETAILS(Partner_Code);
            if (dsdetails.Tables[0].Rows.Count > 0)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(DBConnection.connStringLMS);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var partnerdetailsinsert = new partnerdetailsinsert();
                partnerdetailsinsert.TeacherCode = dsdetails.Tables[0].Rows[0]["Partner_Code"].ToString();
                partnerdetailsinsert.TeacherName = dsdetails.Tables[0].Rows[0]["TeacherName"].ToString();
                partnerdetailsinsert.Sex = dsdetails.Tables[0].Rows[0]["Sex"].ToString();
                partnerdetailsinsert.JoiningDate = Convert.ToDateTime(dsdetails.Tables[0].Rows[0]["DOJ"]);
                partnerdetailsinsert.CreatedOn = Convert.ToDateTime(dsdetails.Tables[0].Rows[0]["Created_On"]);
                partnerdetailsinsert.CreatedBy = dsdetails.Tables[0].Rows[0]["Created_By"].ToString();
                partnerdetailsinsert.ModifiedOn = Convert.ToDateTime(dsdetails.Tables[0].Rows[0]["Modified_On"]);
                partnerdetailsinsert.ModifiedBy = dsdetails.Tables[0].Rows[0]["ModifiedBy"].ToString();
                partnerdetailsinsert.IsActive = Convert.ToBoolean(dsdetails.Tables[0].Rows[0]["IsActive"]);
                partnerdetailsinsert.IsDeleted = Convert.ToBoolean(dsdetails.Tables[0].Rows[0]["IsDeleted"]);

                var response = client.PostAsJsonAsync("teacher/addUpdTeacherMaster", partnerdetailsinsert).Result;

                Response_Status_Code = response.StatusCode.ToString();
                Response_Return_Phrase = response.ReasonPhrase;

                if (response.StatusCode.ToString() == "OK")
                {

                    var partneraccountetailsinsert = new partneraccountetailsinsert();
                    partneraccountetailsinsert.TeacherCode = dsdetails.Tables[0].Rows[0]["Partner_Code"].ToString();
                    partneraccountetailsinsert.TeacherEmailId = dsdetails.Tables[0].Rows[0]["EMailId"].ToString();
                    partneraccountetailsinsert.TeacherLoginId = dsdetails.Tables[0].Rows[0]["Partner_Code"].ToString();
                    partneraccountetailsinsert.Password = dsdetails.Tables[0].Rows[0]["Password"].ToString();
                    partneraccountetailsinsert.CreatedOn = Convert.ToDateTime(dsdetails.Tables[0].Rows[0]["Created_On"]);
                    partneraccountetailsinsert.CreatedBy = dsdetails.Tables[0].Rows[0]["Created_By"].ToString();
                    partneraccountetailsinsert.ModifiedOn = Convert.ToDateTime(dsdetails.Tables[0].Rows[0]["Modified_On"]);
                    partneraccountetailsinsert.ModifiedBy = dsdetails.Tables[0].Rows[0]["ModifiedBy"].ToString();
                    partneraccountetailsinsert.IsActive = Convert.ToBoolean(dsdetails.Tables[0].Rows[0]["IsActive"]);
                    partneraccountetailsinsert.IsDeleted = Convert.ToBoolean(dsdetails.Tables[0].Rows[0]["IsDeleted"]);

                    var responseaccount = client.PostAsJsonAsync("teacher/addUpdTeacherAccountDetails", partneraccountetailsinsert).Result;

                    Response_Status_Code = response.StatusCode.ToString();
                    Response_Return_Phrase = response.ReasonPhrase;

                    if (responseaccount.StatusCode.ToString() == "OK")
                    {
                        DataSet dsreturn = ProductController.UPDATE_DBSYNCFLAG_LMSSERVICE(1, 1, Partner_Code, responseaccount.StatusCode.ToString(), responseaccount.ReasonPhrase, UserID);
                    }

                    else
                    {
                        DataSet dsreturn = ProductController.UPDATE_DBSYNCFLAG_LMSSERVICE(1, -1, Partner_Code, responseaccount.StatusCode.ToString(), responseaccount.ReasonPhrase, UserID);
                    }
                }
                else
                {
                    DataSet dsreturn = ProductController.UPDATE_DBSYNCFLAG_LMSSERVICE(1, -1, Partner_Code, response.StatusCode.ToString(), response.ReasonPhrase, UserID);
                }
            }



        }
        catch (Exception e)
        {
            DataSet dsreturn = ProductController.UPDATE_DBSYNCFLAG_LMSSERVICE(1, -1, Partner_Code, Response_Status_Code, Response_Return_Phrase, UserID);
        }
    }
    class partnerdetailsinsert
    {
        public string TeacherCode { get; set; }
        public string TeacherName { get; set; }
        public string Sex { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }


    }
    class partneraccountetailsinsert
    {
        public string TeacherCode { get; set; }
        public string TeacherEmailId { get; set; }
        public string TeacherLoginId { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }


    }

    #endregion
}