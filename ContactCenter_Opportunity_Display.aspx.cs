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

public partial class ContactCenter_Opportunity_Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["Opportunity_Code"] != null)
            {
                string oppid = Request["Opportunity_Code"];
                string Menuid = "103";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "";
                lblpagetitle2.Text = "";
                limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Opportunity";
                lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Text = "Display Opportunity";
                //lilastbreadcrumb.Visible = true;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
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
                                //btnaddOpp.Visible = True
                                //btnadd2.Visible = True
                                //btnimportOpp.Visible = True
                            }
                            else
                            {
                                //btnaddOpp.Visible = False
                                //btnadd2.Visible = False
                                //btnimportOpp.Visible = False
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
                    //tr1.Visible = false;
                    //tr2.Visible = false;
                    //tr3.Visible = false;
                    tdapplicationno.Visible = true;
                    tdapplicationno1.Visible = true;
                }
                else
                {
                    //tr1.Visible = True
                    //tr2.Visible = True
                    //tr3.Visible = True
                    //tdapplicationno.Visible = False
                    //tdapplicationno1.Visible = False
                    //RequiredFieldValidator11.Visible = False
                    //tr1.Visible = false;
                    //tr2.Visible = false;
                    //tr3.Visible = false;
                    tdapplicationno.Visible = true;
                    tdapplicationno1.Visible = true;

                }
                txt1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtdiscount.Text = "0";
                tblorgassign.Visible = false;
                Currentyear();
                ContactSource();
                ContactType();
                Country2();

                //tdstudentid.Visible = false;
                //tdstudentid1.Visible = false;
                //tdlastcourse.Visible = false;
                //tdlastcourse1.Visible = false;
                //Country();
                //Discipline();
                StudentType();
                //Scorerange();
                //Institutetype();
               // CurrentStudyingin();
                //Board();
                //Yearofpassing();
                //DivisionSession();
                //ContactType();
                BindProductCategory();
                BindSalesStage();
                BindSourceCompany();
                BindTargetCompany();
               // BindSalesChannel();
                //ddlfieldint.Items.Insert(0, "Select");
                //ddlfieldint.SelectedIndex = 0;
                divErrormessage.Visible = false;
                divSuccessmessage.Visible = false;
                Bindlist();
               // BindSecContact();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }


    }


    private void ContactSource()
    {
        DataSet ds = ProductController.GetallactiveleadSource();
        BindDDL(ddlContactsourceadd, ds, "Description", "ID");
        ddlContactsourceadd.Items.Insert(0, "Select");
        ddlContactsourceadd.SelectedIndex = 0;
    }

    private void Bindlist()
    {

        try
        {

            if (Request["Opportunity_Code"] != null)
            {
                string opp_id = Request["Opportunity_Code"];
                string Hiphen = "-";
                SqlDataReader dr = ProductController.GetOppdetailsbyoppid(opp_id);
                if ((((dr) != null)))
                {
                    if (dr.Read())
                    {
                        txt1.Text = dr["Created_on"].ToString();
                        //ContactType();
                        //ddlcontacttype1.SelectedValue = dr["Con_type_id"].ToString();
                        //BindSalesChannel();
                        //ddlsaleschannel.SelectedValue = dr["SalesStage_Id"].ToString();
                        //if (dr["Con_Title"].ToString() == "Mr.")
                        //{
                        //    this.ddltitle.SelectedValue = "1";
                        //}
                        //else
                        //{
                        //    this.ddltitle.SelectedValue = "2";
                        //}


                        //if (dr["gender"].ToString() == "Male")
                        //{
                        //    this.ddlgenderadd.SelectedValue = "1";
                        //}
                        //else if (dr["gender"].ToString() == "Female")
                        //{
                        //    this.ddlgenderadd.SelectedValue = "2";
                        //}
                        //else
                        //{
                        //    this.ddlgenderadd.SelectedValue = "0";
                        //}

                        //txtfirstname.Text = dr["Con_Firstname"].ToString();
                        //txtmidname.Text = dr["Con_midname"].ToString();
                        //txtlastname.Text = dr["Con_lastname"].ToString();
                        lblstudentname.Text = Hiphen + " " + dr["Con_Title"].ToString() + " " + dr["Con_FirstName"].ToString() + " " + dr["Con_midname"].ToString() + " " + dr["Con_lastname"].ToString();
                        lblConId.Text = dr["Con_Id"].ToString();
                        //txthandphone1.Text = dr["handphone1"].ToString();
                        //txthandphone2.Text = dr["handphone2"].ToString();
                        //txtlandline.Text = dr["landline"].ToString();
                        //txtemailid.Text = dr["Emailid"].ToString();
                        //txtflatno.Text = dr["Flatno"].ToString();
                        //this.txtbuildingno.Text = dr["BuildingName"].ToString();
                        //txtstreetname.Text = dr["StreetName"].ToString();
                        //Country();
                        //ddlcountry.SelectedValue = dr["Country"].ToString();
                        //State();
                        //ddlstate.SelectedValue = dr["State"].ToString();
                        //City();
                        //ddlcity.SelectedValue = dr["City"].ToString();
                        //if (ddlcity.SelectedValue == "Select")
                        //{
                        //    ddllocation.SelectedIndex = 0;
                        //}
                        //else
                        //{
                        //    BindLocation();
                        //    ddllocation.SelectedValue = dr["location_id"].ToString();
                        //}
                        //txtpincode.Text = dr["Pincode"].ToString();
                        //txtproductinterested.Text = dr("Prod_Interest").ToString
                        //txtExpjoindate.Text = dr("Time_join").ToString
                        //Institutetype();
                        //this.ddlinstitutiontype.SelectedValue = dr["Institution_Type_Id"].ToString();
                        //this.txtnameofinstitution.Text = dr["Institution_Description"].ToString();
                        //CurrentStudyingin();
                        //this.ddlcurrentstudying.SelectedValue = dr["Current_Standard_id"].ToString();
                        //this.txtadditiondesc.Text = dr["Additional_desc"].ToString();
                        //Board();
                        //ddlboard.SelectedValue = dr["Board_id"].ToString();
                        //DivisionSession();
                        //ddlsection.SelectedValue = dr["Section_id"].ToString();
                        //Yearofpassing();
                        //ddlyearofpassing.SelectedValue = dr["Year_of_Passing_Id"].ToString();
                        lblprimarycontactid.Text = dr["con_id"].ToString();
                       // BindScore();
                        StudentType();
                        ddlstudenttypeadd.SelectedValue = dr["Category_Type_id"].ToString();

                        if (ddlstudenttypeadd.SelectedValue == "01")
                        {
                            tblorgassign.Visible = true;
                            tblrow1.Visible = true;
                            trSourcecompany.Visible = true;
                            //tdstudentid.Visible = true;
                            //tdstudentid1.Visible = true;
                            //tdlastcourse.Visible = true;
                            //tdlastcourse1.Visible = true;
                            BindSourceCompany();
                            ddlsourcecompanyadd.SelectedValue = dr["Opp_Contact_Company"].ToString();
                            BindSourceDivisionAdd();
                            ddlSourcedivisionadd.SelectedValue = dr["Opp_ContactSource_Division"].ToString();
                            BindSourceZoneAdd();
                            ddlSourcezoneadd.SelectedValue = dr["Opp_ContactSource_Zone"].ToString();
                            BindSourceCenterAdd();
                            ddlSourcecenteradd.SelectedValue = dr["Opp_ContactSource_Center"].ToString();
                            BindTargetCompany();
                            ddltargetcompanyadd.SelectedValue = dr["Opp_Contact_Target_Company"].ToString();
                            BindTargetDivisionadd();
                            ddltargetdivisionadd.SelectedValue = dr["Opp_Contact_Division"].ToString();
                            BindTargetzoneadd();
                            ddltargetzoneadd.SelectedValue = dr["Opp_Contact_Zone"].ToString();
                            BindTargetCenterAdd();
                            ddltargetcenteradd.SelectedValue = dr["Opp_Contact_Center"].ToString();
                        }
                        else if (ddlstudenttypeadd.SelectedValue == "02")
                        {
                            tblorgassign.Visible = true;
                            tblrow1.Visible = false;
                            trSourcecompany.Visible = false;
                            //tdstudentid.Visible = false;
                            //tdstudentid1.Visible = false;
                            //tdlastcourse.Visible = false;
                            //tdlastcourse1.Visible = false;
                            BindTargetCompany();
                            ddltargetcompanyadd.SelectedValue = dr["Opp_Contact_Target_Company"].ToString();
                            BindTargetDivisionadd();
                            ddltargetdivisionadd.SelectedValue = dr["Opp_Contact_Division"].ToString();
                            BindTargetzoneadd();
                            ddltargetzoneadd.SelectedValue = dr["Opp_Contact_Zone"].ToString();
                            BindTargetCenterAdd();
                            ddltargetcenteradd.SelectedValue = dr["Opp_Contact_Center"].ToString();

                        }
                        else if (ddlstudenttypeadd.SelectedValue == "03")
                        {
                            tblorgassign.Visible = true;
                            tblrow1.Visible = true;
                            trSourcecompany.Visible = true;
                            //tdstudentid.Visible = true;
                            //tdstudentid1.Visible = true;
                            //tdlastcourse.Visible = true;
                            //tdlastcourse1.Visible = true;
                            BindSourceCompany();
                            ddlsourcecompanyadd.SelectedValue = dr["Opp_Contact_Company"].ToString();
                            BindSourceDivisionAdd();
                            ddlSourcedivisionadd.SelectedValue = dr["Opp_ContactSource_Division"].ToString();
                            BindSourceZoneAdd();
                            ddlSourcezoneadd.SelectedValue = dr["Opp_ContactSource_Zone"].ToString();
                            BindSourceCenterAdd();
                            ddlSourcecenteradd.SelectedValue = dr["Opp_ContactSource_Center"].ToString();
                            BindTargetCompany();
                            ddltargetcompanyadd.SelectedValue = dr["Opp_Contact_Target_Company"].ToString();
                            BindTargetDivisionadd();
                            ddltargetdivisionadd.SelectedValue = dr["Opp_Contact_Division"].ToString();
                            BindTargetzoneadd();
                            ddltargetzoneadd.SelectedValue = dr["Opp_Contact_Zone"].ToString();
                            BindTargetCenterAdd();
                            ddltargetcenteradd.SelectedValue = dr["Opp_Contact_Center"].ToString();

                        }
                        else if (ddlstudenttypeadd.SelectedValue == "04")
                        {
                            tblorgassign.Visible = true;
                            tblrow1.Visible = false;
                            //trSourcecompany.Visible = false;
                            //tdstudentid.Visible = false;
                            //tdstudentid1.Visible = false;
                            //tdlastcourse.Visible = false;
                            //tdlastcourse1.Visible = false;
                            BindTargetCompany();
                            ddltargetcompanyadd.SelectedValue = dr["Opp_Contact_Target_Company"].ToString();
                            BindTargetDivisionadd();
                            ddltargetdivisionadd.SelectedValue = dr["Opp_Contact_Division"].ToString();
                            BindTargetzoneadd();
                            ddltargetzoneadd.SelectedValue = dr["Opp_Contact_Zone"].ToString();
                            BindTargetCenterAdd();
                            ddltargetcenteradd.SelectedValue = dr["Opp_Contact_Center"].ToString();
                        }
                        else
                        {
                            tblorgassign.Visible = false;
                            tblrow1.Visible = true;
                            //tdstudentid.Visible = false;
                            //tdstudentid1.Visible = false;
                            //tdlastcourse.Visible = false;
                            //tdlastcourse1.Visible = false;
                        }

                        
                        //a.Is_Branch_Topper, a.Branch_Topper_Division,a.Branch_Topper_Center,a.Is_School_Ranker,
				        //a.School_Name,a.School_Division,a.School_Rank,a.Apply_Additional_Discount,a.Discount_Type


                        if (dr["Is_Branch_Topper"].ToString() == "1")
                        {
                            ckhBranchTopper.Checked = true;
                            ckhBranchTopper.Enabled = false;

                        }
                        else
                        {
                            ckhBranchTopper.Checked = false;
                            ckhBranchTopper.Enabled = true;
                        }

                        if (ckhBranchTopper.Checked)
                        {
                            trBranchTopper.Visible = true;
                        }
                        else
                        {
                            trBranchTopper.Visible = false;
                        }
                        if (dr["Is_School_Ranker"].ToString() == "1")
                        {

                            chkSchoolRanker.Checked = true;
                            chkSchoolRanker.Enabled = false;
                        }
                        else
                        {
                            chkSchoolRanker.Checked = false;
                            chkSchoolRanker.Enabled = true;
                        }

                        if (chkSchoolRanker.Checked)
                        {
                            trSchoolRanker.Visible = true;
                        }
                        else
                        {
                            trSchoolRanker.Visible = false;
                        }


                        if (dr["Apply_Additional_Discount"].ToString() == "1")
                        {
                            ckhRankerAdditional.Checked = true;
                            ckhRankerAdditional.Enabled = false;
                        }
                        else
                        {
                            ckhRankerAdditional.Checked = false;
                            ckhRankerAdditional.Enabled = true;
                        }


                        if (ckhRankerAdditional.Checked)
                        {
                            trDiscount.Visible = true;
                        }
                        else
                        {
                            trDiscount.Visible = false;
                        }

                        BindBranchTopperDivision();
                        ddlbranchtopperdivision.SelectedValue = dr["Branch_Topper_Division"].ToString();
                        BindBranchTopperCenter();
                        ddlbranchtopperCenter.SelectedValue = dr["Branch_Topper_Center"].ToString();
                        txtschooldivision.Text = dr["School_Division"].ToString();
                        txtschoolrank.Text = dr["School_Rank"].ToString();
                        BindddlInstitute();
                        ddlschoolranker.SelectedValue = dr["School_Name"].ToString();

                        BindDiscountconditions();
                        ddldiscountconditions.SelectedValue = dr["Discount_Type"].ToString();



                        if (lblusercompany.Text == "MPUC")
                        {
                        }
                        else
                        {
                            //txtstudentid.Text = dr["Student_Id"].ToString();
                            //txtlastcourseopted.Text = dr["Last_Course_Opted"].ToString();
                            //txtscore.Text = dr["Score"].ToString();
                            //txtpercentage.Text = dr["Percentile"].ToString();
                            //txtarearank.Text = dr["Area_Rank"].ToString();
                            //txtoverallrank.Text = dr["Overall_Rank"].ToString();
                            //txtcompetitiveexams.Text = dr["Competitive_Exam"].ToString();
                            //Scorerange();
                           // ddlscorerange.SelectedValue = dr["Score_Range_Type"].ToString();
                            //Discipline();
                            //if (dr["Discipline_Id"].ToString() == "0")
                            //{
                            //    ddldiscipline.SelectedIndex = 0;
                            //}
                            //else
                            //{
                            //    ddldiscipline.SelectedValue = dr["Discipline_Id"].ToString();
                            //    FieldInterested();
                            //    ddlfieldint.SelectedValue = dr["Field_ID"].ToString();
                            //}
                            //txtmsmarks.Text = dr["total_ms_marks"].ToString();
                            //txtmsobtained.Text = dr["total_ms_marks_obt"].ToString();
                        }

                        BindProductCategory();
                        this.ddlAddProductCategory.SelectedValue = dr["Product_code"].ToString();
                        BindSalesStage();
                        this.ddlAddSalesStage.SelectedValue = dr["Sales_Stage"].ToString();
                        if (ddlAddSalesStage.SelectedValue == "04")
                        {
                            //Me.txtapplicationno.Enabled = True
                            this.txtapplicationno.Text = dr["app_no"].ToString();
                        }
                        else
                        {
                            this.txtapplicationno.Enabled = false;
                            this.txtapplicationno.Text = dr["app_no"].ToString();
                        }
                        this.txtprobabilitypercent.Text = dr["opp_probability_percent"].ToString();
                        this.txtjoindate.Text = dr["opp_join_date"].ToString();
                        this.txtexpectedclosedate.Text = dr["opp_expected_close_date"].ToString();
                        //BindAcademicYear();
                        this.ddlacademicyear.SelectedValue = dr["Current_Year_Desc"].ToString();
                        //BindStream();
                        //this.ddlproduct.SelectedValue = dr["oppor_product_id"].ToString();
                        txtproductInterested.Text = dr["Oppor_Product"].ToString();
                        this.txtdiscount.Text = dr["opp_disc"].ToString();
                        this.txtdiscountnotes.Text = dr["disc_remark"].ToString();
                        txtassignedto.Text = dr["opp_contact_Assignto"].ToString();
                        txtassignedto.Enabled = false;
                        //txtdateofbirth.Text = dr["dob"].ToString();
                        //txtexaminationdetails.Text = dr["exam_details"].ToString();
                        //ContactType1()
                        //ddlseccontacttype.SelectedValue = dr("Sec_Con_type_id").ToString

                        //If dr("Sec_Con_title").ToString = "Mr." Then
                        //    ddlsectitle.SelectedValue = "1"
                        //ElseIf dr("Sec_Con_title").ToString = "Ms." Then
                        //    ddlsectitle.SelectedValue = "2"
                        //Else
                        //    ddlsectitle.SelectedIndex = 0
                        //End If
                        //txtsecfname.Text = dr("Sec_Con_Firstname").ToString
                        //txtsecmname.Text = dr("Sec_Con_midname").ToString
                        //txtseclname.Text = dr("Sec_Con_lastname").ToString
                        //txtsechandphone1.Text = dr("Sec_Handphone1").ToString
                        //txtsechandphone2.Text = dr("Sec_Handphone2").ToString
                        //txtseclandline.Text = dr("Sec_Landline").ToString
                        //txtsecemailid.Text = dr("Sec_Emailid").ToString
                        //txtsecaddress1.Text = dr("Sec_Flatno").ToString
                        //txtsecaddress2.Text = dr("Sec_BuildingName").ToString
                        //txtsecStreetname.Text = dr("Sec_StreetName").ToString
                        //txtsecpincode.Text = dr("Sec_Pincode").ToString

                        //ddlseccountry.SelectedValue = dr("Sec_Country").ToString
                        //BindSecState()
                        //ddlsecstate.SelectedValue = dr("Sec_State").ToString
                        //BindSecCity()
                        //ddlseccity.SelectedValue = dr("Sec_City").ToString
                        BindSecContactDetails(lblConId.Text);

                        DataSet ds = ProductController.Get_ContactbyContactId(10, opp_id);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataList dlConHistory = (DataList)HistoryPanel1.FindControl("dlConHistory");
                            DataList dlfeedbackhistory = (DataList)HistoryPanel1.FindControl("dlfeedbackhistory");
                            DataList dlCallhistory = (DataList)HistoryPanel1.FindControl("dlCallhistory");

                            if (ds.Tables[3].Rows.Count > 0)
                            {

                                dlConHistory.Visible = true;
                                //lblCon_History.Visible = false;
                                // diverrormessageContactHistory.Visible = false;
                                HistoryPanel1.DivErrorMessageContactHistoryVisibility(false);

                                dlConHistory.DataSource = ds.Tables[3];
                                dlConHistory.DataBind();
                            }
                            else
                            {
                                dlConHistory.Visible = false;
                                HistoryPanel1.DivErrorMessageContactHistoryVisibility(true);
                            }

                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                dlfeedbackhistory.Visible = true;
                                //diverrormessagefeedback.Visible = false;
                                HistoryPanel1.DivErrorMessageFollowupHistoryVisibility(false);
                                dlfeedbackhistory.DataSource = ds.Tables[4];
                                dlfeedbackhistory.DataBind();

                            }
                            else
                            {
                                // divfeedbackhistory.Visible = false;
                                dlfeedbackhistory.Visible = false;
                                HistoryPanel1.DivErrorMessageFollowupHistoryVisibility(true);
                                //diverrormessagefeedback.Visible = true;
                                //lblerrrormessagefeedback.Text = "No Follow up history found !!!";
                            }

                            if (ds.Tables[8].Rows.Count > 0)
                            {
                                dlCallhistory.Visible = true;
                                HistoryPanel1.DivErrorMessageCallHistoryVisibility(false);
                                //diverrormessageCallHistory.Visible = false;
                                dlCallhistory.DataSource = ds.Tables[8];
                                dlCallhistory.DataBind();
                            }
                            else
                            {
                                dlCallhistory.Visible = false;
                                HistoryPanel1.DivErrorMessageCallHistoryVisibility(true);
                                //diverrormessageCallHistory.Visible = true;
                                //lblerrrormessageCallHistory.Visible = true;
                                //lblerrrormessageCallHistory.Text = "No records found..!";
                            }

                        }
                    }
                }
                divErrormessage.Visible = false;
            }
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    //private void BindScore()
    //{
    //    string Conid = lblprimarycontactid.Text;
    //    string Scoretypeid = "";
    //    string Score = "";
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    int Id = 0;
    //    DataSet ds = ProductController.GetAllScore(4, Conid, Scoretypeid, Score, UserID, Id);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        dlScore.DataSource = ds;
    //        dlScore.DataBind();
    //        divscoreerror.Visible = false;
    //    }
    //    else
    //    {
    //        divscoreerror.Visible = true;
    //        lblscoreerror.Text = "No Scores Entered!";
    //    }
    //}
    private void BindSecContact()
    {
        if (Request["Opportunity_Code"] != null)
        {
            string Opporid = Request["Opportunity_Code"];

            DataSet ds = ProductController.Get_SecondaryContactbyOpporid(Opporid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //dlseccontact.DataSource = ds;
                //dlseccontact.DataBind();
                //divseccontact.Visible = false;
            }
            else
            {
                //divseccontact.Visible = true;
                //lblseccontact.Text = "No Secondary Contact Found!";
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
    //private void BindLocation()
    //{
    //    DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
    //    BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
    //    //ddllocation.Items.Insert(0, "Select")
    //    //ddllocation.SelectedIndex = 0
    //}

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
    //private void Discipline()
    //{
    //    DataSet ds = ProductController.GetallDiscipline();
    //    BindDDL(ddldiscipline, ds, "Discipline_Desc", "Discipline_Id");
    //    ddldiscipline.Items.Insert(0, "Select");
    //    ddldiscipline.SelectedIndex = 0;
    //}
    //private void Scorerange()
    //{
    //    DataSet ds = ProductController.GetScorerange();
    //    BindDDL(ddlscorerange, ds, "Description", "ID");
    //    ddlscorerange.Items.Insert(0, "Select");
    //    ddlscorerange.SelectedIndex = 0;
    //}
    //protected void ddldiscipline_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    FieldInterested();
    //}
    //private void FieldInterested()
    //{
    //    DataSet ds = ProductController.GetAllFieldInterestedByDisciplineid(Convert.ToInt32 ( ddldiscipline.SelectedValue));
    //    BindDDL(ddlfieldint, ds, "IField_Desc", "C24_Ifieldid");
    //    ddlfieldint.Items.Insert(0, "Select");
    //    ddlfieldint.SelectedIndex = 0;
    //}
    //private void Institutetype()
    //{
    //    DataSet ds = ProductController.GetallInstituteType();
    //    BindDDL(ddlinstitutiontype, ds, "Description", "ID");
    //    ddlinstitutiontype.Items.Insert(0, "Select");
    //    ddlinstitutiontype.SelectedIndex = 0;
    //}
    //protected void ddlinstitutiontype_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
    //    BindDDL(ddlcurrentstudying, ds, "Description", "ID");
    //    ddlcurrentstudying.Items.Insert(0, "Select");
    //    ddlcurrentstudying.SelectedIndex = 0;
    //}
    //private void CurrentStudyingin()
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
    //    BindDDL(ddlcurrentstudying, ds, "Description", "ID");
    //    ddlcurrentstudying.Items.Insert(0, "Select");
    //    ddlcurrentstudying.SelectedIndex = 0;
    //}

    //private void Board()
    //{
    //    DataSet ds = ProductController.GetallBoard();
    //    BindDDL(ddlboard, ds, "Short_Description", "ID");
    //    ddlboard.Items.Insert(0, "Select");
    //    ddlboard.SelectedIndex = 0;
    //}

    //private void Yearofpassing()
    //{
    //    DataSet ds = ProductController.GetallYearofpassing();
    //    BindDDL(ddlyearofpassing, ds, "Description", "ID");
    //    ddlyearofpassing.Items.Insert(0, "Select");
    //    ddlyearofpassing.SelectedIndex = 0;
    //}
    //Private Sub Currentyear()
    //    Dim ds As DataSet = ProductController.GetAllCurrentyear()
    //    BindDDL(ddlacademicyear, ds, "Description", "ID")
    //    ddlacademicyear.Items.Insert(0, "Select")
    //    ddlacademicyear.SelectedIndex = 0
    //End Sub
    //private void DivisionSession()
    //{
    //    DataSet ds = ProductController.GetAllDivisionSection();
    //    BindDDL(ddlsection, ds, "Description", "ID");
    //    ddlsection.Items.Insert(0, "Select");
    //    ddlsection.SelectedIndex = 0;
    //}
    //private void ContactType()
    //{
    //    DataSet ds = ProductController.GetallactiveContactType();
    //    BindDDL(ddlcontacttype1, ds, "Description", "ID");
    //    ddlcontacttype1.Items.Insert(0, "Select");
    //    ddlcontacttype1.SelectedIndex = 0;
    //}
    //protected void ddlcontacttype1_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    DataSet ds = ProductController.GetAllSContactTypebyPContactType(ddlcontacttype1.SelectedValue);
    //    BindDDL(ddlseccontacttype, ds, "Description", "ID");
    //    ddlseccontacttype.Items.Insert(0, "Select");
    //    ddlseccontacttype.SelectedIndex = 0;
    //    ddlcontacttype1.Focus();
    //}
    //private void Contacttype1()
    //{
    //    DataSet ds = ProductController.GetAllSContactTypebyPContactType(ddlcontacttype1.SelectedValue);
    //    BindDDL(ddlseccontacttype, ds, "Description", "ID");
    //    ddlseccontacttype.Items.Insert(0, "Select");
    //    ddlseccontacttype.SelectedIndex = 0;
    //}
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
        ddlSourcedivisionadd.Focus();
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
        ddltargetdivisionadd.Focus();
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
        ddlSourcedivisionadd.Focus();
    }

    protected void ddltargetdivisionadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTargetzoneadd();
        ddltargetdivisionadd.Focus();
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
        ddlSourcecenteradd.Focus();
    }

    protected void ddltargetzoneadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTargetCenterAdd();
        ddltargetcenteradd.Focus();
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
    //private void Country()
    //{
    //    DataSet ds = ProductController.GetallCountry();
    //    BindDDL(ddlcountry, ds, "Country_Name", "Country_Code");
    //    ddlcountry.Items.Insert(0, "Select");
    //    ddlcountry.SelectedIndex = 0;
    //    ddlstate.Items.Insert(0, "Select");
    //    ddlstate.SelectedIndex = 0;
    //    ddlcity.Items.Insert(0, "Select");
    //    ddlcity.SelectedIndex = 0;
    //    ddllocation.Items.Insert(0, "Select");
    //    ddllocation.SelectedIndex = 0;
    //    BindDDL(ddlseccountry, ds, "Country_Name", "Country_Code");
    //    ddlseccountry.Items.Insert(0, "Select");
    //    ddlseccountry.SelectedIndex = 0;
    //    ddlsecstate.Items.Insert(0, "Select");
    //    ddlsecstate.SelectedIndex = 0;
    //    ddlseccity.Items.Insert(0, "Select");
    //    ddlseccity.SelectedIndex = 0;
    //}
    //protected void ddlcountry_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    State();
    //    ddlstate.Focus();

    //}
    //private void State()
    //{
    //    DataSet ds = ProductController.GetallStatebyCountry(ddlcountry.SelectedValue);
    //    BindDDL(ddlstate, ds, "State_Name", "State_Code");
    //    ddlstate.Items.Insert(0, "Select");
    //    ddlstate.SelectedIndex = 0;
    //}
    //protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    City();
    //    ddlcity.Focus();
    //}
    //private void City()
    //{
    //    DataSet ds = ProductController.GetallCitybyState(ddlstate.SelectedValue);
    //    BindDDL(ddlcity, ds, "City_Name", "City_Code");
    //    ddlcity.Items.Insert(0, "Select");
    //    ddlcity.SelectedIndex = 0;
    //}
    //protected void ddlcity_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindLocation();
    //}
    //Private Sub BindLocation()
    //    Dim ds As DataSet = ProductController.GetallLocationbycity(ddlcity.SelectedValue)
    //    BindDDL(ddllocation, ds, "Location_Name", "Location_Code")
    //    'ddllocation.Items.Insert(0, "Select")
    //    'ddllocation.SelectedIndex = 0
    //End Sub
    protected void ddlstudenttypeadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlstudenttypeadd.SelectedValue == "01")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = true;
            trSourcecompany.Visible = true;
            //tdstudentid.Visible = true;
            //tdstudentid1.Visible = true;
            //tdlastcourse.Visible = true;
            //tdlastcourse1.Visible = true;
            //ddlstudenttypeadd.Focus();
        }
        else if (ddlstudenttypeadd.SelectedValue == "02")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = false;
            trSourcecompany.Visible = false;
            //tdstudentid.Visible = false;
            //tdstudentid1.Visible = false;
            //tdlastcourse.Visible = false;
            //tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus();
        }
        else if (ddlstudenttypeadd.SelectedValue == "03")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = true;
            trSourcecompany.Visible = true;
            //tdstudentid.Visible = true;
            //tdstudentid1.Visible = true;
            //tdlastcourse.Visible = true;
            //tdlastcourse1.Visible = true;
            //ddlstudenttypeadd.Focus();
        }
        else if (ddlstudenttypeadd.SelectedValue == "04")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = false;
            trSourcecompany.Visible = false;
            //tdstudentid.Visible = false;
            //tdstudentid1.Visible = false;
            //tdlastcourse.Visible = false;
            //tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus();
        }
        else
        {
            tblorgassign.Visible = false;
            tblrow1.Visible = true;
            //tdstudentid.Visible = false;
            //tdstudentid1.Visible = false;
            //tdlastcourse.Visible = false;
            //tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus();
        }
    }
    //protected void ddlseccountry_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindSecState();
    //    ddlseccountry.Focus();
    //}

    //private void BindSecState()
    //{
    //    DataSet ds = ProductController.GetallStatebyCountry(ddlseccountry.SelectedValue);
    //    BindDDL(ddlsecstate, ds, "State_Name", "State_Code");
    //    ddlsecstate.Items.Insert(0, "Select");
    //    ddlsecstate.SelectedIndex = 0;
    //    ddlseccity.SelectedIndex = 0;
    //}

    //protected void ddlSecstate_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindSecCity();
    //    ddlsecstate.Focus();
    //    ddlseccity.SelectedIndex = 0;
    //}
    //private void BindSecCity()
    //{
    //    DataSet ds = ProductController.GetallCitybyState(ddlsecstate.SelectedValue);
    //    BindDDL(ddlseccity, ds, "City_Name", "City_Code");
    //    ddlseccity.Items.Insert(0, "Select");
    //    ddlseccity.SelectedIndex = 0;
    //}
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
    //private void BindSalesChannel()
    //{
    //    DataSet ds = ProductController.GetAllSalesChannel();
    //    BindDDL(ddlsaleschannel, ds, "Description", "ID");
    //    ddlsaleschannel.Items.Insert(0, "Select");
    //    ddlsaleschannel.SelectedIndex = 0;
    //}
    protected void ddltargetcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // BindAcademicYear();
    }
    private void Currentyear()
    {
        DataSet ds = ProductController.GetAllCurrentyear();
        BindDDL(ddlacademicyear, ds, "Description", "ID");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
    }
    //private void BindAcademicYear()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetAcademicYearbyCenter(ddltargetcenteradd.SelectedValue);
    //    BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
    //    ddlacademicyear.Items.Insert(0, "Select");
    //    ddlacademicyear.SelectedIndex = 0;
    //}
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // BindStream();
    }
    //private void BindStream()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetStreamby_Center_AcademicYear(ddltargetcenteradd.SelectedValue, ddlacademicyear.SelectedValue);
    //    BindDDL(ddlproduct, ds, "Stream_Sdesc", "Stream_Code");
    //    //ddlproduct.Items.Insert(0, "Select")
    //    //ddlproduct.SelectedIndex = 0
    //    //To Do
    //}

    protected void btnsearchoppor_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Opportunity.aspx");
    }

    protected void ddlbranchtopperdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranchTopperCenter();

    }

    protected void ckhBranchTopper_CheckedChanged(object sender, EventArgs e)
    {
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
        string division_Code = ddltargetdivisionadd.SelectedValue;
        DataSet ds = ProductController.GetDiscount_Types(3, division_Code, "MT");
        BindDDL(ddldiscountconditions, ds, "Discount_Type_Short_Desc", "Discount_Type");
        ddldiscountconditions.Items.Insert(0, "Select");
        ddldiscountconditions.SelectedIndex = 0;
    }

    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactTypeinrelation();
        BindDDL(ddlContactType, ds, "Description", "ID");
    }

    private void Country2()
    {
        DataSet ds = ProductController.GetallCountry();
        BindDDL(ddlCountry, ds, "Country_Name", "Country_Code");
        ddlCountry.Items.Insert(0, "Select");
        ddlCountry.SelectedIndex = 0;
        ddlstate.Items.Insert(0, "Select");
        ddlstate.SelectedIndex = 0;
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
    }

    private void BindState()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlCountry.SelectedValue);
        BindDDL(ddlstate, ds, "State_Name", "State_Code");
        ddlstate.Items.Insert(0, "Select");
        ddlstate.SelectedIndex = 0;
        ddlcity.Items.Clear();
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
    }

    private void BindCity()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlstate.SelectedValue);
        BindDDL(ddlcity, ds, "City_Name", "City_Code");
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
    }

    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCity();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindState();
    }

    protected void btnrefersh_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Opportunity_Display.aspx?&Opportunity_Code=" + Request["Opportunity_Code"]);
    }

    private void BindLocation()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
        BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }  

    private void BindSecContactDetails(string Conid)
    {
        string Con_id = Conid;

        //lblPKey_Con_Id.Text = Con_id;
        HtmlAnchor editContact = aedit;
        editContact.Visible = true;
        editContact.HRef = "ContactCenter_Contact_Edit.aspx?&Con_id=" + Con_id;

        ContactInfoPanel1.BindSecContactDetails_Agent(Con_id);

        DataSet ds = ProductController.Get_ContactbyContactId(7, Con_id);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if ((ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == ""))
            {
                ddlContactsourceadd.SelectedIndex = 0;
            }
            else
            {
                ddlContactsourceadd.SelectedValue = ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString();
            }
            if ((ds.Tables[0].Rows[0]["Con_type_id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Con_type_id"].ToString() == ""))
            {
                ddlContactType.SelectedIndex = 0;
            }
            else
            {
                ddlContactType.SelectedValue = ds.Tables[0].Rows[0]["Con_type_id"].ToString();
            }

            if ((ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == ""))
            {
                ddlstudenttypeadd.SelectedIndex = 0;
            }
            else
            {
                ddlstudenttypeadd.SelectedValue = ds.Tables[0].Rows[0]["Category_Type_Id"].ToString();
            }


            if (ds.Tables[0].Rows[0]["Con_title"].ToString() == "Mr.")
            {
                ddlTitle.SelectedValue = "1";
            }
            else if (ds.Tables[0].Rows[0]["Con_title"].ToString() == "Ms.")
            {
                ddlTitle.SelectedValue = "2";
            }
            else
            {
                ddlTitle.SelectedIndex = 0;
            }

            txtFirstName.Text = ds.Tables[0].Rows[0]["Con_Firstname"].ToString();
            txtMidName.Text = ds.Tables[0].Rows[0]["Con_midname"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["Con_lastname"].ToString();

            if ((ds.Tables[0].Rows[0]["Gender"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Gender"].ToString() == ""))
            {
                ddlGender.SelectedIndex = 0;
            }
            else
            {
                if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Male")
                {
                    ddlGender.SelectedValue = "1";
                }
                else if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Female")
                {
                    ddlGender.SelectedValue = "2";
                }
                else
                    ddlGender.SelectedIndex = 0;
            }

            if (ds.Tables[0].Rows[0]["DOB"].ToString() == "")
            {
                txtdateofbirth.Text = "";
            }
            else
            {
                txtdateofbirth.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
            }

            txtHandPhone1.Text = ds.Tables[0].Rows[0]["handphone1"].ToString();
            txtHandphone2.Text = ds.Tables[0].Rows[0]["handphone2"].ToString();
            txtlandline.Text = ds.Tables[0].Rows[0]["landline"].ToString();
            txtemailid.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
            txtaddress1.Text = ds.Tables[0].Rows[0]["Flatno"].ToString();
            txtaddress2.Text = ds.Tables[0].Rows[0]["BuildingName"].ToString();
            txtStreetname.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
            txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

            if ((ds.Tables[0].Rows[0]["Country"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Country"].ToString() == ""))
            {
                ddlCountry.SelectedIndex = 0;
                ddlstate.Items.Clear();
                ddlcity.Items.Clear();
                ddllocation.Items.Clear();
                ddlstate.Items.Insert(0, "Select");
                ddlcity.Items.Insert(0, "Select");
                ddllocation.Items.Insert(0, "Select");
                ddlstate.SelectedIndex = 0;
                ddlcity.SelectedIndex = 0;
                ddllocation.SelectedIndex = 0;
            }
            else
            {
                ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
                BindState();
                if ((ds.Tables[0].Rows[0]["State"].ToString() == "Select") || (ds.Tables[0].Rows[0]["State"].ToString() == ""))
                {
                    ddlstate.SelectedIndex = 0;
                    ddlcity.Items.Clear();
                    ddllocation.Items.Clear();
                    ddlcity.Items.Insert(0, "Select");
                    ddlcity.SelectedIndex = 0;
                    ddllocation.Items.Insert(0, "Select");
                    ddllocation.SelectedIndex = 0;
                }
                else
                {
                    ddlstate.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
                    BindCity();
                    if ((ds.Tables[0].Rows[0]["City"].ToString() == "Select") || (ds.Tables[0].Rows[0]["City"].ToString() == ""))
                    {
                        ddlcity.SelectedIndex = 0;
                        ddllocation.Items.Clear();
                        ddllocation.Items.Insert(0, "Select");
                        ddllocation.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlcity.SelectedValue = ds.Tables[0].Rows[0]["City"].ToString();
                        BindLocation();
                        if ((ds.Tables[0].Rows[0]["Location"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Location"].ToString() == ""))
                        {
                            ddllocation.SelectedIndex = 0;
                        }
                        else
                        {
                            ddllocation.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                        }
                    }
                }
            }

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
            //    lblAcadInfoRecord.Text = "No records found..!";
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
        }
    }
}