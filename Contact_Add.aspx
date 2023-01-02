<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Contact_Add.aspx.cs" Inherits="Contact_Add" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<!-- CODE CHECKED -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
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
            <!-- /btn-group -->
            <button type="button" class="btn btn-app btn-primary btn-mini radius-4 dropdown-toggle"
                data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                <span>Actions </span><i class="fa fa-angle-down"></i>
            </button>
            <ul class="dropdown-menu pull-right" role="menu">
                <li><a href="#" id="btnaddlead" runat="server">Add Lead</a></li>
            </ul>
        </div>
        <!--#nav-search-->
    </div>


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
            <!--BEGIN PAGE CONTENT FOR ADD LEAD -->
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <!-- BEGIN PAGE CONTENT FOR ADD LEAD-->
                    <div class="row-fluid">
                        <div class="span12">
                            <div id="Div2" class="row-fluid">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">

                                            <div class="widget-box">
                                                <div class="widget-header">
                                                    <h5>
                                                        Lead Basic Info
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-main">
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <tr>
                                                            <td width="10%">
                                                                Lead Type
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtleadtype" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Lead Source
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtleadsource" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Lead Status
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtleadstatus" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Student Name
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtstudentname" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Handphone 1
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txthandphone1" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Landline
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtlandline" runat="server" Enabled="false" Width="95%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </div> 
                                                </div>
                                            </div>
                                            
                                            <!-- Secondary Contact Type  -->
                                            <div>
                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="5">
                                                                Secondary Contact
                                                            </th>
                                                            <th width="20%">
                                                                <asp:CheckBox ID="chkaddcopy" runat="server"  AutoPostBack="true" Text ="" OnCheckedChanged ="chkaddcopy_CheckedChanged"/> 
                                                                <span class="lbl"> Same As Primary Contact</span>

                                                                
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tr>
                                                        <td width="10%">
                                                            Contact Type
                                                            <asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlseccontacttype1" AutoPostBack="true" runat="server" 
                                                                ValidationGroup="Grplead2" data-placeholder="Select Contact Type" CssClass="chzn-select" data-trigger="hover" data-placement="top"
                                                                >
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlseccontacttype1"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                                InitialValue="Select" />
                                                        </td>
                                                        <td width="10%">
                                                            Title
                                                            <asp:Label ID="label5" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlsectitle" runat="server" data-placeholder="Select Title" CssClass="chzn-select" ValidationGroup="Grplead2">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                                <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlsectitle"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title"
                                                                InitialValue="0" />
                                                            <asp:Label ID="lblprimaryconid" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            First Name
                                                            <asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtsecfname" runat="server" Width="86%" ValidationGroup="Grplead2"
                                                                placeholder="First Name"></asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txtsecfname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            --%><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtsecfname"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                                ControlToValidate="txtsecfname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        </td>
                                                        <td width="10%">
                                                            Middle Name
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtsecmname" runat="server" Width="86%" ValidationGroup="Grplead2"
                                                                placeholder="Middle Name"></asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="txtsecmname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            --%>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtsecmname"
                                                                ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        </td>
                                                        <td width="10%">
                                                            Last Name
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtseclname" runat="server" Width="86%" ValidationGroup="Grplead2"
                                                                placeholder="Last Name"></asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="txtseclname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            --%>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtseclname"
                                                                ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_']*$" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Handphone 1
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtsechandphone1" runat="server" Width="86%" placeholder="Handphone 1"
                                                                ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtsechandphone1"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                ControlToValidate="txtsechandphone1" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                            <%--<asp:RequiredFieldValidator id="RequiredFieldValidator1" ControlToValidate="txtsechandphone1" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone1" />
                                                            --%>
                                                        </td>
                                                        <td width="10%">
                                                            Handphone 2
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtsechandphone2" runat="server" Width="86%" placeholder="Handphone 2"
                                                                ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtsechandphone2"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                                ControlToValidate="txtsechandphone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                        </td>
                                                        <td width="10%">
                                                            Landline No.
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtseclandline" runat="server" Width="86%" placeholder="Landline No."
                                                                ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate ="txtseclandline" Text ="#" runat ="server" ValidationGroup ="Grplead2" SetFocusOnError ="true" ErrorMessage ="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtseclandline" ErrorMessage="Handphone length must be between 7 to 18 characters"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[0-9]{7,18}$" />
                                                            --%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Address 1
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtsecaddress1" runat="server" Width="86%" placeholder="Address Line 1"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            Address 2
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtsecaddress2" runat="server" Width="86%" placeholder="Address Line 2"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            Street Name
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtsecStreetname" runat="server" Width="86%" placeholder="Street Name"></asp:TextBox>
                                                        </td>
                                                        <tr>
                                                            <td width="10%">
                                                                Country
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlseccountry" runat="server" data-placeholder="Select Country" CssClass="chzn-select" AutoPostBack="true"
                                                                    ValidationGroup="Grplead2" OnSelectedIndexChanged = "ddlseccountry_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                State
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlsecstate" runat="server" data-placeholder="Select State" CssClass="chzn-select" AutoPostBack="true"
                                                                    ValidationGroup="Grplead2" OnSelectedIndexChanged = "ddlSecstate_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                City
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlseccity" runat="server" data-placeholder="Select City" CssClass="chzn-select" AutoPostBack="true"
                                                                    ValidationGroup="Grplead2" OnSelectedIndexChanged = "ddlseccity_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Location
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlSeclocation" runat="server" data-placeholder="Select Location" CssClass="chzn-select" ValidationGroup="Grplead2">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                Postal Code
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtsecpincode" runat="server" placeholder="Postal Code" MaxLength="10"
                                                                    ValidationGroup="Grplead2" Width="86%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtsecpincode"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtsecpincode"
                                                                    runat="server" ErrorMessage="Pincode length must be of 6-10 Character" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{6,10}$" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Gender
                                                                <asp:Label ID="label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlgenderadd" TabIndex="14" runat="server" data-placeholder="Select Gender" CssClass="chzn-select" ValidationGroup="Grplead2">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                                    <asp:ListItem Value="2">Female</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlgenderadd"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                                    InitialValue="0" />
                                                            </td>
                                                            <td width="10%">
                                                                DOB
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtdateofbirth" Placeholder="Date of Birth" runat="server" Width="86%"
                                                                    ValidationGroup="Grplead2"></asp:TextBox>
                                                                <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdateofbirth"
                                                                    DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                </CC1:CalendarExtender>
                                                                <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="txtdateofbirth"
                                                                    ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- ](0[1-9]|1[012])[- ](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="10%">
                                                                Email id
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtsecemailid" runat="server" Width="86%" placeholder="Email Id"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtsecemailid"
                                                                    ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                </table>
                                            </div>
                                            <div id="divacadinfo" runat="server">
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
                                                            <asp:DropDownList ID="ddlinstitutiontype2" runat="server" AutoPostBack="true" 
                                                                ValidationGroup="Grplead2" data-placeholder="Select Type" CssClass="chzn-select" data-trigger="hover" data-placement="top"
                                                                data-content="Select Institution Type" OnSelectedIndexChanged = "ddlinstitutiontype2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Institution Name
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtnameofinstitution2" runat="server" placeholder="Institution name"
                                                                MaxLength="100" Width="86%" ValidationGroup="Grplead2"  data-trigger="hover"
                                                                data-placement="top" data-content="Enter Institution Name"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            Board / University
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlboard2" runat="server" ValidationGroup="Grplead2"
                                                                data-placeholder="Select Board / University" CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Select Board / University">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Current Standard
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlcurrentstudying2" runat="server" data-placeholder="Select Current Standard" CssClass="chzn-select" ValidationGroup="Grplead2">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Division / Section
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlsection2" runat="server" data-placeholder="Select Division" CssClass="chzn-select" ValidationGroup="Grplead2"
                                                                data-trigger="hover" data-placement="top" data-content="Select Division / Section / Grade">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Year / (Of Passing)
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlyearofpassing2" runat="server" data-placeholder="Select Year" CssClass="chzn-select" ValidationGroup="Grplead2"
                                                                data-trigger="hover" data-placement="top" data-content="Select Year of Passing">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Notes, If Any
                                                        </td>
                                                        <td width="20%" colspan="5">
                                                            <asp:TextBox ID="txtadditiondesc2" runat="server" placeholder="Additional Description"
                                                                Width="97%" MaxLength="100"  data-trigger="hover" data-placement="top"
                                                                data-content="Enter Additional description (If Any)"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">

                                                    <button class="btn btn-app btn-success btn-mini radius-4" id="btnSubmitSeccon" runat="server" validationgroup="Grplead2" onserverclick ="btnSubmitSeccon_ServerClick">
                                                        Save
                                                    </button>
                                                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclearSeccon" runat="server" onserverclick ="btnclearSeccon_ServerClick">
                                                        Cancel
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
            <!--END PAGE CONTENT FOR ADD LEAD-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
