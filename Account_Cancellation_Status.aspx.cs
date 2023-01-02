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

public partial class Account_Cancellation_Status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                try
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string UserID = cookie.Values["UserID"];
                    string UserName = cookie.Values["UserName"];
                    divErrormessage.Visible = false;
                    BindAcademicYear();
                    BindDivision();
                    

                    if (Request["Year"] != null)
                    {
                        string Year = Request["Year"];
                        ddlAcadYear.SelectedValue = Year;
                    }
                    if (Request["Division"] != null)
                    {                        
                        string Division = Request["Division"];
                        ddldivision.SelectedValue = Division;                        
                    }
                    BindCenter();
                    if (Request["Center"] != null)
                    {
                        string Center = Request["Center"];
                        ddlcenter.SelectedValue = Center;
                    }
                    lblPageNumber.Text = "1";

                    Bind_Account_Cancellation_Status();
                }
                catch { }
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

    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        //ddldivision.Items.Insert(0, "All");
        ddldivision.SelectedIndex = 0;
        BindCenter();

    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //if (ddldivision.SelectedIndex == 0)
        //{
        //    BindCenter();
        //    ddlcenter.Items.Clear();
        //    ddlcenter.Items.Insert(0, "All");
        //    ddlcenter.SelectedIndex = 0;

        //}
        //else
        //{
            BindCenter();
            ddlcenter.SelectedIndex = 0;
            string year = ddlAcadYear.SelectedValue;
            string division = ddldivision.SelectedItem.Text;
            string divisioncode = ddldivision.SelectedValue;
            string centercode = ddlcenter.SelectedValue;
            lblPageNumber.Text = "1";
            Bind_Account_Cancellation_Status();
            //BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
        //}
    }

    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", "MT");
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;
    }

    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        Bind_Account_Cancellation_Status();
        lblPageNumber.Text = "1";
        //BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
    }


    private void BindAcademicYear()
    {
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        ddlAcadYear.SelectedIndex = 0;
        //BindAccountSummary();
    }

    protected void ddlAcadYear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string year = ddlAcadYear.SelectedValue;
        lblPageNumber.Text = "1";
        Bind_Account_Cancellation_Status();
    }

    private void Bind_Account_Cancellation_Status()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string AcadYear = ddlAcadYear.SelectedValue;
        //string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        DataSet ds = ProductController.Get_AccountCancellation_Status(UserID, AcadYear, divisioncode, centercode, lblPageNumber.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            divsearchresults.Visible = true;
            divErrormessage.Visible = false;

            dlAccountCancellationStatus.DataSource = ds.Tables[0];
            dlAccountCancellationStatus.DataBind();
            dlAccountCancellationStatus.Visible = true;

            lblCancellationStatus.Text = ds.Tables[0].Rows.Count.ToString();

            lblActualRecordCount.Text = ds.Tables[0].Rows[0]["RowNum"].ToString() + " To " + ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString();
            lblCancellationStatus.Text = ds.Tables[1].Rows[0]["TotalRecords"].ToString();


            if (Convert.ToInt32(lblCancellationStatus.Text) > Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["RowNum"].ToString()))
                btnStud_NextRecord.Visible = true;
            else
                btnStud_NextRecord.Visible = false;

            if (ds.Tables[0].Rows[0]["RowNum"].ToString() == "1")
                btnStud_PrevRecord.Visible = false;
            else
                btnStud_PrevRecord.Visible = true;
            
            //pnlSave2.Update();

            
        }
        else
        {
            dlAccountCancellationStatus.Visible = false;
            divErrormessage.Visible = true;
            divsearchresults.Visible = false;
        }
    }
    
    //protected void Button_Click(object sender, EventArgs e)
    //{
    //    //Get the reference of the clicked button.
    //    Button button = (sender as Button);

    //    //Get the command argument
    //    string commandArgument = button.CommandArgument;

    //    //Get the Repeater Item reference
    //    RepeaterItem item = button.NamingContainer as RepeaterItem;

    //    //Get the repeater item index
    //    //int index = item.ItemIndex;
        

    //}

    protected void btnStud_NextRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
            Bind_Account_Cancellation_Status();    
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
            Bind_Account_Cancellation_Status();    
        }
        catch (Exception ex)
        {
            
        }
    }
    











}