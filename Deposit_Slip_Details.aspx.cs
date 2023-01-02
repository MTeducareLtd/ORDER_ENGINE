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


public partial class Deposit_Slip_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["Slip_No"] != null)
            {
                string Slipno = Request["Slip_No"];
                string Menuid = "102";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "Cheque Management";
                lblpagetitle2.Text = "";
                //limidbreadcrumb.Visible = true;
                //lblmidbreadcrumb.Text = "Cheque Management";
                //lilastbreadcrumb.Visible = true;
                //lbllastbreadcrumb.Visible = true;
                //lbllastbreadcrumb.Text = "Deposit Slip Details";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                upnlviewcms.Visible = true;
                BindCMSDetails(Slipno);
                BindDLCMSDetails(Slipno);
            }
        }

    }


    private void BindCMSDetails(string Slipno)
    {
        string SNo = "";
        SNo = Slipno;
        SqlDataReader dr = AccountController.GetCMSDetailsbySlipno(1, SNo);
        try
        {
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    txtviewdepositslip.Text = dr["SlipNo"].ToString();
                    txtviewdispatch.Text = dr["Dispatch_Date"].ToString();
                    txtviewcenter.Text = dr["Center_Name"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void BindDLCMSDetails(string Slipno)
    {
        string Sno = "";
        Sno = Slipno;
        DataSet ds = AccountController.Get_CMS_Search_results_Details(2, Sno);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlcmsdtls.DataSource = ds;
            dlcmsdtls.DataBind();

        }
        else
        {
        }
    }


}