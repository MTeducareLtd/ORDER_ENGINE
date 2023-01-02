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

public partial class Lead_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //lblpagetitle1.Text = "Add Lead";
            //lblpagetitle2.Text = "";
            limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Lead";
            lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = " Add Lead";
            divErrormessage.Visible = false;
            lblsuccessMessage.Visible = false;
            divSuccessmessage.Visible = false;
            divsuccessmessage1.Visible = false;
            lbldateerror.Visible = false;
            string Menuid = "102";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            txt1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            upnlsearch.Visible = true;
            UpnlSecContact.Visible = false;
            tblorgassign.Visible = false;
            tdstudentid.Visible = false;
            tdstudentid1.Visible = false;
            tdlastcourse.Visible = false;
            tdlastcourse1.Visible = false;
            //CompareValidator1.ValueToCompare = DateTime.Now.[Date].ToShortDateString()
            Leadtype();
            LeadSource();
            leadstatus();
            StudentType();
            BindSourceCompany();
            BindTargetCompany();
            Country();
            Discipline();
            Scorerange();
            Institutetype();
            //Board()
            Yearofpassing();
            Currentyear();
            CurrentyearEducation();
            DivisionSession();
            ContactType();
            BindScore();

            ddlfieldint.Items.Insert(0, "Select");
            ddlfieldint.SelectedIndex = 0;
            ddlboard.Items.Insert(0, "Select");
            ddlboard.SelectedIndex = 0;
            ddlboard2.Items.Insert(0, "Select");
            ddlboard2.SelectedIndex = 0;
            this.ddlcurrentstudying2.Items.Insert(0, "Select");
            this.ddlcurrentstudying2.SelectedIndex = 0;
            
            //For Robomate Integration
            GetAllDeviceType();
            GetAllProvider();
            GetAllOwnedby();
            GetAllPlatform();
            GetAllDevicebrand();
            GetAllAccessmode();
            GetAllStorageMediaType();
            GetAllInstallationType();

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
            if (UserCompany == "MPUC1")
            {
                tr1.Visible = false;
                tr2.Visible = false;
                tr3.Visible = false;
            }
            else
            {
                tr1.Visible = false;
                tr2.Visible = false;
                tr3.Visible = false;
                RequiredFieldValidator32.Visible = false;
                txtExpjoindate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                label17.Visible = false;
            }
        }


    }



    protected void btnSubmitNewlead_ServerClick(object sender, System.EventArgs e)
    {
        try
        {

            if (string.IsNullOrEmpty(txtExpjoindate.Text))
            {
                //ElseIf CDate(ClsCommon.FormatDate(txtExpjoindate.Text)) < Today Then
                //    lbldateerror.Visible = True
                //    lbldateerror.Text = "Joining Date cannot be a past date"
                //    txtExpjoindate.Focus()
                //    Exit Sub
            }
        }
        catch (Exception ex)
        {
            lbldateerror.Visible = true;
            lbldateerror.Text = ex.Message;
            return;
        }
        try
        {
            if (string.IsNullOrEmpty(txtdateofbirth.Text))
            {
            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtdateofbirth.Text)) > DateTime.Today)
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
            return;
        }

        try
        {
            string Leadtype = "";
            string LeadSource = "";
            string LeadSourcedesc = "";
            string LeadStatus = "";
            string LeadStatusdesc = "";
            string Campaignid = "";
            string SourceDesc = "";
            string ContactTYpe = "";
            string Contact_Type_Desc = "";
            string Gender = "";
            string Title = "";
            string Fname = "";
            string Mname = "";
            string Lname = "";
            string CategoryType = "";
            string Category_Type_Id = "";
            decimal Score = 0;
            decimal Percentile = 0;
            int AreaRank = 0;
            int Overallrank = 0;
            string Scorerangetype = "";
            string SourceCompany = "";
            string Sourcedivision = "";
            string SourceZone = "";
            string SourceCenter = "";
            string TargetCompany = "";
            string Targetdivision = "";
            string TargetZone = "";
            string TargetCenter = "";
            string Role = "";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Assignedto = "";

            string handphone1 = "";
            string handphone2 = "";
            string landline = "";
            string emailid = "";
            string flatno = "";
            string buildingname = "";
            string Streetname = "";
            string Countryname = "";
            string State = "";
            string City = "";
            string Pincode = "";



            int Interested_Discipline_Id = 0;
            string Interested_Discipline_Desc = "";
            int Interested_Field_Id = 0;
            string Interested_Field_Desc = "";
            string CompetitiveExam = "";

            string Lead_Type_desc = "";

            // Addition field added on 08-01-2014
            string Productinterested = "";
            DateTime ExpectedJoindate = default(DateTime);

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
            string Studentid = "";
            string LastcourseOpted = "";
            int MSmarkstotal = 0;
            int MSMarksobtained = 0;

            //Added by rakesh for current year of education 20/10/2014
            int C_Year_Education = 0;

            Leadtype = ddlleadtypeadd.SelectedValue;
            LeadSource = ddlleadsourceadd.SelectedValue;
            LeadSourcedesc = ddlleadsourceadd.SelectedItem.Text;
            LeadStatus = ddlleadstatusadd.SelectedValue;
            LeadStatusdesc = ddlleadstatusadd.SelectedItem.Text;
            Campaignid = ddlcampaignid.SelectedValue;
            SourceDesc = txtsourcedesc.Text;
            ContactTYpe = ddlcontacttype1.SelectedValue;
            Contact_Type_Desc = ddlcontacttype1.SelectedItem.Text;
            Gender = ddlgenderadd.SelectedItem.Text;
            Title = ddltitle.SelectedItem.Text;
            Fname = txtfirstname.Text.ToUpper();
            Mname = txtmidname.Text.ToUpper() ;
            Lname = txtlastname.Text.ToUpper();
            CategoryType = ddlstudenttypeadd.SelectedItem.Text;
            Category_Type_Id = ddlstudenttypeadd.SelectedValue;

            if (this.ddlcurrentyeareducation.Text == "Select")
            {
                C_Year_Education = 0;
            }
            else
            {
                C_Year_Education =Convert.ToInt32(ddlcurrentyeareducation.SelectedValue);
            }

            if (lblusercompany.Text == "MPUC")
            {
                Score = 0;
                Percentile = 0;
                AreaRank = 0;
                Overallrank = 0;
                Scorerangetype = "";
                Interested_Discipline_Id = 0;
                Interested_Discipline_Desc = "";
                Interested_Field_Id = 0;
                Interested_Field_Desc = "";
                CompetitiveExam = "";
                MSmarkstotal = 0;
                MSMarksobtained = 0;
            }
            else
            {
                //for MT Science Changes
                if (string.IsNullOrEmpty(txtscore.Text))
                {
                    Score = 0;
                }
                else
                {
                    Score =Convert.ToDecimal(txtscore.Text);
                }

                if (string.IsNullOrEmpty(txtpercentage.Text))
                {
                    Percentile = 0;
                }
                else
                {
                    Percentile =Convert.ToDecimal(txtpercentage.Text);
                }
                if (string.IsNullOrEmpty(txtarearank.Text))
                {
                    AreaRank = 0;
                }
                else
                {
                    AreaRank =Convert.ToInt32(txtarearank.Text);
                }
                if (string.IsNullOrEmpty(txtoverallrank.Text))
                {
                    Overallrank = 0;
                }
                else
                {
                    Overallrank =Convert.ToInt32(txtoverallrank.Text);
                }
                Scorerangetype = ddlscorerange.SelectedValue;



                if (ddldiscipline.SelectedItem.Text == "Select")
                {
                    Interested_Discipline_Id = 0;
                    Interested_Discipline_Desc = "Select";
                }
                else
                {
                    Interested_Discipline_Id =Convert.ToInt32(ddldiscipline.SelectedValue);
                    Interested_Discipline_Desc = ddldiscipline.SelectedItem.Text;
                }
                if (ddlfieldint.SelectedItem.Text == "Select")
                {
                    Interested_Field_Id = 0;
                    Interested_Field_Desc = "Select";
                }
                else
                {
                    Interested_Field_Id =Convert.ToInt32(ddlfieldint.SelectedValue);
                    Interested_Field_Desc = ddlfieldint.SelectedItem.Text;
                }
                CompetitiveExam = txtcompetitiveexams.Text;

                if (string.IsNullOrEmpty(txtmsmarks.Text))
                {
                    MSmarkstotal = 0;
                }
                else
                {
                    MSmarkstotal =Convert.ToInt32(txtmsmarks.Text);
                }

                if (string.IsNullOrEmpty(txtmsobtained.Text))
                {
                    MSMarksobtained = 0;
                }
                else
                {
                    MSMarksobtained =Convert.ToInt32(txtmsobtained.Text);
                }
            }




            //Code done on 08-Jan-2014
            Productinterested = txtproductInterested.Text;
            if (string.IsNullOrEmpty(txtExpjoindate.Text))
            {
                txtExpjoindate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ExpectedJoindate = Convert.ToDateTime(txtExpjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            else
            {
                ExpectedJoindate = Convert.ToDateTime(txtExpjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            //ExpectedJoindate = Request.Form("expclosedate")
            Institutiontypeid = ddlinstitutiontype.SelectedValue;
            InstituionTypedesc = ddlinstitutiontype.SelectedItem.Text;
            InstitutionName = txtnameofinstitution.Text;
            CurrentStandardid = ddlcurrentstudying.SelectedValue;
            CurrentStandarddesc = ddlcurrentstudying.SelectedItem.Text;
            AdditionalDesc = txtadditiondesc.Text;
            BoardUniversityid = ddlboard.SelectedValue;
            BoardUniversitydesc = ddlboard.SelectedItem.Text;
            DivisionSectionGradeid = ddlsection.SelectedValue;
            DivisionSectionGradedesc = ddlsection.SelectedItem.Text;
            Yearofpassingid = ddlyearofpassing.SelectedValue;
            Yearofpassingdesc = ddlyearofpassing.SelectedItem.Text;
            Currentyearofeducationid = ddlacademicyear.SelectedValue;
            Currentyearofeducationdesc = ddlacademicyear.SelectedItem.Text;




            if (ddlstudenttypeadd.SelectedValue == "01")
            {
                SourceCompany = ddlsourcecompanyadd.SelectedValue;
                TargetCompany = ddltargetcompanyadd.SelectedValue;
                Sourcedivision = ddlSourcedivisionadd.SelectedValue;
                SourceZone = ddlSourcezoneadd.SelectedValue;
                SourceCenter = ddlSourcecenteradd.SelectedValue;
                Targetdivision = ddltargetdivisionadd.SelectedValue;
                TargetZone = ddltargetzoneadd.SelectedValue;
                TargetCenter = ddltargetcenteradd.SelectedValue;
                Studentid = txtstudentid.Text;
                LastcourseOpted = txtlastcourseopted.Text;
            }
            else if (ddlstudenttypeadd.SelectedValue == "02")
            {
                TargetCompany = ddltargetcompanyadd.SelectedValue;
                Targetdivision = ddltargetdivisionadd.SelectedValue;
                TargetZone = ddltargetzoneadd.SelectedValue;
                TargetCenter = ddltargetcenteradd.SelectedValue;
                Sourcedivision = "";
                SourceZone = "";
                SourceCenter = "";
            }
            else if (ddlstudenttypeadd.SelectedValue == "03")
            {
                SourceCompany = ddlsourcecompanyadd.SelectedValue;
                TargetCompany = ddltargetcompanyadd.SelectedValue;
                Sourcedivision = ddlSourcedivisionadd.SelectedValue;
                SourceZone = ddlSourcezoneadd.SelectedValue;
                SourceCenter = ddlSourcecenteradd.SelectedValue;
                Targetdivision = ddltargetdivisionadd.SelectedValue;
                TargetZone = ddltargetzoneadd.SelectedValue;
                TargetCenter = ddltargetcenteradd.SelectedValue;
                Studentid = txtstudentid.Text;
                LastcourseOpted = txtlastcourseopted.Text;
            }
            else if (ddlstudenttypeadd.SelectedValue == "04")
            {
                TargetCompany = ddltargetcompanyadd.SelectedValue;
                Targetdivision = ddltargetdivisionadd.SelectedValue;
                TargetZone = ddltargetzoneadd.SelectedValue;
                TargetCenter = ddltargetcenteradd.SelectedValue;
                Sourcedivision = "";
                SourceZone = "";
                SourceCenter = "";
            }
            else
            {
                SourceCompany = "";
                Sourcedivision = "";
                SourceZone = "";
                SourceCenter = "";
                TargetCompany = "";
                Targetdivision = "";
                TargetZone = "";
                TargetCenter = "";
                Studentid = "";
                LastcourseOpted = "";

            }


            //Role = ddlrole.SelectedValue
            Assignedto = UserID;

            handphone1 = txthandphone1.Text;
            handphone2 = txthandphone2.Text;
            landline = txtlandline.Text;
            emailid = txtemailid.Text;
            flatno = txtflatno.Text;
            buildingname = txtbuildingno.Text;
            Streetname = txtstreetname.Text;
            Countryname = ddlcountry.SelectedValue;
            State = ddlstate.SelectedValue;
            City = ddlcity.SelectedValue;
            Pincode = txtpincode.Text;

            Lead_Type_desc = ddlleadtypeadd.SelectedItem.Text;


            string SecContactType = "";
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

            SecContactType = ddlseccontacttype.SelectedValue;
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

            string Seccondesc = "";

            string Dob = "";
            string leadsourceAdditionaldesc = "";
            string Examination = "";

            Dob = txtdateofbirth.Text;
            leadsourceAdditionaldesc = txtsourcedesc.Text;
            Examination = txtexaminationdetails.Text;

            string Location = "";
            Location = ddllocation.SelectedValue;

            //Seccondesc = ddlseccontacttype.SelectedItem.Text
            //Dim cookie As HttpCookie = Request.Cookies.[Get]("MyCookiesLoginInfo")
            //Dim UserID As String = cookie.Values["UserID"]
            //Dim UserName As String = cookie.Values["UserName"]

            string Con_Id = ProductController.InsertAddManualLeadContact("", ContactTYpe, Contact_Type_Desc, Title, Fname, Mname, Lname, Score, Percentile, AreaRank,
            Overallrank, Scorerangetype, "", LeadSource, LeadSourcedesc, Leadtype, LeadStatus, LeadStatusdesc, "", Productinterested,
            "", SourceCompany, Sourcedivision, SourceCenter, SourceZone, Role, Assignedto, UserID, UserID, "",
            "", "", TargetCompany, Targetdivision, TargetZone, TargetCenter, handphone1, handphone2, landline, emailid,
            flatno, buildingname, Streetname, Countryname, State, City, Pincode, Interested_Discipline_Id, Interested_Discipline_Desc, Interested_Field_Id,
            Interested_Field_Desc, CompetitiveExam, Lead_Type_desc, Category_Type_Id, CategoryType, Institutiontypeid, InstituionTypedesc, InstitutionName, CurrentStandardid, CurrentStandarddesc,
            AdditionalDesc, BoardUniversityid, BoardUniversitydesc, DivisionSectionGradeid, DivisionSectionGradedesc, Yearofpassingid, Yearofpassingdesc, Currentyearofeducationid, Currentyearofeducationdesc, Studentid,
            LastcourseOpted, ExpectedJoindate, SecContactType, SecTitle, SecFname, SecMname, SecLname, Sechphone1, Sechphone2, Seclandline,
            Secemail, SecAdd1, Secadd2, SecStreetname, SecCountryname, SecStatename, SecCityname, SecpostalCode, Seccondesc, MSmarkstotal,
            MSMarksobtained, leadsourceAdditionaldesc, Dob, Examination, Location, Gender, C_Year_Education);

            lblprimaryconid.Text = Con_Id;
            InsertScore();

            if (chkmaindevicedetails.Checked == true)
            {
                //string Conid = "";
                string User_Device_id = ddldevice.SelectedValue;
                string Provided_By_id = ddlprovidedby.SelectedValue;
                string Owned_By_Id = ddlownedby.SelectedValue;
                string platform_id = ddlplatform.SelectedValue;
                string Device_Brand_Id = ddldevicebrand.SelectedValue;
                string Device_Brand_Addl_Text = txtotherbrand.Text;
                string Device_Model = txtdevicemodel.Text;
                string Device_Config = txtdeviceconfig.Text;
                string Access_Mode_Id = ddlaccessmode.SelectedValue;
                string Storage_Media_type_Id = ddlstoragemediatype.SelectedValue;
                string Capacity = ddlcapacity.SelectedValue;
                string HDD_Free_Space = txthddfreespace.Text;
                string No_of_Storage_Media = ddlnoofstorage.SelectedValue;
                string Special_Instruction_1 = txtsi1.Text;
                string Special_Instruction_2 = txtsi2.Text;
                string Special_Instruction_3 = txtsi3.Text;

                string Installation_Location = ddlinstallationlocation.SelectedItem.Text;
                string Appointment_Date = date_picker.Text;
                //string Appointment_Date1 = Appointment_Date.ToString("dd MMM yyyy");
                string Appointment_Time = timepicker1.Value;
                string Installation_Date = date_picker1.Text;
                string Installation_Time = timepicker2.Value;
                string Installation_Status_Id = ddlinstallationstatus.SelectedValue;
                string Rescheduled_Date = date_picker2.Text;
                string Rescheduled_Time = timepicker3.Value;
                string Engineer_Name = txtengineername.Text;
                string Contact_Number = txtengineercontactnumber.Text;
                string Email_Id = txtengineeremailid.Text;
                string Engineer_Company = txtengineercompany.Text;

                string Robomate_Details_Id = Robomate_Integration_Lead.Insert_Robomate_Dtls("", TargetCompany, Targetdivision,
                    TargetCenter, Leadtype, Con_Id, User_Device_id,
                    Provided_By_id, Owned_By_Id, platform_id, Device_Brand_Id,
                    Device_Brand_Addl_Text, Device_Model, Device_Config, Access_Mode_Id,
                    Storage_Media_type_Id, Capacity, HDD_Free_Space, No_of_Storage_Media,
                    Special_Instruction_1, Special_Instruction_2, Special_Instruction_3, "", UserID, "", UserID,
                    Installation_Location, Appointment_Date, Appointment_Time,
                    Installation_Date, Installation_Time, Installation_Status_Id,
                    Rescheduled_Date, Rescheduled_Time, Engineer_Name, Contact_Number,
                    Email_Id, Engineer_Company
                    );
            }

            Clearall();
            txtsourcedesc.Text = "";
            ddlgenderadd.SelectedIndex = 0;
            ddltitle.SelectedIndex = 0;
            txtfirstname.Text = "";
            txtmidname.Text = "";
            txtlastname.Text = "";
            txtassignedto.Text = "";
            txthandphone1.Text = "";
            txthandphone2.Text = "";
            txtlandline.Text = "";
            txtemailid.Text = "";
            txtflatno.Text = "";
            txtbuildingno.Text = "";
            txtstreetname.Text = "";
            txtpincode.Text = "";
            txtproductInterested.Text = "";
            //txtExpjoindate.Text = ""
            txtnameofinstitution.Text = "";
            txtadditiondesc.Text = "";
            divSuccessmessage.Visible = false;
            txtstudentid.Text = "";
            txtlastcourseopted.Text = "";
            //Country()
            divSuccessmessage.Visible = false;
            lblsuccessMessage.Visible = false;
            lblsuccessMessage.Text = "Lead Successfully Added";
            divsuccessmessage1.Visible = true;
            //ddlseccontacttype.SelectedIndex = 0
            ddlsectitle.SelectedIndex = 0;
            ddlgenderadd.SelectedIndex = 0;
            ddltitle.SelectedIndex = 0;
            txtsecfname.Text = "";
            txtsecmname.Text = "";
            txtseclname.Text = "";
            txtsechandphone1.Text = "";
            txtsechandphone2.Text = "";
            txtseclandline.Text = "";
            txtsecemailid.Text = "";
            txtsecaddress1.Text = "";
            txtsecaddress2.Text = "";
            txtsecStreetname.Text = "";
            txtsecpincode.Text = "";
            upnlsearch.Visible = false;
            lblleadscuccess.Text = "Lead Successfully Added";
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }

    }
    private void Clearall()
    {
        Leadtype();
        LeadSource();
        leadstatus();
        StudentType();
        BindSourceCompany();
        BindTargetCompany();
        Country();
        Discipline();
        Scorerange();
        Institutetype();
        //Board()
        Yearofpassing();
        Currentyear();
        DivisionSession();
        ContactType();

    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void BindScore()
    {
        string Oppid = "";
        string Scoretypeid = "";
        string Score = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int Id = 0;
        DataSet ds = ProductController.GetAllScore(1, Oppid, Scoretypeid, Score, UserID, Id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlScore.DataSource = ds;
            dlScore.DataBind();
            //divsubjecterror.Visible = False
        }
        else
        {
            //divsubjecterror.Visible = True
            //Label33.Text = "No Marks Entered!"
        }
    }
    private void InsertScore()
    {
        string Conid = lblprimaryconid.Text;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string User_id = cookie.Values["UserID"];
        object obj = null;
        Label lblscoredesc = default(Label);
        Label lblscoreid = default(Label);
        TextBox txtscore = default(TextBox);

        foreach (DataListItem li in dlScore.Items)
        {
            obj = li.FindControl("lblscoretypedesc");
            if (obj != null)
            {
                lblscoredesc = (Label)obj;
            }

            obj = li.FindControl("lblscoreid");
            if (obj != null)
            {
                lblscoreid = (Label)obj;
            }

            obj = li.FindControl("txtscore");
            if (obj != null)
            {
                txtscore = (TextBox)obj;
            }

            if (string.IsNullOrEmpty(txtscore.Text))
            {
            }
            else
            {
                ProductController.InsertScore(2, Conid, lblscoreid.Text, txtscore.Text, User_id, 1);
            }

        }

    }
    private void Leadtype()
    {
        DataSet ds = ProductController.Getallactiveleadtype();
        BindDDL(ddlleadtypeadd, ds, "Description", "ID");
        ddlleadtypeadd.Items.Insert(0, "Select");
        ddlleadtypeadd.SelectedIndex = 0;

    }
    private void LeadSource()
    {
        DataSet ds = ProductController.GetallactiveleadSource();
        BindDDL(ddlleadsourceadd, ds, "Description", "ID");
        ddlleadsourceadd.Items.Insert(0, "Select");
        ddlleadsourceadd.SelectedIndex = 0;

    }
    private void leadstatus()
    {
        DataSet ds = ProductController.GetallactiveleadStatus();
        BindDDL(ddlleadstatusadd, ds, "Description", "ID");
        ddlleadstatusadd.Items.Insert(0, "Select");
        ddlleadstatusadd.SelectedIndex = 0;
    }
    private void StudentType()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlstudenttypeadd, ds, "Description", "Cust_Grp");
        ddlstudenttypeadd.Items.Insert(0, "Select");
        ddlstudenttypeadd.SelectedIndex = 0;
    }
    private void Discipline()
    {
        DataSet ds = ProductController.GetallDiscipline();
        BindDDL(ddldiscipline, ds, "Discipline_Desc", "Discipline_Id");
        ddldiscipline.Items.Insert(0, "Select");
        ddldiscipline.SelectedIndex = 0;
    }
    private void Scorerange()
    {
        DataSet ds = ProductController.GetScorerange();
        BindDDL(ddlscorerange, ds, "Description", "ID");
        ddlscorerange.Items.Insert(0, "Select");
        ddlscorerange.SelectedIndex = 0;
    }
    protected void ddldiscipline_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddldiscipline.SelectedIndex == 0)
        {
            ddlfieldint.SelectedIndex = 0;
        }
        else
        {
            FieldInterested();
        }
    }
    private void FieldInterested()
    {
        int DisciplineId = 0;
        DisciplineId = Convert.ToInt32(ddldiscipline.SelectedValue);
        DataSet ds = ProductController.GetAllFieldInterestedByDisciplineid(DisciplineId);
        BindDDL(ddlfieldint, ds, "IField_Desc", "C24_Ifieldid");
        ddlfieldint.Items.Insert(0, "Select");
        ddlfieldint.SelectedIndex = 0;
    }

    private void Institutetype()
    {
        DataSet ds = ProductController.GetallInstituteType();
        BindDDL(ddlinstitutiontype, ds, "Description", "ID");
        ddlinstitutiontype.Items.Insert(0, "Select");
        ddlinstitutiontype.SelectedIndex = 0;
        BindDDL(ddlinstitutiontype2, ds, "Description", "ID");
        ddlinstitutiontype2.Items.Insert(0, "Select");
        ddlinstitutiontype2.SelectedIndex = 0;
    }
    protected void ddlinstitutiontype_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
        BindDDL(ddlcurrentstudying, ds, "Description", "ID");
        this.ddlcurrentstudying.Items.Insert(0, "Select");
        this.ddlcurrentstudying.SelectedIndex = 0;
        //Me.ddlinstitutiontype.Focus()
        Bindboardbyid();

    }
    protected void ddlinstitutiontype2_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype2.SelectedValue);
        BindDDL(ddlcurrentstudying2, ds, "Description", "ID");
        this.ddlcurrentstudying2.Items.Insert(0, "Select");
        this.ddlcurrentstudying2.SelectedIndex = 0;
        Bindboardbyid2();
        //Me.ddlinstitutiontype2.Focus()
    }
    private void Bindboardbyid()
    {
        DataSet ds = ProductController.GetallBoardbyinstitutetype(ddlinstitutiontype.SelectedValue);
        BindDDL(ddlboard, ds, "Short_Description", "ID");
        ddlboard.Items.Insert(0, "Select");
        ddlboard.SelectedIndex = 0;
        //BindDDL(ddlboard2, ds, "Short_Description", "ID")
        //ddlboard2.Items.Insert(0, "Select")
        //ddlboard2.SelectedIndex = 0
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
        BindDDL(ddlboard, ds, "Short_Description", "ID");
        ddlboard.Items.Insert(0, "Select");
        ddlboard.SelectedIndex = 0;
        BindDDL(ddlboard2, ds, "Short_Description", "ID");
        ddlboard2.Items.Insert(0, "Select");
        ddlboard2.SelectedIndex = 0;
    }

    private void Yearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlyearofpassing, ds, "Description", "ID");
        ddlyearofpassing.Items.Insert(0, "Select");
        ddlyearofpassing.SelectedIndex = 0;
        BindDDL(ddlyearofpassing2, ds, "Description", "ID");
        ddlyearofpassing2.Items.Insert(0, "Select");
        ddlyearofpassing2.SelectedIndex = 0;
    }
    private void Currentyear()
    {
        DataSet ds = ProductController.GetAllCurrentyear();
        BindDDL(ddlacademicyear, ds, "Description", "ID");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
    }
    private void CurrentyearEducation()
    {
        DataSet ds = ProductController.GetAllCurrentyearEducation();
        BindDDL(ddlcurrentyeareducation, ds, "Current_Year_Education", "Year_ID");
        ddlcurrentyeareducation.Items.Insert(0, "Select");
        ddlcurrentyeareducation.SelectedIndex = 0;
    }
    private void DivisionSession()
    {
        DataSet ds = ProductController.GetAllDivisionSection();
        BindDDL(ddlsection, ds, "Description", "ID");
        ddlsection.Items.Insert(0, "Select");
        ddlsection.SelectedIndex = 0;
        BindDDL(ddlsection2, ds, "Description", "ID");
        ddlsection2.Items.Insert(0, "Select");
        ddlsection2.SelectedIndex = 0;
    }
    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactType();
        BindDDL(ddlcontacttype1, ds, "Description", "ID");
        ddlcontacttype1.Items.Insert(0, "Select");
        ddlcontacttype1.SelectedIndex = 0;
    }
    protected void ddlcontacttype1_SelectedIndexChanged1(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetAllSContactTypebyPContactType(ddlcontacttype1.SelectedValue);
        BindDDL(ddlseccontacttype, ds, "Description", "ID");
        ddlseccontacttype.Items.Insert(0, "Select");
        ddlseccontacttype.SelectedIndex = 0;
    }


    private void BindSourceCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(7, "", "", "", "");
        BindDDL(ddlsourcecompanyadd, ds, "Company_Name", "Company_Code");
        ddlsourcecompanyadd.Items.Insert(0, "Select");
        ddlsourcecompanyadd.SelectedIndex = 0;
        ddlSourcedivisionadd.Items.Insert(0, "Select");
        ddlSourcedivisionadd.SelectedIndex = 0;
        ddlSourcezoneadd.Items.Insert(0, "Select");
        ddlSourcezoneadd.SelectedIndex = 0;
        ddlSourcecenteradd.Items.Insert(0, "Select");
        ddlSourcecenteradd.SelectedIndex = 0;
    }
    private void BindTargetCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddltargetcompanyadd, ds, "Company_Name", "Company_Code");
        ddltargetcompanyadd.Items.Insert(0, "Select");
        ddltargetcompanyadd.SelectedIndex = 0;
        ddltargetdivisionadd.Items.Insert(0, "Select");
        ddltargetdivisionadd.SelectedIndex = 0;
        ddltargetzoneadd.Items.Insert(0, "Select");
        ddltargetzoneadd.SelectedIndex = 0;
        ddltargetcenteradd.Items.Insert(0, "Select");
        ddltargetcenteradd.SelectedIndex = 0;
    }
    protected void ddlcompanyadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSourceDivisionAdd();
        //ddlSourcedivisionadd.SelectedIndex = 0
        ddlSourcezoneadd.SelectedIndex = 0;
        ddlSourcecenteradd.SelectedIndex = 0;
        //ddlSourcedivisionadd.Focus()
    }
    private void BindSourceDivisionAdd()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(8, "", "", "", ddlsourcecompanyadd.SelectedValue);
        BindDDL(ddlSourcedivisionadd, ds, "Division_Name", "Division_Code");
        ddlSourcedivisionadd.Items.Insert(0, "Select");
        ddlSourcedivisionadd.SelectedIndex = 0;
    }

    protected void ddltargetcompanyadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTargetDivisionadd();
        ddltargetzoneadd.SelectedIndex = 0;
        ddltargetcenteradd.SelectedIndex = 0;
        //ddltargetdivisionadd.Focus()
    }
    private void BindTargetDivisionadd()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddltargetcompanyadd.SelectedValue);
        BindDDL(ddltargetdivisionadd, ds, "Division_Name", "Division_Code");
        ddltargetdivisionadd.Items.Insert(0, "Select");
        ddltargetdivisionadd.SelectedIndex = 0;
    }
    protected void ddlSourcedivisionadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSourceZoneAdd();
        ddltargetcenteradd.SelectedIndex = 0;
        //ddlSourcedivisionadd.Focus()
    }
    protected void ddltargetdivisionadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTargetzoneadd();
        //ddltargetdivisionadd.Focus()
    }
    private void BindSourceZoneAdd()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(9, "", ddlSourcedivisionadd.SelectedValue, "", ddlsourcecompanyadd.SelectedValue);
        BindDDL(ddlSourcezoneadd, ds, "Zone_Name", "Zone_Code");
        ddlSourcezoneadd.Items.Insert(0, "Select");
        ddlSourcezoneadd.SelectedIndex = 0;
    }
    private void BindTargetzoneadd()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddltargetdivisionadd.SelectedValue, "", ddltargetcompanyadd.SelectedValue);
        BindDDL(ddltargetzoneadd, ds, "Zone_Name", "Zone_Code");
        ddltargetzoneadd.Items.Insert(0, "Select");
        ddltargetzoneadd.SelectedIndex = 0;
    }
    protected void ddlSourcezoneadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSourceCenterAdd();
        //ddlSourcecenteradd.Focus()
    }

    protected void ddltargetzoneadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTargetCenterAdd();
        //ddltargetcenteradd.Focus()
    }
    private void BindSourceCenterAdd()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(10, "", ddlSourcedivisionadd.SelectedValue, ddlSourcezoneadd.SelectedValue, ddlsourcecompanyadd.SelectedValue);
        BindDDL(ddlSourcecenteradd, ds, "Center_name", "Center_Code");
        ddlSourcecenteradd.Items.Insert(0, "Select");
        ddlSourcecenteradd.SelectedIndex = 0;
    }
    private void BindTargetCenterAdd()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddltargetdivisionadd.SelectedValue, ddltargetzoneadd.SelectedValue, ddltargetcompanyadd.SelectedValue);
        BindDDL(ddltargetcenteradd, ds, "Center_name", "Center_Code");
        ddltargetcenteradd.Items.Insert(0, "Select");
        ddltargetcenteradd.SelectedIndex = 0;
    }

    private void Country()
    {
        DataSet ds = ProductController.GetallCountry();
        BindDDL(ddlcountry, ds, "Country_Name", "Country_Code");
        ddlcountry.Items.Insert(0, "Select");
        ddlcountry.SelectedIndex = 0;
        ddlstate.Items.Insert(0, "Select");
        ddlstate.SelectedIndex = 0;
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
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
    protected void ddlcountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        State();
        //ddlstate.Focus()

    }
    private void State()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlcountry.SelectedValue);
        BindDDL(ddlstate, ds, "State_Name", "State_Code");
        ddlstate.Items.Insert(0, "Select");
        ddlstate.SelectedIndex = 0;
    }
    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        City();
        //ddlcity.Focus()
    }

    private void City()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlstate.SelectedValue);
        BindDDL(ddlcity, ds, "City_Name", "City_Code");
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
    }

    protected void ddlcity_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindLocation();
    }
    private void BindLocation()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
        BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }

    protected void ddlstudenttypeadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlstudenttypeadd.SelectedValue == "01")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = true;
            trSourcecompany.Visible = true;
            tdstudentid.Visible = true;
            tdstudentid1.Visible = true;
            tdlastcourse.Visible = true;
            tdlastcourse1.Visible = true;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlstudenttypeadd.SelectedValue == "02")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = false;
            trSourcecompany.Visible = false;
            tdstudentid.Visible = false;
            tdstudentid1.Visible = false;
            tdlastcourse.Visible = false;
            tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlstudenttypeadd.SelectedValue == "03")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = true;
            trSourcecompany.Visible = true;
            tdstudentid.Visible = true;
            tdstudentid1.Visible = true;
            tdlastcourse.Visible = true;
            tdlastcourse1.Visible = true;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlstudenttypeadd.SelectedValue == "04")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = false;
            trSourcecompany.Visible = false;
            tdstudentid.Visible = false;
            tdstudentid1.Visible = false;
            tdlastcourse.Visible = false;
            tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus()
        }
        else
        {
            tblorgassign.Visible = false;
            tblrow1.Visible = true;
            tdstudentid.Visible = false;
            tdstudentid1.Visible = false;
            tdlastcourse.Visible = false;
            tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus()
        }
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

    protected void btnaddlead_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead_Add.aspx");
    }
    protected void btnclear_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead.aspx");
    }

    protected void btnaddseccon_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = false;
        UpnlSecContact.Visible = true;
        divsuccessmessage1.Visible = false;
    }

    protected void btncancelseccon_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead.aspx");
    }


    protected void btnSubmitSeccon_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtsecdob.Text))
            {
            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtsecdob.Text)) > DateTime.Today)
                {
                    Label14.Visible = true;
                    Label14.Text = "DOB cannot be a future date";
                    txtsecdob.Focus();
                    //lbldateerrorsubmit.Visible = False
                    return;
                }
                else
                {
                    //lbldateerrorsubmit.Visible = False
                    Label14.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Label14.Visible = true;
            Label14.Text = ex.Message;
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

            SecContactTypeid = ddlseccontacttype.SelectedValue;
            Seccondesc = ddlseccontacttype.SelectedItem.Text;
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
            string Gender = "";
            string Dob = "";
            Location = ddlSeclocation.SelectedValue;
            Gender = ddlsecgender.SelectedItem.Text;
            Dob = txtsecdob.Text;

            string Con_Id = ProductController.InsertSecondaryLeadContact(PrimaryConid, "", Institutiontypeid, InstituionTypedesc, InstitutionName, CurrentStandardid, CurrentStandarddesc, AdditionalDesc, BoardUniversityid, BoardUniversitydesc,
            DivisionSectionGradeid, DivisionSectionGradedesc, Yearofpassingid, Yearofpassingdesc, Currentyearofeducationid, Currentyearofeducationdesc, SecContactTypeid, Seccondesc, SecTitle, SecFname,
            SecMname, SecLname, Sechphone1, Sechphone2, Seclandline, Secemail, SecAdd1, Secadd2, SecStreetname, SecCountryname,
            SecStatename, SecCityname, SecpostalCode, Location, Gender, Dob);


            lblprimaryconid.Text = Con_Id;
            Clearall();
            txtnameofinstitution.Text = "";
            txtadditiondesc.Text = "";
            divSuccessmessage.Visible = false;
            divSuccessmessage.Visible = false;
            lblsuccessMessage.Visible = false;
            lblsuccessMessage.Text = "Lead Successfully Added";
            divsuccessmessage1.Visible = true;
            ddlseccontacttype.SelectedIndex = 0;
            ddlsectitle.SelectedIndex = 0;
            txtsecfname.Text = "";
            txtsecmname.Text = "";
            txtseclname.Text = "";
            txtsechandphone1.Text = "";
            txtsechandphone2.Text = "";
            txtseclandline.Text = "";
            txtsecemailid.Text = "";
            txtsecaddress1.Text = "";
            txtsecaddress2.Text = "";
            txtsecStreetname.Text = "";
            txtsecpincode.Text = "";
            ddlsecgender.SelectedValue = "0";
            txtsecdob.Text = "";

            upnlsearch.Visible = false;
            UpnlSecContact.Visible = false;
            lblleadscuccess.Text = "Secondary Contact of Lead Successfully Added";
            this.ddlcurrentstudying2.SelectedIndex = 0;
            txtadditiondesc2.Text = "";
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
        Response.Redirect("Lead.aspx");
    }


    protected void btnsearchlead_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("lead.aspx");
    }

    protected void chkaddcopy_CheckedChanged(object sender, System.EventArgs e)
    {
        if (chkaddcopy.Checked == true)
        {
            string Con_id = lblprimaryconid.Text;
            SqlDataReader dr = ProductController.Get_SecondaryContactbyLeadidforfield1(Con_id);
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


    ///////Code for Robomate Form integration

    private void GetAllDeviceType()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllDeviceType();
        BindDDL(ddldevice, ds, "Device_Type_Description", "Device_Type_Id");
        ddldevice.Items.Insert(0, "Select");
        ddldevice.SelectedIndex = 0;
    }

    private void GetAllProvider()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllProvider();
        BindDDL(ddlprovidedby, ds, "Provider_Description", "Provider_Id");
        ddlprovidedby.Items.Insert(0, "Select");
        ddlprovidedby.SelectedIndex = 0;
    }

    private void GetAllOwnedby()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllOwnedby();
        BindDDL(ddlownedby, ds, "Device_Owner_Description", "Device_Owner_id");
        ddlownedby.Items.Insert(0, "Select");
        ddlownedby.SelectedIndex = 0;
    }

    private void GetAllPlatform()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllPlatform();
        BindDDL(ddlplatform , ds, "Platform_Os_Type", "Platform_Type_Id");
        ddlplatform.Items.Insert(0, "Select");
        ddlplatform.SelectedIndex = 0;
    }

    private void GetAllDevicebrand()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllDeviceBrand();
        BindDDL(ddldevicebrand, ds, "Brand_Description", "Device_Brand_id");
        ddldevicebrand.Items.Insert(0, "Select");
        ddldevicebrand.SelectedIndex = 0;
    }

    private void GetAllAccessmode()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllAccessMode ();
        BindDDL(ddlaccessmode, ds, "Access_Mode", "Access_Mode_Id");
        ddlaccessmode.Items.Insert(0, "Select");
        ddlaccessmode.SelectedIndex = 0;
    }

    private void GetAllStorageMediaType()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllStorageMediaType ();
        BindDDL(ddlstoragemediatype , ds, "Storage_Media_Type", "Storage_Media_Type_Id");
        ddlstoragemediatype.Items.Insert(0, "Select");
        ddlstoragemediatype.SelectedIndex = 0;
    }

    private void GetAllInstallationType()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllInstallationType();
        BindDDL(ddlinstallationstatus, ds, "Installation_Status", "Installation_Status_Id");
        ddlinstallationstatus.Items.Insert(0, "Select");
        ddlinstallationstatus.SelectedIndex = 0;
    }

    protected void chkmaindevicedetails_CheckedChanged(object sender, System.EventArgs e)
    {
        if (chkmaindevicedetails.Checked == true)
        {
            tblrobodetails.Visible = true;
            tblrobodetails1.Visible = true;
        }
        else
        {
            tblrobodetails.Visible = false;
            tblrobodetails1.Visible = false;
        }
    }

    protected void ddldevicebrand_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddldevicebrand.SelectedValue =="10004")
        {
            txtotherbrand.Enabled = true;
            RequiredFieldValidator31.Enabled = true;
        }
        else
        {
            txtotherbrand.Enabled = false ;
            RequiredFieldValidator31.Enabled = false;
        }
    }
  
}
