using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;


public partial class Cheque_fallout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDL_Division();
            FillDDL_AcadYear();

            if ((Request["Year"] != null) && (Request["division"] != null) && (Request["center"] != null))
            {
                string Year = Request["Year"];
                ddlAcadYear.SelectedValue = Year;
                string Division = Request["division"];
                ddlDivision.SelectedValue = Division;
                ddlDivision_SelectedIndexChanged(sender, e);
                string Center = Request["center"];
                ddlCentre.SelectedValue = Division;
                for (int rcnt = 0; rcnt <= ddlCentre.Items.Count - 1; rcnt++)
                {
                    if (ddlCentre.Items[rcnt].Value == Center)
                    {
                        ddlCentre.Items[rcnt].Selected = true;
                        break;
                    }
                }

                BtnSearch_Click(sender, e);
            }

        }
    }
    private void FillDDL_Division()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
        BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
        ddlDivision.Items.Insert(0, "Select");
        ddlDivision.SelectedIndex = 0;
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
    private void FillDDL_AcadYear()
    {
        DataSet dsAcadYear = ProductController.GetAllActiveUser_AcadYear();
        BindDDL(ddlAcadYear, dsAcadYear, "Description", "Id");
        ddlAcadYear.Items.Insert(0, "Select");
        ddlAcadYear.SelectedIndex = 0;

    }
  
    
    private void FillDDL_Search_Centre()
    {
        string Company_Code = "MT";
        string DBName = "CDB";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivision.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBName);

        BindListBox(ddlCentre, dsCentre, "Center_Name", "Center_Code");
    }
    protected void ddlDivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       
        FillDDL_Search_Centre();
       
    }
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
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            if (ddlDivision.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "0001");
                ddlDivision.Focus();
                return;
            }

            if (ddlAcadYear.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "0002");
                ddlAcadYear.Focus();
                return;
            }

            string DivisionCode = null;
            DivisionCode = ddlDivision.SelectedValue;

            string YearName = null;
            YearName = ddlAcadYear.SelectedItem.ToString();

           
            string CentreCode = "";
            int CentreCnt = 0;
            int CentreSelCnt = 0;
            for (CentreCnt = 0; CentreCnt <= ddlCentre.Items.Count - 1; CentreCnt++)
            {
                if (ddlCentre.Items[CentreCnt].Selected == true)
                {
                    CentreSelCnt = CentreSelCnt + 1;
                }
            }

            if (CentreSelCnt == 0)
            {
                //all are selected
                for (CentreCnt = 0; CentreCnt <= ddlCentre.Items.Count - 1; CentreCnt++)
                {
                    CentreCode = CentreCode + ddlCentre.Items[CentreCnt].Value + ",";
                }
                CentreCode = Common.RemoveComma(CentreCode);
               
            }
            else
            {
                for (CentreCnt = 0; CentreCnt <= ddlCentre.Items.Count - 1; CentreCnt++)
                {
                    if (ddlCentre.Items[CentreCnt].Selected == true)
                    {
                        CentreCode = CentreCode + ddlCentre.Items[CentreCnt].Value + ",";
                    }
                }
                CentreCode = Common.RemoveComma(CentreCode);
              
            }


            DataSet dsGrid = ProductController.GetStudent_DetailsFor_Remark(DivisionCode, YearName, CentreCode, txtsbentrycode.Text, txtchequeno.Text, ddlStatus.SelectedValue, ddlrecoverystatus.SelectedValue, txtexpecjoindatefrm.Value);
            if (dsGrid != null)
            {
                if (dsGrid.Tables[0].Rows.Count > 0)
                {
                    dlGridDisplay.DataSource = dsGrid;
                    dlGridDisplay.DataBind();
                    Repeater1.DataSource = dsGrid;
                    Repeater1.DataBind();
                    lbltotalcount.Text = Convert.ToString(dsGrid.Tables[0].Rows.Count);
                    ControlVisibility("Result");
                    UpdatePanel1.Update();
                }
                else
                {
                    Show_Error_Success_Box("E","No Records Found");
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Close")
        {
            DivSearchPanel.Visible = false;
            Divupdate_Fallout.Visible = true;
            divfalloutupdated.Visible = false;
            divaddremark.Visible = false;
            BtnShowSearchPanel.Visible = true;
        }
        else if (Mode == "Result")
        {
            DivSearchPanel.Visible = false;
            Divupdate_Fallout.Visible = true;
            divfalloutupdated.Visible = false;
            divaddremark.Visible = false;
            BtnShowSearchPanel.Visible = true;
        }
        else if (Mode == "AddRemark")
        {
            DivSearchPanel.Visible = false;
            Divupdate_Fallout.Visible = false;
            divfalloutupdated.Visible = false;
            divaddremark.Visible = true;
            divfalloutupdated.Visible = true;
            BtnShowSearchPanel.Visible = false;
        }
        else if (Mode == "Search")
        {
            DivSearchPanel.Visible = true;
            Divupdate_Fallout.Visible = false;
            divfalloutupdated.Visible = false;
            divaddremark.Visible = false;
            BtnShowSearchPanel.Visible = false;
        }
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        clear_Search();
        Clear_Error_Success_Box();
    }
    protected void clear_Search()
    {
        ddlDivision.SelectedIndex = 0;
        ddlAcadYear.SelectedIndex = 0;
        ddlCentre.SelectedIndex = -1;
        txtsbentrycode.Text = "";
        txtchequeno.Text = "";
        ddlStatus.SelectedIndex = 0;
        ddlrecoverystatus.SelectedIndex = 0;
        txtexpecjoindatefrm.Value = "";
    }

    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }
   
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        ControlVisibility("Result");
        Clear_Close();
        //BtnSearch_Click(this, e);
        
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            if ((ddlRecoveryStatus1.SelectedValue == "Recovered" || ddlRecoveryStatus1.SelectedValue == "Partially Recovered") && ddlChequenoNo.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Cheque No");
                ddlChequenoNo.Focus();
                return;
            }
            if ((ddlRecoveryStatus1.SelectedValue == "Recovered" || ddlRecoveryStatus1.SelectedValue == "Partially Recovered") && ddlamountcollected.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select  fees Amount Collected ");
                ddlamountcollected.Focus();
                return;
            }
            if ((ddlRecoveryStatus1.SelectedValue == "Recovered" || ddlRecoveryStatus1.SelectedValue == "Partially Recovered") && ddlbouncedcharges.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select  Bounced Charges Collected ");
                ddlbouncedcharges.Focus();
                return;
            }
            //if ((ddlRecoveryStatus1.SelectedValue == "Recovered" || ddlRecoveryStatus1.SelectedValue == "Partially Recoverd") && ddlisbounced.SelectedIndex == 0)
            //{
            //    Show_Error_Success_Box("E", "Select IsBounced Panelty Collected");
            //    ddlisbounced.Focus();
            //    return;
            //}
            if (ddlRecoveryStatus1.SelectedValue == "Pending To Recover" && txtfollowupto.Value == "")
            {
                Show_Error_Success_Box("E", "Select Next Followup Date");
                txtfollowupto.Focus();
                return;
            }
            if (txtFollowup_Remark.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Followup Remark");
                txtFollowup_Remark.Focus();
                return;
            }
               
                string Followupdate = "";
                string Isbounced = "0";
                string Chequeno = "";
                string RecoveredAmount = "";
                string feescollected="";
                string Bounced_charges = "";
                if (ddlRecoveryStatus1.SelectedValue == "Recovered" || ddlRecoveryStatus1.SelectedValue == "Partially Recovered")
                {                   
                    Isbounced = "1";//ddlisbounced.SelectedIndex.ToString();
                    Chequeno = ddlChequenoNo.SelectedValue;
                    RecoveredAmount = lblAmount.Text;
                    feescollected = ddlamountcollected.SelectedValue;
                    Bounced_charges = ddlbouncedcharges.SelectedValue;
                }
             
                if (ddlRecoveryStatus1.SelectedValue == "Pending To Recover")
                {
                    Followupdate = txtfollowupto.Value.ToString().Trim();
                    Isbounced = "0";
                    Chequeno = "";
                    RecoveredAmount = "";
                    feescollected = "";                   
                    Bounced_charges = "";
                }
                if (ddlRecoveryStatus1.SelectedValue == "Non Recoverable")
                {
                    Followupdate = "";
                    Isbounced = "0";
                    Chequeno = "";
                    RecoveredAmount = "";
                    feescollected = "";
                    Bounced_charges = "";
                }

                string a = ProductController.InsertUpdate_Student_FollowupRemark(3, ddlDivision.SelectedValue, lblcenter_code.Text, lblstreamcode.Text, lblsbentrycode.Text, lblchequeId.Text, lblchequeNo.Text, txtFollowup_Remark.Text, lblcheque_status.Text, ddlRecoveryStatus1.SelectedValue, Isbounced, Followupdate, Chequeno, RecoveredAmount, feescollected, Bounced_charges, UserID);
                 
            if (a == "1")
            {
                string Pkey = lblsbentrycode.Text + '%' + lblchequeId.Text;
                DataSet Ds = ProductController.GetStudent_Details(2, Pkey);
                if (Ds != null)
                {
                    if (Ds.Tables[1].Rows.Count > 0)
                    {

                        lblFollowupRecords.Visible = false;
                        RFollowupDisplay.DataSource = Ds.Tables[1];
                        RFollowupDisplay.DataBind();
                        Show_Error_Success_Box("S", "Record Saved Successfully");
                        txtFollowup_Remark.Text = "";
                        ddlRecoveryStatus1.SelectedIndex = 0;
                        addFollowup();
                        
                    }
                }
            }
            else
            {
                Show_Error_Success_Box("E","Record Not Save");
            }
            
        }
        catch (Exception ex)
        {
        }
    }
    
   protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "comAdd")
            {
                ControlVisibility("AddRemark");
                lblPkey.Text =e.CommandArgument.ToString();

                DataSet Ds = ProductController.GetStudent_Details(2, lblPkey.Text);

                if (Ds != null)
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        lblStudentName.Text = Ds.Tables[0].Rows[0]["Student_Name"].ToString();
                        lblsbentrycode.Text = Ds.Tables[0].Rows[0]["SBEntrycode"].ToString();
                        lblcenter_code.Text = Ds.Tables[0].Rows[0]["CenterCode"].ToString();
                        lblCenterName.Text = Ds.Tables[0].Rows[0]["CENTER"].ToString();
                        lblstreamname.Text = Ds.Tables[0].Rows[0]["Stream_Name"].ToString();
                        lblstreamcode.Text = Ds.Tables[0].Rows[0]["Stream_Code"].ToString();
                        lblchequeNo.Text = Ds.Tables[0].Rows[0]["Pay_InsNum"].ToString();
                        lblcheque_status.Text = Ds.Tables[0].Rows[0]["Cheque_Status"].ToString();
                        lblchequeId.Text = Ds.Tables[0].Rows[0]["ChequeIDNo"].ToString();
                        lblinstrumentAmount.Text = Ds.Tables[0].Rows[0]["Amount"].ToString();
                        DataSet Dscheque = ProductController.GetStudent_ChequeDetails(4, lblsbentrycode.Text, lblcenter_code.Text,"");
                        BindDDL(ddlChequenoNo, Dscheque, "Cheque_No", "chequeid");
                        ddlChequenoNo.Items.Insert(0, "Select");
                        ddlChequenoNo.SelectedIndex = 0;
                        addFollowup();
                       
                    }
                    if (Ds.Tables[1].Rows.Count > 0)
                    {

                        lblFollowupRecords.Visible = false;
                        RFollowupDisplay.DataSource = Ds.Tables[1];
                        RFollowupDisplay.DataBind();
                        
                    }
                    else
                    {
                        lblFollowupRecords.Visible = true;
                        lblFollowupRecords.Text = "No Followup Records Found";
                        RFollowupDisplay.DataSource = null;
                        RFollowupDisplay.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
   private void Clear_Close()
   {
       lblStudentName.Text = "";
       lblsbentrycode.Text ="";
       lblcenter_code.Text ="";
       lblCenterName.Text ="";
       lblstreamname.Text = "";
       lblstreamcode.Text = "";
       lblStudentName.Text ="";
       lblchequeNo.Text = "";
       lblchequeId.Text ="";
       txtFollowup_Remark.Text = "";
       ddlRecoveryStatus1.SelectedIndex = 0;
   }
   protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
   {
       Clear_Error_Success_Box();
       ControlVisibility("Search");

       
   }
   //protected void HLExport_Click(object sender, EventArgs e)
   //{
   //    Repeater1.Visible = true;

   //    Response.Clear();
   //    Response.Buffer = true;
   //    Response.ContentType = "application/vnd.ms-excel";
   //    string filenamexls1 = "ChequeFollowup" + DateTime.Now + ".xls";
   //    Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
   //    HttpContext.Current.Response.Charset = "utf-8";
   //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
   //    //sets font
   //    HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
   //    HttpContext.Current.Response.Write("<BR><BR><BR>");
   //    HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='14'>Cheque Followup</b></TD></TR>");
   //    // HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='12'>Asset Tracking Register Report</b></TD></TR>");
   //    Response.Charset = "";
   //    this.EnableViewState = false;
   //    System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
   //    System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
   //    //this.ClearControls(dladmissioncount)
   //    Repeater1.RenderControl(oHtmlTextWriter1);
   //    Response.Write(oStringWriter1.ToString());
   //    Response.Flush();
   //    Response.End();

   //    Repeater1.Visible = false;

   //}
   private void addFollowup()
   {
      // followupdate.Visible = false;
       folpdate.Visible = false;
       cheque.Visible = false;
       folpdate.Visible = false;
       TrFollowup.Visible = false;
       btnsave.Visible = false;
       lblAmount.Visible = false;
       followupdate1.Visible = false;
       lblAmount.Text = "";
       txtfollowupto.Value = "";
       ddlChequenoNo.SelectedIndex = 0;
       ddlamountcollected.SelectedIndex = 0;
       ddlRecoveryStatus1.SelectedIndex = 0;
       //ddlisbounced.SelectedIndex = 0;
       ddlbouncedcharges.SelectedIndex = 0;
       
   }
   protected void ddlRecoveryStatus1_SelectedIndexChanged(object sender, EventArgs e)
   {
       Clear_Error_Success_Box();
       if (ddlRecoveryStatus1.SelectedValue == "Pending To Recover")
       {
           //followupdate.Visible = true;
           folpdate.Visible = true;
           followupdate1.Visible = false;
           cheque.Visible = false;
           btnsave.Visible = true;
           TrFollowup.Visible = true;
          // TrFollowup.Visible = false;
           //btnsave.Visible = false;
           UpdatePanel1.Update();
       }
       if (ddlRecoveryStatus1.SelectedValue == "Recovered" || ddlRecoveryStatus1.SelectedValue == "Partially Recovered")
       {
           //followupdate.Visible = false;
           folpdate.Visible = false;
           cheque.Visible = true;
           followupdate1.Visible = true;
           TrFollowup.Visible = true;
           folpdate.Visible = false;
           btnsave.Visible = true;
           
           UpdatePanel1.Update();
       }
       if (ddlRecoveryStatus1.SelectedValue == "Non Recoverable")
       {
           //followupdate.Visible = true;
           folpdate.Visible = false;
           followupdate1.Visible = false;
           cheque.Visible = false;
           btnsave.Visible = true;
           TrFollowup.Visible = true;
           // TrFollowup.Visible = false;
           //btnsave.Visible = false;
           UpdatePanel1.Update();
       }
       if (ddlRecoveryStatus1.SelectedValue == "Select")
       {
           addFollowup();
          
       }
       UpdatePanel1.Update();
   }
   protected void ddlChequenoNo_SelectedIndexChanged(object sender, EventArgs e)
   {
       if (ddlChequenoNo.SelectedValue != "")
       {
           DataSet DschequeAmount = ProductController.GetStudent_ChequeDetails(5, lblsbentrycode.Text, lblcenter_code.Text, ddlChequenoNo.SelectedValue);
           lblAmount.Visible = true;
           lblAmount.Text = DschequeAmount.Tables[0].Rows[0]["Amount"].ToString();
       }
       else
       {
           lblAmount.Visible = false;
           lblAmount.Text = "";
       }
       UpdatePanel1.Update();
   }
}