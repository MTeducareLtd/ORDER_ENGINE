<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Campaign_RawData.aspx.cs" Inherits="Campaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Uploading Raw Data<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn btn-app btn-success btn-mini radius-4  " runat="server" ID="BtnAdd"
                Text="Add" ToolTip="Add PreLead" OnClick="BtnAdd_Click" />
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
            <div id="DivSearch" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label2" runat="server" Text="Search Criteria"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed"
                                            runat="server" id="tblExcelName">
                                            <tr>
                                                <td class="span12" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: right; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3">Select Excel</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: right; width: 10%;">
                                                                <asp:Label runat="server" ID="Label4" CssClass="red"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 50%;">
                                                                <asp:DataList ID="dlGridExcelName" CssClass="table table-striped table-bordered table-hover"
                                                                    runat="server" Width="100%">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="ChkAll" runat="server" OnCheckedChanged="chkAll_CheckedChanged"
                                                                            AutoPostBack="true" Visible="True" />
                                                                        <span class="lbl"></span></th>
                                                                        <th style="width: 80%; text-align: left;">
                                                                            Excel Name
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkCheck" runat="server" AutoPostBack="true" Checked="false" />
                                                                        <span class="lbl"></span>
                                                                        <asp:Label ID="lblImport_Run_No" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Import_Run_No")%>'
                                                                            Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblTeacherName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ExcelName")%>'
                                                                                Visible="true" />
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="row-fluid" id="divExcelRecord" runat="server">
                                            <div class="span12">
                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            <i class="fa fa-globe"></i>Pre Lead Record
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                            <div class="widget-body" style="height: 700px; overflow: Auto">
                                                                <div class="widget-main">
                                                                    <div class="tabbable tabbable-custom tabbable-full-width">
                                                                        <ul class="nav nav-tabs">
                                                                            <li class="active"><a data-toggle="tab" href="#tab_2_2">Unique Record (<asp:Label
                                                                                ID="lblUniqueCount" runat="server"></asp:Label>)</a> </li>
                                                                            <li><a data-toggle="tab" href="#tab_1_3">Duplicate Record (<asp:Label ID="lblDupliCount"
                                                                                runat="server"></asp:Label>)</a> </li>
                                                                            <li class="pull-right"><a id="acloseExcelrecord" runat="server" onserverclick="acloseExcelrecord_ServerClick">
                                                                                <i class="fa fa-chain-broken"></i>Close</a> </li>
                                                                        </ul>
                                                                        <div class="tab-content">
                                                                            <div id="tab_2_2" class="tab-pane active">
                                                                                <div class="table-responsive">
                                                                                    <asp:DataList ID="dlselective1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                                        Height="20px">
                                                                                        <HeaderTemplate>
                                                                                            <b>
                                                                                                <center>
                                                                                Student Name</center>
                                                                                            </b></th>
                                                                                            <th style="text-align: center" width="30%">
                                                                                                Mobile Number
                                                                                            </th>
                                                                                            <th style="text-align: center" width="30%">
                                                                                                Email ID
                                                                                            </th>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblData_Id" Text='<%#DataBinder.Eval(Container.DataItem, "Data_Id")%>'
                                                                                                runat="server" Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblImportRunNumber" Text='<%#DataBinder.Eval(Container.DataItem, "Import_Run_No")%>'
                                                                                                runat="server" Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem, "StudName")%>'
                                                                                                runat="server"></asp:Label></td>
                                                                                            <td style="text-align: right">
                                                                                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone_1")%>'></asp:Label>
                                                                                            </td>
                                                                                            <td width="10%">
                                                                                                <asp:Label ID="lblEmailId" Text='<%#DataBinder.Eval(Container.DataItem, "Email_Id")%>'
                                                                                                    runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </ItemTemplate>
                                                                                    </asp:DataList>
                                                                                </div>
                                                                            </div>
                                                                            <div id="tab_1_3" class="tab-pane">
                                                                                <div class="table-responsive">
                                                                                    <asp:DataList ID="dlselective2" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                                        Height="20px">
                                                                                        <HeaderTemplate>
                                                                                            <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="chkAll2_CheckedChanged"
                                                                                                AutoPostBack="true" Visible="True" />
                                                                                            <span class="lbl"></span></th>
                                                                                            <th style="text-align: center" width="20%">
                                                                                                File Name
                                                                                            </th>
                                                                                            <th style="text-align: center" width="30%">
                                                                                                Student Name
                                                                                            </th>
                                                                                            <th style="text-align: center" width="20%">
                                                                                                Mobile Number
                                                                                            </th>
                                                                                            <th style="text-align: center" width="20%">
                                                                                                Email ID
                                                                                            </th>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkCheck" runat="server" Checked="false" />
                                                                                            <span class="lbl"></span></td>
                                                                                            <td>
                                                                                                <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "File_Name")%>'
                                                                                                    runat="server" Visible="true"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblData_Id" Text='<%#DataBinder.Eval(Container.DataItem, "Data_Id")%>'
                                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                                <asp:Label ID="lblImportRunNumber" Text='<%#DataBinder.Eval(Container.DataItem, "Import_Run_No")%>'
                                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                                <asp:Label ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem, "StudName")%>'
                                                                                                    runat="server"></asp:Label>
                                                                                            </td>
                                                                                            <td style="text-align: right">
                                                                                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone_1")%>'></asp:Label>
                                                                                            </td>
                                                                                            <td width="10%">
                                                                                                <asp:Label ID="lblEmailId" Text='<%#DataBinder.Eval(Container.DataItem, "Email_Id")%>'
                                                                                                    runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </ItemTemplate>
                                                                                    </asp:DataList>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="acloseExcelrecord" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnViewRecord"
                                    Text="View" ToolTip="View Record" OnClick="btnViewRecord_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
                                                <td class="span12" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: right; width: 40%;">
                                                                <asp:Label runat="server" ID="Label7" CssClass="red">Upload Excel</asp:Label>
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
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnUpload"
                                    Text="Upload" ToolTip="Upload" OnClick="btnUpload_Click" />
                                <asp:DataList ID="dlExportExcelFormat" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%" Visible="false">
                                    <HeaderTemplate>
                                        <b>Data_Source_Name</b> </th>
                                        <th align="left" style="width: 5%; text-align: left;">
                                            Reference_Id
                                        </th>
                                        <th align="left" style="width: 5%; text-align: left;">
                                            Student_First_Name
                                        </th>
                                        <th align="left" style="width: 5%; text-align: left;">
                                            Student_Last_Name
                                        </th>
                                        <th align="left" style="width: 5%; text-align: left;">
                                            Parent_First_Name
                                        </th>
                                        <th align="left" style="width: 3%; text-align: center;">
                                            Parent_Last_Name
                                        </th>
                                        <th align="left" style="width: 2%; text-align: center;">
                                            Email_Id
                                        </th>
                                        <th align="left" style="width: 5%; text-align: center;">
                                            Handphone_1
                                        </th>
                                        <th align="left" style="width: 5%; text-align: center;">
                                            Handphone_2
                                        </th>
                                        <th align="left" style="width: 5%; text-align: center;">
                                            Contact_No
                                        </th>
                                        <th align="left" style="width: 5%; text-align: center;">
                                            Address1
                                        </th>
                                        <th align="left" style="width: 5%; text-align: center;">
                                            Address2
                                        </th>
                                        <th align="left" style="width: 5%; text-align: center;">
                                            Address3
                                        </th>
                                        <th align="left" style="width: 4%; text-align: center;">
                                            Country
                                        </th>
                                        <th align="left" style="width: 4%; text-align: center;">
                                            State
                                        </th>
                                        <th align="left" style="width: 4%; text-align: center;">
                                            City
                                        </th>
                                        <th align="left" style="width: 5%; text-align: center;">
                                            Location
                                        </th>
                                        <th align="left" style="width: 4%; text-align: center;">
                                            Pincode
                                        </th>
                                        <th align="left" style="width: 5%; text-align: center;">
                                            ProductInterest
                                        </th>
                                        <th align="left" style="width: 4%; text-align: center;">
                                            Present_Status
                                        </th>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblData_Source_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Data_Source_Name")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblReference_Id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Reference_Id")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblStudent_First_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_First_Name")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblStudent_Last_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_Last_Name")%>' />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblParent_First_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Parent_First_Name")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblParent_Last_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Parent_Last_Name")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblEmailId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Email_Id")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblHandphone_1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Handphone_1")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblHandphone_2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Handphone_2")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblContact_No" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Contact_No")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblAddress1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address1")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblAddress2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address2")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblAddress3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address3")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Country")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblState" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"State")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblCity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"City")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblPincode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pincode")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblProductInterest" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ProductInterest")%>' />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblPresent_Status" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Present_Status")%>' />
                                        </td>
                                    </ItemTemplate>
                                </asp:DataList>
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
                                    <asp:LinkButton runat="server" ID="btnExport" ToolTip="Export Error Excel" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" Visible="false" OnClick="btnExport_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="DivGridDisplay" runat="server" class="widget-main no-padding" style="height: 400px;
                    width: 100%; overflow-y: none; overflow-x: scroll;">
                    <asp:DataList ID="dlDisplay" CssClass="table table-striped table-bordered table-hover"
                        runat="server" Width="100%">
                        <HeaderTemplate>
                            <b>Remark</b> </th>
                            <th align="left" style="width: 6%; text-align: left;">
                                Data Source Name
                            </th>
                            <th align="left" style="width: 5%; text-align: left;">
                                Reference Id
                            </th>
                            <th align="left" style="width: 6%; text-align: left;">
                                Student First Name
                            </th>
                            <th align="left" style="width: 6%; text-align: left;">
                                Student Last Name
                            </th>
                            <th align="left" style="width: 5%; text-align: left;">
                                Parent First Name
                            </th>
                            <th align="left" style="width: 3%; text-align: center;">
                                Parent Last Name
                            </th>
                            <th align="left" style="width: 2%; text-align: center;">
                                Email ID
                            </th>
                            <th align="left" style="width: 6%; text-align: center;">
                                Handphone1
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Handphone2
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                ContactNo
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Address1
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Address2
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Address3
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Country
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                State
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                City
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Location
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Pincode
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Product Interest
                            </th>
                            <th align="left" style="width: 4%; text-align: center;">
                                Present_Status
                            </th>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                    <i class="icon-bolt"></i>
                                </asp:Panel>
                            </a>
                            <asp:Label ID="lblSuccess" runat="server" Text='Success' CssClass='green' Visible="false" />
                            </td>
                            <td>
                                <asp:Label ID="lblData_Source_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Data_Source_Name")%>' />
                            </td>
                            <td>
                                <asp:Label ID="lblReference_Id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Reference_Id")%>' />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblStudent_First_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_First_Name")%>' />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblStudent_Last_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_Last_Name")%>' />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblParent_First_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Parent_First_Name")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblParent_Last_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Parent_Last_Name")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblEmailID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Email_Id")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblHandphone_1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Handphone_1")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblHandphone_2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Handphone_2")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblContact_No" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Contact_No")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblAddress1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address1")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblAddress2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address2")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblAddress3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address3")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Country")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblState" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"State")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblCity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"City")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblPincode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pincode")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblProductInterest" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ProductInterest")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblPresent_Status" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Present_Status")%>' />
                            </td>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:DataList ID="dlExport" CssClass="table table-striped table-bordered table-hover"
                        runat="server" Width="100%" Visible="false">
                        <HeaderTemplate>
                            <b>Data_Source_Name</b> </th>
                            <th align="left" style="width: 5%; text-align: left;">
                                Reference_Id
                            </th>
                            <th align="left" style="width: 5%; text-align: left;">
                                Student_First_Name
                            </th>
                            <th align="left" style="width: 5%; text-align: left;">
                                Student_Last_Name
                            </th>
                            <th align="left" style="width: 5%; text-align: left;">
                                Parent_First_Name
                            </th>
                            <th align="left" style="width: 3%; text-align: center;">
                                Parent_Last_Name
                            </th>
                            <th align="left" style="width: 2%; text-align: center;">
                                Email_Id
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Handphone_1
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Handphone_2
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Contact_No
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Address1
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Address2
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Address3
                            </th>
                            <th align="left" style="width: 4%; text-align: center;">
                                Country
                            </th>
                            <th align="left" style="width: 4%; text-align: center;">
                                State
                            </th>
                            <th align="left" style="width: 4%; text-align: center;">
                                City
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                Location
                            </th>
                            <th align="left" style="width: 4%; text-align: center;">
                                Pincode
                            </th>
                            <th align="left" style="width: 5%; text-align: center;">
                                ProductInterest
                            </th>
                            <th align="left" style="width: 4%; text-align: center;">
                                Present_Status
                            </th>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblData_Source_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Data_Source_Name")%>' />
                            </td>
                            <td>
                                <asp:Label ID="lblReference_Id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Reference_Id")%>' />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblStudent_First_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_First_Name")%>' />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblStudent_Last_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_Last_Name")%>' />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblParent_First_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Parent_First_Name")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblParent_Last_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Parent_Last_Name")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblEmailID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Email_Id")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblHandphone_1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Handphone_1")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblHandphone_2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Handphone_2")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblContact_No" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Contact_No")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblAddress1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address1")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblAddress2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address2")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblAddress3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Address3")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblCountry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Country")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblState" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"State")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblCity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"City")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblPincode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pincode")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblProductInterest" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ProductInterest")%>' />
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblPresent_Status" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Present_Status")%>' />
                            </td>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="widget-main alert-block alert-info" style="text-align: center;">
                    <!--Button Area -->
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="pnlSave">
                        <ProgressTemplate>
                            <img alt="" src="Images/Processing.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="pnlSave" runat="server">
                        <ContentTemplate>
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSave" runat="server"
                                Text="Save" ValidationGroup="UcValidate" OnClick="BtnSave_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="BtnSave" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
