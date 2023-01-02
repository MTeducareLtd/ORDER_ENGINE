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
using System.Web.UI.DataVisualization.Charting;
using System.Text;
using InfoSoftGlobal;

public partial class Pending_AccountDetailed : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
               
                DataSet ds = ProductController.GetPendingAdmission_detailed(Session["Lblpk.Text"].ToString());
              
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    lblTotalPendingAccounts.Text = ds.Tables[0].Rows.Count.ToString();
                    dlPendingAccountReasonwise.DataSource = ds;
                    dlPendingAccountReasonwise.DataBind();
               
                   
                }

                else
                {
                    //Msg_Error.Visible = true;
                    //lblerror.Visible = true;
                    //lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";

                }
            }
            else
            {
                //Response.Redirect("login.aspx");
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



   



   



    

    protected void btnStud_NextRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
           
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnStud_PrevRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) - 1).ToString();
            
        }
        catch (Exception ex)
        {

        }
    }
    

}