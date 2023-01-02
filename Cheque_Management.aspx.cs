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


public partial class Cheque_Management : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPaymode();
                BindPayment_Status();
                ControlVisibility("Search");
            }
        }
        #endregion

        #region Methods

                
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
                BtnShowSearchPanel.Visible = false;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;
            }
            else if (Mode == "Result")
            {
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;                
                BtnShowSearchPanel.Visible = true;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;                
            }            

        }


        private void BindPaymode()
        {
            try
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                DataSet ds = PaymentController.GetallPaymode();
                BindDDL(ddlpaymode, ds, "Description", "id");
                ddlpaymode.Items.Insert(0, "All");
                ddlpaymode.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                Show_Error_Success_Box("E", ex.ToString());
            }
        }

        private void BindPayment_Status()
        {
            try
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                DataSet ds = PaymentController.GetallPaymentStatus();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["StatusCode"].ToString() == "01")//delete Pending Status
                        dr.Delete();
                }

                BindListBox(ddlChTrStatus, ds, "Status", "StatusCode");
            }
            catch (Exception ex)
            {
                Show_Error_Success_Box("E", ex.ToString());
            }
        }


        /// <summary>
        /// Bind search  Datalist
        /// </summary>
        private void FillGrid()
        {
            try
            {
                Clear_Error_Success_Box();

                if (id_date_range_picker_1.Value == "")
                {
                    Show_Error_Success_Box("E", "Select Date Range");
                    id_date_range_picker_1.Focus();
                    return;
                }
                string FromDate = "", ToDate = "", PayMode = "", Ins_No = "", Ins_Status = "";
                string DateRange = "";
                
                if (ddlpaymode.SelectedIndex != 0)
                {
                    for (int cnt = 0; cnt <= ddlChTrStatus.Items.Count - 1; cnt++)
                    {
                        if (ddlChTrStatus.Items[cnt].Selected == true)
                        {
                            Ins_Status = Ins_Status + ddlChTrStatus.Items[cnt].Value + ",";
                        }
                    }

                    if (Ins_Status == "")
                    {
                        Show_Error_Success_Box("E", "Select Instrument Status");
                        return;
                    }

                    PayMode = ddlpaymode.SelectedValue;

                    if (txtChTrNo.Text.Trim() == "")
                        Ins_No = "%%";
                    else
                        Ins_No = txtChTrNo.Text.Trim();                    
                }
                else
                {
                    PayMode = "%%";
                    Ins_No = "%%";
                    for (int cnt = 0; cnt <= ddlChTrStatus.Items.Count - 1; cnt++)
                    {
                        Ins_Status = Ins_Status + ddlChTrStatus.Items[cnt].Value + ",";
                    }
                }

                DateRange = id_date_range_picker_1.Value;
                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;

                ControlVisibility("Result");

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];

                DataSet ds = PaymentController.Get_Cheque_Management(FromDate, ToDate, PayMode, Ins_No, Ins_Status, UserID, "1");
                if (ds != null)
                {
                    dlGridDisplay.DataSource = ds;
                    dlGridDisplay.DataBind();
                }



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


                foreach (DataListItem dtlItem in dlGridDisplay.Items)
                {
                    DropDownList ddlAction = (DropDownList)dtlItem.FindControl("ddlAction");
                    Label lblStatus = (Label)dtlItem.FindControl("lblStatus");
                    Label lblPayModeCode = (Label)dtlItem.FindControl("lblPayModeCode");

                    if (lblStatus.Text == "01")//Pending
                    {
                        ddlAction.Items.Add("Select");
                        ddlAction.Items.Add("Deposited");
                        ddlAction.Items.Add("Blocked");
                    }
                    else if (lblStatus.Text == "04")//Deposited
                    {
                        if (lblPayModeCode.Text == "04")//if Pay mode is CREDIT / DEBIT CARD
                        {
                            ddlAction.Items.Add("Select");
                            ddlAction.Items.Add("Cleared");
                            ddlAction.Items.Add("Bounced");
                            ddlAction.Items.Add("Blocked");
                        }
                        else
                        {
                            ddlAction.Items.Add("Select");
                            ddlAction.Items.Add("Cleared");
                            ddlAction.Items.Add("Bounced");
                           // ddlAction.Items.Add("Blocked");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Show_Error_Success_Box("E",ex.ToString());
                UpdatePanelMsgBox.Update();
                return;
            }
        }

        #endregion


       
        #region Event's
      

        protected void BtnClearSearch_Click(object sender, EventArgs e)
        {
                     
        }
            
        protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
        {
            ControlVisibility("Search");
        }
         

        protected void BtnSearch_Click(object sender, EventArgs e)
        {            
            FillGrid();
        }

        protected void ddlpaymode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlpaymode.SelectedValue == "01")//CHEQUE
            {
                trChequeTransaction.Visible = true;
                lblChTrNo.Text = "Cheque No";
                lblChTrStatus.Text = "Cheque Status";
            }
            else if (ddlpaymode.SelectedValue == "02")//DEMAND DRAFT
            {
                trChequeTransaction.Visible = true;
                lblChTrNo.Text = "DD No";
                lblChTrStatus.Text = "DD Status";
            }
            else if (ddlpaymode.SelectedValue == "04")//CREDIT / DEBIT CARD
            {
                trChequeTransaction.Visible = true;
                lblChTrNo.Text = "Transaction No";
                lblChTrStatus.Text = "Transaction Status";
            }
            else if (ddlpaymode.SelectedValue == "05")//CREDIT / DEBIT CARD
            {
                trChequeTransaction.Visible = true;
                lblChTrNo.Text = "Transaction No";
                lblChTrStatus.Text = "Transaction Status";
            }
            else
            {
                trChequeTransaction.Visible = false;
            }
        }


        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox s = sender as CheckBox;
                //Set checked status of hidden check box to items in grid
                foreach (DataListItem dtlItem in dlGridDisplay.Items)
                {
                    CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
                    if (chkitemck.Visible == true)
                    {
                        DropDownList ddlAction = (DropDownList)dtlItem.FindControl("ddlAction");
                        Label lblErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");

                        chkitemck.Checked = s.Checked;
                        if (s.Checked == true)
                        {
                            ddlAction.Visible = true;
                        }
                        else
                        {
                            ddlAction.Visible = false;
                            ddlAction.SelectedIndex = 0;
                            lblErrorSaveMessage.Text = "";
                        }
                        
                    }
                }
                Clear_Error_Success_Box();
            }
            catch (Exception ex)
            {
                Show_Error_Success_Box("E", ex.ToString());
            }
        }

        protected void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox s = sender as CheckBox;
                dynamic row = (DataListItem)s.NamingContainer;
                DropDownList ddlAction = row.FindControl("ddlAction");
                Label lblErrorSaveMessage = row.FindControl("lblErrorSaveMessage");
                if (s.Checked == true)
                {
                    ddlAction.Visible = true;
                }
                else
                {
                    ddlAction.Visible = false;
                    ddlAction.SelectedIndex = 0;
                    lblErrorSaveMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                Show_Error_Success_Box("E", ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string XMLData = "<Payments>";
            int i = 0, j=0;
            foreach (DataListItem dtlItem in dlGridDisplay.Items)
            {
                
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                
                if (chkCheck.Checked == true)
                {
                    i=1;
                    DropDownList ddlAction = (DropDownList)dtlItem.FindControl("ddlAction");
                    Label lblErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");
                    if (ddlAction.SelectedIndex == 0)
                    {
                        j = -1;
                        lblErrorSaveMessage.CssClass = "red";
                        lblErrorSaveMessage.Text = "Select Status";                        
                    }
                    else
                    {
                        lblErrorSaveMessage.Text = "";
                        Label lblRowNo = (Label)dtlItem.FindControl("lblRowNo");
                        Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
                        Label lblReceipt_Num = (Label)dtlItem.FindControl("lblReceipt_Num");
                        Label lblIns_No = (Label)dtlItem.FindControl("lblIns_No");

                        XMLData = XMLData + "<Payment><RowNo>" + lblRowNo.Text + "</RowNo><SBEntryCode>" + lblSBEntryCode.Text + "</SBEntryCode><Receipt_No>" + lblReceipt_Num.Text + "</Receipt_No><InstrumentNo>"
                                + lblIns_No.Text + "</InstrumentNo><Action>" + ddlAction.SelectedItem.ToString() + "</Action></Payment>";

                    }
                }
            }

            if (i == 1 && j == 0)//if the Error is not come and atleast one Record is selected then save
            {
                XMLData = XMLData + "</Payments>";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string Created_By = cookie.Values["UserID"];
                DataSet ds = new DataSet();
                ds = PaymentController.Update_Cheque_Management(XMLData, Created_By, "1");
                if (ds != null)
                {
                    if (ds.Tables.Count != 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int k = 0;
                            while (ds.Tables[0].Rows.Count > k)
                            {
                                foreach (DataListItem dtlItem in dlGridDisplay.Items)
                                {
                                    Label lblRowNum = (Label)dtlItem.FindControl("lblRowNo");
                                    if (lblRowNum.Text.Trim() == ds.Tables[0].Rows[k]["RowNum"].ToString())
                                    {
                                        Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");
                                        if (ds.Tables[0].Rows[k]["ErrorSaveId"].ToString() == "-2") //Error Record
                                        {
                                            lbErrorSaveMessage.CssClass = "red";
                                            lbErrorSaveMessage.Text = ds.Tables[0].Rows[k]["ErrorSaveMessage"].ToString();
                                        }
                                        else if (ds.Tables[0].Rows[k]["ErrorSaveId"].ToString() == "1") //Save Record
                                        {
                                            lbErrorSaveMessage.CssClass = "green";
                                            lbErrorSaveMessage.Text = ds.Tables[0].Rows[k]["ErrorSaveMessage"].ToString();

                                        }
                                        break;
                                    }
                                }
                                k++;
                            }
                        }
                    }
                }
            }
        }

        
        #endregion



        
}
