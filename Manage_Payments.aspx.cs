using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using System.Data.SqlClient.SqlDataReader;
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

public partial class Manage_Payments : System.Web.UI.Page
{
    PagedDataSource Pds1 = new PagedDataSource();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["MyCookiesLoginInfo"] != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string UserID = cookie.Values["UserID"];
                    string UserName = cookie.Values["UserName"];
                    lblpagetitle1.Text = "Manage Payments";
                    lblmidbreadcrumb.Text = "Manage Payments";
                    divSuccessmessage.Visible = false;
                    divErrormessage.Visible = false;
                    upnlsearch.Visible = true;
                  
                    //System.Threading.Thread.Sleep(1000);
                    listudentstatus.Visible = false;
                    btnviewenrollment.Visible = false;
                    liregno.Visible = false;
                    tdapplicationid.Visible = false;
                    tdapplicationid1.Visible = false;

                    divmessage.Visible = false;
                    divSearch.Visible = true;
                    divsearchresults.Visible = false;
                    Divmessage1.Visible = false;
                    BindCompany();
                    BindDivision();
                    //BindPayplan();
                    BindProductCategory();
                    StudentType();
                    Institutetype();
                    CountrySearch();
                    Board();
                    Eventtype();
                    BindAcademicYear();
                    BindStream();

                }
                else
                {
                    Response.Redirect("login.aspx");
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

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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
    private void Eventtype()
    {
        DataSet ds = ProductController.GetallEventtype();
        BindDDL(ddlevent, ds, "event_description", "event_type");
        ddlevent.Items.Insert(0, "All");
        ddlevent.SelectedIndex = 0;
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
        ddlstandardsearch.Items.Insert(0, "All");
        ddlstandardsearch.SelectedIndex = 0;
    }
    private void BindProductCategory()
    {
        DataSet ds = ProductController.GetallOpporProductCategory();
        BindDDL(ddlproductcategory, ds, "Description", "ID");
        ddlproductcategory.Items.Insert(0, "All");
        ddlproductcategory.SelectedIndex = 0;
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
        ddlcompany.Items.Insert(0, "All");
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
                //ddlzone.DataSource = ds.Tables[2];
                //ddlzone.DataTextField = "Zone_Name";
                //ddlzone.DataValueField = "Zone_Code";
                //ddlzone.DataBind();
                //ddlzone.Items.Insert(0, "All");
                //ddlzone.SelectedIndex = 0;
                if (ddldivision.Items.Count > 1)
                {
                    ddldivision.SelectedIndex = 1;
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
                //ddlzone.Items.Insert(0, "All");
                //ddlzone.SelectedIndex = 0;
                ddlcenter.Items.Insert(0, "All");
                ddlcenter.SelectedIndex = 0;
            }
        }
        else
        {
            ddldivision.Items.Insert(0, "All");
            ddldivision.SelectedIndex = 0;
            //ddlzone.Items.Insert(0, "All");
            //ddlzone.SelectedIndex = 0;
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
        BindCenter();
    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindZone();
        BindCenter();
    }

    //private void BindZone()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
    //    BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
    //    ddlzone.Items.Insert(0, "All");
    //    ddlzone.SelectedIndex = 0;
    //}
    //protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindCenter();
    //}
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }

    //Private Sub BindCenter()
    //    Dim cookie As HttpCookie = Request.Cookies.[Get]("MyCookiesLoginInfo")
    //    Dim UserID As String = cookie.Values["UserID"]
    //    Dim UserName As String = cookie.Values["UserName"]

    //    Dim ds As DataSet = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue)
    //    BindDDL(ddlcenter, ds, "Center_name", "Center_Code")
    //    ddlcenter.Items.Insert(0, "All")
    //    ddlcenter.SelectedIndex = 0
    //End Sub
    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindAcademicYear();
        BindStream();
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear();
        //DataSet ds = ProductController.GetAcademicYearbyCenter(ddlcenter.SelectedValue);
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

    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {

        try
        {

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string StudentName = "";
            string Applicationno = "";
            string Company = "";
            string Division = "";
            string Zone = "";
            string Center = "";
            string AcademicYear = "";
            string Stream = "";

            StudentName = txtstudentname.Text;
            Applicationno = txtapplicationno.Text;
            Company = ddlcompany.SelectedValue;
            Division = ddldivision.SelectedValue;
            Zone = "All";
            Center = ddlcenter.SelectedValue;
            AcademicYear = ddlacademicyear.SelectedValue;
            Stream = ddlstream.SelectedValue;

            string Customer_Type = "";
            string Institutiontype = "";
            string Boardid = "";
            string Standard = "";
            string Mobile = "";
            string Country = "";
            string State = "";
            string City = "";
            string Location = "";
            string Productcategory = "";
            string Fromdate = "";
            string Todate = "";
            string OrderStatus = "";
            string Sbentrycode = "";
            string Active = "";
            string Promoted = "";
            if (Chkactive.Checked == true)
            {
                Active = "1";
            }
            else
            {
                Active = "0";
            }
            if (chkpromoted.Checked == true)
            {
                Promoted = "1";
            }
            else
            {
                Promoted = "0";
            }

            Customer_Type = ddlcustomertypesearch.SelectedValue;
            Institutiontype = ddlinstitutionsearch.SelectedValue;
            Boardid = ddlboardsearch.SelectedValue;
            Standard = ddlstandardsearch.SelectedValue;
            Mobile = txthandphonesearch.Text;
            Country = ddlcountrysearch.SelectedValue;
            State = ddlstatesearch.SelectedValue;
            City = ddlcitysearch.SelectedValue;
            Location = ddllocationsearch.SelectedValue;
            Productcategory = ddlproductcategory.SelectedValue;
            Fromdate = txteventdatefrom.Text;
            Todate = txteventdateto.Text;
            OrderStatus = ddlorderstatus.SelectedValue;
            Sbentrycode = txtsbentrycode.Text;



            DataSet ds = AccountController.Get_Account_Search_Results_Payment(StudentName, Applicationno, Company, Division, Zone, Center, AcademicYear, Stream, UserID, Customer_Type,
            Institutiontype, Boardid, Standard, Mobile, Country, State, City, Location, Productcategory, Fromdate,
            Todate, OrderStatus, Sbentrycode, Active, Promoted);




            if (ds.Tables[0].Rows.Count > 0)
            {
                Divsearchcriteria.Visible = false;
                lblpagetitle1.Text = "Manage Payments";
                lblpagetitle2.Text = "Search Results";
                lblmidbreadcrumb.Text = "Manage Payments";
                lbllastbreadcrumb.Text = " Payments Search Results";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divsearchresults.Visible = true;
                divmessage.Visible = false;
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                script1.RegisterAsyncPostBackControl(Repeater1);

                btnsearchback.Visible = true;
                Divmessage1.Visible = true;

            }
            else
            {
                divsearchresults.Visible = false;
                Divsearchcriteria.Visible = true;
                divmessage.Visible = true;
                btnsearchback.Visible = false;
                Divmessage1.Visible = false;

                lblmessage.Text = "No Records Found!";
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




    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Ledger")
        {
            
           
           
        }
        else if (e.CommandName == "Edit")
        {
           
        }
        else if (e.CommandName == "Promote")
        {
        }
    }

    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (lblusercompany.Text == "MPUC")
            {
                ((LinkButton)e.Item.FindControl("lnkledger")).Enabled = false;
                ((LinkButton)e.Item.FindControl("lnkledger")).Visible = false;
                //DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = True
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
                scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkledger"));
                //scriptManager__1.RegisterPostBackControl(DirectCast(e.Item.FindControl("lnkpromote"), LinkButton))
                string Status = ((Label)e.Item.FindControl("Label30")).Text;
                if (Status == "03")
                {
                    ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn default btn-xs red");
                    ((Label)e.Item.FindControl("Label3")).Attributes.Add("class", "btn default btn-xs red");
                    ((Label)e.Item.FindControl("Label3")).Text = "Pending";
                    //DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = False
                    ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                }
                else if (Status == "01")
                {
                    ((LinkButton)e.Item.FindControl("lnkledger")).Attributes.Add("class", "btn default btn-xs green");
                    ((Label)e.Item.FindControl("Label3")).Attributes.Add("class", "btn default btn-xs green");
                    ((Label)e.Item.FindControl("Label3")).Text = "Confirmed";
                    string StudeStatus = ((Label)e.Item.FindControl("lblpromotedflag")).Text;
                    if (StudeStatus == "1")
                    {
                        // DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = False
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                        ((Label)e.Item.FindControl("Label6")).Attributes.Add("class", "btn default btn-xs purple");
                        ((Label)e.Item.FindControl("Label6")).Visible = false;
                        ((Label)e.Item.FindControl("Label6")).Text = "Promoted";
                        lblpromoteflag.Text = "1";
                    }
                    else
                    {
                        //DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = True
                        ((LinkButton)e.Item.FindControl("lnkedit")).Visible = true;
                        //DirectCast(e.Item.FindControl("Label6"), Label).Attributes.Add("class", "btn default btn-xs red")
                        ((Label)e.Item.FindControl("Label6")).Visible = false;
                        //DirectCast(e.Item.FindControl("Label6"), Label).Text = "Not Promoted"
                        lblpromoteflag.Text = "0";
                    }

                }
            }
            else
            {
                ((LinkButton)e.Item.FindControl("lnkledger")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkledger")).Enabled = false;
                ((Label)e.Item.FindControl("Label3")).Visible = false;
                //DirectCast(e.Item.FindControl("lnkpromote"), LinkButton).Visible = False
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;

            }

        }
    }






    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {
        divsearchresults.Visible = false;
        Divsearchcriteria.Visible = true;
        divmessage.Visible = false;
        btnsearchback.Visible = false;
        Divmessage1.Visible = false;
    }

}