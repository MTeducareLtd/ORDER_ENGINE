<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Cheque_Followup.aspx.cs" Inherits="Cheque_fallout" %>

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
                    Cheque Followup<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />
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
            <div id="DivSearchPanel" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Search Options
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label15" CssClass="red">Division</asp:Label>
                                                                <%--<asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlDivision" Width="220px" ToolTip="Division"
                                                                    data-placeholder="Select Division" CssClass="chzn-select" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" />
                                                              <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddldivision"
                                                                    Text="#" runat="server" ValidationGroup="UcValidateSearch" SetFocusOnError="True"
                                                                    ErrorMessage="Select Divison" InitialValue="Select" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label16" CssClass="red">Academic Year</asp:Label>
                                                                <%--<asp:Label ID="label12" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlAcadYear" Width="220px" ToolTip="Academic Year"
                                                                    data-placeholder="Select Acad Year" CssClass="chzn-select" AutoPostBack="True" />
                                                              <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlAcadYear"
                                                                    Text="#" runat="server" ValidationGroup="UcValidateSearch" SetFocusOnError="True"
                                                                    ErrorMessage="Select AcadYear" InitialValue="Select" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label18">Centre</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlCentre" Width="220px" ToolTip="Test Mode" data-placeholder="Select Centre"
                                                                    SelectionMode="Multiple" CssClass="chzn-select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label17">Sbentry Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <%--<asp:ListBox runat="server" ID="ddlStandard" Width="142px" ToolTip="Standard" data-placeholder="Select Standard"
                                                                    SelectionMode="Multiple" CssClass="chzn-select" AutoPostBack="False" />--%>
                                                                <asp:TextBox ID="txtsbentrycode" Width="205px" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label1">Cheque No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <%--<asp:ListBox runat="server" ID="ListBox1" Width="142px" ToolTip="Standard" data-placeholder="Select Standard"
                                                                    SelectionMode="Multiple" CssClass="chzn-select" AutoPostBack="False" />--%>
                                                                <asp:TextBox ID="txtchequeno" Width="205px" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label2">Cheque Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlStatus" Width="220px" runat="server" data-placeholder="Select"
                                                                    CssClass="chzn-select">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>All</asp:ListItem>
                                                                    <asp:ListItem>Cleared</asp:ListItem>
                                                                    <asp:ListItem>Bounced</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label20">Recovery Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlrecoverystatus" Width="220px" runat="server" data-placeholder="Select"
                                                                    CssClass="chzn-select">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>New Bounce Case</asp:ListItem>
                                                                    <asp:ListItem>Pending To Recover</asp:ListItem>
                                                                    <asp:ListItem>Recovered</asp:ListItem>
                                                                    <asp:ListItem>Partially Recoverd</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label21">Followup Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" class="span10 date-picker" width="425px;" id="txtexpecjoindatefrm"
                                                                    runat="server" type="text" data-date-format="yyyy-mm-dd" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                    ValidationGroup="UcValidateSearch" ShowSummary="False" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="Divupdate_Fallout" runat="server" class="dataTables_wrapper" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <table width="100%">
                            <tr>
                                <td style="text-align: left" class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <%--  <td style="text-align: right" class="span2">
                                    <asp:LinkButton ID="HLExport" runat="server" class="btn-small btn-danger icon-2x icon-download-alt"
                                        OnClick="HLExport_Click" Height="26px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>--%>
                            </tr>
                        </table>
                    </div>
                   <div class="widget-body">
                        <div class="widget-main">
                            <asp:Repeater ID="dlGridDisplay" runat="server" OnItemCommand="dlGridDisplay_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered table-hover Table2">
                                        <thead>
                                            <tr>
                                                <th style="text-align: center;">
                                                    <b>Sbentry Code</b>
                                                </th>
                                                <th align="left" style="width: 20%">
                                                    Student Name
                                                </th>
                                                <th align="left" style="width: 10%">
                                                    Acad Year
                                                </th>
                                                <th align="left" style="width: 15%">
                                                    Center Name
                                                </th>
                                                 <th align="left" style="width: 20%">
                                                    Stream Name
                                                </th>
                                                <th align="left" style="width: 10%">
                                                    Cheque No
                                                </th>
                                                <th align="left" style="width: 10%">
                                                    Cheque Amount
                                                </th>
                                                <th align="left" style="width: 10%">
                                                    Cheque Date
                                                </th>
                                                <th align="left" style="width: 10%">
                                                    Cheque Status
                                                </th>

                                                 <th align="left" style="width: 10%">
                                                    Reason
                                                </th>
                                                
                                                 <th align="left" style="width: 10%">
                                                    Fees Outstanding
                                                </th>
                                                <th align="left" style="width: 10%">
                                                    Recovery Status
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Action
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href='<%#DataBinder.Eval(Container.DataItem,"SBEntryCode","Accounts.aspx?&SBEntryCode={0}") %>' target="_blank"><asp:Label ID="lblSBEntrycode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' /></a>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStudent_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_Name")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Lblacadyear" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Acad_Year")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CENTER")%>' />
                                            <asp:Label ID="lblcentercode" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CenterCode")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStream_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Stream_Name")%>' />
                                            <asp:Label ID="lblsream_code" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Stream_Code")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblchequeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pay_InsNum")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblcheque_status" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Amount")%>' />
                                            <asp:Label ID="lblcheque_id" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"ChequeIDNo")%>' />
                                        </td>
                                           <td>
                                            <asp:Label ID="Label37" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pay_InstrDate")%>' />
                                            
                                        </td>
                                           <td>
                                            <asp:Label ID="Label39" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"cheque_status")%>' />
                                            
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"REASON")%>' />
                                            
                                        </td>
                                          <td>
                                            <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ChqOutstanding")%>' />
                                            
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCollect_Status" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Recovery_Status")%>' />
                                        </td>
                                        <td style="text-align: center;">
                                            <div class="inline position-relative">
                                                <asp:LinkButton ID="lnkEdit" ToolTip="Add Followup Remark" class="btn-small btn-success icon-plus"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Pkey")%>' Visible='<%#Convert.ToInt32(DataBinder.Eval(Container.DataItem,"Cheque_Activity")) == 0 ? true : false%>'
                                                    runat="server" CommandName="comAdd" Height="25px" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody> </table>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:Repeater ID="Repeater1" runat="server" Visible="false">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered table-hover Table2">
                                        <thead>
                                            <tr>
                                                <th style="text-align: center;">
                                                    <b>Division </b>
                                                </th>
                                                <th align="left" style="width: 15%">
                                                    Center Name
                                                </th>
                                                <th align="left" style="width: 15%">
                                                    Stream Name
                                                </th>
                                                <th align="left" style="width: 15%">
                                                    Sbentry Code
                                                </th>
                                                <th align="left" style="width: 20%">
                                                    Student Name
                                                </th>
                                                <th align="left" style="width: 20%">
                                                    Cheque No
                                                </th>
                                                <th align="left" style="width: 10%">
                                                    Cheque Amount
                                                </th>
                                                <th align="left" style="width: 10%">
                                                    Recovery Status
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSBEntrycode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStudent_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CENTER")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Stream_Name")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStream_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblchequeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_Name")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblcheque_status" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pay_InsNum")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Amount")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCollect_Status" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Recovery_Status")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody> </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divaddremark" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Add Followup Remark
                            <asp:Label ID="lblPkey" Visible="false" runat="server" Text="Label"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="widget-body-inner">
                                    <div class="widget-main">
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label8">Student Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblStudentName" runat="server" Text="Label" class="blue"></asp:Label>
                                                                <asp:Label ID="lblsbentrycode" Visible="false" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label9">Stream Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblstreamname" runat="server" Text="Label" class="blue"></asp:Label>
                                                                <asp:Label ID="lblstreamcode" Visible="false" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label10" runat="server">Centre Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCenterName" runat="server" Text="Label" class="blue"></asp:Label>
                                                                <asp:Label ID="lblcenter_code" Visible="false" runat="server" Text="Label"></asp:Label>
                                                                <asp:Label ID="lblcheque_status" runat="server" Visible="false" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; height: 36px;" class="table-hover"
                                                        width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; height: 18px; width: 40%;">
                                                                <asp:Label runat="server" ID="Label11">Cheque No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; height: 18px; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblchequeNo" runat="server" Text="Label" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; height: 36px;" class="table-hover"
                                                        width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; height: 18px; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3">Instrument Amount</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; height: 18px; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblinstrumentAmount" runat="server" Text="Label" class="blue"></asp:Label>
                                                                <asp:Label ID="lblchequeId" runat="server" Text="Label" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label7">Recovery Status</asp:Label>
                                                                <asp:Label ID="label27" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlRecoveryStatus1" Width="220px" runat="server" data-placeholder="Select"
                                                                    CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRecoveryStatus1_SelectedIndexChanged">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Pending To Recover</asp:ListItem>                                                                    
                                                                    <asp:ListItem>Partially Recovered</asp:ListItem>
                                                                    <asp:ListItem>Recovered</asp:ListItem>
                                                                    <asp:ListItem>Non Recoverable</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlRecoveryStatus1"
                                                                    Text="#" runat="server" ValidationGroup="UcValidateSearch" SetFocusOnError="True"
                                                                    ErrorMessage="Select Recovery Status" InitialValue="Select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="cheque" visible="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; height: 36px;" class="table-hover"
                                                        width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; height: 18px; width: 40%;">
                                                                <asp:Label runat="server" ID="Label23">Recovered Cheque No</asp:Label>
                                                                <asp:Label ID="label28" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; height: 18px; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlChequenoNo" Width="220px" ToolTip="Cheque No"
                                                                    data-placeholder="Select Cheque no" CssClass="chzn-select" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlChequenoNo_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; height: 36px;" class="table-hover"
                                                        width="100%">
                                                        <tr runat="server">
                                                            <td style="border-style: none; text-align: left; height: 18px; width: 40%;">
                                                                <asp:Label runat="server" ID="Label26">Recovered Amount</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; height: 18px; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblAmount" runat="server" Text="Label" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label29">Fees Amount Collected</asp:Label>
                                                                <asp:Label ID="label30" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlamountcollected" Width="220px" runat="server" data-placeholder="Select"
                                                                    CssClass="chzn-select">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Including Course Fees</asp:ListItem>
                                                                    <asp:ListItem>Excluding Course Fees</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="folpdate">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; height: 46px;" class="table-hover"
                                                        width="100%">
                                                        <tr>
                                                            <td style="border-style: none; height: 23px; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label22">Next Followup Date</asp:Label>
                                                                <asp:Label ID="label31" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; height: 23px; text-align: left; width: 60%;">
                                                                <input readonly="readonly" class="span10 date-picker" width="425px;" id="txtfollowupto"
                                                                    runat="server" type="text" data-date-format="dd M yyyy" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                </td>
                                            </tr>
                                            <tr runat="server" id="followupdate1" visible="false">
                                               <td class="span4" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label35">Bounced Charges Collected</asp:Label>
                                                                <asp:Label ID="label36" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlbouncedcharges" Width="220px" runat="server" data-placeholder="Select"
                                                                    CssClass="chzn-select">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Including Penalty</asp:ListItem>
                                                                    <asp:ListItem>Excluding Penalty</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <%--<table cellpadding="0" style="border-style: none; height: 36px;" class="table-hover"
                                                        width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; height: 18px; width: 40%;">
                                                                <asp:Label runat="server" ID="Label24">IsBounced Penalty Collected</asp:Label>
                                                                <asp:Label ID="label25" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; height: 18px; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlisbounced" Width="220px" runat="server" data-placeholder="Select"
                                                                    CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRecoveryStatus1_SelectedIndexChanged">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                    </table>--%>
                                                </td>
                                             
                                                <td class="span4" style="text-align: left">
                                                </td>
                                            </tr>
                                            <tr runat="server" id="TrFollowup" visible="false">
                                                <td class="span10" style="text-align: left" colspan="3">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 13%;">
                                                                <asp:Label runat="server" ID="Label13" Width="40%">Followup Remark</asp:Label>
                                                                <asp:Label ID="label19" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 87%;">
                                                                <asp:TextBox ID="txtFollowup_Remark" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                             
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="widget-main alert-block alert-info" style="text-align: center;" runat="server"
                                        id="buttonarea">
                                        <!--Button Area -->
                                        <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" Visible="false"
                                            ID="btnsave" Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="btnsave_Click" />
                                        <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnClose"
                                            Text="Close" ToolTip="Close" OnClick="btnClose_Click" />
                                        <asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                                            ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ddlRecoveryStatus1" />
                                <asp:PostBackTrigger ControlID="btnsave" />
                                <asp:PostBackTrigger ControlID="btnClose" />
                                <asp:PostBackTrigger ControlID="ddlChequenoNo" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div id="divfalloutupdated" runat="server" class="dataTables_wrapper" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Followup History
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <p>
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lblFollowupRecords" runat="server" Text="" Visible="false" CssClass="red"></asp:Label>
                                </p>
                                <%--<asp:Repeater ID="RFollowupDisplay" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-striped table-bordered table-hover Table4">
                                            <thead>
                                                <tr>
                                                    <th style="text-align: center;">
                                                        <b>Stream Name</b>
                                                    </th>
                                                    <th style="text-align: center;">
                                                        Student Name
                                                    </th>
                                                    <th style="text-align: center;">
                                                        Sbentry Code
                                                    </th>
                                                    <th style="text-align: center;">
                                                        Cheque Status
                                                    </th>
                                                    <th style="text-align: center;">
                                                        Remark
                                                    </th>
                                                    <th style="text-align: center;">
                                                        Collect Status
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 10%; text-align: left;">
                                                <asp:Label ID="lblPremises_ID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Stream_Name")%>' />
                                            </td>
                                            <td style="width: 10%; text-align: left;">
                                                <asp:Label ID="lblPremises_Type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_Name")%>' />
                                            </td>
                                            <td style="width: 10%; text-align: left;">
                                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntryCode")%>' />
                                            </td>
                                            <td style="width: 10%; text-align: left;">
                                                <asp:Label ID="lblCompany" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Cheque_status")%>' />
                                            </td>
                                            <td style="width: 10%; text-align: left;">
                                                <asp:Label ID="lblCarpet_Area" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"followup_remark")%>' />
                                            </td>
                                            <td style="width: 7%; text-align: left;">
                                                <asp:Label ID="lblCity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"collect_status")%>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>--%>
                                <asp:DataList ID="RFollowupDisplay" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%" Visible="True">
                                    <HeaderTemplate>
                                        <b> Sbentry Code</b> </th>
                                        <%--<th style="text-align: center;">
                                            Sbentry Code
                                        </th>--%>
                                        <th style="text-align: center;">
                                            Cheque Status
                                        </th>
                                         <th style="text-align: center;">
                                            Cheque No
                                        </th>
                                         <th style="text-align: center;">
                                            Recovery Amount
                                        </th>
                                         <th style="text-align: center;">
                                           
                                            Bounced ChargesCollected
                                        </th>
                                         <th style="text-align: center;">
                                           
                                          Fees AmountCollected
                                        </th>
                                        <th style="text-align: center;">
                                           Next Followup Date
                                        </th>
                                        <th style="text-align: center;">
                                            Followup Remark
                                        </th>
                                        <th style="text-align: center;">
                                            Recovery Status
                                        </th>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                       <%-- <asp:Label ID="lblPremises_ID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Student_Name")%>' />
                                        </td>
                                        <td style="width: 20%; text-align: left;">--%>
                                            <asp:Label ID="lblPremises_Type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntryCode")%>' />
                                        </td>
                                        <td style="width: 15%; text-align: left;">
                                            <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Cheque_status")%>' />
                                        </td>
                                           <td style="width: 15%; text-align: left;">
                                            <asp:Label ID="Label32" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Recovered_ChequeNo")%>' />
                                        </td>
                                           <td style="width: 15%; text-align: left;">
                                            <asp:Label ID="Label33" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Recovered_Amount")%>' />
                                        </td>
                                           <td style="width: 15%; text-align: left;">
                                            <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Bounced_ChargesCollected")%>' />
                                        </td>
                                            <td style="width: 15%; text-align: left;">
                                            <asp:Label ID="Label38" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Fees_AmountCollected")%>' />
                                        </td>
                                        <td style="width: 10%; text-align: left;">
                                            <asp:Label ID="lblCompany" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Followupdate")%>' />
                                        </td>
                                        <td style="width: 25%; text-align: left;">
                                            <asp:Label ID="lblCarpet_Area" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"followup_remark")%>' />
                                        </td>
                                        <td style="width: 13%; text-align: left;">
                                            <asp:Label ID="lblCity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Recovery_Status")%>' />
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
</asp:Content>
