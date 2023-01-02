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



public partial class ContactCenter_Contacts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Menuid = "117";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "Contacts";
                lblpagetitle2.Text = "Search Results";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Contacts";
                //lilastbreadcrumb.Visible = false;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                upnlsearch.Visible = true;
                upnldisplay.Visible = false;
                //System.Threading.Thread.Sleep(1000);
                //listudentstatus.Visible = false;
                //ContactSource();
                //ContactType();
                //StudentType2();
                //Country2();
                //Institutetype3();
                //Board1();
               // DivisionSession();
                //Yearofpassing1();
    
   

               
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Search By', text: 'Name Or Handphone 1 is mandate for this search ',class_name: 'gritter-error'});});</script>", false);
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

    }


    //private void ContactSource()
    //{
    //    DataSet ds = ProductController.GetallactiveleadSource();
    //    BindDDL(ddlContactsourceadd, ds, "Description", "ID");
    //    ddlContactsourceadd.Items.Insert(0, "Select");
    //    ddlContactsourceadd.SelectedIndex = 0;
    //}

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
        try
        {
            if ((txtstudentnamesearch.Text== "") && (txthandphonesearch.Text == ""))
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

            flag =Convert.ToInt32(ddlSearchby.SelectedValue);
            stage =Convert.ToInt32(dlsearchstage.SelectedValue);
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

            //System.Threading.Thread.Sleep(1000);
            //PagedDataSource Pds1 = new PagedDataSource();
            //Pds1.DataSource = ds.Tables[0].DefaultView;
            //Pds1.AllowPaging = true;
            //Pds1.PageSize = 20;
            //Pds1.CurrentPageIndex = Currentpage;
            //lbl1.Text = "Showing " + (Currentpage + 1).ToString() + " of " + Pds1.PageCount.ToString();
            //btnprevious.Enabled = !Pds1.IsFirstPage;
            //Btnnext.Enabled = !Pds1.IsLastPage;

            if (ds.Tables[0].Rows.Count > 0)
            {
                Divsearchcriteria.Visible = false;
                lblpagetitle1.Text = "Contact";
                lblpagetitle2.Text = "Search Results";
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Success', text: 'Total Records found',class_name: 'gritter-success'});});</script>", false);
                
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

        ContactInfoPanel1.BindSecContactDetails_Agent(Con_id);

        //BindContactHistory
        HistoryPanel1.BindContactHistory(Con_id);

        //DataSet ds = ProductController.Get_ContactbyContactId(7, Con_id);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
            //if ((ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == ""))
            //{
            //    ddlContactsourceadd.SelectedIndex = 0;
            //}
            //else
            //{
            //    ddlContactsourceadd.SelectedValue = ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString();
            //}
            //if ((ds.Tables[0].Rows[0]["Con_type_id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Con_type_id"].ToString() == ""))
            //{
            //    ddlContactType.SelectedIndex = 0;
            //}
            //else
            //{
            //    ddlContactType.SelectedValue = ds.Tables[0].Rows[0]["Con_type_id"].ToString();
            //}

            //if ((ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == ""))
            //{
            //    ddlcustomertype.SelectedIndex = 0;
            //}
            //else
            //{
            //    ddlcustomertype.SelectedValue = ds.Tables[0].Rows[0]["Category_Type_Id"].ToString();
            //}


            //if (ds.Tables[0].Rows[0]["Con_title"].ToString() == "Mr.")
            //{
            //    ddlTitle.SelectedValue = "1";
            //}
            //else if (ds.Tables[0].Rows[0]["Con_title"].ToString() == "Ms.")
            //{
            //    ddlTitle.SelectedValue = "2";
            //}
            //else
            //{
            //    ddlTitle.SelectedIndex = 0;
            //}

            //txtFirstName.Text = ds.Tables[0].Rows[0]["Con_Firstname"].ToString();
            //txtMidName.Text = ds.Tables[0].Rows[0]["Con_midname"].ToString();
            //txtLastName.Text = ds.Tables[0].Rows[0]["Con_lastname"].ToString();

            //if ((ds.Tables[0].Rows[0]["Gender"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Gender"].ToString() == ""))
            //{
            //    ddlGender.SelectedIndex = 0;
            //}
            //else
            //{
            //    if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Male")
            //    {
            //        ddlGender.SelectedValue = "1";
            //    }
            //    else if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Female")
            //    {
            //        ddlGender.SelectedValue = "2";
            //    }
            //    else
            //        ddlGender.SelectedIndex = 0;
            //}

            //if (ds.Tables[0].Rows[0]["DOB"].ToString() == "")
            //{
            //    txtdateofbirth.Text = "";
            //}
            //else
            //{
            //    txtdateofbirth.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
            //}

            //txtHandPhone1.Text = ds.Tables[0].Rows[0]["handphone1"].ToString();
            //txtHandphone2.Text = ds.Tables[0].Rows[0]["handphone2"].ToString();
            //txtlandline.Text = ds.Tables[0].Rows[0]["landline"].ToString();
            //txtemailid.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
            //txtaddress1.Text = ds.Tables[0].Rows[0]["Flatno"].ToString();
            //txtaddress2.Text = ds.Tables[0].Rows[0]["BuildingName"].ToString();
            //txtStreetname.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
            //txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

            //if ((ds.Tables[0].Rows[0]["Country"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Country"].ToString() == ""))
            //{
            //    ddlCountry.SelectedIndex = 0;
            //    ddlstate.Items.Clear();
            //    ddlcity.Items.Clear();
            //    ddllocation.Items.Clear();
            //    ddlstate.Items.Insert(0, "Select");
            //    ddlcity.Items.Insert(0, "Select");
            //    ddllocation.Items.Insert(0, "Select");
            //    ddlstate.SelectedIndex = 0;
            //    ddlcity.SelectedIndex = 0;
            //    ddllocation.SelectedIndex = 0;
            //}
            //else
            //{
            //    ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
            //    BindState();
            //    if ((ds.Tables[0].Rows[0]["State"].ToString() == "Select") || (ds.Tables[0].Rows[0]["State"].ToString() == ""))
            //    {
            //        ddlstate.SelectedIndex = 0;
            //        ddlcity.Items.Clear();
            //        ddllocation.Items.Clear();
            //        ddlcity.Items.Insert(0, "Select");
            //        ddlcity.SelectedIndex = 0;
            //        ddllocation.Items.Insert(0, "Select");
            //        ddllocation.SelectedIndex = 0;                    
            //    }
            //    else
            //    {
            //        ddlstate.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
            //        BindCity();
            //        if ((ds.Tables[0].Rows[0]["City"].ToString() == "Select") || (ds.Tables[0].Rows[0]["City"].ToString() == ""))
            //        {
            //            ddlcity.SelectedIndex = 0;
            //            ddllocation.Items.Clear();
            //            ddllocation.Items.Insert(0, "Select");
            //            ddllocation.SelectedIndex = 0;  
            //        }
            //        else
            //        {
            //            ddlcity.SelectedValue = ds.Tables[0].Rows[0]["City"].ToString();
            //            BindLocation();
            //            if ((ds.Tables[0].Rows[0]["Location"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Location"].ToString() == ""))
            //            {
            //                ddllocation.SelectedIndex = 0;
            //            }
            //            else
            //            {
            //                ddllocation.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
            //            }
            //        }
            //    }
            //}
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    dlAcadInfo.Visible = true;
            //    lblAcadInfoRecord.Visible = false;
            //    dlAcadInfo.DataSource = ds.Tables[1];
            //    dlAcadInfo.DataBind();
            //}
            //else
            //{
            //    dlAcadInfo.Visible = false;
            //    lblAcadInfoRecord.Visible = true;
            //    lblAcadInfoRecord.Text  = "No records found..!";
            //}

            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    dlSec_Con_Info.Visible = true;
            //    lblSecConRecord.Visible = false;
            //    dlSec_Con_Info.DataSource = ds.Tables[2];
            //    dlSec_Con_Info.DataBind();
            //}
            //else
            //{
            //    dlSec_Con_Info.Visible = false;
            //    lblSecConRecord.Visible = true;
            //    lblSecConRecord.Text = "No records found..!";
            //}

            //if (ds.Tables[3].Rows.Count > 0)
            //{

            //    dlConHistory.Visible = true;
            //    lblCon_History.Visible = false;

            //    dlConHistory.DataSource = ds.Tables[3];
            //    dlConHistory.DataBind();
            //}
            //else
            //{
            //    dlConHistory.Visible = false;
            //    lblCon_History.Visible=true;
            //    lblCon_History.Text = "No records found..!";
            //}

            //if (ds.Tables[4].Rows.Count > 0)
            //{
            //    dlfeedbackhistory.DataSource = ds.Tables[4];
            //    dlfeedbackhistory.DataBind();
            //    dlfeedbackhistory.Visible = true;
            //    diverrormessagefeedback.Visible = false;
            //}
            //else
            //{
            //    divfeedbackhistory.Visible = false;
            //    diverrormessagefeedback.Visible = true;
            //    lblerrrormessagefeedback.Text = "No Follow up history found !!!";
            //}
        //}
        //SqlDataReader dr = ProductController.Get_ContactbyLeadidforfield(7, Con_id);
        //if ((((dr) != null)))
        //{
        //    if (dr.Read())
        //    {
        //        ContactType2();
        //        if ((dr["Con_type_id"].ToString() == "Select") || (dr["Con_type_id"].ToString() == ""))
        //        {
        //            ddlseccontacttype2.SelectedIndex = 0;
        //            ddlContactType.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlseccontacttype2.SelectedValue = dr["Con_type_id"].ToString();
        //            ddlContactType.SelectedValue = dr["Con_type_id"].ToString();
        //        }

        //        if ((dr["Category_Type_Id"].ToString() == "Select") || (dr["Category_Type_Id"].ToString() == ""))
        //        {
        //            ddlcustomertype.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlcustomertype.SelectedValue = dr["Category_Type_Id"].ToString();
        //        }


        //        if (dr["Con_title"].ToString() == "Mr.")
        //        {
        //            ddlsectitle2.SelectedValue = "1";
        //            ddlTitle.SelectedValue = "1";
        //        }
        //        else if (dr["Con_title"].ToString() == "Ms.")
        //        {
        //            ddlsectitle2.SelectedValue = "2";
        //            ddlTitle.SelectedValue = "2";
        //        }
        //        else
        //        {
        //            ddlsectitle2.SelectedIndex = 0;
        //            ddlTitle.SelectedIndex = 0;
        //        }
        //        txtsecfname2.Text = dr["Con_Firstname"].ToString();
        //        txtsecmname2.Text = dr["Con_midname"].ToString();
        //        txtseclname2.Text = dr["Con_lastname"].ToString();

        //        if ((dr["Gender"].ToString() == "Select") || (dr["Gender"].ToString() == ""))
        //        {
        //            ddlGender.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            if (dr["Gender"].ToString() == "Male")
        //            {
        //                ddlGender.SelectedValue = "1";
        //            }
        //            else if (dr["Gender"].ToString() == "Female")
        //            {
        //                ddlGender.SelectedValue = "2";
        //            }
        //            else
        //                ddlGender.SelectedIndex = 0;
        //        }

        //        if (dr["DOB"].ToString() == "")
        //        {
        //            txtdateofbirth.Text = "";
        //        }
        //        else
        //        {
        //            txtdateofbirth.Text = dr["DOB"].ToString();
        //        }

        //        txtsechandphone12.Text = dr["handphone1"].ToString();
        //        txtsechandphone22.Text = dr["handphone2"].ToString();
        //        txtseclandline2.Text = dr["landline"].ToString();
        //        txtsecemailid2.Text = dr["Emailid"].ToString();
        //        txtsecaddress12.Text = dr["Flatno"].ToString();
        //        txtsecaddress22.Text = dr["BuildingName"].ToString();
        //        txtsecStreetname2.Text = dr["StreetName"].ToString();
        //        txtsecpincode2.Text = dr["Pincode"].ToString();

        //        txtFirstName.Text = dr["Con_Firstname"].ToString();
        //        txtMidName.Text = dr["Con_midname"].ToString();
        //        txtLastName.Text = dr["Con_lastname"].ToString();
        //        txtHandPhone1.Text = dr["handphone1"].ToString();
        //        txtHandphone2.Text = dr["handphone2"].ToString();
        //        txtlandline.Text = dr["landline"].ToString();
        //        txtemailid.Text = dr["Emailid"].ToString();
        //        txtaddress1.Text = dr["Flatno"].ToString();
        //        txtaddress2.Text = dr["BuildingName"].ToString();
        //        txtStreetname.Text = dr["StreetName"].ToString();
        //        txtpincode.Text = dr["Pincode"].ToString();

        //        if ((dr["Country"].ToString() == "Select") || (dr["Country"].ToString() == ""))
        //        {
        //            ddlCountry.SelectedIndex = 0;
        //            ddlstate.SelectedIndex = 0;
        //            ddlcity.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlCountry.SelectedValue = dr["Country"].ToString();
        //            BindState();
        //            if ((dr["State"].ToString() == "Select") || (dr["State"].ToString() == ""))
        //            {
        //                ddlstate.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                //BindSecState()
        //                ddlstate.SelectedValue = dr["State"].ToString();
        //                BindCity();
        //                if ((dr["City"].ToString() == "Select") || (dr["City"].ToString() == ""))
        //                {
        //                    ddlcity.SelectedIndex = 0;
        //                }
        //                else
        //                {
        //                    ddlcity.SelectedValue = dr["City"].ToString();
        //                }
        //            }
        //        }




        //        Institutetype2();
        //        if ((dr["Institution_Type_Id"].ToString() == "Select")||(dr["Institution_Type_Id"].ToString() == ""))
        //        {
        //            ddlinstitutiontype2.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlinstitutiontype2.SelectedValue = dr["Institution_Type_Id"].ToString();
        //        }

        //        txtnameofinstitution2.Text = dr["Institution_Description"].ToString();
        //        CurrentStudyingIn1();
        //        if ((dr["Current_Standard_id"].ToString() == "Select") || (dr["Current_Standard_id"].ToString() == ""))
        //        {
        //            ddlcurrentstudying2.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlcurrentstudying2.SelectedValue = dr["Current_Standard_id"].ToString();
        //        }

        //        txtadditiondesc2.Text = dr["Additional_desc"].ToString();
        //        Board2();
        //        if ((dr["Board_id"].ToString() == "Select") || (dr["Board_id"].ToString() == ""))
        //        {
        //            ddlboard2.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlboard2.SelectedValue = dr["Board_id"].ToString();
        //        }

        //        DivisionSession2();
        //        if ((dr["Section_id"].ToString() == "Select") || (dr["Section_id"].ToString() == ""))
        //        {
        //            ddlsection2.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlsection2.SelectedValue = dr["Section_id"].ToString();
        //        }

        //        Yearofpassing2();
        //        if ((dr["Year_of_Passing_Id"].ToString() == "Select") || (dr["Year_of_Passing_Id"].ToString() == ""))
        //        {
        //            ddlyearofpassing2.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlyearofpassing2.SelectedValue = dr["Year_of_Passing_Id"].ToString();
        //        }

        //        if ((dr["Country"].ToString() == "Select") || (dr["Country"].ToString() == ""))
        //        {
        //            ddlsecstate21.SelectedIndex = 0;
        //            ddlseccity21.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlseccountry2.SelectedValue = dr["Country"].ToString();
        //            BindSecState();
        //            if ((dr["State"].ToString() == "Select") || (dr["State"].ToString() == ""))
        //            {
        //                ddlsecstate21.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                //BindSecState()
        //                ddlsecstate21.SelectedValue = dr["State"].ToString();
        //                BindSecCity();
        //                if ((dr["City"].ToString() == "Select") || (dr["City"].ToString() == ""))
        //                {
        //                    ddlseccity21.SelectedIndex = 0;
        //                }
        //                else
        //                {
        //                    //BindSecCity()
        //                    ddlseccity21.SelectedValue = dr["City"].ToString();
        //                }
        //            }
        //        }
        //    }
        //}
    }

    //private void ContactType2()
    //{
    //    DataSet ds = ProductController.GetallactiveContactTypeinrelation();
    //    BindDDL(ddlseccontacttype2, ds, "Description", "ID");
    //}

    //private void Institutetype2()
    //{
    //    DataSet ds = ProductController.GetallInstituteType();
    //    BindDDL(ddlinstitutiontype2, ds, "Description", "ID");
    //    ddlinstitutiontype2.Items.Insert(0, "Select");
    //    ddlinstitutiontype2.SelectedIndex = 0;
    //}
    //protected void ddlinstitutiontype2_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype2.SelectedValue);
    //    BindDDL(ddlcurrentstudying2, ds, "Description", "ID");
    //    this.ddlcurrentstudying2.Items.Insert(0, "Select");
    //    this.ddlcurrentstudying2.SelectedIndex = 0;
    //    this.ddlinstitutiontype2.Focus();
    //}
    //private void CurrentStudyingIn1()
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype2.SelectedValue);
    //    BindDDL(ddlcurrentstudying2, ds, "Description", "ID");
    //    this.ddlcurrentstudying2.Items.Insert(0, "Select");
    //    this.ddlcurrentstudying2.SelectedIndex = 0;
    //}
    //private void DivisionSession2()
    //{
    //    DataSet ds = ProductController.GetAllDivisionSection();
    //    BindDDL(ddlsection2, ds, "Description", "ID");
    //    ddlsection2.Items.Insert(0, "Select");
    //    ddlsection2.SelectedIndex = 0;
    //}
    //private void Board2()
    //{
    //    DataSet ds = ProductController.GetallBoard();
    //    BindDDL(ddlboard2, ds, "Short_Description", "ID");
    //    ddlboard2.Items.Insert(0, "Select");
    //    ddlboard2.SelectedIndex = 0;
    //}
    //private void Yearofpassing2()
    //{
    //    DataSet ds = ProductController.GetallYearofpassing();
    //    BindDDL(ddlyearofpassing2, ds, "Description", "ID");
    //    ddlyearofpassing2.Items.Insert(0, "Select");
    //    ddlyearofpassing2.SelectedIndex = 0;
    //}
    //private void Country()
    //{
    //    DataSet ds = ProductController.GetallCountry();
    //    BindDDL(ddlseccountry2, ds, "Country_Name", "Country_Code");
    //    ddlseccountry2.Items.Insert(0, "Select");
    //    ddlseccountry2.SelectedIndex = 0;
    //    ddlsecstate21.Items.Insert(0, "Select");
    //    ddlsecstate21.SelectedIndex = 0;
    //    ddlseccity21.Items.Insert(0, "Select");
    //    ddlseccity21.SelectedIndex = 0;
    //}
    //protected void ddlseccountry_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindSecState();
    //    //ddlseccountry2.Focus()
    //}
    //private void BindSecState()
    //{
    //    DataSet ds = ProductController.GetallStatebyCountry(ddlseccountry2.SelectedValue);
    //    BindDDL(ddlsecstate21, ds, "State_Name", "State_Code");
    //    ddlsecstate21.Items.Insert(0, "Select");
    //    ddlsecstate21.SelectedIndex = 0;
    //    //ddlseccity2.SelectedIndex = 0
    //}

    //private void BindSecCity()
    //{
    //    DataSet ds = ProductController.GetallCitybyState(ddlsecstate21.SelectedValue);
    //    BindDDL(ddlseccity21, ds, "City_Name", "City_Code");
    //    ddlseccity21.Items.Insert(0, "Select");
    //    ddlseccity21.SelectedIndex = 0;
    //}

    //protected void ddlsecstate21_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindSecCity();
    //}

    protected void ddlSearchby_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //if (ddlSearchby.SelectedValue == "2")
        //{
        //    divprimary1.Visible = false;
        //    divprimary2.Visible = false;
        //}
        //else
        //{
        //    divprimary1.Visible = true;
        //    divprimary2.Visible = true;
        //}
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
        //upnlsearch.Visible = true;
        //Divsearchcriteria.Visible = true;
        //divsearchresults.Visible = false;
        //upnldisplay.Visible = false;
        //divSuccessmessage.Visible = false;
        //divErrormessage.Visible = false;
        //btnback.Visible = false;
        //btnsearchback.Visible = false;

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


    //protected void ddlinstitutiontype_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
    //    BindDDL(ddlcurrentstudying, ds, "Description", "ID");
    //    this.ddlcurrentstudying.Items.Insert(0, "Select");
    //    this.ddlcurrentstudying.SelectedIndex = 0;
    //    this.ddlcurrentstudying.Focus();
    //}


    //private void DivisionSession()
    //{
    //    DataSet ds = ProductController.GetAllDivisionSection();
    //    BindDDL(ddlsection, ds, "Description", "ID");
    //    ddlsection.Items.Insert(0, "Select");
    //    ddlsection.SelectedIndex = 0;
    //}

    //private void Board1()
    //{
    //    DataSet ds = ProductController.GetallBoard();
    //    BindDDL(ddlboard, ds, "Short_Description", "ID");
    //    ddlboard.Items.Insert(0, "Select");
    //    ddlboard.SelectedIndex = 0;
    //}

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

    //private void BindState()
    //{
    //    DataSet ds = ProductController.GetallStatebyCountry(ddlCountry.SelectedValue);
    //    BindDDL(ddlstate, ds, "State_Name", "State_Code");
    //    ddlstate.Items.Insert(0, "Select");
    //    ddlstate.SelectedIndex = 0;
    //    ddlcity.Items.Clear();
    //    ddlcity.Items.Insert(0, "Select");
    //    ddlcity.SelectedIndex = 0;
    //}


    //private void BindCity()
    //{
    //    DataSet ds = ProductController.GetallCitybyState(ddlstate.SelectedValue);
    //    BindDDL(ddlcity, ds, "City_Name", "City_Code");
    //    ddlcity.Items.Insert(0, "Select");
    //    ddlcity.SelectedIndex = 0;
    //}

    //private void ContactType()
    //{
    //    DataSet ds = ProductController.GetallactiveContactTypeinrelation();
    //    BindDDL(ddlContactType, ds, "Description", "ID");
    //}

    //private void StudentType2()
    //{
    //    DataSet ds = ProductController.GetAllStudentType();
    //    BindDDL(ddlcustomertype, ds, "Description", "Cust_Grp");
    //    ddlcustomertype.Items.Insert(0, "Select");
    //    ddlcustomertype.SelectedIndex = 0;
    //}
    //private void Country2()
    //{
    //    DataSet ds = ProductController.GetallCountry();
    //    BindDDL(ddlCountry, ds, "Country_Name", "Country_Code");
    //    ddlCountry.Items.Insert(0, "Select");
    //    ddlCountry.SelectedIndex = 0;
    //    ddlstate.Items.Insert(0, "Select");
    //    ddlstate.SelectedIndex = 0;
    //    ddlcity.Items.Insert(0, "Select");
    //    ddlcity.SelectedIndex = 0;
    //}
    //private void Institutetype3()
    //{
    //    DataSet ds = ProductController.GetallInstituteType();
    //    BindDDL(ddlinstitutiontype, ds, "Description", "ID");
    //    ddlinstitutiontype.Items.Insert(0, "Select");
    //    ddlinstitutiontype.SelectedIndex = 0;
    //    ddlcurrentstudying.Items.Insert(0, "Select");
    //    ddlcurrentstudying.SelectedIndex = 0;
    //}

    //private void Yearofpassing1()
    //{
    //    DataSet ds = ProductController.GetallYearofpassing();
    //    BindDDL(ddlyearofpassing, ds, "Description", "ID");
    //    ddlyearofpassing.Items.Insert(0, "Select");
    //    ddlyearofpassing.SelectedIndex = 0;
    //}

}