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
using System.Net;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        if (Request.Cookies["MyCookiesLoginInfo"] != null)
        {
            Generate_Menu();
            lblHeader_User_Name.Text = cookie.Values["UserName"];
            Get_Notification_Detail();
        }
        else
        {
            Response.Redirect("Logout.aspx", false);
        }

    }

    protected void btnBlankECSPDF_Click(object sender, EventArgs e)
    {
        try
        {
            // PrindBlankPDF();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalBlankPDF();", true);
        }
        catch
        {

        }
    }

    protected void btnBlankCancellationletter_Click(object sender, EventArgs e)
    {
        try
        {
            // PrindBlankPDF();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalcancelletterPDF();", true);
        }
        catch
        {

        }
    }


    


    protected void btnBlankECS_Yes_Click(object sender, EventArgs e)
    {
        PrindBlankPDF();
    }

    protected void btnBlankwithrefund_Click(object sender, EventArgs e)
    {
        printwithrefund();
    }
    protected void btnBlankwithoutrefund_Click(object sender, EventArgs e)
    {
        printwithoutrefund();
    }
    protected void btnBlankwithoutrefundCLOSE_Click(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalcancelletterPDFCLOSE();", false); 
    }

    protected void btnBlankECS_No_Click(object sender, EventArgs e)
    {
        // System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalWithData_ECSPDF();", true);
        Response.Redirect("ECS_Blank_PDF.aspx");
    }

    protected void btnDownLoadWithDataPDF_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception Ex)
        {

        }
    }
    protected void btnDownLoadWithDataPDF_Close_Click(object sender, EventArgs e)
    {

    }
    
    protected void BtnLogOut_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx");
    }

    private void PrindBlankPDF()
    {
        
        string strURL = "~/PDF-Files/Print_Blank_ECS.pdf";
        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        response.AddHeader("Content-Disposition", "attachment;filename=\"Print_Blank_ECS.pdf\"");
        byte[] data = req.DownloadData(Server.MapPath(strURL));
        response.BinaryWrite(data);
        response.End();
    }
    
    private void printwithrefund()
    {
        string strURL = "~/PDF-Files/cancellation_with_refund.pdf";
        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        response.AddHeader("Content-Disposition", "attachment;filename=\"cancellation_with_refund.pdf\"");
        byte[] data = req.DownloadData(Server.MapPath(strURL));
        response.BinaryWrite(data);
        response.End();
        
        
    }

    private void printwithoutrefund()
    {
        string strURL = "~/PDF-Files/cancellation_without_refund.pdf";
        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        response.AddHeader("Content-Disposition", "attachment;filename=\"cancellation_without_refund.pdf\"");
        byte[] data = req.DownloadData(Server.MapPath(strURL));
        response.BinaryWrite(data);
        response.End();
        
    }

    private void Generate_Menu()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        //Login_Service.LoginServiceSoapClient client = new Login_Service.LoginServiceSoapClient();
        if (Request.Cookies["MyCookiesLoginInfo"] != null)
        {
            string defaultpage = cookie.Values["Default_page"];
            //DataSet dtApplicatUrl = ProductController.GetApplication_Url();
            //dtApplicatUrl = client.GetApplication_Url();
            //dtApplicatUrl = ProductController.GetApplication_Url();
            //lblPath1.Text = dtApplicatUrl.Tables[0].Rows[0]["Homepage_Path"].ToString();
            //lblPath2.Text = dtApplicatUrl.Tables[0].Rows[1]["Homepage_Path"].ToString();
            //lblPath3.Text = dtApplicatUrl.Tables[0].Rows[2]["Homepage_Path"].ToString();
            //lblPath4.Text = dtApplicatUrl.Tables[0].Rows[3]["Homepage_Path"].ToString();
            //lblPath5.Text = dtApplicatUrl.Tables[0].Rows[4]["Homepage_Path"].ToString();
            //lblPath6.Text = dtApplicatUrl.Rows[5]["Homepage_Path"].ToString();

            string Userid = cookie.Values["UserID"];
            string lstr = "";
            lstr = Convert.ToString(("<ul class='nav nav-list'>"));
            //DataTable dt = client.GetMenuList("1", Userid, "");
            DataSet ds = ProductController.GetMenuList("1", Userid, "");
            lstr += Convert.ToString(("<li> <a href=' " + defaultpage + "'><i class='icon-home'></i><span>Dashboard</span></a></li>"));
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                string Application_no = Convert.ToString(ds.Tables[0].Rows[i]["Application_No"]);
                if (Application_no == "DB01")
                {
                    lstr += Convert.ToString(("<li> <a href=' " + ds.Tables[0].Rows[i]["Menu_link"] + "' class='" + ds.Tables[0].Rows[i]["Toggle"] + "'><i class='" + ds.Tables[0].Rows[i]["Menu_CSS"] + "'></i><span>"));
                    //lstr += Convert.ToString(("<li> <a href=' " + ds.Tables[0].Rows[i]["Menu_link"] + "'><i class='" + ds.Tables[0].Rows[i]["Menu_CSS"] + "'></i><span>"));
                    //lstr += Convert.ToString(("<li class=''> <a href='#' class='dropdown-toggle'><i class='" + dt.Rows[i]["Menu_CSS"] + "'></i><span>"));
                    lstr += (Convert.ToString(ds.Tables[0].Rows[i]["Menu_Name"]));
                    //DataTable dt1 = client.GetMenuList("2", Userid, ds.Tables[0].Rows.[i]["Menu_Code"].ToString());
                    DataSet ds1 = ProductController.GetMenuList("2", Userid, ds.Tables[0].Rows[i]["Menu_Code"].ToString());
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        lstr += Convert.ToString(("</span><b class='arrow icon-angle-down'></b>"));
                        lstr += Convert.ToString(("</a><ul class='submenu'>"));
                        for (int j = 0; j <= ds1.Tables[0].Rows.Count - 1; j++)
                        {
                            lstr += Convert.ToString((((" <li><a href='") + ds1.Tables[0].Rows[j]["Menu_Link"] + "'><i></i>") + ds1.Tables[0].Rows[j]["Menu_Name"] + "</a>"));
                        }
                        lstr += Convert.ToString(("</ul></li>"));
                    }
                    lstr += Convert.ToString(("</span></a></li>"));
                    lblHeaderMenu.Text = lstr;
                }
            }
            lstr += Convert.ToString(("</ul>"));

        }

    }

    protected void btnShortCut_CMDM_Engine_ServerClick(object sender, System.EventArgs e)
    {
        //string Path = lblPath1.Text.Trim();
        //int lenPath = Path.Length;

        //if (lenPath == 0)
        //{
        //}
        //else
        //{
        //    Response.Redirect(Path, false);
        //}


    }

    protected void btnShortCut_Order_Engine_ServerClick(object sender, System.EventArgs e)
    {
        //string Path = lblPath2.Text.Trim();
        //int lenPath = Path.Length;

        //if (lenPath == 0)
        //{
        //}
        //else
        //{
        //    Response.Redirect(Path, false);
        //}
        //Response.Redirect(lblPath2.Text.Trim(), false);
    }

    protected void btnShortCut_Scheduling_Engine_ServerClick(object sender, System.EventArgs e)
    {
        //string Path = lblPath3.Text.Trim();
        //int lenPath = Path.Length;

        //if (lenPath == 0)
        //{
        //}
        //else
        //{
        //    Response.Redirect(Path, false);
        //}
        //Response.Redirect(lblPath3.Text.Trim(), false);
    }

    protected void btnShortCut_Test_Engine_ServerClick(object sender, System.EventArgs e)
    {
        //string Path = lblPath4.Text.Trim();
        //int lenPath = Path.Length;

        //if (lenPath == 0)
        //{
        //}
        //else
        //{
        //    Response.Redirect(Path, false);
        //}
        // Response.Redirect(lblPath4.Text.Trim(), false);
    }

    protected void btnShortCut_Messaging_Engine_ServerClick(object sender, System.EventArgs e)
    {
        //string Path = lblPath5.Text.Trim();
        //int lenPath = Path.Length;

        //if (lenPath == 0)
        //{
        //}
        //else
        //{
        //    Response.Redirect(Path, false);
        //}
        //Response.Redirect(lblPath5.Text.Trim(), false);
    }

    protected void btnShortCut_Engine_ServerClick(object sender, System.EventArgs e)
    {
        //Response.Redirect(lblPath5.Text.Trim(), false);
    }

    public void Get_Notification_Detail()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds = ProductController.Get_Notification_Detail(UserID, "1");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                lblFollowupNotDoneInLead.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                lblFollowupOverdueInLead.Text = ds.Tables[0].Rows[1]["Value"].ToString();
                lblFollowupNotDoneInOpportunity.Text = ds.Tables[0].Rows[2]["Value"].ToString();
                lblFollowupOverdueInOpportunity.Text = ds.Tables[0].Rows[3]["Value"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    lbllastbounceuploaddate.Text = ds.Tables[1].Rows[0]["rtndate"].ToString();
                }
                else
                {
                    lbllastbounceuploaddate.Text = "No Record Found";
                }
            }
        }
    }
}
