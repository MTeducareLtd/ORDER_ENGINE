using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Web.UI;

public partial class Petty_Cash_Entry : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            //Page_Validation();
            ControlVisibility("Search");
            FillDDL_Division();
        }
    }
    //need to add this validation;  
    //private void Page_Validation()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];

    //    string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
    //    System.IO.FileInfo Info = new System.IO.FileInfo(Path);
    //    string pageName = Info.Name;

    //    int ResultId = 0;

    //    ResultId = ProductController.Chk_Page_Validation(pageName, UserID, "DB00");

    //    if (ResultId >= 1)
    //    {
    //        //Allow
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Homepage.aspx", false);
    //    }

    //}

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
            DivApproval.Visible = false;
            //BtnAdd.Visible = True
        }
        else if (Mode == "Result")
        {
            DivResultPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivApproval.Visible = false;
            //BtnAdd.Visible = True
        }
        Clear_Error_Success_Box();
    }

    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
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

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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
    private void FillDDL_PeriodMaster()
    {
        string Divisioncode = ddlDivision.SelectedValue;
        string Centercode = ddlCenter.SelectedValue;

        DataSet dsPeriodMaster = ProductController.GetAllActivePerod(Divisioncode, Centercode);
        BindDDL(ddlPeriod, dsPeriodMaster, "Period", "Period_Id");
        ddlPeriod.Items.Insert(0, "Select");
        ddlPeriod.SelectedIndex = 0;



    }

    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlDivision.SelectedValue, "", "MT");
        BindDDL(ddlCenter, ds, "Center_name", "Center_Code");
        //ddlCenter.Items.Insert(0, "All");
        ddlCenter.SelectedIndex = 0;
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }


    private void FillGrid_Chapter()
    {
        //Validate if all information is entered correctly
        if (ddlDivision.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0001");
            ddlDivision.Focus();
            return;
        }

        if (ddlCenter.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0003");
            ddlCenter.Focus();
            return;
        }

        if (ddlPeriod.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0005");
            ddlPeriod.Focus();
            return;
        }

        ControlVisibility("Result");

        string DivisionCode = null;
        DivisionCode = ddlDivision.SelectedValue;

        string center_code = "";
        center_code = ddlCenter.SelectedValue;

        string Period_id = "";
        Period_id = ddlPeriod.SelectedValue;

        DataSet dsGrid = ProductController.GetAllPettycashentry(DivisionCode, center_code, Period_id);




        //Copy dsGrid content from DataSet to DataTable
        DataTable dtGrid = null;
        dtGrid = dsGrid.Tables[0];

        //Add 1 Blank records
        dtGrid.Rows.Add("", "", "", "", "", "", 0, 0, "", "", 0, 1, 1);

        dlGridDisplay.DataSource = dtGrid;

        dlGridDisplay.DataSource = dsGrid;
        dlGridDisplay.DataBind();

        //dlGridExport.DataSource = dsGrid;
        //dlGridExport.DataBind();



        lblDivision_Result.Text = ddlDivision.SelectedItem.ToString();
        lblCenter_Result.Text = ddlCenter.SelectedItem.ToString();
        lblPeriod_Result.Text = ddlPeriod.SelectedItem.ToString();

        lbltotalcount.Text = Convert.ToString(Convert.ToInt16(dsGrid.Tables[0].Rows.Count.ToString()) - 1);




    }


    //public System.Web.UI.WebControls.DropDownList txtDLExpenseID { get; set; }



    protected void dlGridDisplay_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var txtDLExpenseID = e.Item.FindControl("txtDLExpenseID") as DropDownList;

            if (!string.IsNullOrEmpty(txtDLExpenseID.Text.ToString()))
            {
                //txtDLExpenseID.DataSource = dsexpense;
                //txtDLExpenseID.DataTextField = "txtDLExpenseID";
                //txtDLExpenseID.DataBind();

            }
            else
            {


                DataSet dsexpense = ProductController.GetAllPettycashexpenseType("", "1");
                BindDDL(txtDLExpenseID, dsexpense, "voucher_name", "voucher_id");
                txtDLExpenseID.Items.Insert(0, "Select");

                txtDLExpenseID.DataSource = dsexpense;
                txtDLExpenseID.DataTextField = "voucher_name";
                txtDLExpenseID.DataValueField = "voucher_id";
                txtDLExpenseID.DataBind();
                txtDLExpenseID.Items.Insert(0, "Select");

            }



        }

    }


    protected void Btn_approve_Click(object sender, System.EventArgs e)
    {
        if (ddlDivision.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0001");
            return;
        }

        if (ddlCenter.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0006");
            return;
        }

        if (ddlPeriod.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", " Select Period");
            return;
        }
        string DivisionCode = null;
        DivisionCode = ddlDivision.SelectedValue;
        string center_code = null;
        center_code = ddlCenter.SelectedValue;
        string Period_id = null;
        Period_id = ddlPeriod.SelectedValue;

        DataSet dsGrid = ProductController.GetAllPettycashentry_for_approval(DivisionCode, center_code, Period_id);
        if (dsGrid.Tables.Count > 0)
        {
            dlItemListAuthorise.DataSource = dsGrid;
            dlItemListAuthorise.DataBind();
            DivSearchPanel.Visible = false;
            DivApproval.Visible = true;
            Lblresult2_division.Text = ddlDivision.SelectedItem.ToString();
            lblresult2_center.Text = ddlCenter.SelectedItem.ToString();
            lblreslut_period2.Text = ddlPeriod.SelectedItem.ToString();
            Lblcount.Text = Convert.ToString(Convert.ToInt16(dsGrid.Tables[0].Rows.Count.ToString()));

        }



    }


    protected void BtnSaveapproval_Click(object sender, System.EventArgs e)
    {
        Label lbldivisioncode = (Label)FindControl("lbldivisioncode");
        Label lblcentercode = (Label)FindControl("lblcentercode");
        Label lblperiodid = (Label)FindControl("lblperiodid");
        Label Lblvouchertype = (Label)FindControl("Lblvouchertype");
        Label lblamount = (Label)FindControl("lblamount");

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Division = null;
        Division = lbldivisioncode.Text;
        string center = null;
        center = lblcentercode.Text;
        string period = null;
        period = lblperiodid.Text;
        string vouchertype = null;
        vouchertype = Lblvouchertype.Text;
        string amount = null;
        amount = lblamount.Text;


        int ResultId = 0;
        //Mark exemption/absent/present for those students who are selected
        ResultId = ProductController.Insert_Pettycashentry_For_approvals(Division, center, period, vouchertype, amount, UserID, "1");

        if (ResultId == -1)
        {
            Show_Error_Success_Box("E", "");
            return;
        }
    }
    protected void BtnClose_Click(object sender, System.EventArgs e)
    {
        DivSearchPanel.Visible = true;
        DivApproval.Visible = false;

    }




    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {
        FillGrid_Chapter();
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }

    protected void ddlCenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_PeriodMaster();
    }


    protected void txtDLExpenseID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlList = (DropDownList)sender;
        DataListItem row = (DataListItem)ddlList.NamingContainer;

        Label lblDLExpenceNarration = (Label)row.FindControl("lblDLExpenceNarration");
        DropDownList txtDLExpenseID = (DropDownList)row.FindControl("txtDLExpenseID");
        if (!string.IsNullOrEmpty(txtDLExpenseID.SelectedValue.ToString()))
        {

            DataSet dsexpense1 = ProductController.GetAllPettycashexpenseType(txtDLExpenseID.Text, "2");

            try
            {
                //lblDLExpenceNarration.DataSource = dsexpense1;
                //lblDLExpenceNarration.DataTextField = "narration";
                //lblDLExpenceNarration.DataValueField = "narration";
                //lblDLExpenceNarration.DataBind();
                lblDLExpenceNarration.Text = dsexpense1.Tables[0].Rows[0]["narration"].ToString();

            }
            catch
            {
                //if (lblDLExpenceNarration.Items.Count > 0)
                //    lblDLExpenceNarration.SelectedIndex = 0;
            }

            //ddlRefSubject_SelectedIndexChanged(ddlDLRefSubject, e);

            //if (string.IsNullOrEmpty(lblDLChapter.Text) && ddlChapter.Items.Count == 2)
            //{
            //    ddlChapter.SelectedIndex = 1;
            //}

            //ddlChapter_SelectedIndexChanged(ddlChapter, e);
        }

    }









    protected void ddlStandard_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_PeriodMaster();
    }

    protected void BtnShowSearchPanel_Click(object sender, System.EventArgs e)
    {
        ControlVisibility("Search");
    }

    protected void dlGridDisplay_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {

        TextBox txttransdate = (TextBox)e.Item.FindControl("txttransdate");
        TextBox txtDLVoucherNo = (TextBox)e.Item.FindControl("txtDLVoucherNo");
        DropDownList txtDLExpenseID = (DropDownList)e.Item.FindControl("txtDLExpenseID");
        //TextBox txtDLExpenseID = (TextBox)e.Item.FindControl("txtDLExpenseID");
        TextBox lblDLExpenceNarration = (TextBox)e.Item.FindControl("txtDLExpenceNarration");
        TextBox txtDLExpenceDoneBy = (TextBox)e.Item.FindControl("txtDLExpenceDoneBy");
        TextBox txtDLDescription = (TextBox)e.Item.FindControl("txtDLDescription");
        TextBox txtDLAmount = (TextBox)e.Item.FindControl("txtDLAmount");
        System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiveFlag = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("chkActiveFlag");

        HtmlAnchor lbl_DLError = (HtmlAnchor)e.Item.FindControl("lbl_DLError");


        Label lblDLVoucherNo = (Label)e.Item.FindControl("lblDLVoucherNo");
        Label txtDLExpenseID1 = (Label)e.Item.FindControl("txtDLExpenseID1");
        //Label lblDLExpenceNarration1 = (Label)e.Item.FindControl("lblDLExpenceNarration1");
        Label lblDLExpenceDoneBY = (Label)e.Item.FindControl("lblDLExpenceDoneBY");
        Label lblDLStatus = (Label)e.Item.FindControl("lblDLStatus");
        Label lblDLDescription = (Label)e.Item.FindControl("lblDLDescription");
        Label lblDLAmount = (Label)e.Item.FindControl("lblDLAmount");

        LinkButton lnkDLEdit = (LinkButton)e.Item.FindControl("lnkDLEdit");
        LinkButton lnkDLSave = (LinkButton)e.Item.FindControl("lnkDLSave");

        Panel icon_Error = (Panel)e.Item.FindControl("icon_Error");

        if (e.CommandName == "Edit")
        {
            txtDLVoucherNo.Visible = true;
            txtDLExpenseID.Visible = true;
            //lblDLExpenceNarration.Visible = true;
            txtDLExpenceDoneBy.Visible = true;
            txtDLDescription.Visible = true;
            txtDLAmount.Visible = true;

            lblDLVoucherNo.Visible = false;
            //txtDLExpenseID1.Visible = true;
            txtDLExpenseID1.Visible = false;
            lblDLExpenceDoneBY.Visible = false;
            lblDLDescription.Visible = false;
            lblDLAmount.Visible = false;


            lnkDLEdit.Visible = false;
            lnkDLSave.Visible = true;
            icon_Error.Visible = false;

            //txtDLChapterShortName.Focus();
        }
        else if (e.CommandName == "Save")
        {
            //Validation

            if (string.IsNullOrEmpty(txtDLVoucherNo.Text))
            {
                lbl_DLError.Title = "Enter Voucher number";
                icon_Error.Visible = true;
                txtDLVoucherNo.Focus();
                return;
            }


            if (!IsNumeric(txtDLVoucherNo.Text))
            {

                lbl_DLError.Title = "Invalid entry'Only Number can Allowed'";
                icon_Error.Visible = true;
                txtDLVoucherNo.Focus();
                return;
            }

            if (txtDLExpenseID.SelectedIndex == 0)
            {
                lbl_DLError.Title = "Select Expense Type";
                icon_Error.Visible = true;
                txtDLExpenseID.Focus();
                return;

            }

            if (string.IsNullOrEmpty(txtDLExpenceDoneBy.Text))
            {
                lbl_DLError.Title = "Add Name Of The Person";
                icon_Error.Visible = true;
                txtDLExpenceDoneBy.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDLDescription.Text))
            {
                lbl_DLError.Title = "Add Description";
                icon_Error.Visible = true;
                txtDLDescription.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDLAmount.Text))
            {
                lbl_DLError.Title = "Enter Amount";
                icon_Error.Visible = true;
                txtDLAmount.Focus();
                return;
            }


            //Saving part
            string DivisionCode = null;
            DivisionCode = ddlDivision.SelectedValue;

            string Centercode = "";
            Centercode = ddlCenter.SelectedValue;

            string PeriodId = "";
            PeriodId = ddlPeriod.SelectedValue;
            string transId = "";
            transId = txtDLExpenseID.Text;

            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            string CreatedBy = null;
            CreatedBy = UserID;

            string PettycashentryForEdit = "";
            PettycashentryForEdit = e.CommandArgument.ToString();

            //string ActiveFlag = "0";
            //if (chkActiveFlag.Checked == true)            
            //    ActiveFlag = "1";            
            //else            
            //    ActiveFlag = "0";   

            int ResultId = 0;
            //Mark exemption/absent/present for those students who are selected
            ResultId = ProductController.Insert_Pettycashentry(DivisionCode, Centercode, PeriodId, txttransdate.Text, txtDLVoucherNo.Text.Trim(), transId, txtDLExpenceDoneBy.Text.Trim(), txtDLDescription.Text.Trim(), txtDLAmount.Text, "1", CreatedBy, PettycashentryForEdit);

            if (ResultId == -1)
            {
                lbl_DLError.Title = "ERROR";
                icon_Error.Visible = true;
                //txtDLChapterName.Focus();
                return;
            }
            else
            {
                icon_Error.Visible = false;
            }

            //Change look

            txtDLVoucherNo.Visible = false;
            txtDLExpenseID.Visible = false;
            //txtDLExpenceNarration.Visible = false;
            txtDLExpenceDoneBy.Visible = false;
            txtDLDescription.Visible = false;
            txtDLAmount.Visible = false;

            lblDLVoucherNo.Visible = true;
            txtDLExpenseID1.Visible = true;
            //lblDLExpenceNarration1.Visible = true;

            //txtDLExpenceNarration.Visible = true;
            lblDLExpenceDoneBY.Visible = true;
            lblDLDescription.Visible = true;
            //lblDLStatus.Visible = true;
            lblDLAmount.Visible = true;


            lnkDLEdit.Visible = true;
            lnkDLSave.Visible = false;

            FillGrid_Chapter();
        }

    }

    public Petty_Cash_Entry()
    {
        Load += Page_Load;
    }
    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    dlGridExport.Visible = true;

    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.ContentType = "application/vnd.ms-excel";
    //    string filenamexls1 = "Chapter_" + DateTime.Now + ".xls";
    //    Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
    //    HttpContext.Current.Response.Charset = "utf-8";
    //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
    //    //sets font
    //    HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
    //    HttpContext.Current.Response.Write("<BR><BR><BR>");
    //    HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='7'>Chapter</b></TD></TR><TR><TD Colspan='2'><b>Division : " + ddlDivision.SelectedItem.ToString() + "</b></TD><TD Colspan='2'><b>Course : " + ddlCenter.SelectedItem.ToString() + "</b></TD><TD Colspan='3'><b>Subject : " + ddlPeriod.SelectedItem.ToString() + "</b></TD></TR><TR></TR>");
    //    Response.Charset = "";
    //    this.EnableViewState = false;
    //    System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
    //    System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
    //    //this.ClearControls(dladmissioncount)
    //    dlGridExport.RenderControl(oHtmlTextWriter1);
    //    Response.Write(oStringWriter1.ToString());
    //    Response.Flush();
    //    Response.End();

    //    dlGridExport.Visible = false;
    //}
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ddlDivision.SelectedIndex = 0;
        ddlCenter.SelectedIndex = 0;
        ddlPeriod.SelectedIndex = 0;
    }


    private bool IsNumeric(object value)
    {
        try
        {
            int i = Convert.ToInt32(value.ToString());
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    protected void dlGridDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}