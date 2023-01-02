btnsavediscreq_ServerClickusing System;
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
using Encryption.BL;
using ChequeReturnRequest;


public partial class Accounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "Manage Account";
                lblpagetitle2.Text = "Search Panel";
                lblmidbreadcrumb.Text = "Manage Account";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divpendingreuesterror.Visible = false;
                upnlsearch.Visible = true;
                Upnlviewledger.Visible = false;
                listudentstatus.Visible = false;
                btnviewenrollment.Visible = false;
                btnviewenv.Visible = false;
                btnback.Visible = false;
                imgstudentphotodisplay.Visible = false;
                btnsearchback.Visible = false;

                tdapplicationid.Visible = true;
                tdapplicationid1.Visible = true;

                divmessage.Visible = false;
                divSearch.Visible = true;
                divsearchresults.Visible = false;
                diveditpayemnt.Visible = false;
                BindCompany();
                BindDivision();
                //BindPayplan();
                BindProductCategory();
                BindAcademicYear();
                BindStream();
                if (Request["SBEntryCode"] != null)
                {
                    string SBEntrycode = Request["SBEntryCode"];
                    if (SBEntrycode != "")
                    {
                        try
                        {
                            Viewledger(SBEntrycode);
                        }
                        catch (Exception ex)
                        {
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = ex.Message;
                            Response.Redirect("Errorpages/500.aspx");
                        }
                    }
                }
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

    private void BindProductCategory()
    {
        DataSet ds = ProductController.GetallOpporProductCategory();
        BindDDL(ddlproductcategory, ds, "Description", "ID");
        ddlproductcategory.Items.Insert(0, "All");
        ddlproductcategory.SelectedIndex = 0;
    }




    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center_Top1(1, UserID, "", "", "");
        ddlcompany.DataSource = ds.Tables[0];
        ddlcompany.DataTextField = "Company_Name";
        ddlcompany.DataValueField = "Company_Code";
        ddlcompany.DataBind();
        ddlcompany.Items.Insert(0, "All");
        ddlcompany.SelectedIndex = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlcompany.SelectedValue = ds.Tables[0].Rows[0]["Company_Code"].ToString();
            ddldivision.DataSource = ds.Tables[1];
            ddldivision.DataTextField = "division_name";
            ddldivision.DataValueField = "division_code";
            ddldivision.DataBind();
            ddldivision.Items.Insert(0, "All");
            ddldivision.SelectedIndex = 0;
            if (ddldivision.Items.Count > 1)
            {
                ddldivision.SelectedIndex = 1;
                //ddlzone.DataSource = ds.Tables[2];
                //ddlzone.DataTextField = "Zone_Name";
                //ddlzone.DataValueField = "Zone_Code";
                //ddlzone.DataBind();
                //ddlzone.Items.Insert(0, "All");
                //ddlzone.SelectedIndex = 0;
                if (ddldivision.Items.Count > 1)
                {
                    //ddlzone.SelectedIndex = 1;
                    ddlcenter.DataSource = ds.Tables[3];
                    ddlcenter.DataTextField = "center_name";
                    ddlcenter.DataValueField = "center_code";
                    ddlcenter.DataBind();
                    ddlcenter.Items.Insert(0, "All");
                    ddlcenter.SelectedIndex = 0;
                    if (ddlcenter.Items.Count > 1)
                    {
                        ddlcenter.SelectedIndex = 1;
                    }
                }
                else
                {
                    ddlcenter.Items.Insert(0, "All");
                    ddlcenter.SelectedIndex = 0;
                }
            }
            else
            {
                //ddlzone.Items.Insert(0, "All");
                //ddlzone.SelectedIndex = 0;
                ddlcenter.Items.Insert(0, "All");
                ddlcenter.SelectedIndex = 0;
            }
        }
        else
        {
            ddldivision.Items.Insert(0, "All");
            ddldivision.SelectedIndex = 0;
            //ddlzone.Items.Insert(0, "All");
            //ddlzone.SelectedIndex = 0;
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;
        }


    }

    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDivision();
        //BindCenter();
    }
    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlcompany.SelectedValue);
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;
        BindCenter();

    }
    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddldivision.SelectedIndex == 0)
        {
            //ddlzone.Items.Clear();
            //ddlzone.Items.Insert(0, "All");
            //ddlzone.SelectedIndex = 0;
            BindCenter();
            ddlcenter.Items.Clear();
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;

        }
        else
        {
            //ddlzone.Items.Clear();
            //ddlzone.Items.Insert(0, "All");
            //ddlzone.SelectedIndex = 0;
            //BindZone();
            BindCenter();
            //ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;
        }
    }

    //private void BindZone()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
    //    BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
    //    ddlzone.Items.Insert(0, "All");
    //    ddlzone.SelectedIndex = 0;
    //}
    //protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    //{

    //    BindCenter();
    //}
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }
    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
    }
    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlacademicyear.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
        }
    }
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
    }
    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue);
        BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlstream.Items.Insert(0, "All");
        ddlstream.SelectedIndex = 0;
    }

    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string StudentName = "";
        string Applicationno = "";
        string Company = "";
        string Division = "";
        string Zone = "";
        string Center = "";
        string AcademicYear = "";
        string Stream = "";

        StudentName = txtstudentname.Text;
        Applicationno = txtapplicationno.Text;
        Company = ddlcompany.SelectedValue;
        Division = ddldivision.SelectedValue;
        Zone = "All";
        Center = ddlcenter.SelectedValue;
        AcademicYear = ddlacademicyear.SelectedValue;
        Stream = ddlstream.SelectedValue;

        string Customer_Type = "";
        string Institutiontype = "";
        string Boardid = "";
        string Standard = "";
        string Mobile = "";
        string Country = "";
        string State = "";
        string City = "";
        string Location = "";
        string Productcategory = "";
        string Fromdate = "";
        string Todate = "";
        string OrderStatus = "";
        string Sbentrycode = "";
        string Active = "";
        string Promoted = "";
        if (Chkactive.Checked == true)
        {
            Active = "1";
        }
        else
        {
            Active = "0";
        }
        Promoted = "0";


        Customer_Type = "All";
        Institutiontype = "All";
        Boardid = "All";
        Standard = "All";
        Mobile = "";
        Country = "All";
        State = "All";
        City = "All";
        Location = "All";
        Productcategory = "All";
        Fromdate = "";
        Todate = "";
        OrderStatus = ddlorderstatus.SelectedValue;
        Sbentrycode = txtsbentrycode.Text;


        DataSet ds = AccountController.Get_Account_Search_Results(StudentName, Applicationno, Company, Division, Zone, Center, AcademicYear, Stream, UserID, Customer_Type,
        Institutiontype, Boardid, Standard, Mobile, Country, State, City, Location, Productcategory, Fromdate,
        Todate, OrderStatus, Sbentrycode, Active, Promoted);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Manage Account";
            lblpagetitle2.Text = "Search Results";
            lblmidbreadcrumb.Text = "Manage Account";
            lbllastbreadcrumb.Text = " Account Search Results";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            divmessage.Visible = false;
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            script1.RegisterAsyncPostBackControl(Repeater1);
            btnsearchback.Visible = true;
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            btnsearchback.Visible = false;
            divmessage.Visible = true;
            lblmessage.Text = "No Records Found!";
        }
    }

    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Ledger")
            {
               
                upnlsearch.Visible = false;
                Upnlviewledger.Visible = true;
                lblpagetitle1.Text = "View Ledger";
                lblpagetitle2.Text = "";
                lblmidbreadcrumb.Text = "Manage Account";
                lbllastbreadcrumb.Text = "View Ledger";
                imgstudentphotodisplay.Visible = true;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                btnback.Visible = true;
                string Cur_Sb_Code = "";
                Cur_Sb_Code = e.CommandArgument.ToString();
                Session["CUR_SB_Code"] = e.CommandArgument.ToString();
                diverrorPayment.Visible = false;
                divSuccessPayment.Visible = false;
                btnviewenrollment.Visible = false;
                txtcursbcode.Text = Cur_Sb_Code;
                btnviewenv.Visible = false;
                Bindlist(Cur_Sb_Code);
                BindStudentSubjectGroup(Cur_Sb_Code);
                Bindpayment(Cur_Sb_Code);
                BindECS_Detail(Cur_Sb_Code);

                BindChequeallocationTable(Cur_Sb_Code);
                BindStudentLedger();
                BindChequeOutstanding();
                Bindrequestdetails();
                diveditpayemnt.Visible = false;
                string oppid = txtopportunityid.Text;
                string Cur_sb_code1 = txtcursbcode.Text;


                HtmlAnchor viewenrollment = btnviewenrollment;
                viewenrollment.HRef = "View_Order.aspx?&Cur_Sb_Code=" + Cur_sb_code1 + "&Oppid=" + oppid;
                HtmlAnchor viewenv = btnviewenv;
                viewenv.HRef = "Account_Edit.aspx?&Oppur_ID=" + oppid;
                divpayment.Visible = false;
                divorder.Visible = false;
                lblheadertext.Text = "Payment Details";
                Bindorder();
                Bindorderdetails();
                HtmlAnchor Aprint = aprint;
                //Aprint.Visible = true;
                string PPCode = "PP011";
                Aprint.HRef = "RCL.aspx?SBECode=" + Cur_Sb_Code + "&PPCode=" + PPCode + "";
                //BindOLdfeechart();
                DataSet dsdetails = ProductController.GetoldSbentrycodeforPrint(Cur_Sb_Code);
                //if (dsdetails != null) 
                
                if (dsdetails.Tables[0].Rows.Count > 0)
                {
                    string sbenrtycode = Convert.ToString(dsdetails.Tables[0].Rows[0]["sbentrycode"]);
                    aprint2.HRef = "RCL.aspx?SBECode=" + sbenrtycode + "&PPCode=" + PPCode + "";

                }







                // Pending to Do
                achequereturnrequest.Visible = true;
                //
                string Admissiondate = txtadmndate.Text;
                string AdmissionStatus = ((Label)e.Item.FindControl("Label30")).Text;
                string Staxvalidation = ProductController.GetApplication_Rights("", Cur_Sb_Code);
                HtmlAnchor EventAfterCourseDuration = aEventAfterCourseDuration;
                aEventAfterCourseDuration.Visible = false;
                aEventAfterCourseDuration.HRef = "CD.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;

                HtmlAnchor AEventECS = aEventECS;
                AEventECS.HRef = "Request_ECS.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                btnproceedECS.Visible = false;
                //if the student status is Pending and first cheque entry is entered then ECS request visible true
                if ((lblstdstaus.Text == "Student Status : Pending") && (dlpaymentreceipt.Visible == true))
                {
                    btnproceedECS.Visible = true;
                }





                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];


                if (Staxvalidation == "A100002")
                {
                    aconcessionreq.Visible = true;
                    adiscountreq.Visible = true;
                    awaiverreq.Visible = false;
                    acanceladdmission.Visible = true;
                    arefundrequest.Visible = false;
                    abaddebtsrequest.Visible = false;
                    btnadjustment.Visible = true;
                    HtmlAnchor Addsubject = aaddsubject;
                    Addsubject.Visible = true;
                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor Removesubject = aremovesubject;
                    Removesubject.Visible = true;
                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor ChangeSubject = achangeproduct;
                    ChangeSubject.Visible = false;
                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor streamchange = astreamchange;
                    streamchange.Visible = false;
                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor payplan = apayplanchange;
                    payplan.Visible = false;
                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor transfer = atransfer;
                    transfer.Visible = false;
                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    divErrormessage.Visible = true;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = "Events Blocked for GST rollout";
                    btnEvent.Visible = true;
                    aEventAfterCourseDuration.Visible = false;
                    RequestEneble();

                    if (lblSubmitBankLoanFlag.Text == "1")
                    {
                        Div18.Visible = false;//  Hide Adjustment Button
                        btnpayment1.Visible = false;
                        btnEvent.Visible = false;
                        aEventAfterCourseDuration.Visible = false;
                        btnrequest.Visible = false;
                        btnLoan.Visible = false;
                    }
                    return;

                }
                else
                {
                    string VerifyChequeStr = "";
                    decimal instr_amt = 0;
                    string Allowevents = "";
                    Allowevents = AccountController.Verify_Event_Allow(Cur_Sb_Code, 1);
                    if (Allowevents != "Success")
                    {
                        aconcessionreq.Visible = true;
                        adiscountreq.Visible = true;
                        awaiverreq.Visible = false;
                        acanceladdmission.Visible = false;
                        arefundrequest.Visible = true;
                        abaddebtsrequest.Visible = false;
                        btnadjustment.Visible = true;
                        HtmlAnchor Addsubject = aaddsubject;
                        Addsubject.Visible = false;
                        Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor Removesubject = aremovesubject;
                        Removesubject.Visible = false;
                        Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor ChangeSubject = achangeproduct;
                        ChangeSubject.Visible = false;
                        ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor streamchange = astreamchange;
                        streamchange.Visible = false;
                        streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor payplan = apayplanchange;
                        payplan.Visible = false;
                        payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor transfer = atransfer;
                        transfer.Visible = false;
                        transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Few Events are Not available on the same day";
                        btnEvent.Visible = false;
                        aEventAfterCourseDuration.Visible = false;
                        RequestEneble();

                        if (lblSubmitBankLoanFlag.Text == "1")
                        {
                            Div18.Visible = false;//  Hide Adjustment Button
                            btnpayment1.Visible = false;
                            btnEvent.Visible = false;
                            aEventAfterCourseDuration.Visible = false;
                            btnrequest.Visible = false;
                            btnLoan.Visible = false;
                        }
                        return;
                    }
                    else
                    {
                        VerifyChequeStr = AccountController.Verify_Rule_Event_Activation(Cur_Sb_Code, instr_amt, "", 2);
                        DataSet ds = AccountController.GetPaymentDetailsbySBEntrycode(Cur_Sb_Code);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string studentstatus = lblstdstaus.Text;
                            if (studentstatus == "Student Status : Pending")
                            {

                                if (VerifyChequeStr == "Success")
                                {
                                    aconcessionreq.Visible = true;
                                    adiscountreq.Visible = true;
                                    awaiverreq.Visible = true;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    btnadjustment.Visible = true;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = true;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    aEventAfterCourseDuration.Visible = false;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;

                                }
                                else if (VerifyChequeStr == "First Cheque In Pending Status, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = true;
                                    adiscountreq.Visible = true;
                                    btnadjustment.Visible = true;
                                    awaiverreq.Visible = true;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = false;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    btnEvent.Visible = false;
                                    aEventAfterCourseDuration.Visible = false;
                                    btnrequest.Visible = true;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "First Cheque In Deposited Status, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = false;
                                    btnadjustment.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = false;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = false;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    btnEvent.Visible = false;
                                    aEventAfterCourseDuration.Visible = false;
                                    btnrequest.Visible = true;
                                    RequestEneble();


                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "First Cheque Is Bounced Status, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = true;
                                    adiscountreq.Visible = true;
                                    btnadjustment.Visible = true;
                                    awaiverreq.Visible = true;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = false;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    //divErrormessage.Visible = true;
                                    //lblerrormessage.Visible = true;
                                    //lblerrormessage.Text = VerifyChequeStr;
                                    aEventAfterCourseDuration.Visible = false;
                                    RequestEneble();


                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "Few Cheques are in Deposited, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = true;
                                    adiscountreq.Visible = false;
                                    btnadjustment.Visible = true;
                                    awaiverreq.Visible = true;
                                    acanceladdmission.Visible = false;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    aEventAfterCourseDuration.Visible = false;
                                    RequestEneble();


                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "Course Duration Over, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = false;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    btnadjustment.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = false;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    RequestEneble();


                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "CRF +  Service Tax amount not received. Hence events not allowed")
                                {
                                    aconcessionreq.Visible = true;
                                    adiscountreq.Visible = true;
                                    btnadjustment.Visible = true;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = true;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    aEventAfterCourseDuration.Visible = false;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                aprint.Visible = false;
                            }//End of Pending status
                            else if (studentstatus == "Student Status : Confirmed")
                            {
                                if (VerifyChequeStr == "Success")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = true;
                                    btnadjustment.Visible = true;
                                    awaiverreq.Visible = true;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = true;
                                    abaddebtsrequest.Visible = true;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = true;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = true;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = true;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = true;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }

                                    if (lblECS_RequestCreateThenEventFlag.Text != "0")
                                    {
                                        streamchange.Visible = false;
                                        payplan.Visible = false;
                                        transfer.Visible = false;
                                    }

                                    return;

                                }
                                else if (VerifyChequeStr == "First Cheque In Pending Status, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = true;
                                    btnadjustment.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    btnEvent.Visible = true;
                                    aEventAfterCourseDuration.Visible = false;
                                    btnrequest.Visible = true;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "First Cheque In Deposited Status, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = false;
                                    btnadjustment.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = false;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = false;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    btnEvent.Visible = false;
                                    aEventAfterCourseDuration.Visible = false;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "First Cheque Is Bounced Status, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = true;
                                    btnadjustment.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = true;
                                    abaddebtsrequest.Visible = true;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = true;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = true;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = true;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = true;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }

                                    if (lblECS_RequestCreateThenEventFlag.Text != "0")
                                    {
                                        streamchange.Visible = false;
                                        payplan.Visible = false;
                                        transfer.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "Few Cheques are in Deposited, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = true;
                                    btnadjustment.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = true;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    aEventAfterCourseDuration.Visible = false;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "CRF +  Service Tax amount not received. Hence events not allowed")
                                {
                                    aconcessionreq.Visible = true;
                                    adiscountreq.Visible = true;
                                    btnadjustment.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = true;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = true;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    aEventAfterCourseDuration.Visible = false;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (VerifyChequeStr == "Course Duration Over, Hence few events are not available")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = false;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    btnadjustment.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = false;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    divErrormessage.Visible = true;
                                    lblerrormessage.Visible = true;
                                    lblerrormessage.Text = VerifyChequeStr;
                                    RequestEneble();

                                    DataSet ds1 = AccountController.GetEventAfterCourseDuration(UserID);
                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        if (ds1.Tables[0].Rows[0]["Allow_Post_Course_Duration_Event"].ToString() == "1")
                                        {
                                            aEventAfterCourseDuration.Visible = true;
                                            adiscountreq.Visible = true;
                                            acanceladdmission.Visible = true;

                                        }
                                    }

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    btnEvent.Visible = false;
                                    return;
                                }
                                aprint.Visible = true;
                            }//End of Confirmed status
                            else if (studentstatus == "Student Status : Cancelled")
                            {

                                aconcessionreq.Visible = false;
                                adiscountreq.Visible = false;
                                awaiverreq.Visible = false;
                                acanceladdmission.Visible = false;
                                arefundrequest.Visible = false;
                                abaddebtsrequest.Visible = false;
                                btnadjustment.Visible = false;
                                HtmlAnchor Addsubject = aaddsubject;
                                Addsubject.Visible = false;
                                Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                HtmlAnchor Removesubject = aremovesubject;
                                Removesubject.Visible = false;
                                Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                HtmlAnchor ChangeSubject = achangeproduct;
                                ChangeSubject.Visible = false;
                                ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                HtmlAnchor streamchange = astreamchange;
                                streamchange.Visible = false;
                                streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                HtmlAnchor payplan = apayplanchange;
                                payplan.Visible = false;
                                payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                HtmlAnchor transfer = atransfer;
                                transfer.Visible = false;
                                transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                aEventAfterCourseDuration.Visible = false;

                                if (lblSubmitBankLoanFlag.Text == "1")
                                {
                                    Div18.Visible = false;//  Hide Adjustment Button
                                    btnpayment1.Visible = false;
                                    btnEvent.Visible = false;
                                    aEventAfterCourseDuration.Visible = false;
                                    btnrequest.Visible = false;
                                    btnLoan.Visible = false;
                                }
                                return;


                            }//End of Confirmed status

                            //If No Cheque is Collected
                            else
                            {
                                string studentstatus1 = lblstdstaus.Text;
                                if (studentstatus1 == "Student Status : Pending")
                                {
                                    aconcessionreq.Visible = true;
                                    adiscountreq.Visible = true;
                                    awaiverreq.Visible = true;
                                    acanceladdmission.Visible = true;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = true;
                                    btnadjustment.Visible = true;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = true;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = true;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = true;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = true;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }

                                    if (lblECS_RequestCreateThenEventFlag.Text != "0")
                                    {
                                        streamchange.Visible = false;
                                        payplan.Visible = false;
                                        transfer.Visible = false;
                                    }
                                    return;
                                }
                                else if (studentstatus1 == "Student Status : Cancelled")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = false;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = true;
                                    btnadjustment.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = false;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = false;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = false;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = false;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = false;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    aEventAfterCourseDuration.Visible = false;

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }
                                    return;
                                }
                                else if (studentstatus1 == "Student Status : Confirmed")
                                {
                                    aconcessionreq.Visible = false;
                                    adiscountreq.Visible = false;
                                    awaiverreq.Visible = false;
                                    acanceladdmission.Visible = false;
                                    arefundrequest.Visible = false;
                                    abaddebtsrequest.Visible = false;
                                    btnadjustment.Visible = false;
                                    HtmlAnchor Addsubject = aaddsubject;
                                    Addsubject.Visible = true;
                                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor Removesubject = aremovesubject;
                                    Removesubject.Visible = true;
                                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor ChangeSubject = achangeproduct;
                                    ChangeSubject.Visible = false;
                                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor streamchange = astreamchange;
                                    streamchange.Visible = true;
                                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor payplan = apayplanchange;
                                    payplan.Visible = true;
                                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    HtmlAnchor transfer = atransfer;
                                    transfer.Visible = true;
                                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                                    RequestEneble();

                                    if (lblSubmitBankLoanFlag.Text == "1")
                                    {
                                        Div18.Visible = false;//  Hide Adjustment Button
                                        btnpayment1.Visible = false;
                                        btnEvent.Visible = false;
                                        aEventAfterCourseDuration.Visible = false;
                                        btnrequest.Visible = false;
                                        btnLoan.Visible = false;
                                    }

                                    if (lblECS_RequestCreateThenEventFlag.Text != "0")
                                    {
                                        streamchange.Visible = false;
                                        payplan.Visible = false;
                                        transfer.Visible = false;
                                    }
                                    return;
                                }
                            }
                        }
                        else
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            awaiverreq.Visible = true;
                            aprint.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = "No Payments Received, Hence few events not available";
                            btnEvent.Visible = false;
                            aEventAfterCourseDuration.Visible = false;
                            RequestEneble();
                            DataSet ds1 = AccountController.GetEventAfterCourseDuration(UserID);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                if (ds1.Tables[0].Rows[0]["Allow_Post_Course_Duration_Event"].ToString() == "1")
                                {
                                    aconfirmadmission.Visible = true;
                                }
                                else
                                {
                                    aconfirmadmission.Visible = false;
                                }
                            }
                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPages/500.aspx");
        }
    }
    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //If lblusercompany.Text = "MPUC" Then
            ((LinkButton)e.Item.FindControl("lnkledger")).Enabled = true;
            ((LinkButton)e.Item.FindControl("lnkledger")).Visible = true;
            ((HtmlAnchor)e.Item.FindControl("btndisplay")).Visible = false;

            ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
            ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
            scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkledger"));
            scriptManager__1.RegisterPostBackControl((HtmlAnchor)e.Item.FindControl("btndisplay"));
            scriptManager__1.RegisterPostBackControl((HtmlAnchor)e.Item.FindControl("btndisplayopp"));
            string Status = ((Label)e.Item.FindControl("Label30")).Text;
            if (Status == "03")
            {
                ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn btn-minier btn-danger icon-eye-open tooltip-danger");
                ((Label)e.Item.FindControl("lbladmissionstatus")).Text = "Admission Pending";
                ((Label)e.Item.FindControl("Label3")).Attributes.Add("class", "btn default btn-xs red");
                ((Label)e.Item.FindControl("Label3")).Text = "Pending";
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
            }
            else if (Status == "01")
            {
                ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn btn-minier btn-success icon-eye-open tooltip-success");
                ((Label)e.Item.FindControl("lbladmissionstatus")).Text = "Admission Confirmed";
                ((Label)e.Item.FindControl("Label3")).Attributes.Add("class", "btn default btn-xs green");
                ((Label)e.Item.FindControl("Label3")).Text = "Confirmed";
                string StudeStatus = ((Label)e.Item.FindControl("lblpromotedflag")).Text;
                string Admreasonid = ((Label)e.Item.FindControl("lbladmnreasonid")).Text;
                if (StudeStatus == "1")
                {
                    if (Admreasonid == "03")
                    {
                        ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn btn-minier btn-danger icon-eye-open tooltip-danger");
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                        ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;
                        ((Label)e.Item.FindControl("lbladmissionstatus")).Text = "Product Changed";
                        ((Label)e.Item.FindControl("Label6")).Attributes.Add("class", "btn btn-minier btn-danger tooltip-danger");
                        ((Label)e.Item.FindControl("Label6")).Visible = true;
                        ((Label)e.Item.FindControl("Label6")).Text = "Product Changed";
                        lblpromoteflag.Text = "1";
                    }
                    else if (Admreasonid == "02")
                    {
                        ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn btn-minier btn-danger icon-eye-open tooltip-danger");
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                        ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;
                        ((Label)e.Item.FindControl("lbladmissionstatus")).Text = "Pay Plan Changed";
                        ((Label)e.Item.FindControl("Label6")).Attributes.Add("class", "btn btn-minier btn-danger tooltip-danger");
                        ((Label)e.Item.FindControl("Label6")).Visible = true;
                        ((Label)e.Item.FindControl("Label6")).Text = "Pay Plan Changed";
                        lblpromoteflag.Text = "1";
                    }
                    else if (Admreasonid == "04")
                    {
                        ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn btn-minier btn-danger icon-eye-open tooltip-danger");
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                        ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;
                        ((Label)e.Item.FindControl("lbladmissionstatus")).Text = "Center Changed";
                        ((Label)e.Item.FindControl("Label6")).Attributes.Add("class", "btn btn-minier btn-danger tooltip-danger");
                        ((Label)e.Item.FindControl("Label6")).Visible = true;
                        ((Label)e.Item.FindControl("Label6")).Text = "Center Changed";
                        lblpromoteflag.Text = "1";
                    }
                    else if (Admreasonid == "01")
                    {
                        ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn btn-minier btn-danger icon-eye-open tooltip-danger");
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                        ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;
                        ((Label)e.Item.FindControl("lbladmissionstatus")).Text = "Admission Cancelled";
                        ((Label)e.Item.FindControl("Label6")).Attributes.Add("class", "btn btn-minier btn-danger tooltip-danger");
                        ((Label)e.Item.FindControl("Label6")).Visible = true;
                        ((Label)e.Item.FindControl("Label6")).Text = "Admission Cancelled";
                        lblpromoteflag.Text = "1";
                    }
                }
                else if (StudeStatus == "0")
                {

                }


            }
            else if (Status == "02")
            {
                ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn btn-minier btn-danger icon-eye-open tooltip-danger");
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;
                ((Label)e.Item.FindControl("lbladmissionstatus")).Text = "Admission Cancelled";
                ((Label)e.Item.FindControl("Label6")).Attributes.Add("class", "btn btn-minier btn-danger tooltip-danger");
                ((Label)e.Item.FindControl("Label6")).Visible = true;
                ((Label)e.Item.FindControl("Label6")).Text = "Admission Cancelled";
                lblpromoteflag.Text = "1";

            }
        }
    }
    protected void btnrefersh_ServerClick(object sender, System.EventArgs e)
    {
        string Cur_Sb_Code = "";
        Cur_Sb_Code = txtcursbcode.Text;
        string oppid = txtopportunityid.Text;

        Bindlist(Cur_Sb_Code);
        BindStudentSubjectGroup(Cur_Sb_Code);
        Bindpayment(Cur_Sb_Code);
        BindChequeallocationTable(Cur_Sb_Code);
        BindStudentLedger();
        BindChequeOutstanding();
        Bindrequestdetails();
        Bindorder();
        Bindorderdetails();
        BindECS_Detail(Cur_Sb_Code);
        string VerifyChequeStr = "";
        decimal instr_amt = 0;
        string Allowevents = "";
        // Pending to Do
        achequereturnrequest.Visible = true;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        //
        string Admissiondate = txtadmndate.Text;
        string Staxvalidation = ProductController.GetApplication_Rights("", Cur_Sb_Code);

        if (Staxvalidation == "A100002")
        {
            aconcessionreq.Visible = true;
            adiscountreq.Visible = true;
            awaiverreq.Visible = false;
            acanceladdmission.Visible = true;
            arefundrequest.Visible = false;
            abaddebtsrequest.Visible = false;
            btnadjustment.Visible = true;
            HtmlAnchor Addsubject = aaddsubject;
            Addsubject.Visible = true;
            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor Removesubject = aremovesubject;
            Removesubject.Visible = true;
            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor ChangeSubject = achangeproduct;
            ChangeSubject.Visible = false;
            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor streamchange = astreamchange;
            streamchange.Visible = false;
            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor payplan = apayplanchange;
            payplan.Visible = false;
            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor transfer = atransfer;
            transfer.Visible = false;
            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = "Events Blocked for GST rollout";
            btnEvent.Visible = true;
            RequestEneble();

            return;

        }
        else
        {

            Allowevents = AccountController.Verify_Event_Allow(Cur_Sb_Code, 1);
            if (Allowevents != "Success")
            {
                aconcessionreq.Visible = true;
                adiscountreq.Visible = true;
                awaiverreq.Visible = false;
                acanceladdmission.Visible = false;
                arefundrequest.Visible = false;
                abaddebtsrequest.Visible = false;
                btnadjustment.Visible = true;
                HtmlAnchor Addsubject = aaddsubject;
                Addsubject.Visible = false;
                Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor Removesubject = aremovesubject;
                Removesubject.Visible = false;
                Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor ChangeSubject = achangeproduct;
                ChangeSubject.Visible = false;
                ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor streamchange = astreamchange;
                streamchange.Visible = false;
                streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor payplan = apayplanchange;
                payplan.Visible = false;
                payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor transfer = atransfer;
                transfer.Visible = false;
                transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                btnEvent.Visible = false;
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Few Events are Not available on the same day";
                RequestEneble();
                return;
               
            }
            else
            {
                VerifyChequeStr = AccountController.Verify_Rule_Event_Activation(Cur_Sb_Code, instr_amt, "", 2);
                DataSet ds = AccountController.GetPaymentDetailsbySBEntrycode(Cur_Sb_Code);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string studentstatus = lblstdstaus.Text;
                    if (studentstatus == "Student Status : Pending")
                    {
                        if (VerifyChequeStr == "Success")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            RequestEneble();
                            return;

                        }
                        else if (VerifyChequeStr == "First Cheque In Pending Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            btnEvent.Visible = false;
                            btnrequest.Visible = true;
                            RequestEneble();
                            return;
                        }
                        else if (VerifyChequeStr == "First Cheque In Deposited Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            btnEvent.Visible = false;
                            btnrequest.Visible = true;
                            RequestEneble();
                            return;
                        }
                        else if (VerifyChequeStr == "First Cheque Is Bounced Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            RequestEneble();
                            return;
                        }
                        else if (VerifyChequeStr == "Few Cheques are in Deposited, Hence few events are not available")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = false;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            RequestEneble();

                            return;
                        }
                        else if (VerifyChequeStr == "Course Duration Over, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;


                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "CRF +  Service Tax amount not received. Hence events not allowed")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            aEventAfterCourseDuration.Visible = false;
                            RequestEneble();

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        aprint.Visible = false;
                    }//End of Pending status
                    else if (studentstatus == "Student Status : Confirmed")
                    {
                        if (VerifyChequeStr == "Success")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = true;
                            abaddebtsrequest.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = true;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = true;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = true;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            RequestEneble();

                            if (lblECS_RequestCreateThenEventFlag.Text != "0")
                            {
                                streamchange.Visible = false;
                                payplan.Visible = false;
                                transfer.Visible = false;
                            }
                            return;

                        }
                        else if (VerifyChequeStr == "First Cheque In Pending Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            btnEvent.Visible = true;
                            btnrequest.Visible = true;
                            RequestEneble();
                            return;
                        }
                        else if (VerifyChequeStr == "First Cheque In Deposited Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            btnEvent.Visible = false;
                            RequestEneble();
                            return;
                        }
                        else if (VerifyChequeStr == "First Cheque Is Bounced Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = true;
                            abaddebtsrequest.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = true;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = true;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = true;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            RequestEneble();

                            if (lblECS_RequestCreateThenEventFlag.Text != "0")
                            {
                                streamchange.Visible = false;
                                payplan.Visible = false;
                                transfer.Visible = false;
                            }

                            return;
                        }
                        else if (VerifyChequeStr == "CRF +  Service Tax amount not received. Hence events not allowed")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            aEventAfterCourseDuration.Visible = false;

                            RequestEneble();
                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "Few Cheques are in Deposited, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            RequestEneble();

                            return;
                        }
                        else if (VerifyChequeStr == "Course Duration Over, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            RequestEneble();
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            DataSet ds1 = AccountController.GetEventAfterCourseDuration(UserID);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                if (ds1.Tables[0].Rows[0]["Allow_Post_Course_Duration_Event"].ToString() == "1")
                                {
                                    aEventAfterCourseDuration.Visible = true;
                                    adiscountreq.Visible = true;
                                    acanceladdmission.Visible = true;
                                }
                            }


                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            btnEvent.Visible = false;
                            return;
                        }
                        aprint.Visible = true;
                    }//End of Confirmed status
                    else if (studentstatus == "Student Status : Cancelled")
                    {

                        aconcessionreq.Visible = false;
                        adiscountreq.Visible = false;
                        awaiverreq.Visible = false;
                        acanceladdmission.Visible = false;
                        arefundrequest.Visible = true;
                        abaddebtsrequest.Visible = true;
                        btnadjustment.Visible = false;
                        HtmlAnchor Addsubject = aaddsubject;
                        Addsubject.Visible = false;
                        Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor Removesubject = aremovesubject;
                        Removesubject.Visible = false;
                        Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor ChangeSubject = achangeproduct;
                        ChangeSubject.Visible = false;
                        ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor streamchange = astreamchange;
                        streamchange.Visible = false;
                        streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor payplan = apayplanchange;
                        payplan.Visible = false;
                        payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor transfer = atransfer;
                        transfer.Visible = false;
                        transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        return;


                    }//End of Confirmed status

                    //If Not Cheque is Collected
                    else
                    {
                        string studentstatus1 = lblstdstaus.Text;
                        if (studentstatus1 == "Student Status : Pending")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = true;
                            btnadjustment.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = true;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = true;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = true;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            RequestEneble();

                            if (lblECS_RequestCreateThenEventFlag.Text != "0")
                            {
                                streamchange.Visible = false;
                                payplan.Visible = false;
                                transfer.Visible = false;
                            }
                            return;
                        }
                        else if (studentstatus1 == "Student Status : Cancelled")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = true;
                            btnadjustment.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            RequestEneble();
                            return;
                        }
                        else if (studentstatus1 == "Student Status : Confirmed")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = true;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = true;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = true;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            RequestEneble();

                            if (lblECS_RequestCreateThenEventFlag.Text != "0")
                            {
                                streamchange.Visible = false;
                                payplan.Visible = false;
                                transfer.Visible = false;
                            }
                            return;
                        }
                    }
                }
                else
                {
                    aconcessionreq.Visible = true;
                    aprint.Visible = false;
                    adiscountreq.Visible = true;
                    awaiverreq.Visible = true;
                    acanceladdmission.Visible = true;
                    arefundrequest.Visible = false;
                    abaddebtsrequest.Visible = false;
                    btnadjustment.Visible = true;
                    HtmlAnchor Addsubject = aaddsubject;
                    Addsubject.Visible = false;
                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor Removesubject = aremovesubject;
                    Removesubject.Visible = false;
                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor ChangeSubject = achangeproduct;
                    ChangeSubject.Visible = false;
                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor streamchange = astreamchange;
                    streamchange.Visible = false;
                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor payplan = apayplanchange;
                    payplan.Visible = false;
                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor transfer = atransfer;
                    transfer.Visible = false;
                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    divErrormessage.Visible = true;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = "No Payments Received, Hence few events not available";
                    btnEvent.Visible = false;
                    aEventAfterCourseDuration.Visible = false;
                    RequestEneble();
                    DataSet ds1 = AccountController.GetEventAfterCourseDuration(UserID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0]["Allow_Post_Course_Duration_Event"].ToString() == "1")
                        {
                            aconfirmadmission.Visible = true;
                        }
                        else
                        {
                            aconfirmadmission.Visible = false;
                        }
                    }
                    if (lblSubmitBankLoanFlag.Text == "1")
                    {
                        Div18.Visible = false;//  Hide Adjustment Button
                        btnpayment1.Visible = false;
                        btnEvent.Visible = false;
                        aEventAfterCourseDuration.Visible = false;
                        btnrequest.Visible = false;
                        btnLoan.Visible = false;
                    }
                    return;
                }
            }
        }
    }

    private void Viewledger(string Cur_sb_code)
    {

        upnlsearch.Visible = false;
        Upnlviewledger.Visible = true;
        lblpagetitle1.Text = "View Ledger";
        lblpagetitle2.Text = "";
        lblmidbreadcrumb.Text = "Manage Account";
        lbllastbreadcrumb.Text = "View Ledger";
        imgstudentphotodisplay.Visible = true;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnback.Visible = true;
        string Cur_Sb_Code = "";
        Cur_Sb_Code = Cur_sb_code;
        Session["CUR_SB_Code"] = Cur_Sb_Code;
        diverrorPayment.Visible = false;
        divSuccessPayment.Visible = false;
        btnviewenrollment.Visible = false;
        txtcursbcode.Text = Cur_Sb_Code;
        btnviewenv.Visible = false;
        Bindlist(Cur_Sb_Code);
        BindStudentSubjectGroup(Cur_Sb_Code);
        Bindpayment(Cur_Sb_Code);
        BindECS_Detail(Cur_Sb_Code);

        BindChequeallocationTable(Cur_Sb_Code);
        BindStudentLedger();
        BindChequeOutstanding();
        Bindrequestdetails();
        diveditpayemnt.Visible = false;
        string oppid = txtopportunityid.Text;
        string Cur_sb_code1 = txtcursbcode.Text;


        HtmlAnchor viewenrollment = btnviewenrollment;
        viewenrollment.HRef = "View_Order.aspx?&Cur_Sb_Code=" + Cur_sb_code1 + "&Oppid=" + oppid;
        HtmlAnchor viewenv = btnviewenv;
        viewenv.HRef = "Account_Edit.aspx?&Oppur_ID=" + oppid;
        divpayment.Visible = false;
        divorder.Visible = false;
        lblheadertext.Text = "Payment Details";
        Bindorder();
        Bindorderdetails();
        HtmlAnchor Aprint = aprint;
        //Aprint.Visible = true;
        string PPCode = "PP011";
        Aprint.HRef = "RCL.aspx?SBECode=" + Cur_Sb_Code + "&PPCode=" + PPCode + "";

        // Pending to Do
        achequereturnrequest.Visible = true;
        //
        string Admissiondate = txtadmndate.Text;
       

        string Staxvalidation = ProductController.GetApplication_Rights("", Cur_Sb_Code);
        HtmlAnchor EventAfterCourseDuration = aEventAfterCourseDuration;
        aEventAfterCourseDuration.Visible = false;
        aEventAfterCourseDuration.HRef = "CD.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;

        HtmlAnchor AEventECS = aEventECS;
        AEventECS.HRef = "Request_ECS.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
        btnproceedECS.Visible = false;
        //if the student status is Pending and first cheque entry is entered then ECS request visible true
        if ((lblstdstaus.Text == "Student Status : Pending") && (dlpaymentreceipt.Visible == true))
        {
            btnproceedECS.Visible = true;
        }

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];


        if (Staxvalidation == "A100002")
        {
            aconcessionreq.Visible = true;
            adiscountreq.Visible = true;
            awaiverreq.Visible = false;
            acanceladdmission.Visible = true;
            arefundrequest.Visible = false;
            abaddebtsrequest.Visible = false;
            btnadjustment.Visible = true;
            HtmlAnchor Addsubject = aaddsubject;
            Addsubject.Visible = true;
            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor Removesubject = aremovesubject;
            Removesubject.Visible = true;
            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor ChangeSubject = achangeproduct;
            ChangeSubject.Visible = false;
            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor streamchange = astreamchange;
            streamchange.Visible = false;
            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor payplan = apayplanchange;
            payplan.Visible = false;
            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            HtmlAnchor transfer = atransfer;
            transfer.Visible = false;
            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = "Events Blocked for GST rollout";
            btnEvent.Visible = true;
            aEventAfterCourseDuration.Visible = false;

            if (lblSubmitBankLoanFlag.Text == "1")
            {
                Div18.Visible = false;//  Hide Adjustment Button
                btnpayment1.Visible = false;
                btnEvent.Visible = false;
                aEventAfterCourseDuration.Visible = false;
                btnrequest.Visible = false;
                btnLoan.Visible = false;
            }
            return;

        }
        else
        {
            string VerifyChequeStr = "";
            decimal instr_amt = 0;
            string Allowevents = "";
            Allowevents = AccountController.Verify_Event_Allow(Cur_Sb_Code, 1);
            if (Allowevents != "Success")
            {
                aconcessionreq.Visible = true;
                adiscountreq.Visible = true;
                awaiverreq.Visible = false;
                acanceladdmission.Visible = false;
                arefundrequest.Visible = false;
                abaddebtsrequest.Visible = false;
                btnadjustment.Visible = true;
                HtmlAnchor Addsubject = aaddsubject;
                Addsubject.Visible = false;
                Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor Removesubject = aremovesubject;
                Removesubject.Visible = false;
                Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor ChangeSubject = achangeproduct;
                ChangeSubject.Visible = false;
                ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor streamchange = astreamchange;
                streamchange.Visible = false;
                streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor payplan = apayplanchange;
                payplan.Visible = false;
                payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                HtmlAnchor transfer = atransfer;
                transfer.Visible = false;
                transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Few Events are Not available on the same day";
                btnEvent.Visible = false;
                aEventAfterCourseDuration.Visible = false;


                if (lblSubmitBankLoanFlag.Text == "1")
                {
                    Div18.Visible = false;//  Hide Adjustment Button
                    btnpayment1.Visible = false;
                    btnEvent.Visible = false;
                    aEventAfterCourseDuration.Visible = false;
                    btnrequest.Visible = false;
                    btnLoan.Visible = false;
                }
                return;
            }
            else
            {
                VerifyChequeStr = AccountController.Verify_Rule_Event_Activation(Cur_Sb_Code, instr_amt, "", 2);
                DataSet ds = AccountController.GetPaymentDetailsbySBEntrycode(Cur_Sb_Code);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string studentstatus = lblstdstaus.Text;
                    if (studentstatus == "Student Status : Pending")
                    {

                        if (VerifyChequeStr == "Success")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            aEventAfterCourseDuration.Visible = false;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;

                        }
                        else if (VerifyChequeStr == "First Cheque In Pending Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            btnEvent.Visible = false;
                            aEventAfterCourseDuration.Visible = false;
                            btnrequest.Visible = true;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "First Cheque In Deposited Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            btnEvent.Visible = false;
                            aEventAfterCourseDuration.Visible = false;
                            btnrequest.Visible = true;
                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "First Cheque Is Bounced Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            //divErrormessage.Visible = true;
                            //lblerrormessage.Visible = true;
                            //lblerrormessage.Text = VerifyChequeStr;
                            aEventAfterCourseDuration.Visible = false;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "Few Cheques are in Deposited, Hence few events are not available")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = false;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            aEventAfterCourseDuration.Visible = false;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "Course Duration Over, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;


                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "CRF +  Service Tax amount not received. Hence events not allowed")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            aEventAfterCourseDuration.Visible = false;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        aprint.Visible = false;
                    }//End of Pending status
                    else if (studentstatus == "Student Status : Confirmed")
                    {
                        if (VerifyChequeStr == "Success")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = true;
                            abaddebtsrequest.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = true;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = true;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = true;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }

                            if (lblECS_RequestCreateThenEventFlag.Text != "0")
                            {
                                streamchange.Visible = false;
                                payplan.Visible = false;
                                transfer.Visible = false;
                            }

                            return;

                        }
                        else if (VerifyChequeStr == "First Cheque In Pending Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            btnEvent.Visible = true;
                            aEventAfterCourseDuration.Visible = false;
                            btnrequest.Visible = true;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "First Cheque In Deposited Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            btnEvent.Visible = false;
                            aEventAfterCourseDuration.Visible = false;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "First Cheque Is Bounced Status, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = true;
                            abaddebtsrequest.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = true;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = true;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = true;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }

                            if (lblECS_RequestCreateThenEventFlag.Text != "0")
                            {
                                streamchange.Visible = false;
                                payplan.Visible = false;
                                transfer.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "Few Cheques are in Deposited, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            aEventAfterCourseDuration.Visible = false;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "CRF +  Service Tax amount not received. Hence events not allowed")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            btnadjustment.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;
                            aEventAfterCourseDuration.Visible = false;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (VerifyChequeStr == "Course Duration Over, Hence few events are not available")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = VerifyChequeStr;

                            DataSet ds1 = AccountController.GetEventAfterCourseDuration(UserID);
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                if (ds1.Tables[0].Rows[0]["Allow_Post_Course_Duration_Event"].ToString() == "1")
                                {
                                    aEventAfterCourseDuration.Visible = true;
                                    adiscountreq.Visible = true;
                                    acanceladdmission.Visible = true;

                                }
                            }

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            btnEvent.Visible = false;
                            return;
                        }
                        aprint.Visible = true;
                    }//End of Confirmed status
                    else if (studentstatus == "Student Status : Cancelled")
                    {

                        aconcessionreq.Visible = false;
                        adiscountreq.Visible = false;
                        awaiverreq.Visible = false;
                        acanceladdmission.Visible = false;
                        arefundrequest.Visible = false;
                        abaddebtsrequest.Visible = false;
                        btnadjustment.Visible = false;
                        HtmlAnchor Addsubject = aaddsubject;
                        Addsubject.Visible = false;
                        Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor Removesubject = aremovesubject;
                        Removesubject.Visible = false;
                        Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor ChangeSubject = achangeproduct;
                        ChangeSubject.Visible = false;
                        ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor streamchange = astreamchange;
                        streamchange.Visible = false;
                        streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor payplan = apayplanchange;
                        payplan.Visible = false;
                        payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        HtmlAnchor transfer = atransfer;
                        transfer.Visible = false;
                        transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                        aEventAfterCourseDuration.Visible = false;

                        if (lblSubmitBankLoanFlag.Text == "1")
                        {
                            Div18.Visible = false;//  Hide Adjustment Button
                            btnpayment1.Visible = false;
                            btnEvent.Visible = false;
                            aEventAfterCourseDuration.Visible = false;
                            btnrequest.Visible = false;
                            btnLoan.Visible = false;
                        }
                        return;


                    }//End of Confirmed status

                    //If No Cheque is Collected
                    else
                    {
                        string studentstatus1 = lblstdstaus.Text;
                        if (studentstatus1 == "Student Status : Pending")
                        {
                            aconcessionreq.Visible = true;
                            adiscountreq.Visible = true;
                            awaiverreq.Visible = true;
                            acanceladdmission.Visible = true;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = true;
                            btnadjustment.Visible = true;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = true;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = true;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = true;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }

                            if (lblECS_RequestCreateThenEventFlag.Text != "0")
                            {
                                streamchange.Visible = false;
                                payplan.Visible = false;
                                transfer.Visible = false;
                            }
                            return;
                        }
                        else if (studentstatus1 == "Student Status : Cancelled")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = true;
                            btnadjustment.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = false;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = false;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = false;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = false;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = false;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            aEventAfterCourseDuration.Visible = false;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }
                            return;
                        }
                        else if (studentstatus1 == "Student Status : Confirmed")
                        {
                            aconcessionreq.Visible = false;
                            adiscountreq.Visible = false;
                            awaiverreq.Visible = false;
                            acanceladdmission.Visible = false;
                            arefundrequest.Visible = false;
                            abaddebtsrequest.Visible = false;
                            btnadjustment.Visible = false;
                            HtmlAnchor Addsubject = aaddsubject;
                            Addsubject.Visible = true;
                            Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor Removesubject = aremovesubject;
                            Removesubject.Visible = true;
                            Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor ChangeSubject = achangeproduct;
                            ChangeSubject.Visible = false;
                            ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor streamchange = astreamchange;
                            streamchange.Visible = true;
                            streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor payplan = apayplanchange;
                            payplan.Visible = true;
                            payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                            HtmlAnchor transfer = atransfer;
                            transfer.Visible = true;
                            transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;

                            if (lblSubmitBankLoanFlag.Text == "1")
                            {
                                Div18.Visible = false;//  Hide Adjustment Button
                                btnpayment1.Visible = false;
                                btnEvent.Visible = false;
                                aEventAfterCourseDuration.Visible = false;
                                btnrequest.Visible = false;
                                btnLoan.Visible = false;
                            }

                            if (lblECS_RequestCreateThenEventFlag.Text != "0")
                            {
                                streamchange.Visible = false;
                                payplan.Visible = false;
                                transfer.Visible = false;
                            }
                            return;
                        }
                    }
                }
                else
                {
                    aconcessionreq.Visible = true;
                    adiscountreq.Visible = true;
                    awaiverreq.Visible = true;
                    aprint.Visible = false;
                    acanceladdmission.Visible = true;
                    arefundrequest.Visible = false;
                    abaddebtsrequest.Visible = false;
                    btnadjustment.Visible = true;
                    HtmlAnchor Addsubject = aaddsubject;
                    Addsubject.Visible = false;
                    Addsubject.HRef = "Event_Add.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor Removesubject = aremovesubject;
                    Removesubject.Visible = false;
                    Removesubject.HRef = "Event_Remove.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor ChangeSubject = achangeproduct;
                    ChangeSubject.Visible = false;
                    ChangeSubject.HRef = "Event_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor streamchange = astreamchange;
                    streamchange.Visible = false;
                    streamchange.HRef = "Stream_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor payplan = apayplanchange;
                    payplan.Visible = false;
                    payplan.HRef = "PayPlan_Change.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    HtmlAnchor transfer = atransfer;
                    transfer.Visible = false;
                    transfer.HRef = "Transfer.aspx?&Cur_Sb_Code=" + Cur_Sb_Code + "&Oppid=" + oppid;
                    divErrormessage.Visible = true;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = "No Payments Received, Hence few events not available";
                    btnEvent.Visible = false;
                    aEventAfterCourseDuration.Visible = false;
                    DataSet ds1 = AccountController.GetEventAfterCourseDuration(UserID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0]["Allow_Post_Course_Duration_Event"].ToString() == "1")
                        {
                            aconfirmadmission.Visible = true;
                        }
                        else
                        {
                            aconfirmadmission.Visible = false;
                        }
                    }
                    if (lblSubmitBankLoanFlag.Text == "1")
                    {
                        Div18.Visible = false;//  Hide Adjustment Button
                        btnpayment1.Visible = false;
                        btnEvent.Visible = false;
                        aEventAfterCourseDuration.Visible = false;
                        btnrequest.Visible = false;
                        btnLoan.Visible = false;
                    }
                    return;
                }

            }
        }
    }
    /// <summary>
    /// Upload Student Photgraph
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUploadpic_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#UploadPic').modal('show');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }
    protected void btnclosemodalUploadpic_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#UploadPic').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }
    protected void btnsaveUploadpic_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            if (fileContact.PostedFile != null)
            {
                if (fileContact.HasFile)
                {
                    string strFilePath = "images/studentphoto/";
                    string strFileName = "";
                    FileInfo fi = new FileInfo(fileContact.FileName);
                    string ext = fi.Extension.ToLower().Trim();

                    if (ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".jpeg" || ext == ".bitmap")
                    {

                        if (!System.IO.Directory.Exists(Server.MapPath(strFilePath)))
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath(strFilePath));
                        }
                        DataSet ds = ProductController.UpdateImagePath(txtcursbcode.Text, ext);
                        if (ds != null)
                        {
                            if (ds.Tables.Count != 0)
                            {
                                strFileName = ds.Tables[0].Rows[0]["ImagePath"].ToString();
                                fileContact.SaveAs(Server.MapPath(strFilePath + strFileName));
                                divErrormessage.Visible = false;
                                divSuccessmessage.Visible = true;
                                lblsuccessMessage.Text = "Image Uploaded Successfully";
                            }
                        }

                    }
                    else
                    {

                        divErrormessage.Visible = true;
                        divSuccessmessage.Visible = false;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Invalid File Format";




                    }
                }
                else
                {
                    divErrormessage.Visible = true;
                    divSuccessmessage.Visible = false;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = "Please upload File";


                }
            }
            else
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Please upload File";
            }
        }
        catch (Exception ex)
        {

            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.ToString();
        }
    }

    protected void btnCloseStudentAccount_ServerClick(object sender, System.EventArgs e)
    {
        Upnlviewledger.Visible = false;
        upnlsearch.Visible = true;

    }

    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {
        divLoanStatus.Visible = false;
        divECSStatus_ErrorMessage.Visible = false;
        Upnlviewledger.Visible = false;
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        btnsearchback.Visible = false;
        imgstudentphotodisplay.Visible = false;
        lblpagetitle1.Text = "Manage Account";
        lblpagetitle2.Text = "Search Panel";
        //limidbreadcrumb.Visible = true;
        lblmidbreadcrumb.Text = "Manage Account";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        divpendingreuesterror.Visible = false;
        listudentstatus.Visible = false;
        btnviewenrollment.Visible = false;
        btnviewenv.Visible = false;
        lblstudentname1.Text = "";
        lblstudentname1.Visible = false;
        lblstudentname.Visible = false;
        diverrorPayment.Visible = false;
        btnback.Visible = false;
        diverrorPayment.Visible = false;
        lblerrorPayment.Visible = false;
        div12.Visible = false;
        Label2.Visible = false;
        Bindrequestdetails();
    }

    /// <summary>
    /// Back Functionality
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        divLoanStatus.Visible = false;
        divECSStatus_ErrorMessage.Visible = false;
        upnlsearch.Visible = true;
        Upnlviewledger.Visible = false;
        btnback.Visible = false;
        imgstudentphotodisplay.Visible = false;
        lblpagetitle1.Text = "Manage Account";
        lblpagetitle2.Text = "Search Panel";
        lblmidbreadcrumb.Text = "Manage Account";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        divpendingreuesterror.Visible = false;
        upnlsearch.Visible = true;
        Upnlviewledger.Visible = false;
        listudentstatus.Visible = false;
        btnviewenrollment.Visible = false;
        btnviewenv.Visible = false;
        lblstudentname1.Text = "";
        lblstudentname1.Visible = false;
        lblstudentname.Visible = false;
        diverrorPayment.Visible = false;
        div12.Visible = false;
        diverrorPayment.Visible = false;
        lblerrorPayment.Visible = false;
        div12.Visible = false;
        Label2.Visible = false;
        Bindrequestdetails();
        btnsearch_ServerClick(sender, e);
    }
    private void BindChequeallocationTable(string Cur_sb_code)
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = Cur_sb_code;
        DataSet ds = AccountController.GetPPgroupbysbentrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //System.Threading.Thread.Sleep(1000)
            dlallocationtable.DataSource = ds;
            dlallocationtable.DataBind();
            dlallocationtable.Visible = false;
        }
        else
        {
        }
    }

    private void Bindlist(string Cursbcode)
    {
        string Hiphen = "-";
        SqlDataReader dr = AccountController.GetAccountdetailbycursbcode(1, Cursbcode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                string Gender = dr["GENDER"].ToString();
                if (Gender == "M")
                {
                    txtgender.Text = "Male";
                }
                else
                {
                    txtgender.Text = "Female";
                }
                lblstudentname1.Visible = true;
                lblstudentname.Visible = true;
                txtLstudentname.Text = dr["NAME"].ToString();
                lblstudentname1.Text = dr["NAME"].ToString();
                lblstudentname.Text = Hiphen + " " + dr["NAME"].ToString();
                imgstudentphoto.ImageUrl = dr["stud_image"].ToString();
                txtLappno.Text = dr["Student_App_No"].ToString();
                txtopportunityid.Text = dr["oppor_id"].ToString();
                txtaccountid.Text = dr["account_id"].ToString();
                txtcursbcode.Text = dr["sbentrycode"].ToString();
                BindLedgerCompany();
                ddllcompany.SelectedValue = dr["companycode"].ToString();
                BindLedgerDivision();
                ddlldivision.SelectedValue = dr["divisioncode"].ToString();
                BindLedgerCenter();
                ddllcenter.SelectedValue = dr["center_code"].ToString();
                BindLedgerAcademicYear();
                ddllacadyear.SelectedValue = dr["acad_year"].ToString();
                BindLedgerStream();
                ddllstream.SelectedValue = dr["stream_code"].ToString();
                //BindPayplan();
                txtpayplan.Text = dr["payplan"].ToString();
                txtadmndate.Text = dr["Admndate"].ToString();
                string Studentstatus = "";
                Studentstatus = dr["Account_Status_id"].ToString();
                string studentimage = dr["ImagePath"].ToString();
                Image2.ImageUrl = dr["ImagePath"].ToString();
                Image3.ImageUrl = dr["ImagePath"].ToString();
                lblBankLoanFlag.Text = dr["ApplyLoanFlag"].ToString();
                lblLoanDate.Text = dr["ApplyLoanDate"].ToString();
                btnLoan.Visible = false;
                lblSubmitBankLoanFlag.Text = dr["SubmitLoanFlag"].ToString();
                lblECS_RequestCreateThenEventFlag.Text = dr["ECS_RequestCreateThenEventFlag"].ToString();

                divLoanStatus.Visible = false;
                divECSStatus_ErrorMessage.Visible = false;
                if ((lblBankLoanFlag.Text == "1") && (lblSubmitBankLoanFlag.Text == "0"))
                {
                    divLoanStatus.Visible = true;
                    lblLoanStatus.Text = "Loan Status : Applyed ";
                    lblLoanStatus.ForeColor = System.Drawing.Color.DarkCyan;
                }
                else if ((lblBankLoanFlag.Text == "1") && (lblSubmitBankLoanFlag.Text == "1"))
                {
                    divLoanStatus.Visible = true;
                    lblLoanStatus.Text = "Loan Status : Pending, Hence few events are not available";
                    lblLoanStatus.ForeColor = System.Drawing.Color.DarkRed;
                }
                else if ((lblBankLoanFlag.Text == "1") && (lblSubmitBankLoanFlag.Text == "2"))
                {
                    divLoanStatus.Visible = true;
                    lblLoanStatus.Text = "Loan Status : Approved";
                    lblLoanStatus.ForeColor = System.Drawing.Color.Green;
                }
                else if ((lblBankLoanFlag.Text == "1") && (lblSubmitBankLoanFlag.Text == "3"))
                {
                    divLoanStatus.Visible = true;
                    lblLoanStatus.Text = "Loan Status : Rejected";
                    lblLoanStatus.ForeColor = System.Drawing.Color.Red;
                }


                if (lblECS_RequestCreateThenEventFlag.Text != "0")
                {
                    divECSStatus_ErrorMessage.Visible = true;
                    lblECSStatus_Message.Text = "ECS Request in transit, Hence few events are not available";
                }

                if (Studentstatus == "01")
                {
                    listudentstatus.Visible = true;
                    //liregno.Visible = false;
                    lblstdstaus.Text = "Student Status : Pending";
                    if (lblSubmitBankLoanFlag.Text == "0")
                    {
                        btnLoan.Visible = true;
                    }
                    else
                        btnLoan.Visible = false;

                    btnEvent.Visible = true;
                    aconcessionreq.Visible = true;
                    adiscountreq.Visible = true;
                    txtDiscrequestdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    txtconcessionreqdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    awaiverreq.Visible = true;
                    acanceladdmission.Visible = true;
                    arefundrequest.Visible = true;
                    abaddebtsrequest.Visible = true;
                    aaddsubject.Visible = true;
                    aremovesubject.Visible = true;
                    achangesubject.Visible = false;
                    apromotestudent.Visible = false;
                    string Printvalue = ProductController.CheckPrintValue(Cursbcode);
                    if (Printvalue == "0")
                    {
                        btnproceedprint1.Visible = true;
                    }
                    else if (Printvalue == "1")
                    {
                        btnproceedprint1.Visible = false;
                    }

                }
                else if (Studentstatus == "03")
                {
                    string Ispromote = ProductController.Checkispromote(Cursbcode);
                    if (Ispromote == "1")
                    {
                        listudentstatus.Visible = true;
                        //liregno.Visible = false;
                        lblstdstaus.Text = "Student Status : Promoted";
                        apromotestudent.Visible = false;
                        aaddsubject.Visible = false;
                        aremovesubject.Visible = false;
                        achangesubject.Visible = false;
                        aconcessionreq.Visible = false;
                        adiscountreq.Visible = false;
                        btnaddpayment.Visible = false;
                        acanceladdmission.Visible = false;
                        aaddsubject.Visible = false;
                        aremovesubject.Visible = false;
                        btnEvent.Visible = false;
                        string Printvalue = ProductController.CheckPrintValue(Cursbcode);
                        if (Printvalue == "0")
                        {
                            btnproceedprint1.Visible = true;
                        }
                        else if (Printvalue == "1")
                        {
                            btnproceedprint1.Visible = false;
                        }
                    }
                    else
                    {
                        listudentstatus.Visible = true;
                        lblstdstaus.Text = "Student Status : Confirmed";
                        btnEvent.Visible = true;
                        aconcessionreq.Visible = true;
                        adiscountreq.Visible = true;
                        txtDiscrequestdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                        txtconcessionreqdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                        awaiverreq.Visible = true;
                        acanceladdmission.Visible = true;
                        arefundrequest.Visible = true;
                        abaddebtsrequest.Visible = true;
                        aaddsubject.Visible = true;
                        aremovesubject.Visible = true;
                        achangesubject.Visible = false;
                        //btnLoan.Visible = true;

                        //New Validation
                        string Promteflag = AccountController.Getpromoteflag(txtcursbcode.Text);
                        if (Promteflag == "1")
                        {
                            apromotestudent.Visible = true;
                        }
                        else if (Promteflag == "0")
                        {
                            apromotestudent.Visible = false;

                        }
                        else
                        {
                        }

                        string Printvalue = ProductController.CheckPrintValue(Cursbcode);
                        if (Printvalue == "0")
                        {
                            btnproceedprint1.Visible = true;
                        }
                        else if (Printvalue == "1")
                        {
                            btnproceedprint1.Visible = false;
                        }
                    }
                }
                else if (Studentstatus == "02")
                {
                    listudentstatus.Visible = true;
                    //liregno.Visible = false;
                    lblstdstaus.Text = "Student Status : Cancelled";
                    btnproceedprint1.Visible = false;
                    aaddsubject.Visible = false;
                    aremovesubject.Visible = false;
                    achangesubject.Visible = false;
                    aconcessionreq.Visible = false;
                    adiscountreq.Visible = false;
                    apromotestudent.Visible = false;
                    btnaddpayment.Visible = false;
                    btnEvent.Visible = false;
                    abaddebtsrequest.Visible = true;
                    acanceladdmission.Visible = false;
                }
                if (lblSubmitBankLoanFlag.Text == "1")
                {
                    Div18.Visible = false;//  Hide Adjustment Button
                    btnpayment1.Visible = false;
                    btnEvent.Visible = false;
                    btnrequest.Visible = false;
                    btnLoan.Visible = false;
                }
            }
        }
    }

    private void BindECS_Detail(string Cursbcode)
    {
        lblstudentname2.Text = lblstudentname1.Text;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds = ProductController.Get_ECS_Detail(Cursbcode, UserID, "3");
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DivECSStatus.Visible = true;
                dlECSdetails.DataSource = ds.Tables[0];
                dlECSdetails.DataBind();
            }
            else
            {
                DivECSStatus.Visible = false;
            }
        }
        else
        {
            DivECSStatus.Visible = false;
        }

    }

    private void BindLedgerCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddllcompany, ds, "Company_Name", "Company_Code");
        ddllcompany.Items.Insert(0, "Select");
        ddllcompany.SelectedIndex = 0;
    }
    private void BindLedgerDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddllcompany.SelectedValue);
        BindDDL(ddlldivision, ds, "Division_Name", "Division_Code");
        ddlldivision.Items.Insert(0, "Select");
        ddlldivision.SelectedIndex = 0;
    }
    private void BindLedgerCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlldivision.SelectedValue, "", ddllcompany.SelectedValue);
        BindDDL(ddllcenter, ds, "Center_name", "Center_Code");
        ddllcenter.Items.Insert(0, "Select");
        ddllcenter.SelectedIndex = 0;
    }
    private void BindLedgerAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddllcenter.SelectedValue);
        BindDDL(ddllacadyear, ds, "Acad_Year", "Acad_Year");
        ddllacadyear.Items.Insert(0, "Select");
        ddllacadyear.SelectedIndex = 0;
    }
    private void BindLedgerStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddllcenter.SelectedValue, ddllacadyear.SelectedValue);
        BindDDL(ddllstream, ds, "Stream_Sdesc", "Stream_Code");
        ddllstream.Items.Insert(0, "Select");
        ddllstream.SelectedIndex = 0;
    }
    private void BindStudentSubjectGroup(string CurSbCode)
    {
        DataSet ds = AccountController.GetStudentSubjectgroupbyCursbcode(2, CurSbCode);
        lbsubjectgroup.DataSource = ds;
        lbsubjectgroup.DataTextField = "SGR_DESC";
        lbsubjectgroup.DataValueField = "sgr_material";
        lbsubjectgroup.DataBind();
    }

    //Bind Payment

    private void Bindpayment(string CurSbCode)
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;

        DataSet ds = AccountController.GetPaymentDetailsbySBEntrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //System.Threading.Thread.Sleep(1000)
            divpaydtls.Visible = true;
            dlpaymentreceipt.Visible = true;
            dlpaymentreceipt.DataSource = ds;
            dlpaymentreceipt.DataBind();
            diverrorPayment.Visible = false;
            lblerrorPayment.Visible = false;
        }
        else
        {
            divpaydtls.Visible = true;
            dlpaymentreceipt.Visible = false;
            diverrorPayment.Visible = true;
            lblerrorPayment.Visible = true;
            lblerrorPayment.Text = "No Payment Records Found!";


        }
    }
    protected void dlpaymentreceipt_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Print")
        {
            dlpaymentreceipt.Visible = false;
            string Receiptid = e.CommandArgument.ToString();
            lblreceiptidedit.Text = Receiptid;
            string sgrcode = txtcursbcode.Text;// encryptQueryString(Receiptid);
            string PPCode = "PP011";// encryptQueryString("2");


            dlpaymentreceipt.Visible = true;
            Bindpayment(txtcursbcode.Text);
            ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
            scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkprint"));
        }
        else if (e.CommandName == "Remove")
        {
            lblnote.Text = "You are about to Remove a Receipt. Please confirm.";
            string Receiptid = e.CommandArgument.ToString();
            lblchequeidno.Text = Receiptid;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#Removereceipt').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        }
        else if (e.CommandName == "Payallocate")
        {
            string Receiptid = e.CommandArgument.ToString();
            string Sbentrycode = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            Sbentrycode = txtcursbcode.Text;
            DataSet ds = AccountController.Getpayallocation(1, Receiptid, Sbentrycode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlpayallocation.DataSource = ds;
                dlpayallocation.DataBind();
            }
            else
            {
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#payallocate').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);


        }
    }
    ///'''''''''''''''''Payment Management'''''''''''''''''''''''''''''''''''
    protected void dlpaymentreceipt_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
            scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkprint"));

            string Status = ((Label)e.Item.FindControl("lblchequestatus")).Text;
            if (Status == "Pending")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.IndianRed
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.DarkViolet;
                //DirectCast(e.Item.FindControl("lnkedit"), LinkButton).Visible = True
                //((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
            }
            else if (Status == "Deposited")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.RosyBrown
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.Blue;
                //DirectCast(e.Item.FindControl("lnkedit"), LinkButton).Visible = False
                //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
            }
            else if (Status == "Cleared")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.Green
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.DarkCyan;
                //DirectCast(e.Item.FindControl("lnkedit"), LinkButton).Visible = False
                //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
            }
            else if (Status == "Bounced")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.Red
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.Red;
                //DirectCast(e.Item.FindControl("lnkedit"), LinkButton).Visible = False
                //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
            }
        }
    }
    protected void btncloseremoverpt_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Removereceipt').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

    }
    protected void btnremovereceipt_ServerClick(object sender, System.EventArgs e)
    {
        DateTime Paydate = DateTime.Today;
        decimal Amtinstr = 0;
        string Sbentrycode = "";
        string Paymode = "";
        string PayInsnum = "";
        DateTime PayInsdate = DateTime.Today;
        string PayInsBankName = "";
        string InsStatus = "";
        string Inslocation = "";
        DateTime InsDepositdate = DateTime.Today;
        DateTime IDepositdate = DateTime.Today;
        DateTime InsBRSDate = DateTime.Today;
        DateTime IBRSdate = DateTime.Today;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string MicrCode = "";
        string PayHeadCode = "";
        string PayHeadDesc = "";
        DateTime Payidate = DateTime.Today;
        DateTime paydate1 = DateTime.Today;
        string Payeeid = "";
        string cardtype = "";
        string cardno = "";
        string Chequeidno = lblchequeidno.Text;
        Sbentrycode = txtcursbcode.Text;
        string Receiptid = AccountController.InsertPayment(4, Paydate.ToString("dd-Mmm-yyyy"), Amtinstr, Sbentrycode, Paymode, PayInsnum, Payidate.ToString("dd-Mmm-yyyy"), PayInsBankName, InsStatus, Inslocation,
        IDepositdate.ToString("dd-Mmm-yyyy"), IBRSdate.ToString("dd-Mmm-yyyy"), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Chequeidno, cardtype, cardno);

        string Cur_sb_code = txtcursbcode.Text;
        Bindlist(Cur_sb_code);
        BindStudentSubjectGroup(Cur_sb_code);
        Bindpayment(Cur_sb_code);
        BindStudentLedger();
        BindChequeOutstanding();
        Bindrequestdetails();
    }

    private void BindChequeallocation()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPPgroupbysbentrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            System.Threading.Thread.Sleep(1000);
            dlallocation.DataSource = ds;
            dlallocation.DataBind();
        }
        else
        {
        }
    }


    protected void ddlpayee_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
    }
    protected void ddlpayeedd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
    }

    protected void ddlpayeecash_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
    }


    protected void btnsavepayment_ServerClick(object sender, System.EventArgs e)
    {
    }
    private void Insertallocation()
    {


    }

    protected void btnclosepayment_ServerClick(object sender, System.EventArgs e)
    {
        dlpaymentreceipt.Visible = true;
        divpayment.Visible = false;
        diverrorPayment.Visible = false;
        lblerrorPayment.Visible = false;
        string Cur_Sub_Code = "";
        Bindpayment(Cur_Sub_Code);
    }

    ///'''''''End of Payment Entry'''''''''''''''''''''''''''''''''''''''''''''''''''

    /// <summary>
    /// '''''''Edit Payment'''''''''''''''''''''''''''''''
    /// </summary>
    /// <remarks></remarks>

    private void Bindpaymodeedit()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = AccountController.GetallPaymode();
        BindDDL(ddlpaymodeedit, ds, "Description", "id");
        ddlpaymodeedit.Items.Insert(0, "Select");
        ddlpaymodeedit.SelectedIndex = 0;
    }
    private void BindPayeeedit()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = AccountController.Getallpayee();
        BindDDL(ddlpayeeedit, ds, "Payee_Name", "payee_id");
        ddlpayeeedit.Items.Insert(0, "Select");
        ddlpayeeedit.SelectedIndex = 0;
        BindDDL(ddlpayeeddedit, ds, "Payee_Name", "payee_id");
        ddlpayeeddedit.Items.Insert(0, "Select");
        ddlpayeeddedit.SelectedIndex = 0;
        BindDDL(ddlpayeecashedit, ds, "Payee_Name", "payee_id");
        ddlpayeecashedit.Items.Insert(0, "Select");
        ddlpayeecashedit.SelectedIndex = 0;
    }
    private void BindChequeallocationEdit()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        string receiptcode = "";
        receiptcode = lblreceiptidedit.Text;
        DataSet ds = AccountController.GetPPgroupbyreceiptcode(receiptcode, "1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            System.Threading.Thread.Sleep(1000);
            dlallocationedit.DataSource = ds;
            dlallocationedit.DataBind();
        }
        else
        {
        }
    }
    private void Bindpaymentdata()
    {
        string Receiptid = "";
        Receiptid = lblreceiptidedit.Text;
        SqlDataReader dr = ProductController.Getreceiptdetailsbyreceiptid(Receiptid, 2);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtpaymentdateedit.Text = dr["CreatedOn"].ToString();
                ddlpaymodeedit.Text = dr["Pay_Mode"].ToString();

                txtbanknameedit.Text = dr["Pay_BankName"].ToString();
                txtmicrcodeedit.Text = dr["micrno"].ToString();
                txtbanknameedit.Text = dr["Pay_BankName"].ToString();
                txtbranchnameedit.Text = dr["bankbranch"].ToString();


                if (ddlpaymodeedit.SelectedValue == "01")
                {
                    tblchequeedit.Visible = true;
                    tblddedit.Visible = false;
                    tblbankdetailsedit.Visible = true;
                    tblcashedit.Visible = false;
                    txtchqdateedit.Text = dr["Pay_InstrDate"].ToString();
                    txtchqnoedit.Text = dr["Pay_InsNum"].ToString();
                    txtchequeamtedit.Text = dr["Instr_Amt"].ToString();
                    ddlpayeeedit.Text = dr["payee_id"].ToString();
                }
                else if (ddlpaymodeedit.SelectedValue == "02")
                {
                    tblchequeedit.Visible = false;
                    tblddedit.Visible = true;
                    tblbankdetailsedit.Visible = true;
                    tblcashedit.Visible = false;
                    txtdddateedit.Text = dr["Pay_InstrDate"].ToString();
                    txtddnoedit.Text = dr["Pay_InsNum"].ToString();
                    txtddamtedit.Text = dr["Instr_Amt"].ToString();
                    ddlpayeeddedit.Text = dr["payee_id"].ToString();

                }
                else if (ddlpaymodeedit.SelectedValue == "03")
                {
                    tblchequeedit.Visible = false;
                    tblddedit.Visible = false;
                    tblbankdetailsedit.Visible = false;
                    txtcashamtedit.Text = dr["Instr_Amt"].ToString();
                    ddlpayeecashedit.Text = dr["payee_id"].ToString();
                }

            }
        }
    }

    protected void ddlpaymodeedit_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlpaymodeedit.SelectedValue == "01")
        {
            tblchequeedit.Visible = true;
            tblddedit.Visible = false;
            tblbankdetailsedit.Visible = true;
            tblcashedit.Visible = false;

        }
        else if (ddlpaymodeedit.SelectedValue == "02")
        {
            tblchequeedit.Visible = false;
            tblddedit.Visible = true;
            tblbankdetailsedit.Visible = true;
            tblcashedit.Visible = false;


        }
        else if (ddlpaymodeedit.SelectedValue == "03")
        {
            tblchequeedit.Visible = false;
            tblddedit.Visible = false;
            tblbankdetailsedit.Visible = false;
            tblcashedit.Visible = true;
        }
    }
    protected void txtmicrcodeedit_TextChanged(object sender, System.EventArgs e)
    {
        string MicrCode = "";
        MicrCode = txtmicrcodeedit.Text;
        SqlDataReader dr = AccountController.GetBanknameandAddress(MicrCode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtbanknameedit.Text = dr["bankname"].ToString();
                txtbranchnameedit.Text = dr["bankbranch"].ToString();
            }
        }
    }
    protected void btnclosepaymentedit_ServerClick(object sender, System.EventArgs e)
    {
        dlpaymentreceipt.Visible = true;
        diveditpayemnt.Visible = false;
        tblchequeedit.Visible = false;
        tblddedit.Visible = false;
        tblbankdetailsedit.Visible = false;
        tblcashedit.Visible = false;
        string Cur_Sub_Code = "";
        Bindpayment(Cur_Sub_Code);
    }
    protected void btnsavepaymentedit_ServerClick(object sender, System.EventArgs e)
    {
        DateTime Paydate = DateTime.Today;
        decimal Amtinstr = 0;
        string Sbentrycode = "";
        string Paymode = "";
        string PayInsnum = "";
        DateTime PayInsdate = DateTime.Today;
        string PayInsBankName = "";
        string InsStatus = "";
        string Inslocation = "";
        DateTime InsDepositdate = DateTime.Today;
        DateTime IDepositdate = DateTime.Today;
        DateTime InsBRSDate = DateTime.Today;
        DateTime IBRSdate = DateTime.Today;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string MicrCode = "";
        string PayHeadCode = "";
        string PayHeadDesc = "";
        DateTime Payidate = DateTime.Today;
        DateTime paydate1 = DateTime.Today;
        paydate1 = DateTime.Today;
        Paydate = Convert.ToDateTime(paydate1, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
        InsDepositdate = DateTime.Today;
        InsBRSDate = DateTime.Today;
        Sbentrycode = txtcursbcode.Text;
        string Payeeid = "";
        string cardtype = "";
        string cardno = "";
        Paymode = ddlpaymodeedit.SelectedValue;
        if (ddlpaymodeedit.SelectedValue == "01")
        {
            Amtinstr = Convert.ToDecimal(txtchequeamtedit.Text);
            PayInsnum = txtchqnoedit.Text;
            PayInsdate = Convert.ToDateTime(txtchqdateedit.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            Payidate = Convert.ToDateTime(txtchqdateedit.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            PayInsBankName = txtbanknameedit.Text;
            InsStatus = "01";
            Inslocation = "";
            IDepositdate = Convert.ToDateTime(InsDepositdate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            IBRSdate = Convert.ToDateTime(InsBRSDate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            MicrCode = txtmicrcodeedit.Text;
            Payeeid = ddlpayeeedit.SelectedValue;
        }
        else if (ddlpaymodeedit.SelectedValue == "02")
        {
            Amtinstr = Convert.ToDecimal(txtddamtedit.Text);
            PayInsnum = txtddnoedit.Text;
            PayInsdate = Convert.ToDateTime(txtdddateedit.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            Payidate = Convert.ToDateTime(txtdddateedit.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            PayInsBankName = txtbanknameedit.Text;
            InsStatus = "01";
            Inslocation = "";
            IDepositdate = Convert.ToDateTime(InsDepositdate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            IBRSdate = Convert.ToDateTime(InsBRSDate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            MicrCode = txtmicrcodeedit.Text;
            Payeeid = ddlpayeeddedit.SelectedValue;
        }
        else if (ddlpaymodeedit.SelectedValue == "03")
        {
            Amtinstr = Convert.ToDecimal(txtcashamtedit.Text);
            PayInsnum = "";
            PayInsdate = DateTime.Today;
            Payidate = Convert.ToDateTime(PayInsdate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            PayInsBankName = "";
            InsStatus = "03";
            Inslocation = "";
            IDepositdate = Convert.ToDateTime(InsDepositdate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            IBRSdate = Convert.ToDateTime(InsBRSDate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            MicrCode = txtmicrcodeedit.Text;
            Payeeid = ddlpayeecashedit.SelectedValue;
        }
        string Receiptcode = lblreceiptidedit.Text;
        string Receiptid = AccountController.InsertPayment(3, Paydate.ToString("dd-Mmm-yyyy"), Amtinstr, Sbentrycode, Paymode, PayInsnum, Payidate.ToString("dd-Mmm-yyyy"), PayInsBankName, InsStatus, Inslocation,
        IDepositdate.ToString("dd-Mmm-yyyy"), IBRSdate.ToString("dd-Mmm-yyyy"), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Receiptcode, cardtype, cardno);
        BindStudentLedger();
        BindChequeOutstanding();
        Bindlist(Sbentrycode);
        dlpaymentreceipt.Visible = true;
        diveditpayemnt.Visible = false;
        dynamic Cur_Sb_Code = "";
        Bindpayment(Cur_Sb_Code);
    }

    /// <summary>
    /// '''''''''''End of Payment Edit
    /// </summary>
    /// <remarks></remarks>

    private void BindStudentLedger()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.Getstudentledgerbysbentrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlstudentledger.DataSource = ds;
            dlstudentledger.DataBind();

        }
        else
        {
        }
    }

    /// <summary>
    /// Check for Student Outstanding and Confirm if Outstanding is 0
    /// </summary>
    private void BindChequeOutstanding()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;

        SqlDataReader dr = AccountController.GetChequeOutstanding(Sbentrycode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtcurrentout.Text = dr["outstanding"].ToString();
            }
        }
        if (lblstdstaus.Text == "Student Status : Pending" && Convert.ToInt32(txtcurrentout.Text) <= 0)
        {
            badgeError.Visible = true;
            badgeSuccess.Visible = false;
            Span1.Visible = false;
            Div18.Visible = false;
            string Output = AccountController.Confirmadmission(Sbentrycode);
            LMS_UserDetails.OE_UserDetailsSoap Client = new LMS_UserDetails.OE_UserDetailsSoapClient();
            DataSet dsdetails = ProductController.LMS_PassAllStudentdetailstoLMSApponConfirmation(Sbentrycode);
            if (dsdetails.Tables[0].Rows.Count > 0)
            {
                string flag = "1";
                string SPID = Convert.ToString(dsdetails.Tables[0].Rows[0]["StudentCode"]);
                string SBEntrycode = Convert.ToString(dsdetails.Tables[0].Rows[0]["SBEntryCode"]);
                string SBEntrycodeold = Convert.ToString(dsdetails.Tables[0].Rows[0]["SBEntryCodeOld"]);
                string StudentAccountId = Convert.ToString(dsdetails.Tables[0].Rows[0]["StudentAccountId"]);
                string CenterCodeJoining = Convert.ToString(dsdetails.Tables[0].Rows[0]["CenterCodeJoining"]);
                string CenterCodeCurrent = Convert.ToString(dsdetails.Tables[0].Rows[0]["CenterCodeCurrent"]);
                ProductController.Insert_LMS_LOG(SPID, SBEntrycode, SBEntrycodeold, StudentAccountId, CenterCodeJoining, CenterCodeCurrent, flag, UserID);
            }


        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            badgeError.Visible = false;
            badgeSuccess.Visible = true;
            Span1.Visible = false;
            Div18.Visible = false;
            goto Rowexit;
        }
        else if (lblstdstaus.Text == "Student Status : Cancelled")
        {
            badgeError.Visible = false;
            badgeSuccess.Visible = false;
            Span1.Visible = true;
            Div18.Visible = false;
        }

        else if (lblstdstaus.Text == "Student Status : Pending")
        {
            badgeError.Visible = true;
            badgeSuccess.Visible = false;
            Span1.Visible = false;
            if (lblSubmitBankLoanFlag.Text != "1")
            {
                Div18.Visible = true;
            }
            else
            {
                Div18.Visible = false;
            }
        }
    Rowexit: ;
    }




    protected void btnproceedprint_ServerClick(object sender, System.EventArgs e)
    {
        string sbentrycode = "";
        sbentrycode = txtcursbcode.Text;

        string Sgrcode = sbentrycode;// encryptQueryString(sbentrycode);
        string PPCode = "PP011"; // encryptQueryString("PP001");
        string Script = "<script type='text/javascript'>window.open('receipt_print.aspx?SBECode=" + Sgrcode + "&PPCode=" + PPCode + "','_blank','height=550,width=950,top=100,left=200,,directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no'); </script>";


        ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", Script);

    }



    public string encryptQueryString(string strQueryString)
    {
        Encryption_Decryption oEs1 = new Encryption_Decryption();
        string EncriptStr = oEs1.EncryptString128Bit(strQueryString, "!#$a54?3");
        return EncriptStr;
    }

    //For Message Box

    protected void btnclosemessage_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#message').modal('hide') });</script>", false);
    }
    protected void btnclosemessage1_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#message').modal('hide') });</script>", false);
    }

    //For Change Subject
    protected void achangesubject_ServerClick(object sender, System.EventArgs e)
    {
    }

    // Add Product

    //Protected Sub aaddsubject_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles aaddsubject.ServerClick
    //    '    BindAddProduct()
    //    '    Divaddproderror.Visible = False
    //    '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Addproduct').modal('show') });</script>", False)

    //End Sub
    private void BindAddProduct()
    {
        string SBEntrycode = "";
        SBEntrycode = txtcursbcode.Text;
        DataSet DSAddproduct = AccountController.GetProducttobeaddedbySbentrycode(1, SBEntrycode);
        if (DSAddproduct.Tables[0].Rows.Count > 0)
        {
            dladdproduct.DataSource = DSAddproduct;
            dladdproduct.DataBind();
            Divaddproderror.Visible = false;
            lbladdproderror.Visible = false;
        }
        else
        {
            Divaddproderror.Visible = true;
            lbladdproderror.Visible = true;
            lbladdproderror.Text = "No Product for addition";
        }
    }
    protected void btnaddprodsave_ServerClick(object sender, System.EventArgs e)
    {
        object obj = null;
        CheckBox Chk = default(CheckBox);
        CheckBox cb = default(CheckBox);
        Label lblsgrname = default(Label);
        Label lblmaterialcode = default(Label);
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        lblmaterialcode = null;
        lblsgrname = null;
        string Sgrcode = "";
        string sbentrycode = txtcursbcode.Text;
        try
        {
            //Dim chk1 As HtmlInputCheckBox = DirectCast(Me.dlsubjectgroup.Items(0).FindControl("Chksgr"), HtmlInputCheckBox)
            //If chk1 IsNot Nothing Then


            foreach (DataListItem li in dladdproduct.Items)
            {
                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }
                obj = li.FindControl("lblvoucherDesc");
                if (obj != null)
                {
                    lblsgrname = (Label)obj;
                }
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblmaterialcode = (Label)obj;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {
                //ProductController.InsertAddandRemoveItem(sbentrycode, Sgrcode, 1)
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Product / Item Group Successfully Added";
                Bindlist(sbentrycode);
                BindStudentSubjectGroup(sbentrycode);
                Bindpayment(sbentrycode);
                //BindPaymode();
                BindStudentLedger();
                BindChequeOutstanding();
                //BindPayhead()
                Bindrequestdetails();
                //Response.Redirect("ManageSubjectGroup.aspx?SBEC=" + LTrim(RTrim(Request.QueryString("SBEC"))))
            }
            else
            {
                Divaddproderror.Visible = true;
                lbladdproderror.Visible = true;
                lbladdproderror.Text = "Select Product!!";

            }

        }
        catch (Exception ex)
        {
        }

    }
    protected void btnaddprodclose_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#AddProduct').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#AddProduct').modal('hide') });</script>", False)
    }
    protected void btnaddprodclose1_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#AddProduct').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#AddProduct').modal('hide') });</script>", False)
    }

    //Remove Product

    private void BindRemoveProduct()
    {
        string SBEntrycode = "";
        SBEntrycode = txtcursbcode.Text;
        DataSet dsremoveproduct = AccountController.GetProducttobeaddedbySbentrycode(2, SBEntrycode);
        if (dsremoveproduct.Tables[0].Rows.Count > 0)
        {
            dlremoveproduct.DataSource = dsremoveproduct;
            dlremoveproduct.DataBind();
            divremoveproderror.Visible = false;
            lblremoveproderror.Visible = false;
        }
        else
        {
            divremoveproderror.Visible = true;
            lblremoveproderror.Visible = true;
            lblremoveproderror.Text = "No Product for removal";
        }
    }
    protected void btnremoveclose_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Removeproduct').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Removeproduct').modal('hide') });</script>", False)
    }
    protected void btnremoveclose1_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Removeproduct').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Removeproduct').modal('hide') });</script>", False)
    }
    protected void btnremovesave_ServerClick(object sender, System.EventArgs e)
    {
        object obj = null;
        CheckBox Chk = default(CheckBox);
        CheckBox cb = default(CheckBox);
        Label lblsgrname = default(Label);
        Label lblmaterialcode = default(Label);
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        lblmaterialcode = null;
        lblsgrname = null;
        string Sgrcode = "";
        string sbentrycode = txtcursbcode.Text;
        try
        {
            //Dim chk1 As HtmlInputCheckBox = DirectCast(Me.dlsubjectgroup.Items(0).FindControl("Chksgr"), HtmlInputCheckBox)
            //If chk1 IsNot Nothing Then


            foreach (DataListItem li in dlremoveproduct.Items)
            {
                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }
                obj = li.FindControl("lblvoucherDesc");
                if (obj != null)
                {
                    lblsgrname = (Label)obj;
                }
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblmaterialcode = (Label)obj;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {
                //ProductController.InsertAddandRemoveItem(sbentrycode, Sgrcode, 2)
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Product / Item Group Successfully Removed";
                Bindlist(sbentrycode);
                BindStudentSubjectGroup(sbentrycode);
                Bindpayment(sbentrycode);
                //BindPaymode()
                BindStudentLedger();
                BindChequeOutstanding();
                // BindPayhead();
                Bindrequestdetails();
                //Response.Redirect("ManageSubjectGroup.aspx?SBEC=" + LTrim(RTrim(Request.QueryString("SBEC"))))
            }
            else
            {
                Divaddproderror.Visible = true;
                lbladdproderror.Visible = true;
                lbladdproderror.Text = "Select Product!!";

            }

        }
        catch (Exception ex)
        {
        }
    }


    //Bind Request Details in Student Ledger
    private void Bindrequestdetails()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;

        DataSet ds = AccountController.GetRequestDetails(Sbentrycode, 1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //System.Threading.Thread.Sleep(1000)
            dlrequestdetails.DataSource = ds;
            dlrequestdetails.DataBind();
            dlrequestdetails.Visible = true;
            div12.Visible = false;
            Label2.Visible = false;
        }
        else
        {
            div12.Visible = true;
            dlrequestdetails.Visible = false;
            Label2.Visible = true;
            Label2.Text = "No Request Records Found!";
        }
    }
    protected void dlrequestdetails_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
    }
    protected void dlrequestdetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string lblrequesttype = ((Label)e.Item.FindControl("lblinsnum")).Text;
            if (lblrequesttype == "Promote Request")
            {
                ((HtmlControl)e.Item.FindControl("divreqaction")).Visible = false;
            }
            else
            {
                ((HtmlControl)e.Item.FindControl("divreqaction")).Visible = true;
            }
        }

    }



    ///'''''''''''''''''''''''''''''''''''''''''''''Request and fee adjustment''''''''''''''''''''''''''''''''''''''''''''''''''''''


    //for Fee Adjustment
    protected void btnadjustment_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#divadjustment').modal('show');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Discountreq').modal('show') });</script>", False)
    }
    protected void btncloseadjustment_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#divadjustment').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
        txtadjustmentamt.Text = "0";
        lbladjerror.Visible = false;
    }

    protected void btncloseadjustment1_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Discountreq').modal('hide') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#divadjustment').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
        txtadjustmentamt.Text = "0";
        lbladjerror.Visible = false;

    }

    protected void btnsaveadjustment_ServerClick(object sender, System.EventArgs e)
    {
        int adjamt = Convert.ToInt16(txtadjustmentamt.Text);
        int minvalue = -99;
        int maxvalue = 99;
        if (adjamt < maxvalue)
        {
            if (adjamt > minvalue)
            {
                string Sbentrycode = txtcursbcode.Text;
                string Vouchertype = "ZA03";
                //DateTime  V1 = 
                string VoucherDate = "";
                float Amount = adjamt;
                string Pricing_Procedure_Code = "";
                string Material_Code = "";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                string returnvalue = ProductController.InsertFeesAdjustment(Sbentrycode, Vouchertype, VoucherDate, Amount, Pricing_Procedure_Code, Material_Code, UserID);
                string Cur_sb_code = "";
                Cur_sb_code = txtcursbcode.Text;
                Bindlist(Cur_sb_code);
                BindStudentSubjectGroup(Cur_sb_code);
                Bindpayment(Cur_sb_code);
                BindChequeallocationTable(Cur_sb_code);
                //BindPaymode()
                BindStudentLedger();
                BindChequeOutstanding();
                //BindPayhead()
                Bindrequestdetails();
                Bindorder();
                Bindorderdetails();
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Fee Adjustment successfully added";

            }
            else
            {
                lbladjerror.Visible = true;
                lbladjerror.Text = "Adjustment amount can be between +/- 99 only";
                //txtadjustmentamt.Text = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("$('#divadjustment').modal('show');");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
                //script1.RegisterAsyncPostBackControl(Repeater1);

            }
        }
        else
        {
            lbladjerror.Visible = true;
            lbladjerror.Text = "Adjustment amount can be between +/- 99 only";
            //txtadjustmentamt.Text = "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#divadjustment').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
            script1.RegisterAsyncPostBackControl(Repeater1);

        }
    }



    //For Discount Request
    protected void adiscountreq_ServerClick(object sender, System.EventArgs e)
    {
        int flag = 1;
        string sbentrycode = txtcursbcode.Text;
        string Requesttypecode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        decimal CenterRequestamt = 0;
        int Levelno = 1;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string response = AccountController.Insertrequest(1, Requesttypecode, sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
        if (response != "0")
        {
            string response1 = AccountController.Insertrequest(4, Requesttypecode, sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
            if (response1 != "0")
            {
                BindProductheaderDiscount();
                BindDiscountReason();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("$('#Discountreq').modal('show');");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
                script1.RegisterAsyncPostBackControl(Repeater1);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Request not send  on same day..!');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Earlier request is still pending for approvals');", true);
        }

    }
    private void BindProductheaderDiscount()
    {
        string Sbentrycode = "";
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPPgroupbysbentrycode(Sbentrycode);
        BindDDL(ddlproductheaderdiscount, ds, "Voucher_description", "pricing_procedure_code");
        ddlproductheaderdiscount.Items.Insert(0, "Select");
        ddlproductheaderdiscount.SelectedIndex = 0;
    }

    protected void ddlproductheaderdiscount_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string Sbentrycode = txtcursbcode.Text;
        string ppgroupcode = ddlproductheaderdiscount.SelectedValue;
        string ppgnetvalue = AccountController.Getppgroupnetvalue(Sbentrycode, ppgroupcode, 1);
        txtnetamountdiscount.Text = ppgnetvalue;
        BindDiscounttype();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Discountreq').modal('show');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Discountreq').modal('show') });</script>", False)
    }

    private void BindDiscounttype()
    {
        int Flag = 2;
        string Requesttype = "";
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttype = "RQ01";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttype = "RQ05";
        }
        string PPgroup = "";
        PPgroup = ddlproductheaderdiscount.SelectedValue;
        DataSet ds = AccountController.GetallPPgroup(Flag, Requesttype, PPgroup);
        BindDDL(ddldiscounttype, ds, "voucher_description", "voucher_type");
        ddldiscounttype.Items.Insert(0, "Select");
        ddldiscounttype.SelectedIndex = 0;
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Discountreq').modal('show') });</script>", False)
    }

    private void BindDiscountReason()
    {
        int Flag = 4;
        
       
        DataSet ds = AccountController.GetallPPgroup(Flag, "", "");
        BindDDL(ddldiscountreason, ds, "Request_Type", "Request_code");
        ddldiscountreason.Items.Insert(0, "Select");
        ddldiscountreason.SelectedIndex = 0;
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Discountreq').modal('show') });</script>", False)
    }

    private void BindCancelReason()
    {
        int Flag = 5;


        DataSet ds = AccountController.GetallPPgroup(Flag, "", "");
        BindDDL(DDLCancellationReson, ds, "Request_Type", "Request_code");
        DDLCancellationReson.Items.Insert(0, "Select");
        DDLCancellationReson.SelectedIndex = 0;
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Discountreq').modal('show') });</script>", False)
    }

    protected void txtdiscountamt_TextChanged(object sender, System.EventArgs e)
    {
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            string Sbentrycode = txtcursbcode.Text;
            float amt = 0;
            amt = float.Parse(txtdiscountamt.Text);
            string center = ddllcenter.SelectedValue;
            DataSet ds = ProductController.GetTaxValue(2, Sbentrycode, amt, center);
            float Taxtotalvalue = float.Parse(ds.Tables[0].Rows[0]["TotalTax1"].ToString());
            txtdiscountamtexcludingst.Text = Convert.ToString(Taxtotalvalue);
        }
        else
        {
            string Sbentrycode = txtcursbcode.Text;
            float amt = 0;
            amt = float.Parse(txtdiscountamt.Text);
            string center = ddlcenter.SelectedValue;
            txtdiscountamtexcludingst.Text = Convert.ToString(amt);
        }

    }

    protected void btnsavediscreq_ServerClick(object sender, System.EventArgs e)
    {
        int Flag = 0;
        string Requesttypecode = "";
        string Sbentrycode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        decimal CenterRequestamt = 0;
        string Reasoncode = "";
        int Levelno = 0;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;



        Flag = 1;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ01";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ05";
        }
        //Requesttypecode = "RQ01"
        Conditiontype = "";
        CenterRemarks = "";
        CenterRequestamt = 0;
        Levelno = 1;


        Flag = 2;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ01";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ05";
        }
        Conditiontype = ddldiscounttype.SelectedValue;
        CenterRemarks = txtDiscremarks.Text;
        CenterRequestamt = Convert.ToDecimal(txtdiscountamtexcludingst.Text);
        Levelno = 1;
        Reasoncode = ddldiscountreason.SelectedValue;

        string response = AccountController.Insertrequest(Flag, Requesttypecode, Sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno, Reasoncode, UserID,"","");

        divSuccessmessage.Visible = true;
        lblsuccessMessage.Visible = true;
        ddldiscounttype.SelectedIndex = 0;
        txtdiscountamt.Text = "0";
        txtDiscremarks.Text = "";
        txtdiscountamtexcludingst.Text = "0";
        BindProductheaderDiscount();
        txtnetamountdiscount.Text = "0";
        lblsuccessMessage.Text = "Request Processed - Sent for approval";
        Bindrequestdetails();

    }
    protected void btnclosemodalDisc_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Discountreq').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Discountreq').modal('hide') });</script>", False)
        ddldiscounttype.SelectedIndex = 0;
        txtdiscountamt.Text = "0";
        txtDiscremarks.Text = "";
        BindProductheaderDiscount();
        txtnetamountdiscount.Text = "0";
        txtdiscountamtexcludingst.Text = "0";
    }

    protected void btnclosemodalDisc1_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Discountreq').modal('hide') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Discountreq').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

        ddldiscounttype.SelectedIndex = 0;
        txtdiscountamt.Text = "0";
        txtDiscremarks.Text = "";
        BindProductheaderDiscount();
        txtnetamountdiscount.Text = "0";
        txtdiscountamtexcludingst.Text = "0";
    }

    ///'''''''''''''''''''Concession Request''''''''''''''''''''''''''''''''''
    //For Concession Request
    protected void aconcessionreq_ServerClick(object sender, System.EventArgs e)
    {
        int flag = 1;
        string sbentrycode = txtcursbcode.Text;
        string Requesttypecode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        decimal CenterRequestamt = 0;
        int Levelno = 1;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string response = AccountController.Insertrequest(1, Requesttypecode, sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
        if (response != "0")
        {
            string response1 = AccountController.Insertrequest(4, Requesttypecode, sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
            if (response1 != "0")
            {
                BindConcessionPPGroup();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("$('#Concessionreq').modal('show');");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
                script1.RegisterAsyncPostBackControl(Repeater1);
                //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Concessionreq').modal('show') });</script>", False)
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Request not send  on same day..!');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Earlier request is still pending for approvals');", true);
        }
    }



    private void BindConcessionPPGroup()
    {

        string Sbentrycode = "";
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPPgroupbysbentrycode(Sbentrycode);
        BindDDL(ddlproductheaderconcession, ds, "Voucher_description", "pricing_procedure_code");
        ddlproductheaderconcession.Items.Insert(0, "Select");
        ddlproductheaderconcession.SelectedIndex = 0;
    }
    protected void ddlproductheaderconcession_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string Sbentrycode = txtcursbcode.Text;
        string ppgroupcode = ddlproductheaderconcession.SelectedValue;
        string ppgnetvalue = AccountController.Getppgroupnetvalue(Sbentrycode, ppgroupcode, 1);
        txtnetamountconcession.Text = ppgnetvalue;
        BindConcessiontype();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Concessionreq').modal('show');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Concessionreq').modal('show') });</script>", False)
    }

    private void BindConcessiontype()
    {
        int Flag = 2;
        string Requesttype = "";
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttype = "RQ02";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttype = "RQ06";
        }
        string PPgroup = "";
        PPgroup = ddlproductheaderconcession.SelectedValue;
        DataSet ds = AccountController.GetallPPgroup(Flag, Requesttype, PPgroup);
        BindDDL(ddlconcessiontype, ds, "voucher_description", "voucher_type");
        ddlconcessiontype.Items.Insert(0, "Select");
        ddlconcessiontype.SelectedIndex = 0;
    }

    protected void txtConcessionamt_TextChanged(object sender, System.EventArgs e)
    {
        string Sbentrycode = txtcursbcode.Text;
        float amt = 0;
        amt = float.Parse(txtconcessionamt.Text);
        string center = ddlcenter.SelectedValue;
        DataSet ds = ProductController.GetTaxValue(2, Sbentrycode, amt, center);
        float Taxtotalvalue = float.Parse(ds.Tables[0].Rows[0]["TotalTax1"].ToString());
        txtConcessionamtexcludingst.Text = Convert.ToString(Taxtotalvalue);
    }

    protected void btnsaveconcreq_ServerClick(object sender, System.EventArgs e)
    {
        int Flag = 0;
        string Requesttypecode = "";
        string Sbentrycode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        decimal CenterRequestamt = 0;
        int Levelno = 0;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;

        Flag = 1;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ02";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ06";
        }
        //Requesttypecode = "RQ02"
        Conditiontype = "";
        CenterRemarks = "";
        CenterRequestamt = 0;
        Levelno = 1;


        Flag = 2;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ02";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ06";
        }
        Conditiontype = ddlconcessiontype.SelectedValue;
        CenterRemarks = txtconceremarks.Text;
        CenterRequestamt = Convert.ToDecimal(txtConcessionamtexcludingst.Text);
        Levelno = 1;
        string response = AccountController.Insertrequest(Flag, Requesttypecode, Sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
        divSuccessmessage.Visible = true;
        lblsuccessMessage.Visible = true;
        ddlconcessiontype.SelectedIndex = 0;
        txtconceremarks.Text = "";
        txtconcessionamt.Text = "0";
        txtnetamountconcession.Text = "0";
        txtConcessionamtexcludingst.Text = "0";
        BindConcessionPPGroup();
        lblsuccessMessage.Text = "Request Processed - Sent for approval";
        Bindrequestdetails();
        BindDiscountReason();

    }
    protected void btnclosemodalconc_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Concessionreq').modal('hide') });</script>", False)
        ddlconcessiontype.SelectedIndex = 0;
        txtconceremarks.Text = "";
        txtconcessionamt.Text = "0";
        txtnetamountconcession.Text = "0";
        txtConcessionamtexcludingst.Text = "0";
        BindConcessionPPGroup();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Concessionreq').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

    }

    protected void btnclosemodalconc1_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Concessionreq').modal('hide') });</script>", False)
        ddlconcessiontype.SelectedIndex = 0;
        txtconceremarks.Text = "";
        txtconcessionamt.Text = "0";
        txtnetamountconcession.Text = "0";
        txtConcessionamtexcludingst.Text = "0";
        BindConcessionPPGroup();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Concessionreq').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }





    ///''''''''''''''''''''''''''''''''Waiver Request''''''''''''''''''''''''''''''''''''''''''''''''
    //Waiver

    protected void awaiverreq_ServerClick(object sender, System.EventArgs e)
    {
        int flag = 1;
        string sbentrycode = txtcursbcode.Text;
        string Requesttypecode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        decimal CenterRequestamt = 0;
        int Levelno = 1;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string response = AccountController.Insertrequest(1, Requesttypecode, sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
        if (response != "0")
        {
            //Bindwaivertype()
            txtwaiverrequestdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            BindWaiverPPGroup();
            //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Waiver').modal('show') });</script>", False)
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#Waiver').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
            script1.RegisterAsyncPostBackControl(Repeater1);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Earlier request is still pending for approvals');", true);
        }
    }
    private void BindWaiverPPGroup()
    {

        string Sbentrycode = "";
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPPgroupbysbentrycode(Sbentrycode);
        BindDDL(ddlproductheaderwaiver, ds, "Voucher_description", "pricing_procedure_code");
        ddlproductheaderwaiver.Items.Insert(0, "Select");
        ddlproductheaderwaiver.SelectedIndex = 0;
    }
    protected void ddlproductheaderwaiver_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string Sbentrycode = txtcursbcode.Text;
        string ppgroupcode = ddlproductheaderwaiver.SelectedValue;
        //string maxwaiveramt = "";
        string ppgnetvalue = AccountController.Getppgroupnetvalue(Sbentrycode, ppgroupcode, 1);
        txtnetamountwaiver.Text = ppgnetvalue;
        Bindwaivertype();
    }

    private void Bindwaivertype()
    {

        string Requesttype = "";
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            int Flag = 2;
            Requesttype = "RQ09";
            string PPgroup = "";
            PPgroup = ddlproductheaderwaiver.SelectedValue;
            DataSet ds = AccountController.GetallPPgroup(Flag, Requesttype, PPgroup);
            BindDDL(ddlwaivertype, ds, "voucher_description", "voucher_type");
            ddlwaivertype.Items.Insert(0, "Select");
            ddlwaivertype.SelectedIndex = 0;
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            int Flag = 3;
            Requesttype = "RQ09";
            string PPgroup = "";
            PPgroup = ddlproductheaderwaiver.SelectedValue;
            DataSet ds = AccountController.GetallPPgroup(Flag, Requesttype, PPgroup);
            BindDDL(ddlwaivertype, ds, "voucher_description", "voucher_type");
            ddlwaivertype.Items.Insert(0, "Select");
            ddlwaivertype.SelectedIndex = 0;
            ddlwaivertype.Items.Remove("");
            ddlwaivertype.Items.Remove("");

        }

    }

    protected void ddlwaivertype_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string Sbentrycode = txtcursbcode.Text;
        string ppgroupcode = ddlproductheaderwaiver.SelectedValue;
        string waivertype = ddlwaivertype.SelectedValue;
        string maxwaiveramt = AccountController.GetwaiverMaxAmt(Sbentrycode, ppgroupcode, 1, waivertype);
        txtwaivermaxamt.Text = maxwaiveramt;

    }

    protected void btnsavewaiver_ServerClick(object sender, System.EventArgs e)
    {
        int Flag = 0;
        string Requesttypecode = "";
        string Sbentrycode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        decimal CenterRequestamt = 0;
        int Levelno = 0;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;

        Flag = 1;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ09";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ09";
        }
        //Requesttypecode = "RQ04"
        Conditiontype = ddlwaivertype.SelectedValue;
        CenterRemarks = txtwaiverremark.Text;
        CenterRequestamt = 0;
        Levelno = 1;

        Flag = 2;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ09";
            Conditiontype = ddlwaivertype.SelectedValue;
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ09";
            Conditiontype = ddlwaivertype.SelectedValue;
        }

        //Requesttypecode = "RQ04"

        CenterRemarks = txtwaiverremark.Text;
        CenterRequestamt = Convert.ToDecimal(txtwaiveramt.Text);
        Levelno = 1;
        string response = AccountController.Insertrequest(Flag, Requesttypecode, Sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
        divSuccessmessage.Visible = true;
        lblsuccessMessage.Visible = true;
        BindWaiverPPGroup();
        txtwaiveramt.Text = "";
        txtwaiverremark.Text = "";
        ddlwaivertype.SelectedIndex = 0;
        txtnetamountwaiver.Text = "";
        txtwaivermaxamt.Text = "";
        lblsuccessMessage.Text = "Request Processed - Sent for approval";
        Bindrequestdetails();

    }

    protected void btnclosewaiver_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Waiver').modal('hide') });</script>", False)
        BindWaiverPPGroup();
        txtwaiveramt.Text = "";
        txtwaiverremark.Text = "";
        ddlwaivertype.SelectedIndex = 0;
        txtnetamountwaiver.Text = "";
        txtwaivermaxamt.Text = "";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Waiver').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }

    protected void btnclosewaiver1_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Waiver').modal('hide') });</script>", False)
        BindWaiverPPGroup();
        txtwaiveramt.Text = "";
        txtwaiverremark.Text = "";
        ddlwaivertype.SelectedIndex = 0;
        txtnetamountwaiver.Text = "";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Waiver').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }

    ///'''''''''''''''''''''''''''''''''''Refund''''''''''''''''''''''''''''''''''''''''''''''

    protected void arefundrequest_ServerClick(object sender, System.EventArgs e)
    {
        txtrefunddate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        BindRefundPPGroup();
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Refund').modal('show') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Refund').modal('show');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

    }

    private void BindRefundPPGroup()
    {

        string Sbentrycode = "";
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPPgroupbysbentrycode(Sbentrycode);
        BindDDL(ddlproductheaderrefund, ds, "Voucher_description", "pricing_procedure_code");
        ddlproductheaderrefund.Items.Insert(0, "Select");
        ddlproductheaderrefund.SelectedIndex = 0;
        txtnetamountrefund.Text = "";
    }

    protected void ddlproductheaderrefund_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string Sbentrycode = txtcursbcode.Text;
        string ppgroupcode = ddlproductheaderrefund.SelectedValue;
        string ppgnetvalue = AccountController.Getppgroupnetvalue(Sbentrycode, ppgroupcode, 2);
        txtnetamountrefund.Text = ppgnetvalue;
        Bindrefundtype();
    }

    private void Bindrefundtype()
    {
        int Flag = 2;
        string Requesttype = "";
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttype = "RQ04";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttype = "RQ04";
        }
        string PPgroup = "";
        PPgroup = ddlproductheaderrefund.SelectedValue;
        DataSet ds = AccountController.GetallPPgroup(Flag, Requesttype, PPgroup);
        BindDDL(ddlrefundtype, ds, "voucher_description", "voucher_type");
        ddlrefundtype.Items.Insert(0, "Select");
        ddlrefundtype.SelectedIndex = 0;

    }

    protected void btnrefundclose_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Refund').modal('hide') });</script>", False)
        BindRefundPPGroup();
        ddlrefundtype.SelectedIndex = 0;
        txtrefundcenter.Text = "";
        txtrefundamount.Text = "0";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Refund').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

    }

    protected void btnrefundclose1_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Refund').modal('hide') });</script>", False)
        BindRefundPPGroup();
        ddlrefundtype.SelectedIndex = 0;
        txtrefundcenter.Text = "";
        txtrefundamount.Text = "0";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Refund').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }

    protected void Btnrefundsave_ServerClick(object sender, System.EventArgs e)
    {
        int Flag = 0;
        string Requesttypecode = "";
        string Sbentrycode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        if (txtrefundamount.Text == "")
        {
            txtrefundamount.Text = "0";
        }

        decimal CenterRequestamt = 0;
        int Levelno = 0;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;

        Flag = 1;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ04";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ04";
        }
        //Requesttypecode = "RQ04"
        Conditiontype = ddlrefundtype.SelectedValue;
        CenterRemarks = txtrefundcenter.Text;
        CenterRequestamt = 0;
        Levelno = 1;

        Flag = 2;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ04";
            Conditiontype = ddlrefundtype.SelectedValue;
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ04";
            Conditiontype = ddlrefundtype.SelectedValue;
        }

        //Requesttypecode = "RQ04"

        CenterRemarks = txtrefundcenter.Text;
        CenterRequestamt = Convert.ToDecimal(txtrefundamount.Text);
        Levelno = 1;
        string response = AccountController.Insertrequest(Flag, Requesttypecode, Sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
        divSuccessmessage.Visible = true;
        lblsuccessMessage.Visible = true;
        BindRefundPPGroup();
        ddlrefundtype.SelectedIndex = 0;
        txtrefundcenter.Text = "";
        txtrefundamount.Text = "0";
        lblsuccessMessage.Text = "Request Processed - Sent for approval";
        Bindrequestdetails();

    }


    //For Admission Cancellation

    protected void acanceladdmission_ServerClick(object sender, System.EventArgs e)
    {
        int flag = 1;
        string sbentrycode = txtcursbcode.Text;
        string Requesttypecode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        decimal CenterRequestamt = 0;
        int Levelno = 1;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string response = AccountController.Insertrequest(1, Requesttypecode, sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");

        if (response != "0")
        {

            BindCancelReason();
            txtcanceldate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#AdmissionCancel').modal('show') });</script>", False)
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#AdmissionCancel').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
            script1.RegisterAsyncPostBackControl(Repeater1);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Earlier request is still pending for approvals');", true);
        }
    }

    protected void btncancelsave_ServerClick(object sender, System.EventArgs e)
    {
        int Flag = 0;
        string Requesttypecode = "";
        string Sbentrycode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        string CancellReson = "";
        decimal CenterRequestamt = 0;
        int Levelno = 0;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;

        if (IsRefundApplicabale.SelectedValue == "0")
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = "Kindly select Refund Status";

        }

        //if (IsRefundApplicabale.SelectedValue == "2")
        //{
        //    DDlISINTERNALREFUND.SelectedValue = "-0";
        //}
        Flag = 1;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ03";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ07";
        }

        Conditiontype = "";
        CenterRemarks = "";
        CenterRequestamt = 0;
        Levelno = 1;

        Flag = 2;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ03";
            Conditiontype = "ZZ01";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ07";
            Conditiontype = "ZZ02";
        }
        //Requesttypecode = "RQ03"
        CenterRemarks = txtcancelcenterremarks.Text;
        CenterRequestamt = 0;
        Levelno = 1;
        CancellReson = DDLCancellationReson.SelectedValue;
        string response = AccountController.Insertrequest(Flag, Requesttypecode, Sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno, CancellReson, UserID, IsRefundApplicabale.SelectedValue, "");
        divErrormessage.Visible = false;
        divSuccessmessage.Visible = true;
        lblsuccessMessage.Visible = true;
        lblsuccessMessage.Text = "Request Processed - Sent for approval";
        Bindrequestdetails();
        txtcancelcenterremarks.Text = "";
        IsRefundApplicabale.SelectedValue = "-0";

    }

  
    protected void btncancelclose_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#AdmissionCancel').modal('hide') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#AdmissionCancel').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
        txtcancelcenterremarks.Text = "";

    }

    protected void btncancelclose1_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#AdmissionCancel').modal('hide') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#AdmissionCancel').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }

    //Cheque Return Request

    protected void aChequereturnrequest_ServerClick(object sender, System.EventArgs e)
    {
        txtchequeretuendate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        string Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPaymentDetailsbySBEntrycode2(Sbentrycode);
        BindDDL(ddlchequenumber, ds, "Pay_InsNum", "chequeidno");
        ddlchequenumber.Items.Insert(0, "Select");
        ddlchequenumber.SelectedIndex = 0;

        DataSet ds1 = AccountController.GetallChequeReturnReason();
        BindDDL(ddlreturnreason, ds1, "Return_Reason", "ReturnReason_Id");
        ddlreturnreason.Items.Insert(0, "Select");
        ddlreturnreason.SelectedIndex = 0;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Chequereturn').modal('show');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }

    protected void btnChequereturnrequest_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Baddebts').modal('hide') });</script>", False)
        ddlchequenumber.SelectedIndex = 0;
        ddlreturnreason.SelectedIndex = 0;
        txtchequereturnremarks.Text = "";
        txtchequeamountreturn.Text = "";
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Chequereturn').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

    }

    protected void ddlchequenumber_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string Sbentrycode = txtcursbcode.Text;
        string Chequeidno = ddlchequenumber.SelectedValue;
        string Chequeamount = AccountController.GetChequeamount(Sbentrycode, Chequeidno, 1);
        //string ppgnetvalue = AccountController.Getppgroupnetvalue(Sbentrycode, ppgroupcode, 2);
        txtchequeamountreturn.Text = Chequeamount;
    }

    protected void btnChequereturnrequesssave_ServerClick(object sender, System.EventArgs e)
    {

        ChequeReturnRequest.MTEL_ChequeReturnRequestSoap Client = new ChequeReturnRequest.MTEL_ChequeReturnRequestSoapClient();
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        //1- for DEV and 2 for PRD
        string Verno = "2";
        string CenterCode = ddlcenter.SelectedValue;
        string SBEntrycode = txtcursbcode.Text;
        string studentname = txtstudentname.Text;
        string chequeidno = ddlchequenumber.SelectedValue;
        string returnreasonid = ddlreturnreason.SelectedValue;
        string CenteruserName = UserName;
        string ReturnReasonNote = txtchequereturnremarks.Text;
        DataSet message = Client.AddChequeReturnRequest(Verno, CenterCode, SBEntrycode, studentname, chequeidno, returnreasonid, CenteruserName, ReturnReasonNote);
        string code = message.Tables[0].Rows[0]["Code"].ToString();
        string Desc = message.Tables[0].Rows[0]["Description"].ToString();


        System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
        sb1.Append("<script type = 'text/javascript'>");
        sb1.Append("window.onload=function(){");
        sb1.Append("alert('");
        sb1.Append(Desc);
        sb1.Append("')};");
        sb1.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());


        if (code == "00")
        {
            int Flag = 1;
            string Center_Code = ddlcenter.SelectedValue;
            string SBEntrycode1 = txtcursbcode.Text;
            string DispatchSlipNo = "";
            string DispatchSlipEntrycode = "";
            string ChequeIdNo = ddlchequenumber.SelectedValue;
            string CenterChequeNo = ddlchequenumber.SelectedItem.Text;
            decimal CenterChequeAmt = 0;
            string CCChequeNo = "";
            decimal CCChequeAmount = 0;
            string Changeflag = "CF04";
            string ChangeReason = ddlreturnreason.SelectedValue;
            string Created_By = UserID;
            string returncode = AccountController.InsertChequeReturnRequest(Flag, Center_Code, SBEntrycode, DispatchSlipNo, DispatchSlipEntrycode, ChequeIdNo, CenterChequeNo, CenterChequeAmt, CCChequeNo, CCChequeAmount, Changeflag, ChangeReason, Created_By);

        }
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Chequereturn').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        ddlchequenumber.SelectedIndex = 0;
        ddlreturnreason.SelectedIndex = 0;
        txtchequereturnremarks.Text = "";
        txtchequeamountreturn.Text = "";
    }


    //Bad Debt Request

    protected void abaddebtsrequest_ServerClick(object sender, System.EventArgs e)
    {
        txtbaddebtdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Baddebts').modal('show') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Baddebts').modal('show');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }

    protected void btnbaddebtsclose_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Baddebts').modal('hide') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Baddebts').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }

    protected void btnbaddebtsclose1_ServerClick(object sender, System.EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Baddebts').modal('hide') });</script>", False)
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Baddebts').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }

    protected void btnbaddebtssave_ServerClick(object sender, System.EventArgs e)
    {
        int Flag = 0;
        string Requesttypecode = "";
        string Sbentrycode = "";
        string Conditiontype = "";
        string CenterRemarks = "";
        decimal CenterRequestamt = 0;
        int Levelno = 0;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        Flag = 1;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ11";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ11";
        }
        Conditiontype = "";
        CenterRemarks = "";
        CenterRequestamt = Convert.ToDecimal(txtamtbaddebts.Text);
        Levelno = 1;
        Flag = 2;
        if (lblstdstaus.Text == "Student Status : Pending")
        {
            Requesttypecode = "RQ11";
            Conditiontype = "BD01";
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            Requesttypecode = "RQ11";
            Conditiontype = "BD01";
        }
        CenterRemarks = txtcenterremarksbaddebts.Text;
        CenterRequestamt = Convert.ToDecimal(txtamtbaddebts.Text);
        Levelno = 1;
        string response = AccountController.Insertrequest(Flag, Requesttypecode, Sbentrycode, Conditiontype, CenterRemarks, CenterRequestamt, Levelno,"", UserID,"","");
        divSuccessmessage.Visible = true;
        lblsuccessMessage.Visible = true;
        lblsuccessMessage.Text = "Request Processed - Sent for approval";
        Bindrequestdetails();
        txtcenterremarksbaddebts.Text = "";
        txtamtbaddebts.Text = "";

    }


    //For Promote Student
    protected void apromotestudent_ServerClick(object sender, System.EventArgs e)
    {

    }









    protected void dlselectivepromote_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int Flag = 2;
            string Uomid = "";
            DropDownList d = (DropDownList)e.Item.FindControl("ddluom");
            Label baseuomid = (Label)e.Item.FindControl("lblbaseuomid");
            DataSet ds = ProductController.GetallUom(Flag, baseuomid.Text);
            BindDDL(d, ds, "UOM_DESC", "UOM_Id");
            d.Items.Insert(0, "Select");
            d.SelectedIndex = 0;
        }
    }




    protected void btnclosepayallocate_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#payallocate').modal('hide') });</script>", false);

    }

    protected void btnclosepayallocate1_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#payallocate').modal('hide') });</script>", false);

    }

    protected void btnorderdtls_ServerClick(object sender, System.EventArgs e)
    {
        divpaydtls.Visible = false;
        divorder.Visible = true;
        lblheadertext.Text = "Order Details";
    }

    protected void acloseorder_ServerClick(object sender, System.EventArgs e)
    {
        divpaydtls.Visible = true;
        divorder.Visible = false;
        lblheadertext.Text = "Payment Details";
    }

    private void Bindorder()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string StreamName = "";
        string Center = "";
        StreamName = ddllstream.SelectedValue;
        Center = ddllcenter.SelectedValue;
        string SBentrycode = "";
        SBentrycode = txtcursbcode.Text;
        DataSet ds = ProductController.Getorder(1, StreamName, Center, SBentrycode, UserID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlselective1.DataSource = ds;
            dlselective1.DataBind();
        }
        else
        {
        }
    }

  

    private void Bindorderdetails()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string StreamName = "";
        string Center = "";
        StreamName = ddllstream.SelectedValue;
        Center = ddllcenter.SelectedValue;
        string SBentrycode = "";
        SBentrycode = txtcursbcode.Text;
        DataSet ds = ProductController.Getorder(2, StreamName, Center, SBentrycode, UserID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlselective2.DataSource = ds;
            dlselective2.DataBind();
        }
        else
        {
        }
    }


    protected void btnBankLoan_ServerClick(object sender, System.EventArgs e)
    {
        if (txtcursbcode.Text != string.Empty)
        {
            // divBankLoanError.Visible = false;
            txtLoanDate.Value = "";
            chkLoanFlag.Checked = false;
            if (lblLoanDate.Text != "")
            {
                txtLoanDate.Value = lblLoanDate.Text;
            }
            if (lblBankLoanFlag.Text != "")
            {
                if (lblBankLoanFlag.Text == "1")
                {
                    chkLoanFlag.Checked = true;
                }
                else if (lblBankLoanFlag.Text == "0")
                {
                    chkLoanFlag.Checked = false;
                }
            }
            upnlBankLoan.Update();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalBankLoan();", true);
        }
    }

    protected void btnLoanSave_Click(object sender, EventArgs e)
    {

        try
        {
            int ApplyLoanFlag = 0;
            string ApplyLoanDate = "";
            if (chkLoanFlag.Checked == true)
            {
                ApplyLoanFlag = 1;
            }
            else
            {
                ApplyLoanFlag = 0;
            }
            ApplyLoanDate = txtLoanDate.Value;
            int ResultId = 0;
            ResultId = ProductController.InsertBankLoanForStudent(ApplyLoanFlag, ApplyLoanDate, txtcursbcode.Text, "1");
            if (ResultId == 1)
            {
                if (chkLoanFlag.Checked == true)
                {
                    lblBankLoanFlag.Text = "1";
                }
                else if (chkLoanFlag.Checked == false)
                {
                    lblBankLoanFlag.Text = "0";
                }
                lblLoanDate.Text = txtLoanDate.Value;
            }
            else
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Bank Loan Information Not Saved";
            }
            txtLoanDate.Value = "";
        }
        catch (Exception ex)
        {

            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.ToString();
        }
    }

    protected void btnLoan_Close_Click(object sender, EventArgs e)
    {
        txtLoanDate.Value = "";
    }

    protected void btnproceedEventAfterCourseDuration_ServerClick(object sender, System.EventArgs e)
    {
        string sbentrycode = "";
        sbentrycode = txtcursbcode.Text;

        Response.Redirect("CD.aspx?&Cur_Sb_Code=" + sbentrycode + "&Oppid=" + txtopportunityid.Text);
    }


    protected void aconfirmadmission_ServerClick(object sender, System.EventArgs e)
    {
        int flag = 1;
        string sbentrycode = txtcursbcode.Text;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string response = AccountController.ValidateConfirmAdmission(flag, sbentrycode);
        if (response == "Success")
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#Confirmadmission').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
            script1.RegisterAsyncPostBackControl(Repeater1);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + response + "');", true);
        }
    }

    protected void btnsaveConfirmadmission_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string SBentrycode = "";
        SBentrycode = txtcursbcode.Text;
        string response = AccountController.ForceConfirmAdmission(SBentrycode);
        if (response == "Success")
        {
            string Output = AccountController.Confirmadmission(SBentrycode);
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Event Successfully Completed');", true);
            btnrefersh_ServerClick(sender, e);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Event could not be completed, Please contact Administrator');", true);
        }
    }
    protected void btnclosemodalConfirmadmission1_ServerClick(object sender, System.EventArgs e)
    {

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Confirmadmission').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);

    }

    protected void btnclosemodalConfirmadmission_ServerClick(object sender, System.EventArgs e)
    {

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Confirmadmission').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        script1.RegisterAsyncPostBackControl(Repeater1);
    }


    private void RequestEneble()
    {
       
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
       

        DataSet ds = AccountController.GetRequestEneblebyuser(UserID);
        if (ds.Tables[0].Rows.Count >0)
           // if ((ds.Tables[0].Rows[0]["Role_Code"].ToString() == "R000") || (ds.Tables[0].Rows[0]["Role_Code"].ToString() == "R000") || (ds.Tables[0].Rows[0]["Role_Code"].ToString() == "R000"))
            {
                adiscountreq.Visible = false;
                aconcessionreq.Visible = false;
                awaiverreq.Visible = false;
                acanceladdmission.Visible = false;
               
            }

    }
}