using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Configuration;


public partial class Campaign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ExcelExportFormat();
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = ex.ToString();
            }
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        if (!flExcelUpload.HasFile)//if file uploader has no file selected
        { 
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = "Please Select File";
        }
        else if (flExcelUpload.HasFile)
        {
            try
            {
                string filePath = flExcelUpload.PostedFile.FileName; // getting the file path of uploaded file
                string filename1 = System.IO.Path.GetFileName(filePath);     // getting the file name of uploaded file
                string ext = System.IO.Path.GetExtension(filename1);          // getting the file extension of uploaded file
                string type = String.Empty;

                 switch (ext)    // this switch code validate the files which allow to upload only excel file you can change it for any file
                {
                    case ".xlt": 
                        type = "application/vnd.ms-excel"; 
                        break; 
                }

                 if (type != String.Empty)
                 {
                     string CurrentFilePath = System.IO.Path.GetFullPath(flExcelUpload.PostedFile.FileName);
                     string fileName = System.IO.Path.GetFileName(flExcelUpload.PostedFile.FileName);

                     DataSet dsGrid = new DataSet();
                     dsGrid = ProductController.GetExcelSheetName(fileName, 2);

                     if (dsGrid != null)
                     {
                         if (dsGrid.Tables.Count != 0)
                         {
                             try
                             {
                                 if (dsGrid.Tables[0].Rows[0]["ExcelFlag"].ToString() != "0")
                                 {
                                     Msg_Error.Visible = true;
                                     Msg_Success.Visible = false;
                                     lblerror.Text = fileName + " is already exist.Change your excelsheet name and then upload....!";
                                     return;
                                 }
                             }
                             catch 
                             { 
                             }
                         }
                     }

                     flExcelUpload.PostedFile.SaveAs(Server.MapPath("~/Images/Excel Upload/" + fileName));
                     lblFileName.Text = fileName;
                     

                     DataSet ds = new DataSet();
                     ds = ImportExcelXLS(Server.MapPath("~/Images/Excel Upload/" + fileName), true);
                     if (ds.Tables[0].Rows.Count > 6000)
                     {
                         Msg_Error.Visible = true;
                         Msg_Success.Visible = false;
                         lblerror.Text ="Total No of Records in your Excel Sheet Cannot be greater than 6000...!";
                         return;
                     }

                     if (ds.Tables[0].Rows.Count > 0)
                     {
                         dlDisplay.DataSource = ds.Tables[0];
                         dlDisplay.DataBind();

                         DivResultPanel.Visible = true;
                         DivAddPanel.Visible = false;

                         lbltotalcount.Text = ds.Tables[0].Rows.Count.ToString();
                         BtnShowSearchPanel.Visible = true;
                         btnExport.Visible = false;
                     }
                     else
                     {
                         Msg_Error.Visible = true;
                         Msg_Success.Visible = false;
                         lblerror.Text = "Data Not Available In your Excel Sheet...!";
                     }

                     //Msg_Error.Visible = false;
                     //Msg_Success.Visible = true;
                     //lblSuccess.Text = "Excel Uploaded Successfully...!";
                 }
                 else
                 {
                     Msg_Error.Visible = true;
                     Msg_Success.Visible = false;
                     lblerror.Text = "Select Only Excel File having extension .xlt (Excel 97-2003 Template) ";
                 }
            }
            catch (Exception ex)
            {

            }
        }
    }


    public static DataSet ImportExcelXLS(string FileName, bool hasHeaders)
    {
        string HDR = hasHeaders ? "Yes" : "No";
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=1\"";

        DataSet output = new DataSet();

        using (OleDbConnection conn = new OleDbConnection(strConn))
        {
            conn.Open();

            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            foreach (DataRow row in dt.Rows)
            {
                string sheet = row["TABLE_NAME"].ToString();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                cmd.CommandType = CommandType.Text;
                DataTable outputTable = new DataTable(sheet);
                output.Tables.Add(outputTable);
                new OleDbDataAdapter(cmd).Fill(outputTable);

            }
            conn.Close();
            int i;
            for (i = 0; i < output.Tables[0].Rows.Count; i++)
            {
                if (output.Tables[0].Rows[i].IsNull(0))
                {
                    output.Tables[0].Rows[i].Delete();
                }
            }
            output.AcceptChanges();
        }

        return output;
    }

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");        
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        int TotalSavedRecord = 0;

        DataTable tb = new DataTable();
        DataRow dr;
        tb.Columns.Add("Data_Source_Name", typeof(string));
        tb.Columns.Add("Reference_Id", typeof(string));
        //tb.Columns.Add("Process_Status", typeof(string));
        //tb.Columns.Add("Live_Status", typeof(string));
        tb.Columns.Add("Student_First_Name", typeof(string));
        tb.Columns.Add("Student_Last_Name", typeof(string));
        tb.Columns.Add("Parent_First_Name", typeof(string));
        tb.Columns.Add("Parent_Last_Name", typeof(string));
        tb.Columns.Add("Email_Id", typeof(string));
        tb.Columns.Add("Handphone_1", typeof(string));
        tb.Columns.Add("Handphone_2", typeof(string));
        tb.Columns.Add("Contact_No", typeof(string));
        tb.Columns.Add("Address1", typeof(string));
        tb.Columns.Add("Address2", typeof(string));
        tb.Columns.Add("Address3", typeof(string));
        tb.Columns.Add("Country", typeof(string));
        tb.Columns.Add("State", typeof(string));
        tb.Columns.Add("City", typeof(string));
        tb.Columns.Add("Location", typeof(string));
        tb.Columns.Add("Pincode", typeof(string));
        tb.Columns.Add("ProductInterest", typeof(string));
        tb.Columns.Add("Present_Status", typeof(string));

        string Import_Run_No = ProductController.Insert_CompaignRawData_ExcelInfo("", lblFileName.Text, "", "", Convert.ToString(dlDisplay.Items.Count), Convert.ToString(TotalSavedRecord), UserID, "1");


        foreach (DataListItem dtlItem in dlDisplay.Items)
        {
            Label lblData_Source_Name = (Label)dtlItem.FindControl("lblData_Source_Name");
            Label lblReference_Id = (Label)dtlItem.FindControl("lblReference_Id");
            //Label lblProcess_Status = (Label)dtlItem.FindControl("lblProcess_Status");
            //Label lblLive_Status = (Label)dtlItem.FindControl("lblLive_Status");
            Label lblStudent_First_Name = (Label)dtlItem.FindControl("lblStudent_First_Name");
            Label lblStudent_Last_Name = (Label)dtlItem.FindControl("lblStudent_Last_Name");
            Label lblParent_First_Name = (Label)dtlItem.FindControl("lblParent_First_Name");
            Label lblParent_Last_Name = (Label)dtlItem.FindControl("lblParent_Last_Name");
            Label lblEmailID = (Label)dtlItem.FindControl("lblEmailID");
            Label lblHandphone_1 = (Label)dtlItem.FindControl("lblHandphone_1");
            Label lblHandphone_2 = (Label)dtlItem.FindControl("lblHandphone_2");
            Label lblContact_No = (Label)dtlItem.FindControl("lblContact_No");
            Label lblAddress1 = (Label)dtlItem.FindControl("lblAddress1");
            Label lblAddress2 = (Label)dtlItem.FindControl("lblAddress2");
            Label lblAddress3 = (Label)dtlItem.FindControl("lblAddress3");
            Label lblCountry = (Label)dtlItem.FindControl("lblCountry");
            Label lblState = (Label)dtlItem.FindControl("lblState");
            Label lblCity = (Label)dtlItem.FindControl("lblCity");
            Label lblLocation = (Label)dtlItem.FindControl("lblLocation");
            Label lblPincode = (Label)dtlItem.FindControl("lblPincode");
            Label lblProductInterest = (Label)dtlItem.FindControl("lblProductInterest");
            Label lblPresent_Status = (Label)dtlItem.FindControl("lblPresent_Status");

            Label lblSuccess1 = (Label)dtlItem.FindControl("lblSuccess");
            lblSuccess1.Visible = false;

            HtmlAnchor lbl_DLError = (HtmlAnchor)dtlItem.FindControl("lbl_DLError");
            Panel icon_Error = (Panel)dtlItem.FindControl("icon_Error");


            int Result = ProductController.Insert_Update_CompaignRawData(Import_Run_No, lblData_Source_Name.Text, lblReference_Id.Text, "1", "0", lblStudent_First_Name.Text, lblStudent_Last_Name.Text, lblParent_First_Name.Text, lblParent_Last_Name.Text, lblEmailID.Text, lblHandphone_1.Text, lblHandphone_2.Text, lblContact_No.Text, lblAddress1.Text, lblAddress2.Text, lblAddress3.Text, lblCountry.Text, lblState.Text, lblCity.Text, lblLocation.Text, lblPincode.Text, lblProductInterest.Text, lblPresent_Status.Text, UserID, "1");

            if (Result == 1)
            {
                icon_Error.Visible = false;
                lblSuccess1.Visible = true;
                TotalSavedRecord++;
            }
            else if (Result == -1)
            {
                lbl_DLError.Title = "Your Data is not proper format";//Datatype is different (Parameter datatype and Table column Datatype (Process_Status,Live_Status,Present_Status is Integer in TOE0000_RAW_Data Table but value pass in varchar))
                icon_Error.Visible = true;
                
                dr = tb.NewRow();
                dr["Data_Source_Name"] = lblData_Source_Name.Text;
                dr["Reference_Id"] = lblReference_Id.Text;
                //dr["Process_Status"] = lblProcess_Status.Text;
                //dr["Live_Status"] = lblLive_Status.Text;
                dr["Student_First_Name"] = lblStudent_First_Name.Text;
                dr["Student_Last_Name"] = lblStudent_Last_Name.Text;
                dr["Parent_First_Name"] = lblParent_First_Name.Text;
                dr["Parent_Last_Name"] = lblParent_Last_Name.Text;
                dr["Handphone_1"] = lblHandphone_1.Text;
                dr["Handphone_2"] = lblHandphone_2.Text;
                dr["Contact_No"] = lblContact_No.Text;
                dr["Address1"] = lblAddress1.Text;
                dr["Address2"] = lblAddress2.Text;
                dr["Address3"] = lblAddress3.Text;
                dr["Country"] = lblCountry.Text;
                dr["State"] = lblState.Text;
                dr["City"] = lblCity.Text;
                dr["Location"] = lblLocation.Text;
                dr["Pincode"] = lblPincode.Text;
                dr["ProductInterest"] = lblProductInterest.Text;
                dr["Present_Status"] = lblPresent_Status.Text;
                tb.Rows.Add(dr);
            }
            else if (Result == -2)
            {
                lbl_DLError.Title = "No DataSource Maintained";//if the DataSource Name not find to C094_RawDataSource
                icon_Error.Visible = true;

                dr = tb.NewRow();
                dr["Data_Source_Name"] = lblData_Source_Name.Text;
                dr["Reference_Id"] = lblReference_Id.Text;
                //dr["Process_Status"] = lblProcess_Status.Text;
                //dr["Live_Status"] = lblLive_Status.Text;
                dr["Student_First_Name"] = lblStudent_First_Name.Text;
                dr["Student_Last_Name"] = lblStudent_Last_Name.Text;
                dr["Parent_First_Name"] = lblParent_First_Name.Text;
                dr["Parent_Last_Name"] = lblParent_Last_Name.Text;
                dr["Handphone_1"] = lblHandphone_1.Text;
                dr["Handphone_2"] = lblHandphone_2.Text;
                dr["Contact_No"] = lblContact_No.Text;
                dr["Address1"] = lblAddress1.Text;
                dr["Address2"] = lblAddress2.Text;
                dr["Address3"] = lblAddress3.Text;
                dr["Country"] = lblCountry.Text;
                dr["State"] = lblState.Text;
                dr["City"] = lblCity.Text;
                dr["Location"] = lblLocation.Text;
                dr["Pincode"] = lblPincode.Text;
                dr["ProductInterest"] = lblProductInterest.Text;
                dr["Present_Status"] = lblPresent_Status.Text;
                tb.Rows.Add(dr);
            }        
        }
        Msg_Error.Visible = false;
        Msg_Success.Visible = true;
        lblSuccess.Text = Convert.ToString(TotalSavedRecord) + " Records Saved Successfully out of " + Convert.ToString(dlDisplay.Items.Count) + " Records.Check Individual Record for More Details.";
        if (TotalSavedRecord > 0)
        {
            try
            {

                string Result1 = ProductController.Insert_CompaignRawData_ExcelInfo(Import_Run_No, lblFileName.Text, "", "", Convert.ToString(dlDisplay.Items.Count), Convert.ToString(TotalSavedRecord), UserID, "2");
                if (TotalSavedRecord != dlDisplay.Items.Count)
                {
                    dlExport.DataSource = tb;
                    dlExport.DataBind();
                    btnExport.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;                
                lblerror.Text = ex.ToString();
            }
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        dlExport.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Campaign_RawData_Error_Records_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
       // HttpContext.Current.Response.Charset = "utf-8";
       // HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        ////sets font
        //HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        //HttpContext.Current.Response.Write("<BR><BR><BR>");
        //HttpContext.Current.Response.Write("<Table border='1'   cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> ");
        ////HttpContext.Current.Response.Write("");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlExport.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        dlExport.Visible = false;
    
    }
    protected void lnkExportExcelFormat_Click(object sender, EventArgs e)
    {
        dlExportExcelFormat.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Campaign_RawData_ExelFormat_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        // HttpContext.Current.Response.Charset = "utf-8";
        // HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        ////sets font
        //HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        //HttpContext.Current.Response.Write("<BR><BR><BR>");
        //HttpContext.Current.Response.Write("<Table border='1'   cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> ");
        ////HttpContext.Current.Response.Write("");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlExportExcelFormat.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        dlExportExcelFormat.Visible = false;
    }

    private void ExcelExportFormat()
    {
        DataTable tb = new DataTable();
        DataRow dr;
        tb.Columns.Add("Data_Source_Name", typeof(string));
        tb.Columns.Add("Reference_Id", typeof(string));
        //tb.Columns.Add("Process_Status", typeof(string));
        //tb.Columns.Add("Live_Status", typeof(string));
        tb.Columns.Add("Student_First_Name", typeof(string));
        tb.Columns.Add("Student_Last_Name", typeof(string));
        tb.Columns.Add("Parent_First_Name", typeof(string));
        tb.Columns.Add("Parent_Last_Name", typeof(string));
        tb.Columns.Add("Email_Id", typeof(string));
        tb.Columns.Add("Handphone_1", typeof(string));
        tb.Columns.Add("Handphone_2", typeof(string));
        tb.Columns.Add("Contact_No", typeof(string));
        tb.Columns.Add("Address1", typeof(string));
        tb.Columns.Add("Address2", typeof(string));
        tb.Columns.Add("Address3", typeof(string));
        tb.Columns.Add("Country", typeof(string));
        tb.Columns.Add("State", typeof(string));
        tb.Columns.Add("City", typeof(string));
        tb.Columns.Add("Location", typeof(string));
        tb.Columns.Add("Pincode", typeof(string));
        tb.Columns.Add("ProductInterest", typeof(string));
        tb.Columns.Add("Present_Status", typeof(string));


        dr = tb.NewRow();
        dr["Data_Source_Name"] = "";
        dr["Reference_Id"] = "";
        //dr["Process_Status"] = lblProcess_Status.Text;
        //dr["Live_Status"] = lblLive_Status.Text;
        dr["Student_First_Name"] = "";
        dr["Student_Last_Name"] = "";
        dr["Parent_First_Name"] = "";
        dr["Parent_Last_Name"] = "";
        dr["Handphone_1"] = "";
        dr["Handphone_2"] = "";
        dr["Contact_No"] = "";
        dr["Address1"] = "";
        dr["Address2"] = "";
        dr["Address3"] = "";
        dr["Country"] = "";
        dr["State"] = "";
        dr["City"] = "";
        dr["Location"] = "";
        dr["Pincode"] = "";
        dr["ProductInterest"] = "";
        dr["Present_Status"] = "";
        tb.Rows.Add(dr);
        dlExportExcelFormat.DataSource = tb;
        dlExportExcelFormat.DataBind();
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivSearch.Visible = false;
            DivAddPanel.Visible = true;
            DivResultPanel.Visible = false;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = false;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
        if (Mode == "Add")
        {
            DivSearch.Visible = true;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            BtnAdd.Visible = false;
            BtnShowSearchPanel.Visible = true;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {        
        BindExcelList();
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox s = sender as CheckBox;

            //Set checked status of hidden check box to items in grid
            foreach (DataListItem dtlItem in dlGridExcelName.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");

                chkitemck.Checked = s.Checked;
            }
            Clear_Error_Success_Box();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
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

    private void BindExcelList()
    {
        try
        {
            dlGridExcelName.DataSource = null;
            dlGridExcelName.DataBind();
            DataSet dsGrid = new DataSet();
            dsGrid = ProductController.GetExcelSheetName("",1);
            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count != 0)
                {
                    if (dsGrid.Tables[0].Rows.Count > 0)
                    {
                        dlGridExcelName.DataSource = dsGrid;
                        dlGridExcelName.DataBind();
                        ControlVisibility("Add");
                        tblExcelName.Visible = true;
                        divExcelRecord.Visible = false;
                        btnViewRecord.Text = "View";
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "First Upload Your Excel Sheet...");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }

    }
    protected void btnViewRecord_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (btnViewRecord.Text == "View")
        {
            string Import_Run_No = "";
            foreach (DataListItem dtlItem in dlGridExcelName.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                if (chkCheck.Checked == true)
                {
                    Label lblImport_Run_No = (Label)dtlItem.FindControl("lblImport_Run_No");
                    Import_Run_No = Import_Run_No + lblImport_Run_No.Text + ",";
                }
            }
            if (Import_Run_No == "")
            {
                Show_Error_Success_Box("E", "You have not Selected any Excel.");
                return;
            }

            DataSet dsGrid = new DataSet();
            dsGrid = ProductController.GetExcelSheetRecord(Import_Run_No, 1);
            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count != 0)
                {
                    dlselective1.DataSource = dsGrid.Tables[0];
                    dlselective1.DataBind();
                    dlselective2.DataSource = dsGrid.Tables[1];
                    dlselective2.DataBind();
                    lblUniqueCount.Text = dsGrid.Tables[0].Rows.Count.ToString();
                    lblDupliCount.Text = dsGrid.Tables[1].Rows.Count.ToString();
                    divExcelRecord.Visible = true;
                    tblExcelName.Visible = false;
                    btnViewRecord.Text = "Save";
                }
            }
            //tblExcelName
        }
        else if (btnViewRecord.Text == "Save")
        {
            string Data_Id = "",Import_Run_No = "";
            foreach (DataListItem dtlItem in dlselective1.Items)
            {
                Label lblData_Id = (Label)dtlItem.FindControl("lblData_Id");
                Data_Id = Data_Id + lblData_Id.Text + ",";
            }
            //Check the duplicate record if checked is true then insert into pre lead table
            foreach (DataListItem dtlItem in dlselective2.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
                if (chkitemck.Checked == true)
                {
                    Label lblData_Id = (Label)dtlItem.FindControl("lblData_Id");
                    Data_Id = Data_Id + lblData_Id.Text + ",";
                }
            }

            if (Data_Id == "")
            {
                Show_Error_Success_Box("E", "Select AtLeast One Record....!");
                return;
            }
            //Import run Number Id
            foreach (DataListItem dtlItem in dlGridExcelName.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                if (chkCheck.Checked == true)
                {
                    Label lblImport_Run_No = (Label)dtlItem.FindControl("lblImport_Run_No");
                    Import_Run_No = Import_Run_No + lblImport_Run_No.Text + ",";
                }
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            try
            {
                DataSet dsGrid1 = new DataSet();
                dsGrid1 = ProductController.Insert_PreLeadData(Data_Id, Import_Run_No, UserID, 1);
                ControlVisibility("Search");
                Show_Error_Success_Box("S", "Record's Saved Successfully...!");
            }
            catch (Exception ex)
            {
                ControlVisibility("Search");
                Show_Error_Success_Box("E", ex.ToString());
            }
            
        }
    }

    protected void acloseExcelrecord_ServerClick(object sender, System.EventArgs e)
    {
        tblExcelName.Visible = true;
        divExcelRecord.Visible = false;
        btnViewRecord.Text = "View";
    }


    protected void chkAll2_CheckedChanged(object sender, EventArgs e)
    {
        //int rowcount=
        try
        {
            CheckBox s = sender as CheckBox;
            //Set checked status of hidden check box to items in grid
            foreach (DataListItem dtlItem in dlselective2.Items)
            {
                CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
                chkitemck.Checked = s.Checked;
            }
            
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

}