using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using System.Data.SqlClient.SqlDataReader;
//using Exportxls.BL;
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
//using Exportxls.BL;

public partial class Approval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //string Menuid = "119";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            //limidbreadcrumb.Visible = false;
            //lblpagetitle1.Text = "Approval";
            //lblpagetitle2.Text = "";
            limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Approval";
            lilastbreadcrumb.Visible = false;
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            //lbltabname.Text = "Search by"
            btnback.Visible = false;
            btnbackmain.Visible = false;
            upnlsearch.Visible = true;
            Upnlviewledger.Visible = false;
            //System.Threading.Thread.Sleep(4000);
            script1.RegisterAsyncPostBackControl(btnback);
            listudentstatus.Visible = false;
            //lblpagetitle1.Visible = false;
            //lblpagetitle2.Visible = false;
            divmessage.Visible = false;
            divSearch.Visible = true;
            divsearchresults.Visible = false;

            BindRequestType();
            BindCompany();
            BindDivision();
            //ddldivision.Items.Insert(0, "All");
            //ddldivision.SelectedIndex = 0;
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;
            ddlacademicyear.Items.Insert(0, "All");
            ddlacademicyear.SelectedIndex = 0;
            ddlstreamname.Items.Insert(0, "All");
            ddlstreamname.SelectedIndex = 0;
            string Useraction = "";
            Useraction = ProductController.GetUserAction(UserID);
            if (Useraction == "A100001")
            {
                divapprovalall.Visible = true;
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Bulk Approval feature is available";
            }
            else
            {
                divapprovalall.Visible = false;
                divSuccessmessage.Visible = false;

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

    private void BindRequestType()
    {
        DataSet ds = AccountController.GetallRequesttype();
        BindDDL(ddlrequesttype, ds, "Request_Type", "Request_Code");
        ddlrequesttype.Items.Insert(0, "All");
        ddlrequesttype.SelectedIndex = 0;
    }

    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
        ddlcompany.Items.Insert(0, "All");
        ddlcompany.SelectedIndex = 0;
    }
    //protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindDivision();
    //}
    private void BindDivision()
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;

    }
    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }
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
        BindAcademicYear();
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddlcenter.SelectedValue);
        BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "All");
        ddlacademicyear.SelectedIndex = 0;
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
        BindDDL(ddlstreamname, ds, "Stream_Sdesc", "Stream_Code");
        ddlstreamname.Items.Insert(0, "All");
        ddlstreamname.SelectedIndex = 0;
    }


    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        string Requesttype = "";
        string Requestdate = "";
        string RequestStatus = "";
        string Company = "";
        string Division = "";
        string Center = "";
        string Academicyear = "";
        string Stream = "";
        string SBEntrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Studentname = "";
        string Appno = "";
        lblpagetitle1.Visible = false;
        lblpagetitle2.Visible = false;
        

        Requesttype = ddlrequesttype.SelectedValue;
        if (string.IsNullOrEmpty(txtrequestdate.Text))
        {
            Requestdate = "";
        }
        else
        {
            Requestdate = txtrequestdate.Text;
            //Convert.ToDateTime(txtrequestdate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat)
        }
        RequestStatus = ddlrequeststatus.SelectedValue;
        Company = ddlcompany.SelectedValue;
        Division = ddldivision.SelectedValue;
        Center = ddlcenter.SelectedValue;
        Academicyear = ddlacademicyear.SelectedValue;
        Stream = ddlstreamname.SelectedValue;
        SBEntrycode = txtsbentrycode.Text;
        Studentname = txtname.Text;
        Appno = txtapplicationno.Text;

        DataSet ds = AccountController.GetAllrequest(Requesttype, Requestdate, RequestStatus, Company, Division, Center, Academicyear, Stream, SBEntrycode, UserID,
        Studentname, Appno);


        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Approvals";
            lblpagetitle2.Text = "Approvals Search Results";
            limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Approval";
            lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = " Approval Search Results";
            lilastbreadcrumb.Visible = true;
            limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Approval";
            //lbltabname.Text = "Search Results"
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            btnbackmain.Visible = true;


            divsearchresults.Visible = true;
            divmessage.Visible = false;
            //System.Threading.Thread.Sleep(4000)

            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            //script1.RegisterAsyncPostBackControl(Repeater1);
        }
        else
        {
            btnbackmain.Visible = false;
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            divmessage.Visible = true;
            lblmessage.Text = "No Records Found!";
        }
    }

    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            txtcrfrefundamt.Text = "";
            txtroborefundamt.Text = "";
            txtamtlevel3.Text = "0";
            txtamtlevel2.Text = "0";

            trlevel3_6.Visible = true;
            //System.Threading.Thread.Sleep(2000)
            upnlsearch.Visible = false;
            Upnlviewledger.Visible = true;
            lblpagetitle1.Text = "Approval";
            lblpagetitle2.Text = "Request Details";
            limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Approval";
            lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = "Request Details";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            btnback.Visible = true;
            //lbltabname1.Text = "Request Details"
            string Cur_Sb_Code = "";
            Cur_Sb_Code = e.CommandArgument.ToString();
            Session["CUR_SB_Code"] = e.CommandArgument.ToString();
            Bindlist(Cur_Sb_Code);
            BindStudentSubjectGroup(Cur_Sb_Code);
            BindStudentLedger();
            string Requestid = ((Label)e.Item.FindControl("lblrequestid")).Text;
            lblrequestid.Text = Requestid;
            BindLeveldetails(Requestid);
            //System.Threading.Thread.Sleep(2000)
            diverrorrequest.Visible = false;
            divSuccessRequest.Visible = false;
            //Get User Level
            //Based on User level true or false
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string CenterCode = ddllcenter.SelectedValue;
            CompareValidator10021.Visible = true;
            CompareValidator3.Visible = true;
            CompareValidator1.Visible = true;


            string Userlevel = AccountController.GetUserlevel(Requestid, UserID, CenterCode);
            //Userlevel = "3"
            if (Userlevel == "1")
            {
                trlevel1_1.Visible = true;
                //trlevel1_2.Visible = True
                trlevel1_3.Visible = true;
                //divlevel1.Visible = True
                divlevel1New.Visible = true;
                divlevel1error.Visible = false;
                divlevel1success.Visible = false;

                divlevel1.Visible = true;
                trlevel2_1.Visible = false;
                trlevel2_2.Visible = false;
                trlevel2_3.Visible = false;
                //trlevel2_4.Visible = False
                trlevel2_5.Visible = false;
                divlevel2New.Visible = false;


                Divlevel3.Visible = false;
                trlevel3_1.Visible = false;
                trlevel3_2.Visible = false;
                trlevel3_3.Visible = false;
                //trlevel3_4.Visible = False
                trlevel3_5.Visible = false;
                divlevel3New.Visible = false;

                BindRequestDetails(Cur_Sb_Code);

            }
            else if (Userlevel == "2")
            {
                trlevel1_1.Visible = false;
                //trlevel1_2.Visible = False
                trlevel1_3.Visible = false;


                trlevel2_1.Visible = true;
                trlevel2_2.Visible = true;
                trlevel2_3.Visible = true;
                //trlevel2_4.Visible = True
                trlevel2_5.Visible = true;
                Div8.Visible = true;
                divlevel1.Visible = false;
                divlevel1New.Visible = true;
                divlevel2New.Visible = true;
                divlevel1error.Visible = false;
                divlevel1success.Visible = false;
                divlevel2error.Visible = false;
                divlevel2success.Visible = false;


                trlevel3_1.Visible = false;
                trlevel3_2.Visible = false;
                trlevel3_3.Visible = false;
                //trlevel3_4.Visible = False
                trlevel3_5.Visible = false;
                divlevel3New.Visible = false;
                BindRequestDetails(Cur_Sb_Code);


            }
            else if (Userlevel == "3")
            {
                trlevel1_1.Visible = false;
                // trlevel1_2.Visible = False
                trlevel1_3.Visible = false;
                divlevel1New.Visible = false;

                //centerrequest.Visible = true;
                trlevel2_1.Visible = true;
                trlevel2_2.Visible = true;
                divlevel1New.Visible = true;
                divlevel2New.Visible = true;
                btnsubmitlevel2.Visible = false;

                txtapprovedamt1.Enabled = false;
                txtstatus1.Enabled = false;
                Txtappdate1.Enabled = false;
                txtpremark1.Enabled = false;

                trlevel2_3.Visible = false;
                Div8.Visible = false;
                //trlevel2_4.Visible = False
                trlevel2_5.Visible = false;
                divlevel1.Visible = false;
                divlevel2error.Visible = false;
                divlevel2success.Visible = false;
                //Divlevel2.Visible = False

                trlevel3_1.Visible = true;
                trlevel3_2.Visible = true;
                trlevel3_3.Visible = true;
                //trlevel3_4.Visible = True
                trlevel3_5.Visible = true;
                Divlevel3.Visible = true;
                btnsubmitlevel3.Visible = true;
                divlevel1error.Visible = false;
                divlevel1success.Visible = false;
                BindRequestDetails(Cur_Sb_Code);

                if (txtrequesttype1.Text == "Admission Cancellation - Pre-Admission")
                {
                    trlevel3_6.Visible = false;
                }
                else if (txtrequesttype1.Text == "Admission Cancellation - Post-Admission")
                {
                    trlevel1_1.Visible = false;
                    trlevel2_3.Visible = false;
                    trlevel3_6.Visible = true;
                }
            }
            if (txtrequesttype1.Text == "Admission Cancellation")
            {
                trlevel1_1.Visible = false;
                trlevel2_3.Visible = false;
                //trlevel3_6.Visible = true;
                BindRequestDetails(Cur_Sb_Code);
                //trlevel3_6.Visible = true;
                //trlevel3_7.Visible = true;
            }
            //else
            //{
            //    trlevel3_6.Visible = false;
            //    trlevel3_7.Visible = false;
            //}

        }
    }

    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((LinkButton)e.Item.FindControl("lnkviewdetails")).Visible = true;
            ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
            scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkviewdetails"));
            string Requestdate = ((Label)e.Item.FindControl("Label1")).Text;
            if (string.IsNullOrEmpty(Requestdate))
            {
                ((Label)e.Item.FindControl("Label10")).Visible = false;
            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(Requestdate)) <= DateTime.Today)
                {
                    ((Label)e.Item.FindControl("Label10")).Visible = true;
                    //Get Open days
                    System.DateTime startDate = DateTime.Today;
                    //DateTime.Now.ToString("dd/MM/yyyy")
                    DateTime enddate = Convert.ToDateTime(ClsCommon.FormatDate(Requestdate));
                    TimeSpan ts = startDate.Subtract(enddate);
                    string Opendays = "";
                    Opendays = ts.Days.ToString();
                    //txtdateofbirth.Text = 
                    //Dim var As Integer
                    //var = Math.Truncate(dob / 365)
                    ((Label)e.Item.FindControl("Label10")).Text = Opendays;
                }
                else
                {
                    ((Label)e.Item.FindControl("Label10")).Visible = false;
                }
            }
        }
    }

    private void BindLeveldetails(string requestid)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        //Dim Requestid As String = ""
        //Requestid = lblreqcode.Text
        SqlDataReader dr = AccountController.GetAlluserbylevel(requestid);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                lblCenterusername.Text = dr["centreuser"].ToString();
                lbluserlevel1.Text = dr["apr1name"].ToString();
                lbluserlevel2.Text = dr["apr2name"].ToString();
                lbluserlevel3.Text = dr["apr3name"].ToString();
            }
        }

    }

    private void BindRequestDetails(string CurSbcode)
    {
        string SBEntrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        SBEntrycode = CurSbcode;
        string Requestid = lblrequestid.Text;
        SqlDataReader dr = AccountController.GetAllrequestasreader(SBEntrycode, UserID, Requestid);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtrequesttype1.Text = dr["Voucher_description"].ToString();
                txtrequestdate1.Text = dr["requestdate1"].ToString();
                txtconditiontype.Text = dr["Request_type"].ToString();
                txtrequestamt.Text = dr["amt1"].ToString();
                txtcenterremark1.Text = dr["Centre_remarks"].ToString();
                lblreqcode.Text = dr["request_type_code"].ToString();
                if (lblreqcode.Text == "RQ03" | lblreqcode.Text == "RQ07" | lblreqcode.Text == "RQ04")
                {
                    comparevalidator7.Visible = false;
                    comparevalidator2.Visible = false;
                    comparevalidator4.Visible = false;
                    txtamountapp.Enabled = false;
                    txtamtlevel2.Enabled = false;
                    txtamtlevel3.Enabled = false;
                    trlevel3_6.Visible = true;
                    //trlevel3_7.Visible = true;
                }

                if (lblreqcode.Text == "RQ04")
                {
                    comparevalidator7.Visible = false;
                    CompareValidator1.Visible = false;
                    txtamountapp.Enabled = false;
                    txtamtlevel2.Enabled = false;
                    txtamtlevel3.Enabled = true;
                    trlevel3_6.Visible = true;
                    //trlevel3_7.Visible = true;
                }
                else
                {
                    comparevalidator7.Visible = true;
                    comparevalidator2.Visible = true;
                    comparevalidator4.Visible = true;
                    txtamountapp.Enabled = true;
                    txtamtlevel2.Enabled = true;
                    txtamtlevel3.Enabled = true;
                    trlevel3_6.Visible = false;
                    //trlevel3_7.Visible = false;
                }
                txtapprovedamt1.Text = dr["amt2"].ToString();
                txtstatus1.Text = "Approved";
                Txtappdate1.Text = dr["aprdt2"].ToString();
                txtpremark1.Text = dr["rmk2"].ToString();
                txtapprovalamt2.Text = dr["amt3"].ToString();
                Txtappdate2.Text = dr["aprdt3"].ToString();
                txtpremark2.Text = dr["rmk3"].ToString();
                txtstatus2.Text = "Approved";
            }
        }

    }



    private void Bindlist(string Cursbcode)
    {
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
                txtLstudentname.Text = dr["NAME"].ToString();
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
                txtpayplan.Text = dr["payplan"].ToString();
                string Studentstatus = "";
                Studentstatus = dr["Account_Status_id"].ToString();
                if (Studentstatus == "01")
                {
                    listudentstatus.Visible = true;
                    lblstdstaus.Text = "Student Status : Pending";
                    badgeError.Visible = true;
                    badgeSuccess.Visible = false;
                    badgeCancel.Visible = false;

                }
                else if (Studentstatus == "03")
                {
                    listudentstatus.Visible = true;
                    lblstdstaus.Text = "Student Status : Confirmed";
                    badgeError.Visible = false;
                    badgeSuccess.Visible = true;
                    badgeCancel.Visible = false;
                }
                else if (Studentstatus == "02")
                {
                    listudentstatus.Visible = true;
                    lblstdstaus.Text = "Customer Status : Cancelled";
                    badgeCancel.Visible = true;
                    badgeError.Visible = false;
                    badgeSuccess.Visible = false;
                }
            }
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
            //System.Threading.Thread.Sleep(1000)
            dlstudentledger.DataSource = ds;
            dlstudentledger.DataBind();

        }
        else
        {
        }
    }

    protected void btnsubmitapp_ServerClick(object sender, System.EventArgs e)
    {

        try
        {
            string SBentrycode = "";
            string Req_Code = "";
            string Center = "";
            int Status = 0;
            string remarks = "";
            decimal amount = 0;

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            SBentrycode = txtcursbcode.Text;

            Req_Code = lblreqcode.Text;
            SBentrycode = txtcursbcode.Text;
            Center = ddllcenter.SelectedValue;
            Status = Convert.ToInt32(rbtlapprove.SelectedValue);
            remarks = txtappremark.Text;
            if (Req_Code == "RQ03" | Req_Code == "RQ07" | Req_Code == "RQ04")
            {
                amount = 0;
            }
            else
            {
                amount = Convert.ToDecimal(txtamountapp.Text);
            }
            //amount = txtamountapp.Text

            string Request_id = lblrequestid.Text;

            string Returnresponse = AccountController.UpdateRequest(SBentrycode, Req_Code, Center, Status, remarks, amount, UserID, Request_id);
            if (Status == 1)
            {
                diverrorrequest.Visible = false;
                divSuccessRequest.Visible = true;
                lblsuccessReq.Visible = true;
                lblsuccessReq.Text = "Request Successfully Approved";
                centerrequest.Visible = false;
                btnsubmitapp.Visible = false;
                div11.Visible = false;
                divlevel1New.Visible = false;
                divlevel2New.Visible = false;
                divlevel3New.Visible = false;
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Request Successfully Approved";
                Upnlviewledger.Visible = false;
                rbtlapprove.SelectedIndex = 0;
                txtappremark.Text = "";
                txtamountapp.Text = "";

            }
            else
            {
                diverrorrequest.Visible = false;
                divSuccessRequest.Visible = true;
                lblsuccessReq.Visible = true;
                lblsuccessReq.Text = "Request Successfully Declined";
                centerrequest.Visible = false;
                btnsubmitapp.Visible = false;
                div11.Visible = false;
                divlevel1New.Visible = false;
                divlevel2New.Visible = false;
                divlevel3New.Visible = false;
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Request Declined";
                Upnlviewledger.Visible = false;
                rbtlapprove.SelectedIndex = 0;
                txtappremark.Text = "";
                txtamountapp.Text = "";
            }
            //End If

            //=divErrormessage.Visible = False
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }

    }

    protected void btnsubmitlevel2_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            //If txtrequestamt.Text < txtamtlevel2.Text Then
            //    Label8.Text = "Amount cannot be greater than the requested amount"
            //    txtamtlevel2.Focus()
            //    Exit Sub
            //Else

            string SBentrycode = "";
            string Req_Code = "";
            string Center = "";
            int Status = 0;
            string remarks = "";
            decimal amount = 0;

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            SBentrycode = txtcursbcode.Text;

            Req_Code = lblreqcode.Text;
            SBentrycode = txtcursbcode.Text;
            Center = ddllcenter.SelectedValue;
            Status = Convert.ToInt32(rbtlapprovelevel1.SelectedValue);
            remarks = txtremark2.Text;
            if (Req_Code == "RQ03" | Req_Code == "RQ07" | Req_Code == "RQ04")
            {
                amount = 0;
            }
            else
            {
                amount = Convert.ToDecimal(txtamtlevel2.Text);
            }
            string Request_id = lblrequestid.Text;
            string Returnresponse = AccountController.UpdateRequest(SBentrycode, Req_Code, Center, Status, remarks, amount, UserID, Request_id);
            if (Status == 1)
            {
                divlevel2error.Visible = false;
                divlevel2success.Visible = true;
                lbllevel2success.Visible = true;
                lbllevel2success.Text = "Request Successfully approved";
                div11.Visible = false;
                divlevel1New.Visible = false;
                divlevel2New.Visible = false;
                divlevel3New.Visible = false;
                centerrequest.Visible = false;
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Request Successfully Approved";
                Upnlviewledger.Visible = false;
                rbtlapprovelevel1.SelectedIndex = 0;
                txtamtlevel2.Text = "";
                txtremark2.Text = "";
            }
            else
            {
                divlevel2error.Visible = true;
                lbllevel2error.Visible = true;
                lbllevel2error.Text = "Request Successfully Declined";
                divlevel2success.Visible = false;
                divlevel2New.Visible = false;
                lblsuccessReq.Visible = false;
                //lblsuccessReq.Text = "Request Successfully Approved"
                div11.Visible = false;
                centerrequest.Visible = false;
                divlevel1New.Visible = false;
                divlevel2New.Visible = true;
                divlevel3New.Visible = false;
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Request Declined";
                Upnlviewledger.Visible = false;
                rbtlapprovelevel1.SelectedIndex = 0;
                txtamtlevel2.Text = "";
                txtremark2.Text = "";
            }
            //End If


            //divErrormessage.Visible = False
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void btnsubmitlevel3_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            //If txtrequestamt.Text < txtamtlevel3.Text Then
            //    Label9.Text = "Amount cannot be greater than the requested amount"
            //    txtamtlevel3.Focus()
            //    Exit Sub
            //Else

            divErrormessage.Visible = false;
            string SBentrycode = "";
            string Req_Code = "";
            string Center = "";
            int Status = 0;
            string remarks = "";
            decimal amount = 0;
            float amt = 0;
            float amt1 = 0;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            SBentrycode = txtcursbcode.Text;

            Req_Code = lblreqcode.Text;
            SBentrycode = txtcursbcode.Text;
            Center = ddllcenter.SelectedValue;
            Status = Convert.ToInt32(rbtlapprovelevel3.SelectedValue);
            remarks = txtremark3.Text;
            string Pricing_Procedure_Code = "";
            string Material_Code = "";
            string VoucherDate = "";
            // CRF Amount Validation
            if (Req_Code == "RQ07")
            {
                if (txtcrfrefundamt.Text.Trim() != "")
                {
                    string maxwaiveramt = AccountController.GetwaiverMaxAmt(SBentrycode, "PP01", 1, "ZC09");
                    if (float.Parse(maxwaiveramt) < float.Parse(txtcrfrefundamt.Text.Trim()))
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Registration Waiver amount cannot be greater than Registration Value";
                        return;
                    }
                }
                if (txtroborefundamt.Text.Trim() != "")
                {
                    string maxwaiveramt = AccountController.GetwaiverMaxAmt(SBentrycode, "PP01", 1, "ZC11");
                    if (float.Parse(maxwaiveramt) < float.Parse(txtroborefundamt.Text.Trim()))
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Robomate Content Price Waiver amount cannot be greater than Robomate Content Price";
                        return;
                    }
                }
            }

            if (Req_Code == "RQ03" | Req_Code == "RQ07")
            {
                amount = 0;
            }
            else
            {
                amt1 = float.Parse(txtamtlevel3.Text);
                DataSet ds = ProductController.GetTaxValue(1, SBentrycode, amt1, Center);
                float Taxtotalvalue = float.Parse(ds.Tables[0].Rows[0]["TotalTax"].ToString());
                float STTax = float.Parse(ds.Tables[0].Rows[0]["Stax"].ToString());
                float HTAx = float.Parse(ds.Tables[0].Rows[0]["Htax"].ToString());
                float Etax = float.Parse(ds.Tables[0].Rows[0]["Etax"].ToString());
                float SBtax = float.Parse(ds.Tables[0].Rows[0]["SBtax"].ToString());
                float CGST = float.Parse(ds.Tables[0].Rows[0]["CGST"].ToString());
                float SGST = float.Parse(ds.Tables[0].Rows[0]["SGST"].ToString());
                float UGST = float.Parse(ds.Tables[0].Rows[0]["UGST"].ToString());
                float Newamount = amt1 + Taxtotalvalue;
                amount = Convert.ToDecimal(amt1);
                amt = amt1;
            }
            string Request_id = lblrequestid.Text;
            string Returnresponse = AccountController.UpdateRequestWithCancellationAmount(SBentrycode, Req_Code, Center, Status, remarks, amount, UserID, Request_id, txtcrfrefundamt.Text, txtroborefundamt.Text);
            if (Req_Code == "RQ01" | Req_Code == "RQ02" | Req_Code == "RQ09")
            {
                DataSet ds = ProductController.GetTaxValue(1, SBentrycode, amt, Center);
                float Taxtotalvalue = float.Parse(ds.Tables[0].Rows[0]["TotalTax"].ToString());
                float STTax = float.Parse(ds.Tables[0].Rows[0]["Stax"].ToString());
                float HTAx = float.Parse(ds.Tables[0].Rows[0]["Htax"].ToString());
                float Etax = float.Parse(ds.Tables[0].Rows[0]["Etax"].ToString());
                float SBtax = float.Parse(ds.Tables[0].Rows[0]["SBtax"].ToString());
                float KKTax = float.Parse(ds.Tables[0].Rows[0]["kktax"].ToString());
                float CGST = float.Parse(ds.Tables[0].Rows[0]["CGST"].ToString());
                float SGST = float.Parse(ds.Tables[0].Rows[0]["SGST"].ToString());
                float UGST = float.Parse(ds.Tables[0].Rows[0]["UGST"].ToString());

                STTax = STTax * -1;
                HTAx = HTAx * -1;
                Etax = Etax * -1;
                SBtax = SBtax * -1;
                KKTax = KKTax * -1;
                CGST = CGST * -1;
                SGST = SGST * -1;
                UGST = UGST * -1;


                string returnvalue1 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT01", VoucherDate, STTax, Pricing_Procedure_Code, Material_Code, UserID);
                string returnvalue2 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT02", VoucherDate, HTAx, Pricing_Procedure_Code, Material_Code, UserID);
                string returnvalue3 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT03", VoucherDate, Etax, Pricing_Procedure_Code, Material_Code, UserID);
                string returnvalue4 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT04", VoucherDate, SBtax, Pricing_Procedure_Code, Material_Code, UserID);
                string returnvalue5 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT05", VoucherDate, KKTax, Pricing_Procedure_Code, Material_Code, UserID);
                string returnvalue6 = ProductController.InsertFeesAdjustment(SBentrycode, "JOCG", VoucherDate, CGST, Pricing_Procedure_Code, Material_Code, UserID);
                string returnvalue7 = ProductController.InsertFeesAdjustment(SBentrycode, "JOSG", VoucherDate, SGST, Pricing_Procedure_Code, Material_Code, UserID);
                string returnvalue8 = ProductController.InsertFeesAdjustment(SBentrycode, "JOUG", VoucherDate, UGST, Pricing_Procedure_Code, Material_Code, UserID);

            }

            if (Status == 1)
            {
                diverrorrequest.Visible = false;
                divSuccessRequest.Visible = true;
                lblsuccessReq.Visible = true;
                lblsuccessReq.Text = "Request Successfully approved";
                div11.Visible = false;
                divlevel1New.Visible = false;
                divlevel2New.Visible = false;
                divlevel3New.Visible = false;
                centerrequest.Visible = false;
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Request Successfully Approved";
                Upnlviewledger.Visible = false;
                rbtlapprovelevel3.SelectedIndex = 0;
                txtamtlevel3.Text = "";
                txtremark3.Text = "";
            }
            else
            {
                diverrorrequest.Visible = true;
                lblerrorReq.Visible = true;
                lblerrorReq.Text = "Request Successfully Declined";
                divSuccessRequest.Visible = false;
                lblsuccessReq.Visible = false;
                lblsuccessReq.Text = "Request Successfully Approved";
                div11.Visible = false;
                divlevel1New.Visible = false;
                divlevel2New.Visible = false;
                divlevel3New.Visible = false;
                centerrequest.Visible = false;
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Request Declined";
                Upnlviewledger.Visible = false;
                rbtlapprovelevel3.SelectedIndex = 0;
                txtamtlevel3.Text = "";
                txtremark3.Text = "";
            }

            //End If


            //divErrormessage.Visible = False
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void rbtlapprove_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (lblreqcode.Text == "RQ03" | lblreqcode.Text == "RQ07" | lblreqcode.Text == "RQ04")
        {
        }
        else
        {
            if (rbtlapprove.SelectedValue == "2")
            {
                RequiredFieldValidator4.Visible = false;
                CompareValidator10021.Visible = false;
                txtamountapp.Enabled = false;
                txtamountapp.Text = "0";
                comparevalidator7.Visible = false;
            }
            else
            {
                RequiredFieldValidator4.Visible = true;
                CompareValidator10021.Visible = true;
                txtamountapp.Enabled = true;
                comparevalidator7.Visible = true;
                //txtamountapp.Text = ""
            }
        }
    }

    protected void rbtlapprovelevel1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (lblreqcode.Text == "RQ03" | lblreqcode.Text == "RQ07" | lblreqcode.Text == "RQ04")
        {

        }
        else
        {
            if (rbtlapprovelevel1.SelectedValue == "2")
            {
                RequiredFieldValidator2.Visible = false;
                CompareValidator3.Visible = false;
                txtamtlevel2.Enabled = false;
                txtamtlevel2.Text = "0";
                comparevalidator2.Visible = false;

            }
            else
            {
                RequiredFieldValidator2.Visible = true;
                CompareValidator3.Visible = true;
                txtamtlevel2.Enabled = true;
                comparevalidator2.Visible = true;


            }
        }

    }

    protected void rbtlapprovelevel3_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //If lblreqcode.Text = "RQ03" Then
        //Else'

        if (lblreqcode.Text == "RQ03" | lblreqcode.Text == "RQ07" | lblreqcode.Text == "RQ04")
        {
        }
        else
        {
            if (rbtlapprovelevel3.SelectedValue == "2")
            {
                RequiredFieldValidator5.Visible = false;
                CompareValidator1.Visible = false;
                txtamtlevel3.Enabled = false;
                txtamtlevel3.Text = "0";
                comparevalidator4.Visible = false;

            }
            else
            {
                RequiredFieldValidator5.Visible = true;
                CompareValidator1.Visible = true;
                txtamtlevel3.Enabled = true;
                comparevalidator4.Visible = true;

            }
        }

        //End If

    }


    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        Upnlviewledger.Visible = false;
        lblpagetitle1.Text = "Approval";
        lblpagetitle2.Text = "Request Details";
        limidbreadcrumb.Visible = false;
        lblmidbreadcrumb.Text = "Approval";
        lilastbreadcrumb.Visible = false;
        lbllastbreadcrumb.Text = "Request Details";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnback.Visible = false;
        listudentstatus.Visible = false;
        div11.Visible = true;
        divlevel1New.Visible = true;
        divlevel2New.Visible = true;
        divlevel3New.Visible = true;
        centerrequest.Visible = true;
        btnsubmitapp.Visible = true;
        divSuccessmessage.Visible = false;
        btnsearch_ServerClick(sender, e);

    }

    protected void btnbackmain_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        divsearchresults.Visible = false;
        Divsearchcriteria.Visible = true;

        Upnlviewledger.Visible = false;
        lblpagetitle1.Text = "Approval";
        lblpagetitle2.Text = "Request Details";
        limidbreadcrumb.Visible = false;
        lblmidbreadcrumb.Text = "Approval";
        lilastbreadcrumb.Visible = false;
        lbllastbreadcrumb.Text = "Request Details";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnback.Visible = false;
        listudentstatus.Visible = false;
        div11.Visible = true;
        divlevel1New.Visible = true;
        divlevel2New.Visible = true;
        divlevel3New.Visible = true;
        centerrequest.Visible = true;
        btnsubmitapp.Visible = true;
        divSuccessmessage.Visible = false;
        //btnsearch_ServerClick(sender, e);

    }

    public void All_Student_ChkBox_Selected_Sel(object sender, System.EventArgs e)
    {
        //Change checked status of a hidden check box
        chkStudentAllHidden_Sel.Checked = !(chkStudentAllHidden_Sel.Checked);

        //Set checked status of hidden check box to items in grid
        foreach (RepeaterItem dtlItem in Repeater1.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            chkitemck.Checked = chkStudentAllHidden_Sel.Checked;
        }

    }

    protected void btnapproveall_ServerClick(object sender, System.EventArgs e)
    {
        foreach (RepeaterItem dtlItem in Repeater1.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            Label lblrequestid = (Label)dtlItem.FindControl("lblrequestid");
            Label lblsbentrycode = (Label)dtlItem.FindControl("lblsbentrycode");
            Label lblrequest_type = (Label)dtlItem.FindControl("lblrequest_type");
            Label lblcentercode = (Label)dtlItem.FindControl("lblcentercode");
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            //string Req_Code = ddlrequesttype.SelectedValue;
            string Req_Code = lblrequest_type.Text;
            int Status = 1;
            string remarks = "Bulk Approval";
            string Center = lblcentercode.Text;
            string Pricing_Procedure_Code = "";
            string Material_Code = "";
            string VoucherDate = "";

            if (chkitemck.Checked == true)
            {

                string SBentrycode = lblsbentrycode.Text;
                string Request_id = lblrequestid.Text;
                //Label lblamt = new Label();
                string amount1 = "";
                decimal amount = 0;
                float amt = 0;
                float amt1 = 0;
                string Userlevel = AccountController.GetUserlevel(Request_id, UserID, Center);
                SqlDataReader dr = AccountController.GetAllrequestasreader(SBentrycode, UserID, Request_id);
                if ((((dr) != null)))
                {
                    if (dr.Read())
                    {
                        if (Userlevel == "1")
                        {
                            amount1 = dr["amt1"].ToString();
                            amount = Convert.ToDecimal(amount1);
                            if (Req_Code == "RQ03" | Req_Code == "RQ07")
                            {
                                amount = 0;
                            }
                            else
                            {
                                amt1 = float.Parse(amount1);

                            }
                            string Returnresponse = AccountController.UpdateRequest(SBentrycode, Req_Code, Center, Status, remarks, amount, UserID, Request_id);
                        }
                        else if (Userlevel == "2")
                        {
                            amount1 = dr["amt2"].ToString();
                            amount = Convert.ToDecimal(amount1);
                            if (Req_Code == "RQ03" | Req_Code == "RQ07")
                            {
                                amount = 0;
                            }
                            else
                            {
                                amt1 = float.Parse(amount1);

                            }
                            string Returnresponse = AccountController.UpdateRequest(SBentrycode, Req_Code, Center, Status, remarks, amount, UserID, Request_id);
                        }
                        else if (Userlevel == "3")
                        {
                            amount1 = dr["amt3"].ToString();
                            amount = Convert.ToDecimal(amount1);
                            if (Req_Code == "RQ03" | Req_Code == "RQ07")
                            {
                                amount = 0;
                            }
                            else
                            {
                                amt1 = float.Parse(amount1);
                                DataSet ds = ProductController.GetTaxValue(1, SBentrycode, amt1, Center);
                                float Taxtotalvalue = float.Parse(ds.Tables[0].Rows[0]["TotalTax"].ToString());
                                float STTax = float.Parse(ds.Tables[0].Rows[0]["Stax"].ToString());
                                float HTAx = float.Parse(ds.Tables[0].Rows[0]["Htax"].ToString());
                                float Etax = float.Parse(ds.Tables[0].Rows[0]["Etax"].ToString());
                                float SBtax = float.Parse(ds.Tables[0].Rows[0]["SBtax"].ToString());
                                float KKTax = float.Parse(ds.Tables[0].Rows[0]["kktax"].ToString());
                                float CGST = float.Parse(ds.Tables[0].Rows[0]["CGST"].ToString());
                                float SGST = float.Parse(ds.Tables[0].Rows[0]["SGST"].ToString());
                                float UGST = float.Parse(ds.Tables[0].Rows[0]["UGST"].ToString());
                                float Newamount = amt1 + Taxtotalvalue;
                                amount = Convert.ToDecimal(amt1);
                                amt = amt1;
                            }
                            //string Request_id = lblrequestid.Text;
                            string Returnresponse = AccountController.UpdateRequest(SBentrycode, Req_Code, Center, Status, remarks, amount, UserID, Request_id);
                            if (Req_Code == "RQ01" | Req_Code == "RQ02" | Req_Code == "RQ09")
                            {
                                DataSet ds = ProductController.GetTaxValue(1, SBentrycode, amt, Center);
                                float Taxtotalvalue = float.Parse(ds.Tables[0].Rows[0]["TotalTax"].ToString());
                                float STTax = float.Parse(ds.Tables[0].Rows[0]["Stax"].ToString());
                                float HTAx = float.Parse(ds.Tables[0].Rows[0]["Htax"].ToString());
                                float Etax = float.Parse(ds.Tables[0].Rows[0]["Etax"].ToString());
                                float SBtax = float.Parse(ds.Tables[0].Rows[0]["SBtax"].ToString());
                                float KKTax = float.Parse(ds.Tables[0].Rows[0]["kktax"].ToString());
                                float CGST = float.Parse(ds.Tables[0].Rows[0]["CGST"].ToString());
                                float SGST = float.Parse(ds.Tables[0].Rows[0]["SGST"].ToString());
                                float UGST = float.Parse(ds.Tables[0].Rows[0]["UGST"].ToString());
                                STTax = STTax * -1;
                                HTAx = HTAx * -1;
                                Etax = Etax * -1;
                                SBtax = SBtax * -1;
                                KKTax = KKTax * -1;
                                CGST = CGST * -1;
                                SGST = SGST * -1;
                                UGST = UGST * -1;

                                string returnvalue1 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT01", VoucherDate, STTax, Pricing_Procedure_Code, Material_Code, UserID);
                                string returnvalue2 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT02", VoucherDate, HTAx, Pricing_Procedure_Code, Material_Code, UserID);
                                string returnvalue3 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT03", VoucherDate, Etax, Pricing_Procedure_Code, Material_Code, UserID);
                                string returnvalue4 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT04", VoucherDate, SBtax, Pricing_Procedure_Code, Material_Code, UserID);
                                string returnvalue5 = ProductController.InsertFeesAdjustment(SBentrycode, "ZT05", VoucherDate, KKTax, Pricing_Procedure_Code, Material_Code, UserID);
                                string returnvalue6 = ProductController.InsertFeesAdjustment(SBentrycode, "JOCG", VoucherDate, CGST, Pricing_Procedure_Code, Material_Code, UserID);
                                string returnvalue7 = ProductController.InsertFeesAdjustment(SBentrycode, "JOSG", VoucherDate, SGST, Pricing_Procedure_Code, Material_Code, UserID);
                                string returnvalue8 = ProductController.InsertFeesAdjustment(SBentrycode, "JOUG", VoucherDate, UGST, Pricing_Procedure_Code, Material_Code, UserID);
                            }
                        }
                    }
                }
            }
        }
        upnlsearch.Visible = true;
        Upnlviewledger.Visible = false;
        lblpagetitle1.Text = "Approval";
        lblpagetitle2.Text = "Request Details";
        limidbreadcrumb.Visible = false;
        lblmidbreadcrumb.Text = "Approval";
        lilastbreadcrumb.Visible = false;
        lbllastbreadcrumb.Text = "Request Details";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnback.Visible = false;
        listudentstatus.Visible = false;
        div11.Visible = true;
        divlevel1New.Visible = true;
        divlevel2New.Visible = true;
        divlevel3New.Visible = true;
        centerrequest.Visible = true;
        btnsubmitapp.Visible = true;
        divSuccessmessage.Visible = false;
        btnsearch_ServerClick(sender, e);

    }
}