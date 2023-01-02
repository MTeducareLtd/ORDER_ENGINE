<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Opportunity.aspx.cs" Inherits="Opportunity" ViewStateMode="Inherit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
    <style type="text/css">
        .ajax__calendar_container
        {
            position: absolute;
            z-index: 400000 !important; /*background-color: #DEF1F4;
        border:solid 0px #77D5F7;*/
            border: 0px solid #646464;
            background-color: White;
            color: red;
        }
    </style>
    <style type="text/css">
        .uppercase
        {
            text-transform: uppercase;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN CONTENT -->
    <!-- BEGIN PAGE HEADER-->
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="Opportunity.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a> </li>
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
        <!--#nav-search-->
        <div id="nav-search">
            <button type="button" class="btn  btn-primary btn-small radius-4  btn-danger" id="btnsearchback"
                runat="server" onserverclick="btnsearchback_ServerClick" visible="false">
                <i class="icon-reply"></i>Back to Opportunity Search</button>
            <button data-toggle="dropdown" class="btn btn-danger btn-small dropdown-toggle" runat="server"
                visible="false" id="btnAction">
                Action <span class="caret"></span>
            </button>
            <ul class="dropdown-menu dropdown-yellow pull-right dropdown-caret dropdown-close">
                <li><a href="#" id="btnaddOpp" runat="server" onserverclick="btnaddOpp_ServerClick"
                    visible="false">Add Opportunity</a></li>
                <li><a href="#" id="btnviewenrollment" runat="server" visible="false">View Enrollment</a></li>
            </ul>
        </div>
    </div>
    <!-- END PAGE HEADER-->
    <div id="page-content" class="clearfix">
        <div class="page-content">
            <!-- BEGIN PAGE CONTENT-->
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
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div id="tab_1_3" class="row-fluid">
                                <div class="row-fluid search-form-default" id="Divsearchcriteria" runat="server">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <tr>
                                                    <td width="10%">
                                                        Stage
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="dlsearchstage" runat="server" Width="215px" data-placeholder="Select Stage"
                                                            CssClass="chzn-select">
                                                            <asp:ListItem Value="1" Selected="True">Any</asp:ListItem>
                                                            <asp:ListItem Value="2">Opportunity</asp:ListItem>
                                                            <asp:ListItem Value="3">Enrolment</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="60%">
                                                    </td>
                                                </tr>
                                            </table>
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
                                                        <asp:DropDownList ID="ddldivision" runat="server" Width="215px" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged"
                                                            AutoPostBack="true" data-placeholder="Select Division" CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlcompany" runat="server" Width="215px" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged"
                                                            data-placeholder="Select Company" CssClass="chzn-select" AutoPostBack="true"
                                                            Visible="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <%-- <td width="10%">
                                                        Zone
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlzone" runat="server" Width="215px" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged"
                                                            AutoPostBack="true" data-placeholder="Select Zone" CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                    <td width="10%">
                                                        Center
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcenter" runat="server" Width="215px" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged"
                                                            AutoPostBack="true" data-placeholder="Select Center" CssClass="chzn-select">
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
                                                        Acad Year
                                                        <asp:Label ID="label13" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlacadyearsearch" Width="215px" runat="server" OnSelectedIndexChanged="ddlacadyearsearch_SelectedIndexChanged"
                                                            AutoPostBack="true" data-placeholder="Select Acad Year" CssClass="chzn-select"
                                                            ValidationGroup="Grplead2">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlacadyearsearch"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Acad Year"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Product Category
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlproductcategory" Width="215px" runat="server" AutoPostBack="true"
                                                            data-placeholder="Select Product Category" CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Stream
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstreamsearch" Width="215px" runat="server" AutoPostBack="true"
                                                            data-placeholder="Select Stream" CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <tr>
                                                        <td id="tdadmissionno" runat="server" width="10%">
                                                            Application Form No.
                                                        </td>
                                                        <td id="tdadmissionno1" runat="server" width="20%" colspan="5">
                                                            <asp:TextBox ID="txtadmissionformno" runat="server" Width="205px" placeholder="Search by Admission Form No."></asp:TextBox>
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
                                                        Customer Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcustomertypesearch" runat="server" Width="215px" data-placeholder="Select Customer Type"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Institution Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlinstitutionsearch" runat="server" Width="215px" OnSelectedIndexChanged="ddlinstitutionsearch_SelectedIndexChanged"
                                                            data-placeholder="Select Type" CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Board / University
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlboardsearch" runat="server" Width="215px" data-placeholder="Select Board"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Standard
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstandardsearch" runat="server" Width="215px" data-placeholder="Select Standard"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
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
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Gender
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlgendersearch" runat="server" Width="215px" data-placeholder="Select Gender"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                            <asp:ListItem Value="All">All</asp:ListItem>
                                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
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
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Blocked Status
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:DropDownList ID="ddlblocked" runat="server" Width="215px" data-placeholder="Select Status"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Include Blocked</asp:ListItem>
                                                            <asp:ListItem Value="2">Only Blocked</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                visible="false">
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
                                                        <asp:DropDownList ID="ddlcountrysearch" runat="server" Width="215px" OnSelectedIndexChanged="ddlcountrysearch_SelectedIndexChanged"
                                                            data-placeholder="Select Country" CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        State
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstatesearch" runat="server" Width="215px" OnSelectedIndexChanged="ddlstatesearch_SelectedIndexChanged"
                                                            data-placeholder="Select State" CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        City
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcitysearch" runat="server" Width="215px" OnSelectedIndexChanged="ddlcitysearch_SelectedIndexChanged"
                                                            data-placeholder="Select City" CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Location
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:DropDownList ID="ddllocationsearch" runat="server" Width="215px" data-placeholder="Select Location"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                visible="false">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Sales & Follow-up Information
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Sales Stage
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsalesstage" Width="215px" runat="server" data-placeholder="Select Sales Stage"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Opportunity Created Between
                                                    </td>
                                                    <td width="20%">
                                                        <input readonly="readonly" class="span8 date-picker" id="txtoppcreatedfrm" runat="server"
                                                            type="text" data-date-format="dd M yyyy" />
                                                        <%--<asp:TextBox ID="txtoppcreatedfrm" runat="server" Width="205px"></asp:TextBox>--%>
                                                        <%--<CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtoppcreatedfrm"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtoppcreatedfrm"
                                                            ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                    <td width="10%">
                                                        To
                                                    </td>
                                                    <td width="20%">
                                                        <input readonly="readonly" class="span8 date-picker" id="txtoppcreatedto" runat="server"
                                                            type="text" data-date-format="dd M yyyy" />
                                                        <%-- <asp:TextBox ID="txtoppcreatedto" runat="server" Width="205px"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtoppcreatedto"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtoppcreatedto"
                                                            ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Follow-Up From
                                                    </td>
                                                    <td width="20%">
                                                        <input readonly="readonly" class="span8 date-picker" id="txtfollowupfrm" runat="server"
                                                            type="text" data-date-format="dd M yyyy" />
                                                        <%--<asp:TextBox ID="txtfollowupfrm" runat="server" Width="205px"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtfollowupfrm"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtfollowupfrm"
                                                            ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Follow-Up To
                                                    </td>
                                                    <td width="20%">
                                                        <input readonly="readonly" class="span8 date-picker" id="txtfollowupto" runat="server"
                                                            type="text" data-date-format="dd M yyyy" />
                                                        <%-- <asp:TextBox ID="txtfollowupto" runat="server" Width="205px"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtfollowupto"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtfollowupto"
                                                            ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Overdue Follow-up
                                                    </td>
                                                    <td width="20%">
                                                        <%--<asp:CheckBox ID="chkfollowup" runat="server" />--%>
                                                        <input runat="server" id="chkfollowup" name="switch-field-1" type="checkbox" class="ace-switch ace-switch-2" />
                                                        <span class="lbl"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%" id="td18" runat="server" visible="false">
                                                        Last Follow-Up Over (Days)
                                                    </td>
                                                    <td width="20%" id="td19" runat="server" visible="false">
                                                        <asp:TextBox ID="txtlastfollowoverdays" runat="server" Width="205px" placeholder="Search by Last Follow-up Over (Days)"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Expected date of Joining From
                                                    </td>
                                                    <td width="20%">
                                                        <input readonly="readonly" class="span8 date-picker" id="txtexpecjoindatefrm" runat="server"
                                                            type="text" data-date-format="dd M yyyy" />
                                                        <%-- <asp:TextBox ID="txtexpecjoindatefrm" runat="server" Width="205px"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexpecjoindatefrm"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtexpecjoindatefrm"
                                                            ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Expected date of Joining To
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <input readonly="readonly" class="span4 date-picker" id="txtexpecjoindateto" runat="server"
                                                            type="text" data-date-format="dd M yyyy" />
                                                        <%--<asp:TextBox ID="txtexpecjoindateto" runat="server" Width="205px"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexpecjoindateto"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtexpecjoindateto"
                                                            ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                visible="false">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Last Examination Details
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Board
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlboardsearch2" runat="server" Width="215px" data-placeholder="Select Board"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Standard
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstandardsearch2" runat="server" Width="215px" data-placeholder="Select Standard"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Year
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlyearsearch" runat="server" Width="215px" data-placeholder="Select Year"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Examination Details
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtexamsearch" runat="server" Width="205px" placeholder="Search by Examination Details"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="tr78" runat="server" visible="false">
                                                    <td width="10%">
                                                        Aggregrate Score
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtaggrescore" runat="server" Width="205px" placeholder="Search by Aggregrate Score"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Area Rank
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtxarearank" runat="server" Width="205px" placeholder="Search by Area rank"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Overall Rank
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtoverallrank" runat="server" Width="205px" placeholder="Search by Overall rank"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Score Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlscoretype" runat="server" Width="215px" data-placeholder="Select Type"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Condition
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcondition" runat="server" Width="215px" data-placeholder="Select Condition"
                                                            CssClass="chzn-select" AutoPostBack="true">
                                                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                            <asp:ListItem Value="1"><</asp:ListItem>
                                                            <asp:ListItem Value="2"><=</asp:ListItem>
                                                            <asp:ListItem Value="3">>=</asp:ListItem>
                                                            <asp:ListItem Value="4">></asp:ListItem>
                                                            <asp:ListItem Value="5">=</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Score
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtscore" runat="server" Width="205px" placeholder="Search by Score"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="tr15" runat="server" visible="false">
                                                    <td width="10%">
                                                        Status
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstatus" runat="server" Width="215px" AutoPostBack="true"
                                                            data-placeholder="Select Status" CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" runat="server"
                                                    onserverclick="btnsearch_ServerClick" validationgroup="Grplead2">
                                                    Search
                                                </button>
                                                <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowMessageBox="True"
                                                    ValidationGroup="Grplead2" ShowSummary="False" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid" id="divsearchresults" runat="server">
                                    <div class="span12">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                            <div class="widget-header widget-hea1der-small header-color-dark">
                                                <h4 class="smaller">
                                                    <i class="icon-briefcase"></i>Opportunity Search Results</h4>
                                                <div class="widget-toolbar">
                                                    <div class="btn-group">
                                                        <a class="btn btn-danger btn-mini radius-4" href="Opportunity_Add.aspx" runat="server"
                                                            visible="false">Add Opportunity <i class="icon-plus-sign"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="widget-body">
                                                <div class="table-toolbar">
                                                    <div class="btn-group">
                                                        <a id="btnadd2" class="btn green" runat="server" visible="false" onserverclick="btnadd2_ServerClick">
                                                            Add Opportunity <i class="fa fa-plus"></i></a>
                                                    </div>
                                                </div>
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                                                    OnItemDataBound="Repeater1_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered table-hover Table1">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                    </th>
                                                                    <th>
                                                                        Created On
                                                                    </th>
                                                                    <th>
                                                                        Center
                                                                    </th>
                                                                    <th>
                                                                        Name
                                                                    </th>
                                                                    <th>
                                                                        Age
                                                                    </th>
                                                                    <th>
                                                                        Product
                                                                    </th>
                                                                    <th>
                                                                        Sales Stage
                                                                    </th>
                                                                    <th>
                                                                        App. Form No.
                                                                    </th>
                                                                    <th>
                                                                        Open Days
                                                                    </th>
                                                                    <th>
                                                                        Next Follow-Up
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
                                                                <asp:LinkButton ID="lnkoppednrol" runat="server" class="btn default btn-xs green"
                                                                    Enabled="false" data-trigger="hover" data-placement="top" data-content="Enrolled"><i class="fa fa-bookmark-o "></i> E</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "Created_On")%>'
                                                                    runat="server"></asp:Label>
                                                            <td>
                                                                <asp:Label ID="lblPPgroup" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' runat="server"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="Label10" Text='<%#DataBinder.Eval(Container.DataItem, "Age")%>' runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Oppor_product")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "Sales_Stage_Desc")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" Text='<%#DataBinder.Eval(Container.DataItem, "app_no")%>'
                                                                    runat="server"></asp:Label>
                                                            <td align="right">
                                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "NextFollowup")%>'
                                                                    runat="server"></asp:Label><b><asp:Label ID="label8" runat="server" Text="   (!)"
                                                                        ForeColor="#FF3300"></asp:Label></b>
                                                            </td>
                                                            <td>
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Display.aspx?&Opportunity_Code={0}") %>'
                                                                    id="btndisplay" runat="server" target="_blank" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                    data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                <asp:LinkButton ID="lnkdisplay" runat="server" CommandName="Display" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    Visible="false"></asp:LinkButton>
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Edit.aspx?&Opportunity_Code={0}") %>'
                                                                    id="btndedit" runat="server" target="_blank" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Edit"></a>
                                                                <asp:LinkButton ID="lnkedit" runat="server" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    Visible="false"></asp:LinkButton>
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Followup.aspx?&Opportunity_Code={0}") %>'
                                                                    id="btnfollowup" runat="server" target="_blank" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Follow-up"></a>
                                                                <asp:LinkButton ID="lnkfollowup" runat="server" CommandName="Followup" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    Visible="false"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkconvertmt" runat="server" class="btn btn-minier btn-success icon-check tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Convert" CommandName="Convert_MT"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    ToolTip="Convert"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkformsubmit" runat="server" class="btn btn-minier btn-success icon-download tooltip-success"
                                                                    data-rel="tooltip" data-placement="top" title="Enroll" CommandName='<%#DataBinder.Eval(Container.DataItem,"Enrollcommandname")%>'
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    ToolTip="Enroll"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkblock" runat="server" class="btn btn-minier btn-danger icon-ban-circle tooltip-Danger"
                                                                    data-rel="tooltip" data-placement="top" title="Block" CommandName="Block" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    ToolTip="Block"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkunblock" runat="server" class="btn btn-minier btn-primary icon-unlock tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Unblock" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    ToolTip="Unblock"></asp:LinkButton>
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Enrollment_Display.aspx?&Opportunity_Code={0}") %>'
                                                                    id="btndisplayenroll" runat="server" target="_blank" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                    data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                <asp:LinkButton ID="lnldisplayenrol" runat="server" Visible="false" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                    CommandName="Displayenrol" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    data-rel="tooltip" data-placement="top" title="Display"></asp:LinkButton>
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Enrollment_Edit.aspx?&Opportunity_Code={0}") %>'
                                                                    id="btneditenroll" runat="server" target="_blank" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Edit"></a>
                                                                <asp:LinkButton ID="lnkeditenroll" runat="server" Visible="true" CommandName="Editenrol"
                                                                    class="btn btn-minier btn-primary icon-edit tooltip-info" data-rel="tooltip"
                                                                    data-placement="top" title="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkfollowupenroll" runat="server" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Follow-up" CommandName="FollowupEnroll"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkconvert" runat="server" CommandName="Convert" class="btn btn-minier btn-success icon-check tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Convert" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                    Visible="false"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkblockenroll" runat="server" class="btn btn-minier btn-danger icon-ban-circle tooltip-Danger"
                                                                    data-rel="tooltip" data-placement="top" title="Block" CommandName="BlockEnroll"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'></asp:LinkButton>
                                                                <asp:Label ID="lblisactive" Text='<%#DataBinder.Eval(Container.DataItem, "isactive")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="Label12" Text='<%#DataBinder.Eval(Container.DataItem, "Opp_Contact_Target_Company")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Manage_Order.aspx?&Opportunity_Code={0}") %>'
                                                                    id="btnorder" runat="server" target="_blank" class="btn btn-minier btn-purple icon-asterisk tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Order"></a>
                                                            </td>
                                                            <td id="Td15" width="2%" runat="server" visible="false">
                                                                <asp:Label ID="lblOppor_id" Text='<%#DataBinder.Eval(Container.DataItem, "Opportunity_Code")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody> </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <asp:Label ID="lbloppurid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lbloppid1" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <!-- END EXAMPLE TABLE PORTLET-->
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--end tabbable-->
                    </div>
                    <div class="modal fade" id="Blocklead" tabindex="-1" role="basic" aria-hidden="true"
                        data-keyboard="false" data-backdrop="static" data-keyboard="false" data-attention-animation="false">
                        <div class="modal-dialog modal-small blue">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <div class="scroller" data-always-visible="1" data-rail-visible1="1">
                                        <p>
                                            <b>
                                                <asp:Label ID="lblnote" runat="server" ForeColor="#FF3300"></asp:Label></b>
                                        </p>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btncloseleadblock"
                                        onserverclick="btncloseleadblock_ServerClick" runat="server">
                                        No</button>
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnblocklead"
                                        onserverclick="btnblocklead_ServerClick" runat="server">
                                        Yes</button>
                                    <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Val8" ShowSummary="False" />
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <div class="modal fade" id="UnBlocklead" tabindex="-1" role="basic" aria-hidden="true"
                        data-keyboard="false" data-backdrop="static" data-keyboard="false" data-attention-animation="false">
                        <div class="modal-dialog modal-small blue">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <div class="scroller" data-always-visible="1" data-rail-visible1="1">
                                        <p>
                                            <b>
                                                <asp:Label ID="lblnote1" runat="server" ForeColor="#FF3300"></asp:Label></b>
                                        </p>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnunblockno"
                                        runat="server" onserverclick="btnunblockno_ServerClick">
                                        No</button>
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnunblockyes"
                                        runat="server" onserverclick="btnunblockyes_ServerClick">
                                        Yes</button>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Val8" ShowSummary="False" />
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <div class="modal fade" id="Div1" tabindex="-1" role="basic" aria-hidden="true" data-keyboard="false"
                        data-backdrop="static" data-keyboard="false" data-attention-animation="false">
                        <div class="modal-dialog modal-small blue">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <div class="scroller" data-always-visible="1" data-rail-visible1="1">
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <tr>
                                                <td width="10%">
                                                    Submission Date
                                                    <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtappsubmitdate" runat="server" Width="79%" ValidationGroup="val1"></asp:TextBox>
                                                    <CC1:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd-MM-yyyy" TargetControlID="txtappsubmitdate"
                                                        DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy"
                                                        CssClass="ajax__calendar_container">
                                                    </CC1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator79" ControlToValidate="txtappsubmitdate"
                                                        Text="#" runat="server" ValidationGroup="Val20" SetFocusOnError="True" ErrorMessage="Enter Application Submit Date" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtappsubmitdate"
                                                        ValidationGroup="val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                        ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                    <asp:Label ID="lbldateerrorsubmit" runat="server" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnyes"
                                        validationgroup="Val20" runat="server" onserverclick="btnyes_ServerClick">
                                        Yes</button>
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnno"
                                        runat="server" onserverclick="btnno_ServerClick">
                                        No</button>
                                    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Val20" ShowSummary="False" />
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID ="Exporttoexcel" />--%>
                    <asp:PostBackTrigger ControlID="btnadd2" />
                    <%-- <asp:PostBackTrigger ControlID="btnsearchoppor" />--%>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                    <asp:PostBackTrigger ControlID="btnunblockno" />
                    <asp:PostBackTrigger ControlID="btnunblockyes" />
                    <asp:PostBackTrigger ControlID="btncloseleadblock" />
                    <asp:PostBackTrigger ControlID="btnno" />
                    <asp:PostBackTrigger ControlID="btnyes" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
            <!-- BEGIN PAGE CONTENT FOR CONVERT TO ACCOUNT-->
            <%--<asp:UpdatePanel id="upnlconvert" runat ="server">
                <ContentTemplate>--%>
            <div id="upnlconvert" runat="server">
                <div class="row-fluid" id="div2" runat="server">
                    <div class="span12">
                        <div id="Div3" class="row-fluid">
                            <div class="row-fluid" id="div4" runat="server">
                                <div class="span12">
                                    <div class="table-responsive">
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <tr>
                                                <td width="10%">
                                                    App. No.
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtConapp" runat="server" Enabled="false" Width="88%"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    App. Entry Date
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtconAppentrydate" runat="server" Enabled="false" Width="88%"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    App. Submit Date
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtconappsubdate" runat="server" Enabled="false" Width="88%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Customer Name
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtconstdname" runat="server" Enabled="false" Width="88%"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    Nationality
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlnationality" Enabled="false" Placeholder="Nationality" runat="server"
                                                        ValidationGroup="val1" data-placeholder="Select Nationality" CssClass="chzn-select"
                                                        data-trigger="hover" data-placement="top" data-content="Enter Student Nationality"
                                                        data-original-title="Student Nationality">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Mother Tongue
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlmothertongue" Enabled="false" Placeholder="Mother Tongue"
                                                        runat="server" ValidationGroup="val1" data-placeholder="Select Mother Tongue"
                                                        CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Enter Student Mother tongue"
                                                        data-original-title="Student Mother Tongue">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Religion
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlreligion" Enabled="false" Placeholder="Student Religion"
                                                        runat="server" AutoPostBack="true" ValidationGroup="val1" data-placeholder="Select Religion"
                                                        CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Select Student Religion"
                                                        data-original-title="Student Religion">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Caste
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcaste" Enabled="false" runat="server" Placeholder="Student Caste"
                                                        ValidationGroup="val1" data-placeholder="Select Caste" CssClass="chzn-select"
                                                        data-trigger="hover" data-placement="top" data-content="Enter Student Caste"
                                                        data-original-title="Student Caste">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Sub Caste
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtconsubcaste" Enabled="false" runat="server" Width="88%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Category
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlgroup" Enabled="false" runat="server" ValidationGroup="val1"
                                                        data-placeholder="Select Category" CssClass="chzn-select" data-trigger="hover"
                                                        data-placement="top" data-content="Select Category" data-original-title="Select Category">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Student From
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlstudentfrom" Enabled="false" runat="server" ValidationGroup="val1"
                                                        data-placeholder="Select Student From" CssClass="chzn-select" data-trigger="hover"
                                                        data-placement="top" data-content="Select student from" data-original-title="Student From">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Physically
                                                    <br />
                                                    Challenged
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlphysicalchallenged" Enabled="false" runat="server" ValidationGroup="val1"
                                                        data-placeholder="Select Type" CssClass="chzn-select" data-trigger="hover" data-placement="top"
                                                        data-content="Select whether student is physicaly challenged" data-original-title="Physically Challenged">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="tr67" runat="server" visible="false">
                                                <td width="10%">
                                                    Stay Preference
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlstay" runat="server" Enabled="false" ValidationGroup="Val4"
                                                        data-placeholder="Select Preference" CssClass="chzn-select" data-trigger="hover"
                                                        data-placement="top" data-content="Select Student Current Stay" data-original-title="Stay">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Passing Year
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlconyearofpassing" Enabled="false" runat="server" ValidationGroup="Grplead1"
                                                        data-placeholder="Select Passing Year" CssClass="chzn-select" data-trigger="hover"
                                                        data-placement="top" data-content="Select Year of Passing" data-original-title="Year of Passing">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Company
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlconCompany" Enabled="false" runat="server" AutoPostBack="true"
                                                        ValidationGroup="val2" data-placeholder="Select Company" CssClass="chzn-select"
                                                        data-trigger="hover" data-placement="top" data-content="Select Company" data-original-title="Company">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Division
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcondivision" Enabled="false" runat="server" AutoPostBack="true"
                                                        ValidationGroup="val2" data-placeholder="Select Division" CssClass="chzn-select"
                                                        data-trigger="hover" data-placement="top" data-content="Select Division" data-original-title="Division">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Center
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlconcenter" Enabled="false" runat="server" AutoPostBack="true"
                                                        ValidationGroup="val2" data-placeholder="Select Center" CssClass="chzn-select"
                                                        data-trigger="hover" data-placement="top" data-content="Select Center" data-original-title="Center">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Academic Year
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlconacademicyear" Enabled="false" runat="server" AutoPostBack="true"
                                                        ValidationGroup="val2" data-placeholder="Select Academic Year" CssClass="chzn-select"
                                                        data-trigger="hover" data-placement="top" data-content="Select Academic Year"
                                                        data-original-title="Academic Year">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Product
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlconstream" Enabled="false" runat="server" AutoPostBack="true"
                                                        ValidationGroup="val2" data-placeholder="Select Product" CssClass="chzn-select"
                                                        data-trigger="hover" data-placement="top" data-content="Select Stream" data-original-title="Stream">
                                                    </asp:DropDownList>
                                                </td>
                                                <td id="Td1" width="10%" runat="server" visible="false">
                                                    Transportation
                                                    <asp:Label ID="label18" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                                <td id="Td2" width="20%" runat="server" visible="false">
                                                    <asp:DropDownList ID="ddltransport" runat="server" AutoPostBack="true" ValidationGroup="val2"
                                                        data-placeholder="Select Transportation" CssClass="chzn-select" data-trigger="hover"
                                                        data-placement="top" data-content="Select Transportation required" OnSelectedIndexChanged="ddltransport_SelectedIndexChanged">
                                                        <asp:ListItem Value="00" Selected="True">Select</asp:ListItem>
                                                        <asp:ListItem Value="02">Yes</asp:ListItem>
                                                        <asp:ListItem Value="01">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ControlToValidate="ddltransport"
                                                        Text="#" runat="server" ValidationGroup="val2" SetFocusOnError="True" ErrorMessage="Select Transportation"
                                                        InitialValue="Select" />
                                                </td>
                                                <td width="10%">
                                                    Medium of Instruction
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlConmediumofinstr" Enabled="false" runat="server" ValidationGroup="Val4"
                                                        data-placeholder="Select Medium" CssClass="chzn-select" data-trigger="hover"
                                                        data-placement="top" data-content="Select Medium of Instruction" data-original-title="Medium of Instruction">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <!-- static -->
                                <div class="span12" id="divfeedetails" runat="server">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                    <div class="portlet box green">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-bitcoin"></i>Fee Details - Summarised
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="height: 400px; overflow: Auto">
                                            <div class="table-responsive">
                                                <asp:DataList ID="dlppheader" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                    Height="20px">
                                                    <HeaderTemplate>
                                                        <b>Header (Fees Group)</b></th>
                                                        <th align="center">
                                                            Total Amount
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Pricing_Procedure_name")%>'
                                                            runat="server"></asp:Label></td>
                                                        <td align="right">
                                                            <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amount")%>'
                                                                runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <div id="divcreatebutton" class="well" style="text-align: center; background-color: #F0F0F0"
                                                    runat="server">
                                                    <button class="btn btn-app btn-success btn-mini radius-4" id="btncreateaccount" runat="server"
                                                        validationgroup="Val6" onserverclick="btncreateaccount_ServerClick">
                                                        Create
                                                    </button>
                                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                        ValidationGroup="Val6" ShowSummary="False" />
                                                </div>
                                                <div id="divbtnexit" class="well" style="text-align: center; background-color: #F0F0F0"
                                                    runat="server">
                                                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclose" runat="server"
                                                        onserverclick="btnclose_ServerClick">
                                                        Close
                                                    </button>
                                                </div>
                                                <asp:Label ID="lbloppid" runat="server" Visible="False"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid" id="div5" runat="server">
                                <div class="col-md-3">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                    <div class="portlet box red">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-globe"></i>Compulsory Fee Items
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="height: 1500px; overflow: Auto">
                                            <asp:DataList ID="dlproductHeader" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                Height="30">
                                                <HeaderTemplate>
                                                    <b>Description</b></th>
                                                    <th>
                                                        UOM
                                                    </th>
                                                    <th>
                                                        Quantity
                                                    </th>
                                                    <th>
                                                        Amount
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_description")%>'
                                                        runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lbluom" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblqty" Text="01" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amt")%>'
                                                            runat="server"></asp:Label>
                                                    </td>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="upnl1" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-9">
                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <i class="fa fa-anchor"></i>Product / Item Group Selection
                                                    </div>
                                                </div>
                                                <div class="portlet-body" style="height: 1500px; overflow: Auto">
                                                    <div class="table-responsive">
                                                        <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                            <tr>
                                                                <td width="10%">
                                                                    Pay Plan
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlpayplan" runat="server" Width="88%" AutoPostBack="True"
                                                                        ValidationGroup="Val5">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="ddlpayplan"
                                                                        Text="*" runat="server" ValidationGroup="Val5" SetFocusOnError="True" ErrorMessage="Select Pay Plan"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                            </tr>
                                                            <tr id="tr19" runat="server" visible="false">
                                                                <td width="10%">
                                                                    Opt. Product
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddllanguage" runat="server" Width="88%" AutoPostBack="True"
                                                                        ValidationGroup="Val5">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ControlToValidate="ddllanguage"
                                                                        Text="*" runat="server" ValidationGroup="Val5" SetFocusOnError="True" ErrorMessage="Select Optional Subject"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtLangvalue" runat="server" Width="88%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                                <td width="10%">
                                                                    Comp. Subject
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtmandateSubjects" runat="server" Width="88%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                </td>
                                                                <td id="td3" runat="server" visible="false">
                                                                    <asp:Label ID="lblmaterialcode" runat="server" Visible="false"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtvalue" runat="server" Width="88%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:DataList ID="dlselective" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                            Height="20px" OnItemDataBound="dlselective_ItemDataBound">
                                                            <HeaderTemplate>
                                                                <b></b></th>
                                                                <th width="35%">
                                                                    Item
                                                                </th>
                                                                <th width="10%">
                                                                    Price
                                                                </th>
                                                                <th width="10%">
                                                                    Base UOM
                                                                </th>
                                                                <th width="25%">
                                                                    Unit
                                                                </th>
                                                                <th width="7%">
                                                                    Quantity
                                                                </th>
                                                                <th width="7%">
                                                                    Amount
                                                                </th>
                                                                <th width="25%">
                                                                    Remarks
                                                                </th>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ckhselect1" runat="server" AutoPostBack="true" />
                                                                <td width="35%">
                                                                    <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "SGR_DESC")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td width="10%">
                                                                    <asp:TextBox ID="txtvoucheramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amount")%>'
                                                                        Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td width="10%">
                                                                    <asp:Label ID="lblbaseuom" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Uom_Base_Name")%>'></asp:Label>
                                                                    <asp:Label ID="lblbaseuomid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Uom")%>'
                                                                        Visible="false"></asp:Label>
                                                                </td>
                                                                <td width="25%">
                                                                    <asp:DropDownList ID="ddluom" runat="server" AutoPostBack="true" Enabled="false"
                                                                        Width="90%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="7%">
                                                                    <asp:TextBox ID="txtquantity" runat="server" AutoPostBack="true" Width="100%" Enabled="false"
                                                                        Text='<%#DataBinder.Eval(Container.DataItem, "Uom_Value")%>'></asp:TextBox>
                                                                </td>
                                                                <td width="7%">
                                                                    <asp:TextBox ID="txttotalvalue" runat="server" Enabled="false" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td width="25%">
                                                                    <asp:TextBox ID="txtremark" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                </td>
                                                                <asp:Label ID="lblmaterialcodeadd" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"SGR_Material")%>'></asp:Label>
                                                                <asp:Label ID="lblvoucher_mode" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Mode")%>'></asp:Label>
                                                                <asp:Label ID="lblvoucher_typ" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Typ")%>'></asp:Label>
                                                                <asp:Label ID="lblselgroup" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"sgr_sel_group")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                    <div class="alert alert-danger" id="diverrorsubject" runat="server">
                                                        <strong>
                                                            <asp:Label ID="lblerrorsub" runat="server"></asp:Label></strong>
                                                    </div>
                                                    <div class="alert alert-success" id="divSuccessrsubject" runat="server">
                                                        <strong>
                                                            <asp:Label ID="lblsuccesssub" runat="server"></asp:Label></strong>
                                                    </div>
                                                    <div id="Div6" class="well" style="text-align: center; background-color: #F0F0F0"
                                                        runat="server">
                                                        <button class="btn btn-app btn-primary btn-mini radius-4" id="btncontinue" runat="server"
                                                            validationgroup="Val5" onserverclick="btncontinue_ServerClick">
                                                            Continue
                                                        </button>
                                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                            ValidationGroup="Val5" ShowSummary="False" />
                                                    </div>
                                                    <div id="Divreselect" class="well" style="text-align: center; background-color: #F0F0F0"
                                                        runat="server">
                                                        <button class="btn btn-app btn-primary btn-mini radius-4" id="btnreselect" runat="server"
                                                            onserverclick="btnreselect_ServerClick">
                                                            Reset
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btncontinue" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </div>
            </div>
            <asp:UpdatePanel ID="upnlconvertMT" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="div7" runat="server">
                        <div class="span12">
                            <div id="Div8" class="row-fluid">
                                <div class="row-fluid" id="div9" runat="server">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <tr>
                                                    <td width="10%">
                                                        Product Category
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtproductcategory1" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Sales Stage
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsalesstage1" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Student Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtstudenttype" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Contact Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtcontactname1" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Handphone #1
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txthandphone11" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Landline
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtlandline1" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Join Date
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtjoindate1" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Expected date
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtexpectedate1" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Probability Percent
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtprobpercent1" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <tr>
                                                    <td width="10%">
                                                        Sbentrycode
                                                        <asp:Label ID="label38" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsbentrycode" runat="server" Width="88%" ValidationGroup="Grplead"
                                                            MaxLength="16" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" ControlToValidate="txtsbentrycode"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter SBEntryCode " />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtsbentrycode"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Account Date
                                                        <asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtaccountdate" runat="server" Width="90%" ValidationGroup="Grplead"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtaccountdate"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <span class="add-on"><i class="icon-calendar"></i></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator50" ControlToValidate="txtaccountdate"
                                                            Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter System Admission Date" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtaccountdate"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                    </td>
                                                    <td width="20%">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Notes
                                                        <asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtnotes" runat="server" Width="98%" MaxLength="200" ValidationGroup="Grplead"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator51" ControlToValidate="txtnotes"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Notes" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0" id="divfeedbackbuttonsCon"
                                                runat="server">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnconvertmt" runat="server"
                                                    validationgroup="Grplead" onserverclick="btnconvertmt_ServerClick">
                                                    Convert
                                                </button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclearmt" runat="server"
                                                    onserverclick="btnclearmt_ServerClick">
                                                    Cancel
                                                </button>
                                                <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                                    ValidationGroup="Grplead" ShowSummary="False" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnconvertmt" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR CONVERT TO ACCOUNT FOR MT-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
