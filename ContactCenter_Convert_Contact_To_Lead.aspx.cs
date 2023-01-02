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
using System.Text;
//using Exportxls.BL;



public partial class ContactCenter_Convert_Contact_To_Lead : System.Web.UI.Page
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
                lblpagetitle1.Text = "Assign To Lead";
                lblpagetitle2.Text = "";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "";
                //lilastbreadcrumb.Visible = false;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                upnldisplay.Visible = true;
                System.Threading.Thread.Sleep(1000);

                try
                {
                    if(Request["flag"].ToString() == "1")
                    {
                        btnCloseAll.Visible = true;
                        btnAssignLeadClose.Visible = false;
                        btn_ConvertToOppNo.Visible = true;
                        btnclose.Visible = false;
                    }
                }
                catch
                { }

                 if (Request["Campaign_Id"] != null)  //because the Agent(Contact center) Edit page is different
                {
                    //string Con_id = Request["Con_id"];
                    lblCampaign_Id.Text = Request["Campaign_Id"].ToString();
                }
                else
                {
                    lblCampaign_Id.Text = "";
                }

                //ContactSource();
                //ContactType();
                StudentType();
               // Country();
                Currentyear();
                //Currentyear();
                //listudentstatus.Visible = false;
                
                //SqlDataReader dr = UserController.Getuserrights(UserID, Menuid);
                //try
                //{
                //    if ((((dr) != null)))
                //    {
                //        if (dr.Read())
                //        {
                //            int allowdisplay =Convert.ToInt32(dr["Allow_Add"].ToString());
                //            if (allowdisplay == 1)
                //            {
                //                //btnaddlead.Visible = True
                //                //btnimportlead.Visible = True
                //            }
                //            else
                //            {
                //                //btnaddlead.Visible = False
                //                //btnimportlead.Visible = False
                //            }

                //        }
                //    }


                //}
                //catch (Exception ex)
                //{
                //}
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

                txt1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                //BindSalesStage()
                //BindOpporStatus()
                               
                //Country()
                Leadtype();
                LeadSource();
                leadstatus();
                string Con_id = "";
                Con_id = Request["Con_id"];
                lblConId.Text = Con_id;
                //HtmlAnchor ConEdit = aConEdit;
                //ConEdit.Visible = false;
                //ConEdit.HRef = "Contact_Edit?&Con_id=" + lblConId.Text;
                StudentType();
                BindSecContactDetails(Con_id);
                ddlcustomertype_SelectedIndexChanged(sender,e);
                BindSourceCompany();
                BindTargetCompany();
                ddltargetcompanyadd.SelectedValue = "MT";
                BindTargetDivisionadd();
                try
                {
                    ddltargetdivisionadd.SelectedValue = "V0";
                    BindTargetzoneadd();
                    ddltargetzoneadd.SelectedIndex = 1;
                    BindTargetCenterAdd();
                    ddltargetcenteradd.SelectedIndex = 1;
                }
                catch
                {
                }
                CurrentyearEducation();
                Discipline();
               // FieldInterested();
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


    private void BindSecContactDetails(string Conid)
    {
        string Con_id = Conid;

        lblConId.Text = Con_id;

        //HtmlAnchor editContact = aedit;
        //editContact.Visible = true;
        //editContact.HRef = "ContactCenter_Contact_Edit.aspx?&Con_id=" + lblConId.Text;

        ContactInfoPanel1.BindSecContactDetails_Agent(Con_id);        
        HistoryPanel1.BindContactHistory(Con_id);

        DataSet ds = ProductController.Get_ContactbyContactId(7, Con_id);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //ddlleadsourceadd

            //if ((ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == ""))
            //{
            //    ddlContactsourceadd.SelectedIndex = 0;
            //}
            //else
            //{
            //    ddlContactsourceadd.SelectedValue = ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString();
            //}

            if ((ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString() == ""))
            {
                ddlleadsourceadd.SelectedIndex = 0;
            }
            else
            {
                ddlleadsourceadd.SelectedValue = ds.Tables[0].Rows[0]["Contact_Source_Code"].ToString();
            }


            //if ((ds.Tables[0].Rows[0]["Con_type_id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Con_type_id"].ToString() == ""))
            //{
            //    ddlContactType.SelectedIndex = 0;
            //}
            //else
            //{
            //    ddlContactType.SelectedValue = ds.Tables[0].Rows[0]["Con_type_id"].ToString();
            //}

            if ((ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == ""))
            {
                ddlcustomertype.SelectedIndex = 0;
            }
            else
            {
                ddlcustomertype.SelectedValue = ds.Tables[0].Rows[0]["Category_Type_Id"].ToString();
            }


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


    //private void BindLocation()
    //{
    //    DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
    //    BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
    //    ddllocation.Items.Insert(0, "Select");
    //    ddllocation.SelectedIndex = 0;
    //}   
    
    //private void Country()
    //{
    //    DataSet ds = ProductController.GetallCountry();
    //    BindDDL(ddlCountry, ds, "Country_Name", "Country_Code");
    //    ddlCountry.Items.Insert(0, "Select");
    //    ddlCountry.SelectedIndex = 0;
    //    ddllocation.Items.Insert(0, "Select");
    //    ddllocation.SelectedIndex = 0;
    //}
    
    

    private void Leadtype()
    {
        DataSet ds = ProductController.Getallactiveleadtype();
        BindDDL(ddlleadtypeadd, ds, "Description", "ID");
        ddlleadtypeadd.Items.Insert(0, "Select");
        ddlleadtypeadd.SelectedIndex = 0;
        if (ds.Tables[0].Rows.Count == 1)
            ddlleadtypeadd.SelectedValue = ds.Tables[0].Rows[0]["ID"].ToString();

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
        try
        {
            ddlleadstatusadd.SelectedValue = "05";
        }
        catch
        {
        }
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

    protected void ddlSourcedivisionadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSourceZoneAdd();
        ddltargetcenteradd.SelectedIndex = 0;
        //ddlSourcedivisionadd.Focus()
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

    protected void ddlSourcezoneadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSourceCenterAdd();
        //ddlSourcecenteradd.Focus()
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

    protected void ddltargetdivisionadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTargetzoneadd();
        //ddltargetdivisionadd.Focus()
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

    protected void ddltargetzoneadd_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTargetCenterAdd();
        //ddltargetcenteradd.Focus()
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

    //btnSaveConvertContactToLead_ServerClick


    private void CurrentyearEducation()
    {
        DataSet ds = ProductController.GetAllCurrentyearEducation();
        BindDDL(ddlcurrentyeareducation, ds, "Current_Year_Education", "Year_ID");
        ddlcurrentyeareducation.Items.Insert(0, "Select");
        ddlcurrentyeareducation.SelectedIndex = 0;
    }

    private void Discipline()
    {
        DataSet ds = ProductController.GetallDiscipline();
        BindDDL(ddldiscipline, ds, "Discipline_Desc", "Discipline_Id");
        ddldiscipline.Items.Insert(0, "Select");
        ddldiscipline.SelectedIndex = 0;
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
    
    protected void btnCloseAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Contacts.aspx");
    }
    protected void btnSaveConvertContactToLead_Click(object sender, EventArgs e)
    {
        //string Campaignid = ddlcampaignid.SelectedValue;
        string Campaignid = lblCampaign_Id.Text;
        string SourceCompany = "", TargetCompany = "",Sourcedivision = "",  SourceZone = "",  SourceCenter = "", Targetdivision = "", TargetZone = "",TargetCenter = "";
        string ExpectedJoindate = "";
         HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string Contact_Assignto=UserID;
        if (string.IsNullOrEmpty(txtExpjoindate.Value))
        {
            //txtExpjoindate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            //ExpectedJoindate = Convert.ToDateTime(txtExpjoindate.Value, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            ExpectedJoindate = txtExpjoindate.Value;
        }
        else
        {
            ExpectedJoindate = txtExpjoindate.Value;
                //Convert.ToDateTime(txtExpjoindate.Value, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
        }

        if (ddlcustomertype.SelectedValue == "01")
        {
            SourceCompany = ddlsourcecompanyadd.SelectedValue;
            TargetCompany = ddltargetcompanyadd.SelectedValue;
            Sourcedivision = ddlSourcedivisionadd.SelectedValue;
            SourceZone = ddlSourcezoneadd.SelectedValue;
            SourceCenter = ddlSourcecenteradd.SelectedValue;
            Targetdivision = ddltargetdivisionadd.SelectedValue;
            TargetZone = ddltargetzoneadd.SelectedValue;
            TargetCenter = ddltargetcenteradd.SelectedValue;
        }
        else if (ddlcustomertype.SelectedValue == "02")
        {
            TargetCompany = ddltargetcompanyadd.SelectedValue;
            Targetdivision = ddltargetdivisionadd.SelectedValue;
            TargetZone = ddltargetzoneadd.SelectedValue;
            TargetCenter = ddltargetcenteradd.SelectedValue;
            Sourcedivision = "";
            SourceZone = "";
            SourceCenter = "";
        }
        else if (ddlcustomertype.SelectedValue == "03")
        {
            SourceCompany = ddlsourcecompanyadd.SelectedValue;
            TargetCompany = ddltargetcompanyadd.SelectedValue;
            Sourcedivision = ddlSourcedivisionadd.SelectedValue;
            SourceZone = ddlSourcezoneadd.SelectedValue;
            SourceCenter = ddlSourcecenteradd.SelectedValue;
            Targetdivision = ddltargetdivisionadd.SelectedValue;
            TargetZone = ddltargetzoneadd.SelectedValue;
            TargetCenter = ddltargetcenteradd.SelectedValue;
        }
        else if (ddlcustomertype.SelectedValue == "04")
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
        }

        int Interested_Discipline_Id = 0;
        string Interested_Discipline_Desc = "";
        int Interested_Field_Id = 0;
        string Interested_Field_Desc = "";

        
            if (ddldiscipline.SelectedItem.Text == "Select")
            {
                Interested_Discipline_Id = 0;
                Interested_Discipline_Desc = "Select";
            }
            else
            {
                Interested_Discipline_Id = Convert.ToInt32(ddldiscipline.SelectedValue);
                Interested_Discipline_Desc = ddldiscipline.SelectedItem.Text;
            }
            try
            {
                if (ddlfieldint.SelectedItem.Text == "Select")
                {
                    Interested_Field_Id = 0;
                    Interested_Field_Desc = "Select";
                }
                else
                {
                    Interested_Field_Id = Convert.ToInt32(ddlfieldint.SelectedValue);
                    Interested_Field_Desc = ddlfieldint.SelectedItem.Text;
                }
            }
            catch
            {
                Interested_Field_Id = 0;
                Interested_Field_Desc = "Select";
            }
        
        int C_Year_Education=0;
        if (this.ddlcurrentyeareducation.Text == "Select")
        {
            C_Year_Education = 0;
        }
        else
        {
            C_Year_Education =Convert.ToInt32(ddlcurrentyeareducation.SelectedValue);
        }

        DataSet ds= ProductController.Insert_Convert_Contact_To_Lead(ddlleadsourceadd.SelectedValue, ddlleadsourceadd.SelectedItem.ToString(), ddlleadtypeadd.SelectedValue, ddlleadstatusadd.SelectedValue, ddlleadstatusadd.SelectedItem.ToString(),
                            Campaignid, txtproductInterested.Text, ExpectedJoindate, lblConId.Text, SourceCompany, Sourcedivision, SourceCenter, SourceZone, Contact_Assignto, UserID, UserID, TargetCompany, Targetdivision, TargetZone, TargetCenter, Interested_Discipline_Id,
                            Interested_Discipline_Desc, Interested_Field_Id, Interested_Field_Desc, txtcompetitiveexams.Text, ddlleadtypeadd.SelectedItem.ToString(), txtsourcedesc.Text, txtexaminationdetails.Text, C_Year_Education,ddlacademicyear.SelectedValue);
      
        //Response.Redirect("ContactCenter_Contacts.aspx");
        //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalConvertToLeadMessage();", true);
       
        if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")//The Record is Save successfully
        {
            lblPKeyContactId.Text = ds.Tables[0].Rows[0]["lead_no"].ToString();
            DivMessage.Visible = true;
            upnldisplay.Visible = false;
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            //
            HtmlAnchor ConvertToOpp = aConvertToOpp;
            ConvertToOpp.Visible = true;
            ConvertToOpp.HRef = "ContactCenter_Convert_Lead_To_Opportunity.aspx?&Lead_Code=" + lblPKeyContactId.Text;

            //Response.Redirect("ContactCenter_Convert_Lead_To_Opportunity.aspx?&Lead_Code=" + lblPKeyContactId.Text);

        }
        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "-1")//if the record already Exist
        {
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = true;
            lblerrormessage.Text = ds.Tables[0].Rows[0]["Error"].ToString();
        }       
    }

    protected void ddlcustomertype_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlcustomertype.SelectedValue == "01")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = true;
            trSourcecompany.Visible = true;            
        }
        else if (ddlcustomertype.SelectedValue == "02")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = false;
            trSourcecompany.Visible = false;
        }
        else if (ddlcustomertype.SelectedValue == "03")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = true;
            trSourcecompany.Visible = true;
        }
        else if (ddlcustomertype.SelectedValue == "04")
        {
            tblorgassign.Visible = true;
            tblrow1.Visible = false;
            trSourcecompany.Visible = false;
        }
        else
        {
            tblorgassign.Visible = false;
            tblrow1.Visible = true;
        }
    }

    private void StudentType()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlcustomertype, ds, "Description", "Cust_Grp");
        ddlcustomertype.Items.Insert(0, "Select");
        ddlcustomertype.SelectedIndex = 0;
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
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Contacts.aspx");
    }

    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindCity();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // BindState();
    }


    //private void ContactType()
    //{
    //    DataSet ds = ProductController.GetallactiveContactTypeinrelation();
    //    BindDDL(ddlContactType, ds, "Description", "ID");
    //}

    //private void BindState()
    //{
    //    DataSet ds = ProductController.GetallStatebyCountry(ddlCountry.SelectedValue);
    //    BindDDL(ddlstate, ds, "State_Name", "State_Code");
    //    ddlstate.Items.Insert(0, "Select");
    //    ddlstate.SelectedIndex = 0;
    //    ddlcity.Items.Clear();
    //    ddlcity.Items.Insert(0, "Select");
    //    ddlcity.SelectedIndex = 0;
    //    ddllocation.Items.Clear();
    //    ddllocation.Items.Insert(0, "Select");
    //    ddllocation.SelectedIndex = 0;
    //}


    //private void BindCity()
    //{
    //    DataSet ds = ProductController.GetallCitybyState(ddlstate.SelectedValue);
    //    BindDDL(ddlcity, ds, "City_Name", "City_Code");
    //    ddlcity.Items.Insert(0, "Select");
    //    ddlcity.SelectedIndex = 0;
    //    ddllocation.Items.Clear();
    //    ddllocation.Items.Insert(0, "Select");
    //    ddllocation.SelectedIndex = 0;
    //}

    protected void btn_ConvertToOppYes_Click(object sender, EventArgs e)
    {

        Response.Redirect("ContactCenter_Convert_Lead_To_Opportunity.aspx?&Lead_Code=" + lblPKeyContactId.Text);

        //string url = "ContactCenter_Convert_Lead_To_Opportunity.aspx?&Lead_Code=" + lblPKeyContactId.Text;
        //StringBuilder sb = new StringBuilder();
        //sb.Append("<script type = 'text/javascript'>");
        //sb.Append("window.open('");
        //sb.Append(url);
        //sb.Append("');");
        //sb.Append("</script>");
        //ClientScript.RegisterStartupScript(this.GetType(),
        //        "script", sb.ToString());

    }

    protected void btn_ConvertToOppNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Add_Contacts.aspx");
    }

    protected void btnEditCon_Click(object sender, EventArgs e)
    {
        string url = "ContactCenter_Contact_Edit.aspx?&Con_id=" + lblConId.Text;
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.open('");
        sb.Append(url);
        sb.Append("');");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(),
                "script", sb.ToString());

    }

    protected void btnrefersh_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("ContactCenter_Convert_Contact_To_Lead.aspx?&Con_id=" + lblConId.Text);       
    }

    protected void btnRefreshCon_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Convert_Contact_To_Lead.aspx?&Con_id=" + lblConId.Text);       
    }
    

    private void Currentyear()
    {
        DataSet ds = ProductController.GetAllCurrentyear();
        BindDDL(ddlacademicyear, ds, "Description", "ID");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
    }
}