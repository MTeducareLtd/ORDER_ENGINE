<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Approval.aspx.cs" Inherits="Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN PAGE HEADER-->
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div class="row-fluid hidden-print">
        <div id="breadcrumbs" class="position-relative">
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                    class="icon-angle-right"></i></span></li>
                <li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
                    <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label>
                </a></span></li>
                <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
                </i><a href="#">
                    <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
                <li>
                    <h5 class="smaller">
                        <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname"
                            runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
                                <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                        <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                        <span class="divider"></span>
                    </h5>
                </li>
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
                    <i class="icon-reply"></i>Back to Search</button>
                <button type="button" class="btn  btn-primary btn-small radius-4  btn-danger" id="btnbackmain"
                    runat="server" onserverclick="btnbackmain_ServerClick">
                    <i class="icon-reply"></i>Back</button>
            </div>
            <!--#nav-search-->
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
                                                        Division
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged"
                                                            Width="215px">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" Width="215px" Visible="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Center
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged" Width="215px">
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
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged"
                                                            Width="215px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Product
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstreamname" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" Width="215px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Customer Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtname" runat="server" Width="205px" placeholder="Search by Name"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Customer Number / SB Entry Code
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsbentrycode" runat="server" Width="205px" placeholder="Search by SBEntrycode"></asp:TextBox>
                                                    </td>
                                                    <td width="10%" id="tdapplicationid" runat="server">
                                                        App. Form No
                                                    </td>
                                                    <td width="20%" id="tdapplicationid1" runat="server">
                                                        <asp:TextBox ID="txtapplicationno" runat="server" Width="205px" placeholder="Search by Application Form No."></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Request Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlrequesttype" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            Width="215px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="tr12" runat="server" visible="false">
                                                    <td width="10%">
                                                        Request Date
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtrequestdate" runat="server" Width="205px" placeholder="Search by Date"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtrequestdate"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                    </td>
                                                    <td width="10%">
                                                        Status
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlrequeststatus" runat="server" data-placeholder="Select"
                                                            Width="215px" CssClass="chzn-select" Enabled="false">
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
                                                <h6 class="smaller">
                                                    Approval Search Results</h6>
                                                <div class="widget-toolbar" runat="server" id="divapprovalall">
                                                    <button type="button" class="btn  btn-primary btn-small radius-4 btn-success " id="btnapproveall"
                                                        runat="server" onserverclick="btnapproveall_ServerClick">
                                                        <i class="icon-check"></i>Approve All</button>
                                                </div>
                                            </div>
                                            <div class="widget-body">
                                                <asp:CheckBox ID="chkStudentAllHidden_Sel" runat="server" Visible="False" />
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                                                    OnItemDataBound="Repeater1_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered table-hover Table1">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        <asp:CheckBox ID="chkStudentAll" runat="server" AutoPostBack="True" OnCheckedChanged="All_Student_ChkBox_Selected_Sel" /><span
                                                                            class="lbl"></span>
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
                                                                        Action
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td>
                                                                <asp:CheckBox ID="chkStudent" runat="server" /><span class="lbl"></span>
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
                                                                <asp:LinkButton ID="lnkviewdetails" runat="server" CommandName="ViewDetails" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>'
                                                                    class="btn btn-minier btn-primary icon-edit tooltip-info" data-rel="tooltip"
                                                                    data-placement="top" title="View Details">
                                                                </asp:LinkButton>
                                                            <td id="Td1" width="2%" runat="server" visible="false">
                                                                <asp:Label ID="lblsbentrycode" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntrycode")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td id="Td2" width="2%" runat="server" visible="false">
                                                                <asp:Label ID="lblrequestid" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Id")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td id="Td3" width="2%" runat="server" visible="false">
                                                                <asp:Label ID="lblrequest_type" Text='<%#DataBinder.Eval(Container.DataItem, "request_type_code")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td id="Td6" width="2%" runat="server" visible="false">
                                                                <asp:Label ID="lblcentercode" Text='<%#DataBinder.Eval(Container.DataItem, "Centre_Code")%>'
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
            <!-- BEGIN PAGE CONTENT FOR VIEW LEDGER-->
            <asp:UpdatePanel ID="Upnlviewledger" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row-fluid" id="div1" runat="server">
                        <div class="span12">
                            <div id="Div2">
                                <div class="row-fluid" id="Div3" runat="server">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <tr>
                                                    <td width="10%">
                                                        Gender
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtgender" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Student Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtLstudentname" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%" rowspan="3" id="td4" runat="server" visible="false">
                                                        <br />
                                                        <br />
                                                        Student Photo
                                                    </td>
                                                    <td width="20%" rowspan="3" id="td5" runat="server" visible="false">
                                                        <asp:Image ID="imgstudentphoto" runat="server" Width="150px" Height="100px" />
                                                    </td>
                                                    <td width="10%" rowspan="6" align="justify" valign="middle">
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                        Product / Item Group
                                                    </td>
                                                    <td width="20%" rowspan="6">
                                                        <asp:ListBox ID="lbsubjectgroup" Enabled="false" runat="server" Width="100%" Height="100%">
                                                        </asp:ListBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        App. No
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtLappno" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Opportunity Id
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtopportunityid" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Account ID
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtaccountid" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        SBEntrycode
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtcursbcode" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Company
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllcompany" Enabled="false" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Division
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlldivision" Enabled="false" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Center
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllcenter" Enabled="false" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Academic Year
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllacadyear" Enabled="false" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Stream
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllstream" Enabled="false" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Pay Plan
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtpayplan" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid" id="div5" runat="server">
                                    <div class="span3">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                            <div class="widget-header widget-header-small header-color-dark">
                                                <h5>
                                                    Student Ledger
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <asp:DataList ID="dlstudentledger" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        Height="30">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_description")%>'
                                                                runat="server" class="tooltip-info" data-rel="tooltip" data-placement="left"
                                                                title='<%#DataBinder.Eval(Container.DataItem, "Tooltip")%>' Font-Bold='<%#DataBinder.Eval(Container.DataItem, "BoldFlag")%>'></asp:Label></td>
                                                            <td>
                                                                <div style="float: left; width: 99%; text-align: right;">
                                                                    <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amt")%>'
                                                                        runat="server" Font-Bold='<%#DataBinder.Eval(Container.DataItem, "BoldFlag")%>'></asp:Label></div>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <asp:Label ID="lblrequestid" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span9">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box" id="centerrequest" runat="server">
                                            <div class="widget-header widget-header-small header-color-dark ">
                                                <h5>
                                                    Request Raised by :
                                                    <asp:Label ID="lblCenterusername" runat="server"></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="table-responsive" id="div11" runat="server">
                                                        <table width="100%" class="table table-striped table-bordered table-hover">
                                                            <tr id="tr001" runat="server">
                                                                <td width="10%">
                                                                    Category
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:Label ID="txtconditiontype" runat="server" class="blue"></asp:Label>
                                                                </td>
                                                                <td width="10%">
                                                                    Request Type
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:Label ID="txtrequesttype1" runat="server" class="blue"></asp:Label>
                                                                </td>
                                                                <td width="10%">
                                                                    Request Date
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:Label ID="txtrequestdate1" runat="server" class="blue"></asp:Label>
                                                                </td>
                                                                <td id="td1" runat="server" visible="false">
                                                                    <asp:Label ID="lblreqcode" runat="server" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="10%">
                                                                    Requested Amount
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtrequestamt" runat="server" Width="80%" Enabled="False"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                    Remark
                                                                </td>
                                                                <td width="20%" colspan="3">
                                                                    <asp:Label ID="txtcenterremark1" runat="server" class="blue"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div class="alert alert-danger" id="diverrorrequest" runat="server">
                                                            <strong>
                                                                <asp:Label ID="lblerrorReq" runat="server"></asp:Label></strong>
                                                        </div>
                                                        <div class="alert alert-success" id="divSuccessRequest" runat="server">
                                                            <strong>
                                                                <asp:Label ID="lblsuccessReq" runat="server"></asp:Label></strong>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="widget-box" id="divlevel1New" runat="server">
                                            <div class="widget-header widget-header-small header-color-dark ">
                                                <h5>
                                                    Level - I Approver :
                                                    <asp:Label ID="lbluserlevel1" runat="server"></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="table-responsive" id="div4" runat="server">
                                                        <table width="100%" class="table table-striped table-bordered table-hover">
                                                            <tr id="trlevel1_1" runat="server">
                                                                <td width="10%">
                                                                    Approve
                                                                </td>
                                                                <td width="20%" colspan="3">
                                                                    <asp:DropDownList ID="rbtlapprove" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="rbtlapprove_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="rbtlapprove"
                                                                        Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Approval Status"
                                                                        InitialValue="0" />
                                                                    <td width="10%">
                                                                        Enter Amount
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtamountapp" runat="server" Width="85%" ValidationGroup="Val1"
                                                                            Text="0" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtamountapp"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                                        <asp:CompareValidator ID="CompareValidator10021" runat="server" ControlToValidate="txtamountapp"
                                                                            ErrorMessage="Amount cannot be greater than the requested amount" ControlToCompare="txtrequestamt"
                                                                            Operator="LessThanEqual" Type="Integer" ValidationGroup="Val1" SetFocusOnError="true"
                                                                            Text="#"></asp:CompareValidator>
                                                                        <asp:CompareValidator ID="comparevalidator7" runat="server" ControlToValidate="txtamountapp"
                                                                            ValueToCompare="0" Operator="GreaterThan" ValidationGroup="Val1" Type="Integer"
                                                                            Text="#" SetFocusOnError="true" ErrorMessage="Amount cannot be zero"></asp:CompareValidator>
                                                                    </td>
                                                                </td>
                                                            </tr>
                                                            <tr id="trlevel1_3" runat="server">
                                                                <td width="10%">
                                                                    Remarks
                                                                </td>
                                                                <td width="20%" colspan="5">
                                                                    <asp:TextBox ID="txtappremark" runat="server" Width="85%" ValidationGroup="Val1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtappremark"
                                                                        Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter Remark" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trlevel2_1" runat="server">
                                                                <td width="10%">
                                                                    Amount
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtapprovedamt1" runat="server" Width="85%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                    Status
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtstatus1" runat="server" Width="85%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                    Approval Date
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="Txtappdate1" runat="server" Width="85%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr id="trlevel2_2" runat="server">
                                                                <td width="10%">
                                                                    Remark
                                                                </td>
                                                                <td width="20%" colspan="5">
                                                                    <asp:TextBox ID="txtpremark1" runat="server" Width="85%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div class="alert alert-danger" id="divlevel1error" runat="server">
                                                            <strong>
                                                                <asp:Label ID="lbllevel1error" runat="server"></asp:Label></strong>
                                                        </div>
                                                        <div class="alert alert-success" id="divlevel1success" runat="server">
                                                            <strong>
                                                                <asp:Label ID="lbllevel1success" runat="server"></asp:Label></strong>
                                                        </div>
                                                    </div>
                                                    <div class="well" style="text-align: center; background-color: #F0F0F0" id="divlevel1"
                                                        runat="server">
                                                        <button class="btn btn-app btn-success btn-mini radius-4" id="btnsubmitapp" runat="server"
                                                            validationgroup="Val1" onserverclick="btnsubmitapp_ServerClick">
                                                            Save</button>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                            ValidationGroup="Val1" ShowSummary="False" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="widget-box" id="divlevel2New" runat="server">
                                            <div class="widget-header widget-header-small header-color-dark">
                                                <h5>
                                                    Level - II Approver :
                                                    <asp:Label ID="lbluserlevel2" runat="server"></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="table-responsive" id="div6" runat="server">
                                                        <table width="100%" class="table table-striped table-bordered table-hover">
                                                            <tr id="trlevel2_3" runat="server">
                                                                <td width="10%">
                                                                    Approve
                                                                </td>
                                                                <td width="20%" colspan="3">
                                                                    <asp:DropDownList ID="rbtlapprovelevel1" runat="server" data-placeholder="Select"
                                                                        CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="rbtlapprovelevel1_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="rbtlapprovelevel1"
                                                                        Text="#" runat="server" ValidationGroup="Val2" SetFocusOnError="True" ErrorMessage="Select Approval Status"
                                                                        InitialValue="0" />
                                                                    <td width="10%">
                                                                        Enter Amount
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtamtlevel2" runat="server" Width="85%" ValidationGroup="Val2"
                                                                            Text="0" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtamtlevel2"
                                                                            Text="#" runat="server" ValidationGroup="Val2" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtamtlevel2"
                                                                            ErrorMessage="Amount cannot be greater than the requested amount" ControlToCompare="txtrequestamt"
                                                                            Type="Integer" Operator="LessThanEqual" ValidationGroup="Val2" SetFocusOnError="true"
                                                                            Text="#"></asp:CompareValidator>
                                                                        <asp:CompareValidator ID="comparevalidator2" runat="server" ControlToValidate="txtamtlevel2"
                                                                            ValueToCompare="0" Operator="GreaterThan" ValidationGroup="Val2" Type="Integer"
                                                                            Text="#" SetFocusOnError="true" ErrorMessage="Amount cannot be zero"></asp:CompareValidator>
                                                                    </td>
                                                                </td>
                                                            </tr>
                                                            <tr id="trlevel2_5" runat="server">
                                                                <td width="10%">
                                                                    Remark
                                                                </td>
                                                                <td width="20%" colspan="5">
                                                                    <asp:TextBox ID="txtremark2" runat="server" Width="85%" ValidationGroup="Val2"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtremark2"
                                                                        Text="#" runat="server" ValidationGroup="Val2" SetFocusOnError="True" ErrorMessage="Enter Remark" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trlevel3_1" runat="server">
                                                                <td width="10%">
                                                                    Amount
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtapprovalamt2" runat="server" Width="85%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                    Status
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtstatus2" runat="server" Width="85%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                    Approval Date
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="Txtappdate2" runat="server" Width="85%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr id="trlevel3_2" runat="server">
                                                                <td width="10%">
                                                                    Remark
                                                                </td>
                                                                <td width="20%" colspan="5">
                                                                    <asp:TextBox ID="txtpremark2" runat="server" Width="85%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div class="alert alert-danger" id="divlevel2error" runat="server">
                                                            <strong>
                                                                <asp:Label ID="lbllevel2error" runat="server"></asp:Label></strong>
                                                        </div>
                                                        <div class="alert alert-success" id="divlevel2success" runat="server">
                                                            <strong>
                                                                <asp:Label ID="lbllevel2success" runat="server"></asp:Label></strong>
                                                        </div>
                                                    </div>
                                                    <div class="well" style="text-align: center; background-color: #F0F0F0" id="Div8"
                                                        runat="server">
                                                        <button class="btn btn-app btn-success btn-mini radius-4" id="btnsubmitlevel2" runat="server"
                                                            validationgroup="Val2" onserverclick="btnsubmitlevel2_ServerClick">
                                                            Save</button>
                                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                            ValidationGroup="Val2" ShowSummary="False" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="widget-box" id="divlevel3New" runat="server">
                                            <div class="widget-header widget-header-small header-color-dark">
                                                <h5>
                                                    <i class="fa fa-anchor"></i>Level - III Approver :
                                                    <asp:Label ID="lbluserlevel3" runat="server"></asp:Label>
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="table-responsive" id="div7" runat="server">
                                                        <table width="100%" class="table table-striped table-bordered table-hover">
                                                            <tr id="trlevel3_3" runat="server">
                                                                <td width="10%">
                                                                    Approve
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="rbtlapprovelevel3" runat="server" data-placeholder="Select"
                                                                        CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="rbtlapprovelevel3_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="rbtlapprovelevel3"
                                                                        Text="#" runat="server" ValidationGroup="Val3" SetFocusOnError="True" ErrorMessage="Select Approval Status"
                                                                        InitialValue="0" />
                                                                </td>
                                                                <td width="10%">
                                                                    Amount
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtamtlevel3" runat="server" Width="95%" ValidationGroup="Val3"
                                                                        Text="0" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtamtlevel3"
                                                                        Text="#" runat="server" ValidationGroup="Val3" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtamtlevel3"
                                                                        Type="Integer" ErrorMessage="Amount cannot be greater than the requested amount"
                                                                        ControlToCompare="txtrequestamt" Operator="LessThanEqual" ValidationGroup="Val3"
                                                                        SetFocusOnError="true" Text="#"></asp:CompareValidator>
                                                                    <asp:CompareValidator ID="comparevalidator4" runat="server" ControlToValidate="txtamtlevel3"
                                                                        ValueToCompare="0" Operator="GreaterThan" ValidationGroup="Val3" Type="Integer"
                                                                        Text="#" SetFocusOnError="true" ErrorMessage="Amount cannot be zero"></asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trlevel3_5" runat="server">
                                                                <td width="10%">
                                                                    Remark
                                                                </td>
                                                                <td width="20%" colspan="3">
                                                                    <asp:TextBox ID="txtremark3" runat="server" Width="97%" ValidationGroup="Val3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtremark3"
                                                                        Text="#" runat="server" ValidationGroup="Val3" SetFocusOnError="True" ErrorMessage="Enter Remark" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trlevel3_6" runat="server">
                                                                <td width="10%">
                                                                    CRF Refund Amount
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtcrfrefundamt" runat="server" Width="97%" ValidationGroup="Val3"
                                                                        onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtcrfrefundamt"
                                                                        Text="#" runat="server" ValidationGroup="Val3" SetFocusOnError="True" ErrorMessage="Enter CRF Amount to be Refunded" />
                                                                </td>
                                                                <td width="10%">
                                                                    Robomate Refund Amount
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtroborefundamt" runat="server" Width="97%" ValidationGroup="Val3"
                                                                        onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtroborefundamt"
                                                                        Text="#" runat="server" ValidationGroup="Val3" SetFocusOnError="True" ErrorMessage="Enter Robomate Amount to be Refunded" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="well" style="text-align: center; background-color: #F0F0F0" id="Divlevel3"
                                                        runat="server">
                                                        <button class="btn btn-app btn-success btn-mini radius-4" id="btnsubmitlevel3" runat="server"
                                                            validationgroup="Val3" onserverclick="btnsubmitlevel3_ServerClick">
                                                            Save</button>
                                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                            ValidationGroup="Val3" ShowSummary="False" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsubmitapp" />
                    <asp:PostBackTrigger ControlID="btnsubmitlevel2" />
                    <asp:PostBackTrigger ControlID="btnsubmitlevel3" />
                    <asp:PostBackTrigger ControlID="btnapproveall" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR VIEW LEDGER-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
