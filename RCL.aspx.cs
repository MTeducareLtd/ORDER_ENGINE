using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using ShoppingCart.BL;

public partial class RCL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BaseFont f_cb = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        BaseFont f_cn = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        string SBECode = null;
        SBECode = Request.QueryString["SBECode"];
        string PPCode = null;
        PPCode = Request.QueryString["PPCode"];
        if (!IsPostBack)
        {
            try
            {
                if (SBECode != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string UserID = cookie.Values["UserID"];
                    string UserName = cookie.Values["UserName"];
                    DataSet Result = ProductController_Report.GetStudentPrintReceipt(SBECode, PPCode, 1);
                    if (Result != null)
                    {
                        if (Result.Tables[0].Rows.Count > 0)
                        {
                            string CompanyName = Result.Tables[3].Rows[0]["receipt_head1"].ToString();
                            string Admission_id = Result.Tables[2].Rows[0]["sbentrycode"].ToString();
                            //string Transaction_No = Result.Tables[0].Rows[0]["Pay_Receipt_Id"].ToString();

                            DataRow drreceipt = Result.Tables[0].Rows[0];
                            DataRow drTotal = Result.Tables[1].Rows[0];
                            DataRow drpersonaldtls = Result.Tables[2].Rows[0];
                            DataRow drCompanydtls = Result.Tables[3].Rows[0];
                            DataRow drfeesdtls = Result.Tables[5].Rows[0];
                            DataRow dramtinwords = Result.Tables[6].Rows[0];
                            try
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                                    // Add meta information to the document
                                    document.AddAuthor(drCompanydtls["receipt_head1"].ToString());
                                    document.AddCreator(drCompanydtls["receipt_head1"].ToString());
                                    document.AddKeywords("");
                                    document.AddSubject("Receipt-Cum-Confirmation Letter");
                                    document.AddTitle("Receipt-Cum-Confirmation Letter");

                                    // Open the document to enable you to write to the document
                                    document.Open();
                                    // Makes it possible to add text to a specific place in the document using 
                                    // a X & Y placement syntax.
                                    PdfContentByte cb = writer.DirectContent;
                                    cb.SetFontAndSize(f_cb, 16);
                                    // First we must activate writing
                                    cb.BeginText();
                                    cb.Rectangle(10, 10, 575, 820);
                                    cb.Stroke();
                                    // Add an image to a fixed position from a URL
                                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("https://OE.MTeducare.com/Order_Engine/" + drCompanydtls["ReceiptLogoImagePath"].ToString());
                                    img.SetAbsolutePosition(12, 750);
                                    img.ScaleAbsolute(110, 65);
                                    cb.AddImage(img);
                                    iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_BOLD, 15);
                                    iTextSharp.text.Font font6 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES, 9);
                                    iTextSharp.text.Font font7 = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_BOLD, 11);

                                    PdfPTable table1 = new PdfPTable(1);
                                    table1.DefaultCell.Border = Rectangle.NO_BORDER;
                                    table1.HorizontalAlignment = 1;
                                    table1.TotalWidth = 450;

                                    PdfPCell cell = new PdfPCell(new Phrase((drCompanydtls["receipt_head1"].ToString()), font5));
                                    cell.Colspan = 1;
                                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                                    cell.BorderWidthBottom = 0f;
                                    cell.BorderWidthLeft = 0f;
                                    cell.BorderWidthTop = 0f;
                                    cell.BorderWidthRight = 0f;
                                    table1.AddCell(cell);
                                    PdfPCell cell1 = new PdfPCell(new Phrase((drCompanydtls["receipt_head2"].ToString()), font6));
                                    cell1.Colspan = 1;
                                    cell1.HorizontalAlignment = 1;
                                    cell1.BorderWidthBottom = 0f;
                                    cell1.BorderWidthLeft = 0f;
                                    cell1.BorderWidthTop = 0f;
                                    cell1.BorderWidthRight = 0f;
                                    table1.AddCell(cell1);
                                    PdfPCell cell2 = new PdfPCell(new Phrase((drCompanydtls["ReceiptHead3"].ToString()), font6));
                                    cell2.Colspan = 1;
                                    cell2.HorizontalAlignment = 1;
                                    cell2.BorderWidthBottom = 0f;
                                    cell2.BorderWidthLeft = 0f;
                                    cell2.BorderWidthTop = 0f;
                                    cell2.BorderWidthRight = 0f;
                                    table1.AddCell(cell2);
                                    PdfPCell cell3 = new PdfPCell(new Phrase(("Website: " + drCompanydtls["receiptheaderline2"].ToString()), font6));
                                    cell3.Colspan = 1;
                                    cell3.HorizontalAlignment = 1;
                                    cell3.BorderWidthBottom = 0f;
                                    cell3.BorderWidthLeft = 0f;
                                    cell3.BorderWidthTop = 0f;
                                    cell3.BorderWidthRight = 0f;
                                    table1.AddCell(cell3);
                                    PdfPCell cell4 = new PdfPCell(new Phrase((drCompanydtls["receipt_head5"].ToString()), font6));
                                    cell4.Colspan = 1;
                                    cell4.HorizontalAlignment = 1;
                                    cell4.BorderWidthBottom = 0f;
                                    cell4.BorderWidthLeft = 0f;
                                    cell4.BorderWidthTop = 0f;
                                    cell4.BorderWidthRight = 0f;
                                    table1.AddCell(cell4);
                                    table1.WriteSelectedRows(0, -1, 125, 830, cb);

                                    PdfPTable table2 = new PdfPTable(1);
                                    table2.DefaultCell.Border = Rectangle.NO_BORDER;
                                    table2.HorizontalAlignment = 1;
                                    table2.TotalWidth = 625;

                                    PdfPCell cell5 = new PdfPCell(new Phrase((drCompanydtls["receipt_name"].ToString()), font7));
                                    cell5.Colspan = 1;
                                    cell5.HorizontalAlignment = 1;
                                    cell5.BorderWidthBottom = 0f;
                                    cell5.BorderWidthLeft = 0f;
                                    cell5.BorderWidthTop = 0f;
                                    cell5.BorderWidthRight = 0f;
                                    table2.AddCell(cell5);

                                    table2.WriteSelectedRows(0, -1, 0, 740, cb);
                                    cb.EndText();


                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(10, 725);
                                    cb.LineTo(585, 725);
                                    cb.Stroke();

                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(15, 710); // Left, Top
                                    cb.ShowText("Date:");

                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(72, 710); // Left, Top
                                    cb.ShowText(drpersonaldtls["ReceiptDate"].ToString());

                                    cb.EndText();
                                    
                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(72, 705);
                                    cb.LineTo(125, 705);
                                    cb.Stroke();
                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(455, 710); // Left, Top
                                    cb.ShowText("Sr #:");

                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(485, 710); // Left, Top
                                    cb.ShowText(drpersonaldtls["sbentrycode"].ToString());

                                    cb.EndText();
                                    
                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(485, 705);
                                    cb.LineTo(580, 705);
                                    cb.Stroke();

                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(15, 690); // Left, Top
                                    cb.ShowText("We hereby confirm that we have received the following payments from");

                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(340, 690); // Left, Top
                                    cb.ShowText(drpersonaldtls["StudentName"].ToString());

                                    cb.EndText();
                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(340, 685);
                                    cb.LineTo(580, 685);
                                    cb.Stroke();

                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(15, 670); // Left, Top
                                    cb.ShowText("Address:");

                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(60, 670); // Left, Top
                                    cb.ShowText(drpersonaldtls["StudentAddress"].ToString());

                                    cb.EndText();
                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(59, 665);
                                    cb.LineTo(580, 665);
                                    cb.Stroke();

                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(15, 650); // Left, Top
                                    cb.ShowText("Aggregating to :");

                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(90, 650); // Left, Top
                                    cb.ShowText(dramtinwords["Amountinwords"].ToString());

                                    cb.EndText();
                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(90, 645);
                                    cb.LineTo(580, 645);
                                    cb.Stroke();

                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(15, 630); // Left, Top
                                    cb.ShowText("as tuition fees for ");

                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(100, 630); // Left, Top
                                    cb.ShowText(drpersonaldtls["streamname"].ToString());
                                    cb.EndText();
                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(100, 625);
                                    cb.LineTo(580, 625);
                                    cb.Stroke();
                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(15, 610); // Left, Top
                                    cb.ShowText("for the academic year ");

                                    cb.SetFontAndSize(f_cn, 11);
                                    cb.SetTextMatrix(120, 610); // Left, Top
                                    cb.ShowText(drpersonaldtls["yearname"].ToString());
                                    cb.EndText();
                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(120, 605);
                                    cb.LineTo(580, 605);
                                    cb.Stroke();

                                    // Draw a line by setting the line width and position
                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(10, 600);
                                    cb.LineTo(585, 600);
                                    cb.Stroke();

                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(352, 600);
                                    cb.LineTo(352, 145);
                                    cb.Stroke();

                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(360, 600);
                                    cb.LineTo(360, 145);
                                    cb.Stroke();

                                    cb.SetLineWidth(0f);
                                    cb.MoveTo(10, 145);
                                    cb.LineTo(585, 145);
                                    cb.Stroke();

                                    //cb.Rectangle(10, 10, 350, 590);
                                    //cb.Stroke();

                                    cb.BeginText();
                                    writeText(cb, "No.", 15, 585, f_cn, 9);
                                    writeText(cb, "Date", 45, 585, f_cn, 9);
                                    writeText(cb, "Amount", 100, 585, f_cn, 9);
                                    writeText(cb, "Instr. No", 150, 585, f_cn, 9);
                                    writeText(cb, "Bank/Branch", 225, 585, f_cn, 9);
                                    cb.EndText();

                                    cb.MoveTo(10, 580);
                                    cb.LineTo(352, 580);
                                    cb.Stroke();

                                    cb.BeginText();
                                    int top_margin = 570;
                                    foreach (DataRow drItem in Result.Tables[0].Rows)
                                    {
                                        writeText(cb, drItem["Receipt_Num"].ToString(), 15, top_margin, f_cn, 8);
                                        writeText(cb, drItem["Receipt_Date"].ToString(), 45, top_margin, f_cn, 8);
                                        writeText(cb, drItem["Receipt_Amt"].ToString(), 100, top_margin, f_cn, 8);
                                        writeText(cb, drItem["Instrument_no"].ToString(), 150, top_margin, f_cn, 8);
                                        writeText(cb, drItem["Bank_Name"].ToString(), 225, top_margin, f_cn, 8);
                                        cb.SetLineWidth(0f);
                                        cb.MoveTo(10, top_margin-3);
                                        cb.LineTo(352, top_margin - 3);
                                        cb.Stroke();
                                        top_margin -= 10;
                                    }

                                    int top_margin1 = 585;
                                    foreach (DataRow drItem1 in Result.Tables[5].Rows)
                                    {
                                        writeText(cb, drItem1["Field"].ToString(), 370, top_margin1, f_cn, 10);
                                        writeText(cb, drItem1["GrossFees"].ToString(), 535, top_margin1, f_cn, 10);
                                        cb.SetLineWidth(0f);
                                        cb.MoveTo(360, top_margin1 - 5);
                                        cb.LineTo(585, top_margin1 - 5);
                                        cb.Stroke();
                                        top_margin1 -= 15;
                                    }

                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(14, 130); // Left, Top
                                    cb.ShowText("Notes:");

                                    cb.BeginText();
                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(435, 130); // Left, Top
                                    cb.ShowText("Receivers Signature");

                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(12, 120); // Left, Top
                                    cb.ShowText("* Fees includes amount payable towards coaching & study materials");
                                    
                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(12, 110); // Left, Top
                                    cb.ShowText("* Fees once paid will neither be adjusted /transferred nor refunded under any circumstances.");
                                    

                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(12, 100); // Left, Top
                                    cb.ShowText("* This receipt is subject to realisation of cheques");
                                    

                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(12, 90); // Left, Top
                                    cb.ShowText("* In case of cheque being dishonored, a penalty will be levied as per fees chart for every default.");
                                    

                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(12, 80); // Left, Top
                                    cb.ShowText("* The Company reserves the right to take legal action against any dishonoured cheque.");
                                    

                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(12, 70); // Left, Top
                                    cb.ShowText("* Any change in GST/Cess/Other Tax by Govt. will accordingly be made applicable on PDC’s post the effective date or as the law states.");

                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(12, 60); // Left, Top
                                    cb.ShowText("* For any unforeseen event or circumstances, if company intend to offer refund then the refund will be processed only after 365days from the date of application.");

                                    cb.SetFontAndSize(f_cn, 8);
                                    cb.SetTextMatrix(12, 50); // Left, Top
                                    cb.ShowText("* Bounced payment only through DD/Credit/Debit card.");
                                    

                                    //cb.SetFontAndSize(f_cn, 10);
                                    //cb.SetTextMatrix(15, 35); // Left, Top
                                    //cb.ShowText("Service Tax Regn. No.: " + drCompanydtls["ServiceTaxRegNo"].ToString());
                                   

                                    cb.SetFontAndSize(f_cn, 10);
                                    cb.SetTextMatrix(15, 25); // Left, Top
                                    cb.ShowText("GST No.: " + drCompanydtls["Gst_No"].ToString());
                                    

                                    cb.SetFontAndSize(f_cn, 10);
                                    cb.SetTextMatrix(15, 15); // Left, Top
                                    cb.ShowText("State: " + drCompanydtls["Gst_State"].ToString());
                                    cb.EndText();
                                    //// Close the document
                                    document.Close();
                                    writer.Close();
                                    ms.Close();
                                    string CurTimeFrame = null;
                                    CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

                                    Response.ContentType = "pdf/application";
                                    Response.AddHeader("content-disposition", "attachment;filename=Receipt_" + Admission_id + '_' + CurTimeFrame + ".pdf");
                                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                    Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                                }
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Something went wrong! Contact Administrator  ',class_name: 'gritter-item-wrapper gritter-error'});});</script>", false);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "k2", "<script type=\"text/javascript\">$(function () { $.gritter.add({title: 'Error', text: 'Something went wrong! Contact Administrator  ',class_name: 'gritter-item-wrapper gritter-error'});});</script>", false);
            }
        }
    }

    private void writeText(PdfContentByte cb, string Text, int X, int Y, BaseFont font, int Size)
    {
        cb.SetFontAndSize(font, Size);
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Text, X, Y, 0);
    }
}