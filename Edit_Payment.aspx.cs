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

public partial class Edit_Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (!IsPostBack)
            {
                string Menuid = "117";
                if (Request.Cookies["MyCookiesLoginInfo"] != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string UserID = cookie.Values["UserID"];
                    string UserName = cookie.Values["UserName"];
                   
                    //System.Threading.Thread.Sleep(1000);
                    Upnlviewledger.Visible = true;
                    Upnlprintreceipt.Visible = false;

                    lblpagetitle1.Text = "Edit Payments";
                    lblpagetitle2.Text = "";
                    //limidbreadcrumb.Visible = true;
                    lblmidbreadcrumb.Text = "Manage Payments";
                    //lilastbreadcrumb.Visible = true;
                    lbllastbreadcrumb.Text = "Edit Payments";
                    divSuccessmessage.Visible = false;
                    divErrormessage.Visible = false;
                    //lbltabname1.Text = "Student Ledger"
                    string Cur_Sb_Code = "";
                    Cur_Sb_Code = Request["Cur_sb_code"];
                    Session["CUR_SB_Code"] = Request["Cur_sb_code"];
                    diverrorPayment.Visible = false;
                    divSuccessPayment.Visible = false;
                    btnviewenrollment.Visible = true;
                    Bindlist(Cur_Sb_Code);
                    BindStudentSubjectGroup(Cur_Sb_Code);
                    Bindpayment(Cur_Sb_Code);
                    //BindPaymode()
                    BindStudentLedger();
                    BindChequeOutstanding();
                    //BindPayhead()

                    diveditpayemnt.Visible = false;
                    string oppid = txtopportunityid.Text;
                    HtmlAnchor viewenrollment = btnviewenrollment;
                    viewenrollment.HRef = "Enrollment_display.aspx?&Oppur_id=" + oppid;
                    dlpaymentreceipt.Visible = true;
                    divpayment.Visible = false;
                    txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    tblbankdetails.Visible = false;
                    tblcash.Visible = false;
                    tblcheque.Visible = false;
                    tblDD.Visible = false;
                    ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    SqlDataReader dr = UserController.Getuserrights(UserID, Menuid);
                    try
                    {
                        if ((((dr) != null)))
                        {
                            if (dr.Read())
                            {
                                int allowdisplay = Convert.ToInt32(dr["Allow_Add"].ToString());
                                
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                    }
                    string UserCompany = "";
                    SqlDataReader dr1 = UserController.GetCompanyby_Userid(UserID);
                    try
                    {
                        if ((((dr1) != null)))
                        {
                            if (dr1.Read())
                            {
                                UserCompany = dr1["Company_Code"].ToString();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                    lblusercompany.Text = UserCompany;
                    
                    diveditpayemnt.Visible = false;


                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }
            GetSumvalue();
            GetSumvaluedd();
            GetSumvaluecash();
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }


    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    
        
    public int Currentpage
    {
        get
        {
            object s1 = this.ViewState["Currentpage"];
            if (s1 == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(s1);
            }
        }
        set { this.ViewState["Currentpage"] = value; }
    }

    

    
    private void Bindlist(string Cursbcode)
    {

        try
        {

            string Hiphen = "-";
            SqlDataReader dr = AccountController.GetAccountdetailbycursbcode(1, Cursbcode);
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    string Gender = dr["GENDER"].ToString();
                    if (Gender == "M")
                    {
                        txtgender.Text = "Male";
                    }
                    else
                    {
                        txtgender.Text = "Female";
                    }
                    txtLstudentname.Text = dr["NAME"].ToString();

                    lblstudentname.Text = Hiphen + " " + dr["NAME"].ToString();
                    imgstudentphoto.ImageUrl = dr["stud_image"].ToString();
                    txtLappno.Text = dr["Student_App_No"].ToString();
                    txtopportunityid.Text = dr["oppor_id"].ToString();
                    txtaccountid.Text = dr["account_id"].ToString();
                    txtcursbcode.Text = dr["sbentrycode"].ToString();
                    BindLedgerCompany();
                    ddllcompany.SelectedValue = dr["companycode"].ToString();
                    BindLedgerDivision();
                    ddlldivision.SelectedValue = dr["divisioncode"].ToString();
                    BindLedgerCenter();
                    ddllcenter.SelectedValue = dr["center_code"].ToString();
                    BindLedgerAcademicYear();
                    ddllacadyear.SelectedValue = dr["Acad_Year"].ToString();
                    BindLedgerStream();
                    ddllstream.SelectedValue = dr["stream_code"].ToString();
                    txtpayplan.Text = dr["payplan"].ToString();
                    //BindLedgerCompany();
                    //ddllcompany.SelectedValue = dr["companycode"].ToString();
                    //BindLedgerDivision();
                    //ddlldivision.SelectedValue = dr["divisioncode"].ToString();
                    //BindLedgerCenter();
                    //ddllcenter.SelectedValue = dr["center_code"].ToString();
                    //BindLedgerAcademicYear();
                    //ddllacadyear.SelectedValue = dr["acad_year"].ToString();
                    //BindLedgerStream();
                    //ddllstream.SelectedValue = dr["stream_code"].ToString();
                    //txtpayplan.Text = dr["payplan"].ToString();
                    string Studentstatus = "";
                    Studentstatus = dr["Account_Status_id"].ToString();


                    //03-Pending
                    if (Studentstatus == "01")
                    {
                        listudentstatus.Visible = true;
                        //liregno.Visible = false;
                        lblstdstaus.Text = "Student Status : Pending";
                        //btnstatus.Attributes.Remove("Class");
                        //btnstatus.Attributes.Add("Class", "btn red");
                        btnproceedprint.Visible = false;


                        //BindDiscounttype()
                        //BindConcessiontype()

                    }
                    else if (Studentstatus == "03")
                    {
                        listudentstatus.Visible = true;

                        lblstdstaus.Text = "Student Status : Confirmed";
                        btnproceedprint.Visible = true;

                    }
                    else if (Studentstatus == "02")
                    {
                        listudentstatus.Visible = true;
                        //liregno.Visible = false;
                        lblstdstaus.Text = "Student Status : Cancelled";
                        //btnstatus.Attributes.Remove("Class");
                        //btnstatus.Attributes.Add("Class", "btn purple");
                        btnproceedprint.Visible = true;
                        btnaddpayment.Visible = false;

                    }
                }
            }
            txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    private void BindLedgerCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddllcompany, ds, "Company_Name", "Company_Code");
        ddllcompany.Items.Insert(0, "Select");
        ddllcompany.SelectedIndex = 0;
    }
    private void BindLedgerDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddllcompany.SelectedValue);
        BindDDL(ddlldivision, ds, "Division_Name", "Division_Code");
        ddlldivision.Items.Insert(0, "Select");
        ddlldivision.SelectedIndex = 0;
    }
    private void BindLedgerCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlldivision.SelectedValue, "", ddllcompany.SelectedValue);
        BindDDL(ddllcenter, ds, "Center_name", "Center_Code");
        ddllcenter.Items.Insert(0, "Select");
        ddllcenter.SelectedIndex = 0;
    }

    private void BindLedgerAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddllcenter.SelectedValue);
        BindDDL(ddllacadyear, ds, "Acad_Year", "Acad_Year");
        ddllacadyear.Items.Insert(0, "Select");
        ddllacadyear.SelectedIndex = 0;
    }
    private void BindLedgerStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddllcenter.SelectedValue, ddllacadyear.SelectedValue);
        BindDDL(ddllstream, ds, "Stream_Sdesc", "Stream_Code");
        ddllstream.Items.Insert(0, "Select");
        ddllstream.SelectedIndex = 0;
    }

    private void BindStudentSubjectGroup(string CurSbCode)
    {
        DataSet ds = AccountController.GetStudentSubjectgroupbyCursbcode(2, CurSbCode);
        lbsubjectgroup.DataSource = ds;
        lbsubjectgroup.DataTextField = "SGR_DESC";
        lbsubjectgroup.DataValueField = "sgr_material";
        lbsubjectgroup.DataBind();
    }

    private void BindPayhead()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPayheadbySBentrycode(Sbentrycode);
        BindDDL(ddlpayhead, ds, "Voucher_Description", "Pricing_Procedure_Code");
        ddlpayhead.Items.Insert(0, "Select");
        ddlpayhead.SelectedIndex = 0;
    }
    //Bind Payment

    private void Bindpayment(string CurSbCode)
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPaymentDetailsbySBEntrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            System.Threading.Thread.Sleep(1000);
            dlpaymentreceipt.DataSource = ds;
            dlpaymentreceipt.DataBind();
            diverrorPayment.Visible = false;
            lblerrorPayment.Visible = false;
        }
        else
        {
            diverrorPayment.Visible = true;
            lblerrorPayment.Visible = true;
            lblerrorPayment.Text = "No Payment Records Found!";
        }
    }

    protected void dlpaymentreceipt_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            dlpaymentreceipt.Visible = false;
            string Receiptid = e.CommandArgument.ToString();
            lblreceiptidedit.Text = Receiptid;
            Bindpaymodeedit();
            BindPayeeedit();
            BindChequeallocationEdit();
            Bindpaymentdata();
            diveditpayemnt.Visible = true;
        }
        else if (e.CommandName == "Remove")
        {
            lblnote.Text = "You are about to Remove a Receipt. Please confirm.";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#Removereceipt').modal('show') });</script>", false);
            string Receiptid = e.CommandArgument.ToString();
            lblchequeidno.Text = Receiptid;
        }
    }
    ///'''''''''''''''''Payment Management'''''''''''''''''''''''''''''''''''
    protected void dlpaymentreceipt_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
            scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkedit"));

            string Status = ((Label)e.Item.FindControl("lblchequestatus")).Text;
            if (Status == "Pending")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.IndianRed
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.DarkViolet;
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
            }
            else if (Status == "Deposited")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.RosyBrown
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.Blue;
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
            }
            else if (Status == "Cleared")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.Green
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.DarkCyan;
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
            }
            else if (Status == "Bounced")
            {
                //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.Red
                ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.Red;
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
            }
        }
    }
    protected void btncloseremoverpt_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#Removereceipt').modal('hide') });</script>", false);
    }
    protected void btnremovereceipt_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            DateTime Paydate = DateTime.Today;
            decimal Amtinstr = 0;
            string Sbentrycode = "";
            string Paymode = "";
            string PayInsnum = "";
            DateTime PayInsdate = DateTime.Today;
            string PayInsBankName = "";
            string InsStatus = "";
            string Inslocation = "";
            DateTime InsDepositdate = DateTime.Today;
            DateTime IDepositdate = DateTime.Today;
            DateTime InsBRSDate = DateTime.Today;
            DateTime IBRSdate = DateTime.Today;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string MicrCode = "";
            string PayHeadCode = "";
            string PayHeadDesc = "";
            DateTime Payidate = DateTime.Today;
            DateTime paydate1 = DateTime.Today;
            string Payeeid = "";
            string Chequeidno = lblchequeidno.Text;
            string cardtype = "";
            string cardno = "";
            Sbentrycode = txtcursbcode.Text;
            string Receiptid = AccountController.InsertPayment(4, Paydate.ToString("dd-Mmm-yyyy"), Amtinstr, Sbentrycode, Paymode, PayInsnum, Payidate.ToString("dd-Mmm-yyyy"), PayInsBankName, InsStatus, Inslocation,
            IDepositdate.ToString("dd-Mmm-yyyy"), IBRSdate.ToString("dd-Mmm-yyyy"), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Chequeidno,cardtype ,cardno );

            string Cur_sb_code = txtcursbcode.Text;
            Bindlist(Cur_sb_code);
            BindStudentSubjectGroup(Cur_sb_code);
            Bindpayment(Cur_sb_code);
            //BindPaymode()
            BindStudentLedger();
            BindChequeOutstanding();
            //BindPayhead()

            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    protected void btnaddpayment_ServerClick(object sender, System.EventArgs e)
    {

        try
        {

            dlpaymentreceipt.Visible = false;
            divpayment.Visible = true;
            txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtchequeamt.Text = "";
            txtchqno.Text = "";
            txtchqdate.Text = "";
            txtbankname.Text = "";
            txtddno.Text = "";
            txtdddate.Text = "";
            txtbankname.Text = "";
            txtbranchname.Text = "";
            txtmicrcode.Text = "";
            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblbankdetails.Visible = false;
            tblcash.Visible = false;
            diverrorPayment.Visible = false;
            lblerrorPayment.Visible = false;
            tr22.Visible = false;
            tr23.Visible = false;
            tr24.Visible = false;
            BindPaymode();
            BindChequeallocation();
            BindPayee();
            dlallocation.Visible = false;
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    private void BindChequeallocation()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.GetPPgroupbysbentrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            System.Threading.Thread.Sleep(1000);
            dlallocation.DataSource = ds;
            dlallocation.DataBind();
            //diverrorPayment.Visible = False
            //lblerrorPayment.Visible = False
        }
        else
        {
            //diverrorPayment.Visible = True
            //lblerrorPayment.Visible = True
            //lblerrorPayment.Text = "No Payment Records Found!"
        }
    }
    private void BindPaymode()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = AccountController.GetallPaymode();
        BindDDL(ddlpaymode, ds, "Description", "id");
        ddlpaymode.Items.Insert(0, "Select");
        ddlpaymode.SelectedIndex = 0;
    }
    private void BindPayee()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = AccountController.Getallpayee();
        BindDDL(ddlpayee, ds, "Payee_Name", "payee_id");
        ddlpayee.Items.Insert(0, "Select");
        ddlpayee.SelectedIndex = 0;
        BindDDL(ddlpayeedd, ds, "Payee_Name", "payee_id");
        ddlpayeedd.Items.Insert(0, "Select");
        ddlpayeedd.SelectedIndex = 0;
        BindDDL(ddlpayeecash, ds, "Payee_Name", "payee_id");
        ddlpayeecash.Items.Insert(0, "Select");
        ddlpayeecash.SelectedIndex = 0;
    }
    protected void ddlpayee_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
    }
    protected void ddlpayeedd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
    }

    protected void ddlpayeecash_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlallocation.Visible = true;
    }
    protected void txtmicrcode_TextChanged(object sender, System.EventArgs e)
    {
        string MicrCode = "";
        MicrCode = txtmicrcode.Text;
        SqlDataReader dr = AccountController.GetBanknameandAddress(MicrCode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtbankname.Text = dr["bankname"].ToString();
                txtbranchname.Text = dr["bankbranch"].ToString();
            }
        }
    }
    protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlpaymentreceipt.Visible = false;
        divpayment.Visible = true;
        if (ddlpaymode.SelectedValue == "01")
        {
            tblcheque.Visible = true;
            tblDD.Visible = false;
            tblbankdetails.Visible = true;
            tblcash.Visible = false;
            tr22.Visible = true;
            tr23.Visible = false;
            tr24.Visible = false;

        }
        else if (ddlpaymode.SelectedValue == "02")
        {
            tblcheque.Visible = false;
            tblDD.Visible = true;
            tblbankdetails.Visible = true;
            tblcash.Visible = false;
            tr22.Visible = false;
            tr23.Visible = true;
            tr24.Visible = false;
        }
        else if (ddlpaymode.SelectedValue == "03")
        {
            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblbankdetails.Visible = false;
            tblcash.Visible = true;
            tr22.Visible = false;
            tr23.Visible = false;
            tr24.Visible = true;
        }


        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#basic').modal('show') });</script>", False)
    }
    private void GetSumvalue()
    {

        try
        {

            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            TextBox lblsid = default(TextBox);
            int Sum = 0;
            int Count = 0;
            if (ddlpaymode.SelectedValue == "01")
            {
                foreach (DataListItem li in dlallocation.Items)
                {
                    obj = li.FindControl("chk1");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }

                    obj = li.FindControl("txtcurrentallocation");
                    if (obj != null)
                    {
                        lblsid = (TextBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        //li.FindControl("txtcurrentallocation")
                        if (string.IsNullOrEmpty(lblsid.Text))
                        {
                        }
                        else
                        {
                            Sum = Sum + Convert.ToInt32(lblsid.Text);
                            txtslipamt.Text = Sum.ToString();
                        }
                        lblsid.Enabled = true;
                    }
                    else
                    {
                        lblsid.Enabled = false;
                    }
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    private void GetSumvaluedd()
    {
        try
        {
            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            TextBox lblsid = default(TextBox);
            int Sum = 0;
            int Count = 0;
            if (ddlpaymode.SelectedValue == "02")
            {
                foreach (DataListItem li in dlallocation.Items)
                {
                    obj = li.FindControl("chk1");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }

                    obj = li.FindControl("txtcurrentallocation");
                    if (obj != null)
                    {
                        lblsid = (TextBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        //li.FindControl("txtcurrentallocation")
                        if (string.IsNullOrEmpty(lblsid.Text))
                        {
                        }
                        else
                        {
                            Sum = Sum + Convert.ToInt32(lblsid.Text);
                            txtddalloca.Text = Sum.ToString();
                        }
                        lblsid.Enabled = true;
                    }
                    else
                    {
                        lblsid.Enabled = false;
                    }
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    private void GetSumvaluecash()
    {
        try
        {
            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            TextBox lblsid = default(TextBox);
            int Sum = 0;
            int Count = 0;
            if (ddlpaymode.SelectedValue == "03")
            {
                foreach (DataListItem li in dlallocation.Items)
                {
                    obj = li.FindControl("chk1");
                    if (obj != null)
                    {
                        chk = (CheckBox)obj;
                    }

                    obj = li.FindControl("txtcurrentallocation");
                    if (obj != null)
                    {
                        lblsid = (TextBox)obj;
                    }
                    if (chk.Checked == true)
                    {
                        //li.FindControl("txtcurrentallocation")
                        if (string.IsNullOrEmpty(lblsid.Text))
                        {
                        }
                        else
                        {
                            Sum = Sum + Convert.ToInt32(lblsid.Text);
                            txtcashalloca.Text = Sum.ToString();
                        }
                        lblsid.Enabled = true;
                    }
                    else
                    {
                        lblsid.Enabled = false;
                    }
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    protected void btnsavepayment_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            DateTime Paydate = default(DateTime);
            decimal Amtinstr = 0;
            string Sbentrycode = "";
            string Paymode = "";
            string PayInsnum = "";
            DateTime PayInsdate = default(DateTime);
            string PayInsBankName = "";
            string InsStatus = "";
            string Inslocation = "";
            DateTime InsDepositdate = default(DateTime);
            DateTime IDepositdate = default(DateTime);
            DateTime InsBRSDate = default(DateTime);
            DateTime IBRSdate = default(DateTime);
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string MicrCode = "";
            string PayHeadCode = "";
            string PayHeadDesc = "";
            DateTime Payidate = default(DateTime);
            DateTime paydate1 = default(DateTime);
            paydate1 = DateTime.Today;
            Paydate = Convert.ToDateTime(paydate1, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat); 
            InsDepositdate = DateTime.Today;
            InsBRSDate = DateTime.Today;
            Sbentrycode = txtcursbcode.Text;
            string Payeeid = "";
            string cardtype = "";
            string cardno = "";
            Paymode = ddlpaymode.SelectedValue;
            if (ddlpaymode.SelectedValue == "01")
            {
                Amtinstr = Convert.ToDecimal(txtchequeamt.Text);
                PayInsnum = txtchqno.Text;
                PayInsdate = Convert.ToDateTime(txtchqdate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                Payidate = Convert.ToDateTime(txtchqdate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                PayInsBankName = txtbankname.Text;
                InsStatus = "01";
                Inslocation = "";
                IDepositdate = Convert.ToDateTime(InsDepositdate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                IBRSdate = Convert.ToDateTime(InsBRSDate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                MicrCode = txtmicrcode.Text;
                Payeeid = ddlpayee.SelectedValue;
            }
            else if (ddlpaymode.SelectedValue == "02")
            {
                Amtinstr = Convert.ToDecimal(txtddamt.Text);
                PayInsnum = txtddno.Text;
                PayInsdate = Convert.ToDateTime(txtdddate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                Payidate = Convert.ToDateTime(txtdddate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                PayInsBankName = txtbankname.Text;
                InsStatus = "01";
                Inslocation = "";
                IDepositdate = Convert.ToDateTime(InsDepositdate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                IBRSdate = Convert.ToDateTime(InsBRSDate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                MicrCode = txtmicrcode.Text;
                Payeeid = ddlpayeedd.SelectedValue;
            }
            else if (ddlpaymode.SelectedValue == "03")
            {
                Amtinstr = Convert.ToDecimal(txtcashamt.Text);
                PayInsnum = "";
                PayInsdate = Convert.ToDateTime(txtdddate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                Payidate = Convert.ToDateTime(txtdddate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                PayInsBankName = "";
                InsStatus = "03";
                Inslocation = "";
                IDepositdate = Convert.ToDateTime(InsDepositdate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                IBRSdate = Convert.ToDateTime(InsBRSDate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                MicrCode = txtmicrcode.Text;
                Payeeid = ddlpayeecash.SelectedValue;
            }
            string Receiptcode = "";
            string Receiptid = AccountController.InsertPayment(2, Paydate.ToString("dd-Mmm-yyyy"), Amtinstr, Sbentrycode, Paymode, PayInsnum, Payidate.ToString("dd-Mmm-yyyy"), PayInsBankName, InsStatus, Inslocation,
            IDepositdate.ToString("dd-Mmm-yyyy"), IBRSdate.ToString("dd-Mmm-yyyy"), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Receiptcode,cardtype ,cardno );
            //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#basic').modal('hide') });</script>", False)

            //Insertallocation()
            txtpaydate.Text = "";
            txtchequeamt.Text = "";
            ddlpaymode.SelectedIndex = 0;
            txtchqno.Text = "";
            txtchqdate.Text = "";
            txtbankname.Text = "";
            txtddno.Text = "";
            txtdddate.Text = "";
            txtbankname.Text = "";
            txtbranchname.Text = "";
            txtmicrcode.Text = "";
            Bindpayment(Sbentrycode);
            BindStudentLedger();
            BindChequeOutstanding();
            Bindlist(Sbentrycode);
            //ddlpayhead.SelectedIndex = 0
            dlpaymentreceipt.Visible = true;
            divpayment.Visible = false;
            dynamic Cur_Sb_Code = "";
            Bindpayment(Cur_Sb_Code);
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void btnclosepayment_ServerClick(object sender, System.EventArgs e)
    {
        dlpaymentreceipt.Visible = true;
        divpayment.Visible = false;
        txtpaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        txtchequeamt.Text = "";
        txtchqno.Text = "";
        txtchqdate.Text = "";
        txtbankname.Text = "";
        txtddno.Text = "";
        txtdddate.Text = "";
        txtbankname.Text = "";
        txtbranchname.Text = "";
        txtmicrcode.Text = "";
        tblcheque.Visible = false;
        tblDD.Visible = false;
        tblbankdetails.Visible = false;
        tblcash.Visible = false;
        diverrorPayment.Visible = false;
        lblerrorPayment.Visible = false;
        string Cur_Sub_Code = "";
        Bindpayment(Cur_Sub_Code);
    }

    ///'''''''End of Payment Entry'''''''''''''''''''''''''''''''''''''''''''''''''''

    /// <summary>
    /// '''''''Edit Payment'''''''''''''''''''''''''''''''
    /// </summary>
    /// <remarks></remarks>

    private void Bindpaymodeedit()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = AccountController.GetallPaymode();
        BindDDL(ddlpaymodeedit, ds, "Description", "id");
        ddlpaymodeedit.Items.Insert(0, "Select");
        ddlpaymodeedit.SelectedIndex = 0;
    }
    private void BindPayeeedit()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Center = ddllcenter.SelectedValue;
        DataSet ds = AccountController.GetallpayeebyCenter(1, Center);
        BindDDL(ddlpayeeedit, ds, "Payee_Name", "payee_id");
        ddlpayeeedit.Items.Insert(0, "Select");
        ddlpayeeedit.SelectedIndex = 0;
        BindDDL(ddlpayeeddedit, ds, "Payee_Name", "payee_id");
        ddlpayeeddedit.Items.Insert(0, "Select");
        ddlpayeeddedit.SelectedIndex = 0;
        BindDDL(ddlpayeecashedit, ds, "Payee_Name", "payee_id");
        ddlpayeecashedit.Items.Insert(0, "Select");
        ddlpayeecashedit.SelectedIndex = 0;
    }
    private void BindChequeallocationEdit()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        string receiptcode = "";
        receiptcode = lblreceiptidedit.Text;
        DataSet ds = AccountController.GetPPgroupbyreceiptcode(receiptcode, "1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            //System.Threading.Thread.Sleep(1000);
            dlallocationedit.DataSource = ds;
            dlallocationedit.DataBind();
            dlallocationedit.Visible = false;
        }
        else
        {
        }
    }
    private void Bindpaymentdata()
    {
        string Receiptid = "";
        Receiptid = lblreceiptidedit.Text;
        SqlDataReader dr = ProductController.Getreceiptdetailsbyreceiptid(Receiptid, 2);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtpaymentdateedit.Text = dr["CreatedOn"].ToString();
                ddlpaymodeedit.Text = dr["Pay_Mode"].ToString();
                txtbanknameedit.Text = dr["Pay_BankName"].ToString();
                txtmicrcodeedit.Text = dr["micrno"].ToString();
                txtbanknameedit.Text = dr["Pay_BankName"].ToString();
                txtbranchnameedit.Text = dr["bankbranch"].ToString();


                if (ddlpaymodeedit.SelectedValue == "01")
                {
                    tblchequeedit.Visible = true;
                    tblddedit.Visible = false;
                    tblbankdetailsedit.Visible = true;
                    tblcashedit.Visible = false;
                    //tr29.Visible = True
                    //tr30.Visible = False
                    //tr31.Visible = False
                    txtchqdateedit.Text = dr["Pay_InstrDate"].ToString();
                    txtchqnoedit.Text = dr["Pay_InsNum"].ToString();
                    txtchequeamtedit.Text = dr["Instr_Amt"].ToString();
                    ddlpayeeedit.Text = dr["payee_id"].ToString();
                    //ddlpayeeedit.Text = dr("").ToString

                }
                else if (ddlpaymodeedit.SelectedValue == "02")
                {
                    tblchequeedit.Visible = false;
                    tblddedit.Visible = true;
                    tblbankdetailsedit.Visible = true;
                    tblcashedit.Visible = false;
                    //tr29.Visible = False
                    //tr30.Visible = True
                    //tr31.Visible = False
                    txtdddateedit.Text = dr["Pay_InstrDate"].ToString();
                    txtddnoedit.Text = dr["Pay_InsNum"].ToString();
                    txtddamtedit.Text = dr["Instr_Amt"].ToString();
                    ddlpayeeddedit.Text = dr["payee_id"].ToString();

                }
                else if (ddlpaymodeedit.SelectedValue == "03")
                {
                    tblchequeedit.Visible = false;
                    tblddedit.Visible = false;
                    tblbankdetailsedit.Visible = false;
                    //tblcashedit.Visible = True
                    //tr29.Visible = False
                    //tr30.Visible = False
                    //tr31.Visible = True
                    txtcashamtedit.Text = dr["Instr_Amt"].ToString();
                    ddlpayeecashedit.Text = dr["payee_id"].ToString();
                }

            }
        }
    }

    protected void ddlpaymodeedit_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlpaymodeedit.SelectedValue == "01")
        {
            tblchequeedit.Visible = true;
            tblddedit.Visible = false;
            tblbankdetailsedit.Visible = true;
            tblcashedit.Visible = false;
            //tr29.Visible = True
            //tr30.Visible = False
            //tr31.Visible = False
            //txtchqdateedit.Text = dr("Pay_InstrDate").ToString
            //txtchqnoedit.Text = dr("Pay_InsNum").ToString
            //txtchequeamtedit.Text = dr("Instr_Amt").ToString
            //'ddlpayeeedit.Text = dr("").ToString

        }
        else if (ddlpaymodeedit.SelectedValue == "02")
        {
            tblchequeedit.Visible = false;
            tblddedit.Visible = true;
            tblbankdetailsedit.Visible = true;
            tblcashedit.Visible = false;
            //tr29.Visible = False
            //tr30.Visible = True
            //tr31.Visible = False
            //txtdddateedit.Text = dr("Pay_InstrDate").ToString
            //txtddnoedit.Text = dr("Pay_InsNum").ToString
            //txtddamtedit.Text = dr("Instr_Amt").ToString


        }
        else if (ddlpaymodeedit.SelectedValue == "03")
        {
            tblchequeedit.Visible = false;
            tblddedit.Visible = false;
            tblbankdetailsedit.Visible = false;
            tblcashedit.Visible = true;
            //tr29.Visible = False
            //tr30.Visible = False
            //tr31.Visible = True
            //txtcashamtedit.Text = dr("Instr_Amt").ToString
        }
    }
    protected void txtmicrcodeedit_TextChanged(object sender, System.EventArgs e)
    {
        string MicrCode = "";
        MicrCode = txtmicrcodeedit.Text;
        SqlDataReader dr = AccountController.GetBanknameandAddress(MicrCode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtbanknameedit.Text = dr["bankname"].ToString();
                txtbranchnameedit.Text = dr["bankbranch"].ToString();
            }
        }
    }
    protected void btnclosepaymentedit_ServerClick(object sender, System.EventArgs e)
    {
        dlpaymentreceipt.Visible = true;
        diveditpayemnt.Visible = false;
        tblchequeedit.Visible = false;
        tblddedit.Visible = false;
        tblbankdetailsedit.Visible = false;
        tblcashedit.Visible = false;
        //diverrorPaymentedit.Visible = False
        //lblerrorPayment.Visible = False
        string Cur_Sub_Code = "";
        Bindpayment(Cur_Sub_Code);
    }
    protected void btnsavepaymentedit_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            string Paydate = "";
            decimal Amtinstr = 0;
            string Sbentrycode = "";
            string Paymode = "";
            string PayInsnum = "";
            string PayInsdate = "";
            string PayInsBankName = "";
            string InsStatus = "";
            string Inslocation = "";
            DateTime InsDepositdate = default(DateTime);
            DateTime IDepositdate = default(DateTime);
            DateTime InsBRSDate = default(DateTime);
            DateTime IBRSdate = default(DateTime);
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string MicrCode = "";
            string PayHeadCode = "";
            string PayHeadDesc = "";
            String Payidate = "";
            DateTime paydate1 = default(DateTime);
            paydate1 = DateTime.Today;
            Paydate = Convert.ToString(paydate1);
            InsDepositdate = DateTime.Today;
            InsBRSDate = DateTime.Today;
            Sbentrycode = txtcursbcode.Text;
            string Payeeid = "";
            Paymode = ddlpaymodeedit.SelectedValue;
            string cardtype = "";
            string cardno = "";
            if (ddlpaymodeedit.SelectedValue == "01")
            {
                Amtinstr = Convert.ToDecimal(txtchequeamtedit.Text);
                PayInsnum = txtchqnoedit.Text;
                PayInsdate = txtchqdateedit.Text;
                Payidate = txtchqdateedit.Text;
                PayInsBankName = txtbanknameedit.Text;
                InsStatus = "01";
                Inslocation = "";
                IDepositdate = InsDepositdate;
                IBRSdate = InsBRSDate;
                MicrCode = txtmicrcodeedit.Text;
                Payeeid = ddlpayeeedit.SelectedValue;
            }
            else if (ddlpaymodeedit.SelectedValue == "02")
            {
                Amtinstr = Convert.ToDecimal(txtddamtedit.Text);
                PayInsnum = txtddnoedit.Text;
                PayInsdate = txtdddateedit.Text;
                Payidate = txtdddateedit.Text;
                PayInsBankName = txtbanknameedit.Text;
                InsStatus = "01";
                Inslocation = "";
                IDepositdate = InsDepositdate;
                IBRSdate = InsBRSDate;
                MicrCode = txtmicrcodeedit.Text;
                Payeeid = ddlpayeeddedit.SelectedValue;
            }
            else if (ddlpaymodeedit.SelectedValue == "03")
            {
                Amtinstr = Convert.ToDecimal(txtcashamtedit.Text);
                PayInsnum = "";
                PayInsdate = "";
                Payidate = PayInsdate;
                PayInsBankName = "";
                InsStatus = "03";
                Inslocation = "";
                IDepositdate = Convert.ToDateTime(InsDepositdate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                IBRSdate = Convert.ToDateTime(InsBRSDate, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
                MicrCode = txtmicrcodeedit.Text;
                Payeeid = ddlpayeecashedit.SelectedValue;
            }
            string Receiptcode = lblreceiptidedit.Text;
            string Receiptid = AccountController.InsertPayment(3, Paydate.ToString(), Amtinstr, Sbentrycode, Paymode, PayInsnum, Payidate.ToString(), PayInsBankName, InsStatus, Inslocation,
            IDepositdate.ToString(), IBRSdate.ToString(), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Receiptcode,cardtype ,cardno );
            //Bindpayment(Sbentrycode)
            BindStudentLedger();
            BindChequeOutstanding();
            Bindlist(Sbentrycode);
            //ddlpayhead.SelectedIndex = 0
            dlpaymentreceipt.Visible = true;
            diveditpayemnt.Visible = false;
            dynamic Cur_Sb_Code = "";
            Bindpayment(Cur_Sb_Code);
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// '''''''''''End of Payment Edit
    /// </summary>
    /// <remarks></remarks>

    private void BindStudentLedger()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.Getstudentledgerbysbentrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //System.Threading.Thread.Sleep(1000)
            dlstudentledger.DataSource = ds;
            dlstudentledger.DataBind();

        }
        else
        {
        }
    }
    

    private void BindStudentdetails(string Oppid)
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Hiphen = "-";
            SqlDataReader dr = AccountController.GetStudentDetailsbyOppid(Oppid);
            try
            {
                if ((((dr) != null)))
                {
                    if (dr.Read())
                    {

                        lblstudentname.Text = Hiphen + " " + dr["Name"].ToString();
                       
                        //ddlconacademicyear.SelectedValue = dr("acad_year").ToString
                        //BindConstream()
                        //ddlconstream.SelectedValue = dr("stream_code").ToString
                    }
                }
            }
            catch (Exception ex)
            {
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }





    protected void btnregistrationno_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Series.aspx");
    }

    protected void btnproceedprint_ServerClick(object sender, System.EventArgs e)
    {
        string sbentrycode = "";
        sbentrycode = txtcursbcode.Text;
        string SB = encryptQueryString(sbentrycode);
        Response.Redirect("Receipt_Print.aspx?SB=" + SB);
    }
    public string encryptQueryString(string strQueryString)
    {
        Encryption_Decryption oEs1 = new Encryption_Decryption();
        string EncriptStr = oEs1.EncryptString128Bit(strQueryString, "!#$a54?3");
        return EncriptStr;
    }


    private void BindChequeOutstanding()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;

        SqlDataReader dr = AccountController.GetChequeOutstanding(Sbentrycode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtcurrentout.Text = dr["outstanding"].ToString();
            }
        }
        if (lblstdstaus.Text == "Student Status : Pending" && Convert.ToInt32(txtcurrentout.Text) <= 0)
        {
            badgeError.Visible = true;
            badgeSuccess.Visible = false;
            string Output = AccountController.Confirmadmission(Sbentrycode);

        }
        else if (lblstdstaus.Text == "Student Status : Confirmed")
        {
            badgeError.Visible = false;
            badgeSuccess.Visible = true;
            //goto Rowexit;
        }
        else
        {
        }

    }




    protected void btnclosemessage_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#message').modal('hide') });</script>", false);
    }

    protected void btnclosemessage1_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#message').modal('hide') });</script>", false);
    }

    //For Change Subject



    //For Swap Cheque
    //Protected Sub aswapcheque_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles aswapcheque.ServerClick
    //    Bindlistchequeswap()
    //    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#swapcheque').modal('show') });</script>", False)
    //End Sub

    //Protected Sub btnSwapClose_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSwapClose.ServerClick
    //    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#swapcheque').modal('hide') });</script>", False)
    //End Sub

    //Protected Sub btnSwapClose1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSwapClose1.ServerClick
    //    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#swapcheque').modal('hide') });</script>", False)
    //End Sub
    //Private Sub Bindlistchequeswap()

    //End Sub
    //Protected Sub btnSaveswap_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveswap.ServerClick

    //End Sub




}