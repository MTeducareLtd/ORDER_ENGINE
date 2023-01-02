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
//using Exportxls.BL;
using Encryption.BL;
using System.ComponentModel;
using System.Text;
using System.Drawing;


public partial class ECS_Dispatch : System.Web.UI.Page
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
                lblpagetitle1.Text = "ECS Dispatch";
                lblpagetitle2.Text = "Search Panel";
                //lblmidbreadcrumb.Text = "Manage Account";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                //DivECSDetail.Visible = false;
                //upnlsearch.Visible = true;
                btnback.Visible = false;
                btnsearchback.Visible = false;                
                divSearch.Visible = true;
                divsearchresults.Visible = false;
                BindCompany();                            
                BindAcademicYear();
                BindStream();
            }
            else
            {
                Response.Redirect("login.aspx");
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
    
    
    
    
    
   
    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center_Top1(1, UserID, "", "", "");
        ddlcompany.DataSource = ds.Tables[0];
        ddlcompany.DataTextField = "Company_Name";
        ddlcompany.DataValueField = "Company_Code";
        ddlcompany.DataBind();
       // ddlcompany.Items.Insert(0, "All");
        ddlcompany.SelectedIndex = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlcompany.SelectedValue = ds.Tables[0].Rows[0]["Company_Code"].ToString();
            ddldivision.DataSource = ds.Tables[1];
            ddldivision.DataTextField = "division_name";
            ddldivision.DataValueField = "division_code";
            ddldivision.DataBind();
            ddldivision.Items.Insert(0, "All");
            ddldivision.SelectedIndex = 0;
            if (ddldivision.Items.Count > 1)
            {
                ddldivision.SelectedIndex = 1;
                ddlzone.DataSource = ds.Tables[2];
                ddlzone.DataTextField = "Zone_Name";
                ddlzone.DataValueField = "Zone_Code";
                ddlzone.DataBind();
                ddlzone.Items.Insert(0, "All");
                ddlzone.SelectedIndex = 0;
                if (ddlzone.Items.Count > 1)
                {
                    ddlzone.SelectedIndex = 1;
                    ddlcenter.DataSource = ds.Tables[3];
                    ddlcenter.DataTextField = "center_name";
                    ddlcenter.DataValueField = "center_code";
                    ddlcenter.DataBind();
                    ddlcenter.Items.Insert(0, "All");
                    ddlcenter.SelectedIndex = 0;
                    if (ddlcenter.Items.Count > 1)
                    {
                        ddlcenter.SelectedIndex = 1;
                    }
                }
                else
                {
                    ddlcenter.Items.Insert(0, "All");
                    ddlcenter.SelectedIndex = 0;
                }
            }
            else
            {
                ddlzone.Items.Insert(0, "All");
                ddlzone.SelectedIndex = 0;
                ddlcenter.Items.Insert(0, "All");
                ddlcenter.SelectedIndex = 0;
            }
        }
        else
        {
            ddldivision.Items.Insert(0, "All");
            ddldivision.SelectedIndex = 0;
            ddlzone.Items.Insert(0, "All");
            ddlzone.SelectedIndex = 0;
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;
        }


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
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlcompany.SelectedValue);
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;
    }
    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }

    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "All");
        ddlzone.SelectedIndex = 0;
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

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddldivision.SelectedValue, ddlzone.SelectedValue, ddlcompany.SelectedValue);
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }
    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
    }
    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlacademicyear.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
        }
    }
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
    }
    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue);
        BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlstream.Items.Insert(0, "All");
        ddlstream.SelectedIndex = 0;
    }
    

    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {

        if (ddlacademicyear.SelectedIndex == 0)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Text = "Select Acad Year";           
            return;
        }
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string Company = "";
        string Division = "";
        string Zone = "";
        string Center = "";
        string AcademicYear = "";
        string Stream = "";
        string ECSStatusID = "";

        Company = ddlcompany.SelectedValue;
        Division = ddldivision.SelectedValue;
        Zone = ddlzone.SelectedValue;
        Center = ddlcenter.SelectedValue;
        AcademicYear = ddlacademicyear.SelectedValue;
        Stream = ddlstream.SelectedValue;


        DataSet ds = AccountController.GetECS_Detail(UserID, Company, Division, Zone, Center, AcademicYear, Stream, ECSStatusID, txtsbentrycode.Text.Trim(), "3","");

        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            lblpagetitle1.Text = "ECS Dispatch";
            lblpagetitle2.Text = "Search Results";
            //lblmidbreadcrumb.Text = "Manage Account";
            //lbllastbreadcrumb.Text = " Account Search Results";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            //Repeater1.DataSource = ds;
            //Repeater1.DataBind();
            dlGridDisplay.DataSource = ds;
            dlGridDisplay.DataBind();
           // script1.RegisterAsyncPostBackControl(Repeater1);
            btnsearchback.Visible = true;
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            btnsearchback.Visible = false;
            divErrormessage.Visible = true;
            lblpagetitle1.Text = "ECS Dispatch";
            lblpagetitle2.Text = "Search Panel";
            lblerrormessage.Text = "No Records Found!";            
        }
    }
  
    /// <summary>

    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        btnsearchback.Visible = false;
        lblpagetitle1.Text = "ECS Dispatch";
        lblpagetitle2.Text = "Search Panel";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;       
        btnback.Visible = false;
    }

    /// <summary>
    /// Back Functionality
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = false;
        divsearchresults.Visible = true;
       // DivECSDetail.Visible = false;    
        btnback.Visible = false;
        lblpagetitle1.Text = "ECS Dispatch";
        lblpagetitle2.Text = "Search Panel";
        //lblmidbreadcrumb.Text = "Manage Account";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;     
        btnsearch_ServerClick(sender, e);
    }


    protected void btnClose_Click(object sender, EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = false;
        divsearchresults.Visible = true;
       // DivECSDetail.Visible = false;
        btnback.Visible = false;
        lblpagetitle1.Text = "ECS Dispatch";
        lblpagetitle2.Text = "Search Panel";
        //lblmidbreadcrumb.Text = "Manage Account";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        btnsearch_ServerClick(sender, e);
    }


    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox s = sender as CheckBox;
            //Set checked status of hidden check box to items in grid
            foreach (DataListItem dtlItem in dlGridDisplay.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
                if (chkitemck.Visible == true)
                {
                    chkitemck.Checked = s.Checked;
                }
            }            
        }
        catch (Exception ex)
        {
            
        }
    }


    protected void btnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            string ECS_Id = "";
            foreach (DataListItem item in dlGridDisplay.Items)
            {
                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");
                Label lblECS_Id = (Label)item.FindControl("lblECS_Id");

                if ((chkCheck.Checked == true))
                {
                    if (lblECS_Id.Text != "")
                    {
                        ECS_Id = ECS_Id + lblECS_Id.Text + ",";
                    }
                }
            }
            if (ECS_Id == "")
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Text = "Select atleast one record.";
                return;
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = AccountController.Get_ECS_Dispatch_Export(UserID, "1", ECS_Id);

            if (ds != null)
            {
                GridView GridView1 = new GridView();
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=ECS_Dispatch_" + DateTime.Now + ".xls");
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                GridView1.RenderControl(htw);
                string style = @"<style> td { mso-number-format:\@;} </style>";
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();

            }//complete if  (ds != null)

        }
        catch (Exception ex)
        {

        }
    }


    
}