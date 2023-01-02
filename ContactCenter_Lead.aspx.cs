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

public partial class ContactCenter_Lead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Menuid = "102";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "Lead";
                lblpagetitle2.Text = "Search Criteria / Results";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Lead";
                //lilastbreadcrumb.Visible = false;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                //divSearch.Visible = True
                Divsearchcriteria.Visible = true;
                divsearchresults.Visible = false;
                divconvert.Visible = false;
                lbldateerrorJoindate.Visible = false;
                lbldateerrorexp.Visible = false;
                SqlDataReader dr = UserController.Getuserrights(UserID, Menuid);
                try
                {
                    if ((((dr) != null)))
                    {
                        if (dr.Read())
                        {
                            int allowdisplay =Convert.ToInt32(dr["Allow_Add"].ToString());
                            if (allowdisplay == 1)
                            {
                               // btnaddlead.Visible = true;
                                //btnadd2.Visible = true;
                                //btnimportlead.Visible = False
                            }
                            else
                            {
                               // btnaddlead.Visible = false;
                               // btnadd2.Visible = false;
                                //btnimportlead.Visible = False
                            }

                        }
                    }


                }
                catch (Exception ex)
                {
                }

                string UserCompany = "";
                SqlDataReader dr1 = UserController.GetCompanyby_Userid(UserID);
                try
                {
                    if ((((dr1) != null)))
                    {
                        if (dr1.Read())
                        {
                            UserCompany = dr1["Company_Code"].ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                }
                lblusercompany.Text = UserCompany;
                if (UserCompany == "MPUC1")
                {
                    tdapplicationno.Visible = true;
                    tdapplicationno1.Visible = true;
                }
                else
                {
                    tdapplicationno.Visible = true;
                    tdapplicationno1.Visible = true;
                    RequiredFieldValidator25.Visible = true;
                    label36.Visible = true;
                }
                divmessage.Visible = false;
                //divSearch.Visible = True
                divsearchresults.Visible = false;
                BindBranchTopperDivision();
                BindddlInstitute();                
                Leadtype();
                //Bind Lead type on Page Load
                LeadSource();
                //Bind Lead Source on Page Load
                leadstatus();
                //Bind Lead Status On Page Load
                StudentType();
                //Bind Student Type On Page Load
                BindCompany();
                //Bind Company On Page Load
                Country();
                //Bind Country On Page Load
                Institutetype();
                //Bind Institute Type On Page Load
                Board();
                //Bind Board On Page Load
                Yearofpassing();
                //Bind Year of Passing On Page Load
                this.ddlstandard1.Items.Insert(0, "All");
                this.ddlstandard1.SelectedIndex = 0;
                Bindscore();
                //Bind Score On Page Load
                BindAcademicYearAll();
                CurrentyearEducation();
                ScriptManager1.RegisterAsyncPostBackControl(Repeater1);
            }
            else
            {
                Response.Redirect("login.aspx");
                //
            }
        }


    }



    //function to bind all ddl
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void BindAcademicYearAll()
    {
        DataSet ds = ProductController.GetAllAcadyear();
        BindDDL(ddlacadyear, ds, "Acad_Year", "Acad_Year");
        ddlacadyear.Items.Insert(0, "Select");
        //ddlacadyear.Items.Insert(1, "All");
        ddlacadyear.SelectedIndex = 0;
    }
    private void CurrentyearEducation()
    {
        DataSet ds = ProductController.GetAllCurrentyearEducation();
        BindDDL(ddlyeareducation, ds, "Current_Year_Education", "Year_ID");
        ddlyeareducation.Items.Insert(0, "All");
        ddlyeareducation.SelectedIndex = 0;
    }
    private void Bindscore()
    {
        string Oppid = "";
        string Scoretypeid = "";
        string Score = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int Id = 0;
        DataSet ds = ProductController.GetAllScore(1, Oppid, Scoretypeid, Score, UserID, Id);
        BindDDL(ddlscoretype, ds, "Score_Type_Short_Desc", "ID");
        ddlscoretype.Items.Insert(0, "All");
        ddlscoretype.SelectedIndex = 0;
    }
    private void Leadtype()
    {
        DataSet ds = ProductController.Getallactiveleadtype();
        BindDDL(ddlleadtype, ds, "Description", "ID");
        ddlleadtype.Items.Insert(0, "All");
        ddlleadtype.SelectedIndex = 0;
    }
    private void LeadSource()
    {
        DataSet ds = ProductController.GetallactiveleadSource();
        BindDDL(ddlleadsource, ds, "Description", "ID");
        ddlleadsource.Items.Insert(0, "All");
        ddlleadsource.SelectedIndex = 0;
    }
    private void leadstatus()
    {
        DataSet ds = ProductController.GetallactiveleadStatus();
        BindDDL(ddlleadstatus, ds, "Description", "ID");
        ddlleadstatus.Items.Insert(0, "All");
        ddlleadstatus.SelectedIndex = 0;
    }
    private void StudentType()
    {
        DataSet ds = ProductController.GetAllStudentType();
        BindDDL(ddlstudenttype, ds, "Description", "Cust_Grp");
        ddlstudenttype.Items.Insert(0, "All");
        ddlstudenttype.SelectedIndex = 0;
    }
    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
        ddlcompany.Items.Insert(0, "All");
        ddlcompany.SelectedIndex = 0;

        BindDDL(ddlconvertcompany, ds, "Company_Name", "Company_Code");
        ddlconvertcompany.Items.Insert(0, "Select");
        ddlconvertcompany.SelectedIndex = 0;
        ddlsourcedivision.Items.Insert(0, "All");
        ddlsourcedivision.SelectedIndex = 0;
        ddlsourcezone.Items.Insert(0, "All");
        ddlsourcezone.SelectedIndex = 0;
        ddlsourcecenter.Items.Insert(0, "All");
        ddlsourcecenter.SelectedIndex = 0;

        ddltargetcompany.Items.Insert(0, "All");
        ddltargetcompany.SelectedIndex = 0;

        ddltargetdivision.Items.Insert(0, "All");
        ddltargetdivision.SelectedIndex = 0;
        ddltargetzone.Items.Insert(0, "All");
        ddltargetzone.SelectedIndex = 0;
        ddltargetcenter.Items.Insert(0, "All");
        ddltargetcenter.SelectedIndex = 0;
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
        BindDDL(ddlsourcedivision, ds, "Division_Name", "Division_Code");
        ddlsourcedivision.Items.Insert(0, "All");
        ddlsourcedivision.SelectedIndex = 0;
    }

    protected void ddlsourcedivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
    }

    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddlsourcedivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlsourcezone, ds, "Zone_Name", "Zone_Code");
        ddlsourcezone.Items.Insert(0, "All");
        ddlsourcezone.SelectedIndex = 0;

        ddlsourcecenter.Items.Insert(0, "All");
        ddlsourcecenter.SelectedIndex = 0;
    }
    protected void ddlsourcezone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
    }
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddlsourcedivision.SelectedValue, ddlsourcezone.SelectedValue, ddlcompany.SelectedValue);
        BindDDL(ddlsourcecenter, ds, "Center_name", "Center_Code");
        ddlsourcecenter.Items.Insert(0, "All");
        ddlsourcecenter.SelectedIndex = 0;
    }


    protected void btnsearch_ServerClick(object sender, EventArgs e)
    {
        string Leadtypeid = "";
        string Leadsourceid = "";
        string leadStatusid = "";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Studentname = "";
        string Contact_Company = "";
        string Contact_Source_Division = "";
        string Contact_Source_Zone = "";
        string Contact_Source_Center = "";
        string Contact_Target_Division = "";
        string Contact_Target_Zone = "";
        string Contact_Target_Center = "";

        string Leadcreatedonfrom = "";
        string Leadcreatedonto = "";
        string Country = "";
        string State = "";
        string City = "";

        string Customertype = "";
        string Institutiontype = "";
        string Board = "";
        string Standard = "";
        string Courseinterested = "";
        string followupdatefrom = "";
        string Followupto = "";
        string year = "";
        int Overdue = 0;

        Leadtypeid = ddlleadtype.SelectedValue;
        Leadsourceid = ddlleadsource.SelectedValue;
        leadStatusid = ddlleadstatus.SelectedValue;
        Studentname = txtstudentname.Text;
        Contact_Company = ddlcompany.SelectedValue;
        Contact_Source_Division = ddlsourcedivision.SelectedValue;
        Contact_Source_Zone = ddlsourcezone.SelectedValue;
        Contact_Source_Center = ddlsourcecenter.SelectedValue;
        Contact_Target_Division = ddltargetdivision.SelectedValue;
        Contact_Target_Zone = ddltargetzone.SelectedValue;
        Contact_Target_Center = ddltargetcenter.SelectedValue;

        Leadcreatedonfrom = txtfromdate.Value;
        Leadcreatedonto = txttodate.Value;
        Country = ddlcountrysearch.SelectedValue;
        State = ddlstatesearch.SelectedValue;
        City = ddlcitysearch.SelectedValue;

        Customertype = ddlstudenttype.SelectedValue;
        Institutiontype = ddlinstitutiontype1.SelectedValue;
        Board = ddlboard1.SelectedValue;
        Standard = ddlstandard1.SelectedValue;
        Courseinterested = txtcourseinterestedin.Text;
        year = ddlyear1.SelectedValue;

        lblTargetCompCode.Text = Contact_Company;
        lblTargetDivCode.Text = Contact_Source_Division;
        lblTargetZoanCode.Text = Contact_Source_Zone;
        lblTargetCentreCode.Text = Contact_Source_Center;
        //Contact_Company = ddlcompany.SelectedValue;
        //Contact_Source_Division = ddlsourcedivision.SelectedValue;
        //Contact_Source_Zone = ddlsourcezone.SelectedValue;
        //Contact_Source_Center = ddlsourcecenter.SelectedValue;
        //Contact_Target_Division = ddltargetdivision.SelectedValue;
        //Contact_Target_Zone = ddltargetzone.SelectedValue;
        //Contact_Target_Center = ddltargetcenter.SelectedValue;

        followupdatefrom = txtfollowupfrm.Text;
        Followupto = txtfollowupto.Text;
        if (chkfollowup.Checked == true)
        {
            Overdue = 1;
        }
        else
        {
            Overdue = 0;
        }


        //New Search Criteria
        string Agefrom = "";
        string Ageto = "";
        string block = "";
        //Dim Onlyblock As String = ""
        string Examinationdetails = "";
        string Scoretype = "";
        string Conditiontype = "";
        string Score = "";
        string Gender = "";
        string acadyear = "";
        string yeareducation = "";
        Gender = ddlgender.SelectedItem.Text;
        Agefrom = txtagefrom.Text;
        Ageto = txtageto.Text;
        block = ddlblocked.SelectedValue;
        Examinationdetails = txtexamdtls.Text;
        Scoretype = ddlscoretype.SelectedValue;
        Conditiontype = ddlcondition.SelectedValue;
        Score = txtscore.Text;
        acadyear = this.ddlacadyear.SelectedValue;
        yeareducation = this.ddlyeareducation.SelectedValue;

        DataSet ds = ProductController.Get_Lead_Contact_Search_Results_New(Leadtypeid, leadStatusid, Leadsourceid, UserID, Contact_Company, Contact_Source_Division, Contact_Source_Zone, Contact_Source_Center, Contact_Target_Division, Contact_Target_Zone,
        Contact_Target_Center, Studentname, Leadcreatedonfrom, Leadcreatedonto, Country, State, City, Customertype, Institutiontype, Board,
        Standard, year, Courseinterested, followupdatefrom, Followupto, Overdue, Agefrom, Ageto, block, Examinationdetails,
        Scoretype, Conditiontype, Score, Gender, acadyear, yeareducation, txtstudentnHandphone1.Text.Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            Divsearchcriteria.Visible = false;
            btnsearchback.Visible = true;
            lblpagetitle1.Text = "Lead";
            lblpagetitle2.Text = "Search Results";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Lead";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = " Lead Search Results";
            //lilastbreadcrumb.Visible = true;
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divsearchresults.Visible = true;
            Divsearchcriteria.Visible = false;
            divmessage.Visible = false;
            //System.Threading.Thread.Sleep(1000)
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            ScriptManager1.RegisterAsyncPostBackControl(Repeater1);
            
        }
        else
        {
            divsearchresults.Visible = false;
            Divsearchcriteria.Visible = true;
            divmessage.Visible = true;
            lblmessage.Text = "No Records Found!";
           
        }
        UpdatePanel3.Update();
    }

    protected void btnaddlead_ServerClick(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(1000)
        Response.Redirect("Lead_Add.aspx");
    }

    protected void btnadd2_ServerClick(object sender, System.EventArgs e)
    {
        //System.Threading.Thread.Sleep(1000)
        Response.Redirect("Lead_Add.aspx");
    }

    protected void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Display")
        {
            //System.Threading.Thread.Sleep(1000)
            string Opportunity_Code = e.CommandArgument.ToString();
            Response.Redirect("Lead_Display.aspx?&Lead_Code=" + Opportunity_Code);
        }
        else if (e.CommandName == "Edit")
        {
            //System.Threading.Thread.Sleep(1000)
            string Opportunity_Code = e.CommandArgument.ToString();
            Response.Redirect("Lead_Edit.aspx?&Lead_Code=" + Opportunity_Code);
        }
        else if (e.CommandName == "Followup")
        {
            //System.Threading.Thread.Sleep(1000)
            string Opportunity_Code = e.CommandArgument.ToString();
            Response.Redirect("Lead_Followup.aspx?&Lead_Code=" + Opportunity_Code);
        }
        else if (e.CommandName == "Block")
        {
            lblnote.Text = "You are about to block a Lead. Please confirm.";
            string Lead_Code = e.CommandArgument.ToString();
            lblleadid.Text = Lead_Code;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#Blocklead').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);

        }
        else if (e.CommandName == "UnBlock")
        {
            lblnote1.Text = "You are about to Unblock a Lead. Please confirm.";
            //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#UnBlocklead').modal('show') });</script>", False)
            string Lead_Code = e.CommandArgument.ToString();
            lblleadid.Text = Lead_Code;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#UnBlocklead').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        }
        else if (e.CommandName == "Convert")
        {
            //System.Threading.Thread.Sleep(1000)
            txtdiscount.Text = "";
            txtdiscountnotes.Text = "";
            txtjoindate.Text = "";
            txtexpectedclosedate.Text = "";
            txtconverteddate.Text = "";
            txtprobabilitypercent.Text = "";
            
            btnback.Visible = true;
            Divsearchcriteria.Visible = false;
            divsearchresults.Visible = false;
            divconvert.Visible = true;
            lblpagetitle1.Text = "Convert to Opportunity";
            lblpagetitle2.Text = "";
            //limidbreadcrumb.Visible = true;
            lblmidbreadcrumb.Text = "Manage Lead";
            //lilastbreadcrumb.Visible = true;
            lbllastbreadcrumb.Text = "Convert to Opportunity";
            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            string Lead_Code = e.CommandArgument.ToString();
            lblleadid.Text = Lead_Code;
            bindddlproductcategory();
            Bindddlsalesstage();
            BindSalesChannel();
            txtconverteddate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtdiscount.Text = "0.00";
            txtprobabilitypercent.Text = "0.00";
            txtconverteddate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Leadid = "";
            txtappno.Enabled = false;
            lblappnoerror.Visible = false;
            BindCompany();
            dynamic Hiphen = "-";
            SqlDataReader dr = ProductController.Getleaddetailsbyleadid(Lead_Code);
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    txtleadtype.Text = dr["leadtype"].ToString();
                    txtleadsource.Text = dr["lead_Source_desc"].ToString();
                    txtleadstatus.Text = dr["lead_status_desc"].ToString();
                    txtconstdname.Text = dr["Con_Firstname"].ToString() + " " + dr["Con_Midname"].ToString() + " " + dr["Con_lastname"].ToString();
                    txtconstdhand1.Text = dr["handphone1"].ToString();
                    txtconstdlandline.Text = dr["landline"].ToString();
                    lblstudentname.Text = Hiphen + " " + dr["Con_Title"].ToString() + " " + dr["Con_FirstName"].ToString() + " " + dr["Con_midname"].ToString() + " " + dr["Con_lastname"].ToString();
                    
                    ddlconvertcompany.SelectedValue = dr["Expr5"].ToString();
                    BindConvertDivision();
                    ddlconvertdivision.SelectedValue = dr["Expr6"].ToString();
                    BindConvertZone();
                    ddlconvertzone.SelectedValue = dr["Expr7"].ToString();
                    BindConvertCenter();
                    ddlconvertcenter.SelectedValue = dr["Expr8"].ToString();
                    BindAcademicYear();
                    if (dr["Expected_Join_AcadYear"].ToString() != "0")
                    {
                        ddlConacademicyear.SelectedValue = dr["Expected_Join_AcadYear"].ToString();
                    }

                    BindStream();
                    BindDiscountconditions();

                    ckhBranchTopper.Checked = false;
                    ckhBranchTopper_CheckedChanged(source, e);
                    chkSchoolRanker.Checked = false;
                    chkSchoolRanker_CheckedChanged(source, e);
                    ckhRankerAdditional.Checked = false;
                    ckhRankerAdditional_CheckedChanged(source, e);
                    ddlbranchtopperdivision.SelectedIndex = 0;
                    ddlbranchtopperCenter.Items.Clear();
                    ddlschoolranker.SelectedIndex = 0;
                    txtschooldivision.Text = "";
                    txtschoolrank.Text = "";
                    ddldiscountconditions.SelectedIndex = 0;

                        
                    //txtjoindate.Text = dr["Time_join"].ToString();
                }
            }
            UpdatePanel3.Update();//Student Name lable in UPdate panel
        }
    }

    protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string Isactive = ((Label)e.Item.FindControl("lblisactive")).Text;
            if (Isactive == "1")
            {
                ((LinkButton)e.Item.FindControl("lnkunblock")).Visible = true;
                //Dim scriptManager__1 As ScriptManager = ScriptManager.GetCurrent(Me.Page)
                //scriptManager__1.RegisterPostBackControl(DirectCast(e.Item.FindControl("lnkunblock"), LinkButton))

                ((HtmlAnchor)e.Item.FindControl("btndisplay")).Visible = false;
                ((HtmlAnchor)e.Item.FindControl("btndedit")).Visible = false;
                ((HtmlAnchor)e.Item.FindControl("btnfollowup")).Visible = false;
                //((LinkButton)e.Item.FindControl("lnkconvert")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkblock")).Visible = false;
                ((Label)e.Item.FindControl("label8")).Visible = false;
                ((Label)e.Item.FindControl("Label4")).Visible = false;

            }
            else
            {
                ((HtmlAnchor)e.Item.FindControl("btndisplay")).Visible = true;
                ((HtmlAnchor)e.Item.FindControl("btndedit")).Visible = true;
                ((HtmlAnchor)e.Item.FindControl("btnfollowup")).Visible = true;
                //((LinkButton)e.Item.FindControl("lnkconvert")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkblock")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkunblock")).Visible = false;
                //((LinkButton)e.Item.FindControl("lnkdisplay")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkedit")).Visible = false;
                //((LinkButton)e.Item.FindControl("lnkfollowup")).Visible = false;
                //ScriptManager scriptManager__1 = ScriptManager.GetCurrent(this.Page);
                //scriptManager__1.RegisterPostBackControl((LinkButton)e.Item.FindControl("lnkconvert"));
                string followupdate = ((Label)e.Item.FindControl("Label4")).Text;
                if (string.IsNullOrEmpty(followupdate))
                {
                    ((Label)e.Item.FindControl("label8")).Visible = true;
                }
                else
                {
                    if (Convert.ToDateTime(ClsCommon.FormatDate(followupdate)) < DateTime.Today)
                    {
                        ((Label)e.Item.FindControl("label8")).Visible = true;
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("label8")).Visible = false;
                    }
                }
                string Leadstatus = ((Label)e.Item.FindControl("Label3")).Text;
                if (Leadstatus == "Lost Lead")
                {
                    ((Label)e.Item.FindControl("Label4")).Visible = false;
                    ((Label)e.Item.FindControl("label8")).Visible = false;
                }
                else
                {
                    ((Label)e.Item.FindControl("Label4")).Visible = true;
                }
            }
        }
    }
    //Protected Sub OpenMPEEdit(ByVal sender As Object, ByVal e As System.EventArgs)
    //    Dim Lead_Code As New LinkButton
    //    lblnote.Text = "You are about to block a Lead. Please confirm."
    //    Lead_Code = DirectCast(sender, LinkButton)
    //    'MPETEST.Text = "ID = " & wLink.CommandArgument
    //    lblleadid.Text = Lead_Code.CommandArgument
    //    'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('Blocklead').modal('show') });</script>", False)
    //    'mpeEdit.Show()
    //End Sub

    private void bindddlproductcategory()
    {
        DataSet ds = ProductController.GetallOpporProductCategory();
        BindDDL(ddlproductcategory, ds, "Description", "ID");
        ddlproductcategory.Items.Insert(0, "Select");
        ddlproductcategory.SelectedIndex = 0;
        if (ds.Tables[0].Rows.Count == 1)
        {
            ddlproductcategory.SelectedValue = ds.Tables[0].Rows[0]["ID"].ToString();
        }
    }
    private void BindSalesChannel()
    {
        DataSet ds = ProductController.GetAllSalesChannel();
        BindDDL(ddlsaleschannel, ds, "Description", "ID");
        ddlsaleschannel.Items.Insert(0, "Select");
        ddlsaleschannel.SelectedIndex = 0;
        if (ds.Tables[0].Rows.Count == 1)
        {
            ddlsaleschannel.SelectedValue = ds.Tables[0].Rows[0]["ID"].ToString();
        }
    }
    private void Bindddlsalesstage()
    {
        DataSet ds = ProductController.GetSalesStage(1);
        BindDDL(ddlsalesstage, ds, "Sales_Stage_Desc", "Sales_Id");
        ddlsalesstage.Items.Insert(0, "Select");
        ddlsalesstage.SelectedIndex = 0;
    }

    protected void ckhBranchTopper_CheckedChanged(object sender, EventArgs e)
    {
        ddlbranchtopperdivision.SelectedIndex = 0;
        ddlbranchtopperCenter.Items.Clear();
        if (ckhBranchTopper.Checked)
        {
            trBranchTopper.Visible = true;
        }
        else
        {
            trBranchTopper.Visible = false;
        }


    }

    protected void ckhRankerAdditional_CheckedChanged(object sender, EventArgs e)
    {
        ddldiscountconditions.SelectedIndex = 0;
        if (ckhRankerAdditional.Checked)
        {
            trDiscount.Visible = true;
        }
        else
        {
            trDiscount.Visible = false;
        }

    }

    protected void ddlbranchtopperdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranchTopperCenter();

    }
    
    private void BindBranchTopperDivision()
    {
        ddlbranchtopperCenter.Items.Clear();
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(8, UserID, "", "", "MT");
        BindDDL(ddlbranchtopperdivision, ds, "Division_Name", "Division_Code");
        ddlbranchtopperdivision.Items.Insert(0, "Select");
        ddlbranchtopperdivision.SelectedIndex = 0;
    }

    private void BindBranchTopperCenter()
    {
        ddlbranchtopperCenter.Items.Clear();

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string divcode = ddlbranchtopperdivision.SelectedValue;

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(11, UserID, divcode, "", "MT");
        BindDDL(ddlbranchtopperCenter, ds, "center_name", "center_code");
        ddlbranchtopperCenter.Items.Insert(0, "Select");
        ddlbranchtopperCenter.SelectedIndex = 0;

    }



    private void BindddlInstitute()
    {
        DataSet ds = ProductController.GetallInstitutename();
        BindDDL(ddlschoolranker, ds, "Institution_Description", "Institution_Description");
        ddlschoolranker.Items.Insert(0, "Select");
        ddlschoolranker.SelectedIndex = 0;
    }


    private void BindDiscountconditions()
    {
        ddldiscountconditions.Items.Clear();
        string division_Code = ddlconvertdivision.SelectedValue;
        string Company_code = ddlconvertcompany.SelectedValue;
        DataSet ds = ProductController.GetDiscount_Types(3, division_Code, Company_code);
        BindDDL(ddldiscountconditions, ds, "Discount_Type_Short_Desc", "Discount_Type");
        ddldiscountconditions.Items.Insert(0, "Select");
        ddldiscountconditions.SelectedIndex = 0;
    }

    protected void chkSchoolRanker_CheckedChanged(object sender, EventArgs e)
    {
        ddlschoolranker.SelectedIndex = 0;
        txtschooldivision.Text = "";
        txtschoolrank.Text = "";
        if (chkSchoolRanker.Checked)
        {
            trSchoolRanker.Visible = true;
        }
        else
        {
            trSchoolRanker.Visible = false;
        }


    }

    protected void ddlsalesstage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindProbabilityPercent();
        if (ddlsalesstage.SelectedValue == "04")
        {
            this.txtappno.Enabled = true;
            this.txtappno.Text = "";
        }
        else
        {
            this.txtappno.Enabled = false;
            this.txtappno.Text = "";
            lblappnoerror.Visible = false;
        }
        ddlsalesstage.Focus();
    }
    private void BindProbabilityPercent()
    {
        SqlDataReader dr = ProductController.GetProbabiltyPercent(ddlsalesstage.SelectedValue);
        if ((((dr) != null)))
        {
            if (dr.Read())
            {
                txtprobabilitypercent.Text = dr["Probability_Percent"].ToString();
            }
        }
    }
    protected void ddlconvertcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindConvertDivision();
        ddlconvertcompany.Focus();
    }
    protected void ddlconvertdivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindConvertZone();
        ddlconvertdivision.Focus();
    }
    protected void ddlconvertzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindConvertCenter();
        ddlconvertzone.Focus();
    }
    protected void ddlconvertcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindAcademicYear();
        ddlconvertcenter.Focus();
    }
    private void BindConvertDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlconvertcompany.SelectedValue);
        BindDDL(ddlconvertdivision, ds, "Division_Name", "Division_Code");
        ddlconvertdivision.Items.Insert(0, "Select");
        ddlconvertdivision.SelectedIndex = 0;
    }
    private void BindConvertZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(3, UserID, ddlconvertdivision.SelectedValue, "", ddlconvertcompany.SelectedValue);
        BindDDL(ddlconvertzone, ds, "Zone_Name", "Zone_Code");
        ddlconvertzone.Items.Insert(0, "Select");
        ddlconvertzone.SelectedIndex = 0;
    }
    private void BindConvertCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddlconvertdivision.SelectedValue, ddlconvertzone.SelectedValue, ddlconvertcompany.SelectedValue);
        BindDDL(ddlconvertcenter, ds, "Center_name", "Center_Code");
        ddlconvertcenter.Items.Insert(0, "Select");
        ddlconvertcenter.SelectedIndex = 0;
    }

    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddlconvertcenter.SelectedValue);
        BindDDL(ddlConacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlConacademicyear.Items.Insert(0, "Select");
        ddlConacademicyear.SelectedIndex = 0;
    }

    protected void ddlConacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindStream();
        ddlConacademicyear.Focus();
    }

    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear(ddlconvertcenter.SelectedValue, ddlConacademicyear.SelectedValue);
        BindDDL(ddlproduct, ds, "Stream_Sdesc", "Stream_Code");
        ddlproduct.Items.Insert(0, "Select");
        ddlproduct.SelectedIndex = 0;
        //To Do
    }

    protected void btnopportunitysubmit_ServerClick(object sender, System.EventArgs e)
    {
        if ((ddlsalesstage.SelectedValue == "04" & string.IsNullOrEmpty(this.txtappno.Text)))
        {
            lblappnoerror.Visible = true;
            lblappnoerror.Text = "Please Enter Application Number !";
            this.txtappno.Focus();
            return;
        }
        else if (ddlsalesstage.SelectedValue == "04")
        {
            //Check For duplicate Application No.
            string Company = "";
            string Division = "";
            string Center = "";
            string Stream = "";
            string app_no = "";
            string Flag = "";

            Company = ddlconvertcompany.SelectedValue;
            Division = ddlconvertdivision.SelectedValue;
            Center = ddlconvertcenter.SelectedValue;
            Stream = ddlproduct.SelectedValue;
            app_no = txtappno.Text;
            Flag = ProductController.CheckDuplicateAppno(Company, Division, Center, Stream, app_no);
            //Flag = "0"
            if (Flag == "0")
            {
                lblappnoerror.Visible = true;
                lblappnoerror.Text = "Application No. already exists!";
                return;
            }
            else
            {
                lblappnoerror.Visible = false;
            }
        }


        if (string.IsNullOrEmpty(txtjoindate.Text))
        {
        }
        else
        {

            try
            {

                if (Convert.ToDateTime(ClsCommon.FormatDate(txtjoindate.Text)) < DateTime.Today)
                {
                    //lbldateerrorJoindate.Visible = True
                    //lbldateerrorJoindate.Text = "Exp. Join Date cannot be a past date"
                    //txtjoindate.Focus()
                    //Exit Sub
                }
            }
            catch (Exception ex)
            {
                lbldateerrorJoindate.Visible = true;
                lbldateerrorJoindate.Text = ex.Message;
                txtjoindate.Focus();
                return;
            }
            try
            {
                if (Convert.ToDateTime(ClsCommon.FormatDate(txtexpectedclosedate.Text)) < DateTime.Today)
                {
                    //lbldateerrorexp.Visible = True
                    //lbldateerrorexp.Text = "Exp. Close Date cannot be a past date"
                    //txtexpectedclosedate.Focus()
                    //lbldateerrorJoindate.Visible = False
                    //Exit Sub
                }
                else
                {
                    lbldateerrorJoindate.Visible = false;
                    lbldateerrorexp.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lbldateerrorexp.Visible = true;
                lbldateerrorexp.Text = ex.Message;
                txtexpectedclosedate.Focus();
                lbldateerrorJoindate.Visible = false;
                return;
            }
        }

        try
        {


            if (string.IsNullOrEmpty(txtexpectedclosedate.Text))
            {
            }
            //else if (Convert.ToDateTime(ClsCommon.FormatDate(txtexpectedclosedate.Text)) < Today)
            //{
            //    //lbldateerrorexp.Visible = True
            //    //lbldateerrorexp.Text = "Exp. Close Date cannot be a past date"
            //    //txtexpectedclosedate.Focus()
            //    //lbldateerrorJoindate.Visible = False
            //    //Exit Sub
            //}
            else
            {
                lbldateerrorJoindate.Visible = false;
                lbldateerrorexp.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lbldateerrorexp.Visible = true;
            lbldateerrorexp.Text = ex.Message;
            txtexpectedclosedate.Focus();
            lbldateerrorJoindate.Visible = false;
            return;
        }




        try
        {
            string Opportunity_Type_Id = "";
            string Opportunity_Name = "";
            string Lead_Code = "";
            string Product_Category = "";
            string Product_Code = "";
            string Sales_Stage = "";
            DateTime Opportunity_Joindate = default(DateTime);
            DateTime Opportunity_Expected_Date = default(DateTime);
            string Opportunity_Probability_Percent = "";
            string Opportunity_Next_Step = "";
            decimal Opportunity_Value = 0;
            decimal Opportunity_Discount = 0;
            string Opp_Contact_Company = "";
            string Opp_Contact_Division = "";
            string Opp_Contact_Center = "";
            dynamic Opp_Contact_Zone = "";
            string Opp_Contact_Id = "";
            string Opp_Contact_Role = "";
            string Opp_Contact_Assignto = "";
            string Created_by = "";
            string Last_Modified_by = "";
            string Opportunity_Code = "";
            string Opp_Status = "";
            string Opp_Status_Id = "";
            string SalesChannel = "";
            string SalesChannel_Id = "";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string OppAcadyear = "";
            string AppNo = "";
            Opp_Contact_Assignto = UserID;
            Lead_Code = lblleadid.Text;
            Product_Category = ddlproductcategory.SelectedItem.Text;
            Product_Code = ddlproductcategory.SelectedValue;
            Sales_Stage = ddlsalesstage.SelectedValue;

            if (string.IsNullOrEmpty(txtjoindate.Text))
            {
                //txtjoindate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                Opportunity_Joindate = Convert.ToDateTime(txtjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            else
            {
                Opportunity_Joindate = Convert.ToDateTime(txtjoindate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            }
            Opportunity_Expected_Date = Convert.ToDateTime(txtexpectedclosedate.Text, System.Globalization.CultureInfo.GetCultureInfo("Hi-IN").DateTimeFormat);
            if (string.IsNullOrEmpty(txtdiscount.Text))
            {
                txtdiscount.Text = "0.00";
            }
            else
            {
                Opportunity_Discount = Convert.ToDecimal(txtdiscount.Text);
            }

            Opportunity_Probability_Percent = txtprobabilitypercent.Text;
            Opp_Contact_Company = ddlconvertcompany.SelectedValue;
            Opp_Contact_Division = ddlconvertdivision.SelectedValue;
            Opp_Contact_Zone = ddlconvertzone.SelectedValue;
            Opp_Contact_Center = ddlconvertcenter.SelectedValue;
            OppAcadyear = ddlConacademicyear.SelectedValue;
            AppNo = txtappno.Text;
            string Oppor_product = "";
            string Oppor_Product_id = "";
            Oppor_product = ddlproduct.SelectedItem.Text;
            Oppor_Product_id = ddlproduct.SelectedValue;
            SalesChannel_Id = ddlsaleschannel.SelectedValue;
            SalesChannel = ddlsaleschannel.SelectedItem.Text;
            string Disc_remark = "";
            Disc_remark = txtdiscountnotes.Text;


            string Is_Branch_Topper = "";
            string Branch_Topper_Division = "";
            string Branch_Topper_Center = "";
            string Is_School_Ranker = "";
            string School_Name = "";
            string School_Division = "";
            string School_Rank = "";
            string Apply_Additional_Discount = "";
            string Discount_Type = "";

            if (ckhBranchTopper.Checked == true)
            {
                Is_Branch_Topper = "1";
                Branch_Topper_Division = ddlbranchtopperdivision.SelectedValue;
                Branch_Topper_Center = ddlbranchtopperCenter.SelectedValue;
            }
            else
            {
                Is_Branch_Topper = "0";
                Branch_Topper_Division = "";
                Branch_Topper_Center = "";
            }
            if (chkSchoolRanker.Checked == true)
            {
                Is_School_Ranker = "1";
                School_Name = ddlschoolranker.SelectedValue;
                School_Division = txtschooldivision.Text;
                School_Rank = txtschoolrank.Text;
            }
            else
            {
                Is_School_Ranker = "0";
                School_Name = "";
                School_Division = "";
                School_Rank = "";
            }

            if (ckhRankerAdditional.Checked == true)
            {
                Apply_Additional_Discount = "1";
                Discount_Type = ddldiscountconditions.SelectedValue;
            }
            else
            {
                Apply_Additional_Discount = "0";
                Discount_Type = "";
            }



            Opportunity_Code = ProductController.Insert_ConvertLeadTo_Opportunity("", "", "", Lead_Code, Product_Category, Product_Code, Sales_Stage, Opportunity_Joindate, Opportunity_Expected_Date, Opportunity_Probability_Percent,
            "", Opportunity_Value, Opportunity_Discount, Opp_Contact_Company, Opp_Contact_Division, Opp_Contact_Center, Opp_Contact_Zone, Opp_Contact_Role, Opp_Contact_Assignto, UserID,
            UserID, Opp_Status, Opp_Status_Id, Oppor_product, Oppor_Product_id, OppAcadyear, AppNo, SalesChannel_Id, SalesChannel, Disc_remark, Is_Branch_Topper, Branch_Topper_Division,
            Branch_Topper_Center,Is_School_Ranker,School_Name,School_Division, School_Rank, Apply_Additional_Discount, Discount_Type);
            
            //System.Threading.Thread.Sleep(500);
            
            bindddlproductcategory();
            Bindddlsalesstage();
            BindSalesChannel();
            BindCompany();
            ddlconvertdivision.SelectedIndex = 0;
            ddlconvertcenter.SelectedIndex = 0;
            ddlConacademicyear.SelectedIndex = 0;
            txtconverteddate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtdiscount.Text = "0";
            ddlproduct.SelectedIndex = 0;
            txtprobabilitypercent.Text = "0.00";
            txtappno.Text = "";
            btnback.Visible = false;
            divconvert.Visible = false;
            //btnopportunitysubmit.Visible = false;
            //btnopportunitycancel.Visible = false;
            //Divsearchcriteria.Visible = false;
            //divsearchresults.Visible = false;
            
            //if (ddlcompany.SelectedValue == "All")
            //{
            //    ddlcompany.SelectedValue = lblTargetCompCode.Text;
            //    ddlcompany_SelectedIndexChanged(sender, e);
            //    ddlsourcedivision.SelectedValue = lblTargetDivCode.Text;
            //    ddlsourcedivision_SelectedIndexChanged(sender, e);
            //    ddlsourcezone.SelectedValue = lblTargetZoanCode.Text;
            //    ddlsourcezone_SelectedIndexChanged(sender, e);
            //    ddlsourcecenter.SelectedValue = lblTargetCentreCode.Text;
            //}
            lblstudentname.Text = "";
            btnsearch_ServerClick(sender,e);
            divSuccessmessage.Visible = true;
            lblsuccessMessage.Text = "Lead successfully converted to Opportunity";
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }
    protected void btncloseleadblock_ServerClick(object sender, System.EventArgs e)
    {
        ScriptManager1.RegisterAsyncPostBackControl(Repeater1);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //sb.Append("<script language='javascript'>")
        //sb.Append("$(function () { $('#Blocklead').modal('show') });")
        //sb.Append("</script>")
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#Blocklead').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);

        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#Blocklead').modal('hide') });</script>", False)
    }

    protected void btnblocklead_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Leadid = "";
        int flag = 0;
        Leadid = lblleadid.Text;
        flag = 1;
        ProductController.Block(UserID, Leadid, flag);
        //divSuccessmessage.Visible = True
        //lblsuccessMessage.Text = "Lead blocked successfully - " & Leadid
        //divsearchresults.Visible = False
        //Divsearchcriteria.Visible = True
        Response.Redirect("Lead.aspx");
    }

    protected void btnopportunitycancel_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Lead.aspx");
    }

    //Search additional field
    private void Country()
    {
        DataSet ds = ProductController.GetallCountry();
        BindDDL(ddlcountrysearch, ds, "Country_Name", "Country_Code");
        ddlcountrysearch.Items.Insert(0, "All");
        ddlcountrysearch.SelectedIndex = 0;
        ddlstatesearch.Items.Insert(0, "All");
        ddlstatesearch.SelectedIndex = 0;
        ddlcitysearch.Items.Insert(0, "All");
        ddlcitysearch.SelectedIndex = 0;
        ddllocationsearch.Items.Insert(0, "All");
        ddllocationsearch.SelectedIndex = 0;
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        State();
    }
    private void State()
    {
        DataSet ds = ProductController.GetallStatebyCountry(ddlcountrysearch.SelectedValue);
        BindDDL(ddlstatesearch, ds, "State_Name", "State_Code");
        ddlstatesearch.Items.Insert(0, "All");
        ddlstatesearch.SelectedIndex = 0;
    }
    protected void ddlstate_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        City();
        //ddlcity.Focus()
    }

    private void City()
    {
        DataSet ds = ProductController.GetallCitybyState(ddlstatesearch.SelectedValue);
        BindDDL(ddlcitysearch, ds, "City_Name", "City_Code");
        ddlcitysearch.Items.Insert(0, "All");
        ddlcitysearch.SelectedIndex = 0;
    }
    protected void ddlcitysearch_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindLocationSearch();
    }
    private void BindLocationSearch()
    {
        DataSet ds = ProductController.GetallLocationbycity(ddlcitysearch.SelectedValue);
        BindDDL(ddllocationsearch, ds, "Location_Name", "Location_Code");
        ddllocationsearch.Items.Insert(0, "All");
        ddllocationsearch.SelectedIndex = 0;
    }
    private void Institutetype()
    {
        DataSet ds = ProductController.GetallInstituteType();
        BindDDL(ddlinstitutiontype1, ds, "Description", "ID");
        ddlinstitutiontype1.Items.Insert(0, "All");
        ddlinstitutiontype1.SelectedIndex = 0;
    }
    private void Board()
    {
        DataSet ds = ProductController.GetallBoard();
        BindDDL(ddlboard1, ds, "Short_Description", "ID");
        ddlboard1.Items.Insert(0, "All");
        ddlboard1.SelectedIndex = 0;
    }

    private void Yearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlyear1, ds, "Description", "ID");
        ddlyear1.Items.Insert(0, "All");
        ddlyear1.SelectedIndex = 0;
    }
    protected void ddlinstitutiontype_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DataSet ds = ProductController.GetallCurrentStudyingin(ddlinstitutiontype1.SelectedValue);
        BindDDL(ddlstandard1, ds, "Description", "ID");
        this.ddlstandard1.Items.Insert(0, "All");
        this.ddlstandard1.SelectedIndex = 0;
        //Me.ddlinstitutiontype.Focus()
    }

    protected void btnsearchlead_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Lead.aspx");
    }

    protected void btnunblockno_ServerClick(object sender, System.EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("$('#UnBlocklead').modal('hide');");
        sb.Append("</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", sb.ToString(), false);
        ScriptManager1.RegisterAsyncPostBackControl(Repeater1);
        //ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "k2", "<script type=""text/javascript"">$(function () { $('#UnBlocklead').modal('hide') });</script>", False)
    }

    protected void btnunblockyes_ServerClick(object sender, System.EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Leadid = "";
        int flag = 0;
        Leadid = lblleadid.Text;
        flag = 3;
        ProductController.Block(UserID, Leadid, flag);
        Response.Redirect("Lead.aspx"); lblpagetitle1.Text = "Lead";
        lblpagetitle2.Text = "Search Criteria / Results";
        //limidbreadcrumb.Visible = true;
        lblmidbreadcrumb.Text = "Manage Lead";
        //lilastbreadcrumb.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        //divSearch.Visible = True
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        divconvert.Visible = false;
        lbldateerrorJoindate.Visible = false;
        lbldateerrorexp.Visible = false;
    }

    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        lblstudentname.Text = "";
        btnback.Visible = false;
        //btnsearch_ServerClick(sender, e);
        Divsearchcriteria.Visible = false;
        btnsearchback.Visible = true;
        lblpagetitle1.Text = "Lead";
        lblpagetitle2.Text = "Search Results";
        //limidbreadcrumb.Visible = true;
        lblmidbreadcrumb.Text = "Manage Lead";
        //lilastbreadcrumb.Visible = true;
        lbllastbreadcrumb.Text = " Lead Search Results";
        //lilastbreadcrumb.Visible = true;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        divsearchresults.Visible = true;
        Divsearchcriteria.Visible = false;
        divmessage.Visible = false;
        divconvert.Visible = false;
    }

    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {
        //if (ddlcompany.SelectedValue == "All")
        //{
        //    ddlcompany.SelectedValue = lblTargetCompCode.Text;
        //    ddlcompany_SelectedIndexChanged(sender, e);
        //    ddlsourcedivision.SelectedValue = lblTargetDivCode.Text;
        //    ddlsourcedivision_SelectedIndexChanged(sender, e);
        //    ddlsourcezone.SelectedValue = lblTargetZoanCode.Text;
        //    ddlsourcezone_SelectedIndexChanged(sender, e);
        //    ddlsourcecenter.SelectedValue = lblTargetCentreCode.Text;
        //}
        lblstudentname.Text = "";
        btnsearchback.Visible = false;
        btnback.Visible = false;
        lblpagetitle1.Text = "Lead";
        lblpagetitle2.Text = "Search Criteria / Results";
        //limidbreadcrumb.Visible = true;
        lblmidbreadcrumb.Text = "Manage Lead";
        //lilastbreadcrumb.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        //divSearch.Visible = True
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        divconvert.Visible = false;
        lbldateerrorJoindate.Visible = false;
        lbldateerrorexp.Visible = false;
    }
}