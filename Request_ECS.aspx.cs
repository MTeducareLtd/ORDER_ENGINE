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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class Request_ECS : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string SBECode = null, Oppid = null;
                SBECode = Request.QueryString["Cur_Sb_Code"];
                Oppid = Request.QueryString["Oppid"];
                Bindlist(SBECode);
                ddlFrequency.SelectedValue = "Mthly";
                ddlDebitType.SelectedValue = "Fixed Amount";
                //ECS_Print(SBECode);
                //ECS_BlankPrint("");
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = ex.ToString();
            }
        }
    }

    #region Events
    protected void txtMICRNo_TextChanged(object sender, System.EventArgs e)
    {
        string MicrCode = "";
        MicrCode = txtMICRNo.Text;
        SqlDataReader dr = AccountController.GetBanknameandAddress(MicrCode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtWithBank.Text = dr["bankname"].ToString();
            }
        }
    }

    protected void ddlAcountHolderType_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlAcountHolderType.SelectedValue == "Joint")
        {
            tdAcHld2.Visible = true;
            tdAcHld2A.Visible = true;
        }
        else
        {
            txtAcountHolderName2.Text = "";
            tdAcHld2.Visible = false;
            tdAcHld2A.Visible = false;
        }
    }

    public string Message = "";

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txtUMRN.Text == "")
        //{
        //    Show_Error_Success_Box("E","Enter UMRN");
        //    return;
        //}
        if (ddlToDebit.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select To Debit");
            return;
        }
        
        if (txtPeriod.Value == "")
        {
            Show_Error_Success_Box("E", "Select Period");
            return;
        }


        string PeriodFrom = "", PeriodTo = "",FDate="",TDate="";
        string DateRange = txtPeriod.Value;
        PeriodFrom = DateRange.Substring(0, 10);
        PeriodTo = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
        FDate = DateRange.Substring(3, 2);
        TDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 7, 2) : DateRange;
        
        if (FDate != TDate)
        {
            Show_Error_Success_Box("E", "Date part of the date should be same");
            return;
        }

        if (Convert.ToInt32(FDate) >= 28)
        {
            Show_Error_Success_Box("E", "Date cannot be greater than 28");
            return;
        }

        if (txtBankAcNo.Text == "")
        {
            Show_Error_Success_Box("E", "Enter Bank Account Number");
            return;
        }

        if (txtAcountHolderName1.Text.Trim() == "")
        {
            Show_Error_Success_Box("E", "Enter Bank Account Holder Name1");
            return;
        }

        if ((ddlAcountHolderType.SelectedValue == "Joint") && (txtAcountHolderName2.Text.Trim() == ""))
        {            
                Show_Error_Success_Box("E", "Enter Bank Account Holder Name2");
                return;           
        }
        
        if (txtMICRNo.Text == "")
        {
            Show_Error_Success_Box("E", "Enter MICR Number");
            return;
        }
        
        if (txtWithBank.Text == "")
        {
            Show_Error_Success_Box("E", "Enter Valid MICR Number");
            return;
        }
        if (txtIFSCCode.Text == "")
        {
            Show_Error_Success_Box("E", "Enter IFSC Code");
            return;
        }
        
        if (txtAmount.Text == "")
        {
            Show_Error_Success_Box("E", "Enter Amount");
            return;
        }
        


        if (ddlFrequency.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Frequency");
            return;
        }
        
        if (ddlDebitType.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Enter Debit type");
            return;
        }

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        int flag = 1;
        if (lblECSID.Text != "")//At the update time
        {
            flag = 2;
        }

        DataSet ds = ProductController.Save_ECS_Detail("", txtUMRN.Text.Trim(), lblECSDate.Text, lblSponsorBankCode.Text, lblUtilityCode.Text, lblCompanyName.Text, ddlToDebit.SelectedValue, txtBankAcNo.Text.Trim(),
                        txtWithBank.Text.Trim(), txtIFSCCode.Text.Trim(), txtMICRNo.Text.Trim(), txtAmount.Text.Trim(), ddlFrequency.SelectedValue, ddlDebitType.SelectedValue, txtReference1.Text.Trim(), txtPhoneno.Text.Trim(), txtReference2.Text.Trim(), txtEmailID.Text.Trim(),
                        PeriodFrom, PeriodTo, txtcursbcode.Text.Trim(), txtSPID.Text, UserID, flag , ddlAcountHolderType.SelectedValue, txtAcountHolderName1.Text.Trim(), txtAcountHolderName2.Text.Trim());
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ErrorSaveId"].ToString() == "1")//if record is saved
                {                   
                    ECS_Print(txtcursbcode.Text.Trim());
                    Show_Error_Success_Box("s", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
                    //Print PDF Code
                    btnSave.Visible = false;
                    return;
                }
                else if (ds.Tables[0].Rows[0]["ErrorSaveId"].ToString() == "-1")//if error is come
                {
                    Show_Error_Success_Box("E", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
                    return;
                }
            }
        }
    }

    #endregion

    #region Function

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


    private void Bindlist(string Cursbcode)
    {
        string Hiphen = "-";
        SqlDataReader dr = AccountController.GetAccountdetailbycursbcode(1, Cursbcode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                string Gender = dr["GENDER"].ToString();
                if (Gender == "M")
                {
                    txtgender.Text = "Male";
                }
                else
                {
                    txtgender.Text = "Female";
                }

                txtSPID.Text = dr["SPID"].ToString();
                txtLstudentname.Text = dr["NAME"].ToString();
                lblstudentname.Text = Hiphen + " " + dr["NAME"].ToString();
                imgstudentphoto.ImageUrl = dr["stud_image"].ToString();
                txtLappno.Text = dr["Student_App_No"].ToString();
                txtopportunityid.Text = dr["oppor_id"].ToString();
                txtaccountid.Text = dr["account_id"].ToString();
                txtcursbcode.Text = dr["sbentrycode"].ToString();
                txtReference1.Text = txtcursbcode.Text;
                txtReference2.Text = dr["NAME"].ToString();
                BindLedgerCompany();
                ddllcompany.SelectedValue = dr["companycode"].ToString();
                BindLedgerDivision();
                ddlldivision.SelectedValue = dr["divisioncode"].ToString();
                BindLedgerCenter();
                ddllcenter.SelectedValue = dr["center_code"].ToString();
                BindLedgerAcademicYear();
                ddllacadyear.SelectedValue = dr["acad_year"].ToString();
                BindLedgerStream();
                ddllstream.SelectedValue = dr["stream_code"].ToString();
                BindStudentSubjectGroup(Cursbcode);
                //BindPayplan();
                txtpayplan.Text = dr["payplan"].ToString();
                txtadmndate.Text = dr["Admndate"].ToString();
                string Studentstatus = "";
                Studentstatus = dr["Account_Status_id"].ToString();

                if (Studentstatus == "01")//Pending
                {
                    spanPending.Visible = true;
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string UserID = cookie.Values["UserID"];
                    string UserName = cookie.Values["UserName"];
                    DataSet ds = ProductController.Get_ECS_Detail(Cursbcode, UserID, "1");

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if ((ds.Tables[0].Rows[0]["DupliFlag"].ToString() == "0") && (Convert.ToInt32(ds.Tables[0].Rows[0]["TotalReceipt"].ToString()) > 0))
                            {                              
                                tblEcsDetail.Visible = true;
                                lblECSDate.Text = ds.Tables[0].Rows[0]["ECSDate"].ToString();
                                lblSponsorBankCode.Text = ds.Tables[0].Rows[0]["SponsorBankCode"].ToString();
                                lblUtilityCode.Text = ds.Tables[0].Rows[0]["UtilityCode"].ToString();
                                lblCompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                                txtPhoneno.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                                txtEmailID.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                            }
                            else
                            {
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    tblEcsDetail.Visible = true;
                                    lblEcsHeader.Text = "Update ECS Detail";
                                    lblECSID.Text = ds.Tables[1].Rows[0]["ECS_ID"].ToString();
                                    txtUMRN.Text = ds.Tables[1].Rows[0]["UMR_NO"].ToString();
                                    lblECSDate.Text = ds.Tables[1].Rows[0]["ECS_DATE"].ToString();
                                    lblSponsorBankCode.Text = ds.Tables[1].Rows[0]["SponsorBankCode"].ToString();
                                    lblUtilityCode.Text = ds.Tables[1].Rows[0]["UtilityCode"].ToString();
                                    lblCompanyName.Text = ds.Tables[1].Rows[0]["Company_Name"].ToString();
                                    ddlToDebit.SelectedValue = ds.Tables[1].Rows[0]["ToDebit"].ToString();
                                    txtPeriod.Value = ds.Tables[1].Rows[0]["ECS_Period"].ToString();
                                    txtBankAcNo.Text = ds.Tables[1].Rows[0]["BankAcNo"].ToString();
                                    ddlAcountHolderType.SelectedValue = ds.Tables[1].Rows[0]["Account_HolderType"].ToString();
                                    if (ddlAcountHolderType.SelectedValue == "Joint")
                                    {
                                        tdAcHld2.Visible = true;
                                        tdAcHld2A.Visible = true;
                                    }
                                    else
                                    {
                                        txtAcountHolderName2.Text = "";
                                        tdAcHld2.Visible = false;
                                        tdAcHld2A.Visible = false;
                                    }
                                    txtAcountHolderName1.Text = ds.Tables[1].Rows[0]["Account_Holder1"].ToString();
                                    txtAcountHolderName2.Text = ds.Tables[1].Rows[0]["Account_Holder2"].ToString();
                                    txtMICRNo.Text = ds.Tables[1].Rows[0]["MICR_Code"].ToString();
                                    txtWithBank.Text = ds.Tables[1].Rows[0]["WithBank"].ToString();
                                    txtIFSCCode.Text = ds.Tables[1].Rows[0]["IFSC_Code"].ToString();
                                    txtAmount.Text = ds.Tables[1].Rows[0]["Amount"].ToString();
                                    ddlFrequency.SelectedValue = ds.Tables[1].Rows[0]["Frequency"].ToString();
                                    ddlDebitType.SelectedValue = ds.Tables[1].Rows[0]["Debit_Type"].ToString();
                                    txtReference1.Text = ds.Tables[1].Rows[0]["Ref1"].ToString();
                                    txtPhoneno.Text = ds.Tables[1].Rows[0]["Phone"].ToString();
                                    txtReference2.Text = ds.Tables[1].Rows[0]["Ref2"].ToString();
                                    txtEmailID.Text = ds.Tables[1].Rows[0]["EmailId"].ToString();
                                }
                                else
                                {
                                    tblEcsDetail.Visible = false;
                                    btnSave.Visible = false;
                                    DivEcsError.Visible = true;
                                    lblEcsError.Text = "ECS already created or First payment not paid hence ECS not displayed";
                                }
                            }
                        }
                    }
                   


                }
                else if (Studentstatus == "03")//Confirm
                {
                    spanConfirm.Visible = true;
                    tblEcsDetail.Visible = false;
                    btnSave.Visible = false;
                    DivEcsError.Visible = true;
                    lblEcsError.Text = "Admission is Confirmed hence Ecs not displayed";
                }
                else if (Studentstatus == "02")//Cancel
                {
                    spanCancel.Visible = true;
                    tblEcsDetail.Visible = false;
                    btnSave.Visible = false;
                    DivEcsError.Visible = true;
                    lblEcsError.Text = "Admission is Canceled hence Ecs not displayed";
                }

            }
        }
    }

    private void ECS_Print(string Cursbcode)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.Get_ECS_Detail(Cursbcode, UserID, "2");

        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count == 0)//if the ECS Detail not found
            {
                return;
            }
        }
        else
        {
            return;
        }


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

        float YPos = 0,XPos=0;
       
        
        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
       
        PdfContentByte cb = writer.DirectContent;

        string UMRNo = ds.Tables[0].Rows[0]["UMR_NO"].ToString(), EcsDate = ds.Tables[0].Rows[0]["ECSDate"].ToString(), SponsorBankCode = ds.Tables[0].Rows[0]["SponsorBankCode"].ToString();
        string UtilityCode = ds.Tables[0].Rows[0]["UtilityCode"].ToString(), Company = ds.Tables[0].Rows[0]["Company_Name"].ToString(), ToDebit = ds.Tables[0].Rows[0]["ToDebit"].ToString();
        string BankAcNo = ds.Tables[0].Rows[0]["BankAcNo"].ToString(), BankName = ds.Tables[0].Rows[0]["WithBank"].ToString(), IFSC = ds.Tables[0].Rows[0]["IFSC_Code"].ToString(), MICR = ds.Tables[0].Rows[0]["MICR_Code"].ToString();
        string Amount = ds.Tables[0].Rows[0]["Amount"].ToString(), AmountInWords = ds.Tables[0].Rows[0]["AmountinWords"].ToString(), Frequency = ds.Tables[0].Rows[0]["Frequency"].ToString();
        string DebitType = ds.Tables[0].Rows[0]["Debit_Type"].ToString(), Ref1 = ds.Tables[0].Rows[0]["Ref1"].ToString(), Phone = ds.Tables[0].Rows[0]["Phone"].ToString(), Ref2 = ds.Tables[0].Rows[0]["Ref2"].ToString();
        string EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString(), PeridFrom = ds.Tables[0].Rows[0]["PeriodFromDate"].ToString(), PeridTo = ds.Tables[0].Rows[0]["PeriodToDate"].ToString();
        string Account_Holder1 = ds.Tables[0].Rows[0]["Account_Holder1"].ToString(), Account_Holder2 = ds.Tables[0].Rows[0]["Account_Holder2"].ToString();
        for (int j = 0; j < 3; j++)
        {
            YPos = 500;

            cb.MoveTo(50, YPos - 5);
            cb.LineTo(790, YPos - 5);
            cb.Stroke();

            cb.MoveTo(50, YPos - 380);
            cb.LineTo(790, YPos - 380);
            cb.Stroke();

            cb.MoveTo(50, YPos - 5);
            cb.LineTo(50, YPos - 380);
            cb.Stroke();

            cb.MoveTo(790, YPos - 5);
            cb.LineTo(790, YPos - 380);
            cb.Stroke();

            YPos = YPos - 60;
            dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Kotak_Bank.jpg"));
            logo.SetAbsolutePosition(65, YPos);
            logo.ScalePercent(40);
            document.Add(logo);
            YPos = YPos + 25;

            cb.BeginText();
            cb.SetTextMatrix(230, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("UMRN");
            cb.EndText();

           
            XPos = 270;
            for (int i = 0; i <= 20; i++)
            {
                cb.MoveTo(XPos, YPos + 10);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();
                
                if (UMRNo.Length >= i+1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(XPos + 5, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(UMRNo[i].ToString());
                    cb.EndText();
                }

                XPos = XPos + 15;
            }

            cb.MoveTo(270, YPos + 10);
            cb.LineTo(XPos - 15, YPos + 10);
            cb.Stroke();

            cb.MoveTo(270, YPos - 3);
            cb.LineTo(XPos - 15, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Date");
            cb.EndText();
            int d = 0;

            XPos = XPos + 29;
            float XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 10);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();

                if (i < 2)
                {
                    if (EcsDate.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(EcsDate[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }
                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 10);
            cb.LineTo(XPos - 17, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 3);
            cb.LineTo(XPos - 17, YPos - 3);
            cb.Stroke();

           

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 10);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();
                if (i < 2)
                {
                    if (EcsDate.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(EcsDate[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }
                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 10);
            cb.LineTo(XPos - 17, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 3);
            cb.LineTo(XPos - 17, YPos - 3);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 4; i++)
            {
                cb.MoveTo(XPos, YPos + 10);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();
                if (i < 4)
                {
                    if (EcsDate.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(EcsDate[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }
                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 10);
            cb.LineTo(XPos - 17, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 3);
            cb.LineTo(XPos - 17, YPos - 3);
            cb.Stroke();

            ////Extra Line
            //cb.MoveTo(XPos - 17, YPos + 10);
            //cb.LineTo(XPos - 17, YPos - 400);
            //cb.Stroke();
            ////End Extra Line

            YPos = YPos - 25;

            cb.BeginText();
            cb.SetTextMatrix(75, YPos - 3);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Tick (");

            dynamic logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));
            logo1.SetAbsolutePosition(100, YPos - 5);
            logo1.ScalePercent(5);
            document.Add(logo1);

            cb.SetTextMatrix(114, YPos - 3);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(")");

            cb.EndText();
            float StartYPos = YPos;
           
            cb.MoveTo(75, StartYPos -10);
            cb.LineTo(75, StartYPos - 55);
            cb.Stroke();
           

            cb.MoveTo(135, StartYPos - 10);
            cb.LineTo(135, StartYPos - 55);
            cb.Stroke();

            for (int i = 0; i < 4; i++)
            {
                cb.MoveTo(75, StartYPos - 10);
                cb.LineTo(135, StartYPos - 10);
                cb.Stroke();
                StartYPos = StartYPos - 15;
                if (i == 0)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(80, StartYPos - 5);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("CREATE");
                    cb.EndText();

                    logo1.SetAbsolutePosition(75, StartYPos - 8);
                    logo1.ScalePercent(6);
                    document.Add(logo1);
                }
                else if (i == 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(85, StartYPos - 5);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("MODIFY");
                    cb.EndText();
                }
                else if (i == 2)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(85, StartYPos - 5);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("CANCEL");
                    cb.EndText();
                }
            }
            
            cb.BeginText();
            cb.SetTextMatrix(210, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Sponsor Bank Code");
            cb.EndText();

            XPos = 305;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 160, YPos + 12);
            cb.LineTo(XPos + 160, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 160, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 160, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 160) - XPos) / 2) - (cb.GetEffectiveStringWidth(SponsorBankCode, false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(SponsorBankCode);
            cb.EndText();

            XPos = XPos + 170;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Utility Code");
            cb.EndText();

            XPos = XPos + 60;

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 221) - XPos) / 2) - (cb.GetEffectiveStringWidth(UtilityCode, false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(UtilityCode);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 221, YPos + 12);
            cb.LineTo(XPos + 221, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 221, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 221, YPos - 3);
            cb.Stroke();

            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(165, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("I/We hereby authorize ");
            cb.EndText();

            XPos = 275;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 200, YPos + 12);
            cb.LineTo(XPos + 200, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 200, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 200, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 250) - XPos) / 2) - (cb.GetEffectiveStringWidth(Company, false) / 2)), YPos);
            cb.SetFontAndSize(bf, 7);
            cb.ShowText(Company);
            cb.EndText();
            
            XPos=XPos + 210;

            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("to debit (tick");
            cb.EndText();

            logo1.SetAbsolutePosition(XPos+55, YPos);
            logo1.ScalePercent(4);
            document.Add(logo1);

            cb.BeginText();
            cb.SetTextMatrix(XPos+63, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(")");
            cb.EndText();

            XPos = XPos + 70;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 201, YPos + 12);
            cb.LineTo(XPos + 201, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 201, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 201, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 201) - XPos) / 2) - (cb.GetEffectiveStringWidth("SB/CA/CC/SB-NRE/SB-NRO/Other", false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("SB/CA/CC/SB-NRE/SB-NRO/Other");
            cb.EndText();
            if (ToDebit == "SB")
            {
                logo1.SetAbsolutePosition(XPos + 20, YPos);//SB
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "CA")
            {
                logo1.SetAbsolutePosition(XPos + 40, YPos);//CA
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "CC")
            {
                logo1.SetAbsolutePosition(XPos + 60, YPos);//CC
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "SB-NRE")
            {
                logo1.SetAbsolutePosition(XPos + 85, YPos);//SB-NRE
                logo1.ScalePercent(6);
                document.Add(logo1);
            }            
            else if (ToDebit == "SB-NRO")
            {
                logo1.SetAbsolutePosition(XPos + 120, YPos);//SB-NRO
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "Other")
            {
                logo1.SetAbsolutePosition(XPos + 160, YPos);//Other
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(185, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Bank a/c number");
            cb.EndText();

            XPos = 275;

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 480, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 480, YPos - 3);
            cb.Stroke();
            for (int i = 0; i < 31; i++)
            {
                cb.MoveTo(XPos, YPos + 12);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();
                if (BankAcNo.Length >= i + 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(XPos + 5, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(BankAcNo[i].ToString());
                    cb.EndText();
                }
                
                XPos = XPos + 16;
            }


            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("with Bank");
            cb.EndText();

            XPos = 125;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 232, YPos + 12);
            cb.LineTo(XPos + 232, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 232, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 232, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 232) - XPos) / 2) - (cb.GetEffectiveStringWidth(BankName, false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(BankName);
            cb.EndText();

            XPos = XPos + 237;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("IFSC");
            cb.EndText();

            XPos = XPos + 28;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 176, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 176, YPos - 3);
            cb.Stroke();
            for (int i = 0; i < 12; i++)
            {
                cb.MoveTo(XPos, YPos + 12);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();

                if (IFSC.Length >= i + 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(XPos + 5, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(IFSC[i].ToString());
                    cb.EndText();
                }

                XPos = XPos + 16;
            }

            XPos = XPos -10;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("or MICR");
            cb.EndText();

            XPos = XPos + 40;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 144, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 144, YPos - 3);
            cb.Stroke();
            for (int i = 0; i < 10; i++)
            {
                cb.MoveTo(XPos, YPos + 12);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();

                if (MICR.Length >= i + 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(XPos + 5, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(MICR[i].ToString());
                    cb.EndText();
                }

                XPos = XPos + 16;
            }


            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("an amount of Rupees");
            cb.EndText();

            XPos = 175;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 3, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(AmountInWords);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 435, YPos + 12);
            cb.LineTo(XPos + 435, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 435, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 435, YPos - 3);
            cb.Stroke();

            XPos =XPos + 438;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 143, YPos + 12);
            cb.LineTo(XPos + 143, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 143, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 143, YPos - 3);
            cb.Stroke();

            dynamic logo2 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Indian_Rupees_Icon.jpg"));
            logo2.SetAbsolutePosition(XPos, YPos - 1);
            logo2.ScalePercent(3);
            document.Add(logo2);

            cb.BeginText();
            cb.SetTextMatrix(XPos+13, YPos + 2);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Amount);
            cb.EndText();


            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("FREQUENCY");
            cb.EndText();

            


            XPos = 150;
            
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "Mthly")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Mthly
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos=XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Mthly");
            cb.EndText();

            XPos = XPos + 35;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "Qtly")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Qtly
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Qtly");
            cb.EndText();


            XPos = XPos + 30;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "H-Yrly")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//H-Yrly
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("H-Yrly");
            cb.EndText();

            XPos = XPos + 38;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "Yrly")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Yrly
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Yrly");
            cb.EndText();

            XPos = XPos + 30;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "As & when presented")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//As & when presented
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("As & when presented");
            cb.EndText();

            XPos = XPos + 150;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
           // cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
            cb.ShowText("DEBIT TYPE");
           // cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
            //cb.SetTextRenderingMode(PdfContentByte);
            cb.EndText();

            XPos = XPos + 70;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (DebitType == "Fixed Amount")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Fixed Amount
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Fixed Amount");
            cb.EndText();

            XPos = XPos + 80;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (DebitType == "Maximum Amount")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Maximum Amount
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }


            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Maximum Amount");
            cb.EndText();

            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Reference 1");
            cb.EndText();

            XPos = 140;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 5, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Ref1);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 350, YPos + 10);
            cb.LineTo(XPos + 350, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 350, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 350, YPos - 3);
            cb.Stroke();

            XPos = XPos + 355;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Phone No.");
            cb.EndText();

            XPos = XPos + 50;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 5, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Phone);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 211, YPos + 10);
            cb.LineTo(XPos + 211, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 211, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 211, YPos - 3);
            cb.Stroke();

            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Reference 2");
            cb.EndText();

            XPos = 140;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 5, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Ref2);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 350, YPos + 10);
            cb.LineTo(XPos + 350, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 350, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 350, YPos - 3);
            cb.Stroke();

            XPos = XPos + 355;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Email ID");
            cb.EndText();

            XPos = XPos + 50;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 5, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(EmailId);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 211, YPos + 10);
            cb.LineTo(XPos + 211, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 211, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 211, YPos - 3);
            cb.Stroke();

            YPos = YPos - 15;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 7);
            cb.ShowText("I agree for the debit of mandate processing charges by the bank whom I am authorizing to debit my account as per latest schedule of charges of the bank.");
            cb.EndText();

            YPos = YPos - 25;
            XPos = 75;

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 45);
            cb.Stroke();

            cb.MoveTo(XPos + 180, YPos + 10);
            cb.LineTo(XPos + 180, YPos - 45);
            cb.Stroke();

            cb.MoveTo(XPos+45, YPos + 10);
            cb.LineTo(XPos + 180, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 45);
            cb.LineTo(XPos + 180, YPos - 45);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix(80, YPos + 6);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("PERIOD");

            cb.SetTextMatrix(80, YPos - 6);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("From");

            cb.EndText();
            d = 0;

            XPos = XPos + 35;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 5 );
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 2)
                {
                    if (PeridFrom.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos-6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridFrom[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }

                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 2)
                {
                    if (PeridFrom.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos-6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridFrom[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }

                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 4; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 4)
                {
                    if (PeridFrom.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridFrom[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }

                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            YPos = YPos - 15;
            XPos = 75;
            cb.BeginText();
            cb.SetTextMatrix(80, YPos - 5);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("To");
            cb.EndText();
            d = 0;

            XPos = XPos + 35;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();
                if (i < 2)
                {
                    if (PeridTo.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridTo[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }

                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 2)
                {
                    if (PeridTo.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridTo[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }


                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 4; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 4)
                {
                    if (PeridTo.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridTo[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }


                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            YPos = YPos - 18;
            XPos = 75;
            cb.BeginText();
            cb.SetTextMatrix(80, YPos - 5);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Or");
            cb.EndText();

            XPos = XPos + 40;
            cb.MoveTo(XPos, YPos + 5);
            cb.LineTo(XPos, YPos - 8);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 5);
            cb.LineTo(XPos + 10, YPos - 8);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 5);
            cb.LineTo(XPos + 10, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 8);
            cb.LineTo(XPos + 10, YPos - 8);
            cb.Stroke();

            XPos = XPos + 15;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos - 5);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Until Cancelled");
            cb.EndText();

            XPos = XPos + 150;

            dynamic logo211 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Account_Holder_Sign.jpg"));
            logo211.SetAbsolutePosition(XPos + 10, YPos + 15);
            logo211.ScalePercent(55);
            document.Add(logo211);

            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();

            XPos = XPos + 140+ 28;
            logo211 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Account_Holder_Sign.jpg"));
            logo211.SetAbsolutePosition(XPos + 10, YPos + 15);
            logo211.ScalePercent(55);
            document.Add(logo211);
            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();

            XPos = XPos + 140 + 27;
            logo211 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Account_Holder_Sign.jpg"));
            logo211.SetAbsolutePosition(XPos + 10, YPos + 15);
            logo211.ScalePercent(55);
            document.Add(logo211);
            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();

            
            YPos = YPos -20;
            XPos = 280;

            cb.BeginText();
            cb.SetTextMatrix(XPos-15, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("1.");

            cb.SetTextMatrix(XPos + 10, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Account_Holder1);
            cb.EndText();

            dynamic logo21 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Bank_Record.jpg"));
            logo21.SetAbsolutePosition(XPos + 10, YPos + 13);
            logo21.ScalePercent(70);
            document.Add(logo21);

            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();
            XPos = XPos + 140 + 28;

            cb.BeginText();
            cb.SetTextMatrix(XPos - 15, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("2.");

            cb.SetTextMatrix(XPos + 10, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Account_Holder2);
            cb.EndText();

            logo21 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Bank_Record.jpg"));
            logo21.SetAbsolutePosition(XPos + 10, YPos + 13);
            logo21.ScalePercent(70);
            document.Add(logo21);

            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();
            XPos = XPos + 140 + 27;

            cb.BeginText();
            cb.SetTextMatrix(XPos - 15, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("3.");
            cb.EndText();

            logo21 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Bank_Record.jpg"));
            logo21.SetAbsolutePosition(XPos + 10, YPos + 13);
            logo21.ScalePercent(70);
            document.Add(logo21);

            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();

            //YPos = YPos - 10;
            //XPos = 75;                     

            //cb.BeginText();
            //cb.SetTextMatrix(XPos, YPos - 5);
            //cb.SetFontAndSize(bf, 10);
            //cb.ShowText("SBEntrycode ");

            ////cb.SetTextMatrix(XPos + 70, YPos - 5);
            ////cb.SetFontAndSize(bf, 10);
            ////cb.ShowText( ds.Tables[0].Rows[0]["SBEntryCode"].ToString());


            //float a = XPos + 65;

            //cb.SetTextMatrix((a + (((a + 100) - a) / 2) - (cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["SBEntryCode"].ToString(), false) / 2)), YPos - 5);
            //cb.SetFontAndSize(bf, 10);
            //cb.ShowText(ds.Tables[0].Rows[0]["SBEntryCode"].ToString());

            //cb.EndText();

            //cb.MoveTo(XPos + 65, YPos + 7);
            //cb.LineTo(XPos + 165, YPos + 7);

            //cb.MoveTo(XPos + 65, YPos + 7);
            //cb.LineTo(XPos + 65, YPos - 9);

            //cb.MoveTo(XPos + 65, YPos - 9);
            //cb.LineTo(XPos + 165, YPos - 9);
            
            //cb.MoveTo(XPos + 165, YPos + 7 );
            //cb.LineTo(XPos + 165, YPos - 9);
            //cb.Stroke();

            //cb.BeginText();
            //cb.SetTextMatrix(XPos+ 280, YPos - 5);
            //cb.SetFontAndSize(bf, 10);
            //cb.ShowText("SPID ");

            ////cb.SetTextMatrix(XPos + 335, YPos - 5);
            ////cb.SetFontAndSize(bf, 10);
            ////cb.ShowText(ds.Tables[0].Rows[0]["SPID"].ToString());

            //a = XPos + 310;

            //cb.SetTextMatrix((a + (((a + 135) - a) / 2) - (cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["SPID"].ToString(), false) / 2)), YPos - 5);
            //cb.SetFontAndSize(bf, 10);
            //cb.ShowText(ds.Tables[0].Rows[0]["SPID"].ToString());

            //cb.EndText();

            //cb.MoveTo(XPos + 310, YPos + 7);
            //cb.LineTo(XPos + 445, YPos + 7);

            //cb.MoveTo(XPos + 310, YPos + 7);
            //cb.LineTo(XPos + 310, YPos - 9);

            //cb.MoveTo(XPos + 310, YPos - 9);
            //cb.LineTo(XPos + 445, YPos - 9);
            
            //cb.MoveTo(XPos + 445, YPos + 7 );
            //cb.LineTo(XPos + 445, YPos - 9);
            //cb.Stroke();


            //cb.BeginText();
            //cb.SetTextMatrix(XPos + 520, YPos - 5);
            //cb.SetFontAndSize(bf, 10);
            //cb.ShowText("ContactID ");

            ////cb.SetTextMatrix(XPos + 575, YPos - 5);
            ////cb.SetFontAndSize(bf, 10);
            ////cb.ShowText(ds.Tables[0].Rows[0]["ConId"].ToString());

            //a = XPos + 575;

            //cb.SetTextMatrix((a + (((a + 105) - a) / 2) - (cb.GetEffectiveStringWidth(ds.Tables[0].Rows[0]["ConId"].ToString(), false) / 2)), YPos - 5);
            //cb.SetFontAndSize(bf, 10);
            //cb.ShowText(ds.Tables[0].Rows[0]["ConId"].ToString());

            //cb.EndText();

            //cb.MoveTo(XPos + 575, YPos + 7);
            //cb.LineTo(XPos + 680, YPos + 7);

            //cb.MoveTo(XPos + 575, YPos + 7);
            //cb.LineTo(XPos + 575, YPos - 9);

            //cb.MoveTo(XPos + 575, YPos - 9);
            //cb.LineTo(XPos + 680, YPos - 9);

            //cb.MoveTo(XPos + 680, YPos + 7);
            //cb.LineTo(XPos + 680, YPos - 9);
            //cb.Stroke();


            YPos = YPos - 30;
            XPos = 75;

            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos + 15);
            cb.SetFontAndSize(bf, 15);
            cb.ShowText(".");
            cb.SetTextMatrix(XPos + 5, YPos + 13);
            cb.SetFontAndSize(bf, 7);
            cb.ShowText(" This is to confirm that the declaration has been carefully read, understood & made by me/us.I am authorizing the user entity / corporate to debit my account, based on the instructions as agreed and signed by me.");
            cb.EndText();

            YPos = YPos - 10;
            XPos = 75;

            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos + 15);
            cb.SetFontAndSize(bf, 15);
            cb.ShowText(".");
            cb.SetTextMatrix(XPos + 5, YPos + 13);
            cb.SetFontAndSize(bf, 7);
            cb.ShowText(" I have understood that I am authorized to cancel/amend this mandate by appropriately communicating the cancellation/amendment request to the User entity/corporate or the bank where I have authorized the debit.");
            cb.EndText();

            document.NewPage();
        }
        document.Close();
        string CurTimeFrame = null;
        CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=PrintECS{0}.pdf", CurTimeFrame));
        Response.BinaryWrite(output.ToArray());

    }

    private void ECS_BlankPrint(string Cursbcode)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.Get_ECS_Detail(Cursbcode, UserID, "4");

        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count == 0)//if the ECS Detail not found
            {
                return;
            }
        }
        else
        {
            return;
        }


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

        float YPos = 0, XPos = 0;


        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

        PdfContentByte cb = writer.DirectContent;

        string UMRNo = ds.Tables[0].Rows[0]["UMR_NO"].ToString(), EcsDate = ds.Tables[0].Rows[0]["ECSDate"].ToString(), SponsorBankCode = ds.Tables[0].Rows[0]["SponsorBankCode"].ToString();
        string UtilityCode = ds.Tables[0].Rows[0]["UtilityCode"].ToString(), Company = ds.Tables[0].Rows[0]["Company_Name"].ToString(), ToDebit = ds.Tables[0].Rows[0]["ToDebit"].ToString();
        string BankAcNo = ds.Tables[0].Rows[0]["BankAcNo"].ToString(), BankName = ds.Tables[0].Rows[0]["WithBank"].ToString(), IFSC = ds.Tables[0].Rows[0]["IFSC_Code"].ToString(), MICR = ds.Tables[0].Rows[0]["MICR_Code"].ToString();
        string Amount = ds.Tables[0].Rows[0]["Amount"].ToString(), AmountInWords = ds.Tables[0].Rows[0]["AmountinWords"].ToString(), Frequency = ds.Tables[0].Rows[0]["Frequency"].ToString();
        string DebitType = ds.Tables[0].Rows[0]["Debit_Type"].ToString(), Ref1 = ds.Tables[0].Rows[0]["Ref1"].ToString(), Phone = ds.Tables[0].Rows[0]["Phone"].ToString(), Ref2 = ds.Tables[0].Rows[0]["Ref2"].ToString();
        string EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString(), PeridFrom = ds.Tables[0].Rows[0]["PeriodFromDate"].ToString(), PeridTo = ds.Tables[0].Rows[0]["PeriodToDate"].ToString();
        string Account_Holder1 = ds.Tables[0].Rows[0]["Account_Holder1"].ToString(), Account_Holder2 = ds.Tables[0].Rows[0]["Account_Holder2"].ToString();
        for (int j = 0; j < 3; j++)
        {
            YPos = 500;

            cb.MoveTo(50, YPos - 5);
            cb.LineTo(790, YPos - 5);
            cb.Stroke();

            cb.MoveTo(50, YPos - 380);
            cb.LineTo(790, YPos - 380);
            cb.Stroke();

            cb.MoveTo(50, YPos - 5);
            cb.LineTo(50, YPos - 380);
            cb.Stroke();

            cb.MoveTo(790, YPos - 5);
            cb.LineTo(790, YPos - 380);
            cb.Stroke();

            YPos = YPos - 60;
            dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Kotak_Bank.jpg"));
            logo.SetAbsolutePosition(65, YPos);
            logo.ScalePercent(40);
            document.Add(logo);
            YPos = YPos + 25;

            cb.BeginText();
            cb.SetTextMatrix(230, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("UMRN");
            cb.EndText();


            XPos = 270;
            for (int i = 0; i <= 20; i++)
            {
                cb.MoveTo(XPos, YPos + 10);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();

                if (UMRNo.Length >= i + 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(XPos + 5, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(UMRNo[i].ToString());
                    cb.EndText();
                }

                XPos = XPos + 15;
            }

            cb.MoveTo(270, YPos + 10);
            cb.LineTo(XPos - 15, YPos + 10);
            cb.Stroke();

            cb.MoveTo(270, YPos - 3);
            cb.LineTo(XPos - 15, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Date");
            cb.EndText();
            int d = 0;

            XPos = XPos + 29;
            float XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 10);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();

                if (i < 2)
                {
                    if (EcsDate.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(EcsDate[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }
                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 10);
            cb.LineTo(XPos - 17, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 3);
            cb.LineTo(XPos - 17, YPos - 3);
            cb.Stroke();



            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 10);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();
                if (i < 2)
                {
                    if (EcsDate.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(EcsDate[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }
                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 10);
            cb.LineTo(XPos - 17, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 3);
            cb.LineTo(XPos - 17, YPos - 3);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 4; i++)
            {
                cb.MoveTo(XPos, YPos + 10);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();
                if (i < 4)
                {
                    if (EcsDate.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(EcsDate[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }
                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 10);
            cb.LineTo(XPos - 17, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 3);
            cb.LineTo(XPos - 17, YPos - 3);
            cb.Stroke();

            ////Extra Line
            //cb.MoveTo(XPos - 17, YPos + 10);
            //cb.LineTo(XPos - 17, YPos - 400);
            //cb.Stroke();
            ////End Extra Line

            YPos = YPos - 25;

            cb.BeginText();
            cb.SetTextMatrix(75, YPos - 3);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Tick (");

            dynamic logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));
            logo1.SetAbsolutePosition(100, YPos - 5);
            logo1.ScalePercent(5);
            document.Add(logo1);

            cb.SetTextMatrix(114, YPos - 3);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(")");

            cb.EndText();
            float StartYPos = YPos;

            cb.MoveTo(75, StartYPos - 10);
            cb.LineTo(75, StartYPos - 55);
            cb.Stroke();


            cb.MoveTo(135, StartYPos - 10);
            cb.LineTo(135, StartYPos - 55);
            cb.Stroke();

            for (int i = 0; i < 4; i++)
            {
                cb.MoveTo(75, StartYPos - 10);
                cb.LineTo(135, StartYPos - 10);
                cb.Stroke();
                StartYPos = StartYPos - 15;
                if (i == 0)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(80, StartYPos - 5);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("CREATE");
                    cb.EndText();

                    logo1.SetAbsolutePosition(75, StartYPos - 8);
                    logo1.ScalePercent(6);
                    document.Add(logo1);
                }
                else if (i == 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(85, StartYPos - 5);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("MODIFY");
                    cb.EndText();
                }
                else if (i == 2)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(85, StartYPos - 5);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText("CANCEL");
                    cb.EndText();
                }
            }

            cb.BeginText();
            cb.SetTextMatrix(210, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Sponsor Bank Code");
            cb.EndText();

            XPos = 305;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 160, YPos + 12);
            cb.LineTo(XPos + 160, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 160, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 160, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 160) - XPos) / 2) - (cb.GetEffectiveStringWidth(SponsorBankCode, false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(SponsorBankCode);
            cb.EndText();

            XPos = XPos + 170;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Utility Code");
            cb.EndText();

            XPos = XPos + 60;

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 221) - XPos) / 2) - (cb.GetEffectiveStringWidth(UtilityCode, false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(UtilityCode);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 221, YPos + 12);
            cb.LineTo(XPos + 221, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 221, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 221, YPos - 3);
            cb.Stroke();

            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(165, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("I/We hereby authorize ");
            cb.EndText();

            XPos = 275;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 200, YPos + 12);
            cb.LineTo(XPos + 200, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 200, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 200, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 200) - XPos) / 2) - (cb.GetEffectiveStringWidth(Company, false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Company);
            cb.EndText();

            XPos = XPos + 210;

            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("to debit (tick");
            cb.EndText();

            logo1.SetAbsolutePosition(XPos + 55, YPos);
            logo1.ScalePercent(4);
            document.Add(logo1);

            cb.BeginText();
            cb.SetTextMatrix(XPos + 63, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(")");
            cb.EndText();

            XPos = XPos + 70;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 201, YPos + 12);
            cb.LineTo(XPos + 201, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 201, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 201, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 201) - XPos) / 2) - (cb.GetEffectiveStringWidth("SB/CA/CC/SB-NRE/SB-NRO/Other", false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("SB/CA/CC/SB-NRE/SB-NRO/Other");
            cb.EndText();
            if (ToDebit == "SB")
            {
                logo1.SetAbsolutePosition(XPos + 20, YPos);//SB
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "CA")
            {
                logo1.SetAbsolutePosition(XPos + 40, YPos);//CA
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "CC")
            {
                logo1.SetAbsolutePosition(XPos + 60, YPos);//CC
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "SB-NRE")
            {
                logo1.SetAbsolutePosition(XPos + 85, YPos);//SB-NRE
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "SB-NRO")
            {
                logo1.SetAbsolutePosition(XPos + 120, YPos);//SB-NRO
                logo1.ScalePercent(6);
                document.Add(logo1);
            }
            else if (ToDebit == "Other")
            {
                logo1.SetAbsolutePosition(XPos + 160, YPos);//Other
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(185, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Bank a/c number");
            cb.EndText();

            XPos = 275;

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 480, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 480, YPos - 3);
            cb.Stroke();
            for (int i = 0; i < 31; i++)
            {
                cb.MoveTo(XPos, YPos + 12);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();
                if (BankAcNo.Length >= i + 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(XPos + 5, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(BankAcNo[i].ToString());
                    cb.EndText();
                }

                XPos = XPos + 16;
            }


            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("with Bank");
            cb.EndText();

            XPos = 125;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 232, YPos + 12);
            cb.LineTo(XPos + 232, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 232, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 232, YPos - 3);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix((XPos + (((XPos + 232) - XPos) / 2) - (cb.GetEffectiveStringWidth(BankName, false) / 2)), YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(BankName);
            cb.EndText();

            XPos = XPos + 237;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("IFSC");
            cb.EndText();

            XPos = XPos + 28;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 176, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 176, YPos - 3);
            cb.Stroke();
            for (int i = 0; i < 12; i++)
            {
                cb.MoveTo(XPos, YPos + 12);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();

                if (IFSC.Length >= i + 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(XPos + 5, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(IFSC[i].ToString());
                    cb.EndText();
                }

                XPos = XPos + 16;
            }

            XPos = XPos - 10;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("or MICR");
            cb.EndText();

            XPos = XPos + 40;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 144, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 144, YPos - 3);
            cb.Stroke();
            for (int i = 0; i < 10; i++)
            {
                cb.MoveTo(XPos, YPos + 12);
                cb.LineTo(XPos, YPos - 3);
                cb.Stroke();

                if (MICR.Length >= i + 1)
                {
                    cb.BeginText();
                    cb.SetTextMatrix(XPos + 5, YPos);
                    cb.SetFontAndSize(bf, 10);
                    cb.ShowText(MICR[i].ToString());
                    cb.EndText();
                }

                XPos = XPos + 16;
            }


            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("an amount of Rupees");
            cb.EndText();

            XPos = 175;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 3, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(AmountInWords);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 435, YPos + 12);
            cb.LineTo(XPos + 435, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 435, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 435, YPos - 3);
            cb.Stroke();

            XPos = XPos + 438;
            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 143, YPos + 12);
            cb.LineTo(XPos + 143, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 12);
            cb.LineTo(XPos + 143, YPos + 12);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 143, YPos - 3);
            cb.Stroke();

            dynamic logo2 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Indian_Rupees_Icon.jpg"));
            logo2.SetAbsolutePosition(XPos, YPos - 1);
            logo2.ScalePercent(3);
            document.Add(logo2);

            cb.BeginText();
            cb.SetTextMatrix(XPos + 13, YPos + 2);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Amount);
            cb.EndText();


            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("FREQUENCY");
            cb.EndText();




            XPos = 150;

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "Mthly")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Mthly
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Mthly");
            cb.EndText();

            XPos = XPos + 35;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "Qtly")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Qtly
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Qtly");
            cb.EndText();


            XPos = XPos + 30;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "H-Yrly")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//H-Yrly
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("H-Yrly");
            cb.EndText();

            XPos = XPos + 38;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "Yrly")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Yrly
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Yrly");
            cb.EndText();

            XPos = XPos + 30;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (Frequency == "As & when presented")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//As & when presented
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("As & when presented");
            cb.EndText();

            XPos = XPos + 150;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            // cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE);
            cb.ShowText("DEBIT TYPE");
            // cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
            //cb.SetTextRenderingMode(PdfContentByte);
            cb.EndText();

            XPos = XPos + 70;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (DebitType == "Fixed Amount")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Fixed Amount
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }

            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Fixed Amount");
            cb.EndText();

            XPos = XPos + 80;
            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 10);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 10, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 10, YPos - 3);
            cb.Stroke();

            if (DebitType == "Maximum Amount")
            {
                logo1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Correct_Icon.jpg"));//Maximum Amount
                logo1.SetAbsolutePosition(XPos, YPos - 5);
                logo1.ScalePercent(6);
                document.Add(logo1);
            }


            XPos = XPos + 12;
            cb.BeginText();
            cb.SetTextMatrix(XPos + 2, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Maximum Amount");
            cb.EndText();

            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Reference 1");
            cb.EndText();

            XPos = 140;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 5, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Ref1);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 350, YPos + 10);
            cb.LineTo(XPos + 350, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 350, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 350, YPos - 3);
            cb.Stroke();

            XPos = XPos + 355;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Phone No.");
            cb.EndText();

            XPos = XPos + 50;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 5, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Phone);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 211, YPos + 10);
            cb.LineTo(XPos + 211, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 211, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 211, YPos - 3);
            cb.Stroke();

            YPos = YPos - 25;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Reference 2");
            cb.EndText();

            XPos = 140;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 5, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Ref2);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 350, YPos + 10);
            cb.LineTo(XPos + 350, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 350, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 350, YPos - 3);
            cb.Stroke();

            XPos = XPos + 355;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Email ID");
            cb.EndText();

            XPos = XPos + 50;

            cb.BeginText();
            cb.SetTextMatrix(XPos + 5, YPos);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(EmailId);
            cb.EndText();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos + 211, YPos + 10);
            cb.LineTo(XPos + 211, YPos - 3);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos + 211, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 3);
            cb.LineTo(XPos + 211, YPos - 3);
            cb.Stroke();

            YPos = YPos - 15;
            cb.BeginText();
            cb.SetTextMatrix(75, YPos);
            cb.SetFontAndSize(bf, 7);
            cb.ShowText("I agree for the debit of mandate processing charges by the bank whom I am authorizing to debit my account as per latest schedule of charges of the bank.");
            cb.EndText();

            YPos = YPos - 25;
            XPos = 75;

            cb.MoveTo(XPos, YPos + 10);
            cb.LineTo(XPos, YPos - 45);
            cb.Stroke();

            cb.MoveTo(XPos + 180, YPos + 10);
            cb.LineTo(XPos + 180, YPos - 45);
            cb.Stroke();

            cb.MoveTo(XPos + 45, YPos + 10);
            cb.LineTo(XPos + 180, YPos + 10);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 45);
            cb.LineTo(XPos + 180, YPos - 45);
            cb.Stroke();

            cb.BeginText();
            cb.SetTextMatrix(80, YPos + 6);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("PERIOD");

            cb.SetTextMatrix(80, YPos - 6);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("From");

            cb.EndText();
            d = 0;

            XPos = XPos + 35;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 2)
                {
                    if (PeridFrom.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridFrom[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }

                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 2)
                {
                    if (PeridFrom.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridFrom[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }

                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 4; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 4)
                {
                    if (PeridFrom.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridFrom[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }

                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            YPos = YPos - 15;
            XPos = 75;
            cb.BeginText();
            cb.SetTextMatrix(80, YPos - 5);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("To");
            cb.EndText();
            d = 0;

            XPos = XPos + 35;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();
                if (i < 2)
                {
                    if (PeridTo.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridTo[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }

                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 2; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 2)
                {
                    if (PeridTo.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridTo[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }


                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            XPos = XPos - 14;
            XStartPos = XPos;
            for (int i = 0; i <= 4; i++)
            {
                cb.MoveTo(XPos, YPos + 5);
                cb.LineTo(XPos, YPos - 8);
                cb.Stroke();

                if (i < 4)
                {
                    if (PeridTo.Length >= d + 1)
                    {
                        cb.BeginText();
                        cb.SetTextMatrix(XPos + 5, YPos - 6);
                        cb.SetFontAndSize(bf, 10);
                        cb.ShowText(PeridTo[d].ToString());
                        cb.EndText();
                    }
                    d++;
                }


                XPos = XPos + 17;
            }

            cb.MoveTo(XStartPos, YPos + 5);
            cb.LineTo(XPos - 17, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XStartPos, YPos - 8);
            cb.LineTo(XPos - 17, YPos - 8);
            cb.Stroke();

            YPos = YPos - 18;
            XPos = 75;
            cb.BeginText();
            cb.SetTextMatrix(80, YPos - 5);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Or");
            cb.EndText();

            XPos = XPos + 40;
            cb.MoveTo(XPos, YPos + 5);
            cb.LineTo(XPos, YPos - 8);
            cb.Stroke();

            cb.MoveTo(XPos + 10, YPos + 5);
            cb.LineTo(XPos + 10, YPos - 8);
            cb.Stroke();

            cb.MoveTo(XPos, YPos + 5);
            cb.LineTo(XPos + 10, YPos + 5);
            cb.Stroke();

            cb.MoveTo(XPos, YPos - 8);
            cb.LineTo(XPos + 10, YPos - 8);
            cb.Stroke();

            XPos = XPos + 15;
            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos - 5);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("Until Cancelled");
            cb.EndText();

            XPos = XPos + 150;

            dynamic logo211 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Account_Holder_Sign.jpg"));
            logo211.SetAbsolutePosition(XPos + 10, YPos + 15);
            logo211.ScalePercent(55);
            document.Add(logo211);

            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();

            XPos = XPos + 140 + 28;
            logo211 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Account_Holder_Sign.jpg"));
            logo211.SetAbsolutePosition(XPos + 10, YPos + 15);
            logo211.ScalePercent(55);
            document.Add(logo211);
            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();

            XPos = XPos + 140 + 27;
            logo211 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Account_Holder_Sign.jpg"));
            logo211.SetAbsolutePosition(XPos + 10, YPos + 15);
            logo211.ScalePercent(55);
            document.Add(logo211);
            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();


            YPos = YPos - 20;
            XPos = 280;

            cb.BeginText();
            cb.SetTextMatrix(XPos - 15, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("1.");

            cb.SetTextMatrix(XPos + 10, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Account_Holder1);
            cb.EndText();

            dynamic logo21 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Bank_Record.jpg"));
            logo21.SetAbsolutePosition(XPos + 10, YPos + 13);
            logo21.ScalePercent(70);
            document.Add(logo21);

            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();
            XPos = XPos + 140 + 28;

            cb.BeginText();
            cb.SetTextMatrix(XPos - 15, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("2.");

            cb.SetTextMatrix(XPos + 10, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText(Account_Holder2);
            cb.EndText();

            logo21 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Bank_Record.jpg"));
            logo21.SetAbsolutePosition(XPos + 10, YPos + 13);
            logo21.ScalePercent(70);
            document.Add(logo21);

            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();
            XPos = XPos + 140 + 27;

            cb.BeginText();
            cb.SetTextMatrix(XPos - 15, YPos + 13);
            cb.SetFontAndSize(bf, 10);
            cb.ShowText("3.");
            cb.EndText();

            logo21 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/Bank_Record.jpg"));
            logo21.SetAbsolutePosition(XPos + 10, YPos + 13);
            logo21.ScalePercent(70);
            document.Add(logo21);

            cb.MoveTo(XPos, YPos + 13);
            cb.LineTo(XPos + 140, YPos + 13);
            cb.Stroke();
            
            YPos = YPos - 30;
            XPos = 75;

            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos + 15);
            cb.SetFontAndSize(bf, 15);
            cb.ShowText(".");
            cb.SetTextMatrix(XPos + 5, YPos + 13);
            cb.SetFontAndSize(bf, 7);
            cb.ShowText(" This is to confirm that the declaration has been carefully read, understood & made by me/us.I am authorizing the user entity / corporate to debit my account, based on the instructions as agreed and signed by me.");
            cb.EndText();

            YPos = YPos - 10;
            XPos = 75;

            cb.BeginText();
            cb.SetTextMatrix(XPos, YPos + 15);
            cb.SetFontAndSize(bf, 15);
            cb.ShowText(".");
            cb.SetTextMatrix(XPos + 5, YPos + 13);
            cb.SetFontAndSize(bf, 7);
            cb.ShowText(" I have understood that I am authorized to cancel/amend this mandate by appropriately communicating the cancellation/amendment request to the User entity/corporate or the bank where I have authorized the debit.");
            cb.EndText();

            document.NewPage();
        }
        document.Close();
        string CurTimeFrame = null;
        CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=PrintECS{0}.pdf", CurTimeFrame));
        Response.BinaryWrite(output.ToArray());

    }

    private void BindLedgerCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddllcompany, ds, "Company_Name", "Company_Code");
        ddllcompany.Items.Insert(0, "Select");
        ddllcompany.SelectedIndex = 0;
    }
    private void BindLedgerDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddllcompany.SelectedValue);
        BindDDL(ddlldivision, ds, "Division_Name", "Division_Code");
        ddlldivision.Items.Insert(0, "Select");
        ddlldivision.SelectedIndex = 0;
    }
    private void BindLedgerCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlldivision.SelectedValue, "", ddllcompany.SelectedValue);
        BindDDL(ddllcenter, ds, "Center_name", "Center_Code");
        ddllcenter.Items.Insert(0, "Select");
        ddllcenter.SelectedIndex = 0;
    }
    private void BindLedgerAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddllcenter.SelectedValue);
        BindDDL(ddllacadyear, ds, "Acad_Year", "Acad_Year");
        ddllacadyear.Items.Insert(0, "Select");
        ddllacadyear.SelectedIndex = 0;
    }
    private void BindLedgerStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddllcenter.SelectedValue, ddllacadyear.SelectedValue);
        BindDDL(ddllstream, ds, "Stream_Sdesc", "Stream_Code");
        ddllstream.Items.Insert(0, "Select");
        ddllstream.SelectedIndex = 0;
    }

    private void BindStudentSubjectGroup(string CurSbCode)
    {
        DataSet ds = AccountController.GetStudentSubjectgroupbyCursbcode(2, CurSbCode);
        lbsubjectgroup.DataSource = ds;
        lbsubjectgroup.DataTextField = "SGR_DESC";
        lbsubjectgroup.DataValueField = "sgr_material";
        lbsubjectgroup.DataBind();
    }
    #endregion







   
}