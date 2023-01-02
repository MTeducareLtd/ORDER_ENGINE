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

public partial class Pending_Account_Ageing : System.Web.UI.Page
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
                    divErrormessage.Visible = false;
                    BindAcademicYear();
                    if (Request["Year"] != null)
                    {
                        string Year = Request["Year"];
                        ddlAcadYear.SelectedValue = Year;
                    }
                    if (Request["Division"] != null)
                    {
                        BindDivision();
                        string Division = Request["Division"];
                        ddldivision.SelectedValue = Division;
                        BindCenter();
                    }
                    if (Request["Center"] != null)
                    {
                        string Center = Request["Center"];
                        ddlcenter.SelectedValue = Center;
                    }
                    BindAccountSummary();
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
            ddlcenter.SelectedIndex = 0;
            string year = ddlAcadYear.SelectedValue;
            string division = ddldivision.SelectedItem.Text;
            string divisioncode = ddldivision.SelectedValue;
            string centercode = ddlcenter.SelectedValue;
            BindAccountSummary();
            //BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
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

    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        BindAccountSummary();
        //BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
    }


    private void BindAcademicYear()
    {
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        ddlAcadYear.SelectedIndex = 0;
        //BindAccountSummary();
    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string year = ddlAcadYear.SelectedValue;
        BindAccountSummary();
    }

    private void BindAccountSummary()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string AcadYear = ddlAcadYear.SelectedValue;
        //string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        DataSet ds = ProductController.GetPendingAdmissionAgeing(UserID, AcadYear, divisioncode, centercode);
        if (ds.Tables[1].Rows.Count > 0)
        {
            divsearchresults.Visible = true;
            divErrormessage.Visible = false;
            dlPendingAccountsummary.DataSource = ds.Tables[1];
            dlPendingAccountsummary.DataBind();
            dlPendingAccountsummary.Visible = true;
        }
        else
        {
            dlPendingAccountsummary.Visible = false;
            divErrormessage.Visible = true;
            divsearchresults.Visible = false;
        }
    }

    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "[0-7 Days]")
        { 
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string AcadYear = ddlAcadYear.SelectedValue;
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        DataSet ds = ProductController.Get_Pendingadmissionaginedetails(UserID, AcadYear, divisioncode, centercode, "1");
        if (ds.Tables[0].Rows.Count > 0)
        {

            divsearchresults.Visible = true;
            divErrormessage.Visible = false;

            DLPENDINGACOOUNTDETAILED.DataSource = ds.Tables[0];
            DLPENDINGACOOUNTDETAILED.DataBind();
            DLPENDINGACOOUNTDETAILED.Visible = true;

            //lblCancellationStatus.Text = ds.Tables[0].Rows.Count.ToString();
        }
        else {
            DLPENDINGACOOUNTDETAILED.Visible = false;
        }
        }

        if (e.CommandName == "[8-30 Days]")
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string AcadYear = ddlAcadYear.SelectedValue;
            string year = ddlAcadYear.SelectedValue;
            string division = ddldivision.SelectedItem.Text;
            string divisioncode = ddldivision.SelectedValue;
            string centercode = ddlcenter.SelectedValue;
            DataSet ds = ProductController.Get_Pendingadmissionaginedetails(UserID, AcadYear, divisioncode, centercode, "2");
            if (ds.Tables[0].Rows.Count > 0)
            {

                divsearchresults.Visible = true;
                divErrormessage.Visible = false;

                DLPENDINGACOOUNTDETAILED.DataSource = ds.Tables[0];
                DLPENDINGACOOUNTDETAILED.DataBind();
                DLPENDINGACOOUNTDETAILED.Visible = true;

                //lblCancellationStatus.Text = ds.Tables[0].Rows.Count.ToString();
            }
            else
            {
                DLPENDINGACOOUNTDETAILED.Visible = false;
            }
        }

        if (e.CommandName == "[31-90 Days]")
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string AcadYear = ddlAcadYear.SelectedValue;
            string year = ddlAcadYear.SelectedValue;
            string division = ddldivision.SelectedItem.Text;
            string divisioncode = ddldivision.SelectedValue;
            string centercode = ddlcenter.SelectedValue;
            DataSet ds = ProductController.Get_Pendingadmissionaginedetails(UserID, AcadYear, divisioncode, centercode, "3");
            if (ds.Tables[0].Rows.Count > 0)
            {

                divsearchresults.Visible = true;
                divErrormessage.Visible = false;

                DLPENDINGACOOUNTDETAILED.DataSource = ds.Tables[0];
                DLPENDINGACOOUNTDETAILED.DataBind();
                DLPENDINGACOOUNTDETAILED.Visible = true;

                //lblCancellationStatus.Text = ds.Tables[0].Rows.Count.ToString();
            }
            else
            {
                DLPENDINGACOOUNTDETAILED.Visible = false;
            }
        }

        if (e.CommandName == "[More Than 90 Days]")
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string AcadYear = ddlAcadYear.SelectedValue;
            string year = ddlAcadYear.SelectedValue;
            string division = ddldivision.SelectedItem.Text;
            string divisioncode = ddldivision.SelectedValue;
            string centercode = ddlcenter.SelectedValue;
            DataSet ds = ProductController.Get_Pendingadmissionaginedetails(UserID, AcadYear, divisioncode, centercode, "4");
            if (ds.Tables[0].Rows.Count > 0)
            {

                divsearchresults.Visible = true;
                divErrormessage.Visible = false;

                DLPENDINGACOOUNTDETAILED.DataSource = ds.Tables[0];
                DLPENDINGACOOUNTDETAILED.DataBind();
                DLPENDINGACOOUNTDETAILED.Visible = true;

                //lblCancellationStatus.Text = ds.Tables[0].Rows.Count.ToString();
            }

            else
            {
                DLPENDINGACOOUNTDETAILED.Visible = false;
            }
        }
    
    }


    
}