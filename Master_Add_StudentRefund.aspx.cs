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

public partial class Master_Add_StudentRefund : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ControlVisibility("Search");

            BindDivision();
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

    private void BindDivision()
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;

    }
    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindAcademicYear();
    }
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", "MT");
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }
    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
    }
    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "Select");
        //ddlacademicyear.SelectedIndex = 0;
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    ddlacademicyear.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
        //}
    }
    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue);
        BindListBox(ddlstreamname, ds, "Stream_Sdesc", "Stream_Code");
        ddlstreamname.Items.Insert(0, "All");
        ddlstreamname.SelectedIndex = 0;
    }

    //private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    //{
    //    ddl.DataSource = ds;
    //    ddl.DataTextField = txtField;
    //    ddl.DataValueField = valField;
    //    ddl.DataBind();
    //}

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






    /// <summary>
    /// Bind search  Datalist
    /// </summary>
    private void FillGrid()
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddldivision.SelectedValue == "Select")
            {
                Show_Error_Success_Box("E", "Select Division");
                ddldivision.Focus();
                return;
            }

            if (ddlacademicyear.SelectedValue == "Select")
            {
                Show_Error_Success_Box("E", "Select Acadyear");
                ddldivision.Focus();
                return;
            }




            ControlVisibility("Result");

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = PaymentController.Get_studentForRefund(ddldivision.Text.Trim(), ddlacademicyear.Text.Trim(), ddlcenter.Text.Trim(), ddlstreamname.Text, Txtsbentrycode.Text);
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



        }
        catch (Exception ex)
        {

            Show_Error_Success_Box("E", ex.ToString());
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
                    TextBox txtAmount = (TextBox)dtlItem.FindControl("txtAmount");
                    TextBox txtremarks = (TextBox)dtlItem.FindControl("txtremarks");
                    Label lblErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");
                    Label lblamt = (Label)dtlItem.FindControl("lblamt");

                    chkitemck.Checked = s.Checked;
                    if (s.Checked == true)
                    {
                        txtAmount.Visible = true;
                        txtremarks.Visible = true;
                        lblamt.Visible = false;
                    }
                    else
                    {
                        txtAmount.Visible = false;
                        txtremarks.Visible = false;
                        lblamt.Visible = true;
                        txtAmount.Text = "";
                        txtremarks.Text = "";
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
            TextBox txtAmount = row.FindControl("txtAmount");
            TextBox txtremarks = row.FindControl("txtremarks");
            Label lblamt = row.FindControl("lblamt");
            Label lblErrorSaveMessage = row.FindControl("lblErrorSaveMessage");

            if (s.Checked == true)
            {
                txtAmount.Visible = true;
                txtremarks.Visible = true;
                lblamt.Visible = false;
            }
            else
            {
                txtAmount.Visible = false;
                txtremarks.Visible = false;
                lblamt.Visible = true;
                txtAmount.Text = "";
                txtremarks.Text = "";
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


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        //string XMLData = "<Payments>";
        //int i = 0, j = 0;
        foreach (DataListItem dtlItem in dlGridDisplay.Items)
        {

            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

            if (chkCheck.Checked == true)
            {
                //i = 1;
                TextBox txtAmount = (TextBox)dtlItem.FindControl("txtAmount");
                TextBox txtremarks = (TextBox)dtlItem.FindControl("txtremarks");
                Label lblErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");
                if (txtAmount.Text == "")
                {
                    //j = -1;
                    lblErrorSaveMessage.CssClass = "red";
                    lblErrorSaveMessage.Text = "Add Refund Amount";
                }
                if (txtremarks.Text == "")
                {
                    // j = -1;
                    lblErrorSaveMessage.CssClass = "red";
                    lblErrorSaveMessage.Text = "Add Remarks";
                }
                else
                {
                    lblErrorSaveMessage.Text = "";
                    Label lblRowNo = (Label)dtlItem.FindControl("lblRowNo");
                    Label lblSBEntryCode = (Label)dtlItem.FindControl("lblSBEntryCode");
                    Label LblCenterCode = (Label)dtlItem.FindControl("LblCenterCode");




                    DataSet ds = new DataSet();
                    ds = PaymentController.Update_insert_student_Refund_data(ddldivision.SelectedValue, ddlacademicyear.SelectedValue, LblCenterCode.Text, lblSBEntryCode.Text, Convert.ToInt32(txtAmount.Text), txtremarks.Text, UserID);
                    if (ds != null)
                    {
                        //Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lblErrorSaveMessage");
                        if (ds.Tables[0].Rows[0]["ErrorSaveId"].ToString() == "-2") //Error Record
                        {
                            lblErrorSaveMessage.CssClass = "red";
                            lblErrorSaveMessage.Text = ds.Tables[0].Rows[0]["lblErrorSaveMessage"].ToString();
                        }
                        else if (ds.Tables[0].Rows[0]["ErrorSaveId"].ToString() == "1") //Save Record
                        {
                            lblErrorSaveMessage.CssClass = "green";
                            lblErrorSaveMessage.Text = ds.Tables[0].Rows[0]["lblErrorSaveMessage"].ToString();

                        }

                    }
                }
            }
        }


    }


    #endregion
}