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
//using LMS_UserDetails;
//using iTextSharp.text;
//using iTextSharp.text.pdf;

public partial class Batch_Assignment_New : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            //Page_Validation();
            ControlVisibility("Search");
            FillDDL_Division();
            FillDDL_AcadYear();

        }
    }

    //private void Page_Validation()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];

    //    string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
    //    System.IO.FileInfo Info = new System.IO.FileInfo(Path);
    //    string pageName = Info.Name;

    //    int ResultId = 0;

    //    ResultId = ProductController.Chk_Page_Validation(pageName, UserID, "DB01");

    //    if (ResultId >= 1)
    //    {
    //        //Allow
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Dashboard_Center.aspx", false);
    //    }

    //}
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
            PendingStudent.Visible = true;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = false;
            DivViewStudDetail.Visible = true;

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
        ControlVisibility("Search");
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
                //lblViewDetailBatch_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["BatchName"]);

                lblViewDetailClassroomProduct_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Products"]);

                //lblViewDetailMaxBatchStrength_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["MaxCapacity"]);
                lblViewDetailLMSProduct_Result.Text = Convert.ToString(dsBatch.Tables[2].Rows[0]["ProductName"]);
            }

            //dlViewDetail.DataSource = dsBatch.Tables[1];
            //dlViewDetail.DataBind();           
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.Message);
            return;
        }

    }

   


    protected void btnresetsearch_ServerClick(object sender, System.EventArgs e)
    {
        //FillBatchDetails(lblPKey_Add.Text);
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

    protected void ddlDivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_Standard();
        FillDDL_Search_Centre();
        Clear_Error_Success_Box();
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
        DataSet dsCentre = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlDivision.SelectedValue, "", "MT");
        BindListBox(ddlCentre, dsCentre, "Center_Name", "Center_Code");
        ddlCentre.Items.Insert(0, "Select");
        ddlCentre.SelectedIndex = 0;
        //BindListBox(ddlCentre, dsCentre, "Center_Name", "Center_Code");
    }

    protected void ddlcoursegroup_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_Product();
    }
    protected void ddlproductegroup_SelectedIndexChanged(object sender, System.EventArgs e)
    {

        FillDDL_classroomcourse();
    }
    private void FillDDL_Standard()
    {
        string Div_Code = null;
        Div_Code = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();

        DataSet dsStandard = ProductController.GetAllActive_Standard_ForYear(Div_Code, YearName);
        BindListBox(ddlStandard, dsStandard, "Standard_Name", "Standard_Code");
        ddlStandard.Items.Insert(0, "Select");
        ddlStandard.SelectedIndex = 0;
    }

    private void FillDDL_Product()
    {
        string Div_Code = null;
        Div_Code = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();

        string centercode = null;
        centercode = ddlCentre.SelectedValue;

        //string Standardcode = null;

        string Standardcode = null;
        Standardcode = ddlStandard.SelectedValue;

        DataSet dsproduct = ProductController.GetBatchBy_Division_Year_Standard_Centre_ForProduct(Div_Code, YearName, Standardcode, centercode);
        BindDDL(DDlLmsProduct, dsproduct, "ProductName", "ProductCode");
        DDlLmsProduct.Items.Insert(0, "Select");
        DDlLmsProduct.SelectedIndex = 0;


    }
    private void FillDDL_classroomcourse()
    {
        string Div_Code = null;
        Div_Code = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();
        string coursecode = null;
        coursecode = ddlStandard.SelectedValue;
        string productcode = null;
        productcode = DDlLmsProduct.SelectedValue;


        DataSet dsclassroom = ProductController.GetAllActive_Product(Div_Code, YearName, coursecode, productcode, ddlCentre.SelectedValue, "2");
        if (dsclassroom.Tables[0].Rows.Count > 0)
        {
            LBLStreamname.Text = dsclassroom.Tables[0].Rows[0]["streamname"].ToString();
            LBLStreamname.Enabled = true;

            txtstreamcode.Text = dsclassroom.Tables[0].Rows[0]["streamcode"].ToString();
            txtstreamcode.Enabled = false;

        }



    }


    protected void ddlAcadYear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_Standard();
        Clear_Error_Success_Box();
    }

    public void All_Student_ChkBox_Selected(object sender, System.EventArgs e)
    {
        ////Change checked status of a hidden check box
        //chkStudentAllHidden.Checked = !(chkStudentAllHidden.Checked);
        CheckBox s = sender as CheckBox;
        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlGridDisplay_Pending.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            //TextBox DDLbatchName = (TextBox)dtlItem.FindControl("DDLbatchName");

            //chkitemck.Checked = chkStudentAllHidden.Checked;

            //TextBox txtDLrollno = (TextBox)dtlItem.FindControl("txtDLrollno");
            chkitemck.Checked = s.Checked;
            if (chkitemck.Checked == true)
            {
                BtnSave.Visible = true;

            }
            else
            {
                BtnSave.Visible = false;
            }
        }

    }

    protected void chkCheck_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            //Set checked status of hidden check box to items in grid
            foreach (DataListItem dtlItem in dlGridDisplay_Pending.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                // TextBox txtDLrollno = (TextBox)dtlItem.FindControl("txtDLrollno");

                if (chkitemck.Checked == true)
                {
                    BtnSave.Visible = true;

                }




            }




            Clear_Error_Success_Box();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    public void All_Student_ChkBox_Selected_Sel(object sender, System.EventArgs e)
    {
        ////Change checked status of a hidden check box
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
        
         //Saving part
        

            string DivisionCode = null;
            DivisionCode = ddlDivision.SelectedValue;
            
            string StandardCode = "";
            StandardCode = ddlStandard.SelectedValue;
            string Productcode = "";
            Productcode = DDlLmsProduct.SelectedValue;
             string acadyear = null;
        acadyear = ddlAcadYear.SelectedItem.ToString();

        string center_code = null;
        center_code = ddlCentre.SelectedValue;

            
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            string CreatedBy = null;
            CreatedBy = UserID;
                int icount = 0;
                foreach (DataListItem TextBox in dlGridDisplay_Pending.Items)
                        {
                            CheckBox chkitemck = (CheckBox)TextBox.FindControl("chkStudent");
                            if (chkitemck.Checked == true)
                         {
                             icount++;
                         }
                        }
                        if (icount > 0)
                        {
                           
                            foreach (DataListItem TextBox in dlGridDisplay_Pending.Items)
                            {

                                CheckBox chkitemck = (CheckBox)TextBox.FindControl("chkStudent");

                                //Label lblRegcode = (Label)TextBox.FindControl("lblRegcode");
                                if (chkitemck.Checked == true)
                                {

                                    Label lblSBEntryCode = (Label)TextBox.FindControl("lblSBEntryCode");
                                    Label lblstudentcode = (Label)TextBox.FindControl("lblstudentcode");

                                    ListBox DDLbatchName = (ListBox)TextBox.FindControl("DDLbatchName");

                                    Label lblResult = (Label)TextBox.FindControl("lblResult");
                                    lblResult.Text = "";
                                    List<string> list = new List<string>();
                                    string Batchcode = "";

                                    foreach (ListItem li in DDLbatchName.Items)
                                    {
                                        if (li.Selected == true)
                                        {
                                            list.Add(li.Value);
                                            Batchcode = string.Join(",", list.ToArray());
                                        }
                                    }


                                    int ResultId = 0;
                                    //Mark exemption/absent/present for those students who are selected
                                    ResultId = ProductController.Insert_Newbatchdetails(DivisionCode, StandardCode, Productcode, center_code, lblSBEntryCode.Text.Trim(), lblstudentcode.Text.Trim(), Batchcode, CreatedBy, acadyear, "2");
                                    if (ResultId == 1)
                                    {

                                        lblResult.ForeColor = System.Drawing.Color.Green;
                                        lblResult.Text = "saved successfully";
                                    }
                                    if (ResultId == -1)
                                    {
                                        lblResult.ForeColor = System.Drawing.Color.Red;
                                        lblResult.Text = "Error : Roll Number Alredy Exists";
                                    }

                                    if (ResultId == 2)
                                    {
                                        lblResult.ForeColor = System.Drawing.Color.Gray;
                                        lblResult.Text = "Roll Number Edited successfully";
                                    }
                                }

                            }
                        }
                        if (icount < 1)
                        {
                           

                            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalerror();", true);
                            return;
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

        if (ddlCentre.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0006");
            ddlCentre.Focus();
            return;
        }
        if (ddlStandard.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0003");
            ddlStandard.Focus();
            return;
        }
        if (DDlLmsProduct.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0004");
            DDlLmsProduct.Focus();
            return;
        }

        string DivisionCode = null;
        DivisionCode = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();

        string StandardCode = "";
        StandardCode = ddlStandard.SelectedValue;

        string CentreCode = "";
        CentreCode = ddlCentre.SelectedValue;

        string ProductCode = "";
        ProductCode = DDlLmsProduct.SelectedValue;




        //int StdCnt = 0;
        //int StdSelCnt = 0;
        //for (StdCnt = 0; StdCnt <= ddlStandard.Items.Count - 1; StdCnt++)
        //{
        //    if (ddlStandard.Items[StdCnt].Selected == true)
        //    {
        //        StdSelCnt = StdSelCnt + 1;
        //    }
        //}

        //if (StdSelCnt == 0)
        //{
        //    //When all is selected
        //    for (StdCnt = 0; StdCnt <= ddlStandard.Items.Count - 1; StdCnt++)
        //    {
        //        StandardCode = StandardCode + ddlStandard.Items[StdCnt].Value + ",";
        //    }
        //    //if (Strings.Right(StandardCode, 1) == ",")
        //    //    StandardCode = Strings.Left(StandardCode, Strings.Len(StandardCode) - 1);
        //    StandardCode = Common.RemoveComma(StandardCode);
        //}
        //else
        //{
        //    for (StdCnt = 0; StdCnt <= ddlStandard.Items.Count - 1; StdCnt++)
        //    {
        //        if (ddlStandard.Items[StdCnt].Selected == true)
        //        {
        //            StandardCode = StandardCode + ddlStandard.Items[StdCnt].Value + ",";
        //        }
        //    }
        //    //if (Strings.Right(StandardCode, 1) == ",")
        //    //    StandardCode = Strings.Left(StandardCode, Strings.Len(StandardCode) - 1);
        //    StandardCode = Common.RemoveComma(StandardCode);
        //}


        //int CentreCnt = 0;
        //int CentreSelCnt = 0;
        //for (CentreCnt = 0; CentreCnt <= ddlCentre.Items.Count - 1; CentreCnt++)
        //{
        //    if (ddlCentre.Items[CentreCnt].Selected == true)
        //    {
        //        CentreSelCnt = CentreSelCnt + 1;
        //    }
        //}

        //if (CentreSelCnt == 0)
        //{
        //    //all are selected
        //    for (CentreCnt = 0; CentreCnt <= ddlCentre.Items.Count - 1; CentreCnt++)
        //    {
        //        CentreCode = CentreCode + ddlCentre.Items[CentreCnt].Value + ",";
        //    }

        //}
        //else
        //{
        //    for (CentreCnt = 0; CentreCnt <= ddlCentre.Items.Count - 1; CentreCnt++)
        //    {
        //        if (ddlCentre.Items[CentreCnt].Selected == true)
        //        {
        //            CentreCode = CentreCode + ddlCentre.Items[CentreCnt].Value + ",";
        //        }
        //    }

        //}

        try
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showProgress2();", true);

            DataSet dsBatch = ProductController.GetBatchBY_PKey_with_Product(DivisionCode, YearName, StandardCode, CentreCode, ProductCode, "1");

            if (dsBatch.Tables[0].Rows.Count > 0)
            {
                lblViewDetailDivision_Result.Text = ddlDivision.SelectedValue;
                lblViewDetailAcadYear_Result.Text = ddlAcadYear.SelectedValue;
                lblViewDetailCourse_Result.Text = ddlStandard.SelectedItem.ToString();
                lblViewDetailCenter_Result.Text = ddlCentre.SelectedItem.ToString();
                lblViewDetailLMSProduct_Result.Text = DDlLmsProduct.SelectedItem.ToString();
                lblViewDetailClassroomProduct_Result.Text = LBLStreamname.Text;
                //lblViewDetailBatchShortName_Result.Text = Convert.ToString(dsBatch.Tables[1].Rows[0]["BatchName"]);
                //lblViewDetailSubjects_Result.Text = Convert.ToString(dsBatch.Tables[1].Rows[0]["BatchSubject"]);
                //lblViewDetailLMSProduct_Result.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Products"]);
                //lblSubjects_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["Subjects"]);
                //lblMaxBatchStrength_Add.Text = Convert.ToString(dsBatch.Tables[0].Rows[0]["MaxCapacity"]);
                //streamcode = Convert.ToString(dsBatch.Tables[0].Rows[0]["Streamcode"]);
                //lbllmsproductname.Text = Convert.ToString(dsBatch.Tables[3].Rows[0]["ProductName"]);
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showProgress();", true);
            dlGridDisplay_Pending.DataSource = dsBatch.Tables[0];
            dlGridDisplay_Pending.DataBind();
            ControlVisibility("Manage");
            FillDDL_classRoom();

            //dlGridDisplay_Selected.DataSource = dsBatch.Tables[2];
            //dlGridDisplay_Selected.DataBind();
            foreach (DataListItem dtlItem12 in dlGridDisplay_Pending.Items)
            {
                ListBox DDLbatchName = (ListBox)dtlItem12.FindControl("DDLbatchName");
                //ListBox ddlClassroomsubjectserachadd = (ListBox)dtlItem12.FindControl("ddlClassroomsubjectserachadd");



                Label LblbactCode = (Label)dtlItem12.FindControl("LBLmapedbatchCode");

                DataSet dsGrid1 = ProductController.GetAllActive_Product_Batch(DivisionCode, YearName, StandardCode, CentreCode, ProductCode, LblbactCode.Text, 2);
                if (dsGrid1.Tables[0].Rows.Count > 0)
                {


                    //Fill selected Batches
                    if (dsGrid1.Tables[0].Rows.Count > 0)
                    {
                        for (int cnt = 0; cnt <= dsGrid1.Tables[0].Rows.Count - 1; cnt++)
                        {
                            for (int rcnt = 0; rcnt <= DDLbatchName.Items.Count - 1; rcnt++)
                            {
                                if (DDLbatchName.Items[rcnt].Value == dsGrid1.Tables[0].Rows[cnt]["Batch_Code"].ToString())
                                {
                                    DDLbatchName.Items[rcnt].Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                    //if (dsGrid1.Tables[1].Rows.Count > 0)
                    //{
                    //    for (int cnt1 = 0; cnt1 <= dsGrid1.Tables[1].Rows.Count - 1; cnt1++)
                    //    {
                    //        for (int rcnt1 = 0; rcnt1 <= ddlClassroomsubjectserachadd.Items.Count - 1; rcnt1++)
                    //        {
                    //            if (ddlClassroomsubjectserachadd.Items[rcnt1].Value == dsGrid1.Tables[1].Rows[cnt1]["Sgr_Material"].ToString())
                    //            {
                    //                ddlClassroomsubjectserachadd.Items[rcnt1].Selected = true;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}


                }

            }




            //BindddlInstitute();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.Message);
            return;
        }


        //string BatchName = null;
        //if (string.IsNullOrEmpty(txtBatchName.Text.Trim()))
        //{
        //    BatchName = "%";
        //}
        //else
        //{
        //    BatchName = "%" + txtBatchName.Text.Trim();
        //}

        //DataSet dsGrid = ProductController.GetBatchBy_Division_Year_Standard_Centre_new(DivisionCode, YearName, StandardCode, CentreCode);
        ////dlGridDisplay.DataSource = dsGrid;
        ////dlGridDisplay.DataBind();

        ////lblPKey_Add.Text = e.CommandArgument.ToString();
        //FillBatchDetails(lblPKey_Add.Text);


        //dlGridExport.DataSource = dsGrid;
        //dlGridExport.DataBind();

        lblDivision_Result.Text = ddlDivision.SelectedItem.ToString();
        lblAcadYear_Result.Text = ddlAcadYear.SelectedItem.ToString();

    }



    public Batch_Assignment_New()
    {
        Load += Page_Load;
    }


    protected void btn_Next_Click(object sender, EventArgs e)
    {
    }
   
    protected void btn_CloseCent_Click(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalerror();", false);
    }
    protected void HLExport_Click(object sender, EventArgs e)
    {

    }

    //fill bacth
    private void FillDDL_classRoom()
    {

        try
        {
            string DivisionCode = null;
            DivisionCode = ddlDivision.SelectedValue;

            string YearName = null;
            YearName = ddlAcadYear.SelectedItem.ToString();

            string StandardCode = "";
            StandardCode = ddlStandard.SelectedValue;

            string CentreCode = "";
            CentreCode = ddlCentre.SelectedValue;

            string ProductCode = "";
            ProductCode = DDlLmsProduct.SelectedValue;

            DataSet dsbatchcode = ProductController.GetAllActive_Product_Batch(DivisionCode, YearName, StandardCode, CentreCode, ProductCode, "", 1);

            foreach (DataListItem dtlItem in dlGridDisplay_Pending.Items)
            {
                ListBox DDLbatchName = (ListBox)dtlItem.FindControl("DDLbatchName");
                //ListBox ddlClassroomsubjectserachadd = (ListBox)dtlItem.FindControl("ddlClassroomsubjectserachadd");
                //ListBox ddlClassroomsubjectadd = (ListBox)dtlItem.FindControl("ddlClassroomsubjectserach");

                DDLbatchName.Items.Clear();
                DDLbatchName.DataSource = dsbatchcode.Tables[0];
                DDLbatchName.DataTextField = "BatchName";
                DDLbatchName.DataValueField = "Batch_Code";
                DDLbatchName.DataBind();

                DDLbatchName.Items.Clear();
                DDLbatchName.DataSource = dsbatchcode.Tables[0];
                DDLbatchName.DataTextField = "BatchName";
                DDLbatchName.DataValueField = "Batch_Code";
                DDLbatchName.DataBind();
            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
    }

}