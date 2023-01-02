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
using System.Text;

public partial class Center_UploadContacts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //ExcelExportFormat();
                ContactSource();
                Country();
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = ex.ToString();
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

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
          //  DivSearch.Visible = false;
            DivAddPanel.Visible = true;
            DivResultPanel.Visible = false;
            //BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = false;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
        if (Mode == "Add")
        {
           // DivSearch.Visible = true;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = true;
            BtnShowSearchPanel.Visible = true;
            //BtnAdd.Visible = false;
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
        }
    }

    private void ContactSource()
    {
        DataSet ds = ProductController.GetallactiveleadSource();
        BindDDL(ddlContactsourceadd, ds, "Description", "ID");
        ddlContactsourceadd.Items.Insert(0, "Select");
        ddlContactsourceadd.SelectedIndex = 0;
    }

    private void Country()
    {
        DataSet ds = ProductController.GetallCountry();
        BindDDL(ddlCountry, ds, "Country_Name", "Country_Code");
        ddlCountry.Items.Insert(0, "Select");
        ddlCountry.SelectedIndex = 0;
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {        
        //BindExcelList();
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


    public static bool IsValidEmailId(string InputEmail)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(InputEmail);
        if (match.Success)
            return true;
        else
            return false;
    }


    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Msg_Error.Visible = false ;
        Msg_Success.Visible = false;
        if (!string.IsNullOrEmpty(flExcelUpload.FileName))
        {
            //lbluploadfileName.Text = Path.GetFileName(uploadfile.FileName);
            string FullName = Server.MapPath("~/Contact_Upload") + "\\" + Path.GetFileName(flExcelUpload.FileName);
            lblfilepath.Text = FullName;
            lblfileName1.Text = Path.GetFileName(flExcelUpload.FileName);
            string strFileType = Path.GetExtension(flExcelUpload.FileName).ToLower();
            if (strFileType != ".csv")
            {
                Show_Error_Success_Box("E", "Kindly Select Excel File With .CSV Extension");
                return;
            }

            else
            {
                try
                {


                    DataSet ds1 = new DataSet();
                    ds1 = ProductController.Get_Contacts_ExcelUploadFlag(lblfileName1.Text,  "1");
                    if (ds1 != null)
                    {
                        if (ds1.Tables.Count != 0)
                        {
                            if (ds1.Tables[0].Rows[0]["ExcelCount"].ToString() != "0")
                            {
                                Show_Error_Success_Box("E", "File name already exist.Change File name and upload again");
                                return;
                            }
                        }
                    }

                    bool exists = System.IO.Directory.Exists(Server.MapPath("~/Contact_Upload"));

                    if (!exists)
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Contact_Upload"));

                    flExcelUpload.SaveAs(FullName);

                    DataTable dtRaw = new DataTable();

                    //create object for CSVReader and pass the stream
                    FileStream fileStream = new FileStream(FullName, FileMode.Open);
                    CSVReader reader = new CSVReader(fileStream);
                    //get the header
                    string[] headers = reader.GetCSVLine();
                                       
                    //add headers
                    foreach (string strHeader in headers)
                    {
                        dtRaw.Columns.Add(strHeader);
                    }
                    DataRow NewRow = null;
                    int CurRowNo = 0;

                    string[] data = null;
                    data = reader.GetCSVLine();
                   
                    //Read first line
                    CurRowNo = 1;

                    while (data != null)
                    {                        
                        dtRaw.Rows.Add(data);
                        //data[9] = CurRowNo.ToString();
                    NextCSVLine:
                        data = reader.GetCSVLine();                        
                        //Read next line
                        CurRowNo = CurRowNo + 1;
                       // data[0] = CurRowNo.ToString();
                    }
                    if (dtRaw.Rows.Count == 0)
                    {
                        Show_Error_Success_Box("E", "Invalid Excel sheet(Record not found in your excel sheet)");
                        return;
                    }
                    dtRaw.Columns.Add("RowNum");
                    dtRaw.Columns.Add("Contact_Source");
                    dtRaw.Columns.Add("Country");
                    
                    ControlVisibility("Add");
                    for (int i = 0; i < dtRaw.Rows.Count; i++)
                    {
                        dtRaw.Rows[i]["RowNum"] = (i+ 1).ToString();
                        dtRaw.Rows[i]["Contact_Source"] = ddlContactsourceadd.SelectedItem.ToString();
                        dtRaw.Rows[i]["Country"] = ddlCountry.SelectedItem.ToString();
                    }

                        dlviewExcelFormat.Visible = true;
                        divSaveContacts.Visible = true;
                        btnExportErrorContacts.Visible = false;
                        dlviewExcelFormat.DataSource = dtRaw;
                        dlviewExcelFormat.DataBind();
                    lbltotalcount.Text = dtRaw.Rows.Count.ToString();
                }
                catch
                {
                    Show_Error_Success_Box("E", "Excel File Not Matching With The Template, Kindly Click On Download Template Button And Use That Template");
                    return;
                }

            }

        }
        else
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = "Please Select File...!";
            return;
        }


    }
    protected void lnkExportExcelFormat_Click(object sender, EventArgs e)
    {        
        //To Get the physical Path of the file(me2.doc)
        string filepath = Server.MapPath("~/Images/Contact_template.csv");

        // Create New instance of FileInfo class to get the properties of the file being downloaded
        FileInfo myfile = new FileInfo(filepath);

        // Checking if file exists
        if (myfile.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", myfile.Length.ToString());

            // Set the ContentType
            //Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(myfile.FullName);

            // End the response
            Response.End();
        }
        else
        {
            Msg_Error.Visible = false;
            Msg_Success.Visible = false;
            lblSuccess.Text = "";
            lblerror.Text = "Contact to Administrator (Excel file path not found).";
            UpdatePanelMsgBox.Update();
        }
    }


    protected void btnSaveContacts_Click(object sender, EventArgs e)
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        string Row_num = "", XMLData = "<Contacts>";//ContactSource = "", Contacttitle = "", ContactFirstName = "", ContactMidName = "", ContactLastName = "", Gender = "", EmailId = "", Handphone1 = "", Handphone2="",Landline="",Country = "";
        foreach (DataListItem dtlItem in dlviewExcelFormat.Items)
        {
            Label lblRowNum = (Label)dtlItem.FindControl("lblRowNum");
            Label lblContact_Source = (Label)dtlItem.FindControl("lblContact_Source");
            Label lblCon_Title = (Label)dtlItem.FindControl("lblCon_Title");
            Label lblCon_FirstName = (Label)dtlItem.FindControl("lblCon_FirstName");
            Label lblCon_MidName = (Label)dtlItem.FindControl("lblCon_MidName");
            Label lblConLastName = (Label)dtlItem.FindControl("lblConLastName");
            Label lblGender = (Label)dtlItem.FindControl("lblGender");
            Label lblEmailId = (Label)dtlItem.FindControl("lblEmailId");
            Label lblHandphone1 = (Label)dtlItem.FindControl("lblHandphone1");
            Label lblHandphone2 = (Label)dtlItem.FindControl("lblHandphone2");
            Label lbllandline = (Label)dtlItem.FindControl("lblLandline");
            Label lblInstituteType = (Label)dtlItem.FindControl("lblInstituteType");
            Label lblInstitute = (Label)dtlItem.FindControl("lblInstitute");
            Label lblBoard = (Label)dtlItem.FindControl("lblBoard");
            Label lblCurStudying = (Label)dtlItem.FindControl("lblCurStudying");
            Label lblYearOfPassing = (Label)dtlItem.FindControl("lblYearOfPassing");
            Label lblCountry = (Label)dtlItem.FindControl("lblCountry");
            Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lbErrorSaveMessage");

            if (lblContact_Source.Text == "")
            {
                lbErrorSaveMessage.CssClass = "red";
                lbErrorSaveMessage.Text = "Enter contact source";
            }
            else if (lblCon_Title.Text == "")
            {
                lbErrorSaveMessage.CssClass = "red";
                lbErrorSaveMessage.Text = "Enter contact title";
            }
            else if (lblCon_FirstName.Text == "")
            {
                lbErrorSaveMessage.CssClass = "red";
                lbErrorSaveMessage.Text = "Enter contact First Name";
            }
            else if (lblGender.Text == "")
            {
                lbErrorSaveMessage.CssClass = "red";
                lbErrorSaveMessage.Text = "Enter Gender";
            }
            else if (lblEmailId.Text == "")
            {
                lbErrorSaveMessage.CssClass = "red";
                lbErrorSaveMessage.Text = "Enter Email Id";
            }
            else if (lblHandphone1.Text == "")
            {
                lbErrorSaveMessage.CssClass = "red";
                lbErrorSaveMessage.Text = "Enter Handphone1";
            }
            else if (lblCountry.Text == "")
            {
                lbErrorSaveMessage.CssClass = "red";
                lbErrorSaveMessage.Text = "Enter Country";
            }
            else
            {
                //Check the EmailId Validation
                if (lbErrorSaveMessage.Text == "")
                {
                    if (IsValidEmailId(lblEmailId.Text))
                    {
                    }
                    else
                    {
                        lbErrorSaveMessage.CssClass = "red";
                        lbErrorSaveMessage.Text = "Email Address Not Valid";
                    }
                }
                if (lbErrorSaveMessage.Text == "")
                {
                    foreach (Char ch in lblHandphone1.Text)
                    {
                        if (!Char.IsDigit(ch))
                        {
                            lbErrorSaveMessage.CssClass = "red";
                            lbErrorSaveMessage.Text = "Enter only numeric values in Handphone1";
                            break;
                        }
                    }

                    foreach (Char ch in lblHandphone2.Text)
                    {
                        if (!Char.IsDigit(ch))
                        {
                            lbErrorSaveMessage.CssClass = "red";
                            lbErrorSaveMessage.Text = "Enter only numeric values in Handphone2";
                            break;
                        }
                    }

                    foreach (Char ch in lbllandline.Text)
                    {
                        if (!Char.IsDigit(ch))
                        {
                            lbErrorSaveMessage.CssClass = "red";
                            lbErrorSaveMessage.Text = "Enter only numeric values in Landline";
                            break;
                        }
                    }

                }
                //Check the handphone length
                if ((lbErrorSaveMessage.Text == "") && ((lblHandphone1.Text.Length < 10) || (lblHandphone1.Text.Length > 18)))
                {
                    lbErrorSaveMessage.CssClass = "red";
                    lbErrorSaveMessage.Text = "Handphone length must be between 10 to 18 characters";
                }

                //Check the handphone2 length
                if ((lbErrorSaveMessage.Text == "") && (lblHandphone2.Text !="") &&((lblHandphone2.Text.Length < 10) || (lblHandphone2.Text.Length > 18)))
                {
                    lbErrorSaveMessage.CssClass = "red";
                    lbErrorSaveMessage.Text = "Handphone2 length must be between 10 to 18 characters";
                }
                //Check the InstitutionType, Institute Name and Board name, current studing and Year of passing (If the Board is entered then check Institute is entered or not)
                //If any one enter then check this InstitutionType, Institute Name and Board name, current studing and Year of passing all is entered or not

                if ((lbErrorSaveMessage.Text == "") && (lblInstituteType.Text.Trim() == "") && ((lblInstitute.Text.Trim() != "") || (lblBoard.Text.Trim() != "") || (lblCurStudying.Text.Trim() != "") || (lblYearOfPassing.Text.Trim() != "")))
                {
                    lbErrorSaveMessage.CssClass = "red";
                    lbErrorSaveMessage.Text = "Enter Institution Type";
                }
                //(If the all field is entered then check Institution Name is entered or not)
                else if ((lbErrorSaveMessage.Text == "") && (lblInstitute.Text.Trim() == "") && ((lblInstituteType.Text.Trim() != "") || (lblBoard.Text.Trim() != "") || (lblCurStudying.Text.Trim() != "") || (lblYearOfPassing.Text.Trim() != "")))
                {
                    lbErrorSaveMessage.CssClass = "red";
                    lbErrorSaveMessage.Text = "Enter Institution Name";
                }
                //(If the all field is entered then check Board is entered or not)
                else if ((lbErrorSaveMessage.Text == "") && (lblBoard.Text.Trim() == "") && ((lblInstituteType.Text.Trim() != "") || (lblInstitute.Text.Trim() != "") || (lblCurStudying.Text.Trim() != "") || (lblYearOfPassing.Text.Trim() != "")))
                {
                    lbErrorSaveMessage.CssClass = "red";
                    lbErrorSaveMessage.Text = "Enter Board Name";
                }
                //(If the all field is entered then check Current Studying is entered or not)
                else if ((lbErrorSaveMessage.Text == "") && (lblCurStudying.Text.Trim() == "") && ((lblInstituteType.Text.Trim() != "") || (lblInstitute.Text.Trim() != "") || (lblBoard.Text.Trim() != "") || (lblYearOfPassing.Text.Trim() != "")))
                {
                    lbErrorSaveMessage.CssClass = "red";
                    lbErrorSaveMessage.Text = "Enter Current Studying";
                }
                //(If the all field is entered then check Year of Passing is entered or not)
                else if ((lbErrorSaveMessage.Text == "") && (lblYearOfPassing.Text.Trim() == "") && ((lblInstituteType.Text.Trim() != "") || (lblInstitute.Text.Trim() != "") || (lblBoard.Text.Trim() != "") || (lblCurStudying.Text.Trim() != "")))
                {
                    lbErrorSaveMessage.CssClass = "red";
                    lbErrorSaveMessage.Text = "Enter Current Year of Passing";
                }

                //if any error not come then Pass Record to save Procedure
                if (lbErrorSaveMessage.Text == "")
                {
                    Row_num = Row_num + lblRowNum.Text.Trim() + ",";
                    XMLData = XMLData + "<Contact><Row>" + lblRowNum.Text.Trim() + "</Row><Source>" + lblContact_Source.Text.Trim() + "</Source><Title>" + lblCon_Title.Text.Trim() + "</Title><FName>" + lblCon_FirstName.Text.Trim() + "</FName><MName>"
                            + lblCon_MidName.Text.Trim() + "</MName><LName>" + lblConLastName.Text.Trim() + "</LName><Gender>" + lblGender.Text.Trim() + "</Gender><Email>" + lblEmailId.Text.Trim() + "</Email><Handphone1>"
                            + lblHandphone1.Text.Trim() + "</Handphone1><Handphone2>" + lblHandphone2.Text.Trim() + "</Handphone2><LandLine>" + lbllandline.Text.Trim() + "</LandLine><InstitutionType>" + lblInstituteType.Text.Trim() + "</InstitutionType><Institution>" + lblInstitute.Text.Trim() + "</Institution><Board>" + lblBoard.Text.Trim() + "</Board><CurrentStudying>" + lblCurStudying.Text.Trim() + "</CurrentStudying><YearOfPassing>" + lblYearOfPassing.Text.Trim() + "</YearOfPassing><Country>" + lblCountry.Text.Trim() + "</Country></Contact>";                   

                    //ContactSource = ContactSource + lblContact_Source.Text.Trim() + ",";
                    //Contacttitle = Contacttitle + lblCon_Title.Text.Trim() + ",";
                    //ContactFirstName = ContactFirstName + lblCon_FirstName.Text.Trim() + ",";
                    //ContactMidName = ContactMidName + lblCon_MidName.Text.Trim() + ",";
                    //ContactLastName = ContactLastName + lblConLastName.Text.Trim() + ",";
                    //Gender = Gender + lblGender.Text.Trim() + ",";
                    //EmailId = EmailId + lblEmailId.Text.Trim() + ",";
                    //Handphone1 = Handphone1 + lblHandphone1.Text.Trim() + ",";
                    //Handphone2 = Handphone2 + lblHandphone2.Text.Trim() + ",";
                    //Landline = Landline + lbllandline.Text.Trim() + ",";
                    //Country = Country + lblCountry.Text.Trim() + ",";
                }
            }
        }
        btnExportErrorContacts.Visible = true;
        if (Row_num != "")  //Call sp
        {
            try
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string Created_By = cookie.Values["UserID"];
                DataSet ds = new DataSet();
                XMLData = XMLData + "</Contacts>";
                ds = ProductController.Insert_Contacts_Center_ExcelUpload(XMLData, Created_By, lblfileName1.Text, lbltotalcount.Text, "1");
                if (ds != null)
                {
                    if (ds.Tables.Count != 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int k = 0;
                            while (ds.Tables[0].Rows.Count > k)
                            {
                                foreach (DataListItem dtlItem in dlviewExcelFormat.Items)
                                {
                                    Label lblRowNum = (Label)dtlItem.FindControl("lblRowNum");
                                    if (lblRowNum.Text.Trim() == ds.Tables[0].Rows[k]["RowNum"].ToString())
                                    {
                                        Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lbErrorSaveMessage");
                                        if (ds.Tables[0].Rows[k]["ErrorSaveId"].ToString() == "-2") //Error Record
                                        {
                                            lbErrorSaveMessage.CssClass = "red";
                                            lbErrorSaveMessage.Text = ds.Tables[0].Rows[k]["ErrorSaveMessage"].ToString();
                                        }
                                        else if (ds.Tables[0].Rows[k]["ErrorSaveId"].ToString() == "1") //Save Record
                                        {
                                            lbErrorSaveMessage.CssClass = "green";
                                            lbErrorSaveMessage.Text = ds.Tables[0].Rows[k]["ErrorSaveMessage"].ToString();
                                        }
                                        break;
                                    }
                                }
                                k++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = false;
                Msg_Success.Visible = false;
                lblSuccess.Text = "";
                lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
            }

        }
       
    }

    protected void btnExportErrorContacts_Click(object sender, EventArgs e)
    {
        DataTable tb = new DataTable();
        DataRow dr;
        tb.Columns.Add("Title", typeof(string));
        tb.Columns.Add("FirstName", typeof(string));
        tb.Columns.Add("MiddleName", typeof(string));
        tb.Columns.Add("LastName", typeof(string));
        tb.Columns.Add("Gender", typeof(string));
        tb.Columns.Add("EmailId", typeof(string));
        tb.Columns.Add("Handphone1", typeof(string));
        tb.Columns.Add("Handphone2", typeof(string));
        tb.Columns.Add("Landline", typeof(string));
        tb.Columns.Add("InstitutionType", typeof(string));
        tb.Columns.Add("Institution", typeof(string));
        tb.Columns.Add("Board", typeof(string));
        tb.Columns.Add("CurrentStudying", typeof(string));
        tb.Columns.Add("YearOfPassing", typeof(string));
        tb.Columns.Add("ErrorMessage", typeof(string));

        foreach (DataListItem dtlItem in dlviewExcelFormat.Items)
        {
            Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lbErrorSaveMessage");
            if (lbErrorSaveMessage.CssClass == "red")
            {
                //Label lblContact_Source = (Label)dtlItem.FindControl("lblContact_Source");
                Label lblCon_Title = (Label)dtlItem.FindControl("lblCon_Title");
                Label lblCon_FirstName = (Label)dtlItem.FindControl("lblCon_FirstName");
                Label lblCon_MidName = (Label)dtlItem.FindControl("lblCon_MidName");
                Label lblConLastName = (Label)dtlItem.FindControl("lblConLastName");
                Label lblGender = (Label)dtlItem.FindControl("lblGender");
                Label lblEmailId = (Label)dtlItem.FindControl("lblEmailId");
                Label lblHandphone1 = (Label)dtlItem.FindControl("lblHandphone1");
                Label lblHandphone2 = (Label)dtlItem.FindControl("lblHandphone2");
                Label lblLandline = (Label)dtlItem.FindControl("lblLandline");
                Label lblInstituteType = (Label)dtlItem.FindControl("lblInstituteType");
                Label lblInstitute = (Label)dtlItem.FindControl("lblInstitute");
                Label lblBoard = (Label)dtlItem.FindControl("lblBoard");
                Label lblCurStudying = (Label)dtlItem.FindControl("lblCurStudying");
                Label lblYearOfPassing = (Label)dtlItem.FindControl("lblYearOfPassing");

                dr = tb.NewRow();
                dr["Title"] = lblCon_Title.Text.Trim();
                dr["FirstName"] = lblCon_FirstName.Text.Trim();
                dr["MiddleName"] = lblCon_MidName.Text.Trim();
                dr["LastName"] = lblConLastName.Text.Trim();
                dr["Gender"] = lblGender.Text.Trim();
                dr["EmailId"] = lblEmailId.Text.Trim();
                dr["Handphone1"] = lblHandphone1.Text.Trim();
                dr["Handphone2"] = lblHandphone2.Text.Trim();
                dr["Landline"] = lblLandline.Text.Trim();
                dr["InstitutionType"] = lblInstituteType.Text.Trim();
                dr["Institution"] = lblInstitute.Text.Trim();
                dr["Board"] = lblBoard.Text.Trim();
                dr["CurrentStudying"] = lblCurStudying.Text.Trim();
                dr["YearOfPassing"] = lblYearOfPassing.Text.Trim();
                dr["ErrorMessage"] = lbErrorSaveMessage.Text.Trim();
                tb.Rows.Add(dr);
            }
        }

        if (tb.Rows.Count > 0)
        {
            Response.ContentType = "Application/x-msexcel";
            Response.AddHeader("content-disposition", "attachment;filename=Contact_template" + " " + DateTime.Now + ".csv");
            Response.Write(ExportToCSVFile(tb));
            Response.End();
        }        
    }

    private string ExportToCSVFile(DataTable dtTable)
    {
        StringBuilder sbldr = new StringBuilder();
        if (dtTable.Columns.Count != 0)
        {
            foreach (DataColumn col in dtTable.Columns)
            {
                sbldr.Append(col.ColumnName + ',');
            }
            sbldr.Append("\r\n");
            foreach (DataRow row in dtTable.Rows)
            {
                foreach (DataColumn column in dtTable.Columns)
                {
                    sbldr.Append(row[column].ToString() + ',');
                }
                sbldr.Append("\r\n");
            }
        }
        return sbldr.ToString();
    }
}