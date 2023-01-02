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
using System.Text;

public partial class Convert_Lead_To_Opportunity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["Lead_Code"] != null)
            {
                string leadid = Request["Lead_Code"];
                lblprimaryLeadCode.Text = leadid;
                string Menuid = "102";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "Convert to Opportunity";
                lblpagetitle2.Text = "";
                limidbreadcrumb.Visible = false;
                lblmidbreadcrumb.Text = "Manage Lead";
                lilastbreadcrumb.Visible = false;
                lbllastbreadcrumb.Text = " Display Lead";
                lilastbreadcrumb.Visible = false;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;

                this.txtappno.Enabled = false;
                this.txtappno.Text = "";
                lblappnoerror.Visible = false;

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
                ContactSource();
                BindBranchTopperDivision();
                BindddlInstitute();
                BindDiscountconditions();
                Leadtype();
                LeadSource();
                leadstatus();
                ContactType();
                StudentType2();
                Country2();
                bindddlproductcategory();
                Bindddlsalesstage();
                BindSalesChannel();
                BindCompany();
                txtconverteddate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                //StudentType();
                //ddlfieldint.Items.Insert(0, "Select");
                //ddlfieldint.SelectedIndex = 0;
                //BindSourceCompany();
                //BindTargetCompany();
                Bindlist();
                //BindSecContact();
                //For Robomate Integration
               
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

    private void BindLocation()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
        BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }   

    protected void ckhBranchTopper_CheckedChanged(object sender, EventArgs e)
    {
        ddlbranchtopperdivision.SelectedIndex = 0;
        ddlbranchtopperCenter.Items.Clear();
        if (ckhBranchTopper.Checked)
        {
            trBranchTopper.Visible = true;
            BindBranchTopperCenter();
        }
        else
        {
            trBranchTopper.Visible = false;
        }


    }

    protected void ckhRankerAdditional_CheckedChanged(object sender, EventArgs e)
    {
        ddldiscountconditions.SelectedIndex = 0;
        if (ckhRankerAdditional.Checked)
        {
            trDiscount.Visible = true;
            BindDiscountconditions();
        }
        else
        {
            trDiscount.Visible = false;
        }

    }

    protected void ddlbranchtopperdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranchTopperCenter();

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
        string division_Code = ddlconvertdivision.SelectedValue;
        string Company_code = ddlconvertcompany.SelectedValue;
        DataSet ds = ProductController.GetDiscount_Types(3, division_Code, Company_code);
        BindDDL(ddldiscountconditions, ds, "Discount_Type_Short_Desc", "Discount_Type");
        ddldiscountconditions.Items.Insert(0, "Select");
        ddldiscountconditions.SelectedIndex = 0;
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
                        if (dr["Opp_Flag"].ToString() != "0")
                        {
                            upnl1.Visible = false;
                            divErrorMessage1.Visible = true;
                            lblErrorOpp.Text = "This Lead is already converted to Opportunity....!";
                        }
                        txt1.Text = dr["Createdon"].ToString();
                        ddlleadtypeadd.SelectedValue = dr["Lead_Type_Code"].ToString();
                        ddlleadsourceadd.SelectedValue = dr["Lead_Source_Code"].ToString();
                        ddlleadstatusadd.SelectedValue = dr["Lead_Status_Code"].ToString();
                        txtsourcedesc.Text = "";
                        lblConId.Text = dr["Con_Id"].ToString();
                        BindSecContactDetails(lblConId.Text);
                        ddlconvertcompany.SelectedValue = dr["Expr5"].ToString();
                        BindConvertDivision();
                        ddlconvertdivision.SelectedValue = dr["Expr6"].ToString();
                        BindConvertZone();
                        ddlconvertzone.SelectedValue = dr["Expr7"].ToString();
                        BindConvertCenter();
                        ddlconvertcenter.SelectedValue = dr["Expr8"].ToString();
                        BindAcademicYear();
                        try
                        {
                            ddlConacademicyear.SelectedValue = dr["Expected_Join_AcadYear"].ToString();
                        }
                        catch
                        {
                        }
                        BindStream();

                        //Contact_Target_Company




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
                       // lblprimarycontactid.Text = dr["Lead_Contact_Code"].ToString();

                        
                        //StudentType();
                        ddlcustomertype.SelectedValue = dr["Category_Type_id"].ToString();

                        

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


                        //txtassignedto.Text = dr["Contact_Assignto"].ToString();
                        txtsourcedesc.Text = dr["Source_desc"].ToString();
                        //txtdateofbirth.Text = dr["dob"].ToString();
                        //txtexaminationdetails.Text = dr["Last_Exam_Passed"].ToString();
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
    //private void Currentyear()
    //{
    //    DataSet ds = ProductController.GetAllCurrentyear();
    //    BindDDL(ddlacademicyear, ds, "Description", "ID");
    //    ddlacademicyear.Items.Insert(0, "Select");
    //    ddlacademicyear.SelectedIndex = 0;
    //}
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
    
    
    //private void BindSourceCompany()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(7, "", "", "", "");
    //    BindDDL(ddlsourcecompanyadd, ds, "Company_Name", "Company_Code");
    //    ddlsourcecompanyadd.Items.Insert(0, "Select");
    //    ddlsourcecompanyadd.SelectedIndex = 0;
    //    ddlSourcedivisionadd.Items.Insert(0, "Select");
    //    ddlSourcedivisionadd.SelectedIndex = 0;
    //    ddlSourcezoneadd.Items.Insert(0, "Select");
    //    ddlSourcezoneadd.SelectedIndex = 0;
    //    ddlSourcecenteradd.Items.Insert(0, "Select");
    //    ddlSourcecenteradd.SelectedIndex = 0;
    //}
    //private void BindTargetCompany()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
    //    BindDDL(ddltargetcompanyadd, ds, "Company_Name", "Company_Code");
    //    ddltargetcompanyadd.Items.Insert(0, "Select");
    //    ddltargetcompanyadd.SelectedIndex = 0;
    //    ddltargetdivisionadd.Items.Insert(0, "Select");
    //    ddltargetdivisionadd.SelectedIndex = 0;
    //    ddltargetzoneadd.Items.Insert(0, "Select");
    //    ddltargetzoneadd.SelectedIndex = 0;
    //    ddltargetcenteradd.Items.Insert(0, "Select");
    //    ddltargetcenteradd.SelectedIndex = 0;
    //}
    //protected void ddlcompanyadd_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindSourceDivisionAdd();
    //    ddlSourcedivisionadd.Focus();
    //}
    //private void BindSourceDivisionAdd()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(8, "", "", "", ddlsourcecompanyadd.SelectedValue);
    //    BindDDL(ddlSourcedivisionadd, ds, "Division_Name", "Division_Code");
    //    ddlSourcedivisionadd.Items.Insert(0, "Select");
    //    ddlSourcedivisionadd.SelectedIndex = 0;
    //}

    //protected void ddltargetcompanyadd_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindTargetDivisionadd();
    //    ddltargetdivisionadd.Focus();
    //}
    //private void BindTargetDivisionadd()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddltargetcompanyadd.SelectedValue);
    //    BindDDL(ddltargetdivisionadd, ds, "Division_Name", "Division_Code");
    //    ddltargetdivisionadd.Items.Insert(0, "Select");
    //    ddltargetdivisionadd.SelectedIndex = 0;
    //}
    //protected void ddlSourcedivisionadd_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindSourceZoneAdd();
    //    ddlSourcedivisionadd.Focus();
    //}
    //protected void ddltargetdivisionadd_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindTargetzoneadd();
    //    ddltargetdivisionadd.Focus();
    //}
    //private void BindSourceZoneAdd()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(9, "", ddlSourcedivisionadd.SelectedValue, "", ddlsourcecompanyadd.SelectedValue);
    //    BindDDL(ddlSourcezoneadd, ds, "Zone_Name", "Zone_Code");
    //    ddlSourcezoneadd.Items.Insert(0, "Select");
    //    ddlSourcezoneadd.SelectedIndex = 0;
    //}
    //private void BindTargetzoneadd()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddltargetdivisionadd.SelectedValue, "", ddltargetcompanyadd.SelectedValue);
    //    BindDDL(ddltargetzoneadd, ds, "Zone_Name", "Zone_Code");
    //    ddltargetzoneadd.Items.Insert(0, "Select");
    //    ddltargetzoneadd.SelectedIndex = 0;
    //}
    //protected void ddlSourcezoneadd_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindSourceCenterAdd();
    //    ddlSourcecenteradd.Focus();
    //}

    //protected void ddltargetzoneadd_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindTargetCenterAdd();
    //    ddltargetcenteradd.Focus();
    //}
    //private void BindSourceCenterAdd()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(10, "", ddlSourcedivisionadd.SelectedValue, ddlSourcezoneadd.SelectedValue, ddlsourcecompanyadd.SelectedValue);
    //    BindDDL(ddlSourcecenteradd, ds, "Center_name", "Center_Code");
    //    ddlSourcecenteradd.Items.Insert(0, "Select");
    //    ddlSourcecenteradd.SelectedIndex = 0;
    //}
    //private void BindTargetCenterAdd()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];
    //    DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddltargetdivisionadd.SelectedValue, ddltargetzoneadd.SelectedValue, ddltargetcompanyadd.SelectedValue);
    //    BindDDL(ddltargetcenteradd, ds, "Center_name", "Center_Code");
    //    ddltargetcenteradd.Items.Insert(0, "Select");
    //    ddltargetcenteradd.SelectedIndex = 0;
    //}
        
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
            //tblorgassign.Visible = true;
            //tblrow1.Visible = true;
            //trSourcecompany.Visible = true;
            //tdstudentid.Visible = true;
            //tdstudentid1.Visible = true;
            //tdlastcourse.Visible = true;
            //tdlastcourse1.Visible = true;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlcustomertype.SelectedValue == "02")
        {
            //tblorgassign.Visible = true;
            //tblrow1.Visible = false;
            //trSourcecompany.Visible = false;
            //tdstudentid.Visible = false;
            //tdstudentid1.Visible = false;
            //tdlastcourse.Visible = false;
            //tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlcustomertype.SelectedValue == "03")
        {
            //tblorgassign.Visible = true;
            //tblrow1.Visible = true;
            //trSourcecompany.Visible = true;
            //tdstudentid.Visible = true;
            //tdstudentid1.Visible = true;
            //tdlastcourse.Visible = true;
            //tdlastcourse1.Visible = true;
            //ddlstudenttypeadd.Focus()
        }
        else if (ddlcustomertype.SelectedValue == "04")
        {
            //tblorgassign.Visible = true;
            //tblrow1.Visible = false;
            //trSourcecompany.Visible = false;
            //tdstudentid.Visible = false;
            //tdstudentid1.Visible = false;
            //tdlastcourse.Visible = false;
            //tdlastcourse1.Visible = false;
            //ddlstudenttypeadd.Focus()
        }
        else
        {
            //tblorgassign.Visible = false;
            //tblrow1.Visible = true;
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

    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactTypeinrelation();
        BindDDL(ddlContactType, ds, "Description", "ID");
    }

    private void StudentType2()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlcustomertype, ds, "Description", "Cust_Grp");
        ddlcustomertype.Items.Insert(0, "Select");
        ddlcustomertype.SelectedIndex = 0;
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

    private void BindSecContactDetails(string Conid)
    {
        string Con_id = Conid;

        //lblPKey_Con_Id.Text = Con_id;

        HtmlAnchor editContact = aedit;
        editContact.Visible = true;
        editContact.HRef = "Contact_Edit.aspx?&Con_id=" + Con_id;

        ContactInfoPanel1.BindSecContactDetails(Con_id);
        HistoryPanel1.BindContactHistory(Con_id);

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
                ddlcustomertype.SelectedIndex = 0;
            }
            else
            {
                ddlcustomertype.SelectedValue = ds.Tables[0].Rows[0]["Category_Type_Id"].ToString();
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

            if (ds.Tables[1].Rows.Count > 0)
            {
                dlAcadInfo.Visible = true;
                lblAcadInfoRecord.Visible = false;
                dlAcadInfo.DataSource = ds.Tables[1];
                dlAcadInfo.DataBind();
            }
            else
            {
                dlAcadInfo.Visible = false;
                lblAcadInfoRecord.Visible = true;
                lblAcadInfoRecord.Text = "No records found..!";
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                dlSec_Con_Info.Visible = true;
                lblSecConRecord.Visible = false;
                dlSec_Con_Info.DataSource = ds.Tables[2];
                dlSec_Con_Info.DataBind();
            }
            else
            {
                dlSec_Con_Info.Visible = false;
                lblSecConRecord.Visible = true;
                lblSecConRecord.Text = "No records found..!";
            }

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
            //    lblCon_History.Visible = true;
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

        }
    }

    private void bindddlproductcategory()
    {
        DataSet ds = ProductController.GetallOpporProductCategory();
        BindDDL(ddlproductcategory, ds, "Description", "ID");
        ddlproductcategory.Items.Insert(0, "Select");
        ddlproductcategory.SelectedIndex = 0;
        if (ds.Tables[0].Rows.Count == 1)
        {
            ddlproductcategory.SelectedValue = ds.Tables[0].Rows[0]["ID"].ToString();
        }
    }


    private void Bindddlsalesstage()
    {
        DataSet ds = ProductController.GetSalesStage(1);
        BindDDL(ddlsalesstage, ds, "Sales_Stage_Desc", "Sales_Id");
        ddlsalesstage.Items.Insert(0, "Select");
        ddlsalesstage.SelectedIndex = 0;
    }

    protected void ddlsalesstage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindProbabilityPercent();
        if (ddlsalesstage.SelectedValue == "04")
        {
            this.txtappno.Enabled = true;
            this.txtappno.Text = "";
            lblAppFormNoVal.Visible = true;
        }
        else
        {
            this.txtappno.Enabled = false;
            this.txtappno.Text = "";
            lblappnoerror.Visible = false;
            lblAppFormNoVal.Visible = false;
        }
        ddlsalesstage.Focus();
    }

    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");       

        BindDDL(ddlconvertcompany, ds, "Company_Name", "Company_Code");
        ddlconvertcompany.Items.Insert(0, "Select");
        ddlconvertcompany.SelectedIndex = 0;
      
    }

    private void BindProbabilityPercent()
    {
        SqlDataReader dr = ProductController.GetProbabiltyPercent(ddlsalesstage.SelectedValue);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtprobabilitypercent.Text = dr["Probability_Percent"].ToString();
            }
        }
    }

    protected void ddlconvertcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindConvertDivision();
        ddlconvertcompany.Focus();
    }

    protected void ddlconvertdivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindConvertZone();
        ddlconvertdivision.Focus();
    }
    protected void ddlconvertzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindConvertCenter();
        ddlconvertzone.Focus();
    }
    protected void ddlconvertcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindAcademicYear();
        ddlconvertcenter.Focus();
    }

    private void BindConvertDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlconvertcompany.SelectedValue);
        BindDDL(ddlconvertdivision, ds, "Division_Name", "Division_Code");
        ddlconvertdivision.Items.Insert(0, "Select");
        ddlconvertdivision.SelectedIndex = 0;
    }

    private void BindConvertZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddlconvertdivision.SelectedValue, "", ddlconvertcompany.SelectedValue);
        BindDDL(ddlconvertzone, ds, "Zone_Name", "Zone_Code");
        ddlconvertzone.Items.Insert(0, "Select");
        ddlconvertzone.SelectedIndex = 0;
    }
    private void BindConvertCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddlconvertdivision.SelectedValue, ddlconvertzone.SelectedValue, ddlconvertcompany.SelectedValue);
        BindDDL(ddlconvertcenter, ds, "Center_name", "Center_Code");
        ddlconvertcenter.Items.Insert(0, "Select");
        ddlconvertcenter.SelectedIndex = 0;
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddlconvertcenter.SelectedValue);
        BindDDL(ddlConacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlConacademicyear.Items.Insert(0, "Select");
        ddlConacademicyear.SelectedIndex = 0;
    }


    protected void ddlConacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
        ddlConacademicyear.Focus();
    }

    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear(ddlconvertcenter.SelectedValue, ddlConacademicyear.SelectedValue);
        BindDDL(ddlproduct, ds, "Stream_Sdesc", "Stream_Code");
        ddlproduct.Items.Insert(0, "Select");
        ddlproduct.SelectedIndex = 0;
        //To Do
    }


    private void BindSalesChannel()
    {
        DataSet ds = ProductController.GetAllSalesChannel();
        BindDDL(ddlsaleschannel, ds, "Description", "ID");
        ddlsaleschannel.Items.Insert(0, "Select");
        ddlsaleschannel.SelectedIndex = 0;
        if (ds.Tables[0].Rows.Count == 1)
        {
            ddlsaleschannel.SelectedValue = ds.Tables[0].Rows[0]["ID"].ToString();
        }
    }

    protected void btnEditCon_Click(object sender, EventArgs e)
    {
        string url = "Contact_Edit.aspx?&Con_id=" + lblConId.Text;
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.open('");
        sb.Append(url);
        sb.Append("');");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(),
                "script", sb.ToString());
    }

    protected void btnRefreshCon_Click(object sender, EventArgs e)
    {
        Response.Redirect("Convert_Lead_To_Opportunity.aspx?&Lead_Code=" + lblprimaryLeadCode.Text);
    }

    protected void btnopportunitysubmit_ServerClick(object sender, System.EventArgs e)
    {
        if ((ddlsalesstage.SelectedValue == "04" & string.IsNullOrEmpty(this.txtappno.Text)))
        {
            lblappnoerror.Visible = true;
            lblappnoerror.Text = "Please Enter Application Number !";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Please Enter Application Number !',class_name: 'gritter-error'});});</script>", false);
            this.txtappno.Focus();
            return;
        }
        else if (ddlsalesstage.SelectedValue == "04")
        {
            //Check For duplicate Application No.
            string Company = "";
            string Division = "";
            string Center = "";
            string Stream = "";
            string app_no = "";
            string Flag = "";

            Company = ddlconvertcompany.SelectedValue;
            Division = ddlconvertdivision.SelectedValue;
            Center = ddlconvertcenter.SelectedValue;
            Stream = ddlproduct.SelectedValue;
            app_no = txtappno.Text;
            Flag = ProductController.CheckDuplicateAppno(Company, Division, Center, Stream, app_no);
            //Flag = "0"
            if (Flag == "0")
            {
                lblappnoerror.Visible = true;
                lblappnoerror.Text = "Application No. already exists!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Application No. already exists!',class_name: 'gritter-error'});});</script>", false);
                return;
            }
            else
            {
                lblappnoerror.Visible = false;
            }
        }


        if (string.IsNullOrEmpty(txtjoindate.Value))
        {
        }
        else
        {

            try
            {

                if (Convert.ToDateTime(ClsCommon.FormatDate(txtjoindate.Value)) < DateTime.Today)
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
                return;
            }
            try
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtexpectedclosedate.Value)) < DateTime.Today)
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
                lbldateerrorJoindate.Visible = false;
                return;
            }
        }

        try
        {


            if (string.IsNullOrEmpty(txtexpectedclosedate.Value))
            {
            }
            //else if (Convert.ToDateTime(ClsCommon.FormatDate(txtexpectedclosedate.Text)) < Today)
            //{
            //    //lbldateerrorexp.Visible = True
            //    //lbldateerrorexp.Text = "Exp. Close Date cannot be a past date"
            //    //txtexpectedclosedate.Focus()
            //    //lbldateerrorJoindate.Visible = False
            //    //Exit Sub
            //}
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
            lbldateerrorJoindate.Visible = false;
            return;
        }




        try
        {
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
            string Opp_Contact_Company = "";
            string Opp_Contact_Division = "";
            string Opp_Contact_Center = "";
            dynamic Opp_Contact_Zone = "";
            string Opp_Contact_Id = "";
            string Opp_Contact_Role = "";
            string Opp_Contact_Assignto = "";
            string Created_by = "";
            string Last_Modified_by = "";
            string Opportunity_Code = "";
            string Opp_Status = "";
            string Opp_Status_Id = "";
            string SalesChannel = "";
            string SalesChannel_Id = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string OppAcadyear = "";
            string AppNo = "";
            Opp_Contact_Assignto = UserID;
            Lead_Code = lblprimaryLeadCode.Text;
            Product_Category = ddlproductcategory.SelectedItem.Text;
            Product_Code = ddlproductcategory.SelectedValue;
            Sales_Stage = ddlsalesstage.SelectedValue;

            if (string.IsNullOrEmpty(txtjoindate.Value))
            {
                txtjoindate.Value = DateTime.Now.ToString("dd-MM-yyyy");
                Opportunity_Joindate = Convert.ToDateTime(txtjoindate.Value, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            else
            {
                Opportunity_Joindate = Convert.ToDateTime(txtjoindate.Value, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            Opportunity_Expected_Date = Convert.ToDateTime(txtexpectedclosedate.Value, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            if (string.IsNullOrEmpty(txtdiscount.Text))
            {
                txtdiscount.Text = "0.00";
            }
            else
            {
                Opportunity_Discount = Convert.ToDecimal(txtdiscount.Text);
            }

            Opportunity_Probability_Percent = txtprobabilitypercent.Text;
            Opp_Contact_Company = ddlconvertcompany.SelectedValue;
            Opp_Contact_Division = ddlconvertdivision.SelectedValue;
            Opp_Contact_Zone = ddlconvertzone.SelectedValue;
            Opp_Contact_Center = ddlconvertcenter.SelectedValue;
            OppAcadyear = ddlConacademicyear.SelectedValue;
            AppNo = txtappno.Text;
            string Oppor_product = "";
            string Oppor_Product_id = "";
            Oppor_product = ddlproduct.SelectedItem.Text;
            Oppor_Product_id = ddlproduct.SelectedValue;
            SalesChannel_Id = ddlsaleschannel.SelectedValue;
            SalesChannel = ddlsaleschannel.SelectedItem.Text;
            string Disc_remark = "";
            Disc_remark = txtdiscountnotes.Text;

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



            Opportunity_Code = ProductController.Insert_ConvertLeadTo_Opportunity("", "", "", Lead_Code, Product_Category, Product_Code, Sales_Stage, Opportunity_Joindate, Opportunity_Expected_Date, Opportunity_Probability_Percent,
            "", Opportunity_Value, Opportunity_Discount, Opp_Contact_Company, Opp_Contact_Division, Opp_Contact_Center, Opp_Contact_Zone, Opp_Contact_Role, Opp_Contact_Assignto, UserID,
            UserID, Opp_Status, Opp_Status_Id, Oppor_product, Oppor_Product_id, OppAcadyear, AppNo, SalesChannel_Id, SalesChannel, Disc_remark, Is_Branch_Topper, Branch_Topper_Division,
            Branch_Topper_Center, Is_School_Ranker, School_Name, School_Division, School_Rank, Apply_Additional_Discount, Discount_Type);

            //System.Threading.Thread.Sleep(500);
            if (Opportunity_Code == "-1")
            {
                upnl1.Visible = false;
                divErrorMessage1.Visible = true;
                lblErrorOpp.Text = "This Lead is already converted to Opportunity....!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'This Lead is already converted to Opportunity....!',class_name: 'gritter-error'});});</script>", false);
                return;
            }

            if (ddlsalesstage.SelectedValue == "04")
            {
                EnrollStudent(lblConId.Text, Opportunity_Code);
                lblsaveOpp.Text = "Lead successfully converted to Opportunity....!Do you want to convert into Order?";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Convert into Order', text: 'Lead successfully converted to Opportunity..!If want to convert into Order then click on yes.',class_name: 'gritter-error'});});</script>", false);
                HtmlAnchor ConvertToOrder = aConvertToOrder;
                ConvertToOrder.Visible = true;
                ConvertToOrder.HRef = "Manage_Order.aspx?&Opportunity_Code=" + Opportunity_Code;
                divConvertOppToOrder.Visible = true;
            }
            else
            {
                lblsaveOpp.Text = "Lead successfully converted to Opportunity....!Navigation to manage order cannot be enable as application form number not filled.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Opportunity Save', text: 'Lead successfully converted to Opportunity....!Navigation to manage order cannot be enable as application form number not filled.',class_name: 'gritter-error'});});</script>", false);
            }

            bindddlproductcategory();
            Bindddlsalesstage();
            BindSalesChannel();
            BindCompany();
            ddlconvertdivision.SelectedIndex = 0;
            ddlconvertcenter.SelectedIndex = 0;
            ddlConacademicyear.SelectedIndex = 0;
            txtconverteddate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtdiscount.Text = "0";
            ddlproduct.SelectedIndex = 0;
            txtprobabilitypercent.Text = "0.00";
            txtappno.Text = "";
            
            //btnopportunitysubmit.Visible = false;
            //btnopportunitycancel.Visible = false;
            //Divsearchcriteria.Visible = false;
            //divsearchresults.Visible = false;

           // divSuccessmessage.Visible = true;
            upnl1.Visible = false;
            divSaveOpp.Visible = true;
           
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    private void EnrollStudent(string Contactid, string Opporid)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        //string Oppurid = "";
        string Enrollon = "";
        //string studentid = "";

        //string Opporid = ProductController.GetOppidbyContactid(1, Contactid);
        if (Opporid != "")
        {
            Enrollon = DateTime.Now.ToString("dd-MM-yyyy");
            string Student_id = ClsEnrollment.enrollstudent1(Enrollon, UserID, Opporid, "");

        }
    }

    protected void btnclose_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead.aspx");
    }

    protected void btnOppSaveMsg_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Opportunity.aspx");
    }

    protected void btnrefersh_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Convert_Lead_To_Opportunity.aspx?&Lead_Code=" + Request["Lead_Code"].ToString());
    }
}