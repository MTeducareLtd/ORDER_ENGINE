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



public partial class Campaign_Followup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["RecNo"] != null)
            {
                //string Con_id = Request["Con_id"];
                lblRecNo.Text = Request["RecNo"].ToString();
            }
            lblbuttontext.Text = "Save";
            //lbltabname.Text = "Lead - Basic Information"
            //lblbreadcrumbs.Text = "Followup Action / Lead";
            lblpagetitle1.Text = "Followup Actions ";
            lblpagetitle2.Text = "";
            divErrormessage.Visible = false;
            divSuccessmessage.Visible = false;
            //diverrormessagefeedback.Visible = false;
            tblconvertOpp.Visible = false;
            divconvertoppbuttons.Visible = false;
            lbldateerrorfollow.Visible = false;
            lbldateerrorInteracted.Visible = false;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            txtuserid.Value = UserID;
            txtagentname.Value = UserName;
            txtagentid.Value = cookie.Values["Agent_Id"];
            lbluser_id.Text = UserID;
            txthandledby.Text = UserName;
            txthandledby.Enabled = false;
            txtdate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            //txtdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            string UserCompany = "";

           // BindDDLSeminarDetail();
            divclose.Visible = false;
            divfeedbackbuttons.Visible = true;
            Country2();
            ContactType();
            CampaignFollowupStatus();
            StudentType2();
           // binddlfeedback();
            Bindleadstatus();
            BindDDlInteractedwith();

            BindSecContactDetails(lblRecNo.Text);
            Bindlist();
        }


    }

    protected void btnrefersh_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Campaign_Followup.aspx?&RecNo=" + lblRecNo.Text);
    }


    private void BindSecContactDetails(string RecNo1)
    {
        string RecNo = RecNo1;
        DataSet ds = ProductController.Get_Campaign_ContactbyRecordNo(2, RecNo);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblPKey_Con_Id.Text = ds.Tables[0].Rows[0]["Con_Id"].ToString();
            txtconid.Value = lblPKey_Con_Id.Text;

            if (Request["Flag"] != null)  //because the Agent(Contact center) Edit page is different
            {
                //string Con_id = Request["Con_id"];
                if (Request["Flag"].ToString() == "100")
                {
                    HtmlAnchor editContact = aedit;
                    editContact.Visible = true;
                    editContact.HRef = "ContactCenter_Contact_Edit.aspx?&Con_id=" + lblPKey_Con_Id.Text;
                }
                else
                {
                    HtmlAnchor editContact = aedit;
                    editContact.Visible = true;
                    editContact.HRef = "Contact_Edit.aspx?&Con_id=" + lblPKey_Con_Id.Text;
                }
            }
            else
            {
                HtmlAnchor editContact = aedit;
                editContact.Visible = true;
                editContact.HRef = "Contact_Edit.aspx?&Con_id=" + lblPKey_Con_Id.Text;
            }

            //ContactInfoPanel1.BindSecContactDetails(Con_id);
            //HistoryPanel1.BindContactHistory(lblPKey_Con_Id.Text);

            DataList dlConHistory = (DataList)HistoryPanel1.FindControl("dlConHistory");
            DataList dlfeedbackhistory = (DataList)HistoryPanel1.FindControl("dlfeedbackhistory");
            DataList dlCallhistory = (DataList)HistoryPanel1.FindControl("dlCallhistory");

            if (ds.Tables[6].Rows.Count > 0)
            {

                dlConHistory.Visible = true;
                //lblCon_History.Visible = false;
                // diverrormessageContactHistory.Visible = false;
                HistoryPanel1.DivErrorMessageContactHistoryVisibility(false);

                dlConHistory.DataSource = ds.Tables[6];
                dlConHistory.DataBind();
            }
            else
            {
                dlConHistory.Visible = false;
                HistoryPanel1.DivErrorMessageContactHistoryVisibility(true);
            }

            if (ds.Tables[7].Rows.Count > 0)
            {
                dlfeedbackhistory.Visible = true;
                //diverrormessagefeedback.Visible = false;
                HistoryPanel1.DivErrorMessageFollowupHistoryVisibility(false);
                dlfeedbackhistory.DataSource = ds.Tables[7];
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


            lblCampaign_Id.Text = ds.Tables[0].Rows[0]["Campaign_Id"].ToString();
            txtcampaignid.Value = lblCampaign_Id.Text;
            txtcampaignname.Value = ds.Tables[0].Rows[0]["Campaign_Name"].ToString();
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

            txthandphone1.Text = ds.Tables[0].Rows[0]["handphone1"].ToString();
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
                ddlstate.Items.Insert(0, "Select");
                ddlcity.Items.Insert(0, "Select");
                ddlstate.SelectedIndex = 0;
                ddlcity.SelectedIndex = 0;

            }
            else
            {
                ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
                BindState();
                if ((ds.Tables[0].Rows[0]["State"].ToString() == "Select") || (ds.Tables[0].Rows[0]["State"].ToString() == ""))
                {
                    ddlstate.SelectedIndex = 0;
                    ddlcity.Items.Clear();
                    ddlcity.Items.Insert(0, "Select");
                    ddlcity.SelectedIndex = 0;
                }
                else
                {
                    ddlstate.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
                    BindCity();
                    if ((ds.Tables[0].Rows[0]["City"].ToString() == "Select") || (ds.Tables[0].Rows[0]["City"].ToString() == ""))
                    {
                        ddlcity.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlcity.SelectedValue = ds.Tables[0].Rows[0]["City"].ToString();
                    }
                }
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                dlSec_Con_Info.Visible = true;
                lblSecConRecord.Visible = false;
                dlSec_Con_Info.DataSource = ds.Tables[1];
                dlSec_Con_Info.DataBind();
            }
            else
            {
                dlSec_Con_Info.Visible = false;
                lblSecConRecord.Visible = true;
                lblSecConRecord.Text = "No records found..!";
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                dlAcadInfo.Visible = true;
                lblAcadInfoRecord.Visible = false;
                dlAcadInfo.DataSource = ds.Tables[2];
                dlAcadInfo.DataBind();
            }
            else
            {
                dlAcadInfo.Visible = false;
                lblAcadInfoRecord.Visible = true;
                lblAcadInfoRecord.Text = "No records found..!";
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                ddlContact_AccountHistory.Visible = true;
                lblAccountInfoRecord.Visible = false;
                ddlContact_AccountHistory.DataSource = ds.Tables[3];
                ddlContact_AccountHistory.DataBind();
            }
            else
            {
                ddlContact_AccountHistory.Visible = false;
                //ddlContact_AccountHistory.Visible = true;
                lblAccountInfoRecord.Visible = true;
                lblAccountInfoRecord.Text = "No records found..!";
            }

            ddlCallingContact_Type.DataSource = ds.Tables[4];
            ddlCallingContact_Type.DataTextField = "Con_Type_desc";
            ddlCallingContact_Type.DataValueField = "Con_Id";
            ddlCallingContact_Type.DataBind();
            ddlCallingContact_Type.Items.Insert(0, "Select");
            ddlCallingContact_Type.SelectedIndex = 0;


            ddlCallStatus.DataSource = ds.Tables[5];
            ddlCallStatus.DataTextField = "CallStatusDesc";
            ddlCallStatus.DataValueField = "CallStatusID";
            ddlCallStatus.DataBind();
            ddlCallStatus.Items.Insert(0, "Select");
            ddlCallStatus.SelectedIndex = 0;
        }
    }


    //private void BindSecContactDetails(string Conid)
    //{
    //    string Con_id = Conid;

    //    lblPKey_Con_Id.Text = Con_id;

    //    //ContactInfoPanel1.BindSecContactDetails(Con_id);
    //    HistoryPanel1.BindContactHistory(Con_id);

    //    HtmlAnchor editContact = aedit;
    //    editContact.Visible = true;
    //    editContact.HRef = "Contact_Edit.aspx?&Con_id=" + lblPKey_Con_Id.Text; 

    //    DataSet ds = ProductController.Get_ContactbyContactId(8, Con_id);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        if ((ds.Tables[0].Rows[0]["Con_type_id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Con_type_id"].ToString() == ""))
    //        {
    //            ddlContactType.SelectedIndex = 0;
    //        }
    //        else
    //        {
    //            ddlContactType.SelectedValue = ds.Tables[0].Rows[0]["Con_type_id"].ToString();
    //        }

    //        if ((ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Category_Type_Id"].ToString() == ""))
    //        {
    //            ddlcustomertype.SelectedIndex = 0;
    //        }
    //        else
    //        {
    //            ddlcustomertype.SelectedValue = ds.Tables[0].Rows[0]["Category_Type_Id"].ToString();
    //        }


    //        if (ds.Tables[0].Rows[0]["Con_title"].ToString() == "Mr.")
    //        {
    //            ddlTitle.SelectedValue = "1";
    //        }
    //        else if (ds.Tables[0].Rows[0]["Con_title"].ToString() == "Ms.")
    //        {
    //            ddlTitle.SelectedValue = "2";
    //        }
    //        else
    //        {
    //            ddlTitle.SelectedIndex = 0;
    //        }

    //        txtFirstName.Text = ds.Tables[0].Rows[0]["Con_Firstname"].ToString();
    //        txtMidName.Text = ds.Tables[0].Rows[0]["Con_midname"].ToString();
    //        txtLastName.Text = ds.Tables[0].Rows[0]["Con_lastname"].ToString();

    //        if ((ds.Tables[0].Rows[0]["Gender"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Gender"].ToString() == ""))
    //        {
    //            ddlGender.SelectedIndex = 0;
    //        }
    //        else
    //        {
    //            if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Male")
    //            {
    //                ddlGender.SelectedValue = "1";
    //            }
    //            else if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Female")
    //            {
    //                ddlGender.SelectedValue = "2";
    //            }
    //            else
    //                ddlGender.SelectedIndex = 0;
    //        }

    //        if (ds.Tables[0].Rows[0]["DOB"].ToString() == "")
    //        {
    //            txtdateofbirth.Text = "";
    //        }
    //        else
    //        {
    //            txtdateofbirth.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
    //        }

    //        txthandphone1.Text = ds.Tables[0].Rows[0]["handphone1"].ToString();
    //        txtHandphone2.Text = ds.Tables[0].Rows[0]["handphone2"].ToString();
    //        txtlandline.Text = ds.Tables[0].Rows[0]["landline"].ToString();
    //        txtemailid.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
    //        txtaddress1.Text = ds.Tables[0].Rows[0]["Flatno"].ToString();
    //        txtaddress2.Text = ds.Tables[0].Rows[0]["BuildingName"].ToString();
    //        txtStreetname.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
    //        txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

    //        if ((ds.Tables[0].Rows[0]["Country"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Country"].ToString() == ""))
    //        {
    //            ddlCountry.SelectedIndex = 0;
    //            ddlstate.Items.Clear();
    //            ddlcity.Items.Clear();
    //            ddllocation.Items.Clear();
    //            ddlstate.Items.Insert(0, "Select");
    //            ddlcity.Items.Insert(0, "Select");
    //            ddllocation.Items.Insert(0, "Select");
    //            ddlstate.SelectedIndex = 0;
    //            ddlcity.SelectedIndex = 0;
    //            ddllocation.SelectedIndex = 0;
    //        }
    //        else
    //        {
    //            ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
    //            BindState();
    //            if ((ds.Tables[0].Rows[0]["State"].ToString() == "Select") || (ds.Tables[0].Rows[0]["State"].ToString() == ""))
    //            {
    //                ddlstate.SelectedIndex = 0;
    //                ddlcity.Items.Clear();
    //                ddllocation.Items.Clear();
    //                ddlcity.Items.Insert(0, "Select");
    //                ddlcity.SelectedIndex = 0;
    //                ddllocation.Items.Insert(0, "Select");
    //                ddllocation.SelectedIndex = 0;
    //            }
    //            else
    //            {
    //                ddlstate.SelectedValue = ds.Tables[0].Rows[0]["State"].ToString();
    //                BindCity();
    //                if ((ds.Tables[0].Rows[0]["City"].ToString() == "Select") || (ds.Tables[0].Rows[0]["City"].ToString() == ""))
    //                {
    //                    ddlcity.SelectedIndex = 0;
    //                    ddllocation.Items.Clear();
    //                    ddllocation.Items.Insert(0, "Select");
    //                    ddllocation.SelectedIndex = 0;
    //                }
    //                else
    //                {
    //                    ddlcity.SelectedValue = ds.Tables[0].Rows[0]["City"].ToString();
    //                    BindLocation();
    //                    if ((ds.Tables[0].Rows[0]["Location"].ToString() == "Select") || (ds.Tables[0].Rows[0]["Location"].ToString() == ""))
    //                    {
    //                        ddllocation.SelectedIndex = 0;
    //                    }
    //                    else
    //                    {
    //                        ddllocation.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
    //                    }
    //                }
    //            }
    //        }

    //        if (ds.Tables[1].Rows.Count > 0)
    //        {
    //            dlAcadInfo.Visible = true;
    //            lblAcadInfoRecord.Visible = false;
    //            dlAcadInfo.DataSource = ds.Tables[1];
    //            dlAcadInfo.DataBind();
    //        }
    //        else
    //        {
    //            dlAcadInfo.Visible = false;
    //            lblAcadInfoRecord.Visible = true;
    //            lblAcadInfoRecord.Text = "No records found..!";
    //        }

    //        if (ds.Tables[2].Rows.Count > 0)
    //        {
    //            dlSec_Con_Info.Visible = true;
    //            lblSecConRecord.Visible = false;
    //            dlSec_Con_Info.DataSource = ds.Tables[2];
    //            dlSec_Con_Info.DataBind();
    //        }
    //        else
    //        {
    //            dlSec_Con_Info.Visible = false;
    //            lblSecConRecord.Visible = true;
    //            lblSecConRecord.Text = "No records found..!";
    //        }

    //        if (ds.Tables[5].Rows.Count > 0)
    //        {
    //            ddlContact_AccountHistory.Visible = true;
    //            lblAccountInfoRecord.Visible = false;
    //            ddlContact_AccountHistory.DataSource = ds.Tables[5];
    //            ddlContact_AccountHistory.DataBind();
    //        }
    //        else
    //        {
    //            ddlContact_AccountHistory.Visible = false;
    //            //ddlContact_AccountHistory.Visible = true;
    //            lblAccountInfoRecord.Visible = true;
    //            lblAccountInfoRecord.Text = "No records found..!";
    //        }
            
    //        ddlCallingContact_Type.DataSource = ds.Tables[6];
    //        ddlCallingContact_Type.DataTextField = "Con_Type_desc";
    //        ddlCallingContact_Type.DataValueField = "Con_Id";
    //        ddlCallingContact_Type.DataBind();
    //        ddlCallingContact_Type.Items.Insert(0, "Select");
    //        ddlCallingContact_Type.SelectedIndex = 0;

    //        ddlCallStatus.DataSource = ds.Tables[7];
    //        ddlCallStatus.DataTextField = "CallStatusDesc";
    //        ddlCallStatus.DataValueField = "CallStatusID";
    //        ddlCallStatus.DataBind();
    //        ddlCallStatus.Items.Insert(0, "Select");
    //        ddlCallStatus.SelectedIndex = 0;

    //        //if (ds.Tables[8].Rows.Count > 0)
    //        //{
    //        //    dlCallhistory.Visible = true;
    //        //    lblerrrormessageCallHistory.Visible = false;
    //        //    dlCallhistory.DataSource = ds.Tables[8];
    //        //    dlCallhistory.DataBind();
    //        //}
    //        //else
    //        //{
    //        //    dlCallhistory.Visible = false;
    //        //    lblerrrormessageCallHistory.Visible = true;
    //        //    lblerrrormessageCallHistory.Text = "No records found..!";
    //        //}
    //    }
    //}


    private void FindCallNumber()
    {
        if ((ddlCallingContact_Type.SelectedIndex == 0) || (ddlCallingContact_NoType.SelectedIndex == 0))
        {
            txtCallingNumber.Text = "";
            divCallButton.Visible = false;
            return;
        }
        else
        {

            foreach (DataListItem item in dlSec_Con_Info.Items)
            {

                Label lblContactId = (Label)item.FindControl("lblContactId");
                if (lblContactId.Text == ddlCallingContact_Type.SelectedValue.ToString())
                {
                    if(ddlCallingContact_NoType.SelectedValue == "Handphone1")
                    {
                        Label lblHandphone1 = (Label)item.FindControl("lblHandphone1");
                        txtCallingNumber.Text = lblHandphone1.Text;
                        if (txtCallingNumber.Text == "")
                        {
                            divCallButton.Visible = false;
                        }
                        else
                        {
                            divCallButton.Visible = true;
                        }
                        return;
                    }
                    else if (ddlCallingContact_NoType.SelectedValue == "Handphone2")
                    {
                        Label lblHandphone2 = (Label)item.FindControl("lblHandphone2");
                        txtCallingNumber.Text = lblHandphone2.Text;
                        if (txtCallingNumber.Text == "")
                        {
                            divCallButton.Visible = false;
                        }
                        else
                        {
                            divCallButton.Visible = true;
                        }
                        return;
                    }
                    else if (ddlCallingContact_NoType.SelectedValue == "Landline")
                    {
                        Label lblLandline = (Label)item.FindControl("lblLandline");
                        txtCallingNumber.Text = lblLandline.Text;
                        if (txtCallingNumber.Text == "")
                        {
                            divCallButton.Visible = false;
                        }
                        else
                        {
                            divCallButton.Visible = true;
                        }
                        return;
                    }
                }

            }
        }
    }   

    private void BindLocation()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcity.SelectedValue);
        BindDDL(ddllocation, ds, "Location_Name", "Location_Code");
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }   
    

    private void Bindlist()
    {

        try
        {

            if (Request["Lead_Code"] != null)
            {
                string leadid = Request["Lead_Code"];
                //SqlDataReader dr = ProductController.Getleaddetailsbyleadid(leadid);
                //if ((((dr) != null)))
                //{
                //    if (dr.Read())
                //    {
                //        txtleadtype.Text = dr["leadtype"].ToString();
                //        txtleadsource.Text = dr["lead_Source_desc"].ToString();
                //        txtleadstatus.Text = dr["lead_status_desc"].ToString();
                //        txtstudentname.Text = dr["Con_Firstname"].ToString() + " " + dr["Con_Midname"].ToString() + " " + dr["Con_lastname"].ToString();
                //        txthandphone1.Text = dr["handphone1"].ToString();
                //        txtlandline.Text = dr["landline"].ToString();
                //        txtsourcecenter.Text = dr["Source_Center_Name"].ToString();
                //        lblstudentname.Text = dr["Con_Title"].ToString() + " " + dr["Con_FirstName"].ToString() + " " + dr["Con_midname"].ToString() + " " + dr["Con_lastname"].ToString();
                //        Bindleadstatus();
                //        //ddlfeedbackstatus.SelectedValue = dr["Lead_Status_Code"].ToString();
                //    }

                //}
            }
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
   
    //private void binddlfeedback()
    //{
    //    if (Request["Con_id"] != null)
    //    {
    //        string Con_id = Request["Con_id"];
    //        DataSet ds = ProductController.GetAllContactCampaignfeedbackbyId(Con_id,"1");
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

    //private void BindDDLSeminarDetail()
    //{
    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string User_Code = cookie.Values["UserID"];
    //    string  Flag="1";
    //    DataSet ds = ProductController.Get_Seminar_Detail(User_Code, Flag);
    //    BindDDL(ddlSeminar, ds, "Seminar_Name", "Seminar_Id");
    //    ddlSeminar.Items.Insert(0, "Select");
    //    ddlSeminar.SelectedIndex = 0;
    //}

    private void BindDDlInteractedwith()
    {
        DataSet ds = ProductController.GetallInteractedwith();
        BindDDL(ddlinteratedrelation, ds, "Description", "ID");
        ddlinteratedrelation.Items.Insert(0, "Select");
        ddlinteratedrelation.SelectedIndex = 0;
    }

    private void Bindleadstatus()
    {
        DataSet ds = ProductController.GetallactiveleadStatus();
        BindDDL(ddlOppstatus, ds, "Description", "ID");
        ddlOppstatus.Items.Insert(0, "Select");
        ddlOppstatus.SelectedIndex = 0;

        //BindDDL(ddlfeedbackstatus, ds, "Description", "ID");
        //ddlfeedbackstatus.Items.Insert(0, "Select");
        //ddlfeedbackstatus.SelectedIndex = 0;
    }

    private void Bindproduct()
    {
        DataSet ds = ProductController.GetallactiveleadStatus();
        BindDDL(ddlOppstatus, ds, "Description", "ID");
        ddlOppstatus.Items.Insert(0, "Select");
        ddlOppstatus.SelectedIndex = 0;
    }

    private void bindddlproductcategory()
    {
        DataSet ds = ProductController.GetallProductCategory();
        BindDDL(ddlproductcategory, ds, "Description", "ID");
        ddlproductcategory.Items.Insert(0, "Select");
        ddlproductcategory.SelectedIndex = 0;
    }
    private void Bindddlsalesstage()
    {
        DataSet ds = ProductController.GetallSalesStage();
        BindDDL(ddlsalesstage, ds, "Sales_Stage_Desc", "Sales_Id");
        ddlsalesstage.Items.Insert(0, "Select");
        ddlsalesstage.SelectedIndex = 0;
    }
    protected void ddlsalesstage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindProbabilityPercent();
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


    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }


    protected void btnSubmitFeedback_ServerClick(object sender, System.EventArgs e)
    {
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        if (ddlContactMode.SelectedValue == "1001") //If the Contact Mode is System Dial 
        {
            try
            {
                string contactno_Called1 = customerPhone.Value;
                if (string.IsNullOrEmpty(contactno_Called1)) //If the Contact mode is system dial and not click calling button
                {
                    divErrormessage.Visible = true;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = "Call Not Made";
                    divSuccessmessage.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Call Not Made";
                divSuccessmessage.Visible = false;
                return;
            }
        }

        try
        {
            //if (txtdate.Text != "")
            //{
            //    if ((Convert.ToDateTime(ClsCommon.FormatDate(txtdate.Text)) > DateTime.Today))
            //    {
            //        lbldateerrorInteracted.Visible = true;
            //        lbldateerrorInteracted.Text = "Interacted Date cannot be a future date";
            //        txtdate.Focus();
            //        return;
            //    }
            //}
            if (txtdate.Value == "")
            {
                lbldateerrorInteracted.Visible = true;
                lbldateerrorInteracted.Text = "Enter the date of Interaction";
                //txtdate.Focus();
                return;
            }
            if (txtdate.Value != "")
            {
                if ((Convert.ToDateTime(ClsCommon.FormatDate(txtdate.Value)) > DateTime.Today))
                {
                    lbldateerrorInteracted.Visible = true;
                    lbldateerrorInteracted.Text = "Interacted Date cannot be a future date";
                    //txtdate.Focus();
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            lbldateerrorInteracted.Visible = true;
            lbldateerrorInteracted.Text = ex.Message;
            txtdate.Focus();
            return;
        }

        try
        {
            if (txtnextfollowupdate.Value != "")
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtnextfollowupdate.Value)) < Convert.ToDateTime(ClsCommon.FormatDate(txtdate.Value)))
                {
                    lbldateerrorfollow.Visible = true;
                    lbldateerrorfollow.Text = "Follow up date cannot be prior to Interacted date";
                    txtnextfollowupdate.Focus();
                    return;
                }
            }

        }
        catch (Exception ex)
        {
            return;
            
        }


        if (string.IsNullOrEmpty(txtnextfollowupdate.Value))
        {
            txtnextfollowupdate.Value = "";
        }
        else
        {
            try
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtnextfollowupdate.Value)) < DateTime.Today)
                {
                    //lbldateerrorfollow.Visible = True
                    //lbldateerrorfollow.Text = "Followup Date cannot be a past date"
                    //txtnextfollowupdate.Focus()
                    //lbldateerrorInteracted.Visible = False
                    //Exit Sub
                }
                else
                {
                    lbldateerrorfollow.Visible = false;
                    lbldateerrorInteracted.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lbldateerrorfollow.Visible = true;
                lbldateerrorfollow.Text = ex.Message;
                txtnextfollowupdate.Focus();
                return;
            }
        }

        string Feedbackid = "";
        string Taskid = "";
        string Leadid = "";
        string Interacted_With = "";
        string Interacted_Relation = "";
        string Interacted_On = "";
        string Feedback = "";
        string Feedback_Status = "";
        string NextFollowupdate = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string SeminarStatus = "";

        //for Recording Call Log
        

        try
        {
            Leadid = Request["Lead_Code"];
            Interacted_With = txtinteractedwith.Text;
            try
            {
                Interacted_Relation = ddlinteratedrelation.SelectedItem.Text;
            }
            catch(Exception ex)
            {
            }
            Interacted_On = txtdate.Value;
            Feedback = txtfeedback.Text;
            Feedback_Status = "";
            NextFollowupdate = txtnextfollowupdate.Value;
            SeminarStatus = "";

            //ddlseminarstatus.SelectedValue
            string fid = "";
            //string Seminar_Id = "";
            //if (ddlSeminar.SelectedIndex != 0)
            //{
            //    Seminar_Id = ddlSeminar.SelectedValue;
            //}

            if (ddlContactMode.SelectedValue == "1001") //If the Contact Mode is System Dial 
            {
                string contactno_Called = customerPhone.Value;
                string contact_id = customerId.Value;
                string leadgroupid = leadsetId.Value;
                string leadname = leadsetName.Value;
                string Campaign_Id = txtcampaignid.Value;
                string campaign_Name = txtcampaignname.Value;
                string Process_Id = processId.Value;
                string Process_Name = processName.Value;
                string agent_id = agentId.Value;
                string CR_UD = crUd.Value;
                string RF_UD_recording = rfUd.Value;
                string Leg_Type = legType.Value;
                string SN_UD = snUd.Value;
                string OT_UD = otUd.Value;
                string agent_Ext = atEn.Value;
                string TX_ST = txSt.Value;
                string MO_C = moc.Value;
                string Call_Start_Time = callstarttime.Value;
                string Call_End_Time = callendtime.Value;

            //    txtcampaignid.Value = lblCampaign_Id.Text;
            //txtcampaignname.Value
                

                if (ddlCallStatus.SelectedValue == "01") //Call Status is Call Connected then save the feedback into feddback table and Call info into the Log Table
                {
                    fid = ProductController.InsertFeedback_Campaign_ContactsNew(ddlContactMode.SelectedValue, Feedbackid, Taskid, lblRecNo.Text, Interacted_With, Interacted_Relation, Interacted_On,
                        Feedback, Feedback_Status, ddlCampaignFollowupStatus.SelectedValue, UserID, SeminarStatus, NextFollowupdate, "1");

                    DataSet ds = ProductController.Insert_Update_Calling_Info(1, ddlContactMode.SelectedValue, ddlContactMode.SelectedItem.ToString(), "Campaign", fid, ddlCallingContact_Type.SelectedValue, contactno_Called, lblPKey_Con_Id.Text, leadgroupid, leadname,
                                Campaign_Id, campaign_Name, Process_Id, Process_Name, agent_id, CR_UD, RF_UD_recording, Leg_Type, SN_UD, OT_UD, agent_Ext, TX_ST, MO_C,
                                Call_Start_Time, Call_End_Time, "", ddlCallStatus.SelectedValue);
                    BindSecContactDetails(lblRecNo.Text);
                }
                else //Save Only call Info 
                {
                    DataSet ds1 = ProductController.Insert_Update_Calling_Info(1, ddlContactMode.SelectedValue, ddlContactMode.SelectedItem.ToString(), "Campaign", fid, ddlCallingContact_Type.SelectedValue, contactno_Called, lblPKey_Con_Id.Text, leadgroupid, leadname,
                                Campaign_Id, campaign_Name, Process_Id, Process_Name, agent_id, CR_UD, RF_UD_recording, Leg_Type, SN_UD, OT_UD, agent_Ext, TX_ST, MO_C,
                                Call_Start_Time, Call_End_Time, "", ddlCallStatus.SelectedValue);
                    BindSecContactDetails(lblRecNo.Text);
                }
            }
            else  //If the Contact Mode is Manual Dial or Contact Visit
            {
                fid = ProductController.InsertFeedback_Campaign_ContactsNew(ddlContactMode.SelectedValue,Feedbackid, Taskid, lblRecNo.Text, Interacted_With, Interacted_Relation, Interacted_On,
                        Feedback, Feedback_Status, ddlCampaignFollowupStatus.SelectedValue, UserID, SeminarStatus, NextFollowupdate, "1");
                BindSecContactDetails(lblRecNo.Text);
            }

           

           // divfeedbackhistory.Visible = true;
            divfeedbackbuttons.Visible = false;
            divclose.Visible = true;
            txtinteractedwith.Text = "";
            //txtdate.Value = "";
            txtfeedback.Text = "";
            txtnextfollowupdate.Value = "";
            //binddlfeedback()
            Bindleadstatus();
            BindDDlInteractedwith();
            lblbuttontext.Text = "Save";
            divSuccessmessage.Visible = true;
            lblsuccessMessage.Text = "Follow up details successfully saved";
          //  binddlfeedback();


        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void chkconvert_CheckedChanged(object sender, System.EventArgs e)
    {
        if (chkconvert.Checked == true)
        {
            ddlconvertto.Enabled = true;
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            string leadid = "";
            leadid = Request["Lead_Code"];
           // divfeedbackhistory.Visible = false;
            lblbuttontext.Text = "Convert";
        }
        else
        {
            ddlconvertto.Enabled = false;
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
            ddlconvertto.SelectedIndex = 0;
            //divfeedbackhistory.Visible = true;
            lblbuttontext.Text = "Save";
        }
    }

    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
        ddlcompany.Items.Insert(0, "Select");
        ddlcompany.SelectedIndex = 0;

        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;

        ddlzone.Items.Insert(0, "Select");
        ddlzone.SelectedIndex = 0;

        ddlcenter.Items.Insert(0, "Select");
        ddlcenter.SelectedIndex = 0;
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
        //'GetAllActiveDivision(ddlcompany.SelectedValue, UserID)

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlcompany.SelectedValue);
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;

        //ddlzone.Items.Insert(0, "Select")
        //ddlzone.SelectedIndex = 0

        //ddlcenter.Items.Insert(0, "Select")
        //ddlcenter.SelectedIndex = 0

    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
        Bindproductbydivision();
    }

    private void Bindproductbydivision()
    {
        DataSet ds = ProductController.GetAllProductbyDivision(ddldivision.SelectedValue);
        BindDDL(ddlproduct, ds, "Oppor_Product", "id");
        ddlproduct.Items.Insert(0, "Select");
        ddlproduct.SelectedIndex = 0;
    }
    private void BindZone()
    {
        //GetAllZonebyDivision(ddlcompany.SelectedValue, ddlsourcedivision.SelectedValue)
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "Select");
        ddlzone.SelectedIndex = 0;

        //ddlcenter.Items.Insert(0, "All")
        //ddlcenter.SelectedIndex = 0
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
        //GetAllCenterbyZone(ddlsourcezone.SelectedValue)

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddldivision.SelectedValue, ddlzone.SelectedValue, ddlcompany.SelectedValue);
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "Select");
        ddlcenter.SelectedIndex = 0;
    }
    protected void btnopportunitycancel_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead.aspx");
    }


    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCity();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindState();
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

    //protected void ddlfeedbackstatus_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    if (ddlfeedbackstatus.SelectedValue == "04")
    //    {
    //        RequiredFieldValidator15.Visible = false;
    //        label8.Visible = false;
    //    }
    //    else
    //    {
    //        RequiredFieldValidator15.Visible = true;
    //        label8.Visible = true;
    //    }
    //}


    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactTypeinrelation();
        BindDDL(ddlContactType, ds, "Description", "ID");
    }

    private void CampaignFollowupStatus()
    {
        DataSet ds = ProductController.GetallactiveCampaignFollowupStatus();
        BindDDL(ddlCampaignFollowupStatus, ds, "Description", "ID");
        ddlCampaignFollowupStatus.Items.Insert(0, "Select");
        ddlCampaignFollowupStatus.SelectedIndex = 0;
    }

    private void StudentType2()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlcustomertype, ds, "Description", "Cust_Grp");
        ddlcustomertype.Items.Insert(0, "Select");
        ddlcustomertype.SelectedIndex = 0;
    }
    protected void ddlCallingContact_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        FindCallNumber();
    }
    protected void ddlCallingContact_NoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FindCallNumber();
    }

    protected void ddlContactMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlContactMode.SelectedValue == "1001") //if the Contact Mode is System Dial
        {
            lblCall_Status.Visible = true;
            lblCall_Status_Asstric.Visible = true;
            ddlCallStatus.Visible = true;
            ddlCallStatus.SelectedIndex = 0;
            //tblfollowupdetails.Visible = false;
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
        }
        else if (ddlContactMode.SelectedValue == "1002")  //if the Contact Mode is Manual Dial
        {
            lblCall_Status.Visible = false;
            lblCall_Status_Asstric.Visible = false;
            ddlCallStatus.Visible = false;
            ddlCallStatus.SelectedIndex = 0;
            //tblfollowupdetails.Visible = true;
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
        }
        else if (ddlContactMode.SelectedValue == "1003")  //if the Contact Mode is Contact Visit
        {
            lblCall_Status.Visible = false;
            lblCall_Status_Asstric.Visible = false;
            ddlCallStatus.Visible = false;
            ddlCallStatus.SelectedIndex = 0;
            //tblfollowupdetails.Visible = true;
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
        }
        else
        {
            lblCall_Status.Visible = false;
            lblCall_Status_Asstric.Visible = false;
            ddlCallStatus.Visible = false;
            ddlCallStatus.SelectedIndex = 0;
            //tblfollowupdetails.Visible = false;
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
        }
    }
    protected void ddlCallStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCallStatus.SelectedValue == "01")
        {
            //tblfollowupdetails.Visible = true;
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;
        }
        else
        {
           // tblfollowupdetails.Visible = false;
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            txtnextfollowupdate.Value = "";
            //txtinteractedwith.Text = "";
            //ddlinteratedrelation.SelectedIndex = 0;

        }
    }
}