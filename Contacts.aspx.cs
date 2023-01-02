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
//using Exportxls.BL;
using Microsoft.VisualBasic;



public partial class Contacts : System.Web.UI.Page
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
                lblpagetitle1.Text = "Contacts";
                lblmidbreadcrumb.Text = "Manage Contacts";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                upnlsearch.Visible = true;
                upnldisplay.Visible = false;
                divmessage.Visible = false;
                divSearch.Visible = true;
                divsearchresults.Visible = false;
                BindProductCategory();
                BindCompany();
                StudentType();
                Institutetype();
                Board();
                this.ddlstandardsearch.Items.Insert(0, "All");
                this.ddlstandardsearch.SelectedIndex = 0;
                CountrySearch();
                ddlacadyearsearch.Items.Insert(0, "All");
                ddlacadyearsearch.SelectedIndex = 0;
                ddlstreamsearch.Items.Insert(0, "All");
                ddlstreamsearch.SelectedIndex = 0;
                Yearofpassing();
                Bindscore();
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Name <b>OR</b> Handphone is <strong class='red'>Mandate</strong> for Contacts Search";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Search By', text: 'Name Or Handphone 1 is mandate for this search ',class_name: 'gritter-error'});});</script>", false);
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

    protected void ddlcity_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindLocation();
    }
    //private void BindLocation()
    //{
    //    DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
    //    BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
    //    ddllocation.Items.Insert(0, "Select");
    //    ddllocation.SelectedIndex = 0;
    //}


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
    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddlcenter.SelectedValue);
        BindDDL(ddlacadyearsearch, ds, "AY_String", "AY_String");
        ddlacadyearsearch.Items.Insert(0, "All");
        ddlacadyearsearch.SelectedIndex = 0;
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
        var watch = System.Diagnostics.Stopwatch.StartNew();

        try
        {
            if ((txtstudentnamesearch.Text == "") && (txthandphonesearch.Text == ""))
            {
                divErrormessage.Visible = false;
                lblerrormessage.Visible = false;
                lblerrormessage.Text = "Enter Student Name or Handphone 1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Name & Handphone 1 field is blank. Please fill atleast 1 field and try again  ',class_name: 'gritter-error'});});</script>", false);
                return;
            }
            int flag = 0;
            int stage = 0;
            string Company = "";
            string Division = "";
            string Zone = "";
            string Center = "";
            string customer_type = "";

            string institution_type = "";
            string board_id = "";
            string standard = "";
            string name = "";

            string mobile = "";
            string country = "";
            string state = "";
            string city = "";
            string location = "";

            string acadyear = "";
            string productcategory = "";
            string stream = "";
            string application_form_no = "";

            string agefrom = "";
            string ageto = "";
            string boardid = "";
            string standard_id = "";
            string year = "";

            string xam_details = "";
            string scoretype = "";
            string condition = "";

            string score = "";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            flag = Convert.ToInt32(ddlSearchby.SelectedValue);
            stage = Convert.ToInt32(dlsearchstage.SelectedValue);
            Company = ddlcompany.SelectedValue;
            Division = ddldivision.SelectedValue;
            Zone = ddlzone.SelectedValue;
            Center = ddlcenter.SelectedValue;
            customer_type = ddlcustomertypesearch.SelectedValue;
            institution_type = ddlinstitutionsearch.SelectedValue;
            board_id = ddlboardsearch.SelectedValue;
            standard = ddlstandardsearch.SelectedValue;
            name = txtstudentnamesearch.Text;
            mobile = txthandphonesearch.Text;
            country = ddlcountrysearch.SelectedValue;
            state = ddlstatesearch.SelectedValue;
            city = ddlcitysearch.SelectedValue;
            location = ddllocationsearch.SelectedValue;
            acadyear = ddlacadyearsearch.SelectedValue;
            productcategory = ddlproductcategory.SelectedValue;
            stream = ddlstreamsearch.SelectedValue;
            application_form_no = txtadmissionformno.Text;
            agefrom = txtagefrom.Text;
            ageto = txtageto.Text;
            boardid = ddlboardsearch2.SelectedValue;
            standard_id = ddlstandardsearch2.SelectedValue;
            year = ddlyearsearch.SelectedValue;
            xam_details = txtexamsearch.Text;
            scoretype = ddlscoretype.SelectedValue;
            condition = ddlcondition.SelectedValue;
            score = txtscore.Text;


            DataSet ds = AccountController.Get_Contact_Search(flag, stage, Company, Division, Zone, Center, customer_type, institution_type, board_id, standard,
            name, mobile, country, state, city, location, acadyear, productcategory, stream, application_form_no,
            agefrom, ageto, boardid, standard_id, year, xam_details, scoretype, condition, score, UserID);



            if (ds.Tables[0].Rows.Count > 0)
            {
                Divsearchcriteria.Visible = false;
                lblpagetitle1.Text = "Contact";
                //lblpagetitle2.Text = "Search Results";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Contact";
                //lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Text = " Contact Search Results";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divsearchresults.Visible = true;
                divmessage.Visible = false;
                // System.Threading.Thread.Sleep(500);
                //dlsearch.DataSource = Pds1;
                dlsearch.DataSource = ds.Tables[0];
                dlsearch.DataBind();
                //script1.RegisterAsyncPostBackControl(dlsearch);
                divErrormessage.Visible = false;
                btnsearchback.Visible = true;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Success', text: 'Total Records found',class_name: 'gritter-success'});});</script>", false);

            }
            else
            {
                divsearchresults.Visible = false;
                Divsearchcriteria.Visible = true;
                divmessage.Visible = true;
                lblmessage.Text = "No Records Found!";
            }
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        lblexecutiontime.Text = "Time taken:" + TimeSpan.FromMilliseconds(elapsedMs).ToString();
    }



    protected void dlsearch_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Display")
        {
            upnlsearch.Visible = false;
            upnldisplay.Visible = true;
            lblpagetitle1.Text = "Contact";
            lblpagetitle2.Text = "";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Contact";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = "Display";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            string Conid = e.CommandArgument.ToString();
            // ddlContactsourceadd.SelectedIndex = 0;
            //Country();
            BindSecContactDetails(Conid);
            btnback.Visible = true;
        }
        else if (e.CommandName == "Convert_To_Lead")
        {
            //System.Threading.Thread.Sleep(100);
            string Con_ID = e.CommandArgument.ToString();
            //Server.Transfer("Convert_Contact_To_Lead.aspx?&Con_id=" + Con_ID);
            // Response.Redirect("Convert_Contact_To_Lead.aspx?&Con_id=" + Con_ID);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('Convert_Contact_To_Lead.aspx?Con_id=" + Con_ID.ToString() + "');", true);


        }
    }

    protected void dlsearch_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
            scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkdisplay"));
            //scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkconverttolead"));
            string Categorytype = ((Label)e.Item.FindControl("lblstudentname1")).Text;
            if (string.IsNullOrEmpty(Categorytype))
            {
                ((Label)e.Item.FindControl("lblstudentname1")).Text = "(Secondary Contact)";
                //DirectCast(e.Item.FindControl("Label4"), Label).ForeColor = System.Drawing.Color.White
            }
            else
            {
                //DirectCast(e.Item.FindControl("Label4"), Label).BackColor = System.Drawing.Color.IndianRed
                //DirectCast(e.Item.FindControl("Label4"), Label).ForeColor = System.Drawing.Color.White
            }
        }
    }

    private void BindSecContactDetails(string Conid)
    {
        string Con_id = Conid;

        lblPKey_Con_Id.Text = Con_id;

        ContactInfoPanel1.BindSecContactDetails(Con_id);
        //BindContactHistory
        HistoryPanel1.BindContactHistory(Con_id);


    }



    protected void ddlSearchby_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlSearchby.SelectedValue == "2")
        {
            divprimary1.Visible = false;
            divprimary2.Visible = false;
        }
        else
        {
            divprimary1.Visible = true;
            divprimary2.Visible = true;
        }
    }
    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = false;
        divsearchresults.Visible = true;
        upnldisplay.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnback.Visible = false;
        //upnlsearch.Update();
    }

    protected void btnClose_Click(object sender, System.EventArgs e)
    {


        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = false;
        divsearchresults.Visible = true;
        upnldisplay.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnback.Visible = false;
        lblpagetitle1.Text = "Contact";
        lblpagetitle2.Text = "Search Results";
        //limidbreadcrumb.Visible = true;
        lblmidbreadcrumb.Text = "Contact";
        //lilastbreadcrumb.Visible = true;
        lbllastbreadcrumb.Text = " Contact Search Results";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;


    }

    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        upnldisplay.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnback.Visible = false;
        btnsearchback.Visible = false;
        //upnlsearch.Update();
    }




    protected void btnAddAcadInfo_Click(object sender, EventArgs e)
    {

    }

    protected void btnSaveAcadInfo_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnUpdateAcadInfo_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnCloseAcadInfo_ServerClick(object sender, EventArgs e)
    {

    }

    protected void dlAcadInfo_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {

    }

    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // BindCity();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // BindState();
    }


}