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
using Encryption.BL;
using System.Globalization;

public partial class Receive_Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["MyCookiesLoginInfo"] != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string UserID = cookie.Values["UserID"];
                    string UserName = cookie.Values["UserName"];
                    upnlsearch.Visible = false;
                    Upnlviewledger.Visible = true;
                    lblpagetitle1.Text = "Receive Payments";
                    lblpagetitle2.Text = "";
                    //limidbreadcrumb.Visible = true;
                    lblmidbreadcrumb.Text = "Manage Payments";
                    //lilastbreadcrumb.Visible = true;
                    lbllastbreadcrumb.Text = "Receive Payments";
                    divSuccessmessage.Visible = false;
                    divErrormessage.Visible = false;
                    //lbltabname1.Text = "Student Ledger"
                    string Cur_Sb_Code = "";
                    Cur_Sb_Code = Request["Cur_sb_code"];
                    Session["CUR_SB_Code"] = Request["Cur_sb_code"];
                    diverrorPayment.Visible = false;
                    divSuccessPayment.Visible = false;
                    //btnviewenrollment.Visible = true;
                    Bindlist(Cur_Sb_Code);
                    BindStudentSubjectGroup(Cur_Sb_Code);
                    Bindpayment(Cur_Sb_Code);
                    //BindPaymode()
                    BindStudentLedger();
                    BindChequeOutstanding();
                    //BindPayhead()
                    //Bindrequestdetails();
                    diveditpayemnt.Visible = false;
                    string oppid = txtopportunityid.Text;
                    //HtmlAnchor viewenrollment = btnviewenrollment;
                    //viewenrollment.HRef = "Enrollment_display.aspx?&Oppur_id=" + oppid;
                    dlpaymentreceipt.Visible = true;
                    divpayment.Visible = false;
                    txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    tblbankdetails.Visible = false;
                    tblcash.Visible = false;
                    tblcheque.Visible = false;
                    tblDD.Visible = false;
                    
                    lblusercompany.Text = "MT";
                    tdapplicationid.Visible = false;
                    tdapplicationid1.Visible = false;
                    divmessage.Visible = false;
                    divSearch.Visible = true;
                    divsearchresults.Visible = false;
                    diveditpayemnt.Visible = false;
                    BindCompany();
                    //BindPayplan();
                    BindProductCategory();
                    StudentType();
                    Institutetype();
                    CountrySearch();
                    Board();
                    Eventtype();
                    BindStudentpendingresaon();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }
            GetSumvalue();
            GetSumvaluedd();
            GetSumvaluecash();
            //divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void StudentType()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlcustomertypesearch, ds, "Description", "Cust_Grp");
        ddlcustomertypesearch.Items.Insert(0, "All");
        ddlcustomertypesearch.SelectedIndex = 0;
    }
    private void Institutetype()
    {
        DataSet ds = ProductController.GetallInstituteType();
        BindDDL(ddlinstitutionsearch, ds, "Description", "ID");
        ddlinstitutionsearch.Items.Insert(0, "All");
        ddlinstitutionsearch.SelectedIndex = 0;
    }
    private void Eventtype()
    {
        DataSet ds = ProductController.GetallEventtype();
        BindDDL(ddlevent, ds, "event_description", "event_type");
        ddlevent.Items.Insert(0, "All");
        ddlevent.SelectedIndex = 0;
    }

    protected void ddlinstitutionsearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutionsearch.SelectedValue);
        BindDDL(ddlstandardsearch, ds, "Description", "ID");
        this.ddlstandardsearch.Items.Insert(0, "All");
        this.ddlstandardsearch.SelectedIndex = 0;
    }
    private void Board()
    {
        DataSet ds = ProductController.GetallBoard();
        BindDDL(ddlboardsearch, ds, "Short_Description", "ID");
        ddlboardsearch.Items.Insert(0, "All");
        ddlboardsearch.SelectedIndex = 0;
        ddlstandardsearch.Items.Insert(0, "All");
        ddlstandardsearch.SelectedIndex = 0;
    }
    private void BindProductCategory()
    {
        DataSet ds = ProductController.GetallOpporProductCategory();
        BindDDL(ddlproductcategory, ds, "Description", "ID");
        ddlproductcategory.Items.Insert(0, "All");
        ddlproductcategory.SelectedIndex = 0;
    }
    private void CountrySearch()
    {
        DataSet ds = ProductController.GetallCountry();
        BindDDL(ddlcountrysearch, ds, "Country_Name", "Country_Code");
        ddlcountrysearch.Items.Insert(0, "All");
        ddlcountrysearch.SelectedIndex = 0;
        ddlstatesearch.Items.Insert(0, "All");
        ddlstatesearch.SelectedIndex = 0;
        ddlcitysearch.Items.Insert(0, "All");
        ddlcitysearch.SelectedIndex = 0;
        ddllocationsearch.Items.Insert(0, "All");
        ddllocationsearch.SelectedIndex = 0;
    }
    protected void ddlcountrysearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStateSearch();
    }
    protected void ddlstatesearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCitySearch();
    }
    protected void ddlcitysearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindLocationSearch();
    }
    private void BindStateSearch()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlcountrysearch.SelectedValue);
        BindDDL(ddlstatesearch, ds, "State_Name", "State_Code");
        ddlstatesearch.Items.Insert(0, "Select");
        ddlstatesearch.SelectedIndex = 0;
    }
    private void BindCitySearch()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlstatesearch.SelectedValue);
        BindDDL(ddlcitysearch, ds, "City_Name", "City_Code");
        ddlcitysearch.Items.Insert(0, "Select");
        ddlcitysearch.SelectedIndex = 0;
    }
    private void BindLocationSearch()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcitysearch.SelectedValue);
        BindDDL(ddllocationsearch, ds, "Location_Name", "Location_Code");
        ddllocationsearch.Items.Insert(0, "All");
        ddllocationsearch.SelectedIndex = 0;
    }

    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
        //ddlcompany.Items.Insert(0, "All")
        //ddlcompany.SelectedIndex = 1
        BindDivision();
        //ddldivision.Items.Insert(0, "All")
        //ddldivision.SelectedIndex = 0

        ddlzone.Items.Insert(0, "All");
        ddlzone.SelectedIndex = 0;

        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;

        ddlacademicyear.Items.Insert(0, "All");
        ddlacademicyear.SelectedIndex = 0;

        ddlstream.Items.Insert(0, "All");
        ddlstream.SelectedIndex = 0;
    }

    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDivision();
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
    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
        BindCenter();
    }

    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "All");
        ddlzone.SelectedIndex = 0;
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
        BindDDL(ddlacademicyear, ds, "AY_String", "AY_String");
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
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue);
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
        Zone = ddlzone.SelectedValue;
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
        if (chkpromoted.Checked == true)
        {
            Promoted = "1";
        }
        else
        {
            Promoted = "0";
        }

        Customer_Type = ddlcustomertypesearch.SelectedValue;
        Institutiontype = ddlinstitutionsearch.SelectedValue;
        Boardid = ddlboardsearch.SelectedValue;
        Standard = ddlstandardsearch.SelectedValue;
        Mobile = txthandphonesearch.Text;
        Country = ddlcountrysearch.SelectedValue;
        State = ddlstatesearch.SelectedValue;
        City = ddlcitysearch.SelectedValue;
        Location = ddllocationsearch.SelectedValue;
        Productcategory = ddlproductcategory.SelectedValue;
        Fromdate = txteventdatefrom.Text;
        Todate = txteventdateto.Text;
        OrderStatus = ddlorderstatus.SelectedValue;
        Sbentrycode = txtsbentrycode.Text;
        //If chkfollowup.Checked = True Then
        //    followup_overdue = 1
        //Else
        //    followup_overdue = 0
        //End If



        DataSet ds = AccountController.Get_Account_Search_Results(StudentName, Applicationno, Company, Division, Zone, Center, AcademicYear, Stream, UserID, Customer_Type,
        Institutiontype, Boardid, Standard, Mobile, Country, State, City, Location, Productcategory, Fromdate,
        Todate, OrderStatus, Sbentrycode, Active, Promoted);

        PagedDataSource Pds1 = new PagedDataSource();
        Pds1.DataSource = ds.Tables[0].DefaultView;
        Pds1.AllowPaging = true;
        Pds1.PageSize = 10;
        Pds1.CurrentPageIndex = Currentpage;
        lbl1.Text = "Showing " + (Currentpage + 1).ToString() + " of " + Pds1.PageCount.ToString();
        btnprevious.Enabled = !Pds1.IsFirstPage;
        Btnnext.Enabled = !Pds1.IsLastPage;

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Manage Account";
            lblpagetitle2.Text = "Search Results";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Account";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = " Account Search Results";
            //lilastbreadcrumb.Visible = True

            //lbltabname.Text = "Search Results"
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            divmessage.Visible = false;
            System.Threading.Thread.Sleep(1000);
            dlsearch.DataSource = Pds1;
            dlsearch.DataBind();
            script1.RegisterAsyncPostBackControl(dlsearch);
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            divmessage.Visible = true;
            lblmessage.Text = "No Records Found!";
        }
    }
    public int Currentpage
    {
        get
        {
            object s1 = this.ViewState["Currentpage"];
            if (s1 == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(s1);
            }
        }
        set { this.ViewState["Currentpage"] = value; }
    }

    protected void btnprevious_Click(object sender, System.EventArgs e)
    {
        Currentpage -= 1;
        BindSearch();
    }

    protected void Btnnext_Click(object sender, System.EventArgs e)
    {
        Currentpage += 1;
        BindSearch();
    }

    private void BindSearch()
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
        Company = lblusercompany.Text;
        //ddlcompany.SelectedValue
        Division = ddldivision.SelectedValue;
        Zone = ddlzone.SelectedValue;
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
        if (chkpromoted.Checked == true)
        {
            Promoted = "1";
        }
        else
        {
            Promoted = "0";
        }

        Customer_Type = ddlcustomertypesearch.SelectedValue;
        Institutiontype = ddlinstitutionsearch.SelectedValue;
        Boardid = ddlboardsearch.SelectedValue;
        Standard = ddlstandardsearch.SelectedValue;
        Mobile = txthandphonesearch.Text;
        Country = ddlcountrysearch.SelectedValue;
        State = ddlstatesearch.SelectedValue;
        City = ddlcitysearch.SelectedValue;
        Location = ddllocationsearch.SelectedValue;
        Productcategory = ddlproductcategory.SelectedValue;
        Fromdate = txteventdatefrom.Text;
        Todate = txteventdateto.Text;
        OrderStatus = ddlorderstatus.SelectedValue;
        Sbentrycode = txtsbentrycode.Text;
        //If chkfollowup.Checked = True Then
        //    followup_overdue = 1
        //Else
        //    followup_overdue = 0
        //End If



        DataSet ds = AccountController.Get_Account_Search_Results(StudentName, Applicationno, Company, Division, Zone, Center, AcademicYear, Stream, UserID, Customer_Type,
        Institutiontype, Boardid, Standard, Mobile, Country, State, City, Location, Productcategory, Fromdate,
        Todate, OrderStatus, Sbentrycode, Active, Promoted);


        PagedDataSource Pds1 = new PagedDataSource();
        Pds1.DataSource = ds.Tables[0].DefaultView;
        Pds1.AllowPaging = true;
        Pds1.PageSize = 10;
        Pds1.CurrentPageIndex = Currentpage;
        lbl1.Text = "Showing " + (Currentpage + 1).ToString() + " of " + Pds1.PageCount.ToString();
        btnprevious.Enabled = !Pds1.IsFirstPage;
        Btnnext.Enabled = !Pds1.IsLastPage;

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Manage Account";
            lblpagetitle2.Text = "Search";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Account";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = " Account Search Results";
            //lilastbreadcrumb.Visible = true;

            //lbltabname.Text = "Search Results"
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            divmessage.Visible = false;
            //System.Threading.Thread.Sleep(1000);
            dlsearch.DataSource = Pds1;
            dlsearch.DataBind();
            script1.RegisterAsyncPostBackControl(dlsearch);

        }
        else
        {
            //divsearchresults.Visible = False
            //divmessage.Visible = True
            //lblmessage.Text = "No Records Found!"
        }
    }


    protected void dlsearch_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Ledger")
        {
            System.Threading.Thread.Sleep(1000);
            upnlsearch.Visible = false;
            Upnlviewledger.Visible = true;
            lblpagetitle1.Text = "View Ledger";
            lblpagetitle2.Text = "";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Account";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = "View Ledger";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            //lbltabname1.Text = "Student Ledger"
            string Cur_Sb_Code = "";
            Cur_Sb_Code = e.CommandArgument.ToString();
            Session["CUR_SB_Code"] = e.CommandArgument.ToString();
            diverrorPayment.Visible = false;
            divSuccessPayment.Visible = false;
            //btnviewenrollment.Visible = true;
            Bindlist(Cur_Sb_Code);
            BindStudentSubjectGroup(Cur_Sb_Code);
            Bindpayment(Cur_Sb_Code);
            //BindPaymode()
            BindStudentLedger();
            BindChequeOutstanding();
            //BindPayhead()
            //Bindrequestdetails();
            diveditpayemnt.Visible = false;
            string oppid = txtopportunityid.Text;
            //HtmlAnchor viewenrollment = btnviewenrollment;
            //viewenrollment.HRef = "Enrollment_display.aspx?&Oppur_id=" + oppid;
            dlpaymentreceipt.Visible = true;
            divpayment.Visible = false;
            txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            tblbankdetails.Visible = false;
            tblcash.Visible = false;
            tblcheque.Visible = false;
            tblDD.Visible = false;
            //tr01.Visible = False
            //tr02.Visible = False
            //tr03.Visible = False
            //tr04.Visible = False
            //'tr05.Visible = False
            //tr01_1.Visible = False
            //tr01_2.Visible = False
            //'tr01_3.Visible = False
            //tr02_1.Visible = False
            //tr01_5.Visible = False
        }
        else if (e.CommandName == "Edit")
        {
            //diveditpayemnt.Visible = True
            //System.Threading.Thread.Sleep(100)
            //Dim Sbentrycode As String = e.CommandArgument.ToString
            //Dim Oppur_id As String = AccountController.GetOppidbysbentrycode(Sbentrycode)
            //Response.Redirect("Account_Edit.aspx?&Oppur_ID=" & Oppur_id)

        }
        else if (e.CommandName == "Promote")
        {
        }
    }

    protected void dlsearch_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (lblusercompany.Text == "MPUC")
            {
                ((LinkButton)e.Item.FindControl("lnkledger")).Enabled = true;
                ((LinkButton)e.Item.FindControl("lnkledger")).Visible = true;
                //DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = True
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;


                ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
                scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkledger"));
                //scriptManager__1.RegisterPostBackControl(DirectCast(e.Item.FindControl("lnkpromote"), LinkButton))
                string Status = ((Label)e.Item.FindControl("Label30")).Text;
                if (Status == "03")
                {
                    ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn default btn-xs red");
                    ((Label)e.Item.FindControl("Label3")).Attributes.Add("class", "btn default btn-xs red");
                    ((Label)e.Item.FindControl("Label3")).Text = "Pending";
                    //DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = False
                    ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                }
                else if (Status == "01")
                {
                    ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn default btn-xs green");
                    ((Label)e.Item.FindControl("Label3")).Attributes.Add("class", "btn default btn-xs green");
                    ((Label)e.Item.FindControl("Label3")).Text = "Confirmed";
                    string StudeStatus = ((Label)e.Item.FindControl("lblpromotedflag")).Text;
                    if (StudeStatus == "1")
                    {
                        // DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = False
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                        ((Label)e.Item.FindControl("Label6")).Attributes.Add("class", "btn default btn-xs purple");
                        ((Label)e.Item.FindControl("Label6")).Visible = false;
                        ((Label)e.Item.FindControl("Label6")).Text = "Promoted";
                        lblpromoteflag.Text = "1";
                    }
                    else
                    {
                        //DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = True
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                        //DirectCast(e.Item.FindControl("Label6"), Label).Attributes.Add("class", "btn default btn-xs red")
                        ((Label)e.Item.FindControl("Label6")).Visible = false;
                        //DirectCast(e.Item.FindControl("Label6"), Label).Text = "Not Promoted"
                        lblpromoteflag.Text = "0";
                    }

                }
            }
            else
            {
                ((LinkButton)e.Item.FindControl("lnkledger")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkledger")).Enabled = false;
                ((Label)e.Item.FindControl("Label3")).Visible = false;
                //DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = False
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;

            }

        }
    }

    private void Bindlist(string Cursbcode)
    {

        try
        {

            string Hiphen = "-";
            SqlDataReader dr = AccountController.GetAccountdetailbycursbcode(1, Cursbcode);
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    string Gender = dr["GENDER"].ToString();
                    //if (Gender == "M")
                    //{
                    //    txtgender.Text = "Male";
                    //}
                    //else
                    //{
                    //    txtgender.Text = "Female";
                    //}
                    txtadmndate.Text = dr["Admndate"].ToString();
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
                    ddllacadyear.SelectedValue = dr["Acad_Year"].ToString();
                    BindLedgerStream();
                    ddllstream.SelectedValue = dr["stream_code"].ToString();
                    txtpayplan.Text = dr["payplan"].ToString();
                    string Studentstatus = "";
                    Studentstatus = dr["Account_Status_id"].ToString();


                    //01-Pending
                    if (Studentstatus == "01")
                    {
                        listudentstatus.Visible = true;
                        //liregno.Visible = false;
                        lblstdstaus.Text = "Student Status : Pending";
                        //btnstatus.Attributes.Remove("Class");
                        //btnstatus.Attributes.Add("Class", "btn red");
                        btnproceedprint.Visible = false;


                        //txtDiscrequestdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                        //txtconcessionreqdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                        //BindDiscounttype()
                        //BindConcessiontype()

                    }
                    else if (Studentstatus == "03")
                    {
                        if (lblpromoteflag.Text == "1")
                        {
                            listudentstatus.Visible = true;
                            //liregno.Visible = false;
                            lblstdstaus.Text = "Student Status : Promoted";
                            btnaddpayment.Visible = false;


                        }
                        else
                        {
                            listudentstatus.Visible = true;
                            //liregno.Visible = false;
                            lblstdstaus.Text = "Student Status : Confirmed";
                            //btnstatus.Attributes.Remove("Class");
                            //btnstatus.Attributes.Add("Class", "btn green");

                            btnaddpayment.Visible = true;

                        }

                    }
                    else if (Studentstatus == "02")
                    {
                        listudentstatus.Visible = true;
                        //liregno.Visible = false;
                        lblstdstaus.Text = "Student Status : Cancelled";
                        //btnstatus.Attributes.Remove("Class");
                        //btnstatus.Attributes.Add("Class", "btn purple");
                        btnproceedprint.Visible = true;

                        btnaddpayment.Visible = false;

                    }
                }
            }
            txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
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

    private void BindPayhead()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPayheadbySBentrycode(Sbentrycode);
        BindDDL(ddlpayhead, ds, "Voucher_Description", "Pricing_Procedure_Code");
        ddlpayhead.Items.Insert(0, "Select");
        ddlpayhead.SelectedIndex = 0;
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
            dlpaymentreceipt.DataSource = ds;
            dlpaymentreceipt.DataBind();
            diverrorPayment.Visible = false;
            lblerrorPayment.Visible = false;
        }
        else
        {
            diverrorPayment.Visible = true;
            lblerrorPayment.Visible = true;
            lblerrorPayment.Text = "No Payment Records Found!";
        }
    }

    protected void dlpaymentreceipt_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            dlpaymentreceipt.Visible = false;
            string Receiptid = e.CommandArgument.ToString();
            lblreceiptidedit.Text = Receiptid;
            Bindpaymodeedit();
            BindPayeeedit();
            BindChequeallocationEdit();
            Bindpaymentdata();
            diveditpayemnt.Visible = true;
        }
        else if (e.CommandName == "Remove")
        {
            //lblnote.Text = "You are about to Remove a Receipt. Please confirm.";
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#Removereceipt').modal('show') });</script>", false);
            string Receiptid = e.CommandArgument.ToString();
            lblChequeidno1.Text = Receiptid;
            upnlRemoveCheque.Update();
            //lblChequeidno1.Text = e.CommandArgument.ToString();

            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDelete();", true);
        }
    }
    ///'''''''''''''''''Payment Management'''''''''''''''''''''''''''''''''''
    protected void dlpaymentreceipt_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
            scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkedit"));

            string Status = ((Label)e.Item.FindControl("lblchequestatus")).Text;
            if (Status == "Pending")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.IndianRed
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.DarkViolet;
                string Status1 = ((Label)e.Item.FindControl("lblLocation")).Text;
                string T005_Populate_Flag = ((Label)e.Item.FindControl("lblT005_Populate_Flag")).Text;
                if ((Status1 == "Center"))
                {
                    if (T005_Populate_Flag == "1")
                    {
                        ((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
                        ((Label)e.Item.FindControl("lblAction")).Visible = false;
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("lblAction")).Visible = true;
                        ((Label)e.Item.FindControl("lblAction")).ToolTip = "Record Already populated for SAP...!";
                    }
                }
                else
                {
                    ((Label)e.Item.FindControl("lblAction")).Visible = true;
                }
                //((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                //((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
            }
            else if (Status == "Deposited")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.RosyBrown
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.Blue;
                //((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
                ((Label)e.Item.FindControl("lblAction")).Visible = true;
            }
            else if (Status == "Cleared")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.Green
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.DarkCyan;
                //((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
                ((Label)e.Item.FindControl("lblAction")).Visible = true;
            }
            else if (Status == "Bounced")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.Red
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.Red;
                //((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
                ((Label)e.Item.FindControl("lblAction")).Visible = true;
            }
        }
       
    }
    protected void btncloseremoverpt_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#Removereceipt').modal('hide') });</script>", false);
    }
    protected void btnremovereceipt_ServerClick(object sender, System.EventArgs e)
    {

        try
        {

            DateTime  Paydate = DateTime.Today;
            decimal Amtinstr = 0;
            string Sbentrycode = "";
            string Paymode = "";
            string PayInsnum = "";
            DateTime  PayInsdate = DateTime.Today;
            string PayInsBankName = "";
            string InsStatus = "";
            string Inslocation = "";
            string InsDepositdate = "";
            DateTime  IDepositdate = DateTime.Today;
            DateTime  InsBRSDate = DateTime.Today;
            DateTime  IBRSdate = DateTime.Today;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string MicrCode = "";
            string PayHeadCode = "";
            string PayHeadDesc = "";
            DateTime  Payidate = DateTime.Today;
            DateTime  paydate1 = DateTime.Today;
            string Payeeid = "";
            string Chequeidno = lblchequeidno.Text;
            Sbentrycode = txtcursbcode.Text;
            string cardtype = "";
            string cardno = "";
            string Receiptid = AccountController.InsertPayment(4, Paydate.ToString("dd-Mmm-yyyy"), Amtinstr, Sbentrycode, Paymode, PayInsnum, Payidate.ToString("dd-Mmm-yyyy"), PayInsBankName, InsStatus, Inslocation,
            IDepositdate.ToString("dd-Mmm-yyyy"), IBRSdate.ToString("dd-Mmm-yyyy"), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Chequeidno,cardtype ,cardno );

            string Cur_sb_code = txtcursbcode.Text;
            Bindlist(Cur_sb_code);
            BindStudentSubjectGroup(Cur_sb_code);
            Bindpayment(Cur_sb_code);
            //BindPaymode()
            BindStudentLedger();
            BindChequeOutstanding();
            //BindPayhead()
            //Bindrequestdetails();
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;

        }
    }
    protected void btnaddpayment_ServerClick(object sender, System.EventArgs e)
    {

        try
        {

            dlpaymentreceipt.Visible = false;
            divpayment.Visible = true;
            txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtchequeamt.Text = "";
            txtchqno.Text = "";
            txtchqdate.Value = "";
            txtbankname.Text = "";
            txtddno.Text = "";
            txtdddate.Value = "";
            txtbankname.Text = "";
            txtbranchname.Text = "";
            txtmicrcode.Text = "";
            //NEFT
            txtNeft_UTRNo.Text = "";
            txtNeft_trandate.Value = "";
            txtNeftAmount.Text = "";
           // ddlpayee_Neft.SelectedIndex = 0;

            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblbankdetails.Visible = false;
            tblcash.Visible = false;
            tblccdc.Visible = false;
            tblNeft.Visible = false;
            diverrorPayment.Visible = false;
            lblerrorPayment.Visible = false;
            tr22.Visible = false;
            tr23.Visible = false;
            tr24.Visible = false;
            BindPaymode();
            BindPayee();
            BindChequeallocation();
            dlallocation.Visible = false ;
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void btnaddremarks_ServerClick(object sender, System.EventArgs e)
    {
            //lblnote.Text = "You are about to Remove a Receipt. Please confirm.";
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#Removereceipt').modal('show') });</script>", false);
            //lblChequeidno1.Text = e.CommandArgument.ToString();

        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAddremarks();", true);
        }

    protected void ddlpayhead_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //Dim Sbentrycode As String = ""
        //Dim PPgroup As String = ""

        //Sbentrycode = txtcursbcode.Text
        //PPgroup = ddlpayhead.SelectedValue
        //Dim dr As SqlDataReader = AccountController.Get_Feeheadvalue(Sbentrycode, PPgroup)
        //If (Not (dr) Is Nothing) Then
        //    If dr.Read Then
        //        txtpayheadfee.Text = dr("Feehead").ToString
        //        txtreceipt.Text = (dr("Receipt_Collected").ToString)
        //        txttobecollected.Text = dr("Amount_to_be_collected").ToString
        //        BindPaymode()
        //    End If
        //End If
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
            //System.Threading.Thread.Sleep(1000)
            dlallocation.DataSource = ds;
            dlallocation.DataBind();
            //diverrorPayment.Visible = False
            //lblerrorPayment.Visible = False
        }
        else
        {
            //diverrorPayment.Visible = True
            //lblerrorPayment.Visible = True
            //lblerrorPayment.Text = "No Payment Records Found!"
        }
    }
    private void BindPaymode()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = AccountController.GetallPaymode();
        BindDDL(ddlpaymode, ds, "Description", "id");
        ddlpaymode.Items.Insert(0, "Select");
        ddlpaymode.SelectedIndex = 0;
    }
    private void BindPayee()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Company = "";
        string Division = "";
        
        Company = ddllcompany.SelectedValue;
        Division = ddlldivision.SelectedValue;
        
        DataSet ds = AccountController.Getallpayeebycompanydivision(Company, Division);

        BindDDL(ddlpayee,    ds.Tables[0].DataSet , "Payee_Name", "payee_id");
        //ddlpayee.Items.Insert(0, "Select");
        ddlpayee.SelectedIndex = 0;

        BindDDL(ddlpayeedd, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
        //ddlpayeedd.Items.Insert(0, "Select");
        ddlpayeedd.SelectedIndex = 0;

        BindDDL(ddlpayeecash, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
        //ddlpayeecash.Items.Insert(0, "Select");
        ddlpayeecash.SelectedIndex = 0;

        BindDDL(ddlpayeetrans, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
        //ddlpayeetrans.Items.Insert(0, "Select");
        ddlpayeetrans.SelectedIndex = 0;

        BindDDL(ddlpayee_Neft, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
        //ddlpayee_Neft.Items.Insert(0, "Select");
        ddlpayee_Neft.SelectedIndex = 0;        

        if (ds.Tables[1].Rows.Count > 0 )
        {
            txtShowReceiptAllocation.Text = ds.Tables[1].Rows[0]["ShowReceiptAllocation"].ToString();         
        }
        
        //txtShowReceiptAllocation

    }
    protected void ddlpayee_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
        string payeeid = ddlpayee.SelectedValue;
        if (payeeid == "Select")
        {
            dlallocation.Visible = false;
        }
        else
        {
            BindChequeallocationbyPayee(payeeid);
        }

    }
    protected void ddlpayeedd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
        string payeeid = ddlpayeedd.SelectedValue;
        if (payeeid == "Select")
        {
            dlallocation.Visible = false;
        }
        else
        {
            BindChequeallocationbyPayee(payeeid);
        }
    }

    protected void ddlpayeecash_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
        string payeeid = ddlpayeecash.SelectedValue;
        if (payeeid == "Select")
        {
            dlallocation.Visible = false;
        }
        else
        {
            BindChequeallocationbyPayee(payeeid);
        }
    }
    private void BindChequeallocationbyPayee(string Payeeid)
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPPGroupbySBEntrycodeAndPayeeid(Sbentrycode, Payeeid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlallocation.DataSource = ds;
            dlallocation.DataBind();
            //diverrorPayment.Visible = False
            //lblerrorPayment.Visible = False
        }
        else
        {
            dlallocation.Visible = false;
            //diverrorPayment.Visible = True
            //lblerrorPayment.Visible = True
            //lblerrorPayment.Text = "No Allocation Assigned! Contact Administrator"
        }
    }
    protected void txtmicrcode_TextChanged(object sender, System.EventArgs e)
    {
        string MicrCode = "";
        MicrCode = txtmicrcode.Text;
        SqlDataReader dr = AccountController.GetBanknameandAddress(MicrCode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtbankname.Text = dr["bankname"].ToString();
                txtbranchname.Text = dr["bankbranch"].ToString();
            }
        }
    }
    protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlpaymentreceipt.Visible = false;
        divpayment.Visible = true;
        txtchequeamt.Text = "";
        txtchqno.Text = "";
        txtchqdate.Value = "";
        txtbankname.Text = "";
        txtddno.Text = "";
        txtdddate.Value = "";
        txtbankname.Text = "";
        txtbranchname.Text = "";
        txtmicrcode.Text = "";
        //NEFT
        txtNeft_UTRNo.Text = "";
        txtNeft_trandate.Value = "";
        txtNeftAmount.Text = "";
       

        if (ddlpaymode.SelectedValue == "01")
        {
            tblcheque.Visible = true;
            tblDD.Visible = false;
            tblbankdetails.Visible = true;
            tblcash.Visible = false;
            tblccdc.Visible = false;
            tblNeft.Visible = false;
            tr22.Visible = true;
            tr23.Visible = false;
            tr24.Visible = false;

        }
        else if (ddlpaymode.SelectedValue == "02")
        {
            tblcheque.Visible = false;
            tblDD.Visible = true;
            tblbankdetails.Visible = true;
            tblcash.Visible = false;
            tblccdc.Visible = false;
            tblNeft.Visible = false;
            tr22.Visible = false;
            tr23.Visible = true;
            tr24.Visible = false;
        }
        else if (ddlpaymode.SelectedValue == "03")
        {
            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblbankdetails.Visible = false;
            tblcash.Visible = true;
            tblccdc.Visible = false;
            tblNeft.Visible = false;
            tr22.Visible = false;
            tr23.Visible = false;
            tr24.Visible = true;
        }
        else if (ddlpaymode.SelectedValue == "04")
        {
            BindCardtype();
            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblbankdetails.Visible = false;
            tblcash.Visible = false ;
            tblccdc.Visible = true;
            tblNeft.Visible = false;
            tr22.Visible = false;
            tr23.Visible = false;
            tr24.Visible = false ;
        }
        else if (ddlpaymode.SelectedValue == "05")//Neft
        {
            BindCardtype();
            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblbankdetails.Visible = false;
            tblcash.Visible = false;
            tblccdc.Visible = false;
            tblNeft.Visible = true;

        }

        if (txtShowReceiptAllocation.Text == "1")
        {
            tblAllocationAdd.Visible = true;
        }
        else
        {
            tblAllocationAdd.Visible = false;
        }
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#basic').modal('show') });</script>", False)
    }
    private void BindCardtype()
    {
        DataSet ds = ProductController.GetallCardtype();
        BindDDL(ddlcardtype , ds, "Card_Type_Name", "Card_Type_Code");
        ddlcardtype.Items.Insert(0, "Select");
        ddlcardtype.SelectedIndex = 0;
    }

    private void GetSumvalue()
    {

        try
        {

            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            TextBox lblsid = default(TextBox);
            int Sum = 0;
            int Count = 0;
            if (ddlpaymode.SelectedValue == "01")
            {
                foreach (DataListItem li in dlallocation.Items)
                {
                    obj = li.FindControl("chk1");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }

                    obj = li.FindControl("txtcurrentallocation");
                    if (obj != null)
                    {
                        lblsid = (TextBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        //li.FindControl("txtcurrentallocation")
                        if (string.IsNullOrEmpty(lblsid.Text))
                        {
                        }
                        else
                        {
                            Sum = Sum + Convert.ToInt32(lblsid.Text);
                            txtslipamt.Text = Sum.ToString();
                        }
                        lblsid.Enabled = true;
                    }
                    else
                    {
                        lblsid.Enabled = false;
                        lblsid.Text = "";
                        //txtslipamt.Text = "0"
                    }
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    private void GetSumvaluedd()
    {
        try
        {
            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            TextBox lblsid = default(TextBox);
            int Sum = 0;
            int Count = 0;
            if (ddlpaymode.SelectedValue == "02")
            {
                foreach (DataListItem li in dlallocation.Items)
                {
                    obj = li.FindControl("chk1");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }

                    obj = li.FindControl("txtcurrentallocation");
                    if (obj != null)
                    {
                        lblsid = (TextBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        //li.FindControl("txtcurrentallocation")
                        if (string.IsNullOrEmpty(lblsid.Text))
                        {
                        }
                        else
                        {
                            Sum = Sum + Convert.ToInt32(lblsid.Text);
                            txtddalloca.Text = Sum.ToString();
                        }
                        lblsid.Enabled = true;
                    }
                    else
                    {
                        lblsid.Enabled = false;
                        lblsid.Text = "";
                        // txtddalloca.Text = "0"
                    }
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    private void GetSumvaluecash()
    {

        try
        {

            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            TextBox lblsid = default(TextBox);
            int Sum = 0;
            int Count = 0;
            if (ddlpaymode.SelectedValue == "03")
            {
                foreach (DataListItem li in dlallocation.Items)
                {
                    obj = li.FindControl("chk1");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }

                    obj = li.FindControl("txtcurrentallocation");
                    if (obj != null)
                    {
                        lblsid = (TextBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        //li.FindControl("txtcurrentallocation")
                        if (string.IsNullOrEmpty(lblsid.Text))
                        {
                        }
                        else
                        {
                            Sum = Sum + Convert.ToInt32(lblsid.Text);
                            txtcashalloca.Text = Sum.ToString();
                        }
                        lblsid.Enabled = true;
                    }
                    else
                    {
                        lblsid.Enabled = false;
                        lblsid.Text = "";
                        //txtcashalloca.Text = ""
                    }
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void btnsavepayment_ServerClick(object sender, System.EventArgs e)
    
    {

        try
        {
            

            

            object obj11 = null;
            object obj12 = null;
            CheckBox Chk11 = default(CheckBox);
            Label lblselecteditem = default(Label);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            string Sgrcode = "";
            CheckBox cb1 = default(CheckBox);
            foreach (DataListItem li in dlallocation.Items)
            {
                obj11 = li.FindControl("lblproductheader");
                if (obj11 != null)
                {
                    lblselecteditem = (Label)obj11;
                }

                obj12 = li.FindControl("chk1");
                if (obj12 != null)
                {
                    Chk11 = (CheckBox)obj12;
                }

                if (Chk11.Checked == true)
                {
                    list.Add(lblselecteditem.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
                else
                {
                }
            }
            if ((Sgrcode.Length > 0 && txtShowReceiptAllocation.Text == "1") ||  (txtShowReceiptAllocation.Text != "1") )
            {
                String Paydate = "";
                decimal Amtinstr = 0;
                string Sbentrycode = "";
                string Paymode = "";
                string PayInsnum = "";
                string PayInsdate ="";
                string PayInsBankName = "";
                string InsStatus = "";
                string Inslocation = "";
                DateTime InsDepositdate = default(DateTime);
                DateTime IDepositdate = default(DateTime);
                DateTime InsBRSDate = default(DateTime);
                DateTime IBRSdate = default(DateTime);
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                string MicrCode = "";
                string PayHeadCode = "";
                string PayHeadDesc = "";
                String Payidate = "";
                string cardtype = "";
                string cardno = "";
                DateTime paydate1 = default(DateTime);
                paydate1 = DateTime.Today;
                Paydate = Convert.ToString(paydate1);
                InsDepositdate = DateTime.Today;
                InsBRSDate = DateTime.Today;
                Sbentrycode = txtcursbcode.Text;
                string Payeeid = "";
                Paymode = ddlpaymode.SelectedValue;
                if (ddlpaymode.SelectedValue == "01")
                {
                    if (txtchqdate.Value == "")
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Enter Cheque Date";
                        return;
                    }
                    Amtinstr = Convert.ToDecimal(txtchequeamt.Text);
                    PayInsnum = txtchqno.Text;
                    PayInsdate = txtchqdate.Value;
                    Payidate = txtchqdate.Value;
                    PayInsBankName = txtbankname.Text;
                    InsStatus = "01";
                    Inslocation = "01";     //center
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = txtmicrcode.Text;
                    Payeeid = ddlpayee.SelectedValue;
                }
                else if (ddlpaymode.SelectedValue == "02")
                {
                    if (txtdddate.Value == "")
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Enter DD Date";
                        return;
                    }
                    Amtinstr = Convert.ToDecimal(txtddamt.Text);
                    PayInsnum = txtddno.Text;
                    PayInsdate = txtdddate.Value;
                    Payidate = txtdddate.Value;
                    PayInsBankName = txtbankname.Text;
                    InsStatus = "01";
                    Inslocation = "01"; //Center
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = txtmicrcode.Text;
                    Payeeid = ddlpayeedd.SelectedValue;
                }
                else if (ddlpaymode.SelectedValue == "03")
                {
                    Amtinstr = Convert.ToDecimal(txtcashamt.Text);
                    PayInsnum = "";
                    PayInsdate = Convert.ToString (DateTime.Today);
                    PayInsBankName = "";
                    InsStatus = "03";
                    Inslocation = "05"; //NA
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = txtmicrcode.Text;
                    Payeeid = ddlpayeecash.SelectedValue;
                }
                if (ddlpaymode.SelectedValue == "04")
                {
                    if (txttrandate.Value == "")
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Enter Transaction Date";
                        return;
                    }

                    //Check if CCDC date is greater than last cheque date allowed for the stream
                    string VerifyCCDCStr = "";
                    //string paydate = 
                    VerifyCCDCStr = AccountController.Verify_CCDCEntry(txttrandate.Value);

                    if (VerifyCCDCStr != "Success")
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = VerifyCCDCStr;
                        return;
                    }

              
                    
                    Amtinstr = Convert.ToDecimal(txttransamt.Text);
                    PayInsnum = txttransid.Text;
                    PayInsdate = txttrandate.Value;
                    Payidate = txttrandate.Value;
                    PayInsBankName = txtcardholder.Text;
                    InsStatus = "01";
                    Inslocation = "01";     //NA
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = txtmicrcode.Text;
                    Payeeid = ddlpayeetrans.SelectedValue;
                    cardtype = ddlcardtype.SelectedValue;
                    cardno = txtlast4digit.Text;
                }
                if (ddlpaymode.SelectedValue == "05")//Neft
                {
                    if (txtNeft_trandate.Value == "")
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Enter Date";
                        return;
                    }
                    Amtinstr = Convert.ToDecimal(txtNeftAmount.Text);
                    PayInsnum = txtNeft_UTRNo.Text;
                    PayInsdate = txtNeft_trandate.Value;
                    Payidate = txtNeft_trandate.Value;
                    PayInsBankName = "";
                    InsStatus = "01";
                    Inslocation = "01";     //NA
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = "";
                    Payeeid = ddlpayee_Neft.SelectedValue;
                    cardtype = "";
                    cardno = "";
                }

                //Check if cheque date is greater than last cheque date allowed for the stream
                string VerifyChequeStr ="";
                //string paydate = 
                VerifyChequeStr = AccountController.Verify_ChequeEntry(Sbentrycode, Amtinstr,Payidate.ToString() , 1);
  
                if (VerifyChequeStr != "Success")
                {
                    divErrormessage.Visible = true;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = VerifyChequeStr;
                    return;
                }


                //Check if this is first payment entry and if yes then
                //check is amount is greater than CRF + Robomate or not
                //PayInsdate


                string Receiptcode = "";
                string Receiptid = AccountController.InsertPayment(2, Paydate.ToString(), Amtinstr, Sbentrycode, Paymode, PayInsnum, Payidate.ToString(), PayInsBankName, InsStatus, Inslocation,
                    IDepositdate.ToString(), IBRSdate.ToString(), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Receiptcode, cardtype ,cardno);
                
                lblreceiptid.Text = Receiptid;
                Insertallocation();

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
                    string Output1 = AccountController.InsertP19(Sbentrycode);
                    string Output = AccountController.Confirmadmission(Sbentrycode);
                    
                }
                else if (lblstdstaus.Text == "Student Status : Confirmed")
                {
                    badgeError.Visible = false;
                    badgeSuccess.Visible = true;
                    string Output = AccountController.InsertE19(Sbentrycode);
                    
                }
                else if (lblstdstaus.Text == "Student Status : Pending")
                {
                    badgeError.Visible = true;
                    badgeSuccess.Visible = false;
                    string Output = AccountController.InsertP19(Sbentrycode);
                   
                }
                else if (lblstdstaus.Text == "Student Status : Cancelled")
                {
                    badgeError.Visible = false;
                    badgeSuccess.Visible = false;
                    Span1.Visible = true;
                    
                }

                txtpaydate.Text = "";
                //txtchequeamt.Text = "";
                //ddlpaymode.SelectedIndex = 0;  changes on 15-07-2019
                //txtchqno.Text = "";
                txtchqdate.Value = "";
                //txtbankname.Text = "";
                //txtddno.Text = "";
                //txtddamt.Text = "";
                txtdddate.Value = "";
                //txtbankname.Text = "";
                //txtbranchname.Text = "";
                //txtmicrcode.Text = "";
                //txtcashamt.Text = "";
                Bindpayment(Sbentrycode);
                BindStudentLedger();
                BindChequeOutstanding();
                Bindlist(Sbentrycode);
                //ddlpayhead.SelectedIndex = 0
                dlpaymentreceipt.Visible = true;
                divpayment.Visible = false;
                dynamic Cur_Sb_Code = "";
                txtslipamt.Text = "";
                txtddalloca.Text = "";
                txtcashalloca.Text = "";
                Bindpayment(Cur_Sb_Code);
                divErrormessage.Visible = false;
                //string message = "Record Saved Successfully";
                //System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
                //sb1.Append("<script type = 'text/javascript'>");
                //sb1.Append("window.onload=function(){");
                //sb1.Append("alert('");
                //sb1.Append(message);
                //sb1.Append("')};");
                //sb1.Append("</script>");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());


                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAddpayemtnewclick();", true);

            
              
                //
            }
            else
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Atleast One Product Header should be Selected.";
            }
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    private void Insertallocation()
    {

        try
        {

            object obj = null;
            CheckBox Chk = default(CheckBox);
            CheckBox cb = default(CheckBox);
            TextBox txtcurrentallocation = default(TextBox);
            Label lblproductheadercode = default(Label);
            TextBox Txtamt = default(TextBox);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            int Flag = 1;
            lblproductheadercode = null;
            txtcurrentallocation = null;
            Txtamt = null;
            string receiptid = "";
            receiptid = lblreceiptid.Text;

            string Paymode = "";
            Paymode = ddlpaymode.SelectedValue;
            if (txtShowReceiptAllocation.Text == "1")
            {
            


            if (ddlpaymode.SelectedValue == "01")
            {
                string PPcode = "";
                string amt = "";
                string Chqno = txtchqno.Text;
                string sbentrycode = txtcursbcode.Text;
                string Payeeid = "";
                try
                {
                    foreach (DataListItem li in dlallocation.Items)
                    {
                        obj = li.FindControl("chk1");
                        if (obj != null)
                        {
                            Chk = (CheckBox)obj;
                        }
                        obj = li.FindControl("lblproductheadercode");
                        if (obj != null)
                        {
                            lblproductheadercode = (Label)obj;
                        }
                        obj = li.FindControl("txtcurrentallocation");
                        if (obj != null)
                        {
                            Txtamt = (TextBox)obj;
                        }
                        if (Chk.Checked == true)
                        {
                            Payeeid = ddlpayee.SelectedValue;
                            ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                        }
                        else
                        {
                            Txtamt.Text = "0";
                            Payeeid = ddlpayee.SelectedValue;
                            ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                        }
                    }


                }
                catch (Exception ex)
                {
                }
            }
            else if (ddlpaymode.SelectedValue == "02")
            {
                string PPcode = "";
                string amt = "";
                string Chqno = txtddno.Text;
                string sbentrycode = txtcursbcode.Text;
                string Payeeid = "";
                try
                {
                    foreach (DataListItem li in dlallocation.Items)
                    {
                        obj = li.FindControl("chk1");
                        if (obj != null)
                        {
                            Chk = (CheckBox)cb;
                        }
                        obj = li.FindControl("lblproductheadercode");
                        if (obj != null)
                        {
                            lblproductheadercode = (Label)obj;
                        }
                        obj = li.FindControl("txtcurrentallocation");
                        if (obj != null)
                        {
                            Txtamt = (TextBox)obj;
                        }
                        if (Chk.Checked == true)
                        {
                            Payeeid = ddlpayeedd.SelectedValue;
                            ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                        }
                        else
                        {
                            Txtamt.Text = "0";
                            Payeeid = ddlpayeedd.SelectedValue;
                            ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                        }
                    }


                }
                catch (Exception ex)
                {
                }
            }
            else if (ddlpaymode.SelectedValue == "03")
            {
                string PPcode = "";
                string amt = "";
                string Chqno = "";
                string sbentrycode = txtcursbcode.Text;
                string Payeeid = ddlpayeecash.SelectedValue;
                try
                {
                    foreach (DataListItem li in dlallocation.Items)
                    {
                        obj = li.FindControl("chk1");
                        if (obj != null)
                        {
                            Chk = (CheckBox)cb;
                        }
                        obj = li.FindControl("lblproductheadercode");
                        if (obj != null)
                        {
                            lblproductheadercode = (Label)obj;
                        }
                        obj = li.FindControl("txtcurrentallocation");
                        if (obj != null)
                        {
                            Txtamt = (TextBox)obj;
                        }
                        if (Chk.Checked == true)
                        {
                            Payeeid = ddlpayeecash.SelectedValue;
                            ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                        }
                        else
                        {
                            Txtamt.Text = "0";
                            Payeeid = ddlpayeecash.SelectedValue;
                            ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                        }
                    }


                }
                catch (Exception ex)
                {
                }
            }

        }
        else // allocation Not required
        {
            string Chqno ="";
            string amt = "";
            string PPCode = "PP011"; //temporarily put
            string sbentrycode = txtcursbcode.Text;
            string Payeeid = "";

            if (ddlpaymode.SelectedValue == "03")
            {
                Chqno = "";
                amt = txtcashamt.Text;
                Payeeid = ddlpayeecash.SelectedItem.Value; 
            }
            else if (ddlpaymode.SelectedValue == "02")
            {
                Chqno = txtddno.Text;
                amt = txtddamt.Text;
                Payeeid = ddlpayeedd.SelectedItem.Value;
            }
            else if (ddlpaymode.SelectedValue == "01")
            {
                Chqno = txtchqno.Text;
                amt = txtchequeamt.Text;
                Payeeid = ddlpayee.SelectedItem.Value;
            }
            else if (ddlpaymode.SelectedValue == "04")
            {
                Chqno = txttransid.Text;
                amt = txttransamt.Text;
                Payeeid = ddlpayeetrans.SelectedItem.Value;
            }
            else if (ddlpaymode.SelectedValue == "05")//Neft
            {
                Chqno = txtNeft_UTRNo.Text;
                amt = txtNeftAmount.Text;
                Payeeid = ddlpayee_Neft.SelectedItem.Value;
            }
           
            ProductController.Insertchequeallocation(PPCode, amt, sbentrycode, Chqno, 1, Payeeid, receiptid);

        }

            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }


    }
    protected void btnclosepayment_ServerClick(object sender, System.EventArgs e)
    {
        dlpaymentreceipt.Visible = true;
        divpayment.Visible = false;
        txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        txtchequeamt.Text = "";
        txtchqno.Text = "";
        txtchqdate.Value = "";
        txtbankname.Text = "";
        txtddno.Text = "";
        txtdddate.Value = "";
        txtbankname.Text = "";
        txtbranchname.Text = "";
        txtmicrcode.Text = "";
        txtslipamt.Text = "0";
        txtddalloca.Text = "0";
        txtcashalloca.Text = "0";
        tblcheque.Visible = false;
        tblDD.Visible = false;
        tblbankdetails.Visible = false;
        tblcash.Visible = false;
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

        try
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
                        //tr29.Visible = True
                        //tr30.Visible = False
                        //tr31.Visible = False
                        txtchqdateedit.Text = dr["Pay_InstrDate"].ToString();
                        txtchqnoedit.Text = dr["Pay_InsNum"].ToString();
                        txtchequeamtedit.Text = dr["Instr_Amt"].ToString();
                        ddlpayeeedit.Text = dr["payee_id"].ToString();
                        //ddlpayeeedit.Text = dr("").ToString

                    }
                    else if (ddlpaymodeedit.SelectedValue == "02")
                    {
                        tblchequeedit.Visible = false;
                        tblddedit.Visible = true;
                        tblbankdetailsedit.Visible = true;
                        tblcashedit.Visible = false;
                        //tr29.Visible = False
                        //tr30.Visible = True
                        //tr31.Visible = False
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
                        //tblcashedit.Visible = True
                        //tr29.Visible = False
                        //tr30.Visible = False
                        //tr31.Visible = True
                        txtcashamtedit.Text = dr["Instr_Amt"].ToString();
                        ddlpayeecashedit.Text = dr["payee_id"].ToString();
                    }

                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
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

            
            
            //tr29.Visible = True
            //tr30.Visible = False
            //tr31.Visible = False
            //txtchqdateedit.Text = dr("Pay_InstrDate").ToString
            //txtchqnoedit.Text = dr("Pay_InsNum").ToString
            //txtchequeamtedit.Text = dr("Instr_Amt").ToString
            //'ddlpayeeedit.Text = dr("").ToString

        }
        else if (ddlpaymodeedit.SelectedValue == "02")
        {
            tblchequeedit.Visible = false;
            tblddedit.Visible = true;
            tblbankdetailsedit.Visible = true;
            tblcashedit.Visible = false;
            //tr29.Visible = False
            //tr30.Visible = True
            //tr31.Visible = False
            //txtdddateedit.Text = dr("Pay_InstrDate").ToString
            //txtddnoedit.Text = dr("Pay_InsNum").ToString
            //txtddamtedit.Text = dr("Instr_Amt").ToString


        }
        else if (ddlpaymodeedit.SelectedValue == "03")
        {
            tblchequeedit.Visible = false;
            tblddedit.Visible = false;
            tblbankdetailsedit.Visible = false;
            tblcashedit.Visible = true;
            //tr29.Visible = False
            //tr30.Visible = False
            //tr31.Visible = True
            //txtcashamtedit.Text = dr("Instr_Amt").ToString
        }

        if (txtShowReceiptAllocation.Text == "1")
        {
            tblallocation.Visible = true;
        }
        else
        {
            tblallocation.Visible = false;
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
        //diverrorPaymentedit.Visible = False
        //lblerrorPayment.Visible = False
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
        Paymode = ddlpaymodeedit.SelectedValue;
        string cardtype = "";
        string cardno = "";
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
        IDepositdate.ToString("dd-Mmm-yyyy"), IBRSdate.ToString("dd-Mmm-yyyy"), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Receiptcode,cardtype ,cardno );
        //Bindpayment(Sbentrycode)
        BindStudentLedger();
        BindChequeOutstanding();
        Bindlist(Sbentrycode);
        //ddlpayhead.SelectedIndex = 0
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
            //System.Threading.Thread.Sleep(1000)
            dlstudentledger.DataSource = ds;
            dlstudentledger.DataBind();

        }
        else
        {
        }
    }

    private void BindChequeOutstanding()
    {
	    string Sbentrycode = "";
	    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
	    string UserID = cookie.Values["UserID"];
	    string UserName = cookie.Values["UserName"];
	    Sbentrycode = txtcursbcode.Text;

	    SqlDataReader dr = AccountController.GetChequeOutstanding(Sbentrycode);
	    if ((((dr) != null))) {
		    if (dr.Read()) {
			    txtcurrentout.Text = dr["outstanding"].ToString();
		    }
	    }
	    if (lblstdstaus.Text == "Student Status : Pending" && Convert.ToInt32(txtcurrentout.Text) <= 0) {
            badgeError.Visible = true ;
            badgeSuccess.Visible = false ;
            Span1.Visible = false;
		    string Output = AccountController.Confirmadmission(Sbentrycode);
            LMS_UserDetails.OE_UserDetailsSoap Client = new LMS_UserDetails.OE_UserDetailsSoapClient();
            DataSet dsdetails = ProductController.LMS_PassAllStudentdetailstoLMSApponConfirmation(Sbentrycode);
            //Client.UpdUserInformationDetails(dsdetails, "1");
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
        else if (lblstdstaus.Text == "Student Status : Pending" && Convert.ToInt32(txtcurrentout.Text) == 0) 
        {
            badgeError.Visible = false;
            badgeSuccess.Visible = true;
            Span1.Visible = false;
        }
        else if (lblstdstaus.Text == "Student Status : Confirmed") {
            badgeError.Visible = false;
            badgeSuccess.Visible =true;
            Span1.Visible = false;
		    //goto Rowexit;
        }
        else if (lblstdstaus.Text == "Student Status : Cancelled")
        {
            badgeError.Visible = false;
            badgeSuccess.Visible = false;
            Span1.Visible = true;

        }
        else if (lblstdstaus.Text == "Student Status : Pending")
        {
            badgeError.Visible = true;
            badgeSuccess.Visible = false;
            Span1.Visible = false;

        }
        
    }




    

    
    public string encryptQueryString(string strQueryString)
    {
        Encryption_Decryption oEs1 = new Encryption_Decryption();
        string EncriptStr = oEs1.EncryptString128Bit(strQueryString, "!#$a54?3");
        return EncriptStr;
    }





    protected void btn_DeleteYes_Click(object sender, EventArgs e)
    {
        try
        {
            string UserID = "";

            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                UserID = cookie.Values["UserID"];
            }
            int ResultId = 0;
            ResultId = ProductController.DeleteCheque(lblChequeidno1.Text, txtcursbcode.Text, UserID, "1");
            if (ResultId == 1)
            {
                SqlDataReader dr = AccountController.GetChequeOutstanding(txtcursbcode.Text);
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
                    string Output1 = AccountController.InsertP20(txtcursbcode.Text);            

                }
                else if (lblstdstaus.Text == "Student Status : Confirmed")
                {
                    badgeError.Visible = false;
                    badgeSuccess.Visible = true;
                    string Output = AccountController.InsertE20(txtcursbcode.Text);

                }
                else if (lblstdstaus.Text == "Student Status : Pending")
                {
                    badgeError.Visible = true;
                    badgeSuccess.Visible = false;
                    string Output = AccountController.InsertP20(txtcursbcode.Text);

                }
                //else if (lblstdstaus.Text == "Student Status : Cancelled")
                //{
                //    badgeError.Visible = false;
                //    badgeSuccess.Visible = false;
                //    Span1.Visible = true;
                //}


                Bindpayment(txtcursbcode.Text);
                divErrormessage.Visible = false;
                divSuccessmessage.Visible = false;
                lblerrormessage.Text = "";
            }
            else
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Cheque Not Delete...!";
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

    protected void btn_saveYes_Click(object sender, EventArgs e)
    {

        if (txtpendingremarks.Text == "")
        {
            lblpendingremarks.Visible = true;
            lblpendingremarks.ForeColor = System.Drawing.Color.Red;
            lblpendingremarks.Text = "Remarks Can't be Blank";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalAddremarks();", true);
            return;
        }
        
        string UserID = "";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                UserID = cookie.Values["UserID"];
            }
            int ResultId = 0;
            ResultId = ProductController.DeleteCheque(txtpendingremarks.Text, txtcursbcode.Text, UserID, "2");
            if (ResultId == 1)
            {
                BindStudentpendingresaon();
                //lblpendingremarks.Visible = true;
                //lblpendingremarks.Text = "Remarks Can't be Blank";
            }
            else
            {
                
            }

      
    }

    private void BindStudentpendingresaon()
    {
        string Sbentrycode = "";
         Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.Getstudentpendingreasonbysbentrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblremarksupdated.ForeColor = System.Drawing.Color.Red;
            lblremarksupdated.Text = (ds.Tables[0].Rows[0]["Remarks"].ToString());
           

        }
        else
        {
        }
    }

    protected void btn_AddpaymnetnYes_Click(object sender, EventArgs e)
    {
       // added on 15-07-2019

            dlpaymentreceipt.Visible = false;
            divpayment.Visible = true;
            txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //txtchequeamt.Text = "";
            //txtchqno.Text = "";
            txtchqdate.Value = "";
            //txtbankname.Text = "";
            //txtddno.Text = "";
            txtdddate.Value = "";
            //txtbankname.Text = "";
            //txtbranchname.Text = "";
            //txtmicrcode.Text = "";
            //NEFT
            //txtNeft_UTRNo.Text = "";
            txtNeft_trandate.Value = "";
            //txtNeftAmount.Text = "";
            // ddlpayee_Neft.SelectedIndex = 0;

            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblbankdetails.Visible = false;
            tblcash.Visible = false;
            tblccdc.Visible = false;
            tblNeft.Visible = false;
            diverrorPayment.Visible = false;
            lblerrorPayment.Visible = false;
            tr22.Visible = false;
            tr23.Visible = false;
            tr24.Visible = false;
            //BindPaymode();
            BindPayee();
            BindChequeallocation();
            dlallocation.Visible = false;
            divErrormessage.Visible = false;

            if (ddlpaymode.SelectedValue == "01")
            {
                tblcheque.Visible = true;
                tblDD.Visible = false;
                tblbankdetails.Visible = true;
                tblcash.Visible = false;
                tblccdc.Visible = false;
                tblNeft.Visible = false;
                tr22.Visible = true;
                tr23.Visible = false;
                tr24.Visible = false;

            }
            else if (ddlpaymode.SelectedValue == "02")
            {
                tblcheque.Visible = false;
                tblDD.Visible = true;
                tblbankdetails.Visible = true;
                tblcash.Visible = false;
                tblccdc.Visible = false;
                tblNeft.Visible = false;
                tr22.Visible = false;
                tr23.Visible = true;
                tr24.Visible = false;
            }
            else if (ddlpaymode.SelectedValue == "03")
            {
                tblcheque.Visible = false;
                tblDD.Visible = false;
                tblbankdetails.Visible = false;
                tblcash.Visible = true;
                tblccdc.Visible = false;
                tblNeft.Visible = false;
                tr22.Visible = false;
                tr23.Visible = false;
                tr24.Visible = true;
            }
            else if (ddlpaymode.SelectedValue == "04")
            {
                BindCardtype();
                tblcheque.Visible = false;
                tblDD.Visible = false;
                tblbankdetails.Visible = false;
                tblcash.Visible = false;
                tblccdc.Visible = true;
                tblNeft.Visible = false;
                tr22.Visible = false;
                tr23.Visible = false;
                tr24.Visible = false;
            }
            else if (ddlpaymode.SelectedValue == "05")//Neft
            {
                BindCardtype();
                tblcheque.Visible = false;
                tblDD.Visible = false;
                tblbankdetails.Visible = false;
                tblcash.Visible = false;
                tblccdc.Visible = false;
                tblNeft.Visible = true;

            }

            if (txtShowReceiptAllocation.Text == "1")
            {
                tblAllocationAdd.Visible = true;
            }
            else
            {
                tblAllocationAdd.Visible = false;
            }
   
    }

}