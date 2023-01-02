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

public partial class Fees_Deductions : System.Web.UI.Page
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
                    if (Request["Year"] != null)
                    {
                        string Year = Request["Year"];
                        ddlAcadYear.SelectedValue = Year;
                    }
                    if (Request["Division"] != null)
                    {
                        BindDivision();
                        string Division = Request["Division"];
                        ddldivision.SelectedValue = Division;
                        BindCenter();
                    }
                    if (Request["Center"] != null)
                    {
                        string Center = Request["Center"];
                        ddlcenter.SelectedValue = Center;
                    }
                    BindAccountSummary();
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
        if (ddldivision.SelectedIndex == 0)
        {
            BindCenter();
            ddlcenter.Items.Clear();
            ddlcenter.Items.Insert(0, "All");
            ddlcenter.SelectedIndex = 0;

        }
        else
        {
            BindCenter();
            ddlcenter.SelectedIndex = 0;
            string year = ddlAcadYear.SelectedValue;
            string division = ddldivision.SelectedItem.Text;
            string divisioncode = ddldivision.SelectedValue;
            string centercode = ddlcenter.SelectedValue;
            BindAccountSummary();
            //BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
        }
    }

    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddldivision.SelectedValue, "", "MT");
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        //ddlcenter.Items.Insert(0, "All");
        ddlcenter.SelectedIndex = 0;

    }

    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        BindAccountSummary();
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
        BindAccountSummary();
    }

    private void BindAccountSummary()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string AcadYear = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        DataSet ds = ProductController.GetFees_Deductions(UserID, AcadYear, divisioncode, centercode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            divsearchresults.Visible = true;
            divErrormessage.Visible = false;
            dlPendingAccountsummary.DataSource = ds.Tables[0];
            dlPendingAccountsummary.DataBind();
            dlPendingAccountsummary.Visible = true;

        }
        else
        {
            dlPendingAccountsummary.Visible = false;
            divErrormessage.Visible = true;
            divsearchresults.Visible = false;
        }
    }

    //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        if (e.Row.RowIndex > 0)
    //        {
    //            GridViewRow previousRow = dlPendingAccountsummary.Rows[e.Row.RowIndex - 1];
    //            if (e.Row.Cells[0].Text == previousRow.Cells[0].Text)
    //            {
    //                if (previousRow.Cells[0].RowSpan == 0)
    //                {
    //                    previousRow.Cells[0].RowSpan += 7;
    //                    e.Row.Cells[0].Visible = false;
    //                }
    //            }
    //            if (e.Row.Cells[1].Text == previousRow.Cells[1].Text)
    //            {
    //                if (previousRow.Cells[1].RowSpan == 0)
    //                {
    //                    previousRow.Cells[1].RowSpan += 7;
    //                    e.Row.Cells[1].Visible = false;
    //                }
    //            }
    //        }
    //    }
    //}

    protected void dlPendingAccountsummary_RowCreated(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.Header)
    {
        //Creating a gridview object            
        GridView objGridView = (GridView)sender;
 
        //Creating a gridview row object
        GridViewRow objgridviewrow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
 
        //Creating a table cell object
        TableCell objtablecell = new TableCell();
 
        #region Merge cells
 
        //Add a blank cell at the first three cell headers
        //This can be achieved by making the colspan property of the table cell object as 3
        // and the text property of the table cell object will be blank
        //Henceforth, add the table cell object to the grid view row object
        AddMergedCells(objgridviewrow, objtablecell, 1,"", System.Drawing.Color.Black.Name);
 
        //Merge columns d,e (i.e.Address, City, Region, Postal Code, 
        //Country) under the column name "Address Details"
        //This can be achieved by making the colspan property of the table cell object as 2
        //and setting it's text to "Address Details" 
        //Henceforth, add the table cell object to the grid view row object
        AddMergedCells(objgridviewrow, objtablecell, 2, "Pre-Defined Discount", System.Drawing.Color.LightSkyBlue.Name);
        AddMergedCells(objgridviewrow, objtablecell, 2, "Other Discount", System.Drawing.Color.LightGreen.Name);
        AddMergedCells(objgridviewrow, objtablecell, 2, "Concessions", System.Drawing.Color.LightPink.Name);
        AddMergedCells(objgridviewrow, objtablecell, 2, "Waivers", System.Drawing.Color.LightSalmon.Name);
        AddMergedCells(objgridviewrow, objtablecell, 2, "Additional Discounts", System.Drawing.Color.LightSkyBlue.Name);
        AddMergedCells(objgridviewrow, objtablecell, 2, "Additional_Concessions", System.Drawing.Color.LightSteelBlue.Name);
        AddMergedCells(objgridviewrow, objtablecell, 2, "Total", System.Drawing.Color.LightCyan.Name);
        //Lastly add the gridrow object to the gridview object at the 0th position
        //Because, the header row position is 0.
        objGridView.Controls[0].Controls.AddAt(0, objgridviewrow);
        dlPendingAccountsummary.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        //dlPendingAccountsummary.Columns[0].ItemStyle.VerticalAlign = VerticalAlign.Center;
        #endregion
    }
}

    protected void AddMergedCells(GridViewRow objgridviewrow,
    TableCell objtablecell, int colspan, string celltext, string backcolor)
    {
        objtablecell = new TableCell();
        objtablecell.Text = celltext;
        objtablecell.Style.Add("text-align", "Center");
        objtablecell.Font.Bold = true;
        objtablecell.ColumnSpan = colspan;
        objtablecell.Style.Add("background-color", backcolor);
        objtablecell.HorizontalAlign = HorizontalAlign.Center;
        objgridviewrow.Cells.Add(objtablecell);
        
        //objgridviewrow.HorizontalAlign = HorizontalAlign.Center;
    }

   
}