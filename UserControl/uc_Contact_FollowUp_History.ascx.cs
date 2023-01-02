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

public partial class UserControl_uc_Contact_FollowUp_History : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void BindContactHistory(string Conid)
    {
        DataSet ds = ProductController.Get_ContactbyContactId(8, Conid);
        if (ds.Tables[3].Rows.Count > 0)
        {

            dlConHistory.Visible = true;
            //lblCon_History.Visible = false;
            diverrormessageContactHistory.Visible = false;

            dlConHistory.DataSource = ds.Tables[3];
            dlConHistory.DataBind();
        }
        else
        {
            dlConHistory.Visible = false;
            lblCon_History.Visible = true;
            diverrormessageContactHistory.Visible = true;
            lblCon_History.Text = "No records found..!";
        }

        if (ds.Tables[4].Rows.Count > 0)
        {
            dlfeedbackhistory.Visible = true;
            diverrormessagefeedback.Visible = false;
            dlfeedbackhistory.DataSource = ds.Tables[4];
            dlfeedbackhistory.DataBind();
            
        }
        else
        {
           // divfeedbackhistory.Visible = false;
            dlfeedbackhistory.Visible = false;
            diverrormessagefeedback.Visible = true;
            lblerrrormessagefeedback.Text = "No Follow up history found !!!";
        }

        if (ds.Tables[8].Rows.Count > 0)
        {
            dlCallhistory.Visible = true;
            diverrormessageCallHistory.Visible = false;
            dlCallhistory.DataSource = ds.Tables[8];
            dlCallhistory.DataBind();
        }
        else
        {
            dlCallhistory.Visible = false;
            diverrormessageCallHistory.Visible = true;
            lblerrrormessageCallHistory.Visible = true;
            lblerrrormessageCallHistory.Text = "No records found..!";
        }

       // binddlfeedback();
    }

    public void DivErrorMessageContactHistoryVisibility(bool visible)
    {
        diverrormessageContactHistory.Visible = visible;
    }

    public void DivErrorMessageFollowupHistoryVisibility(bool visible)
    {
        diverrormessagefeedback.Visible = visible;
    }

    public void DivErrorMessageCallHistoryVisibility(bool visible)
    {
        diverrormessageCallHistory.Visible = visible;
    }
    //diverrormessageCallHistory
}