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

public partial class ECS_Confirmation : System.Web.UI.Page
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
                lblpagetitle1.Text = "ECS Confirmation";
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

        bool exists = System.IO.Directory.Exists(Server.MapPath("~/ECS_Import"));

        if (!exists)
            System.IO.Directory.CreateDirectory(Server.MapPath("~/ECS_Import"));

        string path = Server.MapPath("~/ECS_Import/" + fluDocUpload.FileName);       


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
        DataSet ds = ProductController.Get_ECS_BankDetail_Dupli(FileName, UserID, "1");
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
        
        string FullName = Server.MapPath("~/ECS_Import") + "\\" + Path.GetFileName(fluDocUpload.FileName);

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

        DataTable dt = new DataTable();

        dt.Columns.Add("LotNo");
        dt.Columns.Add("MessageID");
        dt.Columns.Add("MessageCreationDateTime");
        dt.Columns.Add("InitiatingPartyID");
        dt.Columns.Add("InstructingAgentMemberID");
        dt.Columns.Add("InstructedAgentMemberID");
        dt.Columns.Add("InstructedAgentName");
        dt.Columns.Add("MandateRequestID");
        dt.Columns.Add("MandateCategory");
        dt.Columns.Add("MandateCategoryName");
        dt.Columns.Add("TXNtype");
        dt.Columns.Add("Recurring_or_OneOff");
        dt.Columns.Add("Frequency");
        dt.Columns.Add("FirstCollectionDate");
        dt.Columns.Add("FinalCollectionDate");
        dt.Columns.Add("CollectionAmount");
        dt.Columns.Add("MaximumAmount");
        dt.Columns.Add("Name_of_Utility");
        dt.Columns.Add("Utility_Code");
        dt.Columns.Add("Sponsor_Bank_Code");
        dt.Columns.Add("Debtor_Name");
        dt.Columns.Add("Consumer_Reference_No");
        dt.Columns.Add("Scheme");
        dt.Columns.Add("Debtor_Telephone_No");
        dt.Columns.Add("Debtor_Mobile_No");
        dt.Columns.Add("Debtor_Email");
        dt.Columns.Add("Debtor_other_details");
        dt.Columns.Add("Destination_Bank_Account_Number");
        dt.Columns.Add("Destination_Bank_Account_Type");
        dt.Columns.Add("Destination_Bank_IFSC");
        dt.Columns.Add("Destination_Bank_Name");
        dt.Columns.Add("UMRN_NO");
        dt.Columns.Add("STATUS");
        dt.Columns.Add("RTN_CODE");
        dt.Columns.Add("REASON");
        dt.Columns.Add("ClosureDate");
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
            DataSet ds1 = ProductController.Get_ECS_BankDetail_Dupli(lblFileName.Text, UserID, "1");
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
                Label lblLotNo = (Label)dtlItem.FindControl("lblLotNo");
                Label lblMessageID = (Label)dtlItem.FindControl("lblMessageID");
                Label lblMessageCreationDateTime = (Label)dtlItem.FindControl("lblMessageCreationDateTime");
                Label lblInitiatingPartyID = (Label)dtlItem.FindControl("lblInitiatingPartyID");
                Label lblInstructingAgentMemberID = (Label)dtlItem.FindControl("lblInstructingAgentMemberID");
                Label lblInstructedAgentMemberID = (Label)dtlItem.FindControl("lblInstructedAgentMemberID");
                Label lblInstructedAgentName = (Label)dtlItem.FindControl("lblInstructedAgentName");
                Label lblMandateRequestID = (Label)dtlItem.FindControl("lblMandateRequestID");
                Label lblMandateCategory = (Label)dtlItem.FindControl("lblMandateCategory");
                Label lblMandateCategoryName = (Label)dtlItem.FindControl("lblMandateCategoryName");
                Label lblTXNtype = (Label)dtlItem.FindControl("lblTXNtype");
                Label lblRecurring_or_OneOff = (Label)dtlItem.FindControl("lblRecurring_or_OneOff");
                Label lblFrequency = (Label)dtlItem.FindControl("lblFrequency");
                Label lblFirstCollectionDate = (Label)dtlItem.FindControl("lblFirstCollectionDate");
                Label lblFinalCollectionDate = (Label)dtlItem.FindControl("lblFinalCollectionDate");
                Label lblCollectionAmount = (Label)dtlItem.FindControl("lblCollectionAmount");
                Label lblMaximumAmount = (Label)dtlItem.FindControl("lblMaximumAmount");
                Label lblName_of_Utility = (Label)dtlItem.FindControl("lblName_of_Utility");
                Label lblUtility_Code = (Label)dtlItem.FindControl("lblUtility_Code");
                Label lblSponsor_Bank_Code = (Label)dtlItem.FindControl("lblSponsor_Bank_Code");
                Label lblDebtor_Name = (Label)dtlItem.FindControl("lblDebtor_Name");
                Label lblConsumer_Reference_No = (Label)dtlItem.FindControl("lblConsumer_Reference_No");
                Label lblScheme = (Label)dtlItem.FindControl("lblScheme");
                Label lblDebtor_Telephone_No = (Label)dtlItem.FindControl("lblDebtor_Telephone_No");
                Label lblDebtor_Mobile_No = (Label)dtlItem.FindControl("lblDebtor_Mobile_No");
                Label lblDebtor_Email = (Label)dtlItem.FindControl("lblDebtor_Email");
                Label lblDebtor_other_details = (Label)dtlItem.FindControl("lblDebtor_other_details");
                Label lblDestination_Bank_Account_Number = (Label)dtlItem.FindControl("lblDestination_Bank_Account_Number");
                Label lblDestination_Bank_Account_Type = (Label)dtlItem.FindControl("lblDestination_Bank_Account_Type");
                Label lblDestination_Bank_IFSC = (Label)dtlItem.FindControl("lblDestination_Bank_IFSC");
                Label lblDestination_Bank_Name = (Label)dtlItem.FindControl("lblDestination_Bank_Name");
                Label lblUMRN_NO = (Label)dtlItem.FindControl("lblUMRN_NO");
                Label lblSTATUS = (Label)dtlItem.FindControl("lblSTATUS");
                Label lblRTN_CODE = (Label)dtlItem.FindControl("lblRTN_CODE");
                Label lblREASON = (Label)dtlItem.FindControl("lblREASON");
                Label lblClosureDate = (Label)dtlItem.FindControl("lblClosureDate");

                Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lbErrorSaveMessage");               
                

                //if any error not come then Pass Record to save Procedure
                if (lbErrorSaveMessage.Text == "")
                {
                    XMLData = XMLData + "<ExcelData><RowNum>" + lblRowNum.Text + "</RowNum><LotNo>" + lblLotNo.Text + "</LotNo><MessageID>" + lblMessageID.Text + "</MessageID><MessageCreationDateTime>" + lblMessageCreationDateTime.Text + "</MessageCreationDateTime><InitiatingPartyID>" +
                              lblInitiatingPartyID.Text + "</InitiatingPartyID><InstructingAgentMemberID>" + lblInstructingAgentMemberID.Text + "</InstructingAgentMemberID><InstructedAgentMemberID>" + lblInstructedAgentMemberID.Text + "</InstructedAgentMemberID><InstructedAgentName>"+
                              lblInstructedAgentName.Text + "</InstructedAgentName><MandateRequestID>" + lblMandateRequestID.Text + "</MandateRequestID><MandateCategory>" + lblMandateCategory.Text + "</MandateCategory><MandateCategoryName>"+
                              lblMandateCategoryName.Text + "</MandateCategoryName><TXNtype>" + lblTXNtype.Text + "</TXNtype><Recurring_or_OneOff>" + lblRecurring_or_OneOff.Text + "</Recurring_or_OneOff><Frequency>" + lblFrequency.Text + "</Frequency><FirstCollectionDate>"+
                              lblFirstCollectionDate.Text + "</FirstCollectionDate><FinalCollectionDate>" + lblFinalCollectionDate.Text + "</FinalCollectionDate><CollectionAmount>" + lblCollectionAmount.Text + "</CollectionAmount><MaximumAmount>" +
                              lblMaximumAmount.Text + "</MaximumAmount><Name_of_Utility>" + lblName_of_Utility.Text + "</Name_of_Utility><Utility_Code>" + lblUtility_Code.Text + "</Utility_Code><Sponsor_Bank_Code>" + lblSponsor_Bank_Code.Text + "</Sponsor_Bank_Code><Debtor_Name>"+
                              lblDebtor_Name.Text + "</Debtor_Name><Consumer_Reference_No>" + lblConsumer_Reference_No.Text + "</Consumer_Reference_No><Scheme>" + lblScheme.Text + "</Scheme><Debtor_Telephone_No>" + lblDebtor_Telephone_No.Text + "</Debtor_Telephone_No><Debtor_Mobile_No>" +
                              lblDebtor_Mobile_No.Text + "</Debtor_Mobile_No><Debtor_Email>" + lblDebtor_Email.Text + "</Debtor_Email><Debtor_other_details>" + lblDebtor_other_details.Text + "</Debtor_other_details><Destination_Bank_Account_Number>" +
                              lblDestination_Bank_Account_Number.Text + "</Destination_Bank_Account_Number><Destination_Bank_Account_Type>" + lblDestination_Bank_Account_Type.Text + "</Destination_Bank_Account_Type><Destination_Bank_IFSC>" +
                              lblDestination_Bank_IFSC.Text + "</Destination_Bank_IFSC><Destination_Bank_Name>" + lblDestination_Bank_Name.Text + "</Destination_Bank_Name><UMRN_NO>" + lblUMRN_NO.Text + "</UMRN_NO><STATUS>" + lblSTATUS.Text + "</STATUS><RTN_CODE>"+
                              lblRTN_CODE.Text + "</RTN_CODE><REASON>" + lblREASON.Text + "</REASON><ClosureDate>" + lblClosureDate.Text + "</ClosureDate></ExcelData>";
                }
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

            DataSet ds = ProductController.Insert_ECS_BankDetail_ExportSave(XMLData, lblFileName.Text, UserID, "1");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ErrorSaveCode"].ToString() == "1")
                    {
                        divErrormessage.Visible = false;
                        divSuccessmessage.Visible = true;
                        lblsuccessMessage.Text = ds.Tables[0].Rows[0]["ErrorSaveMessage"].ToString();

                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            foreach (DataListItem dtlItem in dlGridDisplay.Items)
                            {
                                Label lblRowNum = (Label)dtlItem.FindControl("lblRowNum");
                                Label lbErrorSaveMessage = (Label)dtlItem.FindControl("lbErrorSaveMessage");

                                if (ds.Tables[1].Rows[i]["RowNum"].ToString() == lblRowNum.Text) //Check correct Record
                                {
                                    if (ds.Tables[1].Rows[i]["ErrorSaveId"].ToString() == "1") //if the record is saved
                                    {
                                        lbErrorSaveMessage.CssClass = "green";                                        
                                    }
                                    else//if the record is not saved (any error is come)
                                    {
                                        lbErrorSaveMessage.CssClass = "red";
                                    }
                                    lbErrorSaveMessage.Text = ds.Tables[1].Rows[i]["ErrorSaveMessage"].ToString();
                                }
                            }
                        }
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