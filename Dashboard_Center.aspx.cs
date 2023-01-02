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


public partial class Dashboard_Center : System.Web.UI.Page
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
                    BindAcademicYear();
                    BindDivision();
                    BindCenter();
                    BindDashboradcounts();
                    string year = ddlAcadYear.SelectedValue;
                    string division = ddldivision.SelectedItem.Text;
                    string divisioncode = ddldivision.SelectedValue;
                    string centercode = ddlcenter.SelectedValue;
                    BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
                    HtmlAnchor Apendingadmissionageing = apendingaccountageing;
                    Apendingadmissionageing.HRef = "Pending_Account_Ageing.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                    HtmlAnchor Acancelledaccount = acancelledaccount;
                    Acancelledaccount.HRef = "Cancelled_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                    HtmlAnchor Aecsdone = aecsdone;
                    Aecsdone.HRef = "ECS_Done.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                    HtmlAnchor Aecspendingstatus = aecspendingstatus;
                    Aecspendingstatus.HRef = "ECS_Pending_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                    HtmlAnchor Apendingapprovalstatus = apendingapprovalstatus;
                    Apendingapprovalstatus.HRef = "Pending_Approval_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                    HtmlAnchor Afeesdeductions = afeesdeductions;
                    Afeesdeductions.HRef = "Fees_Deductions.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                    
                    HtmlAnchor aPendingAccountReasonwise = aPendingAccountsReasonwise;
                    aPendingAccountReasonwise.HRef = "Pending_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                    HtmlAnchor Apendingadmission = apendingaccount;
                    Apendingadmission.HRef = "Pending_Accounts_Reasonwise.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

                    HtmlAnchor aAccountsCancellationStatus1 = aAccountsCancellationStatus;
                    aAccountsCancellationStatus1.HRef = "Account_Cancellation_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                                       

                    HtmlAnchor ABouncedPaymentRecoveryStatus = aBouncedPaymentRecoveryStatus;
                    ABouncedPaymentRecoveryStatus.HRef = "Cheque_Followup.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";


                    HtmlAnchor bouncedPaymentsAgeing = aBouncedPaymentsAgeing;
                    aBouncedPaymentsAgeing.HRef = "BouncedChequeAging.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";


                    HtmlAnchor aBouncedAccount1 = aBlockedAccount;
                    aBlockedAccount.HRef = "Blocked_Cheque_Details.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

                    HtmlAnchor aPayementdeposited1 = aPayementdeposited;
                    aPayementdeposited.HRef = "PayementInClearing.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

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
        //ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;
        BindCenter();

    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddldivision.SelectedIndex == 0)
        {
            BindCenter();
            ddlcenter.Items.Clear();
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;

        }
        else
        {
            BindCenter();
            BindDashboradcountsonDivisionSelected();
            ddlcenter.SelectedIndex = 0;
            string year = ddlAcadYear.SelectedValue;
            string division = ddldivision.SelectedItem.Text;
            string divisioncode = ddldivision.SelectedValue;
            string centercode = ddlcenter.SelectedValue;
            BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
            HtmlAnchor Apendingadmissionageing = apendingaccountageing;
            Apendingadmissionageing.HRef = "Pending_Account_Ageing.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
           HtmlAnchor Acancelledaccount = acancelledaccount;
            Acancelledaccount.HRef = "Cancelled_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
            HtmlAnchor Aecsdone = aecsdone;
            Aecsdone.HRef = "ECS_Done.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
            HtmlAnchor Aecspendingstatus = aecspendingstatus;
            Aecspendingstatus.HRef = "ECS_Pending_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
            HtmlAnchor Apendingapprovalstatus = apendingapprovalstatus;
            Apendingapprovalstatus.HRef = "Pending_Approval_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
            HtmlAnchor Afeesdeductions = afeesdeductions;
            Afeesdeductions.HRef = "Fees_Deductions.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
            HtmlAnchor aPendingAccountReasonwise = aPendingAccountsReasonwise;
            aPendingAccountReasonwise.HRef = "Pending_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
            HtmlAnchor Apendingadmission = apendingaccount;
            Apendingadmission.HRef = "Pending_Accounts_Reasonwise.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

            HtmlAnchor aAccountsCancellationStatus1 = aAccountsCancellationStatus;
            aAccountsCancellationStatus1.HRef = "Account_Cancellation_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                         

            HtmlAnchor ABouncedPaymentRecoveryStatus = aBouncedPaymentRecoveryStatus;
            ABouncedPaymentRecoveryStatus.HRef = "Cheque_Followup.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

            HtmlAnchor bouncedPaymentsAgeing = aBouncedPaymentsAgeing;
            aBouncedPaymentsAgeing.HRef = "BouncedChequeAging.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";



            HtmlAnchor aBouncedAccount1 = aBlockedAccount;
            aBlockedAccount.HRef = "Blocked_Cheque_Details.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

            HtmlAnchor aPayementdeposited1 = aPayementdeposited;
            aPayementdeposited.HRef = "PayementInClearing.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

            //BindDashboradcounts();
            //HtmlAnchor aBouncedAccount1 = aBouncedAccount;
            //aBouncedAccount1.HRef = "Bounced_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        }
    }

    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", "MT");
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        //ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
        
    }

    private void BindDashboradcounts()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(20, UserID, ddldivision.SelectedValue, "", "MT");
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblpendingCount.InnerText = ds.Tables[0].Rows[0]["Admission_Pending_Count"].ToString();
            lblpendingCount1.InnerText = ds.Tables[0].Rows[0]["Admission_Pending_Count"].ToString();
            lblpendingCount2.InnerText = ds.Tables[0].Rows[0]["Admission_Pending_Count"].ToString();
            lblcancelladm.InnerText = ds.Tables[0].Rows[0]["Admission_Cancelled_Count"].ToString();
            lblcanelled.InnerText = ds.Tables[0].Rows[0]["Admission_Cancelled_Count"].ToString();
            lblECS.InnerText = ds.Tables[0].Rows[0]["ECS_Count"].ToString();

            lblblokedchque.InnerText = ds.Tables[0].Rows[0]["Cheque_Bloked_Count"].ToString();
            lblbouce.InnerText = ds.Tables[0].Rows[0]["Bounce_Cheque_Count"].ToString();
            lblDepositedchque.InnerText = ds.Tables[0].Rows[0]["Deposited_Count"].ToString();
            lblapprovals.InnerText = ds.Tables[0].Rows[0]["Pending_Approval_Count"].ToString();
            lblAcadyear.InnerText = ds.Tables[0].Rows[0]["acadyear"].ToString();
            lbldate.InnerText = ds.Tables[0].Rows[0]["Created_on"].ToString();
        }

    }

    private void BindDashboradcountsonDivisionSelected()
    {

       
        ddlcenter.SelectedIndex = 0;
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(21, UserID, divisioncode, "All", year);
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblpendingCount.InnerText = ds.Tables[0].Rows[0]["PendingAdmission"].ToString();
            lblpendingCount1.InnerText = ds.Tables[0].Rows[0]["PendingAdmission"].ToString();
            lblpendingCount2.InnerText = ds.Tables[0].Rows[0]["PendingAdmission"].ToString();
            lblcancelladm.InnerText = ds.Tables[1].Rows[0]["Canclledadmission"].ToString();
            lblcanelled.InnerText = ds.Tables[1].Rows[0]["Canclledadmission"].ToString();
            lblECS.InnerText = ds.Tables[2].Rows[0]["ECSDoneCount"].ToString();

            lblblokedchque.InnerText = ds.Tables[3].Rows[0]["Blockedcheque"].ToString();
            lblapprovals.InnerText = ds.Tables[4].Rows[0]["PendingAprovals"].ToString();
            lblbouce.InnerText = ds.Tables[5].Rows[0]["bouncedcheque"].ToString();
            lblDepositedchque.InnerText = ds.Tables[6].Rows[0]["Deposit"].ToString();
        
        }

    }

    private void BindDashboradcountsonCenterSelected()
    {

               
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(21, UserID, divisioncode, centercode, year);
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblpendingCount.InnerText = ds.Tables[0].Rows[0]["PendingAdmission"].ToString();
            lblpendingCount1.InnerText = ds.Tables[0].Rows[0]["PendingAdmission"].ToString();
            lblpendingCount2.InnerText = ds.Tables[0].Rows[0]["PendingAdmission"].ToString();
            lblcancelladm.InnerText = ds.Tables[1].Rows[0]["Canclledadmission"].ToString();
            lblcanelled.InnerText = ds.Tables[1].Rows[0]["Canclledadmission"].ToString();
            lblECS.InnerText = ds.Tables[2].Rows[0]["ECSDoneCount"].ToString();

            lblblokedchque.InnerText = ds.Tables[3].Rows[0]["Blockedcheque"].ToString();
            lblapprovals.InnerText = ds.Tables[4].Rows[0]["PendingAprovals"].ToString();
            lblbouce.InnerText = ds.Tables[5].Rows[0]["bouncedcheque"].ToString();
            lblDepositedchque.InnerText = ds.Tables[6].Rows[0]["Deposit"].ToString();

        }

    }
   

    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDashboradcountsonCenterSelected();
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
        HtmlAnchor Apendingadmissionageing = apendingaccountageing;
        Apendingadmissionageing.HRef = "Pending_Account_Ageing.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Acancelledaccount = acancelledaccount;
        Acancelledaccount.HRef = "Cancelled_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Aecsdone = aecsdone;
        Aecsdone.HRef = "ECS_Done.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Aecspendingstatus = aecspendingstatus;
        Aecspendingstatus.HRef = "ECS_Pending_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Apendingapprovalstatus = apendingapprovalstatus;
        Apendingapprovalstatus.HRef = "Pending_Approval_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Afeesdeductions = afeesdeductions;
        Afeesdeductions.HRef = "Fees_Deductions.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor aPendingAccountReasonwise = aPendingAccountsReasonwise;
        HtmlAnchor aAccountsCancellationStatus1 = aAccountsCancellationStatus;
        aAccountsCancellationStatus1.HRef = "Account_Cancellation_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                         
        aPendingAccountReasonwise.HRef = "Pending_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Apendingadmission = apendingaccount;
        Apendingadmission.HRef = "Pending_Accounts_Reasonwise.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                     
        HtmlAnchor ABouncedPaymentRecoveryStatus = aBouncedPaymentRecoveryStatus;
        ABouncedPaymentRecoveryStatus.HRef = "Cheque_Followup.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

        HtmlAnchor bouncedPaymentsAgeing = aBouncedPaymentsAgeing;
        aBouncedPaymentsAgeing.HRef = "BouncedChequeAging.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        
        HtmlAnchor aBouncedAccount1 = aBlockedAccount;
        aBlockedAccount.HRef = "Blocked_Cheque_Details.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        
        HtmlAnchor aPayementdeposited1 = aPayementdeposited;
        aPayementdeposited.HRef = "PayementInClearing.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

    
    
    }

    private void BindAcademicYear()
    {
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        ddlAcadYear.SelectedIndex = 0;

    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        BindDashboradcountsonCenterSelected();
        BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
        HtmlAnchor Apendingadmissionageing = apendingaccountageing;
        Apendingadmissionageing.HRef = "Pending_Account_Ageing.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Acancelledaccount = acancelledaccount;
        Acancelledaccount.HRef = "Cancelled_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Aecsdone = aecsdone;
        Aecsdone.HRef = "ECS_Done.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Aecspendingstatus = aecspendingstatus;
        Aecspendingstatus.HRef = "ECS_Pending_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Apendingapprovalstatus = apendingapprovalstatus;
        Apendingapprovalstatus.HRef = "Pending_Approval_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Afeesdeductions = afeesdeductions;
        Afeesdeductions.HRef = "Fees_Deductions.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor aPendingAccountReasonwise = aPendingAccountsReasonwise;
        HtmlAnchor aAccountsCancellationStatus1 = aAccountsCancellationStatus;
        aAccountsCancellationStatus1.HRef = "Account_Cancellation_Status.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                         
        aPendingAccountReasonwise.HRef = "Pending_Accounts.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
        HtmlAnchor Apendingadmission = apendingaccount;
        Apendingadmission.HRef = "Pending_Accounts_Reasonwise.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
                    
        HtmlAnchor ABouncedPaymentRecoveryStatus = aBouncedPaymentRecoveryStatus;
        ABouncedPaymentRecoveryStatus.HRef = "Cheque_Followup.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

        HtmlAnchor bouncedPaymentsAgeing = aBouncedPaymentsAgeing;
        aBouncedPaymentsAgeing.HRef = "BouncedChequeAging.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

        
        HtmlAnchor aBouncedAccount1 = aBlockedAccount;
        aBlockedAccount.HRef = "Blocked_Cheque_Details.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";

        HtmlAnchor aPayementdeposited1 = aPayementdeposited;
        aPayementdeposited.HRef = "PayementInClearing.aspx?Year=" + year + "&division=" + divisioncode + "&center=" + centercode + "";
       
    
    
    }
  
    private void BindChartsWithoutCategories(string year, string DivisionCode, string DivisionName, string ZoneCode, string ZoneName, string CenterCode)
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            DataSet ds = ProductController.GetDashboardValues_Centers(4, year, DivisionCode, ZoneCode, CenterCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string xmlstr = ds.Tables[0].Rows[0]["chart"].ToString();
                FusionCharts.SetRenderer("javascript");
                Literal0.Text = FusionCharts.RenderChart("FusionCharts/StackedColumn3DLine.swf", "", xmlstr, "Acad_Year_Admission", "100%", "500", false, true);
            }
        }
        catch (Exception ex)
        {
        }
    }

    
}