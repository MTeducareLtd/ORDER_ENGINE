<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ECS_Confirmation.aspx.cs" Inherits="ECS_Confirmation" %>

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
        <div id="breadcrumbs" class="position-relative" >
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                    class="icon-angle-right"></i></span></li>
                <li>
                    <h5 class="smaller">
                        <b>
                            <asp:Label ID="lblpagetitle1" runat="server">ECS confirmation</asp:Label>&nbsp;</b>
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
                                                            validationgroup="Grplead12" runat="server">
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
                                                        <i class="icon-briefcase"></i>ECS Confirmation List</h4>
                                                    <asp:Label ID="lblFileName" Text=''
                                                                    runat="server" Visible="false"></asp:Label>
                                                </div>
                                                <div class="widget-body" >
                                                   <%-- <br>--%>
                                                    <div style="height: 500px;width: 100%;  overflow: scroll; ">
                                                    <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                                                        runat="server" Width="100%">
                                                        <HeaderTemplate>
                                                            <b>Lot No</b></th>
                                                            <th align="left">
                                                                Message ID
                                                            </th>
                                                            <th align="left">
                                                                Message Creation DateTime
                                                            </th>
                                                            <th align="left">
                                                                Initiating PartyID
                                                            </th>
                                                            <th align="left">
                                                                Instructing Agent MemberID
                                                            </th>
                                                            <th align="left">
                                                                Instructed Agent MemberID
                                                            </th>
                                                            <th align="left">
                                                                Instructed Agent Name
                                                            </th>
                                                             <th align="left">
                                                                Mandate Request ID
                                                            </th>
                                                            <th align="left">
                                                                Mandate Category
                                                            </th>
                                                            <th align="left">
                                                                Mandate Category Name
                                                            </th>
                                                            <th align="left">
                                                                TXN Type
                                                            </th>
                                                            <th align="left">
                                                                Recurring Or OneOff
                                                            </th>
                                                            <th align="left">
                                                                Frequency
                                                            </th>
                                                            <th align="left">
                                                                First Collection Date
                                                            </th>
                                                            <th align="left">
                                                                Final Collection Date
                                                            </th>
                                                            <th align="left">
                                                                Collection Amount
                                                            </th>
                                                            <th align="left">
                                                                Maximum Amount
                                                            </th>
                                                            <th align="left">
                                                                Name of Utility/ Biller/ Bank/ Company
                                                            </th>
                                                            <th align="left">
                                                                Utility Code
                                                            </th>
                                                            <th align="left">
                                                                Sponsor Bank Code
                                                            </th>
                                                            <th align="left">
                                                                Debtor Name/Name of Account Holder
                                                            </th>
                                                            <th align="left">
                                                                Consumer Reference No
                                                            </th>
                                                            <th align="left">
                                                                Scheme/Plan Reference No
                                                            </th>
                                                            <th align="left">
                                                                Debtor Telephone No
                                                            </th>
                                                            <th align="left">
                                                                Debtor Mobile No
                                                            </th>
                                                            <th align="left">
                                                                Debtor Email Address
                                                            </th>
                                                            <th align="left">
                                                                Debtor Other Details
                                                            </th>
                                                            <th align="left">
                                                                Destination Bank Account Number/ Legal Account Number
                                                            </th>
                                                            <th align="left">
                                                                Destination Bank Account Type
                                                            </th>
                                                            <th align="left">
                                                                Destination Bank IFSC/MICR code
                                                            </th>
                                                            <th align="left">
                                                                Destination Bank Name
                                                            </th>
                                                            <th align="left">
                                                                UMRN
                                                            </th>
                                                            <th align="left">
                                                                RES Accepted/Rejected
                                                            </th>
                                                            <th align="left">
                                                                RES Reason Code
                                                            </th>
                                                            <th align="left">
                                                                REJECT REASON(BPO REJECTION,ACK REJECTION RES REJECTION)
                                                            </th>
                                                            <th align="left">                                                                
                                                                Closure Date
                                                            </th>
                                                            <th align="left">
                                                                ErrorSaveMessage
                                                        </HeaderTemplate>
                                                        <ItemTemplate>                                                            
                                                                <asp:Label ID="lblLotNo" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "LotNo")%>'
                                                                    runat="server"></asp:Label>
                                                                <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                                    
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="lblMessageID" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "MessageID")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMessageCreationDateTime" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "MessageCreationDateTime")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInitiatingPartyID" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "InitiatingPartyID")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInstructingAgentMemberID" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "InstructingAgentMemberID")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInstructedAgentMemberID" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "InstructedAgentMemberID")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInstructedAgentName" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "InstructedAgentName")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="lblMandateRequestID" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "MandateRequestID")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMandateCategory" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "MandateCategory")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMandateCategoryName" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "MandateCategoryName")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTXNtype" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "TXNtype")%>'></asp:Label>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="lblRecurring_or_OneOff" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Recurring_or_OneOff")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblFrequency" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Frequency")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblFirstCollectionDate" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "FirstCollectionDate")%>'></asp:Label>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="lblFinalCollectionDate" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "FinalCollectionDate")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCollectionAmount" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "CollectionAmount")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMaximumAmount" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "MaximumAmount")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblName_of_Utility" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Name_of_Utility")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblUtility_Code" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Utility_Code")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSponsor_Bank_Code" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Sponsor_Bank_Code")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDebtor_Name" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Debtor_Name")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblConsumer_Reference_No" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Consumer_Reference_No")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblScheme" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Scheme")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDebtor_Telephone_No" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Debtor_Telephone_No")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDebtor_Mobile_No" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Debtor_Mobile_No")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDebtor_Email" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Debtor_Email")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDebtor_other_details" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Debtor_other_details")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDestination_Bank_Account_Number" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Destination_Bank_Account_Number")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDestination_Bank_Account_Type" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Destination_Bank_Account_Type")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDestination_Bank_IFSC" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Destination_Bank_IFSC")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDestination_Bank_Name" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "Destination_Bank_Name")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblUMRN_NO" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "UMRN_NO")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSTATUS" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "STATUS")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblRTN_CODE" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "RTN_CODE")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblREASON" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "REASON")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblClosureDate" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "ClosureDate")%>'></asp:Label>
                                                            </td>
                                                            <td style="text-align: center">
                                                                <asp:Label ID="lbErrorSaveMessage" runat="server" Text='' />
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
