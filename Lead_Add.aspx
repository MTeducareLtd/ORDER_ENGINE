<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Lead_Add.aspx.cs" Inherits="Lead_Add" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .uppercase
        {
            text-transform: uppercase;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label>  </a> <span class="divider"><i
                class="icon-angle-right"></i></span></li>
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
            <button data-toggle="dropdown" class="btn btn-danger btn-small dropdown-toggle">Action <span class="caret"></span></button>
            <ul class="dropdown-menu dropdown-yellow pull-right dropdown-caret dropdown-close">
                <li><a href="#" id="btnsearchlead" runat="server" onserverclick ="btnsearchlead_ServerClick">Search Lead</a> </li>
                <li><a href="#" id="btnaddlead" runat="server" onserverclick ="btnaddlead_ServerClick">Add Lead</a></li>
                      
            </ul>
        </div>


        <!--#nav-search-->
    </div>
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
            <div class="alert alert-block alert-success fade in" id="divsuccessmessage1" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                </button>
                <h4 class="alert-heading">
                    <strong>
                        <asp:Label ID="lblleadscuccess" runat="server"></asp:Label></strong></h4>
                <p>
                    Add Secondary Contact to a lead</p>
                <p>
                    <button class="btn btn-app btn-success btn-mini radius-4" id="btnaddseccon" runat="server"
                        onserverclick="btnaddseccon_ServerClick">
                        Yes <i class="m-icon-swapright m-icon-white"></i>
                    </button>
                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btncancelseccon" runat="server"
                        onserverclick="btncancelseccon_ServerClick">
                        No <i class="m-icon-swapright m-icon-white"></i>
                    </button>
                  
                </p>
            </div>
            <!--BEGIN PAGE CONTENT FOR ADD LEAD -->
            <asp:UpdatePanel ID="upnlsearch" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- BEGIN PAGE CONTENT FOR ADD LEAD-->
                    <div class="row-fluid">
                        <div class="span12">
                            <div id="Div2" class="tab-pane active">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Basic Data
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Lead Date
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txt1" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Lead Type
                                                        <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        &nbsp;
                                                        <span class="help-button ace-popover" data-trigger="hover" data-placement="right" data-content="Type of the lead"
                                                        title="Lead Type">?</span>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlleadtypeadd" runat="server" Width="215px" CssClass="chzn-select"
                                                            ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead type"
                                                            TabIndex="1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlleadtypeadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Lead Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Lead Source
                                                        <asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlleadsourceadd" runat="server" Width="215px" CssClass="chzn-select"
                                                            ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead Source"
                                                            TabIndex="2">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlleadsourceadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Lead Source"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Lead Status
                                                        <asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlleadstatusadd" runat="server" Width="215px" CssClass="chzn-select"
                                                            ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead Status"
                                                            TabIndex="3">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="ddlleadstatusadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Lead Status"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%" id="td11" runat="server" visible="false">
                                                        Campaign ID
                                                    </td>
                                                    <td width="20%" id="td12" runat="server" visible="false">
                                                        <asp:DropDownList ID="ddlcampaignid" runat="server" Width="215px" CssClass="chzn-select"
                                                            TabIndex="4">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Source Description
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:TextBox ID="txtsourcedesc" runat="server" MaxLength="200" Width="90%" placeholder="Free Text"
                                                            TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- Primary Contact Type  -->
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Primary Contact
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Contact Type
                                                        <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcontacttype1" AutoPostBack="true" Width="215px" runat="server"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" data-trigger="hover" data-placement="top"
                                                            data-content="Select Contact Type" OnSelectedIndexChanged="ddlcontacttype1_SelectedIndexChanged1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlcontacttype1"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Title
                                                        <asp:Label ID="label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan="3">
                                                        <asp:DropDownList ID="ddltitle" runat="server" Width="215px" CssClass="chzn-select"
                                                            ValidationGroup="Grplead">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                            <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="ddltitle"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Title"
                                                            InitialValue="0" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        First Name
                                                        <asp:Label ID="label12" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtfirstname" runat="server" Width="205px" ValidationGroup="Grplead"
                                                            placeholder="First Name" CssClass="uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="r2" ControlToValidate="txtfirstname" Text="#" runat="server"
                                                            ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Name" />
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtfirstname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />--%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server"
                                                            ControlToValidate="txtfirstname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                    <td width="10%">
                                                        Middle Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtmidname" runat="server" Width="205px" ValidationGroup="Grplead"
                                                            placeholder="Middle Name" CssClass="uppercase"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator2" ControlToValidate="txtmidname" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Middle Name" />
                                                        --%>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="txtmidname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        --%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server"
                                                            ControlToValidate="txtmidname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                    <td width="10%">
                                                        Last Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtlastname" runat="server" Width="205px" ValidationGroup="Grplead"
                                                            placeholder="Last Name" CssClass="uppercase"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator3" ControlToValidate="txtlastname" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Last Name" />
                                                        --%>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="txtlastname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        --%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                            ControlToValidate="txtlastname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Handphone 1
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txthandphone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                            ValidationGroup="Grplead" MaxLength="18"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator4" ControlToValidate="txthandphone1" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Handphone no." />
                                                        --%><asp:RegularExpressionValidator ID="RegularExpressionValidator26" ControlToValidate="txthandphone1"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <%--<asp:RegularExpressionValidator ID="regPhone" runat="server" ControlToValidate="txthandphone1" 
                                                            ValidationExpression="^(\(?\s*\d{3}\s*[\)\-\.]?\s*)?[2-9]\d{2}\s*[\-\.]\s*\d{4}$"
                                                            Text="Enter a valid phone number" ValidationGroup="Grplead" SetFocusOnError="true" />--%>
                                                        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ControlToValidate="txthandphone1"
                                                            ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                    </td>
                                                    <td width="10%">
                                                        Handphone 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txthandphone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                            ValidationGroup="Grplead" MaxLength="18"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txthandphone2"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                            ControlToValidate="txthandphone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                    </td>
                                                    <td width="10%">
                                                        Landline No.
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtlandline" runat="server" Width="205px" placeholder="Landline No."
                                                            ValidationGroup="Grplead" MaxLength="18"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator34" ControlToValidate ="txtlandline" Text ="#" runat ="server" ValidationGroup ="Grplead" SetFocusOnError ="true" ErrorMessage ="Please Enter Only Numbers" ValidationExpression="^(?:([0-9#*])(?!(?:,-.)*,\1)(?:,-|$))+$"></asp:RegularExpressionValidator>
                                                        --%>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtlandline" ErrorMessage="Handphone length must be between 7 to 18 characters"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[0-9]{7,18}$" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Gender
                                                        <asp:Label ID="label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlgenderadd" runat="server" Width="205px" CssClass="chzn-select"
                                                            ValidationGroup="Grplead">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlgenderadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                            InitialValue="0" />
                                                    </td>
                                                    <td width="10%">
                                                        DOB
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtdateofbirth" Width="205px" Placeholder="Date of Birth" runat="server"
                                                            ValidationGroup="val1"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdateofbirth"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="txtdateofbirth"
                                                            ValidationGroup="val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtdateofbirth"
                                                            ValidationGroup="val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date"
                                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                        <%--<asp:CompareValidator ID="compare1" runat ="server" ControlToValidate ="txtdateofbirth" Operator ="DataTypeCheck" Type ="Date" Text="#" SetFocusOnError="True"  ValidationGroup="val1" ErrorMessage="Invalid Date"></asp:CompareValidator>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Email id
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtemailid" runat="server" Width="205px" placeholder="Email Id"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator1" ControlToValidate="txtemailid"  runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Email Address" Text="*" />
                                                        --%><asp:RegularExpressionValidator ID="EmailIDValidation" runat="server" ControlToValidate="txtemailid"
                                                            ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="Grplead" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Address Line 1
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtflatno" runat="server" Width="205px" placeholder="Address Line 1"
                                                            CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Address Line 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtbuildingno" runat="server" Width="205px" placeholder="Address Line 2"
                                                            CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Street Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtstreetname" runat="server" Width="205px" placeholder="Street Name"
                                                            CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <tr>
                                                        <td width="10%">
                                                            Country
                                                            <asp:Label ID="label37" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlcountry" runat="server" Width="215px" CssClass="chzn-select"
                                                                AutoPostBack="true" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator555" ControlToValidate="ddlcountry"
                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Country"
                                                                InitialValue="Select" />
                                                        </td>
                                                        <td width="10%">
                                                            State
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlstate" runat="server" Width="215px" CssClass="chzn-select"
                                                                AutoPostBack="true" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator id="RequiredFieldValidator6" ControlToValidate="ddlstate" Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True"  ErrorMessage="Select State" InitialValue="Select" />
                                                            --%>
                                                        </td>
                                                        <td width="10%">
                                                            City
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlcity" runat="server" AutoPostBack="true" Width="215px" CssClass="chzn-select"
                                                                ValidationGroup="Grplead" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator id="RequiredFieldValidator7" ControlToValidate="ddlcity" Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True"  ErrorMessage="Select City" InitialValue="Select" />
                                                            --%>
                                                        </td>
                                                    </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Location
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllocation" runat="server" Width="215px" CssClass="chzn-select" ValidationGroup="val1">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Postal Code
                                                    </td>
                                                    <td width="20%" colspan="3">
                                                        <asp:TextBox ID="txtpincode" runat="server" placeholder="Postal Code" MaxLength="10"
                                                            ValidationGroup="Grplead" Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtpincode"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                            ErrorMessage="Pincode length must be of 6 Character" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ControlToValidate="txtpincode" ValidationExpression="^[0-9]{6,10}$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Course Interested In
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtproductInterested" runat="server" placeholder="Course Interested"
                                                            ValidationGroup="Grplead" Width="205px" data-trigger="hover" data-placement="top"
                                                            data-content="Enter Course Interested in" CssClass="uppercase"></asp:TextBox>
                                                        <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator31" ControlToValidate="txtproductInterested" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Course Interested In" />
                                                        --%>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtproductInterested" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[\w\s]*$" />
                                                        --%>
                                                    </td>
                                                    <td width="10%">
                                                        Expected Joining Acad. Year
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlacademicyear" runat="server" Width="215px" CssClass="chzn-select" ValidationGroup="Grplead"
                                                            data-trigger="hover" data-placement="top" data-content="Select Expected Joining Academic Year">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator39" ControlToValidate="ddlacademicyear" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True"  ErrorMessage="Select Expected Joining Current Academic Year" InitialValue="Select" />
                                                        --%>
                                                    </td>
                                                    <td width="10%">
                                                        Expected Joining Date
                                                        <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtExpjoindate" placeholder="Expected Joining Date" runat="server"
                                                            Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtExpjoindate"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ControlToValidate="txtExpjoindate"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Expected Join Date" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtExpjoindate"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lbldateerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Student Academic Information
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Institution Type
                                                        <asp:Label ID="label18" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlinstitutiontype" runat="server" AutoPostBack="true" Width="215px" CssClass="chzn-select"
                                                            ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select Institution Type"
                                                            OnSelectedIndexChanged="ddlinstitutiontype_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ControlToValidate="ddlinstitutiontype"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Institution Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Institution Name
                                                        <asp:Label ID="label19" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtnameofinstitution" runat="server" placeholder="Institution name"
                                                            MaxLength="100" Width="205px" ValidationGroup="Grplead" data-trigger="hover" data-placement="top"
                                                            data-content="Enter Institution Name" CssClass ="uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" ControlToValidate="txtnameofinstitution"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Institution Name" />
                                                    </td>
                                                    <td width="10%">
                                                        Board / University
                                                        <asp:Label ID="label21" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlboard" runat="server" CssClass="chzn-select" Width="215px" ValidationGroup="Grplead"
                                                            data-trigger="hover" data-placement="top" data-content="Select Board / University">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" ControlToValidate="ddlboard"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Board / University "
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Current Standard
                                                        <asp:Label ID="label20" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcurrentstudying" Width="215px" runat="server" CssClass="chzn-select" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" ControlToValidate="ddlcurrentstudying"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Current Studying in "
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Division / Section
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsection" Width="215px" runat="server" CssClass="chzn-select" ValidationGroup="Grplead"
                                                            data-trigger="hover" data-placement="top" data-content="Select Division / Section / Grade">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Year of Passing
                                                        <asp:Label ID="label23" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlyearofpassing" Width="215px" runat="server" CssClass="chzn-select" ValidationGroup="Grplead"
                                                            data-trigger="hover" data-placement="top" data-content="Select Year of Passing">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ControlToValidate="ddlyearofpassing"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Year of Passing"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Current Year of Education<asp:Label ID="label38" runat="server" ForeColor="#FF3300"
                                                            Text=" *"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcurrentyeareducation" Width="215px" runat="server" ValidationGroup="Grplead"
                                                            CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Examination Details
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtexaminationdetails" runat="server" data-content="Enter Examination Details"
                                                            data-placement="top" data-trigger="hover" Placeholder="Examination Details" 
                                                            ValidationGroup="Val4" Width="205px"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Customer Type<asp:Label ID="label25" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstudenttypeadd" runat="server" AutoPostBack="true" data-content="Select Student Type"
                                                            data-placement="top" data-trigger="hover" Width="215px" ValidationGroup="Grplead"
                                                            CssClass="chzn-select" OnSelectedIndexChanged="ddlstudenttypeadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlstudenttypeadd"
                                                            ErrorMessage="Select Student Type" InitialValue="Select" SetFocusOnError="True"
                                                            Text="#" ValidationGroup="Grplead" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%" id="tdstudentid" runat="server">
                                                        Student ID
                                                    </td>
                                                    <td width="20%" id="tdstudentid1" runat="server">
                                                        <asp:TextBox ID="txtstudentid" runat="server" placeholder="Student Id" MaxLength="20"
                                                            Width="205px" ValidationGroup="Grplead" data-trigger="hover" data-placement="top"
                                                            data-content="Enter Student Id"></asp:TextBox>
                                                    </td>
                                                    <td width="10%" id="tdlastcourse" runat="server">
                                                        Last Course Opted
                                                    </td>
                                                    <td width="20%" id="tdlastcourse1" runat="server">
                                                        <asp:TextBox ID="txtlastcourseopted" runat="server" placeholder="Last Course Opted"
                                                            Width="205px" ValidationGroup="Grplead" data-trigger="hover" data-placement="top"
                                                            data-content="Enter Last Course Opted at MTeducare"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Notes, If Any
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtadditiondesc" runat="server" placeholder="Additional Information"
                                                            Width="90%" MaxLength="100" data-trigger="hover" data-placement="top" data-content="Enter Additional Information"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="tr1" runat="server">
                                                    <td width="10%">
                                                        Score
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtscore" runat="server" Width="205px" MaxLength="6"
                                                            ValidationGroup="Grplead" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" ControlToValidate="txtscore"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Percentile
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtpercentage" runat="server" Width="205px" MaxLength="5"
                                                            ValidationGroup="Grplead" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtpercentage"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Area Rank
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtarearank" runat="server" MaxLength="5" Width="205px"
                                                            ValidationGroup="Grplead" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" ControlToValidate="txtarearank"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr id="tr2" runat="server">
                                                    <td width="10%">
                                                        Overall Rank
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtoverallrank" runat="server" MaxLength="5" Width="205px"
                                                            ValidationGroup="Grplead" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20" ControlToValidate="txtoverallrank"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Score Range Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlscorerange" Width="215px" runat="server" CssClass="chzn-select"
                                                            AutoPostBack="true" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Interested Discipline
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldiscipline" Width="215px" runat="server" CssClass="chzn-select"
                                                            AutoPostBack="true" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="tr3" runat="server">
                                                    <td width="10%">
                                                        Field Interested
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlfieldint" Width="215px" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Competitive Exams
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtcompetitiveexams" Width="215px" runat="server"  ValidationGroup="Grplead"></asp:TextBox>
                                                    </td>
                                                    <td width="30%" colspan="2">
                                                        <asp:Label ID="lblmstotal" runat="server" Text="M-S Total"></asp:Label>&nbsp;
                                                        <asp:TextBox ID="txtmsmarks" runat="server" TabIndex="47" Width="25%" MaxLength="3"
                                                            ValidationGroup="Grplead" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" ControlToValidate="txtmsmarks"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>&nbsp;&nbsp;
                                                        <asp:Label ID="Label1" runat="server" Text="M-S Obtained"></asp:Label>&nbsp;
                                                        <asp:TextBox ID="txtmsobtained" TabIndex="48" runat="server" Width="25%" MaxLength="3"
                                                            ValidationGroup="Grplead" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator28" ControlToValidate="txtmsobtained"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover" id="tblorgassign"
                                                runat="server">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Organization Assignments
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr id="trSourcecompany" runat="server">
                                                    <td width="10%">
                                                        Source Company<asp:Label ID="label28" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsourcecompanyadd" Width="215px" runat="server" AutoPostBack="true"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlcompanyadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlsourcecompanyadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Company"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr id="tblrow1" runat="server">
                                                    <td width="10%">
                                                        Source Division
                                                        <asp:Label ID="label29" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlSourcedivisionadd" Width="215px" runat="server" AutoPostBack="true"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlSourcedivisionadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="ddlSourcedivisionadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Division"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Source Area/Zone
                                                        <asp:Label ID="label30" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlSourcezoneadd" Width="215px" runat="server" AutoPostBack="true"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlSourcezoneadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="ddlSourcezoneadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Zone"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Source Center
                                                        <asp:Label ID="label31" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlSourcecenteradd" Width="215px" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlSourcecenteradd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Center"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr id="trtargetcompany" runat="server">
                                                    <td width="10%">
                                                        Target Company<asp:Label ID="label2" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddltargetcompanyadd" Width="215px" runat="server" AutoPostBack="true"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddltargetcompanyadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddltargetcompanyadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Company"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr id="trtargetrow2" runat="server">
                                                    <td width="10%">
                                                        Target Division
                                                        <asp:Label ID="label32" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddltargetdivisionadd" Width="215px" runat="server" AutoPostBack="true"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddltargetdivisionadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="ddltargetdivisionadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Division"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Target Area/Zone
                                                        <asp:Label ID="label33" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddltargetzoneadd" Width="215px" runat="server" AutoPostBack="true"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddltargetzoneadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="ddltargetzoneadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Zone"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Target Center
                                                        <asp:Label ID="label34" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddltargetcenteradd" Width="215px" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="ddltargetcenteradd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Center"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr id="tr11" runat="server" visible="false">
                                                    <%--<td width="10%">Role</td>
                                                <td width="20%"><asp:DropDownList ID="ddlrole" runat ="server" AutoPostBack ="true" Width="86%" ValidationGroup ="Grplead"></asp:DropDownList></td>--%>
                                                    <td width="10%">
                                                        Assigned To
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtassignedto" runat="server" Width="205px" MaxLength="6"
                                                            ValidationGroup="Grplead" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="txtassignedto"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Assign Contact to User" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:DataList ID="dlScore" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                Style="height: 100px; overflow: Auto">
                                                <HeaderTemplate>
                                                    <b>Score Type</b></th>
                                                    <th>
                                                        Score
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblscoretypedesc" Text='<%#DataBinder.Eval(Container.DataItem, "Score_Type_Short_Desc")%>'
                                                        runat="server"></asp:Label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtscore" runat="server" Text="0" Width="205px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="txtscore"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Field Cannot be blank" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtscore"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lblscoreid" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>'
                                                            runat="server" Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            <asp:CheckBox ID="chkmaindevicedetails" runat="server" Checked="true" OnCheckedChanged="chkmaindevicedetails_CheckedChanged"
                                                                AutoPostBack="true" /><span class="lbl"> <strong>Devices & Storage</strong>
                                                            </span>
                                                        </th>
                                                    </tr>
                                                </thead>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                id="tblrobodetails">
                                                <tr>
                                                    <td width="10%">
                                                        User Device
                                                        <asp:Label ID="label24" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldevice" runat="server" Width="215px" CssClass="chzn-select"
                                                            AutoPostBack="true" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddldevice"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Provided by
                                                        <asp:Label ID="label26" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlprovidedby" runat="server" Width="215px" CssClass="chzn-select"
                                                            AutoPostBack="true" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlprovidedby"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device Provided by"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Owned by
                                                        <asp:Label ID="label27" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlownedby" runat="server" Width="215px" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlownedby"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device Owned by"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Platform / OS
                                                        <asp:Label ID="label35" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlplatform" runat="server" Width="215px" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="ddlplatform"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device Platform"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Device Brand
                                                        <asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldevicebrand" runat="server" Width="215px" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead" OnSelectedIndexChanged="ddldevicebrand_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="ddldevicebrand"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device Brand"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Other Brand
                                                        <asp:Label ID="label39" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtotherbrand" runat="server" Width="205px" placeholder="Other Brand" Enabled="false"
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ControlToValidate="txtotherbrand"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Brand"
                                                            Enabled="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Device Model
                                                        <asp:Label ID="label41" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtdevicemodel" runat="server" placeholder="Enter the model number"
                                                            ValidationGroup="Grplead" Width="205px" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" ControlToValidate="txtdevicemodel"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Device Model" />
                                                    </td>
                                                    <td width="10%">
                                                        Device Config
                                                        <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan="3">
                                                        <asp:TextBox ID="txtdeviceconfig" runat="server" placeholder="Enter processor speed, RAM, Storage Capacity"
                                                            ValidationGroup="Grplead" Width="83%" CssClass="uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="txtdeviceconfig"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Device Configuration" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Access Mode
                                                        <asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlaccessmode" runat="server" Width="215px" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddlaccessmode"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Access Mode"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Storage Media Type
                                                        <asp:Label ID="label43" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstoragemediatype" runat="server" Width="215px" CssClass="chzn-select"
                                                            AutoPostBack="true" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="ddlstoragemediatype"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Storage Media"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Capacity
                                                        <asp:Label ID="label44" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcapacity" runat="server" Width="215px" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead">
                                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="8" Text="8 GB"></asp:ListItem>
                                                            <asp:ListItem Value="16" Text="16 GB"></asp:ListItem>
                                                            <asp:ListItem Value="32" Text="32 GB"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="ddlcapacity"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Storage Capacity"
                                                            InitialValue="0" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        HDD Free Space
                                                        <asp:Label ID="label45" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan="3">
                                                        <asp:TextBox ID="txthddfreespace" runat="server" placeholder="Enter Free Space required  in HDD for the product e.g. 40GB"
                                                            ValidationGroup="Grplead" Width="83%" CssClass="uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="txthddfreespace"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Free Space Available on HDD" />
                                                    </td>
                                                    <td width="10%">
                                                        No. of Storage Media required
                                                        <%--<asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlnoofstorage" runat="server" Width="215px" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead">
                                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator28" ControlToValidate="ddlnoofstorage"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Number of Storage"
                                                            InitialValue="0" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Special Instruction 1
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtsi1" runat="server" placeholder="Special Instruction 1" ValidationGroup="Grplead"
                                                            Width="90%" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Special Instruction 2
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtsi2" runat="server" placeholder="Special Instruction 2" ValidationGroup="Grplead"
                                                            Width="90%" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Special Instruction 3
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtsi3" runat="server" placeholder="Special Instruction 3" ValidationGroup="Grplead"
                                                            Width="90%" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                id="tblrobodetails1">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Maintain Installation Details
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Installation Location
                                                        <asp:Label ID="label47" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlinstallationlocation" Width="215px" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead">
                                                            <asp:ListItem Value="00" Text="Select" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="01" Text="Home"></asp:ListItem>
                                                            <asp:ListItem Value="02" Text="Center"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="ddlinstallationlocation"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Installation Location"
                                                            InitialValue="00" />
                                                    </td>
                                                    <td width="10%">
                                                        Appointment Date
                                                        <asp:Label ID="label48" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <div class="row-fluid input-append date">
                                                            <asp:TextBox ID="date_picker" Placeholder="Appointment Date" runat="server" Width="215px"
                                                                ValidationGroup="Grplead"></asp:TextBox>
                                                            <CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker"
                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                            </CC1:CalendarExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                                ControlToValidate="date_picker" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                                ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                            <asp:Label ID="Label15" runat="server" ForeColor="#FF3300"></asp:Label>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                                ControlToValidate="date_picker" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                                ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="date_picker"
                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Appointment Date" />
                                                        </div>
                                                    </td>
                                                    <td width="10%">
                                                        Appointment time
                                                        <asp:Label ID="label49" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <div class="input-append bootstrap-timepicker">
                                                            <input readonly="readonly" runat="server" class="timepicker span8" name="timepicker"
                                                                id="timepicker1" placeholder="Select Time" data-placement="bottom" data-original-title="timepicker"
                                                                validationgroup="Grplead" />
                                                            <span class="add-on"><i class="icon-time"></i></span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="timepicker1"
                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Appointment Time" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Installation Date
                                                        <asp:Label ID="label50" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <div class="row-fluid input-append date">
                                                            <asp:TextBox ID="date_picker1"  Placeholder="Installation Date" runat="server"
                                                                Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                            <CC1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker1"
                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                            </CC1:CalendarExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server"
                                                                ControlToValidate="date_picker1" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                                ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                            <asp:Label ID="Label16" runat="server" ForeColor="#FF3300"></asp:Label>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server"
                                                                ControlToValidate="date_picker1" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                                ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="date_picker1"
                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Installation Date" />
                                                        </div>
                                                    </td>
                                                    <td width="10%">
                                                        Installation time
                                                        <asp:Label ID="label52" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <div class="input-append bootstrap-timepicker">
                                                            <%--<input id="timepicker2" type="text" class="input-small" runat ="server" />--%>
                                                            <input readonly="readonly" runat="server" class="timepicker span8" name="timepicker"
                                                                id="timepicker2" placeholder="Select Time" data-placement="bottom" data-original-title="timepicker"
                                                                validationgroup="Grplead" />
                                                            <span class="add-on"><i class="icon-time"></i></span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="timepicker2"
                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Installation Time" />
                                                        </div>
                                                    </td>
                                                    <td width="10%">
                                                        Installation Status
                                                        <asp:Label ID="label51" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlinstallationstatus" runat="server" Width="215px" CssClass="chzn-select"
                                                            ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="ddlinstallationstatus"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Installation Status"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Rescheduled Date
                                                    </td>
                                                    <td width="20%">
                                                        <div class="row-fluid input-append date">
                                                            <asp:TextBox ID="date_picker2"  Placeholder="Rescheduled Date" runat="server"
                                                                Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                            <CC1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker2"
                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                            </CC1:CalendarExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server"
                                                                ControlToValidate="date_picker2" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                                ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                            <asp:Label ID="Label22" runat="server" ForeColor="#FF3300"></asp:Label>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server"
                                                                ControlToValidate="date_picker2" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                                ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </td>
                                                    <td width="10%">
                                                        Rescheduled time
                                                    </td>
                                                    <td width="20%">
                                                        <div class="input-append bootstrap-timepicker">
                                                            <input readonly="readonly" runat="server" class="timepicker span8" name="timepicker"
                                                                id="timepicker3" placeholder="Select Time" data-placement="bottom" data-original-title="timepicker" />
                                                            <%--<input id="timepicker3" type="text" class="input-small" runat ="server" />--%>
                                                            <span class="add-on"><i class="icon-time"></i></span>
                                                        </div>
                                                    </td>
                                                    <td width="10%">
                                                        Engineer Name
                                                        <asp:Label ID="label53" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtengineername" runat="server" placeholder="Engineer Name" ValidationGroup="Grplead" Width="205px"
                                                            CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="txtengineername"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer Name" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Contact Number
                                                        <asp:Label ID="label54" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>&nbsp;
                                                        <span class="help-button ace-popover" data-trigger="hover" data-placement="right" data-content="Contact number of Engineer"
                                                        title="Contact Number">?</span>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtengineercontactnumber" runat="server" placeholder="Contact number of Engineer" Width="205px"
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator47" ControlToValidate="txtengineercontactnumber" Text="#" runat="server"
                                                            ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer Contact Number" />--%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator34" ControlToValidate="txtengineercontactnumber"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server"
                                                            ControlToValidate="txtengineercontactnumber" ErrorMessage="Contact Number length must be between 7 to 18 characters"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
                                                    </td>
                                                    <td width="10%">
                                                        Email Id
                                                        &nbsp;
                                                        <span class="help-button ace-popover" data-trigger="hover" data-placement="right" data-content="Email id of Engineer"
                                                        title="Email Id">?</span>
                                                       
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtengineeremailid" runat="server" placeholder="Email id of Engineer " Width="205px"
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server"
                                                            ControlToValidate="txtengineeremailid" ErrorMessage="Email Address Not Valid"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Grplead"
                                                            SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Company (Engineer)
                                                        <asp:Label ID="label56" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>&nbsp;
                                                        <span class="help-button ace-popover" data-trigger="hover" data-placement="right" data-content="Company Engineer belongs to"
                                                        title="Company (Engineer)">?</span>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtengineercompany" runat="server" placeholder="Company Engineer belongs to" Width="205px"
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="txtengineercompany"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer's Company Name" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnSubmitNewlead" runat="server"
                                                    validationgroup="Grplead" onserverclick="btnSubmitNewlead_ServerClick">
                                                    Save <i class="m-icon-swapright m-icon-white"></i>
                                                </button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclear" runat="server"
                                                    onserverclick="btnclear_ServerClick">
                                                    Close
                                                </button>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ValidationGroup="Grplead" ShowSummary="False" />
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
                    <asp:PostBackTrigger ControlID="btnSubmitNewlead" />
                </Triggers>
            </asp:UpdatePanel>
            <!--END PAGE CONTENT FOR ADD LEAD-->
            <!--BEGIN PAGE CONTENT FOR ADD SECONDARY CONTACT -->
            <asp:UpdatePanel ID="UpnlSecContact" runat="server">
                <ContentTemplate>
                    <!-- BEGIN PAGE CONTENT FOR ADD LEAD-->
                    <div class="row-fluid">
                        <div class="span12">
                            <div id="Div3" class="tab-pane active">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <!-- Secondary Contact Type  -->
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="5">
                                                            Secondary Contact
                                                        </th>
                                                        <th width="20%">
                                                            <%-- <asp:CheckBox ID="chkaddcopy" CssClass ="ace-checkbox-2" type="Checkbox" runat="server" Text=" Same As Primary Contact" AutoPostBack="true" />
                                                            --%>
                                                            <asp:CheckBox ID="chkaddcopy" runat="server" AutoPostBack="true" OnCheckedChanged="chkaddcopy_CheckedChanged" /><span
                                                                class="lbl"> Same As Primary Contact</span>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Contact Type
                                                        <asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlseccontacttype" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2"
                                                            data-trigger="hover" data-placement="top" data-content="Select Secondary Contact Type">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlseccontacttype"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Title
                                                        <asp:Label ID="label5" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsectitle" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
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
                                                        <asp:TextBox ID="txtsecfname" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="First Name" CssClass="uppercase"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txtsecfname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        --%><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtsecfname"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                                            ControlToValidate="txtsecfname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                    <td width="10%">
                                                        Middle Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecmname" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="Middle Name" CssClass="uppercase"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="txtsecmname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                        --%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server"
                                                            ControlToValidate="txtsecmname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                    <td width="10%">
                                                        Last Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtseclname" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="Last Name" CssClass="uppercase"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="txtseclname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        --%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server"
                                                            ControlToValidate="txtseclname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_']*$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Handphone 1
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsechandphone1" runat="server" Width="79%" placeholder="Handphone 1"
                                                            ValidationGroup="Grplead2" MaxLength="18"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtsechandphone1"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                            ControlToValidate="txtsechandphone1" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                            ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator6" ControlToValidate="txtsechandphone1" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone1" />
                                                        --%>
                                                    </td>
                                                    <td width="10%">
                                                        Handphone 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsechandphone2" runat="server" Width="79%" placeholder="Handphone 2"
                                                            ValidationGroup="Grplead2" MaxLength="18"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtseclandline" runat="server" Width="79%" placeholder="Landline No."
                                                            ValidationGroup="Grplead2" MaxLength="18"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate ="txtseclandline" Text ="#" runat ="server" ValidationGroup ="Grplead2" SetFocusOnError ="true" ErrorMessage ="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtseclandline" ErrorMessage="Handphone length must be between 7 to 18 characters"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[0-9]{7,18}$" />
                                                        --%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Address Line 1
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecaddress1" runat="server" Width="79%" placeholder="Address Line 1"
                                                            CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Address Line 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecaddress2" runat="server" Width="79%" placeholder="Address Line 2"
                                                            CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Street Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecStreetname" runat="server" Width="79%" placeholder="Street Name"
                                                            CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <tr>
                                                        <td width="10%">
                                                            Country
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlseccountry" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlseccountry_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            State
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlsecstate" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlSecstate_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            City
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlseccity" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlseccity_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Location
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlSeclocation" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Postal Code
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecpincode" runat="server" placeholder="Postal Code" MaxLength="10"
                                                            ValidationGroup="Grplead2" Width="79%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtsecpincode"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtsecpincode"
                                                            runat="server" ErrorMessage="Pincode length must be of 6-10 Character" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{6,10}$" />
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Gender
                                                        <asp:Label ID="label13" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsecgender" TabIndex="14" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead2">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlsecgender"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                            InitialValue="0" />
                                                    </td>
                                                    <td width="10%">
                                                        DOB
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecdob" Placeholder="Date of Birth" runat="server" Width="79%"
                                                            ValidationGroup="Grplead2"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtsecdob"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtsecdob"
                                                            ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- ](0[1-9]|1[012])[- ](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="Label14" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        Email id
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecemailid" runat="server" Width="79%" placeholder="Email Id"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtsecemailid"
                                                            ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
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
                                                        <asp:TextBox ID="txtadditiondesc2" runat="server" placeholder="Additional Description"
                                                            Width="94%" MaxLength="100" data-trigger="hover" data-placement="top" data-content="Enter Additional description (If Any)"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnSubmitSeccon" runat="server"
                                                    validationgroup="Grplead2" onserverclick="btnSubmitSeccon_ServerClick">
                                                    Save <i class="m-icon-swapright m-icon-white"></i>
                                                </button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclearSeccon" runat="server"
                                                    onserverclick="btnclearSeccon_ServerClick">
                                                    Close
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
                    <asp:PostBackTrigger ControlID="btnsearchlead" />
                </Triggers>
            </asp:UpdatePanel>
            <!--END PAGE CONTENT FOR ADD SECONDARY CONTACT-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
