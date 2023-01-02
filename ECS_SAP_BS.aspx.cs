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
using Encryption.BL;
using System.ComponentModel;
using System.Text;
using System.Drawing;

using System.Data.OleDb;

public partial class ECS_SAP_BS : System.Web.UI.Page
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
                lblpagetitle1.Text = "ECS SAP Bank Statements";
                lblpagetitle2.Text = "Search Panel";
                //lblmidbreadcrumb.Text = "Manage Account";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                //DivECSDetail.Visible = false;
                //upnlsearch.Visible = true;
                btnsearchback.Visible = false;
                btnsearchback.Visible = false;                
                divSearch.Visible = true;
                divsearchresults.Visible = false;
                
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

    }


    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }


    
    

    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        divErrormessage.Visible = false;
        divSuccessmessage.Visible = false;

        bool exists = System.IO.Directory.Exists(Server.MapPath("~/ECS_SAP_BS_Import"));

        if (!exists)
            System.IO.Directory.CreateDirectory(Server.MapPath("~/ECS_SAP_BS_Import"));

        string path = Server.MapPath("~/ECS_SAP_BS_Import/" + fluDocUpload.FileName);

        string FileName = Path.GetFileName(fluDocUpload.FileName);

        lblFileName.Text = FileName;

        if (FileName.Length > 50)
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = "File Name length not more than 45 characters";
            return;
        }

        string strFileType = Path.GetExtension(fluDocUpload.FileName).ToLower();
        if (strFileType != ".csv")
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = "Kindly Select Excel File With .CSV Extension";
            return;
        }

        if (File.Exists(path.ToString().ToUpper()))
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = "This File is already Exist Rename file name and upload again";
            return;
        }

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        DataSet ds = ProductController.Get_ECS_SAP_Bank_Statement_Dupli(FileName, UserID, "1");
        if (ds != null)
        {
            if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() != "0")
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Text = "This file already uploaded. Rename your file and upload again.";
                return;
            }
        }
        else
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = "Search Time Error Please Contact to administrator";
            return;
        }


        // fluDocUpload.FileName is fileupload control name
        //if (!File.Exists(path.ToString().ToUpper()))
        //{
            fluDocUpload.SaveAs(path);
        //}

            string FullName = Server.MapPath("~/ECS_SAP_BS_Import") + "\\" + Path.GetFileName(fluDocUpload.FileName);

        DataTable dtRaw = new DataTable();

        //create object for CSVReader and pass the stream
        FileStream fileStream = new FileStream(FullName, FileMode.Open);
        CSVReader reader = new CSVReader(fileStream);
        //get the header
        string[] headers = reader.GetCSVLine();

        int r = 0;
        //add headers
        foreach (string strHeader in headers)
        {
            try
            {
                dtRaw.Columns.Add(strHeader);
            }
            catch
            {
                r = r + 1;
                dtRaw.Columns.Add(strHeader + r.ToString());
            }
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

        DataTable dt = new DataTable();

        dt.Columns.Add("ACH_Transaction_Code");
        dt.Columns.Add("Control");
        dt.Columns.Add("Destination_Account_Type");
        dt.Columns.Add("Ledger_Folio_Number");
        dt.Columns.Add("Control1");
        dt.Columns.Add("Beneficiary_Account_Holders_Name");
        dt.Columns.Add("Control2");
        dt.Columns.Add("Control3");
        dt.Columns.Add("User_Name_Narration");
        dt.Columns.Add("Control4");
        dt.Columns.Add("Amount");
        dt.Columns.Add("Reserved_ACH_Item_Seq_No");
        dt.Columns.Add("Reserved_Checksum");
        dt.Columns.Add("Reserved_Flag_for_success_return");
        dt.Columns.Add("Reserved_Reason_Code");
        dt.Columns.Add("Destination_Bank_IFSC_MICR_IIN");
        dt.Columns.Add("Beneficiarys_Bank_Account_number");
        dt.Columns.Add("Sponsor_Bank_IFSC_MICR_IIN");
        dt.Columns.Add("User_Number");
        dt.Columns.Add("Transaction_Reference");
        dt.Columns.Add("Product_Type");
        dt.Columns.Add("Beneficiary_Aadhaar_Number");
        dt.Columns.Add("UMRN");
        //dt.Columns.Add("Filler");
        dt.Columns.Add("STATUS");
        dt.Columns.Add("RETURN_CODE");
        dt.Columns.Add("REASON");
        dt.Columns.Add("RowNum");


        if (dtRaw.Columns.Count != dt.Columns.Count - 1)
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = "Format of the uploaded file does not match.";
            return;
        }
        
        for (int i = 0; i < dtRaw.Rows.Count; i++)
        {
            dt.ImportRow(dtRaw.Rows[i]);
        }


        for (int i = 0; i < dtRaw.Rows.Count; i++)
        {
            dt.Rows[i]["RowNum"] = (i + 1).ToString();
            for (int j = 0; j < dtRaw.Columns.Count; j++)
            {               
                dt.Rows[i][j] = dtRaw.Rows[i][j].ToString();
            }
        }
        
        if (dt.Rows.Count == 0)
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = "Invalid Excel sheet(Record not found in your excel sheet)";    
            return;
        }

        dlGridDisplay.DataSource = dt;
        dlGridDisplay.DataBind();


        Divsearchcriteria.Visible = false;
        divsearchresults.Visible = true;
        btnsearchback.Visible = true;
    }
  
    /// <summary>
    /// 

    protected void btnsearchback_ServerClick(object sender, System.EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        btnsearchback.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;     
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            divErrormessage.Visible = false;
            divSuccessmessage.Visible = false;


            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            DataSet ds1 = ProductController.Get_ECS_SAP_Bank_Statement_Dupli(lblFileName.Text, UserID, "1");
            if (ds1 != null)
            {
                if (ds1.Tables[0].Rows[0]["ErrorSaveCode"].ToString() != "0")
                {
                    divErrormessage.Visible = true;
                    divSuccessmessage.Visible = false;
                    lblerrormessage.Text = "This file already uploaded. Rename your file and upload again.";
                    return;
                }
            }
            else
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Text = "Save Time Error Please Contact to administrator";
                return;
            }


            string XMLData = "<ExcelList>";
            foreach (DataListItem dtlItem in dlGridDisplay.Items)
            {
                Label lblRowNum = (Label)dtlItem.FindControl("lblRowNum");
                Label lblACH_Transaction_Code = (Label)dtlItem.FindControl("lblACH_Transaction_Code");
                Label lblControl = (Label)dtlItem.FindControl("lblControl");
                Label lblDestination_Account_Type = (Label)dtlItem.FindControl("lblDestination_Account_Type");
                Label lblLedger_Folio_Number = (Label)dtlItem.FindControl("lblLedger_Folio_Number");
                Label lblControl1 = (Label)dtlItem.FindControl("lblControl1");
                Label lblBeneficiary_Account_Holders_Name = (Label)dtlItem.FindControl("lblBeneficiary_Account_Holders_Name");
                Label lblControl2 = (Label)dtlItem.FindControl("lblControl2");
                Label lblControl3 = (Label)dtlItem.FindControl("lblControl3");
                Label lblUser_Name_Narration = (Label)dtlItem.FindControl("lblUser_Name_Narration");
                Label lblControl4 = (Label)dtlItem.FindControl("lblControl4");
                Label lblAmount = (Label)dtlItem.FindControl("lblAmount");
                Label lblReserved_ACH_Item_Seq_No = (Label)dtlItem.FindControl("lblReserved_ACH_Item_Seq_No");
                Label lblReserved_Checksum = (Label)dtlItem.FindControl("lblReserved_Checksum");
                Label lblReserved_Flag_for_success_return = (Label)dtlItem.FindControl("lblReserved_Flag_for_success_return");
                Label lblReserved_Reason_Code = (Label)dtlItem.FindControl("lblReserved_Reason_Code");
                Label lblDestination_Bank_IFSC_MICR_IIN = (Label)dtlItem.FindControl("lblDestination_Bank_IFSC_MICR_IIN");
                Label lblBeneficiarys_Bank_Account_number = (Label)dtlItem.FindControl("lblBeneficiarys_Bank_Account_number");
                Label lblSponsor_Bank_IFSC_MICR_IIN = (Label)dtlItem.FindControl("lblSponsor_Bank_IFSC_MICR_IIN");
                Label lblUser_Number = (Label)dtlItem.FindControl("lblUser_Number");
                Label lblTransaction_Reference = (Label)dtlItem.FindControl("lblTransaction_Reference");
                Label lblProduct_Type = (Label)dtlItem.FindControl("lblProduct_Type");
                Label lblBeneficiary_Aadhaar_Number = (Label)dtlItem.FindControl("lblBeneficiary_Aadhaar_Number");
                Label lblUMRN = (Label)dtlItem.FindControl("lblUMRN");
                //Label lblFiller = (Label)dtlItem.FindControl("lblFiller");
                Label lblSTATUS = (Label)dtlItem.FindControl("lblSTATUS");
                Label lblRETURN_CODE = (Label)dtlItem.FindControl("lblRETURN_CODE");
                Label lblREASON = (Label)dtlItem.FindControl("lblREASON");



                XMLData = XMLData + "<ExcelData><RowNum>" + lblRowNum.Text + "</RowNum><ACH_Transaction_Code>" + lblACH_Transaction_Code.Text + "</ACH_Transaction_Code><Control>" + lblControl.Text + "</Control><Destination_Account_Type>" + lblDestination_Account_Type.Text + "</Destination_Account_Type><Ledger_Folio_Number>" +
                              lblLedger_Folio_Number.Text + "</Ledger_Folio_Number><Control1>" + lblControl1.Text + "</Control1><Beneficiary_Account_Holders_Name>" + lblBeneficiary_Account_Holders_Name.Text + "</Beneficiary_Account_Holders_Name><Control2>" +
                              lblControl2.Text + "</Control2><Control3>" + lblControl3.Text + "</Control3><User_Name_Narration>" + lblUser_Name_Narration.Text + "</User_Name_Narration><Control4>" +
                              lblControl4.Text + "</Control4><Amount>" + lblAmount.Text + "</Amount><Reserved_ACH_Item_Seq_No>" + lblReserved_ACH_Item_Seq_No.Text + "</Reserved_ACH_Item_Seq_No><Reserved_Checksum>" + lblReserved_Checksum.Text + "</Reserved_Checksum><Reserved_Flag_for_success_return>" +
                              lblReserved_Flag_for_success_return.Text + "</Reserved_Flag_for_success_return><Reserved_Reason_Code>" + lblReserved_Reason_Code.Text + "</Reserved_Reason_Code><Destination_Bank_IFSC_MICR_IIN>" + lblDestination_Bank_IFSC_MICR_IIN.Text + "</Destination_Bank_IFSC_MICR_IIN><Beneficiarys_Bank_Account_number>" +
                              lblBeneficiarys_Bank_Account_number.Text + "</Beneficiarys_Bank_Account_number><Sponsor_Bank_IFSC_MICR_IIN>" + lblSponsor_Bank_IFSC_MICR_IIN.Text + "</Sponsor_Bank_IFSC_MICR_IIN><User_Number>" + lblUser_Number.Text + "</User_Number><Transaction_Reference>" + lblTransaction_Reference.Text + "</Transaction_Reference><Product_Type>" +
                              lblProduct_Type.Text + "</Product_Type><Beneficiary_Aadhaar_Number>" + lblBeneficiary_Aadhaar_Number.Text + "</Beneficiary_Aadhaar_Number><UMRN>" + lblUMRN.Text + "</UMRN><STATUS>" + lblSTATUS.Text + "</STATUS><RETURN_CODE>" +
                              lblRETURN_CODE.Text + "</RETURN_CODE><REASON>" + lblREASON.Text + "</REASON><Excel_File_Name>"+ lblFileName.Text +"</Excel_File_Name></ExcelData>";
                
            }

            XMLData = XMLData + "</ExcelList>";
            if (XMLData == "<ExcelList></ExcelList>")
            {
                divErrormessage.Visible = true;
                divSuccessmessage.Visible = false;
                lblerrormessage.Text = "No Record Found.";
                return;
            }

            XMLData = XMLData.Replace("&", "&amp;");

            DataSet ds = ProductController.Insert_ECS_SAP_Bank_Statements_ExportSave(XMLData, lblFileName.Text, UserID, "1");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() == "1")
                    {
                        divErrormessage.Visible = false;
                        divSuccessmessage.Visible = true;
                        lblsuccessMessage.Text = ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString();
                        Export_ECS_SAP_Bank_Statement(ds.Tables[0].Rows[0]["PKey"].ToString());                        
                    }
                    else
                    {
                        divErrormessage.Visible = true;
                        divSuccessmessage.Visible = false;
                        lblerrormessage.Text = ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString();
                       
                    }
                }

            }

        }
        catch (Exception ex)
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = ex.ToString();
            return;
        }
    }

    private void Export_ECS_SAP_Bank_Statement(string ExcelFileNo)
    {
        DataSet ds = ProductController.Export_ECS_SAP_Bank_Statements(ExcelFileNo, "1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView GridView1 = new GridView();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=ECS_SAP_BankStatement_" + DateTime.Now + ".xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string style = @"<style> td { mso-number-format:\@;} </style>";
            Response.Write(style);
            Response.Write(sw.ToString());
            Response.End();
        }                       
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        upnlsearch.Visible = true;
        Divsearchcriteria.Visible = true;
        divsearchresults.Visible = false;
        btnsearchback.Visible = false;
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;     
    }
}