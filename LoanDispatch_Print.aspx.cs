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

public partial class LoanDispatch_Print : System.Web.UI.Page
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
                //lblpagetitle1.Text = "Dispatch Management";
                //lblpagetitle2.Text = "Print";
                //limidbreadcrumb.Visible = true;
                //lblmidbreadcrumb.Text = "Print";
                //lilastbreadcrumb.Visible = false;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                //listudentstatus.Visible = false;
                lblslipno.Text = Request["Sno"];
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
                //lblusercompany.Text = UserCompany;
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            if (Request["Slip_No"] != null)
            {
                string Slipno = Request["Slip_No"];
                if (Convert.ToInt32(Request["Centre"]) == 1)
                {
                    BindDLLoanDetails(Slipno);
                    divCentrePrint.Visible = true;
                    UpnlprintCentre.Update();
                }
                else
                {
                    divCentrePrint.Visible = true;
                    UpnlprintCentre.Update();
                }
               // Slipdetails(Slipno);
            }
        }

    }


    private void BindDLLoanDetails(string Slipno)
    {
        string Sno = "";
        Sno = Slipno;
        DataSet ds = AccountController.GetLoanDispatchDetailsbySlipno(2, Sno);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCentreName.Text = ds.Tables[0].Rows[0]["Center_Name"].ToString();
            lblDivisionName.Text = ds.Tables[0].Rows[0]["Division"].ToString();
            lblslipdate.Text = ds.Tables[0].Rows[0]["LoanDispatchDate"].ToString();

            dlLoanDisp.DataSource = ds.Tables[1];
            dlLoanDisp.DataBind();
        }
        else
        {
        }
    }

   
    public string GetInWords(decimal num)
    {
        // ERROR: Not supported in C#: OnErrorStatement

        string str = null;
        long subnum = 0;
        TextBox Digits = new TextBox();
        str = "";
        Digits.Text = num.ToString();
        if (Digits.Text.Length > 11)
        {
            str = GetSubInWords(Convert.ToInt64(Digits.Text.Substring(1, Digits.Text.Length - 9)));

            Digits.Text = Digits.Text.Substring(Digits.Text.Length - 9 + 1, 9);

        }

        if (Digits.Text.Length == 11)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Billion ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Billion ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(9, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(10, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 10)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Billion ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Billion ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(8, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(9, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                // str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 9)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(8, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                // str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 8)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 7)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 6)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 5)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }

        if (Digits.Text.Length == 4)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";

        }
        if (Digits.Text.Length == 3)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";

        }
        if (Digits.Text.Length == 2 | Digits.Text.Length == 1)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Rupees only "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Rupees only "
            }
            str = str + " only ";
        }
        if (Digits.Text.Length == 0)
        {
            str = "";
        }

        return str;

    }

    public string GetTens(long num)
    {
        // ERROR: Not supported in C#: OnErrorStatement

        switch ((num))
        {
            case 0:
                return ("");
            case 1:
                return ("One");
            case 2:
                return ("Two");
            case 3:
                return ("Three");
            case 4:
                return ("Four");
            case 5:
                return ("Five");
            case 6:
                return ("Six");
            case 7:
                return ("Seven");
            case 8:
                return ("Eight");
            case 9:
                return ("Nine");
            case 10:
                return ("Ten");
            case 11:
                return ("Eleven");
            case 12:
                return ("Twelve");
            case 13:
                return ("Thirteen");
            case 14:
                return ("Fourteen");
            case 15:
                return ("Fifteen");
            case 16:
                return ("Sixteen");
            case 17:
                return ("Seventeen");
            case 18:
                return ("Eighteen");
            case 19:

                return ("Nineteen");
        }

        return ("");

    }
    public string GetTwenty(long num)
    {
        // ERROR: Not supported in C#: OnErrorStatement

        switch ((num))
        {
            case 0:
                return ("");
            case 1:
                return ("One");
            case 2:
                return ("Twenty");
            case 3:
                return ("Thirty");
            case 4:
                return ("Forty");
            case 5:
                return ("Fifty");
            case 6:
                return ("Sixty");
            case 7:
                return ("Seventy");
            case 8:
                return ("Eighty");
            case 9:

                return ("Ninety");
        }
        return ("");
    }

    public string GetSubInWords(long num)
    {
        // ERROR: Not supported in C#: OnErrorStatement

        string str = null;
        long subnum = 0;
        TextBox Digits = new TextBox();
        str = "";
        Digits.Text = Convert.ToString(num);
        if (Digits.Text.Length == 11)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Billion ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Billion ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(9, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(10, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);

            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);

            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 10)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Billion ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Billion ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(8, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(9, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);

            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);

            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 9)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakhs ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakhs ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(8, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);

            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);

            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 8)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Crores ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Crores ";
            }
            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(7, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);

            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);

            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 7)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(6, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                // str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 6)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);

                str = str + " " + GetTens(subnum % 10);
                str = str + " Lakh ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Lakh ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(5, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 5)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(4, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }

        if (Digits.Text.Length == 4)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Thousand ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Thousand ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(3, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 3)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 1));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                str = str + " Hundred ";
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                str += " Hundred ";
            }

            subnum = Convert.ToInt64(Digits.Text.Substring(2, 2));

            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 2 | Digits.Text.Length == 1)
        {
            subnum = Convert.ToInt64(Digits.Text.Substring(1, 2));
            if (subnum >= 20)
            {
                str = str + GetTwenty(subnum / 10);
                str = str + " " + GetTens(subnum % 10);
                //str = str + " Billions And "
            }
            else if (subnum > 0)
            {
                str += GetTens(subnum);
                //str += " Billions And "
            }
            str += " Billions And ";
        }
        if (Digits.Text.Length == 0)
        {
            str = "";
        }

        return str;
    }
}