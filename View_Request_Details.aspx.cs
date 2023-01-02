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

public partial class View_Request_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            lblpagetitle1.Text = "Manage Account";
            //lblpagetitle2.Text = "Request Details";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage View Ledger";
            //lilastbreadcrumb.Visible = false;
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            //lbltabname.Text = "Search by"
            //upnlsearch.Visible = True
            Upnlviewledger.Visible = true;
            //System.Threading.Thread.Sleep(4000);
            listudentstatus.Visible = false;

            //System.Threading.Thread.Sleep(2000);
            //upnlsearch.Visible = False
            Upnlviewledger.Visible = true;
            lblpagetitle1.Text = "Manage Account";
            lblpagetitle2.Text = "Request Details";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage View Ledger";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = "Request Details";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            //lbltabname1.Text = "Request Details"
            string Cur_Sb_Code = "";
            Cur_Sb_Code = Request["SBEntrycode"];
            string Requestid = "";
            Requestid = Request["Req_id"];
            Bindlist(Cur_Sb_Code);
            BindStudentSubjectGroup(Cur_Sb_Code);
            BindStudentLedger();
            BindLeveldetails();

            //System.Threading.Thread.Sleep(2000);
            diverrorrequest.Visible = false;
            divSuccessRequest.Visible = false;

            trlevel1_1.Visible = false;
            //trlevel1_2.Visible = False
            trlevel1_3.Visible = false;

            trlevel2_1.Visible = true;
            trlevel2_2.Visible = true;
            trlevel2_3.Visible = false;
            //trlevel2_4.Visible = False
            trlevel2_5.Visible = false;

            trlevel3_1.Visible = true;
            trlevel3_2.Visible = true;
            trlevel3_3.Visible = false;
            //trlevel3_4.Visible = False
            trlevel3_5.Visible = false;

            divlevel1error.Visible = false;
            divlevel1success.Visible = false;
            divlevel2error.Visible = false;
            divlevel2success.Visible = false;

            BindRequestDetails(Cur_Sb_Code);

            
        }


    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void BindLeveldetails()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Requestid = "";
        Requestid = Request["Req_id"];
        SqlDataReader dr = AccountController.GetAlluserbylevel(Requestid);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                lblCenterusername.Text = dr["centreuser"].ToString();
                lbluserlevel1.Text = dr["apr1name"].ToString();
                lbluserlevel2.Text = dr["apr2name"].ToString();
                lbluserlevel3.Text = dr["apr3name"].ToString();
            }
        }

    }
    private void BindRequestDetails(string CurSbcode)
    {
        string SBEntrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        SBEntrycode = CurSbcode;
        string Requestid = "";
        Requestid = Request["Req_id"];
        SqlDataReader dr = AccountController.GetAllrequestasreaderforuser(SBEntrycode, UserID, Requestid);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtrequesttype1.Text = dr["Voucher_description"].ToString();
                txtrequestdate1.Text = dr["requestdate1"].ToString();
                txtconditiontype.Text = dr["Request_type"].ToString();
                txtrequestamt.Text = dr["amt1"].ToString();
                txtcenterremark1.Text = dr["Centre_remarks"].ToString();
                lblreqcode.Text = dr["request_type_code"].ToString();
                lblapprovalstatuslevel1.Text = dr["rst1"].ToString();
                lblapprovalstatuslevel2.Text = dr["rst2"].ToString();
                lblapprovalstatuslevel3.Text = dr["rst3"].ToString();


                if (lblapprovalstatuslevel1.Text == "Declined")
                {
                    divlevel1error.Visible = true;
                    lbllevel1error.Visible = true;
                    lbllevel1error.Text = "Request Declined" + ": " + dr["rmk2"].ToString();
                    divlevel2New.Visible = false;
                    divlevel3New.Visible = false;
                    trlevel2_1.Visible = false;
                    trlevel2_2.Visible = false;
                    tr1.Visible = false;
                    tr2.Visible = false;
                    divlevel4error.Visible = false;
                    //lbllevel4error.Visible = True
                    //lbllevel4error.Text = "Request Pending for Approval"
                    //divlevel4success.Visible = False
                }
                else
                {
                    if (lblapprovalstatuslevel1.Text == "Approved")
                    {
                        txtapprovedamt1.Text = dr["amt2"].ToString();
                        txtstatus1.Text = "Approved";
                        Txtappdate1.Text = dr["aprdt2"].ToString();
                        txtpremark1.Text = dr["rmk2"].ToString();
                    }
                    else
                    {
                        if (dr["amt2"].ToString() == "0")
                        {
                            divlevel1error.Visible = true;
                            lbllevel1error.Visible = true;
                            lbllevel1error.Text = "Request Pending for Approval";
                            trlevel2_1.Visible = false;
                            trlevel2_2.Visible = false;
                            tr1.Visible = false;
                            tr2.Visible = false;
                            divlevel4error.Visible = true;
                            lbllevel4error.Visible = true;
                            lbllevel4error.Text = "Request Pending for Approval";
                            divlevel4success.Visible = false;
                        }
                        else
                        {
                            txtapprovedamt1.Text = dr["amt2"].ToString();
                            txtstatus1.Text = "Approved";
                            Txtappdate1.Text = dr["aprdt2"].ToString();
                            txtpremark1.Text = dr["rmk2"].ToString();

                        }
                    }

                }

                if (lblapprovalstatuslevel2.Text == "Declined" | lblapprovalstatuslevel1.Text == "Declined")
                {
                    divlevel2error.Visible = true;
                    lbllevel2error.Visible = true;
                    lbllevel2error.Text = "Request Declined" + ": " + dr["rmk3"].ToString();
                    divlevel3New.Visible = false;
                    trlevel3_1.Visible = false;
                    trlevel3_2.Visible = false;
                    tr1.Visible = false;
                    tr2.Visible = false;
                    //divlevel4error.Visible = True
                    //lbllevel4error.Visible = True
                    //lbllevel4error.Text = "Request Pending for Approval"
                    //divlevel4success.Visible = False
                }
                else
                {
                    if (lblapprovalstatuslevel2.Text == "Approved")
                    {
                        txtapprovalamt2.Text = dr["amt3"].ToString();
                        Txtappdate2.Text = dr["aprdt3"].ToString();
                        txtpremark2.Text = dr["rmk3"].ToString();
                        txtstatus2.Text = "Approved";
                    }
                    else
                    {
                        if (dr["amt3"].ToString() == "0")
                        {
                            divlevel2error.Visible = true;
                            lbllevel2error.Visible = true;
                            lbllevel2error.Text = "Request Pending for Approval";
                            trlevel3_1.Visible = false;
                            trlevel3_2.Visible = false;
                            tr1.Visible = false;
                            tr2.Visible = false;
                            divlevel4error.Visible = true;
                            lbllevel4error.Visible = true;
                            lbllevel4error.Text = "Request Pending for Approval";
                            divlevel4success.Visible = false;
                        }
                        else
                        {
                            txtapprovalamt2.Text = dr["amt3"].ToString();
                            Txtappdate2.Text = dr["aprdt3"].ToString();
                            txtpremark2.Text = dr["rmk3"].ToString();
                            txtstatus2.Text = "Approved";
                        }
                    }

                }

                if (lblapprovalstatuslevel3.Text == "Declined" | lblapprovalstatuslevel1.Text == "Declined" | lblapprovalstatuslevel3.Text == "Declined")
                {
                    divlevel4error.Visible = true;
                    lbllevel4error.Visible = true;
                    string rmk1 = "";
                    rmk1 = dr["rmk4"].ToString();
                    lbllevel4error.Text = "Request Declined" + ": " + rmk1;
                    divlevel4success.Visible = false;
                    tr1.Visible = false;
                    tr2.Visible = false;
                }
                else
                {
                    if (lblapprovalstatuslevel3.Text == "Approved")
                    {
                        txtlevel4amt.Text = dr["amt4"].ToString();
                        txtlevel4appdate.Text = dr["aprdt4"].ToString();
                        txtlevel4remark.Text = dr["rmk4"].ToString();
                        txtlevel4status.Text = "Approved";
                        divlevel4error.Visible = false;
                        divlevel4success.Visible = false;
                    }
                    else
                    {
                        if (dr["amt4"].ToString() == "0")
                        {
                            divlevel4error.Visible = true;
                            lbllevel4error.Visible = true;
                            lbllevel4error.Text = "Request Pending for Approval";
                            divlevel4success.Visible = false;
                            tr1.Visible = false;
                            tr2.Visible = false;
                        }
                        else
                        {
                            txtlevel4amt.Text = dr["amt4"].ToString();
                            txtlevel4appdate.Text = dr["aprdt4"].ToString();
                            txtlevel4remark.Text = dr["rmk4"].ToString();
                            txtlevel4status.Text = "Approved";
                            divlevel4error.Visible = false;
                            divlevel4success.Visible = false;
                        }
                    }

                }



            }
        }
    }
    private void Bindlist(string Cursbcode)
    {
        SqlDataReader dr = AccountController.GetAccountdetailbycursbcode(1, Cursbcode);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                string Gender = dr["gender"].ToString();
                if (Gender == "M")
                {
                    txtgender.Text = "Male";
                }
                else
                {
                    txtgender.Text = "Female";
                }
                txtLstudentname.Text = dr["NAME"].ToString();
                imgstudentphoto.ImageUrl = dr["stud_image"].ToString();
                txtLappno.Text = dr["Student_App_No"].ToString();
                txtopportunityid.Text = dr["oppor_id"].ToString();
                txtaccountid.Text = dr["account_id"].ToString();
                txtcursbcode.Text = dr["sbentrycode"].ToString();
                BindLedgerCompany();
                ddllcompany.SelectedValue = dr["companycode"].ToString();
                BindLedgerDivision();
                ddlldivision.SelectedValue = dr["divisioncode"].ToString();
                BindLedgerCenter();
                ddllcenter.SelectedValue = dr["center_code"].ToString();
                BindLedgerAcademicYear();
                ddllacadyear.SelectedValue = dr["acad_year"].ToString();
                BindLedgerStream();
                ddllstream.SelectedValue = dr["stream_code"].ToString();
                txtpayplan.Text = dr["payplan"].ToString();
                string Studentstatus = "";
                Studentstatus = dr["Account_Status_id"].ToString();


                if (Studentstatus == "01")
                {
                    listudentstatus.Visible = true;
                    lblstdstaus.Text = "Student Status : Pending";

                }
                else if (Studentstatus == "03")
                {
                    listudentstatus.Visible = true;
                    lblstdstaus.Text = "Student Status : Confirmed";

                }
                else if (Studentstatus == "02")
                {
                    listudentstatus.Visible = true;
                    lblstdstaus.Text = "Customer Status : Cancelled";

                }
            }
        }
    }
    private void BindLedgerCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserID"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddllcompany, ds, "Company_Name", "Company_Code");
        ddllcompany.Items.Insert(0, "Select");
        ddllcompany.SelectedIndex = 0;
    }
    private void BindLedgerDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddllcompany.SelectedValue);
        BindDDL(ddlldivision, ds, "Division_Name", "Division_Code");
        ddlldivision.Items.Insert(0, "Select");
        ddlldivision.SelectedIndex = 0;
    }
    private void BindLedgerCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlldivision.SelectedValue, "", ddllcompany.SelectedValue);
        BindDDL(ddllcenter, ds, "Center_name", "Center_Code");
        ddllcenter.Items.Insert(0, "Select");
        ddllcenter.SelectedIndex = 0;
    }
    private void BindLedgerAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddllcenter.SelectedValue);
        BindDDL(ddllacadyear, ds, "Acad_Year", "Acad_Year");
        ddllacadyear.Items.Insert(0, "Select");
        ddllacadyear.SelectedIndex = 0;
    }
    private void BindLedgerStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear(ddllcenter.SelectedValue, ddllacadyear.SelectedValue);
        BindDDL(ddllstream, ds, "Stream_Sdesc", "Stream_Code");
        ddllstream.Items.Insert(0, "Select");
        ddllstream.SelectedIndex = 0;
    }
    private void BindStudentSubjectGroup(string CurSbCode)
    {
        DataSet ds = AccountController.GetStudentSubjectgroupbyCursbcode(2, CurSbCode);
        lbsubjectgroup.DataSource = ds;
        lbsubjectgroup.DataTextField = "SGR_DESC";
        lbsubjectgroup.DataValueField = "sgr_material";
        lbsubjectgroup.DataBind();
    }
    private void BindStudentLedger()
    {
        string Sbentrycode = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        Sbentrycode = txtcursbcode.Text;
        DataSet ds = AccountController.Getstudentledgerbysbentrycode(Sbentrycode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //System.Threading.Thread.Sleep(1000)
            dlstudentledger.DataSource = ds;
            dlstudentledger.DataBind();

        }
        else
        {
        }
    }


}