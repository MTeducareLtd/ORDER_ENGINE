using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Net;
using ShoppingCart.BL;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class Registration_MPUC : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            lblDivHead.Text = "Please Fill Following Information";
            //FillDDL_Division();
            FillDDL_CurrentSScCenter();
            //FillDDL_CouncilBy();

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            if ((UserID == "") || (UserID == null))
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

    

    #region Event
    protected void lnkSearchInfo_Click(object sender, EventArgs e)
   {
        try
        {


            DataSet ds = ProductController.Get_RegistrationDetail_Byno(txtSearchUID.Text.Trim(), "1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Result"].ToString() == "-1")
                {
                    Show_Error_Success_Box("E", "Record Not Found");
                    tblSearchInfo.Visible = true;
                    tblSearchDetail.Visible = false;
                    BindAcademicYear();
                    BtnSave.Visible = true;
                    BtnClose.Visible = true;
                    txtFName.Text = "";
                    txtMName.Text = "";
                    txtLName.Text = "";
                    txtAddress.Text = "";
                    txtParentName.Text = "";
                    txtParentContact.Text = "";
                    txtStudentEmailId.Text = "";
                    txtParentEmailId.Text = "";
                    txtContactNo.Text = "";
                    ddlCurrentSSCCenter.SelectedIndex = 0;
                    Txtschoolname.Text = "";
                    txtDOB.Value = "";
                    Txtcity.Text = "";
                    ddlBorad.SelectedIndex = 0;
                    DDLStatus.SelectedIndex = 0;
                    DDlHostel.SelectedIndex = 0;
                    ddlProductName.SelectedIndex = 0;


                   // ddlDivision.SelectedIndex = 0;
                    //ddlDivision_SelectedIndexChanged(sender, e);
                    //ddlPrefferedScCenter_SelectedIndexChanged(sender, e);
                    //ddlProductName_SelectedIndexChanged(sender, e);
                    ddlPayMode.SelectedIndex = 0;
                    ddlPayType.SelectedIndex = 0;
                    ddlPayType_SelectedIndexChanged(sender, e);

                    txtCCDCAmount.Text = "";
                    txtCCDCTransctionId.Text = "";
                    txtChequeDate.Value = "";
                    txtChequeAmount.Text = "";
                    txtMICRCode.Text = "";
                    lblBankName.Text = "";
                    txtChequeNo.Text = "";
                    FillDDL_CurrentSScCenter();
                   // ddlBorad.SelectedIndex = 0;
                    return;
                }
                else if (ds.Tables[0].Rows[0]["Result"].ToString() == "-2")
                {
                    Show_Error_Success_Box("E", "Admission Already Taken");
                    tblSearchInfo.Visible = false;
                    tblSearchDetail.Visible = true;
                    BtnSave.Visible = false;
                    BtnClose.Visible = false;
                    return;
                }
                else if (ds.Tables[0].Rows[0]["Result"].ToString() == "-3")
                {
                    Show_Error_Success_Box("E", "Parents has not yet Accepted Terms and Conditions");
                    tblSearchInfo.Visible = false;
                    tblSearchDetail.Visible = true;
                    BtnSave.Visible = false;
                    BtnClose.Visible = false;
                    return;
                }
                else if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        tblSearchInfo.Visible = true;
                        BindAcademicYear();
                        //tblSearchDetail.Visible = true;
                        BtnSave.Visible = false;
                        BtnClose.Visible = true;
                        ddlacademicyear.Text = ds.Tables[1].Rows[0]["AcadYear"].ToString();
                        txtFName.Text = ds.Tables[1].Rows[0]["First_Name"].ToString();
                        txtMName.Text = ds.Tables[1].Rows[0]["Middle_Name"].ToString();
                        txtLName.Text = ds.Tables[1].Rows[0]["Last_Name"].ToString();
                        txtAddress.Text = ds.Tables[1].Rows[0]["Address"].ToString();
                        txtParentName.Text = ds.Tables[1].Rows[0]["Parent_Name"].ToString();
                        txtParentContact.Text = ds.Tables[1].Rows[0]["Parent_Contact_No"].ToString();
                        txtStudentEmailId.Text = ds.Tables[1].Rows[0]["Student_Email_Id"].ToString();
                        txtParentEmailId.Text = ds.Tables[1].Rows[0]["Parent_Email_Id"].ToString();
                        txtContactNo.Text = ds.Tables[1].Rows[0]["Student_Contact_No"].ToString();
                        txtDOB.Value = ds.Tables[1].Rows[0]["DBO"].ToString();
                        Txtcity.Text = ds.Tables[1].Rows[0]["City"].ToString();
                        txtParentEmailId.Text = ds.Tables[1].Rows[0]["Parent_Email_Id"].ToString();
                         Txtschoolname.Text = ds.Tables[1].Rows[0]["Schoolname"].ToString();
                         Txtpercentage.Text = ds.Tables[1].Rows[0]["Percentage"].ToString();
                       
                        if (ds.Tables[1].Rows[0]["Borad"].ToString() != "")
                        {
                            try
                            {
                                ddlBorad.SelectedValue = ds.Tables[1].Rows[0]["BoradID"].ToString();
                            }
                            catch
                            {
                                ddlBorad.SelectedIndex = 0;
                            }
                        }
                        try
                        {
                            ddlCurrentSSCCenter.SelectedValue = ds.Tables[1].Rows[0]["Preferred_Center_Code"].ToString();
                        }
                        catch
                        {
                            ddlCurrentSSCCenter.SelectedIndex = 0;
                        }
                          try
                         {
                             DDLStatus.SelectedValue = ds.Tables[1].Rows[0]["EnquirystatuID"].ToString();

                         }
                          catch
                          {
                              DDLStatus.SelectedIndex = 0;
                          }
                    }
                }
            }

            //ddlProductName.SelectedIndex = 0;
            //ddlDivision.SelectedIndex = 0;

            //lblDivHead.Text = "Result";
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
            return;
        }
    }
    protected void ddlPayType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            if (ddlPayType.SelectedValue.ToString() == "04") //Credit Card Debit Card
            {
                trCCDCAmount.Visible = true;
                trCCDCTransactionId.Visible = true;
                trChequeAmount.Visible = false;
                trMICRCode.Visible = false;
                trChequeNumber.Visible = false;
                trChequeDate.Visible = false;
            }
            else if (ddlPayType.SelectedValue.ToString() == "01")//Demanddraft/
            {
                trCCDCAmount.Visible = false;
                trCCDCTransactionId.Visible = false;
                trChequeAmount.Visible = true;
                trMICRCode.Visible = true;
                trChequeNumber.Visible = true;
                trChequeDate.Visible = true;
            }
            else if (ddlPayType.SelectedValue.ToString() == "05") //NEFT Card
            {
                trCCDCAmount.Visible = true;
                trCCDCTransactionId.Visible = true;
                trChequeAmount.Visible = false;
                trMICRCode.Visible = false;
                trChequeNumber.Visible = false;
                trChequeDate.Visible = false;
            }
            else if (ddlPayType.SelectedValue.ToString() == "02")//Cheque/
            {
                trCCDCAmount.Visible = false;
                trCCDCTransactionId.Visible = false;
                trChequeAmount.Visible = true;
                trMICRCode.Visible = true;
                trChequeNumber.Visible = true;
                trChequeDate.Visible = true;
            }
            else
            {
                trCCDCAmount.Visible = false;
                trCCDCTransactionId.Visible = false;
                trChequeAmount.Visible = false;
                trMICRCode.Visible = false;
                trChequeNumber.Visible = false;
                trChequeDate.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
            return;
        }
    }
    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    ddlacademicyear.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
        //}
    }
    protected void txtMICRCode_TextChanged(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
        string MicrCode = "";
        MicrCode = txtMICRCode.Text;
        SqlDataReader dr = AccountController.GetBanknameandAddress(MicrCode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                lblBankName.Text = dr["bankname"].ToString();
                //lblBankName.Text = dr["bankbranch"].ToString();
            }
            else
            {
                lblBankName.Text = "";
            }
        }
        else
        {
            lblBankName.Text = "";
        }
    }

    protected void DDLStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLStatus.SelectedValue == "1")
        {
            trREMAKRS.Visible = false;
            trFOLLOEUP.Visible = false;
            trHOSTEL.Visible = true;
            trPAYMODE.Visible = true;
            trPAYTYPE.Visible = true;

        }
        if (DDLStatus.SelectedValue == "2")
        {
            trREMAKRS.Visible = true;
            trFOLLOEUP.Visible = true;
            trHOSTEL.Visible = false;
            trPAYMODE.Visible = false;
            trPAYTYPE.Visible = false;

        }
        if (DDLStatus.SelectedValue == "3")
        {
            trREMAKRS.Visible = true;
            trFOLLOEUP.Visible = true;
            trHOSTEL.Visible = false;
            trPAYMODE.Visible = false;
            trPAYTYPE.Visible = false;

        }
        if (DDLStatus.SelectedValue == "0")
        {
            trREMAKRS.Visible = false;
            trFOLLOEUP.Visible = false;
            trHOSTEL.Visible = false;
            trPAYMODE.Visible = false;
            trPAYTYPE.Visible = false;

        }
    }

    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        //FillDDL_PrefScCenter();
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            if (txtFName.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter FirstName");
                txtFName.Focus();
                return;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Student Contact Number");
                txtContactNo.Focus();
                return;
            }
            if (txtStudentEmailId.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Student Email ID");
                txtStudentEmailId.Focus();
                return;
            }
            if (txtParentName.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Parent Name");
                txtParentName.Focus();
                return;
            }

            if (txtParentContact.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Parent Contact Number");
                txtParentContact.Focus();
                return;
            }

            if (ddlCurrentSSCCenter.SelectedValue == "Select")
            {
                Show_Error_Success_Box("E", "Select  Center");
                return;
            }
            //if (ddlDivision.SelectedValue == "Select")
            //{
            //    Show_Error_Success_Box("E", "Select Division");
            //    return;
            //}
            //if (ddlPrefferedScCenter.SelectedValue == "Select")
            //{
            //    Show_Error_Success_Box("E", "Select Preffered Center");
            //    return;
            //}

            if (ddlProductName.SelectedValue == "Select")
            {
                Show_Error_Success_Box("E", "Select Interested Product");
                return;
            }
            if (DDLStatus.SelectedValue == "0")
            {
                Show_Error_Success_Box("E", "Select Enquiry status");
                return;
            }
            if (DDLStatus.SelectedValue == "1")
            {

                if (ddlPayMode.SelectedValue.ToString() == "0")
                {
                    Show_Error_Success_Box("E", "Select Pay Mode");
                    return;
                }
                if (ddlPayType.SelectedValue.ToString() == "0")
                {
                    Show_Error_Success_Box("E", "Select Pay Type");
                    return;
                }
                if (ddlPayType.SelectedValue.ToString() == "04")//Credit Or Debit Card
                {
                    if (txtCCDCAmount.Text.Trim() == "")
                    {
                        Show_Error_Success_Box("E", "Enter Amount");
                        txtCCDCAmount.Focus();
                        return;
                    }
                    if (txtCCDCTransctionId.Text.Trim() == "")
                    {
                        Show_Error_Success_Box("E", "Enter Transaction Id");
                        txtCCDCTransctionId.Focus();
                        return;
                    }
                }
                else if (ddlPayType.SelectedValue.ToString() == "01")//Cheque
                {
                    if (txtChequeDate.Value == "")
                    {
                        Show_Error_Success_Box("E", "Enter Cheque Date");
                        txtChequeDate.Focus();
                        return;
                    }
                    if (txtChequeAmount.Text.Trim() == "")
                    {
                        Show_Error_Success_Box("E", "Enter Amount");
                        txtChequeAmount.Focus();
                        return;
                    }
                    if (txtMICRCode.Text.Trim() == "")
                    {
                        Show_Error_Success_Box("E", "Enter MICR Code");
                        txtMICRCode.Focus();
                        return;
                    }
                    if (lblBankName.Text == "")
                    {
                        Show_Error_Success_Box("E", "Enter Correct MICR Code");
                        txtMICRCode.Focus();
                        return;
                    }


                    if (txtChequeNo.Text.Trim() == "")
                    {
                        Show_Error_Success_Box("E", "Enter Cheque Number");
                        txtChequeNo.Focus();
                        return;
                    }
                    if (txtChequeNo.Text.Length != 6)
                    {
                        Show_Error_Success_Box("E", "Enter 6 Digit Cheque Number");
                        txtChequeNo.Focus();
                        return;
                    }

                }
            }

            else if (DDLStatus.SelectedValue == "2")
            {
                if (Txtremarks.Text == "") 
                {
                    Show_Error_Success_Box("E", "Enter Remarks");
                    return;
                }

                if (Txtfllowup.Value == null)
                {
                    Show_Error_Success_Box("E", "Enter Fallowup Date");
                    return;
                }

            }
            else if (DDLStatus.SelectedValue == "3")
            {
                if (Txtremarks.Text == "")
                {
                    Show_Error_Success_Box("E", "Enter Remarks");
                    return;
                }

                if (Txtfllowup.Value == null)
                {
                    Show_Error_Success_Box("E", "Enter Fallowup Date");
                    return;
                }

            }

            string Cheque_No = "", MICR_Code = "", Amount = "", Cheque_Date = "";
            if (ddlPayType.SelectedValue.ToString() == "04")//Credit Or Debit Card
            {
                Cheque_No = txtCCDCTransctionId.Text.Trim();
                Amount = txtCCDCAmount.Text.Trim();

            }
            else if (ddlPayType.SelectedValue.ToString() == "01")//Cheque
            {
                Cheque_No = txtChequeNo.Text.Trim();
                MICR_Code = txtMICRCode.Text.Trim();
                Amount = txtChequeAmount.Text.Trim();
                Cheque_Date = txtChequeDate.Value;
            }

            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            List<string> List2 = new List<string>();

            string Productname = "";
            foreach (ListItem li in ddlProductName.Items)
            {
                if (li.Selected == true)
                {
                    list.Add(li.Value);
                    Productname = string.Join(",", list.ToArray());
                }
            }
            string Productnames = Productname;

            string Productcode = "";
            foreach (ListItem li in ddlProductName.Items)
            {
                if (li.Selected == true)
                {
                    List1.Add(li.Value);
                    Productcode = string.Join(",", List1.ToArray());
                }
            }
            string Productcode1 = Productcode;


            int ResultId = 0;
            int resultid = 0;
            string count = "";
            ResultId = ProductController.InsertUpdateregistration_Center(txtFName.Text.Trim(), txtMName.Text.Trim(), txtLName.Text.Trim(), txtContactNo.Text.Trim(), txtStudentEmailId.Text.Trim(), txtAddress.Text.Trim(), txtParentName.Text.Trim(), txtParentContact.Text.Trim(), txtParentEmailId.Text.Trim(), ddlacademicyear.Text.Trim(), "2",
                Productnames, ddlCurrentSSCCenter.SelectedValue, ddlCurrentSSCCenter.SelectedItem.ToString(), ddlPayMode.SelectedItem.ToString(), Cheque_No, MICR_Code, Amount, ddlPayType.SelectedValue.ToString(), Cheque_Date, txtDOB.Value, Txtcity.Text,
                Txtschoolname.Text, ddlBorad.SelectedItem.ToString(), Txtpercentage.Text, DDLStatus.SelectedItem.ToString(), Txtremarks.Text, Txtfllowup.Value, DDlHostel.SelectedItem.ToString(), Productcode1, ddlBorad.SelectedValue.ToString(), DDLStatus.SelectedValue.ToString());
            if (ResultId == 1)
            {
                   

                Show_Error_Success_Box("S", "Student Details are Saved Successfully....!");
                tblSearchInfo.Visible = false;
                tblSearchDetail.Visible = true;
                BtnSave.Visible = false;
                BtnClose.Visible = false;
                txtSearchUID.Text = "";
                return;
            }
            else
            {
                Show_Error_Success_Box("E", "Admission Not Saved.....!");
            }


        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
            return;
        }
    }

    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        tblSearchInfo.Visible = false;
        tblSearchDetail.Visible = true;
        BtnSave.Visible = false;
        BtnClose.Visible = false;
        txtSearchUID.Text = "";
    }

    protected void ddlPrefferedScCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        //FillDDL_Product();
    }
    #endregion

    #region Methods
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

    //private void BindOptionalSubject(string StreamName, string Center)
    //{
    //    DataSet ds = ProductController.GetSubjectsbyStreamCode(5, StreamName, Center);
    //    if (ds.Tables[0] != null)
    //    {
    //        dlselective.DataSource = ds;
    //        dlselective.DataBind();
    //    }

    //}


    //private void FillDDL_CouncilBy()
    //{

    //    try
    //    {
    //        Clear_Error_Success_Box();
    //        // string UserID = txtUserId.Text.Trim();
    //        DataSet dsCouncilBy = ProductController.GetCouncil_Seminar();
    //        BindDDL(ddlCouncilBy, dsCouncilBy, "Council_Name", "Council_Id");
    //        ddlCouncilBy.Items.Insert(0, "Select");
    //        ddlCouncilBy.SelectedIndex = 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }
    //}

    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "ZERO";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 10000000) + " CRORE ";
            number %= 10000000;
        }
        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKH ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "AND ";
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }

    //private void FillDDL_Product()
    //{
    //    try
    //    {
    //        ddlProductName.Items.Clear();
    //        DataSet dsProduct = ProductController.GetStreamby_Center_Seminar(ddlPrefferedScCenter.SelectedValue);
    //        BindDDL(ddlProductName, dsProduct, "Stream_SDesc", "Stream_Code");
    //        ddlProductName.Items.Insert(0, "Select");
    //        ddlProductName.SelectedIndex = 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }
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



    //private void FillDDL_Division()
    //{

    //    try
    //    {
    //        Clear_Error_Success_Box();
    //        // string UserID = txtUserId.Text.Trim();
    //        DataSet dsDivision = ProductController.GetDivision_Seminar();
    //        BindDDL(ddlDivision, dsDivision, "Source_Division_ShortDesc", "Source_Division_Code");
    //        ddlDivision.Items.Insert(0, "Select");
    //        ddlDivision.SelectedIndex = 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }
    //}


    private void FillDDL_CurrentSScCenter()
    {

        try
        {
            Clear_Error_Success_Box();
            DataSet dsCenter = ProductController.GetCenter_Seminar("", "3");
            BindDDL(ddlCurrentSSCCenter, dsCenter, "Source_Center_Name", "Source_Center_Code");
            ddlCurrentSSCCenter.Items.Insert(0, "Select");
            ddlCurrentSSCCenter.SelectedIndex = 0;
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

    //private void FillDDL_PrefScCenter()
    //{

    //    try
    //    {
    //        Clear_Error_Success_Box();
    //        DataSet dsCenter = ProductController.GetCenter_Seminar(ddlDivision.SelectedValue, "2");
    //        BindDDL(ddlPrefferedScCenter, dsCenter, "Source_Center_Name", "Source_Center_Code");
    //        ddlPrefferedScCenter.Items.Insert(0, "Select");
    //        ddlPrefferedScCenter.SelectedIndex = 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }
    //}


    #endregion

}