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
using Encryption.BL;

public partial class Dashboard_Account : System.Web.UI.Page
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
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divmessage.Visible = false;
                BindAccountSummary();
                BindAcademicYear();
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

    private void BindAcademicYear()
    {
        DataSet ds = ProductController.GetAllAcadyear();
        //DataSet ds = ProductController.GetAcademicYearbyCenter(ddlcenter.SelectedValue);
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        string AcadYear = Request["AcadYear"];
        ddlAcadYear.SelectedValue = AcadYear;
        //ddlAcadYear.Items.Insert(0, "Select");
        //ddlAcadYear.SelectedIndex = 1;
    }

    private void BindAccountSummary()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string AcadYear = "2017-2018";
        DataSet ds = ProductController.GetAdmissionDashboard(UserID,AcadYear);
        if (ds.Tables[1].Rows.Count > 0)
        {
            dlPendingAccountsummary.DataSource = ds.Tables[1];
            Repeater1.DataSource = ds.Tables[0];
            dlPendingAccountsummary.DataBind();
            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader1('" + dlPendingAccountsummary.ClientID + "', 490, 1250, 55 ,false); </script>", false);
            Repeater1.DataBind();
            //ScriptManager1.RegisterAsyncPostBackControl(dlPendingAccountsummary);
        }
        else
        {
            dlPendingAccountsummary.Visible = false;
        }
    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.Cookies["MyCookiesLoginInfo"] != null)
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string AcadYear = ddlAcadYear.SelectedValue;
            try
            {
                DataSet ds = ProductController.GetAdmissionDashboard(UserID, AcadYear);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    dlPendingAccountsummary.DataSource = ds.Tables[1];
                    Repeater1.DataSource = ds.Tables[0];
                    dlPendingAccountsummary.DataBind();
                    Repeater1.DataBind();
                }
                else
                {
                    dlPendingAccountsummary.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}