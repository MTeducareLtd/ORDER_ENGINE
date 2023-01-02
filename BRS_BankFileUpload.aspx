<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="BRS_BankFileUpload.aspx.cs" Inherits="FilesImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    BRS Bank File Upload <span class="divider"></span>
                </h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <div class="page-content">
            <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="alert alert-block alert-success" id="Msg_Success" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-ok"></i></strong>
                            <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                    <div class="alert alert-error" id="Msg_Error" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-remove"></i>Error!</strong>
                            <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="DivNew_Upload" visible="true" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            BRS Bank File Upload
                            <asp:Label ID="lblimport" runat="server" Visible="false"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <div id="search" runat="server">
                                    <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="Table4">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 15%;">
                                                            <asp:Label ID="Label10" runat="server" ForeColor="Red">Select File</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 85%;">
                                                            <asp:FileUpload ID="uploadfile" runat="server" />
                                                            <asp:Label ID="lblfilepath" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnUpload"
                                                    Text="Upload" ToolTip="Upload" ValidationGroup="UcValidateSearch" OnClick="btnUpload_Click" />
                                            </td>
                                            <td class="span4" style="text-align: left">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="New_UploadGrid" runat="server" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="prefix" id="New_UploadGrid1" runat="server" visible="false" style="overflow-x: scroll !important;
                    height: 400PX;">
                    <asp:DataList ID="datalist_NewUploads1" CssClass="table table-striped table-bordered table-hover"
                        runat="server" Width="100%" Visible="True" Style="overflow:scroll">
                        <HeaderTemplate>
                            <b>TYPE</b> </th>
                            <th style="text-align: center; width: 03px;">
                                CLCODE
                            </th>
                            <th style="text-align: center;width: 03px;" >
                                BANK_ACCOUNT
                            </th>
                            <th style="text-align: center; width: 03px;">
                                PRDCODE
                            </th>
                            <th style="text-align: center; width: 03px;">
                                LOCATION
                            </th>
                            <th style="text-align: center; width: 03px;">
                                LOCATION_NAME
                            </th>
                            <th style="text-align: center; width: 03px;">
                                DEPDATE
                            </th>
                            <th style="text-align: center; width: 03px;">
                                CLGTYPE
                            </th>
                            <th id="Th1" runat="server" style="text-align: center; width: 03px;">
                                CRDATE
                            </th>
                            <th id="Th2" runat="server" style="text-align: center; width: 03px;">
                                RTNDATE
                            </th>
                            <th id="Th3" runat="server" style="text-align: center; width: 03px;">
                                SLIPNO
                            </th>
                            <th id="Th4" runat="server" style="text-align: center; width: 01px;">
                                TOTAL_INSTRUMENTS
                            </th>
                            <th id="Th5" runat="server" style="text-align: center; width: 03px;">
                                SLIPAMOUNT
                            </th>
                            <th id="Th6" runat="server" style="text-align: center; width: 03px;">
                                INSTRUMENTNO
                            </th>
                            <th id="Th7" runat="server" style="text-align: center; width: 03px;">
                                INSTRUMENTTYPE
                            </th>
                            <th id="Th8" runat="server" style="text-align: center; width: 03px;">
                                INSTRUMENTDATE
                            </th>
                            <th id="Th9" runat="server" style="text-align: center; width: 03px;">
                                INSTRUMENTAMNT
                            </th>
                            <th id="Th10" runat="server" style="text-align: center; width: 03px;">
                                RECOVEREDAMNT
                            </th>
                            <th id="Th11" runat="server" style="text-align: center; width: 03px;">
                                DRAWNON
                            </th>
                            <th id="Th12" runat="server" style="text-align: center; width: 03px;">
                                DRAWNONLOC
                            </th>
                            <th id="Th13" runat="server" style="text-align: center; width: 03px;">
                                DRWANBANK DRAWNBRANCH
                            </th>
                            <th id="Th23" runat="server" style="text-align: center; width: 03px;">
                                DRAWNBRANCH
                            </th>
                            <th id="Th14" runat="server" style="text-align: center; width: 03px;">
                                DRAWERNAME
                            </th>
                            <th id="Th15" runat="server" style="text-align: center; width: 03px;">
                                RTN
                            </th>
                            <th id="Th16" runat="server" style="text-align: center; width: 03px;">
                                RTN REASON
                            </th>
                            <th id="Th22" runat="server" style="text-align: center; width: 03px;">
                                INST_ADD_INFO
                            </th>
                            <th id="Th17" runat="server" style="text-align: center; width: 03px;">
                                INST_ADD_INFO2
                            </th>
                            <th id="Th18" runat="server" style="text-align: center; width: 03px;">
                                INST_ADD_INFO3
                            </th>
                            <th id="Th19" runat="server" style="text-align: center; width: 03px;">
                                INST_ADD_INFO4
                            </th>
                            <th id="Th20" runat="server" style="text-align: center; width: 14px;">
                                REMARKS
                            </th>
                            <th id="Th21" runat="server" style="text-align: center; width: 20px;">
                                STATUS
                            </th>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTYPE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TYPE")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblCLCODE" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"CLCODE")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblBANK_ACCOUNT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BANK_ACCOUNT")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblPRDCODE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PRDCODE")%>' />
                            </td>
                            <td style="text-align: left; width: 03px;">
                                <asp:Label ID="lblLOCATION" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LOCATION")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblLOCATION_NAME" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"LOCATION_NAME")%>' />
                            </td>
                            <td id="Td1" style="text-align: Center; width: 03px;" runat="server">
                                <asp:Label ID="lblDEPDATE" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"DEPDATE")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="LBLCLGTYPE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CLGTYPE")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="LBLCRDATE" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"CRDATE")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblRTNDATE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RTNDATE")%>' />
                            </td>
                            <td id="Td2" style="text-align: Center; width: 03px;" runat="server">
                                <asp:Label ID="lblSLIPNO" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SLIPNO")%>' />
                            </td>
                            <td id="Td3" style="text-align: Center; width: 01px;" runat="server">
                                <asp:Label ID="lblTOTAL_INSTRUMENTS" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TOTAL_INSTRUMENTS")%>' />
                            </td>
                            <td id="Td4" style="text-align: Center; width: 03px;" runat="server">
                                <asp:Label ID="lblSLIPAMOUNT" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"SLIPAMOUNT")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblINSTRUMENTNO" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INSTRUMENTNO")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblINSTRUMENTTYPE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INSTRUMENTTYPE")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblINSTRUMENTDATE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INSTRUMENTDATE")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblINSTRUMENTAMNT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INSTRUMENTAMNT")%>' />
                            </td>
                            <td style="text-align: Center;">
                                <asp:Label ID="lblRECOVEREDAMNT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RECOVEREDAMNT")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblDRAWNON" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DRAWNON")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblDRAWNONLOC" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"DRAWNONLOC")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblDRWANBANK" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"DRWANBANK")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblDRAWNBRANCH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DRAWNBRANCH")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblDRAWERNAME" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"DRAWERNAME")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblRTN" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RTN")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblRTN_REASON" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RTN REASON")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblINST_ADD_INFO" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INST_ADD_INFO")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblINST_ADD_INFO2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INST_ADD_INFO2")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblINST_ADD_INFO3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INST_ADD_INFO3")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblINST_ADD_INFO4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INST_ADD_INFO4")%>' />
                            </td>
                            <td style="text-align: Center; width: 03px;">
                                <asp:Label ID="lblREMARKS" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"REMARKS")%>' />
                            </td>
                            <td style="text-align: Center; width: 20px;">
                                <asp:Label ID="lblSTATUS" runat="server" Text="" />
                            </td>
                            
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div runat="server" class="widget-main alert-block alert-info" id="Divbtnimport"
                    style="text-align: center;">
                    <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnImport"
                        Text="Save" ToolTip="Import" ValidationGroup="UcValidateSearch" OnClick="btnImport_Click" />
                    <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnClose"
                        Text="Close" ToolTip="Close" ValidationGroup="UcValidateSearch" OnClick="btnClose_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                        ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                </div>
            </div>

            <div id="Divdatamismatch" runat="server" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Error records
                                    <asp:Label runat="server" ID="Label1" Text="" />
                                </td>

                            </tr>
                        </table>
                    </div>
                </div>
                <div id="Divchequemismatch" runat="server" visible="false" style="overflow-x: scroll !important; height: 400PX;">
                    <asp:DataList ID="datalistcheque" CssClass="table table-striped table-bordered table-hover"
                        runat="server" Width="100%" Visible="True" Style="overflow:scroll">
                        <HeaderTemplate>
                            <b>TYPE</b> </th>
                            <th id="Th6" runat="server" style="text-align: center; width: 20px;">
                                INSTRUMENTNO
                            </th>
                            <th id="Th7" runat="server" style="text-align: center; width: 20px;">
                                INSTRUMENTTYPE
                            </th>
                            <th id="Th8" runat="server" style="text-align: center; width: 20px;">
                                INSTRUMENTDATE
                            </th>
                            <th id="Th9" runat="server" style="text-align: center; width: 20px;">
                                INSTRUMENTAMNT
                            </th>
                            <th id="Th22" runat="server" style="text-align: center; width: 20px;">
                                INST_ADD_INFO
                            </th>
                              <th id="Th21" runat="server" style="text-align: center; width: 20px;">
                                STATUS
                            </th>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTYPE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TYPE")%>' />
                            </td>
                             <td style="text-align: Center; width: 20px;">
                                <asp:Label ID="lblINSTRUMENTNO" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INSTRUMENTNO")%>' />
                            </td>
                            <td style="text-align: Center; width: 20px;">
                                <asp:Label ID="lblINSTRUMENTTYPE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INSTRUMENTTYPE")%>' />
                            </td>
                            <td style="text-align: Center; width: 20px;">
                                <asp:Label ID="lblINSTRUMENTDATE" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INSTRUMENTDATE")%>' />
                            </td>
                            <td style="text-align: Center; width: 20px;">
                                <asp:Label ID="lblINSTRUMENTAMNT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INSTRUMENTAMNT")%>' />
                            </td>
                          
                            <td style="text-align: Center; width: 20px;">
                                <asp:Label ID="lblINST_ADD_INFO" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"INST_ADD_INFO")%>' />
                            </td>
                     
                            <td style="text-align: Center; width: 20px;">
                                <asp:Label ID="lblSTATUS" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"status")%> '/>
                            </td>
                            
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                    <div runat="server" class="widget-main alert-block alert-info" id="Div3" 
                    style="text-align: center;">
                    <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnexport"
                        Text="Export" ToolTip="Export"  OnClick="btnexport_Click" />
                    <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnexportclose"
                        Text="Close" ToolTip="Close"  OnClick="btnClose_Click1" />
                  </div>
                </div>
           </div>
    </div>
</asp:Content>
