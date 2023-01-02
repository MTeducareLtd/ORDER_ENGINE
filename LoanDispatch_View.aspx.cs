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

public partial class LoanDispatch_View : System.Web.UI.Page
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
                lblpagetitle1.Text = "Loan Dispatch Management";
                lblpagetitle2.Text = "";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                upnlviewcms.Visible = true;
                BindLoanDetails(Slipno);                
            }
        }

    }


    private void BindLoanDetails(string Slipno)
    {
        //DataSet  = ProductController.Get_LectureScheduleByPKey(lblPkey.Text);
        DataSet ds = AccountController.GetLoanDispatchDetailsbySlipno(1, Slipno);
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtviewDespatchslip.Text = ds.Tables[0].Rows[0]["LoanDispatchSlipNo"].ToString();
                txtviewdispatchDate.Text = ds.Tables[0].Rows[0]["LoanDispatchDate"].ToString();
                txtviewcenter.Text = ds.Tables[0].Rows[0]["Center_Name"].ToString();
                txtviewLoanCnt.Text = ds.Tables[0].Rows[0]["LoanCnt"].ToString();
                //txtviewLoanValue.Text = ds.Tables[0].Rows[0]["LoanValue"].ToString();
                dlcmsdtls.DataSource = ds.Tables[1];
                dlcmsdtls.DataBind();
            }
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Text = ex.ToString();
        }
    }

    //private void BindDLCMSDetails(string Slipno)
    //{
    //    string Sno = "";
    //    Sno = Slipno;
    //    DataSet ds = AccountController.GetDispatchDetailsbySlipno_Details(2, Sno);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        dlcmsdtls.DataSource = ds;
    //        dlcmsdtls.DataBind();

    //    }
    //    else
    //    {
    //    }
    //}

}