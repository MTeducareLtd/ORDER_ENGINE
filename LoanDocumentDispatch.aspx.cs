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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;

public partial class LoanDocumentDispatch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Menuid = "117";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            lblpagetitle1.Text = "Loan Dispatch Management";
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
            BindCompany();
            //BindLDDCenter();
            BindAddDivision();
            //BindPayee();
            //System.Threading.Thread.Sleep(1000);
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
        ddlcompany.Items.Insert(0, "Select");
        ddlcompany.SelectedIndex = 0;

        //ddldivision.Items.Insert(0, "Select");
        //ddldivision.SelectedIndex = 0;

        //ddlzone.Items.Insert(0, "All");
        //ddlzone.SelectedIndex = 0;

        //ddlcenter.Items.Insert(0, "All");
        //ddlcenter.SelectedIndex = 0;

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
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;
    }


    private void BindAddDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddlDivisionAdd, ds, "Division_Name", "Division_Code");
        ddlDivisionAdd.Items.Insert(0, "Select");
        ddlDivisionAdd.SelectedIndex = 0;
    }


    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
        //BindPayee();
    }

    protected void ddlDivisionAdd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindAddZone();        
    }
    

    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "Select");
        ddlzone.SelectedIndex = 0;
    }

    private void BindAddZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddlDivisionAdd.SelectedValue, "", "MT");
        BindDDL(ddlZoneAdd, ds, "Zone_Name", "Zone_Code");
        ddlZoneAdd.Items.Insert(0, "Select");
        ddlZoneAdd.SelectedIndex = 0;
    }
    protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }

    protected void ddlZoneAdd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindAddCenter();
    }

    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddldivision.SelectedValue, ddlzone.SelectedValue, ddlcompany.SelectedValue);
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "Select");
        ddlcenter.SelectedIndex = 0;
    }

    private void BindAddCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddlDivisionAdd.SelectedValue, ddlZoneAdd.SelectedValue, "MT");
        BindDDL(ddlcenterSlip, ds, "Center_name", "Center_Code");
        ddlcenterSlip.Items.Insert(0, "Select");
        ddlcenterSlip.SelectedIndex = 0;
    }

    private void BindLDDCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(13, UserID, "", "", "");
        BindDDL(ddlcenterSlip, ds, "Center_name", "Center_Code");
        ddlcenterSlip.Items.Insert(0, "Select");
        ddlcenterSlip.SelectedIndex = 0;
    }
    //private void BindPayee()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = AccountController.Getallpayeebycompanydivision(ddlcompany.SelectedValue , ddldivision .SelectedValue );
    //    BindDDL(ddlpayee, ds, "Payee_Name", "payee_id");
    //    ddlpayee.Items.Insert(0, "Select");
    //    ddlpayee.SelectedIndex = 0;
    //}



    protected void btnmakeLDMS_ServerClick(object sender, System.EventArgs e)
    {
        lblpagetitle1.Text = "Add Loan Dispatch";
        lblpagetitle2.Text = "";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlsearch.Visible = false;
        UpnladdCMS.Visible = true;
        divmakecmserror.Visible = false;
        divmessage.Visible = false;
        //txtdispatchDate.Text = "";

        ddlDivisionAdd.SelectedIndex = 0;
        ddlZoneAdd.Items.Clear();
        ddlcenterSlip.Items.Clear();
        //ddlcenterSlip.SelectedIndex = 0;
        txtnoofinstr.Text = "";
        //txtslipamt.Text = "";
        //txtdispatchDate.Text = "";
        txtdispatchDate.Text = DateTime.Today.ToString("dd-MM-yyyy");        
        lbldateerrordob.Text = "";
        txtnoofinstr.Text = "0";
        //txtslipamt.Text = "0";
      //  txtdispatchDate.Text = DateTime.Now.ToString("dd-MM-yyyy");        
        BindSlipno();
        Bindlist();
    }

    protected void btnSearchLDMS_ServerClick(object sender, System.EventArgs e)
    {
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        UpnladdCMS.Visible = false;
        divmakecmserror.Visible = false;
        divmessage.Visible = false;
        lblpagetitle1.Text = "Loan Dispatch Management";
        lblpagetitle2.Text = "";
        //divSuccessmessage.Visible = false;
        //divErrormessage.Visible = false;
        //upnlsearch.Visible = false;
        //UpnladdCMS.Visible = true;
        //divmakecmserror.Visible = false;
        //txtdispatchDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        //BindSlipno();
        //Bindlist();
    }

    private void BindSlipno()
    {
        if (txtdepositslipno.Text == "")
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            int Flag = 0;
            string Center = "";
            string Slip = "";
            Flag = 3;
            Center = ddlcenterSlip.SelectedValue;
            string Payeeid = "";
            //Payeeid = ddlpayeeadd.SelectedValue;
            string paymode = "";
            //paymode = ddlpaymode.SelectedValue;
            string Slipno = AccountController.GetSlipno(Flag, Center, UserID, Slip, Payeeid, paymode);
            txtdepositslipno.Text = Slipno;
        }

    }
    private void Bindlist()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Flag = "1";
        string Center = "";             
        Center = ddlcenterSlip.SelectedValue;

        txtnoofinstr.Text = "0";
        //txtslipamt.Text = "0";

        DataSet ds = AccountController.GetLoan_ForDispatch(Flag, Center);
        if (ds.Tables[0].Rows.Count > 0)
        {            
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
            lblrecordcount.Text = "0";
            lblmakecmserror.Text = "No Pending Loan!";
        }

    }

    protected void ddlcenterSlip_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // ddlpaymode.SelectedValue = "04";
        //BindPayeeadd();
        //dlreceipts.Visible = false;
        Bindlist();
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

    protected void ddlpayeeadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Bindlist();
        txtnoofinstr.Text = "";
        //txtslipamt.Text = "";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
    }

    protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindPayeeadd();
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
    }

    private void GetSumvalue()
    {
        Object obj = default(Object);
        Object obj1 = default(Object);
        CheckBox chk = null;
        Label lblsid = default(Label);
        decimal Sum = 0;
        int Count = 0;

        //txtslipamt.Text = "0";
        txtnoofinstr.Text = "0";

        foreach (DataListItem li in dlreceipts.Items)
        {
            obj = li.FindControl("checkpoint");
            if (obj != null)
            {
                chk = (CheckBox)obj;
            }

            obj = li.FindControl("lblos");
            if (obj != null)
            {
                lblsid = (Label)obj;
            }
            if (chk.Checked == true)
            {
                //try
                //{
                //    Sum = Sum + Convert.ToDecimal(lblsid.Text);
                //}
                //catch (Exception ex)
                //{

                //}
                //txtslipamt.Text = Sum.ToString();
                Count = Count + 1;
                txtnoofinstr.Text = Count.ToString();
            }
        }
    }

    protected void btnsave_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            divmessage.Visible = false;
            lbldateerrordob.Text = "";
            if (txtdispatchDate.Text == "")
            {
                lbldateerrordob.Visible = true;
                lbldateerrordob.Text = "Dispatch date cannot be Blank";
                //txtdispatchDate.Focus();
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

        String SbEntryCode = "";

        foreach (DataListItem li in dlreceipts.Items)
        {
            CheckBox checkpoint = (CheckBox)li.FindControl("checkpoint");
            if (checkpoint.Checked == true)
            {
                Label lblSbEntryCode = (Label)li.FindControl("lblSbEntryCode");                
                SbEntryCode = SbEntryCode + lblSbEntryCode.Text + ",";
            }
        }
        if (SbEntryCode == "")
        {              
            divmessage.Visible = true;
            lblmessage.Text = "Atleast one Student should be selected";
            return;
        }
        SbEntryCode = SbEntryCode.Substring(0, SbEntryCode.Length - 1);
        string CenterCode=ddlcenterSlip.SelectedValue; 
        
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];             
        string ResultID = AccountController.InsertLoanDispatchslip_details("1", "", CenterCode, txtdepositslipno.Text, txtdispatchDate.Text, txtnoofinstr.Text, "0", SbEntryCode, UserID);
        if (ResultID == "1")
        {
            txtdepositslipno.Text = "";
            divSuccessmessage.Visible = true;            
            lblsuccessMessage.Text = "Record Saved Successfully...!";

            lblpagetitle1.Text = "Dispatch Management";
            lblpagetitle2.Text = "";
            divErrormessage.Visible = false;
            upnlsearch.Visible = true;
            Divsearchcriteria.Visible = true;
            UpnladdCMS.Visible = false;
            divmakecmserror.Visible = false;
        }
        else
        {
            divSuccessmessage.Visible = false;            
            divErrormessage.Visible = false;
            divmakecmserror.Visible = false;
            divmessage.Visible = true;
            lblmessage.Text = "Reord Not Saved...!";


        }
        
        //string Slipid = AccountController.InsertDispatchslip_details(Flag, "", CenterHeader, Division, Chkdate, Chkcnt, TotalChkAmt, 0, Payeeid, UserID, ChequeIDNo);
    }

    protected void btnCloseAdd_ServerClick(object sender, System.EventArgs e)
    {
        lblpagetitle1.Text = "Dispatch Management";
        lblpagetitle2.Text = "";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = true;
        UpnladdCMS.Visible = false;
        divmakecmserror.Visible = false;

    }

    protected void btnClear_ServerClick(object sender, System.EventArgs e)
    {
        ddlcompany.SelectedIndex = 0;
        ddldivision.Items.Clear();
        ddlzone.Items.Clear();
        ddlcenter.Items.Clear();
        txtslipnosearch.Text = "";
        txtfromdate.Value = "";
        txttodate.Value = "";        
    }


    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        divErrormessage.Visible = false;
        divSuccessmessage.Visible = false;
        divmessage.Visible = false;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        //string Company = "";
        string Division = "";
        //string Zone = "";
        string Center = "";
        string Fromdate = "";
        string Todate = "";
        //string Payeeid = "";
        string Slipno = "";

        //Company = ddlcompany.SelectedValue;
        Division = ddldivision.SelectedValue;
        //Zone = ddlzone.SelectedValue;
        Center = ddlcenter.SelectedValue;
        Fromdate = txtfromdate.Value;
        Todate = txttodate.Value;
        //Payeeid = ddlpayee.SelectedValue;
        Slipno = txtslipnosearch.Text;

        if (txttodate.Value != "")
        {            
            Todate = (DateTime.Parse(txttodate.Value).AddDays(1)).ToString();
        }

        DataSet ds = AccountController.GetLoanDispatchSlip(Division, Center, Fromdate, Todate, UserID, Slipno);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Loan Dispatch";
            lblpagetitle2.Text = "Search Results";            
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
        if (e.CommandName == "Print")
        {
            lblSlipNo.Text = e.CommandArgument.ToString();
            checkCentre.Checked = false;
            DataSet ds = AccountController.GetLoanDispatchDetailsbySlipno(2, e.CommandArgument.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlPrintStudent.DataSource = ds.Tables[1];
                dlPrintStudent.DataBind();
            }
            upnlPrint.Update();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalPrint();", true);
        }
    }


    protected void btnPrintTest_Click(object sender, EventArgs e)
    {
        try
        {
            //Create PDF
            // Create a Document object
            dynamic document = new Document(PageSize.A4.Rotate(), 50, 50, 25, 25);


            // Create a new PdfWriter object, specifying the output stream
            dynamic output = new MemoryStream();
            dynamic writer = PdfWriter.GetInstance(document, output);


            dynamic TitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
            dynamic subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            dynamic boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            dynamic endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            dynamic bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);


            // Open the Document for writing
            document.Open();

            //Print OverAll Loan Document Dispatch 
            float YPos = 0;
            YPos = 400;

            //dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/logoNew.jpg"));
            //logo.SetAbsolutePosition(25, YPos);
            //logo.ScalePercent(60);
            //document.Add(logo);

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/logoNew.jpg"));
            jpg.ScaleToFit(980, 580);
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
            jpg.SetAbsolutePosition(10, 10);
            document.Add(jpg);

            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            PdfContentByte cb = writer.DirectContent;
            cb.BeginText();
            cb.SetTextMatrix(200, YPos + 20);
            cb.SetFontAndSize(bf, 16);

            //cb.SetLineWidth(0.5f);
            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);

            cb.ShowText("Digambar Kadam");
            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
            YPos = YPos - 0;

            //cb.SetColorStroke(new CMYKColor(1f, 1f, 1f, 1f));
            //cb.SetLineWidth(0.5f);

            cb.EndText();

            document.Close();

            string CurTimeFrame = null;
            CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Testing{0}.pdf", CurTimeFrame));
            Response.BinaryWrite(output.ToArray());
        }
        catch (Exception ex)
        {

            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.ToString();
        }
    }

    protected void btnbtnPrintOK_Click(object sender, EventArgs e)
    {

        try
        {

            int PrintCentreFlag = 0;
           
            if (checkCentre.Checked == true)
            {
                PrintCentreFlag = 1;
            }
            else
            {
                PrintCentreFlag = 0;
            }

            String SbEntryCode = "";

            foreach (DataListItem li in dlPrintStudent.Items)
            {
                CheckBox checkStudent = (CheckBox)li.FindControl("checkStudent");
                if (checkStudent.Checked == true)
                {
                    Label lblSbEntryCode = (Label)li.FindControl("lblSbEntryCode");
                    SbEntryCode = SbEntryCode + lblSbEntryCode.Text + ",";
                }
            }

            if ((SbEntryCode == "") && (PrintCentreFlag==0))
            {
                divmessage.Visible = true;
                lblmessage.Text = "Atleast one Student should be selected";
                return;
            }
            if (SbEntryCode!="")
            {
                SbEntryCode = SbEntryCode.Substring(0, SbEntryCode.Length - 1);
            }
           //Create PDF
            // Create a Document object
            dynamic document = new Document(PageSize.A4, 50, 50, 25, 25);
            
            
            // Create a new PdfWriter object, specifying the output stream
            dynamic output = new MemoryStream();
            dynamic writer = PdfWriter.GetInstance(document, output);


            dynamic TitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
            dynamic subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            dynamic boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            dynamic endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            dynamic bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);


            // Open the Document for writing
            document.Open();
            //document.NewPage();
            if (PrintCentreFlag == 1)
            {
                DataSet ds = AccountController.GetLoanDispatchDetailsbySlipno(2, lblSlipNo.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblCentreName.Text = ds.Tables[0].Rows[0]["Center_Name"].ToString();
                    lblDivisionName.Text = ds.Tables[0].Rows[0]["Division"].ToString();
                    lblslipdate.Text = ds.Tables[0].Rows[0]["LoanDispatchDate"].ToString();
                    lblBankname.Text = ds.Tables[0].Rows[0]["BankName"].ToString();

                    dlLoanDisp.DataSource = ds.Tables[1];
                    dlLoanDisp.DataBind();
                    UpnlprintCentre.Update();

                    //Print OverAll Loan Document Dispatch 
                    float YPos = 0;
                    YPos = 780;

                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/logo.jpg"));
                    logo.SetAbsolutePosition(25, YPos);
                    logo.ScalePercent(60);
                    document.Add(logo);

                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                    PdfContentByte cb = writer.DirectContent;
                    cb.BeginText();
                    cb.SetTextMatrix(200, YPos + 20);
                    cb.SetFontAndSize(bf, 16);

                    cb.SetLineWidth(0.5f);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);

                    cb.ShowText(lblBankname.Text);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    YPos = YPos - 0;

                    cb.SetColorStroke(new CMYKColor(1f, 1f, 1f, 1f));
                    cb.SetLineWidth(0.5f);

                    cb.EndText();
                    cb.MoveTo(20, YPos);
                    cb.LineTo(570, YPos);
                    cb.Stroke();

                    YPos = YPos - 15;

                    cb.BeginText();
                    cb.SetTextMatrix(25, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("Centre Name : ");

                    cb.SetTextMatrix(120, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
                    cb.ShowText(lblCentreName.Text);

                    cb.SetTextMatrix(225, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.ShowText("Div: ");

                    cb.SetTextMatrix(275, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
                    cb.ShowText(lblDivisionName.Text);

                    cb.SetTextMatrix(425, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                    cb.ShowText("Date : ");

                    cb.SetTextMatrix(475, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
                    cb.ShowText(lblslipdate.Text);
                    cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                    cb.EndText();

                    float TableStartYPos = 0;
                    cb.MoveTo(20, YPos - 10);
                    cb.LineTo(570, YPos - 10);
                    cb.Stroke();
                    TableStartYPos = YPos - 10;

                    YPos = YPos - 25;

                    
                    float Col0Left = 0;
                    float Col1Left = 0;
                    //float Col2Left = 0;
                    float Col3Left = 0;
                    //float Col4Left = 0;
                    float Col5Left = 0;
                    float Col6Left = 0;
                    float Col7Left = 0;
                    float Col8Left = 0;
                    

                    Col0Left = 25;
                    Col1Left = Col0Left + 15;
                    //Col2Left = Col1Left + 120;
                    Col3Left = Col1Left + 150;
                    //Col4Left = Col3Left + 50;
                    Col5Left = Col3Left + 80;
                    Col6Left = Col5Left + 180;
                    Col7Left = Col6Left + 50;
                    Col8Left = 570;
                    
                    cb.BeginText();


                    cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (cb.GetEffectiveStringWidth("Sr   ", false) / 2)), YPos);
                    //cb.SetTextMatrix(Col0Left, YPos);
                    cb.SetFontAndSize(bf,10);
                    cb.ShowText("Sr");

                    cb.SetTextMatrix((Col1Left + ((Col3Left - Col1Left) / 2) - (cb.GetEffectiveStringWidth("Name Of Student", false) / 2)), YPos);
                    //cb.SetTextMatrix(Col1Left, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("Name Of Student");

                    //cb.SetTextMatrix(Col2Left, YPos);
                    //cb.SetFontAndSize(bf, 10);
                    //cb.ShowText("Name Of Applicant");

                    cb.SetTextMatrix((Col3Left + ((Col5Left - Col3Left) / 2) - (cb.GetEffectiveStringWidth("SBEntry Code", false) / 2)), YPos);
                    //cb.SetTextMatrix(Col3Left, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("SBEntry Code");

                    //cb.SetTextMatrix(Col4Left, YPos);
                    //cb.SetFontAndSize(bf, 10);
                    //cb.ShowText("Centre Name");

                    cb.SetTextMatrix((Col5Left + ((Col6Left - Col5Left) / 2) - (cb.GetEffectiveStringWidth("SBEntry Code", false) / 2)), YPos);
                    //cb.SetTextMatrix(Col5Left, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("Stream Name");

                    cb.SetTextMatrix(Col6Left, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(" Total Fee");

                    cb.SetTextMatrix(Col7Left, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("Down Payment");

                    cb.SetTextMatrix(Col8Left, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("");
                    cb.EndText();

                    cb.MoveTo(20, YPos - 5);
                    cb.LineTo(570, YPos - 5);
                    cb.Stroke();

                    foreach (DataListItem dtlItem1 in dlLoanDisp.Items)
                    {
                        Label lblSrNo = (Label)dtlItem1.FindControl("lblSrNo");
                        Label lblstudentname = (Label)dtlItem1.FindControl("lblstudentname");
                        Label lblApplicantname = (Label)dtlItem1.FindControl("lblApplicantname");
                        Label lblSBEntryCode = (Label)dtlItem1.FindControl("lblSBEntryCode");
                        Label lblstudCentreName = (Label)dtlItem1.FindControl("lblstudCentreName");
                        Label lblStream = (Label)dtlItem1.FindControl("lblStream");
                        Label lblTotalFee = (Label)dtlItem1.FindControl("lblTotalFee");
                        Label lblDownPaymentAmount = (Label)dtlItem1.FindControl("lblDownPaymentAmount");

                        YPos = YPos - 20;
                        cb.BeginText();

                        
                        cb.SetTextMatrix(Col0Left, YPos);
                        cb.SetFontAndSize(bf, 8);
                        cb.ShowText(lblSrNo.Text);

                        cb.SetTextMatrix(Col1Left, YPos);
                        cb.SetFontAndSize(bf, 8);
                        cb.ShowText(lblstudentname.Text);

                        //cb.SetTextMatrix(Col2Left, YPos);
                        //cb.SetFontAndSize(bf, 8);
                        //cb.ShowText(lblApplicantname.Text);

                        cb.SetTextMatrix(Col3Left, YPos);
                        cb.SetFontAndSize(bf, 8);
                        cb.ShowText(lblSBEntryCode.Text);

                        //cb.SetTextMatrix(Col4Left, YPos);
                        //cb.SetFontAndSize(bf, 8);
                        //cb.ShowText(lblstudCentreName.Text);

                        cb.SetTextMatrix(Col5Left, YPos);
                        cb.SetFontAndSize(bf, 8);
                        cb.ShowText(lblStream.Text);

                        cb.SetTextMatrix((Col6Left + ((Col7Left - Col6Left) / 1) - (cb.GetEffectiveStringWidth(lblTotalFee.Text + " ", false) / 1)), YPos);
                        //cb.SetTextMatrix(Col6Left, YPos);
                        cb.SetFontAndSize(bf, 8);
                        cb.ShowText(lblTotalFee.Text);

                        cb.SetTextMatrix((Col7Left + ((Col8Left - Col7Left) / 1) - (cb.GetEffectiveStringWidth(lblDownPaymentAmount.Text + " ", false) / 1)), YPos);
                        //cb.SetTextMatrix(Col7Left, YPos);
                        cb.SetFontAndSize(bf, 8);
                        cb.ShowText(lblDownPaymentAmount.Text);

                        cb.SetTextMatrix(Col8Left, YPos);
                        cb.SetFontAndSize(bf, 8);
                        cb.ShowText("");

                        cb.EndText();

                        cb.MoveTo(20, YPos - 5);
                        cb.LineTo(570, YPos - 5);
                        cb.Stroke();
                        
                    }

                    cb.MoveTo(20, TableStartYPos);
                    cb.LineTo(20, YPos - 5);
                    cb.Stroke();

                    //cb.MoveTo(Col0Left - 5, TableStartYPos);
                    //cb.LineTo(Col1Left - 5, YPos - 5);
                    //cb.Stroke();

                    cb.MoveTo(Col1Left - 5, TableStartYPos);
                    cb.LineTo(Col1Left - 5, YPos - 5);
                    cb.Stroke();

                    //cb.MoveTo(Col2Left - 5, TableStartYPos);
                    //cb.LineTo(Col2Left - 5, YPos - 5);
                    //cb.Stroke();

                    cb.MoveTo(Col3Left-5, TableStartYPos);
                    cb.LineTo(Col3Left-5, YPos - 5);
                    cb.Stroke();

                    //cb.MoveTo(Col4Left, TableStartYPos);
                    //cb.LineTo(Col4Left, YPos - 5);
                    //cb.Stroke();

                    cb.MoveTo(Col5Left-5, TableStartYPos);
                    cb.LineTo(Col5Left-5, YPos - 5);
                    cb.Stroke();

                    cb.MoveTo(Col6Left, TableStartYPos);
                    cb.LineTo(Col6Left, YPos - 5);
                    cb.Stroke();

                    cb.MoveTo(Col7Left, TableStartYPos);
                    cb.LineTo(Col7Left, YPos - 5);
                    cb.Stroke();

                    cb.MoveTo(Col8Left, TableStartYPos);
                    cb.LineTo(Col8Left, YPos - 5);
                    cb.Stroke();

                }
                document.NewPage();
            }

            //For each Student selected in list 
            if (SbEntryCode != "")
            {
                foreach (DataListItem dtlItem in dlPrintStudent.Items)
                {
                    CheckBox checkStudent = (CheckBox)dtlItem.FindControl("checkStudent");
                    Label lblSbEntryCode = (Label)dtlItem.FindControl("lblSbEntryCode");
                    if (checkStudent.Checked == true)
                    {
                        DataSet dsStudentSlip = AccountController.GetStudentLoanDetails(1, lblSbEntryCode.Text);
                        if (dsStudentSlip.Tables[0].Rows.Count > 0)
                        {
                            lblSBEntryCode.Text = dsStudentSlip.Tables[0].Rows[0]["SbEntryCode"].ToString();
                            lblStudName.Text = dsStudentSlip.Tables[0].Rows[0]["Stud_NAME"].ToString();
                            lblDate.Text = dsStudentSlip.Tables[0].Rows[0]["Date"].ToString();
                            lblStudCentreName.Text = dsStudentSlip.Tables[0].Rows[0]["Source_center_name"].ToString();
                            lblStreamName.Text = dsStudentSlip.Tables[0].Rows[0]["Stream"].ToString();
                            lblAddress.Text = dsStudentSlip.Tables[0].Rows[0]["StudAddress"].ToString();
                            lblDivision.Text = dsStudentSlip.Tables[0].Rows[0]["Division"].ToString();
                           
                            rptReceiptDetail.DataSource = dsStudentSlip.Tables[1];
                            rptReceiptDetail.DataBind();
                           
                            rptStudTotal.DataSource = dsStudentSlip.Tables[2];
                            rptStudTotal.DataBind();

                            lblTotalAmtInWord.Text = dsStudentSlip.Tables[3].Rows[0]["TotalAmounInWord"].ToString();
                           
                            //decimal Amtinwords = decimal.Parse(dsStudentSlip.Tables[3].Rows[0]["TotalAmounInWord"].ToString());
                            
                            //decimal a1 = Amtinwords;
                            //string Inwords = "Rupees" + " " + GetInWords(a1);
                            String txt = lblTotalAmtInWord.Text;
                            String NewString = txt.Remove(txt.Length - 3, 3);
                            lblTotalAmtInWord.Text = NewString;
                            string Inwords = ConvertNumbertoWords(Convert.ToInt32(lblTotalAmtInWord.Text));
                            lblTotalAmtInWord.Text = Inwords;
                            UpnlPrintStudent.Update();
                        }
                        //Print Student Detail

                        float YPos = 0;
                        YPos = 780;

                        dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/logo.jpg"));
                        logo.SetAbsolutePosition(25, YPos);
                        logo.ScalePercent(60);
                        document.Add(logo);

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        PdfContentByte cb = writer.DirectContent;
                        cb.BeginText();
                        cb.SetTextMatrix(150, YPos + 20);
                        cb.SetFontAndSize(bf, 16);

                        cb.SetLineWidth(0.5f);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);

                        cb.ShowText("MT-EDUCARE LIMITED - " + lblDivision.Text);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        YPos = YPos - 0;

                        cb.SetColorStroke(new CMYKColor(1f, 1f, 1f, 1f));
                        cb.SetLineWidth(0.5f);

                        cb.EndText();
                        cb.MoveTo(20, YPos);
                        cb.LineTo(570, YPos);
                        cb.Stroke();

                        YPos = YPos - 15;

                        cb.BeginText();
                        cb.SetTextMatrix(25, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("Corporate Office:-220,2nd Floor, Flying Colors, Pandit Din Dayal Upadhyay Marg, Mulund (West) ,Mumbai 400080, INDIA");                      
                        
                        YPos = YPos - 15;

                        cb.SetColorStroke(new CMYKColor(1f, 1f, 1f, 1f));
                        cb.SetLineWidth(0.5f);

                        cb.EndText();
                        cb.MoveTo(20, YPos);
                        cb.LineTo(570, YPos);
                        cb.Stroke();

                        YPos = YPos - 15;
                        cb.BeginText();
                        cb.SetTextMatrix(225, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
                        cb.ShowText("DOWN PAYMENT RECEIPT");
                        cb.EndText();

                        cb.MoveTo(220, YPos - 2);
                        cb.LineTo(360, YPos-2);
                        cb.Stroke();

                        YPos = YPos - 15;

                        cb.SetColorStroke(new CMYKColor(1f, 1f, 1f, 1f));
                        cb.SetLineWidth(0.5f);

                        
                        cb.MoveTo(20, YPos);
                        cb.LineTo(570, YPos);
                        cb.Stroke();

                        YPos = YPos - 15;
                        
                        cb.BeginText();
                        cb.SetTextMatrix(25, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("SB Entry Code:-");

                        cb.SetTextMatrix(100, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText(lblSBEntryCode.Text);

                        cb.SetTextMatrix(200, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("Student Name:-");

                        cb.SetTextMatrix(275, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText(lblStudName.Text);

                        cb.SetTextMatrix(475, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("Date:-");

                        cb.SetTextMatrix(510, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText(lblDate.Text);

                        cb.EndText();

                        YPos = YPos - 5;

                        cb.SetColorStroke(new CMYKColor(1f, 1f, 1f, 1f));
                        cb.SetLineWidth(0.5f);
                        

                        cb.MoveTo(20, YPos);
                        cb.LineTo(570, YPos);
                        cb.Stroke();                        

                        YPos = YPos - 15;
                        cb.BeginText();
                        cb.SetTextMatrix(25, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("Centre Name:-");

                        cb.SetTextMatrix(100, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText(lblStudCentreName.Text);

                        cb.SetTextMatrix(200, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("Stream Name:-");

                        cb.SetTextMatrix(275, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText(lblStreamName.Text);

                        cb.EndText();

                        YPos = YPos - 5;

                        cb.SetColorStroke(new CMYKColor(1f, 1f, 1f, 1f));
                        cb.SetLineWidth(0.5f);


                        cb.MoveTo(20, YPos);
                        cb.LineTo(570, YPos);
                        cb.Stroke();

                        YPos = YPos - 15;
                        cb.BeginText();
                        cb.SetTextMatrix(25, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("We hereby confirm that we have received the following down payment From");

                        cb.EndText();

                        YPos = YPos - 15;
                        cb.BeginText();
                        cb.SetTextMatrix(100, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText(lblStudName.Text);
                        
                        cb.EndText();

                        YPos = YPos - 15;
                        cb.BeginText();
                        cb.SetTextMatrix(100, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText(lblAddress.Text);

                        cb.EndText();

                        YPos = YPos - 5;

                        cb.SetColorStroke(new CMYKColor(1f, 1f, 1f, 1f));
                        cb.SetLineWidth(0.5f);

                        cb.MoveTo(20, YPos);
                        cb.LineTo(570, YPos);
                        cb.Stroke();

                        YPos = YPos - 15;
                        cb.BeginText();
                        cb.SetTextMatrix(25, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("Aggregating to Rs:- " + lblTotalAmtInWord.Text + " Only");

                        cb.EndText();
                        float TableStartYPos = 0;
                        cb.MoveTo(20, YPos - 10);
                        cb.LineTo(570, YPos - 10);
                        cb.Stroke();
                        TableStartYPos = YPos - 10;

                        YPos = YPos - 25;

                        float Col0Left = 0;
                        float Col1Left = 0;
                        float Col2Left = 0;
                        float Col3Left = 0;
                        float Col4Left = 570;
                        
                        Col0Left = 40;
                        Col1Left = Col0Left + 100;
                        Col2Left = Col1Left + 150;
                        Col3Left = Col2Left + 150;

                        cb.BeginText();
                        cb.SetTextMatrix(Col0Left, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("Date");

                        cb.SetTextMatrix(Col1Left, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("Chq/DD No/ TID-APPR code");

                        cb.SetTextMatrix(Col2Left, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("Bank/Branch");

                        cb.SetTextMatrix((Col3Left + ((Col4Left - Col3Left) / 1) - (cb.GetEffectiveStringWidth("Amount ", false) / 1)), YPos);
                        //cb.SetTextMatrix(Col3Left, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("Amount");

                        cb.EndText();

                        cb.MoveTo(20, YPos - 5);
                        cb.LineTo(570, YPos - 5);
                        cb.Stroke();

                        foreach (DataListItem dt1 in rptReceiptDetail.Items)
                        {
                            Label lblReceiptDate = (Label)dt1.FindControl("lblReceiptDate");
                            Label lblReceiptAmount = (Label)dt1.FindControl("lblReceiptAmount");
                            Label lblInstNo = (Label)dt1.FindControl("lblInstNo");
                            Label lblBankName = (Label)dt1.FindControl("lblBankName");

                            YPos = YPos - 20;
                            cb.BeginText();
                            cb.SetTextMatrix(Col0Left, YPos);
                            cb.SetFontAndSize(bf, 10);
                            cb.ShowText(lblReceiptDate.Text);

                            cb.SetTextMatrix(Col1Left, YPos);
                            cb.SetFontAndSize(bf, 10);
                            cb.ShowText(lblInstNo.Text);

                            cb.SetTextMatrix(Col2Left, YPos);
                            cb.SetFontAndSize(bf, 10);
                            cb.ShowText(lblBankName.Text);

                            cb.SetTextMatrix((Col3Left + ((Col4Left - Col3Left) / 1) - (cb.GetEffectiveStringWidth(lblReceiptAmount.Text + " ", false) / 1)), YPos);
                            //cb.SetTextMatrix(Col3Left, YPos);
                            cb.SetFontAndSize(bf, 10);
                            cb.ShowText(lblReceiptAmount.Text);

                            
                            
                            cb.EndText();

                            cb.MoveTo(20, YPos - 5);
                            cb.LineTo(570, YPos - 5);
                            cb.Stroke();
                        }
                        //

                        cb.MoveTo(20, TableStartYPos);
                        cb.LineTo(20, YPos - 5);
                        cb.Stroke();

                        cb.MoveTo(Col1Left - 5, TableStartYPos);
                        cb.LineTo(Col1Left - 5, YPos - 5);
                        cb.Stroke();

                        cb.MoveTo(Col2Left - 5, TableStartYPos);
                        cb.LineTo(Col2Left - 5, YPos - 5);
                        cb.Stroke();

                        cb.MoveTo(Col3Left, TableStartYPos);
                        cb.LineTo(Col3Left, YPos - 5);
                        cb.Stroke();

                        cb.MoveTo(Col4Left, TableStartYPos);
                        cb.LineTo(Col4Left, YPos - 5);
                        cb.Stroke();

                        
                        YPos = YPos - 10;


                        TableStartYPos = 0;
                        cb.MoveTo(20, YPos - 10);
                        cb.LineTo(570, YPos - 10);
                        cb.Stroke();
                        TableStartYPos = YPos - 10;

                        cb.BeginText();
                        cb.SetTextMatrix(350, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("");
                        //cb.ShowText("Total");
                        
                        cb.EndText();

                        //cb.MoveTo(20, YPos - 5);
                        //cb.LineTo(570, YPos - 5);
                        //cb.Stroke();
                        
                        Col2Left = 25;
                        Col3Left = Col2Left + 300;
                        foreach (DataListItem dt1 in rptStudTotal.Items)
                        {
                            Label lblField = (Label)dt1.FindControl("lblField");
                            Label lblGrossFees = (Label)dt1.FindControl("lblGrossFees");
                            
                            YPos = YPos - 20;
                            cb.BeginText();
                            cb.SetTextMatrix(Col2Left, YPos);
                            cb.SetFontAndSize(bf, 10);
                            cb.ShowText(lblField.Text);

                            cb.SetTextMatrix((Col3Left + ((Col4Left - Col3Left) / 1) - (cb.GetEffectiveStringWidth(lblGrossFees.Text + " ", false) / 1)), YPos);
                            //cb.SetTextMatrix(Col3Left, YPos);
                            cb.SetFontAndSize(bf, 10);
                            cb.ShowText(lblGrossFees.Text);

                            cb.EndText();

                            cb.MoveTo(20, YPos - 5);
                            cb.LineTo(570, YPos - 5);
                            cb.Stroke();
                        }

                        //cb.MoveTo(20, TableStartYPos);
                        //cb.LineTo(20, YPos - 5);
                        //cb.Stroke();
                        
                        cb.MoveTo(Col2Left - 5, TableStartYPos);
                        cb.LineTo(Col2Left - 5, YPos - 5);
                        cb.Stroke();

                        cb.MoveTo(Col3Left - 5, TableStartYPos);
                        cb.LineTo(Col3Left -5, YPos - 5);
                        cb.Stroke();

                        cb.MoveTo(Col4Left, TableStartYPos);
                        cb.LineTo(Col4Left, YPos - 5);
                        cb.Stroke();


                        cb.MoveTo(20, YPos - 10);
                        cb.LineTo(570, YPos - 10);
                        cb.Stroke();
                        YPos = YPos - 25;

                        //TableStartYPos = 0;
                        //cb.MoveTo(20, YPos - 10);
                        //cb.LineTo(570, YPos - 10);
                        //cb.Stroke();
                        //TableStartYPos = YPos - 10;

                       

                        cb.BeginText();
                        cb.SetTextMatrix(20, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("NOTE :-");

                        cb.EndText();
                                               

                        YPos = YPos - 20;

                        cb.BeginText();
                        cb.SetTextMatrix(20, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("Fees once paid will not be refunded under any circumstances.");

                        cb.EndText();

                        YPos = YPos - 15;

                        cb.BeginText();
                        cb.SetTextMatrix(20, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("This receipt is subject to realisation of cheques");

                        cb.EndText();

                        YPos = YPos - 15;
                        
                        cb.BeginText();
                        cb.SetTextMatrix(20, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("In case of cheque being dishonoured , a penalty of Rs 200/- will be levied for every default.");

                        cb.EndText();

                        YPos = YPos - 15;

                        cb.BeginText();
                        cb.SetTextMatrix(20, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText("The Institute reserves the right to take legal action against any dishonoured cheque.");

                        cb.SetTextMatrix(450, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
                        cb.ShowText("For MT Educare Limited");

                        cb.EndText();

                        YPos = YPos - 30;

                        cb.BeginText();
                        cb.SetTextMatrix(20, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("Service Tax Regn No: AAECM7770QST001");

                        cb.EndText();

                        YPos = YPos - 15;

                        cb.BeginText();
                        cb.SetTextMatrix(20, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                        cb.ShowText("CIN : L80903MH2006PLC163888");

                        cb.SetTextMatrix(465, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
                        cb.ShowText("Authorised Signatory");
                                              

                        cb.EndText();

                        document.NewPage();
                    }

                }
            }


            document.Close();

            string CurTimeFrame = null;
            CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename=LoanDocumentDispatch{0}.pdf", CurTimeFrame));
            Response.BinaryWrite(output.ToArray());
            

            //Response.Redirect("LoanDispatch_Print.aspx?Slip_No=" + lblSlipNo.Text + "&Centre=" + PrintCentreFlag + "&SbEntryCode=" + SbEntryCode + "");
            //LoanDispatch_Print.aspx?Slip_No={0}
        }
        catch (Exception ex)
        {

            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.ToString();
        }
    }


    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        //If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        //    Dim scriptManager__1 As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        //    scriptManager__1.RegisterPostBackControl(DirectCast(e.Item.FindControl("lnkviewdetails"), LinkButton))
        //End If
    }

    private void BindLDDDetails(string Slipno)
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


    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "Zero";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        //if ((number / 10000000) > 0)
        //{
        //    words += ConvertNumbertoWords(number / 10000000) + " Million ";
        //    number %= 10000000;
        //}
        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " Lakhs ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " Thousand ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " Hundred ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "AND ";
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }

    public string GetInWords(decimal num)
    {
        // ERROR: Not supported in C#: OnErrorStatement

        string str = null;
        long subnum = 0;
        TextBox Digits = new TextBox();
        str = "";
        Digits.Text = num.ToString();
        String txt = Digits.Text;
        String NewString = txt.Remove(txt.Length - 3, 3);
        Digits.Text = NewString;
        if (Digits.Text.Length > 11)
        {
            str = GetSubInWords(Convert.ToInt64(Digits.Text.Substring(1, Digits.Text.Length - 9)));

            Digits.Text = Digits.Text.Substring(Digits.Text.Length - 9, 9);
        }

        if (Digits.Text.Length == 11)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Billion ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Billion ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(9, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(10, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 10)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Billion ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Billion ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(8, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(9, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                // str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 9)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(8, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                // str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 8)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 7)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 6)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 5)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }

        if (Digits.Text.Length == 4)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";

        }
        if (Digits.Text.Length == 3)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";

        }
        if (Digits.Text.Length == 2 | Digits.Text.Length == 1)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 0)
        {
            str = "";
        }

        return str;

    }

    public string GetTens(long num)
    {
        // ERROR: Not supported in C#: OnErrorStatement

        switch ((num))
        {
            case 0:
                return ("");
            case 1:
                return ("One");
            case 2:
                return ("Two");
            case 3:
                return ("Three");
            case 4:
                return ("Four");
            case 5:
                return ("Five");
            case 6:
                return ("Six");
            case 7:
                return ("Seven");
            case 8:
                return ("Eight");
            case 9:
                return ("Nine");
            case 10:
                return ("Ten");
            case 11:
                return ("Eleven");
            case 12:
                return ("Twelve");
            case 13:
                return ("Thirteen");
            case 14:
                return ("Fourteen");
            case 15:
                return ("Fifteen");
            case 16:
                return ("Sixteen");
            case 17:
                return ("Seventeen");
            case 18:
                return ("Eighteen");
            case 19:

                return ("Nineteen");
        }

        return ("");

    }

    public string GetTwenty(long num)
    {
        // ERROR: Not supported in C#: OnErrorStatement

        switch ((num))
        {
            case 0:
                return ("");
            case 1:
                return ("One");
            case 2:
                return ("Twenty");
            case 3:
                return ("Thirty");
            case 4:
                return ("Forty");
            case 5:
                return ("Fifty");
            case 6:
                return ("Sixty");
            case 7:
                return ("Seventy");
            case 8:
                return ("Eighty");
            case 9:

                return ("Ninety");
        }
        return ("");
    }
    
    public string GetSubInWords(long num)
    {
        // ERROR: Not supported in C#: OnErrorStatement

        string str = null;
        long subnum = 0;
        TextBox Digits = new TextBox();
        str = "";
        Digits.Text = Convert.ToString(num);
        if (Digits.Text.Length == 11)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Billion ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Billion ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(9, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(10, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);

            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);

            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 10)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Billion ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Billion ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(8, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(9, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);

            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);

            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 9)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(8, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);

            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);

            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 8)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);

            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);

            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 7)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                // str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 6)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 5)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }

        if (Digits.Text.Length == 4)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 3)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 2 | Digits.Text.Length == 1)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 0)
        {
            str = "";
        }

        return str;
    }


}