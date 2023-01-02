<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ContactCenter_Convert_Lead_To_Opportunity.aspx.cs" Inherits="ContactCenter_Convert_Lead_To_Opportunity" %>

<%@ Register TagPrefix="ContactInfoPanel" TagName="ContactInfoPanel" Src="~/UserControl/uc_Contact_Information.ascx" %>
<%@ Register TagPrefix="HistoryPanel" TagName="HistoryPanel" Src="~/UserControl/uc_Contact_FollowUp_History.ascx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN CONTENT -->
    <!-- BEGIN PAGE HEADER-->
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
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
            <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
            </i><a href="#">
                <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <button type="button" class="btn btn-danger btn-small dropdown-toggle" data-toggle="dropdown"
                data-hover="dropdown" data-delay="1000" data-close-others="true" runat="server"
                visible="false">
                <span>Actions </span><i class="fa fa-angle-down"></i>
            </button>
            <ul class="dropdown-menu pull-right" role="menu">
                <li><a href="#" id="btnsearchlead" runat="server" onserverclick="btnsearchlead_ServerClick">
                    Search Lead</a> </li>
                <%--<li><a href="#" id="btnaddlead" runat="server" onserverclick="btnaddlead_ServerClick">
                    Add Lead</a> </li>--%>
            </ul>
        </div>
        <!--#nav-search-->
    </div>
    <!-- END PAGE HEADER-->
    <div id="page-content" class="clearfix">
        <div class="row-fluid">
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>
            <!-- BEGIN PAGE CONTENT FOR DISPLAY-->
            <asp:UpdatePanel ID="upnl1" runat="server">
                <ContentTemplate>
                    <div class="row-fluid">
                        <div class="span12">
                            <div id="Div2" class="span12">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <!-- Primary Contact Type  -->
                                            <div class="row-fluid">
                                                <asp:Label ID="lblConId" runat="server" Visible="false"></asp:Label>
                                                <ContactInfoPanel:ContactInfoPanel runat="server" ID="ContactInfoPanel1"></ContactInfoPanel:ContactInfoPanel>
                                            </div>  

                                            <div class="row-fluid" runat="server" visible="false">
                                                <div class="span12">
                                                    <div class="widget-box">
                                                        <div class="widget-header">
                                                            <h5>
                                                                Primary Contact
                                                            </h5>
                                                            <%--<asp:Label ID="lblConId" runat="server" Visible="false"></asp:Label>--%>
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
                                                                            <asp:Label ID="label26" runat="server" Enabled="false" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlContactsourceadd" runat="server" CssClass="chzn-select"
                                                                                Enabled="false" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top"
                                                                                data-content="Select Contact Source">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlContactsourceadd"
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
                                                                            <asp:DropDownList ID="ddlcustomertype" runat="server" data-placeholder="Select Type"
                                                                                Enabled="false" Width="215px" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead2"
                                                                                OnSelectedIndexChanged="ddlcustomertype_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlcustomertype"
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
                                                                        <td width="10%" colspan="4">
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
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMidName"
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
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtdateofbirth"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Date Of Birth" />
                                                                            <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="txtdateofbirth"
                                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                            <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtdateofbirth"
                                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date"
                                                                                ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Handphone 1
                                                                            <asp:Label ID="label1" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtHandPhone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                                                Enabled="false" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ControlToValidate="txtHandPhone1"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone 1" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatordsw2" ControlToValidate="txtHandPhone1"
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
                                                                                Enabled="false" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
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
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
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
                                                                Basic Data
                                                            </h5>
                                                            <asp:Label ID="lblprimaryLeadCode" runat="server" Visible="false"></asp:Label>
                                                            <%-- <button id="btnEditCon" runat="server" data-rel="tooltip" data-placement="left" visible="true"
                                                            title="Edit  Contact" class="btn btn-app btn-primary btn-mini radius-4" onserverclick="btnEditCon_Click">
                                                            <i class="icon-edit"></i>
                                                        </button>
                                                        <button id="btnRefreshCon" runat="server" data-rel="tooltip" data-placement="left"
                                                            visible="true" title="Refresh  Contact" class="btn btn-app btn-primary btn-mini radius-4"
                                                            onserverclick="btnRefreshCon_Click">
                                                            <i class="icon-refresh"></i>
                                                        </button>
                                                        &nbsp;&nbsp;--%>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main">
                                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Lead Date
                                                                        </td>
                                                                        <td width="20%" colspan="5">
                                                                            <asp:TextBox ID="txt1" runat="server" CssClass="input-large uppercase" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Lead Type
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlleadtypeadd" Enabled="false" runat="server" CssClass="chzn-select"
                                                                                ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead type">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlleadtypeadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Lead Type"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Lead Source
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlleadsourceadd" Enabled="false" runat="server" CssClass="chzn-select"
                                                                                ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead Source">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlleadsourceadd"
                                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Lead Source"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Lead Status
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlleadstatusadd" Enabled="false" runat="server" CssClass="chzn-select"
                                                                                ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead Status">
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
                                                                            <asp:DropDownList ID="ddlcampaignid" runat="server" CssClass="chzn-select">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Source Description
                                                                        </td>
                                                                        <td colspan="5" width="86%">
                                                                            <asp:TextBox ID="txtsourcedesc" Enabled="false" runat="server" MaxLength="200" Width="91%"
                                                                                placeholder="Free Text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-fluid">
                                                <div class="widget-box">
                                                    <div class="widget-body">
                                                        <div class="widget-header">
                                                            <h4>
                                                                Convert</h4>
                                                        </div>
                                                        <div class="widget-body">
                                                            <table class="table table-striped table-bordered table-advance table-hover" id="tblconvertOpp"
                                                                runat="server" width="100%">
                                                                <thead>
                                                                    <th colspan="6">
                                                                        Opportunity Details
                                                                    </th>
                                                                </thead>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Product Category
                                                                        
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlproductcategory" runat="server" CssClass="chzn-select" ValidationGroup="Val1"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="ddlproductcategory"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Product Category"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Sales Stage
                                                                        <asp:Label ID="label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlsalesstage" runat="server" CssClass="chzn-select" ValidationGroup="Val1"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlsalesstage_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="ddlsalesstage"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Sales Stage"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%" id="tdapplicationno" runat="server">
                                                                        App. Form No.
                                                                        <%--<asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                    </td>
                                                                    <td width="20%" id="tdapplicationno1" runat="server">
                                                                        <asp:TextBox ID="txtappno" runat="server" Width="205px" ValidationGroup="Val1" MaxLength="7"
                                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtappno"
                                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                        <asp:Label ID="lblappnoerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Company
                                                                        
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlconvertcompany" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                            ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertcompany_SelectedIndexChanged"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" ControlToValidate="ddlconvertcompany"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Company"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Division
                                                                        
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlconvertdivision" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                            ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertdivision_SelectedIndexChanged"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="ddlconvertdivision"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Division"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Zone / Area
                                                                        
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlconvertzone" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                            ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertzone_SelectedIndexChanged"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="ddlconvertzone"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Zone/Area"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Center
                                                                        
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlconvertcenter" AutoPostBack="true" runat="server" CssClass="chzn-select"
                                                                            ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertcenter_SelectedIndexChanged"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="ddlconvertcenter"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Acad. Year
                                                                        
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlConacademicyear" AutoPostBack="true" runat="server" CssClass="chzn-select"
                                                                            ValidationGroup="Val1" OnSelectedIndexChanged="ddlConacademicyear_SelectedIndexChanged"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="ddlConacademicyear"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Academic Year"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Product Name
                                                                        <asp:Label ID="label44" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtproductInterested" runat="server" placeholder="Course Interested"
                                                                                        Width="205px" data-trigger="hover" data-placement="top" data-content="Enter Course Interested in"
                                                                                        ValidationGroup="Val1"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="txtproductInterested"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter Product Name" />
                                                                       <%-- <asp:DropDownList ID="ddlproduct" runat="server" CssClass="chzn-select" ValidationGroup="Val1">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="ddlproduct"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Product"
                                                                            InitialValue="Select" />--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Discount offered
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtdiscount" runat="server" Width="205px" ValidationGroup="Val1"
                                                                            MaxLength="10" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="redquiredexpression5" ControlToValidate="txtdiscount"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Discount Notes
                                                                    </td>
                                                                    <td width="70%" colspan="4">
                                                                        <asp:TextBox ID="txtdiscountnotes" runat="server" Width="675px" ValidationGroup="Val1"
                                                                            placeholder="Free Text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Expected DoJ
                                                                        <asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <input readonly="readonly" class="span8 date-picker" id="txtjoindate" runat="server"
                                                                                type="text" data-date-format="dd M yyyy" style="width:215px" />
                                                                        <%--<asp:TextBox ID="txtjoindate" runat="server" Width="205px" ValidationGroup="Val1"></asp:TextBox>--%>
                                                                        <%--<CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtjoindate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>--%>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="txtjoindate"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter Join Date" />
                                                                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                                            ControlToValidate="txtjoindate" ValidationGroup="Val1" Text="#" SetFocusOnError="True"
                                                                            ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                                        <asp:Label ID="lbldateerrorJoindate" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Exp. Closure date
                                                                        <asp:Label ID="label37" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <input readonly="readonly" class="span8 date-picker" id="txtexpectedclosedate" runat="server"
                                                                                type="text" data-date-format="dd M yyyy" style="width:215px" />
                                                                        <%--<asp:TextBox ID="txtexpectedclosedate" runat="server" Width="205px" ValidationGroup="Val1"></asp:TextBox>--%>
                                                                        <%--<CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexpectedclosedate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>--%>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="txtexpectedclosedate"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Expected Closure Date" />
                                                                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                            ControlToValidate="txtexpectedclosedate" ValidationGroup="Val1" Text="#" SetFocusOnError="True"
                                                                            ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                                        <asp:Label ID="lbldateerrorexp" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Converted Date
                                                                        <%--<asp:Label ID="label35" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtconverteddate" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Probability %
                                                                        <asp:Label ID="label38" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtprobabilitypercent" runat="server" MaxLength="2" Width="205px"
                                                                            ValidationGroup="Val1"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="txtprobabilitypercent"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Probability Percent of Conversion" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtprobabilitypercent"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Contact Source
                                                                        
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlsaleschannel" runat="server" CssClass="chzn-select" ValidationGroup="Val1"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="ddlsaleschannel"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Contact Source"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                    </td>
                                                                    <td width="20%">
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr7" runat="server" visible="false">
                                                                    <td width="10%">
                                                                        Assigned To
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtassignedto" runat="server" Width="88%" ValidationGroup="Val1"
                                                                            ToolTip="Enter User ID" MaxLength="6" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="txtassignedto"
                                                                            Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Assign Lead" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Search User
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtusername" runat="server" Width="88%"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        <asp:Button ID="btnseacrhbyusername" runat="server" Text="Search" CssClass="btn btn-small green" />
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlOppstatus" runat="server" Width="88%" Visible="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                                                        <asp:Label ID="label2" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="text-align: left">
                                                                        <asp:DropDownList ID="ddlbranchtopperdivision" runat="server" CssClass="chzn-select"
                                                                            AutoPostBack="True" ValidationGroup="Val1" OnSelectedIndexChanged="ddlbranchtopperdivision_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFifgdeldValidator2" ControlToValidate="ddlbranchtopperdivision"
                                                                            Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Branch Division"
                                                                            InitialValue="Select" Display="None" />
                                                                    </td>
                                                                    <td align="left" style="text-align: left">
                                                                        Center
                                                                        <asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="text-align: left" colspan="3">
                                                                        <asp:DropDownList ID="ddlbranchtopperCenter" runat="server" CssClass="chzn-select"
                                                                            AutoPostBack="True" ValidationGroup="Val1">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlbranchtopperCenter"
                                                                            Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                            InitialValue="Select" Display="None" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th colspan="6">
                                                                        <asp:CheckBox ID="chkSchoolRanker" runat="server" AutoPostBack="true" OnCheckedChanged="chkSchoolRanker_CheckedChanged" />
                                                                        <span class="lbl"></span>School Ranker for Standard X
                                                                    </th>
                                                                </tr>
                                                                <tr runat="server" visible="false" id="trSchoolRanker">
                                                                    <td align="left" style="text-align: left">
                                                                        School Name
                                                                        <asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="text-align: left">
                                                                        <asp:DropDownList ID="ddlschoolranker" runat="server" CssClass="chzn-select" ValidationGroup="Val1">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlschoolranker"
                                                                            Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select School"
                                                                            InitialValue="Select" Display="None" />
                                                                    </td>
                                                                    <td align="left" style="text-align: left">
                                                                        School Division
                                                                        <asp:Label ID="label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="text-align: left">
                                                                        <asp:TextBox ID="txtschooldivision" runat="server" Width="205px" ValidationGroup="Val1"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtschooldivision"
                                                                            Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter School Division"
                                                                            InitialValue="" Display="None" />
                                                                    </td>
                                                                    <td align="left" style="text-align: left">
                                                                        Rank
                                                                        <asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="text-align: left">
                                                                        <asp:TextBox ID="txtschoolrank" runat="server" Width="205px" ValidationGroup="Val1"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtschoolrank"
                                                                            Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter Rank"
                                                                            InitialValue="" Display="None" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th colspan="6">
                                                                        <asp:CheckBox ID="ckhRankerAdditional" runat="server" AutoPostBack="true" OnCheckedChanged="ckhRankerAdditional_CheckedChanged" />
                                                                        <span class="lbl"></span>Additional Pre-Defined Conditions
                                                                    </th>
                                                                </tr>
                                                                <tr runat="server" visible="false" id="trDiscount">
                                                                    <td align="left" style="text-align: left">
                                                                        Discount Condition
                                                                        <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td align="left" style="text-align: left" colspan="5">
                                                                        <asp:DropDownList ID="ddldiscountconditions" runat="server" CssClass="chzn-select"
                                                                            AutoPostBack="True" ValidationGroup="Val1">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddldiscountconditions"
                                                                            Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Discount Condition"
                                                                            InitialValue="Select" Display="None" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnopportunitysubmit"
                                                    runat="server" validationgroup="Val1" onserverclick="btnopportunitysubmit_ServerClick">
                                                    Save
                                                </button>
                                                <%--<button class="btn btn-app btn-primary btn-mini radius-4" id="btnclose" runat="server" onserverclick ="btnclose_ServerClick">
                                                                Close
                                                </button>--%>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclose" runat="server"
                                                    onclick="javascript:window.close()">
                                                    Close</button>
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                    ValidationGroup="Val1" ShowSummary="False" />
                                            </div>

                                            <div class="row-fluid">
                                                <HistoryPanel:HistoryPanel runat="server" ID="HistoryPanel1"></HistoryPanel:HistoryPanel>
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
                    <asp:PostBackTrigger ControlID="btnsearchlead" />
                    <asp:PostBackTrigger ControlID="btnopportunitysubmit" />
                    <%--<asp:PostBackTrigger ControlID="btnaddlead" />--%>
                    <asp:PostBackTrigger ControlID="btnRefreshCon" />
                </Triggers>
            </asp:UpdatePanel>
            <div class="alert alert-success" id="divSaveOpp" runat="server" visible="false">
                <strong>
                    <asp:Label ID="lblsaveOpp" runat="server"></asp:Label></strong>
                <%-- <button class="btn btn-app btn-success btn-mini radius-4" id="btnOppSaveMsg" runat="server"
                    onserverclick="btnOppSaveMsg_ServerClick">
                    OK
                </button>--%><br />
                 <div class="btn-group" id="divConvertOppToOrder" runat="server" visible="false">
                    <a id="aConvertToOrder" runat="server" target="_blank" class="btn btn-app btn-primary btn-mini radius-4"
                        title="Convert To Order">Yes</a>
                </div>
                <button class="btn btn-app btn-primary btn-mini radius-4" id="btncloseSaveopp" runat="server"
                    onclick="javascript:window.close()">
                    Close
                </button>
            </div>
            <div class="alert alert-danger" id="divErrorMessage1" runat="server" visible="false">
                <strong>
                    <asp:Label ID="lblErrorOpp" runat="server"></asp:Label></strong>
                <%--<button class="btn btn-app btn-success btn-mini radius-4" id="Button1" runat="server"
                        onserverclick="btnOppSaveMsg_ServerClick">
                        OK
                    </button>--%>
                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnCloseError" runat="server"
                    onclick="javascript:window.close()">
                    OK
                </button>
            </div>
            <!-- END PAGE CONTENT FOR DISPLAY-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
