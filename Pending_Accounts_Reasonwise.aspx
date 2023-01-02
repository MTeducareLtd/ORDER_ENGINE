<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Pending_Accounts_Reasonwise.aspx.cs" Inherits="Pending_Accounts_Reasonwise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
<asp:ScriptManager ID="script1" runat="server">
</asp:ScriptManager>
<div id="page-content" class="clearfix">
<div class="page-header position-relative">
<h1>
<b>Dashboard </b><small><i class="icon-double-angle-right"></i>&nbsp;<b>Pending Accounts</b></small>
<div class="nav ace-nav pull-right">
<small style="font-size:16px">Division</small>
<asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" AutoPostBack="true" Style="border-radius:10;width:200px" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
</asp:DropDownList>
&nbsp; <small style="font-size:16px">Center</small>
<asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" AutoPostBack="true" Style="border-radius:10;width:200px" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
</asp:DropDownList>
&nbsp; <small style="font-size:16px">Academic Year</small>
<asp:DropDownList ID="ddlAcadYear" runat="server" data-placeholder="Select" AutoPostBack="true" Style="border-radius:10;width:200px" OnSelectedIndexChanged="ddlAcadYear_SelectedIndexChanged">
</asp:DropDownList>
</div>
</h1>
</div>
<div class="alert alert-danger" id="divErrormessage" runat="server">
<strong>
<asp:Label ID="lblerrormessage" runat="server"> No Records Found !!</asp:Label></strong>
</div>
<div class="row-fluid" id="divsearchresults" runat="server">
<div class="span12">
<div class="widget-box">
<div class="widget-header widget-hea1der-small header-color-dark">
<h4 class="smaller">
<i class="icon-book"></i>Pending Accounts Reasonwise
</h4>
</div>
<div class="widget-body">
<div class="table-toolbar" id="divtoolbar" runat="server" visible="false">
</div>
<asp:UpdatePanel ID="pnlSave2" runat="server">
<ContentTemplate>
<table width="100%">
<tr>
<td>
<h4>
<b>
<asp:Label ID="lblActualRecordCount" runat="server" CssClass="badge badge-inverse"></asp:Label>
</b>
<asp:Label ID="lblPageNumber" runat="server" Visible="false"></asp:Label>
<button id="btnStud_NextRecord" runat="server" class="btn btn-small btn-inverse radius-4" data-rel="tooltip" data-placement="right" title="Find Next Record" onserverclick="btnStud_NextRecord_ServerClick">
<i class="icon-share-alt"></i>
</button>
<button id="btnStud_PrevRecord" runat="server" class="btn btn-small btn-inverse radius-4" data-rel="tooltip" data-placement="right" title="Find Prev Record" onserverclick="btnStud_PrevRecord_ServerClick">
<i class="icon-reply"></i>
</button>
</h4>
</td>
<td align="right">
<b>
<asp:Label ID="lblTotalPendingAccounts2" runat="server" CssClass="badge badge-inverse">Total No of Records: </asp:Label>
&nbsp;
<asp:Label ID="lblTotalPendingAccounts" runat="server" Text="" CssClass="badge badge-inverse"></asp:Label>
</b>&nbsp; &nbsp;
</td>
</tr>
</table>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="btnStud_NextRecord" />
<asp:PostBackTrigger ControlID="btnStud_PrevRecord" />
</Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>
<asp:DataList ID="dlPendingAccountReasonwise" CssClass="table table-striped table-bordered table-hover" runat="server" Width="100%" OnItemCommand="dlPendingAccountReasonwise_ItemCommand">
<HeaderTemplate>
<b>Stream</b> </th>
<th style="width:20%;text-align:center">
Student Name
</th>
<th style="width:2%;text-align:center">
</th>
<th style="width:10%;text-align:center">
Outstanding
</th>
<th style="width:15%;text-align:center">
Reason
</th>
<th style="width:15%;text-align:center">
Expected Close Date
</th>
<th>
Remarks
</th>
<th style="width:10%;text-align:center">
Action
</th>
<th style="width:5%;text-align:center;vertical-align:middle">
</th>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lblCenterName" Text='<%#DataBinder.Eval(Container.DataItem, "CenterName")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblStream" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>' runat="server"></asp:Label>
<asp:Label ID="lblSBEntryCode" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntryCode")%>' runat="server" Visible="false">
</asp:Label>
</td>
<td>
<asp:Label ID="lblStudentName" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>' runat="server"></asp:Label>
</td>
<td>
<a href='<%#DataBinder.Eval(Container.DataItem,"SBEntryCode","Accounts.aspx?&SBEntryCode={0}") %>' id="btndisplay" runat="server" target="_blank" visible="true" class="btn btn-minier btn-success icon-eye-open tooltip-success" data-rel="tooltip" data-placement="top" title="View Ledger"></a>
</td>
<td style="text-align:right">
<asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Chqoutstanding")%>' runat="server"></asp:Label>
</td>
<td style="text-align:left">
<asp:Label ID="lblPending_ReasonId" Text='<%#DataBinder.Eval(Container.DataItem, "Pending_ReasonId")%>' runat="server" Visible="false">
</asp:Label>
<asp:DropDownList runat="server" ID="ddlPending_Reason" Width="215px" ToolTip="Pending Reason" data-placeholder="Select Pending Reason" CssClass="chzn-select" Visible="true" />
</td>
<td style="text-align:left">
<input type="text" readonly="readonly" class="span8 date-picker" id="txtExpectedCloseDate" runat="server" visible="true" value='<%#DataBinder.Eval(Container.DataItem, "ExpectedCloseDate")%>' data-date-format="dd M yyyy" style="width:80%" />
</td>
<td style="text-align:left">
<asp:TextBox ID="txtremarks" runat="server" MaxLength="200" Text='<%#DataBinder.Eval(Container.DataItem, "Remarks")%>'></asp:TextBox>
</td>
<td style="text-align:center">
<asp:LinkButton ID="lnkDLSave" ToolTip="Save" class="btn-small btn-success icon-save" runat="server" CommandName="Save" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' Visible="true" />
</td>
<td style="text-align:center;vertical-align:middle">
<a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
<asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
<i class="icon-bolt"></i>
</asp:Panel>
</a>
<asp:Label ID="lblSuccess" runat="server" Text='Success' CssClass='green' Visible="false" />
</td>
</ItemTemplate>
</asp:DataList>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="dlPendingAccountReasonwise" />
</Triggers>
</asp:UpdatePanel>
</div>
</div>
</div>
</div>
</div>
</asp:Content>