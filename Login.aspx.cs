using Microsoft.VisualBasic;
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
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!IsPostBack)
        {
            diverror.Visible = false;
            LoginPanel.Visible = true;
            resetpassword.Visible = false;
            
        }
    }
    protected void btnreset_ServerClick(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string newpassword = txtresetpassword.Text;
        DataSet ds = AccountController.Resetpassword(UserID, newpassword);
        if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
        {
           
            LoginPanel.Visible = true;
            resetpassword.Visible = false;
            divnote.Visible = true;
            lblnote.Text = "This password is valid only for 180 days";
        }
        if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
        {

            LoginPanel.Visible = false;
            resetpassword.Visible = true;
            diverror.Visible = true;
            lblerrormsg.Text = " This User Id Is Not Active";
        }
        if (ds.Tables[0].Rows[0]["Result"].ToString() == "-1")
        {

            LoginPanel.Visible = false;
            resetpassword.Visible = true;
            diverror.Visible = true;
            lblerrormsg.Text = "New password should not be your Earlier or Old password";
        }
    }
    protected void btnsubmit_ServerClick(object sender, EventArgs e)
    {
        Login_Service.LoginServiceSoapClient client = new Login_Service.LoginServiceSoapClient();
        try
        {
            HttpCookie LoginInfo = new HttpCookie("MyCookiesLoginInfo");
            string Username = txtusername.Text;
            string password = Request.Form["password"];
            resetpassword.Visible = false;
            if (!string.IsNullOrEmpty(Username))
            {
                if (!String.IsNullOrEmpty(password))
                {
                    object obj = client.ValidateUser(Username, password, "DB01");
                    Login_Service.LoginData Login = (Login_Service.LoginData)obj;
                    String ReturnMessage = Login.Message;
                    String Displayname = Login.DisplayName;
                    String passwordreset = Login.Passwordreset;
                    String userid = Login.UserId ;
                    String Agentid = Login.Agent_Id;
                    String Designation = Login.Designation;
                    String Default_page = "";
                    if (Login.Defaultpage == "")
                    {
                        Default_page = "Dashboard_Center.aspx";   
                    }
                    else
                    {
                        Default_page = Login.Defaultpage;
                    }
                    String Application_Id = Login.Application_Id;
                    
                    if (ReturnMessage == "Success")
                    {

                        string role = client.CheckUserRole(Login.UserId);
                        //Response.Redirect("Homepage.aspx",false );
                        if (!string.IsNullOrEmpty(role))
                        {
                            if (passwordreset == "0")
                            {
                                LoginPanel.Visible = false;
                                resetpassword.Visible = true;
                                LoginInfo["UserID"] = userid;
                                LoginInfo["UserName"] = Displayname;
                                LoginInfo["Expired"] = "1Day";
                                LoginInfo["Agent_Id"] = Agentid;
                                LoginInfo["Default_page"] = Default_page;
                                string user_id = userid;
                                Response.Cookies.Add(LoginInfo);
                                LoginInfo.Expires = DateTime.Now.AddDays(1);
                                string ipaddress;
                                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                                if (ipaddress == "" || ipaddress == null)
                                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                                string Ip = ipaddress;//GetIpAddress();
                                string Compcode = Dns.GetHostName();//GetCompCode();
                                string Browser = Request.Browser.Browser;
                                string Browser_version = Request.Browser.Version;
                                UserController.Insertapplog(user_id, "Login", "Successful Logged In", Ip, Compcode, Browser, Browser_version);
                                diverror.Visible = true;
                                lblerrormsg.Text = "Your current password has expired.Kindly create new password";
                            }
                            else
                            {
                                LoginPanel.Visible = true;
                                resetpassword.Visible = false;
                                LoginInfo["UserID"] = userid;
                                LoginInfo["UserName"] = Displayname;
                                LoginInfo["Expired"] = "1Day";
                                LoginInfo["Agent_Id"] = Agentid;
                                LoginInfo["Default_page"] = Default_page;
                                string user_id = userid;
                                Response.Cookies.Add(LoginInfo);
                                LoginInfo.Expires = DateTime.Now.AddDays(1);
                               
                                string Browser = Request.Browser.Browser ;
                                string Browser_version = Request.Browser.Version;
                                //string redirectpagename="~/" + Default_page;
                                string ipaddress;
                                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                                if (ipaddress == "" || ipaddress == null)
                                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                                string Ip = ipaddress;//GetIpAddress();
                                string Compcode = Dns.GetHostName();//GetCompCode();
                                UserController.Insertapplog(user_id, "Login", "Successful Logged In", Ip, Compcode, Browser, Browser_version);

                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Browser', text: 'Not Compattaable ',class_name: 'gritter-error'});});</script>", false);
            

                                Response.Redirect("~/" + Default_page, false);
                                //Response.Redirect("~/Dashboard_Marketing.aspx", false);
                                //Response.Redirect("~/Homepage.aspx", false);
                               
                                
                            }
                        }
                        else 
                        {
                            diverror.Visible = true;
                            LoginPanel.Visible = true;
                            resetpassword.Visible = false; 
                            lblerrormsg.Text = "Role Not Assigned. Contact Administrator";

                        }
                    }
                    else
                    {
                        diverror.Visible = true;
                        LoginPanel.Visible = true;
                        resetpassword.Visible = false; 
                        lblerrormsg.Text = "Invalid Username or Password";

                    }
                       
                }
            }
              
        }
        catch (Exception Ex)
        {
            diverror.Visible = true;
            LoginPanel.Visible = true;
            resetpassword.Visible = false;
            lblerrormsg.Text = "Connection Unavailable";
        }
    }
    public class LoginData
    {
        public bool IsValid { get; set; }
        public string SessionId { get; set; }
        public List<string> MenuName { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public string Passwordreset { get; set; }
        public string Agent_Id { get; set; }
    }
    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    public static string GetIpAddress()
    {
        // Get IP Address
        string ip = "";
        IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
        IPAddress[] addr = ipEntry.AddressList;
        ip = addr[2].ToString();
        return ip;
    }
    public static string GetCompCode()
    {
        // Get Computer Name
        string strHostName = "";
        strHostName = Dns.GetHostName();
        return strHostName;
    }

}