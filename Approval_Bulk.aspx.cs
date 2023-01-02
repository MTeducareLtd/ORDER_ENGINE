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

public partial class Approval_Bulk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Menuid = "119";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            lblpagetitle1.Text = "Approval";
            lblpagetitle2.Text = "Search Results";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Approval";
            lilastbreadcrumb.Visible = false;
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            //lbltabname.Text = "Search by"
            btnback.Visible = false;
            upnlsearch.Visible = true;
            //Upnlviewledger.Visible = false;
            //System.Threading.Thread.Sleep(4000);
            script1.RegisterAsyncPostBackControl(btnback);
            listudentstatus.Visible = false;
           
            divmessage.Visible = false;
            divSearch.Visible = true;
            divsearchresults.Visible = false;

            BindRequestType();
            BindCompany();
            ddldivision.Items.Insert(0, "All");
            ddldivision.SelectedIndex = 0;
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;
            ddlacademicyear.Items.Insert(0, "All");
            ddlacademicyear.SelectedIndex = 0;
            ddlstreamname.Items.Insert(0, "All");
            ddlstreamname.SelectedIndex = 0;
            
        }
        GetSumvalue();
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        //Upnlviewledger.Visible = false;
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
        //div11.Visible = true;
        //divlevel1New.Visible = true;
        //divlevel2New.Visible = true;
        //divlevel3New.Visible = true;
        //centerrequest.Visible = true;
        btnsearch_ServerClick(sender, e);

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

            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;

            divsearchresults.Visible = true;
            divmessage.Visible = false;
           
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
           
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            divmessage.Visible = true;
            lblmessage.Text = "No Records Found!";
        }
    }

    private void GetSumvalue()
    {

        try
        {

            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            Label lblsid = default(Label);
            Label lblbaseuomid = default(Label);
            Label lblselgroup = default(Label);
            Label lblvouchermode = default(Label);
            RequiredFieldValidator regularvalidator = default(RequiredFieldValidator);
            RequiredFieldValidator r2 = default(RequiredFieldValidator);
            CompareValidator C1 = default(CompareValidator);
            TextBox lblquantity = default(TextBox);
            TextBox lblvoucheramt = default(TextBox);
            TextBox lblremarks = default(TextBox);
            TextBox lblamt = default(TextBox);
            TextBox txttotal = default(TextBox);
            DropDownList ddluom1 = default(DropDownList);
            string Totalvalue = "";
            int Sum = 0;
            int Count = 0;
            //Dim Quant As TextBox

            foreach (RepeaterItem  li in Repeater1.Items)
            {
                obj = li.FindControl("checkpoint");
                if (obj != null)
                {
                    chk = (CheckBox)obj;
                }

                obj = li.FindControl("txtamountapp");
                if (obj != null)
                {
                    lblvoucheramt = (TextBox)obj;
                }

                obj = li.FindControl("txtappremark");
                if (obj != null)
                {
                    lblremarks  = (TextBox)obj;
                }

                obj = li.FindControl("rbtlapprove");
                if (obj != null)
                {
                    ddluom1 = (DropDownList)obj;
                 }

                if (chk.Checked == true)
                {
                    ddluom1.Enabled = true;
                    lblvoucheramt.Enabled = true;
                    lblremarks.Enabled = true;

                }
                else
                {
                    ddluom1.Enabled = false;
                    lblvoucheramt.Enabled = false;
                    lblremarks.Enabled = false;
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
}