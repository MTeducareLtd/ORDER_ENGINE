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

public partial class BouncedChequeAging : System.Web.UI.Page
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
                    //BindAcademicYear();
                    BindDivision();

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

                    Bind_Bouncechequeaging();
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
        ddldivision.SelectedIndex = 0;
        BindCenter();

    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      
        BindCenter();
        ddlcenter.SelectedIndex = 0;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        lblPageNumber.Text = "1";
        Bind_Bouncechequeaging();
      
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
        //string year = ddlAcadYear.SelectedValue;
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        Bind_Bouncechequeaging();
        lblPageNumber.Text = "1";
        //BindChartsWithoutCategories(year, divisioncode, division, "", "", centercode);
    }



    private void Bind_Bouncechequeaging()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string division = ddldivision.SelectedItem.Text;
        string divisioncode = ddldivision.SelectedValue;
        string centercode = ddlcenter.SelectedValue;
        DataSet ds = ProductController.Get_Bouncechequeagine(UserID, "", divisioncode, centercode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            divsearchresults.Visible = true;
            divErrormessage.Visible = false;

            dlbouncechequeaging.DataSource = ds.Tables[0];
            dlbouncechequeaging.DataBind();
            dlbouncechequeaging.Visible = true;

            lblCancellationStatus.Text = ds.Tables[0].Rows.Count.ToString();
        }
        else
        {
            dlbouncechequeaging.Visible = false;
            divErrormessage.Visible = true;
            divsearchresults.Visible = false;
        }
    }

    protected void dlStudentStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            if (gvRow.Cells[0].Text == "Stream")
            {
                gvRow.Cells.Remove(gvRow.Cells[0]);
                gvRow.Cells.Remove(gvRow.Cells[14]);
                gvRow.Cells.Remove(gvRow.Cells[14]);
                GridViewRow gvHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                TableCell headerCell0 = new TableCell()
                {
                    Text = "<b>Stream</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    RowSpan = 2
                };
                TableCell headerCell1 = new TableCell()
                {
                    Text = "<b>0-30</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell2 = new TableCell()
                {
                    Text = "<b>31-60</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell3 = new TableCell()
                {
                    Text = "<b>61-90</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell4 = new TableCell()
                {
                    Text = "<b>91-120</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell5 = new TableCell()
                {
                    Text = "<b>121-150</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell6 = new TableCell()
                {
                    Text = "<b>151-180</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };
                TableCell headerCell7 = new TableCell()
                {
                    Text = "<b>180 Above</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    ColumnSpan = 2
                };

                TableCell headerCell8 = new TableCell()
                {
                    Text = "<b>Total TOTAL Count</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    RowSpan = 2
                };


                TableCell headerCell9 = new TableCell()
                {
                    Text = "<b>Total Total Amount</b>",
                    HorizontalAlign = HorizontalAlign.Center,
                    RowSpan = 2
                };



                gvHeader.Cells.Add(headerCell0);
                gvHeader.Cells.Add(headerCell1);
                gvHeader.Cells.Add(headerCell2);
                gvHeader.Cells.Add(headerCell3);
                gvHeader.Cells.Add(headerCell4);
                gvHeader.Cells.Add(headerCell5);
                gvHeader.Cells.Add(headerCell6);
                gvHeader.Cells.Add(headerCell7);
                gvHeader.Cells.Add(headerCell8);
                gvHeader.Cells.Add(headerCell9);

                dlbouncechequeaging.Controls[0].Controls.AddAt(0, gvHeader);
            }
        }
    }



    protected void btnStud_NextRecord_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            lblPageNumber.Text = (Convert.ToInt32(lblPageNumber.Text) + 1).ToString();
            Bind_Bouncechequeaging();
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
            Bind_Bouncechequeaging();
        }
        catch (Exception ex)
        {

        }
    }
}