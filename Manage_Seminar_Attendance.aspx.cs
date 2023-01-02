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


public partial class Manage_Seminar_Attendance : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {             
                ControlVisibility("Search");
               // BindDDLSeminarDetail();
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
                DivAttendancePanel.Visible = false;
                BtnShowSearchPanel.Visible = false;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;
            }            
            else if (Mode == "Attendance")
            {
                DivSearchPanel.Visible = false;
                DivAttendancePanel.Visible = true;
                BtnShowSearchPanel.Visible = true;
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;
            }


        }

        //private void BindDDLSeminarDetail()
        //{
        //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        //    string User_Code = cookie.Values["UserID"];
        //    string Flag = "1";
        //    DataSet ds = ProductController.Get_Seminar_Detail(User_Code, Flag);
        //    BindDDL(ddlSeminar, ds, "Seminar_Name", "Seminar_Id");
        //    ddlSeminar.Items.Insert(0, "Select");
        //    ddlSeminar.SelectedIndex = 0;
        //}

      
        /// <summary>
        /// Bind search  Datalist
        /// </summary>
        private void FillGrid()
        {
            try
            {
                Clear_Error_Success_Box();

                ControlVisibility("Attendance");

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];

                DataSet ds = ProductController.Get_Student_Seminar_Attendance(1, "", UserID,txtSeminarDate123.Value);
                if (ds != null)
                {
                    dlSeminarAttendance.DataSource = ds.Tables[0];
                    dlSeminarAttendance.DataBind();

                    lblSummary_TotalSeminarStudent.Text = ds.Tables[1].Rows[0]["TotalSeminarStudent"].ToString();
                    lblSummary_PresentCount.Text = ds.Tables[1].Rows[0]["PresentCount"].ToString();
                    lblSummary_AbsentCount.Text = ds.Tables[1].Rows[0]["AbsentCount"].ToString();
                    lblSummary_NMCount.Text = ds.Tables[1].Rows[0]["NotMarkedCount"].ToString();

                    foreach (DataListItem dtlItem in dlSeminarAttendance.Items)
                    {

                        DropDownList ddlabsentreason = (DropDownList)dtlItem.FindControl("ddlabsentreason");
                        ddlabsentreason.SelectedIndex = 0;
                        DataSet ds1 = ProductController.GetAllAbsentreasons();

                        BindDDL(ddlabsentreason, ds1, "AbsentReason_Name", "AbsentReason");
                        ddlabsentreason.Items.Insert(0, "Select");
                        ddlabsentreason.SelectedIndex = 0;
                        Label lblDLAbsentReasonID = (Label)dtlItem.FindControl("lblDLAbsentReasonID");
                        // Label lblDLAbsentReason = (Label)dtlItem.FindControl("lblDLAbsentReason");
                        // lblDLAbsentReason.Text = ddlabsentreason.SelectedIndex.ToString();
                        if (lblDLAbsentReasonID.Text != "")
                        {
                            ddlabsentreason.SelectedValue = lblDLAbsentReasonID.Text;
                        }
                    }
                }

                
            }
            catch (Exception ex)
            {

                Show_Error_Success_Box("E",ex.ToString());
                //Msg_Error.Visible = true;
                //Msg_Success.Visible = false;
                //lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
                return;
            }
        }


       

        #endregion


       
        #region Event's
      

        protected void BtnClearSearch_Click(object sender, EventArgs e)
        {
           // ddlSeminar.SelectedIndex = 0;
            txtSeminarDate123.Value = "";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ControlVisibility("Search");
        }

        protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
        {
            ControlVisibility("Search");
        }

       
      

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();
            //if (ddlSeminar.SelectedIndex == 0)
            //{
            //    Show_Error_Success_Box("E", "Select Seminar");
            //    return;
            //}

            if (txtSeminarDate123.Value == "")
            {
                Show_Error_Success_Box("E", "Select Seminar Date");
                return;
            }

            FillGrid();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            bool flag1 = false;
            foreach (DataListItem dtlItem in dlSeminarAttendance.Items)
            {
                CheckBox chkStudent = (CheckBox)dtlItem.FindControl("chkStudent");
                DropDownList ddlabsentreason = (DropDownList)dtlItem.FindControl("ddlabsentreason");
                Label lblDLAbsentReasonID = (Label)dtlItem.FindControl("lblDLAbsentReasonID");
                //Label lblDLAbsentReason = (Label)dtlItem.FindControl("lblDLAbsentReason");

                System.Web.UI.HtmlControls.HtmlAnchor lbl_DLError = (System.Web.UI.HtmlControls.HtmlAnchor)dtlItem.FindControl("lbl_DLError");
                Panel icon_Error = (Panel)dtlItem.FindControl("icon_Error");

                lbl_DLError.Title = "";
                icon_Error.Visible = false;


                if (chkStudent.Checked == true && ddlabsentreason.SelectedIndex == 0)
                {
                    flag = false;
                    // chkStudent.Visible = false;
                    //ddlabsentreason.Visible = false;
                }

                if (chkStudent != null && chkStudent.Checked == false)
                {
                    flag = true;
                }
                //if (flag == true && l)
                //{
                //    flag = false;
                //}
                if (ddlabsentreason.SelectedIndex != 0)
                {
                    flag = true;
                }
                if (chkStudent.Checked == true)
                {
                    ddlabsentreason.SelectedIndex = 0;
                    //ddlabsentreason.Visible = false;
                }
                if (chkStudent.Checked == false && ddlabsentreason.SelectedIndex == 0)
                {
                    lbl_DLError.Title = "Please Select Reason";
                    icon_Error.Visible = true;
                    return;
                }

                if (flag == false && chkStudent.Checked == false && ddlabsentreason.SelectedIndex == 0)
                {

                    flag1 = true;
                    lbl_DLError.Title = "Please Select Reason";
                    icon_Error.Visible = true;
                    UpdatePanelMsgBox.Update();
                    //lblDLAbsentReason.Focus();
                    lblDLAbsentReasonID.Focus();
                    return;

                }
            }

            if (flag1 == false)
            {
                string ActionFlag = "";
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string CreatedBy = cookie.Values["UserID"];

                int ResultId = 0;
                string LeadId = "",SeminarId="",seminarDate="";

                foreach (DataListItem dtlItem in dlSeminarAttendance.Items)
                {
                    CheckBox chkStudent = (CheckBox)dtlItem.FindControl("chkStudent");
                    Label lblLeadId = (Label)dtlItem.FindControl("lblLeadId");
                    //Label lblSeminarId = (Label)dtlItem.FindControl("lblSeminarId");
                    Label lblSeminarDate12 = (Label)dtlItem.FindControl("lblSeminarDate12");
                    
                    DropDownList ddlabsentreason = (DropDownList)dtlItem.FindControl("ddlabsentreason");

                    LeadId = lblLeadId.Text.Trim();
                   // SeminarId = lblSeminarId.Text;
                    seminarDate = lblSeminarDate12.Text;
                    string AbsentReason = ddlabsentreason.SelectedItem.ToString().Trim();
                    string AbsentReasonId = ddlabsentreason.SelectedValue.ToString().Trim();
                    
                    if (chkStudent.Checked)
                    {
                        ActionFlag = "P";
                        AbsentReason = "";
                        AbsentReasonId = "";
                    }
                    else
                    {
                        ActionFlag = "A";
                    }
                    if (AbsentReason == "Select")
                    {
                        AbsentReason = "";
                        AbsentReasonId = "";
                    }


                    //Mark exemption/absent/present for those students who are selected
                    ResultId = ProductController.Insert_UpdateStudent_Seminar_Attendance(LeadId, SeminarId, ActionFlag, AbsentReasonId, AbsentReason, "", CreatedBy, seminarDate);
                }
                
                //Close the Add Panel and go to Search Grid
                if (ResultId == 1)
                {
                    //btnSearchAttendance_Click(sender, e);
                    FillGrid();
                    Show_Error_Success_Box("S", "0000");
                }
            }

        }

       
        protected void chkAttendanceAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox s = sender as CheckBox;

            //Set checked status of hidden check box to items in grid
            foreach (DataListItem dtlItem in dlSeminarAttendance.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
                chkitemck.Checked = s.Checked;
            }

            Clear_Error_Success_Box();

        }

        protected void dlSeminarAttendance_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditReason")
            {
                DropDownList ddlabsentreason = (DropDownList)e.Item.FindControl("AbsentReason_ID");
                DataSet ds1 = ProductController.GetAllAbsentreasons();

                BindDDL(ddlabsentreason, ds1, "AbsentReason_ID", "AbsentReason_ID");
                ddlabsentreason.Items.Insert(0, "Select");
                ddlabsentreason.SelectedIndex = 0;
            }
        }
        
        #endregion


        
}
