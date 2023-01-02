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

public partial class ContactCenter_Lead_Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["Lead_Code"] != null)
            {
                string leadid = Request["Lead_Code"];
                string Menuid = "102";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "Display Lead";
                lblpagetitle2.Text = "";
                limidbreadcrumb.Visible = false;
                lblmidbreadcrumb.Text = "Manage Lead";
                lilastbreadcrumb.Visible = false;
                lbllastbreadcrumb.Text = " Display Lead";
                lilastbreadcrumb.Visible = false;
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
                                //btnaddlead.Visible = true;
                                //btnimportlead.Visible = True
                            }
                            else
                            {
                               // btnaddlead.Visible = false;
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
                //if (UserCompany == "MPUC1")
                //{
                //    tr1.Visible = false;
                //    tr2.Visible = false;
                //    tr3.Visible = false;
                //}
                //else
                //{
                //    tr1.Visible = false;
                //    tr2.Visible = false;
                //    tr3.Visible = false;
                //}
                //ContactSource();
                Leadtype();
                LeadSource();
                leadstatus();
                //ContactType();
                StudentType2();
                //Country2();
                Currentyear();
                //StudentType();
                //ddlfieldint.Items.Insert(0, "Select");
                //ddlfieldint.SelectedIndex = 0;
                BindSourceCompany();
                BindTargetCompany();
                Bindlist();
                //BindSecContact();
                //For Robomate Integration
                GetAllDeviceType();
                GetAllProvider();
                GetAllOwnedby();
                GetAllPlatform();
                GetAllDevicebrand();
                GetAllAccessmode();
                GetAllStorageMediaType();
                GetAllInstallationType();
                //BindRobomatedetails();
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

    private void Bindlist()
    {

        try
        {
            if (Request["Lead_Code"] != null)
            {
                string Lead_Code = Request["Lead_Code"];
                SqlDataReader dr = ProductController.Getleaddetailsbyleadid(Lead_Code);
                if ((((dr) != null)))
                {
                    if (dr.Read())
                    {
                        txt1.Text = dr["Createdon"].ToString();
                        ddlleadtypeadd.SelectedValue = dr["Lead_Type_Code"].ToString();
                        ddlleadsourceadd.SelectedValue = dr["Lead_Source_Code"].ToString();
                        ddlleadstatusadd.SelectedValue = dr["Lead_Status_Code"].ToString();
                        txtsourcedesc.Text = "";
                        lblConId.Text = dr["Con_Id"].ToString();
                        BindSecContactDetails(lblConId.Text);


                        //ContactType();
                        //ddlcontacttype1.SelectedValue = dr["Con_type_id"].ToString();
                        //if (dr["Con_Title"].ToString() == "Mr.")
                        //{
                        //    //ddlgenderadd.SelectedValue = "1"
                        //    ddltitle.SelectedValue = "1";
                        //}
                        //else
                        //{
                        //    //ddlgenderadd.SelectedValue = "2"
                        //    ddltitle.SelectedValue = "2";
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

                        
                        //Country();
                        

                        //Institutetype();                        
                        //CurrentStudyingIn();
                        //Board();
                       // DivisionSession();
                        //Yearofpassing();
                        //Currentyear();
                        lblprimarycontactid.Text = dr["Lead_Contact_Code"].ToString();
                        txtproductInterested.Text = dr["Prod_Interest"].ToString();
                        //BindScore();
                        //StudentType();
                        
                        ddlacademicyear.SelectedValue = dr["Expected_Join_AcadYear"].ToString();
                        txtExpjoindate.Text = dr["Time_join"].ToString();
                        ddlcustomertype.SelectedValue = dr["Category_Type_id"].ToString();

                        if (ddlcustomertype.SelectedValue == "01")
                        {
                            tblorgassign.Visible = true;
                            tblrow1.Visible = true;
                            trSourcecompany.Visible = true;
                            //tdstudentid.Visible = true;
                            //tdstudentid1.Visible = true;
                            //tdlastcourse.Visible = true;
                            //tdlastcourse1.Visible = true;
                            BindSourceCompany();
                            ddlsourcecompanyadd.SelectedValue = dr["Contact_Source_Company"].ToString();
                            BindSourceDivisionAdd();
                            ddlSourcedivisionadd.SelectedValue = dr["Contact_Source_Division"].ToString();
                            BindSourceZoneAdd();
                            ddlSourcezoneadd.SelectedValue = dr["Contact_Source_Zone"].ToString();
                            BindSourceCenterAdd();
                            ddlSourcecenteradd.SelectedValue = dr["Contact_Source_Center"].ToString();
                            BindTargetCompany();
                            ddltargetcompanyadd.SelectedValue = dr["Contact_Target_Company"].ToString();
                            BindTargetDivisionadd();
                            ddltargetdivisionadd.SelectedValue = dr["Contact_Target_Division"].ToString();
                            BindTargetzoneadd();
                            ddltargetzoneadd.SelectedValue = dr["Contact_Target_Zone"].ToString();
                            BindTargetCenterAdd();
                            ddltargetcenteradd.SelectedValue = dr["Contact_Target_Center"].ToString();

                        }
                        else if (ddlcustomertype.SelectedValue == "02")
                        {
                            tblorgassign.Visible = true;
                            tblrow1.Visible = false;
                            trSourcecompany.Visible = false;
                            //tdstudentid.Visible = false;
                            //tdstudentid1.Visible = false;
                            //tdlastcourse.Visible = false;
                            //tdlastcourse1.Visible = false;

                            BindTargetCompany();
                            ddltargetcompanyadd.SelectedValue = dr["Contact_Target_Company"].ToString();
                            BindTargetDivisionadd();
                            ddltargetdivisionadd.SelectedValue = dr["Contact_Target_Division"].ToString();
                            BindTargetzoneadd();
                            ddltargetzoneadd.SelectedValue = dr["Contact_Target_Zone"].ToString();
                            BindTargetCenterAdd();
                            ddltargetcenteradd.SelectedValue = dr["Contact_Target_Center"].ToString();

                        }
                        else if (ddlcustomertype.SelectedValue == "03")
                        {
                            tblorgassign.Visible = true;
                            tblrow1.Visible = true;
                            trSourcecompany.Visible = true;
                            //tdstudentid.Visible = true;
                            //tdstudentid1.Visible = true;
                            //tdlastcourse.Visible = true;
                            //tdlastcourse1.Visible = true;
                            BindSourceCompany();
                            ddlsourcecompanyadd.SelectedValue = dr["Contact_Source_Company"].ToString();
                            BindSourceDivisionAdd();
                            ddlSourcedivisionadd.SelectedValue = dr["Contact_Source_Division"].ToString();
                            BindSourceZoneAdd();
                            ddlSourcezoneadd.SelectedValue = dr["Contact_Source_Zone"].ToString();
                            BindSourceCenterAdd();
                            ddlSourcecenteradd.SelectedValue = dr["Contact_Source_Center"].ToString();
                            BindTargetCompany();
                            ddltargetcompanyadd.SelectedValue = dr["Contact_Target_Company"].ToString();
                            BindTargetDivisionadd();
                            ddltargetdivisionadd.SelectedValue = dr["Contact_Target_Division"].ToString();
                            BindTargetzoneadd();
                            ddltargetzoneadd.SelectedValue = dr["Contact_Target_Zone"].ToString();
                            BindTargetCenterAdd();
                            ddltargetcenteradd.SelectedValue = dr["Contact_Target_Center"].ToString();

                        }
                        else if (ddlcustomertype.SelectedValue == "04")
                        {
                            tblorgassign.Visible = true;
                            tblrow1.Visible = false;
                            trSourcecompany.Visible = false;
                            //tdstudentid.Visible = false;
                            //tdstudentid1.Visible = false;
                            //tdlastcourse.Visible = false;
                            //tdlastcourse1.Visible = false;
                            BindTargetCompany();
                            ddltargetcompanyadd.SelectedValue = dr["Contact_Target_Company"].ToString();
                            BindTargetDivisionadd();
                            ddltargetdivisionadd.SelectedValue = dr["Contact_Target_Division"].ToString();
                            BindTargetzoneadd();
                            ddltargetzoneadd.SelectedValue = dr["Contact_Target_Zone"].ToString();
                            BindTargetCenterAdd();
                            ddltargetcenteradd.SelectedValue = dr["Contact_Target_Center"].ToString();
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


                        if (lblusercompany.Text == "MPUC")
                        {
                        }
                        else
                        {
                            //txtscore.Text = dr["Score"].ToString();
                            //txtpercentage.Text = dr["Percentile"].ToString();
                            //txtarearank.Text = dr["Area_Rank"].ToString();
                            //txtoverallrank.Text = dr["Overall_Rank"].ToString();
                            //Scorerange();
                            //ddlscorerange.SelectedValue = dr["Score_Range_Type"].ToString();
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
                            //txtcompetitiveexams.Text = dr["Competitive_Exam"].ToString();
                            //txtmsmarks.Text = dr["total_ms_marks"].ToString();
                            //txtmsobtained.Text = dr["total_ms_marks_obt"].ToString();
                        }


                        txtassignedto.Text = dr["Contact_Assignto"].ToString();
                        txtsourcedesc.Text = dr["Source_desc"].ToString();
                        //txtdateofbirth.Text = dr["dob"].ToString();
                        //txtexaminationdetails.Text = dr["Last_Exam_Passed"].ToString();
                        DataSet ds = ProductController.Get_ContactbyContactId(9, Lead_Code);

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
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    private void BindRobomatedetails()
    {
        try
        {
            if (Request["Lead_Code"] != null)
            {
                string Lead_Code = Request["Lead_Code"];
                SqlDataReader dr = Robomate_Integration_Lead.GetRobomatedetailsbyLeadid(Lead_Code);
                if ((((dr) != null)))
                {
                    if (dr.Read())
                    {

                        ddldevice.SelectedValue = dr["User_Device_Id"].ToString();
                        ddlprovidedby.SelectedValue = dr["Provided_By_id"].ToString();
                        ddlownedby.SelectedValue = dr["Owned_By_Id"].ToString();
                        ddlplatform.SelectedValue = dr["Platform_Id"].ToString();
                        ddldevicebrand.SelectedValue = dr["Device_Brand_Id"].ToString();
                        txtotherbrand.Text = dr["Device_Brand_Addl_Text"].ToString();
                        txtdevicemodel.Text = dr["Device_Model"].ToString();
                        txtdeviceconfig.Text = dr["Device_Config"].ToString();
                        ddlaccessmode.SelectedValue = dr["Access_Mode_Id"].ToString();
                        ddlstoragemediatype.SelectedValue = dr["Storage_Media_type_Id"].ToString();
                        ddlcapacity.SelectedValue = dr["Capacity"].ToString();
                        txthddfreespace.Text = dr["HDD_Free_Space"].ToString();
                        ddlnoofstorage.SelectedValue = dr["No_of_Storage_Media"].ToString();
                        txtsi1.Text = dr["Special_Instruction_1"].ToString();
                        txtsi2.Text = dr["Special_Instruction_2"].ToString();
                        txtsi3.Text = dr["Special_Instruction_3"].ToString();
                        ddlinstallationlocation.SelectedItem.Text = dr["Installation_Location"].ToString();
                        date_picker.Text = dr["Appointment_Date"].ToString();
                        timepicker1.Value = dr["Appointment_Time"].ToString();
                        date_picker1.Text = dr["Installation_Date"].ToString();
                        timepicker2.Value = dr["Installation_Time"].ToString();
                        ddlinstallationstatus.SelectedValue = dr["Installation_Status_Id"].ToString();
                        date_picker2.Text = dr["Rescheduled_Date"].ToString();
                        timepicker3.Value = dr["Rescheduled_Time"].ToString();
                        txtengineername.Text = dr["Engineer_Name"].ToString();
                        txtengineercontactnumber.Text = dr["Contact_Number"].ToString();
                        txtengineeremailid.Text = dr["Email_Id"].ToString();
                        txtengineercompany.Text = dr["Engineer_Company"].ToString();
                        lblContactid.Text = dr["Lead_Contact_Code"].ToString();
                        chkmaindevicedetails.Checked = true;
                        chkmaindevicedetails.Enabled = false;
                        //tblrobodetails.Visible = true;
                        //tblrobodetails1.Visible = true;
                    }
                    else
                    {
                        chkmaindevicedetails.Checked = false;
                        chkmaindevicedetails.Enabled = true;
                        tblrobodetails.Visible = false;
                        tblrobodetails1.Visible = false;
                    }
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
    //        //divscoreerror.Visible = true;
    //        //lblscoreerror.Text = "No Scores Entered!";
    //        divscoreerror.Visible = false;
    //    }
    //}


    //private void BindSecContact()
    //{
    //    if (Request["Lead_Code"] != null)
    //    {
    //        string Lead_Code = Request["Lead_Code"];

    //        DataSet ds = ProductController.Get_SecondaryContactbyLeadid(Lead_Code);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            dlseccontact.DataSource = ds;
    //            dlseccontact.DataBind();
    //            divseccontact.Visible = false;
    //        }
    //        else
    //        {
    //            divseccontact.Visible = true;
    //            lblseccontact.Text = "No Secondary Contact Found!";
    //        }
    //    }
    //}
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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
    //private void StudentType()
    //{
    //    DataSet ds = ProductController.GetAllStudentType();
    //    BindDDL(ddlstudenttypeadd, ds, "Description", "Cust_Grp");
    //    ddlstudenttypeadd.Items.Insert(0, "Select");
    //    ddlstudenttypeadd.SelectedIndex = 0;

    //}
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
    //    DataSet ds = ProductController.GetAllFieldInterestedByDisciplineid( Convert.ToInt32 (  ddldiscipline.SelectedValue));
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
    //    this.ddlcurrentstudying.Items.Insert(0, "Select");
    //    this.ddlcurrentstudying.SelectedIndex = 0;
    //    this.ddlinstitutiontype.Focus();
    //}
    //private void CurrentStudyingIn()
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
    //    BindDDL(ddlcurrentstudying, ds, "Description", "ID");
    //    this.ddlcurrentstudying.Items.Insert(0, "Select");
    //    this.ddlcurrentstudying.SelectedIndex = 0;
    //    this.ddlinstitutiontype.Focus();
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
    private void Currentyear()
    {
        DataSet ds = ProductController.GetAllCurrentyear();
        BindDDL(ddlacademicyear, ds, "Description", "ID");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
    }
    //private void DivisionSession()
    //{
    //    DataSet ds = ProductController.GetAllDivisionSection();
    //    BindDDL(ddlsection, ds, "Description", "ID");
    //}
    //private void ContactType()
    //{
    //    DataSet ds = ProductController.GetallactiveContactType();
    //    BindDDL(ddlcontacttype1, ds, "Description", "ID");

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
        
    //protected void ddlcity_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindLocation();
    //}
    //private void BindLocation()
    //{
    //    DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
    //    BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
    //    //ddllocation.Items.Insert(0, "Select")
    //    //ddllocation.SelectedIndex = 0
    //}

    protected void ddlcustomertype_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlcustomertype.SelectedValue == "01")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = true;
            trSourcecompany.Visible = true;
            //tdstudentid.Visible = true;
            //tdstudentid1.Visible = true;
            //tdlastcourse.Visible = true;
            //tdlastcourse1.Visible = true;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlcustomertype.SelectedValue == "02")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = false;
            trSourcecompany.Visible = false;
            //tdstudentid.Visible = false;
            //tdstudentid1.Visible = false;
            //tdlastcourse.Visible = false;
            //tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlcustomertype.SelectedValue == "03")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = true;
            trSourcecompany.Visible = true;
            //tdstudentid.Visible = true;
            //tdstudentid1.Visible = true;
            //tdlastcourse.Visible = true;
            //tdlastcourse1.Visible = true;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlcustomertype.SelectedValue == "04")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = false;
            trSourcecompany.Visible = false;
            //tdstudentid.Visible = false;
            //tdstudentid1.Visible = false;
            //tdlastcourse.Visible = false;
            //tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus()
        }
        else
        {
            tblorgassign.Visible = false;
            tblrow1.Visible = true;
            //tdstudentid.Visible = false;
            //tdstudentid1.Visible = false;
            //tdlastcourse.Visible = false;
            //tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus()
        }
    }
   
    protected void btnaddlead_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead_Add.aspx");
    }


    protected void btnsearchlead_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead.aspx");
    }


    //protected void btnback_Click(object sender, System.EventArgs e)
    //{
    //    if (ViewState["PreviousPage"] != null)
    //    {
    //        Response.Redirect(ViewState["PreviousPage"].ToString());
    //    }
    //}

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
        BindDDL(ddlplatform, ds, "Platform_Os_Type", "Platform_Type_Id");
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
        DataSet ds = Robomate_Integration_Lead.GetAllAccessMode();
        BindDDL(ddlaccessmode, ds, "Access_Mode", "Access_Mode_Id");
        ddlaccessmode.Items.Insert(0, "Select");
        ddlaccessmode.SelectedIndex = 0;
    }

    private void GetAllStorageMediaType()
    {
        DataSet ds = Robomate_Integration_Lead.GetAllStorageMediaType();
        BindDDL(ddlstoragemediatype, ds, "Storage_Media_Type", "Storage_Media_Type_Id");
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
            //tblrobodetails.Visible = true;
            //tblrobodetails1.Visible = true;
        }
        else
        {
            tblrobodetails.Visible = false;
            tblrobodetails1.Visible = false;
        }
    }

    protected void ddldevicebrand_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddldevicebrand.SelectedValue == "10004")
        {
            txtotherbrand.Enabled = true;
            //RequiredFieldValidator31.Enabled = true;
        }
        else
        {
            txtotherbrand.Enabled = false;
            //RequiredFieldValidator31.Enabled = false;
        }
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

    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindCity();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindState();
    }

    //private void ContactType()
    //{
    //    DataSet ds = ProductController.GetallactiveContactTypeinrelation();
    //    BindDDL(ddlContactType, ds, "Description", "ID");
    //}

    private void StudentType2()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlcustomertype, ds, "Description", "Cust_Grp");
        ddlcustomertype.Items.Insert(0, "Select");
        ddlcustomertype.SelectedIndex = 0;
    }

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

    private void BindSecContactDetails(string Conid)
    {
        string Con_id = Conid;

        //lblPKey_Con_Id.Text = Con_id;

        ContactInfoPanel1.BindSecContactDetails_Agent(Con_id);
        //BindContactHistory
        //HistoryPanel1.BindContactHistory(Con_id);
        
        //DataSet ds = ProductController.Get_ContactbyContactId(7, Con_id);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    if ((ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == ""))
        //    {
        //        ddlContactsourceadd.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        ddlContactsourceadd.SelectedValue = ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString();
        //    }

        //    if ((ds.Tables[0].Rows[0]["Con_type_id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Con_type_id"].ToString() == ""))
        //    {
        //        ddlContactType.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        ddlContactType.SelectedValue = ds.Tables[0].Rows[0]["Con_type_id"].ToString();
        //    }

        //    if ((ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == ""))
        //    {
        //        ddlcustomertype.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        ddlcustomertype.SelectedValue = ds.Tables[0].Rows[0]["Category_Type_Id"].ToString();
        //    }


        //    if (ds.Tables[0].Rows[0]["Con_title"].ToString() == "Mr.")
        //    {
        //        ddlTitle.SelectedValue = "1";
        //    }
        //    else if (ds.Tables[0].Rows[0]["Con_title"].ToString() == "Ms.")
        //    {
        //        ddlTitle.SelectedValue = "2";
        //    }
        //    else
        //    {
        //        ddlTitle.SelectedIndex = 0;
        //    }

        //    txtFirstName.Text = ds.Tables[0].Rows[0]["Con_Firstname"].ToString();
        //    txtMidName.Text = ds.Tables[0].Rows[0]["Con_midname"].ToString();
        //    txtLastName.Text = ds.Tables[0].Rows[0]["Con_lastname"].ToString();

        //    if ((ds.Tables[0].Rows[0]["Gender"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Gender"].ToString() == ""))
        //    {
        //        ddlGender.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Male")
        //        {
        //            ddlGender.SelectedValue = "1";
        //        }
        //        else if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Female")
        //        {
        //            ddlGender.SelectedValue = "2";
        //        }
        //        else
        //            ddlGender.SelectedIndex = 0;
        //    }

        //    if (ds.Tables[0].Rows[0]["DOB"].ToString() == "")
        //    {
        //        txtdateofbirth.Text = "";
        //    }
        //    else
        //    {
        //        txtdateofbirth.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
        //    }

        //    txtHandPhone1.Text = ds.Tables[0].Rows[0]["handphone1"].ToString();
        //    txtHandphone2.Text = ds.Tables[0].Rows[0]["handphone2"].ToString();
        //    txtlandline.Text = ds.Tables[0].Rows[0]["landline"].ToString();
        //    txtemailid.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
        //    txtaddress1.Text = ds.Tables[0].Rows[0]["Flatno"].ToString();
        //    txtaddress2.Text = ds.Tables[0].Rows[0]["BuildingName"].ToString();
        //    txtStreetname.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
        //    txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

        //    if ((ds.Tables[0].Rows[0]["Country"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Country"].ToString() == ""))
        //    {
        //        ddlCountry.SelectedIndex = 0;
        //        ddlstate.Items.Clear();
        //        ddlcity.Items.Clear();
        //        ddllocation.Items.Clear();
        //        ddlstate.Items.Insert(0, "Select");
        //        ddlcity.Items.Insert(0, "Select");
        //        ddllocation.Items.Insert(0, "Select");
        //        ddlstate.SelectedIndex = 0;
        //        ddlcity.SelectedIndex = 0;
        //        ddllocation.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
        //        BindState();
        //        if ((ds.Tables[0].Rows[0]["State"].ToString() == "Select") || (ds.Tables[0].Rows[0]["State"].ToString() == ""))
        //        {
        //            ddlstate.SelectedIndex = 0;
        //            ddlcity.Items.Clear();
        //            ddllocation.Items.Clear();
        //            ddlcity.Items.Insert(0, "Select");
        //            ddlcity.SelectedIndex = 0;
        //            ddllocation.Items.Insert(0, "Select");
        //            ddllocation.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            ddlstate.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
        //            BindCity();
        //            if ((ds.Tables[0].Rows[0]["City"].ToString() == "Select") || (ds.Tables[0].Rows[0]["City"].ToString() == ""))
        //            {
        //                ddlcity.SelectedIndex = 0;
        //                ddllocation.Items.Clear();
        //                ddllocation.Items.Insert(0, "Select");
        //                ddllocation.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                ddlcity.SelectedValue = ds.Tables[0].Rows[0]["City"].ToString();
        //                BindLocation();
        //                if ((ds.Tables[0].Rows[0]["Location"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Location"].ToString() == ""))
        //                {
        //                    ddllocation.SelectedIndex = 0;
        //                }
        //                else
        //                {
        //                    ddllocation.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
        //                }
        //            }
        //        }
        //    }

        //    if (ds.Tables[1].Rows.Count > 0)
        //    {
        //        dlAcadInfo.Visible = true;
        //        lblAcadInfoRecord.Visible = false;
        //        dlAcadInfo.DataSource = ds.Tables[1];
        //        dlAcadInfo.DataBind();
        //    }
        //    else
        //    {
        //        dlAcadInfo.Visible = false;
        //        lblAcadInfoRecord.Visible = true;
        //        lblAcadInfoRecord.Text = "No records found..!";
        //    }

        //    if (ds.Tables[2].Rows.Count > 0)
        //    {
        //        dlSec_Con_Info.Visible = true;
        //        lblSecConRecord.Visible = false;
        //        dlSec_Con_Info.DataSource = ds.Tables[2];
        //        dlSec_Con_Info.DataBind();
        //    }
        //    else
        //    {
        //        dlSec_Con_Info.Visible = false;
        //        lblSecConRecord.Visible = true;
        //        lblSecConRecord.Text = "No records found..!";
        //    }

        //    if (ds.Tables[3].Rows.Count > 0)
        //    {

        //        dlConHistory.Visible = true;
        //        lblCon_History.Visible = false;

        //        dlConHistory.DataSource = ds.Tables[3];
        //        dlConHistory.DataBind();
        //    }
        //    else
        //    {
        //        dlConHistory.Visible = false;
        //        lblCon_History.Visible = true;
        //        lblCon_History.Text = "No records found..!";
        //    }

        //    binddlfeedback();
        //}
    }

    //private void BindLocation()
    //{
    //    DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
    //    BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
    //    ddllocation.Items.Insert(0, "Select");
    //    ddllocation.SelectedIndex = 0;
    //}   
    

    //private void binddlfeedback()
    //{
    //    if (Request["Lead_Code"] != null)
    //    {
    //        string leadid = Request["Lead_Code"];
    //        DataSet ds = ProductController.GetAllLeadfeedbackbyLeadid(leadid);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            dlfeedbackhistory.DataSource = ds;
    //            dlfeedbackhistory.DataBind();
    //            dlfeedbackhistory.Visible = true;
    //            diverrormessagefeedback.Visible = false;
    //        }
    //        else
    //        {
    //            divfeedbackhistory.Visible = false;
    //            diverrormessagefeedback.Visible = true;
    //            lblerrrormessagefeedback.Text = "No Follow up history found !!!";
    //        }
    //    }
    //}
    
}