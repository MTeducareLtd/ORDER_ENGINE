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

public partial class Manage_Request : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //string Menuid = "119";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            lblpagetitle1.Text = "Manage Request";
            //lblpagetitle2.Text = "Search Results";
            lblmidbreadcrumb.Text = "Manage Request";
            lilastbreadcrumb.Visible = false;
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            upnlsearch.Visible = true;
            
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
        //ddlcompany.Items.Insert(0, "All");
        //ddlcompany.SelectedIndex = 0;
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
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", "MT");
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
        //ddlacademicyear.Items.Insert(0, "All");
        //ddlacademicyear.SelectedIndex = 0;
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
        BindDDL(ddlstreamname, ds, "Stream_Sdesc", "Stream_Code");
        ddlstreamname.Items.Insert(0, "All");
        ddlstreamname.SelectedIndex = 0;
    }
    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        Bindlist();
    }
    private void Bindlist()
    {
        string Requesttype = "";
        string Requestdate = "";
        string RequestStatus = "";
        string Company = "";
        string Division = "";
        string Center = "";
        string Academicyear = "";
        string Stream = "";
        string Name = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
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
        Name = txtname.Text;
        string Sbentrycode = "";
        string Appno = "";
        Sbentrycode = txtsbentrycode.Text;
        Appno = txtapplicationno.Text;
        DataSet ds = AccountController.GetAllrequestformanagerequestpage(Requesttype, Requestdate, RequestStatus, Company, Division, Center, Academicyear, Stream, Name, UserID,
        Sbentrycode, Appno);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnsearchback.Visible = true;
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Manage Request";
            //lblpagetitle2.Text = "Requests Grid";
            //limidbreadcrumb.Visible = true;
            //lblmidbreadcrumb.Text = "Manage Request";
            //lilastbreadcrumb.Visible = true;
            //lbllastbreadcrumb.Text = " Requests Grid";
            //lilastbreadcrumb.Visible = true;
            //lbltabname.Text = "Search Results"
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            divmessage.Visible = false;
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            script1.RegisterAsyncPostBackControl(Repeater1);
           
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            divmessage.Visible = true;
            lblmessage.Text = "No Records Found!";
        }
    }
   

    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string ApprovalStatus = ((Label)e.Item.FindControl("Label7")).Text;
            if (ApprovalStatus == "In Process")
            {
                string Opendays = ((Label)e.Item.FindControl("Label1")).Text;
                if (string.IsNullOrEmpty(Opendays))
                {
                    ((Label)e.Item.FindControl("Label10")).Visible = false;
                }
                else
                {
                    if (Convert.ToDateTime(ClsCommon.FormatDate(Opendays)) < DateTime.Today)
                    {
                        ((Label)e.Item.FindControl("Label10")).Visible = true;
                        //Get Open days
                        System.DateTime startDate = DateTime.Today;
                        //DateTime.Now.ToString("dd/MM/yyyy")
                        DateTime enddate = Convert.ToDateTime(ClsCommon.FormatDate(Opendays));
                        TimeSpan ts = startDate.Subtract(enddate);
                        string od = "";
                        od = ts.Days.ToString();
                        ((Label)e.Item.FindControl("Label10")).Text = od;
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("Label10")).Text = "0";
                    }
                }
            }
            else
            {
                ((Label)e.Item.FindControl("Label10")).Visible = false;
            }


        }
    }

    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {
        divsearchresults.Visible = false;
        Divsearchcriteria.Visible = true;
        divmessage.Visible = false;
        btnsearchback.Visible = false;
    }
}