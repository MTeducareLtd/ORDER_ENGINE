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
//using Encryption.BL;


public partial class Event_Change : System.Web.UI.Page
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
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                upnlconvert.Visible = true;
                //System.Threading.Thread.Sleep(1000)
                //listudentstatus.Visible = False
                //btnviewenrollment.Visible = false;
                //liregno.Visible = False
                //Dim Orderid As String = AccountController.Getorderid()
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
                                //btnaddlead.Visible = True
                                //btnimportlead.Visible = True
                            }
                            else
                            {
                                //btnaddlead.Visible = False
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
                //BindCompany()
                //BindPayplan();
                //BindProductCategory()
                //StudentType()
                //Institutetype()
                //CountrySearch()
                //Board()
                //Eventtype()
                lblpagetitle1.Text = "Add Product";
                lblpagetitle2.Text = "";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Manage Account";
                //lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Text = "Add Product";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                upnlconvert.Visible = false;
                diverrorsubject.Visible = false;
                divSuccessrsubject.Visible = false;
                //listudentstatus.Visible = True
                string Cur_Sb_Code = "";
                Cur_Sb_Code = Request["Cur_Sb_Code"];
                lblcursbcode.Text = Cur_Sb_Code;
                string Oppid = "";
                Oppid = Request["Oppid"];
                string SBEntrycode = Cur_Sb_Code;
                //Dim Opportunity_Code As String = AccountController.GetOppidbysbentrycode(SBEntrycode)
                //lbloppurid.Text = Oppid
                string Accountid = AccountController.GetAccountidbysbentrycode(SBEntrycode);
                //lblaccountid.Text = Accountid
                lbloppid.Text = Oppid;
                //HtmlAnchor viewenrollment = btnviewenrollment;
                //viewenrollment.HRef = "Enrollment_display.aspx?&Opportunity_Code=" & Oppid
                upnlconvert.Visible = true;
                //btnviewenrollment.Visible = false;
                BindStudentdetails(Oppid);
                Session["Opp_id"] = Oppid;
                div5.Visible = true;
                divcreatebutton.Visible = true;

                //Important Do forget to uncomment

                BindConvert(Oppid);
                BindMandateSubjects();
                BindCompulsorySubjects();
                BindOptionalSubject();
                //BindPayplan();
                divcreatebutton.Visible = false;
                Divreselect.Visible = false;
                Div6.Visible = true;
                divbtnexit.Visible = false;
                btnclose.Visible = false;
                //ProductController.Removerecordsifexists(lblcursbcode.Text, 2, "Add", lblOrderid.Text)
                //ProductController.Removerecordsifexists(lblcursbcode.Text, 2, "Add")
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }
        GetSumvalue();

    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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
                    BindPayplan();
                    ddlpayplan.SelectedValue = dr["Payplan"].ToString();
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
    private void BindPayplan()
    {
        DataSet ds = AccountController.GetAllPayplan();
        BindDDL(ddlpayplan, ds, "Pay_Plan_Description", "Pay_Plan_Code");
        ddlpayplan.Items.Insert(0, "Select");
        ddlpayplan.SelectedIndex = 0;
    }
    //Protected Sub ddlpayplan_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlpayplan.SelectedIndexChanged
    //    If ddlpayplan.SelectedValue = "Select" Then
    //        dlselective.Enabled = False
    //    Else
    //        dlselective.Enabled = True
    //    End If
    //End Sub
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
        StreamName = ddlconstream.SelectedValue;
        Center = ddlconcenter.SelectedValue;
        string sbentrycode = Request["Cur_Sb_Code"];
        DataSet ds = ProductController.GetproductsforAdd(1, StreamName, Center, sbentrycode, UserID);
        //DataSet ds = ProductController.GetSubjectsbyStreamCode(7, StreamName, Center);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dlselective.DataSource = ds;
            dlselective.DataBind();
        }
        else
        {
        }
    }


    protected void ddllanguage_SelectedIndexChanged(object sender, System.EventArgs e)
    {
    }

    protected void btncontinue_ServerClick(object sender, System.EventArgs e)
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
                string Orderid = AccountController.Getorderid();
                lblOrderid.Text = Orderid;
                Opp_id = lblcursbcode.Text;
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
                        AccountController.InserttoGetPricingprocedurevaluebyoppid_AddRemove(Opp_id, lblfmaterialcode.Text, lblvouchertype.Text, txtvoucheramt.Text, baseuomid.Text, Baseuomdesc.Text, Unit.SelectedValue, Quantity.Text, Amount.Text, Remark.Text,
                        Doctype, Flag, Stream, "Add", Orderid);
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


                DataSet ds = AccountController.GetPricingprocedureHeaderValue_AddRemove(Opp_id, "", "", "", "", "", "", "", "", "", "DC05", 2, Stream, "Add", Orderid);

                //DataSet ds = AccountController.GetPricingprocedureHeaderValue_AddRemove(Opp_id, "", "", "", "", "", "", "", "", "","DC05", 2, Stream, "Add", Orderid);
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
    protected void btncreateaccount_ServerClick(object sender, System.EventArgs e)
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
                string cbcode = Request["Cur_Sb_Code"];
                Opp_id = Request["Cur_Sb_Code"];
                MaterialCode = MandateSubjects + "," + OptionalSubjects + "," + Sgrcode;
                Doctype = "DC05";
                Payplan = ddlpayplan.SelectedValue;
                string Stream = ddlconstream.SelectedValue;
                string Orderno = lblOrderid.Text;
                ProductController.InsertAddandRemoveItem(Opp_id, Stream, 1, Orderno);
                //Accountid = AccountController.Payplan(Opp_id, MaterialCode, Doctype, Payplan, UserID, Stream, Accountid, cbcode);
                //Accountid = AccountController.Addevent(Opp_id, MaterialCode, Doctype, Payplan, UserID, Stream, Accountid, cbcode,Orderno );
            }
            else
            {
                diverrorsubject.Visible = true;
                lblerrorsub.Visible = true;
                lblerrorsub.Text = "Select Product";
            }

            divSuccessmessage.Visible = true;
            lblsuccessMessage.Visible = true;
            lblsuccessMessage.Text = "New Product successfully added - Proceed to Manage Account'";
            btncreateaccount.Visible = false;
            btnreselect.Visible = false;
            divbtnexit.Visible = true;
            btnclose.Visible = true;
            divErrormessage.Visible = false;
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
        ProductController.Removerecordsifexists(lblcursbcode.Text, 2, "Add", lblOrderid.Text);
        //divpersonalinfo.Visible = True
        //divfeedetails.Visible = False
    }

    protected void btnclose_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }

}