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

public partial class Cancelled_Accounts_Detail : System.Web.UI.Page
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
                    string Year = "", Stream = "";

                    if (Request["AcadYear"] != null)
                    {
                        Year = Request["AcadYear"];
                    }
                    if (Request["Stream"] != null)
                    {
                        Stream = Request["Stream"];
                    }

                    Bind_Stream(Year, Stream);
                    ddlStream.SelectedValue = Stream;

                    BindAccountSummary(Year);
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

    protected void ddlStream_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string Year = "";
        if (Request["AcadYear"] != null)
        {
            Year = Request["AcadYear"];
        }
        
        BindAccountSummary(Year);

    }

    protected void btnCancelledAccountCount_ServerClick(object sender, System.EventArgs e)
    {
        string Year = "", division = "", center = "";

        if (Request["AcadYear"] != null)
        {
            Year = Request["AcadYear"];
        }
        if (Request["division"] != null)
        {
            division = Request["division"];
        }

        if (Request["center"] != null)
        {
            center = Request["center"];
        }


        Response.Redirect("Cancelled_Accounts.aspx?Year=" + Year + "&division=" + division + "&center=" + center);
    }

    private void Bind_Stream(string Acadyear, string PKey)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetCancelledAdmission_Detail(UserID, Acadyear, PKey, "2");

        BindDDL(ddlStream, ds, "Stream", "PKey");
        //ddldivision.Items.Insert(0, "All");
        ddlStream.SelectedIndex = 0;
    }

    private void BindAccountSummary(string Acadyear)
    {
        string PKey = ddlStream.SelectedValue.ToString();
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetCancelledAdmission_Detail(UserID, Acadyear, PKey,"1");

        if (ds.Tables[0].Rows.Count > 0)
        {
            divsearchresults.Visible = true;
            divErrormessage.Visible = false;
            dlPendingAccountsummary.DataSource = ds.Tables[0];
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
    
}