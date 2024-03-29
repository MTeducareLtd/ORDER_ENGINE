﻿using System;
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
public partial class Opportunity_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Menuid = "103";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                divadd.Visible = true;
                lblpagetitle1.Text = "";
                lblpagetitle2.Text = "";
                limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Opportunity";
                lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Text = " Display Opportunity";
                UpnlAdd.Visible = true;
                UpnlSecContact.Visible = false;
                divsuccessmessage1.Visible = false;
                lbldateerrorexp.Visible = false;
                lbldateerrorJoindate.Visible = false;
                SqlDataReader dr = UserController.Getuserrights(UserID, Menuid);
                try
                {
                    if ((((dr) != null)))
                    {
                        if (dr.Read())
                        {
                            int allowdisplay =Convert.ToInt32(dr["Allow_Add"].ToString());
                            if (allowdisplay == 1)
                            {
                                btnaddOpp.Visible = true;
                            }
                            else
                            {
                                btnaddOpp.Visible = false;
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
                if (UserCompany == "MPUC1")
                {
                    tr1.Visible = false;
                    tr2.Visible = false;
                    tr3.Visible = false;
                    tdapplicationno.Visible = true;
                    tdapplicationno1.Visible = true;

                }
                else
                {
                    tr1.Visible = false;
                    tr2.Visible = false;
                    tr3.Visible = false;
                    tdapplicationno.Visible = true;
                    tdapplicationno1.Visible = true;
                    //tdapplicationno.Visible = False
                    //tdapplicationno1.Visible = False
                    //txtjoindate.Text = DateTime.Now.ToString("dd-MM-yyyy")
                    //RequiredFieldValidator11.Visible = False
                    //label4.Visible = False
                }
                txt1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtdiscount.Text = "0.00";
                tblorgassign.Visible = false;
                tdstudentid.Visible = false;
                tdstudentid1.Visible = false;
                tdlastcourse.Visible = false;
                tdlastcourse1.Visible = false;
                ddlfieldint.Items.Insert(0, "Select");
                ddlfieldint.SelectedIndex = 0;
                Country();
                Discipline();
                StudentType();
                Scorerange();
                Institutetype();
                CurrentStudyingin();
                //Board()
                Yearofpassing();
                DivisionSession();
                ContactType();
                BindProductCategory();
                BindSalesStage();
                BindSourceCompany();
                BindTargetCompany();
                BindSalesChannel();
                BindScore();
                BindBranchTopperDivision();
                BindddlInstitute();
                BindDiscountconditions();
                this.ddlcurrentstudying2.Items.Insert(0, "Select");
                this.ddlcurrentstudying2.SelectedIndex = 0;
                ddlboard.Items.Insert(0, "Select");
                ddlboard.SelectedIndex = 0;
                divErrormessage.Visible = false;
                divSuccessmessage.Visible = false;
                lblappnoerror.Visible = false;
                //ddlcontacttype1.Focus()
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }


    protected void btnSubmitNewOpp_ServerClick(object sender, System.EventArgs e)
    {
        //If lblusercompany.Text = "MPUC" Then
        if ((ddlAddSalesStage.SelectedValue == "04" & string.IsNullOrEmpty(this.txtapplicationno.Text)))
        {
            lblappnoerror.Visible = true;
            lblappnoerror.Text = "Please Enter Application Number !";
            this.txtapplicationno.Focus();
            return;
        }
        else if (ddlAddSalesStage.SelectedValue == "04")
        {
            //Check For duplicate Application No.
            string Company = "";
            string Division = "";
            string Center = "";
            string Stream = "";
            string app_no = "";
            string Flag = "";

            Company = ddltargetcompanyadd.SelectedValue;
            Division = ddltargetdivisionadd.SelectedValue;
            Center = ddltargetcenteradd.SelectedValue;
            Stream = ddlproduct.SelectedValue;
            app_no = txtapplicationno.Text;
            Flag = ProductController.CheckDuplicateAppno(Company, Division, Center, Stream, app_no);
            //Flag = "0"
            if (Flag == "0")
            {
                lblappnoerror.Visible = true;
                lblappnoerror.Text = "Application No. already exists!";
                return;
            }
            else
            {
                lblappnoerror.Visible = false;
            }
        }
        if (string.IsNullOrEmpty(txtjoindate.Text))
        {
        }
        else
        {
            try
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtjoindate.Text)) < DateTime.Today)
                {
                    //lbldateerrorJoindate.Visible = True
                    //lbldateerrorJoindate.Text = "Exp. Join Date cannot be a past date"
                    //txtjoindate.Focus()
                    //Exit Sub
                }
            }
            catch (Exception ex)
            {
                lbldateerrorJoindate.Visible = true;
                lbldateerrorJoindate.Text = ex.Message;
                txtjoindate.Focus();
            }


            try
            {

                if (Convert.ToDateTime(ClsCommon.FormatDate(txtexpectedclosedate.Text)) < DateTime.Today)
                {
                    //lbldateerrorexp.Visible = True
                    //lbldateerrorexp.Text = "Exp. Close Date cannot be a past date"
                    //txtexpectedclosedate.Focus()
                    //lbldateerrorJoindate.Visible = False
                    //Exit Sub
                }
                else
                {
                    lbldateerrorJoindate.Visible = false;
                    lbldateerrorexp.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lbldateerrorexp.Visible = true;
                lbldateerrorexp.Text = ex.Message;
                txtexpectedclosedate.Focus();
                return;
            }
        }


        try
        {


            if (string.IsNullOrEmpty(txtexpectedclosedate.Text))
            {
            }
            else if (Convert.ToDateTime(ClsCommon.FormatDate(txtexpectedclosedate.Text)) < DateTime.Today)
            {
                //lbldateerrorexp.Visible = True
                //lbldateerrorexp.Text = "Exp. Close Date cannot be a past date"
                //txtexpectedclosedate.Focus()
                //lbldateerrorJoindate.Visible = False
                //Exit Sub
            }
        }
        catch (Exception ex)
        {
            lbldateerrorexp.Visible = true;
            lbldateerrorexp.Text = ex.Message;
            txtexpectedclosedate.Focus();
            return;
            //lbldateerrorJoindate.Visible = False
        }

        try
        {

            if (string.IsNullOrEmpty(txtdateofbirth.Text))
            {
            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtdateofbirth.Text))> DateTime.Today)
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
            //lbldateerrorsubmit.Visible = False
            return;
        }

        try
        {

            string appno = "";
            appno = this.txtapplicationno.Text;
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

            // Addition field added on 08-01-2014
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

            string SalesChannel = "";
            string SalesChannel_Id = "";



            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Opportunity_Type_Id = "";
            string Opportunity_Name = "";
            string Lead_Code = "";
            string Product_Category = "";
            string Product_Code = "";
            string Sales_Stage = "";
            DateTime Opportunity_Joindate = default(DateTime);
            DateTime Opportunity_Expected_Date = default(DateTime);
            string Opportunity_Probability_Percent = "";
            string Opportunity_Next_Step = "";
            decimal Opportunity_Value = 0;

            decimal Opportunity_Discount = 0;
            string Opp_Contact_SCompany = "";
            string Opp_Contact_SDivision = "";
            string Opp_Contact_SCenter = "";
            dynamic Opp_Contact_SZone = "";
            string Opp_Contact_TCompany = "";
            string Opp_Contact_TDivision = "";
            string Opp_Contact_TCenter = "";
            dynamic Opp_Contact_TZone = "";
            string Opp_Contact_Id = "";
            string Opp_Contact_Role = "";
            string Opp_Contact_Assignto = "";
            string Created_by = "";
            string Last_Modified_by = "";
            string Con_id = "";

            string Opp_Status = "";
            string Opp_Status_Id = "";

            int Interested_Discipline_Id = 0;
            string Interested_Discipline_Desc = "";
            int Interested_Field_Id = 0;
            string Interested_Field_Desc = "";
            string CompetitiveExam = "";
            int MSmarkstotal = 0;
            int MSMarksobtained = 0;

            ContactTYpe = ddlcontacttype1.SelectedValue;
            Contact_Type_Desc = ddlcontacttype1.SelectedItem.Text;
            //Gender = ddlgender.SelectedItem.Text
            Title = ddltitle.SelectedItem.Text;
            if (Title == "Mr.")
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }
            Fname = txtfirstname.Text;
            Mname = txtmidname.Text;
            Lname = txtlastname.Text;
            CategoryType = ddlstudenttypeadd.SelectedItem.Text;
            Category_Type_Id = ddlstudenttypeadd.SelectedValue;

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
                Studentid = txtstudentid.Text;
                LastcourseOpted = txtlastcourseopted.Text;
                Opp_Contact_SCompany = ddlsourcecompanyadd.SelectedValue;
                Opp_Contact_SDivision = ddlSourcedivisionadd.SelectedValue;
                Opp_Contact_SZone = ddlSourcezoneadd.SelectedValue;
                Opp_Contact_SCenter = ddlSourcecenteradd.SelectedValue;
                Opp_Contact_TCompany = ddltargetcompanyadd.SelectedValue;
                Opp_Contact_TDivision = ddltargetdivisionadd.SelectedValue;
                Opp_Contact_TZone = ddltargetzoneadd.SelectedValue;
                Opp_Contact_TCenter = ddltargetcenteradd.SelectedValue;

            }
            else if (ddlstudenttypeadd.SelectedValue == "02")
            {
                Opp_Contact_TCompany = ddltargetcompanyadd.SelectedValue;
                Opp_Contact_TDivision = ddltargetdivisionadd.SelectedValue;
                Opp_Contact_TZone = ddltargetzoneadd.SelectedValue;
                Opp_Contact_TCenter = ddltargetcenteradd.SelectedValue;
                Opp_Contact_SDivision = "";
                Opp_Contact_SZone = "";
                Opp_Contact_SCenter = "";

            }
            else if (ddlstudenttypeadd.SelectedValue == "03")
            {
                Studentid = txtstudentid.Text;
                LastcourseOpted = txtlastcourseopted.Text;
                Opp_Contact_SCompany = ddlsourcecompanyadd.SelectedValue;
                Opp_Contact_SDivision = ddlSourcedivisionadd.SelectedValue;
                Opp_Contact_SZone = ddlSourcezoneadd.SelectedValue;
                Opp_Contact_SCenter = ddlSourcecenteradd.SelectedValue;
                Opp_Contact_TCompany = ddltargetcompanyadd.SelectedValue;
                Opp_Contact_TDivision = ddltargetdivisionadd.SelectedValue;
                Opp_Contact_TZone = ddltargetzoneadd.SelectedValue;
                Opp_Contact_TCenter = ddltargetcenteradd.SelectedValue;

            }
            else if (ddlstudenttypeadd.SelectedValue == "04")
            {
                Opp_Contact_TCompany = ddltargetcompanyadd.SelectedValue;
                Opp_Contact_TDivision = ddltargetdivisionadd.SelectedValue;
                Opp_Contact_TZone = ddltargetzoneadd.SelectedValue;
                Opp_Contact_TCenter = ddltargetcenteradd.SelectedValue;
                Opp_Contact_SDivision = "";
                Opp_Contact_SZone = "";
                Opp_Contact_SCenter = "";

            }
            else
            {
                Studentid = "";
                LastcourseOpted = "";
                Opp_Contact_SCompany = "";
                Opp_Contact_SDivision = "";
                Opp_Contact_SZone = "";
                Opp_Contact_SCenter = "";
                Opp_Contact_TCompany = "";
                Opp_Contact_TDivision = "";
                Opp_Contact_TZone = "";
                Opp_Contact_TCenter = "";

            }


            //Role = ddlrole.SelectedValue
            Assignedto = txtassignedto.Text;
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

            Opp_Contact_Assignto = UserID;
            Lead_Code = "";
            Product_Category = ddlAddProductCategory.SelectedItem.Text;
            Product_Code = ddlAddProductCategory.SelectedValue;
            Sales_Stage = ddlAddSalesStage.SelectedValue;
            if (string.IsNullOrEmpty(txtjoindate.Text))
            {
                txtjoindate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                Opportunity_Joindate = Convert.ToDateTime(txtjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            else
            {
                Opportunity_Joindate = Convert.ToDateTime(txtjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            Opportunity_Expected_Date = Convert.ToDateTime(txtexpectedclosedate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            Opportunity_Discount = Convert.ToDecimal(txtdiscount.Text);
            Opportunity_Probability_Percent = txtprobabilitypercent.Text;

            string Oppor_product = "";
            string Oppor_Product_id = "";

            Oppor_product = ddlproduct.SelectedItem.Text;
            Oppor_Product_id = ddlproduct.SelectedValue;

            SalesChannel_Id = ddlsaleschannel.SelectedValue;
            SalesChannel = ddlsaleschannel.SelectedItem.Text;

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
            //Seccondesc = ddlseccontacttype.SelectedItem.Text
            string Dob = "";
            string Examination = "";
            string Location = "";

            Dob = txtdateofbirth.Text;
            Examination = txtexaminationdetails.Text;
            Location = ddllocation.SelectedValue;
            Gender = ddlgenderadd.SelectedItem.Text;

            string Is_Branch_Topper = "";
            string Branch_Topper_Division = "";
            string Branch_Topper_Center = "";
            string Is_School_Ranker = "";
            string School_Name = "";
            string School_Division = "";
            string School_Rank = "";
            string Apply_Additional_Discount = "";
            string Discount_Type = "";

            if (ckhBranchTopper.Checked == true)
            {
                Is_Branch_Topper = "1";
                Branch_Topper_Division = ddlbranchtopperdivision.SelectedValue;
                Branch_Topper_Center = ddlbranchtopperCenter.SelectedValue;
            }
            else
            {
                Is_Branch_Topper = "0";
                Branch_Topper_Division = "";
                Branch_Topper_Center = "";
            }
            if (chkSchoolRanker.Checked == true)
            {
                Is_School_Ranker = "1";
                School_Name = ddlschoolranker.SelectedValue;
                School_Division = txtschooldivision.Text;
                School_Rank = txtschoolrank.Text;
            }
            else
            {
                Is_School_Ranker = "0";
                School_Name = "";
                School_Division = "";
                School_Rank = "";
            }

            if (ckhRankerAdditional.Checked == true)
            {
                 Apply_Additional_Discount = "1";
                 Discount_Type = ddldiscountconditions.SelectedValue;
            }
            else
            {
                 Apply_Additional_Discount = "0";
                 Discount_Type = "";
            }

		    
		   

            Con_id = ProductController.InsertAddOpportunity("", ContactTYpe, Contact_Type_Desc, Title, Fname, Mname, Lname, Score, Percentile, AreaRank,
            Overallrank, Scorerangetype, handphone1, handphone2, landline, emailid, flatno, buildingname, Streetname, Countryname,
            State, City, Pincode, Category_Type_Id, CategoryType, Institutiontypeid, InstituionTypedesc, InstitutionName, CurrentStandardid, CurrentStandarddesc,
            AdditionalDesc, BoardUniversityid, BoardUniversitydesc, DivisionSectionGradeid, DivisionSectionGradedesc, Yearofpassingid, Yearofpassingdesc, Currentyearofeducationid, Currentyearofeducationdesc, Studentid,
            LastcourseOpted, "", "", "", Lead_Code, Product_Category, Product_Code, Sales_Stage, Opportunity_Joindate, Opportunity_Expected_Date,
            Opportunity_Probability_Percent, "", Opportunity_Value, Convert.ToInt32( Opportunity_Discount), Opp_Contact_SCompany, Opp_Contact_TDivision, Opp_Contact_TCenter, Opp_Contact_TZone, Opp_Contact_Role, Opp_Contact_Assignto,
            UserID, UserID, Opp_Status, Opp_Status_Id, Opp_Contact_SDivision, Opp_Contact_SCenter, Opp_Contact_SZone, Oppor_product, Oppor_Product_id, appno,
            SalesChannel_Id, SalesChannel, SecContactType, SecTitle, SecFname, SecMname, SecLname, Sechphone1, Sechphone2, Seclandline,
            Secemail, SecAdd1, Secadd2, SecStreetname, SecCountryname, SecStatename, SecCityname, SecpostalCode, Seccondesc, Interested_Discipline_Id,
            Interested_Discipline_Desc, Interested_Field_Id, Interested_Field_Desc, CompetitiveExam, MSmarkstotal, MSMarksobtained, Opp_Contact_TCompany, Dob, Examination, Location,
            Gender, Is_Branch_Topper,Branch_Topper_Division,Branch_Topper_Center,Is_School_Ranker,School_Name,School_Division,School_Rank,Apply_Additional_Discount,Discount_Type);

            lblprimaryconid.Text = Con_id;
            InsertScore();
            if (ddlAddSalesStage.SelectedValue == "04")
            {
                EnrollStudent(Con_id);
            }
            Clearall();
            divSuccessmessage.Visible = false;
            if (ddlAddSalesStage.SelectedValue == "04")
            {
                lblsuccessMessage.Text = "Opportunity and Enrollment Successfully Added";
            }
            else
            {
                lblsuccessMessage.Text = "Opportunity Successfully Added";
            }


            
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
            txtnameofinstitution.Text = "";
            txtadditiondesc.Text = "";
            divSuccessmessage.Visible = true;
            txtstudentid.Text = "";
            txtlastcourseopted.Text = "";
            //Country()
            ddlseccontacttype.SelectedIndex = 0;
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
            UpnlAdd.Visible = false;
            divSuccessmessage.Visible = false;
            lblsuccessMessage.Visible = false;
            divsuccessmessage1.Visible = true;
            lblleadscuccess.Text = "Opportunity Successfully Added";
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    private void EnrollStudent(string Contactid)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        //string Oppurid = "";
        string Enrollon = "";
        //string studentid = "";

        string Opporid = ProductController.GetOppidbyContactid(1, Contactid);
        if (Opporid != "")
        {
            Enrollon = DateTime.Now.ToString("dd-MM-yyyy");
            string Student_id = ClsEnrollment.enrollstudent1(Enrollon, UserID, Opporid, "");
            
        }
    }

    protected void btnproceedorder_ServerClick(object sender, System.EventArgs e)
    {
        
    }

    private void Clearall()
    {
        StudentType();
        BindSourceCompany();
        BindTargetCompany();
        Country();
        Discipline();
        Scorerange();
        Institutetype();
        Board();
        Yearofpassing();
        //Currentyear()
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
    private void StudentType()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlstudenttypeadd, ds, "Description", "Cust_Grp");
        ddlstudenttypeadd.Items.Insert(0, "Select");
        ddlstudenttypeadd.SelectedIndex = 0;

    }
    protected void ddlAddSalesStage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindProbabilityPercent();
        if (ddlAddSalesStage.SelectedValue == "04")
        {
            this.txtapplicationno.Enabled = true;
            this.txtapplicationno.Text = "";
            txtapplicationno.Focus();
        }
        else
        {
            this.txtapplicationno.Enabled = false;
            this.txtapplicationno.Text = "";
            txtjoindate.Focus();
        }
    }

    private void BindProbabilityPercent()
    {
        SqlDataReader dr = ProductController.GetProbabiltyPercent(ddlAddSalesStage.SelectedValue);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtprobabilitypercent.Text = dr["Probability_Percent"].ToString();
            }
        }
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
            ddlfieldint.Items.Insert(0, "Select");
            ddlfieldint.SelectedIndex = 0;
        }
        else
        {
            FieldInterested();
        }
    }
    private void FieldInterested()
    {
        DataSet ds = ProductController.GetAllFieldInterestedByDisciplineid(Convert.ToInt32(ddldiscipline.SelectedValue));
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
        ddlcurrentstudying.Items.Insert(0, "Select");
        ddlcurrentstudying.SelectedIndex = 0;
        //txtnameofinstitution.Focus()
        Bindboardbyid();
    }
    protected void ddlinstitutiontype2_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype2.SelectedValue);
        BindDDL(ddlcurrentstudying2, ds, "Description", "ID");
        this.ddlcurrentstudying2.Items.Insert(0, "Select");
        this.ddlcurrentstudying2.SelectedIndex = 0;
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

    private void CurrentStudyingin()
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
        BindDDL(ddlcurrentstudying, ds, "Description", "ID");
        ddlcurrentstudying.Items.Insert(0, "Select");
        ddlcurrentstudying.SelectedIndex = 0;


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
    //Private Sub Currentyear()
    //    Dim ds As DataSet = ProductController.GetAllCurrentyear()
    //    BindDDL(ddlacademicyear, ds, "Description", "ID")
    //    ddlacademicyear.Items.Insert(0, "Select")
    //    ddlacademicyear.SelectedIndex = 0
    //End Sub
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


    protected void ddlcontacttype1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetAllSContactTypebyPContactType(ddlcontacttype1.SelectedValue);
        BindDDL(ddlseccontacttype, ds, "Description", "ID");
        ddlseccontacttype.Items.Insert(0, "Select");
        ddlseccontacttype.SelectedIndex = 0;
        //ddlsaleschannel.Focus()
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
        //ddlSourcedivisionadd.Focus()
    }
    protected void ddltargetdivisionadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTargetzoneadd();
        //ddltargetdivisionadd.Focus()
        BindDiscountconditions();
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
        //ddlSeclocation.Items.Insert(0, "Select")
        //ddlSeclocation.SelectedIndex = 0
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
    private void BindProductCategory()
    {
        DataSet ds = ProductController.GetallOpporProductCategory();
        BindDDL(ddlAddProductCategory, ds, "Description", "ID");
        ddlAddProductCategory.Items.Insert(0, "Select");
        ddlAddProductCategory.SelectedIndex = 0;
    }
    private void BindSalesStage()
    {
        DataSet ds = ProductController.GetallSalesStage();
        BindDDL(ddlAddSalesStage, ds, "Sales_Stage_Desc", "Sales_Id");
        ddlAddSalesStage.Items.Insert(0, "Select");
        ddlAddSalesStage.SelectedIndex = 0;
    }
    private void BindSalesChannel()
    {
        DataSet ds = ProductController.GetAllSalesChannel();
        BindDDL(ddlsaleschannel, ds, "Description", "ID");
        ddlsaleschannel.Items.Insert(0, "Select");
        ddlsaleschannel.SelectedIndex = 0;
    }
    protected void ddltargetcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindAcademicYear();
        //ddlAddProductCategory.Focus()
    }
    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddltargetcenteradd.SelectedValue);
        BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
    }
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
        //ddlproduct.Focus()
    }
    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear(ddltargetcenteradd.SelectedValue, ddlacademicyear.SelectedValue);
        BindDDL(ddlproduct, ds, "Stream_Sdesc", "Stream_Code");
        ddlproduct.Items.Insert(0, "Select");
        ddlproduct.SelectedIndex = 0;
        //To Do
    }
    protected void btnclear_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Opportunity.aspx");
    }

    protected void btnaddseccon_ServerClick(object sender, System.EventArgs e)
    {
        UpnlAdd.Visible = false;
        UpnlSecContact.Visible = true;
        divsuccessmessage1.Visible = false;
        divSuccessmessage.Visible = false;
    }

    protected void btncancelseccon_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Opportunity.aspx");
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
            txtsecdob.Focus();
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
            UpnlAdd.Visible = false;
            UpnlSecContact.Visible = false;
            lblleadscuccess.Text = "Secondary Contact of Opportunity Successfully Added";
            this.ddlcurrentstudying2.SelectedIndex = 0;
            txtadditiondesc2.Text = "";
            divErrormessage.Visible = false;
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
        Response.Redirect("Opportunity.aspx");
    }

    protected void btnsearchoppor_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Opportunity.aspx");
    }


    protected void chkaddcopy_CheckedChanged(object sender, System.EventArgs e)
    {

        try
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
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void ddlbranchtopperdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranchTopperCenter();

    }
    protected void ckhBranchTopper_CheckedChanged(object sender, EventArgs e)
    {
        ddlbranchtopperdivision.SelectedIndex = 0;
        ddlbranchtopperCenter.Items.Clear();
        if (ckhBranchTopper.Checked)
        {
            trBranchTopper.Visible = true;
        }
        else
        {
            trBranchTopper.Visible = false;
        }


    }
    protected void chkSchoolRanker_CheckedChanged(object sender, EventArgs e)
    {
        ddlschoolranker.SelectedIndex = 0;
        txtschooldivision.Text = "";
        txtschoolrank.Text = "";
        if (chkSchoolRanker.Checked)
        {
            trSchoolRanker.Visible = true;
        }
        else
        {
            trSchoolRanker.Visible = false;
        }


    }
    protected void ckhRankerAdditional_CheckedChanged(object sender, EventArgs e)
    {
        ddldiscountconditions.SelectedIndex = 0;
        if (ckhRankerAdditional.Checked)
        {
            trDiscount.Visible = true;
        }
        else
        {
            trDiscount.Visible = false;
        }

    }

    private void BindBranchTopperDivision()
    {

        ddlbranchtopperCenter.Items.Clear();
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(8, UserID, "", "", "MT");
        BindDDL(ddlbranchtopperdivision, ds, "Division_Name", "Division_Code");
        ddlbranchtopperdivision.Items.Insert(0, "Select");
        ddlbranchtopperdivision.SelectedIndex = 0;

    }


    private void BindBranchTopperCenter()
    {
        ddlbranchtopperCenter.Items.Clear();

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string divcode = ddlbranchtopperdivision.SelectedValue;

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(11, UserID, divcode, "", "MT");
        BindDDL(ddlbranchtopperCenter, ds, "center_name", "center_code");
        ddlbranchtopperCenter.Items.Insert(0, "Select");
        ddlbranchtopperCenter.SelectedIndex = 0;

    }


    private void BindddlInstitute()
    {
        DataSet ds = ProductController.GetallInstitutename();
        BindDDL(ddlschoolranker, ds, "Institution_Description", "Institution_Description");
        ddlschoolranker.Items.Insert(0, "Select");
        ddlschoolranker.SelectedIndex = 0;
    }

    private void BindDiscountconditions()
    {
        ddldiscountconditions.Items.Clear();
        string division_Code = ddltargetdivisionadd.SelectedValue;
        string Company_code = ddltargetcompanyadd.SelectedValue;
        DataSet ds = ProductController.GetDiscount_Types(3, division_Code, Company_code);
        BindDDL(ddldiscountconditions, ds, "Discount_Type_Short_Desc", "Discount_Type");
        ddldiscountconditions.Items.Insert(0, "Select");
        ddldiscountconditions.SelectedIndex = 0;
    }

}