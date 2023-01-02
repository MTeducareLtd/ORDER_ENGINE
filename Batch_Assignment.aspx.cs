using ShoppingCart.BL;
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
using LMS_UserDetails;
using iTextSharp.text;
using iTextSharp.text.pdf;





public partial class Batch_Assignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            Page_Validation();
            ControlVisibility("Search");
            FillDDL_Division();
            FillDDL_AcadYear();

        }
    }

    private void Page_Validation()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;

        int ResultId = 0;

        ResultId = ProductController.Chk_Page_Validation(pageName, UserID, "DB01");

        if (ResultId >= 1)
        {
            //Allow
        }
        else
        {
            Response.Redirect("~/Dashboard_Center.aspx", false);
        }

    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
            DivAddPanel.Visible = false;
            DivViewStudDetail.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivResultPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivAddPanel.Visible = false;
            DivViewStudDetail.Visible = false;
        }
        else if (Mode == "Manage")
        {
            DivAddPanel.Visible = true;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivViewStudDetail.Visible = false;
        }
        else if (Mode == "ViewDetail")
        {
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivViewStudDetail.Visible = true;
        }
        Clear_Error_Success_Box();
    }


    protected void BtnCloseAdd_Click(object sender, System.EventArgs e)
    {
        ControlVisibility("Result");
    }


    protected void dlGridDisplay_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Manage")
        {
            ControlVisibility("Manage");
            lblPKey_Add.Text = e.CommandArgument.ToString();
            FillBatchDetails(lblPKey_Add.Text);
            BindddlClassroomproduct(lblPKey_Add.Text);

        }
        if (e.CommandName == "ViewDetail")
        {
            ControlVisibility("ViewDetail");
            lblPKey_Add.Text = e.CommandArgument.ToString();
            FillBatch_StudentViewDetails(lblPKey_Add.Text);
        }
        else if (e.CommandName == "Delete")
        {
            lbldelCode.Text = e.CommandArgument.ToString();
            txtDeleteItemName.Text = (((Label)e.Item.FindControl("lblModeName")).Text);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDelete();", true);
        }
    }

    private void FillBatchDetails(string PKey)
    {
        try
        {
            string streamcode = "";
            DataSet dsBatch = ProductController.GetBatchBY_PKey(PKey);

            if (dsBatch.Tables[0].Rows.Count > 0)
            {
                lblDivision_Add.Text = lblDivision_Result.Text;
                lblAcadYear_Add.Text = lblAcadYear_Result.Text;
                lblStandard_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Standard_Name"]);
                lblCentre_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Centre_Name"]);
                lblBatchName_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["BatchName"]);
                lblBatchShortName_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["BatchShortName"]);
                lblProducts_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Products"]);
                lblSubjects_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Subjects"]);
                lblMaxBatchStrength_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["MaxCapacity"]);
                streamcode = Convert.ToString(dsBatch.Tables[0].Rows[0]["Streamcode"]);
                lbllmsproductname.Text = Convert.ToString(dsBatch.Tables[3].Rows[0]["ProductName"]);
            }

            dlGridDisplay_Pending.DataSource = dsBatch.Tables[1];
            dlGridDisplay_Pending.DataBind();

            dlGridDisplay_Selected.DataSource = dsBatch.Tables[2];
            dlGridDisplay_Selected.DataBind();

            lblPendingRecCnt.Text = Convert.ToString(dsBatch.Tables[1].Rows.Count);
            lblCurrentRecCnt.Text = Convert.ToString(dsBatch.Tables[2].Rows.Count);

            btnStud_SaveRollNo.Visible = false;
            btnStud_EditRollNo.Visible = true;


            BindddlInstitute();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.Message);
            return;
        }

    }

    private void FillBatch_StudentViewDetails(string PKey)
    {
        try
        {
            string streamcode = "";
            DataSet dsBatch = ProductController.GetBatchStudentDetailBY_PKey(PKey, 1);

            if (dsBatch.Tables[0].Rows.Count > 0)
            {
                lblViewDetailDivision_Result.Text = lblDivision_Result.Text;
                lblViewDetailAcadYear_Result.Text = lblAcadYear_Result.Text;
                lblViewDetailCourse_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Standard_Name"]);
                lblViewDetailCenter_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Centre_Name"]);
                lblViewDetailBatch_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["BatchName"]);
                lblViewDetailBatchShortName_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["BatchShortName"]);
                lblViewDetailClassroomProduct_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Products"]);
                lblViewDetailSubjects_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Subjects"]);
                lblViewDetailMaxBatchStrength_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["MaxCapacity"]);
                lblViewDetailLMSProduct_Result.Text = Convert.ToString(dsBatch.Tables[2].Rows[0]["ProductName"]);
            }

            dlViewDetail.DataSource = dsBatch.Tables[1];
            dlViewDetail.DataBind();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.Message);
            return;
        }

    }

    private void BindddlClassroomproduct(string PKey)
    {
        DataSet ds = ProductController.GetAllClassroomProduct_ByPKEY(PKey);
        BindDDL(ddlclassroomproduct, ds, "Stream_Sdesc", "Stream_Code");
        ddlclassroomproduct.Items.Insert(0, "Select");
        ddlclassroomproduct.SelectedIndex = 0;
    }


    protected void ddlClassroom_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string streamcode = ddlclassroomproduct.SelectedValue;
        Bindddlsubjectgroup(streamcode);
    }


    private void Bindddlsubjectgroup(string streamcode)
    {
        DataSet ds = ProductController.GetallSubjectGroupbyStreamCode(streamcode.Trim());
        BindDDL(ddlsubjectgroup, ds, "SGR_DESC", "SGR_MATERIAL");
        ddlsubjectgroup.Items.Insert(0, "Select");
        ddlsubjectgroup.SelectedIndex = 0;
    }

    private void BindddlInstitute()
    {
        DataSet ds = ProductController.GetallInstitutename();
        BindDDL(ddlInstitute, ds, "Institution_Description", "Institution_Description");
        ddlInstitute.Items.Insert(0, "All");
        ddlInstitute.SelectedIndex = 0;
    }

    protected void btnRedefine_ServerClick(object sender, System.EventArgs e)
    {
        DataSet dsBatch = ProductController.GetBatchBY_PKey_SubjectGrp(lblPKey_Add.Text, ddlsubjectgroup.SelectedValue, ddlInstitute.SelectedValue, ddlclassroomproduct.SelectedValue);
        dlGridDisplay_Pending.DataSource = dsBatch.Tables[0];
        dlGridDisplay_Pending.DataBind();
    }

    protected void btnresetsearch_ServerClick(object sender, System.EventArgs e)
    {
        FillBatchDetails(lblPKey_Add.Text);
    }
    protected void BtnShowSearchPanel_Click(object sender, System.EventArgs e)
    {
        ControlVisibility("Search");
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

    private void FillDDL_Division()
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddlDivision, ds, "Division_Name", "Division_Code");
        ddlDivision.Items.Insert(0, "Select");
        ddlDivision.SelectedIndex = 0;


    }

    private void FillDDL_AcadYear()
    {
        DataSet dsAcadYear = ProductController.GetAllActiveUser_AcadYear();
        BindDDL(ddlAcadYear, dsAcadYear, "Description", "Id");
        ddlAcadYear.Items.Insert(0, "Select");
        ddlAcadYear.SelectedIndex = 0;
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


    private void Clear_AddPanel()
    {
    }

    //protected void ddlDivision_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    //FillDDL_Standard();
    //    //FillDDL_Search_Centre();
    //    //Clear_Error_Success_Box();
    //}

    protected void ddlDivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZoneSearch();
    }

    private void BindZoneSearch()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddlDivision.SelectedValue, "", "MT");
        BindDDL(ddlzonesearch, ds, "Zone_Name", "Zone_Code");
        ddlzonesearch.Items.Insert(0, "Select");
        ddlzonesearch.SelectedIndex = 0;
    }

    protected void ddlzonesearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_Search_Centre();
        FillDDL_Standard();
        Clear_Error_Success_Box();
    }

    private void FillDDL_Search_Centre()
    {
        //Label lblHeader_Company_Code = default(Label);
        //lblHeader_Company_Code = (Label)Master.FindControl("lblHeader_Company_Code");

        //Label lblHeader_User_Code = default(Label);
        //lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

        //Label lblHeader_DBName = default(Label);
        //lblHeader_DBName = (Label)Master.FindControl("lblHeader_DBName");

        //string Div_Code = null;
        //Div_Code = ddlDivision.SelectedValue;

        //DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(lblHeader_User_Code.Text, lblHeader_Company_Code.Text, Div_Code, "", "5", lblHeader_DBName.Text);
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet dsCentre = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddlDivision.SelectedValue, ddlzonesearch.SelectedValue, "MT");
        BindListBox(ddlCentre, dsCentre, "Center_Name", "Center_Code");

        //BindListBox(ddlCentre, dsCentre, "Center_Name", "Center_Code");
    }

    protected void ddlsubjectgroup_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_Subjectgroup();
    }

    private void FillDDL_Standard()
    {
        string Div_Code = null;
        Div_Code = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();

        DataSet dsStandard = ProductController.GetAllActive_Standard_ForYear(Div_Code, YearName);
        BindListBox(ddlStandard, dsStandard, "Standard_Name", "Standard_Code");
        //ddlStandard.Items.Insert(0, "All")
        //ddlStandard.SelectedIndex = 0
    }

    private void FillDDL_Subjectgroup()
    {
        string Div_Code = null;
        Div_Code = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();

        //string Standardcode = null;

        string Standardcode = null;
        int SCode = 0;
        for (SCode = 0; SCode <= ddlStandard.Items.Count - 1; SCode++)
        {
            if (ddlStandard.Items[SCode].Selected == true)
            {
                //Stream_Code = Stream_Code & "'" & ddlProduct_Add.Items(PrdCnt).Value & "',"
                Standardcode = Standardcode + ddlStandard.Items[SCode].Value + ",";
            }
        }
        if (Standardcode != null)
        {
            Standardcode = Common.RemoveComma(Standardcode);
        }
        //DataSet dsStandard = ProductController.GetAllActive_Standard_ForYear(Div_Code, YearName);
        //BindListBox(ddlStandard, dsStandard, "Standard_Name", "Standard_Code");

    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_Standard();
        Clear_Error_Success_Box();
    }

    public void All_Student_ChkBox_Selected(object sender, System.EventArgs e)
    {
        //Change checked status of a hidden check box
        chkStudentAllHidden.Checked = !(chkStudentAllHidden.Checked);

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlGridDisplay_Pending.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");

            chkitemck.Checked = chkStudentAllHidden.Checked;
        }

    }

    public void All_Student_ChkBox_Selected_Sel(object sender, System.EventArgs e)
    {
        //Change checked status of a hidden check box
        chkStudentAllHidden_Sel.Checked = !(chkStudentAllHidden_Sel.Checked);

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");

            chkitemck.Checked = chkStudentAllHidden_Sel.Checked;
        }

    }

    protected void btnStud_AddToBatch_ServerClick(object sender, System.EventArgs e)
    {
        //Add selected students in current batch and refresh both the datalists
        //LMS_UserDetails.OE_UserDetailsSoap Client = new LMS_UserDetails.OE_UserDetailsSoapClient();
        //validation
        int SelCnt = 0;
        string SBEntryCode = "";
        SelCnt = 0;
        foreach (DataListItem dtlItem in dlGridDisplay_Pending.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
            if (chkitemck.Checked == true)
            {
                SelCnt = SelCnt + 1;
                SBEntryCode = SBEntryCode + lblSBEntryCode.Text + ",";
            }
        }
        if (SelCnt == 0)
        {
            Show_Error_Success_Box("E", "0007");
            return;
        }
        //if (Strings.Right(SBEntryCode, 1) == ",")
        //    SBEntryCode = Strings.Left(SBEntryCode, Strings.Len(SBEntryCode) - 1);

        SBEntryCode = Common.RemoveComma(SBEntryCode);

        //Check if number of students selected is becoming more than max strength of the batch
        int MaxStrength = 0;
        MaxStrength = Convert.ToInt32(lblMaxBatchStrength_Add.Text);

        int CurStrength = 0;
        CurStrength = Convert.ToInt32(lblCurrentRecCnt.Text);

        int NewStrength = 0;
        NewStrength = SelCnt;

        if (MaxStrength < CurStrength + NewStrength)
        {
            Show_Error_Success_Box("E", "0008");
            return;
        }

        //Save
        int ResultId = 0;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //Label lblHeader_User_Code = default(Label);
        //lblHeader_User_Code = UserID;

        string CreatedBy = null;
        CreatedBy = UserID;

        string PKey = null;
        //S0%2013-2014%S0%S001%B10001
        PKey = lblPKey_Add.Text;

        ResultId = ProductController.Insert_Batch_Students(PKey, SBEntryCode, 1, CreatedBy);

        if (ResultId == 1)
        {
            DataSet dsdetails = ProductController.LMS_PassAllStudentdetailstoLMSApp(PKey);
            //Client.UpdUserBatchDetails (dsdetails, "1");
            FillBatchDetails(PKey);
            UpdatePanelStudList.Update();
        }
    }

    protected void btnStud_RemoveFromBatch_ServerClick(object sender, System.EventArgs e)
    {
        //Remove selected students from the current batch
        //validation
        int SelCnt = 0;
        string SBEntryCode = "";
        SelCnt = 0;
        foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
            if (chkitemck.Checked == true)
            {
                SelCnt = SelCnt + 1;
                SBEntryCode = SBEntryCode + lblSBEntryCode.Text + ",";
            }
        }
        if (SelCnt == 0)
        {
            Show_Error_Success_Box("E", "0007");
            return;
        }
        //if (Strings.Right(SBEntryCode, 1) == ",")
        //    SBEntryCode = Strings.Left(SBEntryCode, Strings.Len(SBEntryCode) - 1);

        SBEntryCode = Common.RemoveComma(SBEntryCode);

        //Save
        int ResultId = 0;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //Label lblHeader_User_Code = default(Label);
        //lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

        string CreatedBy = null;
        //CreatedBy = lblHeader_User_Code.Text;
        CreatedBy = UserID;

        string PKey = null;
        //S0%2013-2014%S0%S001%B10001
        PKey = lblPKey_Add.Text;

        ResultId = ProductController.Insert_Batch_Students(PKey, SBEntryCode, 2, CreatedBy);

        if (ResultId == 1)
        {
            FillBatchDetails(PKey);
            UpdatePanelStudList.Update();

        }
    }

    protected void btnStud_EditRollNo_ServerClick(object sender, System.EventArgs e)
    {

        foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
        {
            Label lblStudentRollNo = (Label)dtlItem.FindControl("lblStudentRollNo");
            TextBox txtStudentRollNo = (TextBox)dtlItem.FindControl("txtStudentRollNo");

            lblStudentRollNo.Visible = false;
            txtStudentRollNo.Visible = true;
        }

        btnStud_SaveRollNo.Visible = true;
        btnStud_EditRollNo.Visible = false;
    }

    protected void btnStud_SaveRollNo_ServerClick(object sender, System.EventArgs e)
    {

        foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
        {
            Label lblStudentRollNo = (Label)dtlItem.FindControl("lblStudentRollNo");
            Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
            TextBox txtStudentRollNo = (TextBox)dtlItem.FindControl("txtStudentRollNo");

            if (lblStudentRollNo.Text == txtStudentRollNo.Text)
            {
                //There is no change in roll number hence no need to save
                goto NextStudent;
            }

            string SBEntryCode = null;
            SBEntryCode = lblSBEntryCode.Text;

            string PKey = null;
            //S0%2013-2014%S0%S001%B10001
            PKey = lblPKey_Add.Text;

            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            CreatedBy = lblHeader_User_Code.Text;

            int ResultId = 0;
            ResultId = ProductController.Update_Batch_Student_RollNo(PKey, SBEntryCode, txtStudentRollNo.Text, CreatedBy);

            //Check if same student is getting multiple roll numbers
            //Check if same roll number is getting assigned to multiple students
            if (ResultId == 1)
            {
                lblStudentRollNo.Text = txtStudentRollNo.Text;
                lblStudentRollNo.ForeColor = System.Drawing.Color.Black;
            }
            else if (ResultId == -1)
            {
                //do nothing
                lblStudentRollNo.ForeColor = System.Drawing.Color.Red;
                txtStudentRollNo.Text = lblStudentRollNo.Text;

                //Stop and throw error
                Show_Error_Success_Box("E", "Roll No " + txtStudentRollNo.Text + " is already assigned to another student");
                return;
            }
            else if (ResultId == -2)
            {
                //do nothing
                lblStudentRollNo.ForeColor = System.Drawing.Color.Red;
                txtStudentRollNo.Text = lblStudentRollNo.Text;

                //Stop and throw error
                Show_Error_Success_Box("E", "Roll No " + txtStudentRollNo.Text + " can't be saved as another Roll No is assigned to student in other batch");
                return;
            }
        NextStudent:

            lblStudentRollNo.Visible = true;
            txtStudentRollNo.Visible = false;
        }
        btnStud_SaveRollNo.Visible = false;
        btnStud_EditRollNo.Visible = true;

    }

    protected void btnSaveBatchShortName_ServerClick(object sender, System.EventArgs e)
    {
        string PKey = null;
        //S0%2013-2014%S0%S001%B10001
        PKey = lblPKey_Add.Text;

        Label lblHeader_User_Code = default(Label);
        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

        string CreatedBy = null;
        CreatedBy = lblHeader_User_Code.Text;

        int ResultId = 0;
        ResultId = ProductController.Update_Batch_ShortName(PKey, lblBatchShortName_Add.Text, CreatedBy);

        if (ResultId == 1)
        {
            Show_Error_Success_Box("S", "0000");
        }
    }

    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {
        //Validate if all information is entered correctly
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

        ControlVisibility("Result");

        string DivisionCode = null;
        DivisionCode = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();

        string StandardCode = "";
        int StdCnt = 0;
        int StdSelCnt = 0;
        for (StdCnt = 0; StdCnt <= ddlStandard.Items.Count - 1; StdCnt++)
        {
            if (ddlStandard.Items[StdCnt].Selected == true)
            {
                StdSelCnt = StdSelCnt + 1;
            }
        }

        if (StdSelCnt == 0)
        {
            //When all is selected
            for (StdCnt = 0; StdCnt <= ddlStandard.Items.Count - 1; StdCnt++)
            {
                StandardCode = StandardCode + ddlStandard.Items[StdCnt].Value + ",";
            }
            //if (Strings.Right(StandardCode, 1) == ",")
            //    StandardCode = Strings.Left(StandardCode, Strings.Len(StandardCode) - 1);
            StandardCode = Common.RemoveComma(StandardCode);
        }
        else
        {
            for (StdCnt = 0; StdCnt <= ddlStandard.Items.Count - 1; StdCnt++)
            {
                if (ddlStandard.Items[StdCnt].Selected == true)
                {
                    StandardCode = StandardCode + ddlStandard.Items[StdCnt].Value + ",";
                }
            }
            //if (Strings.Right(StandardCode, 1) == ",")
            //    StandardCode = Strings.Left(StandardCode, Strings.Len(StandardCode) - 1);
            StandardCode = Common.RemoveComma(StandardCode);
        }

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

        }

        string BatchName = null;
        if (string.IsNullOrEmpty(txtBatchName.Text.Trim()))
        {
            BatchName = "%";
        }
        else
        {
            BatchName = "%" + txtBatchName.Text.Trim();
        }

        DataSet dsGrid = ProductController.GetBatchBy_Division_Year_Standard_Centre(DivisionCode, YearName, StandardCode, CentreCode, BatchName);
        dlGridDisplay.DataSource = dsGrid;
        dlGridDisplay.DataBind();

        dlGridExport.DataSource = dsGrid;
        dlGridExport.DataBind();

        lblDivision_Result.Text = ddlDivision.SelectedItem.ToString();
        lblAcadYear_Result.Text = ddlAcadYear.SelectedItem.ToString();
        lbltotalcount.Text = Convert.ToString(dsGrid.Tables[0].Rows.Count);
    }

    protected void btnStud_AssignRollNo_ServerClick(object sender, System.EventArgs e)///NFFFF  server click events
    {
        Label lblHeader_User_Code = default(Label);
        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

        string PKey = null;
        PKey = lblPKey_Add.Text;
        string CreatedBy = null;
        CreatedBy = lblHeader_User_Code.Text;
        DataSet ds = ProductController.Update_RollNo_Student(PKey, CreatedBy, "1");
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() == "1")
                {
                    FillBatchDetails(PKey);
                    Show_Error_Success_Box("S", "Roll No Assigned successfully");
                }
                else if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() == "-1")
                {
                    Show_Error_Success_Box("E", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());//
                }
            }
        }
    }

    public Batch_Assignment()
    {
        Load += Page_Load;
    }


    protected void btnPrintHallTicket_ServerClick(object sender, System.EventArgs e)
    {
        //Print PDF
        try
        {
            Clear_Error_Success_Box();
            int SelCnt = 0;
            string SBEntryCode = "";
            SelCnt = 0;
            foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
                if (chkitemck.Checked == true)
                {
                    SelCnt = SelCnt + 1;
                    SBEntryCode = SBEntryCode + lblSBEntryCode.Text + ",";
                }
            }
            if (SelCnt == 0)
            {
                Show_Error_Success_Box("E", "0007");
                return;
            }
            txtCenterName.Text = "";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalHallTicket();", true);



        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
            return;
        }
    }

    protected void btn_Next_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCenterName.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Exam Center Name");
                return;
            }

            if (ddlDivision.SelectedValue == "D0")
            {

                //string DispatchCode = null, UserID=null;
                //DispatchCode = Request.QueryString["DispatchCode"];
                //UserID = Request.QueryString["UserID"];
                DataSet ds = null;

                dynamic document = new Document(PageSize.A4, 50, 50, 20, 20);



                // Create a new PdfWriter object, specifying the output stream
                dynamic output = new MemoryStream();
                dynamic writer = PdfWriter.GetInstance(document, output);

                dynamic TitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                dynamic subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
                dynamic boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                dynamic endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                dynamic bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
                BaseFont font_bold = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);




                // Open the Document for writing

                document.Open();
                foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
                {
                    CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                    if (chkitemck.Checked == true)
                    {
                        var content = writer.DirectContent;
                        var pageBorderRect = new Rectangle(document.PageSize);
                        Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
                        Label lblStudDOB = (Label)dtlItem.FindControl("lblStudDOB");
                        Label lblGender = (Label)dtlItem.FindControl("lblGender");
                        Label lblStudentName = (Label)dtlItem.FindControl("lblStudentName");
                        Label lblMotherName = (Label)dtlItem.FindControl("lblMotherName");
                        Label LblInstitutionDescription = (Label)dtlItem.FindControl("LblInstitutionDescription");
                        Label lblStudentRollNo = (Label)dtlItem.FindControl("lblStudentRollNo");
                        

                        pageBorderRect.Left -= document.LeftMargin;
                        pageBorderRect.Right += document.RightMargin;
                        pageBorderRect.Top += document.TopMargin;
                        pageBorderRect.Bottom -= document.BottomMargin;

                        //content.SetColorStroke(BaseColor.BLACK);
                        content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
                        content.Stroke();
                        string Centercode = null;

                        Centercode = "1173" + lblStudentRollNo.Text;

                        ds = ProductController.GetICardImagePath(3, lblSBEntryCode.Text);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            float YPos1 = 0;
                            YPos1 = 720;
                            PdfContentByte cb1 = writer.DirectContent;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 500;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);


                            cb1.Stroke();



                            YPos1 = 790;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);
                            cb1.MoveTo(20, YPos1);

                            cb1.LineTo(20, YPos1 - 510);
                            cb1.MoveTo(580, YPos1);
                            cb1.LineTo(580, YPos1 - 510);
                            cb1.Stroke();
                            //  last line
                            YPos1 = 280;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);




                            //// row start from here---------------------------------------
                            YPos1 = 695;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(480, YPos1);

                            YPos1 = 670;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(480, YPos1);

                            YPos1 = 645;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(480, YPos1);

                            YPos1 = 620;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 595;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(480, YPos1);

                            YPos1 = 570;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(480, YPos1);

                            YPos1 = 545;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 520;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 500;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 480;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 460;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 440;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 420;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 400;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 380;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            YPos1 = 360;
                            cb1.MoveTo(20, YPos1);
                            cb1.LineTo(580, YPos1);

                            //YPos1 = 340;
                            //cb1.MoveTo(20, YPos1);
                            //cb1.LineTo(580, YPos1);
                            //-----------end here
                            /// page start fro here
                            float YPos = 0;
                            YPos = 700;



                            try
                            {
                                // jpg = iTextSharp.text.Image.GetInstance(Server.MapPath(ds.Tables[0].Rows[0]["ReceiptLogoImagePath"].ToString()));
                                dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(ds.Tables[0].Rows[0]["ReceiptLogoImagePath"].ToString()));
                                logo.SetAbsolutePosition(30, YPos);
                                logo.ScaleToFit(200, 95);
                                logo.ScaleAbsolute(80, 82);
                                //logo.ScalePercent(35);
                                document.Add(logo);
                            }
                            catch (Exception ex)
                            {
                            }

                            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                            float Col0Left = 30;
                            float Col1Left = 640;

                            PdfContentByte cb = writer.DirectContent;
                            //cb.SetColorFill(Color.GREEN);
                            cb.BeginText();

                            //PdfContentByte cb2 = writer.DirectContent;
                            //cb2.SetColorFill(Color.ORANGE);

                            //cb.SetFontAndSize(bf, 9);
                            //cb.SetTextMatrix(710, YPos + 65);
                            //cb.SetFontAndSize(bf, 9);
                            //cb.ShowText("Rule 55 Of CGST");
                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);








                            cb.SetFontAndSize(bf, 15);

                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head1"].ToString(), false)) / 2)), YPos + 60);
                            cb.SetFontAndSize(bf, 15);

                            cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head1"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 11);
                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head2"].ToString(), false)) / 2)), YPos + 45);
                            cb.SetFontAndSize(bf, 11);
                            cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head2"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head3"].ToString(), false)) / 2)), YPos + 30);
                            cb.SetFontAndSize(bf, 9);
                            cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head3"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            //cb.SetFontAndSize(bf, 12);
                            //cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth("DELIVERY CHALLAN ", false)) / 2)), YPos + 10);
                            //cb.SetFontAndSize(bf, 12);
                            //cb.ShowText(" DELIVERY CHALLAN ");
                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            //cb.SetFontAndSize(bf, 10);
                            //cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth("ORIGINAL For Consignee/ DUPLICATE For Transporter/ TRIPLICATE For Consignor", false)) / 2)), YPos - 8);
                            //cb.SetFontAndSize(bf, 10);
                            //cb.ShowText("ORIGINAL For Consignee/ DUPLICATE For Transporter/ TRIPLICATE For Consignor ");
                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                            cb.SetFontAndSize(bf, 10);
                            cb.SetTextMatrix(25, YPos + 5);
                            cb.ShowText("Candidate Name:");

                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 10);
                            cb.SetTextMatrix(120, YPos + 5);
                            cb.ShowText(lblStudentName.Text);
                            //cb.SetColorFill(Color.BLACK);
                            //cb.ShowText(ds.Tables[1].Rows[0]["DeliveryChalan"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 10);
                            cb.SetTextMatrix(25, YPos - 20);
                            cb.ShowText("DOB:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 10);
                            cb.SetTextMatrix(120, YPos - 20);
                            cb.ShowText(lblStudDOB.Text);
                            //cb.ShowText(ds.Tables[1].Rows[0]["ChallanDate"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 10);
                            cb.SetTextMatrix(25, YPos - 45);
                            cb.ShowText("Examination:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 10);
                            cb.SetTextMatrix(120, YPos - 45);
                            //cb.ShowText(lblStudname.Text);
                            //cb.ShowText("");
                            cb.ShowText(ds.Tables[1].Rows[0]["Examination"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                            cb.SetFontAndSize(bf, 10);
                            cb.SetTextMatrix(260, YPos - 20);
                            cb.ShowText("Unique ID:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 10);
                            cb.SetTextMatrix(330, YPos - 20);
                            //cb.ShowText("");
                            cb.ShowText(ds.Tables[1].Rows[0]["SPID"].ToString());

                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                            //========

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(25, YPos - 70);
                            cb.ShowText("Mother's Name:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(120, YPos - 70);
                            //cb.ShowText(ds.Tables[1].Rows[0]["From_Location"].ToString());
                            cb.ShowText(lblMotherName.Text);
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(25, YPos - 95);
                            cb.ShowText("Father's Name:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(120, YPos - 95);
                            cb.ShowText(ds.Tables[1].Rows[0]["FatherName"].ToString());
                            //cb.ShowText("");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(25, YPos - 120);
                            cb.ShowText("Guardian Name:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(120, YPos - 120);
                            cb.ShowText(ds.Tables[1].Rows[0]["Guardian"].ToString());
                            //cb.ShowText("");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(25, YPos - 145);
                            cb.ShowText("School Name:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(120, YPos - 145);
                            //cb.ShowText(ds.Tables[1].Rows[0]["From_Location"].ToString());
                            cb.ShowText(LblInstitutionDescription.Text);
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(250, YPos - 192);
                            cb.ShowText("SUBJECTS OFFERED");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(275, YPos - 215);
                            cb.ShowText("GROUP I");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(30, YPos - 233);
                            cb.ShowText(ds.Tables[2].Rows[0]["Group1Sub1"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(300, YPos - 233);
                            cb.ShowText(ds.Tables[2].Rows[0]["Group1Sub2"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(30, YPos - 253);
                            cb.ShowText(ds.Tables[2].Rows[0]["Group1Sub3"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(300, YPos - 253);
                            cb.ShowText("XXXXXXXXXX");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(275, YPos - 275);
                            cb.ShowText("GROUP II");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(30, YPos - 295);
                            cb.ShowText(ds.Tables[2].Rows[0]["Group2Sub1"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(170, YPos - 295);
                            cb.ShowText(ds.Tables[2].Rows[0]["Group2Sub2"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(300, YPos - 295);
                            cb.ShowText(ds.Tables[2].Rows[0]["Group2Sub3"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(450, YPos - 295);
                            cb.ShowText(ds.Tables[2].Rows[0]["Group2Sub4"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(275, YPos - 315);
                            cb.ShowText("GROUP III");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(30, YPos - 335);
                            cb.ShowText(ds.Tables[2].Rows[0]["Group3Sub1"].ToString());
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(232, YPos - 45);
                            cb.ShowText("Center No:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(275, YPos - 45);
                            //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                            cb.ShowText(Centercode);
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(342, YPos - 45);
                            cb.ShowText("Index No.:");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(385, YPos - 45);
                            //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                            cb.ShowText(lblStudentRollNo.Text);
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            ///=======================================================================
                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(30, YPos - 70);
                            cb.ShowText("");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(30, YPos - 410);
                            cb.ShowText("SIGNATURE OF THE CANDIDATE");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(230, YPos - 410);
                            cb.ShowText("SIGNATURE OF THE HEAD");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                            cb.SetFontAndSize(bf, 9);
                            cb.SetTextMatrix(430, YPos - 410);
                            cb.ShowText("CHIEF EXECUTIVE & SECRETARY");
                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                            cb.EndText();
                            float Yp2PDF = 0;



                            YPos = YPos + 100;
                            //============================================================================
                            //drow line towards down
                            cb.MoveTo(110, YPos - 254);
                            cb.LineTo(110, YPos - 80);
                            cb.Stroke();

                            cb.MoveTo(240, YPos - 130);
                            cb.LineTo(240, YPos - 105);
                            cb.Stroke();

                            cb.MoveTo(320, YPos - 130);
                            cb.LineTo(320, YPos - 105);
                            cb.Stroke();

                            cb.MoveTo(230, YPos - 155);
                            cb.LineTo(230, YPos - 130);
                            cb.Stroke();

                            cb.MoveTo(340, YPos - 155);
                            cb.LineTo(340, YPos - 130);
                            cb.Stroke();


                            cb.MoveTo(295, YPos - 320);
                            cb.LineTo(295, YPos - 360);
                            cb.Stroke();


                            cb.MoveTo(295, YPos - 380);
                            cb.LineTo(295, YPos - 400);
                            cb.Stroke();


                            cb.MoveTo(160, YPos - 380);
                            cb.LineTo(160, YPos - 400);
                            cb.Stroke();

                            cb.MoveTo(430, YPos - 380);
                            cb.LineTo(430, YPos - 400);
                            cb.Stroke();

                            cb.MoveTo(480, YPos - 254);
                            cb.LineTo(480, YPos - 80);
                            cb.Stroke();




                            cb.MoveTo(680, YPos);
                            cb.LineTo(680, YPos - 20);
                            cb.MoveTo(680, YPos);
                            cb.LineTo(680, YPos - 20);
                            //cb.MoveTo(690, YPos - 20);
                            cb.LineTo(680, YPos - 20);
                            cb.Stroke();


                            //=========================================================



                        }

                        document.NewPage();

                    }
                }
                document.Close();

                string CurTimeFrame = null;
                CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Hall Ticket_{0}.pdf", CurTimeFrame));
                Response.BinaryWrite(output.ToArray());

            }


            if (ddlDivision.SelectedValue != "D0")
            {


                if (ddlDivision.SelectedValue == "A0")
                {
                    //string DispatchCode = null, UserID=null;
                    //DispatchCode = Request.QueryString["DispatchCode"];
                    //UserID = Request.QueryString["UserID"];
                    DataSet ds = null;

                    dynamic document = new Document(PageSize.A4, 50, 50, 20, 20);



                    // Create a new PdfWriter object, specifying the output stream
                    dynamic output = new MemoryStream();
                    dynamic writer = PdfWriter.GetInstance(document, output);

                    dynamic TitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                    dynamic subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
                    dynamic boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                    dynamic endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                    dynamic bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
                    BaseFont font_bold = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);




                    // Open the Document for writing

                    document.Open();
                    foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
                    {
                        CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                        if (chkitemck.Checked == true)
                        {
                            var content = writer.DirectContent;
                            var pageBorderRect = new Rectangle(document.PageSize);
                            Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
                            Label lblStudDOB = (Label)dtlItem.FindControl("lblStudDOB");
                            Label lblGender = (Label)dtlItem.FindControl("lblGender");
                            Label lblStudentName = (Label)dtlItem.FindControl("lblStudentName");
                            Label lblMotherName = (Label)dtlItem.FindControl("lblMotherName");
                            Label LblInstitutionDescription = (Label)dtlItem.FindControl("LblInstitutionDescription");
                            Label lblStudentRollNo = (Label)dtlItem.FindControl("lblStudentRollNo");
                            Label lblSchoolId = (Label)dtlItem.FindControl("lblCenter");
                            Label lblRollNoInWords = (Label)dtlItem.FindControl("lblRollNoInWords");

                            pageBorderRect.Left -= document.LeftMargin;
                            pageBorderRect.Right += document.RightMargin;
                            pageBorderRect.Top += document.TopMargin;
                            pageBorderRect.Bottom -= document.BottomMargin;

                            //content.SetColorStroke(BaseColor.BLACK);
                            content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
                            content.Stroke();
                            string Centercode = null;

                            Centercode = "1173" + lblStudentRollNo.Text;

                            ds = ProductController.GetICardImagePath(4, lblSBEntryCode.Text);
                            if (ds.Tables[0].Rows.Count > 0)
                            {

                                float YPos1 = 0;
                                YPos1 = 720;
                                PdfContentByte cb1 = writer.DirectContent;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(580, YPos1);

                                //YPos1 = 500;  RIGHT LINE
                                //cb1.MoveTo(20, YPos1);
                                //cb1.LineTo(580, YPos1);


                                cb1.Stroke();



                                YPos1 = 790;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(580, YPos1);
                                cb1.MoveTo(20, YPos1);

                                cb1.LineTo(20, YPos1 - 710);//LEFT BORDER
                                cb1.MoveTo(580, YPos1);
                                cb1.LineTo(580, YPos1 - 710);//RIGHT BORDER
                                cb1.Stroke();



                                YPos1 = 80;  //  last line
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(580, YPos1);




                                //// row start from here---------------------------------------
                                YPos1 = 615;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(410, YPos1);

                                YPos1 = 590;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(410, YPos1);

                                YPos1 = 575;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(410, YPos1);

                                YPos1 = 560;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(410, YPos1);

                                YPos1 = 545;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(410, YPos1);

                                YPos1 = 530;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(410, YPos1);

                                YPos1 = 515;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(410, YPos1);

                                YPos1 = 500;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(410, YPos1);

                                YPos1 = 420;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(580, YPos1);

                                YPos1 = 400;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(580, YPos1);
                                // ROW ENDS HERE

                                //-----------end here
                                /// page start fro here
                                float YPos = 0;
                                YPos = 710;



                                try
                                {
                                    // jpg = iTextSharp.text.Image.GetInstance(Server.MapPath(ds.Tables[0].Rows[0]["ReceiptLogoImagePath"].ToString()));
                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(ds.Tables[0].Rows[0]["ReceiptLogoImagePath"].ToString()));
                                    logo.SetAbsolutePosition(30, YPos);
                                    logo.ScaleToFit(200, 95);
                                    logo.ScaleAbsolute(80, 82);
                                    //logo.ScalePercent(35);
                                    document.Add(logo);
                                }
                                catch (Exception ex)
                                {
                                }

                                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                                float Col0Left = 30;
                                float Col1Left = 640;

                                PdfContentByte cb = writer.DirectContent;
                                //cb.SetColorFill(Color.GREEN);
                                cb.BeginText();

                                cb.SetFontAndSize(bf, 15);

                                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head1"].ToString(), false)) / 2)), YPos + 60);
                                cb.SetFontAndSize(bf, 15);

                                cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head1"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 11);
                                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head2"].ToString(), false)) / 2)), YPos + 45);
                                cb.SetFontAndSize(bf, 11);
                                cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head2"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);



                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 5);
                                cb.ShowText("Divisional Board :");

                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(120, YPos - 5);
                                cb.ShowText("MUMBAI");
                                //cb.SetColorFill(Color.BLACK);
                                //cb.ShowText(ds.Tables[1].Rows[0]["DeliveryChalan"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 20);
                                cb.ShowText("Medium              :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(120, YPos - 20);
                                cb.ShowText("ENGLISH");
                                //cb.ShowText(ds.Tables[1].Rows[0]["ChallanDate"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 35);
                                cb.ShowText("Birth Date           :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(120, YPos - 35);
                                //cb.ShowText(lblStudname.Text);
                                cb.ShowText(lblStudDOB.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(232, YPos - 5);
                                cb.ShowText("School No.   :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 5);
                                //cb.ShowText("");
                                cb.ShowText(ddlCentre.SelectedValue);

                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                                //========

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(400, YPos - 5);
                                cb.ShowText("Seat No.:");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 15);
                                cb.SetTextMatrix(450, YPos - 5);
                                //cb.ShowText("");
                                cb.ShowText(lblStudentRollNo.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(232, YPos - 20);
                                cb.ShowText("Divyang Type  :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 20);
                                //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                                cb.ShowText("---");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(232, YPos - 35);
                                cb.ShowText("Birth Place   :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 35);
                                //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                                cb.ShowText("MAHARASHTRA");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 55);
                                cb.ShowText("Name                 :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 12);
                                cb.SetTextMatrix(120, YPos - 55);
                                //cb.ShowText(lblStudname.Text);
                                cb.ShowText(lblStudentName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 70);
                                cb.ShowText("Mother's Name     :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(120, YPos - 70);
                                cb.ShowText(ds.Tables[1].Rows[0]["Mother"].ToString());
                                //cb.ShowText(lblMotherName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(232, YPos - 70);
                                cb.ShowText("Gender   :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 70);
                                //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                                cb.ShowText(lblGender.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(400, YPos - 70);
                                cb.ShowText("Type Of Cand  :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(490, YPos - 70);
                                //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                                cb.ShowText("REGULAR");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 80);
                                cb.ShowText("Seat No(In Word)  :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(120, YPos - 80);
                                cb.ShowText(lblRollNoInWords.Text);
                                //cb.ShowText("");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 90);
                                cb.ShowText("Center Name        :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(120, YPos - 90);
                                cb.ShowText(txtCenterName.Text);
                                //cb.ShowText(ds.Tables[1].Rows[0]["From_Location"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 110);
                                cb.ShowText("Sub. Code");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(170, YPos - 110);
                                cb.ShowText("Subject Name");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 110);
                                cb.ShowText("Language Of");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 118);
                                cb.ShowText("Answer");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 133);
                                cb.ShowText("03");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 133);
                                cb.ShowText("ENGLISH");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 133);
                                cb.ShowText("ENGLISH");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 148);
                                cb.ShowText("27");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 148);
                                cb.ShowText(ds.Tables[2].Rows[0]["sgr_desc"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 148);
                                cb.ShowText("ENGLISH");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 163);
                                cb.ShowText("16");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 163);
                                cb.ShowText("MARATHI");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 163);
                                cb.ShowText("ENGLISH");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 178);
                                cb.ShowText("71");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 178);
                                cb.ShowText("MATHEMATICS");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 178);
                                cb.ShowText("ENGLISH");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 193);
                                cb.ShowText("72");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 193);
                                cb.ShowText("SCIENCE & TECHNOLOGY");
                                
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 193);
                                cb.ShowText("ENGLISH");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 208);
                                cb.ShowText("73");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 208);
                                cb.ShowText("SOCIAL SCIENCES");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 208);
                                cb.ShowText("ENGLISH");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 6);
                                cb.SetTextMatrix(450, YPos - 133);
                                cb.ShowText("Student Photo & Sign");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);



                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(20, YPos - 225);
                                cb.ShowText("   Note: Candidate must preserve and produce this card at each session of examination.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(20, YPos - 235);
                                cb.ShowText("   Without  which admission to the examination may be disallowed.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(170, YPos - 305);
                                cb.ShowText("  INSTRUCTIONS TO BE FOLLOWED FOR THE EXAMINATION");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 320);
                                cb.ShowText("1. Attendance of a candidates should be 75% or more of the working days of the school jr. college in each term, separately.if a candidate");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 330);
                                cb.ShowText("   fails to fulfill this condition his/her application form for the examination shall be treated us cancelled and he/she will not be allowed");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 340);
                                cb.ShowText("   to appear for the examination");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 355);
                                cb.ShowText("2. The candidates should visit and confirm, one day prior to the commencing of the examination, about the Examination Center, about the");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 365);
                                cb.ShowText("   about the Examination Center, and the sub-centre where his/her Seat no is alloted.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 380);
                                cb.ShowText("3. A Candidate must be present in the Examination Hall half an hour before the commencement of the actual Examination. For example,");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 390);
                                cb.ShowText("   for the morning session at 10.30 a.m. and for the afternoon session at 2.30 p.m.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 405);
                                cb.ShowText("4. There will be a warning bell 10 minutes before the commencement of the examination and 10 minutes before the end of each session.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 415);
                                cb.ShowText("   The candidate must stop writing after the final bell. The candidate must not leave his/her seat until all the Answer Books are");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 425);
                                cb.ShowText("   collected by the invigilator.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 440);
                                cb.ShowText("5. Candidates can be punished if (a) they bring any books, note books, a piece of paper with scribbling or a piece of paper for the purpose,");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 450);
                                cb.ShowText("   Mobile, Digital Watch,the purpose, Mobile, Digital Watch, Calculator or any other electronic device, etc. (b) they speak or communicate");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 460);
                                cb.ShowText("   with any other candidates during the period of the examination (c) they try to carry Answer Book or a Supplement along with them (d)");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 470);
                                cb.ShowText("   they disobey any instruction issued by the conductor/the invigilator.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 485);
                                cb.ShowText("6. Candidate will not be allowed to leave the examination hall during the examination. However, in exceptional cases if a candidate is");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 495);
                                cb.ShowText("   allowed to leave the examination hall he/she will have to submit the Answer Book & Question Paper to the invigilator.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 510);
                                cb.ShowText("7. Write your seat Number (In Figures and in Words) on every Answer Books/ Supplement issued to you and other details in the space");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 520);
                                cb.ShowText("   provided for the purpose.Candidates are forbidden to write their Seat Number either in figures or words his/her name or reveal");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 530);
                                cb.ShowText("   their identity in any other way on any other part of the Answer Book or Supplement. Otherwise the performance of the");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 540);
                                cb.ShowText("   candidate will be treated as cancelled.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 555);
                                cb.ShowText("8. The candidate must read the instructions given inside the Answer Book and follow them carefully.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                ///=======================================================================

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(450, YPos - 270);
                                cb.ShowText("Sign of head & Stamp");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                                cb.EndText();
                                float Yp2PDF = 0;



                                YPos = YPos + 100;
                                //============================================================================
                                //drow line towards down
                                cb.MoveTo(80, YPos - 311);
                                cb.LineTo(80, YPos - 195);
                                cb.Stroke();

                                cb.MoveTo(340, YPos - 311);
                                cb.LineTo(340, YPos - 195);
                                cb.Stroke();

                                cb.MoveTo(410, YPos - 311);
                                cb.LineTo(410, YPos - 195);
                                cb.Stroke();

                                cb.MoveTo(420, YPos - 311);
                                cb.LineTo(420, YPos - 195);
                                cb.Stroke();

                                cb.MoveTo(550, YPos - 311);
                                cb.LineTo(550, YPos - 195);
                                cb.Stroke();

                                YPos1 = 500;
                                cb1.MoveTo(420, YPos1);
                                cb1.LineTo(550, YPos1);

                                YPos1 = 615;
                                cb1.MoveTo(420, YPos1);
                                cb1.LineTo(550, YPos1);


                                //cb.MoveTo(680, YPos);
                                //cb.LineTo(680, YPos - 20);
                                cb.MoveTo(680, YPos);
                                cb.LineTo(680, YPos - 20);
                                //cb.MoveTo(690, YPos - 20);
                                cb.LineTo(680, YPos - 20);
                                cb.Stroke();


                                //=========================================================



                            }

                            document.NewPage();

                        }
                    }
                    document.Close();

                    string CurTimeFrame = null;
                    CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Hall Ticket_{0}.pdf", CurTimeFrame));
                    Response.BinaryWrite(output.ToArray());

                }
                if (ddlDivision.SelectedValue == "C0")
                {
                    //string DispatchCode = null, UserID=null;
                    //DispatchCode = Request.QueryString["DispatchCode"];
                    //UserID = Request.QueryString["UserID"];
                    DataSet ds = null;

                    dynamic document = new Document(PageSize.A4, 50, 50, 20, 20);



                    // Create a new PdfWriter object, specifying the output stream
                    dynamic output = new MemoryStream();
                    dynamic writer = PdfWriter.GetInstance(document, output);

                    dynamic TitleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                    dynamic subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
                    dynamic boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                    dynamic endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                    dynamic bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
                    BaseFont font_bold = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);




                    // Open the Document for writing

                    document.Open();
                    foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
                    {
                        CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                        if (chkitemck.Checked == true)
                        {
                            var content = writer.DirectContent;
                            var pageBorderRect = new Rectangle(document.PageSize);
                            Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
                            Label lblStudDOB = (Label)dtlItem.FindControl("lblStudDOB");
                            Label lblGender = (Label)dtlItem.FindControl("lblGender");
                            Label lblStudentName = (Label)dtlItem.FindControl("lblStudentName");
                            Label lblMotherName = (Label)dtlItem.FindControl("lblMotherName");
                            Label LblInstitutionDescription = (Label)dtlItem.FindControl("LblInstitutionDescription");
                            Label lblStudentRollNo = (Label)dtlItem.FindControl("lblStudentRollNo");
                            Label lblSchoolId = (Label)dtlItem.FindControl("lblCenter");
                            Label lblRollNoInWords = (Label)dtlItem.FindControl("lblRollNoInWords");

                            pageBorderRect.Left -= document.LeftMargin;
                            pageBorderRect.Right += document.RightMargin;
                            pageBorderRect.Top += document.TopMargin;
                            pageBorderRect.Bottom -= document.BottomMargin;

                            //content.SetColorStroke(BaseColor.BLACK);
                            content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
                            content.Stroke();
                            string Centercode = null;

                            Centercode = "1173" + lblStudentRollNo.Text;

                            ds = ProductController.GetICardImagePath(5, lblSBEntryCode.Text);
                            if (ds.Tables[0].Rows.Count > 0)
                            {

                                float YPos1 = 0;
                                YPos1 = 720;
                                PdfContentByte cb1 = writer.DirectContent;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(580, YPos1);

                                //YPos1 = 500;  RIGHT LINE
                                //cb1.MoveTo(20, YPos1);
                                //cb1.LineTo(580, YPos1);


                                cb1.Stroke();



                                YPos1 = 790;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(580, YPos1);
                                cb1.MoveTo(20, YPos1);

                                cb1.LineTo(20, YPos1 - 710);//LEFT BORDER
                                cb1.MoveTo(580, YPos1);
                                cb1.LineTo(580, YPos1 - 710);//RIGHT BORDER
                                cb1.Stroke();



                                YPos1 = 80;  //  last line
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(580, YPos1);




                                //// row start from here---------------------------------------
                                //YPos1 = 615;
                                //cb1.MoveTo(20, YPos1);
                                //cb1.LineTo(410, YPos1);

                                //YPos1 = 590;
                                //cb1.MoveTo(20, YPos1);
                                //cb1.LineTo(410, YPos1);

                                //YPos1 = 575;
                                //cb1.MoveTo(20, YPos1);
                                //cb1.LineTo(410, YPos1);

                                YPos1 = 582;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(500, YPos1);

                                YPos1 = 567;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(500, YPos1);

                                YPos1 = 552;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(500, YPos1);

                                YPos1 = 537;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(500, YPos1);

                                YPos1 = 522;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(500, YPos1);

                                YPos1 = 507;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(500, YPos1);

                                YPos1 = 492;
                                cb1.MoveTo(20, YPos1);
                                cb1.LineTo(500, YPos1);

                                //YPos1 = 477;
                                //cb1.MoveTo(20, YPos1);
                                //cb1.LineTo(500, YPos1);
                                // ROW ENDS HERE    

                                //-----------end here
                                /// page start fro here
                                float YPos = 0;
                                YPos = 710;



                                try
                                {
                                    // jpg = iTextSharp.text.Image.GetInstance(Server.MapPath(ds.Tables[0].Rows[0]["ReceiptLogoImagePath"].ToString()));
                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(ds.Tables[0].Rows[0]["ReceiptLogoImagePath"].ToString()));
                                    logo.SetAbsolutePosition(30, YPos);
                                    logo.ScaleToFit(200, 95);
                                    logo.ScaleAbsolute(80, 82);
                                    //logo.ScalePercent(35);
                                    document.Add(logo);
                                }
                                catch (Exception ex)
                                {
                                }

                                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                                float Col0Left = 30;
                                float Col1Left = 640;

                                PdfContentByte cb = writer.DirectContent;
                                //cb.SetColorFill(Color.GREEN);
                                cb.BeginText();

                                cb.SetFontAndSize(bf, 15);

                                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head1"].ToString(), false)) / 2)), YPos + 60);
                                cb.SetFontAndSize(bf, 15);

                                cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head1"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 11);
                                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head2"].ToString(), false)) / 2)), YPos + 45);
                                cb.SetFontAndSize(bf, 11);
                                cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head2"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["Receipt_head3"].ToString(), false)) / 2)), YPos + 30);
                                cb.SetFontAndSize(bf, 9);
                                cb.ShowText(ds.Tables[0].Rows[0]["Receipt_head3"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);



                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 5);
                                cb.ShowText("Roll No. :");

                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 11);
                                cb.SetTextMatrix(100, YPos - 5);
                                cb.ShowText(lblStudentRollNo.Text);
                                //cb.SetColorFill(Color.BLACK);
                                //cb.ShowText(ds.Tables[1].Rows[0]["DeliveryChalan"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(25, YPos - 20);
                                cb.ShowText("Roll No.(In Words) :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(120, YPos - 20);
                                cb.ShowText(lblRollNoInWords.Text);
                                //cb.ShowText(ds.Tables[1].Rows[0]["ChallanDate"].ToString());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(170, YPos - 5);
                                cb.ShowText("Date Of Birth:");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(240, YPos - 5);
                                //cb.ShowText("");
                                cb.ShowText(lblStudDOB.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                                //========

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(360, YPos - 5);
                                cb.ShowText("School No.:");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(420, YPos - 5);
                                //cb.ShowText("");
                                cb.ShowText("06841");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(480, YPos - 5);
                                cb.ShowText("Center No.:");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(540, YPos - 5);
                                //cb.ShowText("");
                                cb.ShowText(ddlCentre.SelectedValue);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(200, YPos - 35);
                                cb.ShowText("Candidate's Name :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 35);
                                //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                                cb.ShowText(lblStudentName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(200, YPos - 50);
                                cb.ShowText("Mother's Name :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 50);
                                cb.ShowText(ds.Tables[1].Rows[0]["Mother"].ToString());
                                cb.ShowText(lblMotherName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(200, YPos - 65);
                                cb.ShowText("Father's Name :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 65);
                                cb.ShowText(ds.Tables[1].Rows[0]["FatherName"].ToString());
                                //cb.ShowText(lblMotherName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(200, YPos - 80);
                                cb.ShowText("Of :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 80);
                                cb.ShowText(LblInstitutionDescription.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(200, YPos - 95);
                                cb.ShowText("Center :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 95);
                                //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                                cb.ShowText(txtCenterName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(200, YPos - 110);
                                cb.ShowText("Category of PwD :");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(295, YPos - 110);
                                //cb.ShowText(ds.Tables[1].Rows[0]["Tolocation"].ToString());
                                cb.ShowText("-");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(200, YPos - 125);
                                cb.ShowText("is permitted to appear in the subjects given below");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 138);
                                cb.ShowText("Sub. Code");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(130, YPos - 138);
                                cb.ShowText("Subject Description");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(300, YPos - 138);
                                cb.ShowText("Medium");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 138);
                                cb.ShowText("Paper");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(450, YPos - 138);
                                cb.ShowText("Date");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 155);
                                cb.ShowText("101");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 155);
                                cb.ShowText("ENGLISH COMM.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 155);
                                cb.ShowText("1");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 170);
                                cb.ShowText("086");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 170);
                                cb.ShowText("SCIENCE");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 170);
                                cb.ShowText("1");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 185);
                                cb.ShowText("087");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 185);
                                cb.ShowText("SOCIAL SCIENCE");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 185);
                                cb.ShowText("1");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 200);
                                cb.ShowText("041");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 200);
                                cb.ShowText("MATHEMATICS");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 200);
                                cb.ShowText("1");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 215);
                                cb.ShowText("018");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(85, YPos - 215);
                                cb.ShowText("2ND LANGUAGE");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(350, YPos - 215);
                                cb.ShowText("1");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 6);
                                cb.SetTextMatrix(70, YPos - 65);
                                cb.ShowText("Student Photo");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);



                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(20, YPos - 235);
                                cb.ShowText(" Important Note:");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(30, YPos - 245);
                                cb.ShowText("1. Candidate must check all particulars carefully and corrections,if any, be brought to the notice of the School immediately. Under no");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(30, YPos - 255);
                                cb.ShowText("   circumstances corrections in particulars will be centertained beyond one year of issue of pass certificate.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(30, YPos - 275);
                                cb.ShowText("2. This card may be issued to the candidate after the attestation of photo and signature of the candidate  by the principal");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(30, YPos - 295);
                                cb.ShowText("3. Visually impaired/Dyslexic/Hearing Impaired/Spastic/Locomotor Impaired candidate are requested to bring the  medical");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(30, YPos - 305);
                                cb.ShowText("   Certificate/document supporting their disability/disorder and its extent.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 325);
                                cb.ShowText("This is a provisional admit card. The principal and candidate should sing at the appropriate Place.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 470);
                                cb.ShowText("Note :1.    For dates and time of examination, please See DATE SHEET also.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 485);
                                cb.ShowText("         2.    The candidate must keep this admission card  at the time of Examination and present on demand to the Superintendent");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 495);
                                cb.ShowText("                of Examination Centre or any other person authorised on this behalf.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 510);
                                cb.ShowText("         3.    Candidate will be allowed to appear in the subject/course filled in by them in  their application forms and given");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 520);
                                cb.ShowText("                 against each name in the list of candidates supplied  to the centre. A Candidate shall not be ordinarily allowed");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 530);
                                cb.ShowText("                 to appear in subject/courses other than those given in the list.");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);



                                ///=======================================================================

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 430);
                                cb.ShowText("Full Signature of the Candidate");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(25, YPos - 440);
                                cb.ShowText("(Not in BLOCK LETTERS)");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(300, YPos - 430);
                                cb.ShowText(" Principal");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 9);
                                cb.SetTextMatrix(255, YPos - 440);
                                cb.ShowText("(Signature & Stamp of the Principal)");
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.EndText();
                                float Yp2PDF = 0;



                                YPos = YPos + 100;
                                //============================================================================
                                //drow line towards down
                                cb.MoveTo(80, YPos - 316);
                                cb.LineTo(80, YPos - 228);
                                cb.Stroke();

                                cb.MoveTo(280, YPos - 316);
                                cb.LineTo(280, YPos - 228);
                                cb.Stroke();

                                cb.MoveTo(340, YPos - 316);
                                cb.LineTo(340, YPos - 228);
                                cb.Stroke();

                                cb.MoveTo(410, YPos - 316);
                                cb.LineTo(410, YPos - 228);
                                cb.Stroke();

                                cb.MoveTo(500, YPos - 316);
                                cb.LineTo(500, YPos - 228);
                                cb.Stroke();

                                                               
                                //photo box
                                cb.MoveTo(25, YPos - 125);
                                cb.LineTo(25, YPos - 220);
                                cb.Stroke();

                                cb.MoveTo(150, YPos - 125);
                                cb.LineTo(150, YPos - 220);
                                cb.Stroke();

                                YPos1 = 685;
                                cb1.MoveTo(150, YPos1);
                                cb1.LineTo(25, YPos1);

                                YPos1 = 590;
                                cb1.MoveTo(150, YPos1);
                                cb1.LineTo(25, YPos1);
                                // end

                                //cb.MoveTo(430, YPos - 380);
                                //cb.LineTo(430, YPos - 400);
                                //cb.Stroke();

                                //cb.MoveTo(480, YPos - 254);
                                //cb.LineTo(480, YPos - 80);
                                //cb.Stroke();

                                //cb.MoveTo(680, YPos);
                                //cb.LineTo(680, YPos - 20);
                                cb.MoveTo(680, YPos);
                                cb.LineTo(680, YPos - 20);
                                //cb.MoveTo(690, YPos - 20);
                                cb.LineTo(680, YPos - 20);
                                cb.Stroke();


                            }

                            document.NewPage();

                        }
                    }
                    document.Close();

                    string CurTimeFrame = null;
                    CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Hall Ticket_{0}.pdf", CurTimeFrame));
                    Response.BinaryWrite(output.ToArray());

                }


                else if (ddlDivision.SelectedValue!="A0" && ddlDivision.SelectedValue!="D0" && ddlDivision.SelectedValue!="C0")
                {

                    //Print PDF Code
                    iTextSharp.text.Image jpg;

                    string ImagePath = "";
                    string PrintImageonHallticket = "";
                    DataSet dsImagePath = ProductController.GetICardImagePath(2, ddlDivision.SelectedValue);
                    if (dsImagePath.Tables[0].Rows.Count > 0)
                    {
                        ImagePath = dsImagePath.Tables[0].Rows[0]["HallTicketImagePath"].ToString();
                        PrintImageonHallticket = dsImagePath.Tables[0].Rows[0]["Print_Image_Hallticket"].ToString(); ;
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Hall Ticket Configration not maintained. Kindly Contact Administrator.");
                        return;
                    }

                    try //First Check the Background image path is available or not
                    {
                        jpg = iTextSharp.text.Image.GetInstance(Server.MapPath(ImagePath));
                    }
                    catch (Exception ex)
                    {
                        Show_Error_Success_Box("E", "Hall Ticket Configration not maintained. Kindly Contact Administrator.");
                        return;
                    }

                    if (PrintImageonHallticket == "1")
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


                        //Loop Start
                        foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
                        {


                            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                            if (chkitemck.Checked == true)
                            {


                                float YPos = 0;
                                YPos = 400;


                                jpg.ScaleToFit(700, 500);
                                jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
                                jpg.SetAbsolutePosition(15, YPos - 200);
                                document.Add(jpg);


                                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                                PdfContentByte cb = writer.DirectContent;

                                Label lblCenter = (Label)dtlItem.FindControl("lblCenter");
                                Label lblStudDOB = (Label)dtlItem.FindControl("lblStudDOB");
                                Label lblGender = (Label)dtlItem.FindControl("lblGender");
                                Label lblStudentName = (Label)dtlItem.FindControl("lblStudentName");
                                Label lblMotherName = (Label)dtlItem.FindControl("lblMotherName");
                                Label lblRollNoInWords = (Label)dtlItem.FindControl("lblRollNoInWords");
                                Label lblStudentRollNo = (Label)dtlItem.FindControl("lblStudentRollNo");
                                Label lblimagepath = (Label)dtlItem.FindControl("lblimagepath");
                                string AcadYear = ddlAcadYear.SelectedItem.ToString();

                                cb.BeginText();

                                cb.SetFontAndSize(bf, 13);
                                cb.SetTextMatrix(480, YPos + 95);//
                                cb.SetFontAndSize(bf, 13);
                                cb.ShowText(AcadYear);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 13);
                                cb.SetTextMatrix(600, YPos + 73);//
                                cb.SetFontAndSize(bf, 13);
                                cb.ShowText(lblStudentRollNo.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(((60) + ((150 - (60)) / 2) - ((cb.GetEffectiveStringWidth(lblCenter.Text, false)) / 2)), YPos + 35);//start 60 End 150
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblCenter.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(((160) + ((255 - (200)) / 2) - ((cb.GetEffectiveStringWidth(lblCenter.Text, false)) / 2)), YPos + 35);//start 160 End 230
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblStudDOB.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(425, YPos + 35);//start 425 
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblGender.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(100, YPos + 8);//start 100
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblStudentName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(165, YPos - 8);//start 100
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblMotherName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(180, YPos - 25);//start 100
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblRollNoInWords.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(150, YPos - 41);//start 100
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(txtCenterName.Text.ToUpper());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.EndText();
                                if ((lblimagepath.Text != ""))
                                {
                                    try
                                    {
                                        dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(lblimagepath.Text));
                                        logo.SetAbsolutePosition(560, YPos - 55);
                                        logo.ScaleToFit(200, 95);
                                        logo.ScaleAbsolute(110, 100);
                                        //logo.ScalePercent(35);
                                        document.Add(logo);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                document.NewPage();
                            }
                        }

                        document.Close();


                        string CurTimeFrame = null;
                        CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=HallTicket_{0}.pdf", CurTimeFrame));
                        Response.BinaryWrite(output.ToArray());
                    }
                    else
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


                        //Loop Start
                        foreach (DataListItem dtlItem in dlGridDisplay_Selected.Items)
                        {


                            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                            if (chkitemck.Checked == true)
                            {


                                float YPos = 0;
                                YPos = 400;


                                jpg.ScaleToFit(700, 500);
                                jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
                                jpg.SetAbsolutePosition(15, YPos - 200);
                                document.Add(jpg);


                                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                                PdfContentByte cb = writer.DirectContent;

                                Label lblCenter = (Label)dtlItem.FindControl("lblCenter");
                                Label lblStudDOB = (Label)dtlItem.FindControl("lblStudDOB");
                                Label lblGender = (Label)dtlItem.FindControl("lblGender");
                                Label lblStudentName = (Label)dtlItem.FindControl("lblStudentName");
                                Label lblMotherName = (Label)dtlItem.FindControl("lblMotherName");
                                Label lblRollNoInWords = (Label)dtlItem.FindControl("lblRollNoInWords");
                                Label lblStudentRollNo = (Label)dtlItem.FindControl("lblStudentRollNo");
                                string AcadYear = ddlAcadYear.SelectedItem.ToString();

                                cb.BeginText();

                                cb.SetFontAndSize(bf, 13);
                                cb.SetTextMatrix(480, YPos + 95);//
                                cb.SetFontAndSize(bf, 13);
                                cb.ShowText(AcadYear);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 13);
                                cb.SetTextMatrix(600, YPos + 73);//
                                cb.SetFontAndSize(bf, 13);
                                cb.ShowText(lblStudentRollNo.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(((60) + ((150 - (60)) / 2) - ((cb.GetEffectiveStringWidth(lblCenter.Text, false)) / 2)), YPos + 35);//start 60 End 150
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblCenter.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(((160) + ((255 - (175)) / 2) - ((cb.GetEffectiveStringWidth(lblCenter.Text, false)) / 2)), YPos + 35);//start 160 End 230
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblStudDOB.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(425, YPos + 35);//start 425 
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblGender.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(100, YPos + 8);//start 100
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblStudentName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(165, YPos - 8);//start 100
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblMotherName.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(180, YPos - 25);//start 100
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(lblRollNoInWords.Text);
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                cb.SetFontAndSize(bf, 10);
                                cb.SetTextMatrix(150, YPos - 41);//start 100
                                cb.SetFontAndSize(bf, 10);
                                cb.ShowText(txtCenterName.Text.ToUpper());
                                cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                cb.EndText();

                                document.NewPage();
                            }
                        }

                        document.Close();


                        string CurTimeFrame = null;
                        CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=HallTicket_{0}.pdf", CurTimeFrame));
                        Response.BinaryWrite(output.ToArray());
                    }




                }
            }
        }


        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
            return;
        }

    }
    protected void btn_CloseCent_Click(object sender, EventArgs e)
    {

    }
    protected void HLExport_Click(object sender, EventArgs e)
    {

    }

}