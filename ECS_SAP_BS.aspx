<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ECS_SAP_BS.aspx.cs" Inherits="ECS_SAP_BS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
    <script type="text/javascript" src="assets/js/jquery.gritter.min.js"></script>
    <script language="javascript" type="text/javascript">
// <![CDATA[

       

// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid hidden-print">
        <div id="breadcrumbs" class="position-relative">
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                    class="icon-angle-right"></i></span></li>
                <li>
                    <h5 class="smaller">
                        <b>
                            <asp:Label ID="lblpagetitle1" runat="server">ECS SAP Bank Statements</asp:Label>&nbsp;</b>
                        <small>
                            <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                    </h5>
                </li>
            </ul>
            <div id="nav-search">
                <!-- /btn-group -->
                <button type="button" class="btn  btn-primary btn-small radius-4  btn-danger" id="btnsearchback"
                    runat="server" onserverclick="btnsearchback_ServerClick">
                    <i class="icon-reply"></i>Back</button>
            </div>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
    <!-- END PAGE HEADER-->
    <!-- BEGIN CONTENT -->
    <div id="page-content" class="clearfix">
        <div class="page-content">
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>
            <asp:UpdatePanel ID="upnlsearch" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div id="tab_1_31" class="row-fluid">
                                <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-header widget-hea1der-small header-color-dark">
                                                <h4 class="smaller">
                                                    <i class="icon-search"></i>Search Options</h4>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-body-inner">
                                                    <div class="widget-main">
                                                        <table class="table table-striped table-bordered table-condensed">
                                                            
                                                            <tr>
                                                                <td width="10%">
                                                                    Upload Excel
                                                                </td>
                                                                <td width="20%" colspan="5">                                                                    
                                                                    <asp:FileUpload ID="fluDocUpload" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="widget-main alert-block alert-info" style="text-align: center;">
                                                        <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" onserverclick="btnsearch_ServerClick"
                                                            validationgroup="Grplead12" runat="server" >
                                                            Search
                                                        </button>
                                                        <asp:ValidationSummary ID="ValidationSummary17" runat="server" ShowMessageBox="True"
                                                            ValidationGroup="Grplead12" ShowSummary="False" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid" id="divsearchresults" runat="server">
                                    <div class="span12">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                            <div class="widget-body">
                                                <div class="widget-header widget-hea1der-small header-color-dark">
                                                    <h4 class="smaller">
                                                        <i class="icon-briefcase"></i>ECS SAP Bank Statement</h4>
                                                    <asp:Label ID="lblFileName" Text=''
                                                                    runat="server" Visible="false"></asp:Label>
                                                </div>
                                                <div class="widget-body" >
                                                   <%-- <br>--%>
                                                    <div style="height: 500px;width: 100%;  overflow: scroll; ">
                                                    <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                                                        runat="server" Width="100%">
                                                        <HeaderTemplate>
                                                            <b>ACH Transaction Code</b></th>
                                                            <th align="left">
                                                                Control
                                                            </th>
                                                            <th align="left">
                                                                Destination Account Type
                                                            </th>
                                                            <th align="left">
                                                                Ledger Folio Number
                                                            </th>
                                                            <th align="left">
                                                                Control
                                                            </th>
                                                            <th align="left">
                                                                Beneficiary Account Holders Name
                                                            </th>
                                                            <th align="left">
                                                                Control
                                                            </th>
                                                             <th align="left">
                                                                Control
                                                            </th>
                                                            <th align="left">
                                                                User Name_Narration
                                                            </th>
                                                            <th align="left">
                                                                Control
                                                            </th>
                                                            <th align="left">
                                                                Amount
                                                            </th>
                                                            <th align="left">
                                                                Reserved ACH Item Seq No
                                                            </th>
                                                            <th align="left">
                                                                Reserved Checksum
                                                            </th>
                                                            <th align="left">
                                                                Reserved Flag for success  return
                                                            </th>
                                                            <th align="left">
                                                                Reserved Reason Code
                                                            </th>
                                                            <th align="left">
                                                                Destination Bank IFSC_MICR_IIN
                                                            </th>
                                                            <th align="left">
                                                                Beneficiarys Bank Account number
                                                            </th>
                                                            <th align="left">
                                                                Sponsor Bank IFSC_MICR_IIN
                                                            </th>
                                                            <th align="left">
                                                                User Number
                                                            </th>
                                                            <th align="left">
                                                                Transaction Reference
                                                            </th>
                                                            <th align="left">
                                                                Product Type
                                                            </th>
                                                            <th align="left">
                                                                Beneficiary Aadhaar Number
                                                            </th>
                                                            <th align="left">
                                                                UMRN
                                                            </th>
                                                            <%--<th align="left">
                                                                Filler
                                                            </th>--%>
                                                            <th align="left">
                                                                STATUS
                                                            </th>
                                                            <th align="left">
                                                                RETURN CODE
                                                            </th>
                                                            <th align="left">
                                                                REASON
                                                        </HeaderTemplate>
                                                        <ItemTemplate>                                                            
                                                                <asp:Label ID="lblACH_Transaction_Code" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "ACH_Transaction_Code")%>'
                                                                    runat="server"></asp:Label>
                                                                <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                                    
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblControl" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Control")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDestination_Account_Type" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Destination_Account_Type")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLedger_Folio_Number" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Ledger_Folio_Number")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblControl1" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Control1")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBeneficiary_Account_Holders_Name" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Beneficiary_Account_Holders_Name")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblControl2" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Control2")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblControl3" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Control3")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblUser_Name_Narration" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "User_Name_Narration")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblControl4" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Control4")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAmount" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'></asp:Label>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="lblReserved_ACH_Item_Seq_No" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Reserved_ACH_Item_Seq_No")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblReserved_Checksum" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Reserved_Checksum")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblReserved_Flag_for_success_return" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Reserved_Flag_for_success_return")%>'></asp:Label>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="lblReserved_Reason_Code" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Reserved_Reason_Code")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDestination_Bank_IFSC_MICR_IIN" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Destination_Bank_IFSC_MICR_IIN")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBeneficiarys_Bank_Account_number" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Beneficiarys_Bank_Account_number")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSponsor_Bank_IFSC_MICR_IIN" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Sponsor_Bank_IFSC_MICR_IIN")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblUser_Number" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "User_Number")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTransaction_Reference" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Transaction_Reference")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProduct_Type" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Product_Type")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBeneficiary_Aadhaar_Number" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Beneficiary_Aadhaar_Number")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblUMRN" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "UMRN")%>'></asp:Label>
                                                            </td>
                                                            <%--<td>
                                                                <asp:Label ID="lblFiller" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Filler")%>'></asp:Label>
                                                            </td>--%>
                                                            <td>
                                                                <asp:Label ID="lblSTATUS" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "STATUS")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblRETURN_CODE" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "RETURN_CODE")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblREASON" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "REASON")%>'></asp:Label>
                                                            </td>                                                            
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    </div>
                                                    <div class="widget-main alert-block alert-info" style="text-align: center;">
                                                    <!--Button Area -->
                                                    <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSave"
                                                        Text="Save" ToolTip="Save" onclick="btnSave_Click"  />
                                                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" runat="server" ID="btnBack"
                                                        Text="Back" ToolTip="Back" onclick="btnBack_Click" />
                                                </div>
                                                </div>
                                                
                                            </div>
                                            <!-- END EXAMPLE TABLE PORTLET-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                    <asp:PostBackTrigger ControlID="btnSave" />  
                    <asp:PostBackTrigger ControlID="btnBack" />  
                                      
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
