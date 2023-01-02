using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
using System.Data.SqlClient;


public partial class Cheque_Management_Reconciled : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlType.SelectedIndex = 1;
                ControlVisibility("Search");
                BindDivision();
                BindAcadYear();
            }
        }
        #endregion

        #region Methods

                
        /// <summary>
        /// Fill drop down list and assign value and Text
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="txtField"></param>
        /// <param name="valField"></param>
        private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = txtField;
            ddl.DataValueField = valField;
            ddl.DataBind();
        }

        /// <summary>
        /// Fill List box and assign value and Text
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="txtField"></param>
        /// <param name="valField"></param>
        private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = txtField;
            ddl.DataValueField = valField;
            ddl.DataBind();
        }

        /// <summary>
        /// Clear Error Success Box
        /// </summary>
        private void Clear_Error_Success_Box()
        {
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            lblSuccess.Text = "";
            lblerror.Text = "";
            UpdatePanelMsgBox.Update();
        }


        /// <summary>
        /// Show Error or success box on top base on boxtype and Error code
        /// </summary>
        /// <param name="BoxType">BoxType</param>
        /// <param name="Error_Code">Error_Code</param>
        private void Show_Error_Success_Box(string BoxType, string Error_Code)
        {
            if (BoxType == "E")
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = ProductController.Raise_Error(Error_Code);
                UpdatePanelMsgBox.Update();
            }
            else
            {
                Msg_Success.Visible = true;
                Msg_Error.Visible = false;
                lblSuccess.Text = ProductController.Raise_Error(Error_Code);
                UpdatePanelMsgBox.Update();
            }
        }


        private void ControlVisibility(string Mode)
        {
            if (Mode == "Search")
            {
                DivSearchPanel.Visible = true;
                DivResultPanel.Visible = false;                
                BtnShowSearchPanel.Visible = false;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;
            }
            else if (Mode == "Result")
            {
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;                
                BtnShowSearchPanel.Visible = true;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;                
            }            

        }


        

       
        /// <summary>
        /// Bind search  Datalist
        /// </summary>
        private void FillGrid()
        {
            try
            {
                Clear_Error_Success_Box();

                
                

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];

                DataSet ds = PaymentController.Get_Cheque_Management_Reconcile(ddlDivision.SelectedValue, ddlZone.SelectedValue, ddlCenter.SelectedValue, ddlAcadYear.SelectedValue, txtSBEntryCode.Text, ddlType.SelectedValue, UserID, "1");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ControlVisibility("Result");
                        dlGridDisplay.DataSource = ds;
                        dlGridDisplay.DataBind();
                        if (ddlType.SelectedValue == "Reconcile")
                        {
                            lblHeader.Text = "Total Reconcile Records:";
                        }
                        else
                        {
                            lblHeader.Text = "Total Not Reconcile Records:";
                        }
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Records not found.");
                        UpdatePanelMsgBox.Update();
                        return;
                    }
                }



                if (ds != null)
                {
                    if (ds.Tables.Count != 0)
                    {
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            lbltotalcount.Text = (ds.Tables[0].Rows.Count).ToString();
                        }
                        else
                        {
                            lbltotalcount.Text = "0";
                        }
                    }
                    else
                    {
                        lbltotalcount.Text = "0";
                    }
                }
                else
                {
                    lbltotalcount.Text = "0";
                }


                
            }
            catch (Exception ex)
            {

                Show_Error_Success_Box("E",ex.ToString());
                UpdatePanelMsgBox.Update();
                return;
            }
        }

       private void BindDivision()
       {        
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(2, UserID, "", "", "MT");
            BindDDL(ddlDivision, ds, "Division_Name", "Division_Code");
            ddlDivision.Items.Insert(0, "All");
            ddlDivision.SelectedIndex = 0;
            ddlZone.Items.Clear();
            ddlZone.Items.Insert(0, "All");
            ddlZone.SelectedIndex = 0;
            ddlCenter.Items.Clear();
            ddlCenter.Items.Insert(0, "All");
            ddlCenter.SelectedIndex = 0;
       }

        private void BindZone()
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(9, "", ddlDivision.SelectedValue, "", "MT");
            BindDDL(ddlZone, ds, "Zone_Name", "Zone_Code");
            ddlZone.Items.Insert(0, "All");
            ddlZone.SelectedIndex = 0;
            ddlCenter.Items.Clear();
            ddlCenter.Items.Insert(0, "All");
            ddlCenter.SelectedIndex = 0;
        }
    
        private void BindCenter()
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            DataSet ds = ProductController.GetUser_Company_Division_Zone_Center(4, UserID, ddlDivision.SelectedValue, ddlZone.SelectedValue, "MT");
            BindDDL(ddlCenter, ds, "Center_name", "Center_Code");
            ddlCenter.Items.Insert(0, "All");
            ddlCenter.SelectedIndex = 0;
        }

        private void BindAcadYear()
        {
            DataSet ds = ProductController.GetAllCurrentyear();
            BindDDL(ddlAcadYear, ds, "Description", "ID");
            ddlAcadYear.Items.Insert(0, "All");
            ddlAcadYear.SelectedIndex = 0;
        }

        #endregion


       
        #region Event's
      

        protected void BtnClearSearch_Click(object sender, EventArgs e)
        {
            ddlDivision.SelectedIndex = 0;
            ddlAcadYear.SelectedIndex = 0;
            ddlZone.Items.Clear();
            ddlCenter.Items.Clear();
            ddlZone.Items.Insert(0, "All");
            ddlZone.SelectedIndex = 0;
            ddlCenter.Items.Insert(0, "All");
            ddlCenter.SelectedIndex = 0;
            txtSBEntryCode.Text = "";
            ddlType.SelectedIndex = 1;
        }
            
        protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
        {
            ControlVisibility("Search");
        }
         

        protected void BtnSearch_Click(object sender, EventArgs e)
        {            
            FillGrid();
        }
    
        protected void ddlDivision_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            BindZone();            
        }
    
        protected void ddlZone_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            BindCenter();
        }

        #endregion



        
}
