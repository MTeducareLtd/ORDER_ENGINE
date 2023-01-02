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

public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string LeadCount = "";
            string AdmissionCount = "";
            string Conversionratio = "";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];

                SqlDataReader dr = ProductController.Getleadcount(UserID);
                try
                {
                    if ((((dr) != null)))
                    {
                        if (dr.Read())
                        {
                            lblleadcount.Text = dr["Leadcount"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                SqlDataReader dr1 = ProductController.GetOpportunitycount(UserID);
                try
                {
                    if ((((dr1) != null)))
                    {
                        if (dr1.Read())
                        {
                            lblopportunitycount.Text = dr1["OpporCount"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                SqlDataReader dr2 = ProductController.GetAccountcount(UserID);
                try
                {
                    if ((((dr2) != null)))
                    {
                        if (dr2.Read())
                        {
                            lblAccountCount.Text = dr2["AccountCount"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {
                    int Count1 = Convert.ToInt32(int.Parse(lblopportunitycount.Text).ToString());
                    int AccountCount1 = Convert.ToInt32(int.Parse(lblAccountCount.Text).ToString());
                    float Conversion = (AccountCount1 * 100) / (Count1 + AccountCount1);
                    lblconversion.Text = string.Format("{0:0.00}", Conversion);
                    BindCompanyforleadsummary();
                    Bindlist();
                    BindOppSummary();
                    BindCompanyforleadsummary();
                }
                catch (Exception ex)
                {
                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

    }


    private void Bindlist()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Leadcompany = ddlcompanyselect.SelectedValue;
        DataSet ds = ProductController.Getleadoppsummary(1, UserID, Leadcompany);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlleadsummary.DataSource = ds;
            dlleadsummary.DataBind();
        }
        else
        {
            dlleadsummary.Visible = false;
        }
    }
    private void BindOppSummary()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string oppcompany = ddlcompanysearchopp.SelectedValue;
        DataSet ds = ProductController.Getleadoppsummary(2, UserID, oppcompany);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dloppsummary.DataSource = ds;
            dloppsummary.DataBind();
        }
        else
        {
            dloppsummary.Visible = false;
        }
    }
    int Sum;
    //Protected Sub dlleadsummary_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlleadsummary.ItemDataBound
    //    If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
    //        Dim LblA1 As Label = CType(e.Item.FindControl("Label2"), Label)
    //        Sum += Integer.Parse(LblA1.Text)
    //    End If
    //    If e.Item.ItemIndex = ListItemType.Footer Then
    //        Dim lbl1 As Label = CType(e.Item.FindControl("lbltotal"), Label)
    //        'lbl1.Text = Sum.ToString
    //    End If
    //End Sub

    protected void btnexport_ServerClick(object sender, System.EventArgs e)
    {
        //Response.Clear()
        //Response.Buffer = True
        //Response.AddHeader("content-disposition", "attachment;filename=lead_summary.xls")
        //Response.Charset = ""
        //Response.ContentType = "application/vnd.msexcel"
        //Dim Stringwriter As System.IO.StringWriter
        //Dim htmlwrite As System.Web.UI.HtmlTextWriter
        //dlleadsummary.RenderControl(htmlwrite)
        //Response.Write(Stringwriter.ToString())
        //Response.End()
        string Strfilename = DateTime.Now + "_" + "Lead Summary.xls";
        Response.BufferOutput = true;
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + Strfilename);
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        dlleadsummary.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();

    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void BindCompanyforleadsummary()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompanyselect, ds, "Company_Name", "Company_Code");
        ddlcompanyselect.Items.Insert(0, "All");
        ddlcompanyselect.SelectedIndex = 0;
        BindDDL(ddlcompanysearchopp, ds, "Company_Name", "Company_Code");
        ddlcompanysearchopp.Items.Insert(0, "All");
        ddlcompanysearchopp.SelectedIndex = 0;
    }

    protected void btnexpopp_ServerClick(object sender, System.EventArgs e)
    {
        string Strfilename = DateTime.Now + "_" + "Opportunity Summary.xls";
        Response.BufferOutput = true;
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + Strfilename);
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        dloppsummary.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }

    protected void ddlcompanysearchopp_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //Dim cookie As HttpCookie = Request.Cookies.[Get]("MyCookiesLoginInfo")
        //Dim UserID As String = cookie.Values("UserID")
        //Dim UserName As String = cookie.Values("UserName")
        //Dim oppcompany As String = ddlcompanysearchopp.SelectedValue
        //Dim ds As DataSet = ProductController.Getleadoppsummary(2, UserID, oppcompany)
        //If ds.Tables(0).Rows.Count > 0 Then
        //    dloppsummary.DataSource = ds
        //    dloppsummary.DataBind()
        //Else
        //    dloppsummary.Visible = False
        //End If
        BindOppSummary();
    }

    protected void ddlcompanyselect_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //Dim cookie As HttpCookie = Request.Cookies.[Get]("MyCookiesLoginInfo")
        //Dim UserID As String = cookie.Values("UserID")
        //Dim UserName As String = cookie.Values("UserName")
        //Dim Leadcompany As String = ddlcompanyselect.SelectedValue
        //Dim ds As DataSet = ProductController.Getleadoppsummary(1, UserID, Leadcompany)
        //If ds.Tables(0).Rows.Count > 0 Then
        //    dlleadsummary.DataSource = ds
        //    dlleadsummary.DataBind()
        //Else
        //    dlleadsummary.Visible = False
        //End If
        Bindlist();
    }

}