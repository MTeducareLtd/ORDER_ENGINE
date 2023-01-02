<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ContactCenter_Opportunity_Edit.aspx.cs" Inherits="ContactCenter_Opportunity_Edit" %>

<%@ Register TagPrefix="ContactInfoPanel" TagName="ContactInfoPanel" Src="~/UserControl/uc_Contact_Information.ascx" %>
<%@ Register TagPrefix="HistoryPanel" TagName="HistoryPanel" Src="~/UserControl/uc_Contact_FollowUp_History.ascx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
    <style type="text/css">
        .uppercase
        {
            text-transform: uppercase;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE HEADER-->
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="ContactCenter_Opportunity.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a> <span class="divider">
                    <i class="icon-angle-right"></i></span></li>
            <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
            </i><a href="#">
                <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a> </li>
            <li>
                <h4 class="blue">
                    <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname"
                        runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
                            <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                    <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                    <span class="divider"></span>
                </h4>
            </li>
        </ul>
        <%--<div id="nav-search">
                <!-- /btn-group -->
                <button type="button" class="btn btn-app btn-primary btn-mini radius-4 dropdown-toggle"
                    data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                    <span>Actions </span><i class="fa fa-angle-down"></i>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li><a href="#" id="btnsearchoppor" runat="server" onserverclick="btnsearchoppor_ServerClick">
                        Search Opportunity</a> </li>
                    <li><a href="#" id="btnaddOpp" runat="server">Add Opportunity</a> </li>
                </ul>
            </div>--%>
        <!--#nav-search-->
        <!--#nav-search-->
        <div id="nav-search">
            <button data-toggle="dropdown" class="btn btn-danger btn-small dropdown-toggle" runat="server"
                visible="false">
                Action <span class="caret"></span>
            </button>
            <ul class="dropdown-menu dropdown-yellow pull-right dropdown-caret dropdown-close">
                <li><a href="#" id="btnsearchoppor" runat="server" onserverclick="btnsearchoppor_ServerClick">
                    Search Opportunity</a> </li>
                <li><a href="#" id="btnaddOpp" runat="server">Add New Opportunity</a></li>
                <li><a href="#" id="btnviewenrollment" runat="server" visible="false">View Enrollment</a></li>
            </ul>
        </div>
    </div>
    <!-- BEGIN PAGE CONTENT-->
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
            <!-- BEGIN PAGE CONTENT FOR Edit Opportunity-->
            <asp:UpdatePanel ID="UpnlAdd" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="div1" runat="server">
                        <div class="span12">
                            <div id="Divadd" class="row-fluid">
                                <div class="row-fluid" id="divadd" runat="server">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            
                                            <div class="row-fluid">
                                                <ContactInfoPanel:ContactInfoPanel runat="server" ID="ContactInfoPanel1"></ContactInfoPanel:ContactInfoPanel>
                                            </div>

                                            <div class="row-fluid" runat="server" visible="false">
                                                <div class="span12">
                                                    <div class="widget-box">
                                                        <div class="widget-header">
                                                            <h5>
                                                                Primary Contact
                                                            </h5>
                                                            <asp:Label ID="lblConId" runat="server" Visible="false"></asp:Label>
                                                            <%--<button id="btnEditCon" runat="server" data-rel="tooltip" data-placement="left" visible="true"
                                                                title="Edit  Contact" class="btn btn-app btn-primary btn-mini radius-4" onserverclick="btnEditCon_Click">
                                                                <i class="icon-edit"></i>
                                                            </button>
                                                            <button id="btnRefreshCon" runat="server" data-rel="tooltip" data-placement="left"
                                                                visible="true" title="Refresh  Contact" class="btn btn-app btn-primary btn-mini radius-4"
                                                                onserverclick="btnRefreshCon_Click">
                                                                <i class="icon-refresh"></i>
                                                            </button>--%>
                                                            <div class="btn-group" id="divEditContact" runat="server">
                                                                <a id="aedit" runat="server" target="_blank" class="btn btn-small btn-primary tooltip-info"
                                                                    title="Edit Contact"><i class="icon-edit"></i></a>
                                                            </div>
                                                            <div class="btn-group" id="divRefreshContact" runat="server">
                                                                <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnRefreshCon"
                                                                    runat="server" onserverclick="btnrefersh_ServerClick" data-rel="tooltip" data-placement="top"
                                                                    title="Refresh Contact">
                                                                    <i class="icon-refresh"></i>
                                                                </button>
                                                            </div>
                                                            &nbsp;&nbsp;
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main">
                                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Contact Source
                                                                            <asp:Label ID="label21" runat="server" Enabled="false" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlContactsourceadd" runat="server" CssClass="chzn-select"
                                                                                Enabled="false" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top"
                                                                                data-content="Select Contact Source">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddlContactsourceadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Source"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Contact Type
                                                                            <asp:Label ID="Label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlContactType" runat="server" Width="215px" Enabled="false"
                                                                                CssClass="chzn-select" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top"
                                                                                data-content="Select Contact Type">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlContactType"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Customer Type
                                                                            <asp:Label ID="Label1re7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlstudenttypeadd" runat="server" data-placeholder="Select Type"
                                                                                Enabled="false" Width="215px" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead2"
                                                                                OnSelectedIndexChanged="ddlstudenttypeadd_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValifgdgdator4" ControlToValidate="ddlstudenttypeadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Customer Type"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Title
                                                                            <asp:Label ID="Label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlTitle" runat="server" Width="215px" CssClass="chzn-select"
                                                                                Enabled="false" ValidationGroup="Grplead2">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                                                <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlTitle"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title"
                                                                                InitialValue="0" />
                                                                        </td>
                                                                        <td colspan="4">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            First Name
                                                                            <asp:Label ID="label12" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtFirstName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                                Enabled="false" placeholder="First Name"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtFirstName"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator121" runat="server"
                                                                                ControlToValidate="txtFirstName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Middle Name
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtMidName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                                Enabled="false" placeholder="Middle Name"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMidName"
                                                                                ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                                ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Last Name
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtLastName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                                Enabled="false" placeholder="Last Name"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtLastName"
                                                                                ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                                ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Gender
                                                                            <asp:Label ID="label18" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlGender" runat="server" Width="215px" CssClass="chzn-select"
                                                                                Enabled="false" ValidationGroup="Grplead2">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Male</asp:ListItem>
                                                                                <asp:ListItem Value="2">Female</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="ddlGender"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                                                InitialValue="0" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            DOB
                                                                            <asp:Label ID="label19" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtdateofbirth" Width="205px" Placeholder="Date of Birth" runat="server"
                                                                                Enabled="false" ValidationGroup="Grplead2"></asp:TextBox>
                                                                            <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdateofbirth"
                                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                            </CC1:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtdateofbirth"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Date Of Birth" />
                                                                            <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="txtdateofbirth"
                                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                            <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionVaxcdlidator3" runat="server"
                                                                                ControlToValidate="txtdateofbirth" ValidationGroup="Grplead2" Text="#" SetFocusOnError="True"
                                                                                ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Handphone 1
                                                                            <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtHandPhone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                                                Enabled="false" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ControlToValidate="txtHandPhone1"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone 1" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatordsw2" ControlToValidate="txtHandPhone1"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValiregtet4dator1" runat="server"
                                                                                ControlToValidate="txtHandPhone1" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Handphone 2
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtHandphone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                                                Enabled="false" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtHandphone2"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpresfddefr3ssionValidator3" runat="server"
                                                                                ControlToValidate="txtHandphone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Landline No.
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtlandline" runat="server" Width="205px" placeholder="Landline No."
                                                                                Enabled="false" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtlandline"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtlandline"
                                                                                ErrorMessage="Handphone length must be between 7 to 18 characters" ValidationGroup="Grplead2"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Address 1
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtaddress1" runat="server" Width="205px" placeholder="Address Line 1"
                                                                                Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Address 2
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtaddress2" runat="server" Width="205px" placeholder="Address Line 2"
                                                                                Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Street Name
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtStreetname" runat="server" Width="205px" placeholder="Street Name"
                                                                                Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <tr>
                                                                            <td width="10%">
                                                                                Country
                                                                                <asp:Label ID="label23" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            </td>
                                                                            <td width="20%">
                                                                                <asp:DropDownList ID="ddlCountry" runat="server" Width="215px" CssClass="chzn-select"
                                                                                    Enabled="false" AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator133" ControlToValidate="ddlCountry"
                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Country"
                                                                                    InitialValue="Select" />
                                                                            </td>
                                                                            <td width="10%">
                                                                                State
                                                                            </td>
                                                                            <td width="20%">
                                                                                <asp:DropDownList ID="ddlstate" runat="server" Width="215px" CssClass="chzn-select"
                                                                                    Enabled="false" AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td width="10%">
                                                                                City
                                                                            </td>
                                                                            <td width="20%">
                                                                                <asp:DropDownList ID="ddlcity" runat="server" Width="215px" CssClass="chzn-select"
                                                                                    Enabled="false" ValidationGroup="Grplead2">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="10%">
                                                                                Location
                                                                            </td>
                                                                            <td width="20%">
                                                                                <asp:DropDownList ID="ddllocation" runat="server" Width="215px" CssClass="chzn-select"
                                                                                    ValidationGroup="Grplead2" Enabled="false">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td width="10%">
                                                                                Postal Code
                                                                            </td>
                                                                            <td width="20%">
                                                                                <asp:TextBox ID="txtpincode" runat="server" placeholder="Postal Code" MaxLength="6"
                                                                                    Enabled="false" ValidationGroup="Grplead2" Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3243" ControlToValidate="txtpincode"
                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtpincode"
                                                                                    runat="server" ErrorMessage="Pincode length must be of 6 Character" ValidationGroup="Grplead2"
                                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{6,6}$" />
                                                                            </td>
                                                                            <td width="10%">
                                                                                Email id
                                                                            </td>
                                                                            <td width="20%">
                                                                                <asp:TextBox ID="txtemailid" runat="server" Width="205px" placeholder="Email Id"
                                                                                    Enabled="false" ValidationGroup="Grplead2"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValasdwidator5" runat="server"
                                                                                    ControlToValidate="txtemailid" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                    ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                            <%--<td colspan="2">
                                                                            </td>--%>
                                                                        </tr>
                                                                </table>
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
                                                                Contact Academic Information
                                                            </h5>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main">
                                                                <div class="row-fluid">
                                                                    <asp:DataList ID="dlAcadInfo" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                                        <HeaderTemplate>
                                                                            <b class="center" style="text-align: left">Institution Type</b></th>
                                                                            <th style="text-align: center">
                                                                                Institution Name
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Board
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Standard
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Division
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Year Of Passing
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Additional Desc
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Examination Name
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Final Marks Obtained
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Final Marks Total
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Grade
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Percentage
                                                                            </th>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRowNumber" Text='<%#DataBinder.Eval(Container.DataItem, "Record_No")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblInstitutionTypeCode" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Type_Id")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblInstitutionType" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Type_Desc")%>'
                                                                                runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblInstitutionName" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Description")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblBoardId" Text='<%#DataBinder.Eval(Container.DataItem, "Board_Id")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblBoardName" Text='<%#DataBinder.Eval(Container.DataItem, "Board_Desc")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblStandardCode" Text='<%#DataBinder.Eval(Container.DataItem, "Current_Standard_Id")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblStandardName" Text='<%#DataBinder.Eval(Container.DataItem, "Current_Standard_Desc")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblDivisionCode" Text='<%#DataBinder.Eval(Container.DataItem, "Section_Id")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblDivisionName" Text='<%#DataBinder.Eval(Container.DataItem, "Section_Desc")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPassingYearCode" Text='<%#DataBinder.Eval(Container.DataItem, "Year_of_Passing_ID")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblPassingYearName" Text='<%#DataBinder.Eval(Container.DataItem, "Year_of_Passing_Desc")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblAditionalDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Additional_Desc")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblExamName" Text='<%#DataBinder.Eval(Container.DataItem, "ExamName")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblFinalMarkObt" Text='<%#DataBinder.Eval(Container.DataItem, "FinalMarksObtained")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblFinalMarkTotal" Text='<%#DataBinder.Eval(Container.DataItem, "FinalMarksTotal")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblGrade" Text='<%#DataBinder.Eval(Container.DataItem, "Grade")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPercentage" Text='<%#DataBinder.Eval(Container.DataItem, "Percentage")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                    <asp:Label ID="lblAcadInfoRecord" CssClass="red" Visible="False" runat="server" Font-Bold="True"></asp:Label>
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
                                                                Secondary Contact Information
                                                            </h5>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main">
                                                                <div class="row-fluid">
                                                                    <asp:DataList ID="dlSec_Con_Info" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                                        <HeaderTemplate>
                                                                            <b class="center" style="text-align: left">Contact Type</b></th>
                                                                            <th style="text-align: center">
                                                                                Name
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Handphone1
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Handphone2
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                LandLineNo
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Gender
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Email Id
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Occupation
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Organization
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Designation
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Office Phone
                                                                            </th>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblContactId" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Id")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblCon_type_id" Text='<%#DataBinder.Eval(Container.DataItem, "Con_type_id")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblCon_Type_desc" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Type_desc")%>'
                                                                                runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblName" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' runat="server"></asp:Label>
                                                                                <asp:Label ID="lblConTitle" Text='<%#DataBinder.Eval(Container.DataItem, "Con_title")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblFName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Firstname")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblMName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_midname")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblLName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_lastname")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblHandphone1" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone1")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblHandphone2" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone2")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblLandline" Text='<%#DataBinder.Eval(Container.DataItem, "Landline")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblGender" Text='<%#DataBinder.Eval(Container.DataItem, "Gender")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblEmailid" Text='<%#DataBinder.Eval(Container.DataItem, "Emailid")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblOccupation" Text='<%#DataBinder.Eval(Container.DataItem, "Occupation")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblOrganization" Text='<%#DataBinder.Eval(Container.DataItem, "Organization")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblDesignation" Text='<%#DataBinder.Eval(Container.DataItem, "Designation")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblOffice_phone" Text='<%#DataBinder.Eval(Container.DataItem, "Office_phone")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                    <asp:Label ID="lblSecConRecord" CssClass="red" Visible="False" runat="server" Font-Bold="True"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget-box">
                                                        <div class="widget-header">
                                                            <h5>
                                                                Organization Assignments
                                                            </h5>
                                                            <asp:Label ID="Label13" runat="server" Visible="false"></asp:Label>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main">
                                                                <table class="table table-striped table-bordered table-advance table-hover" id="tblorgassign"
                                                                    runat="server">
                                                                    <%-- <thead>
                                                                        <tr>
                                                                            <th colspan="6">
                                                                                Organization Assignments
                                                                            </th>
                                                                        </tr>
                                                                    </thead>--%>
                                                                    <tr id="trSourcecompany" runat="server">
                                                                        <td width="10%">
                                                                            Source Company
                                                                            <%--<asp:Label ID="label28" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%" colspan="5">
                                                                            <asp:DropDownList ID="ddlsourcecompanyadd" runat="server" Width="215px" AutoPostBack="true"
                                                                                Enabled="false" CssClass="chzn-select" ValidationGroup="Grplead1" OnSelectedIndexChanged="ddlcompanyadd_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlsourcecompanyadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Source Company"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="tblrow1" runat="server">
                                                                        <td width="10%">
                                                                            Source Division
                                                                            <%--<asp:Label ID="label29" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlSourcedivisionadd" Width="215px" runat="server" OnSelectedIndexChanged="ddlSourcedivisionadd_SelectedIndexChanged"
                                                                                AutoPostBack="true" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead1"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="ddlSourcedivisionadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Source Division"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Source Area / Zone
                                                                            <%--<asp:Label ID="label30" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlSourcezoneadd" Width="215px" runat="server" AutoPostBack="true"
                                                                                OnSelectedIndexChanged="ddlSourcezoneadd_SelectedIndexChanged" data-placeholder="Select"
                                                                                CssClass="chzn-select" ValidationGroup="Grplead1" Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="ddlSourcezoneadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Source Zone"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Source Center
                                                                            <%--<asp:Label ID="label31" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlSourcecenteradd" Width="215px" runat="server" data-placeholder="Select"
                                                                                CssClass="chzn-select" ValidationGroup="Grplead1" Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlSourcecenteradd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Source Center"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trtargetcompany" runat="server">
                                                                        <td width="10%">
                                                                            Target Company
                                                                            <%--<asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%" colspan="5">
                                                                            <asp:DropDownList ID="ddltargetcompanyadd" Width="215px" Enabled="false" runat="server"
                                                                                OnSelectedIndexChanged="ddltargetcompanyadd_SelectedIndexChanged" AutoPostBack="true"
                                                                                data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddltargetcompanyadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Target Company"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Target Division
                                                                            <%--<asp:Label ID="label32" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddltargetdivisionadd" Width="215px" Enabled="false" runat="server"
                                                                                OnSelectedIndexChanged="ddltargetdivisionadd_SelectedIndexChanged" AutoPostBack="true"
                                                                                data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="ddltargetdivisionadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Target Division"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Target Area / Zone
                                                                            <%--<asp:Label ID="label33" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddltargetzoneadd" Width="215px" Enabled="false" runat="server"
                                                                                AutoPostBack="true" OnSelectedIndexChanged="ddltargetzoneadd_SelectedIndexChanged"
                                                                                data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="ddltargetzoneadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Target Zone"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Target Center
                                                                            <%--<asp:Label ID="label34" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddltargetcenteradd1" Width="215px" Enabled="false" AutoPostBack="true"
                                                                                runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead1"
                                                                                OnSelectedIndexChanged="ddltargetcenteradd1_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="ddltargetcenteradd1"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Target Center"
                                                                                InitialValue="Select" />
                                                                            <asp:TextBox ID="txtstudentid" runat="server" Width="205px" Visible="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="tr11" runat="server" visible="false">
                                                                        <%--<td width="10%">Role</td>
                                                <td width="20%"><asp:DropDownList ID="ddlrole" runat ="server" AutoPostBack ="true" Width="86%" ValidationGroup ="Grplead1"></asp:DropDownList></td>--%>
                                                                        <td width="10%">
                                                                            Assigned To
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Width="86%" MaxLength="6" ValidationGroup="Grplead1"
                                                                                onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="txtassignedto"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Assign Contact to User" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget-box">
                                                        <div class="widget-header">
                                                            <h5>
                                                                Opportunity Details
                                                            </h5>
                                                            <asp:Label ID="Label20" runat="server" Visible="false"></asp:Label>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main">
                                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                                    <%--<thead>
                                                                        <tr>
                                                                            <th colspan="6">
                                                                                Opportunity Details
                                                                            </th>
                                                                        </tr>
                                                                    </thead>--%>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Opportunity Date
                                                                        </td>
                                                                        <td width="20%" colspan="5">
                                                                            <asp:TextBox ID="txt1" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Product Category
                                                                            <asp:Label ID="label1" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlAddProductCategory" Width="215px" runat="server" data-placeholder="Select"
                                                                                CssClass="chzn-select" ValidationGroup="Grplead1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlAddProductCategory"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Product Category"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Acad. Year
                                                                            <%--<asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlacademicyear" Width="215px" runat="server" Enabled="false"
                                                                                data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged"
                                                                                ValidationGroup="Grplead1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="ddlacademicyear"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Academic Year"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Product Name
                                                                            <asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtproductInterested" runat="server" placeholder="Course Interested"
                                                                                        Width="205px" data-trigger="hover" data-placement="top" data-content="Enter Course Interested in"
                                                                                        ValidationGroup="Grplead1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="txtproductInterested"
                                                                                        Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Enter Product Name" />
                                                                            <%--<asp:DropDownList ID="ddlproduct" Width="215px" runat="server" data-placeholder="Select"
                                                                                CssClass="chzn-select" ValidationGroup="Grplead1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="ddlproduct"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Product"
                                                                                InitialValue="Select" />--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Sales Stage
                                                                            <asp:Label ID="label2" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlAddSalesStage" Width="215px" Enabled="false" runat="server"
                                                                                data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead1" AutoPostBack="true"
                                                                                OnSelectedIndexChanged="ddlAddSalesStage_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlAddSalesStage"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Sales Stage"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%" id="tdapplicationno" runat="server">
                                                                            App. Form No
                                                                            <%--<asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%" id="tdapplicationno1" runat="server">
                                                                            <asp:TextBox ID="txtapplicationno" runat="server" Enabled="False" MaxLength="10"
                                                                                onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"
                                                                                ToolTip="Enter Application No" ValidationGroup="Grplead1" Width="205px"></asp:TextBox>
                                                                            <asp:Label ID="lblappnoerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Probability %
                                                                            <%--<asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtprobabilitypercent" Enabled="false" runat="server" ValidationGroup="Grplead1"
                                                                                Width="205px" MaxLength="2" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtprobabilitypercent"
                                                                                ErrorMessage="Enter Probability Percent of Conversion" SetFocusOnError="True"
                                                                                Text="*" ValidationGroup="Grplead1" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtprobabilitypercent"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Source
                                                                            <asp:Label ID="label27" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlsaleschannel" runat="server" Width="215px" data-placeholder="Select Source"
                                                                                CssClass="chzn-select" ValidationGroup="Grplead1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator122" ControlToValidate="ddlsaleschannel"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Contact Source"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Expected DoJ
                                                                            <%--<asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtjoindate" runat="server" Enabled="false" Width="205px" ValidationGroup="Grplead1"></asp:TextBox>
                                                                            <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtjoindate"
                                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                            </CC1:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtjoindate"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Enter Join Date" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtjoindate"
                                                                                ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Exp. Closure date
                                                                            <%--<asp:Label ID="label5" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtexpectedclosedate" Enabled="false" runat="server" Width="205px"
                                                                                ValidationGroup="Grplead1"></asp:TextBox>
                                                                            <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexpectedclosedate"
                                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                            </CC1:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="txtexpectedclosedate"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Expected Closure Date" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtexpectedclosedate"
                                                                                ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Discount Offered
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtdiscount" ToolTip="Enter Discount" runat="server" Width="205px"
                                                                                ValidationGroup="Grplead1" MaxLength="10"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtdiscount"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Discount Notes
                                                                        </td>
                                                                        <td width="70%" colspan="3">
                                                                            <asp:TextBox ID="txtdiscountnotes" runat="server" Width="92%" ValidationGroup="Grplead1"
                                                                                placeholder="Free Text"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%" id="td1" runat="server" visible="false">
                                                                            Assigned To
                                                                            <asp:Label ID="label26" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%" id="td2" runat="server" visible="false">
                                                                            <asp:TextBox ID="TextBox2" runat="server" Width="205px" ValidationGroup="Grplead1"
                                                                                ToolTip="Enter User ID" MaxLength="6" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtassignedto"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Assign Lead" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator44" ControlToValidate="txtassignedto"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td width="10%" id="td70" runat="server" visible="false">
                                                                            Assigned To
                                                                        </td>
                                                                        <td width="20%" id="td71" runat="server" visible="false">
                                                                            <asp:TextBox ID="txtassignedto" runat="server" Width="205px" ValidationGroup="Grplead1"
                                                                                ToolTip="Enter User ID" MaxLength="6" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" ControlToValidate="txtassignedto"
                                                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Assign Lead" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <table class="table table-striped table-bordered table-advance table-hover" width="80% !important">
                                                <tr>
                                                    <th colspan="6">
                                                        <asp:CheckBox ID="ckhBranchTopper" runat="server" AutoPostBack="true" OnCheckedChanged="ckhBranchTopper_CheckedChanged" />
                                                        <span class="lbl"></span>Branch Topper for Standard X
                                                    </th>
                                                </tr>
                                                <tr id="trBranchTopper" runat="server" visible="false">
                                                    <td align="left" style="text-align: left">
                                                        Division
                                                        <asp:Label ID="label35" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        <asp:DropDownList ID="ddlbranchtopperdivision" runat="server" CssClass="chzn-select"
                                                            AutoPostBack="True" ValidationGroup="Grplead1" OnSelectedIndexChanged="ddlbranchtopperdivision_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlbranchtopperdivision"
                                                            Text="*" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Branch Division"
                                                            InitialValue="Select" Display="None" />
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        Center
                                                        <asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left" colspan="3">
                                                        <asp:DropDownList ID="ddlbranchtopperCenter" runat="server" CssClass="chzn-select"
                                                            AutoPostBack="True" ValidationGroup="Grplead1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlbranchtopperCenter"
                                                            Text="*" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Center"
                                                            InitialValue="Select" Display="None" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th colspan="6">
                                                        <asp:CheckBox ID="chkSchoolRanker" runat="server" AutoPostBack="true" OnCheckedChanged="chkSchoolRanker_CheckedChanged" />
                                                        <span class="lbl">School Ranker for Standard X
                                                    </th>
                                                </tr>
                                                <tr runat="server" visible="false" id="trSchoolRanker">
                                                    <td align="left" style="text-align: left">
                                                        School Name
                                                        <asp:Label ID="label37" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        <asp:DropDownList ID="ddlschoolranker" runat="server" CssClass="chzn-select" ValidationGroup="Grplead1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlschoolranker"
                                                            Text="*" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select School"
                                                            InitialValue="Select" Display="None" />
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        School Division
                                                        <asp:Label ID="label38" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        <asp:TextBox ID="txtschooldivision" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtschooldivision"
                                                            Test="*" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Enter School Division"
                                                            Display="None" />
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        Rank
                                                        <asp:Label ID="label39" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        <asp:TextBox ID="txtschoolrank" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtschoolrank"
                                                            runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Enter Rank"
                                                            Display="None" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th colspan="6">
                                                        <asp:CheckBox ID="ckhRankerAdditional" runat="server" AutoPostBack="true" OnCheckedChanged="ckhRankerAdditional_CheckedChanged" />
                                                        <span class="lbl">Additional Pre-Defined Conditions
                                                    </th>
                                                </tr>
                                                <tr runat="server" visible="false" id="trDiscount">
                                                    <td align="left" style="text-align: left">
                                                        Discount Condition
                                                        <asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left" colspan="5">
                                                        <asp:DropDownList ID="ddldiscountconditions" runat="server" CssClass="chzn-select"
                                                            AutoPostBack="True" ValidationGroup="Grplead1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValfdteidator16" ControlToValidate="ddldiscountconditions"
                                                            Text="*" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Discount Condition"
                                                            InitialValue="Select" Display="None" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:DataList ID="dlScore" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                <HeaderTemplate>
                                                    <b>Score Type</b></th>
                                                    <th>
                                                    Score
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblscoretypedesc" Text='<%#DataBinder.Eval(Container.DataItem, "Score_Type_Short_Desc")%>'
                                                        runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtscore" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Score")%>'
                                                            Width="205px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="txtscore"
                                                            Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Field Cannot be blank" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtscore"
                                                            Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lblscoreid" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>'
                                                            runat="server" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <div class="alert alert-danger" id="divscoreerror" runat="server" visible="false">
                                                <strong>
                                                    <asp:Label ID="lblscoreerror" runat="server"></asp:Label></strong>
                                            </div>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnEditSubmit" runat="server"
                                                    validationgroup="Grplead1" onserverclick="btnEditSubmit_ServerClick">
                                                    Save
                                                </button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclear" runat="server"
                                                    onclick="javascript:window.close()">
                                                    Close
                                                </button>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ValidationGroup="Grplead1" ShowSummary="False" />
                                                <asp:Label ID="lblprimarycontactid" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="row-fluid">
                                                <historypanel:historypanel runat="server" id="HistoryPanel1"></historypanel:historypanel>
                                            </div>
                                            <%--<div class="row-fluid">
                                                <div class="span12">
                                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    Secondary Contact Details
                                                                </th>
                                                                <th width="20%">
                                                                    <button type="button" class="btn btn-small btn-primary" id="btnaddcontact" runat="server" onserverclick ="btnaddcontact_ServerClick"><i class="icon-pencil"></i> Add Secondary Contact
                                                                        </button>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                    </table>
                                                    <asp:DataList ID="dlseccontact" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"  OnItemCommand ="dlseccontact_ItemCommand"  OnItemDataBound ="dlseccontact_ItemDataBound" >
                                                        <HeaderTemplate>
                                                            <b>Contact Type</b></th>
                                                            <th>
                                                                Contact Name
                                                            </th>
                                                            <th>
                                                                Handphone 1
                                                            </th>
                                                            <th>
                                                                Handphone 2
                                                            </th>
                                                            <th>
                                                                Landline
                                                            </th>
                                                            <th>
                                                            Action
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcontacttype" Text='<%#DataBinder.Eval(Container.DataItem, "Con_type_Desc")%>'
                                                                runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "SecondaryName")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "handphone1")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "handphone2")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "landline")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lnkedit" runat="server" class="btn btn-minier btn-primary icon-edit tooltip-info" data-rel="tooltip" data-placement="top" title="Edit" CommandName="Edit"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Con_id")%>'></asp:LinkButton>

                                                                
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <div class="alert alert-danger" id="divseccontact" runat="server">
                                                        <strong>
                                                            <asp:Label ID="lblseccontact" runat="server"></asp:Label></strong>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <!-- static -->
                                </div>
                            </div>
                        </div>
                        <!--end tabbable-->
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnEditSubmit" />
                    <asp:PostBackTrigger ControlID="btnsearchoppor" />
                    <%--<asp:PostBackTrigger ControlID="btnEditCon" />--%>
                    <asp:PostBackTrigger ControlID="btnRefreshCon" />
                </Triggers>
            </asp:UpdatePanel>
            <!--BEGIN PAGE CONTENT FOR ADD SECONDARY CONTACT -->
            <asp:UpdatePanel ID="UpnlSecContact" runat="server">
                <ContentTemplate>
                    <!-- BEGIN PAGE CONTENT FOR ADD LEAD-->
                    <div class="row-fluid">
                        <div class="span12">
                            <div id="Div3" class="row-fluid">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <!-- Secondary Contact Type  -->
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Secondary Contact
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Contact Type
                                                        <asp:Label ID="label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlseccontacttype2" Enabled="false" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Secondary Contact Type">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator101" ControlToValidate="ddlseccontacttype2"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Title
                                                        <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsectitle2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                            <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator102" ControlToValidate="ddlsectitle2"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title"
                                                            InitialValue="0" />
                                                        <asp:Label ID="lblprimaryconid" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        First Name
                                                        <asp:Label ID="label22" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecfname2" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="First Name"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server"
                                                            ControlToValidate="txtsecfname2" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtsecfname2"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
                                                    </td>
                                                    <td width="10%">
                                                        Middle Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecmname2" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="Middle Name"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server"
                                                            ControlToValidate="txtsecmname2" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                    <td width="10%">
                                                        Last Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtseclname2" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="Last Name"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server"
                                                            ControlToValidate="txtseclname2" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Handphone 1
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsechandphone12" runat="server" Width="79%" placeholder="Handphone 1"
                                                            ValidationGroup="Grplead2" MaxLength="18"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator35" ControlToValidate="txtsechandphone12"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server"
                                                            ControlToValidate="txtsechandphone12" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                            ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator2" ControlToValidate="txtsechandphone12" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone1" />
                                                        --%>
                                                    </td>
                                                    <td width="10%">
                                                        Handphone 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsechandphone22" runat="server" Width="79%" placeholder="Handphone 2"
                                                            ValidationGroup="Grplead2" MaxLength="18"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator37" ControlToValidate="txtsechandphone22"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator38" runat="server"
                                                            ControlToValidate="txtsechandphone22" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                            ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                    </td>
                                                    <td width="10%">
                                                        Landline No.
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtseclandline2" runat="server" Width="79%" placeholder="Landline No."
                                                            ValidationGroup="Grplead2" MaxLength="18"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator39" ControlToValidate ="txtseclandline2" Text ="#" runat ="server" ValidationGroup ="Grplead2" SetFocusOnError ="true" ErrorMessage ="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" ControlToValidate="txtseclandline2" ErrorMessage="Handphone length must be between 7 to 18 characters"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[0-9]{7,18}$" />
                                                        --%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Address 1
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecaddress12" runat="server" Width="79%" placeholder="Address Line 1"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Address 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecaddress22" runat="server" Width="79%" placeholder="Address Line 2"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Street Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecStreetname2" runat="server" Width="79%" placeholder="Street Name"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Country
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlseccountry2" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlseccountry_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        State
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsecstate2" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        City
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlseccity2" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlseccity2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Location
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlSeclocation2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Postal Code
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecpincode2" runat="server" placeholder="Postal Code" MaxLength="6"
                                                            ValidationGroup="Grplead2" Width="79%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator41" ControlToValidate="txtsecpincode2"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator42" ControlToValidate="txtsecpincode2"
                                                            runat="server" ErrorMessage="Pincode length must be of 6 Character" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{6,6}$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Gender
                                                        <asp:Label ID="label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsecgender" TabIndex="14" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead2">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlsecgender"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                            InitialValue="0" />
                                                    </td>
                                                    <td width="10%">
                                                        DOB
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecdob" Placeholder="Date of Birth" runat="server" Width="79%"
                                                            ValidationGroup="Grplead2"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtsecdob"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtsecdob"
                                                            ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- ](0[1-9]|1[012])[- ](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="Label24" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        Email id
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecemailid2" runat="server" Width="79%" placeholder="Email Id"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server"
                                                            ControlToValidate="txtsecemailid2" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Secondary Contact Academic Information
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Institution Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlinstitutiontype2" runat="server" AutoPostBack="true" CssClass="chzn-select"
                                                            ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Institution Type"
                                                            OnSelectedIndexChanged="ddlinstitutiontype2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Institution Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtnameofinstitution2" runat="server" placeholder="Institution name"
                                                            MaxLength="100" Width="79%" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top"
                                                            data-content="Enter Institution Name"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Board / University
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlboard2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2"
                                                            data-trigger="hover" data-placement="top" data-content="Select Board / University">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Current Standard
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcurrentstudying2" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Division / Section
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsection2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2"
                                                            data-trigger="hover" data-placement="top" data-content="Select Division / Section / Grade">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Year of Passing
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlyearofpassing2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2"
                                                            data-trigger="hover" data-placement="top" data-content="Select Year of Passing">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Notes, If Any
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtadditiondesc2" runat="server" placeholder="Additional Information"
                                                            Width="94%" MaxLength="100" data-trigger="hover" data-placement="top" data-content="Enter Additional Information"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnSubmitSeccon" runat="server"
                                                    validationgroup="Grplead2" onserverclick="btnSubmitSeccon_ServerClick">
                                                    Update
                                                </button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclearSeccon" runat="server"
                                                    onserverclick="btnclearSeccon_ServerClick">
                                                    Back
                                                </button>
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                    ValidationGroup="Grplead2" ShowSummary="False" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                    <!-- END PAGE CONTENT FOR ADD LEAD-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSubmitSeccon" />
                    <asp:PostBackTrigger ControlID="btnclearSeccon" />
                </Triggers>
            </asp:UpdatePanel>
            <!--END PAGE CONTENT FOR ADD SECONDARY CONTACT-->
            <!-- END PAGE CONTENT FOR ADD OPP-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
