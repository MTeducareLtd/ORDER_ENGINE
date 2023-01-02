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
using System.Web.UI.DataVisualization.Charting;
//using Exportxls.BL;

public partial class Homepage : System.Web.UI.Page
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
                BindAcademicYear();
                try
                {
                    DataSet ds = ProductController.GetDashboardValues(UserID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //dloppsummary.DataSource = ds;
                        //dloppsummary.DataBind();

                        Chart1.DataSource = ds.Tables[0];
                        Chart1.Series["Series1"].XValueMember = "Lead_status_desc";
                        Chart1.Series["Series1"].YValueMembers = "Lead_Count";
                        //Chart1.Series["Series1"].ToolTip = "Min:#VALY1, Max:#VALY2";
                        Chart1.Series["Series1"].ToolTip = "#VALY1";
                        
                        Chart1.DataBind();

                        Chart2.DataSource = ds.Tables[1];
                        Chart2.Series["Series1"].XValueMember = "Sales_Stage_Desc";
                        Chart2.Series["Series1"].YValueMembers = "Oppur_Count";
                        Chart2.DataBind();

                        Chart3.DataSource = ds.Tables[2];
                        Chart3.Series["Series1"].XValueMember = "Sales_Stage_Desc";
                        Chart3.Series["Series1"].YValueMembers = "Value";
                        Chart3.Series["Series1"].ToolTip = "#VALY1";
                        Chart3.DataBind();

                        lblleadcount.Text = Convert.ToString(ds.Tables[3].Rows[0]["Leadcount"]);
                        lblopportunitycount.Text = Convert.ToString(ds.Tables[4].Rows[0]["OpporCount"]);
                        lblAccountCount.Text = Convert.ToString(ds.Tables[5].Rows[0]["AccountCount"]);
                        lblpendingaccount.Text = Convert.ToString(ds.Tables[6].Rows[0]["AccountCountPending"]);
                        lblpendingacc.Text = Convert.ToString(ds.Tables[6].Rows[0]["AccountCountPending"]);
                        lblconfirmaccount.Text = Convert.ToString(ds.Tables[7].Rows[0]["AccountCountConfirm"]);
                        lblpendingfollowup.Text = Convert.ToString(ds.Tables[8].Rows[0]["PendingFollowupCount"]);
                        lbldiscountvalue.Text = Convert.ToString(ds.Tables[9].Rows[0]["DiscountValue"]);
                        lblApprovalPendingCount.Text = Convert.ToString(ds.Tables[10].Rows[0]["ApprovalPendingCount"]);
                        //lblApprovalPendingCount1.Text = Convert.ToString(ds.Tables[10].Rows[0]["ApprovalPendingCount"]);
                        int Count1 = Convert.ToInt32(int.Parse(lblopportunitycount.Text).ToString());
                        int AccountCount1 = Convert.ToInt32(int.Parse(lblAccountCount.Text).ToString());
                        float Conversion = (AccountCount1 * 100) / (Count1 + AccountCount1);
                        lblconversion.Text = string.Format("{0}", Conversion)+" %";
                        //divleadcount.Attributes.Add("data-percent", "80");
                        lblconversion.Attributes.Add("ToolTip", "(Account x 100/Opportunity+Account)");
                        divconfirmadmission.Attributes.Add("data-percent=", "80");
                        divconfirmadmission.Attributes.Add("data-size=", "80");

                        //HtmlAnchor NavigatePendingadmission = apendingadmission;
                        //HtmlAnchor NavigateAdmission = aadmission;
                        //NavigatePendingadmission.HRef = "Dashboard_Account.aspx?&AcadYear=" + ddlAcadYear.SelectedValue;
                        //NavigateAdmission.HRef = "Dashboard_Account.aspx?&AcadYear=" + ddlAcadYear.SelectedValue;
                    }
                  
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
    int Sum;


    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void BindAcademicYear()
    {
        DataSet ds = ProductController.GetAllAcadyear();
        //DataSet ds = ProductController.GetAcademicYearbyCenter(ddlcenter.SelectedValue);
        BindDDL(ddlAcadYear, ds, "Acad_Year", "Acad_Year");
        //ddlAcadYear.Items.Insert(0, "Select");
        ddlAcadYear.SelectedIndex = 1;
        HtmlAnchor NavigatePendingadmission = apendingadmission;
        HtmlAnchor NavigateAdmission = aadmission;
        HtmlAnchor NavigateOpportunity = Dashboard_Opportunity;
        NavigatePendingadmission.HRef = "Dashboard_Account.aspx?&AcadYear=" + ddlAcadYear.SelectedValue;
        NavigateAdmission.HRef = "Dashboard_Account.aspx?&AcadYear=" + ddlAcadYear.SelectedValue;
        NavigateOpportunity.HRef = "Dashboard_Opportunity.aspx?&AcadYear=" + ddlAcadYear.SelectedValue;
    }


    protected void ddlAcadYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.Cookies["MyCookiesLoginInfo"] != null)
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];            
            try
            {
                DataSet ds = ProductController.GetDashboardValuesbyAcadYear(UserID,ddlAcadYear.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //dloppsummary.DataSource = ds;
                    //dloppsummary.DataBind();

                    Chart1.DataSource = ds.Tables[0];
                    Chart1.Series["Series1"].XValueMember = "Lead_status_desc";
                    Chart1.Series["Series1"].YValueMembers = "Lead_Count";
                    //Chart1.Series["Series1"].ToolTip = "Min:#VALY1, Max:#VALY2";
                    Chart1.Series["Series1"].ToolTip = "#VALY1";
                    Chart1.DataBind();

                    Chart2.DataSource = ds.Tables[1];
                    Chart2.Series["Series1"].XValueMember = "Sales_Stage_Desc";
                    Chart2.Series["Series1"].YValueMembers = "Oppur_Count";
                    Chart2.DataBind();

                    Chart3.DataSource = ds.Tables[2];
                    Chart3.Series["Series1"].XValueMember = "Sales_Stage_Desc";
                    Chart3.Series["Series1"].YValueMembers = "Value";
                    Chart3.Series["Series1"].ToolTip = "#VALY1";
                    Chart3.DataBind();

                    lblleadcount.Text = Convert.ToString(ds.Tables[3].Rows[0]["Leadcount"]);
                    lblopportunitycount.Text = Convert.ToString(ds.Tables[4].Rows[0]["OpporCount"]);
                    lblAccountCount.Text = Convert.ToString(ds.Tables[5].Rows[0]["AccountCount"]);
                    lblpendingaccount.Text = Convert.ToString(ds.Tables[6].Rows[0]["AccountCountPending"]);
                    lblpendingacc.Text = Convert.ToString(ds.Tables[6].Rows[0]["AccountCountPending"]);
                    lblconfirmaccount.Text = Convert.ToString(ds.Tables[7].Rows[0]["AccountCountConfirm"]);
                    lblpendingfollowup.Text = Convert.ToString(ds.Tables[8].Rows[0]["PendingFollowupCount"]);
                    lbldiscountvalue.Text = Convert.ToString(ds.Tables[9].Rows[0]["DiscountValue"]);
                    lblApprovalPendingCount.Text = Convert.ToString(ds.Tables[10].Rows[0]["ApprovalPendingCount"]);
                    //lblApprovalPendingCount1.Text = Convert.ToString(ds.Tables[10].Rows[0]["ApprovalPendingCount"]);
                    int Count1 = Convert.ToInt32(int.Parse(lblopportunitycount.Text).ToString());
                    int AccountCount1 = Convert.ToInt32(int.Parse(lblAccountCount.Text).ToString());
                    if (AccountCount1 > 0)
                    {
                        float Conversion = (AccountCount1 * 100) / (Count1 + AccountCount1);
                        lblconversion.Text = string.Format("{0}", Conversion) + " %";
                    }
                    else
                    {
                        lblconversion.Text = string.Format("{0}", "0") + " %";
                    }
                    //divleadcount.Attributes.Add("data-percent", "80");
                    lblconversion.Attributes.Add("ToolTip", "(Account x 100/Opportunity+Account)");
                    HtmlAnchor NavigatePendingadmission = apendingadmission;
                    HtmlAnchor NavigateAdmission = aadmission;
                    NavigatePendingadmission.HRef = "Dashboard_Account.aspx?&AcadYear=" + ddlAcadYear.SelectedValue;
                    NavigateAdmission.HRef = "Dashboard_Account.aspx?&AcadYear=" + ddlAcadYear.SelectedValue;
                    HtmlAnchor NavigateOpportunity = Dashboard_Opportunity;
                    
                    NavigateOpportunity.HRef = "Dashboard_Opportunity.aspx?&AcadYear=" + ddlAcadYear.SelectedValue;

                   
                }

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