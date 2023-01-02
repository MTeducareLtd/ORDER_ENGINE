<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Opportunity_Add.aspx.cs" Inherits="Opportunity_Add" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .uppercase
        {
            text-transform: uppercase;
        }
    </style>
    <!-- CODE CHECKED -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
        <div id="breadcrumbs" class="position-relative" style="height: 53px">
            <ul class="breadcrumb" style="height: 15px">
                <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                    class="icon-angle-right"></i></span></li>
                <li id="limidbreadcrumb" runat="server" visible="false"><a href="Opportunity.aspx">
                    <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a> <span class="divider">
                        <i class="icon-angle-right"></i></span></li>
                <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
                </i><a href="#">
                    <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
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
            <button data-toggle="dropdown" class="btn btn-danger btn-small dropdown-toggle">
                Action <span class="caret"></span>
            </button>
            <ul class="dropdown-menu dropdown-yellow pull-right dropdown-caret dropdown-close">
                <li><a href="#" id="btnsearchoppor" runat="server" onserverclick="btnsearchoppor_ServerClick">
                    Search Opportunity</a> </li>
                <li><a href="#" id="btnaddOpp" runat="server" >
                    Add New Opportunity</a></li>
                <li><a href="#" id="btnviewenrollment" runat="server" visible="false">View Enrollment</a></li>
            </ul>
        </div>
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
            <div class="alert alert-block alert-success fade in" id="divsuccessmessage1" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                </button>
                <h4 class="alert-heading">
                    <strong>
                        <asp:Label ID="lblleadscuccess" runat="server"></asp:Label></strong></h4>
                <p>
                    Add Secondary Contact to a Opportunity</p>
                <p>
                    <button class="btn btn-app btn-success btn-mini radius-4" id="btnaddseccon" runat="server" onserverclick="btnaddseccon_ServerClick">
                        Yes
                    </button>
                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btncancelseccon" runat="server" onserverclick="btncancelseccon_ServerClick">
                        No
                    </button>
                    <%--<button class="btn btn-app btn-primary btn-mini radius-4" id="btnproceedorder" runat="server" onserverclick="btnproceedorder_ServerClick">
                        Convert to Order
                    </button>--%>
                    
                </p>
                
            </div>
            <!-- BEGIN PAGE CONTENT FOR ADD OPPORTUNITY-->
            <asp:UpdatePanel ID="UpnlAdd" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="div1" runat="server">
                        <div class="span12">
                            <div id="Divadd" class="tab-pane active">
                                <div class="row-fluid" id="divadd" runat="server">
                                    <div class="span12">
                                        <div class="table-responsive">
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
                                                        Opportunity Date
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txt1" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Contact Type
                                                        <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcontacttype1" Width="215px" AutoPostBack="true" runat="server" data-placeholder="Select Type"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlcontacttype1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="ddlcontacttype1"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Source
                                                        <asp:Label ID="label26" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsaleschannel" Width="215px" runat="server" data-placeholder="Select Source"
                                                            CssClass="chzn-select" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlsaleschannel"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Contact Source"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Title
                                                        <asp:Label ID="label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddltitle" Width="215px" runat="server" data-placeholder="Select Title" CssClass="chzn-select"
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
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtfirstname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        --%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                            ControlToValidate="txtfirstname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                    <td width="10%">
                                                        Middle Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtmidname" runat="server" Width="205px" ValidationGroup="Grplead"
                                                            placeholder="Middle Name" CssClass="uppercase"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="txtmidname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        --%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                                            ControlToValidate="txtmidname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                    <td width="10%">
                                                        Last Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtlastname" runat="server" Width="205px" ValidationGroup="Grplead"
                                                            placeholder="Last Name" CssClass="uppercase"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtlastname" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                        --%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                            ControlToValidate="txtlastname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Handphone 1
                                                        <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txthandphone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                            ValidationGroup="Grplead" MaxLength="18"></asp:TextBox>
                                                        <asp:RequiredFieldValidator id="RequiredFieldValidator41111" ControlToValidate="txthandphone1" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Handphone no." />
                                                        <asp:RegularExpressionValidator ID="redquiredexpression5" ControlToValidate="txthandphone1"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                                                            ControlToValidate="txthandphone1" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                    </td>
                                                    <td width="10%">
                                                        Handphone 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txthandphone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                            ValidationGroup="Grplead" MaxLength="18"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txthandphone2"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                                            ControlToValidate="txthandphone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                    </td>
                                                    <td width="10%">
                                                        Landline No.
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtlandline" runat="server" Width="205px" placeholder="Landline No."
                                                            ValidationGroup="Grplead" MaxLength="18"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate ="txtlandline" Text ="#" runat ="server" ValidationGroup ="Grplead" SetFocusOnError ="true" ErrorMessage ="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtlandline" ErrorMessage="Handphone length must be between 7 to 18 characters"  ValidationGroup ="Grplead" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[0-9]{7,18}$" />
                                                        --%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Gender
                                                        <asp:Label ID="label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlgenderadd" runat="server" Width="215px" data-placeholder="Select Gender"
                                                            CssClass="chzn-select" ValidationGroup="Grplead">
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
                                                        <asp:TextBox ID="txtdateofbirth" Placeholder="Date of Birth" runat="server" Width="215px"
                                                            ValidationGroup="val1"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdateofbirth"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="txtdateofbirth"
                                                            ValidationGroup="val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        Email id
                                                        <asp:Label ID="label43" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtemailid" runat="server" Width="205px" placeholder="Email Id"></asp:TextBox>
                                                        <asp:RequiredFieldValidator id="RequiredFieldValidator1111" ControlToValidate="txtemailid"  runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Email Address" Text="*" />
                                                        <asp:RegularExpressionValidator ID="EmailIDValidation" runat="server" ControlToValidate="txtemailid"
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
                                                            data-trigger="hover" data-placement="top" data-content="Enter Address Line 1"
                                                            CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Address Line 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtbuildingno" runat="server" Width="205px" placeholder="Address Line 2"
                                                            data-trigger="hover" data-placement="top" data-content="Enter Address Line 2"
                                                            CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Street Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtstreetname" runat="server" Width="205px" placeholder="Street Name"
                                                            data-trigger="hover" data-placement="top" data-content="Enter Street Name" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <tr>
                                                        <td width="10%">
                                                            Country
                                                            <asp:Label ID="label27" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlcountry" runat="server" Width="215px" data-placeholder="Select Country"
                                                                CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator555" ControlToValidate="ddlcountry"
                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Country"
                                                                InitialValue="Select" />
                                                        </td>
                                                        <td width="10%">
                                                            State
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlstate" runat="server" Width="215px" data-placeholder="Select State" CssClass="chzn-select"
                                                                AutoPostBack="true" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            City
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlcity" runat="server" Width="215px" data-placeholder="Select City" CssClass="chzn-select"
                                                                AutoPostBack="true" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Location
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllocation" runat="server" Width="215px" data-placeholder="Select Location"
                                                            CssClass="chzn-select" ValidationGroup="val1">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Postal Code
                                                    </td>
                                                    <td width="20%" colspan ="3">
                                                        <asp:TextBox ID="txtpincode" runat="server" placeholder="Postal Code" MaxLength="10"
                                                            ValidationGroup="Grplead" Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtpincode"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Pincode length must be of 6-10 Character"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="true" ControlToValidate="txtpincode"
                                                            ValidationExpression="^[0-9]{6,10}$" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                                            ErrorMessage="Pincode length must be of 6-10 Character" ValidationGroup="Grplead"
                                                            Text="#" SetFocusOnError="true" ControlToValidate="txtpincode" ValidationExpression="^[0-9]{6,10}$" />
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
                                                        <asp:DropDownList ID="ddlinstitutiontype" Width="215px" runat="server" AutoPostBack="true" data-placeholder="Select Type"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" data-trigger="hover" data-placement="top"
                                                            data-content="Select Institution Type" OnSelectedIndexChanged="ddlinstitutiontype_SelectedIndexChanged">
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
                                                            data-content="Enter Institution Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" ControlToValidate="txtnameofinstitution"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Institution Name" />
                                                    </td>
                                                    <td width="10%">
                                                        Board / University
                                                        <asp:Label ID="label21" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlboard" runat="server" Width="215px" CssClass="chzn-select" ValidationGroup="Grplead"
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
                                                        <asp:DropDownList ID="ddlcurrentstudying" Width="215px" runat="server" data-placeholder="Select Standard"
                                                            CssClass="chzn-select" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" ControlToValidate="ddlcurrentstudying"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Current Studying in "
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Division / Section
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsection" Width="215px" runat="server" ValidationGroup="Grplead" data-placeholder="Select Division / Section"
                                                            CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Select Division / Section / Grade">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Year of Passing
                                                        <asp:Label ID="label23" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlyearofpassing" Width="215px" runat="server" ValidationGroup="Grplead"
                                                            data-placeholder="Select Year of Passing" CssClass="chzn-select" data-trigger="hover"
                                                            data-placement="top" data-content="Select Year of Passing">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ControlToValidate="ddlyearofpassing"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Year of Passing"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Examination Details
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtexaminationdetails" runat="server" Width="205px" ValidationGroup="Val4"
                                                            Placeholder="Examination Details" data-trigger="hover" data-placement="top" data-content="Enter Examination Details"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Customer Type
                                                        <asp:Label ID="label25" runat="server" Text="*" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan ="3">
                                                        <asp:DropDownList ID="ddlstudenttypeadd" runat="server" ValidationGroup="Grplead" Width="215px"
                                                            AutoPostBack="true" data-placeholder="Select Company" CssClass="chzn-select"
                                                            data-trigger="hover" data-placement="top" data-content="Select Student Type"
                                                            OnSelectedIndexChanged="ddlstudenttypeadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="ddlstudenttypeadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Student Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%" id="tdstudentid" runat="server">
                                                        Student ID
                                                    </td>
                                                    <td width="20%" id="tdstudentid1" runat="server">
                                                        <asp:TextBox ID="txtstudentid" runat="server" placeholder="Student Id" MaxLength="20"
                                                            Width="205px" ValidationGroup="Grplead" data-trigger="hover" data-placement="top"
                                                            data-content="Enter Student Id" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                    <td width="10%" id="tdlastcourse" runat="server">
                                                        Last Course Opted
                                                    </td>
                                                    <td width="20%" id="tdlastcourse1" runat="server" colspan ="3">
                                                        <asp:TextBox ID="txtlastcourseopted" runat="server" placeholder="Last Course Opted"
                                                            Width="205px" ValidationGroup="Grplead" data-trigger="hover" data-placement="top"
                                                            data-content="Enter Last Course Opted at MTeducare" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Notes, If Any
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtadditiondesc" runat="server" placeholder="Additional Information"
                                                            Width="94%" MaxLength="100" data-trigger="hover" data-placement="top" data-content="Enter Additional Information"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="tr1" runat="server">
                                                    <td width="10%">
                                                        Score
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtscore" runat="server" Width="205px" MaxLength="6" ValidationGroup="Grplead"
                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator29" ControlToValidate="txtscore"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Percentile
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtpercentage" runat="server" Width="205px" MaxLength="5" ValidationGroup="Grplead"
                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator30" ControlToValidate="txtpercentage"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Area Rank
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtarearank" runat="server" MaxLength="5" Width="205px" ValidationGroup="Grplead"
                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator31" ControlToValidate="txtarearank"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr id="tr2" runat="server">
                                                    <td width="10%">
                                                        Overall Rank
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtoverallrank" runat="server" MaxLength="5" Width="205px" ValidationGroup="Grplead"
                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator32" ControlToValidate="txtoverallrank"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Score Range Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlscorerange" runat="server" data-placeholder="Select Type"
                                                            CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Interested Discipline
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldiscipline" runat="server" data-placeholder="Select Discipline"
                                                            CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" OnSelectedIndexChanged="ddldiscipline_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="tr3" runat="server">
                                                    <td width="10%">
                                                        Field Interested
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlfieldint" runat="server" data-placeholder="Select Field Interested"
                                                            CssClass="chzn-select" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Competitive Exams
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtcompetitiveexams" runat="server" Width="86%" ValidationGroup="Grplead"></asp:TextBox>
                                                    </td>
                                                    <td width="30%" colspan="2">
                                                        <asp:Label ID="lblmstotal" runat="server" Text="M-S Total"></asp:Label>&nbsp;
                                                        <asp:TextBox ID="txtmsmarks" runat="server" Width="25%" MaxLength="3" ValidationGroup="Grplead"
                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator33" ControlToValidate="txtmsmarks"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>&nbsp;&nbsp;
                                                        <asp:Label ID="Label14" runat="server" Text="M-S Obtained"></asp:Label>&nbsp;
                                                        <asp:TextBox ID="txtmsobtained" runat="server" Width="25%" MaxLength="3" ValidationGroup="Grplead"
                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator34" ControlToValidate="txtmsobtained"
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
                                                    <td width="20%" colspan ="5">
                                                        <asp:DropDownList ID="ddlsourcecompanyadd" runat="server" AutoPostBack="true" data-placeholder="Select Source Company"
                                                            CssClass="chzn-select" Width="215px" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlcompanyadd_SelectedIndexChanged">
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
                                                        <asp:DropDownList ID="ddlSourcedivisionadd" Width="215px" runat="server" AutoPostBack="true" data-placeholder="Select Source Division"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlSourcedivisionadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="ddlSourcedivisionadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Division"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Source Area / Zone
                                                        <asp:Label ID="label30" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlSourcezoneadd" Width="215px" runat="server" AutoPostBack="true" data-placeholder="Select Source Area"
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
                                                        <asp:DropDownList ID="ddlSourcecenteradd" Width="215px" runat="server" data-placeholder="Select Source Center"
                                                            CssClass="chzn-select" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlSourcecenteradd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Center"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr id="trtargetcompany" runat="server">
                                                    <td width="10%">
                                                        Target Company<asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan ="5">
                                                        <asp:DropDownList ID="ddltargetcompanyadd" runat="server" Width="215px" AutoPostBack="true" data-placeholder="Select Target Company"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddltargetcompanyadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddltargetcompanyadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Company"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Target Division
                                                        <asp:Label ID="label32" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddltargetdivisionadd" runat="server" AutoPostBack="true" data-placeholder="Select Target Division"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddltargetdivisionadd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="ddltargetdivisionadd"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Division"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Target Area / Zone
                                                        <asp:Label ID="label33" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddltargetzoneadd" runat="server" AutoPostBack="true" data-placeholder="Select Target Area"
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
                                                        <asp:DropDownList ID="ddltargetcenteradd" runat="server" data-placeholder="Select Target Center"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" AutoPostBack="true" OnSelectedIndexChanged="ddltargetcenter_SelectedIndexChanged">
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
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="205px" MaxLength="6" ValidationGroup="Grplead"
                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="txtassignedto"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Assign Contact to User" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Opportunity Details
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Product Category
                                                        <asp:Label ID="label1" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlAddProductCategory" Width="215px"  runat="server" data-placeholder="Select Category"
                                                            CssClass="chzn-select" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlAddProductCategory"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Product Category"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Acad. Year
                                                        <asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlacademicyear" Width="215px" runat="server" data-placeholder="Select Acad Year"
                                                            CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged"
                                                            ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="ddlacademicyear"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Current Academic Year"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Product Name
                                                        <asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlproduct"  Width="215px" runat="server" data-placeholder="Select Product Name"
                                                            CssClass="chzn-select" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="ddlproduct"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Product"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Sales Stage
                                                        <asp:Label ID="label2" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlAddSalesStage" Width="215px" runat="server" data-placeholder="Select Sales Stage"
                                                            CssClass="chzn-select" ValidationGroup="Grplead" AutoPostBack="true" OnSelectedIndexChanged="ddlAddSalesStage_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlAddSalesStage"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Sales Stage"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%" id="tdapplicationno" runat="server">
                                                        App. Form No
                                                        <asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" id="tdapplicationno1" runat="server">
                                                        <asp:TextBox ID="txtapplicationno" runat="server" Enabled="False" MaxLength="5" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"
                                                            ToolTip="Enter Application No" ValidationGroup="Grplead" Width="205px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" ControlToValidate="txtapplicationno"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lblappnoerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        Probability %
                                                        <asp:Label ID="label13" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtprobabilitypercent" runat="server" MaxLength="2" ValidationGroup="Grplead"
                                                            Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtprobabilitypercent"
                                                            ErrorMessage="Enter Probability Percent of Conversion" SetFocusOnError="True"
                                                            Text="#" ValidationGroup="Grplead" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtprobabilitypercent"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Expected DoJ
                                                        <asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtjoindate" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtjoindate"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtjoindate"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Join Date" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtjoindate"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lbldateerrorJoindate" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        Exp. Closure date
                                                        <asp:Label ID="label5" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan="3">
                                                        <asp:TextBox ID="txtexpectedclosedate" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexpectedclosedate"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="txtexpectedclosedate"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Expected Closure Date" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtexpectedclosedate"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="lbldateerrorexp" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    
                                                </tr>
                                               
                                                <tr>
                                                    <td width="10%">
                                                        Discount Offered
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtdiscount" ToolTip="Enter Discount" runat="server" Width="205px"
                                                            ValidationGroup="Grplead" MaxLength="10" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                    </td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtdiscount"
                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                        ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                    <td width="10%">
                                                        Discount Notes
                                                    </td>
                                                    <td width="70%" colspan="4">
                                                        <asp:TextBox ID="txtdiscountnotes" runat="server" Width="94%" ValidationGroup="Grplead"
                                                            placeholder="Free Text"></asp:TextBox>
                                                    </td>
                                                    <td width="10%" id="td70" runat="server" visible="false">
                                                        Assigned To
                                                        <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" id="td71" runat="server" visible="false">
                                                        <asp:TextBox ID="txtassignedto" runat="server" Width="205px" ValidationGroup="Grplead"
                                                            ToolTip="Enter User ID" MaxLength="6" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator49" ControlToValidate="txtassignedto"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Assign Lead" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtassignedto"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover" width="80% !important">
                                                <tr>
                                                    <th colspan="6">
                                                      <asp:CheckBox ID="ckhBranchTopper" runat="server" AutoPostBack="true" 
                                                            oncheckedchanged="ckhBranchTopper_CheckedChanged" />
                                                      <span class="lbl">
                                                                </span>  Branch Topper for Standard X
                                                    </th>
                                                </tr>
                                                <tr id="trBranchTopper" runat="server" visible="false">
                                                    <td align="left" style="text-align: left">
                                                        Division <asp:Label ID="label39" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        <asp:DropDownList ID="ddlbranchtopperdivision" runat="server" CssClass="chzn-select"
                                                            AutoPostBack="True" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlbranchtopperdivision_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlbranchtopperdivision"
                                                            Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Branch Division"
                                                            InitialValue="Select" Display="None" />
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        Center <asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left"   colspan="3">
                                                        <asp:DropDownList ID="ddlbranchtopperCenter" runat="server" CssClass="chzn-select"
                                                            AutoPostBack="True" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlbranchtopperCenter"
                                                            Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Center"
                                                            InitialValue="Select" Display="None" />
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <th colspan="6">
                                                      <asp:CheckBox ID="chkSchoolRanker" runat="server" AutoPostBack="true" 
                                                            oncheckedchanged="chkSchoolRanker_CheckedChanged" />
                                                      <span class="lbl">  </span>
                                                      
                                                      School Ranker for Standard X
                                                    </th>
                                                </tr>
                                                <tr runat="server" visible="false" id="trSchoolRanker">
                                                    <td align="left" style="text-align: left">
                                                        School Name <asp:Label ID="label37" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        <asp:DropDownList ID="ddlschoolranker" runat="server" CssClass="chzn-select" ValidationGroup="Grplead">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlschoolranker"
                                                            Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select School"
                                                            InitialValue="Select" Display="None" />
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        School Division <asp:Label ID="label38" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        <asp:TextBox ID="txtschooldivision" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtschooldivision"
                                                                Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter School Division"
                                                                InitialValue="" Display="None" />
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        Rank <asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td align="left" style="text-align: left">
                                                        <asp:TextBox ID="txtschoolrank" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtschoolrank"
                                                                Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Rank"
                                                                InitialValue="" Display="None" />
                                                    </td>
                                                    </tr>
                                                    <tr>
                                                        <th colspan="6">
                                                           <asp:CheckBox ID="ckhRankerAdditional" runat="server" AutoPostBack="true" 
                                                                oncheckedchanged="ckhRankerAdditional_CheckedChanged" />
                                                      <span class="lbl"> </span>Additional Pre-Defined Conditions
                                                        </th>
                                                    </tr>
                                                    <tr runat="server" visible="false" id="trDiscount">
                                                        <td align="left" style="text-align: left">
                                                            Discount Condition <asp:Label ID="label41" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td align="left" style="text-align: left" colspan="5">
                                                            <asp:DropDownList ID="ddldiscountconditions" runat="server" CssClass="chzn-select"
                                                                AutoPostBack="True" ValidationGroup="Grplead">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddldiscountconditions"
                                                                Text="*" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Discount Condition"
                                                                InitialValue="Select" Display="None" />
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
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnSubmitNewOpp" runat="server"
                                                    validationgroup="Grplead" onserverclick="btnSubmitNewOpp_ServerClick">
                                                    Save</button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclear" runat="server"
                                                    onserverclick="btnclear_ServerClick">
                                                    Cancel</button>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ValidationGroup="Grplead" ShowSummary="False" />
                                            </div>
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
                    <asp:PostBackTrigger ControlID="btnSubmitNewOpp" />
                    <asp:PostBackTrigger ControlID="btnsearchoppor" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR ADD OPPORTUNITY-->
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
                                                            <asp:CheckBox ID="chkaddcopy" runat="server" AutoPostBack="true" OnCheckedChanged="chkaddcopy_CheckedChanged" /><span
                                                                class="lbl"> Same As Primary Contact</span>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Contact Type
                                                        <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlseccontacttype" runat="server" ValidationGroup="Grplead2"
                                                            data-placeholder="Select Contact Type" CssClass="chzn-select" data-trigger="hover"
                                                            data-placement="top" data-content="Select Secondary Contact Type">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="ddlseccontacttype"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Title
                                                        <asp:Label ID="label22" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsectitle" runat="server" data-placeholder="Select Title"
                                                            CssClass="chzn-select" ValidationGroup="Grplead2">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                            <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator56" ControlToValidate="ddlsectitle"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title"
                                                            InitialValue="0" />
                                                        <asp:Label ID="lblprimaryconid" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        First Name
                                                        <asp:Label ID="label24" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecfname" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="First Name" CssClass="uppercase"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator101" runat="server"
                                                            ControlToValidate="txtsecfname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtsecfname"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
                                                    </td>
                                                    <td width="10%">
                                                        Middle Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecmname" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="Middle Name" CssClass="uppercase"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server"
                                                            ControlToValidate="txtsecmname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                    <td width="10%">
                                                        Last Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtseclname" runat="server" Width="79%" ValidationGroup="Grplead2"
                                                            placeholder="Last Name" CssClass="uppercase"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server"
                                                            ControlToValidate="txtseclname" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Handphone 1
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsechandphone1" runat="server" Width="79%" placeholder="Handphone 1"
                                                            ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtsechandphone1"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtsechandphone1"
                                                            ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2"
                                                            Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator2" ControlToValidate="txtsechandphone1" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone1" />
                                                        --%>
                                                    </td>
                                                    <td width="10%">
                                                        Handphone 2
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsechandphone2" runat="server" Width="79%" placeholder="Handphone 2"
                                                            ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtsechandphone2"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                            ControlToValidate="txtsechandphone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                            ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                    </td>
                                                    <td width="10%">
                                                        Landline No.
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtseclandline" runat="server" Width="79%" placeholder="Landline No."
                                                            ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
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
                                                            Country Name
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlseccountry" runat="server" data-placeholder="Select Country"
                                                                CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlseccountry_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            State Name
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlsecstate" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlSecstate_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            City Name
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlseccity" runat="server" AutoPostBack="true" data-placeholder="Select City"
                                                                CssClass="chzn-select" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlseccity_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Location
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlSeclocation" runat="server" data-placeholder="Select Location"
                                                            CssClass="chzn-select" ValidationGroup="Grplead2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Postal Code
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecpincode" runat="server" placeholder="Postal Code" MaxLength="6"
                                                            ValidationGroup="Grplead2" Width="79%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator59" ControlToValidate="txtsecpincode"
                                                            Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator23" ControlToValidate="txtsecpincode"
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
                                                        <asp:DropDownList ID="ddlsecgender" TabIndex="14" runat="server" data-placeholder="Select Gender"
                                                            CssClass="chzn-select" ValidationGroup="Grplead2">
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
                                                        <CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtsecdob"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtsecdob"
                                                            ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- ](0[1-9]|1[012])[- ](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="Label35" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                                        Email id
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsecemailid" runat="server" Width="79%" placeholder="Email Id"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator60" runat="server"
                                                            ControlToValidate="txtsecemailid" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
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
                                                        <asp:DropDownList ID="ddlinstitutiontype2" runat="server" AutoPostBack="true" ValidationGroup="Grplead2"
                                                            data-placeholder="Select Institution Type" CssClass="chzn-select" data-trigger="hover"
                                                            data-placement="top" data-content="Select Institution Type" OnSelectedIndexChanged="ddlinstitutiontype2_SelectedIndexChanged">
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
                                                        <asp:DropDownList ID="ddlboard2" runat="server" ValidationGroup="Grplead2" data-placeholder="Select Board"
                                                            CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Select Board / University">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Cur. Studying
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcurrentstudying2" runat="server" data-placeholder="Select Cur. Studying"
                                                            CssClass="chzn-select" ValidationGroup="Grplead2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Division/Section/Grade
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlsection2" runat="server" ValidationGroup="Grplead2" data-placeholder="Select"
                                                            CssClass="chzn-select" data-trigger="hover" data-placement="top" data-content="Select Division / Section / Grade">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Year of Passing
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlyearofpassing2" runat="server" ValidationGroup="Grplead2"
                                                            data-placeholder="Select Year of Passing" CssClass="chzn-select" data-trigger="hover"
                                                            data-placement="top" data-content="Select Year of Passing">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Additional Desc
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
                                                    Save</button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclearSeccon" runat="server"
                                                    onserverclick="btnclearSeccon_ServerClick">
                                                    Cancel</button>
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
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
