<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Manage_Payments.aspx.cs" Inherits="Manage_Payments" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
<asp:ScriptManager ID="script1" runat="server">
</asp:ScriptManager>
<div class="row-fluid hidden-print">
<div id="breadcrumbs" class="position-relative">
<ul class="breadcrumb">
<li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
<li>
<h5 class="Smaller">
<asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname" runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
<asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
<asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
<span class="divider"></span>
</h5>
</li>
<li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
<asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
<li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
</i><a href="#">
<asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
<li class="btn-group" id="liregno" runat="server" visible="false">
<button type="button" class="btn purple dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" visible="false">
<span>Actions </span><i class="fa fa-angle-down"></i>
</button>
<ul class="dropdown-menu pull-right" role="menu">
<li><a id="A2" runat="server" href="Series.aspx" target="_blank">Manage Statutory Info.</a>
</li>
</ul>
</li>
<li class="btn-group"><a data-loading-text="Loading..." class="demo-loading-btn btn blue" runat="server" visible="false" target="_blank" id="btnviewenrollment" style="margin-right:197px;position:relative"><i class="fa fa-bullhorn"></i>View Order</a>&nbsp; </li>
</ul>
<div id="nav-search">
<span id="listudentstatus" runat="server"><span class="badge badge-important">
<asp:Label ID="lblstdstaus" runat="server"></asp:Label></span> </span>
<button type="button" class="btn btn-primary btn-small radius-4 btn-danger" id="btnsearchback" runat="server" onserverclick="btnsearchback_ServerClick" visible="false">
<i class="icon-reply"></i>Back to Payment Search</button>
</div>
</div>
</div>
<div class="page-container">
<div id="page-content" class="clearfix">
<div class="page-content">
<div class="alert alert-danger" id="divErrormessage" runat="server">
<button class="close" data-close="alert">
</button>
<strong>
<asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
</div>
<div class="alert alert-success" id="divSuccessmessage" runat="server">
<button class="close" data-close="alert">
</button>
<strong>
<asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
</div>
<div class="alert alert-danger" id="divmessage" runat="server">
<strong>
<asp:Label ID="lblmessage" runat="server"></asp:Label>
</strong>
</div>
<div class="alert alert-block alert-success" id="Divmessage1" runat="server">
<button type="button" class="close" data-dismiss="alert">
<i class="icon-remove"></i>
</button>
<i class="icon-ok green"></i>Grid Display only <strong class="green">Active Accounts</strong>,
</div>
<asp:UpdatePanel ID="upnlsearch" runat="server">
<ContentTemplate>
<div class="row-fluid" id="divSearch" runat="server">
<div class="span12">
<div id="tab_1_3" class="tab-pane active">
<div class="row-fluid" id="Divsearchcriteria" runat="server">
<div class="span12">
<div class="table-responsive">
<table class="table table-striped table-bordered table-advance table-hover">
<thead>
<tr>
<th colspan="6">
Organization Assignment
</th>
</tr>
</thead>
<tr>
<td width="10%">
Division
</td>
<td width="20%">
<asp:DropDownList ID="ddldivision" Width="215px" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
</asp:DropDownList>
<asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead12" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged" AutoPostBack="true" Width="215px" Visible="false">
</asp:DropDownList>
</td>
<td width="10%">
Location / Center
</td>
<td width="20%">
<asp:DropDownList ID="ddlcenter" Width="215px" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
</asp:DropDownList>
</td>
<td width="10%">
</td>
<td width="20%">
</td>
</tr>
</table>
<table class="table table-striped table-bordered table-advance table-hover">
<thead>
<tr>
<th colspan="6">
Stream Information
</th>
</tr>
</thead>
<tr>
<td width="10%">
Academic Year
<asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlacademicyear" Width="215px" runat="server" ValidationGroup="Grplead12" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="ddlacademicyear" Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Acacdemic Year" InitialValue="Select" />
</td>
<td width="10%">
Product Category
</td>
<td width="20%">
<asp:DropDownList ID="ddlproductcategory" Width="215px" runat="server" AutoPostBack="true" data-placeholder="Select" CssClass="chzn-select">
</asp:DropDownList>
</td>
<td width="10%">
Product
</td>
<td width="20%">
<asp:DropDownList ID="ddlstream" runat="server" Width="215px" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
</asp:DropDownList>
</td>
</tr>
<tr>
<td width="10%">
Status
</td>
<td width="20%">
<asp:DropDownList ID="ddlorderstatus" Width="215px" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
<asp:ListItem Value="01">Pending</asp:ListItem>
<asp:ListItem Value="03">Confirmed</asp:ListItem>
</asp:DropDownList>
</td>
<td width="10%">
Account Code (SBEntrycode)
</td>
<td width="20%">
<asp:TextBox ID="txtsbentrycode" runat="server" Width="205px" placeholder="Search by SBEntrycode"></asp:TextBox>
</td>
<td width="10%">
Active
</td>
<td width="20%">
<%--<asp:CheckBox ID="Chkactive" runat="server" Checked="true" /><span class="lbl"></span>--%>
<input runat="server" id="Chkactive" name="switch-field-1" type="checkbox" class="ace-switch ace-switch-2" checked="checked" />
<span class="lbl"></span>
</td>
</tr>
<tr>
<td width="10%">
Student Name
</td>
<td width="20%">
<asp:TextBox ID="txtstudentname" runat="server" Width="205px" placeholder="Search by Name"></asp:TextBox>
</td>
<td width="10%">
Handphone
</td>
<td width="20%">
<asp:TextBox ID="txthandphonesearch" runat="server" Width="205px" placeholder="Search by Handphone 1"></asp:TextBox>
</td>
<td width="10%">
</td>
<td width="20%">
</td>
</tr>
<tr id="tr15" runat="server" visible="false">
<td width="10%">
Show Only Promoted
</td>
<td width="20%">
<asp:CheckBox ID="chkpromoted" runat="server" />
</td>
<td width="10%">
Event
</td>
<td width="20%">
<asp:DropDownList ID="ddlevent" runat="server" Width="215px" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
</asp:DropDownList>
</td>
<td width="10%">
From
</td>
<td width="20%">
<asp:TextBox ID="txteventdatefrom" runat="server" Width="205px"></asp:TextBox>
<CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txteventdatefrom" DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
</CC1:CalendarExtender>
<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txteventdatefrom" ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
</td>
<td width="10%">
To
</td>
<td width="20%">
<asp:TextBox ID="txteventdateto" Width="205px" runat="server"></asp:TextBox>
<CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txteventdateto" DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
</CC1:CalendarExtender>
<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txteventdateto" ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
</td>
</tr>
<tr id="tr69" runat="server" visible="false">
<td width="10%" id="tdapplicationid" runat="server">
App. No
</td>
<td width="20%" id="tdapplicationid1" runat="server">
<asp:TextBox ID="txtapplicationno" runat="server" Width="70%" placeholder="Search by Application No."></asp:TextBox>
</td>
</tr>
</table>
<table id="Table1" class="table table-striped table-bordered table-advance table-hover" runat="server" visible="false">
<thead>
<tr>
<th colspan="6">
Customer Information
</th>
</tr>
</thead>
<tr>
<td width="10%">
Customer Type
</td>
<td width="20%">
<asp:DropDownList ID="ddlcustomertypesearch" Width="215px" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
</asp:DropDownList>
</td>
<td width="10%">
Institution Type
</td>
<td width="20%">
<asp:DropDownList ID="ddlinstitutionsearch" Width="215px" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlinstitutionsearch_SelectedIndexChanged">
</asp:DropDownList>
</td>
<td width="10%">
Board
</td>
<td width="20%">
<asp:DropDownList ID="ddlboardsearch" Width="215px" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
</asp:DropDownList>
</td>
</tr>
<tr>
<td width="10%">
Standard
</td>
<td width="20%">
<asp:DropDownList ID="ddlstandardsearch" Width="215px" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
</asp:DropDownList>
</td>
</tr>
</table>
<table id="Table2" class="table table-striped table-bordered table-advance table-hover" runat="server" visible="false">
<thead>
<tr>
<th colspan="6">
Customer Residential Information
</th>
</tr>
</thead>
<tr>
<td width="10%">
Country
</td>
<td width="20%">
<asp:DropDownList ID="ddlcountrysearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlcountrysearch_SelectedIndexChanged">
</asp:DropDownList>
</td>
<td width="10%">
State
</td>
<td width="20%">
<asp:DropDownList ID="ddlstatesearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlstatesearch_SelectedIndexChanged">
</asp:DropDownList>
</td>
<td width="10%">
City
</td>
<td width="20%">
<asp:DropDownList ID="ddlcitysearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlcitysearch_SelectedIndexChanged">
</asp:DropDownList>
</td>
</tr>
<tr>
<td width="10%">
Location
</td>
<td width="20%">
<asp:DropDownList ID="ddllocationsearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
</asp:DropDownList>
</td>
</tr>
</table>
<div class="well" style="text-align:center;background-color:#F0F0F0">
<button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" runat="server" onserverclick="btnsearch_ServerClick" validationgroup="Grplead12">
Search
</button>
<asp:ValidationSummary ID="ValidationSummary17" runat="server" ShowMessageBox="True" ValidationGroup="Grplead12" ShowSummary="False" />
</div>
</div>
</div>
</div>
<div class="row-fluid" id="divsearchresults" runat="server">
<div class="span12">
<%--<div class="portlet box blue">
                                                        <div class="portlet-title">
                                                            <div class="table-header">
                                                                Payments Search Results
                                                            </div>
                                                        </div>
                                                    <div class="portlet-body">--%>
<div class="widget-box">
<div class="widget-body">
<div class="widget-header widget-hea1der-small header-color-dark">
<h4 class="smaller">
<i class="icon-briefcase"></i>Payments Search Results</h4>
</div>
<div class="widget-body">
<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
<HeaderTemplate>
<table class="table table-striped table-bordered table-hover Table4">
<thead>
<tr>
<th>
Division
</th>
<th>
Location / Center
</th>
<th>
Date
</th>
<th>
App. Form No.
</th>
<th>
Customer Name
</th>
<th>
Product
</th>
<th>
Cheque O/S
</th>
<th>
Action
</th>
</tr>
</thead>
<tbody>
</HeaderTemplate>
<ItemTemplate>
<tr class="odd gradeX">
<td>
<asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblcenter" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Name")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lbldate" Text='<%#DataBinder.Eval(Container.DataItem, "EventDate")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label38" Text='<%#DataBinder.Eval(Container.DataItem, "App_no")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblcustomername" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblproduct" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblchequeos" CssClass="rightAlign" Text='<%#DataBinder.Eval(Container.DataItem, "Chqoutstanding")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label30" Text='<%#DataBinder.Eval(Container.DataItem, "Adm_Status")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
<asp:Label ID="Label6" runat="server"></asp:Label>
<asp:Label ID="lblpromotedflag" Text='<%#DataBinder.Eval(Container.DataItem, "IsPromote")%>' runat="server" Visible="false"></asp:Label>
<a href='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code","Display_Payment.aspx?&Cur_sb_code={0}") %>' id="btndisplay" runat="server" target="_blank" class="btn btn-minier btn-success icon-eye-open tooltip-success" data-rel="tooltip" data-placement="top" title="Display"></a>&nbsp; <a href='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code","Receive_Payment.aspx?&Cur_sb_code={0}") %>' id="A1" runat="server" target="_blank" class="btn btn-minier btn-danger icon-plus tooltip-success" data-rel="tooltip" data-placement="top" title="Add"></a><a href='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code","Edit_Payment.aspx?&Cur_sb_code={0}") %>' id="A2" runat="server" target="_blank" data-rel="tooltip" data-placement="top" title="Edit" visible="false"></a><a href='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code","Cancel_Payment.aspx?&Cur_sb_code={0}") %>' id="btneditenroll" runat="server" target="_blank" class="btn btn-minier btn-danger icon-ban-circle tooltip-Danger" data-rel="tooltip" data-placement="top" title="Remove" visible="false">
</a>
<asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>' Visible="false"></asp:LinkButton>
<asp:LinkButton ID="lnkledger" runat="server" CommandName="Ledger" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>' Visible="false"></asp:LinkButton>
<asp:Label ID="lblsbentrycode" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>' runat="server" Visible="false"></asp:Label>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</tbody> </table>
</FooterTemplate>
</asp:Repeater>
<asp:Label ID="lbloppurid" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblaccountid" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblpromoteflag" runat="server" Visible="false"></asp:Label>
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
<asp:PostBackTrigger ControlID="btnsearch" />
</Triggers>
</asp:UpdatePanel>
</div>
</div>
</div>
</asp:Content>