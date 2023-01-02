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

public partial class ECS_Deposit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Menuid = "117";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            try
            {
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
            }
            catch
            {
                Response.Redirect("login.aspx");
            }
            lblpagetitle1.Text = "ECS Dispatch Management";
            lblpagetitle2.Text = "";
            //limidbreadcrumb.Visible = true;
            //lblmidbreadcrumb.Text = "Dispatch Management";
            //lilastbreadcrumb.Visible = false;
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            upnlsearch.Visible = true;
            UpnladdCMS.Visible = false;
            upnlviewcms.Visible = false;
            divmakecmserror.Visible = false;
            //BindCompany();
            BindDivision();
            //BindCMSCenter();
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

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
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
        ddldivision.Items.Insert(0, "Select");
        ddldivision.Items.Insert(1, "All");
        ddldivision.SelectedIndex = 0;
        
        //BindDDL(ddlAddSlipDivision, ds, "Division_Name", "Division_Code");
        //ddlAddSlipDivision.Items.Insert(0, "Select");
        //ddlAddSlipDivision.SelectedIndex = 0;
        //ddlcenter.Items.Insert(0, "Select");
        //ddlcenter.SelectedIndex = 0;
    }
    private void BindDivision_Slip()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindListBox(ddlAddSlipDivisionNew, ds, "Division_Name", "Division_Code");
    }

    public void All_Student_ChkBox_Selected_Sel(object sender, System.EventArgs e)
    {
        //Change checked status of a hidden check box
        chkStudentAllHidden_Sel.Checked = !(chkStudentAllHidden_Sel.Checked);

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlreceipts.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("checkpoint");

            chkitemck.Checked = chkStudentAllHidden_Sel.Checked;
        }

    }


    protected void btnBackECSSearch_ServerClick(object sender, System.EventArgs e)
    {
        btnBackECSSearch.Visible = false;
        Divsearchcriteria.Visible = true;
        lblpagetitle1.Text = "ECS Dispatch Management";
        lblpagetitle2.Text = "";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        divsearchresults.Visible = false;
        divmessage.Visible = false;
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
        //txtdispatchDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        txtdispatchDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
        BindSlipno();
        btnmakeCMSButton.Visible = false;
        lblrecordcount.Text = "0";
        txtnoofinstr.Text = "0";
        txtslipamt.Text = "0";        
        BindDivision_Slip();
        //ddlAddSlipDivision.SelectedIndex = 0;
        //ddlcenterSlip.Items.Clear();
        //ddlcenterSlip.Items.Insert(0, "Select");
        //ddlcenterSlip.SelectedIndex = 0;
        //Bindlist();
    }

    //protected void ddlAddSlipDivision_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindAddSlipCenter();
    //}


    protected void ddlAddSlipDivisionNew_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlreceipts.Visible = false;
    }

    //private void BindAddSlipCenter()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlAddSlipDivision.SelectedValue, "", "MT");
    //    BindDDL(ddlcenterSlip, ds, "Center_name", "Center_Code");
    //    ddlcenterSlip.Items.Insert(0, "Select");
    //    ddlcenterSlip.Items.Insert(1, "All");
    //    ddlcenterSlip.SelectedIndex = 0;
    //    dlreceipts.Visible = false;
    //}

    protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindPayeeadd();
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
    }

    protected void ddlcenterSlip_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //ddlpaymode.SelectedValue = "04";
       // BindPayeeadd();
        dlreceipts.Visible = false;
    }


    //private void BindPayeeadd()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    string Center = ddlcenterSlip.SelectedValue;
    //    DataSet ds = AccountController.GetallpayeebyCenter(1, Center);
    //    BindDDL(ddlpayeeadd, ds, "Payee_Name", "payee_id");
    //    ddlpayeeadd.Items.Insert(0, "Select");
    //    ddlpayeeadd.SelectedIndex = 0;
    //}

   


    private void BindSlipno()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        int Flag = 0;
        string Center = "";
        string Slip = "";
        Flag = 4;
       // Center = ddlcenterSlip.SelectedValue;
        string Payeeid = "10001";//MTEducare
       // Payeeid = ddlpayeeadd.SelectedValue;
        string paymode = "05";//Instruments
        //paymode = ddlpaymode.SelectedValue;
        string Slipno = AccountController.Get_ECS_Slipno(Flag, Center, UserID, Slip, Payeeid, paymode);
        txtdepositslipno.Text = Slipno;
        dlreceipts.Visible = false;
        //ddlAddSlipDivision.SelectedIndex = 0;
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
        int Flag = 2;
        string Center = "All", DivisionCode = "";
        string Slip = "";
        int Cnt = 0;
        for (Cnt = 0; Cnt <= ddlAddSlipDivisionNew.Items.Count - 1; Cnt++)
        {
            if (ddlAddSlipDivisionNew.Items[Cnt].Selected == true)
            {
                DivisionCode = DivisionCode + ddlAddSlipDivisionNew.Items[Cnt].Value + ",";
            }
        }
        //Center = ddlcenterSlip.SelectedValue;
        string Payeeid = "10001";//MTEducare
        //Payeeid = ddlpayeeadd.SelectedValue;
        string paymode = "05";//Instruments
      //  paymode = ddlpaymode.SelectedValue;
        lblECSDate.Text = txtdispatchDate.Value;
        DataSet ds = AccountController.Get_ECS_Cheques_ForDispatch(Flag, Center, UserID, Slip, Payeeid, paymode, lblECSDate.Text, DivisionCode);
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
            lblrecordcount.Text = "0";
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
            if (string.IsNullOrEmpty(txtdispatchDate.Value))
            {
                lbldateerrordob.Visible = true;
                lbldateerrordob.Text = "Dispatch date cannot be Blank";
                //txtdispatchDate.Focus();
                return;
            }
            else
            {
                //if (Convert.ToDateTime(ClsCommon.FormatDate(txtdispatchDate.Value)) > DateTime.Today)
                //{
                //    lbldateerrordob.Visible = true;
                //    lbldateerrordob.Text = "Dispatch date cannot be a future date";
                //   // txtdispatchDate.Focus();
                //    return;
                //}
                ////else
                ////{
                ////    if (Convert.ToDateTime(ClsCommon.FormatDate(txtdispatchDate.Value)) > DateTime.Today.AddDays(2))
                ////    {
                ////        lbldateerrordob.Visible = true;
                ////        lbldateerrordob.Text = "Dispatch date cannot be a greater than " + DateTime.Today.AddDays(2).ToString("dd-MM-yyyy");
                ////        txtdispatchDate.Focus();
                ////        return;
                ////    }
                ////    lbldateerrordob.Visible = false;
                ////}
            }
        }        
        catch (Exception ex)
        {
            lbldateerrordob.Visible = true;
            lbldateerrordob.Text = ex.Message;
            return;
        }

        string Division = "";
        int Cnt = 0;
        for (Cnt = 0; Cnt <= ddlAddSlipDivisionNew.Items.Count - 1; Cnt++)
        {
            if (ddlAddSlipDivisionNew.Items[Cnt].Selected == true)
            {
                Division = Division + ddlAddSlipDivisionNew.Items[Cnt].Value + ",";
            }
        }



        if (dlreceipts.Visible == false)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = "Atleast One Instrument Should be selected";
            return;
        }
        
        object obj11 = null;
        object obj12 = null;
        CheckBox Chk11 = default(CheckBox);
        Label lblselecteditem = default(Label);
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        string Sgrcode = "";
        CheckBox cb1 = default(CheckBox);
        Label lblinstrdate = default(Label);
        
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

            obj12 = (Label)li.FindControl("lblinstrdate");
            if (obj12 != null)
            {
                lblinstrdate = (Label)obj12;
                if (lblinstrdate.Text != txtdispatchDate.Value)
                {
                    divErrormessage.Visible = true;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = "If you change the Dispatch date then first click on get button then select the instrument then Save.";
                    return;
                }
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
            string Chkdate = lblECSDate.Text;
            
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string CenterHeader = "All";

            Object obj = default(Object);
            CheckBox chk = null;
            Label lblinstrid = default(Label);
            int Sum = 0;
            lblinstrid = null;
            string Payeeid = "";


            Slipno = txtdepositslipno.Text;
            Chkcnt = Convert.ToInt32(  txtnoofinstr.Text);
            TotalChkAmt = Convert.ToDecimal(txtslipamt.Text);
                        
            //CenterHeader = ddlcenterSlip.SelectedValue;
            //if (CenterHeader == "Select")
            //{
            //    divErrormessage.Visible =true;
            //    lblerrormessage.Visible =true;
            //    lblerrormessage .Text="Center Not Selected";
            //}
            //else
            //{
            //    Division = ddlAddSlipDivision.SelectedValue;//CenterHeader.Substring(0, 2);
            //    divErrormessage.Visible = false;                
            //}
           // Payeeid = ddlpayeeadd.SelectedValue;
            Payeeid = "10001";//MTEducare

            int Flag = 1;

            string ChequeIDNo = "";
            //string Slipid = AccountController.InsertDepositSlip(Slipno, Chkcnt, TotalChkAmt, Chkdate, 0, Acadyear, Chkno, Chkid, SBentrycode, CenterHeader,
            //Division, UserID, Flag, Payeeid);
            string Slipid1 = "";
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
                Slipid1 = AccountController.Insert_ECSDispatchslip_details(Flag, txtdepositslipno.Text, CenterHeader, Division, Chkdate, Chkcnt, TotalChkAmt, 0, Payeeid, UserID, ChequeIDNo);
                //Flag = 2;
                //Slipid1 = AccountController.Insert_ECSDispatchslip_details(Flag, txtdepositslipno.Text, CenterHeader, Division, Chkdate, Chkcnt, TotalChkAmt, 0, Payeeid, UserID, ChequeIDNo);
            }
            catch (Exception ex)
            {
            }
            
            BindSlipno();
            Bindlist();
            //BindPayeeadd();
            divErrormessage.Visible = false;
            divSuccessmessage.Visible = true;
            lblsuccessMessage.Visible = true;
            lblsuccessMessage.Text = "Dispatch Successfully Created";
            txtnoofinstr.Text = "0";
            txtslipamt.Text = "0.00";
            BindECSDeposit_ExcelUpload(Slipid1);
           // btnmakeCMSButton.Visible = true;
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
        lblpagetitle1.Text = "ECS Dispatch Management";
        lblpagetitle2.Text = "";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlsearch.Visible = true;
        UpnladdCMS.Visible = false;
        divmakecmserror.Visible = false;
        btnmakeCMSButton.Visible = true;
    }


    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Company = "MT";
        string Division = "";
        string Zone = "All";
        string Center = "All";
        string Fromdate = "";
        string Todate = "";
        string Payeeid = "10001";
        string Slipno = "";

       // Company = ddlcompany.SelectedValue;
        Division = ddldivision.SelectedValue;
       // Zone = ddlzone.SelectedValue;
        //Center = ddlcenter.SelectedValue;
        Fromdate = txtfromdate.Value;
        Todate = txttodate.Value;
        //Payeeid = ddlpayee.SelectedValue;
        Slipno = txtslipnosearch.Text;

        DataSet ds = AccountController.Get_ECS_DispatchSlip(Company, Division, Zone, Center, Fromdate, Todate, UserID, Payeeid, Slipno);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "ECS Dispatch";
            lblpagetitle2.Text = "Search Results";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            divmessage.Visible = false;
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            btnBackECSSearch.Visible = true;
           // script1.RegisterAsyncPostBackControl(Repeater1);
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            divmessage.Visible = true;
            lblmessage.Text = "No Records Found!";
        }

    }


    protected void btnClear_ServerClick(object sender, System.EventArgs e)
    {
        ddldivision.SelectedIndex = 0;
        //ddlcenter.Items.Clear();
        //ddlcenter.Items.Insert(0, "Select");
        //ddlcenter.SelectedIndex = 0;
        txtslipnosearch.Text = "";
        txtfromdate.Value = "";
        txttodate.Value = "";
    }

    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ExcelUpload")
        {
            BindECSDeposit_ExcelUpload(e.CommandArgument.ToString());
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

    

    private void BindECSDeposit_ExcelUpload(string DispatchSlipCode)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        DataSet ds = ProductController.Get_ECS_DepositExcelDownload(DispatchSlipCode,UserID, "1");//string DispatchSlipCode, string User_Code, string Flag

        if (ds != null)
        {
            GridView GridView1 = new GridView();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=ECS_Deposit_" + DateTime.Now + ".xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string style = @"<style> td { mso-number-format:\@;} </style>";
            Response.Write(style);
            Response.Write(sw.ToString());
            Response.End();

        }//complete if  (ds != null)
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