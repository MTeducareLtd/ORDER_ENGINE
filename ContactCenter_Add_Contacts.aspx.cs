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
using System.Threading;
using System.Text;
//using Exportxls.BL;


public partial class ContactCenter_Add_Contacts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           
            lblpagetitle1.Text = "Add Contact";
            lblpagetitle2.Text = "";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Contact";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = " Add Secondary Contact";
            divErrormessage.Visible = false;
            lblsuccessMessage.Visible = false;
            divSuccessmessage.Visible = false;
            //string Menuid = "102";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            StudentType();
            ContactType();
            ContactSource();
            ddlContactType.SelectedValue= "01";//01 is a student
            Country();
            ddlCountry.SelectedValue = "IN";//Default India
            BindState();
            Institutetype();
            Board();
            DivisionSession();
            Yearofpassing();
            Fill_Grid_AcadInfo();
            ddlFatherGender.SelectedValue = "1";
            ddlMotherGender.SelectedValue = "2";

        }

    }


    private void ContactSource()
    {
        DataSet ds = ProductController.GetallactiveleadSource();
        BindDDL(ddlContactsourceadd, ds, "Description", "ID");
        ddlContactsourceadd.Items.Insert(0, "Select");
        ddlContactsourceadd.SelectedIndex = 0;

    }

    private void Fill_Grid_AcadInfo()
    {
        DataTable dtCorrectEntry = new DataTable();
        //DataRow NewRow = null;
        var _with1 = dtCorrectEntry;
        _with1.Columns.Add("InstitutionTypeCode");
        _with1.Columns.Add("InstitutionType");
        _with1.Columns.Add("InstitutionName");
        _with1.Columns.Add("BoardId");
        _with1.Columns.Add("BoardName");
        _with1.Columns.Add("standrdCode");
        _with1.Columns.Add("standardName");
        _with1.Columns.Add("DivisionCode");
        _with1.Columns.Add("DivisionName");
        _with1.Columns.Add("PassingYearCode");
        _with1.Columns.Add("PassingYearName");
        _with1.Columns.Add("AditionalDesc");
        _with1.Columns.Add("ExamName");
        _with1.Columns.Add("FinalMarkObtain");
        _with1.Columns.Add("FinalMarkTotal");
        _with1.Columns.Add("Grade");
        _with1.Columns.Add("Percentage");
        _with1.Columns.Add("RowNumber");

        dlAcadInfo.DataSource = dtCorrectEntry;
        dlAcadInfo.DataBind();
    }

    private void Country()
    {
        DataSet ds = ProductController.GetallCountry();
        BindDDL(ddlCountry, ds, "Country_Name", "Country_Code");
        ddlCountry.Items.Insert(0, "Select");
        ddlCountry.SelectedIndex = 0;
        ddlstate.Items.Insert(0, "Select");
        ddlstate.SelectedIndex = 0;
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
        ddllocation.Items.Clear();
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }

    private void Board()
    {
        DataSet ds = ProductController.GetallBoard();
        BindDDL(ddlboard, ds, "Short_Description", "ID");
        ddlboard.Items.Insert(0, "Select");
        ddlboard.SelectedIndex = 0;
    }



    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindState();
    }
    private void BindState()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlCountry.SelectedValue);
        BindDDL(ddlstate, ds, "State_Name", "State_Code");
        ddlstate.Items.Insert(0, "Select");
        ddlstate.SelectedIndex = 0;
        ddlcity.Items.Clear();
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
        ddllocation.Items.Clear();
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }

    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactTypeinrelation();
        BindDDL(ddlContactType, ds, "Description", "ID");
    }

    private void BindCity()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlstate.SelectedValue);
        BindDDL(ddlcity, ds, "City_Name", "City_Code");
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
        ddllocation.Items.Clear();
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }

    private void Institutetype()
    {
        DataSet ds = ProductController.GetallInstituteType();
        BindDDL(ddlinstitutiontype, ds, "Description", "ID");
        ddlinstitutiontype.Items.Insert(0, "Select");
        ddlinstitutiontype.SelectedIndex = 0;
        ddlcurrentstudying.Items.Insert(0, "Select");
        ddlcurrentstudying.SelectedIndex = 0;
    }

    private void DivisionSession()
    {
        DataSet ds = ProductController.GetAllDivisionSection();
        BindDDL(ddlsection, ds, "Description", "ID");
        ddlsection.Items.Insert(0, "Select");
        ddlsection.SelectedIndex = 0;
    }

    private void Yearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlyearofpassing, ds, "Description", "ID");
        ddlyearofpassing.Items.Insert(0, "Select");
        ddlyearofpassing.SelectedIndex = 0;
    }

    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCity();
    }


    protected void btnAddAcadInfo_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        tblAddAcadinfo.Visible = true;
        Clear_AddAcadInfo();
        btnSubmitcon.Visible = false;
        btnclearcon.Visible = false;
        btnAddAcadInfo.Visible = true;
        btnUpdateAcadInfo.Visible = false;
    }

    protected void btnCloseAcadInfo_ServerClick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        tblAddAcadinfo.Visible = false;
        btnSubmitcon.Visible = true;
       // btnclearcon.Visible = true;
    }

    protected void btnSaveAcadInfo_ServerClick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        DataTable dtCorrectEntry = new DataTable();
        DataRow NewRow = null;
        var _with1 = dtCorrectEntry;
        _with1.Columns.Add("InstitutionTypeCode");
        _with1.Columns.Add("InstitutionType");
        _with1.Columns.Add("InstitutionName");
        _with1.Columns.Add("BoardId");
        _with1.Columns.Add("BoardName");
        _with1.Columns.Add("standrdCode");
        _with1.Columns.Add("standardName");
        _with1.Columns.Add("DivisionCode");
        _with1.Columns.Add("DivisionName");
        _with1.Columns.Add("PassingYearCode");
        _with1.Columns.Add("PassingYearName");
        _with1.Columns.Add("AditionalDesc");
        _with1.Columns.Add("ExamName");
        _with1.Columns.Add("FinalMarkObtain");
        _with1.Columns.Add("FinalMarkTotal");
        _with1.Columns.Add("Grade");
        _with1.Columns.Add("Percentage");
        _with1.Columns.Add("RowNumber");

        int i = 1;

        foreach (DataListItem item in dlAcadInfo.Items)
        {
            NewRow = dtCorrectEntry.NewRow();

            Label lblInstitutionTypeCode = (Label)item.FindControl("lblInstitutionTypeCode");
            Label lblInstitutionType = (Label)item.FindControl("lblInstitutionType");
            Label lblInstitutionName = (Label)item.FindControl("lblInstitutionName");
            Label lblBoardId = (Label)item.FindControl("lblBoardId");
            Label lblBoardName = (Label)item.FindControl("lblBoardName");
            Label lblStandardCode = (Label)item.FindControl("lblStandardCode");
            Label lblStandardName = (Label)item.FindControl("lblStandardName");
            Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
            Label lblDivisionName = (Label)item.FindControl("lblDivisionName");
            Label lblPassingYearCode = (Label)item.FindControl("lblPassingYearCode");
            Label lblPassingYearName = (Label)item.FindControl("lblPassingYearName");
            Label lblAditionalDesc = (Label)item.FindControl("lblAditionalDesc");
            Label lblExamName = (Label)item.FindControl("lblExamName");
            Label lblFinalMarkObt = (Label)item.FindControl("lblFinalMarkObt");
            Label lblFinalMarkTotal = (Label)item.FindControl("lblFinalMarkTotal");
            Label lblGrade = (Label)item.FindControl("lblGrade");
            Label lblPercentage = (Label)item.FindControl("lblPercentage");

            NewRow = dtCorrectEntry.NewRow();

            NewRow["InstitutionTypeCode"] = lblInstitutionTypeCode.Text;
            NewRow["InstitutionType"] = lblInstitutionType.Text;
            NewRow["InstitutionName"] = lblInstitutionName.Text;
            NewRow["BoardId"] = lblBoardId.Text;
            NewRow["BoardName"] = lblBoardName.Text;
            NewRow["standrdCode"] = lblStandardCode.Text;
            NewRow["standardName"] = lblStandardName.Text;
            NewRow["DivisionCode"] = lblDivisionCode.Text;
            NewRow["DivisionName"] = lblDivisionName.Text;
            NewRow["PassingYearCode"] = lblPassingYearCode.Text;
            NewRow["PassingYearName"] = lblPassingYearName.Text;
            NewRow["AditionalDesc"] = lblAditionalDesc.Text;
            NewRow["ExamName"] = lblExamName.Text;
            NewRow["FinalMarkObtain"] = lblFinalMarkObt.Text;
            NewRow["FinalMarkTotal"] = lblFinalMarkTotal.Text;
            NewRow["Grade"] = lblGrade.Text;
            NewRow["Percentage"] = lblPercentage.Text;
            NewRow["RowNumber"] = i.ToString();

            dtCorrectEntry.Rows.Add(NewRow);
            i++;
        }

        NewRow = dtCorrectEntry.NewRow();

        NewRow["InstitutionTypeCode"] = ddlinstitutiontype.SelectedValue;
        NewRow["InstitutionType"] = ddlinstitutiontype.SelectedItem.ToString();
        NewRow["InstitutionName"] = txtnameofinstitution.Text.Trim();
        NewRow["BoardId"] = ddlboard.SelectedValue;
        NewRow["BoardName"] = ddlboard.SelectedItem.ToString();
        NewRow["standrdCode"] = ddlcurrentstudying.SelectedValue;
        NewRow["standardName"] = ddlcurrentstudying.SelectedItem.ToString();
        NewRow["DivisionCode"] = ddlsection.SelectedValue;
        NewRow["DivisionName"] = ddlsection.SelectedItem.ToString();
        NewRow["PassingYearCode"] = ddlyearofpassing.SelectedValue;
        NewRow["PassingYearName"] = ddlyearofpassing.SelectedItem.ToString();
        NewRow["AditionalDesc"] = txtadditiondesc.Text.Trim();
        NewRow["ExamName"] = txtExamName.Text.Trim();
        NewRow["FinalMarkObtain"] = txtFinalMarksObtained.Text.Trim();
        NewRow["FinalMarkTotal"] = txtFinalMarksTotal.Text.Trim();
        NewRow["Grade"] = txtGrade.Text.Trim();
        NewRow["Percentage"] = txtPercentage.Text.Trim();
        NewRow["RowNumber"] = i.ToString();

        dtCorrectEntry.Rows.Add(NewRow);


        dlAcadInfo.DataSource = dtCorrectEntry;
        dlAcadInfo.DataBind();

        tblAddAcadinfo.Visible = false;
        btnSubmitcon.Visible = true;
       // btnclearcon.Visible = true;


    }

    protected void btnUpdateAcadInfo_ServerClick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        DataTable dtCorrectEntry = new DataTable();
        DataRow NewRow = null;
        var _with1 = dtCorrectEntry;
        _with1.Columns.Add("InstitutionTypeCode");
        _with1.Columns.Add("InstitutionType");
        _with1.Columns.Add("InstitutionName");
        _with1.Columns.Add("BoardId");
        _with1.Columns.Add("BoardName");
        _with1.Columns.Add("standrdCode");
        _with1.Columns.Add("standardName");
        _with1.Columns.Add("DivisionCode");
        _with1.Columns.Add("DivisionName");
        _with1.Columns.Add("PassingYearCode");
        _with1.Columns.Add("PassingYearName");
        _with1.Columns.Add("AditionalDesc");
        _with1.Columns.Add("ExamName");
        _with1.Columns.Add("FinalMarkObtain");
        _with1.Columns.Add("FinalMarkTotal");
        _with1.Columns.Add("Grade");
        _with1.Columns.Add("Percentage");
        _with1.Columns.Add("RowNumber");

        int i = 1;
        foreach (DataListItem item in dlAcadInfo.Items)
        {
            NewRow = dtCorrectEntry.NewRow();

            Label lblInstitutionTypeCode = (Label)item.FindControl("lblInstitutionTypeCode");
            Label lblInstitutionType = (Label)item.FindControl("lblInstitutionType");
            Label lblInstitutionName = (Label)item.FindControl("lblInstitutionName");
            Label lblBoardId = (Label)item.FindControl("lblBoardId");
            Label lblBoardName = (Label)item.FindControl("lblBoardName");
            Label lblStandardCode = (Label)item.FindControl("lblStandardCode");
            Label lblStandardName = (Label)item.FindControl("lblStandardName");
            Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
            Label lblDivisionName = (Label)item.FindControl("lblDivisionName");
            Label lblPassingYearCode = (Label)item.FindControl("lblPassingYearCode");
            Label lblPassingYearName = (Label)item.FindControl("lblPassingYearName");
            Label lblAditionalDesc = (Label)item.FindControl("lblAditionalDesc");
            Label lblExamName = (Label)item.FindControl("lblExamName");
            Label lblFinalMarkObt = (Label)item.FindControl("lblFinalMarkObt");
            Label lblFinalMarkTotal = (Label)item.FindControl("lblFinalMarkTotal");
            Label lblGrade = (Label)item.FindControl("lblGrade");
            Label lblPercentage = (Label)item.FindControl("lblPercentage");
            Label lblRowNumber = (Label)item.FindControl("lblRowNumber");

            NewRow = dtCorrectEntry.NewRow();
            if (lblPKeyRowNumber.Text == lblRowNumber.Text)
            {
                NewRow["InstitutionTypeCode"] = ddlinstitutiontype.SelectedValue;
                NewRow["InstitutionType"] = ddlinstitutiontype.SelectedItem.ToString();
                NewRow["InstitutionName"] = txtnameofinstitution.Text;
                NewRow["BoardId"] = ddlboard.SelectedValue;
                NewRow["BoardName"] = ddlboard.SelectedItem.ToString();
                NewRow["standrdCode"] = ddlcurrentstudying.SelectedValue;
                NewRow["standardName"] = ddlcurrentstudying.SelectedItem.ToString();
                NewRow["DivisionCode"] = ddlsection.SelectedValue;
                NewRow["DivisionName"] = ddlsection.SelectedItem.ToString();
                NewRow["PassingYearCode"] = ddlyearofpassing.SelectedValue;
                NewRow["PassingYearName"] = ddlyearofpassing.SelectedItem.ToString();
                NewRow["AditionalDesc"] = txtadditiondesc.Text;
                NewRow["ExamName"] = txtExamName.Text;
                NewRow["FinalMarkObtain"] = txtFinalMarksObtained.Text;
                NewRow["FinalMarkTotal"] = txtFinalMarksTotal.Text;
                NewRow["Grade"] = txtGrade.Text;
                NewRow["Percentage"] = txtPercentage.Text;
                NewRow["RowNumber"] = i.ToString();
            }
            else
            {
                NewRow["InstitutionTypeCode"] = lblInstitutionTypeCode.Text;
                NewRow["InstitutionType"] = lblInstitutionType.Text;
                NewRow["InstitutionName"] = lblInstitutionName.Text;
                NewRow["BoardId"] = lblBoardId.Text;
                NewRow["BoardName"] = lblBoardName.Text;
                NewRow["standrdCode"] = lblStandardCode.Text;
                NewRow["standardName"] = lblStandardName.Text;
                NewRow["DivisionCode"] = lblDivisionCode.Text;
                NewRow["DivisionName"] = lblDivisionName.Text;
                NewRow["PassingYearCode"] = lblPassingYearCode.Text;
                NewRow["PassingYearName"] = lblPassingYearName.Text;
                NewRow["AditionalDesc"] = lblAditionalDesc.Text;
                NewRow["ExamName"] = lblExamName.Text;
                NewRow["FinalMarkObtain"] = lblFinalMarkObt.Text;
                NewRow["FinalMarkTotal"] = lblFinalMarkTotal.Text;
                NewRow["Grade"] = lblGrade.Text;
                NewRow["Percentage"] = lblPercentage.Text;
                NewRow["RowNumber"] = i.ToString();
            }
            dtCorrectEntry.Rows.Add(NewRow);
            i++;
        }

        dlAcadInfo.DataSource = dtCorrectEntry;
        dlAcadInfo.DataBind();
        tblAddAcadinfo.Visible = false;
        btnSubmitcon.Visible = true;
       // btnclearcon.Visible = true;
    }

    protected void ddlcity_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindLocation();
    }
    private void BindLocation()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
        BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }

    private void Clear_AddAcadInfo()
    {
        Clear_Error_Success_Box();
        ddlinstitutiontype.SelectedIndex = 0;
        txtnameofinstitution.Text = "";
        ddlboard.SelectedIndex = 0;
        ddlcurrentstudying.Items.Clear();
        ddlcurrentstudying.Items.Insert(0, "Select");
        ddlcurrentstudying.SelectedIndex = 0;
        ddlsection.SelectedIndex = 0;
        ddlyearofpassing.SelectedIndex = 0;
        txtadditiondesc.Text = "";
        txtExamName.Text = "";
        txtFinalMarksObtained.Text = "";
        txtFinalMarksTotal.Text = "";
        txtGrade.Text = "";
        txtPercentage.Text = "";
    }


    protected void dlAcadInfo_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        DataTable dtCorrectEntry = new DataTable();
        int i = 0;
        if (e.CommandName == "Remove")
        {
            DataRow NewRow = null;
            var _with1 = dtCorrectEntry;
            _with1.Columns.Add("InstitutionTypeCode");
            _with1.Columns.Add("InstitutionType");
            _with1.Columns.Add("InstitutionName");
            _with1.Columns.Add("BoardId");
            _with1.Columns.Add("BoardName");
            _with1.Columns.Add("standrdCode");
            _with1.Columns.Add("standardName");
            _with1.Columns.Add("DivisionCode");
            _with1.Columns.Add("DivisionName");
            _with1.Columns.Add("PassingYearCode");
            _with1.Columns.Add("PassingYearName");
            _with1.Columns.Add("AditionalDesc");
            _with1.Columns.Add("ExamName");
            _with1.Columns.Add("FinalMarkObtain");
            _with1.Columns.Add("FinalMarkTotal");
            _with1.Columns.Add("Grade");
            _with1.Columns.Add("Percentage");
            _with1.Columns.Add("RowNumber");

            i = 1;

            foreach (DataListItem item in dlAcadInfo.Items)
            {
                NewRow = dtCorrectEntry.NewRow();

                Label lblInstitutionTypeCode = (Label)item.FindControl("lblInstitutionTypeCode");
                Label lblInstitutionType = (Label)item.FindControl("lblInstitutionType");
                Label lblInstitutionName = (Label)item.FindControl("lblInstitutionName");
                Label lblBoardId = (Label)item.FindControl("lblBoardId");
                Label lblBoardName = (Label)item.FindControl("lblBoardName");
                Label lblStandardCode = (Label)item.FindControl("lblStandardCode");
                Label lblStandardName = (Label)item.FindControl("lblStandardName");
                Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                Label lblDivisionName = (Label)item.FindControl("lblDivisionName");
                Label lblPassingYearCode = (Label)item.FindControl("lblPassingYearCode");
                Label lblPassingYearName = (Label)item.FindControl("lblPassingYearName");
                Label lblAditionalDesc = (Label)item.FindControl("lblAditionalDesc");
                Label lblExamName = (Label)item.FindControl("lblExamName");
                Label lblFinalMarkObt = (Label)item.FindControl("lblFinalMarkObt");
                Label lblFinalMarkTotal = (Label)item.FindControl("lblFinalMarkTotal");
                Label lblGrade = (Label)item.FindControl("lblGrade");
                Label lblPercentage = (Label)item.FindControl("lblPercentage");
                Label lblRowNumber = (Label)item.FindControl("lblRowNumber");

                if (lblRowNumber.Text != e.CommandArgument.ToString())
                {
                    NewRow = dtCorrectEntry.NewRow();

                    NewRow["InstitutionTypeCode"] = lblInstitutionTypeCode.Text;
                    NewRow["InstitutionType"] = lblInstitutionType.Text;
                    NewRow["InstitutionName"] = lblInstitutionName.Text;
                    NewRow["BoardId"] = lblBoardId.Text;
                    NewRow["BoardName"] = lblBoardName.Text;
                    NewRow["standrdCode"] = lblStandardCode.Text;
                    NewRow["standardName"] = lblStandardName.Text;
                    NewRow["DivisionCode"] = lblDivisionCode.Text;
                    NewRow["DivisionName"] = lblDivisionName.Text;
                    NewRow["PassingYearCode"] = lblPassingYearCode.Text;
                    NewRow["PassingYearName"] = lblPassingYearName.Text;
                    NewRow["AditionalDesc"] = lblAditionalDesc.Text;
                    NewRow["ExamName"] = lblExamName.Text;
                    NewRow["FinalMarkObtain"] = lblFinalMarkObt.Text;
                    NewRow["FinalMarkTotal"] = lblFinalMarkTotal.Text;
                    NewRow["Grade"] = lblGrade.Text;
                    NewRow["Percentage"] = lblPercentage.Text;
                    NewRow["RowNumber"] = i.ToString();

                    dtCorrectEntry.Rows.Add(NewRow);
                    i++;
                }
            }
            

            dlAcadInfo.DataSource = dtCorrectEntry;
            dlAcadInfo.DataBind();
            tblAddAcadinfo.Visible = false;
            btnSubmitcon.Visible = true;
           // btnclearcon.Visible = true;
        }
        else if (e.CommandName == "Edit")
        {

            foreach (DataListItem item in dlAcadInfo.Items)
            {

                Label lblInstitutionTypeCode = (Label)item.FindControl("lblInstitutionTypeCode");
                Label lblInstitutionType = (Label)item.FindControl("lblInstitutionType");
                Label lblInstitutionName = (Label)item.FindControl("lblInstitutionName");
                Label lblBoardId = (Label)item.FindControl("lblBoardId");
                Label lblBoardName = (Label)item.FindControl("lblBoardName");
                Label lblStandardCode = (Label)item.FindControl("lblStandardCode");
                Label lblStandardName = (Label)item.FindControl("lblStandardName");
                Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                Label lblDivisionName = (Label)item.FindControl("lblDivisionName");
                Label lblPassingYearCode = (Label)item.FindControl("lblPassingYearCode");
                Label lblPassingYearName = (Label)item.FindControl("lblPassingYearName");
                Label lblAditionalDesc = (Label)item.FindControl("lblAditionalDesc");
                Label lblExamName = (Label)item.FindControl("lblExamName");
                Label lblFinalMarkObt = (Label)item.FindControl("lblFinalMarkObt");
                Label lblFinalMarkTotal = (Label)item.FindControl("lblFinalMarkTotal");
                Label lblGrade = (Label)item.FindControl("lblGrade");
                Label lblPercentage = (Label)item.FindControl("lblPercentage");
                Label lblRowNumber = (Label)item.FindControl("lblRowNumber");


                if (lblRowNumber.Text == e.CommandArgument.ToString())
                {                    
                    ddlinstitutiontype.SelectedValue = lblInstitutionTypeCode.Text;
                    ddlinstitutiontype_SelectedIndexChanged(source, e);
                    txtnameofinstitution.Text = lblInstitutionName.Text;
                    ddlboard.SelectedValue = lblBoardId.Text;
                    ddlcurrentstudying.SelectedValue = lblStandardCode.Text;
                    ddlsection.SelectedValue = lblDivisionCode.Text;
                    ddlyearofpassing.SelectedValue = lblPassingYearCode.Text;
                    txtadditiondesc.Text = lblAditionalDesc.Text;
                    txtExamName.Text = lblExamName.Text;
                    txtFinalMarksObtained.Text = lblFinalMarkObt.Text;
                    txtFinalMarksTotal.Text = lblFinalMarkTotal.Text;
                    txtGrade.Text = lblGrade.Text;
                    txtPercentage.Text = lblPercentage.Text;
                    tblAddAcadinfo.Visible = true;
                    btnSaveAcadInfo.Visible = false;
                    btnUpdateAcadInfo.Visible = true;
                    btnSubmitcon.Visible = false;
                    btnclearcon.Visible = false;
                    lblPKeyRowNumber.Text = lblRowNumber.Text;
                    return;
                }
            }

        }
    }


    protected void ddlinstitutiontype_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
        BindDDL(ddlcurrentstudying, ds, "Description", "ID");
        this.ddlcurrentstudying.Items.Insert(0, "Select");
        this.ddlcurrentstudying.SelectedIndex = 0;
        this.ddlcurrentstudying.Focus();
    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }




    protected void btnSubmitcon_ServerClick(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
        int i = 0;
        lbldateerrordob.Visible = false;
        try
        {
            if (string.IsNullOrEmpty(txtdateofbirth.Value))
            {
            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtdateofbirth.Value)) > DateTime.Today)
                {
                    lbldateerrordob.Visible = true;
                    lbldateerrordob.Text = "DOB cannot be a future date";
                    txtdateofbirth.Focus();
                    return;
                }
                else
                {                    
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

        //foreach (DataListItem item in dlAcadInfo.Items)
        //{
        //    i = 1;
        //    break;
        //}
        //if (i == 0)
        //{
        //    Show_Error_Success_Box("E", "Enter academic Information");
        //    return;
        //}
        //if ((chkFatherInfo.Checked == false) && (chkMotherInfo.Checked == false) && (chkGuardianInfo.Checked == false))
        //{
        //    Show_Error_Success_Box("E", "Enter atleast one secondory contact detail (Father/Mother/Guardian).");
        //    return;
        //}

        string  state = "",city="",Location="";
        if (ddlstate.SelectedValue == "0")
        {
            state = "";
            city = "";
        }
        else
        {
            state = ddlstate.SelectedValue;
            if (ddlcity.SelectedValue == "0")
            {
                city = "";
            }
            else
            {
                city = ddlcity.SelectedValue;
                if (ddllocation.SelectedValue == "0")
                    Location = "";
                else
                    Location = ddllocation.SelectedValue;
            }
        }
        //Acad Info Parameters
        string Institution_Type_Id = "", Institution_Type_Desc = "", Institution_Desc = "", Board_Id = "", Board_Desc = "", Cur_Standard_Id = "", Cur_Standard_Desc="",
                 Section_Id = "", Section_Desc = "", YearOfPassing_Id = "", YearOfPassing_Desc = "", Aditional_Desc = "", ExamName = "", 
                 FinalMarksObt = "", FinalMarksTotal = "", Grade="", Percentage = "";
        foreach (DataListItem item in dlAcadInfo.Items)
        {
            Label lblInstitutionTypeCode = (Label)item.FindControl("lblInstitutionTypeCode");
            Label lblInstitutionType = (Label)item.FindControl("lblInstitutionType");
            Label lblInstitutionName = (Label)item.FindControl("lblInstitutionName");
            Label lblBoardId = (Label)item.FindControl("lblBoardId");
            Label lblBoardName = (Label)item.FindControl("lblBoardName");
            Label lblStandardCode = (Label)item.FindControl("lblStandardCode");
            Label lblStandardName = (Label)item.FindControl("lblStandardName");
            Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
            Label lblDivisionName = (Label)item.FindControl("lblDivisionName");
            Label lblPassingYearCode = (Label)item.FindControl("lblPassingYearCode");
            Label lblPassingYearName = (Label)item.FindControl("lblPassingYearName");
            Label lblAditionalDesc = (Label)item.FindControl("lblAditionalDesc");
            Label lblExamName = (Label)item.FindControl("lblExamName");
            Label lblFinalMarkObt = (Label)item.FindControl("lblFinalMarkObt");
            Label lblFinalMarkTotal = (Label)item.FindControl("lblFinalMarkTotal");
            Label lblGrade = (Label)item.FindControl("lblGrade");
            Label lblPercentage = (Label)item.FindControl("lblPercentage");

            Institution_Type_Id = Institution_Type_Id + lblInstitutionTypeCode.Text + ",";
            Institution_Type_Desc = Institution_Type_Desc + lblInstitutionType.Text + ",";
            Institution_Desc = Institution_Desc + lblInstitutionName.Text + ",";
            Board_Id = Board_Id + lblBoardId.Text + ",";
            Board_Desc = Board_Desc + lblBoardName.Text + ",";
            Cur_Standard_Id = Cur_Standard_Id + lblStandardCode.Text + ",";
            Cur_Standard_Desc = Cur_Standard_Desc + lblStandardName.Text + ",";
	        Section_Id = Section_Id + lblDivisionCode.Text + ",";
            Section_Desc = Section_Desc + lblDivisionName.Text + ",";
            YearOfPassing_Id = YearOfPassing_Id + lblPassingYearCode.Text + ",";
            YearOfPassing_Desc =YearOfPassing_Desc + lblPassingYearName.Text + ",";
            Aditional_Desc = Aditional_Desc + lblAditionalDesc.Text + ",";
            ExamName = ExamName + lblExamName.Text + ",";
            FinalMarksObt =FinalMarksObt + lblFinalMarkObt.Text + ",";
            FinalMarksTotal =FinalMarksTotal + lblFinalMarkTotal.Text + ",";
            Grade = Grade + lblGrade.Text + ",";
            Percentage = Percentage + lblPercentage.Text + ",";           
        }
        //Secondory Contacts Parameter
        string SecCon_Type = "", SecCon_Title = "", SecCon_FName = "", SecCon_MName = "", SecCon_LName = "", SecCon_Handphone1 = "", SecCon_Handphone2 = "",
               SecCon_Landline = "", SecCon_EmailId = "", SecCon_Gender = "", SecCon_Occupation = "", SecCon_Organization = "", SecCon_Designation = "", SecCon_OfficePhone = "";
        if (chkFatherInfo.Checked == true)
        {
            SecCon_Type = SecCon_Type + "Father" + ",";
            SecCon_Title = SecCon_Title + ddlFatherTitle.SelectedItem.ToString() + ",";
            SecCon_FName = SecCon_FName + txtFatherFName.Text.Trim() + ",";
            SecCon_MName = SecCon_MName + txtFatherMName.Text.Trim() + ",";
            SecCon_LName = SecCon_LName + txtFatherLName.Text.Trim() + ",";
            SecCon_Handphone1 = SecCon_Handphone1 + txtFatherHandphone1.Text.Trim() + ",";
            SecCon_Handphone2 = SecCon_Handphone2 + txtFatherHandPhone2.Text.Trim() + ",";
            SecCon_Landline = SecCon_Landline + txtFatherLandLineNumber.Text.Trim() + ",";
            SecCon_EmailId = SecCon_EmailId + txtFatherEmailID.Text.Trim() + ",";
            SecCon_Gender = SecCon_Gender + ddlFatherGender.SelectedItem.ToString() + ",";
            SecCon_Occupation = SecCon_Occupation + txtFatherOccupation.Text.Trim() + ",";
            SecCon_Organization = SecCon_Organization + txtFatherOrganization.Text.Trim() + ",";
            SecCon_Designation = SecCon_Designation + txtFatherDesignation.Text.Trim() + ",";
            SecCon_OfficePhone = SecCon_OfficePhone + txtFatherOfficePhone.Text.Trim() + ",";
        }
        if (chkMotherInfo.Checked == true)
        {
            SecCon_Type = SecCon_Type + "Mother" + ",";
            SecCon_Title = SecCon_Title + ddlMotherTitle.SelectedItem.ToString() + ",";
            SecCon_FName = SecCon_FName + txtMotherFName.Text.Trim() + ",";
            SecCon_MName = SecCon_MName + txtMotherMName.Text.Trim() + ",";
            SecCon_LName = SecCon_LName + txtMotherLName.Text.Trim() + ",";
            SecCon_Handphone1 = SecCon_Handphone1 + txtMotherHandphone1.Text.Trim() + ",";
            SecCon_Handphone2 = SecCon_Handphone2 + txtMotherHandPhone2.Text.Trim() + ",";
            SecCon_Landline = SecCon_Landline + txtMotherLandLineNumber.Text.Trim() + ",";
            SecCon_EmailId = SecCon_EmailId + txtMotherEmailID.Text.Trim() + ",";
            SecCon_Gender = SecCon_Gender + ddlMotherGender.SelectedItem.ToString() + ",";
            SecCon_Occupation = SecCon_Occupation + txtMotherOccupation.Text.Trim() + ",";
            SecCon_Organization = SecCon_Organization + txtMotherOrganization.Text.Trim() + ",";
            SecCon_Designation = SecCon_Designation + txtMotherDesignation.Text.Trim() + ",";
            SecCon_OfficePhone = SecCon_OfficePhone + txtMotherOfficePhone.Text.Trim() + ",";
        }
        if (chkGuardianInfo.Checked == true)
        {
            SecCon_Type = SecCon_Type + "Guardian" + ",";
            SecCon_Title = SecCon_Title + ddlGuardianTitle.SelectedItem.ToString() + ",";
            SecCon_FName = SecCon_FName + txtGuardianFName.Text.Trim() + ",";
            SecCon_MName = SecCon_MName + txtGuardianMName.Text.Trim() + ",";
            SecCon_LName = SecCon_LName + txtGuardianLName.Text.Trim() + ",";
            SecCon_Handphone1 = SecCon_Handphone1 + txtGuardianHandphone1.Text.Trim() + ",";
            SecCon_Handphone2 = SecCon_Handphone2 + txtGuardianHandPhone2.Text.Trim() + ",";
            SecCon_Landline = SecCon_Landline + txtGuardianLandLineNumber.Text.Trim() + ",";
            SecCon_EmailId = SecCon_EmailId + txtGuardianEmailID.Text.Trim() + ",";
            SecCon_Gender = SecCon_Gender + ddlGuardianGender.SelectedItem.ToString() + ",";
            SecCon_Occupation = SecCon_Occupation + txtGuardianOccupation.Text.Trim() + ",";
            SecCon_Organization = SecCon_Organization + txtGuardianOrganization.Text.Trim() + ",";
            SecCon_Designation = SecCon_Designation + txtGuardianDesignation.Text.Trim() + ",";
            SecCon_OfficePhone = SecCon_OfficePhone + txtGuardianOfficePhone.Text.Trim() + ",";
        }
        //Save Record
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds=new DataSet();
        ds = ProductController.Insert_Contacts_Detail(ddlContactsourceadd.SelectedValue,ddlContactType.SelectedValue, ddlContactType.SelectedItem.ToString(), ddlcustomertype.SelectedValue, ddlcustomertype.SelectedItem.ToString(), ddlTitle.SelectedItem.ToString(), txtFirstName.Text.Trim(), txtMidName.Text.Trim(), txtLastName.Text.Trim(),
                                                    ddlGender.SelectedItem.ToString(), txtdateofbirth.Value, txtHandPhone1.Text.Trim(), txtHandphone2.Text.Trim(), txtlandline.Text.Trim(), txtaddress1.Text.Trim(), txtaddress2.Text.Trim(), txtStreetname.Text.Trim(), ddlCountry.SelectedValue, state, city, Location, txtpincode.Text.Trim(),
                                                    txtemailid.Text.Trim(), Institution_Type_Id, Institution_Type_Desc, Institution_Desc, Board_Id, Board_Desc, Cur_Standard_Id, Cur_Standard_Desc,
                                                    Section_Id, Section_Desc, YearOfPassing_Id, YearOfPassing_Desc, Aditional_Desc, ExamName, FinalMarksObt, FinalMarksTotal, Grade,
                                                    Percentage, SecCon_Type, SecCon_Title, SecCon_FName, SecCon_MName, SecCon_LName, SecCon_Handphone1, SecCon_Handphone2,
                                                    SecCon_Landline, SecCon_EmailId, SecCon_Gender, SecCon_Occupation, SecCon_Organization, SecCon_Designation, SecCon_OfficePhone, UserID, "1","","","","");
        if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")//if the record not save
        {
            Show_Error_Success_Box("e", "Error in Contact Save...!");
            return;
        }
        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")//if the record is saved without error and warning
        {
            lblContactWarningError.Text = "";
            lblPKeyContactId.Text = ds.Tables[0].Rows[0]["Con_Id"].ToString();
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalConvertToLead();", true);
            upnlsearch.Visible = false;
            divSaveMessage.Visible = true;

            //HtmlAnchor AssignContactToLead = aAssignToLead;
            //AssignContactToLead.Visible = true;
            //AssignContactToLead.HRef = "Convert_Contact_To_Lead.aspx?&Con_id=" + lblPKeyContactId.Text;
        }
        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "-1")//if the record is saved with warning
        {
            lblPKeyContactId.Text = ds.Tables[0].Rows[0]["Con_Id"].ToString();
            lblContactWarningError.Text = ds.Tables[0].Rows[0]["ErrorWarningMessage"].ToString();
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalConvertToLead();", true);
            upnlsearch.Visible = false;
            divSaveMessage.Visible = true;
            //HtmlAnchor AssignContactToLead = aAssignToLead;
            //AssignContactToLead.Visible = true;
            //AssignContactToLead.HRef = "Convert_Contact_To_Lead.aspx?&Con_id=" + lblPKeyContactId.Text;
        }
        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "-2")//error is come
        {
            Show_Error_Success_Box("E", ds.Tables[0].Rows[0]["ErrorWarningMessage"].ToString());
            return;
        }        
    }


    protected void btn_ConvertToLeadYes_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Convert_Contact_To_Lead.aspx?&Con_id=" + lblPKeyContactId.Text + "&flag=1");
        //string url = "Convert_Contact_To_Lead.aspx?&Con_id=" + lblPKeyContactId.Text;
        //StringBuilder sb = new StringBuilder();
        //sb.Append("<script type = 'text/javascript'>");
        //sb.Append("window.open('");
        //sb.Append(url);
        //sb.Append("');");
        //sb.Append("</script>");
        //ClientScript.RegisterStartupScript(this.GetType(),
        //        "script", sb.ToString());
    }

    protected void btn_ConvertToLeadNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Add_Contacts.aspx");
    }


    protected void btn_SearchContact_Click(object sender, EventArgs e)
    {
        Response.Redirect("Contacts.aspx");
    }

    private void StudentType()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlcustomertype, ds, "Description", "Cust_Grp");
        ddlcustomertype.Items.Insert(0, "Select");
        ddlcustomertype.SelectedIndex = 0;
        ddlcustomertype.SelectedValue = "02";
    }

    protected void btn_ConvertToLeadYes_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Convert_Contact_To_Lead.aspx?&Con_id="+lblPKeyContactId.Text);
    }
    protected void btn_ConvertToLeadNo_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Add_Contacts.aspx");
    }

    

    protected void chkFatherInfo_CheckedChanged(object sender, EventArgs e)
    {
        //int rowcount=
        try
        {
            CheckBox s = sender as CheckBox;
            tblFatherInfo.Visible = s.Checked;
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }
    protected void chkMotherInfo_CheckedChanged(object sender, EventArgs e)
    {
        //int rowcount=
        try
        {
            CheckBox s = sender as CheckBox;
            tblMotherInfo.Visible = s.Checked;
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }


    protected void chkGuardianInfo_CheckedChanged(object sender, EventArgs e)
    {
        //int rowcount=
        try
        {
            CheckBox s = sender as CheckBox;
            tblGuardianInfo.Visible = s.Checked;
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
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
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
        else
        {
            divSuccessmessage.Visible = true;
            divErrormessage.Visible = false;
            lblsuccessMessage.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
    }

    /// <summary>
    /// Clear Error Success Box
    /// </summary>
    private void Clear_Error_Success_Box()
    {
        divErrormessage.Visible = false;
        divSuccessmessage.Visible = false;
        lblsuccessMessage.Text = "";
        lblerrormessage.Text = "";
        UpdatePanelMsgBox.Update();
    }
    protected void btnclearSeccon_ServerClick(object sender, System.EventArgs e)
    {
        string Oppur_Id = Request["Lead_id"];
        Response.Redirect("Lead_Edit.aspx?&Lead_ID=" + Oppur_Id);
    }

    protected void btnConClose_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Contacts.aspx");
    }

}