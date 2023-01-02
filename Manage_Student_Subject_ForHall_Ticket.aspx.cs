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

public partial class Manage_Student_Subject_ForHall_Ticket : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            ControlVisibility("Search");
            FillDDL_Division();
            FillDDL_AcadYear();

        }
    }

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            DivResultPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;

        }


        Clear_Error_Success_Box();
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

    private void FillDDL_Search_Centre()
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet dsCentre = ProductController.GetUser_Company_Division_Zone_Center(18, UserID, ddlDivision.SelectedValue, "", "MT");
        BindListBox(ddlCentre, dsCentre, "Center_Name", "Center_Code");
        ddlCentre.Items.Insert(0, "Select");


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

        if (ddlCentre.SelectedIndex <= 0)
        {
            Show_Error_Success_Box("E", "Kindly Select Center");
            return;
        }
 


        ControlVisibility("Result");


        //string streamcode = "";
        //streamcode = txtstreamcode.Text;


        string DivisionCode = null;
        DivisionCode = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();




        DataSet dsGrid = ProductController.GetStudentBy_Division_Year_Standard_Centre(DivisionCode, LBLStreamname.SelectedValue, ddlCentre.SelectedValue, "", "2");
        dlGridDisplay.DataSource = dsGrid;
        dlGridDisplay.DataBind();
        BtnSave.Visible = true;

        foreach (DataListItem dtlItem in dlGridDisplay.Items)
        {


            ListBox DDlsubjects = (ListBox)dtlItem.FindControl("DDlsubjects");
            //ddlabsentreason.SelectedIndex = 0;
            DataSet dsclassroom = ProductController.GetAllActive_Product("", "", "", "", "", "5");
            //DataSet ds1 = ProductController.GetAllAbsentreasons();
            BindListBox(DDlsubjects, dsclassroom, "Subject_name", "Subject_Code");
            DDlsubjects.Items.Insert(0, "Select");
            DDlsubjects.SelectedIndex = 0;
            Label lblDLSubjectname = (Label)dtlItem.FindControl("lblDLSubjectname");
            //Label lblDLSubjectID = (Label)dtlItem.FindControl("lblDLSubjectID");
            //lblDLSubjectname.Text = DDlsubjects.SelectedIndex.ToString();

            //DDlsubjects.SelectedValue = lblDLSubjectID.Text;
            lblDLSubjectname.Visible = true;

        }

        lblDivision_Result.Text = ddlDivision.SelectedItem.ToString();
        lblAcadYear_Result.Text = ddlAcadYear.SelectedItem.ToString();
        Lblcenter_Result.Text = ddlCentre.SelectedItem.ToString();
        lbltotalcount.Text = Convert.ToString(dsGrid.Tables[0].Rows.Count);
    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        
        Clear_Error_Success_Box();
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_Search_Centre();
    }



    protected void ddlCenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_classroomcourse();

    }

    



    private void FillDDL_classroomcourse()
    {
        string Div_Code = null;
        Div_Code = ddlDivision.SelectedValue;

        string YearName = null;
        YearName = ddlAcadYear.SelectedItem.ToString();
   


        DataSet dsstreacode = ProductController.GetAllActive_Product(Div_Code, YearName, "", "", ddlCentre.SelectedValue, "6");
        BindListBox(LBLStreamname, dsstreacode, "Stream_SDesc", "Stream_Code");
        LBLStreamname.Items.Insert(0, "Select");



    }

    private void FillDDL_Subjectdetails()
    {


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
                ListBox DDlsubjects = (ListBox)dtlItem.FindControl("DDlsubjects");
                Label lblDLSubjectname = (Label)dtlItem.FindControl("lblDLSubjectname");
                chkitemck.Checked = s.Checked;
                if (chkitemck.Checked == true)
                {
                    DDlsubjects.Visible = true;
                    lblDLSubjectname.Visible = false;
                    lblDLSubjectname.Text = "";
                }
                else
                {
                    //txtDLrollno.Enabled = false;
                }
            }
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

            //Set checked status of hidden check box to items in grid
            foreach (DataListItem dtlItem in dlGridDisplay.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
                ListBox DDlsubjects = (ListBox)dtlItem.FindControl("DDlsubjects");
                Label lblDLSubjectname = (Label)dtlItem.FindControl("lblDLSubjectname");

                if (chkitemck.Checked == true)
                {

                    DDlsubjects.Visible = true;
                    lblDLSubjectname.Visible = false;
                    lblDLSubjectname.Text = "";
                }
                else
                {
                    //txtDLrollno.Enabled = false;
                }



            }




            Clear_Error_Success_Box();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }


    protected void Btnclose_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }
    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }



    protected void BtnSave_Click(object sender, EventArgs e)
    {

        //Saving part
        string DivisionCode = null;
        DivisionCode = ddlDivision.SelectedValue;

        string StandardCode = "";
       

        Label lblHeader_User_Code = default(Label);
        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        string CreatedBy = null;
        CreatedBy = UserID;

        foreach (DataListItem TextBox in dlGridDisplay.Items)
        {
            CheckBox chkitemck = (CheckBox)TextBox.FindControl("chkCheck");
            //Label lblRegcode = (Label)TextBox.FindControl("lblRegcode");
            if (chkitemck.Checked == true)
            {
                Label Lblcentercode = (Label)TextBox.FindControl("Lblcentercode");
                Label Lblstreamcode = (Label)TextBox.FindControl("Lblstreamcode");
                Label LBlsbnetry = (Label)TextBox.FindControl("LBlsbnetry");
                Label lblSPID = (Label)TextBox.FindControl("lblSPID");
                ListBox DDlsubjects = (ListBox)TextBox.FindControl("DDlsubjects");
                string rollCodeForEdit = null;
              
                string subjectcode = "";
                int SubjectCnt = 0;
                string subjectname = "";
                //int SubjectCnt = 0;

         
                {
                    for (SubjectCnt = 0; SubjectCnt <= DDlsubjects.Items.Count - 1; SubjectCnt++)
                    {
                        if (DDlsubjects.Items[SubjectCnt].Selected == true)
                        {
                            subjectcode = subjectcode + DDlsubjects.Items[SubjectCnt].Value + ",";
                        }
                    }
                    subjectcode = Common.RemoveComma(subjectcode);

                }

                {
                    for (SubjectCnt = 0; SubjectCnt <= DDlsubjects.Items.Count - 1; SubjectCnt++)
                    {
                        if (DDlsubjects.Items[SubjectCnt].Selected == true)
                        {
                            subjectname = subjectname + DDlsubjects.Items[SubjectCnt].Text +" ";
                        }
                    }
                    subjectname = Common.RemoveComma(subjectname);

                }

                Label lblResult = (Label)TextBox.FindControl("lblResult");
                lblResult.Text = "";


                int ResultId = 0;
                //Mark exemption/absent/present for those students who are selected
                ResultId = ProductController.Insert_StudentSubeject(DivisionCode, Lblcentercode.Text.Trim(), Lblstreamcode.Text.Trim(), LBlsbnetry.Text.Trim(), lblSPID.Text.Trim(), subjectcode,subjectname, ddlAcadYear.SelectedValue, rollCodeForEdit, CreatedBy, "2");
                if (ResultId == 1)
                {

                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = " Subject saved successfully";
                }
                if (ResultId == -1)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Error : Subject  Alredy Exists";
                }

                if (ResultId == 2)
                {
                    lblResult.ForeColor = System.Drawing.Color.Gray;
                    lblResult.Text = "Subject Edited successfully";
                }
            }

        }



    }
}