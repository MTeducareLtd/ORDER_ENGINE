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
using System.Threading;
//using Exportxls.BL;


public partial class Contact_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["Lead_id"] != null)
            {
                string leadid = Request["Lead_id"];
                lblpagetitle1.Text = "Add Contact";
                lblpagetitle2.Text = "";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Contact";
                //lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Text = " Add Secondary Contact";
                divErrormessage.Visible = false;
                lblsuccessMessage.Visible = false;
                divSuccessmessage.Visible = false;
                string Menuid = "102";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                this.ddlcurrentstudying2.Items.Insert(0, "Select");
                this.ddlcurrentstudying2.SelectedIndex = 0;
                Institutetype();
                //Board()
                Yearofpassing();
                DivisionSession();
                ContactType();
                Country();
                ddlboard2.Items.Insert(0, "Select");
                ddlboard2.SelectedIndex = 0;
                Bindlist();
                BindSecContactDetails();
            }
        }

    }


    private void Bindlist()
    {

        try
        {

            if (Request["Lead_id"] != null)
            {
                string leadid = Request["Lead_id"];
                SqlDataReader dr = ProductController.Getleaddetailsbyleadid(leadid);
                if ((((dr) != null)))
                {
                    if (dr.Read())
                    {
                        txtleadtype.Text = dr["leadtype"].ToString();
                        txtleadsource.Text = dr["lead_src_desc"].ToString();
                        txtleadstatus.Text = dr["lead_status_desc"].ToString();
                        txtstudentname.Text = dr["Con_Firstname"].ToString() + " " + dr["Con_Midname"].ToString() + " " + dr["Con_lastname"].ToString();
                        txthandphone1.Text = dr["handphone1"].ToString();
                        txtlandline.Text = dr["landline"].ToString();
                        lblstudentname.Text = dr["Con_Title"].ToString() + " " + dr["Con_FirstName"].ToString() + " " + dr["Con_midname"].ToString() + " " + dr["Con_lastname"].ToString();


                        //txtseclandline.Text = dr("").ToString
                        //txtsecaddress1.Text = dr("").ToString
                        //txtsecaddress2.Text = dr("").ToString
                        //txtsecStreetname.Text = dr("").ToString
                        //ddlseccountry.SelectedValue = dr("").ToString

                    }

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
    private void BindSecContactDetails()
    {
        if (Request["Lead_id"] != null)
        {
            string lead_id = Request["Lead_id"];
            SqlDataReader dr = ProductController.Get_ContactbyLeadidforfield(1, lead_id);
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    lblprimaryconid.Text = dr["Lead_Con_id"].ToString();
                }
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
    private void Institutetype()
    {
        DataSet ds = ProductController.GetallInstituteType();
        BindDDL(ddlinstitutiontype2, ds, "Description", "ID");
        ddlinstitutiontype2.Items.Insert(0, "Select");
        ddlinstitutiontype2.SelectedIndex = 0;
    }
    protected void ddlinstitutiontype2_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype2.SelectedValue);
        BindDDL(ddlcurrentstudying2, ds, "Description", "ID");
        this.ddlcurrentstudying2.Items.Insert(0, "Select");
        this.ddlcurrentstudying2.SelectedIndex = 0;
        //Me.ddlinstitutiontype2.Focus()
        Bindboardbyid2();
    }
    private void Bindboardbyid2()
    {
        DataSet ds = ProductController.GetallBoardbyinstitutetype(ddlinstitutiontype2.SelectedValue);
        //BindDDL(ddlboard, ds, "Short_Description", "ID")
        //ddlboard.Items.Insert(0, "Select")
        //ddlboard.SelectedIndex = 0
        BindDDL(ddlboard2, ds, "Short_Description", "ID");
        ddlboard2.Items.Insert(0, "Select");
        ddlboard2.SelectedIndex = 0;
    }
    private void Board()
    {
        DataSet ds = ProductController.GetallBoard();
        BindDDL(ddlboard2, ds, "Short_Description", "ID");
        ddlboard2.Items.Insert(0, "Select");
        ddlboard2.SelectedIndex = 0;
    }
    private void Yearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlyearofpassing2, ds, "Description", "ID");
        ddlyearofpassing2.Items.Insert(0, "Select");
        ddlyearofpassing2.SelectedIndex = 0;
    }
    private void DivisionSession()
    {
        DataSet ds = ProductController.GetAllDivisionSection();
        BindDDL(ddlsection2, ds, "Description", "ID");
        ddlsection2.Items.Insert(0, "Select");
        ddlsection2.SelectedIndex = 0;
    }
    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactTypeSecondary();
        BindDDL(ddlseccontacttype1, ds, "Description", "ID");
        ddlseccontacttype1.Items.Insert(0, "Select");
        ddlseccontacttype1.SelectedIndex = 0;
    }
    private void Country()
    {
        DataSet ds = ProductController.GetallCountry();
        BindDDL(ddlseccountry, ds, "Country_Name", "Country_Code");
        ddlseccountry.Items.Insert(0, "Select");
        ddlseccountry.SelectedIndex = 0;
        ddlsecstate.Items.Insert(0, "Select");
        ddlsecstate.SelectedIndex = 0;
        ddlseccity.Items.Insert(0, "Select");
        ddlseccity.SelectedIndex = 0;
        ddlSeclocation.Items.Insert(0, "Select");
        ddlSeclocation.SelectedIndex = 0;

    }
    protected void ddlseccountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSecState();
        //ddlsecstate.Focus()
    }
    private void BindSecState()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlseccountry.SelectedValue);
        BindDDL(ddlsecstate, ds, "State_Name", "State_Code");
        ddlsecstate.Items.Insert(0, "Select");
        ddlsecstate.SelectedIndex = 0;
        ddlseccity.SelectedIndex = 0;
    }
    protected void ddlSecstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSecCity();
        //ddlseccity.Focus()
        ddlseccity.SelectedIndex = 0;
    }
    private void BindSecCity()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlsecstate.SelectedValue);
        BindDDL(ddlseccity, ds, "City_Name", "City_Code");
        ddlseccity.Items.Insert(0, "Select");
        ddlseccity.SelectedIndex = 0;
    }
    protected void ddlseccity_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSeclocationadd();
    }
    private void BindSeclocationadd()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlseccity.SelectedValue);
        BindDDL(ddlSeclocation, ds, "Location_Name", "Location_Code");
        ddlSeclocation.Items.Insert(0, "Select");
        ddlSeclocation.SelectedIndex = 0;

    }
    protected void btnSubmitSeccon_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtdateofbirth.Text))
            {
            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtdateofbirth.Text)) >DateTime.Today)
                {
                    lbldateerrordob.Visible = true;
                    lbldateerrordob.Text = "DOB cannot be a future date";
                    txtdateofbirth.Focus();
                    //lbldateerrorsubmit.Visible = False
                    return;
                }
                else
                {
                    //lbldateerrorsubmit.Visible = False
                    lbldateerrordob.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            lbldateerrordob.Visible = true;
            lbldateerrordob.Text = ex.Message;
            txtdateofbirth.Focus();
            return;
        }

        try
        {

            string SecContactTypeid = "";
            string Secgender = "";
            string SecTitle = "";
            string SecFname = "";
            string SecMname = "";
            string SecLname = "";
            string Sechphone1 = "";
            string Sechphone2 = "";
            string Seclandline = "";
            string Secemail = "";
            string SecAdd1 = "";
            string Secadd2 = "";
            string SecStreetname = "";
            string SecCountryname = "";
            string SecStatename = "'";
            string SecCityname = "";
            string SecpostalCode = "";
            string Secintitutiontype = "";
            string SecInstitutionname = "";
            string Secboard = "";
            string SecCurrstying = "";
            string SecDivision = "";
            string SecYOP = "";
            string SECAdditinalinfo = "";
            string Seccondesc = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Institutiontypeid = "";
            string InstituionTypedesc = "";
            string InstitutionName = "";
            string CurrentStandardid = "";
            string CurrentStandarddesc = "";
            string AdditionalDesc = "";
            string BoardUniversityid = "";
            string BoardUniversitydesc = "";
            string DivisionSectionGradeid = "";
            string DivisionSectionGradedesc = "";
            string Yearofpassingid = "";
            string Yearofpassingdesc = "";
            string Currentyearofeducationid = "";
            string Currentyearofeducationdesc = "";
            string PrimaryConid = "";
            PrimaryConid = lblprimaryconid.Text;
            SecContactTypeid = ddlseccontacttype1.SelectedValue;
            Seccondesc = ddlseccontacttype1.SelectedItem.Text;
            SecTitle = ddlsectitle.SelectedItem.Text;
            SecFname = txtsecfname.Text;
            SecMname = txtsecmname.Text;
            SecLname = txtseclname.Text;
            Sechphone1 = txtsechandphone1.Text;
            Sechphone2 = txtsechandphone2.Text;
            Seclandline = txtseclandline.Text;
            Secemail = txtsecemailid.Text;
            SecAdd1 = txtsecaddress1.Text;
            Secadd2 = txtsecaddress2.Text;
            SecStreetname = txtsecStreetname.Text;
            SecCountryname = ddlseccountry.SelectedValue;
            SecStatename = ddlsecstate.SelectedValue;
            SecCityname = ddlseccity.SelectedValue;
            SecpostalCode = txtsecpincode.Text;
            Institutiontypeid = ddlinstitutiontype2.SelectedValue;
            InstituionTypedesc = ddlinstitutiontype2.SelectedItem.Text;
            InstitutionName = txtnameofinstitution2.Text;
            CurrentStandardid = ddlcurrentstudying2.SelectedValue;
            CurrentStandarddesc = ddlcurrentstudying2.SelectedItem.Text;
            AdditionalDesc = txtadditiondesc2.Text;
            BoardUniversityid = ddlboard2.SelectedValue;
            BoardUniversitydesc = ddlboard2.SelectedItem.Text;
            DivisionSectionGradeid = ddlsection2.SelectedValue;
            DivisionSectionGradedesc = ddlsection2.SelectedItem.Text;
            Yearofpassingid = ddlyearofpassing2.SelectedValue;
            Yearofpassingdesc = ddlyearofpassing2.SelectedItem.Text;
            string Location = "";
            Location = ddlSeclocation.SelectedValue;
            string DOB = "";
            DOB = txtdateofbirth.Text;
            string Gender = "";
            Gender = ddlgenderadd.SelectedItem.Text;
            string Con_Id = ProductController.InsertSecondaryLeadContact(PrimaryConid, "", Institutiontypeid, InstituionTypedesc, InstitutionName, CurrentStandardid, CurrentStandarddesc, AdditionalDesc, BoardUniversityid, BoardUniversitydesc,
            DivisionSectionGradeid, DivisionSectionGradedesc, Yearofpassingid, Yearofpassingdesc, Currentyearofeducationid, Currentyearofeducationdesc, SecContactTypeid, Seccondesc, SecTitle, SecFname,
            SecMname, SecLname, Sechphone1, Sechphone2, Seclandline, Secemail, SecAdd1, Secadd2, SecStreetname, SecCountryname,
            SecStatename, SecCityname, SecpostalCode, Location, Gender, DOB);


            lblprimaryconid.Text = Con_Id;
            string Oppur_Id = Request["Lead_id"];
            Response.Redirect("Lead_Edit.aspx?&Lead_ID=" + Oppur_Id);
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void btnclearSeccon_ServerClick(object sender, System.EventArgs e)
    {
        string Oppur_Id = Request["Lead_id"];
        Response.Redirect("Lead_Edit.aspx?&Lead_ID=" + Oppur_Id);
    }


    protected void chkaddcopy_CheckedChanged(object sender, System.EventArgs e)
    {
        if (chkaddcopy.Checked == true)
        {
            string leadid = Request["Lead_id"];
            SqlDataReader dr = ProductController.Getleaddetailsbyleadid(leadid);
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    txtsecaddress1.Text = dr["Flatno"].ToString();
                    txtsecaddress2.Text = dr["BuildingName"].ToString();
                    txtsecStreetname.Text = dr["Streetname"].ToString();
                    ddlseccountry.SelectedValue = dr["Country"].ToString();
                    BindSecState();
                    ddlsecstate.SelectedValue = dr["State"].ToString();
                    BindSecCity();
                    ddlseccity.SelectedValue = dr["City"].ToString();
                    BindSeclocationadd();
                    ddlSeclocation.SelectedValue = dr["Location_id"].ToString();
                    txtsecpincode.Text = dr["Pincode"].ToString();
                }
            }
        }
        else
        {
            txtsecaddress1.Text = "";
            txtsecaddress2.Text = "";
            txtsecStreetname.Text = "";
            ddlseccountry.SelectedIndex = 0;
            ddlsecstate.SelectedIndex = 0;
            ddlseccity.SelectedIndex = 0;
            ddlSeclocation.SelectedIndex = 0;
            txtsecpincode.Text = "";
        }

    }

}