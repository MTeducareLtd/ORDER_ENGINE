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
//using Exportxls.BL;



public partial class ContactCenter_Contact_Edit : System.Web.UI.Page
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
                lblpagetitle1.Text = "Contacts";
                lblpagetitle2.Text = "";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Contacts";
                //lilastbreadcrumb.Visible = false;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;  
                System.Threading.Thread.Sleep(1000);
                //listudentstatus.Visible = false;

                ContactType();
                StudentType2();
                Country2();
                Institutetype3();
                Board1();
                DivisionSession();
                Yearofpassing1();
                ContactSource();
    
   

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

                string Con_id = "";
                Con_id = Request["Con_id"];
                BindSecContactDetails(Con_id);
                Institutetype();
                ddlinstitutiontype_SelectedIndexChanged(sender, e);

                Board();
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

    private void Institutetype()
    {
        DataSet ds = ProductController.GetallInstituteType();
        BindDDL(ddlinstitutiontype, ds, "Description", "ID");
        ddlinstitutiontype.Items.Insert(0, "Select");
        ddlinstitutiontype.SelectedIndex = 0;
        ddlcurrentstudying.Items.Insert(0, "Select");
        ddlcurrentstudying.SelectedIndex = 0;
    }

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

        lblPKey_Con_Id.Text = Con_id;

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
                txtdateofbirth.Value = "";
            }
            else
            {
                txtdateofbirth.Value = ds.Tables[0].Rows[0]["DOB"].ToString();
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


            if (ds.Tables[3].Rows.Count > 0)
            {

                dlConHistory.Visible = true;
                lblCon_History.Visible = false;

                dlConHistory.DataSource = ds.Tables[3];
                dlConHistory.DataBind();
            }
            else
            {
                dlConHistory.Visible = false;
                lblCon_History.Visible = true;
                lblCon_History.Text = "No records found..!";
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                dlfeedbackhistory.DataSource = ds.Tables[4];
                dlfeedbackhistory.DataBind();
                dlfeedbackhistory.Visible = true;
                diverrormessagefeedback.Visible = false;
            }
            else
            {
                divfeedbackhistory.Visible = false;
                diverrormessagefeedback.Visible = true;
                lblerrrormessagefeedback.Text = "No Follow up history found !!!";
            }
        }        
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

    


    protected void ddlinstitutiontype_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype.SelectedValue);
        BindDDL(ddlcurrentstudying, ds, "Description", "ID");
        this.ddlcurrentstudying.Items.Insert(0, "Select");
        this.ddlcurrentstudying.SelectedIndex = 0;
        this.ddlcurrentstudying.Focus();
    }


    private void DivisionSession()
    {
        DataSet ds = ProductController.GetAllDivisionSection();
        BindDDL(ddlsection, ds, "Description", "ID");
        ddlsection.Items.Insert(0, "Select");
        ddlsection.SelectedIndex = 0;
    }

    private void Board1()
    {
        DataSet ds = ProductController.GetallBoard();
        BindDDL(ddlboard, ds, "Short_Description", "ID");
        ddlboard.Items.Insert(0, "Select");
        ddlboard.SelectedIndex = 0;
    }

    /// <summary>
    /// Clear Error Success Box
    /// </summary>
    private void Clear_Error_Success_Box()
    {
        divErrormessage.Visible = false;
        divSuccessmessage.Visible = false;
        lblsuccessMessage.Text = "";
        lblerrormessage.Text = "";
    }

    private void Clear_AddAcadInfo()
    {
        Clear_Error_Success_Box();
        ddlinstitutiontype.SelectedIndex = 0;
        txtnameofinstitution.Text = "";
        ddlboard.SelectedIndex = 0;
        ddlcurrentstudying.Items.Clear();
        ddlcurrentstudying.Items.Insert(0, "Select");
        ddlcurrentstudying.SelectedIndex = 0;
        ddlsection.SelectedIndex = 0;
        ddlyearofpassing.SelectedIndex = 0;
        txtadditiondesc.Text = "";
        txtExamName.Text = "";
        txtFinalMarksObtained.Text = "";
        txtFinalMarksTotal.Text = "";
        txtGrade.Text = "";
        txtPercentage.Text = "";
    }

    protected void btnAddSecondoryContact_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        tblSecConInfo.Visible = true;
        Clear_AddSecCon();
        btnSubmitcon.Visible = false;
        btnclose.Visible = false;
        btnSaveSecContact.Visible = true;
        btnUpdateSecContact.Visible = false;
    }

    private void Clear_AddSecCon()
    {
        ddlSecContactType.SelectedIndex = 0;
        ddlSecConTitle.SelectedIndex = 0;
        txtSecConFName.Text = "";
        txtSecConMName.Text = "";
        txtSecConLName.Text = "";
        txtSecConHandphone1.Text = "";
        txtSecConHandPhone2.Text = "";
        txtSecConLandLineNumber.Text = "";
        ddlSecConGender.SelectedIndex = 0;
        txtSecConEmailID.Text = "";
        txtSecConOccupation.Text = "";
        txtSecConOrganization.Text = "";
        txtSecConDesignation.Text = "";
        txtSecConOfficePhone.Text = "";
    }

    protected void btnSaveSecContact_ServerClick(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = ProductController.Insert_Update_Secondory_Contact(lblPKey_Con_Id.Text,ddlSecContactType.SelectedValue,ddlSecContactType.SelectedItem.ToString(),ddlSecConTitle.SelectedItem.ToString(),txtSecConFName.Text.Trim(),txtSecConMName.Text.Trim(),txtSecConLName.Text.Trim(),txtSecConHandphone1.Text.Trim(),txtSecConHandPhone2.Text.Trim(),txtSecConLandLineNumber.Text.Trim(),txtSecConEmailID.Text.Trim(),ddlSecConGender.SelectedItem.ToString(),
                                    txtSecConOccupation.Text.Trim(),txtSecConOrganization.Text.Trim(),txtSecConDesignation.Text.Trim(),txtSecConOfficePhone.Text.Trim(),UserID,"4");
            if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
            {

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
                
                tblSecConInfo.Visible = false;
                btnSubmitcon.Visible = true;
                btnclose.Visible = true;
            }

        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
        
    }

    protected void btnUpdateSecContact_ServerClick(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = ProductController.Insert_Update_Secondory_Contact(lblPrimary_ConId.Text, ddlSecContactType.SelectedValue, ddlSecContactType.SelectedItem.ToString(), ddlSecConTitle.SelectedItem.ToString(), txtSecConFName.Text.Trim(), txtSecConMName.Text.Trim(), txtSecConLName.Text.Trim(), txtSecConHandphone1.Text.Trim(), txtSecConHandPhone2.Text.Trim(), txtSecConLandLineNumber.Text.Trim(), txtSecConEmailID.Text.Trim(), ddlSecConGender.SelectedItem.ToString(),
                                    txtSecConOccupation.Text.Trim(), txtSecConOrganization.Text.Trim(), txtSecConDesignation.Text.Trim(), txtSecConOfficePhone.Text.Trim(), UserID, "5");
            if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
            {
                dlSec_Con_Info.DataSource = ds.Tables[1];
                dlSec_Con_Info.DataBind();

                tblSecConInfo.Visible = false;
                btnSubmitcon.Visible = true;
                btnclose.Visible = true;
            }

        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    protected void btnCloseSecCon_ServerClick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        tblSecConInfo.Visible = false;
        Clear_AddSecCon();
        btnSubmitcon.Visible = true;
        btnclose.Visible = true;
        btnSaveSecContact.Visible = false;
        btnUpdateSecContact.Visible = false;
    }

    protected void btnAddAcadInfo_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        tblAddAcadinfo.Visible = true;
        Clear_AddAcadInfo();
        btnSubmitcon.Visible = false;
        btnclose.Visible = false;
        btnAddAcadInfo.Visible = true;
        btnUpdateAcadInfo.Visible = false;
    }

    protected void btnSubmitcon_ServerClick(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();

         try
        {
            if (string.IsNullOrEmpty(txtdateofbirth.Value))
            {
            }
            else
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtdateofbirth.Value)) > DateTime.Today)
                {
                    lbldateerrordob.Visible = true;
                    lbldateerrordob.Text = "DOB cannot be a future date";
                    txtdateofbirth.Focus();
                    return;
                }
                else
                {                    
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

         //if (dlAcadInfo.Visible == false)
         //{
         //    Show_Error_Success_Box("E", "Enter academic Information");
         //    return;
         //}

         //if (dlSec_Con_Info.Visible == false)
         //{
         //    Show_Error_Success_Box("E", "Enter atleast one secondory contact detail...!");
         //    return;
         //}

        string  state = "",city="",Location="";
        if (ddlstate.SelectedValue == "0")
        {
            state = "";
            city = "";
            Location = "";
        }
        else
        {
            state = ddlstate.SelectedValue;
            if (ddlcity.SelectedValue == "0")
            {
                city = "";
                Location = "";
            }
            else
            {
                city = ddlcity.SelectedValue;
                if (ddllocation.SelectedValue == "0")
                {
                    Location = "";
                }
                else
                    Location = ddllocation.SelectedValue;
            }
        }
        
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        DataSet ds = ProductController.Insert_Update_Contact_Detail_New(ddlContactsourceadd.SelectedValue, ddlContactType.SelectedValue, ddlContactType.SelectedItem.ToString(), ddlcustomertype.SelectedValue, ddlcustomertype.SelectedItem.ToString(), ddlTitle.SelectedItem.ToString(), txtFirstName.Text.Trim(), txtMidName.Text.Trim(), txtLastName.Text.Trim(), ddlGender.SelectedItem.ToString(), 
                                        txtdateofbirth.Value, txtHandPhone1.Text.Trim(), txtHandphone2.Text.Trim(), txtlandline.Text.Trim(), txtaddress1.Text.Trim(), txtaddress2.Text.Trim(), txtStreetname.Text.Trim(), ddlCountry.SelectedValue, state, city,Location, txtpincode.Text.Trim(), txtemailid.Text.Trim(), lblPKey_Con_Id.Text, UserID, "1");
        if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
        {
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalConvertToLead();", true);
            divSaveMessage.Visible = true;
            upnldisplay.Visible = false;
        }

    }
    protected void btnSaveAcadInfo_ServerClick(object sender, EventArgs e)
    {        
        try
        {
            Clear_Error_Success_Box();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = ProductController.Insert_Update_Contact_AcadInfo(ddlinstitutiontype.SelectedValue, ddlinstitutiontype.SelectedItem.ToString(), txtnameofinstitution.Text.Trim(), ddlboard.SelectedValue, ddlboard.SelectedItem.ToString(), ddlcurrentstudying.SelectedValue, ddlcurrentstudying.SelectedItem.ToString(),
                            ddlsection.SelectedValue, ddlsection.SelectedItem.ToString(), ddlyearofpassing.SelectedValue, ddlyearofpassing.SelectedItem.ToString(), txtadditiondesc.Text.Trim(), txtExamName.Text.Trim(), txtFinalMarksObtained.Text.Trim(), txtFinalMarksTotal.Text.Trim(), txtGrade.Text.Trim(), txtPercentage.Text.Trim(), lblPKey_Con_Id.Text, UserID, "", "2","","","","","","");
            if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
            {

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


                tblAddAcadinfo.Visible = false;
                btnSubmitcon.Visible = true;
                btnclose.Visible = true;
            }

        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    protected void btnUpdateAcadInfo_ServerClick(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = ProductController.Insert_Update_Contact_AcadInfo(ddlinstitutiontype.SelectedValue, ddlinstitutiontype.SelectedItem.ToString(), txtnameofinstitution.Text.Trim(), ddlboard.SelectedValue, ddlboard.SelectedItem.ToString(), ddlcurrentstudying.SelectedValue, ddlcurrentstudying.SelectedItem.ToString(),
                            ddlsection.SelectedValue, ddlsection.SelectedItem.ToString(), ddlyearofpassing.SelectedValue, ddlyearofpassing.SelectedItem.ToString(), txtadditiondesc.Text.Trim(), txtExamName.Text.Trim(), txtFinalMarksObtained.Text.Trim(), txtFinalMarksTotal.Text.Trim(), txtGrade.Text.Trim(), txtPercentage.Text.Trim(), lblPKey_Con_Id.Text, UserID, lblAcadInfoRecordNo.Text, "3","","","","","","");
            if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
            {
                dlAcadInfo.DataSource = ds.Tables[1];
                dlAcadInfo.DataBind();

                tblAddAcadinfo.Visible = false;
                btnSubmitcon.Visible = true;
                btnclose.Visible = true;
            }

        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    private void Show_Error_Success_Box(string BoxType, string Error_Code)
    {
        if (BoxType == "E")
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = ProductController.Raise_Error(Error_Code);
        }
        else
        {
            divSuccessmessage.Visible = true;
            divErrormessage.Visible = false;
            lblsuccessMessage.Text = ProductController.Raise_Error(Error_Code);
        }
    }

    private void Board()
    {
        DataSet ds = ProductController.GetallBoard();
        BindDDL(ddlboard, ds, "Short_Description", "ID");
        ddlboard.Items.Insert(0, "Select");
        ddlboard.SelectedIndex = 0;
    }

    protected void dlSec_Con_Info_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Clear_AddSecCon();
            foreach (DataListItem item in dlSec_Con_Info.Items)
            {
                Label lblContactId = (Label)item.FindControl("lblContactId");

                if (lblContactId.Text == e.CommandArgument.ToString())
                {
                    Label lblCon_type_id = (Label)item.FindControl("lblCon_type_id");
                    Label lblConTitle = (Label)item.FindControl("lblConTitle");
                    Label lblFName = (Label)item.FindControl("lblFName");
                    Label lblMName = (Label)item.FindControl("lblMName");
                    Label lblLName = (Label)item.FindControl("lblLName");
                    Label lblHandphone1 = (Label)item.FindControl("lblHandphone1");
                    Label lblHandphone2 = (Label)item.FindControl("lblHandphone2");
                    Label lblLandline = (Label)item.FindControl("lblLandline");
                    Label lblGender = (Label)item.FindControl("lblGender");
                    Label lblEmailid = (Label)item.FindControl("lblEmailid");
                    Label lblOccupation = (Label)item.FindControl("lblOccupation");
                    Label lblOrganization = (Label)item.FindControl("lblOrganization");
                    Label lblDesignation = (Label)item.FindControl("lblDesignation");
                    Label lblOffice_phone = (Label)item.FindControl("lblOffice_phone");

                    lblPrimary_ConId.Text = lblContactId.Text;

                    ddlSecContactType.SelectedValue = lblCon_type_id.Text;
                    if (lblConTitle.Text == "Mr.")
                        ddlSecConTitle.SelectedValue = "1";
                    else if (lblConTitle.Text == "Ms.")
                        ddlSecConTitle.SelectedValue = "2";
                    else
                        ddlSecConTitle.SelectedIndex = 0;

                    txtSecConFName.Text = lblFName.Text;
                    txtSecConMName.Text = lblMName.Text;
                    txtSecConLName.Text = lblLName.Text;
                    txtSecConHandphone1.Text = lblHandphone1.Text;
                    txtSecConHandPhone2.Text = lblHandphone2.Text;
                    txtSecConLandLineNumber.Text = lblLandline.Text;

                    if (lblGender.Text == "Male")
                        ddlSecConGender.SelectedValue = "1";
                    else if (lblGender.Text == "Female")
                        ddlSecConGender.SelectedValue = "2";
                    else
                        ddlSecConGender.SelectedIndex = 0;

                    txtSecConEmailID.Text = lblEmailid.Text;
                    txtSecConOccupation.Text = lblOccupation.Text;
                    txtSecConOrganization.Text = lblOrganization.Text;
                    txtSecConDesignation.Text = lblDesignation.Text;
                    txtSecConOfficePhone.Text = lblOffice_phone.Text;

                    tblSecConInfo.Visible = true;
                    btnSaveSecContact.Visible = false;
                    btnUpdateSecContact.Visible = true;
                    btnSubmitcon.Visible = false;
                    btnclose.Visible = false;
                    return;
                }
            }
        }
    }

    protected void dlAcadInfo_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            foreach (DataListItem item in dlAcadInfo.Items)
            {
                Label lblInstitutionTypeCode = (Label)item.FindControl("lblInstitutionTypeCode");
                Label lblInstitutionType = (Label)item.FindControl("lblInstitutionType");
                Label lblInstitutionName = (Label)item.FindControl("lblInstitutionName");
                Label lblBoardId = (Label)item.FindControl("lblBoardId");
                Label lblBoardName = (Label)item.FindControl("lblBoardName");
                Label lblStandardCode = (Label)item.FindControl("lblStandardCode");
                Label lblStandardName = (Label)item.FindControl("lblStandardName");
                Label lblDivisionCode = (Label)item.FindControl("lblDivisionCode");
                Label lblDivisionName = (Label)item.FindControl("lblDivisionName");
                Label lblPassingYearCode = (Label)item.FindControl("lblPassingYearCode");
                Label lblPassingYearName = (Label)item.FindControl("lblPassingYearName");
                Label lblAditionalDesc = (Label)item.FindControl("lblAditionalDesc");
                Label lblExamName = (Label)item.FindControl("lblExamName");
                Label lblFinalMarkObt = (Label)item.FindControl("lblFinalMarkObt");
                Label lblFinalMarkTotal = (Label)item.FindControl("lblFinalMarkTotal");
                Label lblGrade = (Label)item.FindControl("lblGrade");
                Label lblPercentage = (Label)item.FindControl("lblPercentage");
                Label lblRowNumber = (Label)item.FindControl("lblRowNumber");


                if (lblRowNumber.Text == e.CommandArgument.ToString())
                {
                    ddlinstitutiontype.SelectedValue = lblInstitutionTypeCode.Text;
                    ddlinstitutiontype_SelectedIndexChanged(source, e);
                    txtnameofinstitution.Text = lblInstitutionName.Text;
                    ddlboard.SelectedValue = lblBoardId.Text;
                    ddlcurrentstudying.SelectedValue = lblStandardCode.Text;
                    ddlsection.SelectedValue = lblDivisionCode.Text;
                    ddlyearofpassing.SelectedValue = lblPassingYearCode.Text;
                    txtadditiondesc.Text = lblAditionalDesc.Text;
                    txtExamName.Text = lblExamName.Text;
                    txtFinalMarksObtained.Text = lblFinalMarkObt.Text;
                    txtFinalMarksTotal.Text = lblFinalMarkTotal.Text;
                    txtGrade.Text = lblGrade.Text;
                    txtPercentage.Text = lblPercentage.Text;
                    tblAddAcadinfo.Visible = true;
                    btnSaveAcadInfo.Visible = false;
                    btnUpdateAcadInfo.Visible = true;
                    btnSubmitcon.Visible = false;
                    btnclose.Visible = false;
                    lblAcadInfoRecordNo.Text = lblRowNumber.Text;
                    return;
                }
            }
        }
    }

    protected void btnCloseAcadInfo_ServerClick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        tblAddAcadinfo.Visible = false;
        btnSubmitcon.Visible = true;
        btnclose.Visible = true;
        //btnclearcon.Visible = true;
    }

    

    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCity();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindState();
    }

    protected void btn_ConvertToLeadYes_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Convert_Contact_To_Lead.aspx?&Con_id=" + lblPKey_Con_Id.Text);
    }

    protected void btn_ConvertToLeadNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Contact_Edit.aspx?&Con_id=" + lblPKey_Con_Id.Text);
    }


    protected void btn_ContactMsgOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactCenter_Contact_Edit.aspx?&Con_id=" + lblPKey_Con_Id.Text);
    }

    //protected void btn_ConvertToLeadYes_ServerClick(object sender, EventArgs e)
    //{
    //    Response.Redirect("Convert_Contact_To_Lead.aspx?&Con_id=" + lblPKey_Con_Id.Text);
    //}
    //protected void btn_ConvertToLeadNo_ServerClick(object sender, EventArgs e)
    //{
    //    Response.Redirect("Contact_Edit.aspx?&Con_id=" + lblPKey_Con_Id.Text);
    //}

    private void BindState()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlCountry.SelectedValue);
        BindDDL(ddlstate, ds, "State_Name", "State_Code");
        ddlstate.Items.Insert(0, "Select");
        ddlstate.SelectedIndex = 0;
        ddlcity.Items.Clear();        
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
        ddllocation.Items.Clear();
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }


    private void BindCity()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlstate.SelectedValue);
        BindDDL(ddlcity, ds, "City_Name", "City_Code");
        ddlcity.Items.Insert(0, "Select");
        ddlcity.SelectedIndex = 0;
        ddllocation.Items.Clear();
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }

    private void ContactType()
    {
        DataSet ds = ProductController.GetallactiveContactTypeinrelation();
        BindDDL(ddlContactType, ds, "Description", "ID");
        BindDDL(ddlSecContactType, ds, "Description", "ID");
        ddlSecContactType.Items.Insert(0, "Select");
        ddlSecContactType.SelectedIndex = 0;
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
        ddllocation.Items.Insert(0, "Select");
        ddllocation.SelectedIndex = 0;
    }
    private void Institutetype3()
    {
        DataSet ds = ProductController.GetallInstituteType();
        BindDDL(ddlinstitutiontype, ds, "Description", "ID");
        ddlinstitutiontype.Items.Insert(0, "Select");
        ddlinstitutiontype.SelectedIndex = 0;
        ddlcurrentstudying.Items.Insert(0, "Select");
        ddlcurrentstudying.SelectedIndex = 0;
    }

    private void Yearofpassing1()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlyearofpassing, ds, "Description", "ID");
        ddlyearofpassing.Items.Insert(0, "Select");
        ddlyearofpassing.SelectedIndex = 0;
    }

   
}