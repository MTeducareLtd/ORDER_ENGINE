using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

public partial class Manage_Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "Manage Order";
                lblpagetitle2.Text = "";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Order";
                //lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Text = "Search Panel";
                btnback.Visible = false;
                //lilastbreadcrumb.Visible = False
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divinfo.Visible = true;
                lblInfo.Text = "For Quick results, use filters below";

                diverrorsubject.Visible = false;
                divSuccessrsubject.Visible = false;
                upnlconvert.Visible = false;
                divSearch.Visible = true;
                div_ConvertMT.Visible = false;
                btnviewenrollment.Disabled = true;
                btnback.Visible = false;
                btnsearchback.Visible = false;

                tdadmissionno.Visible = false;
                tdadmissionno1.Visible = false;
                divmessage.Visible = false;
                divSearch.Visible = true;
                divsearchresults.Visible = false;
                BindProductCategory();
                BindSalesStage();
                BindOpporStatus();
                BindCompany();
                StudentType();
                Institutetype();
                Board();
                this.ddlstandardsearch.Items.Insert(0, "All");
                this.ddlstandardsearch.SelectedIndex = 0;
                CountrySearch();
                BindAcademicYear();
                //ddlacadyearsearch.Items.Insert(0, "All");
                //ddlacadyearsearch.SelectedIndex = 0;
                ddlstreamsearch.Items.Insert(0, "All");
                ddlstreamsearch.SelectedIndex = 0;
                Yearofpassing();
                Bindscore();
                dlselective.Enabled = false;
                if (Request["Opportunity_Code"] != null)
                {
                    string Opportunity_Code = Request["Opportunity_Code"];
                    if (Opportunity_Code != "")
                    {
                        try
                        {
                            //System.Threading.Thread.Sleep(100)
                            lblpagetitle1.Text = "Create Order";
                            lblpagetitle2.Text = "";
                            //limidbreadcrumb.Visible = true;
                            lblmidbreadcrumb.Text = "Manage Order";
                            //lilastbreadcrumb.Visible = true;
                            lbllastbreadcrumb.Text = "Create Order";
                            divSuccessmessage.Visible = false;
                            divErrormessage.Visible = false;
                            upnlconvert.Visible = true;
                            divSearch.Visible = false;
                            btnviewenrollment.Disabled = false;
                            btnback.Visible = true;

                            ClearAddPanel();
                            string Oppid = Opportunity_Code;
                            lbloppid.Text = Oppid;
                            ProductController.Removerecordsifexists(Oppid, 1, "", "");
                            HtmlAnchor viewenrollment = btnviewenrollment;
                            viewenrollment.HRef = "Enrollment_display.aspx?&Oppur_id=" + Oppid;

                            BindStudentdetails(Oppid);
                            Session["Opp_id"] = Oppid;
                            //divcreatebutton.Visible = False
                            //div5.Visible = False
                            div5.Visible = true;
                            divcreatebutton.Visible = true;
                            //Dim oppid As String = ""
                            //oppid = lbloppid.Text

                            //Important Do forget to uncomment
                            BindConvert(Oppid);
                            BindMandateSubjects();
                            BindCompulsorySubjects();
                            BindOptionalSubject();
                            BindPayplan();

                            divcreatebutton.Visible = false;
                            Divreselect.Visible = false;
                            Div6.Visible = true;
                            //divfeedetails.Visible = False
                            divbtnexit.Visible = false;
                            btnclose.Visible = false;
                            divErrormessage.Visible = false;

                        }
                        catch (Exception ex)
                        {
                            divErrormessage.Visible = true;
                            lblerrormessage.Visible = true;
                            lblerrormessage.Text = ex.Message;
                            Response.Redirect("Errorpages/500.aspx");
                        }
                    }
                }
                //DirectCast(dlselective.Items(0).FindControl("txtquantity"), TextBox).Enabled = False
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }
        GetSumvalue();


    }


    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void Bindscore()
    {
        string Oppid = "";
        string Scoretypeid = "";
        string Score = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int Id = 0;
        DataSet ds = ProductController.GetAllScore(1, Oppid, Scoretypeid, Score, UserID, Id);
        BindDDL(ddlscoretype, ds, "Score_Type_Short_Desc", "ID");
        ddlscoretype.Items.Insert(0, "All");
        ddlscoretype.SelectedIndex = 0;
    }
    
    private void StudentType()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlcustomertypesearch, ds, "Description", "Cust_Grp");
        ddlcustomertypesearch.Items.Insert(0, "All");
        ddlcustomertypesearch.SelectedIndex = 0;
    }
    
    private void Institutetype()
    {
        DataSet ds = ProductController.GetallInstituteType();
        BindDDL(ddlinstitutionsearch, ds, "Description", "ID");
        ddlinstitutionsearch.Items.Insert(0, "All");
        ddlinstitutionsearch.SelectedIndex = 0;
    }
    
    protected void ddlinstitutionsearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutionsearch.SelectedValue);
        BindDDL(ddlstandardsearch, ds, "Description", "ID");
        this.ddlstandardsearch.Items.Insert(0, "All");
        this.ddlstandardsearch.SelectedIndex = 0;
    }

    private void Board()
    {
        DataSet ds = ProductController.GetallBoard();
        BindDDL(ddlboardsearch, ds, "Short_Description", "ID");
        ddlboardsearch.Items.Insert(0, "All");
        ddlboardsearch.SelectedIndex = 0;
        BindDDL(ddlboardsearch2, ds, "Short_Description", "ID");
        ddlboardsearch2.Items.Insert(0, "All");
        ddlboardsearch2.SelectedIndex = 0;

        ddlstandardsearch2.Items.Insert(0, "All");
        ddlstandardsearch2.SelectedIndex = 0;

    }

    private void Yearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlyearsearch, ds, "Description", "ID");
        ddlyearsearch.Items.Insert(0, "All");
        ddlyearsearch.SelectedIndex = 0;
    }

    private void CountrySearch()
    {
        DataSet ds = ProductController.GetallCountry();
        BindDDL(ddlcountrysearch, ds, "Country_Name", "Country_Code");
        ddlcountrysearch.Items.Insert(0, "All");
        ddlcountrysearch.SelectedIndex = 0;
        ddlstatesearch.Items.Insert(0, "All");
        ddlstatesearch.SelectedIndex = 0;
        ddlcitysearch.Items.Insert(0, "All");
        ddlcitysearch.SelectedIndex = 0;
        ddllocationsearch.Items.Insert(0, "All");
        ddllocationsearch.SelectedIndex = 0;
    }

    protected void ddlcountrysearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStateSearch();
    }
    protected void ddlstatesearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCitySearch();
    }

    protected void ddlcitysearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindLocationSearch();
    }


    private void BindStateSearch()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlcountrysearch.SelectedValue);
        BindDDL(ddlstatesearch, ds, "State_Name", "State_Code");
        ddlstatesearch.Items.Insert(0, "Select");
        ddlstatesearch.SelectedIndex = 0;
    }
    private void BindCitySearch()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlstatesearch.SelectedValue);
        BindDDL(ddlcitysearch, ds, "City_Name", "City_Code");
        ddlcitysearch.Items.Insert(0, "Select");
        ddlcitysearch.SelectedIndex = 0;
    }
    private void BindLocationSearch()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcitysearch.SelectedValue);
        BindDDL(ddllocationsearch, ds, "Location_Name", "Location_Code");
        ddllocationsearch.Items.Insert(0, "All");
        ddllocationsearch.SelectedIndex = 0;
    }
    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindAcademicYear();
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear();
        //DataSet ds = ProductController.GetAcademicYearbyCenter(ddlcenter.SelectedValue);
        BindDDL(ddlacadyearsearch, ds, "Acad_Year", "Acad_Year");
        ddlacadyearsearch.Items.Insert(0, "Select");
        ddlacadyearsearch.SelectedIndex = 0;
    }
    protected void ddlacadyearsearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
    }
    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear(ddlcenter.SelectedValue, ddlacadyearsearch.SelectedValue);
        BindDDL(ddlstreamsearch, ds, "Stream_Sdesc", "Stream_Code");
        ddlstreamsearch.Items.Insert(0, "All");
        ddlstreamsearch.SelectedIndex = 0;
    }

    private void BindProductCategory()
    {
        DataSet ds = ProductController.GetallOpporProductCategory();
        BindDDL(ddlproductcategory, ds, "Description", "ID");
        ddlproductcategory.Items.Insert(0, "All");
        ddlproductcategory.SelectedIndex = 0;
    }
    private void BindSalesStage()
    {
        DataSet ds = ProductController.GetallSalesStage();
        BindDDL(ddlsalesstage, ds, "Sales_Stage_Desc", "Sales_Id");
        ddlsalesstage.Items.Insert(0, "All");
        ddlsalesstage.SelectedIndex = 0;
    }
    private void BindOpporStatus()
    {
        DataSet ds = ProductController.GetallLeadStatus();
        BindDDL(ddlstatus, ds, "Description", "ID");
        ddlstatus.Items.Insert(0, "All");
        ddlstatus.SelectedIndex = 0;
    }
    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
        ddlcompany.Items.Insert(0, "All");
        ddlcompany.SelectedIndex = 0;
        ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;
        ddlzone.Items.Insert(0, "All");
        ddlzone.SelectedIndex = 0;
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
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
        ddlzone.Items.Insert(0, "All");
        ddlzone.SelectedIndex = 0;
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

        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
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
    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDivision();
    }
    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
    }
    protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }
    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            
            int area_rank = 0;
            int overall_rank = 0;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Company = ddlcompany.SelectedValue;
            string Division = ddldivision.SelectedValue;
            string Zone = ddlzone.SelectedValue;
            string Center = ddlcenter.SelectedValue;
            string customer_type = ddlcustomertypesearch.SelectedValue;
            string institution_type = ddlinstitutionsearch.SelectedValue;
            string board_id = ddlboardsearch.SelectedValue;
            string standard = ddlstandardsearch.SelectedValue;
            string name = txtstudentname.Text;
            string mobile = txthandphonesearch.Text;
            string country = ddlcountrysearch.SelectedValue;
            string state = ddlstatesearch.SelectedValue;
            string city = ddlcitysearch.SelectedValue;
            string location = ddllocationsearch.SelectedValue;
            string acadyear = ddlacadyearsearch.SelectedValue;
            string productcategory = ddlproductcategory.SelectedValue;
            string Stream = ddlstreamsearch.SelectedValue;
            string application_form_no = txtadmissionformno.Text;
            string salesstage = ddlsalesstage.SelectedValue;
            string opp_from = txtoppcreatedfrm.Text;
            string opp_to = txtoppcreatedto.Text;
            string followup_from = txtfollowupfrm.Text;
            string followup_to = txtfollowupto.Text;
            string followup_overdue = "1";
            if (chkfollowup.Checked == true)
            {
                followup_overdue = "1";
            }
            else
            {
                followup_overdue = "0";
            }

            string last_followupoverdays = txtlastfollowoverdays.Text;
            string joining_from = txtexpecjoindatefrm.Text;
            string joining_to = txtexpecjoindateto.Text;
            string boardid = ddlboardsearch2.SelectedValue;
            string Year = ddlyearsearch.SelectedValue;
            string agg_score = txtaggrescore.Text;
            if (string.IsNullOrEmpty(txtxarearank.Text))
            {
                area_rank = 0;
            }
            else
            {
                area_rank = int.Parse(txtxarearank.Text);
            }
            if (string.IsNullOrEmpty(txtoverallrank.Text))
            {
                overall_rank = 0;
            }
            else
            {
                overall_rank = int.Parse(txtoverallrank.Text);
            }

            //string Scoretype = "";
            //string Condition = "";
            //string Score = "";

            string Scoretype = ddlscoretype.SelectedValue;
            string Condition = ddlcondition.SelectedValue;
            string Score = txtscore.Text;

            //string Agefrom = "";
            //string Ageto = "";
            //string block = "";
            ////Dim Onlyblock As String = ""
            //string Examinationdetails = "";
            //string Stage = "";


            string Agefrom = txtagefrom.Text;
            string Ageto = txtageto.Text;
            string block = ddlblocked.SelectedValue;
            string Examinationdetails = txtexamsearch.Text;
            string Stage = dlsearchstage.SelectedValue;
            //string Gender = "";
            string Gender = ddlgendersearch.SelectedValue;

            string Orderby = "";
            DataSet ds = UserController.Get_Opportunity_Search_Results_New(Company, Division, Zone, Center, customer_type, institution_type, board_id, standard, name, mobile,
            country, state, city, location, acadyear, productcategory, Stream, application_form_no, salesstage, opp_from,
            opp_to, followup_from, followup_to, followup_overdue, last_followupoverdays, joining_from, joining_to, boardid, Year, agg_score,
            area_rank, overall_rank, UserID, Scoretype, Condition, Score, Agefrom, Ageto, block, Examinationdetails,
            Stage, Gender, Orderby);

            if (ds.Tables[0].Rows.Count > 0)
            {
                divsearchresults.Visible = true;
                Divsearchcriteria.Visible = false;
                lblpagetitle1.Text = "Manage Order";
                lblpagetitle2.Text = "Order Search Results";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Order";
                lilastbreadcrumb.Visible = false;
                lbllastbreadcrumb.Text = " Order Search Results";
                //lilastbreadcrumb.Visible = true;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divsearchresults.Visible = true;
                divmessage.Visible = false;
                //System.Threading.Thread.Sleep(100)
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                btnback.Visible = false;
                divinfo.Visible = false;
                btnsearchback.Visible = true;
            }
            else
            {
                divsearchresults.Visible = false;
                divmessage.Visible = true;
                lblmessage.Text = "No Records Found!";
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "No Records Found! Please check your search criteria";
            }
            //divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void btnadd2_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Opportunity_Add.aspx");
    }

    private void ClearAddPanel()
    {
        txtConapp.Text = "";
        txtconAppentrydate.Text = "";
        txtconappsubdate.Text = "";
        txtconstdname.Text = "";
        //ddlconCompany.SelectedIndex = 0;
        //ddlcondivision.SelectedIndex = 0;
        //ddlstay.SelectedIndex = 0;
        //ddlconyearofpassing.SelectedIndex = 0;
        //ddlconcenter.SelectedIndex = 0;
        //ddlconacademicyear.SelectedIndex = 0;
        //ddlconstream.SelectedIndex = 0;
        txtopportunitycode.Text = "";
        //ddltransport.SelectedIndex = 0;
        // ddlpayplan.SelectedIndex = 0;
        //ddlConmediumofinstr.SelectedIndex = 0;
        //ddlnationality.SelectedIndex = 0;
        //ddlmothertongue.SelectedIndex = 0;
        //ddlreligion.SelectedIndex = 0;
        //ddlcaste.SelectedIndex = 0;
        txtconsubcaste.Text = "";
        //ddlgroup.SelectedIndex = 0;
        //ddlstudentfrom.SelectedIndex = 0;
        //ddlphysicalchallenged.SelectedIndex = 0;
        ddlpayplan.Enabled = true;

        dlproductHeader.DataSource = null;
        dlproductHeader.DataBind();

        //ddllanguage.SelectedIndex = 0;
        txtLangvalue.Text = "";
        txtmandateSubjects.Text = "";
        // lblmaterialcode.Text = "";
        txtvalue.Text = "";

        dlselective.DataSource = null;
        dlselective.DataBind();

        lblsuccesssub.Text = "";

        dlppheader.DataSource = null;
        dlppheader.DataBind();
        lbloppid.Text = "";


    }

    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Display")
        {
            //System.Threading.Thread.Sleep(100);
            string Oppur_Id = e.CommandArgument.ToString();
            Response.Redirect("Opportunity_Display.aspx?&Oppur_ID=" + Oppur_Id);
        }
        else if (e.CommandName == "Edit")
        {
            //System.Threading.Thread.Sleep(100);
            string Oppur_id = e.CommandArgument.ToString();
            Response.Redirect("Opportunity_Edit.aspx?&Oppur_ID=" + Oppur_id);
        }
        else if (e.CommandName == "Followup")
        {
            //System.Threading.Thread.Sleep(100);
            string Oppur_id = e.CommandArgument.ToString();
            Response.Redirect("Opportunity_Followup.aspx?&Oppur_ID=" + Oppur_id);
        }
        else if (e.CommandName == "Block")
        {
            lblnote.Text = "You are about to block a Opportunity. Please confirm.";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#Blocklead').modal('show') });</script>", false);
            string Opporid = e.CommandArgument.ToString();
            lbloppid1.Text = Opporid;
        }
        else if (e.CommandName == "Formsubmit")
        {
            System.Threading.Thread.Sleep(100);
            string Oppur_id = e.CommandArgument.ToString();
            Response.Redirect("Enrollment.aspx?&Oppur_ID=" + Oppur_id);
        }
        else if (e.CommandName == "Displayenrol")
        {
            System.Threading.Thread.Sleep(100);
            string Oppur_id = e.CommandArgument.ToString();
            Response.Redirect("Enrollment_Display.aspx?&Oppur_ID=" + Oppur_id);
        }
        else if (e.CommandName == "Editenrol")
        {
            System.Threading.Thread.Sleep(100);
            string Oppur_id = e.CommandArgument.ToString();
            Response.Redirect("Enrollment_Edit.aspx?&Oppur_ID=" + Oppur_id);
        }
        else if (e.CommandName == "FollowupEnroll")
        {
            System.Threading.Thread.Sleep(100);
            string Oppur_id = e.CommandArgument.ToString();
            Response.Redirect("Opportunity_Followup.aspx?&Oppur_ID=" + Oppur_id);
        }
        else if (e.CommandName == "Convert")
        {
            try
            {
                //System.Threading.Thread.Sleep(100)
                lblpagetitle1.Text = "Create Order";
                lblpagetitle2.Text = "";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Order";
                //lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Text = "Create Order";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                upnlconvert.Visible = true;
                divSearch.Visible = false;
                btnviewenrollment.Disabled = false;
                btnback.Visible = true;

                ClearAddPanel();
                string Oppid = ((LinkButton)e.Item.FindControl("lnkdisplay")).CommandArgument;
                lbloppid.Text = Oppid;
                ProductController.Removerecordsifexists(Oppid, 1, "", "");
                HtmlAnchor viewenrollment = btnviewenrollment;
                viewenrollment.HRef = "Enrollment_display.aspx?&Oppur_id=" + Oppid;

                BindStudentdetails(Oppid);
                Session["Opp_id"] = Oppid;
                //divcreatebutton.Visible = False
                //div5.Visible = False
                div5.Visible = true;
                divcreatebutton.Visible = true;
                btncreateaccount.Enabled = true;
                //Dim oppid As String = ""
                //oppid = lbloppid.Text

                //Important Do forget to uncomment
                BindConvert(Oppid);
                BindMandateSubjects();
                BindCompulsorySubjects();
                BindOptionalSubject();
                BindPayplan();

                divcreatebutton.Visible = false;
                Divreselect.Visible = false;
                Div6.Visible = true;
                //divfeedetails.Visible = False
                divbtnexit.Visible = false;
                btnclose.Visible = false;
                divErrormessage.Visible = false;

            }
            catch (Exception ex)
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = ex.Message;
                Response.Redirect("Errorpages/500.aspx");
            }
        }
        else if (e.CommandName == "UnBlock")
        {
            lblnote1.Text = "You are about to Unblock a Opportunity. Please confirm.";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#UnBlocklead').modal('show') });</script>", false);
            string Opportunityid = e.CommandArgument.ToString();
            lbloppurid.Text = Opportunityid;

        }
        else if (e.CommandName == "Convert_MT")
        {
            System.Threading.Thread.Sleep(100);
            lblpagetitle1.Text = "Convert to Account";
            lblpagetitle2.Text = "";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Opportunity";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = "Convert to Account";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            //UpnlAdd.Visible = False
            upnlconvert.Visible = false;
            divSearch.Visible = false;
            div_ConvertMT.Visible = true;
            string Oppid = ((LinkButton)e.Item.FindControl("lnkdisplay")).CommandArgument;
            BindConvertMT(Oppid);
            lbloppid.Text = Oppid;
            upnlconvertMT.Update();
        }
    }

    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //If lblusercompany.Text = "MPUC" Then
            string Isactive = ((Label)e.Item.FindControl("lblisactive")).Text;
            if (Isactive == "1")
            {
                ((LinkButton)e.Item.FindControl("lnkunblock")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkoppednrol")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnldisplayenrol")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkeditenroll")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkconvert")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkfollowupenroll")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkblockenroll")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkformsubmit")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkdisplay")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkfollowup")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
                ((HtmlAnchor)e.Item.FindControl("btndisplay")).Visible = false;
                ((HtmlAnchor)e.Item.FindControl("btndedit")).Visible = false;
                ((HtmlAnchor)e.Item.FindControl("btnfollowup")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkconvertmt")).Visible = false;
                ((HtmlAnchor)e.Item.FindControl("btndisplayenroll")).Visible = false;
                ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;
            }
            else
            {
                ((LinkButton)e.Item.FindControl("lnkunblock")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkdisplay")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkfollowup")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkconvertmt")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkoppednrol")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkconvertmt")).Visible = false;
                ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
                scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkconvert"));
                scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkeditenroll"));
                //scriptManager__1.RegisterPostBackControl(DirectCast(e.Item.FindControl("lnkblock"), LinkButton))
                //Dim followupdate As String = DirectCast(e.Item.FindControl("Label6"), Label).Text
                //If followupdate = "" Then
                //    DirectCast(e.Item.FindControl("label8"), Label).Visible = True
                //Else
                //    If CDate(ClsCommon.FormatDate(followupdate)) <= Today Then
                //        DirectCast(e.Item.FindControl("label8"), Label).Visible = True
                //        'Get Open days
                //        Dim startDate As Date = Today 'DateTime.Now.ToString("dd/MM/yyyy")
                //        Dim enddate As DateTime = CDate(ClsCommon.FormatDate(followupdate))
                //        Dim ts As TimeSpan = startDate.Subtract(enddate)
                //        Dim dob As String = ""
                //        dob = ts.Days.ToString()
                //        'Dim var As Integer
                //        'var = Math.Truncate(dob / 365)
                //        DirectCast(e.Item.FindControl("Label5"), Label).Text = dob
                //    Else
                //        DirectCast(e.Item.FindControl("label8"), Label).Visible = False
                //    End If
                //End If

                string Opendays = ((Label)e.Item.FindControl("Label9")).Text;
                if (string.IsNullOrEmpty(Opendays))
                {
                    ((Label)e.Item.FindControl("Label5")).Visible = false;
                }
                else
                {
                    //(Convert.ToDateTime(ClsCommon.FormatDate(followupdate)) <= DateTime.Today)
                    if (Convert.ToDateTime(ClsCommon.FormatDate(Opendays)) < DateTime.Today)
                    {
                        ((Label)e.Item.FindControl("Label5")).Visible = true;
                        //Get Open days
                        System.DateTime startDate = DateTime.Today;
                        //DateTime.Now.ToString("dd/MM/yyyy")
                        DateTime enddate = Convert.ToDateTime(ClsCommon.FormatDate(Opendays));
                        TimeSpan ts = startDate.Subtract(enddate);
                        string od = "";
                        od = ts.Days.ToString();
                        ((Label)e.Item.FindControl("Label5")).Text = od;
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("Label5")).Text = "0";
                    }
                }

                string SalesStage = ((Label)e.Item.FindControl("Label7")).Text;
                if (SalesStage == "Closed Lost" | SalesStage == "Closed Won")
                {
                    ((Label)e.Item.FindControl("Label7")).Visible = true;
                    //DirectCast(e.Item.FindControl("label8"), Label).Visible = False
                }
                else
                {
                    ((Label)e.Item.FindControl("Label7")).Visible = true;
                }
                ((LinkButton)e.Item.FindControl("lnkoppednrol")).Visible = true;
                string Oppid = ((LinkButton)e.Item.FindControl("lnkdisplay")).CommandArgument;
                string CheckEdit = "";
                string CheckEnrol = "";
                CheckEdit = ClsEnrollment.CheckStudentInfobyOppid(Oppid);
                if (CheckEdit == "1")
                {
                    ((LinkButton)e.Item.FindControl("lnkoppednrol")).Visible = true;
                    ((LinkButton)e.Item.FindControl("lnldisplayenrol")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lnkeditenroll")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lnkconvert")).Visible = true;
                    ((LinkButton)e.Item.FindControl("lnkfollowupenroll")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lnkblockenroll")).Visible = false;

                    ((HtmlAnchor)e.Item.FindControl("btndisplayenroll")).Visible = false;
                    ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;

                    ((LinkButton)e.Item.FindControl("lnkformsubmit")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lnkdisplay")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lnkfollowup")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;


                    ((HtmlAnchor)e.Item.FindControl("btndisplay")).Visible = true;
                    ((HtmlAnchor)e.Item.FindControl("btndedit")).Visible = true;
                    ((HtmlAnchor)e.Item.FindControl("btnfollowup")).Visible = true;

                }
                else
                {
                    CheckEnrol = ClsEnrollment.CheckStudentApplicationidbyOpporid(Oppid);
                    if (CheckEnrol == "0")
                    {
                        ((LinkButton)e.Item.FindControl("lnkoppednrol")).Visible = false;
                        //DirectCast(e.Item.FindControl("lblopporenr"), Label).Text = "O"
                        //DirectCast(e.Item.FindControl("lblopporenr"), Label).BackColor = Drawing.Color.Beige
                        ((LinkButton)e.Item.FindControl("lnkeditenroll")).Visible = false;
                        ((LinkButton)e.Item.FindControl("lnkconvert")).Visible = false;
                        ((LinkButton)e.Item.FindControl("lnkblockenroll")).Visible = false;
                        ((LinkButton)e.Item.FindControl("lnldisplayenrol")).Visible = false;
                        ((HtmlAnchor)e.Item.FindControl("btndisplayenroll")).Visible = false;
                        ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;

                        ((LinkButton)e.Item.FindControl("lnkformsubmit")).Visible = false;
                        ((LinkButton)e.Item.FindControl("lnkdisplay")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkfollowup")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkfollowupenroll")).Visible = false;
                    }
                    else
                    {
                        ((LinkButton)e.Item.FindControl("lnkeditenroll")).Visible = false;
                        ((LinkButton)e.Item.FindControl("lnkconvert")).Visible = false;
                        ((LinkButton)e.Item.FindControl("lnkblockenroll")).Visible = false;
                        ((LinkButton)e.Item.FindControl("lnldisplayenrol")).Visible = false;
                        ((HtmlAnchor)e.Item.FindControl("btndisplayenroll")).Visible = false;
                        ((HtmlAnchor)e.Item.FindControl("btneditenroll")).Visible = false;

                        ((LinkButton)e.Item.FindControl("lnkoppednrol")).Visible = false;
                        ((LinkButton)e.Item.FindControl("lnkformsubmit")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkdisplay")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkfollowup")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
                        ((LinkButton)e.Item.FindControl("lnkfollowupenroll")).Visible = false;
                        //DirectCast(e.Item.FindControl("lnkoppednrol"), LinkButton).Visible = True
                    }
                }

                //Else
                //DirectCast(e.Item.FindControl("lnkdisplay"), LinkButton).Visible = False
                //DirectCast(e.Item.FindControl("lnkedit"), LinkButton).Visible = False
                //DirectCast(e.Item.FindControl("lnkfollowup"), LinkButton).Visible = False
                //DirectCast(e.Item.FindControl("lnkconvertmt"), LinkButton).Visible = False
                //DirectCast(e.Item.FindControl("lnkblock"), LinkButton).Visible = False
                //Dim scriptManager__1 As ScriptManager = ScriptManager.GetCurrent(Me.Page)
                //scriptManager__1.RegisterPostBackControl(DirectCast(e.Item.FindControl("lnkconvertmt"), LinkButton))

                //DirectCast(e.Item.FindControl("lnldisplayenrol"), LinkButton).Visible = False
                //DirectCast(e.Item.FindControl("lnkeditenroll"), LinkButton).Visible = False
                //DirectCast(e.Item.FindControl("lnkconvert"), LinkButton).Visible = False
                //DirectCast(e.Item.FindControl("lnkblockenroll"), LinkButton).Visible = False
                //DirectCast(e.Item.FindControl("lnkformsubmit"), LinkButton).Visible = False
                //End If
            }
        }
    }

    protected void ddltransport_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddltransport.SelectedIndex == 0)
        {
            div5.Visible = true;
            divcreatebutton.Visible = true;
        }
        else
        {
            div5.Visible = true;
            string oppid = "";
            oppid = lbloppid.Text;
            BindConvert(oppid);
            BindMandateSubjects();
            BindCompulsorySubjects();
            BindOptionalSubject();
            BindPayplan();
            divcreatebutton.Visible = false;
        }

    }
    
    private void BindConvertMT(string Oppid)
    {
        string Opporid = Oppid;
        string Hiphen = "-";
        SqlDataReader dr = ProductController.GetOppordetailsbyOpporid(Opporid);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtproductcategory1.Text = dr["ProductCategory"].ToString();
                txtsalesstage1.Text = dr["SalesStagedesc"].ToString();
                txtcontactname1.Text = dr["Studentname"].ToString();
                lblstudentname.Text = Hiphen + " " + dr["Studentname"].ToString();
                txthandphone11.Text = dr["handphone1"].ToString();
                txtlandline1.Text = dr["landline"].ToString();
                txtjoindate1.Text = dr["Opp_Join_Date_Con"].ToString();
                txtexpectedate1.Text = dr["Opp_Expected_Close_Date_Con"].ToString();
                txtprobpercent1.Text = dr["Opp_Probability_Percent"].ToString();
                txtstudenttype.Text = dr["Category_Type"].ToString();
            }
        }
    }

    private void GetOppid(string Oppid)
    {
        string Opp_id = "";
        Opp_id = Oppid;
    }

    private void BindStudentdetails(string Oppid)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Hiphen = "-";
        SqlDataReader dr = AccountController.GetStudentDetailsbyOppid(Oppid);
        try
        {
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    lblstudentname.Visible = true;
                    txtConapp.Text = dr["student_app_no"].ToString();
                    txtconAppentrydate.Text = dr["entrydate"].ToString();
                    txtconappsubdate.Text = dr["enrollon"].ToString();
                    txtconstdname.Text = dr["Name"].ToString();
                    lblstudentname.Text = Hiphen + " " + dr["Name"].ToString();
                    BindNationality();

                    if (dr["nationality"].ToString() == "")
                    {
                        ddlnationality.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlnationality.SelectedValue = dr["nationality"].ToString();
                    }

                    BindMothertongue();
                    if (dr["mother_tongue"].ToString() == "")
                    {
                        ddlmothertongue.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlmothertongue.SelectedValue = dr["mother_tongue"].ToString();
                    }
                    BindReligion();
                    if (dr["religion"].ToString() == "")
                    {
                        ddlreligion.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlreligion.SelectedValue = dr["religion"].ToString();
                    }
                    BindCaste();
                    if (dr["caste"].ToString() == "")
                    {
                        ddlcaste.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlcaste.SelectedValue = dr["caste"].ToString();
                    }

                    txtconsubcaste.Text = dr["subcaste"].ToString();

                    Bindgroup();
                    if (dr["category"].ToString() == "")
                    {
                        ddlgroup.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlgroup.SelectedValue = dr["category"].ToString();
                    }

                    string PhysicallyChalleged = dr["physically_challenege"].ToString();
                    if (PhysicallyChalleged == "Y")
                    {
                        ddlphysicalchallenged.SelectedValue = "Y";
                    }
                    else
                    {
                        ddlphysicalchallenged.SelectedValue = "N";
                    }

                    BindStudentfrom();
                    if (dr["student_from"].ToString() == "")
                    {
                        ddlstudentfrom.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlstudentfrom.SelectedValue = dr["student_from"].ToString();
                    }

                    BindmediumofInstruction();
                    if (dr["medium_instructions"].ToString() == "")
                    {
                        ddlConmediumofinstr.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlConmediumofinstr.SelectedValue = dr["medium_instructions"].ToString();
                    }


                    BindConYearofpassing();
                    if (dr["year_passing"].ToString() == "")
                    {
                        ddlconyearofpassing.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlconyearofpassing.SelectedValue = dr["year_passing"].ToString();
                    }

                    BindConCompany();
                    if (dr["company_code"].ToString() == "")
                    {
                        ddlconCompany.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlconCompany.SelectedValue = dr["company_code"].ToString();
                    }

                    BindConDivision();
                    if (dr["division_code"].ToString() == "")
                    {
                        ddlcondivision.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlcondivision.SelectedValue = dr["division_code"].ToString();
                    }

                    BindConcenters();
                    if (dr["center_code"].ToString() == "")
                    {
                        ddlconcenter.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlconcenter.SelectedValue = dr["center_code"].ToString();
                    }

                    BindConAcademicYear();
                    if (dr["acad_year"].ToString() == "")
                    {
                        ddlconacademicyear.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlconacademicyear.SelectedValue = dr["acad_year"].ToString();
                    }

                    BindConstream();
                    if (dr["stream_code"].ToString() == "")
                    {
                        ddlconstream.SelectedIndex = 0;
                    }
                    else
                    {
                        try
                        {
                            ddlconstream.SelectedValue = dr["stream_code"].ToString();

                        }
                        catch (Exception ex)
                        {
                            lblcoursedurationover.Text = "Course Duration has Ended for selected student";
                        }
                    }
                    txtopportunitycode.Text = Oppid;

                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }

    }

    private void BindConYearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlconyearofpassing, ds, "Description", "ID");
        ddlconyearofpassing.Items.Insert(0, "Select");
        ddlconyearofpassing.SelectedIndex = 0;
    }

    private void BindConCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlconCompany, ds, "Company_Name", "Company_Code");
        ddlconCompany.Items.Insert(0, "Select");
        ddlconCompany.SelectedIndex = 0;
    }

    private void BindConDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlconCompany.SelectedValue);
        BindDDL(ddlcondivision, ds, "Division_Name", "Division_Code");
        ddlcondivision.Items.Insert(0, "Select");
        ddlcondivision.SelectedIndex = 0;
    }

    private void BindConcenters()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlcondivision.SelectedValue, "", ddlconCompany.SelectedValue);
        BindDDL(ddlconcenter, ds, "Center_name", "Center_Code");
        ddlconcenter.Items.Insert(0, "Select");
        ddlconcenter.SelectedIndex = 0;
    }

    private void BindConAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddlconcenter.SelectedValue);
        BindDDL(ddlconacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlconacademicyear.Items.Insert(0, "Select");
        ddlconacademicyear.SelectedIndex = 0;
    }

    private void BindConstream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear(ddlconcenter.SelectedValue, ddlconacademicyear.SelectedValue);
        BindDDL(ddlconstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlconstream.Items.Insert(0, "Select");
        ddlconstream.SelectedIndex = 0;

    }

    private void Bindstay()
    {
        DataSet ds = ProductController.GetallStay();
        BindDDL(ddlstay, ds, "Description", "id");
        ddlstay.Items.Insert(0, "Select");
        ddlstay.SelectedIndex = 0;
    }
    
    private void BindmediumofInstruction()
    {
        DataSet ds = ProductController.GetallMediumofInstruction();
        BindDDL(ddlConmediumofinstr, ds, "Description", "id");
        ddlConmediumofinstr.Items.Insert(0, "Select");
        ddlConmediumofinstr.SelectedIndex = 0;
    }

    private void BindStudentfrom()
    {
        DataSet ds = ProductController.GetallResidenceType();
        BindDDL(ddlstudentfrom, ds, "Description", "ID");
        ddlstudentfrom.Items.Insert(0, "Select");
        ddlstudentfrom.SelectedIndex = 0;
    }

    private void BindNationality()
    {
        DataSet ds = ProductController.GetallNationality();
        BindDDL(ddlnationality, ds, "Description", "id");
        ddlnationality.Items.Insert(0, "Select");
        ddlnationality.SelectedIndex = 0;
    }

    private void BindMothertongue()
    {
        DataSet ds = ProductController.GetallMothertongue();
        BindDDL(ddlmothertongue, ds, "Description", "id");
        ddlmothertongue.Items.Insert(0, "Select");
        ddlmothertongue.SelectedIndex = 0;
    }

    private void BindReligion()
    {
        DataSet ds = ProductController.GetallReligion();
        BindDDL(ddlreligion, ds, "Description", "id");
        ddlreligion.Items.Insert(0, "Select");
        ddlreligion.SelectedIndex = 0;
    }

    private void BindCaste()
    {
        DataSet ds = ProductController.GetallCaste();
        BindDDL(ddlcaste, ds, "Description", "id");
        ddlcaste.Items.Insert(0, "Select");
        ddlcaste.SelectedIndex = 0;
    }

    private void Bindgroup()
    {
        DataSet ds = ProductController.GetallStudentcastegroup();
        BindDDL(ddlgroup, ds, "Description", "id");
        ddlgroup.Items.Insert(0, "Select");
        ddlgroup.SelectedIndex = 0;
    }

    private void BindPayplan()
    {
        DataSet ds = AccountController.GetAllPayplan();
        BindDDL(ddlpayplan, ds, "Pay_Plan_Description", "Pay_Plan_Code");
        ddlpayplan.Items.Insert(0, "Select");
        ddlpayplan.SelectedIndex = 0;
    }

    protected void ddlpayplan_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlpayplan.SelectedValue == "Select")
        {
            dlselective.Enabled = false;
        }
        else
        {
            dlselective.Enabled = true;
        }
    }

    private void GetSumvalue()
    {

        try
        {

            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            Label lblsid = default(Label);
            Label lblbaseuomid = default(Label);
            Label lblselgroup = default(Label);
            Label lblvouchermode = default(Label);
            RequiredFieldValidator regularvalidator = default(RequiredFieldValidator);
            RequiredFieldValidator r2 = default(RequiredFieldValidator);
            CompareValidator C1 = default(CompareValidator);
            TextBox lblquantity = default(TextBox);
            TextBox lblvoucheramt = default(TextBox);
            TextBox lblamt = default(TextBox);
            TextBox txttotal = default(TextBox);
            DropDownList ddluom1 = default(DropDownList);
            string Totalvalue = "";
            int Sum = 0;
            int Count = 0;
            //Dim Quant As TextBox

            foreach (DataListItem li in dlselective.Items)
            {
                obj = li.FindControl("ckhselect1");
                if (obj != null)
                {
                    chk = (CheckBox)obj;
                }

                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblsid = (Label)obj;
                }

                obj = li.FindControl("txtquantity");
                if (obj != null)
                {
                    lblquantity = (TextBox)obj;
                    try
                    {
                        int.Parse(lblquantity.Text);

                    }
                    catch (Exception ex)
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Quantity can only be in Number";
                    }
                }

                obj = li.FindControl("txtvoucheramt");
                if (obj != null)
                {
                    lblvoucheramt = (TextBox)obj;
                }

                obj = li.FindControl("lblbaseuomid");
                if (obj != null)
                {
                    lblbaseuomid = (Label)obj;
                }

                obj = li.FindControl("txttotalvalue");
                if (obj != null)
                {
                    txttotal = (TextBox)obj;
                }

                obj = li.FindControl("ddluom");
                if (obj != null)
                {
                    ddluom1 = (DropDownList)obj;
                    if (ddluom1.SelectedValue == "Select")
                    {
                        lblquantity.Enabled = false;
                    }
                    else
                    {
                        lblquantity.Enabled = true;
                    }
                }

                obj = li.FindControl("lblselgroup");
                if (obj != null)
                {
                    lblselgroup = (Label)obj;
                    if (lblselgroup.Text == "1")
                    {
                        chk.Checked = true;
                        chk.Enabled = false;
                        lblquantity.Enabled = false;
                        if (ddluom1.SelectedValue == "01")
                        {
                            try
                            {
                                int.Parse(lblquantity.Text);
                                Sum = Sum + Convert.ToInt32(lblquantity.Text);
                                string Uomid = "";
                                SqlDataReader dr = ProductController.GetallUomReader(2, ddluom1.SelectedValue);
                                if ((((dr) != null)))
                                {
                                    if (dr.Read())
                                    {
                                        Uomid = dr["UOM_Value"].ToString();
                                    }
                                }
                                Totalvalue = (decimal.Parse(lblvoucheramt.Text) * int.Parse(lblquantity.Text) * int.Parse(Uomid)).ToString();
                                txttotal.Text = Totalvalue;
                            }
                            catch (Exception ex)
                            {
                                divErrormessage.Visible = true;
                                lblerrormessage.Visible = true;
                                lblerrormessage.Text = "Quantity can only be in Number";
                            }

                        }
                        else if (ddluom1.SelectedValue == "02")
                        {
                            Sum = Sum + Convert.ToInt32(lblquantity.Text);
                            string Uomid = "";
                            SqlDataReader dr = ProductController.GetallUomReader(2, ddluom1.SelectedValue);
                            if ((((dr) != null)))
                            {
                                if (dr.Read())
                                {
                                    Uomid = dr["UOM_Value"].ToString();
                                }
                            }
                            Totalvalue = (decimal.Parse(lblvoucheramt.Text) * int.Parse(lblquantity.Text) * int.Parse(Uomid)).ToString();
                            txttotal.Text = Totalvalue;



                        }
                        else if (ddluom1.SelectedValue == "03")
                        {
                            Sum = Sum + Convert.ToInt32(lblquantity.Text);
                            string Uomid = "";
                            SqlDataReader dr = ProductController.GetallUomReader(2, ddluom1.SelectedValue);
                            if ((((dr) != null)))
                            {
                                if (dr.Read())
                                {
                                    Uomid = dr["UOM_Value"].ToString();
                                }
                            }
                            Totalvalue = (decimal.Parse(lblvoucheramt.Text) * int.Parse(lblquantity.Text) * int.Parse(Uomid)).ToString();
                            txttotal.Text = Totalvalue;
                        }

                    }
                }

                obj = li.FindControl("lblvoucher_mode");
                if (obj != null)
                {
                    lblvouchermode = (Label)obj;
                    if (lblvouchermode.Text == "A")
                    {
                        lblvoucheramt.Enabled = false;
                    }
                    else if (lblvouchermode.Text == "M")
                    {
                        lblvoucheramt.Enabled = true;
                    }
                }

                obj = li.FindControl("RequiredFieldValidator35");
                if (obj != null)
                {
                    regularvalidator = (RequiredFieldValidator)obj;
                }

                obj = li.FindControl("r2");
                if (obj != null)
                {
                    r2 = (RequiredFieldValidator)obj;
                }

                obj = li.FindControl("CompareValidator1");
                if (obj != null)
                {
                    C1 = (CompareValidator)obj;
                }

                if (chk.Checked == true)
                {
                    if (lblselgroup.Text == "1")
                    {
                        //ddluom1.Enabled = true;
                        lblvoucheramt.Enabled = false;
                    }
                    else
                    {
                        // ddluom1.Enabled = true;
                        regularvalidator.Visible = true;

                        if (ddluom1.SelectedValue == "Select")
                        {
                            lblquantity.Enabled = false;

                        }
                        else
                        {
                            lblquantity.Enabled = true;
                            r2.Visible = true;
                            C1.Visible = true;
                            if (string.IsNullOrEmpty(lblquantity.Text))
                            {

                            }
                            else
                            {
                                //If ddluom1.SelectedValue = "01" Then

                                Sum = Sum + Convert.ToInt32(lblquantity.Text);
                                string Uomid = "";
                                SqlDataReader dr = ProductController.GetallUomReader(3, ddluom1.SelectedValue);
                                if ((((dr) != null)))
                                {
                                    if (dr.Read())
                                    {
                                        Uomid = dr["UOM_Value"].ToString();
                                    }
                                }
                                Totalvalue = (decimal.Parse(lblvoucheramt.Text) * int.Parse(lblquantity.Text) * int.Parse(Uomid)).ToString();
                                txttotal.Text = Totalvalue;
                            }
                            lblquantity.Enabled = true;
                        }
                    }

                }
                else
                {
                    // ddluom1.Enabled = false;
                    //ddluom1.SelectedIndex = 0;
                    //lblquantity.Text = "0"
                    txttotal.Text = "0";
                    lblquantity.Enabled = false;
                    regularvalidator.Visible = false;
                    r2.Visible = false;
                    C1.Visible = false;
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void dlselective_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int Flag = 2;
            string Uomid = "";
            DropDownList d = (DropDownList)e.Item.FindControl("ddluom");
            Label baseuomid = (Label)e.Item.FindControl("lblbaseuomid");
            DataSet ds = ProductController.GetallUom(Flag, baseuomid.Text);
            BindDDL(d, ds, "UOM_DESC", "UOM_Id");
            d.Items.Insert(0, "Select");
            //d.SelectedIndex = 0;
            d.SelectedValue = "01";

            //Dim Selgroup As Label = DirectCast(e.Item.FindControl("lblselgroup"), Label)
            //Dim Sgrgroup As String = Selgroup.Text
            //If Sgrgroup = "1" Then
            //    Dim Chk As CheckBox = DirectCast(e.Item.FindControl("ckhselect1"), CheckBox)
            //    Chk.Checked = True
            //    Chk.Enabled = False
            //End If


        }
    }

    private void BindConvert(string Oppid)
    {
        string Oppor_id = "";
        Oppor_id = Oppid;
        string Documenttype = "";
        Documenttype = "DC05";
        string Transport = "";
        Transport = "01";
        DataSet ds = AccountController.GetPricingbyOppId(3, Oppor_id, Documenttype, Transport);
        if (ds.Tables[0] != null)
        {
            dlproductHeader.DataSource = ds.Tables[0];
            dlproductHeader.DataBind();

            if (ds.Tables[1].Rows[0]["OrderFlag"].ToString() != "0")
            {
                divErrormessage.Visible = true;
                lblerrormessage.Text = "This opportunity is already converted to Account, heance you cannot proceed";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'This opportunity is already converted to Account, heance you cannot proceed.',class_name: 'gritter-error'});});</script>", false);
                btncontinue.Visible = false;
                btncreateaccount.Visible = false;
            }
        }

    }

    private void BindMandateSubjects()
    {
        
    }

    private void BindCompulsorySubjects()
    {
        
    }

    private void BindOptionalSubject()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string StreamName = "";
        string Center = "";
        StreamName = ddlconstream.SelectedValue;
        Center = ddlconcenter.SelectedValue;

        DataSet ds = ProductController.GetSubjectsbyStreamCode(5, StreamName, Center);
        if (ds.Tables[0] != null)
        {
            dlselective.DataSource = ds;
            dlselective.DataBind();
        }

    }

    protected void ddllanguage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        

    }

    protected void btncontinue_ServerClick(object sender, System.EventArgs e)
    {

        try
        {

            object obj = null;
            CheckBox Chk = default(CheckBox);
            Label lblSelectmaterialcode = default(Label);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            string Sgrcode = "";
            CheckBox cb = default(CheckBox);



            foreach (DataListItem li in dlselective.Items)
            {
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblSelectmaterialcode = (Label)obj;
                }

                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblSelectmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {
                diverrorsubject.Visible = false;
                lblerrorsub.Visible = false;
                divcreatebutton.Visible = true;
                btncreateaccount.Visible = true;
                string Opp_id = "";
                string Doctype = "";
                int Flag = 0;
                Label lblfmaterialcode = null;
                Label lblvouchertype = null;
                TextBox txtvoucheramt = null;
                Label Baseuomdesc = null;
                Label baseuomid = null;
                DropDownList Unit = default(DropDownList);
                TextBox Quantity = null;
                TextBox Amount = null;
                TextBox Remark = null;

                Opp_id = lbloppid.Text; // Session["Opp_id"].ToString();
                Flag = 1;
                Doctype = "DC05";
               
                foreach (DataListItem li in dlselective.Items)
                {
                    obj = li.FindControl("lblmaterialcodeadd");
                    if (obj != null)
                    {
                        lblfmaterialcode = (Label)obj;
                    }

                    obj = li.FindControl("lblvoucher_typ");
                    if (obj != null)
                    {
                        lblvouchertype = (Label)obj;
                    }

                    obj = li.FindControl("txtvoucheramt");
                    if (obj != null)
                    {
                        txtvoucheramt = (TextBox)obj;
                    }

                    obj = li.FindControl("lblbaseuom");
                    if (obj != null)
                    {
                        Baseuomdesc = (Label)obj;
                    }

                    obj = li.FindControl("lblbaseuomid");
                    if (obj != null)
                    {
                        baseuomid = (Label)obj;
                    }

                    obj = li.FindControl("ddluom");
                    if (obj != null)
                    {
                        Unit = (DropDownList)obj;
                    }

                    obj = li.FindControl("txtquantity");
                    if (obj != null)
                    {
                        Quantity = (TextBox)obj;
                    }

                    obj = li.FindControl("txttotalvalue");
                    if (obj != null)
                    {
                        Amount = (TextBox)obj;
                    }

                    obj = li.FindControl("txtremark");
                    if (obj != null)
                    {
                        Remark = (TextBox)obj;
                    }

                    cb = (CheckBox)li.FindControl("ckhselect1");
                    if (cb != null)
                    {
                        Chk = (CheckBox)cb;
                    }

                    if (Chk.Checked == true)
                    {
                        AccountController.InserttoGetPricingprocedurevaluebyoppid(Opp_id, lblfmaterialcode.Text, lblvouchertype.Text, txtvoucheramt.Text, baseuomid.Text, Baseuomdesc.Text, Unit.SelectedValue, Quantity.Text, Amount.Text, Remark.Text,
                        Doctype, Flag);
                    }
                }
               

                int flag2 = 2;
                if (ddlpayplan.SelectedValue == "EMI")
                {
                    flag2 = 3;
                }
                else
                {
                    flag2 = 2;
                }


                DataSet ds = AccountController.GetPricingprocedureHeaderValue_New(Opp_id, Sgrcode, "", "", "", "", "", "", "", "", "DC05", flag2);
                DataSet ds1 = AccountController.GetFeesComponent(1, Opp_id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlppheader.DataSource = ds1;
                    dlppheader.DataBind();
                    ddlpayplan.Enabled = false;
                    ddllanguage.Enabled = false;
                    dlselective.Enabled = false;
                    Divreselect.Visible = true;
                    //divfeedetails.Visible = True
                    btnreselect.Visible = true;
                    Div6.Visible = false;
                    dlppheader.Visible = true;
                    divcreatebutton.Visible = true;
                    DivFeesOffered.Visible = false;
                    //divpersonalinfo.Visible = False
                    if ((ddlcondivision.SelectedValue == "A0") || (ddlcondivision.SelectedValue == "C0") || (ddlcondivision.SelectedValue == "D0"));
                    {
                        DivFeesOffered.Visible = true;
                    }

                }
                else
                {
                    if (ds1.Tables[0] != null)
                    {
                        dlppheader.DataSource = ds1;
                        dlppheader.DataBind();
                    }
                }
            }
            else
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Select Product";
                //diverrorsubject.Visible = True
                //lblerrorsub.Visible = True
                //lblerrorsub.Text = "Select Product"

            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }

    }

    protected void btncreateaccount_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            if ((ddlcondivision.SelectedValue == "A0") || (ddlcondivision.SelectedValue == "C0") || (ddlcondivision.SelectedValue == "D0"))
            {
                if (txtFeeOffered.Text == "")
                {
                    divErrormessage.Visible = true;
                    lblerrormessage.Text = "Kindly Add Offered Fees";                    
                    return;
                }
                else
                {
                    btncreateaccount.Visible = false;
                    string MandateSubjects = "";
                    string OptionalSubjects = "";
                    string Selectivesubjects = "";
                    MandateSubjects = lblmaterialcode.Text;
                    OptionalSubjects = ddllanguage.SelectedValue;
                    object obj = null;
                    CheckBox Chk = default(CheckBox);
                    Label lblSelectmaterialcode = default(Label);
                    List<string> list = new List<string>();
                    List<string> List1 = new List<string>();
                    string Sgrcode = "";
                    CheckBox cb = default(CheckBox);
                    foreach (DataListItem li in dlselective.Items)
                    {
                        obj = li.FindControl("lblmaterialcodeadd");
                        if (obj != null)
                        {
                            lblSelectmaterialcode = (Label)obj;
                        }

                        cb = (CheckBox)li.FindControl("ckhselect1");
                        if (cb != null)
                        {
                            Chk = (CheckBox)cb;
                        }

                        if (Chk.Checked == true)
                        {
                            list.Add(lblSelectmaterialcode.Text);
                            Sgrcode = string.Join(",", list.ToArray());

                        }
                    }
                    if (Sgrcode.Length > 0)
                    {
                        diverrorsubject.Visible = false;
                        lblerrorsub.Visible = false;
                        divcreatebutton.Visible = true;
                        string MaterialCode = "";
                        string Doctype = "";
                        string Opp_id = "";
                        string Payplan = "";
                        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                        string UserID = cookie.Values["UserID"];
                        string UserName = cookie.Values["UserName"];
                        Opp_id = lbloppid.Text;// Session["Opp_id"].ToString();
                        //MaterialCode = MandateSubjects + "," + OptionalSubjects + "," + Sgrcode;
                        MaterialCode = Sgrcode;
                        Doctype = "DC05";
                        Payplan = ddlpayplan.SelectedValue;
                        string Accountid = "";
                        int flag2 = 2;
                        if (ddlpayplan.SelectedValue == "EMI")
                        {
                            flag2 = 3;
                        }
                        else
                        {
                            flag2 = 2;
                        }
                        Accountid = AccountController.CreateAccount(Opp_id, MaterialCode, Doctype, Payplan, UserID, flag2);

                        if (Accountid == "0")
                        {
                            divErrormessage.Visible = true;
                            lblerrormessage.Text = "This opportunity is already converted to Account, hence you cannot proceed";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'This opportunity is allready converted to Account, hence you cannot proceed.',class_name: 'gritter-error'});});</script>", false);
                            btncontinue.Visible = false;
                            btncreateaccount.Visible = false;
                            return;
                        }
                        string SBEntrycode = AccountController.GetSBEntrycodebyOppid(Opp_id);
                        if (SBEntrycode != "")
                        {
                            string receiptid = AccountController.PopulateP01forManageOrder(SBEntrycode);
                            lblsbentrycode.Text = SBEntrycode;
                            int ResultId = 0;
                            ResultId = ProductController.DeleteCheque(txtFeeOffered.Text, SBEntrycode, UserID, "2");
                            if (ResultId == 1)
                            {

                                //lblpendingremarks.Visible = true;
                                //lblpendingremarks.Text = "Remarks Can't be Blank";
                            }
                        }

                    }
                    else
                    {
                        diverrorsubject.Visible = true;
                        lblerrorsub.Visible = true;
                        lblerrorsub.Text = "Select Subject Group";
                    }

                    divSuccessmessage.Visible = true;
                    lblsuccessMessage.Visible = true;
                    lblsuccessMessage.Text = "Order Saved - Proceed to Manage Account";
                    btncreateaccount.Visible = false;
                    btnreselect.Visible = false;
                    divbtnexit.Visible = true;
                    btnclose.Visible = true;
                    divErrormessage.Visible = false;
                    
                }
            }
            else
            {
                {
                    btncreateaccount.Visible = false;
                    string MandateSubjects = "";
                    string OptionalSubjects = "";
                    string Selectivesubjects = "";
                    MandateSubjects = lblmaterialcode.Text;
                    OptionalSubjects = ddllanguage.SelectedValue;
                    object obj = null;
                    CheckBox Chk = default(CheckBox);
                    Label lblSelectmaterialcode = default(Label);
                    List<string> list = new List<string>();
                    List<string> List1 = new List<string>();
                    string Sgrcode = "";
                    CheckBox cb = default(CheckBox);
                    foreach (DataListItem li in dlselective.Items)
                    {
                        obj = li.FindControl("lblmaterialcodeadd");
                        if (obj != null)
                        {
                            lblSelectmaterialcode = (Label)obj;
                        }

                        cb = (CheckBox)li.FindControl("ckhselect1");
                        if (cb != null)
                        {
                            Chk = (CheckBox)cb;
                        }

                        if (Chk.Checked == true)
                        {
                            list.Add(lblSelectmaterialcode.Text);
                            Sgrcode = string.Join(",", list.ToArray());

                        }
                    }
                    if (Sgrcode.Length > 0)
                    {
                        diverrorsubject.Visible = false;
                        lblerrorsub.Visible = false;
                        divcreatebutton.Visible = true;
                        string MaterialCode = "";
                        string Doctype = "";
                        string Opp_id = "";
                        string Payplan = "";
                        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                        string UserID = cookie.Values["UserID"];
                        string UserName = cookie.Values["UserName"];
                        Opp_id = lbloppid.Text;// Session["Opp_id"].ToString();
                        //MaterialCode = MandateSubjects + "," + OptionalSubjects + "," + Sgrcode;
                        MaterialCode = Sgrcode;
                        Doctype = "DC05";
                        Payplan = ddlpayplan.SelectedValue;
                        string Accountid = "";
                        int flag2 = 2;
                        if (ddlpayplan.SelectedValue == "EMI")
                        {
                            flag2 = 3;
                        }
                        else
                        {
                            flag2 = 2;
                        }
                        Accountid = AccountController.CreateAccount(Opp_id, MaterialCode, Doctype, Payplan, UserID, flag2);

                        if (Accountid == "0")
                        {
                            divErrormessage.Visible = true;
                            lblerrormessage.Text = "This opportunity is already converted to Account, hence you cannot proceed";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'This opportunity is allready converted to Account, hence you cannot proceed.',class_name: 'gritter-error'});});</script>", false);
                            btncontinue.Visible = false;
                            btncreateaccount.Visible = false;
                            
                            return;
                        }
                        string SBEntrycode = AccountController.GetSBEntrycodebyOppid(Opp_id);
                        if (SBEntrycode != "")
                        {
                            string receiptid = AccountController.PopulateP01forManageOrder(SBEntrycode);
                            lblsbentrycode.Text = SBEntrycode;
                         
                         
                        }

                    }
                    else
                    {
                        diverrorsubject.Visible = true;
                        lblerrorsub.Visible = true;
                        lblerrorsub.Text = "Select Subject Group";
                    }

                    divSuccessmessage.Visible = true;
                    lblsuccessMessage.Visible = true;
                    lblsuccessMessage.Text = "Order Saved - Proceed to Manage Account";
                    btncreateaccount.Visible = false;
                    btnreselect.Visible = false;
                    divbtnexit.Visible = true;
                    btnclose.Visible = true;
                    divErrormessage.Visible = false;                    
                }


            }

        }

        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    private void createaccount()
    {
        try
        {
            if ((ddlcondivision.SelectedValue == "A0") || (ddlcondivision.SelectedValue == "C0") || (ddlcondivision.SelectedValue == "D0"))
            {
                if (txtFeeOffered.Text == "")
                {
                    divErrormessage.Visible = true;
                    lblerrormessage.Text = "Kindly Add Offered Fees";
                    btncreateaccount.Enabled = true;
                    return;
                }
                else
                {
                    btncreateaccount.Visible = false;
                    string MandateSubjects = "";
                    string OptionalSubjects = "";
                    string Selectivesubjects = "";
                    MandateSubjects = lblmaterialcode.Text;
                    OptionalSubjects = ddllanguage.SelectedValue;
                    object obj = null;
                    CheckBox Chk = default(CheckBox);
                    Label lblSelectmaterialcode = default(Label);
                    List<string> list = new List<string>();
                    List<string> List1 = new List<string>();
                    string Sgrcode = "";
                    CheckBox cb = default(CheckBox);
                    foreach (DataListItem li in dlselective.Items)
                    {
                        obj = li.FindControl("lblmaterialcodeadd");
                        if (obj != null)
                        {
                            lblSelectmaterialcode = (Label)obj;
                        }

                        cb = (CheckBox)li.FindControl("ckhselect1");
                        if (cb != null)
                        {
                            Chk = (CheckBox)cb;
                        }

                        if (Chk.Checked == true)
                        {
                            list.Add(lblSelectmaterialcode.Text);
                            Sgrcode = string.Join(",", list.ToArray());

                        }
                    }
                    if (Sgrcode.Length > 0)
                    {
                        diverrorsubject.Visible = false;
                        lblerrorsub.Visible = false;
                        divcreatebutton.Visible = true;
                        string MaterialCode = "";
                        string Doctype = "";
                        string Opp_id = "";
                        string Payplan = "";
                        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                        string UserID = cookie.Values["UserID"];
                        string UserName = cookie.Values["UserName"];
                        Opp_id = lbloppid.Text;// Session["Opp_id"].ToString();
                        //MaterialCode = MandateSubjects + "," + OptionalSubjects + "," + Sgrcode;
                        MaterialCode = Sgrcode;
                        Doctype = "DC05";
                        Payplan = ddlpayplan.SelectedValue;
                        string Accountid = "";
                        int flag2 = 2;
                        if (ddlpayplan.SelectedValue == "EMI")
                        {
                            flag2 = 3;
                        }
                        else
                        {
                            flag2 = 2;
                        }
                        Accountid = AccountController.CreateAccount(Opp_id, MaterialCode, Doctype, Payplan, UserID, flag2);

                        if (Accountid == "0")
                        {
                            divErrormessage.Visible = true;
                            lblerrormessage.Text = "This opportunity is already converted to Account, hence you cannot proceed";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'This opportunity is allready converted to Account, hence you cannot proceed.',class_name: 'gritter-error'});});</script>", false);
                            btncontinue.Visible = false;
                            btncreateaccount.Visible = false;
                            btncreateaccount.Enabled = true;
                            return;
                        }
                        string SBEntrycode = AccountController.GetSBEntrycodebyOppid(Opp_id);
                        if (SBEntrycode != "")
                        {
                            string receiptid = AccountController.PopulateP01forManageOrder(SBEntrycode);
                            lblsbentrycode.Text = SBEntrycode;
                            int ResultId = 0;
                            ResultId = ProductController.DeleteCheque(txtFeeOffered.Text, SBEntrycode, UserID, "2");
                            if (ResultId == 1)
                            {

                                //lblpendingremarks.Visible = true;
                                //lblpendingremarks.Text = "Remarks Can't be Blank";
                            }
                        }

                    }
                    else
                    {
                        diverrorsubject.Visible = true;
                        lblerrorsub.Visible = true;
                        lblerrorsub.Text = "Select Subject Group";
                    }

                    divSuccessmessage.Visible = true;
                    lblsuccessMessage.Visible = true;
                    lblsuccessMessage.Text = "Order Saved - Proceed to Manage Account";
                    btncreateaccount.Visible = false;
                    btnreselect.Visible = false;
                    divbtnexit.Visible = true;
                    btnclose.Visible = true;
                    divErrormessage.Visible = false;
                    btncreateaccount.Enabled = true;
                }
            }
            else
            {
                {
                    btncreateaccount.Visible = false;
                    string MandateSubjects = "";
                    string OptionalSubjects = "";
                    string Selectivesubjects = "";
                    MandateSubjects = lblmaterialcode.Text;
                    OptionalSubjects = ddllanguage.SelectedValue;
                    object obj = null;
                    CheckBox Chk = default(CheckBox);
                    Label lblSelectmaterialcode = default(Label);
                    List<string> list = new List<string>();
                    List<string> List1 = new List<string>();
                    string Sgrcode = "";
                    CheckBox cb = default(CheckBox);
                    foreach (DataListItem li in dlselective.Items)
                    {
                        obj = li.FindControl("lblmaterialcodeadd");
                        if (obj != null)
                        {
                            lblSelectmaterialcode = (Label)obj;
                        }

                        cb = (CheckBox)li.FindControl("ckhselect1");
                        if (cb != null)
                        {
                            Chk = (CheckBox)cb;
                        }

                        if (Chk.Checked == true)
                        {
                            list.Add(lblSelectmaterialcode.Text);
                            Sgrcode = string.Join(",", list.ToArray());

                        }
                    }
                    if (Sgrcode.Length > 0)
                    {
                        diverrorsubject.Visible = false;
                        lblerrorsub.Visible = false;
                        divcreatebutton.Visible = true;
                        string MaterialCode = "";
                        string Doctype = "";
                        string Opp_id = "";
                        string Payplan = "";
                        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                        string UserID = cookie.Values["UserID"];
                        string UserName = cookie.Values["UserName"];
                        Opp_id = lbloppid.Text;// Session["Opp_id"].ToString();
                        //MaterialCode = MandateSubjects + "," + OptionalSubjects + "," + Sgrcode;
                        MaterialCode = Sgrcode;
                        Doctype = "DC05";
                        Payplan = ddlpayplan.SelectedValue;
                        string Accountid = "";
                        int flag2 = 2;
                        if (ddlpayplan.SelectedValue == "EMI")
                        {
                            flag2 = 3;
                        }
                        else
                        {
                            flag2 = 2;
                        }
                        Accountid = AccountController.CreateAccount(Opp_id, MaterialCode, Doctype, Payplan, UserID, flag2);

                        if (Accountid == "0")
                        {
                            divErrormessage.Visible = true;
                            lblerrormessage.Text = "This opportunity is already converted to Account, hence you cannot proceed";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'This opportunity is allready converted to Account, hence you cannot proceed.',class_name: 'gritter-error'});});</script>", false);
                            btncontinue.Visible = false;
                            btncreateaccount.Visible = false;
                            btncreateaccount.Enabled = true;
                            return;
                        }
                        string SBEntrycode = AccountController.GetSBEntrycodebyOppid(Opp_id);
                        if (SBEntrycode != "")
                        {
                            string receiptid = AccountController.PopulateP01forManageOrder(SBEntrycode);
                            lblsbentrycode.Text = SBEntrycode;


                        }

                    }
                    else
                    {
                        diverrorsubject.Visible = true;
                        lblerrorsub.Visible = true;
                        lblerrorsub.Text = "Select Subject Group";
                    }

                    divSuccessmessage.Visible = true;
                    lblsuccessMessage.Visible = true;
                    lblsuccessMessage.Text = "Order Saved - Proceed to Manage Account";
                    btncreateaccount.Visible = false;
                    btnreselect.Visible = false;
                    divbtnexit.Visible = true;
                    btnclose.Visible = true;
                    divErrormessage.Visible = false;
                    btncreateaccount.Enabled = true;
                }


            }

        }

        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
            btncreateaccount.Enabled = true;
        }
    }

    protected void btncreateaccount_Click(object sender, EventArgs e)
    {
        createaccount();
    }
    protected void btnaccount_ServerClick(object sender, System.EventArgs e)
    {
        txtFeeOffered.Text = "";
        string Opp_id = lbloppid.Text;
        string SBEntrycode = lblsbentrycode.Text;
        if (SBEntrycode != "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('Accounts.aspx?&SBEntryCode=" + SBEntrycode + "','_blank')", true);
        }
    }

    protected void btnpayment_ServerClick(object sender, System.EventArgs e)
    {
        txtFeeOffered.Text = "";
        string Opp_id = lbloppid.Text;
        string SBEntrycode = lblsbentrycode.Text;
        if (SBEntrycode != "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('Receive_Payment.aspx?&Cur_sb_code=" + SBEntrycode + "','_blank')", true);
        }
    }

    protected void btnreselect_ServerClick(object sender, System.EventArgs e)
    {
        ddlpayplan.Enabled = true;
        ddllanguage.Enabled = true;
        dlselective.Enabled = true;
        Divreselect.Visible = false;
        btnreselect.Visible = false;
        Div6.Visible = true;
        dlppheader.Visible = false;
        divcreatebutton.Visible = false;
        ProductController.Removerecordsifexists(lbloppid.Text, 1, "", "");
        //divpersonalinfo.Visible = True
        //divfeedetails.Visible = False
    }

    protected void btnclearmt_ServerClick(object sender, System.EventArgs e)
    {
        //Response.Redirect("Manage_Opportunity.aspx")
        upnlconvert.Visible = false;
        divSearch.Visible = true;
        div_ConvertMT.Visible = false;


    }

    protected void btnconvertmt_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Opporid = lbloppid.Text;
        string sbentrycode = "";
        DateTime AccountConvertDate = default(DateTime);
        string notes = "";
        string Createdby = "";
        string Modifiedby = "";
        string Accountid = "";

        sbentrycode = txtsbentrycode.Text;
        AccountConvertDate = Convert.ToDateTime(txtaccountdate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
        notes = txtnotes.Text;
        Createdby = UserID;

        Accountid = ProductController.InsertAccount("", Opporid, sbentrycode, AccountConvertDate, notes, Createdby, Modifiedby);
        divSuccessmessage.Visible = true;
        lblsuccessMessage.Text = "Order Saved - Proceed to Manage Account";
        txtsbentrycode.Text = "";
        txtnotes.Text = "";
        btnconvertmt.Visible = false;
        btnclearmt.Visible = false;
        txtaccountdate.Text = "";
        upnlconvert.Visible = false;
    }

    protected void btncloseleadblock_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#Blocklead').modal('hide') });</script>", false);
    }

    protected void btnblocklead_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Opporid = "";
        int flag = 0;
        Opporid = lbloppid1.Text;
        flag = 2;
        ProductController.Block(UserID, Opporid, flag);
        divSuccessmessage.Visible = true;
        lblsuccessMessage.Text = "Opportunity blocked successfully - " + Opporid;
        divsearchresults.Visible = false;
        Divsearchcriteria.Visible = true;

    }
   
    protected void btnclose_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Manage_Order.aspx");
        txtFeeOffered.Text = "";
    }

    protected void btnunblockno_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $('#UnBlocklead').modal('hide') });</script>", false);
    }

    protected void btnunblockyes_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Oppurid = "";
        int flag = 0;
        Oppurid = lbloppurid.Text;
        flag = 4;
        ProductController.Block(UserID, Oppurid, flag);
        divSuccessmessage.Visible = true;
        lblsuccessMessage.Text = "Opportunity unblocked successfully - " + Oppurid;
        divsearchresults.Visible = false;
        Divsearchcriteria.Visible = true;
    }

    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        divsearchresults.Visible = true;
        Divsearchcriteria.Visible = false;
        lblpagetitle1.Text = "Manage Order";
        lblpagetitle2.Text = "Search Results";
        //limidbreadcrumb.Visible = true;
        lblmidbreadcrumb.Text = "Manage Order";
        //lilastbreadcrumb.Visible = true;
        lbllastbreadcrumb.Text = " Order Search Results";
        //lilastbreadcrumb.Visible = true;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;

        divmessage.Visible = false;

        btnback.Visible = false;
        lblstudentname.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlconvert.Visible = false;
        divSearch.Visible = false;
        btnviewenrollment.Disabled = false;
        btnback.Visible = false;
        btnback.Visible = false;

        div5.Visible = false;
        divcreatebutton.Visible = false;

        divcreatebutton.Visible = false;
        Divreselect.Visible = false;
        Div6.Visible = false;
        //divfeedetails.Visible = False
        divbtnexit.Visible = false;
        btnclose.Visible = false;
        divErrormessage.Visible = false;
        upnlsearch.Visible = true;
        divSearch.Visible = true;
        btnsearch_ServerClick(sender, e);
    }

    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {

        divsearchresults.Visible = false;
        Divsearchcriteria.Visible = true;
        lblpagetitle1.Text = "Manage Order";
        lblpagetitle2.Text = "";
        //limidbreadcrumb.Visible = true;
        lblmidbreadcrumb.Text = "Manage Order";
        //lilastbreadcrumb.Visible = true;
        lbllastbreadcrumb.Text = "Search Panel";
        //lilastbreadcrumb.Visible = true;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        divsearchresults.Visible = false;
        divmessage.Visible = false;

        btnback.Visible = false;
        lblstudentname.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        upnlconvert.Visible = false;
        divSearch.Visible = true;
        btnviewenrollment.Disabled = false;
        btnback.Visible = false;
        btnback.Visible = false;
        btnsearchback.Visible = false;
        div5.Visible = false;
        divcreatebutton.Visible = false;

        divcreatebutton.Visible = false;
        Divreselect.Visible = false;
        Div6.Visible = false;
        //divfeedetails.Visible = False
        divbtnexit.Visible = false;
        btnclose.Visible = false;
        divErrormessage.Visible = false;
    }
   
}