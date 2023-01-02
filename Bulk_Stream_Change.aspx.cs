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
using System.Threading;


public partial class Bulk_Stream_Change : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            if (!IsPostBack)
            {
                string Menuid = "117";
                if (Request.Cookies["MyCookiesLoginInfo"] != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string UserID = cookie.Values["UserID"];
                    string UserName = cookie.Values["UserName"];
                    lblpagetitle1.Text = "Bulk Stream Change";
                    lblpagetitle2.Text = "Search Panel";
                    lblmidbreadcrumb.Text = "Bulk Stream Change";
                    divSuccessmessage.Visible = false;
                    divErrormessage.Visible = false;
                    divpendingreuesterror.Visible = false;
                    upnlsearch.Visible = true;
                    listudentstatus.Visible = false;
                    btnviewenrollment.Visible = false;
                    btnviewenv.Visible = false;
                    //btnback.Visible = false;
                    //liregno.Visible = true;
                    SqlDataReader dr = UserController.Getuserrights(UserID, Menuid);
                    try
                    {
                        if ((((dr) != null)))
                        {
                            if (dr.Read())
                            {
                                int allowdisplay = Convert.ToInt32(dr["Allow_Add"].ToString());
                                if (allowdisplay == 1)
                                {
                                    //btnaddlead.Visible = True
                                    //btnimportlead.Visible = True
                                }
                                else
                                {
                                    //btnaddlead.Visible = False
                                    //btnimportlead.Visible = False
                                }

                            }
                        }


                    }
                    catch (Exception ex)
                    {
                    }
                    string UserCompany = "";
                    SqlDataReader dr1 = UserController.GetCompanyby_Userid(UserID);
                    try
                    {
                        if ((((dr1) != null)))
                        {
                            if (dr1.Read())
                            {
                                UserCompany = dr1["Company_Code"].ToString();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                    lblusercompany.Text = UserCompany;
                    if (lblusercompany.Text == "MPUC1")
                    {
                        tdapplicationid.Visible = true;
                        tdapplicationid1.Visible = true;
                    }
                    else
                    {
                        tdapplicationid.Visible = true;
                        tdapplicationid1.Visible = true;

                    }
                    //divmessage.Visible = false;
                    divSearch.Visible = true;
                    divsearchresults.Visible = false;
                    BindCompany();
                    BindProductCategory();
                    StudentType();
                    Institutetype();
                    CountrySearch();
                    Board();
                    Eventtype();
                    BindAcademicYear();
                    BindPayplan();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }
        }
        GetSumvalue();
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
                        ddluom1.Enabled = true;
                        lblvoucheramt.Enabled = false;
                    }
                    else
                    {
                        ddluom1.Enabled = true;
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
                    ddluom1.Enabled = false;
                    ddluom1.SelectedIndex = 0;
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
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void BindPayplan()
    {
        DataSet ds = AccountController.GetAllPayplan();
        BindDDL(ddlpayplan, ds, "Pay_Plan_Description", "Pay_Plan_Code");
        ddlpayplan.Items.Insert(0, "Select");
        ddlpayplan.SelectedIndex = 0;
    }


    private void BindOptionalSubject()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string StreamName = "";
        string Center = "";
        StreamName = ddldestinationstream.SelectedValue;
        Center = ddlcenter.SelectedValue;

        DataSet ds = ProductController.GetSubjectsbyStreamCode(7, StreamName, Center);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlselective.DataSource = ds;
            dlselective.DataBind();
        }
        else
        {
        }
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
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
        //ddlcompany.Items.Insert(0, "All")
        //ddlcompany.SelectedIndex = 1
        BindDivision();
        //ddldivision.Items.Insert(0, "All")
        //ddldivision.SelectedIndex = 0

        ddlzone.Items.Insert(0, "All");
        ddlzone.SelectedIndex = 0;

        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;

        //ddlacademicyear.Items.Insert(0, "Select");
        //ddlacademicyear.SelectedIndex = 0;

        ddlstream.Items.Insert(0, "All");
        ddlstream.SelectedIndex = 0;
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
        //BindCenter()
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
        BindAcademicYear();
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
        BindDDL(ddldestinationstream, ds, "Stream_Sdesc", "Stream_Code");
        ddldestinationstream.Items.Insert(0, "Select");
        ddldestinationstream.SelectedIndex = 0;
    }

    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
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
        Zone = ddlzone.SelectedValue;
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


        //DataSet ds = AccountController.Get_Account_Search_Results(StudentName, Applicationno, Company, Division, Zone, Center, AcademicYear, Stream, UserID, Customer_Type,
        //Institutiontype, Boardid, Standard, Mobile, Country, State, City, Location, Productcategory, Fromdate,
        //Todate, OrderStatus, Sbentrycode, Active, Promoted);

        DataSet ds = AccountController.Get_Account_Search_Results_Bulk_Stream_Change(StudentName, Applicationno, Company, Division, Zone, Center, AcademicYear, Stream, UserID, Customer_Type,
        Institutiontype, Boardid, Standard, Mobile, Country, State, City, Location, Productcategory, Fromdate,
        Todate, OrderStatus, Sbentrycode, Active, Promoted);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Bulk Stream Change";
            lblpagetitle2.Text = "Search Results";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Bulk Stream Change";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = " Bulk Stream Change Search Results";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            //divmessage.Visible = false;
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            script1.RegisterAsyncPostBackControl(Repeater1);
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            //divmessage.Visible = true;
            //lblmessage.Text = "No Records Found!";
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

    protected void btnstartsync_ServerClick(object sender, System.EventArgs e)
    {
        string Sbentrycode = "";
        List<string> list = new List<string>();
        string Sgrcode = "";
        try
        {
            foreach (RepeaterItem dtlItem in Repeater1.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                Label lblsbentrycode = (Label)dtlItem.FindControl("Label43");
                if (chkitemck.Checked == true)
                {
                  //Code for Bulk stream here
                    string Opp_id = "";
                    string Doctype = "";
                    int Flag = 0;
                    Opp_id = lblsbentrycode.Text + "P"; 
                    

                    //Get New Stream,Pay Plan and Subject Group
                    string DestinationStream = "";
                    string SourceStreamCode = "";
                    DataSet dsstudentdetails = AccountController.GetCustomerdetailsbySbentrycode(lblsbentrycode.Text);
                    string DestinationPayplan = "";
                    string Oldstreamsubjectgroup = "";
                    string Vouchertype = "ZP02";
                    string Voucheramount = "";
                    string BaseUOM = "Each";
                    string BaseUOMId = "01";
                    string Unit = "01";
                    string Quantity = "1";
                    string Amount = "";
                    string Remark = "Bulk Stream Change";
                    string Opportunitycode = "";
                    string Centercode = "";
                    string TotalDiscountValue = "";
                    string TotalConcessionValue = "";
                    Flag = 1;
                    Doctype = "DC05";
                    if (dsstudentdetails.Tables[0].Rows.Count > 0)
                    {
                        DestinationStream = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Destination_Stream_Code"]);
                        DestinationPayplan = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Pay_Type"]);
                        Oldstreamsubjectgroup = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Source_Material_Code"]);
                        SourceStreamCode=Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Source_Stream_Code"]);
                        Opportunitycode = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Opportunity_Code"]);
                        Centercode = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Center_Code"]);
                        TotalDiscountValue = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Total_Discount_Value"]);
                        TotalConcessionValue = Convert.ToString(dsstudentdetails.Tables[3].Rows[0]["Total_Concession_Value"]);
                    }

                    string sgr_materialcode = "";
                    DataSet dsSubjectGroupPrice = AccountController.GetCustomerSubjectGroupMaterial(lblsbentrycode.Text, DestinationStream, Oldstreamsubjectgroup);

                    //Foreach materialcode insertusing below function
                    foreach (DataRow row in dsSubjectGroupPrice.Tables[2].Rows)
                    {
                        sgr_materialcode = row["sgr_material"].ToString();
                        Voucheramount = row["Voucher_Amt"].ToString();
                        AccountController.InserttoGetPricingprocedurevaluebyoppidStreamChange(
                                            Opp_id, sgr_materialcode, Vouchertype, Voucheramount, BaseUOMId, BaseUOM, Unit, Quantity, Voucheramount, Remark,
                                            Doctype, Flag, DestinationStream);
                    }
                    ////Get pay plan
                    int flag2 = 2;
                    if (DestinationPayplan=="FDP")
                    {
                        flag2 = 3;
                    }
                    else
                    {
                        flag2 = 2;
                    }

                    DataSet ds = AccountController.GetPricingprocedureHeaderValue_NewStreamChange(Opp_id, Oldstreamsubjectgroup, "", "", "", "", "", "", "", "", "DC05", flag2, SourceStreamCode);

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

                    Accountid = AccountController.StreamChange(Opportunitycode, Oldstreamsubjectgroup, Doctype, DestinationPayplan, UserID, DestinationStream, Accountid, Opp_id);
                    string newsbentrycode = ProductController.GetNewSbntrycodebyOldSbnetrycode(flag, lblsbentrycode.Text);
                    //string NewSB = newsbentrycode;


                    //Moving Receipt
                    string VouchertypeRegistrationFees = "ZRE1";
                    //DateTime  V1 = 
                    string VoucherDate = "";
                    string adjamt = ProductController.GetVoucherValuebySbentrycode(1, lblsbentrycode.Text, "ZRE1");
                    string adjamt1 = ProductController.GetVoucherValuebySbentrycode(1, newsbentrycode, "ZRE1");
                    //decimal  adjamt1 = Convert.(adjamt);
                    float finalamt = 0;
                    //float STaxamt = 0;
                    //decimal  HETAx = 0;
                    //float ECEssTax = 0;
                    float oldAmount = float.Parse(adjamt);
                    float newAmount = float.Parse(adjamt1);
                    float lessamt = 0;
                    

                    if (oldAmount >= newAmount)
                    {
                        DataSet dsTax = ProductController.GetTaxValue(1, lblsbentrycode.Text, oldAmount, Centercode);
                        float Taxtotalvalue = float.Parse(dsTax.Tables[0].Rows[0]["TotalTax"].ToString());
                        float STTax = float.Parse(dsTax.Tables[0].Rows[0]["Stax"].ToString());
                        float HTAx = float.Parse(dsTax.Tables[0].Rows[0]["Htax"].ToString());
                        float Etax = float.Parse(dsTax.Tables[0].Rows[0]["Etax"].ToString());
                        STTax = STTax * -1;
                        HTAx = HTAx * -1;
                        Etax = Etax * -1;
                        finalamt = oldAmount + Taxtotalvalue;
                        lessamt = newAmount * -1;
                        flag = 1;
                        ProductController.InsertReceiptforevent(flag, lblsbentrycode.Text, UserID, newsbentrycode, finalamt);
                        string Pricing_Procedure_Code = "";
                        string Material_Code = "";
                        string returnvalue = ProductController.InsertFeesAdjustment(newsbentrycode, VouchertypeRegistrationFees, VoucherDate, lessamt, Pricing_Procedure_Code, Material_Code, UserID);
                        string returnvalue1 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT01", VoucherDate, STTax, Pricing_Procedure_Code, Material_Code, UserID);
                        string returnvalue2 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT02", VoucherDate, HTAx, Pricing_Procedure_Code, Material_Code, UserID);
                        string returnvalue3 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT03", VoucherDate, Etax, Pricing_Procedure_Code, Material_Code, UserID);

                    }
                    else if (oldAmount < newAmount)
                    {
                        DataSet dsTax2 = ProductController.GetTaxValue(1, lblsbentrycode.Text, oldAmount, Centercode);
                        float Taxtotalvalue = float.Parse(dsTax2.Tables[0].Rows[0]["TotalTax"].ToString());
                        float STTax = float.Parse(dsTax2.Tables[0].Rows[0]["Stax"].ToString());
                        float HTAx = float.Parse(dsTax2.Tables[0].Rows[0]["Htax"].ToString());
                        float Etax = float.Parse(dsTax2.Tables[0].Rows[0]["Etax"].ToString());
                        STTax = STTax * -1;
                        HTAx = HTAx * -1;
                        Etax = Etax * -1;
                        finalamt = oldAmount + Taxtotalvalue;
                        lessamt = oldAmount * -1;
                        flag = 1;
                        ProductController.InsertReceiptforevent(flag, lblsbentrycode.Text, UserID, newsbentrycode, finalamt);
                        string Pricing_Procedure_Code = "";
                        string Material_Code = "";
                        string returnvalue = ProductController.InsertFeesAdjustment(newsbentrycode, VouchertypeRegistrationFees, VoucherDate, lessamt, Pricing_Procedure_Code, Material_Code, UserID);
                        string returnvalue1 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT01", VoucherDate, STTax, Pricing_Procedure_Code, Material_Code, UserID);
                        string returnvalue2 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT02", VoucherDate, HTAx, Pricing_Procedure_Code, Material_Code, UserID);
                        string returnvalue3 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT03", VoucherDate, Etax, Pricing_Procedure_Code, Material_Code, UserID);

                    }

                    //Insert Discount Value
                    float TotalDiscount = float.Parse(TotalDiscountValue);
                    if (TotalDiscount <  0)
                    {
                        
                        ProductController.InsertFeesAdjustment(newsbentrycode, "ZA01", VoucherDate, TotalDiscount, "PP011", "", UserID);

                        DataSet dsTax = ProductController.GetTaxValue(1, newsbentrycode, TotalDiscount, Centercode);
                        float Taxtotalvalue = float.Parse(dsTax.Tables[0].Rows[0]["TotalTax"].ToString());
                        float STTax = float.Parse(dsTax.Tables[0].Rows[0]["Stax"].ToString());
                        float HTAx = float.Parse(dsTax.Tables[0].Rows[0]["Htax"].ToString());
                        float Etax = float.Parse(dsTax.Tables[0].Rows[0]["Etax"].ToString());
                        //STTax = STTax ;
                        //HTAx = HTAx ;
                        //Etax = Etax ;
                        string returnvalue1 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT01", VoucherDate, STTax, "PP011", "", UserID);
                        string returnvalue2 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT02", VoucherDate, HTAx, "PP011", "", UserID);
                        string returnvalue3 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT03", VoucherDate, Etax, "PP011", "", UserID);
                    }


                    
                    float TotalConcession = float.Parse(TotalConcessionValue);
                    if (TotalConcession < 0)
                    {
                        string a = ProductController.InsertFeesAdjustment(newsbentrycode, "ZC01", VoucherDate, TotalConcession, "PP011", "", UserID);
                        DataSet dsTax = ProductController.GetTaxValue(1, newsbentrycode, TotalDiscount, Centercode);
                        float Taxtotalvalue = float.Parse(dsTax.Tables[0].Rows[0]["TotalTax"].ToString());
                        float STTax = float.Parse(dsTax.Tables[0].Rows[0]["Stax"].ToString());
                        float HTAx = float.Parse(dsTax.Tables[0].Rows[0]["Htax"].ToString());
                        float Etax = float.Parse(dsTax.Tables[0].Rows[0]["Etax"].ToString());
                        STTax = STTax * -1;
                        HTAx = HTAx * -1;
                        Etax = Etax * -1;
                        string returnvalue1 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT01", VoucherDate, STTax, "PP011", "", UserID);
                        string returnvalue2 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT02", VoucherDate, HTAx, "PP011", "", UserID);
                        string returnvalue3 = ProductController.InsertFeesAdjustment(newsbentrycode, "ZT03", VoucherDate, Etax, "PP011", "", UserID);
                    }

                    //Confirm Student
                    AccountController.GetPaymentDetailsbySBEntrycode(newsbentrycode);
                    AccountController.GetPPgroupbysbentrycode(newsbentrycode);
                    AccountController.Getstudentledgerbysbentrycode(newsbentrycode);
                    string amountdiff = "";
                    SqlDataReader dr = AccountController.GetChequeOutstanding(newsbentrycode);
                        if ((((dr) != null)))
                        {
                            if (dr.Read())
                            {
                                amountdiff = dr["outstanding"].ToString();
                            }
                        }
                        //if (Convert.ToInt32(amountdiff) <= 0)
                        //{
                            string Output = AccountController.Confirmadmission(newsbentrycode);
                            if (Output == "XXX") {
                                Output = "03";
                            }
                            AccountController.BulkStreamChangeLog(lblsbentrycode.Text, newsbentrycode, Output,amountdiff);
                            AccountController.Getstudentledgerbysbentrycode(newsbentrycode);
                        //}
                        //else
                        //{
                        //    string Output = "Admission Pending";
                        //    AccountController.BulkStreamChangeLog(lblsbentrycode.Text, newsbentrycode, Output, amountdiff);
                        //    AccountController.Getstudentledgerbysbentrycode(newsbentrycode);
                        //}
                 }
           }
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;

        }
        btnsearch_ServerClick(sender, e);
    }


   

    protected void ddllanguage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        
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
            d.SelectedIndex = 0;

            //Dim Selgroup As Label = DirectCast(e.Item.FindControl("lblselgroup"), Label)
            //Dim Sgrgroup As String = Selgroup.Text
            //If Sgrgroup = "1" Then
            //    Dim Chk As CheckBox = DirectCast(e.Item.FindControl("ckhselect1"), CheckBox)
            //    Chk.Checked = True
            //    Chk.Enabled = False
            //End If


        }
    }
    protected void ddldestinationstream_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindOptionalSubject();
    }
}