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

public partial class ChequeDispatch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        divErrormessage.Visible = false;
        if (!IsPostBack)
        {
           
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            lblpagetitle1.Text = "Dispatch Management";
            //lblpagetitle2.Text = "";
            
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            upnlsearch.Visible = true;
            UpnladdCMS.Visible = false;
            upnlviewcms.Visible = false;
            divmakecmserror.Visible = false;
            BindCompany();
            BindDivision();
            BindCMSCenter();
            //BindPayee();
            //System.Threading.Thread.Sleep(1000);
           
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
        //ddlcompany.Items.Insert(0, "Select");
        //ddlcompany.SelectedIndex = 0;

        //ddldivision.Items.Insert(0, "Select");
        //ddldivision.SelectedIndex = 0;

        //ddlzone.Items.Insert(0, "All");
        //ddlzone.SelectedIndex = 0;

        //ddlcenter.Items.Insert(0, "All");
        //ddlcenter.SelectedIndex = 0;

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
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;
    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindZone();
        BindPayee();
        BindCenter();
    }
    //private void BindZone()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
    //    BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
    //    ddlzone.Items.Insert(0, "Select");
    //    ddlzone.SelectedIndex = 0;
    //}
    protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        
    }
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", "MT");
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "Select");
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
        DataSet ds = AccountController.Getallpayeebycompanydivision(ddlcompany.SelectedValue , ddldivision .SelectedValue );
        BindDDL(ddlpayee, ds, "Payee_Name", "payee_id");
        ddlpayee.Items.Insert(0, "Select");
        ddlpayee.SelectedIndex = 0;
    }



    protected void btnmakeCMS_ServerClick(object sender, System.EventArgs e)
    {
        lblpagetitle1.Text = "Add Slip";
        lblpagetitle2.Text = "";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlsearch.Visible = false;
        UpnladdCMS.Visible = true;
        divmakecmserror.Visible = false;
        txtdispatchDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        BindSlipno();
        //Bindlist();
    }

    protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindPayeeadd();
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
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

    protected void btngetrecords_ServerClick(object sender, System.EventArgs e)
    {
        Bindlist();
        txtnoofinstr.Text = "";
        txtslipamt.Text = "";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;

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
        DataSet ds = AccountController.GetCheques_ForDispatch(Flag, Center, UserID, Slip, Payeeid, paymode);
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

   

    
    

    private void GetSumvalue()
    {
        Object obj = default(Object);
        Object obj1 = default(Object);
        CheckBox chk = null;
        Label lblsid = default(Label);
        decimal Sum = 0;
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
                lbldateerrordob.Text = "Dispatch date cannot be Blank";
                txtdispatchDate.Focus();
                return;

            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtdispatchDate.Text)) < DateTime.Today)
                {
                    lbldateerrordob.Visible = true;
                    lbldateerrordob.Text = "Dispatch date cannot be a past date";
                    txtdispatchDate.Focus();
                    return;
                }
                else
                {
                    if (Convert.ToDateTime(ClsCommon.FormatDate(txtdispatchDate.Text)) > DateTime.Today.AddDays(2))
                    {
                        lbldateerrordob.Visible = true;
                        lbldateerrordob.Text = "Dispatch date cannot be a greater than " + DateTime.Today.AddDays(2).ToString("dd-MM-yyyy");
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
            int  Chkcnt = 0;
            decimal TotalChkAmt = 0;
            string Chkdate = "";
            //decimal Chkamt = 0;
            //string Acadyear = "";
            //string Chkno = "";
            //string Chkid = "";
            //string SBentrycode = "";
            //string Center = "";
            string Division = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string CenterHeader = "";

            Object obj = default(Object);
            //Object obj1 = default(Object);
            CheckBox chk = null;
            //Label lblInstramt = default(Label);
            //Label lblInstrdate = default(Label);
            //Label lblacadyear = default(Label);
            //Label lblinstrno = default(Label);
            Label lblinstrid = default(Label);
            //Label lblsbentrycode = default(Label);
            //Label lblcenter = default(Label);
            //Label lbldivision = default(Label);
            int Sum = 0;
            //lblInstramt = null;
            //lblInstrdate = null;
            //lblacadyear = null;
            //lblinstrno = null;
            lblinstrid = null;
            //lblsbentrycode = null;
            //lblcenter = null;
            //lbldivision = null;
            string Payeeid = "";


            Slipno = txtdepositslipno.Text;
            Chkcnt = Convert.ToInt32(  txtnoofinstr.Text);
            TotalChkAmt = Convert.ToDecimal(txtslipamt.Text);
            
            CenterHeader = ddlcenterSlip.SelectedValue;
            if (CenterHeader == "Select")
            {
                divErrormessage.Visible =true;
                lblerrormessage.Visible =true;
                lblerrormessage .Text="Center Not Selected";
            }
            else
            {
                Division = CenterHeader.Substring(0, 2);
                divErrormessage.Visible = false;
                
            }
            Payeeid = ddlpayeeadd.SelectedValue;

            int Flag = 0;
            Flag = 1;

            string ChequeIDNo = "";
            //string Slipid = AccountController.InsertDepositSlip(Slipno, Chkcnt, TotalChkAmt, Chkdate, 0, Acadyear, Chkno, Chkid, SBentrycode, CenterHeader,
            //Division, UserID, Flag, Payeeid);
            try
            {
                foreach (DataListItem li in dlreceipts.Items)
                {
                    obj = li.FindControl("lblChequeidno");
                    if (obj != null)
                    {
                        lblinstrid = (Label)obj;
                    }

                    obj = li.FindControl("checkpoint");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        ChequeIDNo = ChequeIDNo + lblinstrid.Text + ",";

                    }
                }

                //remove last comma
                //if ( ChequeIDNo.EndsWith(",")== true  )
                //{
                //    ChequeIDNo = ChequeIDNo.Substring(1, ChequeIDNo.Length  - 1);
                //}


                string Slipid1 = AccountController.InsertDispatchslip_details(Flag, "", CenterHeader, Division, Chkdate, Chkcnt, TotalChkAmt, 0, Payeeid, UserID, ChequeIDNo );

            }
            catch (Exception ex)
            {
            }
            ddlcenterSlip.SelectedIndex = 0;
            BindSlipno();
            Bindlist();
            BindPayeeadd();
            divErrormessage.Visible = false;
            divSuccessmessage.Visible = true;
            lblsuccessMessage.Visible = true;
            lblsuccessMessage.Text = "Dispatch Successfully Created";
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

    protected void btnsave_Click(object sender, EventArgs e)
    {
        SaveDispatch();
    }

    private void SaveDispatch()
    {
        try
        {
            if (string.IsNullOrEmpty(txtdispatchDate.Text))
            {
                lbldateerrordob.Visible = true;
                lbldateerrordob.Text = "Dispatch date cannot be Blank";
                txtdispatchDate.Focus();
                btnsave.Enabled = true;
                return;

            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtdispatchDate.Text)) < DateTime.Today)
                {
                    lbldateerrordob.Visible = true;
                    lbldateerrordob.Text = "Dispatch date cannot be a past date";
                    txtdispatchDate.Focus();
                    btnsave.Enabled = true;
                    return;
                }
                else
                {
                    if (Convert.ToDateTime(ClsCommon.FormatDate(txtdispatchDate.Text)) > DateTime.Today.AddDays(2))
                    {
                        lbldateerrordob.Visible = true;
                        lbldateerrordob.Text = "Dispatch date cannot be a greater than " + DateTime.Today.AddDays(2).ToString("dd-MM-yyyy");
                        txtdispatchDate.Focus();
                        btnsave.Enabled = true;
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
            btnsave.Enabled = true;
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
            int Chkcnt = 0;
            decimal TotalChkAmt = 0;
            string Chkdate = "";
            //decimal Chkamt = 0;
            //string Acadyear = "";
            //string Chkno = "";
            //string Chkid = "";
            //string SBentrycode = "";
            //string Center = "";
            string Division = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string CenterHeader = "";

            Object obj = default(Object);
            //Object obj1 = default(Object);
            CheckBox chk = null;
            //Label lblInstramt = default(Label);
            //Label lblInstrdate = default(Label);
            //Label lblacadyear = default(Label);
            //Label lblinstrno = default(Label);
            Label lblinstrid = default(Label);
            //Label lblsbentrycode = default(Label);
            //Label lblcenter = default(Label);
            //Label lbldivision = default(Label);
            int Sum = 0;
            //lblInstramt = null;
            //lblInstrdate = null;
            //lblacadyear = null;
            //lblinstrno = null;
            lblinstrid = null;
            //lblsbentrycode = null;
            //lblcenter = null;
            //lbldivision = null;
            string Payeeid = "";


            Slipno = txtdepositslipno.Text;
            Chkcnt = Convert.ToInt32(txtnoofinstr.Text);
            TotalChkAmt = Convert.ToDecimal(txtslipamt.Text);

            CenterHeader = ddlcenterSlip.SelectedValue;
            if (CenterHeader == "Select")
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Center Not Selected";
                btnsave.Enabled = true;
            }
            else
            {
                Division = CenterHeader.Substring(0, 2);
                divErrormessage.Visible = false;
                btnsave.Enabled = true;

            }
            Payeeid = ddlpayeeadd.SelectedValue;

            int Flag = 0;
            Flag = 1;

            string ChequeIDNo = "";
            //string Slipid = AccountController.InsertDepositSlip(Slipno, Chkcnt, TotalChkAmt, Chkdate, 0, Acadyear, Chkno, Chkid, SBentrycode, CenterHeader,
            //Division, UserID, Flag, Payeeid);
            try
            {
                foreach (DataListItem li in dlreceipts.Items)
                {
                    obj = li.FindControl("lblChequeidno");
                    if (obj != null)
                    {
                        lblinstrid = (Label)obj;
                    }

                    obj = li.FindControl("checkpoint");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        ChequeIDNo = ChequeIDNo + lblinstrid.Text + ",";

                    }
                }

                //remove last comma
                //if ( ChequeIDNo.EndsWith(",")== true  )
                //{
                //    ChequeIDNo = ChequeIDNo.Substring(1, ChequeIDNo.Length  - 1);
                //}


                string Slipid1 = AccountController.InsertDispatchslip_details(Flag, "", CenterHeader, Division, Chkdate, Chkcnt, TotalChkAmt, 0, Payeeid, UserID, ChequeIDNo);

            }
            catch (Exception ex)
            {
                btnsave.Enabled = true;
            }
            ddlcenterSlip.SelectedIndex = 0;
            BindSlipno();
            Bindlist();
            BindPayeeadd();
            divErrormessage.Visible = false;
            divSuccessmessage.Visible = true;
            lblsuccessMessage.Visible = true;
            lblsuccessMessage.Text = "Dispatch Successfully Created";
            txtnoofinstr.Text = "0";
            txtslipamt.Text = "0.00";
            btnsave.Enabled = true;
        }
        else
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = "Atleast One Instrument Should be selected";
            btnsave.Enabled = true;
        }
    
    }

    protected void btnCloseAdd_ServerClick(object sender, System.EventArgs e)
    {
        lblpagetitle1.Text = "Dispatch Management";
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
        divErrormessage.Visible = false;
        Company = ddlcompany.SelectedValue;
        Division = ddldivision.SelectedValue;
        Zone = "All";
        Center = ddlcenter.SelectedValue;
        Fromdate = txtfromdate.Text;
        Todate = txttodate.Text;
        Payeeid = ddlpayee.SelectedValue;
        Slipno = txtslipnosearch.Text;

        DataSet ds = AccountController.GetDispatchSlip(Company, Division, Zone, Center, Fromdate, Todate, UserID, Payeeid, Slipno);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Cheque Dispatch";
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
            //divmessage.Visible = true;
            //lblmessage.Text = "No Records Found!";
            divErrormessage.Visible = true;
            lblerrormessage.Text = "No Records Found!";
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