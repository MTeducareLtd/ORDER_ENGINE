<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ContactCenter_UploadContacts.aspx.cs" Inherits="ContactCenter_UploadContacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="#">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Upload Contacts<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Upload" ToolTip="Upload Excel" OnClick="BtnShowSearchPanel_Click" />
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <!--/page-header-->
        <div class="row-fluid">
            <!-- -->
            <!-- PAGE CONTENT BEGINS HERE -->
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
            <div id="DivAddPanel" runat="server" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <table width="100%">
                            <tr>
                                <td style="text-align: left" class="span10">
                                    <h5 class="modal-title">
                                        <asp:Label ID="lblHeader_Add" runat="server" Text="Upload Excel"></asp:Label>
                                    </h5>
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="lnkExportExcelFormat" ToolTip="Export Excel Format"
                                        class="btn-small btn-danger icon-2x icon-download-alt" Height="25px" OnClick="lnkExportExcelFormat_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: right; width: 40%;">
                                                                <asp:Label runat="server" ID="Label7" CssClass="red">Upload Excel</asp:Label>
                                                                <asp:Label runat="server" ID="lblfilepath" Visible="false"></asp:Label>
                                                                <asp:Label runat="server" ID="lblfileName1" Visible="false"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: right; width: 10%;">
                                                                <asp:Label runat="server" ID="Label1" CssClass="red"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 50%;">
                                                                <asp:FileUpload ID="flExcelUpload" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; width: 40%;">
                                                                <asp:Label runat="server" ID="Label2" CssClass="red">Contact Source</asp:Label>
                                                            </td>
                                                            <td style="border-style: none;  width: 60%;">
                                                                <asp:DropDownList ID="ddlContactsourceadd" runat="server" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Contact Source">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddlContactsourceadd"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Source"
                                                                    InitialValue="Select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3" CssClass="red">Country</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; width: 60%;">
                                                                <asp:DropDownList ID="ddlCountry" runat="server" Width="215px" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead2">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator133" ControlToValidate="ddlCountry"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Country"
                                                                    InitialValue="Select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnUpload"
                                    Text="Upload" ToolTip="Upload" OnClick="btnUpload_Click" ValidationGroup="Grplead2" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                    ValidationGroup="Grplead2" ShowSummary="False" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                    <asp:Label runat="server" ID="lblFileName" Text="0" Visible="false" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="btnExportErrorContacts" 
                                        ToolTip="Export Error Contacts" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" Visible="false" onclick="btnExportErrorContacts_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:DataList ID="dlviewExcelFormat" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="false">
                    <HeaderTemplate>
                        <b>Contact Source</b> </th>
                        <th align="left" style="width: 5%; text-align: left;">
                            Title
                        </th>
                        <th align="left" style="width: 15%; text-align: left;">
                            First Name
                        </th>
                        <th align="left" style="width: 10%; text-align: left;">
                            Mid Name
                        </th>
                        <th align="left" style="width: 10%; text-align: left;">
                            Last Name
                        </th>
                        <th align="left" style="width: 10%; text-align: center;">
                            Gender
                        </th>
                        <th align="left" style="width: 10%; text-align: center;">
                            EmailId
                        </th>
                        <th align="left" style="width: 10%; text-align: center;">
                            Handphone_1
                        </th>
                        <th align="left" style="width: 10%; text-align: center;">
                            Handphone_2
                        </th>
                         <th align="left" style="width: 10%; text-align: center;">
                            LandLine
                        </th>
                        <th align="left" style="width: 10%; text-align: center;">
                            Country
                        </th>
                        <th align="left" style="width: 10%; text-align: center;">
                            ErrorSaveMessage
                        </th>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRowNum" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RowNum")%>'
                            Visible="false" />
                        <asp:Label ID="lblContact_Source" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Contact_Source")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lblCon_Title" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Title")%>' />
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCon_FirstName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FirstName")%>' />
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCon_MidName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MiddleName")%>' />
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblConLastName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LastName")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblGender" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Gender")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblEmailId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"EmailId")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblHandphone1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Handphone1")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblHandphone2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Handphone2")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblLandLine" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Landline")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Country")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lbErrorSaveMessage" runat="server" Text='' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
                <div class="widget-main alert-block alert-info" style="text-align: center;" runat="server"
                    id="divSaveContacts" visible="false">
                    <!--Button Area -->
                    <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSaveContacts"
                        Text="Save" ToolTip="Save Contacts" OnClick="btnSaveContacts_Click" />
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
