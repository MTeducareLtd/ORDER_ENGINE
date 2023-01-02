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
using Encryption.BL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;

public partial class I_Card_Print : System.Web.UI.Page
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
                lblpagetitle1.Text = "Print I-Card";
                lblpagetitle2.Text = "Search Panel";
                lblmidbreadcrumb.Text = "Print I-Card";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divpendingreuesterror.Visible = false;
                upnlsearch.Visible = true;
                listudentstatus.Visible = false;
                btnviewenrollment.Visible = false;
                btnviewenv.Visible = false;
                tdapplicationid.Visible = true;
                tdapplicationid1.Visible = true;
                
                divmessage.Visible = false;
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
        ddldivision.Items.Insert(0, "Select");
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


        DataSet ds = AccountController.Get_Account_Search_Results(StudentName, Applicationno, Company, Division, Zone, Center, AcademicYear, Stream, UserID, Customer_Type,
        Institutiontype, Boardid, Standard, Mobile, Country, State, City, Location, Productcategory, Fromdate,
        Todate, OrderStatus, Sbentrycode, Active, Promoted);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "Print I-Card";
            lblpagetitle2.Text = "Search Results";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Print I-Card";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = " Print I-Card Search Results";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            divmessage.Visible = false;
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            script1.RegisterAsyncPostBackControl(Repeater1);
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            divmessage.Visible = true;
            lblmessage.Text = "No Records Found!";
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

    protected void btnprint_ServerClick(object sender, System.EventArgs e)
    {
        string Sbentrycode = "";
        List<string> list = new List<string>();
        string Sgrcode = "";
        try
        {
            int TotalStud = 0;
            foreach (RepeaterItem dtlItem in Repeater1.Items)
            {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            Label lblsbentrycode = (Label)dtlItem.FindControl("Label43");
                if (chkitemck.Checked == true)
                {
                    list.Add(lblsbentrycode.Text);
                    Sgrcode = string.Join(",", list.ToArray());
                    TotalStud = TotalStud + 1;
                }
            }
              
            if (Sgrcode.Length > 0)
            {
                //Response.Redirect("ICARD_Print.aspx?sb=" + Sgrcode);
                //Print PDF
                try
                {
                   

                    

                    int mod = TotalStud % 10;
                    int TotalPage = TotalStud / 10;
                    if (mod > 0)
                    {
                        TotalPage++;
                    }
                    //Find Icard Image Path into C072_Receipt_Configuration
                    string ImagePath = "";
                    DataSet dsImagePath = ProductController.GetICardImagePath(1, ddldivision.SelectedValue);
                    if (dsImagePath.Tables[0].Rows.Count > 0)
                    {
                        ImagePath = dsImagePath.Tables[0].Rows[0]["IcardImagePath"].ToString();                        
                    }
                    else
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Icard Configration not maintained. Kindly Contact Administrator.";
                        return;
                    }

                    //If Icard Image Path into C072_Receipt_Configuration is find  but the image is not available into Server path then display Error
                    iTextSharp.text.Image jpg;

                    try
                    {
                         jpg = iTextSharp.text.Image.GetInstance(Server.MapPath(ImagePath));
                    }
                    catch (Exception ex)
                    {

                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        divSuccessmessage.Visible = false;
                        lblerrormessage.Text = "Icard Configration not maintained. Kindly Contact Administrator.";
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

                    int ActualStud = 0;
                    for (int i = 0; i < TotalPage; i++)
                    {
                        float YPos = 0;
                        YPos = 400;

                        
                        jpg.ScaleToFit(980, 580);
                        jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
                        jpg.SetAbsolutePosition(10, 10);
                        document.Add(jpg);

                        for (int j = 0; j < 5; j++)
                        {
                            if (ActualStud != TotalStud)
                            {
                                string ActualSBEntryCode = list[ActualStud] as string;

                                DataSet dsDetails = new DataSet();
                                dsDetails = ProductController.GetStudentDetailsBySBEntrycode(ActualSBEntryCode, 1);


                                if (dsDetails != null)
                                {
                                    if (dsDetails.Tables[0].Rows.Count > 0)
                                    {
                                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                                        PdfContentByte cb = writer.DirectContent;

                                        float Col0Left = 0;
                                        float Col1Left = 0;
                                        if (j == 0)
                                        {
                                            Col0Left = 15;
                                            Col1Left = 175;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            //cb.SetTextMatrix((Col1Left + ((Col3Left - Col1Left) / 2) - (cb.GetEffectiveStringWidth("Name Of Student", false) / 2)), YPos);
                                            //cb.SetTextMatrix(((Col0Left + 15)+ (((Col1Left) - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos + 135);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos + 135);//115
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos + 130);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos + 130);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos + 115);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos + 115);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos + 100);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos + 100);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(55, YPos - 23);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(55, YPos - 30);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(55, YPos - 37);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 60);//115
                                            //cb.SetTextMatrix(20, YPos - 60);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 67);//115
                                            //cb.SetTextMatrix(20, YPos - 67);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 74);//115
                                            //cb.SetTextMatrix(20, YPos - 74);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(59, YPos - 1);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                        else if (j == 1)
                                        {
                                            Col0Left = 175;
                                            Col1Left = 340;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);   
                                            //cb.SetTextMatrix((Col1Left + ((Col3Left - Col1Left) / 2) - (cb.GetEffectiveStringWidth("Name Of Student", false) / 2)), YPos);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos + 135);//115
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos + 135);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            //cb.SetTextMatrix(15, YPos + 135);
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 10);
                                            //cb.ShowText("Test");
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            //cb.SetTextMatrix(825, YPos + 135);
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 10);
                                            //cb.ShowText("Test");
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos + 130);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos + 130);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos + 115);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos + 115);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos + 100);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos + 100);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);                                                        
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(217, YPos - 23);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(217, YPos - 30);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(217, YPos - 37);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 60);//115
                                            //cb.SetTextMatrix(181, YPos - 60);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 67);//115
                                            //cb.SetTextMatrix(181, YPos - 67);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 74);//115
                                            //cb.SetTextMatrix(181, YPos - 74);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            //cb.SetTextMatrix(181, YPos - 60);                                            
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(221, YPos - 1);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                        else if (j == 2)
                                        {
                                            Col0Left = 340;
                                            Col1Left = 500;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos + 135);//115
                                            //cb.SetTextMatrix((Col1Left + ((Col3Left - Col1Left) / 2) - (cb.GetEffectiveStringWidth("Name Of Student", false) / 2)), YPos);
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos + 135);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos + 130);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos + 130);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos + 115);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos + 115);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos + 100);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos + 100);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(380, YPos - 23);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(380, YPos - 30);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(380, YPos - 37);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 60);//115
                                            //cb.SetTextMatrix(344, YPos - 60);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 67);//115
                                            //cb.SetTextMatrix(344, YPos - 67);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 74);//115
                                            //cb.SetTextMatrix(344, YPos - 74);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            //cb.SetTextMatrix(344, YPos - 60);                                            
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(384, YPos - 1);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);

                                                    //logo.SetAbsolutePosition(388, YPos - 1);
                                                    //logo.ScaleToFit(200, 85);
                                                    //logo.ScalePercent(35);
                                                    //document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                        else if (j == 3)
                                        {
                                            Col0Left = 500;
                                            Col1Left = 665;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos + 135);//115
                                            //cb.SetTextMatrix((Col1Left + ((Col3Left - Col1Left) / 2) - (cb.GetEffectiveStringWidth("Name Of Student", false) / 2)), YPos);
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos + 135);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos + 130);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos + 130);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos + 115);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos + 115);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos + 100);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos + 100);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(543, YPos - 23);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(543, YPos - 30);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(543, YPos - 37);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 60);//115
                                            //cb.SetTextMatrix(508, YPos - 60);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 67);//115
                                            //cb.SetTextMatrix(508, YPos - 67);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 74);//115
                                            //cb.SetTextMatrix(508, YPos - 74);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            //cb.SetTextMatrix(508, YPos - 60);
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(545, YPos - 1);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                        else if (j == 4)
                                        {
                                            Col0Left = 665;
                                            Col1Left = 825;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos + 135);//115
                                            //cb.SetTextMatrix((Col1Left + ((Col3Left - Col1Left) / 2) - (cb.GetEffectiveStringWidth("Name Of Student", false) / 2)), YPos);
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos + 135);                                            
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos + 130);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos + 130);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos + 115);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos + 115);                                            
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos + 100);//115
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(707, YPos - 23);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(707, YPos - 30);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(707, YPos - 37);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 60);//115
                                            //cb.SetTextMatrix(670, YPos - 60);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 67);//115
                                            //cb.SetTextMatrix(670, YPos - 67);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 74);//115
                                            //cb.SetTextMatrix(670, YPos - 74);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            //cb.SetTextMatrix(670, YPos - 60);
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(710, YPos - 1);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                    }
                                }
                                ActualStud++;
                            }
                        }
                        for (int k = 0; k < 5; k++)
                        {
                            if (ActualStud != TotalStud)
                            {
                                string ActualSBEntryCode = list[ActualStud] as string;

                                DataSet dsDetails = new DataSet();
                                dsDetails = ProductController.GetStudentDetailsBySBEntrycode(ActualSBEntryCode, 1);

                                if (dsDetails != null)
                                {

                                    if (dsDetails.Tables[0].Rows.Count > 0)
                                    {
                                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                                        PdfContentByte cb = writer.DirectContent;

                                        float Col0Left = 0;
                                        float Col1Left = 0;
                                        if (k == 0)
                                        {
                                            Col0Left = 15;
                                            Col1Left = 175;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            //cb.SetTextMatrix((Col1Left + ((Col3Left - Col1Left) / 2) - (cb.GetEffectiveStringWidth("Name Of Student", false) / 2)), YPos);
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos - 142);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos - 142);//115
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos - 147);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos - 162);//115
                                            //cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((lblFName.Text.Length) / 2)), YPos - 162);//115
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);
                                            
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos - 177);//100
                                            //cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos - 177);//115                                                                                       
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);                                          

                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(55, YPos - 299);//23
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(55, YPos - 306);//30
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(55, YPos - 313);//37
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 336);//115
                                            //cb.SetTextMatrix(20, YPos - 336);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 343);//115
                                            //cb.SetTextMatrix(20, YPos - 343);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 350);//115
                                            //cb.SetTextMatrix(20, YPos - 350);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            //cb.SetTextMatrix(20, YPos - 336);//60
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(59, YPos - 277);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                        else if (k == 1)
                                        {
                                            Col0Left = 175;
                                            Col1Left = 340;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos - 142);//100
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos - 142);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos - 147);//100
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos - 147);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos - 162);//100
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos - 162);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos - 177);//100
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos - 177);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(217, YPos - 299);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(217, YPos - 306);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(217, YPos - 313);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 336);//115
                                            //cb.SetTextMatrix(181, YPos - 336);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 343);//115
                                            //cb.SetTextMatrix(181, YPos - 343);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 350);//115
                                            //cb.SetTextMatrix(181, YPos - 350);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            //cb.SetTextMatrix(181, YPos - 336);
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(221, YPos - 277);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                        else if (k == 2)
                                        {
                                            Col0Left = 340;
                                            Col1Left = 500;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos - 142);//100                                            
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos - 142);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos - 147);//100                                            
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos - 147);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos - 162);//100                                            
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos - 162);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos - 177);//100                                            
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos - 177);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);


                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(380, YPos - 299);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(380, YPos - 306);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(380, YPos - 313);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);



                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 336);//115
                                            //cb.SetTextMatrix(344, YPos - 336);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 343);//115
                                            //cb.SetTextMatrix(344, YPos - 343);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 350);//115
                                            //cb.SetTextMatrix(344, YPos - 350);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            //cb.SetTextMatrix(344, YPos - 336);
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    //logo.SetAbsolutePosition(388, YPos - 277);
                                                    //logo.ScaleToFit(200, 85);
                                                    ////logo.ScalePercent(35);
                                                    //document.Add(logo);

                                                    logo.SetAbsolutePosition(384, YPos - 277);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);


                                                    //Image img = Image.GetInstance(imagePath);
                                                    //img.ScaleAbsolute(159f, 159f);
                                                    //PdfPTable table = new PdfPTable(1);
                                                    //table.AddCell(img);
                                                    //document.Add(table);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                        else if (k == 3)
                                        {
                                            Col0Left = 500;
                                            Col1Left = 665;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos - 142);//100                                                                                        
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos - 142);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos - 147);//100                                                                                        
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos - 147);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos - 162);//100                                                                                        
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos - 162);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos - 177);//100                                                                                        
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos - 177);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(543, YPos - 299);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(543, YPos - 306);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(543, YPos - 313);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);



                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 336);//115
                                            //cb.SetTextMatrix(508, YPos - 336);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 343);//115
                                            //cb.SetTextMatrix(508, YPos - 343);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 350);//115
                                            //cb.SetTextMatrix(508, YPos - 350);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            //cb.SetTextMatrix(508, YPos - 336);
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(545, YPos - 277);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                        else if (k == 4)
                                        {
                                            Col0Left = 665;
                                            Col1Left = 825;
                                            cb.BeginText();

                                            Label lblRollNo = new Label();
                                            Label lblStreamName = new Label();
                                            Label lblFName = new Label();
                                            Label lblLName = new Label();
                                            Label lblFlatno = new Label();
                                            Label lblBuildingName = new Label();
                                            Label lblStreetName = new Label();
                                            Label lblBranchAddress = new Label();
                                            //Label lblStudCity = new Label();

                                            lblRollNo.Text = dsDetails.Tables[0].Rows[0]["Student_RFID"].ToString();
                                            lblStreamName.Text = dsDetails.Tables[0].Rows[0]["Stream_SDesc"].ToString();
                                            lblFName.Text = dsDetails.Tables[0].Rows[0]["Firstname"].ToString();
                                            lblLName.Text = dsDetails.Tables[0].Rows[0]["LAST_NAME"].ToString();
                                            lblFlatno.Text = dsDetails.Tables[0].Rows[0]["Flatno"].ToString();
                                            lblBuildingName.Text = dsDetails.Tables[0].Rows[0]["BuildingName"].ToString();
                                            lblStreetName.Text = dsDetails.Tables[0].Rows[0]["StreetName"].ToString();
                                            lblBranchAddress.Text = dsDetails.Tables[0].Rows[0]["BranchAddress"].ToString();
                                            //lblStudCity.Text = dsDetails.Tables[0].Rows[0]["City_Name"].ToString();

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblRollNo.Text, false)) / 2)), YPos - 142);//100                                                                                                                                    
                                            //cb.SetTextMatrix(((Col0Left + 15) + ((Col1Left - Col0Left) / 2) - (lblRollNo.Text.Length / 2)), YPos - 142);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblRollNo.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblStreamName.Text, false)) / 2)), YPos - 147);//100                                                                                                                                    
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblStreamName.Text.Length / 2)), YPos - 147);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreamName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetFontAndSize(bf, 10);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblFName.Text, false)) / 2)), YPos - 162);//100                                                                                                                                    
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblFName.Text.Length / 2)), YPos - 162);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblFName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(lblLName.Text, false)) / 2)), YPos - 177);//100                                                                                                                                    
                                            //cb.SetTextMatrix((Col0Left + ((Col1Left - Col0Left) / 2) - (lblLName.Text.Length / 2)), YPos - 177);
                                            cb.SetFontAndSize(bf, 10);
                                            cb.ShowText(lblLName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            string s = lblFlatno.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblFlatno.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(707, YPos - 299);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblFlatno.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblBuildingName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblBuildingName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }


                                            cb.SetTextMatrix(707, YPos - 306);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblBuildingName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            s = lblStreetName.Text;
                                            if (s.Length > 30)
                                            {
                                                for (int a = 30; a < s.Length; a++)
                                                {
                                                    if ((s[a].ToString() == " ") || (s[a].ToString() == ","))
                                                    {
                                                        lblStreetName.Text = s.Substring(0, a + 1);
                                                        break;
                                                    }
                                                }
                                            }

                                            cb.SetTextMatrix(707, YPos - 313);
                                            //cb.SetTextMatrix(10, YPos + 100);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(lblStreetName.Text);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);



                                            string str = lblBranchAddress.Text;
                                            string value2 = str, value3 = "", value4 = "";
                                            if (str.Length > 50)
                                            {
                                                for (int a = 50; a < str.Length; a++)
                                                {
                                                    if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                    {
                                                        value2 = str.Substring(0, a + 1);
                                                        value3 = str.Substring(a + 1);
                                                        break;
                                                    }
                                                }
                                                str = value3;
                                                if (str.Length > 50)
                                                {
                                                    for (int a = 50; a < str.Length; a++)
                                                    {
                                                        if ((str[a].ToString() == " ") || (str[a].ToString() == ","))
                                                        {
                                                            value3 = str.Substring(0, a + 1);
                                                            value4 = str.Substring(a + 1);
                                                            break;
                                                        }
                                                    }
                                                    if (value4.Length > 50)
                                                    {
                                                        for (int a = 50; a < value4.Length; a++)
                                                        {
                                                            if ((value4[a].ToString() == " ") || (value4[a].ToString() == ","))
                                                            {
                                                                value4 = value4.Substring(0, a + 1);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }

                                            }

                                            cb.SetFontAndSize(bf, 5);
                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value2, false)) / 2)), YPos - 336);//115
                                            //cb.SetTextMatrix(670, YPos - 336);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value2);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value3, false)) / 2)), YPos - 343);//115
                                            //cb.SetTextMatrix(670, YPos - 343);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value3);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.SetTextMatrix(((Col0Left) + ((Col1Left - (Col0Left)) / 2) - ((cb.GetEffectiveStringWidth(value4, false)) / 2)), YPos - 350);//115
                                            //cb.SetTextMatrix(670, YPos - 350);
                                            cb.SetFontAndSize(bf, 5);
                                            cb.ShowText(value4);
                                            cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            //cb.SetTextMatrix(670, YPos - 336);
                                            ////cb.SetTextMatrix(10, YPos + 100);
                                            //cb.SetFontAndSize(bf, 5);
                                            //cb.ShowText(lblBranchAddress.Text);
                                            //cb.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_FILL);

                                            cb.EndText();
                                            if ((dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != null) || (dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString() != ""))
                                            {
                                                try
                                                {
                                                    dynamic logo = iTextSharp.text.Image.GetInstance(Server.MapPath(dsDetails.Tables[0].Rows[0]["Stud_Image"].ToString()));
                                                    logo.SetAbsolutePosition(710, YPos - 277);
                                                    logo.ScaleToFit(200, 95);
                                                    logo.ScaleAbsolute(80, 82);
                                                    //logo.ScalePercent(35);
                                                    document.Add(logo);
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                    }
                                }
                                ActualStud++;
                            }
                        }
                        document.NewPage();
                    }

                    document.Close();

                    string CurTimeFrame = null;
                    CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename=ICard_{0}.pdf", CurTimeFrame));
                    Response.BinaryWrite(output.ToArray());
                }
                catch (Exception ex)
                {

                    divErrormessage.Visible = true;
                    divSuccessmessage.Visible = false;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = ex.ToString();
                }
            }
            else
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "No Records Selected.";
            }
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
            
        }
    }
}