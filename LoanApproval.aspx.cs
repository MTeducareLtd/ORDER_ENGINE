using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
using System.Data.SqlClient;


public partial class LoanApproval : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
                BindPaymode();
                ControlVisibility("Search");
                //txtNeftDate.Disabled = true;
            }
        }
        #endregion

        #region Methods

        

        /// <summary>
        /// Fill Division drop down list
        /// </summary>
        private void BindCompany()
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
            BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
            //ddlcompany.Items.Insert(0, "All")
            //ddlcompany.SelectedIndex = 1
            BindDivision();
            //ddldivision.Items.Insert(0, "All")
            //ddldivision.SelectedIndex = 0
            
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


        private void BindCardtype()
        {
            DataSet ds = ProductController.GetallCardtype();
            BindDDL(ddlcardtype, ds, "Card_Type_Name", "Card_Type_Code");
            ddlcardtype.Items.Insert(0, "Select");
            ddlcardtype.SelectedIndex = 0;
        }

        private void Tdtrue()
        {
            lblLOanAmount.Visible = true;
            label56.Visible = true;
            txtLoanApproveAmount.Visible = true;
            Label8.Visible = true;
            ddlpaymode.Visible = true;
            label59.Visible = true;
        }

        private void Tdfalse()
        {
            lblLOanAmount.Visible = false;
            label56.Visible = false;
            txtLoanApproveAmount.Visible = false;
            Label8.Visible = false;
            ddlpaymode.Visible = false;
            label59.Visible = false;

            tblbankdetails.Visible = false;
            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblcash.Visible = false;
            tblccdc.Visible = false;
            tblNEFT.Visible = false;
        }

        //Bind Payment
        private void Bindpayment(string CurSbCode)
        {
            string Sbentrycode = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            Sbentrycode = lblSBEntryCodet_Result1.Text;
            DataSet ds = AccountController.GetLoanPaymentDetailsbySBEntrycode(Sbentrycode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // System.Threading.Thread.Sleep(1000);
                dlpaymentreceipt.DataSource = ds;
                dlpaymentreceipt.DataBind();
                script1.RegisterAsyncPostBackControl(dlpaymentreceipt);
            }
            else
            {
                dlpaymentreceipt.DataSource = null;
                dlpaymentreceipt.DataBind();
                script1.RegisterAsyncPostBackControl(dlpaymentreceipt);
            }
        }
        /// <summary>
        /// Fill drop down list and assign value and Text
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="txtField"></param>
        /// <param name="valField"></param>
        private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = txtField;
            ddl.DataValueField = valField;
            ddl.DataBind();
        }

        /// <summary>
        /// Fill List box and assign value and Text
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="txtField"></param>
        /// <param name="valField"></param>
        private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = txtField;
            ddl.DataValueField = valField;
            ddl.DataBind();
        }

        /// <summary>
        /// Clear Error Success Box
        /// </summary>
        private void Clear_Error_Success_Box()
        {
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            lblSuccess.Text = "";
            lblerror.Text = "";
            UpdatePanelMsgBox.Update();
        }


        /// <summary>
        /// Show Error or success box on top base on boxtype and Error code
        /// </summary>
        /// <param name="BoxType">BoxType</param>
        /// <param name="Error_Code">Error_Code</param>
        private void Show_Error_Success_Box(string BoxType, string Error_Code)
        {
            if (BoxType == "E")
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = ProductController.Raise_Error(Error_Code);
                UpdatePanelMsgBox.Update();
            }
            else
            {
                Msg_Success.Visible = true;
                Msg_Error.Visible = false;
                lblSuccess.Text = ProductController.Raise_Error(Error_Code);
                UpdatePanelMsgBox.Update();
            }
        }


        private void ControlVisibility(string Mode)
        {
            if (Mode == "Search")
            {
                DivSearchPanel.Visible = true;
                DivResultPanel.Visible = false;
                DivEditPanel.Visible = false;
                badgeError.Visible = false;
                badgeSuccess.Visible = false;
                Span1.Visible = false;
                BtnShowSearchPanel.Visible = false;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;
            }
            else if (Mode == "Result")
            {
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;
                DivEditPanel.Visible = false;
                badgeError.Visible = false;
                badgeSuccess.Visible = false;
                Span1.Visible = false;
                BtnShowSearchPanel.Visible = true;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;
            }
            else if (Mode == "Edit")
            {
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = false;
                DivEditPanel.Visible = true;
                BtnShowSearchPanel.Visible = true;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;
                Tdfalse();
            }


        }

        /// Clear Add Panel 
        /// </summary>
        private void ClearAddPanel()
        {
            txtLoanApproveAmount.Text = "";
            txtpaydate.Text = "";
            txtmicrcode.Text = "";
            txtbankname.Text = "";
            txtbranchname.Text = "";
            txtchqno.Text = "";
            txtchqdate.Value = "";
            txtRemark.Text = "";
            txtNeftDate.Value = "";


            lblCentre_Result1.Text = "";
            lblClassRoomProduct_Result1.Text = "";
            lblSBEntryCodet_Result1.Text = "";
            lblStudName_Result1.Text = "";
            lblLoanDispatchDate_Result1.Text = "";
            lblDivCode_Result1.Text = "";
            lblNetFees_Result1.Text = "";
            lblAmountRec_Result1.Text = "";
            lblBalanceAmount_Result1.Text = "";
            lblPDCInHand_Result1.Text = "";
            ddlpaymode.SelectedIndex = 0;
            
            tblbankdetails.Visible = false;
            tblcheque.Visible = false;
            tblDD.Visible = false;
            tblcash.Visible = false;
            tblccdc.Visible = false;
            tblNEFT.Visible = false;
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

        //private void BindPayee()
        //{
        //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        //    string UserID = cookie.Values["UserID"];
        //    string UserName = cookie.Values["UserName"];
        //    string Company = "";
        //    string Division = "";

        //    Company = ddlcompany.SelectedValue;
        //    Division = lblDivCode_Result1.Text;

        //    DataSet ds = AccountController.Getallpayeebycompanydivision(Company, Division);

        //    BindDDL(ddlpayee, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
        //    ddlpayee.Items.Insert(0, "Select");
        //    ddlpayee.SelectedIndex = 0;

        //    BindDDL(ddlpayeedd, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
        //    ddlpayeedd.Items.Insert(0, "Select");
        //    ddlpayeedd.SelectedIndex = 0;

        //    BindDDL(ddlpayeecash, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
        //    ddlpayeecash.Items.Insert(0, "Select");
        //    ddlpayeecash.SelectedIndex = 0;

        //    BindDDL(ddlpayeetrans, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
        //    ddlpayeetrans.Items.Insert(0, "Select");
        //    ddlpayeetrans.SelectedIndex = 0;
        //    if (ds.Tables[1].Rows.Count > 0)
        //    {
        //        txtShowReceiptAllocation.Text = ds.Tables[1].Rows[0]["ShowReceiptAllocation"].ToString();
        //    }
            
        //}

        /// <summary>
        /// Bind search  Datalist
        /// </summary>
        private void FillGrid()
        {
            try
            {
                Clear_Error_Success_Box();

                ControlVisibility("Result");

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];

                DataSet ds = AccountController.GetLoanApprovalStudent(ddldivision.SelectedValue, ddlStatus.SelectedValue, UserID);
                if (ds != null)
                {
                    dlGridDisplay.DataSource = ds;
                    dlGridDisplay.DataBind();
                }

                lblCompany_Result.Text = ddlcompany.SelectedItem.ToString();
                lblDivision_Result.Text = ddldivision.SelectedItem.ToString();
                lblStatus_Result.Text = ddlStatus.SelectedItem.ToString();
                if (ds != null)
                {
                    if (ds.Tables.Count != 0)
                    {
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            lbltotalcount.Text = (ds.Tables[0].Rows.Count).ToString();
                        }
                        else
                        {
                            lbltotalcount.Text = "0";
                        }
                    }
                    else
                    {
                        lbltotalcount.Text = "0";
                    }
                }
                else
                {
                    lbltotalcount.Text = "0";
                }               

            }
            catch (Exception ex)
            {

                Show_Error_Success_Box("E",ex.ToString());
                //Msg_Error.Visible = true;
                //Msg_Success.Visible = false;
                //lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
                return;
            }
        }


        private void BindPayee(string Division)
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Company = "";
            

            Company = ddlcompany.SelectedValue;            

            DataSet ds = AccountController.Getallpayeebycompanydivision(Company, Division);

            BindDDL(ddlpayee, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
            ddlpayee.Items.Insert(0, "Select");
            ddlpayee.SelectedIndex = 0;

            BindDDL(ddlpayeedd, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
            ddlpayeedd.Items.Insert(0, "Select");
            ddlpayeedd.SelectedIndex = 0;

            BindDDL(ddlpayeecash, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
            ddlpayeecash.Items.Insert(0, "Select");
            ddlpayeecash.SelectedIndex = 0;

            BindDDL(ddlpayeetrans, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
            ddlpayeetrans.Items.Insert(0, "Select");
            ddlpayeetrans.SelectedIndex = 0;

            BindDDL(ddlNeftPayee, ds.Tables[0].DataSet, "Payee_Name", "payee_id");
            ddlNeftPayee.Items.Insert(0, "Select");
            ddlNeftPayee.SelectedIndex = 0;
            
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtShowReceiptAllocation.Text = ds.Tables[1].Rows[0]["ShowReceiptAllocation"].ToString();

            }

            //txtShowReceiptAllocation

        }

        /// <summary>
        /// Insert data
        /// </summary>
        private void SaveData()
        {
            try
            {
                Clear_Error_Success_Box();

                String Paydate = "";
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
                string cardtype = "";
                string cardno = "";
                DateTime paydate1 = default(DateTime);
                paydate1 = DateTime.Today;
                Paydate = Convert.ToString(paydate1);
                InsDepositdate = DateTime.Today;
                InsBRSDate = DateTime.Today;
                Sbentrycode = lblSBEntryCodet_Result1.Text;
                string Payeeid = "";
                Paymode = ddlpaymode.SelectedValue;
                if (ddlpaymode.SelectedValue == "01")
                {
                    Amtinstr = Convert.ToDecimal(txtLoanApproveAmount.Text);
                    PayInsnum = txtchqno.Text;
                    PayInsdate = txtchqdate.Value;
                    Payidate = txtchqdate.Value;
                    PayInsBankName = txtbankname.Text;
                    InsStatus = "01";
                    Inslocation = "01";     //center
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = txtmicrcode.Text;
                    Payeeid = ddlpayee.SelectedValue;
                }
                else if (ddlpaymode.SelectedValue == "02")
                {
                    Amtinstr = Convert.ToDecimal(txtLoanApproveAmount.Text);
                    PayInsnum = txtddno.Text;
                    PayInsdate = txtdddate.Value;
                    Payidate = txtdddate.Value;
                    PayInsBankName = txtbankname.Text;
                    InsStatus = "01";
                    Inslocation = "01"; //Center
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = txtmicrcode.Text;
                    Payeeid = ddlpayeedd.SelectedValue;
                }
                else if (ddlpaymode.SelectedValue == "03")
                {
                    Amtinstr = Convert.ToDecimal(txtLoanApproveAmount.Text);
                    PayInsnum = "";
                    PayInsdate = Convert.ToString(DateTime.Today);
                    PayInsBankName = "";
                    InsStatus = "03";
                    Inslocation = "05"; //NA
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = txtmicrcode.Text;
                    Payeeid = ddlpayeecash.SelectedValue;
                }
                if (ddlpaymode.SelectedValue == "04")
                {
                    Amtinstr = Convert.ToDecimal(txtLoanApproveAmount.Text);
                    PayInsnum = txttransid.Text;
                    PayInsdate = txttrandate.Value;
                    Payidate = txttrandate.Value;
                    PayInsBankName = txtcardholder.Text;
                    InsStatus = "01";
                    Inslocation = "01";     //NA
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = txtmicrcode.Text;
                    Payeeid = ddlpayeetrans.SelectedValue;
                    cardtype = ddlcardtype.SelectedValue;
                    cardno = txtlast4digit.Text;
                }
                if (ddlpaymode.SelectedValue == "05")
                {
                    Amtinstr = Convert.ToDecimal(txtLoanApproveAmount.Text);
                    PayInsnum = txtNeftRefNo.Text;
                    //PayInsdate = Convert.ToString(DateTime.Today);
                    //Payidate = Convert.ToString(DateTime.Today);
                    PayInsdate = txtNeftDate.Value;
                    Payidate = txtNeftDate.Value;
                    PayInsBankName = "";
                    InsStatus = "03";
                    Inslocation = "01";     //NA
                    IDepositdate = InsDepositdate;
                    IBRSdate = InsBRSDate;
                    MicrCode = "";
                    Payeeid = ddlNeftPayee.SelectedValue;                    
                }

                //Check if cheque date is greater than last cheque date allowed for the stream
                string VerifyChequeStr = "";
                //string paydate = 
                VerifyChequeStr = AccountController.Verify_ChequeEntry(Sbentrycode, Amtinstr, Payidate.ToString(), 1);

                if (VerifyChequeStr != "Success")
                {
                    Show_Error_Success_Box("E", VerifyChequeStr);
                    //Msg_Error.Visible = true;
                    //lblerror.Visible = true;
                    //lblerror.Text = VerifyChequeStr;
                    UpdatePanelMsgBox.Update();
                    return;
                }

                //Check if this is first payment entry and if yes then
                //check is amount is greater than CRF + Robomate or not
                //PayInsdate


                string Receiptcode = "";
                string Receiptid = AccountController.InsertPayment(2, Paydate.ToString(), Amtinstr, Sbentrycode, Paymode, PayInsnum, Payidate.ToString(), PayInsBankName, InsStatus, Inslocation,
                    IDepositdate.ToString(), IBRSdate.ToString(), UserID, MicrCode, PayHeadCode, PayHeadDesc, Payeeid, Receiptcode, cardtype, cardno);

                lblreceiptid.Text = Receiptid;
                if (Receiptid == "")
                {
                    return;
                }

                Insertallocation();
                string SBCode = AccountController.InsertLoan_ApprovalStud(Sbentrycode, ddlLoanAppStatus.SelectedValue, Amtinstr, txtRemark.Text.Trim(), Receiptid, UserID);

                
                

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
                    string Output1 = AccountController.InsertP19(Sbentrycode);
                    string Output = AccountController.Confirmadmission(Sbentrycode);

                }
                else if (lblstdstaus.Text == "Student Status : Confirmed")
                {
                    badgeError.Visible = false;
                    badgeSuccess.Visible = true;
                    string Output = AccountController.InsertE19(Sbentrycode);

                }
                else if (lblstdstaus.Text == "Student Status : Pending")
                {
                    badgeError.Visible = true;
                    badgeSuccess.Visible = false;
                    string Output = AccountController.InsertP19(Sbentrycode);

                }
                else if (lblstdstaus.Text == "Student Status : Cancelled")
                {
                    badgeError.Visible = false;
                    badgeSuccess.Visible = false;
                    Span1.Visible = true;

                }
                ControlVisibility("Search");
                Show_Error_Success_Box("S", "Records Saved Successfully");
                               
            }
            catch (Exception ex)
            {
                Show_Error_Success_Box("E", ex.ToString());
                //Msg_Error.Visible = true;
                //Msg_Success.Visible = false;
                //lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
                return;
            }

        }

        private void BindChequeallocation()
        {
            string Sbentrycode = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            Sbentrycode = lblSBEntryCodet_Result1.Text;
            DataSet ds = AccountController.GetPPgroupbysbentrycode(Sbentrycode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //System.Threading.Thread.Sleep(1000)
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

        private void BindChequeallocationbyPayee(string Payeeid)
        {
            string Sbentrycode = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            Sbentrycode = lblSBEntryCodet_Result1.Text;
            DataSet ds = AccountController.GetPPGroupbySBEntrycodeAndPayeeid(Sbentrycode, Payeeid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlallocation.DataSource = ds;
                dlallocation.DataBind();
                //diverrorPayment.Visible = False
                //lblerrorPayment.Visible = False
            }
            else
            {
                dlallocation.Visible = false;
                //diverrorPayment.Visible = True
                //lblerrorPayment.Visible = True
                //lblerrorPayment.Text = "No Allocation Assigned! Contact Administrator"
            }
        }

        private void Insertallocation()
        {

            try
            {

                object obj = null;
                CheckBox Chk = default(CheckBox);
                CheckBox cb = default(CheckBox);
                TextBox txtcurrentallocation = default(TextBox);
                Label lblproductheadercode = default(Label);
                TextBox Txtamt = default(TextBox);
                List<string> list = new List<string>();
                List<string> List1 = new List<string>();
                int Flag = 1;
                lblproductheadercode = null;
                txtcurrentallocation = null;
                Txtamt = null;
                string receiptid = "";
                receiptid = lblreceiptid.Text;

                string Paymode = "";
                Paymode = ddlpaymode.SelectedValue;
                if (txtShowReceiptAllocation.Text == "1")
                {



                    if (ddlpaymode.SelectedValue == "01")
                    {
                        string PPcode = "";
                        string amt = "";
                        string Chqno = txtchqno.Text;
                        string sbentrycode = lblSBEntryCodet_Result1.Text;
                        string Payeeid = "";
                        try
                        {
                            foreach (DataListItem li in dlallocation.Items)
                            {
                                obj = li.FindControl("chk1");
                                if (obj != null)
                                {
                                    Chk = (CheckBox)obj;
                                }
                                obj = li.FindControl("lblproductheadercode");
                                if (obj != null)
                                {
                                    lblproductheadercode = (Label)obj;
                                }
                                obj = li.FindControl("txtcurrentallocation");
                                if (obj != null)
                                {
                                    Txtamt = (TextBox)obj;
                                }
                                if (Chk.Checked == true)
                                {
                                    Payeeid = ddlpayee.SelectedValue;
                                    ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                                }
                                else
                                {
                                    Txtamt.Text = "0";
                                    Payeeid = ddlpayee.SelectedValue;
                                    ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                                }
                            }


                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else if (ddlpaymode.SelectedValue == "02")
                    {
                        string PPcode = "";
                        string amt = "";
                        string Chqno = txtddno.Text;
                        string sbentrycode = lblSBEntryCodet_Result1.Text;
                        string Payeeid = "";
                        try
                        {
                            foreach (DataListItem li in dlallocation.Items)
                            {
                                obj = li.FindControl("chk1");
                                if (obj != null)
                                {
                                    Chk = (CheckBox)cb;
                                }
                                obj = li.FindControl("lblproductheadercode");
                                if (obj != null)
                                {
                                    lblproductheadercode = (Label)obj;
                                }
                                obj = li.FindControl("txtcurrentallocation");
                                if (obj != null)
                                {
                                    Txtamt = (TextBox)obj;
                                }
                                if (Chk.Checked == true)
                                {
                                    Payeeid = ddlpayeedd.SelectedValue;
                                    ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                                }
                                else
                                {
                                    Txtamt.Text = "0";
                                    Payeeid = ddlpayeedd.SelectedValue;
                                    ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                                }
                            }


                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else if (ddlpaymode.SelectedValue == "03")
                    {
                        string PPcode = "";
                        string amt = "";
                        string Chqno = "";
                        string sbentrycode = lblSBEntryCodet_Result1.Text;
                        string Payeeid = ddlpayeecash.SelectedValue;
                        try
                        {
                            foreach (DataListItem li in dlallocation.Items)
                            {
                                obj = li.FindControl("chk1");
                                if (obj != null)
                                {
                                    Chk = (CheckBox)cb;
                                }
                                obj = li.FindControl("lblproductheadercode");
                                if (obj != null)
                                {
                                    lblproductheadercode = (Label)obj;
                                }
                                obj = li.FindControl("txtcurrentallocation");
                                if (obj != null)
                                {
                                    Txtamt = (TextBox)obj;
                                }
                                if (Chk.Checked == true)
                                {
                                    Payeeid = ddlpayeecash.SelectedValue;
                                    ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                                }
                                else
                                {
                                    Txtamt.Text = "0";
                                    Payeeid = ddlpayeecash.SelectedValue;
                                    ProductController.Insertchequeallocation(lblproductheadercode.Text, Txtamt.Text, sbentrycode, Chqno, 1, Payeeid, receiptid);
                                }
                            }


                        }
                        catch (Exception ex)
                        {
                        }
                    }

                }
                else // allocation Not required
                {
                    string Chqno = "";
                    string amt = "";
                    string PPCode = "PP011"; //temporarily put
                    string sbentrycode = lblSBEntryCodet_Result1.Text;
                    string Payeeid = "";

                    if (ddlpaymode.SelectedValue == "03")
                    {
                        Chqno = "";
                        amt = txtLoanApproveAmount.Text;
                        Payeeid = ddlpayeecash.SelectedItem.Value;
                    }
                    else if (ddlpaymode.SelectedValue == "02")
                    {
                        Chqno = txtddno.Text;
                        amt = txtLoanApproveAmount.Text;
                        Payeeid = ddlpayeedd.SelectedItem.Value;
                    }
                    else if (ddlpaymode.SelectedValue == "01")
                    {
                        Chqno = txtchqno.Text;
                        amt = txtLoanApproveAmount.Text;
                        Payeeid = ddlpayee.SelectedItem.Value;
                    }
                    else if (ddlpaymode.SelectedValue == "04")
                    {
                        Chqno = txttransid.Text;
                        amt = txtLoanApproveAmount.Text;
                        Payeeid = ddlpayeetrans.SelectedItem.Value;
                    }
                    else if (ddlpaymode.SelectedValue == "05")//NEFT
                    {
                        Chqno = txtNeftRefNo.Text;
                        amt = txtLoanApproveAmount.Text;
                        Payeeid = ddlNeftPayee.SelectedItem.Value;
                    }

                    ProductController.Insertchequeallocation(PPCode, amt, sbentrycode, Chqno, 1, Payeeid, receiptid);

                }

                Msg_Error.Visible = false;
            }
            catch (Exception ex)
            {
                Show_Error_Success_Box("E", ex.ToString());
                //Msg_Error.Visible = true;
                //lblerror.Visible = true;
                //lblerror.Text = ex.Message;
                UpdatePanelMsgBox.Update();
            }


        }

        #endregion


       
        #region Event's
      

        protected void BtnClearSearch_Click(object sender, EventArgs e)
        {
            BindCompany();
            ddlStatus.SelectedValue = "All";            
        }

        protected void BtnCloseAdd_Click(object sender, EventArgs e)
        {
            ControlVisibility("Search");
        }

        protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
        {
            ControlVisibility("Search");
        }

       
      

        protected void BtnSearch_Click(object sender, EventArgs e)
        {            
            FillGrid();
        }

        protected void dlGridDisplay_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Open")
                {
                    lblRemark.Visible = false;
                    txtRemark.Visible = true;
                    ControlVisibility("Edit");
                    ClearAddPanel();
                    DateTime today = DateTime.Today; // As DateTime
                    txtpaydate.Text = today.ToString("dd-MM-yyyy");
                    //txtNeftDate.Value = today.ToString("dd-MM-yyyy");
                    lblPkey.Text = e.CommandArgument.ToString();
                    DataSet ds = AccountController.GetLoanApprovalStudentBySBEntryCode(lblPkey.Text);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblCentre_Result1.Text = ds.Tables[0].Rows[0]["Center"].ToString();
                            lblClassRoomProduct_Result1.Text = ds.Tables[0].Rows[0]["ClassRoomProduct"].ToString();
                            lblSBEntryCodet_Result1.Text = ds.Tables[0].Rows[0]["SBEntryCode"].ToString();
                            lblStudName_Result1.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
                            lblLoanDispatchDate_Result1.Text = ds.Tables[0].Rows[0]["LoanDispatchDate"].ToString();
                            lblDivCode_Result1.Text = ds.Tables[0].Rows[0]["Divisioncode"].ToString();
                            ddlLoanAppStatus.SelectedValue = ds.Tables[0].Rows[0]["SubmitLoanFlag"].ToString();
                            
                            BindChequeallocation();
                            //Account_Status_id
                            string Studentstatus = "";
                            Studentstatus = ds.Tables[0].Rows[0]["Account_Status_id"].ToString();

                            //01-Pending
                            if (Studentstatus == "01")
                            {
                                listudentstatus.Visible = true;
                                //liregno.Visible = false;
                                lblstdstaus.Text = "Student Status : Pending";
                                badgeError.Visible = true;

                            }
                            else if (Studentstatus == "03")
                            {                               
                                    listudentstatus.Visible = true;
                                    //liregno.Visible = false;
                                    lblstdstaus.Text = "Student Status : Confirmed";
                                    badgeSuccess.Visible = true;
                            }
                            else if (Studentstatus == "02")
                            {
                                listudentstatus.Visible = true;
                                //liregno.Visible = false;
                                lblstdstaus.Text = "Student Status : Cancelled";
                                Span1.Visible = true;
                            }



                            BindPayee(lblDivCode_Result1.Text);
                            if (ds.Tables[0].Rows[0]["SubmitLoanFlag"].ToString() == "1") //Pending
                            {
                                ddlLoanAppStatus.Enabled = true;
                                btnSave.Visible = true;
                                dlpaymentreceipt.Visible = false;
                            }  
                            else if (ds.Tables[0].Rows[0]["SubmitLoanFlag"].ToString() == "2")//Approved
                            {                                
                                Tdtrue();
                                ddlLoanAppStatus.Enabled = false;
                                btnSave.Visible = false;
                                //txtRemark.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                                lblRemark.Visible = true;
                                txtRemark.Visible = false;
                                lblRemark.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                                txtLoanApproveAmount.Text = ds.Tables[0].Rows[0]["ApprovalLoanAmount"].ToString();
                                txtpaydate.Text = ds.Tables[0].Rows[0]["ApprovalLoanDate"].ToString();
                                //ApprovalLoanAmount
                                Bindpayment(lblSBEntryCodet_Result1.Text);
                                dlpaymentreceipt.Visible = true;
                                ddlpaymode.Visible = false;
                                Label8.Visible = false;
                                label59.Visible = false;
                            }
                            else if (ds.Tables[0].Rows[0]["SubmitLoanFlag"].ToString() == "3") //Rejected
                            {
                                ddlLoanAppStatus.Enabled = false;
                                btnSave.Visible = false;
                                //txtRemark.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                                lblRemark.Visible = true;
                                txtRemark.Visible = false;
                                lblRemark.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                                txtpaydate.Text = ds.Tables[0].Rows[0]["ApprovalLoanDate"].ToString();
                                dlpaymentreceipt.Visible = false;
                            }

                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                                {
                                    if (ds.Tables[1].Rows[i]["voucher_description"].ToString() == "Net Fees")
                                    {
                                        lblNetFees_Result1.Text = ds.Tables[1].Rows[i]["voucher_amt"].ToString();
                                    }
                                    else if (ds.Tables[1].Rows[i]["voucher_description"].ToString() == "Realised")
                                    {
                                        lblAmountRec_Result1.Text = ds.Tables[1].Rows[i]["voucher_amt"].ToString();
                                    }
                                    else if (ds.Tables[1].Rows[i]["voucher_description"].ToString() == "Cheque Outstanding")
                                    {
                                        lblBalanceAmount_Result1.Text = ds.Tables[1].Rows[i]["voucher_amt"].ToString();
                                    }
                                    else if (ds.Tables[1].Rows[i]["voucher_description"].ToString() == "PDC in Hand")
                                    {
                                        lblPDCInHand_Result1.Text = ds.Tables[1].Rows[i]["voucher_amt"].ToString();
                                    }                                    
                                }
                            }
                        }
                    }

                }
               
            }
            catch (Exception ex)
            {
                Show_Error_Success_Box("E", ex.ToString());
                //Msg_Error.Visible = true;
                //Msg_Success.Visible = false;
                //lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
                return;
            }
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

        protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            BindDivision();
        }


        protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //dlpaymentreceipt.Visible = false;
            //divpayment.Visible = true;
            
            if (ddlpaymode.SelectedValue == "01")
            {
                tblcheque.Visible = true;
                tblDD.Visible = false;
                tblbankdetails.Visible = true;
                tblcash.Visible = false;
                tblccdc.Visible = false;
                tblNEFT.Visible = false;

                txtchqno.Text = "";
                txtchqdate.Value = "";
                ddlpayee.SelectedIndex = 0;
                txtmicrcode.Text = "";
                txtbankname.Text = "";
                txtbranchname.Text = "";
            }
            else if (ddlpaymode.SelectedValue == "02")
            {
                tblcheque.Visible = false;
                tblDD.Visible = true;
                tblbankdetails.Visible = true;
                tblcash.Visible = false;
                tblccdc.Visible = false;
                tblNEFT.Visible = false;

                txtddno.Text = "";
                txtdddate.Value = "";
                ddlpayeedd.SelectedIndex = 0;

                txtmicrcode.Text = "";
                txtbankname.Text = "";
                txtbranchname.Text = "";

            }
            else if (ddlpaymode.SelectedValue == "03")
            {
                tblcheque.Visible = false;
                tblDD.Visible = false;
                tblbankdetails.Visible = false;
                tblcash.Visible = true;
                tblccdc.Visible = false;
                tblNEFT.Visible = false;

                ddlpayeecash.SelectedIndex = 0;
            }
            else if (ddlpaymode.SelectedValue == "04")
            {
                BindCardtype();
                tblcheque.Visible = false;
                tblDD.Visible = false;
                tblbankdetails.Visible = false;
                tblcash.Visible = false;
                tblccdc.Visible = true;
                tblNEFT.Visible = false;

                txttransid.Text = "";
                txttrandate.Value = "";
                ddlpayeetrans.SelectedIndex = 0;
                ddlcardtype.SelectedIndex = 0;
                txtcardholder.Text = "";
                txtlast4digit.Text = "";

            }
            else if (ddlpaymode.SelectedValue == "05") //NEFT
            {
                tblcheque.Visible = false;
                tblDD.Visible = false;
                tblbankdetails.Visible = false;
                tblcash.Visible = false;
                tblccdc.Visible = false;
                tblNEFT.Visible = true;

                txtNeftRefNo.Text = "";
                //txtNeftDate.Text = "";
                ddlNeftPayee.SelectedIndex = 0;

            }
            else
            {
                tblcheque.Visible = false;
                tblDD.Visible = false;
                tblbankdetails.Visible = false;
                tblcash.Visible = false;
                tblccdc.Visible = false;
                tblNEFT.Visible = false;
            }
            //if (txtShowReceiptAllocation.Text == "1")
            //{
            //    tblAllocationAdd.Visible = true;
            //}
            //else
            //{
            //    tblAllocationAdd.Visible = false;
            //}
            //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#basic').modal('show') });</script>", False)
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlLoanAppStatus.SelectedValue == "1")//Pending
            {
                Show_Error_Success_Box("E","Change Loan Application Status");
                return;
            }
            else if (ddlLoanAppStatus.SelectedValue == "2")//Approve
            {
                SaveData();
            }
            else if (ddlLoanAppStatus.SelectedValue == "3")//Rejected
            {
                if (txtRemark.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E","Enter Remarks");
                    return;
                }
                string Sbentrycode = "";
                decimal Amtinstr = 0;
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                Sbentrycode = lblSBEntryCodet_Result1.Text;
                string SBCode = AccountController.InsertLoan_ApprovalStud(Sbentrycode, ddlLoanAppStatus.SelectedValue, Amtinstr,txtRemark.Text.Trim(),"", UserID);
                if (Sbentrycode != "")
                {
                    ControlVisibility("Search");
                    Show_Error_Success_Box("S", "Student Loan Rejected...!");
                }
                else
                {
                    Show_Error_Success_Box("S", "ERROR...!");
                }
                
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ControlVisibility("Result");
        }

        protected void ddlpayee_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            dlallocation.Visible = true;
            string payeeid = ddlpayee.SelectedValue;
            if (payeeid == "Select")
            {
                dlallocation.Visible = false;
            }
            else
            {
                BindChequeallocationbyPayee(payeeid);
            }

        }

        protected void ddlpayeedd_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            dlallocation.Visible = true;
            string payeeid = ddlpayeedd.SelectedValue;
            if (payeeid == "Select")
            {
                dlallocation.Visible = false;
            }
            else
            {
                BindChequeallocationbyPayee(payeeid);
            }
        }
    
        protected void ddlpayeecash_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            dlallocation.Visible = true;
            string payeeid = ddlpayeecash.SelectedValue;
            if (payeeid == "Select")
            {
                dlallocation.Visible = false;
            }
            else
            {
                BindChequeallocationbyPayee(payeeid);
            }
        }

        protected void ddlLoanAppStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLoanAppStatus.SelectedValue == "1")
                {
                    Tdfalse();

                }
                else if (ddlLoanAppStatus.SelectedValue == "2")
                {
                    Tdtrue();
                    ddlpaymode.SelectedIndex = 0;
                }
                else if (ddlLoanAppStatus.SelectedValue == "3")
                {
                    Tdfalse();
                }
            }
            catch (Exception ex)
            {
                Show_Error_Success_Box("E", ex.ToString());
            }
        }

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
                    string Status1 = ((Label)e.Item.FindControl("lblLocation")).Text;
                    if (Status1 == "Center")
                    {
                        ((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
                        ((Label)e.Item.FindControl("lblAction")).Visible = false;
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("lblAction")).Visible = true;
                    }
                    //((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                    //((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
                }
                else if (Status == "Deposited")
                {
                    //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.RosyBrown
                    ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.Blue;
                    //((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                    //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
                    ((Label)e.Item.FindControl("lblAction")).Visible = true;
                }
                else if (Status == "Cleared")
                {
                    //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.Green
                    ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.DarkCyan;
                    //((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                    //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
                    ((Label)e.Item.FindControl("lblAction")).Visible = true;
                }
                else if (Status == "Bounced")
                {
                    //DirectCast(e.Item.FindControl("lblchequestatus"), Label).BackColor = System.Drawing.Color.Red
                    ((Label)e.Item.FindControl("lblchequestatus")).ForeColor = System.Drawing.Color.Red;
                    //((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                    //((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
                    ((Label)e.Item.FindControl("lblAction")).Visible = true;
                }



            }
        }
        #endregion


        
}
