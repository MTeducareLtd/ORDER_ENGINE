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
//using Exportxls.BL;
using Encryption.BL;


public partial class ECS_Acknowledgement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //string Menuid = "117";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "ECS Acknowledgement";
                lblpagetitle2.Text = "Search Panel";
                //lblmidbreadcrumb.Text = "Manage Account";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                DivECSDetail.Visible = false;
                //upnlsearch.Visible = true;
                btnback.Visible = false;
                btnsearchback.Visible = false;
                divSearch.Visible = true;
                divsearchresults.Visible = false;
                BindCompany();
                BindAcademicYear();
                BindStream();
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

    }


    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }






    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center_Top1(1, UserID, "", "", "");
        ddlcompany.DataSource = ds.Tables[0];
        ddlcompany.DataTextField = "Company_Name";
        ddlcompany.DataValueField = "Company_Code";
        ddlcompany.DataBind();
        // ddlcompany.Items.Insert(0, "All");
        ddlcompany.SelectedIndex = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlcompany.SelectedValue = ds.Tables[0].Rows[0]["Company_Code"].ToString();
            ddldivision.DataSource = ds.Tables[1];
            ddldivision.DataTextField = "division_name";
            ddldivision.DataValueField = "division_code";
            ddldivision.DataBind();
            ddldivision.Items.Insert(0, "All");
            ddldivision.SelectedIndex = 0;
            if (ddldivision.Items.Count > 1)
            {
                ddldivision.SelectedIndex = 1;
                ddlzone.DataSource = ds.Tables[2];
                ddlzone.DataTextField = "Zone_Name";
                ddlzone.DataValueField = "Zone_Code";
                ddlzone.DataBind();
                ddlzone.Items.Insert(0, "All");
                ddlzone.SelectedIndex = 0;
                if (ddlzone.Items.Count > 1)
                {
                    ddlzone.SelectedIndex = 1;
                    ddlcenter.DataSource = ds.Tables[3];
                    ddlcenter.DataTextField = "center_name";
                    ddlcenter.DataValueField = "center_code";
                    ddlcenter.DataBind();
                    ddlcenter.Items.Insert(0, "All");
                    ddlcenter.SelectedIndex = 0;
                    if (ddlcenter.Items.Count > 1)
                    {
                        ddlcenter.SelectedIndex = 1;
                    }
                }
                else
                {
                    ddlcenter.Items.Insert(0, "All");
                    ddlcenter.SelectedIndex = 0;
                }
            }
            else
            {
                ddlzone.Items.Insert(0, "All");
                ddlzone.SelectedIndex = 0;
                ddlcenter.Items.Insert(0, "All");
                ddlcenter.SelectedIndex = 0;
            }
        }
        else
        {
            ddldivision.Items.Insert(0, "All");
            ddldivision.SelectedIndex = 0;
            ddlzone.Items.Insert(0, "All");
            ddlzone.SelectedIndex = 0;
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;
        }


    }

    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDivision();
    }
    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlcompany.SelectedValue);
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;
    }
    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }

    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "All");
        ddlzone.SelectedIndex = 0;
    }
    protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddldivision.SelectedValue, ddlzone.SelectedValue, ddlcompany.SelectedValue);
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
        ddlacademicyear.SelectedIndex = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlacademicyear.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
        }
    }
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
    }
    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue);
        BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlstream.Items.Insert(0, "All");
        ddlstream.SelectedIndex = 0;
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


    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {

        if (ddlacademicyear.SelectedIndex == 0)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Text = "Select Acad Year";
            return;
        }
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string Company = "";
        string Division = "";
        string Zone = "";
        string Center = "";
        string AcademicYear = "";
        string Stream = "";
        string ECSStatusID = "";

        Company = ddlcompany.SelectedValue;
        Division = ddldivision.SelectedValue;
        Zone = ddlzone.SelectedValue;
        Center = ddlcenter.SelectedValue;
        AcademicYear = ddlacademicyear.SelectedValue;
        Stream = ddlstream.SelectedValue;
        ECSStatusID = ddlAcknowledgementstatus.SelectedValue;


        DataSet ds = AccountController.GetECS_Detail(UserID, Company, Division, Zone, Center, AcademicYear, Stream, ECSStatusID, txtsbentrycode.Text.Trim(), "1", "");

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "ECS Acknowledgement";
            lblpagetitle2.Text = "Search Results";
            //lblmidbreadcrumb.Text = "Manage Account";
            //lbllastbreadcrumb.Text = " Account Search Results";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            DivECSDetail.Visible = false;
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            // script1.RegisterAsyncPostBackControl(Repeater1);
            btnsearchback.Visible = true;
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            btnsearchback.Visible = false;
            divErrormessage.Visible = true;
            DivECSDetail.Visible = false;
            lblpagetitle1.Text = "ECS Acknowledgement";
            lblpagetitle2.Text = "Search Panel";
            lblerrormessage.Text = "No Records Found!";
        }
    }
    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ECSView")
            {
                string ECS_ID = "";
                ECS_ID = e.CommandArgument.ToString();

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];

                DataSet ds = AccountController.GetECS_Detail(UserID, "", "", "", "", "", "", "", "", "2", ECS_ID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    upnlsearch.Visible = false;
                    divErrormessage.Visible = false;
                    DivECSDetail.Visible = true;
                    btnback.Visible = true;
                    lblpagetitle2.Text = "View ECS";

                    string SBEntrycode = ds.Tables[0].Rows[0]["SBEntryCode"].ToString();

                    lblUMRN.Text = ds.Tables[0].Rows[0]["UMR_NO"].ToString();
                    lblECSDate.Text = ds.Tables[0].Rows[0]["ECS_DATE"].ToString();
                    lblSponsorBankCode.Text = ds.Tables[0].Rows[0]["SponsorBankCode"].ToString();
                    lblUtilityCode.Text = ds.Tables[0].Rows[0]["UtilityCode"].ToString();
                    lblCompanyName.Text = ds.Tables[0].Rows[0]["Company_Name"].ToString();
                    lblToDebit.Text = ds.Tables[0].Rows[0]["ToDebit"].ToString();
                    lblBankAcNo.Text = ds.Tables[0].Rows[0]["BankAcNo"].ToString();
                    lblPeriod.Text = ds.Tables[0].Rows[0]["Period"].ToString();
                    lblMICRNo.Text = ds.Tables[0].Rows[0]["MICR_Code"].ToString();
                    lblWithBank.Text = ds.Tables[0].Rows[0]["WithBank"].ToString();
                    lblIFSCCode.Text = ds.Tables[0].Rows[0]["IFSC_Code"].ToString();
                    lblAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                    lblFrequency.Text = ds.Tables[0].Rows[0]["Frequency"].ToString();
                    lblDebitType.Text = ds.Tables[0].Rows[0]["Debit_Type"].ToString();
                    lblRef1.Text = ds.Tables[0].Rows[0]["Ref1"].ToString();
                    lblPhoneNo.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    lblRef2.Text = ds.Tables[0].Rows[0]["Ref2"].ToString();
                    lblEmailID.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {

                        txtSPID.Text = ds.Tables[1].Rows[0]["SPID"].ToString();
                        txtLstudentname.Text = ds.Tables[1].Rows[0]["NAME"].ToString();
                        imgstudentphoto.ImageUrl = ds.Tables[1].Rows[0]["stud_image"].ToString();
                        txtLappno.Text = ds.Tables[1].Rows[0]["Student_App_No"].ToString();
                        txtopportunityid.Text = ds.Tables[1].Rows[0]["oppor_id"].ToString();
                        txtaccountid.Text = ds.Tables[1].Rows[0]["account_id"].ToString();
                        txtcursbcode.Text = ds.Tables[1].Rows[0]["sbentrycode"].ToString();
                        BindLedgerCompany();
                        ddllcompany.SelectedValue = ds.Tables[1].Rows[0]["companycode"].ToString();
                        BindLedgerDivision();
                        ddlldivision.SelectedValue = ds.Tables[1].Rows[0]["divisioncode"].ToString();
                        BindLedgerCenter();
                        ddllcenter.SelectedValue = ds.Tables[1].Rows[0]["center_code"].ToString();
                        BindLedgerAcademicYear();
                        ddllacadyear.SelectedValue = ds.Tables[1].Rows[0]["acad_year"].ToString();
                        BindLedgerStream();
                        ddllstream.SelectedValue = ds.Tables[1].Rows[0]["stream_code"].ToString();
                        BindStudentSubjectGroup(SBEntrycode);
                        txtpayplan.Text = ds.Tables[1].Rows[0]["payplan"].ToString();
                        txtadmndate.Text = ds.Tables[1].Rows[0]["Admndate"].ToString();
                    }
                }
            }
            else if (e.CommandName == "IsAcknowledge")
            {
                lblPKey.Text = e.CommandArgument.ToString();
                upnlECSAcknowledge.Update();
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalECSAcknowledge();", true);
            }
            else if (e.CommandName == "IsDeclined")
            {
                lblPKey.Text = e.CommandArgument.ToString();
                upnlECSDecline.Update();
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDecline();", true);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("ErrorPages/500.aspx");
        }
    }

    /// <summary>

    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        btnsearchback.Visible = false;
        DivECSDetail.Visible = false;
        lblpagetitle1.Text = "ECS Acknowledgement";
        lblpagetitle2.Text = "Search Panel";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnback.Visible = false;
    }

    /// <summary>
    /// Back Functionality
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = false;
        divsearchresults.Visible = true;
        DivECSDetail.Visible = false;
        btnback.Visible = false;
        lblpagetitle1.Text = "ECS Acknowledgement";
        lblpagetitle2.Text = "Search Panel";
        //lblmidbreadcrumb.Text = "Manage Account";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnsearch_ServerClick(sender, e);
    }


    protected void btnClose_Click(object sender, EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = false;
        divsearchresults.Visible = true;
        DivECSDetail.Visible = false;
        btnback.Visible = false;
        lblpagetitle1.Text = "ECS Acknowledgement";
        lblpagetitle2.Text = "Search Panel";
        //lblmidbreadcrumb.Text = "Manage Account";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnsearch_ServerClick(sender, e);
    }

    protected void btnAckYes_Click(object sender, EventArgs e)
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = AccountController.Update_ECS_Acknowledgement(UserID, "1", lblPKey.Text,"");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
                    {
                        divErrormessage.Visible = false;
                        divSuccessmessage.Visible = true;
                        lblsuccessMessage.Text = "ECS Acknowledged successfully.";
                        btnsearch_ServerClick(sender, e);
                    }
                }
                else
                {
                    divErrormessage.Visible = true;
                    divSuccessmessage.Visible = false;
                    lblerrormessage.Text = "ECS Not Acknowledged.";
                    return;
                }
            }
            else
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Text = "ECS Not Acknowledged.";
                return;
            }
        }
        catch (Exception ex)
        {

            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.ToString();
        }
    }

    protected void btndecYes_Click(object sender, EventArgs e)
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = AccountController.Update_ECS_Acknowledgement(UserID, "2", lblPKey.Text,txtdeclinereason.Text.Trim());
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
                    {
                        divErrormessage.Visible = false;
                        divSuccessmessage.Visible = true;
                        lblsuccessMessage.Text = "ECS Declined Successfully.";
                        btnsearch_ServerClick(sender, e);
                        txtdeclinereason.Text = "";
                    }
                }
                else
                {
                    divErrormessage.Visible = true;
                    divSuccessmessage.Visible = false;
                    lblerrormessage.Text = "ECS Not Declined.";
                    return;
                }
            }
            else
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Text = "ECS Not Declined.";
                return;
            }
        }
        catch (Exception ex)
        {

            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.ToString();
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            string filenamexls1 = "ECS_Acknowledgement_" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='8'>Facultywise Detailed Timetable Report </b></TD></TR>");
           // HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='7'><b>Student Remark Report </b></TD></TR><TR style='color: #fff; background: black;text-align:center;'><TD Colspan='2' style='text-align:left;'><b>Division-" + lblResult_Division1.Text + "</b></TD><TD Colspan='3' style='text-align:left;'><b>Acad Year-" + lblResult_AcadYear1.Text + "</b></TD><TD Colspan='2' style='text-align:left;'><b>Course-" + lblResult_Course1.Text + "</b></TD></TR><TR style='color: #fff; background: black;text-align:center;'><TD Colspan='2' style='text-align:left;'><b>LMS/Non LMS Product-" + lblResult_LMSNonLMSProduct1.Text + "</b></TD><TD Colspan='3' style='text-align:left;'><b>Center-" + lblResult_Center1.Text + "</b></TD><TD Colspan='2' style='text-align:left;'><b>Batch-" + lblResult_Batch1.Text + "</b></TD></TR><TR style='color: #fff; background: black;text-align:center;'><TD Colspan='2' style='text-align:left;'><b>Period-" + lblResult_Period1.Text + "</b></TD><TD Colspan='5' style='text-align:left;'><b>Student-" + lblResult_Student1.Text + "</b></TD></TR>");
            //HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='8'>Facultywise Detailed Timetable Report  </b></TD></TR><TR style='color: #fff; background: black;text-align:center;'><TD Colspan='1' style='text-align:right;'>Division - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblDivision_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'>Acad Year - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblAcademicYear_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'>Course - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblCourse_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'></b></TD><TD Colspan='1' style='text-align:right;'></b></TD></TR><TR style='color: #fff; background: black;'><TD Colspan='1' style='text-align:right;'>LMS/NONLMS Product - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblLMSProduct_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'>Center - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblCenter_Result.Text + "</b></TD><TD Colspan='1' style='text-align:right;'>Period - </b></TD><TD Colspan='1' style='text-align:left;'>" + lblPeriod.Text + "</b></TD><TD Colspan='1' style='text-align:right;'></b></TD><TD Colspan='1' style='text-align:right;'></b></TD></TR> ");
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
        catch (Exception ex)
        {
            //Msg_Error.Visible = true;
            //Msg_Success.Visible = false;
            //lblerror.Text = ex.ToString();
            //UpdatePanelMsgBox.Update();
            //return;
        }
    }

   
}