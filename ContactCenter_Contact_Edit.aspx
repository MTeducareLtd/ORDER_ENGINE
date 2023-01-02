<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ContactCenter_Contact_Edit.aspx.cs" Inherits="ContactCenter_Contact_Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
    <script language="javascript" type="text/javascript">
       
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname"
                        runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
                            <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                    <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                    <span class="divider"></span>
                </h4>
            </li>
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="Contacts.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
            <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
            </i><a href="#">
                <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
        </ul>
        <div id="nav-search">
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
            <!-- END PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnldisplay" runat="server">
                <ContentTemplate>
                    <div runat="server" id="divContactDetail" class="row-fluid">
                        <div class="span12">
                            <div id="Div3" class="row-fluid">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <%--<div class="table-responsive">--%>
                                        <!-- Secondary Contact Type  -->
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            Contact
                                                        </h5>
                                                        <asp:Label ID="lblPKey_Con_Id" runat="server" Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Contact Source
                                                                        <asp:Label ID="label26" runat="server" Enabled="false" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlContactsourceadd" runat="server" CssClass="chzn-select"
                                                                            ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Contact Source">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddlContactsourceadd"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Source"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Contact Type
                                                                        <%--<asp:Label ID="Label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlContactType" runat="server" Width="215px" Enabled="false"
                                                                            CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Select Contact Type">
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlContactType"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                                            InitialValue="Select" />--%>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Customer Type
                                                                        <%--<asp:Label ID="Label1re7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlcustomertype" runat="server" data-placeholder="Select Type"
                                                                            Width="215px" CssClass="chzn-select" AutoPostBack="true" Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlcustomertype"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Customer Type"
                                                                            InitialValue="Select" />--%>
                                                                    </td>
                                                                </tr>
                                                                <%-- <tr>
                                                                    <td width="10%">
                                                                        Title
                                                                        <asp:Label ID="Label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlTitle" runat="server" Width="215px" CssClass="chzn-select"
                                                                            ValidationGroup="Grplead2">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                                            <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlTitle"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title"
                                                                            InitialValue="0" />
                                                                    </td>
                                                                    <td colspan="4">
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td width="10%">
                                                                        First Name
                                                                        <asp:Label ID="label12" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlTitle" runat="server" Width="60px" CssClass="chzn-select"
                                                                            ValidationGroup="Grplead2">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                                            <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtFirstName" runat="server" Width="145px" ValidationGroup="Grplead2"
                                                                            placeholder="First Name"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlTitle"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title"
                                                                            InitialValue="0" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtFirstName"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirstName"
                                                                            ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                            ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Middle Name
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtMidName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                            placeholder="Middle Name"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMidName"
                                                                            ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                            ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Last Name
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtLastName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                            placeholder="Last Name"></asp:TextBox>
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
                                                                            ValidationGroup="Grplead2">
                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="ddlGender"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                                            InitialValue="0" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        DOB
                                                                        <%--<asp:Label ID="label19" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <input readonly="readonly" class="span8 date-picker" id="txtdateofbirth" runat="server"
                                                                            type="text" data-date-format="dd M yyyy" style="width: 215px" />
                                                                        <%--<asp:TextBox ID="txtdateofbirth" Width="205px" Placeholder="Date of Birth" runat="server"
                                                                            ValidationGroup="Grplead2"></asp:TextBox>
                                                                        <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdateofbirth"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>--%>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="txtdateofbirth"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Date Of Birth" />--%>
                                                                        <%--<asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="txtdateofbirth"
                                                                            ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                                        <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server"
                                                                            ControlToValidate="txtdateofbirth" ValidationGroup="Grplead2" Text="#" SetFocusOnError="True"
                                                                            ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>--%>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Email id
                                                                        <asp:Label ID="label5" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtemailid" runat="server" Width="205px" placeholder="Email Id"
                                                                            ValidationGroup="Grplead2"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="txtemailid"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Email Id" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                                            ControlToValidate="txtemailid" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                            ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <%-- <td colspan="2">
                                                                    </td>--%>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Handphone 1
                                                                        <asp:Label ID="label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtHandPhone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                                            ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtHandPhone1"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone 1" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtHandPhone1"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtHandPhone1"
                                                                            ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2"
                                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Handphone 2
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtHandphone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                                            ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtHandphone2"
                                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtHandphone2"
                                                                            ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2"
                                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Landline No.
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtlandline" runat="server" Width="205px" placeholder="Landline No."
                                                                            ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
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
                                                                        <asp:TextBox ID="txtaddress1" runat="server" Width="205px" placeholder="Address Line 1"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Address 2
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtaddress2" runat="server" Width="205px" placeholder="Address Line 2"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Street Name
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtStreetname" runat="server" Width="205px" placeholder="Street Name"></asp:TextBox>
                                                                    </td>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Country
                                                                            <asp:Label ID="label23" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlCountry" runat="server" Width="215px" CssClass="chzn-select"
                                                                                AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
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
                                                                                AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="10%">
                                                                            City
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlcity" runat="server" Width="215px" CssClass="chzn-select"
                                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged" ValidationGroup="Grplead2">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Location
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddllocation" runat="server" Width="215px" CssClass="chzn-select"
                                                                                ValidationGroup="Grplead2">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Postal Code
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtpincode" runat="server" placeholder="Postal Code" MaxLength="6"
                                                                                ValidationGroup="Grplead2" Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtpincode"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtpincode"
                                                                                runat="server" ErrorMessage="Pincode length must be of 6 Character" ValidationGroup="Grplead2"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{6,6}$" />
                                                                        </td>
                                                                        <td colspan="2">
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
                                                            Contact Academic Information
                                                        </h5>
                                                        <asp:Label ID="lblAcadInfoRecordNo" runat="server" Visible="false"></asp:Label>
                                                        <button id="btnAddAcadInfo" runat="server" data-rel="tooltip" data-placement="left"
                                                            visible="true" title="Add Academic Information" class="btn btn-mini btn-primary"
                                                            onserverclick="btnAddAcadInfo_Click">
                                                            <i class="icon-plus"></i>
                                                        </button>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                            <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                                id="tblAddAcadinfo" visible="false">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Institution Type
                                                                        <asp:Label ID="Label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlinstitutiontype" runat="server" AutoPostBack="true" CssClass="chzn-select"
                                                                            Width="215px" ValidationGroup="Grplead3" data-trigger="hover" data-placement="top"
                                                                            data-content="Select Institution Type" OnSelectedIndexChanged="ddlinstitutiontype_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlinstitutiontype"
                                                                            Text="#" runat="server" ValidationGroup="Grplead3" SetFocusOnError="True" ErrorMessage="Select Institution Type"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Institution Name
                                                                        <asp:Label ID="Label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtnameofinstitution" runat="server" placeholder="Institution name"
                                                                            MaxLength="100" Width="205px" ValidationGroup="Grplead3" data-trigger="hover"
                                                                            data-placement="top" data-content="Enter Institution Name"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtnameofinstitution"
                                                                            Text="#" runat="server" ValidationGroup="Grplead3" SetFocusOnError="True" ErrorMessage="Enter Institution Name" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Board / University
                                                                        <asp:Label ID="Label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlboard" runat="server" Width="215px" ValidationGroup="Grplead3"
                                                                            CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Select Board / University">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="ddlboard"
                                                                            Text="#" runat="server" ValidationGroup="Grplead3" SetFocusOnError="True" ErrorMessage="Select Board / University"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Cur. Studying
                                                                        <asp:Label ID="Label18z" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlcurrentstudying" runat="server" Width="215px" CssClass="chzn-select"
                                                                            ValidationGroup="Grplead3">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="ddlcurrentstudying"
                                                                            Text="#" runat="server" ValidationGroup="Grplead3" SetFocusOnError="True" ErrorMessage="Select Current Studying"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Division/Section
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlsection" runat="server" Width="215px" ValidationGroup="Grplead2"
                                                                            CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Select Division / Section / Grade">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Year of Passing
                                                                        <asp:Label ID="Label19s" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlyearofpassing" runat="server" Width="215px" CssClass="chzn-select"
                                                                            ValidationGroup="Grplead3" data-trigger="hover" data-placement="top" data-content="Select Year of Passing">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="ddlyearofpassing"
                                                                            Text="#" runat="server" ValidationGroup="Grplead3" SetFocusOnError="True" ErrorMessage="Select Year of Passing"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Additional Desc
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtadditiondesc" runat="server" placeholder="Additional Description"
                                                                            Width="205px" MaxLength="100" data-trigger="hover" data-placement="top" data-content="Enter Additional description (If Any)"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Exam Name
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtExamName" runat="server" placeholder="Exam Name" Width="205px"
                                                                            data-trigger="hover" data-placement="top" data-content="Enter Exam Name"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Final Marks Obtained
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtFinalMarksObtained" runat="server" placeholder="Final Marks Obtained"
                                                                            Width="205px" MaxLength="100" data-trigger="hover" data-placement="top" data-content="Enter Final Obtained Marks"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Final Marks Total
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtFinalMarksTotal" runat="server" placeholder="Final Marks Total"
                                                                            Width="205px" data-trigger="hover" data-placement="top" data-content="Enter Final Obtained Total"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Grade
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtGrade" runat="server" placeholder="Final Grade" Width="205px"
                                                                            data-trigger="hover" data-placement="top" data-content="Enter Grade"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Percentage
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtPercentage" runat="server" placeholder="Final Percentage" Width="205px"
                                                                            data-trigger="hover" data-placement="top" data-content="Enter Percentage"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%" colspan="6">
                                                                        <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                                            <button class="btn btn-app btn-success btn-mini radius-4" id="btnSaveAcadInfo" runat="server"
                                                                                validationgroup="Grplead3" onserverclick="btnSaveAcadInfo_ServerClick">
                                                                                Save
                                                                            </button>
                                                                            <button class="btn btn-app btn-success btn-mini radius-4" id="btnUpdateAcadInfo"
                                                                                runat="server" validationgroup="Grplead3" onserverclick="btnUpdateAcadInfo_ServerClick">
                                                                                Save
                                                                            </button>
                                                                            <button class="btn btn-app btn-primary btn-mini radius-4" id="btnCloseAcadInfo" runat="server"
                                                                                onserverclick="btnCloseAcadInfo_ServerClick">
                                                                                Close
                                                                            </button>
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                                                ValidationGroup="Grplead3" ShowSummary="False" />
                                                                            <asp:Label ID="lblPKeyRowNumber" runat="server" Visible="false"></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div class="row-fluid">
                                                                <asp:DataList ID="dlAcadInfo" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                    OnItemCommand="dlAcadInfo_ItemCommand">
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
                                                                        <th style="text-align: center">
                                                                            Action
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
                                                                        <td style="text-align: center">
                                                                            <asp:LinkButton ID="lnkDLEdit" ToolTip="Edit" class="btn btn-mini btn-primary" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Record_No")%>'
                                                                                runat="server" CommandName="Edit" Height="15px"><i class=" icon-info-sign"></i></asp:LinkButton>
                                                                            <%--<asp:LinkButton ID="lnkDelete" ToolTip="Remove" runat="server" class="btn btn-mini btn-danger"
                                                                                CommandName="Remove" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Record_No")%>'><i class="icon-trash"></i></asp:LinkButton>--%>
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
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            Secondary Contact Information
                                                        </h5>
                                                        <asp:Label ID="lblPrimary_ConId" runat="server" Visible="false"></asp:Label>
                                                        <button id="btnAddSecondoryContact" runat="server" data-rel="tooltip" data-placement="left"
                                                            title="Add Secondory Contact" class="btn btn-mini btn-primary" onserverclick="btnAddSecondoryContact_Click">
                                                            <i class="icon-plus"></i>
                                                        </button>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                            <div class="row-fluid">
                                                                <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                                    id="tblSecConInfo" visible="false">
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Contact Type
                                                                            <asp:Label ID="Label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlSecContactType" runat="server" Width="215px" CssClass="chzn-select"
                                                                                ValidationGroup="Grplead4" data-trigger="hover" data-placement="top" data-content="Select Contact Type">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlSecContactType"
                                                                                Text="#" runat="server" ValidationGroup="Grplead4" SetFocusOnError="True" ErrorMessage="Select Secondory Contact Type"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Title
                                                                            <asp:Label ID="Label2" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlSecConTitle" runat="server" Width="215px" CssClass="chzn-select"
                                                                                ValidationGroup="Grplead4">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                                                <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlSecConTitle"
                                                                                Text="#" runat="server" ValidationGroup="Grplead4" SetFocusOnError="True" ErrorMessage="Select Father Title"
                                                                                InitialValue="0" />
                                                                        </td>
                                                                        <td colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            First Name
                                                                            <asp:Label ID="label1" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConFName" runat="server" Width="205px" ValidationGroup="Grplead4"
                                                                                placeholder="First Name"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtSecConFName"
                                                                                Text="#" runat="server" ValidationGroup="Grplead4" SetFocusOnError="True" ErrorMessage="Enter Father Name" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                                ControlToValidate="txtSecConFName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead4"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Middle Name
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConMName" runat="server" Width="205px" ValidationGroup="Grplead4"
                                                                                placeholder="Middle Name"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                                                ControlToValidate="txtSecConMName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead4"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Last Name
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConLName" runat="server" Width="205px" ValidationGroup="Grplead4"
                                                                                placeholder="Last Name"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                                                ControlToValidate="txtSecConLName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead4"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Handphone 1
                                                                            <asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConHandphone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                                                ValidationGroup="Grplead4" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtSecConHandphone1"
                                                                                Text="#" runat="server" ValidationGroup="Grplead4" SetFocusOnError="True" ErrorMessage="Enter Father Handphone 1" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtSecConHandphone1"
                                                                                Text="#" runat="server" ValidationGroup="Grplead4" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                                                ControlToValidate="txtSecConHandphone1" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                                ValidationGroup="Grplead4" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Handphone 2
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConHandPhone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                                                ValidationGroup="Grplead4" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtSecConHandPhone2"
                                                                                Text="#" runat="server" ValidationGroup="Grplead4" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                                                                ControlToValidate="txtSecConHandPhone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                                ValidationGroup="Grplead4" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Landline No.
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConLandLineNumber" runat="server" Width="205px" placeholder="Landline No."
                                                                                ValidationGroup="Grplead4" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" ControlToValidate="txtSecConLandLineNumber"
                                                                                Text="#" runat="server" ValidationGroup="Grplead4" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                                                ControlToValidate="txtSecConLandLineNumber" ErrorMessage="Land Line Number length must be between 7 to 18 characters"
                                                                                ValidationGroup="Grplead4" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Gender
                                                                            <asp:Label ID="label20" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlSecConGender" runat="server" Width="215px" CssClass="chzn-select"
                                                                                ValidationGroup="Grplead4">
                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                <asp:ListItem Value="1">Male</asp:ListItem>
                                                                                <asp:ListItem Value="2">Female</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlSecConGender"
                                                                                Text="#" runat="server" ValidationGroup="Grplead4" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                                                InitialValue="0" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Email ID
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConEmailID" runat="server" Width="205px" placeholder="Email Id"
                                                                                ValidationGroup="Grplead4"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                                                                ControlToValidate="txtSecConEmailID" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                ValidationGroup="Grplead4" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Occupation
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConOccupation" runat="server" Width="205px" placeholder="Occupation"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Organization
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConOrganization" runat="server" Width="205px" placeholder="Organization"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Designation
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConDesignation" runat="server" Width="205px" placeholder="Designation"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Office Phone
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtSecConOfficePhone" runat="server" Width="205px" placeholder="Office Phone"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="100%" colspan="6">
                                                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnSaveSecContact"
                                                                                    runat="server" validationgroup="Grplead4" onserverclick="btnSaveSecContact_ServerClick">
                                                                                    Save
                                                                                </button>
                                                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnUpdateSecContact"
                                                                                    runat="server" validationgroup="Grplead4" onserverclick="btnUpdateSecContact_ServerClick">
                                                                                    Save
                                                                                </button>
                                                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnCloseSecContact"
                                                                                    runat="server" onserverclick="btnCloseSecCon_ServerClick">
                                                                                    Close
                                                                                </button>
                                                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                                                    ValidationGroup="Grplead4" ShowSummary="False" />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div class="row-fluid">
                                                                <asp:DataList ID="dlSec_Con_Info" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                    OnItemCommand="dlSec_Con_Info_ItemCommand">
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
                                                                        <th style="text-align: center">
                                                                            Action
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
                                                                        <td style="text-align: center">
                                                                            <asp:LinkButton ID="lnkDLEdit" ToolTip="Edit" class="btn btn-mini btn-primary" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Con_Id")%>'
                                                                                runat="server" CommandName="Edit" Height="15px"><i class=" icon-info-sign"></i></asp:LinkButton>
                                                                            <%--<asp:LinkButton ID="lnkDelete" ToolTip="Remove" runat="server" class="btn btn-mini btn-danger"
                                                                                CommandName="Remove" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Con_Id")%>'><i class="icon-trash"></i></asp:LinkButton>--%>
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
                                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                                            <!--Button Area -->
                                            <button class="btn btn-app btn-success btn-mini radius-4" id="btnSubmitcon" runat="server"
                                                validationgroup="Grplead2" onserverclick="btnSubmitcon_ServerClick">
                                                Save
                                            </button>
                                            <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclose" runat="server"
                                                onclick="javascript:window.close()">
                                                Close</button>
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                ValidationGroup="Grplead2" ShowSummary="False" />
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            Contact History
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                            <div class="row-fluid">
                                                                <asp:DataList ID="dlConHistory" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                                    <HeaderTemplate>
                                                                        <b class="center" style="text-align: left">Event Name</b></th>
                                                                        <th style="text-align: center">
                                                                            Event Description
                                                                        </th>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEvent_Name" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Name")%>'
                                                                            runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblEvent_Description" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Description")%>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                                <asp:Label ID="lblCon_History" Visible="false" CssClass="red" runat="server" Font-Bold="True"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-fluid" id="divfeedbackhistory" runat="server">
                                            <div class="span12">
                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            <i class="icon-calendar"></i>Follow up History
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="dlfeedbackhistory" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                                <HeaderTemplate>
                                                                    <b>Phase</b></th>
                                                                    <th>
                                                                        Interacted On
                                                                    </th>
                                                                    <th>
                                                                        Interacted With
                                                                    </th>
                                                                    <th>
                                                                        Relation
                                                                    </th>
                                                                    <%-- <th>
                                                                                                Lead Status
                                                                                            </th>--%>
                                                                    <th>
                                                                        Feedback
                                                                    </th>
                                                                    <th>
                                                                        Next Follow-up
                                                                    </th>
                                                                    <th>
                                                                        Agent
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPhase" Text='<%#DataBinder.Eval(Container.DataItem, "Phase")%>'
                                                                        runat="server"></asp:Label></a> </td>
                                                                    <td>
                                                                        <asp:Label ID="lblusermailid" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_On")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbluserid" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_With")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblusername" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_Relation")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <%--<td>
                                                                                                <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Feedback_Status")%>'
                                                                                                    runat="server"></asp:Label>
                                                                                            </td>--%>
                                                                    <td>
                                                                        <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Feedback")%>'
                                                                            runat="server" data-trigger="hover" data-placement="top" data-content='<%#DataBinder.Eval(Container.DataItem, "Feedback")%>'></asp:Label></a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "Nextfollowupdate")%>'
                                                                            runat="server"></asp:Label></a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Updated_By")%>'
                                                                            runat="server"></asp:Label></a>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- END EXAMPLE TABLE PORTLET-->
                                            </div>
                                        </div>
                                        <div class="alert alert-danger" id="diverrormessagefeedback" runat="server">
                                            <strong>
                                                <asp:Label ID="lblerrrormessagefeedback" runat="server"></asp:Label></strong>
                                        </div>
                                        <%--</div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSubmitcon" />
                    <asp:PostBackTrigger ControlID="btnSaveAcadInfo" />
                    <asp:PostBackTrigger ControlID="btnUpdateAcadInfo" />
                    <asp:PostBackTrigger ControlID="btnCloseAcadInfo" />
                    <asp:PostBackTrigger ControlID="btnSaveSecContact" />
                    <asp:PostBackTrigger ControlID="btnUpdateSecContact" />
                    <asp:PostBackTrigger ControlID="btnCloseSecContact" />
                    <asp:PostBackTrigger ControlID="btnAddSecondoryContact" />
                    <asp:PostBackTrigger ControlID="btnAddAcadInfo" />
                    <%--<asp:PostBackTrigger ControlID="btn_ConvertToLeadYes" />
                    <asp:PostBackTrigger ControlID="btn_ConvertToLeadNo" />--%>
                </Triggers>
            </asp:UpdatePanel>
            <div runat="server" id="divSaveMessage" class="row-fluid" visible="false">
                <div class="alert alert-success" id="div1" runat="server">
                    <strong>
                        <asp:Label ID="Label4" runat="server">Record Saved Successfully...!</asp:Label></strong>
                    &nbsp;&nbsp;
                    <%--<asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btn_ConvertToLeadYes"
                        ToolTip="Yes" runat="server" Text="Yes" OnClick="btn_ConvertToLeadYes_Click" />
                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btn_ConvertToLeadNo"
                        ToolTip="No" runat="server" OnClick="btn_ConvertToLeadNo_Click" Text="No" />--%>
                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btn_ContactMsgOk"
                        ToolTip="OK" runat="server" Text="OK" OnClick="btn_ContactMsgOk_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
