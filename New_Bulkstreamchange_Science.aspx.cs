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

public partial class New_Bulkstreamchange_Science : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FillDDL_Division();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        Getstudentdetails();


    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void Getstudentdetails()
    {
        DataSet ds1 = AccountController.GetSbentrycodeforstreamchange();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Repeater1.DataSource = ds1;
            Repeater1.DataBind();
            DivResult.Visible = true;
            ControlVisibility("Result");


        }

    }


    public void All_Student_ChkBox_Selected_Sel(object sender, System.EventArgs e)
    {
        //Change checked status of a hidden check box
        chkStudentAllHidden_Sel.Checked = !(chkStudentAllHidden_Sel.Checked);

        //Set checked status of hidden check box to items in grid
        foreach (RepeaterItem dtlItem in Repeater1.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            chkitemck.Checked = chkStudentAllHidden_Sel.Checked;
        }
    }
    public void btnstartsync_ServerClick(object sender, System.EventArgs e)
    {
        string Sbentrycode = "";
        List<string> list = new List<string>();
        string Sgrcode = "";
        try
        {
            foreach (RepeaterItem dtlItem in Repeater1.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                Label lblsbentrycode = (Label)dtlItem.FindControl("lblsbentrycode");
                Label DestinationStream = (Label)dtlItem.FindControl("lblnewstream");
                Label DestinationPayplan = (Label)dtlItem.FindControl("LBLPAYPALN");
                Label Oldstreamsubjectgroup = (Label)dtlItem.FindControl("lblSubjectCode");
                Label SourceStreamCode = (Label)dtlItem.FindControl("lblOldstream");
                Label Opportunitycode = (Label)dtlItem.FindControl("lblOppID");
                Label Centercode = (Label)dtlItem.FindControl("LBLCENTERCODE");
                Label TotalDiscountValue = (Label)dtlItem.FindControl("lbldiscount");
                Label TotalConcessionValue = (Label)dtlItem.FindControl("lblconessesion");
                Label payplan = (Label)dtlItem.FindControl("LBLPAYPALN");


                if (chkitemck.Checked == true)
                {
                    //Code for Bulk stream here
                    string Opp_id = "";
                    string Doctype = "";
                    int Flag = 0;
                    Opp_id = lblsbentrycode.Text + "P";


                    //Get New Stream,Pay Plan and Subject Group
                    //string DestinationStream = "";
                    //string SourceStreamCode = "";
                    DataSet dsstudentdetails = AccountController.GetCustomerdetailsSbentrycode(lblsbentrycode.Text);
                    if (dsstudentdetails.Tables[4].Rows.Count > 0)
                    {


                        //string DestinationPayplan = "";
                        //string Oldstreamsubjectgroup = "";
                        string Vouchertype = "ZP02";
                        string Voucheramount = "";
                        string BaseUOM = "Each";
                        string BaseUOMId = "01";
                        string Unit = "01";
                        string Quantity = "1";
                        string Amount = "";
                        string Remark = "BulkStreamChange";
                        //string Opportunitycode = "";
                        //string Centercode = "";
                        //string TotalDiscountValue = "";
                        //string TotalConcessionValue = "";
                        Flag = 1;
                        Doctype = "DC05";

                        AccountController.InserttoGetPricingprocedurevaluebyoppidStreamChangeBulk(Opp_id, Oldstreamsubjectgroup.Text, Vouchertype, Centercode.Text, DestinationStream.Text);

                        //if (dsstudentdetails.Tables[0].Rows.Count > 0)
                        //{
                        //    DestinationStream = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Destination_Stream_Code"]);
                        //    DestinationPayplan = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Pay_Type"]);
                        //    Oldstreamsubjectgroup = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Source_Material_Code"]);
                        //    SourceStreamCode = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Source_Stream_Code"]);
                        //    Opportunitycode = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Opportunity_Code"]);
                        //    Centercode = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Center_Code"]);
                        //    TotalDiscountValue = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Total_Discount_Value"]);
                        //    TotalConcessionValue = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Total_Concession_Value"]);
                        //}

                        //string sgr_materialcode = "";
                        //DataSet dsSubjectGroupPrice = AccountController.GetCustomerSubjectGroupMaterial(lblsbentrycode.Text, DestinationStream, Oldstreamsubjectgroup);

                        ////Foreach materialcode insertusing below function
                        //foreach (DataRow row in dsSubjectGroupPrice.Tables[2].Rows)
                        //{
                        //    sgr_materialcode = row["sgr_material"].ToString();
                        //    Voucheramount = row["Voucher_Amt"].ToString();
                        //    //AccountController.InserttoGetPricingprocedurevaluebyoppidStreamChange(
                        //    //                    Opp_id, sgr_materialcode, Vouchertype, Voucheramount, BaseUOMId, BaseUOM, Unit, Quantity, Voucheramount, Remark,
                        //    //                    Doctype, Flag, DestinationStream);

                        //    AccountController.InserttoGetPricingprocedurevaluebyoppidStreamChange(Opp_id, sgr_materialcode, Vouchertype, Voucheramount, BaseUOMId, BaseUOM, Unit, Quantity, Voucheramount, Remark,
                        //    Doctype, Flag, DestinationStream);
                        //}


                        ////Get pay plan
                        int flag2 = 2;
                        if (payplan.Text == "FDP")
                        {
                            flag2 = 3;
                        }
                        else
                        {
                            flag2 = 2;
                        }

                        DataSet ds = AccountController.GetPricingprocedureHeaderValue_NewStreamChange(Opp_id, Oldstreamsubjectgroup.Text, "", "", "", "", "", "", "", "", "DC05", flag2, SourceStreamCode.Text);

                        //Get Account id 
                        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                        string UserID = cookie.Values["UserID"];
                        string UserName = cookie.Values["UserName"];
                        string Cur_sb_code = lblsbentrycode.Text;
                        string Accountid = AccountController.GetAccountidbysbentrycode(Cur_sb_code);
                        string MandateSubjects = "";
                        string OptionalSubjects = "";
                        string Selectivesubjects = "";

                        //Get new SBEntryCode
                        int flag = 1;

                        Accountid = AccountController.StreamChange(Opportunitycode.Text, Oldstreamsubjectgroup.Text, Doctype, payplan.Text, UserID, DestinationStream.Text, Accountid, Opp_id);

                        if (TotalDiscountValue.Text != "")
                        {

                            DataSet ds1 = AccountController.GetTaxValue_forstreamchange(1, lblsbentrycode.Text, Centercode.Text);

                        }
                        if (TotalConcessionValue.Text != "")
                        {

                            DataSet ds1 = AccountController.GetTaxValue_forstreamchange(2, lblsbentrycode.Text, Centercode.Text);

                        }

                        ProductController.EventSTS(lblsbentrycode.Text);

                        // Confirm admission

                        AccountController.EventSTSConfrim(lblsbentrycode.Text); // this funtion will update the new sbentrycode and fee out standing



                        //Accountid = AccountController.StreamChange(Opportunitycode, Oldstreamsubjectgroup, Doctype, DestinationPayplan, UserID, DestinationStream, Accountid, Opp_id);
                        //string newsbentrycode = ProductController.GetNewSbntrycodebyOldSbnetrycode(flag, lblsbentrycode.Text);
                        //string NewSB = newsbentrycode;


                        ////Moving Receipt
                        //string VouchertypeRegistrationFees = "ZRE1";
                        ////DateTime  V1 = 
                        //string VoucherDate = "";
                        //string adjamt = ProductController.GetVoucherValuebySbentrycode(1, lblsbentrycode.Text, "ZRE1");
                        //string adjamt1 = ProductController.GetVoucherValuebySbentrycode(1, newsbentrycode, "ZRE1");
                        ////decimal  adjamt1 = Convert.(adjamt);
                        //float finalamt = 0;
                        ////float STaxamt = 0;
                        ////decimal  HETAx = 0;
                        ////float ECEssTax = 0;
                        //float oldAmount = float.Parse(adjamt);
                        //float newAmount = float.Parse(adjamt1);
                        //float lessamt = 0;


                        //if (oldAmount >= newAmount)
                        //{
                        //    DataSet dsTax = ProductController.GetTaxValue(1, lblsbentrycode.Text, oldAmount, Centercode);
                        //    float Taxtotalvalue = float.Parse(dsTax.Tables[0].Rows[0]["TotalTax"].ToString());
                        //    float STTax = float.Parse(dsTax.Tables[0].Rows[0]["Stax"].ToString());
                        //    float HTAx = float.Parse(dsTax.Tables[0].Rows[0]["Htax"].ToString());
                        //    float Etax = float.Parse(dsTax.Tables[0].Rows[0]["Etax"].ToString());
                        //    STTax = STTax * -1;
                        //    HTAx = HTAx * -1;
                        //    Etax = Etax * -1;
                        //    finalamt = oldAmount + Taxtotalvalue;
                        //    lessamt = newAmount * -1;
                        //    flag = 1;
                        //    ProductController.InsertReceiptforevent(flag, lblsbentrycode.Text, UserID, newsbentrycode, finalamt);
                        //    string Pricing_Procedure_Code = "";
                        //    string Material_Code = "";
                        //    string returnvalue = ProductController.InsertFeesAdjustment(newsbentrycode, VouchertypeRegistrationFees, VoucherDate, lessamt, Pricing_Procedure_Code, Material_Code, UserID);
                        //    string returnvalue1 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT01", VoucherDate, STTax, Pricing_Procedure_Code, Material_Code, UserID);
                        //    string returnvalue2 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT02", VoucherDate, HTAx, Pricing_Procedure_Code, Material_Code, UserID);
                        //    string returnvalue3 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT03", VoucherDate, Etax, Pricing_Procedure_Code, Material_Code, UserID);

                        //}
                        //else if (oldAmount < newAmount)
                        //{
                        //    DataSet dsTax2 = ProductController.GetTaxValue(1, lblsbentrycode.Text, oldAmount, Centercode);
                        //    float Taxtotalvalue = float.Parse(dsTax2.Tables[0].Rows[0]["TotalTax"].ToString());
                        //    float STTax = float.Parse(dsTax2.Tables[0].Rows[0]["Stax"].ToString());
                        //    float HTAx = float.Parse(dsTax2.Tables[0].Rows[0]["Htax"].ToString());
                        //    float Etax = float.Parse(dsTax2.Tables[0].Rows[0]["Etax"].ToString());
                        //    STTax = STTax * -1;
                        //    HTAx = HTAx * -1;
                        //    Etax = Etax * -1;
                        //    finalamt = oldAmount + Taxtotalvalue;
                        //    lessamt = oldAmount * -1;
                        //    flag = 1;
                        //    ProductController.InsertReceiptforevent(flag, lblsbentrycode.Text, UserID, newsbentrycode, finalamt);
                        //    string Pricing_Procedure_Code = "";
                        //    string Material_Code = "";
                        //    string returnvalue = ProductController.InsertFeesAdjustment(newsbentrycode, VouchertypeRegistrationFees, VoucherDate, lessamt, Pricing_Procedure_Code, Material_Code, UserID);
                        //    string returnvalue1 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT01", VoucherDate, STTax, Pricing_Procedure_Code, Material_Code, UserID);
                        //    string returnvalue2 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT02", VoucherDate, HTAx, Pricing_Procedure_Code, Material_Code, UserID);
                        //    string returnvalue3 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT03", VoucherDate, Etax, Pricing_Procedure_Code, Material_Code, UserID);

                        //}

                        ////Insert Discount Value
                        //float TotalDiscount = float.Parse(TotalDiscountValue);
                        //if (TotalDiscount < 0)
                        //{

                        //    ProductController.InsertFeesAdjustment(newsbentrycode, "ZA01", VoucherDate, TotalDiscount, "PP011", "", UserID);

                        //    DataSet dsTax = ProductController.GetTaxValue(1, newsbentrycode, TotalDiscount, Centercode);
                        //    float Taxtotalvalue = float.Parse(dsTax.Tables[0].Rows[0]["TotalTax"].ToString());
                        //    float STTax = float.Parse(dsTax.Tables[0].Rows[0]["Stax"].ToString());
                        //    float HTAx = float.Parse(dsTax.Tables[0].Rows[0]["Htax"].ToString());
                        //    float Etax = float.Parse(dsTax.Tables[0].Rows[0]["Etax"].ToString());
                        //    //STTax = STTax ;
                        //    //HTAx = HTAx ;
                        //    //Etax = Etax ;
                        //    string returnvalue1 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT01", VoucherDate, STTax, "PP011", "", UserID);
                        //    string returnvalue2 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT02", VoucherDate, HTAx, "PP011", "", UserID);
                        //    string returnvalue3 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT03", VoucherDate, Etax, "PP011", "", UserID);
                        //}



                        //float TotalConcession = float.Parse(TotalConcessionValue);
                        //if (TotalConcession < 0)
                        //{
                        //    string a = ProductController.InsertFeesAdjustment(newsbentrycode, "ZC01", VoucherDate, TotalConcession, "PP011", "", UserID);
                        //    DataSet dsTax = ProductController.GetTaxValue(1, newsbentrycode, TotalDiscount, Centercode);
                        //    float Taxtotalvalue = float.Parse(dsTax.Tables[0].Rows[0]["TotalTax"].ToString());
                        //    float STTax = float.Parse(dsTax.Tables[0].Rows[0]["Stax"].ToString());
                        //    float HTAx = float.Parse(dsTax.Tables[0].Rows[0]["Htax"].ToString());
                        //    float Etax = float.Parse(dsTax.Tables[0].Rows[0]["Etax"].ToString());
                        //    STTax = STTax * -1;
                        //    HTAx = HTAx * -1;
                        //    Etax = Etax * -1;
                        //    string returnvalue1 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT01", VoucherDate, STTax, "PP011", "", UserID);
                        //    string returnvalue2 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT02", VoucherDate, HTAx, "PP011", "", UserID);
                        //    string returnvalue3 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT03", VoucherDate, Etax, "PP011", "", UserID);
                        //}

                        ////Confirm Student
                        //AccountController.GetPaymentDetailsbySBEntrycode(newsbentrycode);
                        //AccountController.GetPPgroupbysbentrycode(newsbentrycode);
                        //AccountController.Getstudentledgerbysbentrycode(newsbentrycode);
                        //string amountdiff = "";
                        //SqlDataReader dr = AccountController.GetChequeOutstanding(newsbentrycode);
                        //if ((((dr) != null)))
                        //{
                        //    if (dr.Read())
                        //    {
                        //        amountdiff = dr["outstanding"].ToString();
                        //    }
                        //}
                        ////if (Convert.ToInt32(amountdiff) <= 0)
                        ////{
                        //string Output = AccountController.Confirmadmission(newsbentrycode);
                        //if (Output == "XXX")
                        //{
                        //    Output = "03";
                        //}
                        //AccountController.BulkStreamChangeLog(lblsbentrycode.Text, newsbentrycode, Output, amountdiff);
                        //AccountController.Getstudentledgerbysbentrycode(newsbentrycode);
                        ////}
                        ////else
                        ////{
                        ////    string Output = "Admission Pending";
                        ////    AccountController.BulkStreamChangeLog(lblsbentrycode.Text, newsbentrycode, Output, amountdiff);
                        ////    AccountController.Getstudentledgerbysbentrycode(newsbentrycode);
                        ////}
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //divErrormessage.Visible = true;
            //lblerrormessage.Visible = true;
            //lblerrormessage.Text = ex.Message;

        }




    }

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = true;


        }
        else if (Mode == "Result")
        {
            DivResultPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;


        }
        else if (Mode == "Add")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;


        }
        else if (Mode == "Edit")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;


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
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        DivResultPanel.Visible = false;
        DivSearchPanel.Visible = true;
        BtnShowSearchPanel.Visible = false;
    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Rpt_Lecture_Schedule_Details.aspx");

    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Faculty_LateComing_Rpt_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='10'>Faculty Late Coming Report</b></TD></TR><TR style='text-align:center;'><TD Colspan='10'></TD></TR><TR></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        Repeater1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

    }
}