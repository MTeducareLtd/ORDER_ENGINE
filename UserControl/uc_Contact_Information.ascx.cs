using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
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

public partial class UserControl_uc_Contact_Information : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

    //public string Con_Id
    //{
    //    get { return lblContactId.Text; }
    //    set { lblContactId.Text = value; }
    //}


    public void BindSecContactDetails(string Conid)
    {
        string Con_id = Conid;

        //lblPKey_Con_Id.Text = Con_id;

        HtmlAnchor editContact = aedit;
        editContact.Visible = true;
        editContact.HRef = "../Contact_Edit.aspx?&Con_id=" + Con_id;

        DataSet ds = ProductController.Get_ContactbyContactId(8, Con_id);

        if (ds.Tables[0].Rows.Count > 0)
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

            if (ds.Tables[5].Rows.Count > 0)
            {
                ddlContact_AccountHistory.Visible = true;
                lblAccountInfoRecord.Visible = false;
                ddlContact_AccountHistory.DataSource = ds.Tables[5];
                ddlContact_AccountHistory.DataBind();
            }
            else
            {
                ddlContact_AccountHistory.Visible = false;
                //ddlContact_AccountHistory.Visible = true;
                lblAccountInfoRecord.Visible = true;
                lblAccountInfoRecord.Text = "No records found..!";
            }

            //ddlCallingContact_Type.DataSource = ds.Tables[6];
            //ddlCallingContact_Type.DataTextField = "Con_Type_desc";
            //ddlCallingContact_Type.DataValueField = "Con_Id";
            //ddlCallingContact_Type.DataBind();
            //ddlCallingContact_Type.Items.Insert(0, "Select");
            //ddlCallingContact_Type.SelectedIndex = 0;

            //ddlCallStatus.DataSource = ds.Tables[7];
            //ddlCallStatus.DataTextField = "CallStatusDesc";
            //ddlCallStatus.DataValueField = "CallStatusID";
            //ddlCallStatus.DataBind();
            //ddlCallStatus.Items.Insert(0, "Select");
            //ddlCallStatus.SelectedIndex = 0;

            //if (ds.Tables[8].Rows.Count > 0)
            //{
            //    dlCallhistory.Visible = true;
            //    lblerrrormessageCallHistory.Visible = false;
            //    dlCallhistory.DataSource = ds.Tables[8];
            //    dlCallhistory.DataBind();
            //}
            //else
            //{
            //    dlCallhistory.Visible = false;
            //    lblerrrormessageCallHistory.Visible = true;
            //    lblerrrormessageCallHistory.Text = "No records found..!";
            //}
        }
    }



    public void BindSecContactDetails_Agent(string Conid)
    {
        string Con_id = Conid;

        //lblPKey_Con_Id.Text = Con_id;

        HtmlAnchor editContact = aedit;
        editContact.Visible = true;
        editContact.HRef = "../ContactCenter_Contact_Edit.aspx?&Con_id=" + Con_id;

        DataSet ds = ProductController.Get_ContactbyContactId(8, Con_id);

        if (ds.Tables[0].Rows.Count > 0)
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

            if (ds.Tables[5].Rows.Count > 0)
            {
                ddlContact_AccountHistory.Visible = true;
                lblAccountInfoRecord.Visible = false;
                ddlContact_AccountHistory.DataSource = ds.Tables[5];
                ddlContact_AccountHistory.DataBind();
            }
            else
            {
                ddlContact_AccountHistory.Visible = false;
                //ddlContact_AccountHistory.Visible = true;
                lblAccountInfoRecord.Visible = true;
                lblAccountInfoRecord.Text = "No records found..!";
            }

            //ddlCallingContact_Type.DataSource = ds.Tables[6];
            //ddlCallingContact_Type.DataTextField = "Con_Type_desc";
            //ddlCallingContact_Type.DataValueField = "Con_Id";
            //ddlCallingContact_Type.DataBind();
            //ddlCallingContact_Type.Items.Insert(0, "Select");
            //ddlCallingContact_Type.SelectedIndex = 0;

            //ddlCallStatus.DataSource = ds.Tables[7];
            //ddlCallStatus.DataTextField = "CallStatusDesc";
            //ddlCallStatus.DataValueField = "CallStatusID";
            //ddlCallStatus.DataBind();
            //ddlCallStatus.Items.Insert(0, "Select");
            //ddlCallStatus.SelectedIndex = 0;

            //if (ds.Tables[8].Rows.Count > 0)
            //{
            //    dlCallhistory.Visible = true;
            //    lblerrrormessageCallHistory.Visible = false;
            //    dlCallhistory.DataSource = ds.Tables[8];
            //    dlCallhistory.DataBind();
            //}
            //else
            //{
            //    dlCallhistory.Visible = false;
            //    lblerrrormessageCallHistory.Visible = true;
            //    lblerrrormessageCallHistory.Text = "No records found..!";
            //}
        }
    }
}