using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Data.OleDb;
using System.IO;
using System.Data.Odbc;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using ShoppingCart.BL;

public partial class FilesImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        Abc();
    }
    protected void Abc()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        if (!string.IsNullOrEmpty(uploadfile.FileName))
        {
           // lbluploadfileName.Text = Path.GetFileName(uploadfile.FileName);
            string FullName = Server.MapPath("~/FileImport") + "\\" + Path.GetFileName(uploadfile.FileName);
            lblfilepath.Text = uploadfile.FileName;

            string strFileType = Path.GetExtension(uploadfile.FileName).ToLower();
            string Import_Id = ProductController.GetImport_Id(3, lblfilepath.Text, UserID, 1);
            lblimport.Text = Import_Id;
            
            if (strFileType != ".csv")
            {
                Show_Error_Success_Box("E", "File should be in csv fromat");
                return;
            }
            else if (Import_Id == "0")
            {
                try
                {
                    uploadfile.SaveAs(FullName);
                }
                catch
                {
                    Show_Error_Success_Box("E", "This file already exists change filename and upload again.");
                    return;
                }

                DataTable dtRaw = new DataTable();

                //create object for CSVReader and pass the stream
                ////CSVReader reader = new CSVReader(FFLExcel.PostedFile.InputStream);
                FileStream fileStream = new FileStream(FullName, FileMode.Open);
                CSVReader reader = new CSVReader(fileStream);
                //get the header
                string[] headers = reader.GetCSVLine();

                //add headers
                foreach (string strHeader in headers)
                {
                    dtRaw.Columns.Add(strHeader);
                }               
                int CurRowNo = 0;
                //  DateTime.ParseExact(lblP_O_Date.Text.Trim(), "MM/dd/yyyy", null).ToString("dd/MM/yyyy");
                string[] data = null;
                data = reader.GetCSVLine();
                //Read first line
                CurRowNo = 1;
                while (data != null)
                {
                    dtRaw.Rows.Add(data);

                    data = reader.GetCSVLine();
                    //Read next line
                    CurRowNo = CurRowNo + 1;
                }
                
                datalist_NewUploads1.DataSource = dtRaw;
               datalist_NewUploads1.DataBind();
                
                lbltotalcount.Text =dtRaw.Rows.Count.ToString();
                datalist_NewUploads1.Visible = true;
                New_UploadGrid.Visible = true;
                New_UploadGrid1.Visible = true;
                Msg_Error.Visible = false;
                ControlVisibility("Result");                
            }
            else
            {
                Show_Error_Success_Box("E", "File Already Exists");
                ControlVisibility("Search");
                return;
            }
        }
        else
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblfilepath.Text = "";
            lblerror.Text = "Please Select File...!";
            return;
        }

    }
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
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string ResultId="0";
        if (lblfilepath.Text == "")
        {
            Show_Error_Success_Box("E", "File not found");
            return;
        }

        string XMLData = "<BRS>";

        string Import_Id = ProductController.GetImport_Id(1, lblfilepath.Text, UserID, 1);
        if (Import_Id != "-1")
        {
            foreach (DataListItem item in datalist_NewUploads1.Items)
            {
                //if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                //{
                    Label lblTYPE = (Label)item.FindControl("lblTYPE");
                    Label lblCLCODE = (Label)item.FindControl("lblCLCODE");
                    Label lblBANK_ACCOUNT = (Label)item.FindControl("lblBANK_ACCOUNT");
                    Label lblPRDCODE = (Label)item.FindControl("lblPRDCODE");
                    Label lblLOCATION = (Label)item.FindControl("lblLOCATION");
                    Label lblLOCATION_NAME = (Label)item.FindControl("lblLOCATION_NAME");
                    Label lblDEPDATE = (Label)item.FindControl("lblDEPDATE");
                    Label lblRTNDATE = (Label)item.FindControl("lblRTNDATE");
                    Label LBLCLGTYPE = (Label)item.FindControl("LBLCLGTYPE");
                    Label LBLCRDATE = (Label)item.FindControl("LBLCRDATE");
                    Label lblSLIPNO = (Label)item.FindControl("lblSLIPNO");
                    Label lblTOTAL_INSTRUMENTS = (Label)item.FindControl("lblTOTAL_INSTRUMENTS");
                    Label lblSLIPAMOUNT = (Label)item.FindControl("lblSLIPAMOUNT");
                    Label lblINSTRUMENTNO = (Label)item.FindControl("lblINSTRUMENTNO");
                    Label lblINSTRUMENTTYPE = (Label)item.FindControl("lblINSTRUMENTTYPE");
                    Label lblINSTRUMENTDATE = (Label)item.FindControl("lblINSTRUMENTDATE");
                    Label lblINSTRUMENTAMNT = (Label)item.FindControl("lblINSTRUMENTAMNT");
                    Label lblRECOVEREDAMNT = (Label)item.FindControl("lblRECOVEREDAMNT");
                    Label lblDRAWNON = (Label)item.FindControl("lblDRAWNON");
                    Label lblDRAWNONLOC = (Label)item.FindControl("lblDRAWNONLOC");
                    Label lblDRWANBANK = (Label)item.FindControl("lblDRWANBANK");
                    Label lblDRAWERNAME = (Label)item.FindControl("lblDRAWERNAME");
                    Label lblDRAWNBRANCH = (Label)item.FindControl("lblDRAWNBRANCH");
                    Label lblRTN_REASON = (Label)item.FindControl("lblRTN_REASON");
                    Label lblRTN = (Label)item.FindControl("lblRTN");
                    Label lblINST_ADD_INFO = (Label)item.FindControl("lblINST_ADD_INFO");
                    Label lblINST_ADD_INFO2 = (Label)item.FindControl("lblINST_ADD_INFO2");
                    Label lblINST_ADD_INFO3 = (Label)item.FindControl("lblINST_ADD_INFO3");
                    Label lblINST_ADD_INFO4 = (Label)item.FindControl("lblINST_ADD_INFO4");
                    Label lblREMARKS = (Label)item.FindControl("lblREMARKS");
                    Label lblSTATUS = (Label)item.FindControl("lblSTATUS");


                    XMLData = XMLData + "<BankFileUpload><TYPE>" + lblTYPE.Text + "</TYPE><CLCODE>" + lblCLCODE.Text + "</CLCODE><BANK_ACCOUNT>" + lblBANK_ACCOUNT.Text + "</BANK_ACCOUNT><PRDCODE>" + lblPRDCODE.Text +
                              "</PRDCODE><LOCATION>" + lblLOCATION.Text + "</LOCATION><LOCATION_NAME>" + lblLOCATION_NAME.Text + "</LOCATION_NAME><DEPDATE>" + lblDEPDATE.Text + "</DEPDATE><CLGTYPE>" + LBLCLGTYPE.Text +
                              "</CLGTYPE><CRDATE>" + LBLCRDATE.Text + "</CRDATE><RTNDATE>" + lblRTNDATE.Text + "</RTNDATE><SLIPNO>" + lblSLIPNO.Text + "</SLIPNO><TOTAL_INSTRUMENTS>" + lblTOTAL_INSTRUMENTS.Text +
                              "</TOTAL_INSTRUMENTS><SLIPAMOUNT>" + lblSLIPAMOUNT.Text + "</SLIPAMOUNT><INSTRUMENTNO>" + lblINSTRUMENTNO.Text + "</INSTRUMENTNO><INSTRUMENTTYPE>" + lblINSTRUMENTTYPE.Text +
                              "</INSTRUMENTTYPE><INSTRUMENTDATE>" + lblINSTRUMENTDATE.Text + "</INSTRUMENTDATE><INSTRUMENTAMNT>" + lblINSTRUMENTAMNT.Text + "</INSTRUMENTAMNT><RECOVEREDAMNT>" + lblRECOVEREDAMNT.Text +
                              "</RECOVEREDAMNT><DRAWNON>" + lblDRAWNON.Text + "</DRAWNON><DRAWNONLOC>" + lblDRAWNONLOC.Text + "</DRAWNONLOC><DRWANBANK>" + lblDRWANBANK.Text + "</DRWANBANK><DRAWNBRANCH>" + lblDRAWNBRANCH.Text +
                              "</DRAWNBRANCH><DRAWERNAME>" + lblDRAWERNAME.Text + "</DRAWERNAME><RTN>" + lblRTN.Text + "</RTN><RTN_REASON>" + lblRTN_REASON.Text + "</RTN_REASON><INST_ADD_INFO>" + lblINST_ADD_INFO.Text +
                              "</INST_ADD_INFO><INST_ADD_INFO2>" + lblINST_ADD_INFO2.Text + "</INST_ADD_INFO2><INST_ADD_INFO3>" + lblINST_ADD_INFO3.Text + "</INST_ADD_INFO3><INST_ADD_INFO4>" + lblINST_ADD_INFO4.Text +
                              "</INST_ADD_INFO4><REMARKS>" + lblREMARKS.Text + "</REMARKS><STATUS>" + lblSTATUS.Text + "</STATUS><UserID>" + UserID + "</UserID><Import_Id>" + Import_Id + "</Import_Id></BankFileUpload>";
                    //ResultId = ProductController.InsertBankDetails(lblTYPE.Text, lblCLCODE.Text, lblBANK_ACCOUNT.Text, lblPRDCODE.Text, lblLOCATION.Text, lblLOCATION_NAME.Text, lblDEPDATE.Text, LBLCLGTYPE.Text, LBLCRDATE.Text, 
                    //lblRTNDATE.Text, lblSLIPNO.Text, lblTOTAL_INSTRUMENTS.Text, lblSLIPAMOUNT.Text, lblINSTRUMENTNO.Text, lblINSTRUMENTTYPE.Text, lblINSTRUMENTDATE.Text, lblINSTRUMENTAMNT.Text, lblRECOVEREDAMNT.Text, 
                //lblDRAWNON.Text, lblDRAWNONLOC.Text, lblDRWANBANK.Text, lblDRAWNBRANCH.Text, lblDRAWERNAME.Text, lblRTN.Text, lblRTN_REASON.Text, lblINST_ADD_INFO.Text, 
                //lblINST_ADD_INFO2.Text, lblINST_ADD_INFO3.Text, lblINST_ADD_INFO4.Text, lblREMARKS.Text, lblSTATUS.Text, UserID, Import_Id, 2);
                //}
            }

            XMLData =XMLData + "</BRS>";

            if (XMLData != "<BRS></BRS>")
            {
                

            // replace literal values with entities
             
                XMLData = XMLData.Replace("&", "&amp;");


                DataSet ds = ProductController.Insert_BRS_BankUpload("1", XMLData);

                if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() == "1")
                {

                    DataSet ds1 = ProductController.BRS_BankUpload_Error("1", UserID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        Divdatamismatch.Visible = true;
                        Divchequemismatch.Visible = true;
                        datalistcheque.DataSource = ds1;
                        datalistcheque.DataBind();
                        

                        datalist_NewUploads1.DataSource = ds1;
                        datalist_NewUploads1.DataBind();
                        datalist_NewUploads1.Visible = false;
                        New_UploadGrid.Visible = false;
                        New_UploadGrid1.Visible = false;


                    }
                    else
                    {
                        Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
                        ControlVisibility("Search");
                        lblfilepath.Text = "";
                    }
                }
                else
                {
                    Show_Error_Success_Box("E", ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString());
                    ControlVisibility("Result");
                    return;
                }

                

            }
            else
            {
                Show_Error_Success_Box("E", "Records not found");
                return;
            }

            //if (ResultId == "1")
            //{
            //    Show_Error_Success_Box("S", "Records Save Successfully");
            //    ControlVisibility("Search");
            //    lblfilepath.Text = "";
            //}
            //else
            //{
            //    Show_Error_Success_Box("E", "Records Not  Saved");
            //    ControlVisibility("Result");
            //}
        }
        else
        {
            Show_Error_Success_Box("E", "File Already Exists");
            ControlVisibility("Result");
        }
       
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            New_UploadGrid.Visible = false;
            DivNew_Upload.Visible = true;
        }
        if (Mode == "Result")
        {
            New_UploadGrid.Visible = true;
            //search.Visible = false;
            DivNew_Upload.Visible = false;
        }

    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        datalist_NewUploads1.Visible = true;
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "ChequeStatus" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='32'>Cheque Status</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        datalist_NewUploads1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
        datalist_NewUploads1.Visible = false;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds1 = ProductController.BRS_BankUpload_Error("2", UserID);
        


    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        lblfilepath.Text = "";
        ControlVisibility("Search");
    }
    protected void btnClose_Click1(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        //lblfilepath.Text = "";
        ControlVisibility("Search");
        Divdatamismatch.Visible = false;
        Divchequemismatch.Visible = false;

    }
}