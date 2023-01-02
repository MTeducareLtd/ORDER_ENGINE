<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Approval_Bulk.aspx.cs" Inherits="Approval_Bulk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div class="row-fluid hidden-print">
        <div id="breadcrumbs" class="position-relative">
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                    class="icon-angle-right"></i></span></li>
                <li>
                    <h5 class="smaller">
                        <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname"
                            runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
                                <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                        <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                        <span class="divider"></span>
                    </h5>
                </li>
                <li id="limidbreadcrumb" runat="server" visible="false"><a href="#">
                    <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
                <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
                </i><a href="#">
                    <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
            </ul>
            <div id="nav-search">
                <span id="listudentstatus" runat="server"><span id="badgeError" runat="server" class="badge badge-important"
                    visible="true">Student Status : Pending</span> <span id="badgeSuccess" runat="server"
                        class="badge badge-success" visible="false">Student Status : Confirmed</span>
                    <span id="badgeCancel" runat="server" class="badge badge-danger" visible="false">Student
                        Status : Cancelled</span>
                    <asp:Label ID="lblstdstaus" runat="server" Visible="false"></asp:Label>
                </span>
                <button type="button" class="btn  btn-primary btn-small radius-4  btn-danger" id="btnback"
                    runat="server" onserverclick="btnback_ServerClick">
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
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnlsearch" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div id="tab_1_3">
                                <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Organizational Assignment
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Company
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Division
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Center
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Customer Information
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Academic Year
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlacademicyear" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Product
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstreamname" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Customer Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtname" runat="server" Width="90%" placeholder="Search by Name"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Customer Number / SB Entry Code
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsbentrycode" runat="server" Width="90%" placeholder="Search by SBEntrycode"></asp:TextBox>
                                                    </td>
                                                    <td width="10%" id="tdapplicationid" runat="server">
                                                        App. Form No
                                                    </td>
                                                    <td width="20%" id="tdapplicationid1" runat="server">
                                                        <asp:TextBox ID="txtapplicationno" runat="server" Width="90%" placeholder="Search by Application Form No."></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Request Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlrequesttype" runat="server" data-placeholder="Select" CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="tr12" runat="server" visible="false">
                                                    <td width="10%">
                                                        Request Date
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtrequestdate" runat="server" Width="90%" placeholder="Search by Date"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtrequestdate"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                    </td>
                                                    <td width="10%">
                                                        Status
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlrequeststatus" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select" Enabled="false">
                                                            <asp:ListItem Value="All">All</asp:ListItem>
                                                            <asp:ListItem Value="0" Selected="true">Pending</asp:ListItem>
                                                            <asp:ListItem Value="1">Approved</asp:ListItem>
                                                            <asp:ListItem Value="2">Declined</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" runat="server"
                                                    onserverclick="btnsearch_ServerClick">
                                                    Search
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid" id="divsearchresults" runat="server">
                                    <div class="span12">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                            <div class="widget-header widget-header-small header-color-dark">
                                                <h5>
                                                    <i class="fa fa-globe"></i>Approval Search Results
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <asp:Repeater ID="Repeater1" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table table-striped table-bordered table-hover Table1">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            <asp:CheckBox ID="Selectallcheckbox" runat="server" ToolTip="Select All" onclick="Selectall_Deselectall(this)" />
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Acad Year
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Date
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Center / Location
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Request Type
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Name
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            SBEntrycode
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Product
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Requested Amount
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Status
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Open (Days)
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Approve
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Approve Amount
                                                                        </th>
                                                                        <th align="center" style="text-align: center">
                                                                            Remark
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr class="odd gradeX">
                                                                <td>
                                                                    <asp:CheckBox ID="checkpoint" runat="server" AutoPostBack="true" /><span class="lbl"></span>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "Acad_year")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Date")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblrequesttype" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Type")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Student_Name")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label8" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntrycode")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "Stream_Sdesc")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <div style="float: left; width: 99%; text-align: right;">
                                                                        <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'
                                                                            runat="server"></asp:Label></div>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Status")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label10" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="rbtlapprove" runat="server" data-placeholder="Select">
                                                                        <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtamountapp" runat="server" Width="85%" ValidationGroup="Val1"
                                                                        Text="0" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtappremark" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td id="Td3" width="2%" runat="server" visible="false">
                                                                    <asp:LinkButton ID="lnkviewdetails" runat="server" CommandName="ViewDetails" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>'
                                                                        class="btn btn-minier btn-primary icon-edit tooltip-info" data-rel="tooltip"
                                                                        data-placement="top" title="View Details">
                                                                    </asp:LinkButton>
                                                                </td>
                                                                <td id="Td1" width="2%" runat="server" visible="false">
                                                                    <asp:Label ID="lblsbentrycode" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntrycode")%>'
                                                                        runat="server" Visible="false"></asp:Label>
                                                                </td>
                                                                <td id="Td2" width="2%" runat="server" visible="false">
                                                                    <asp:Label ID="lblrequestid" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Id")%>'
                                                                        runat="server" Visible="false"></asp:Label>
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
                                        <!-- END EXAMPLE TABLE PORTLET-->
                                    </div>
                                </div>
                                <div class="alert alert-danger" id="divmessage" runat="server">
                                    <strong>
                                        <asp:Label ID="lblmessage" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
