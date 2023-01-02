<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Add_Contacts.aspx.cs" Inherits="Add_Contacts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
    <script language="javascript" type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="h5.smaller">
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
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <div class="page-content">
            <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="alert alert-danger" id="divErrormessage" runat="server">
                        <strong>
                            <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
                    </div>
                    <div class="alert alert-success" id="divSuccessmessage" runat="server">
                        <strong>
                            <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <!--BEGIN PAGE CONTENT FOR ADD LEAD -->
            <div runat="server" id="divSaveMessage" class="row-fluid" visible="false">
                <div class="alert alert-success" id="div1" runat="server">
                    <strong>
                        <asp:Label ID="lblPKeyContactId" runat="server" Visible="false" />
                        <asp:Label ID="Label24" runat="server">Contact created successfully. Please select the further action.</asp:Label></strong>
                    &nbsp;&nbsp;
                    <br />
                    <asp:Label ID="lblContactWarningError" runat="server" CssClass="red" Font-Bold="True"
                        Font-Size="Large"></asp:Label>
                    <br />
                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btn_ConvertToLeadYes"
                        ToolTip="Assign Contact To Lead" runat="server" Text="Assign Contact To Lead"
                        OnClick="btn_ConvertToLeadYes_Click" Width="175px" />
                    &nbsp;
                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btn_ConvertToLeadNo"
                        ToolTip="Add Contact" runat="server" OnClick="btn_ConvertToLeadNo_Click" Text="Add Contact"
                        Width="125px" />
                    &nbsp;
                    <asp:Button class="btn btn-app btn-danger btn-mini radius-4" ID="btn_SearchContact"
                        ToolTip="Search Contact" runat="server" OnClick="btn_SearchContact_Click" Text="Search Contact"
                        Width="125px" />
                </div>
            </div>
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <!-- BEGIN PAGE CONTENT FOR ADD LEAD-->
                    <div class="row-fluid">
                        <div class="span12">
                            <div id="Div2" class="row-fluid">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget-box">
                                                        <div class="widget-header widget-hea1der-small header-color-dark">
                                                            <h5>
                                                                Contact
                                                            </h5>
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
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlContactType" runat="server" Width="215px" Enabled="false"
                                                                                CssClass="chzn-select" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top"
                                                                                data-content="Select Contact Type">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1002" ControlToValidate="ddlContactType"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Customer Type
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlcustomertype" runat="server" data-placeholder="Select Type"
                                                                                Width="215px" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead2"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlcustomertype"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Customer Type"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            First Name
                                                                            <asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
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
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlTitle"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title"
                                                                                InitialValue="0" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtFirstName"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server"
                                                                                ControlToValidate="txtFirstName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Middle Name
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtMidName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                                placeholder="Middle Name"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server"
                                                                                ControlToValidate="txtMidName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Last Name
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtLastName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                                placeholder="Last Name"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server"
                                                                                ControlToValidate="txtLastName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                                Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
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
                                                                            <asp:Label ID="label19" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <input readonly="readonly" class="span8 date-picker" id="txtdateofbirth" runat="server"
                                                                                type="text" data-date-format="dd M yyyy" style="width: 215px" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="txtdateofbirth"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Date Of Birth" />
                                                                            <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Email id
                                                                            <asp:Label ID="label25" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtemailid" runat="server" Width="205px" placeholder="Email Id"
                                                                                ValidationGroup="Grplead2"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="txtemailid"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Email Id" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server"
                                                                                ControlToValidate="txtemailid" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Handphone 1
                                                                            <asp:Label ID="label13" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtHandPhone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                                                ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtHandPhone1"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone 1" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator32" ControlToValidate="txtHandPhone1"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server"
                                                                                ControlToValidate="txtHandPhone1" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Handphone 2
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtHandphone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                                                ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator34" ControlToValidate="txtHandphone2"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server"
                                                                                ControlToValidate="txtHandphone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Landline No.
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtlandline" runat="server" Width="205px" placeholder="Landline No."
                                                                                ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator36" ControlToValidate="txtlandline"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator37" runat="server"
                                                                                ControlToValidate="txtlandline" ErrorMessage="Handphone length must be between 7 to 18 characters"
                                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
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
                                                                                    AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged">
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
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator38" ControlToValidate="txtpincode"
                                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator39" ControlToValidate="txtpincode"
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
                                                        <div class="widget-header widget-hea1der-small header-color-dark">
                                                            <h5>
                                                                Contact Academic Information
                                                            </h5>
                                                            <button id="btnAddAcadInfo" runat="server" data-rel="tooltip" data-placement="left"
                                                                title="Add Academic Information" class="btn btn-mini btn-primary" onserverclick="btnAddAcadInfo_Click">
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
                                                                            <asp:Label ID="Label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
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
                                                                            <asp:Label ID="Label12" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlnameofinstitution" runat="server" Width="215px" CssClass="chzn-select"
                                                                                ValidationGroup="Grplead3">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="ddlnameofinstitution"
                                                                                Text="#" runat="server" ValidationGroup="Grplead3" SetFocusOnError="True" ErrorMessage="Select School / College"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Board / University
                                                                            <asp:Label ID="Label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
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
                                                                            <asp:Label ID="Label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
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
                                                                            <asp:Label ID="Label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
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
                                                                            <asp:DropDownList ID="ddlexamname" runat="server" Width="215px" CssClass="chzn-select"
                                                                                data-trigger="hover" data-placement="top" data-content="Select Exam" AutoPostBack="true"
                                                                                OnSelectedIndexChanged="ddlexamname_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Exam Status
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlexamstatus" runat="server" Width="215px" CssClass="chzn-select"
                                                                                data-trigger="hover" data-placement="top" data-content="Select Exam Status">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Exam Rank
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtexamrank" runat="server" placeholder="Exam Rank" Width="205px"
                                                                                data-trigger="hover" data-placement="top" data-content="Exam Rank" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Final Marks Obtained
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtFinalMarksObtained" runat="server" placeholder="Final Marks Obtained"
                                                                                Width="205px" MaxLength="100" data-trigger="hover" data-placement="top" data-content="Enter Final Obtained Marks"
                                                                                onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;">></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Final Marks Total
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtFinalMarksTotal" runat="server" placeholder="Final Marks Total"
                                                                                Width="205px" data-trigger="hover" data-placement="top" data-content="Enter Final Obtained Total"
                                                                                onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;">></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
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
                                                                                data-trigger="hover" data-placement="top" data-content="Enter Percentage" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;">></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                        </td>
                                                                        <td width="20%">
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
                                                                            <asp:Label ID="lblRowNumber" Text='<%#DataBinder.Eval(Container.DataItem, "RowNumber")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblInstitutionTypeCode" Text='<%#DataBinder.Eval(Container.DataItem, "InstitutionTypeCode")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblInstitutionType" Text='<%#DataBinder.Eval(Container.DataItem, "InstitutionType")%>'
                                                                                runat="server"></asp:Label>
                                                                            <asp:Label ID="lblnameofinstitutionid" Text='<%#DataBinder.Eval(Container.DataItem, "nameofinstitutionid")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblexamnameid" Text='<%#DataBinder.Eval(Container.DataItem, "examnameid")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblexamstatusid" Text='<%#DataBinder.Eval(Container.DataItem, "examstatusid")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblexamrank" Text='<%#DataBinder.Eval(Container.DataItem, "examrank")%>'
                                                                                runat="server" Visible="false"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblInstitutionName" Text='<%#DataBinder.Eval(Container.DataItem, "InstitutionName")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblBoardId" Text='<%#DataBinder.Eval(Container.DataItem, "BoardId")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblBoardName" Text='<%#DataBinder.Eval(Container.DataItem, "BoardName")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblStandardCode" Text='<%#DataBinder.Eval(Container.DataItem, "standrdCode")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblStandardName" Text='<%#DataBinder.Eval(Container.DataItem, "standardName")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblDivisionCode" Text='<%#DataBinder.Eval(Container.DataItem, "DivisionCode")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblDivisionName" Text='<%#DataBinder.Eval(Container.DataItem, "DivisionName")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPassingYearCode" Text='<%#DataBinder.Eval(Container.DataItem, "PassingYearCode")%>'
                                                                                    runat="server" Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblPassingYearName" Text='<%#DataBinder.Eval(Container.DataItem, "PassingYearName")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblAditionalDesc" Text='<%#DataBinder.Eval(Container.DataItem, "AditionalDesc")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblExamName" Text='<%#DataBinder.Eval(Container.DataItem, "ExamName")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblFinalMarkObt" Text='<%#DataBinder.Eval(Container.DataItem, "FinalMarkObtain")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblFinalMarkTotal" Text='<%#DataBinder.Eval(Container.DataItem, "FinalMarkTotal")%>'
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
                                                                                <asp:LinkButton ID="lnkDLEdit" ToolTip="Edit" class="btn btn-mini btn-primary" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RowNumber")%>'
                                                                                    runat="server" CommandName="Edit" Height="15px"><i class=" icon-info-sign"></i></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkDelete" ToolTip="Remove" runat="server" class="btn btn-mini btn-danger"
                                                                                    CommandName="Remove" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RowNumber")%>'><i class="icon-trash"></i></asp:LinkButton>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-fluid">
                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="6">
                                                                <asp:CheckBox ID="chkFatherInfo" runat="server" AutoPostBack="True" Checked="false"
                                                                    OnCheckedChanged="chkFatherInfo_CheckedChanged" />
                                                                <span class="lbl"></span><strong>Father Information</strong> </span>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                        id="tblFatherInfo" visible="false">
                                                        <tr>
                                                            <td width="10%">
                                                                Contact Type
                                                            </td>
                                                            <td width="20%">
                                                                <b>Father</b>
                                                            </td>
                                                            <td width="10%">
                                                                Title
                                                                <asp:Label ID="Label2" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlFatherTitle" runat="server" Width="215px" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead2">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                                    <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlFatherTitle"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Father Title"
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
                                                                <asp:TextBox ID="txtFatherFName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="First Name"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtFatherFName"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Father Name" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFatherFName"
                                                                    ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                    ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                            <td width="10%">
                                                                Middle Name
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherMName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="Middle Name"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFatherMName"
                                                                    ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                    ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                            <td width="10%">
                                                                Last Name
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherLName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="Last Name"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFatherLName"
                                                                    ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true"
                                                                    ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Handphone 1
                                                                <asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherHandphone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtFatherHandphone1"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Father Handphone 1" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtFatherHandphone1"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtFatherHandphone1"
                                                                    ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                            </td>
                                                            <td width="10%">
                                                                Handphone 2
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherHandPhone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtFatherHandPhone2"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtFatherHandPhone2"
                                                                    ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                            </td>
                                                            <td width="10%">
                                                                Landline No.
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherLandLineNumber" runat="server" Width="205px" placeholder="Landline No."
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtFatherLandLineNumber"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtFatherLandLineNumber"
                                                                    ErrorMessage="Land Line Number length must be between 7 to 18 characters" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Gender
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlFatherGender" runat="server" Width="215px" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead2" Enabled="false">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                                    <asp:ListItem Value="2">Female</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlFatherGender"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                                    InitialValue="0" />
                                                            </td>
                                                            <td width="10%">
                                                                Email ID
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherEmailID" runat="server" Width="205px" placeholder="Email Id"
                                                                    ValidationGroup="Grplead2"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                    ControlToValidate="txtFatherEmailID" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td width="10%">
                                                                Occupation
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherOccupation" runat="server" Width="205px" placeholder="Occupation"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Organization
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherOrganization" runat="server" Width="205px" placeholder="Organization"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Designation
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherDesignation" runat="server" Width="205px" placeholder="Designation"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Office Phone
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtFatherOfficePhone" runat="server" Width="205px" placeholder="Office Phone"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="row-fluid">
                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="6">
                                                                <asp:CheckBox ID="chkMotherInfo" runat="server" AutoPostBack="True" Checked="false"
                                                                    OnCheckedChanged="chkMotherInfo_CheckedChanged" />
                                                                <span class="lbl"></span><strong>Mother Information</strong> </span>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                        visible="false" id="tblMotherInfo">
                                                        <tr>
                                                            <td width="10%">
                                                                Contact Type
                                                            </td>
                                                            <td width="20%">
                                                                <b>Mother</b>
                                                            </td>
                                                            <td width="10%">
                                                                Title
                                                                <asp:Label ID="Label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlMotherTitle" runat="server" Width="215px" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead2">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                                    <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlMotherTitle"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Mother Title"
                                                                    InitialValue="0" />
                                                            </td>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                First Name
                                                                <asp:Label ID="label5" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherFName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="First Name"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtMotherFName"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Mother Name" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                                    ControlToValidate="txtMotherFName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                            <td width="10%">
                                                                Middle Name
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherMName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="Middle Name"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                                    ControlToValidate="txtMotherMName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                            <td width="10%">
                                                                Last Name
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherLName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="Last Name"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                                    ControlToValidate="txtMotherLName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Handphone 1
                                                                <asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherHandphone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtMotherHandphone1"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Mother Handphone 1" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtMotherHandphone1"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                                    ControlToValidate="txtMotherHandphone1" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                    ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                            </td>
                                                            <td width="10%">
                                                                Handphone 2
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherHandPhone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtMotherHandPhone2"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                                    ControlToValidate="txtMotherHandPhone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                    ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                            </td>
                                                            <td width="10%">
                                                                Landline No.
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherLandLineNumber" runat="server" Width="205px" placeholder="Landline No."
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtMotherLandLineNumber"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                                                    ControlToValidate="txtMotherLandLineNumber" ErrorMessage="Land Line Number length must be between 7 to 18 characters"
                                                                    ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Gender
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlMotherGender" runat="server" Width="215px" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead2" Enabled="false">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                                    <asp:ListItem Value="2">Female</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="ddlMotherGender"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                                    InitialValue="0" />
                                                            </td>
                                                            <td width="10%">
                                                                Email ID
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherEmailID" runat="server" Width="205px" placeholder="Email Id"
                                                                    ValidationGroup="Grplead2"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server"
                                                                    ControlToValidate="txtMotherEmailID" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td width="10%">
                                                                Occupation
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherOccupation" runat="server" Width="205px" placeholder="Occupation"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Organization
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherOrganization" runat="server" Width="205px" placeholder="Organization"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Designation
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherDesignation" runat="server" Width="205px" placeholder="Designation"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Office Phone
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtMotherOfficePhone" runat="server" Width="205px" placeholder="Office Phone"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="row-fluid">
                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="6">
                                                                <asp:CheckBox ID="chkGuardianInfo" runat="server" AutoPostBack="True" Checked="false"
                                                                    OnCheckedChanged="chkGuardianInfo_CheckedChanged" />
                                                                <span class="lbl"></span><strong>Guardian Information</strong> </span>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                        visible="false" id="tblGuardianInfo">
                                                        <tr>
                                                            <td width="10%">
                                                                Contact Type
                                                            </td>
                                                            <td width="20%">
                                                                <b>Guardian</b>
                                                            </td>
                                                            <td width="10%">
                                                                Title
                                                                <asp:Label ID="Label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlGuardianTitle" runat="server" Width="215px" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead2">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Mr.</asp:ListItem>
                                                                    <asp:ListItem Value="2">Ms.</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlGuardianTitle"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Guardian Title"
                                                                    InitialValue="0" />
                                                            </td>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                First Name
                                                                <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianFName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="First Name"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtGuardianFName"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Guardian Name" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                                    ControlToValidate="txtGuardianFName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                            <td width="10%">
                                                                Middle Name
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianMName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="Middle Name"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                                                    ControlToValidate="txtGuardianMName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                            <td width="10%">
                                                                Last Name
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianLName" runat="server" Width="205px" ValidationGroup="Grplead2"
                                                                    placeholder="Last Name"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server"
                                                                    ControlToValidate="txtGuardianLName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2"
                                                                    Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Handphone 1
                                                                <asp:Label ID="label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianHandphone1" runat="server" Width="205px" placeholder="Handphone 1"
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtGuardianHandphone1"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Guardian Handphone 1" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator24" ControlToValidate="txtGuardianHandphone1"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server"
                                                                    ControlToValidate="txtGuardianHandphone1" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                    ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                            </td>
                                                            <td width="10%">
                                                                Handphone 2
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianHandPhone2" runat="server" Width="205px" placeholder="Handphone 2"
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator26" ControlToValidate="txtGuardianHandPhone2"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                                    ControlToValidate="txtGuardianHandPhone2" ErrorMessage="Handphone length must be between 10 to 18 characters"
                                                                    ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
                                                            </td>
                                                            <td width="10%">
                                                                Landline No.
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianLandLineNumber" runat="server" Width="205px" placeholder="Landline No."
                                                                    ValidationGroup="Grplead2" MaxLength="18" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator28" ControlToValidate="txtGuardianLandLineNumber"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server"
                                                                    ControlToValidate="txtGuardianLandLineNumber" ErrorMessage="Land Line Number length must be between 7 to 18 characters"
                                                                    ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Gender
                                                                <asp:Label ID="label22" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlGuardianGender" runat="server" Width="215px" CssClass="chzn-select"
                                                                    ValidationGroup="Grplead2">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                                    <asp:ListItem Value="2">Female</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="ddlGuardianGender"
                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender"
                                                                    InitialValue="0" />
                                                            </td>
                                                            <td width="10%">
                                                                Email ID
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianEmailID" runat="server" Width="205px" placeholder="Email Id"
                                                                    ValidationGroup="Grplead2"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server"
                                                                    ControlToValidate="txtGuardianEmailID" ErrorMessage="Email Address Not Valid"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Grplead2"
                                                                    SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td width="10%">
                                                                Occupation
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianOccupation" runat="server" Width="205px" placeholder="Occupation"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Organization
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianOrganization" runat="server" Width="205px" placeholder="Organization"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Designation
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianDesignation" runat="server" Width="205px" placeholder="Designation"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Office Phone
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtGuardianOfficePhone" runat="server" Width="205px" placeholder="Office Phone"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnSubmitcon" runat="server"
                                                    validationgroup="Grplead2" onserverclick="btnSubmitcon_ServerClick">
                                                    Save
                                                </button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnConClose" runat="server"
                                                    onserverclick="btnConClose_ServerClick">
                                                    Close
                                                </button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclearcon" runat="server"
                                                    onserverclick="btnclearSeccon_ServerClick" visible="false">
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
                        <!--end tabbable-->
                        <!-- END PAGE CONTENT FOR ADD LEAD-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSubmitcon" />
                    <asp:PostBackTrigger ControlID="btnclearcon" />
                    <asp:PostBackTrigger ControlID="btnAddAcadInfo" />
                    <asp:PostBackTrigger ControlID="btnSaveAcadInfo" />
                    <asp:PostBackTrigger ControlID="btnUpdateAcadInfo" />
                    <asp:PostBackTrigger ControlID="btnCloseAcadInfo" />
                    <asp:PostBackTrigger ControlID="btnCloseAcadInfo" />
                </Triggers>
            </asp:UpdatePanel>
            <!--END PAGE CONTENT FOR ADD LEAD-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
