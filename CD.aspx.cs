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

public partial class CD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Menuid = "103";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                
                lblpagetitle1.Text = "";
                lblpagetitle2.Text = "";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "";
                //lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Visible = false;
                //lbllastbreadcrumb.Text = "Search Panel";
                //lilastbreadcrumb.Visible = False;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                diverrorsubject.Visible = false;
                divSuccessrsubject.Visible = false;
                upnlStudDetail.Visible = true;
                btnviewenrollment.Disabled = true;
                SqlDataReader dr = UserController.Getuserrights(UserID, Menuid);
                try
                {
                    if ((((dr) != null)))
                    {
                        if (dr.Read())
                        {
                            int allowdisplay = Convert.ToInt32(dr["Allow_Add"].ToString());
                            if (allowdisplay == 1)
                            {
                                //btnaddOpp.Visible = True
                                //btnadd2.Visible = true;
                                //btnimportOpp.Visible = True
                            }
                            else
                            {
                                //btnaddOpp.Visible = False
                                //btnadd2.Visible = false;
                                //btnimportOpp.Visible = False
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
                try
                {
                    divSuccessmessage.Visible = false;
                    divErrormessage.Visible = false;
                    upnlStudDetail.Visible = true;
                    //divSearch.Visible = false;
                    btnviewenrollment.Disabled = false;
                    string Cur_Sb_Code = "";
                    Cur_Sb_Code = Request["Cur_Sb_Code"];
                    //lblcursbcode.Text = Cur_Sb_Code;
                    string Oppid = "";
                    Oppid = Request["Oppid"];
                    string SBEntrycode = Cur_Sb_Code;

                    //string Oppid = ((LinkButton)e.Item.FindControl("lnkdisplay")).CommandArgument;
                    //lbloppid.Text = Oppid;
                    //ProductController.Removerecordsifexists(Oppid, 1, "", "");
                    //HtmlAnchor viewenrollment = btnviewenrollment;
                    //viewenrollment.HRef = "Enrollment_display.aspx?&Oppur_id=" + Oppid;

                    BindStudentdetails(Oppid);
                    Session["Opp_id"] = Oppid;
                   // divBatchChange.Visible = true;
                    divcreatebutton.Visible = true;

                    //Important Do forget to uncomment
                    //divCompulsoryFee.Visible = false;
                    BindConvert(Oppid);
                    BindMandateSubjects();
                    BindCompulsorySubjects();
                    BindOptionalSubject();
                    binddestcenter();
                    BindPayplan();
                    divcreatebutton.Visible = false;
                    Divreselect.Visible = false;
                    Div6.Visible = true;
                    divbtnexit.Visible = false;
                    btnclose.Visible = false;
                    divErrormessage.Visible = false;
                }
                catch (Exception ex)
                {
                    divErrormessage.Visible = true;
                    lblerrormessage.Visible = true;
                    lblerrormessage.Text = ex.Message;
                    Response.Redirect("Errorpages/500.aspx");
                }
                BindConstreamAfterCourseDuration();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            
        }
        GetSumvalue();
       
    }
    private void BindStudentdetails(string Oppid)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Hiphen = "-";
        string Cur_sb_code = Request["Cur_Sb_Code"];
        //Dim dr As SqlDataReader = AccountController.GetStudentDetailsbyOppid(Oppid)
        SqlDataReader dr = AccountController.GetAccountdetailbycursbcode(1, Cur_sb_code);
        try
        {
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    txtConapp.Text = dr["student_app_no"].ToString();
                    txtconAppentrydate.Text = dr["entrydate"].ToString();
                    txtconappsubdate.Text = dr["enrollon"].ToString();
                    txtconstdname.Text = dr["Name"].ToString();
                    lblstudentname.Text = Hiphen + " " + dr["Name"].ToString();
                    BindNationality();
                    ddlnationality.SelectedValue = dr["nationality"].ToString();
                    BindMothertongue();
                    ddlmothertongue.SelectedValue = dr["mother_tongue"].ToString();
                    BindReligion();
                    ddlreligion.SelectedValue = dr["religion"].ToString();
                    BindCaste();
                    ddlcaste.SelectedValue = dr["caste"].ToString();
                    txtconsubcaste.Text = dr["subcaste"].ToString();
                    Bindgroup();
                    ddlgroup.SelectedValue = dr["category"].ToString();
                    string PhysicallyChalleged = dr["physically_challenege"].ToString();
                    if (PhysicallyChalleged == "Y")
                    {
                        ddlphysicalchallenged.SelectedValue = "Y";
                    }
                    else
                    {
                        ddlphysicalchallenged.SelectedValue = "N";
                    }
                    BindStudentfrom();
                    ddlstudentfrom.SelectedValue = dr["student_from"].ToString();
                    BindmediumofInstruction();
                    ddlConmediumofinstr.SelectedValue = dr["medium_instructions"].ToString();
                    //Bindstay()
                    //ddlstay.SelectedValue = dr("stay_preference").ToString
                    BindConYearofpassing();
                    ddlconyearofpassing.SelectedValue = dr["year_passing"].ToString();
                    BindConCompany();
                    ddlconCompany.SelectedValue = dr["company_code"].ToString();
                    BindConDivision();
                    ddlcondivision.SelectedValue = dr["division_code"].ToString();
                    BindConcenters();
                    ddlconcenter.SelectedValue = dr["center_code"].ToString();
                    BindConAcademicYear();
                    ddlconacademicyear.SelectedValue = dr["acad_year"].ToString();
                    BindConstream();
                    ddlconstream.SelectedValue = dr["stream_code"].ToString();
                    lblCurrentStream.Text = dr["stream_code"].ToString();
                    txtopportunitycode.Text = Oppid;
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }

    }

    private void BindConvert(string Oppid)
    {
        string Oppor_id = "";
        Oppor_id = Oppid;
        string Documenttype = "";
        Documenttype = "DC05";
        string Transport = "";
        Transport = "01";
        DataSet ds = AccountController.GetPricingbyOppId(1, Oppor_id, Documenttype, Transport);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlproductHeader.DataSource = ds;
            dlproductHeader.DataBind();
        }
        else
        {
        }
    }

    private void BindMandateSubjects()
    {
    }

    private void BindCompulsorySubjects()
    {
    }

    private void BindOptionalSubject()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string StreamName = "";
        string Center = "";
        StreamName = ddlBatchAfterCourse.SelectedValue;
        Center = ddlconcenter.SelectedValue;

        DataSet ds = ProductController.GetSubjectsbyStreamCode(7, StreamName, Center);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlselective.DataSource = ds;
            dlselective.DataBind();
        }
        else
        {
        }
    }

    private void BindPayplan()
    {
        DataSet ds = AccountController.GetAllPayplan();
        BindDDL(ddlpayplan, ds, "Pay_Plan_Description", "Pay_Plan_Code");
        ddlpayplan.Items.Insert(0, "Select");
        ddlpayplan.SelectedIndex = 0;
        BindDDL(ddlpayplanChange, ds, "Pay_Plan_Description", "Pay_Plan_Code");
        ddlpayplanChange.Items.Insert(0, "Select");
        ddlpayplanChange.SelectedIndex = 0;
        
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void BindNationality()
    {
        DataSet ds = ProductController.GetallNationality();
        BindDDL(ddlnationality, ds, "Description", "id");
        ddlnationality.Items.Insert(0, "Select");
        ddlnationality.SelectedIndex = 0;
    }
    private void BindMothertongue()
    {
        DataSet ds = ProductController.GetallMothertongue();
        BindDDL(ddlmothertongue, ds, "Description", "id");
        ddlmothertongue.Items.Insert(0, "Select");
        ddlmothertongue.SelectedIndex = 0;
    }

    private void BindReligion()
    {
        DataSet ds = ProductController.GetallReligion();
        BindDDL(ddlreligion, ds, "Description", "id");
        ddlreligion.Items.Insert(0, "Select");
        ddlreligion.SelectedIndex = 0;
    }


    private void BindCaste()
    {
        DataSet ds = ProductController.GetallCaste();
        BindDDL(ddlcaste, ds, "Description", "id");
        ddlcaste.Items.Insert(0, "Select");
        ddlcaste.SelectedIndex = 0;
    }
    private void Bindgroup()
    {
        DataSet ds = ProductController.GetallStudentcastegroup();
        BindDDL(ddlgroup, ds, "Description", "id");
        ddlgroup.Items.Insert(0, "Select");
        ddlgroup.SelectedIndex = 0;
    }

    private void Bindstay()
    {
        DataSet ds = ProductController.GetallStay();
        BindDDL(ddlstay, ds, "Description", "id");
        ddlstay.Items.Insert(0, "Select");
        ddlstay.SelectedIndex = 0;
    }


    private void BindmediumofInstruction()
    {
        DataSet ds = ProductController.GetallMediumofInstruction();
        BindDDL(ddlConmediumofinstr, ds, "Description", "id");
        ddlConmediumofinstr.Items.Insert(0, "Select");
        ddlConmediumofinstr.SelectedIndex = 0;
    }
    private void BindStudentfrom()
    {
        DataSet ds = ProductController.GetallResidenceType();
        BindDDL(ddlstudentfrom, ds, "Description", "ID");
        ddlstudentfrom.Items.Insert(0, "Select");
        ddlstudentfrom.SelectedIndex = 0;
    }

    private void BindConYearofpassing()
    {
        DataSet ds = ProductController.GetallYearofpassing();
        BindDDL(ddlconyearofpassing, ds, "Description", "ID");
        ddlconyearofpassing.Items.Insert(0, "Select");
        ddlconyearofpassing.SelectedIndex = 0;
    }

    private void BindConCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(1, UserID, "", "", "");
        BindDDL(ddlconCompany, ds, "Company_Name", "Company_Code");
        ddlconCompany.Items.Insert(0, "Select");
        ddlconCompany.SelectedIndex = 0;
    }
    private void BindConDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", ddlconCompany.SelectedValue);
        BindDDL(ddlcondivision, ds, "Division_Name", "Division_Code");
        ddlcondivision.Items.Insert(0, "Select");
        ddlcondivision.SelectedIndex = 0;
    }

    private void BindConcenters()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(5, UserID, ddlcondivision.SelectedValue, "", ddlconCompany.SelectedValue);
        BindDDL(ddlconcenter, ds, "Center_name", "Center_Code");
        ddlconcenter.Items.Insert(0, "Select");
        ddlconcenter.SelectedIndex = 0;
    }

    private void BindConAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAcademicYearbyCenter(ddlconcenter.SelectedValue);
        BindDDL(ddlconacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlconacademicyear.Items.Insert(0, "Select");
        ddlconacademicyear.SelectedIndex = 0;
    }


    private void BindConstream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All(ddlconcenter.SelectedValue, ddlconacademicyear.SelectedValue);
        BindDDL(ddlconstream, ds, "Stream_Sdesc", "Stream_Code");
        ddlconstream.Items.Insert(0, "Select");
        ddlconstream.SelectedIndex = 0;

    }

    private void BindConstreamAfterCourseDuration()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_AllAfterCourseDuration(ddlconcenter.SelectedValue, ddlconacademicyear.SelectedValue);
        BindDDL(ddlBatchAfterCourse, ds, "Stream_Sdesc", "Stream_Code");
        ddlBatchAfterCourse.Items.Insert(0, "Select");
        ddlBatchAfterCourse.SelectedIndex = 0;

    }

    private void AllDivVisibleFalse()
    {
        ddlconstream.SelectedValue = lblCurrentStream.Text;
        divBatchChange.Visible = false;
        // ddlconstream.Enabled = false;
        tdProduct.Visible = false;
        ddlBatchAfterCourse.Visible = false;
        divPayPlanChange.Visible = false;

        tdProduct.Visible = false;
        ddlBatchAfterCourse.Visible = false;
        ddldestcenter.Visible = false;
        lblDestCenter.Visible = false;
        lblpagetitle1.Text = "";
        lblmidbreadcrumb.Text = "";
        divTransfer.Visible = false;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 

    protected void dlselective_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int Flag = 2;
            string Uomid = "";
            DropDownList d = (DropDownList)e.Item.FindControl("ddluom");
            Label baseuomid = (Label)e.Item.FindControl("lblbaseuomid");
            DataSet ds = ProductController.GetallUom(Flag, baseuomid.Text);
            BindDDL(d, ds, "UOM_DESC", "UOM_Id");
            d.Items.Insert(0, "Select");
            d.SelectedIndex = 0;

            //Dim Selgroup As Label = DirectCast(e.Item.FindControl("lblselgroup"), Label)
            //Dim Sgrgroup As String = Selgroup.Text
            //If Sgrgroup = "1" Then
            //    Dim Chk As CheckBox = DirectCast(e.Item.FindControl("ckhselect1"), CheckBox)
            //    Chk.Checked = True
            //    Chk.Enabled = False
            //End If


        }
    }

    protected void ddltransport_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddltransport.SelectedIndex == 0)
        {
            divBatchChange.Visible = true;
            divcreatebutton.Visible = true;
        }
        else
        {
            divBatchChange.Visible = true;
            string oppid = "";
            oppid = lbloppid.Text;
            BindConvert(oppid);
            BindMandateSubjects();
            BindCompulsorySubjects();
            BindOptionalSubject();
            BindPayplan();
            divcreatebutton.Visible = false;
        }

    }

    protected void ddlpayplan_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlpayplan.SelectedValue == "Select")
        {
            dlselective.Enabled = false;
        }
        else
        {
            dlselective.Enabled = true;
        }
    }

    protected void ddllanguage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //Dim cookie As HttpCookie = Request.Cookies.[Get]("MyCookiesLoginInfo")
        //Dim UserID As String = cookie.Values["UserID"]
        //Dim UserName As String = cookie.Values["UserName"]
        //Dim MaterialCode As String = ""
        //Dim StreamName As String = ""
        //Dim Center As String = ""
        //StreamName = ddlconstream.SelectedValue
        //Center = ddlconcenter.SelectedValue
        //MaterialCode = ddllanguage.SelectedValue

        //Dim dr As SqlDataReader = AccountController.GetlanguageValuebyMaterialCode(Center, StreamName, MaterialCode)
        //Try
        //    If (Not (dr) Is Nothing) Then
        //        If dr.Read Then
        //            txtLangvalue.Text = dr("Voucher_amount").ToString
        //        End If
        //    End If
        //Catch ex As Exception

        //End Try

    }

    protected void btncontinue_ServerClick(object sender, System.EventArgs e)
    {
        if (ddlBatchAfterCourse.SelectedIndex == 0)
        {
            lblconstreamerror.Visible = true;
            lblconstreamerror.Text = "Select New Product";
            return;
        }
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string Hiphen = "-";
        string Cur_sb_code = Request["Cur_Sb_Code"];
        string currentstream = "";
        //Dim dr As SqlDataReader = AccountController.GetStudentDetailsbyOppid(Oppid)
        SqlDataReader dr = AccountController.GetAccountdetailbycursbcode(1, Cur_sb_code);
        try
        {
            if ((((dr) != null)))
            {
                if (dr.Read())
                {
                    //BindConstream();
                    //ddlconstream.SelectedValue = dr["stream_code"].ToString();
                    currentstream = dr["stream_code"].ToString();
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
        if (ddlBatchAfterCourse.SelectedValue == currentstream)
        {
            lblconstreamerror.Visible = true;
            lblconstreamerror.Text = "Same Stream Cannot be Selected";
        }
        else
        {

            lblconstreamerror.Visible = false;
            object obj = null;
            CheckBox Chk = default(CheckBox);
            Label lblSelectmaterialcode = default(Label);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            string Sgrcode = "";
            CheckBox cb = default(CheckBox);



            foreach (DataListItem li in dlselective.Items)
            {
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblSelectmaterialcode = (Label)obj;
                }

                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblSelectmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {
                diverrorsubject.Visible = false;
                lblerrorsub.Visible = false;
                divcreatebutton.Visible = true;
                string Opp_id = "";
                string Doctype = "";
                int Flag = 0;
                Label lblfmaterialcode = null;
                Label lblvouchertype = null;
                TextBox txtvoucheramt = null;
                Label Baseuomdesc = null;
                Label baseuomid = null;
                DropDownList Unit = default(DropDownList);
                TextBox Quantity = null;
                TextBox Amount = null;
                TextBox Remark = null;

                Opp_id = Request["Cur_Sb_Code"] + "P"; // Session["Opp_id"].ToString();
                Flag = 1;
                Doctype = "DC05";
                string Stream = ddlconstream.SelectedValue;

                foreach (DataListItem li in dlselective.Items)
                {
                    obj = li.FindControl("lblmaterialcodeadd");
                    if (obj != null)
                    {
                        lblfmaterialcode = (Label)obj;
                    }

                    obj = li.FindControl("lblvoucher_typ");
                    if (obj != null)
                    {
                        lblvouchertype = (Label)obj;
                    }

                    obj = li.FindControl("txtvoucheramt");
                    if (obj != null)
                    {
                        txtvoucheramt = (TextBox)obj;
                    }

                    obj = li.FindControl("lblbaseuom");
                    if (obj != null)
                    {
                        Baseuomdesc = (Label)obj;
                    }

                    obj = li.FindControl("lblbaseuomid");
                    if (obj != null)
                    {
                        baseuomid = (Label)obj;
                    }

                    obj = li.FindControl("ddluom");
                    if (obj != null)
                    {
                        Unit = (DropDownList)obj;
                    }

                    obj = li.FindControl("txtquantity");
                    if (obj != null)
                    {
                        Quantity = (TextBox)obj;
                    }

                    obj = li.FindControl("txttotalvalue");
                    if (obj != null)
                    {
                        Amount = (TextBox)obj;
                    }

                    obj = li.FindControl("txtremark");
                    if (obj != null)
                    {
                        Remark = (TextBox)obj;
                    }

                    cb = (CheckBox)li.FindControl("ckhselect1");
                    if (cb != null)
                    {
                        Chk = (CheckBox)cb;
                    }

                    if (Chk.Checked == true)
                    {
                        AccountController.InserttoGetPricingprocedurevaluebyoppidStreamChange(Opp_id, lblfmaterialcode.Text, lblvouchertype.Text, txtvoucheramt.Text, baseuomid.Text, Baseuomdesc.Text, Unit.SelectedValue, Quantity.Text, Amount.Text, Remark.Text,
                        Doctype, Flag, Stream);
                    }
                }


                int flag2 = 2;
                if (ddlpayplan.SelectedIndex == 1)
                {
                    flag2 = 3;
                }
                else
                {
                    flag2 = 2;
                }
                DataSet ds = AccountController.GetPricingprocedureHeaderValue_NewStreamChange(Opp_id, Sgrcode, "", "", "", "", "", "", "", "", "DC05", flag2, Stream);

                ///Handle CRF and Robomate fees///
                ///
                DataSet ds1 = AccountController.GetFeesComponent(1, Opp_id);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dlppheader.DataSource = ds1;
                    dlppheader.DataBind();
                    ddlpayplan.Enabled = false;
                    ddllanguage.Enabled = false;
                    dlselective.Enabled = false;
                    Divreselect.Visible = true;
                    //divfeedetails.Visible = True
                    btnreselect.Visible = true;
                    Div6.Visible = false;
                    dlppheader.Visible = true;
                    divcreatebutton.Visible = true;
                    //divpersonalinfo.Visible = False
                    divfeedetails.Visible = true;
                    ddlEvent.Enabled = false;
                    ddlBatchAfterCourse.Enabled = false;
                    //tdProduct.Visible = false; 
                    //ddlBatchAfterCourse.Visible = false;
                    //ddlconstream.Enabled = false;
                }
                else
                {
                }
            }
            else
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Select Product";
                //diverrorsubject.Visible = True
                //lblerrorsub.Visible = True
                //lblerrorsub.Text = "Select Product"

            }
            divErrormessage.Visible = false;
        }
    }

    protected void btncreateaccount_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Cur_sb_code = Request["Cur_Sb_Code"];
            string Accountid = AccountController.GetAccountidbysbentrycode(Cur_sb_code);
            //lblaccountid.Text = Accountid;
            string MandateSubjects = "";
            string OptionalSubjects = "";
            string Selectivesubjects = "";
            MandateSubjects = lblmaterialcode.Text;
            OptionalSubjects = ddllanguage.SelectedValue;
            object obj = null;
            CheckBox Chk = default(CheckBox);
            Label lblSelectmaterialcode = default(Label);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            string Sgrcode = "";
            CheckBox cb = default(CheckBox);
            foreach (DataListItem li in dlselective.Items)
            {
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblSelectmaterialcode = (Label)obj;
                }

                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblSelectmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {
                diverrorsubject.Visible = false;
                lblerrorsub.Visible = false;
                divcreatebutton.Visible = true;
                string MaterialCode = "";
                string Doctype = "";
                string Opp_id = "";
                string Payplan = "";
                //HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                //string UserID = cookie.Values["UserID"];
                //string UserName = cookie.Values["UserName"];
                Opp_id = txtopportunitycode.Text;// Session["Opp_id"].ToString();
                string cbcode = Request["Cur_Sb_Code"] + "P";
                //MaterialCode = MandateSubjects + "," + OptionalSubjects + "," + Sgrcode;
                MaterialCode = Sgrcode;
                Doctype = "DC05";
                Payplan = ddlpayplan.SelectedValue;
                //string Accountid = "";
                //string Accountid = lblaccountid.Text;
                string Stream = ddlBatchAfterCourse.SelectedValue;
                Accountid = AccountController.StreamChange(Opp_id, MaterialCode, Doctype, Payplan, UserID, Stream, Accountid, cbcode);
                //Accountid = AccountController.CreateAccount(Opp_id, MaterialCode, Doctype, Payplan, UserID);
                //DataSet ds1 = AccountController.GetStudentreceiptbySBEntrycode(1, Request["Cur_Sb_Code"],UserID );

                int flag = 1;
                string sbentrycode = Request["Cur_Sb_Code"];
                ProductController.EventSTS(sbentrycode);

                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Product Changed - Proceed to Manage Account";

                upnlStudDetail.Visible = false;
                BtnOk.Visible = true;
                btncreateaccount.Visible = false;
                btnreselect.Visible = false;
                divbtnexit.Visible = true;
                btnclose.Visible = true;
                divErrormessage.Visible = false;
                ddlEvent.Enabled = true;
                tdProduct.Visible = true; 
                ddlBatchAfterCourse.Visible = true;
                ddlBatchAfterCourse.Enabled = true;


            }
            else
            {
                diverrorsubject.Visible = true;
                lblerrorsub.Visible = true;
                lblerrorsub.Text = "Select Subject Group";
            }

            
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void btnreselect_ServerClick(object sender, System.EventArgs e)
    {
        ddlpayplan.Enabled = true;
        ddllanguage.Enabled = true;
        dlselective.Enabled = true;
        Divreselect.Visible = false;
        btnreselect.Visible = false;
        Div6.Visible = true;
        dlppheader.Visible = false;
        divcreatebutton.Visible = false;
        ProductController.Removerecordsifexists(lbloppid.Text, 1, "", "");
        ddlEvent.Enabled = true;
        tdProduct.Visible = true; 
        ddlBatchAfterCourse.Visible = true;
        ddlBatchAfterCourse.Enabled = true;
        //divpersonalinfo.Visible = True
        //divfeedetails.Visible = False
    }

    protected void btnclose_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }

    private void GetSumvalue()
    {

        try
        {

            Object obj = default(Object);
            Object obj1 = default(Object);
            CheckBox chk = null;
            Label lblsid = default(Label);
            Label lblbaseuomid = default(Label);
            Label lblselgroup = default(Label);
            Label lblvouchermode = default(Label);
            RequiredFieldValidator regularvalidator = default(RequiredFieldValidator);
            RequiredFieldValidator r2 = default(RequiredFieldValidator);
            CompareValidator C1 = default(CompareValidator);
            TextBox lblquantity = default(TextBox);
            TextBox lblvoucheramt = default(TextBox);
            TextBox lblamt = default(TextBox);
            TextBox txttotal = default(TextBox);
            DropDownList ddluom1 = default(DropDownList);
            string Totalvalue = "";
            int Sum = 0;
            int Count = 0;
            //Dim Quant As TextBox

            foreach (DataListItem li in dlselective.Items)
            {
                obj = li.FindControl("ckhselect1");
                if (obj != null)
                {
                    chk = (CheckBox)obj;
                }

                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblsid = (Label)obj;
                }

                obj = li.FindControl("txtquantity");
                if (obj != null)
                {
                    lblquantity = (TextBox)obj;
                    try
                    {
                        int.Parse(lblquantity.Text);

                    }
                    catch (Exception ex)
                    {
                        divErrormessage.Visible = true;
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "Quantity can only be in Number";
                    }
                }

                obj = li.FindControl("txtvoucheramt");
                if (obj != null)
                {
                    lblvoucheramt = (TextBox)obj;
                }

                obj = li.FindControl("lblbaseuomid");
                if (obj != null)
                {
                    lblbaseuomid = (Label)obj;
                }

                obj = li.FindControl("txttotalvalue");
                if (obj != null)
                {
                    txttotal = (TextBox)obj;
                }

                obj = li.FindControl("ddluom");
                if (obj != null)
                {
                    ddluom1 = (DropDownList)obj;
                    if (ddluom1.SelectedValue == "Select")
                    {
                        lblquantity.Enabled = false;
                    }
                    else
                    {
                        lblquantity.Enabled = true;
                    }
                }

                obj = li.FindControl("lblselgroup");
                if (obj != null)
                {
                    lblselgroup = (Label)obj;
                    if (lblselgroup.Text == "1")
                    {
                        chk.Checked = true;
                        chk.Enabled = false;
                        lblquantity.Enabled = false;
                        if (ddluom1.SelectedValue == "01")
                        {
                            try
                            {
                                int.Parse(lblquantity.Text);
                                Sum = Sum + Convert.ToInt32(lblquantity.Text);
                                string Uomid = "";
                                SqlDataReader dr = ProductController.GetallUomReader(2, ddluom1.SelectedValue);
                                if ((((dr) != null)))
                                {
                                    if (dr.Read())
                                    {
                                        Uomid = dr["UOM_Value"].ToString();
                                    }
                                }
                                Totalvalue = (decimal.Parse(lblvoucheramt.Text) * int.Parse(lblquantity.Text) * int.Parse(Uomid)).ToString();
                                txttotal.Text = Totalvalue;
                            }
                            catch (Exception ex)
                            {
                                divErrormessage.Visible = true;
                                lblerrormessage.Visible = true;
                                lblerrormessage.Text = "Quantity can only be in Number";
                            }

                        }
                        else if (ddluom1.SelectedValue == "02")
                        {
                            Sum = Sum + Convert.ToInt32(lblquantity.Text);
                            string Uomid = "";
                            SqlDataReader dr = ProductController.GetallUomReader(2, ddluom1.SelectedValue);
                            if ((((dr) != null)))
                            {
                                if (dr.Read())
                                {
                                    Uomid = dr["UOM_Value"].ToString();
                                }
                            }
                            Totalvalue = (decimal.Parse(lblvoucheramt.Text) * int.Parse(lblquantity.Text) * int.Parse(Uomid)).ToString();
                            txttotal.Text = Totalvalue;



                        }
                        else if (ddluom1.SelectedValue == "03")
                        {
                            Sum = Sum + Convert.ToInt32(lblquantity.Text);
                            string Uomid = "";
                            SqlDataReader dr = ProductController.GetallUomReader(2, ddluom1.SelectedValue);
                            if ((((dr) != null)))
                            {
                                if (dr.Read())
                                {
                                    Uomid = dr["UOM_Value"].ToString();
                                }
                            }
                            Totalvalue = (decimal.Parse(lblvoucheramt.Text) * int.Parse(lblquantity.Text) * int.Parse(Uomid)).ToString();
                            txttotal.Text = Totalvalue;
                        }

                    }
                }

                obj = li.FindControl("lblvoucher_mode");
                if (obj != null)
                {
                    lblvouchermode = (Label)obj;
                    if (lblvouchermode.Text == "A")
                    {
                        lblvoucheramt.Enabled = false;
                    }
                    else if (lblvouchermode.Text == "M")
                    {
                        lblvoucheramt.Enabled = true;
                    }
                }

                obj = li.FindControl("RequiredFieldValidator35");
                if (obj != null)
                {
                    regularvalidator = (RequiredFieldValidator)obj;
                }

                obj = li.FindControl("r2");
                if (obj != null)
                {
                    r2 = (RequiredFieldValidator)obj;
                }

                obj = li.FindControl("CompareValidator1");
                if (obj != null)
                {
                    C1 = (CompareValidator)obj;
                }

                if (chk.Checked == true)
                {
                    if (lblselgroup.Text == "1")
                    {
                        ddluom1.Enabled = true;
                        lblvoucheramt.Enabled = false;
                    }
                    else
                    {
                        ddluom1.Enabled = true;
                        regularvalidator.Visible = true;

                        if (ddluom1.SelectedValue == "Select")
                        {
                            lblquantity.Enabled = false;

                        }
                        else
                        {
                            lblquantity.Enabled = true;
                            r2.Visible = true;
                            C1.Visible = true;
                            if (string.IsNullOrEmpty(lblquantity.Text))
                            {

                            }
                            else
                            {
                                //If ddluom1.SelectedValue = "01" Then

                                Sum = Sum + Convert.ToInt32(lblquantity.Text);
                                string Uomid = "";
                                SqlDataReader dr = ProductController.GetallUomReader(3, ddluom1.SelectedValue);
                                if ((((dr) != null)))
                                {
                                    if (dr.Read())
                                    {
                                        Uomid = dr["UOM_Value"].ToString();
                                    }
                                }
                                Totalvalue = (decimal.Parse(lblvoucheramt.Text) * int.Parse(lblquantity.Text) * int.Parse(Uomid)).ToString();
                                txttotal.Text = Totalvalue;
                            }
                            lblquantity.Enabled = true;
                        }
                    }

                }
                else
                {
                    ddluom1.Enabled = false;
                    ddluom1.SelectedIndex = 0;
                    //lblquantity.Text = "0"
                    txttotal.Text = "0";
                    lblquantity.Enabled = false;
                    regularvalidator.Visible = false;
                    r2.Visible = false;
                    C1.Visible = false;
                }
            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Additioncal Code for Stream Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlconstream_SelectedIndexChanged(object sender, System.EventArgs e)
    {


        lblconstreamerror.Visible = false;
        BindMandateSubjects();
        BindCompulsorySubjects();
        BindOptionalSubject();
        BindPayplan();
    }


    protected void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEvent.SelectedValue == "1")
        {
            divBatchChange.Visible = true;
           // ddlconstream.Enabled = true;
            divfeedetails.Visible = false;
            
            divPayPlanChange.Visible = false;
            divTransfer.Visible = false;

            lblpagetitle1.Text = "Change Stream";
            lblmidbreadcrumb.Text = "Change Stream";
            tdProduct.Visible = true;
            ddlBatchAfterCourse.Visible = true;
            ddldestcenter.Visible = false;
            lblDestCenter.Visible = false;
        }
        else if (ddlEvent.SelectedValue == "2")
        {
            divBatchChange.Visible = false;
            // ddlconstream.Enabled = true;
            divfeedetails.Visible = false;            
            divPayPlanChange.Visible = true;
            divTransfer.Visible = false;

            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divPayPlanerrorsubject.Visible = false;
            divPayPlanSuccessrsubject.Visible = false;
            divPayPlancreatebutton.Visible = false;


            DivPayPlanreselect.Visible = false;
            Div7.Visible = true;
            divPayPlanbtnexit.Visible = false;
            btnPayPlanclose.Visible = false;
            divErrormessage.Visible = false;
            dlPayPlanselective.Enabled = false;

            BindPayPlanOptionalSubject();
            lblpagetitle1.Text = "Pay Plan Change";
            lblmidbreadcrumb.Text = "Pay Plan Change";

            tdProduct.Visible = false;
            ddlBatchAfterCourse.Visible = false;
            ddldestcenter.Visible = false;
            lblDestCenter.Visible = false;
        }
        else if (ddlEvent.SelectedValue == "3")
        {
             divBatchChange.Visible = false;
           // ddlconstream.Enabled = true;
            divfeedetails.Visible = false;
            
            divPayPlanChange.Visible = false;
            divTransfer.Visible = true;

            divSuccessmessage.Visible = false;
            divErrormessage.Visible = false;
            divTransfererrorsubject.Visible = false;
            divTransferSuccessrsubject.Visible = false;
            div1.Visible = true;
            divTransfercreatebutton.Visible = false;
            DivTransferreselect.Visible = false;
            Div10.Visible = true;
            divTransferbtnexit.Visible = false;
            btnTransferclose.Visible = false;
            divErrormessage.Visible = false;

            lblpagetitle1.Text = "Transfer";
            lblmidbreadcrumb.Text = "Transfer";
            tdProduct.Visible = false;
            ddlBatchAfterCourse.Visible = false;
            ddldestcenter.Visible = true;
            lblDestCenter.Visible = true;
        }
        else
        {
            AllDivVisibleFalse();
        }
    }

    protected void ddlBatchAfterCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblconstreamerror.Visible = false;
        BindMandateSubjects();
        BindCompulsorySubjects();
        BindOptionalSubject();
        BindPayplan();
    }


    protected void ddlpayplanChange_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (ddlpayplanChange.SelectedValue == "Select")
        {
            dlPayPlanselective.Enabled = false;

        }
        else
        {
            dlPayPlanselective.Enabled = false;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Hiphen = "-";
            string Cur_sb_code = Request["Cur_Sb_Code"];
            string currentpayplan = "";
            //Dim dr As SqlDataReader = AccountController.GetStudentDetailsbyOppid(Oppid)
            SqlDataReader dr = AccountController.GetAccountdetailbycursbcode(1, Cur_sb_code);
            try
            {
                if ((((dr) != null)))
                {
                    if (dr.Read())
                    {
                        currentpayplan = dr["payplan"].ToString();
                    }

                }
                divErrormessage.Visible = false;
            }
            catch (Exception ex)
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = ex.Message;
            }
            if (ddlpayplanChange.SelectedValue != currentpayplan)
            {
                dlPayPlanselective.Enabled = false;
                lblpayplanerror.Visible = false;
                BindMandateSubjects();
                BindCompulsorySubjects();
                BindPayPlanOptionalSubject();
                //BindPayplan();
                object obj = null;
                CheckBox Chk = default(CheckBox);
                Label lblSelectmaterialcode = default(Label);
                List<string> list = new List<string>();
                List<string> List1 = new List<string>();
                string Sgrcode = "";
                CheckBox cb = default(CheckBox);
                foreach (DataListItem li in dlPayPlanselective.Items)
                {
                    obj = li.FindControl("lblmaterialcodeadd");
                    if (obj != null)
                    {
                        lblSelectmaterialcode = (Label)obj;
                    }

                    cb = (CheckBox)li.FindControl("ckhselect1");
                    if (cb != null)
                    {
                        Chk = (CheckBox)cb;
                        Chk.Checked = true;
                    }

                    //if (Chk.Checked == true)
                    //{
                    //    list.Add(lblSelectmaterialcode.Text);
                    //    Sgrcode = string.Join(",", list.ToArray());

                    //}
                }
            }
            else
            {
                lblpayplanerror.Visible = true;
                lblpayplanerror.Text = "Student Cannot select the current payplan";
            }
        }
    }


    private void BindPayPlanOptionalSubject()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string StreamName = "";
        string Center = "";
        StreamName = ddlconstream.SelectedValue;
        Center = ddlconcenter.SelectedValue;
        string SBentrycode = "";
        SBentrycode = Request["Cur_Sb_Code"];
        DataSet ds = ProductController.GetproductsforPayplan(1, StreamName, Center, SBentrycode, UserID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlPayPlanselective.DataSource = ds;
            dlPayPlanselective.DataBind();
        }
        else
        {
        }
    }


    protected void ddlPayPlanlanguage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //Dim cookie As HttpCookie = Request.Cookies.[Get]("MyCookiesLoginInfo")
        //Dim UserID As String = cookie.Values["UserID"]
        //Dim UserName As String = cookie.Values["UserName"]
        //Dim MaterialCode As String = ""
        //Dim StreamName As String = ""
        //Dim Center As String = ""
        //StreamName = ddlconstream.SelectedValue
        //Center = ddlconcenter.SelectedValue
        //MaterialCode = ddllanguage.SelectedValue

        //Dim dr As SqlDataReader = AccountController.GetlanguageValuebyMaterialCode(Center, StreamName, MaterialCode)
        //Try
        //    If (Not (dr) Is Nothing) Then
        //        If dr.Read Then
        //            txtPayPlanLangvalue.Text = dr("Voucher_amount").ToString
        //        End If
        //    End If
        //Catch ex As Exception

        //End Try

    }


    protected void btnPayPlancontinue_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            object obj = null;
            CheckBox Chk = default(CheckBox);
            Label lblSelectmaterialcode = default(Label);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            string Sgrcode = "";
            CheckBox cb = default(CheckBox);



            foreach (DataListItem li in dlPayPlanselective.Items)
            {
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblSelectmaterialcode = (Label)obj;
                }

                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblSelectmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {
                divPayPlanerrorsubject.Visible = false;
                lblPayPlanerrorsub.Visible = false;
                divPayPlancreatebutton.Visible = true;
                string Opp_id = "";
                string Doctype = "";
                int Flag = 0;
                Label lblfmaterialcode = null;
                Label lblvouchertype = null;
                TextBox txtvoucheramt = null;
                Label Baseuomdesc = null;
                Label baseuomid = null;
                DropDownList Unit = default(DropDownList);
                TextBox Quantity = null;
                TextBox Amount = null;
                TextBox Remark = null;
                TextBox txtnewquantity = null;
                //string Orderid = AccountController.Getorderid();
                //lblOrderid.Text = Orderid;
                //Opp_id = Request["Cur_Sb_Code"];
                Flag = 1;
                Doctype = "DC05";
                Opp_id = Request["Cur_Sb_Code"] + "P"; // Session["Opp_id"].ToString();
                //Flag = 1;
                //Doctype = "DC05";
                //string Stream = ddlconstream.SelectedValue;

                string Stream = ddlconstream.SelectedValue;
                foreach (DataListItem li in dlPayPlanselective.Items)
                {
                    obj = li.FindControl("lblmaterialcodeadd");
                    if (obj != null)
                    {
                        lblfmaterialcode = (Label)obj;
                    }

                    obj = li.FindControl("lblvoucher_typ");
                    if (obj != null)
                    {
                        lblvouchertype = (Label)obj;
                    }

                    obj = li.FindControl("txtvoucheramt");
                    if (obj != null)
                    {
                        txtvoucheramt = (TextBox)obj;
                    }

                    obj = li.FindControl("lbluomdesc");
                    if (obj != null)
                    {
                        Baseuomdesc = (Label)obj;
                    }

                    obj = li.FindControl("lblbaseuomid");
                    if (obj != null)
                    {
                        baseuomid = (Label)obj;
                    }

                    Label uomid = null;
                    obj = li.FindControl("lbluomid");
                    if (obj != null)
                    {
                        uomid = (Label)obj;
                    }

                    obj = li.FindControl("txtquantity");
                    if (obj != null)
                    {
                        Quantity = (TextBox)obj;
                    }

                    obj = li.FindControl("txttotalvalue");
                    if (obj != null)
                    {
                        Amount = (TextBox)obj;
                    }

                    //obj = li.FindControl("txtnewqty");
                    //if (obj != null)
                    //{
                    //    txtnewquantity = (TextBox)obj;
                    //}


                    obj = li.FindControl("txtremark");
                    if (obj != null)
                    {
                        Remark = (TextBox)obj;
                    }

                    cb = (CheckBox)li.FindControl("ckhselect1");
                    if (cb != null)
                    {
                        Chk = (CheckBox)cb;
                    }


                    if (Chk.Checked == true)
                    {
                        //String ac = "true";
                        AccountController.InserttoGetPricingprocedurevaluebyoppidStreamChange(Opp_id, lblfmaterialcode.Text, lblvouchertype.Text, txtvoucheramt.Text, baseuomid.Text, Baseuomdesc.Text, uomid.Text, Quantity.Text, txtvoucheramt.Text, Remark.Text,
                                            Doctype, Flag, Stream);
                    }
                }
                int flag2 = 2;
                if (ddlpayplanChange.SelectedIndex == 1)
                {
                    flag2 = 3;
                }
                else
                {
                    flag2 = 2;
                }


                DataSet ds = AccountController.GetPricingprocedureHeaderValue_NewStreamChange(Opp_id, Sgrcode, "", "", "", "", "", "", "", "", "DC05", flag2, Stream);
                DataSet ds1 = AccountController.GetFeesComponent(1, Opp_id);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dlPayPlanppheader.DataSource = ds1;
                    dlPayPlanppheader.DataBind();
                    ddlpayplanChange.Enabled = false;
                    ddlPayPlanlanguage.Enabled = false;
                    dlPayPlanselective.Enabled = false;
                    DivPayPlanreselect.Visible = true;
                    //divPayPlanfeedetails.Visible = True
                    btnPayPlanreselect.Visible = true;
                    Div7.Visible = false;
                    dlPayPlanppheader.Visible = true;
                    divPayPlancreatebutton.Visible = true;
                    //divpersonalinfo.Visible = False
                    ddlEvent.Enabled = false;
                }
                else
                {
                }
            }
            else
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Select Product";
                //divPayPlanerrorsubject.Visible = True
                //lblPayPlanerrorsub.Visible = True
                //lblPayPlanerrorsub.Text = "Select Product"

            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }

    }


    protected void btnPayPlanreselect_ServerClick(object sender, System.EventArgs e)
    {
        ddlpayplanChange.Enabled = true;
        ddlPayPlanlanguage.Enabled = true;
        dlPayPlanselective.Enabled = true;
        DivPayPlanreselect.Visible = false;
        btnPayPlanreselect.Visible = false;
        Div7.Visible = true;
        dlPayPlanppheader.Visible = false;
        divPayPlancreatebutton.Visible = false;
        ddlEvent.Enabled = true;
        ProductController.Removerecordsifexists(lbloppid.Text, 1, "", "");
        //divpersonalinfo.Visible = True
        //divPayPlanfeedetails.Visible = False
    }


    protected void btnPayPlancreateaccount_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Cur_sb_code = Request["Cur_Sb_Code"];
            string Accountid = AccountController.GetAccountidbysbentrycode(Cur_sb_code);
            string MandateSubjects = "";
            string OptionalSubjects = "";
            string Selectivesubjects = "";
            MandateSubjects = lblmaterialcode.Text;
            OptionalSubjects = ddlPayPlanlanguage.SelectedValue;
            object obj = null;
            CheckBox Chk = default(CheckBox);
            Label lblSelectmaterialcode = default(Label);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            string Sgrcode = "";
            CheckBox cb = default(CheckBox);
            foreach (DataListItem li in dlPayPlanselective.Items)
            {
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblSelectmaterialcode = (Label)obj;
                }

                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblSelectmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {

                divPayPlanerrorsubject.Visible = false;
                lblPayPlanerrorsub.Visible = false;
                divPayPlancreatebutton.Visible = true;
                string MaterialCode = "";
                string Doctype = "";
                string Opp_id = "";
                string Payplan = "";

                Opp_id = txtopportunitycode.Text;// Session["Opp_id"].ToString();
                string cbcode = Request["Cur_Sb_Code"] + "P";

                MaterialCode = Sgrcode;
                Doctype = "DC05";
                Payplan = ddlpayplanChange.SelectedValue;

                string Stream = ddlconstream.SelectedValue;
                int flag2 = 2;
                if (ddlpayplanChange.SelectedIndex == 1)
                {
                    flag2 = 3;
                }
                else
                {
                    flag2 = 2;
                }
                Accountid = AccountController.Payplan(Opp_id, MaterialCode, Doctype, Payplan, UserID, Stream, Accountid, cbcode, flag2);
                //int flag = 1;
                string sbentrycode = Request["Cur_Sb_Code"];
                ProductController.EventSTS(sbentrycode);
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Student Transfered - Proceed to Manage Account";
                btnPayPlancreateaccount.Visible = false;
                btnPayPlanreselect.Visible = false;
                divPayPlanbtnexit.Visible = true;
                btnPayPlanclose.Visible = true;
                divErrormessage.Visible = false;
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Pay Plan Changed - Proceed to Manage Account";
                btnPayPlancreateaccount.Visible = false;
                btnPayPlanreselect.Visible = false;
                divPayPlanbtnexit.Visible = true;
                btnPayPlanclose.Visible = true;
                divErrormessage.Visible = false;
                ddlEvent.Enabled = true;
                upnlStudDetail.Visible = false;
                BtnOk.Visible = true;
                AllDivVisibleFalse();
            }
            else
            {
                divPayPlanerrorsubject.Visible = true;
                lblPayPlanerrorsub.Visible = true;
                lblPayPlanerrorsub.Text = "Select Subject Group";
            }




        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }

    protected void btnPayPlanclose_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }

    protected void BtnOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }

    protected void ddlpayplanTransfer_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        dlTransferselective.Enabled = false;
        //lblpayplanerror.Visible = false ;
        BindMandateSubjects();
        BindCompulsorySubjects();
        BindTransferOptionalSubject();
        //BindPayplan();
        object obj = null;
        CheckBox Chk = default(CheckBox);
        Label lblSelectmaterialcode = default(Label);
        List<string> list = new List<string>();
        List<string> List1 = new List<string>();
        string Sgrcode = "";
        CheckBox cb = default(CheckBox);
        foreach (DataListItem li in dlTransferselective.Items)
        {
            obj = li.FindControl("lblmaterialcodeadd");
            if (obj != null)
            {
                lblSelectmaterialcode = (Label)obj;
            }

            cb = (CheckBox)li.FindControl("ckhselect1");
            if (cb != null)
            {
                Chk = (CheckBox)cb;
                Chk.Checked = true;
            }

            //if (Chk.Checked == true)
            //{
            //    list.Add(lblSelectmaterialcode.Text);
            //    Sgrcode = string.Join(",", list.ToArray());

            //}

        }
    }

    private void BindTransferOptionalSubject()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string StreamName = "";
        string Center = "";
        StreamName = ddlconstream.SelectedValue;
        Center = ddlconcenter.SelectedValue;
        string SBentrycode = "";
        SBentrycode = Request["Cur_Sb_Code"];
        DataSet ds = ProductController.GetproductsforPayplan(1, StreamName, Center, SBentrycode, UserID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlTransferselective.DataSource = ds;
            dlTransferselective.DataBind();
        }
        else
        {
        }
    }

    protected void ddlTransferlanguage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //Dim cookie As HttpCookie = Request.Cookies.[Get]("MyCookiesLoginInfo")
        //Dim UserID As String = cookie.Values["UserID"]
        //Dim UserName As String = cookie.Values["UserName"]
        //Dim MaterialCode As String = ""
        //Dim StreamName As String = ""
        //Dim Center As String = ""
        //StreamName = ddlconstream.SelectedValue
        //Center = ddlconcenter.SelectedValue
        //MaterialCode = ddllanguage.SelectedValue

        //Dim dr As SqlDataReader = AccountController.GetlanguageValuebyMaterialCode(Center, StreamName, MaterialCode)
        //Try
        //    If (Not (dr) Is Nothing) Then
        //        If dr.Read Then
        //            txtLangvalue.Text = dr("Voucher_amount").ToString
        //        End If
        //    End If
        //Catch ex As Exception

        //End Try

    }

    protected void btnTransfercontinue_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            object obj = null;
            CheckBox Chk = default(CheckBox);
            Label lblSelectmaterialcode = default(Label);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            string Sgrcode = "";
            CheckBox cb = default(CheckBox);



            foreach (DataListItem li in dlTransferselective.Items)
            {
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblSelectmaterialcode = (Label)obj;
                }

                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblSelectmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {
                divTransfererrorsubject.Visible = false;
                lblTransfererrorsub.Visible = false;
                divTransfercreatebutton.Visible = true;
                string Opp_id = "";
                string Doctype = "";
                int Flag = 0;
                Label lblfmaterialcode = null;
                Label lblvouchertype = null;
                TextBox txtvoucheramt = null;
                Label Baseuomdesc = null;
                Label baseuomid = null;
                DropDownList Unit = default(DropDownList);
                TextBox Quantity = null;
                TextBox Amount = null;
                TextBox Remark = null;
                TextBox txtnewquantity = null;
                //string Orderid = AccountController.Getorderid();
                //lblOrderid.Text = Orderid;
                //Opp_id = Request["Cur_Sb_Code"];
                Flag = 1;
                Doctype = "DC05";
                Opp_id = Request["Cur_Sb_Code"] + "P"; // Session["Opp_id"].ToString();
                //Flag = 1;
                //Doctype = "DC05";
                //string Stream = ddlconstream.SelectedValue;

                string Stream = ddlconstream.SelectedValue;
                foreach (DataListItem li in dlTransferselective.Items)
                {
                    obj = li.FindControl("lblmaterialcodeadd");
                    if (obj != null)
                    {
                        lblfmaterialcode = (Label)obj;
                    }

                    obj = li.FindControl("lblvoucher_typ");
                    if (obj != null)
                    {
                        lblvouchertype = (Label)obj;
                    }

                    obj = li.FindControl("txtvoucheramt");
                    if (obj != null)
                    {
                        txtvoucheramt = (TextBox)obj;
                    }

                    obj = li.FindControl("lbluomdesc");
                    if (obj != null)
                    {
                        Baseuomdesc = (Label)obj;
                    }

                    obj = li.FindControl("lblbaseuomid");
                    if (obj != null)
                    {
                        baseuomid = (Label)obj;
                    }

                    Label uomid = null;
                    obj = li.FindControl("lbluomid");
                    if (obj != null)
                    {
                        uomid = (Label)obj;
                    }

                    obj = li.FindControl("txtquantity");
                    if (obj != null)
                    {
                        Quantity = (TextBox)obj;
                    }

                    obj = li.FindControl("txttotalvalue");
                    if (obj != null)
                    {
                        Amount = (TextBox)obj;
                    }

                    //obj = li.FindControl("txtnewqty");
                    //if (obj != null)
                    //{
                    //    txtnewquantity = (TextBox)obj;
                    //}


                    obj = li.FindControl("txtremark");
                    if (obj != null)
                    {
                        Remark = (TextBox)obj;
                    }

                    cb = (CheckBox)li.FindControl("ckhselect1");
                    if (cb != null)
                    {
                        Chk = (CheckBox)cb;
                    }


                    if (Chk.Checked == true)
                    {
                        //String ac = "true";
                        AccountController.InserttoGetPricingprocedurevaluebyoppidStreamChange(Opp_id, lblfmaterialcode.Text, lblvouchertype.Text, txtvoucheramt.Text, baseuomid.Text, Baseuomdesc.Text, uomid.Text, Quantity.Text, txtvoucheramt.Text, Remark.Text,
                                            Doctype, Flag, Stream);
                    }
                }
                int flag2 = 2;
                if (ddlpayplanTransfer.SelectedIndex == 1)
                {
                    flag2 = 3;
                }
                else
                {
                    flag2 = 2;
                }


                DataSet ds = AccountController.GetPricingprocedureHeaderValue_NewStreamChange(Opp_id, lblfmaterialcode.Text, "", "", "", "", "", "", "", "", "DC05", flag2, Stream);
                DataSet ds1 = AccountController.GetFeesComponent(1, Opp_id);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dlTranfserppheader.DataSource = ds1;
                    dlTranfserppheader.DataBind();
                    ddlpayplanTransfer.Enabled = false;
                    ddlTransferlanguage.Enabled = false;
                    dlTransferselective.Enabled = false;
                    DivTransferreselect.Visible = true;
                    //divTransferfeedetails.Visible = True
                    btnTransferreselect.Visible = true;
                    Div10.Visible = false;
                    dlTranfserppheader.Visible = true;
                    divTransfercreatebutton.Visible = true;
                    //divpersonalinfo.Visible = False
                    ddlEvent.Enabled = false;
                    ddldestcenter.Enabled = false;
                }
                else
                {
                }
            }
            else
            {
                divErrormessage.Visible = true;
                lblerrormessage.Visible = true;
                lblerrormessage.Text = "Select Product";
                //diverrorsubject.Visible = True
                //lblerrorsub.Visible = True
                //lblerrorsub.Text = "Select Product"

            }
            divErrormessage.Visible = false;
        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }

    }


    protected void btnTransferreselect_ServerClick(object sender, System.EventArgs e)
    {
        ddlpayplanTransfer.Enabled = true;
        ddlTransferlanguage.Enabled = true;
        dlTransferselective.Enabled = true;
        DivTransferreselect.Visible = false;
        btnTransferreselect.Visible = false;
        Div10.Visible = true;
        dlTranfserppheader.Visible = false;
        divTransfercreatebutton.Visible = false;
        ProductController.Removerecordsifexists(lbloppid.Text, 1, "", "");
        ddlEvent.Enabled = true;
        ddldestcenter.Enabled = true;       
        //divpersonalinfo.Visible = True
        //divfeedetails.Visible = False
    }

    protected void btnTransfercreateaccount_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Cur_sb_code = Request["Cur_Sb_Code"];
            string Accountid = AccountController.GetAccountidbysbentrycode(Cur_sb_code);
            string MandateSubjects = "";
            string OptionalSubjects = "";
            string Selectivesubjects = "";
            MandateSubjects = lblmaterialcode.Text;
            OptionalSubjects = ddlTransferlanguage.SelectedValue;
            object obj = null;
            CheckBox Chk = default(CheckBox);
            Label lblSelectmaterialcode = default(Label);
            List<string> list = new List<string>();
            List<string> List1 = new List<string>();
            string Sgrcode = "";
            CheckBox cb = default(CheckBox);
            foreach (DataListItem li in dlTransferselective.Items)
            {
                obj = li.FindControl("lblmaterialcodeadd");
                if (obj != null)
                {
                    lblSelectmaterialcode = (Label)obj;
                }

                cb = (CheckBox)li.FindControl("ckhselect1");
                if (cb != null)
                {
                    Chk = (CheckBox)cb;
                }

                if (Chk.Checked == true)
                {
                    list.Add(lblSelectmaterialcode.Text);
                    Sgrcode = string.Join(",", list.ToArray());

                }
            }
            if (Sgrcode.Length > 0)
            {
                //diverrorsubject.Visible = false;
                //lblerrorsub.Visible = false;
                //divcreatebutton.Visible = true;
                //string MaterialCode = "";
                //string Doctype = "";
                //string Opp_id = "";
                //string Payplan = "";
                ////HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                ////string UserID = cookie.Values["UserID"];
                ////string UserName = cookie.Values["UserName"];
                //Opp_id = lbloppid.Text;// Session["Opp_id"].ToString();
                //MaterialCode = MandateSubjects + "," + OptionalSubjects + "," + Sgrcode;
                //Doctype = "DC05";
                //Payplan = ddlpayplan.SelectedValue;
                //string Accountid = "";
                //Accountid = AccountController.CreateAccount(Opp_id, MaterialCode, Doctype, Payplan, UserID);
                divTransfererrorsubject.Visible = false;
                lblTransfererrorsub.Visible = false;
                divTransfercreatebutton.Visible = true;
                string MaterialCode = "";
                string Doctype = "";
                string Opp_id = "";
                string Payplan = "";
                //HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                //string UserID = cookie.Values["UserID"];
                //string UserName = cookie.Values["UserName"];
                Opp_id = txtopportunitycode.Text;// Session["Opp_id"].ToString();
                string cbcode = Request["Cur_Sb_Code"] + "P";
                //MaterialCode = MandateSubjects + "," + OptionalSubjects + "," + Sgrcode;
                MaterialCode = Sgrcode;
                Doctype = "DC05";
                Payplan = ddlpayplanTransfer.SelectedValue;
                //string Accountid = "";
                //string Accountid = lblaccountid.Text;
                string Stream = ddlconstream.SelectedValue;
                Accountid = AccountController.Transfer(Opp_id, MaterialCode, Doctype, Payplan, UserID, Stream, Accountid, cbcode, ddldestcenter.SelectedValue);
                int flag = 1;
                string sbentrycode = Request["Cur_Sb_Code"];
                ProductController.EventSTS(sbentrycode);
                divSuccessmessage.Visible = true;
                lblsuccessMessage.Visible = true;
                lblsuccessMessage.Text = "Student Transfered - Proceed to Manage Account";
                btnTransfercreateaccount.Visible = false;
                btnTransferreselect.Visible = false;
                divTransferbtnexit.Visible = true;
                btnTransferclose.Visible = true;
                divErrormessage.Visible = false;
                ddlEvent.Enabled = true;
                upnlStudDetail.Visible = false;
                ddldestcenter.Enabled = true;
                BtnOk.Visible = true;
            }
            else
            {
                divTransfererrorsubject.Visible = true;
                lblTransfererrorsub.Visible = true;
                lblTransfererrorsub.Text = "Select Subject Group";
            }


        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            lblerrormessage.Visible = true;
            lblerrormessage.Text = ex.Message;
        }
    }


    protected void btnTransferclose_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }

    protected void ddldestcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindTransferPayplan();
    }
    private void BindTransferPayplan()
    {
        DataSet ds = AccountController.GetAllPayplan();
        BindDDL(ddlpayplanTransfer, ds, "Pay_Plan_Description", "Pay_Plan_Code");
        ddlpayplanTransfer.Items.Insert(0, "Select");
        ddlpayplanTransfer.SelectedIndex = 0;
    }


    private void binddestcenter()
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.Get_Center_By_Company_Division_Stream(ddlconCompany.SelectedValue, ddlcondivision.SelectedValue, ddlconstream.SelectedValue, 1);
        BindDDL(ddldestcenter, ds, "Center_name", "Center_Code");
        ddldestcenter.Items.Insert(0, "Select");
        ddldestcenter.SelectedIndex = 0;

    }
}