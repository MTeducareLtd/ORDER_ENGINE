<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Contacts.aspx.cs" Inherits="Contacts" %>

<%@ Register TagPrefix="ContactInfoPanel" TagName="ContactInfoPanel" Src="~/UserControl/uc_Contact_Information.ascx" %>
<%@ Register TagPrefix="HistoryPanel" TagName="HistoryPanel" Src="~/UserControl/uc_Contact_FollowUp_History.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
    <script language="javascript" type="text/javascript">
// <![CDATA[

        

// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
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
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="Contacts.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
            <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
            </i><a href="#">
                <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
        </ul>
        <div id="nav-search">
            <button type="button" class="btn btn-primary btn-small radius-4  btn-danger" id="btnback"
                runat="server" visible="false" onserverclick="btnback_ServerClick">
                <i class="icon-reply"></i>Back</button>
            <button type="button" class="btn  btn-primary btn-small radius-4  btn-danger" id="btnsearchback"
                runat="server" onserverclick="btnsearchback_ServerClick" visible="false">
                <i class="icon-reply"></i>Back to Contact Search</button>
            <!-- /btn-group -->
            <button type="button" class="btn btn-danger btn-small dropdown-toggle" data-toggle="dropdown"
                data-hover="dropdown" data-delay="1000" data-close-others="true">
                <span>Actions </span><i class="fa fa-angle-down"></i>
            </button>
            <ul class="dropdown-menu pull-right" role="menu">
                <li><a href="Add_Contacts.aspx" id="btnregistrationno" runat="server">Add Contact</a></li>
                <li><a href="Center_UploadContacts.aspx" id="A1" runat="server">Bulk Upload</a></li>
            </ul>
        </div>
        <!--#nav-search-->
    </div>
    <!-- BEGIN CONTENT -->
    <div id="page-content" class="clearfix">
        <div class="page-content">
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div id="tab_1_3" class="row-fluid">
                                <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                    <div class="span12">
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Search By : Customer Information
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td width="10%">
                                                    Search
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlSearchby" runat="server" data-placeholder="Select Search Type"
                                                        Width="215px" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchby_SelectedIndexChanged">
                                                        <asp:ListItem Value="1" Selected="True">Primary Contact</asp:ListItem>
                                                        <asp:ListItem Value="2">Secondary Contact</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Stage
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="dlsearchstage" runat="server" data-placeholder="Select Stage"
                                                        Width="215px" CssClass="chzn-select">
                                                        <asp:ListItem Value="1" Selected="True">Any</asp:ListItem>
                                                        <asp:ListItem Value="2">Lead</asp:ListItem>
                                                        <asp:ListItem Value="3">Opportunity</asp:ListItem>
                                                        <asp:ListItem Value="4">Account</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Customer Type
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcustomertypesearch" runat="server" data-placeholder="Select Type"
                                                        Width="215px" CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Institution Type
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlinstitutionsearch" runat="server" data-placeholder="Select Type"
                                                        Width="215px" OnSelectedIndexChanged="ddlinstitutionsearch_SelectedIndexChanged"
                                                        CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Board
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlboardsearch" runat="server" data-placeholder="Select Board"
                                                        Width="215px" CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Standard
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlstandardsearch" runat="server" data-placeholder="Select Standard"
                                                        Width="215px" CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Student Name
                                                    <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtstudentnamesearch" runat="server" Width="205px" placeholder="Search by Name"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    Handphone
                                                    <asp:Label ID="label20" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txthandphonesearch" runat="server" placeholder="Search by Handphone 1"
                                                        Width="205px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="well" style="text-align: center; background-color: #F0F0F0">
                                            <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" runat="server"
                                                onserverclick="btnsearch_ServerClick">
                                                Search
                                            </button>
                                        </div>
                                        <div class="widget-box" runat="server" visible="false">
                                            <%--<div class="widget-header widget-header-small header-color-dark">
                                                <h5>
                                                    Search Options :  Customer Information
                                                </h5>
                                            </div>--%>
                                            <div class="widget-body">
                                                <div class="widget-body-inner">
                                                    <div class="widget-main">
                                                        <div class="table-responsive">
                                                            <div id="divprimary1" runat="server" visible="false">
                                                                <div class="row-fluid">
                                                                    <div class="span12">
                                                                        <div class="widget-box">
                                                                            <div class="widget-header">
                                                                                <h5>
                                                                                    Organization Assignment
                                                                                </h5>
                                                                            </div>
                                                                            <div class="widget-body">
                                                                                <div class="widget-main">
                                                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                                                        <%-- <thead>
                                                                                        <tr>
                                                                                            <th colspan="6">
                                                                                                Organization Assignment
                                                                                            </th>
                                                                                        </tr>
                                                                                    </thead>--%>
                                                                                        <tr>
                                                                                            <td width="10%">
                                                                                                Company
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select Company"
                                                                                                    Width="215px" CssClass="chzn-select" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged"
                                                                                                    AutoPostBack="true">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td width="10%">
                                                                                                Division
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:DropDownList ID="ddldivision" runat="server" AutoPostBack="true" data-placeholder="Select Division"
                                                                                                    Width="215px" CssClass="chzn-select" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td width="10%">
                                                                                                Zone
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:DropDownList ID="ddlzone" runat="server" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged"
                                                                                                    Width="215px" AutoPostBack="true" data-placeholder="Select Zone" CssClass="chzn-select">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td width="10%">
                                                                                                Location / Center
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:DropDownList ID="ddlcenter" runat="server" AutoPostBack="true" data-placeholder="Select Location"
                                                                                                    Width="215px" CssClass="chzn-select">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="4">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <div class="span12">
                                                                    <%--<div class="widget-box">
                                                                        <div class="widget-header">
                                                                            <h5>
                                                                               
                                                                            </h5>
                                                                        </div>
                                                                        <div class="widget-body">
                                                                            <div class="widget-main">
                                                                                
                                                                            </div>
                                                                        </div>
                                                                    </div>--%>
                                                                </div>
                                                            </div>
                                                            <div class="row-fluid" runat="server" visible="false">
                                                                <div class="span12">
                                                                    <div class="widget-box">
                                                                        <div class="widget-header">
                                                                            <h5>
                                                                                Customer Residential Information
                                                                            </h5>
                                                                        </div>
                                                                        <div class="widget-body">
                                                                            <div class="widget-main">
                                                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                                                    <%--<thead>
                                                                        <tr>
                                                                            <th colspan="6">
                                                                                Customer Residential Information
                                                                            </th>
                                                                        </tr>
                                                                    </thead>--%>
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            Age From
                                                                                        </td>
                                                                                        <td width="20%">
                                                                                            <asp:TextBox ID="txtagefrom" runat="server" Width="205px" placeholder="Age From"></asp:TextBox>
                                                                                        </td>
                                                                                        <td width="10%">
                                                                                            To
                                                                                        </td>
                                                                                        <td width="20%">
                                                                                            <asp:TextBox ID="txtageto" runat="server" Width="205px" placeholder="Age To"></asp:TextBox>
                                                                                        </td>
                                                                                        <td colspan="2">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            Country
                                                                                        </td>
                                                                                        <td width="20%">
                                                                                            <asp:DropDownList ID="ddlcountrysearch" runat="server" OnSelectedIndexChanged="ddlcountrysearch_SelectedIndexChanged"
                                                                                                data-placeholder="Select Country" CssClass="chzn-select" AutoPostBack="true"
                                                                                                Width="215px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td width="10%">
                                                                                            State
                                                                                        </td>
                                                                                        <td width="20%">
                                                                                            <asp:DropDownList ID="ddlstatesearch" runat="server" OnSelectedIndexChanged="ddlstatesearch_SelectedIndexChanged"
                                                                                                data-placeholder="Select State" CssClass="chzn-select" AutoPostBack="true" Width="215px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td width="10%">
                                                                                            City
                                                                                        </td>
                                                                                        <td width="20%">
                                                                                            <asp:DropDownList ID="ddlcitysearch" runat="server" OnSelectedIndexChanged="ddlcitysearch_SelectedIndexChanged"
                                                                                                data-placeholder="Select City" CssClass="chzn-select" AutoPostBack="true" Width="215px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            Location
                                                                                        </td>
                                                                                        <td width="20%">
                                                                                            <asp:DropDownList ID="ddllocationsearch" runat="server" data-placeholder="Select Location"
                                                                                                Width="215px" CssClass="chzn-select" AutoPostBack="true">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td colspan="4">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="divprimary2" runat="server" visible="false">
                                                                <div class="row-fluid">
                                                                    <div class="span12">
                                                                        <div class="widget-box">
                                                                            <div class="widget-header">
                                                                                <h5>
                                                                                    Stream Information
                                                                                </h5>
                                                                            </div>
                                                                            <div class="widget-body">
                                                                                <div class="widget-main">
                                                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                                                        <%-- <thead>
                                                                                <tr>
                                                                                    <th colspan="6">
                                                                                        Stream Information
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>--%>
                                                                                        <tr>
                                                                                            <td width="10%">
                                                                                                Acad Year
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:DropDownList ID="ddlacadyearsearch" runat="server" AutoPostBack="true" data-placeholder="Select Acad Year"
                                                                                                    Width="215px" CssClass="chzn-select">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td width="10%">
                                                                                                Product Category
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:DropDownList ID="ddlproductcategory" runat="server" AutoPostBack="true" data-placeholder="Select Product Category"
                                                                                                    Width="215px" CssClass="chzn-select">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td width="10%">
                                                                                                Stream
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:DropDownList ID="ddlstreamsearch" runat="server" AutoPostBack="true" data-placeholder="Select Stream"
                                                                                                    Width="215px" CssClass="chzn-select">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td id="tdadmissionno" runat="server" width="10%">
                                                                                                Application Form No.
                                                                                            </td>
                                                                                            <td id="tdadmissionno1" runat="server" width="20%">
                                                                                                <asp:TextBox ID="txtadmissionformno" runat="server" placeholder="Search by Admission Form No."
                                                                                                    Width="205px"></asp:TextBox>
                                                                                            </td>
                                                                                            <td colspan="4">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row-fluid" runat="server" visible="false">
                                                            <div class="span12">
                                                                <div class="widget-box">
                                                                    <div class="widget-header">
                                                                        <h5>
                                                                            Last Examination Details
                                                                        </h5>
                                                                    </div>
                                                                    <div class="widget-body">
                                                                        <div class="widget-main">
                                                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                                                <%--<thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Last Examination Details
                                                    </th>
                                                </tr>
                                            </thead>--%>
                                                                                <tr>
                                                                                    <td width="10%">
                                                                                        Board
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlboardsearch2" runat="server" data-placeholder="Select Board"
                                                                                            CssClass="chzn-select" AutoPostBack="true" Width="215px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td width="10%">
                                                                                        Standard
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlstandardsearch2" runat="server" data-placeholder="Select Standard"
                                                                                            CssClass="chzn-select" AutoPostBack="true" Width="215px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td width="10%">
                                                                                        Year
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlyearsearch" runat="server" data-placeholder="Select Year"
                                                                                            CssClass="chzn-select" AutoPostBack="true" Width="215px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="10%">
                                                                                        Score Type
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlscoretype" runat="server" data-placeholder="Select Score Type"
                                                                                            CssClass="chzn-select" AutoPostBack="true" Width="215px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td width="10%">
                                                                                        Condition
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlcondition" runat="server" data-placeholder="Select Condition"
                                                                                            CssClass="chzn-select" AutoPostBack="true" Width="215px">
                                                                                            <asp:ListItem Value="0" Selected="True">All</asp:ListItem>
                                                                                            <asp:ListItem Value="1">Less Than</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Less Than Equal</asp:ListItem>
                                                                                            <asp:ListItem Value="3">Greater Than Equal</asp:ListItem>
                                                                                            <asp:ListItem Value="4">Greater Than</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Equal</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td width="10%">
                                                                                        Score
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:TextBox ID="txtscore" runat="server" Width="205px" placeholder="Search by Score"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="10%">
                                                                                        Examination Details
                                                                                    </td>
                                                                                    <td width="20%">
                                                                                        <asp:TextBox ID="txtexamsearch" runat="server" Width="205px" placeholder="Search by Examination Details"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="4">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
                            </div>
                            <div class="row-fluid" id="divsearchresults" runat="server">
                                <div class="span12">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                    <div class="widget-box">
                                        <div class="widget-body">
                                            <div class="widget-header widget-hea1der-small header-color-dark">
                                                <h4 class="smaller">
                                                    <i class="icon-briefcase"></i>Contact Search Results</h4>
                                                <div class="widget-toolbar">
                                                    <asp:Label ID="lblexecutiontime" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="widget-body">
                                                <asp:Repeater ID="dlsearch" runat="server" OnItemDataBound="dlsearch_ItemDataBound"
                                                    OnItemCommand="dlsearch_ItemCommand">
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered table-hover Table3">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        Customer Type
                                                                    </th>
                                                                    <th>
                                                                        Contact Type
                                                                    </th>
                                                                    <th>
                                                                        Name
                                                                    </th>
                                                                    <th>
                                                                        Age
                                                                    </th>
                                                                    <th>
                                                                        Board
                                                                    </th>
                                                                    <th>
                                                                        Standard
                                                                    </th>
                                                                    <th>
                                                                        Year
                                                                    </th>
                                                                    <th>
                                                                        Last Action
                                                                    </th>
                                                                    <th>
                                                                        On
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
                                                                <asp:Label ID="lblstudentname1" Text='<%#DataBinder.Eval(Container.DataItem, "category_type")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Con_type_Desc")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>' runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <div style="float: left; width: 99%; text-align: right;">
                                                                    <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "age")%>' runat="server"></asp:Label></div>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "board_desc")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label8" Text='<%#DataBinder.Eval(Container.DataItem, "current_standard_desc")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "yearpass")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Action")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "createdon")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnkdisplay" runat="server" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                    CommandName="Display" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Con_id")%>'
                                                                    ToolTip="Display"></asp:LinkButton>&nbsp;
                                                                <%--<asp:LinkButton ID="lnkconverttolead" runat="server" class="btn btn-minier btn-pink  icon-exchange tooltip-success"
                                                                    CommandName="Convert_To_Lead" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Con_id")%>'
                                                                    ToolTip="Convert To Lead"></asp:LinkButton>--%>
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Con_id","Contact_Edit.aspx?&Con_id={0}") %>'
                                                                    id="btnEdit" runat="server" target="_blank" class="btn btn-minier btn-primary  icon-edit tooltip-success"
                                                                    data-rel="tooltip" data-placement="top" title="Edit"></a>&nbsp; <a href='<%#DataBinder.Eval(Container.DataItem,"Con_id","Convert_Contact_To_Lead.aspx?&Con_id={0}") %>'
                                                                        id="btnConvertToLead" runat="server" target="_blank" class="btn btn-minier btn-pink  icon-exchange tooltip-success"
                                                                        data-rel="tooltip" data-placement="top" title="Assign To Lead"></a>&nbsp;
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Con_id","Contact_Followup.aspx?&Con_id={0}") %>'
                                                                    id="btnContactFollowup" runat="server" target="_blank" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="FollowUp"></a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody> </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <asp:Label ID="lblConid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblpromoteflag" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <!-- END EXAMPLE TABLE PORTLET-->
                                    </div>
                                </div>
                            </div>
                            <%-- Old
                                        <div class="row-fluid" id="divsearchresults" runat="server">
                                            <div class="span12">
                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                <div class="portlet box green ">
                                                    <div class="portlet-title">
                                                        <div class="table-header">
                                                            Contact Search Results
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <asp:DataList ID="dlsearch" runat="server" Width="100%" DataKeyField="Con_id" CssClass="table table-striped table-bordered table-hover" OnItemDataBound ="dlsearch_ItemDataBound" OnItemCommand ="dlsearch_ItemCommand">
                                                            <HeaderTemplate>
                                                                <b>Customer Type</b></th>
                                                                <th>
                                                                    Contact Type
                                                                </th>
                                                                <th>
                                                                    Name
                                                                </th>
                                                                <th>
                                                                    Age
                                                                </th>
                                                                <th>
                                                                    Board
                                                                </th>
                                                                <th>
                                                                    Standard
                                                                </th>
                                                                <th>
                                                                    Year
                                                                </th>
                                                                <th>
                                                                    Last Action
                                                                </th>
                                                                <th>
                                                                    On
                                                                </th>
                                                                <th>
                                                                Action
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstudentname" Text='<%#DataBinder.Eval(Container.DataItem, "category_type")%>'
                                                                    runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Con_type_Desc")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>' runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <div style="float: left; width: 99%; text-align: right;">
                                                                        <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "age")%>' runat="server"></asp:Label></div>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "board_desc")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label8" Text='<%#DataBinder.Eval(Container.DataItem, "current_standard_desc")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "yearpass")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Action")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "createdon")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkdisplay" runat="server" class="btn default btn-xs green" CommandName="Display"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Con_id")%>'><i class="fa fa-eye"></i> Display</asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkconverttolead" runat="server" class="btn default btn-xs blue"
                                                                        CommandName="Convert_To_Lead" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Con_id")%>'><i class="fa fa-arrow-right"></i> Convert To Lead </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:Label ID="lblConid" runat="server" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblpromoteflag" runat="server" Visible="false"></asp:Label>
                                                        <div class="pagination">
                                                            <div class="results">
                                                                <asp:Label ID="lbl1" runat="server"></asp:Label>
                                                                <asp:Button ID="btnprevious" runat="server" Text="Prev" class="button" OnClick ="btnprevious_Click" />&nbsp;&nbsp;&nbsp;
                                                                <asp:Button ID="Btnnext" runat="server" Text="Next" class="button" OnClick ="Btnnext_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- END EXAMPLE TABLE PORTLET-->
                                            </div>
                                        </div>
                                        End Old--%>
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
                    <asp:PostBackTrigger ControlID="dlsearch" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnldisplay" runat="server">
                <ContentTemplate>
                    <div class="row-fluid">
                        <div class="span12">
                            <div id="Div3" class="row-fluid">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="row-fluid">
                                            <asp:Label ID="lblPKey_Con_Id" runat="server" Visible="false"></asp:Label>
                                            <ContactInfoPanel:ContactInfoPanel runat="server" ID="ContactInfoPanel1"></ContactInfoPanel:ContactInfoPanel>
                                        </div>
                                        <div class="row-fluid">
                                            <HistoryPanel:HistoryPanel runat="server" ID="HistoryPanel1"></HistoryPanel:HistoryPanel>
                                        </div>
                                        <div class="well" style="text-align: center; background-color: #F0F0F0">
                                            <!--Button Area -->
                                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnClose" Visible="true"
                                                runat="server" Text="Close" OnClick="btnClose_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnClose" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
