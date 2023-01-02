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
using Microsoft.VisualBasic;

public partial class Lead_Edit : System.Web.UI.Page
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
                lblpagetitle1.Text = "Edit Lead";
                lblpagetitle2.Text = "";
                limidbreadcrumb.Visible = false;
                lblmidbreadcrumb.Text = "Manage Lead";
                lilastbreadcrumb.Visible = false;
                lbllastbreadcrumb.Text = " Edit Lead";
                lilastbreadcrumb.Visible = false;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                //lbldateerror.Visible = false;
                upnl1.Visible = true;
                UpnlSecContact.Visible = false;
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
                                btnaddlead.Visible = true;
                                //btnimportlead.Visible = True
                            }
                            else
                            {
                                btnaddlead.Visible = false;
                                //btnimportlead.Visible = False
                            }

                        }
                    }


                }
                catch (Exception ex)
                {
                }

                string UserCompany = "MT";
                txtExpjoindate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ContactSource();
                CurrentyearEducation();
                Leadtype();
                LeadSource();
                leadstatus();
                ContactType();
                StudentType2();
                Country2();
                Currentyear();
               
                BindSourceCompany();
                BindTargetCompany();
                Bindlist();

                GetAllDeviceType();
                GetAllProvider();
                GetAllOwnedby();
                GetAllPlatform();
                GetAllDevicebrand();
                GetAllAccessmode();
                GetAllStorageMediaType();
                GetAllInstallationType();
               // BindRobomatedetails();
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
        Response.Redirect("Lead_Edit.aspx?&Lead_Code=" + Request["Lead_Code"]);
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
                        txt1.Text = dr["Createdon"].ToString();
                        ddlleadtypeadd.SelectedValue = dr["Lead_Type_Code"].ToString();
                        ddlleadsourceadd.SelectedValue = dr["Lead_Source_Code"].ToString();
                        ddlleadstatusadd.SelectedValue = dr["Lead_Status_Code"].ToString();
                        try
                        {
                            if ((dr["year_education"].ToString() == "") || (dr["year_education"].ToString() == "0"))
                                ddlcurrentyeareducation.SelectedIndex = 0;
                            else
                                ddlcurrentyeareducation.SelectedValue = dr["year_education"].ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                        txtsourcedesc.Text = "";
                        lblConId.Text = dr["Con_Id"].ToString();
                        BindSecContactDetails(lblConId.Text);

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
                                           

                        ContactType();
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

                        //txtfirstname.Text = dr["Con_Firstname"].ToString();
                        //txtmidname.Text = dr["Con_midname"].ToString();
                        //txtlastname.Text = dr["Con_lastname"].ToString();
                        //lblstudentname.Text = dr["Con_Title"].ToString() + " " + dr["Con_FirstName"].ToString() + " " + dr["Con_midname"].ToString() + " " + dr["Con_lastname"].ToString();
                        //txthandphone1.Text = dr["handphone1"].ToString();
                        //txthandphone2.Text = dr["handphone2"].ToString();
                        //txtlandline.Text = dr["landline"].ToString();
                        //txtemailid.Text = dr["Emailid"].ToString();
                        //txtflatno.Text = dr["Flatno"].ToString();
                        //txtbuildingno.Text = dr["BuildingName"].ToString();
                        //txtstreetname.Text = dr["StreetName"].ToString();
                        //Country();
                        //ddlcountry.SelectedValue = dr["Country"].ToString();
                        //if (ddlcountry.SelectedValue == "Select")
                        //{
                        //    ddlstate.SelectedIndex = 0;
                        //    ddlcity.SelectedIndex = 0;
                        //}
                        //else
                        //{
                        //    State();
                        //    ddlstate.SelectedValue = dr["State"].ToString();
                        //    if (ddlstate.SelectedValue == "Select")
                        //    {
                        //        ddlcity.SelectedIndex = 0;
                        //    }
                        //    else
                        //    {
                        //        City();
                        //        ddlcity.SelectedValue = dr["City"].ToString();
                        //        if (ddlcity.SelectedValue == "Select")
                        //        {
                        //            ddllocation.SelectedIndex = 0;
                        //        }
                        //        else
                        //        {
                        //            if (dr["location_id"].ToString() == "Select")
                        //            {
                        //                ddllocation.SelectedIndex = 0;
                        //            }
                        //            else
                        //            {
                        //                BindLocation();
                        //                ddllocation.SelectedValue = dr["location_id"].ToString();
                        //            }
                        //        }
                        //    }


                        //}





                        //txtpincode.Text = dr["Pincode"].ToString();
                        txtproductInterested.Text = dr["Prod_Interest"].ToString();
                        txtExpjoindate.Text = dr["Time_join"].ToString();
                        Institutetype();
                        //ddlinstitutiontype.SelectedValue = dr["Institution_Type_Id"].ToString();
                        //txtnameofinstitution.Text = dr["Institution_Description"].ToString();
                       // CurrentStudyingIn();
                        //ddlcurrentstudying.SelectedValue = dr["Current_Standard_id"].ToString();
                        //txtadditiondesc.Text = dr["Additional_desc"].ToString();
                        Board();
                        //ddlboard.SelectedValue = dr["Board_id"].ToString();
                        DivisionSession();
                        //ddlsection.SelectedValue = dr["Section_id"].ToString();
                        Yearofpassing();
                        //ddlyearofpassing.SelectedValue = dr["Year_of_Passing_Id"].ToString();
                        lblprimarycontactid.Text = dr["Lead_Contact_Code"].ToString();
                       // BindScore();
                        //Currentyear();
                        ddlacademicyear.SelectedValue = dr["Expected_Join_AcadYear"].ToString();
                        //StudentType();
                        //ddlstudenttypeadd.SelectedValue = dr["Category_Type_id"].ToString();

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
                            ////For Science Division
                            //txtscore.Text = dr["Score"].ToString();
                            //txtpercentage.Text = dr["Percentile"].ToString();
                            //txtarearank.Text = dr["Area_Rank"].ToString();
                            //txtoverallrank.Text = dr["Overall_Rank"].ToString();
                            //Scorerange();
                            //ddlscorerange.SelectedValue = dr["Score_Range_Type"].ToString();
                            //Discipline();
                            if (dr["Discipline_Id"].ToString() == "0")
                            {
                                //ddldiscipline.SelectedIndex = 0;
                            }
                            else
                            {
                               // ddldiscipline.SelectedValue = dr["Discipline_Id"].ToString();
                                //FieldInterested();
                                if (dr["Field_ID"].ToString() == "0")
                                {
                                   // ddlfieldint.SelectedIndex = 0;
                                }
                                else
                                {
                                   // ddlfieldint.SelectedValue = dr["Field_ID"].ToString();
                                }

                            }
                            //txtcompetitiveexams.Text = dr["Competitive_Exam"].ToString();
                            //txtmsmarks.Text = dr["total_ms_marks"].ToString();
                            //txtmsobtained.Text = dr["total_ms_marks_obt"].ToString();
                        }

                        txtassignedto.Text = dr["Contact_Assignto"].ToString();
                        txtsourcedesc.Text = dr["Source_desc"].ToString();
                        //txtdateofbirth.Text = dr["dob"].ToString();
                        txtexaminationdetails.Text = dr["Last_Exam_Passed"].ToString();
                        lblContactid.Text = dr["Lead_Contact_Code"].ToString();
                        //ContactType1()
                        //ddlseccontacttype.SelectedValue = dr("Sec_Con_type_id").ToString
                        //If ddlseccontacttype.SelectedValue = "Select" Then
                        //    ddlseccontacttype.SelectedIndex = 0
                        //Else
                        //    ddlseccontacttype.SelectedValue = dr("Sec_Con_type_id").ToString
                        //End If

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
                        //If ddlseccountry.SelectedValue = "Select" Then
                        //    ddlsecstate.SelectedIndex = "0"
                        //    ddlseccity.SelectedIndex = "0"
                        //Else
                        //    BindSecState()
                        //    ddlsecstate.SelectedValue = dr("Sec_State").ToString
                        //    If ddlsecstate.SelectedValue = "Select" Then
                        //        ddlseccity.SelectedIndex = "0"
                        //    Else
                        //        BindSecCity()
                        //        ddlseccity.SelectedValue = dr("Sec_City").ToString
                        //    End If
                        //End If

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
    private void BindSecContact()
    {
        if (Request["Lead_Code"] != null)
        {
            string Lead_Code = Request["Lead_Code"];

            DataSet ds = ProductController.Get_SecondaryContactbyLeadid(Lead_Code);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlseccontact.DataSource = ds;
                dlseccontact.DataBind();
                divseccontact.Visible = false;
            }
            else
            {
                divseccontact.Visible = true;
                lblseccontact.Text = "No Secondary Contact Found!";
            }
        }
    }

    protected void dlseccontact_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            UpnlSecContact.Visible = true;
            upnl1.Visible = false;
            lblprimaryconid.Text = e.CommandArgument.ToString();
            string Conid = lblprimaryconid.Text;
            BindSecContactDetails(Conid);
        }
    }

    protected void dlseccontact_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
            scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkedit"));
        }
    }



    protected void btnrefersh_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead_Edit.aspx?&Lead_Code=" + Request["Lead_Code"]);
    }

    private void BindSecContactDetails(string Conid)
    {
        string Con_id = Conid;

        lblPKey_Con_Id.Text = Con_id;
        HtmlAnchor editContact = aedit;
        editContact.Visible = true;
        editContact.HRef = "Contact_Edit.aspx?&Con_id=" + Con_id;

        ContactInfoPanel1.BindSecContactDetails(Con_id);
        //BindContactHistory
        //HistoryPanel1.BindContactHistory(Con_id);

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

            //binddlfeedback();
        }
    }

    private void BindLocation()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
        BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }   
    
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

    //private void BindSecContactDetails(string Conid)
    //{

    //    try
    //    {

    //        if (Request["Lead_Code"] != null)
    //        {
    //            string Con_id = Conid;
    //            SqlDataReader dr = ProductController.Get_SecondaryContactbyLeadidforfield1(Con_id);
    //            if ((((dr) != null)))
    //            {
    //                if (dr.Read())
    //                {
    //                    //ContactType2();
    //                    if (ddlseccontacttype2.SelectedValue == "Select")
    //                    {
    //                        ddlseccontacttype2.SelectedIndex = 0;
    //                    }
    //                    else
    //                    {
    //                        ddlseccontacttype2.SelectedValue = dr["Con_type_id"].ToString();
    //                    }

    //                    if (dr["Con_title"].ToString() == "Mr.")
    //                    {
    //                        ddlsectitle2.SelectedValue = "1";
    //                    }
    //                    else if (dr["Con_title"].ToString() == "Ms.")
    //                    {
    //                        ddlsectitle2.SelectedValue = "2";
    //                    }
    //                    else
    //                    {
    //                        ddlsectitle2.SelectedIndex = 0;
    //                    }

    //                    if (dr["gender"].ToString() == "Male")
    //                    {
    //                        this.ddlsecgender.SelectedValue = "1";
    //                    }
    //                    else if (dr["gender"].ToString() == "Female")
    //                    {
    //                        this.ddlsecgender.SelectedValue = "2";
    //                    }
    //                    else
    //                    {
    //                        this.ddlsecgender.SelectedValue = "0";
    //                    }

    //                    txtsecfname2.Text = dr["Con_Firstname"].ToString();
    //                    txtsecmname2.Text = dr["Con_midname"].ToString();
    //                    txtseclname2.Text = dr["Con_lastname"].ToString();
    //                    txtsechandphone12.Text = dr["handphone1"].ToString();
    //                    txtsechandphone22.Text = dr["handphone2"].ToString();
    //                    txtseclandline2.Text = dr["landline"].ToString();
    //                    txtsecemailid2.Text = dr["Emailid"].ToString();
    //                    txtsecaddress12.Text = dr["Flatno"].ToString();
    //                    txtsecaddress22.Text = dr["BuildingName"].ToString();
    //                    txtsecStreetname2.Text = dr["StreetName"].ToString();
    //                    txtsecpincode2.Text = dr["Pincode"].ToString();

    //                    Institutetype();
    //                    if (dr["Institution_Type_Id"].ToString() == "Select")
    //                    {
    //                        ddlinstitutiontype2.SelectedIndex = 0;
    //                    }
    //                    else
    //                    {
    //                        ddlinstitutiontype2.SelectedValue = dr["Institution_Type_Id"].ToString();
    //                    }

    //                    txtnameofinstitution2.Text = dr["Institution_Description"].ToString();
    //                    CurrentStudyingIn1();
    //                    if (dr["Current_Standard_id"].ToString() == "Select")
    //                    {
    //                        ddlcurrentstudying2.SelectedIndex = 0;
    //                    }
    //                    else
    //                    {
    //                        ddlcurrentstudying2.SelectedValue = dr["Current_Standard_id"].ToString();
    //                    }

    //                    txtadditiondesc2.Text = dr["Additional_desc"].ToString();
    //                    Board();
    //                    if (dr["Board_id"].ToString() == "Select")
    //                    {
    //                        ddlboard2.SelectedIndex = 0;
    //                    }
    //                    else
    //                    {
    //                        ddlboard2.SelectedValue = dr["Board_id"].ToString();
    //                    }

    //                    DivisionSession();
    //                    if (dr["Section_id"].ToString() == "Select")
    //                    {
    //                        ddlsection2.SelectedIndex = 0;
    //                    }
    //                    else
    //                    {
    //                        ddlsection2.SelectedValue = dr["Section_id"].ToString();
    //                    }

    //                    Yearofpassing();
    //                    if (dr["Year_of_Passing_Id"].ToString() == "Select")
    //                    {
    //                        ddlyearofpassing2.SelectedIndex = 0;
    //                    }
    //                    else
    //                    {
    //                        ddlyearofpassing2.SelectedValue = dr["Year_of_Passing_Id"].ToString();
    //                    }
    //                    txtsecdob.Text = dr["dob"].ToString();
    //                    //txtexaminationdetails.Text = dr("exam_details").ToString

    //                    ddlseccountry2.SelectedValue = dr["Country"].ToString();
    //                    if (ddlseccountry2.SelectedValue == "Select")
    //                    {
    //                        ddlsecstate2.SelectedIndex = 0;
    //                        ddlseccity2.SelectedIndex = 0;
    //                    }
    //                    else
    //                    {
    //                        BindSecState();
    //                        ddlsecstate2.SelectedValue = dr["State"].ToString();
    //                        if (ddlsecstate2.SelectedValue == "Select")
    //                        {
    //                            ddlseccity2.SelectedIndex = 0;
    //                        }
    //                        else
    //                        {
    //                            BindSecCity();
    //                            ddlseccity2.SelectedValue = dr["City"].ToString();
    //                            if (ddlseccity2.SelectedValue == "Select")
    //                            {
    //                                ddlSeclocationedit.SelectedIndex = 0;

    //                            }
    //                            else
    //                            {
    //                                if (dr["Location_id"].ToString() == "Select")
    //                                {
    //                                    ddlSeclocationedit.SelectedIndex = 0;
    //                                }
    //                                else
    //                                {
    //                                    BindSeclocationadd();
    //                                    ddlSeclocationedit.SelectedValue = dr["Location_id"].ToString();
    //                                }

    //                            }
    //                        }
    //                    }

    //                }
    //            }
    //        }
    //        divErrormessage.Visible = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        divErrormessage.Visible = true;
    //        lblerrormessage.Visible = true;
    //        lblerrormessage.Text = ex.Message;
    //    }
    //}



    protected void btneditsubmit_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            //if (string.IsNullOrEmpty(txtdateofbirth.Text))
            //{
            //}
            //else
            //{
            //    if (Convert.ToDateTime(ClsCommon.FormatDate(txtdateofbirth.Text)) > DateTime.Today)
            //    {
            //        lbldateerrordob.Visible = true;
            //        lbldateerrordob.Text = "DOB cannot be a future date";
            //        txtdateofbirth.Focus();
            //        //lbldateerrorsubmit.Visible = False
            //        return;
            //    }
            //    else
            //    {
            //        //lbldateerrorsubmit.Visible = False
            //        lbldateerrordob.Visible = false;
            //    }
            //}
        }
        catch (Exception ex)
        {
            //lbldateerrordob.Visible = true;
            //lbldateerrordob.Text = ex.Message;
            //txtdateofbirth.Focus();
            return;
        }


        try
        {

            string Leadtype = "";
            string LeadSource = "";
            string leadsourcedesc = "";
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
            string TargetCompany = "";
            string Sourcedivision = "";
            string SourceZone = "";
            string SourceCenter = "";
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

            Leadtype = ddlleadtypeadd.SelectedValue;
            LeadSource = ddlleadsourceadd.SelectedValue;
            leadsourcedesc = ddlleadsourceadd.SelectedItem.Text;
            LeadStatus = ddlleadstatusadd.SelectedValue;
            LeadStatusdesc = ddlleadstatusadd.SelectedItem.Text;
            Campaignid = ddlcampaignid.SelectedValue;
            SourceDesc = txtsourcedesc.Text;
            //ContactTYpe = ddlcontacttype1.SelectedValue;
            //Contact_Type_Desc = ddlcontacttype1.SelectedItem.Text;
            //Gender = ddlgenderadd.SelectedItem.Text;
            //Title = ddltitle.SelectedItem.Text;
            //Fname = txtfirstname.Text;
            //Mname = txtmidname.Text;
            //Lname = txtlastname.Text;
            //CategoryType = ddlstudenttypeadd.SelectedItem.Text;
            //Category_Type_Id = ddlstudenttypeadd.SelectedValue;

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
                //if (string.IsNullOrEmpty(txtscore.Text))
                //{
                //    Score = 0;
                //}
                //else
                //{
                //    Score =Convert.ToDecimal(txtscore.Text);
                //}

                //if (string.IsNullOrEmpty(txtpercentage.Text))
                //{
                //    Percentile = 0;
                //}
                //else
                //{
                //    Percentile =Convert.ToDecimal(txtpercentage.Text);
                //}
                //if (string.IsNullOrEmpty(txtarearank.Text))
                //{
                //    AreaRank = 0;
                //}
                //else
                //{
                //    AreaRank =Convert.ToInt32(txtarearank.Text);
                //}
                //if (string.IsNullOrEmpty(txtoverallrank.Text))
                //{
                //    Overallrank = 0;
                //}
                //else
                //{
                //    Overallrank =Convert.ToInt32(txtoverallrank.Text);
                //}
                //Scorerangetype = ddlscorerange.SelectedValue;
                //if (ddldiscipline.SelectedItem.Text == "Select")
                //{
                //    Interested_Discipline_Id = 0;
                //    Interested_Discipline_Desc = "Select";
                //}
                //else
                //{
                //    Interested_Discipline_Id =Convert.ToInt32(ddldiscipline.SelectedValue);
                //    Interested_Discipline_Desc = ddldiscipline.SelectedItem.Text;
                //}
                //if (ddlfieldint.SelectedItem.Text == "Select")
                //{
                //    Interested_Field_Id = 0;
                //    Interested_Field_Desc = "Select";
                //}
                //else
                //{
                //    Interested_Field_Id =Convert.ToInt32(ddlfieldint.SelectedValue);
                //    Interested_Field_Desc = ddlfieldint.SelectedItem.Text;
                //}
                //CompetitiveExam = txtcompetitiveexams.Text;
                //if (string.IsNullOrEmpty(txtmsmarks.Text))
                //{
                //    MSmarkstotal = 0;
                //}
                //else
                //{
                //    MSmarkstotal =Convert.ToInt32(txtmsmarks.Text);
                //}

                //if (string.IsNullOrEmpty(txtmsobtained.Text))
                //{
                //    MSMarksobtained = 0;
                //}
                //else
                //{
                //    MSMarksobtained =Convert.ToInt32(txtmsobtained.Text);
                //}
            }

            ////Code done on 08-Jan-2014
            if (string.IsNullOrEmpty(txtExpjoindate.Text))
            {
                txtExpjoindate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ExpectedJoindate = Convert.ToDateTime(txtExpjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            else
            {
                ExpectedJoindate = Convert.ToDateTime(txtExpjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }

            Productinterested = txtproductInterested.Text;
            ////ExpectedJoindate = Convert.ToDateTime(txtExpjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat)
            ////ExpectedJoindate = Request.Form("expclosedate")
            //Institutiontypeid = ddlinstitutiontype.SelectedValue;
            //InstituionTypedesc = ddlinstitutiontype.SelectedItem.Text;
            //InstitutionName = txtnameofinstitution.Text;
            //CurrentStandardid = ddlcurrentstudying.SelectedValue;
            //CurrentStandarddesc = ddlcurrentstudying.SelectedItem.Text;
            //AdditionalDesc = txtadditiondesc.Text;
            //BoardUniversityid = ddlboard.SelectedValue;
            //BoardUniversitydesc = ddlboard.SelectedItem.Text;
            //DivisionSectionGradeid = ddlsection.SelectedValue;
            //DivisionSectionGradedesc = ddlsection.SelectedItem.Text;
            //Yearofpassingid = ddlyearofpassing.SelectedValue;
            //Yearofpassingdesc = ddlyearofpassing.SelectedItem.Text;
            Currentyearofeducationid = ddlacademicyear.SelectedValue;
            Currentyearofeducationdesc = ddlacademicyear.SelectedItem.Text;




            if (ddlcustomertype.SelectedValue == "01")
            {
                SourceCompany = ddlsourcecompanyadd.SelectedValue;
                Sourcedivision = ddlSourcedivisionadd.SelectedValue;
                SourceZone = ddlSourcezoneadd.SelectedValue;
                SourceCenter = ddlSourcecenteradd.SelectedValue;
                TargetCompany = ddltargetcompanyadd.SelectedValue;
                Targetdivision = ddltargetdivisionadd.SelectedValue;
                TargetZone = ddltargetzoneadd.SelectedValue;
                TargetCenter = ddltargetcenteradd.SelectedValue;
                //Studentid = txtstudentid.Text;
                //LastcourseOpted = txtlastcourseopted.Text;
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
                Sourcedivision = ddlSourcedivisionadd.SelectedValue;
                SourceZone = ddlSourcezoneadd.SelectedValue;
                SourceCenter = ddlSourcecenteradd.SelectedValue;
                TargetCompany = ddltargetcompanyadd.SelectedValue;
                Targetdivision = ddltargetdivisionadd.SelectedValue;
                TargetZone = ddltargetzoneadd.SelectedValue;
                TargetCenter = ddltargetcenteradd.SelectedValue;
                //Studentid = txtstudentid.Text;
                //LastcourseOpted = txtlastcourseopted.Text;
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
                Studentid = "";
                LastcourseOpted = "";

            }


            //Role = ddlrole.SelectedValue
            Assignedto = UserID;

            //handphone1 = txthandphone1.Text;
            //handphone2 = txthandphone2.Text;
            //landline = txtlandline.Text;
            //emailid = txtemailid.Text;
            //flatno = txtflatno.Text;
            //buildingname = txtbuildingno.Text;
            //Streetname = txtstreetname.Text;
            //Countryname = ddlcountry.SelectedValue;
            //State = ddlstate.SelectedValue;
            //City = ddlcity.SelectedValue;
            //Pincode = txtpincode.Text;

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

            //SecContactType = ddlseccontacttype.SelectedValue
            //SecTitle = ddlsectitle.SelectedItem.Text
            //SecFname = txtsecfname.Text
            //SecMname = txtsecmname.Text
            //SecLname = txtseclname.Text
            //Sechphone1 = txtsechandphone1.Text
            //Sechphone2 = txtsechandphone2.Text
            //Seclandline = txtseclandline.Text
            //Secemail = txtsecemailid.Text
            //SecAdd1 = txtsecaddress1.Text
            //Secadd2 = txtsecaddress2.Text
            //SecStreetname = txtsecStreetname.Text
            //SecCountryname = ddlseccountry.SelectedValue
            //SecStatename = ddlsecstate.SelectedValue
            //SecCityname = ddlseccity.SelectedValue
            //SecpostalCode = txtsecpincode.Text

            string Seccondesc = "";
            //Seccondesc = ddlseccontacttype.SelectedItem.Text
            string Dob = "";
            string leadsourceAdditionaldesc = "";
            string Examination = "";

            //Dob = txtdateofbirth.Text;
            leadsourceAdditionaldesc = txtsourcedesc.Text;
            //Examination = txtexaminationdetails.Text;

            string Location = "";
            //Location = ddllocation.SelectedValue;
            if (Request["Lead_Code"] != null)
            {
                string leadid = Request["Lead_Code"];
                
                DataSet ds=ProductController.UpdateManualLeadContact_New(Title, Fname, Mname, Lname, Score, Percentile, AreaRank, Overallrank, Scorerangetype, handphone1,
                handphone2, landline, emailid, flatno, buildingname, Streetname, Countryname, State, City, Pincode,
                leadid, lblContactid.Text, SourceCompany, Sourcedivision, SourceCenter, SourceZone, Assignedto, UserID, TargetCompany, Targetdivision,
                TargetZone, TargetCenter, Interested_Discipline_Id, Interested_Discipline_Desc, Interested_Field_Id, Interested_Field_Desc, CompetitiveExam, Category_Type_Id, CategoryType, Institutiontypeid,
                InstituionTypedesc, InstitutionName, CurrentStandardid, CurrentStandarddesc, AdditionalDesc, BoardUniversityid, BoardUniversitydesc, DivisionSectionGradeid, DivisionSectionGradedesc, Yearofpassingid,
                Yearofpassingdesc, Currentyearofeducationid, Currentyearofeducationdesc, Studentid, LastcourseOpted, SecContactType, SecTitle, SecFname, SecMname, SecLname,
                Sechphone1, Sechphone2, Seclandline, Secemail, SecAdd1, Secadd2, SecStreetname, SecCountryname, SecStatename, SecCityname,
                SecpostalCode, Seccondesc, MSmarkstotal, MSMarksobtained, leadsourceAdditionaldesc, Dob, Examination, Location,Currentyearofeducationid,Productinterested,"101");


                if (ds.Tables[0].Rows[0]["Result"].ToString() == "-1")//if the record already Exist
                {
                    divSuccessmessage.Visible = false;
                    divErrormessage.Visible = true;
                    lblerrormessage.Text = ds.Tables[0].Rows[0]["Error"].ToString();
                    return;
                }       

               // InsertScore();

                if (chkmaindevicedetails.Checked == true)
                {
                    string Conid = lblContactid.Text;
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

                    //string Robomate_Details_Id = Robomate_Integration_Lead.Insert_Robomate_Dtls("", TargetCompany, Targetdivision,
                    //    TargetCenter, Leadtype, Conid, User_Device_id,
                    //    Provided_By_id, Owned_By_Id, platform_id, Device_Brand_Id,
                    //    Device_Brand_Addl_Text, Device_Model, Device_Config, Access_Mode_Id,
                    //    Storage_Media_type_Id, Capacity, HDD_Free_Space, No_of_Storage_Media,
                    //    Special_Instruction_1, Special_Instruction_2, Special_Instruction_3, "", UserID, "", UserID,
                    //    Installation_Location, Appointment_Date, Appointment_Time,
                    //    Installation_Date, Installation_Time, Installation_Status_Id,
                    //    Rescheduled_Date, Rescheduled_Time, Engineer_Name, Contact_Number,
                    //    Email_Id, Engineer_Company
                    //    );
                }
            }

            divSuccessmessage.Visible = true;
            lblsuccessMessage.Text = "Lead Successfully Updated";
            Bindlist();
           // BindSecContact();
            divErrormessage.Visible = false;


            //ContactInfoPanel1.BindSecContactDetails(lblPKey_Con_Id.Text);
            ////BindContactHistory
            //HistoryPanel1.BindContactHistory(lblPKey_Con_Id.Text);
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
    //private void CurrentStudyingIn()
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
    //    BindDDL(ddlcurrentstudying, ds, "Description", "ID");
    //    this.ddlcurrentstudying.Items.Insert(0, "Select");
    //    this.ddlcurrentstudying.SelectedIndex = 0;
    //    //Me.ddlinstitutiontype.Focus()
    //}
    private void CurrentStudyingIn1()
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype2.SelectedValue);
        BindDDL(ddlcurrentstudying2, ds, "Description", "ID");
        this.ddlcurrentstudying2.Items.Insert(0, "Select");
        this.ddlcurrentstudying2.SelectedIndex = 0;
    }
    //private void Discipline()
    //{
    //    DataSet ds = ProductController.GetallDiscipline();
    //    BindDDL(ddldiscipline, ds, "Discipline_Desc", "Discipline_Id");
    //    ddldiscipline.Items.Insert(0, "Select");
    //    ddldiscipline.SelectedIndex = 0;
    //}
    //private void Discipline1()
    //{
    //    DataSet ds = ProductController.GetallDiscipline();
    //    BindDDL(ddldiscipline, ds, "Discipline_Desc", "Discipline_Id");
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
    //    if (ddldiscipline.SelectedIndex == 0)
    //    {
    //        ddlfieldint.SelectedIndex = 0;
    //    }
    //    else
    //    {
    //        FieldInterested();
    //    }
    //}
    
    //private void FieldInterested()
    //{
    //    DataSet ds = ProductController.GetAllFieldInterestedByDisciplineid(Convert.ToInt32 ( ddldiscipline.SelectedValue));
    //    BindDDL(ddlfieldint, ds, "IField_Desc", "C24_Ifieldid");
    //    ddlfieldint.Items.Insert(0, "Select");
    //    ddlfieldint.SelectedIndex = 0;
    //}

    private void Institutetype()
    {
        DataSet ds = ProductController.GetallInstituteType();
        //BindDDL(ddlinstitutiontype, ds, "Description", "ID");
        //ddlinstitutiontype.Items.Insert(0, "Select");
        //ddlinstitutiontype.SelectedIndex = 0;

        BindDDL(ddlinstitutiontype2, ds, "Description", "ID");
        ddlinstitutiontype2.Items.Insert(0, "Select");
        ddlinstitutiontype2.SelectedIndex = 0;
    }
    //protected void ddlinstitutiontype_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
    //    BindDDL(ddlcurrentstudying, ds, "Description", "ID");
    //    this.ddlcurrentstudying.Items.Insert(0, "Select");
    //    this.ddlcurrentstudying.SelectedIndex = 0;
    //    Bindboardbyid();
    //    //Me.ddlinstitutiontype.Focus()
    //}
    //private void Bindboardbyid()
    //{
    //    DataSet ds = ProductController.GetallBoardbyinstitutetype(ddlinstitutiontype.SelectedValue);
    //    BindDDL(ddlboard, ds, "Short_Description", "ID");
    //    ddlboard.Items.Insert(0, "Select");
    //    ddlboard.SelectedIndex = 0;
    //    //BindDDL(ddlboard2, ds, "Short_Description", "ID")
    //    //ddlboard2.Items.Insert(0, "Select")
    //    //ddlboard2.SelectedIndex = 0
    //}

    private void Board()
    {
        DataSet ds = ProductController.GetallBoard();
        //BindDDL(ddlboard, ds, "Short_Description", "ID");
        //ddlboard.Items.Insert(0, "Select");
        //ddlboard.SelectedIndex = 0;

        BindDDL(ddlboard2, ds, "Short_Description", "ID");
        ddlboard2.Items.Insert(0, "Select");
        ddlboard2.SelectedIndex = 0;
    }

    private void Yearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        //BindDDL(ddlyearofpassing, ds, "Description", "ID");
        //ddlyearofpassing.Items.Insert(0, "Select");
        //ddlyearofpassing.SelectedIndex = 0;

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
    private void DivisionSession()
    {
        DataSet ds = ProductController.GetAllDivisionSection();
       // BindDDL(ddlsection, ds, "Description", "ID");
        BindDDL(ddlsection2, ds, "Description", "ID");
        ddlsection2.Items.Insert(0, "Select");
        ddlsection2.SelectedIndex = 0;
    }


    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactTypeinrelation();
        BindDDL(ddlContactType, ds, "Description", "ID");
    }
    protected void ddlcontacttype1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //DataSet ds = ProductController.GetAllSContactTypebyPContactType(ddlcontacttype1.SelectedValue);
        //BindDDL(ddlseccontacttype, ds, "Description", "ID");
        //ddlseccontacttype.Items.Insert(0, "Select");
        //ddlseccontacttype.SelectedIndex = 0;
        //ddlcontacttype1.Focus()
    }
    private void ContactType1()
    {
        //DataSet ds = ProductController.GetAllSContactTypebyPContactType(ddlcontacttype1.SelectedValue);
        //BindDDL(ddlseccontacttype, ds, "Description", "ID");
        //ddlseccontacttype.Items.Insert(0, "Select");
        //ddlseccontacttype.SelectedIndex = 0;
    }

    //private void ContactType2()
    //{
    //    DataSet ds = ProductController.GetAllSContactTypebyPContactType(ddlcontacttype1.SelectedValue);
    //    BindDDL(ddlseccontacttype2, ds, "Description", "ID");
    //    //ddlseccontacttype2.Items.Insert(0, "Select")
    //    //ddlseccontacttype2.SelectedIndex = 0
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

    //    BindDDL(ddlseccountry2, ds, "Country_Name", "Country_Code");
    //    ddlseccountry2.Items.Insert(0, "Select");
    //    ddlseccountry2.SelectedIndex = 0;
    //    ddlsecstate2.Items.Insert(0, "Select");
    //    ddlsecstate2.SelectedIndex = 0;
    //    ddlseccity2.Items.Insert(0, "Select");
    //    ddlseccity2.SelectedIndex = 0;
    //    ddlSeclocationedit.Items.Insert(0, "Select");
    //    ddlSeclocationedit.SelectedIndex = 0;
    //}

    protected void ddlcountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // State();
        //ddlstate.Focus()
    }
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
    //    //ddlcity.Focus()
    //}

    //private void City()
    //{
    //    DataSet ds = ProductController.GetallCitybyState(ddlstate.SelectedValue);
    //    BindDDL(ddlcity, ds, "City_Name", "City_Code");
    //    ddlcity.Items.Insert(0, "Select");
    //    ddlcity.SelectedIndex = 0;
    //}
    protected void ddlcity_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindLocation();
    }
    //private void BindLocation()
    //{
    //    DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
    //    BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
    //    ddllocation.Items.Insert(0, "Select");
    //    ddllocation.SelectedIndex = 0;
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
    protected void ddlseccountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSecState();
        //ddlseccountry2.Focus()
    }
    private void BindSecState()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlseccountry2.SelectedValue);
        BindDDL(ddlsecstate2, ds, "State_Name", "State_Code");
        ddlsecstate2.Items.Insert(0, "Select");
        ddlsecstate2.SelectedIndex = 0;
        ddlseccity2.SelectedIndex = 0;
    }
    protected void ddlSecstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSecCity();
        //ddlsecstate2.Focus()
        ddlseccity2.SelectedIndex = 0;
    }
    private void BindSecCity()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlsecstate2.SelectedValue);
        BindDDL(ddlseccity2, ds, "City_Name", "City_Code");
        ddlseccity2.Items.Insert(0, "Select");
        ddlseccity2.SelectedIndex = 0;
    }
    protected void ddlseccity2_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindSeclocationadd();
    }
    private void BindSeclocationadd()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlseccity2.SelectedValue);
        BindDDL(ddlSeclocationedit, ds, "Location_Name", "Location_Code");
        ddlSeclocationedit.Items.Insert(0, "Select");
        ddlSeclocationedit.SelectedIndex = 0;

    }
    protected void btnaddlead_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead_Add.aspx");
    }

    protected void btnclear_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead.aspx");
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
                    Label13.Visible = true;
                    Label13.Text = "DOB cannot be a future date";
                    txtsecdob.Focus();
                    //lbldateerrorsubmit.Visible = False
                    return;
                }
                else
                {
                    //lbldateerrorsubmit.Visible = False
                    Label13.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Label13.Visible = true;
            Label13.Text = ex.Message;
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

            string Conid = "";
            Conid = lblprimaryconid.Text;

            SecContactTypeid = ddlseccontacttype2.SelectedValue;
            Seccondesc = ddlseccontacttype2.SelectedItem.Text;
            SecTitle = ddlsectitle2.SelectedItem.Text;
            SecFname = txtsecfname2.Text;
            SecMname = txtsecmname2.Text;
            SecLname = txtseclname2.Text;
            Sechphone1 = txtsechandphone12.Text;
            Sechphone2 = txtsechandphone22.Text;
            Seclandline = txtseclandline2.Text;
            Secemail = txtsecemailid2.Text;
            SecAdd1 = txtsecaddress12.Text;
            Secadd2 = txtsecaddress22.Text;
            SecStreetname = txtsecStreetname2.Text;
            SecCountryname = ddlseccountry2.SelectedValue;
            SecStatename = ddlsecstate2.SelectedValue;
            SecCityname = ddlseccity2.SelectedValue;
            SecpostalCode = txtsecpincode2.Text;


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
            Location = ddlSeclocationedit.SelectedValue;
            string Secgender1 = "";
            Secgender1 = ddlsecgender.SelectedItem.Text;
            string SecDob = "";
            SecDob = txtsecdob.Text;
            string Con_Id = ProductController.InsertSecondaryLeadContact("", Conid, Institutiontypeid, InstituionTypedesc, InstitutionName, CurrentStandardid, CurrentStandarddesc, AdditionalDesc, BoardUniversityid, BoardUniversitydesc,
            DivisionSectionGradeid, DivisionSectionGradedesc, Yearofpassingid, Yearofpassingdesc, Currentyearofeducationid, Currentyearofeducationdesc, SecContactTypeid, Seccondesc, SecTitle, SecFname,
            SecMname, SecLname, Sechphone1, Sechphone2, Seclandline, Secemail, SecAdd1, Secadd2, SecStreetname, SecCountryname,
            SecStatename, SecCityname, SecpostalCode, Location, Secgender1, SecDob);
            string Opportunity_Code = Request["Lead_Code"];
            Response.Redirect("Lead_Edit.aspx?&Lead_Code=" + Opportunity_Code);
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
        string Opportunity_Code = Request["Lead_Code"];
        Response.Redirect("Lead_Edit.aspx?&Lead_Code=" + Opportunity_Code);
    }

    protected void btnaddcontact_ServerClick(object sender, System.EventArgs e)
    {
        string Opportunity_Code = Request["Lead_Code"];
        Response.Redirect("Contact_Add.aspx?&Lead_Code=" + Opportunity_Code);
    }

    protected void btnsearchlead_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead.aspx");
    }

    //private void InsertScore()
    //{
    //    string Conid = lblprimarycontactid.Text;
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string User_id = cookie.Values["UserID"];
    //    object obj = null;
    //    Label lblscoredesc = default(Label);
    //    Label lblscoreid = default(Label);
    //    TextBox txtscore = default(TextBox);

    //    foreach (DataListItem li in dlScore.Items)
    //    {
    //        obj = li.FindControl("lblscoretypedesc");
    //        if (obj != null)
    //        {
    //            lblscoredesc = (Label)obj;
    //        }

    //        obj = li.FindControl("lblscoreid");
    //        if (obj != null)
    //        {
    //            lblscoreid = (Label)obj;
    //        }

    //        obj = li.FindControl("txtscore");
    //        if (obj != null)
    //        {
    //            txtscore = (TextBox)obj;
    //        }

    //        if (string.IsNullOrEmpty(txtscore.Text))
    //        {
    //        }
    //        else
    //        {
    //            ProductController.InsertScore(3, Conid, "", txtscore.Text, User_id, Convert.ToInt32 ( lblscoreid.Text));
    //        }

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
            RequiredFieldValidator31.Enabled = true;
        }
        else
        {
            txtotherbrand.Enabled = false;
            RequiredFieldValidator31.Enabled = false;
        }
    }

    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCity();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindState();
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


    private void CurrentyearEducation()
    {
        DataSet ds = ProductController.GetAllCurrentyearEducation();
        BindDDL(ddlcurrentyeareducation, ds, "Current_Year_Education", "Year_ID");
        ddlcurrentyeareducation.Items.Insert(0, "Select");
        ddlcurrentyeareducation.SelectedIndex = 0;
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
}