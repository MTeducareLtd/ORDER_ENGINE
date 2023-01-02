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
//using Exportxls.BL;

public partial class ChequeDeposit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Menuid = "117";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            lblpagetitle1.Text = "Deposit Management";
            lblpagetitle2.Text = "";
            //limidbreadcrumb.Visible = true;
            //lblmidbreadcrumb.Text = "Deposit Management";
            //lilastbreadcrumb.Visible = false;
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            upnlsearch.Visible = true;
            UpnladdCMS.Visible = false;
            upnlviewcms.Visible = false;
            divmakecmserror.Visible = false;
            BindCompany();
            BindCMSCenter();
            BindPayee();
            System.Threading.Thread.Sleep(1000);
            SqlDataReader dr = UserController.Getuserrights(UserID, Menuid);
            try
            {
                if ((((dr) != null)))
                {
                    if (dr.Read())
                    {
                        int allowdisplay = Convert.ToInt32(dr["Allow_Add"].ToString());
                        if (allowdisplay == 1)
                        {
                            //btnaddlead.Visible = True
                            //btnimportlead.Visible = True
                        }
                        else
                        {
                            //btnaddlead.Visible = False
                            //btnimportlead.Visible = False
                        }

                    }
                }


            }
            catch (Exception ex)
            {
            }
            divmessage.Visible = false;
            divSearch.Visible = true;
            divsearchresults.Visible = false;
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
    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
        ddlcompany.Items.Insert(0, "All");
        ddlcompany.SelectedIndex = 0;

        ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;

        ddlzone.Items.Insert(0, "All");
        ddlzone.SelectedIndex = 0;

        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;

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
    protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddldivision.SelectedValue, ddlzone.SelectedValue, ddlcompany.SelectedValue);
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }
    private void BindCMSCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(13, UserID, "", "", "");
        BindDDL(ddlcenterSlip, ds, "Center_name", "Center_Code");
        ddlcenterSlip.Items.Insert(0, "Select");
        ddlcenterSlip.SelectedIndex = 0;
    }
    private void BindPayee()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = AccountController.Getallpayee();
        BindDDL(ddlpayee, ds, "Payee_Name", "payee_id");
        ddlpayee.Items.Insert(0, "All");
        ddlpayee.SelectedIndex = 0;
    }



    protected void btnmakeCMS_ServerClick(object sender, System.EventArgs e)
    {
        lblpagetitle1.Text = "Add Slip";
        lblpagetitle2.Text = "";
        //limidbreadcrumb.Visible = true;
        //lblmidbreadcrumb.Text = "Deposit Management";
        //lilastbreadcrumb.Visible = true;
        //lbllastbreadcrumb.Visible = true;
        //lbllastbreadcrumb.Text = "New CMS Deposit Slip";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlsearch.Visible = false;
        UpnladdCMS.Visible = true;
        divmakecmserror.Visible = false;
        txtdispatchDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        BindSlipno();
        //txtdepositslipno.Text = GetSlipno()
        Bindlist();
    }

    private void BindSlipno()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        int Flag = 0;
        string Center = "";
        string Slip = "";
        Flag = 1;
        Center = ddlcenterSlip.SelectedValue;
        string Payeeid = "";
        Payeeid = ddlpayeeadd.SelectedValue;
        string paymode = "";
        paymode = ddlpaymode.SelectedValue;
        string Slipno = AccountController.GetSlipno(Flag, Center, UserID, Slip, Payeeid, paymode);
        txtdepositslipno.Text = Slipno;

    }
    private void Bindlist()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        int Flag = 0;
        string Center = "";
        string Slip = "";
        Flag = 2;
        Center = ddlcenterSlip.SelectedValue;
        string Payeeid = "";
        Payeeid = ddlpayeeadd.SelectedValue;
        string paymode = "";
        paymode = ddlpaymode.SelectedValue;
        DataSet ds = AccountController.Get_All_Pending_Receipts(Flag, Center, UserID, Slip, Payeeid, paymode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //System.Threading.Thread.Sleep(1000)
            dlreceipts.Visible = true;
            dlreceipts.DataSource = ds;
            dlreceipts.DataBind();
            divmakecmserror.Visible = false;
            lblrecordcount.Text = ds.Tables[0].Rows.Count.ToString();
        }
        else
        {
            dlreceipts.Visible = false;
            divsearchresults.Visible = false;
            divmakecmserror.Visible = true;
            lblmakecmserror.Text = "No Pending Instrument to be deposited!";
        }

    }

    protected void ddlcenterSlip_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ddlpaymode.SelectedValue = "04";
        BindPayeeadd();
        dlreceipts.Visible = false;
    }
    private void BindPayeeadd()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Center = ddlcenterSlip.SelectedValue;
        DataSet ds = AccountController.GetallpayeebyCenter(1, Center);
        BindDDL(ddlpayeeadd, ds, "Payee_Name", "payee_id");
        ddlpayeeadd.Items.Insert(0, "Select");
        ddlpayeeadd.SelectedIndex = 0;
    }

    protected void ddlpayeeadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Bindlist();
        txtnoofinstr.Text = "";
        txtslipamt.Text = "";
    }

    protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindPayeeadd();
    }

    private void GetSumvalue()
    {
        Object obj = default(Object);
        Object obj1 = default(Object);
        CheckBox chk = null;
        Label lblsid = default(Label);
        decimal  Sum = 0;
        int Count = 0;

        txtslipamt.Text = "0";
                txtnoofinstr.Text = "0";

        foreach (DataListItem li in dlreceipts.Items)
        {
            obj = li.FindControl("checkpoint");
            if (obj != null)
            {
                chk = (CheckBox)obj;
            }

            obj = li.FindControl("lblinstramt");
            if (obj != null)
            {
                lblsid = (Label)obj;
            }
            if (chk.Checked == true)
            {
                try
                {
                    Sum = Sum + Convert.ToDecimal(lblsid.Text);
                }
                catch (Exception ex)
                {
                    
                }
                txtslipamt.Text = Sum.ToString();
                Count = Count + 1;
                txtnoofinstr.Text = Count.ToString();
            }
        }
    }

    protected void btnsave_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtdispatchDate.Text))
            {
                lbldateerrordob.Visible = true;
                lbldateerrordob.Text = "Deposit date cannot be Blank";
                txtdispatchDate.Focus();
                return;

            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtdispatchDate.Text)) < DateTime.Today)
                {
                    lbldateerrordob.Visible = true;
                    lbldateerrordob.Text = "Deposit date cannot be a past date";
                    txtdispatchDate.Focus();
                    return;
                }
                else
                {
                    if (Convert.ToDateTime(ClsCommon.FormatDate(txtdispatchDate.Text)) > DateTime.Today.AddDays(2))
                    {
                        lbldateerrordob.Visible = true;
                        lbldateerrordob.Text = "Deposit date cannot be a greater than " + DateTime.Today.AddDays(2).ToString("dd-MM-yyyy");
                        txtdispatchDate.Focus();
                        return;
                    }
                    lbldateerrordob.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            lbldateerrordob.Visible = true;
            lbldateerrordob.Text = ex.Message;
            return;
        }

        object obj11 = null;
        CheckBox Chk11 = default(CheckBox);
        Label lblselecteditem = default(Label);
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        string Sgrcode = "";
        CheckBox cb1 = default(CheckBox);
        foreach (DataListItem li in dlreceipts.Items)
        {
            obj11 = li.FindControl("lblChequeidno");
            if (obj11 != null)
            {
                lblselecteditem = (Label)obj11;
            }

            cb1 = (CheckBox)li.FindControl("checkpoint");
            if (cb1 != null)
            {
                Chk11 = (CheckBox)cb1;
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
        if (Sgrcode.Length > 0)
        {
            string Slipno = "";
            string Chkcnt = "";
            decimal TotalChkAmt = 0;
            string Chkdate = "";
            decimal Chkamt = 0;
            string Acadyear = "";
            string Chkno = "";
            string Chkid = "";
            string SBentrycode = "";
            string Center = "";
            string Division = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string CenterHeader = "";

            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            Label lblInstramt = default(Label);
            Label lblInstrdate = default(Label);
            Label lblacadyear = default(Label);
            Label lblinstrno = default(Label);
            Label lblinstrid = default(Label);
            Label lblsbentrycode = default(Label);
            Label lblcenter = default(Label);
            Label lbldivision = default(Label);
            int Sum = 0;
            lblInstramt = null;
            lblInstrdate = null;
            lblacadyear = null;
            lblinstrno = null;
            lblinstrid = null;
            lblsbentrycode = null;
            lblcenter = null;
            lbldivision = null;
            string Payeeid = "";


            Slipno = txtdepositslipno.Text;
            Chkcnt = txtnoofinstr.Text;
            TotalChkAmt =Convert.ToDecimal(txtslipamt.Text);
            CenterHeader = ddlcenterSlip.SelectedValue;
            Payeeid = ddlpayeeadd.SelectedValue;

            int Flag = 0;
            Flag = 1;
            string Slipid = AccountController.InsertDepositSlip(Slipno, Chkcnt, TotalChkAmt, Chkdate, 0, Acadyear, Chkno, Chkid, SBentrycode, CenterHeader,
            Division, UserID, Flag, Payeeid);
            try
            {
                foreach (DataListItem li in dlreceipts.Items)
                {
                    obj = li.FindControl("lblinstramt");
                    if (obj != null)
                    {
                        lblInstramt = (Label)obj;
                    }

                    obj = li.FindControl("lblinstrdate");
                    if (obj != null)
                    {
                        lblInstrdate = (Label)obj;
                    }

                    obj = li.FindControl("lblAcadyear");
                    if (obj != null)
                    {
                        lblacadyear = (Label)obj;
                    }

                    obj = li.FindControl("lblinstrno");
                    if (obj != null)
                    {
                        lblinstrno = (Label)obj;
                    }

                    obj = li.FindControl("lblChequeidno");
                    if (obj != null)
                    {
                        lblinstrid = (Label)obj;
                    }

                    obj = li.FindControl("lblsbentrycode");
                    if (obj != null)
                    {
                        lblsbentrycode = (Label)obj;
                    }

                    obj = li.FindControl("lblCenterCode");
                    if (obj != null)
                    {
                        lblcenter = (Label)obj;
                    }

                    obj = li.FindControl("lblDivisionCode");
                    if (obj != null)
                    {
                        lbldivision = (Label)obj;
                    }

                    obj = li.FindControl("checkpoint");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        Flag = 2;
                        string Slipid1 = AccountController.InsertDepositSlip(Slipno, Chkcnt, TotalChkAmt, lblInstrdate.Text, Convert.ToDecimal(lblInstramt.Text), lblacadyear.Text, lblinstrno.Text, lblinstrid.Text, lblsbentrycode.Text, lblcenter.Text,
                        lbldivision.Text, UserID, Flag, Payeeid);
                        //ProductController.UpdateShoppingCartItem(lblsid.Text, Convert.ToInt32(lblpid.Text), Convert.ToInt32(txtqty.Text))

                    }
                }

            }
            catch (Exception ex)
            {
            }
            ddlcenterSlip.SelectedIndex = 0;
            BindSlipno();
            Bindlist();
            divErrormessage.Visible = false;
            divSuccessmessage.Visible = true;
            lblsuccessMessage.Visible = true;
            lblsuccessMessage.Text = "CMS Successfully Created";
            txtnoofinstr.Text = "0";
            txtslipamt.Text = "0.00";
        }
        else
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = "Atleast One Instrument Should be selected";
        }
    }

    protected void btnCloseAdd_ServerClick(object sender, System.EventArgs e)
    {
        lblpagetitle1.Text = "Deposit Management";
        lblpagetitle2.Text = "";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlsearch.Visible = true;
        UpnladdCMS.Visible = false;
        divmakecmserror.Visible = false;

    }


    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Company = "";
        string Division = "";
        string Zone = "";
        string Center = "";
        string Fromdate = "";
        string Todate = "";
        string Payeeid = "";
        string Slipno = "";

        Company = ddlcompany.SelectedValue;
        Division = ddldivision.SelectedValue;
        Zone = ddlzone.SelectedValue;
        Center = ddlcenter.SelectedValue;
        Fromdate = txtfromdate.Text;
        Todate = txttodate.Text;
        Payeeid = ddlpayee.SelectedValue;
        Slipno = txtslipnosearch.Text;

        DataSet ds = AccountController.Get_CMS_Search_results(Company, Division, Zone, Center, Fromdate, Todate, UserID, Payeeid, Slipno);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Cheque Deposit";
            lblpagetitle2.Text = "Search Results";
            //limidbreadcrumb.Visible = true;
            //lblmidbreadcrumb.Text = "Cheque Deposit";
            //lilastbreadcrumb.Visible = true;
            //lbllastbreadcrumb.Text = " Search Results";
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


    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
    }

    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        //If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        //    Dim scriptManager__1 As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        //    scriptManager__1.RegisterPostBackControl(DirectCast(e.Item.FindControl("lnkviewdetails"), LinkButton))
        //End If
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