<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Lead_Edit.aspx.cs" Inherits="Lead_Edit" %>
<%@ Register TagPrefix="ContactInfoPanel" TagName="ContactInfoPanel" Src="~/UserControl/uc_Contact_Information.ascx" %>
<%@ Register TagPrefix="HistoryPanel" TagName="HistoryPanel" Src="~/UserControl/uc_Contact_FollowUp_History.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">.uppercase{text-transform:uppercase}</style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
<asp:ScriptManager ID="script1" runat="server">
</asp:ScriptManager>
<div id="breadcrumbs" class="position-relative">
<ul class="breadcrumb">
<li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
<li>
<h5 class="smaller">
<asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname" runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
<asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
<asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
<span class="divider"></span>
</h5>
</li>
<li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
<asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
<li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
</i><a href="#">
<asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
</ul>
<div id="nav-search">
<ul class="dropdown-menu pull-right" role="menu">
<li><a href="#" id="btnsearchlead" runat="server" onserverclick="btnsearchlead_ServerClick">
Search Lead</a> </li>
<li><a href="#" id="btnaddlead" runat="server" onserverclick="btnaddlead_ServerClick" visible="false">Add Lead</a> </li>
</ul>
</div>
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
<asp:UpdatePanel ID="upnl1" runat="server">
<ContentTemplate>
<div class="row-fluid">
<div class="span12">
<div>
<div>
<div id="Div2">
<div class="row-fluid">
<div class="span12">
<div>
<div class="row-fluid">
<asp:Label ID="lblPKey_Con_Id" runat="server" Visible="false"></asp:Label>
<ContactInfoPanel:ContactInfoPanel runat="server" ID="ContactInfoPanel1"></ContactInfoPanel:ContactInfoPanel>
</div>
<div id="Div1" class="row-fluid" runat="server" visible="false">
<div class="span12">
<div class="widget-box">
<div class="widget-header">
<h5>
Primary Contact
</h5>
<asp:Label ID="lblConId" runat="server" Visible="false"></asp:Label>
<div class="btn-group" id="divEditContatc" runat="server">
<a id="aedit" runat="server" target="_blank" class="btn btn-small btn-primary tooltip-info" title="Edit Contact"><i class="icon-edit"></i></a>
</div>
<div class="btn-group" id="divRefreshContact" runat="server">
<button type="button" class="btn btn-small btn-primary tooltip-info" id="btnRefreshCon" runat="server" onserverclick="btnrefersh_ServerClick" data-rel="tooltip" data-placement="top" title="Refresh Contact">
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
<asp:DropDownList ID="ddlContactsourceadd" runat="server" CssClass="chzn-select" Enabled="false" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Contact Source">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="ddlContactsourceadd" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Source" InitialValue="Select" />
</td>
<td width="10%">
Contact Type
<asp:Label ID="Label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlContactType" runat="server" Width="215px" Enabled="false" CssClass="chzn-select" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Contact Type">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFielferedValidator4" ControlToValidate="ddlContactType" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type" InitialValue="Select" />
</td>
<td width="10%">
Customer Type
<asp:Label ID="Label1re7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlcustomertype" runat="server" data-placeholder="Select Type" Enabled="false" Width="215px" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlcustomertype_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlcustomertype" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Customer Type" InitialValue="Select" />
</td>
</tr>
<tr>
<td width="10%">
Title
<asp:Label ID="Label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlTitle" runat="server" Width="215px" CssClass="chzn-select" Enabled="false" ValidationGroup="Grplead2">
<asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="1">Mr.</asp:ListItem>
<asp:ListItem Value="2">Ms.</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidatosdwr12" ControlToValidate="ddlTitle" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title" InitialValue="0" />
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
<asp:TextBox ID="txtFirstName" runat="server" Width="205px" ValidationGroup="Grplead2" Enabled="false" placeholder="First Name"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtFirstName" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator121" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
</td>
<td width="10%">
Middle Name
</td>
<td width="20%">
<asp:TextBox ID="txtMidName" runat="server" Width="205px" ValidationGroup="Grplead2" Enabled="false" placeholder="Middle Name"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValere4idator2" runat="server" ControlToValidate="txtMidName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
</td>
<td width="10%">
Last Name
</td>
<td width="20%">
<asp:TextBox ID="txtLastName" runat="server" Width="205px" ValidationGroup="Grplead2" Enabled="false" placeholder="Last Name"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
</td>
</tr>
<tr>
<td width="10%">
Gender
<asp:Label ID="label18" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlGender" runat="server" Width="215px" CssClass="chzn-select" Enabled="false" ValidationGroup="Grplead2">
<asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="1">Male</asp:ListItem>
<asp:ListItem Value="2">Female</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="ddlGender" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender" InitialValue="0" />
</td>
<td width="10%">
DOB
<asp:Label ID="label19" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:TextBox ID="txtdateofbirth" Width="205px" Placeholder="Date of Birth" runat="server" Enabled="false" ValidationGroup="Grplead2"></asp:TextBox>
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
<asp:TextBox ID="txtHandPhone1" runat="server" Width="205px" placeholder="Handphone 1" Enabled="false" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtHandPhone1" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Handphone 1" />
<asp:RegularExpressionValidator ID="RegularExpressionValidatordsw2" ControlToValidate="txtHandPhone1" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidfgdator5" runat="server" ControlToValidate="txtHandPhone1" ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
</td>
<td width="10%">
Handphone 2
</td>
<td width="20%">
<asp:TextBox ID="txtHandphone2" runat="server" Width="205px" placeholder="Handphone 2" Enabled="false" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtHandphone2" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtHandphone2" ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
</td>
<td width="10%">
Landline No.
</td>
<td width="20%">
<asp:TextBox ID="txtlandline" runat="server" Width="205px" placeholder="Landline No." Enabled="false" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtlandline" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtlandline" ErrorMessage="Handphone length must be between 7 to 18 characters" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
</td>
</tr>
<tr>
<td width="10%">
Address 1
</td>
<td width="20%">
<asp:TextBox ID="txtaddress1" runat="server" Width="205px" placeholder="Address Line 1" Enabled="false"></asp:TextBox>
</td>
<td width="10%">
Address 2
</td>
<td width="20%">
<asp:TextBox ID="txtaddress2" runat="server" Width="205px" placeholder="Address Line 2" Enabled="false"></asp:TextBox>
</td>
<td width="10%">
Street Name
</td>
<td width="20%">
<asp:TextBox ID="txtStreetname" runat="server" Width="205px" placeholder="Street Name" Enabled="false"></asp:TextBox>
</td>
<tr>
<td width="10%">
Country
<asp:Label ID="label23" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlCountry" runat="server" Width="215px" CssClass="chzn-select" Enabled="false" AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator133" ControlToValidate="ddlCountry" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Country" InitialValue="Select" />
</td>
<td width="10%">
State
</td>
<td width="20%">
<asp:DropDownList ID="ddlstate" runat="server" Width="215px" CssClass="chzn-select" Enabled="false" AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
</asp:DropDownList>
</td>
<td width="10%">
City
</td>
<td width="20%">
<asp:DropDownList ID="ddlcity" runat="server" Width="215px" CssClass="chzn-select" Enabled="false" ValidationGroup="Grplead2">
</asp:DropDownList>
</td>
</tr>
<tr>
<td width="10%">
Location
</td>
<td width="20%">
<asp:DropDownList ID="ddllocation" runat="server" Width="215px" CssClass="chzn-select" ValidationGroup="Grplead2" Enabled="false">
</asp:DropDownList>
</td>
<td width="10%">
Postal Code
</td>
<td width="20%">
<asp:TextBox ID="txtpincode" runat="server" placeholder="Postal Code" MaxLength="6" Enabled="false" ValidationGroup="Grplead2" Width="205px" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3243" ControlToValidate="txtpincode" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtpincode" runat="server" ErrorMessage="Pincode length must be of 6 Character" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{6,6}$" />
</td>
<td width="10%">
Email id
</td>
<td width="20%">
<asp:TextBox ID="txtemailid" runat="server" Width="205px" placeholder="Email Id" Enabled="false" ValidationGroup="Grplead2"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtemailid" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
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
<div id="Div2" class="row-fluid" runat="server" visible="false">
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
<b class="center" style="text-align:left">Institution Type</b></th>
<th style="text-align:center">
Institution Name
</th>
<th style="text-align:center">
Board
</th>
<th style="text-align:center">
Standard
</th>
<th style="text-align:center">
Division
</th>
<th style="text-align:center">
Year Of Passing
</th>
<th style="text-align:center">
Additional Desc
</th>
<th style="text-align:center">
Examination Name
</th>
<th style="text-align:center">
Final Marks Obtained
</th>
<th style="text-align:center">
Final Marks Total
</th>
<th style="text-align:center">
Grade
</th>
<th style="text-align:center">
Percentage
</th>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lblRowNumber" Text='<%#DataBinder.Eval(Container.DataItem, "Record_No")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblInstitutionTypeCode" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Type_Id")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblInstitutionType" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Type_Desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblInstitutionName" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Description")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblBoardId" Text='<%#DataBinder.Eval(Container.DataItem, "Board_Id")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblBoardName" Text='<%#DataBinder.Eval(Container.DataItem, "Board_Desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblStandardCode" Text='<%#DataBinder.Eval(Container.DataItem, "Current_Standard_Id")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblStandardName" Text='<%#DataBinder.Eval(Container.DataItem, "Current_Standard_Desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblDivisionCode" Text='<%#DataBinder.Eval(Container.DataItem, "Section_Id")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblDivisionName" Text='<%#DataBinder.Eval(Container.DataItem, "Section_Desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblPassingYearCode" Text='<%#DataBinder.Eval(Container.DataItem, "Year_of_Passing_ID")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblPassingYearName" Text='<%#DataBinder.Eval(Container.DataItem, "Year_of_Passing_Desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblAditionalDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Additional_Desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblExamName" Text='<%#DataBinder.Eval(Container.DataItem, "ExamName")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblFinalMarkObt" Text='<%#DataBinder.Eval(Container.DataItem, "FinalMarksObtained")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblFinalMarkTotal" Text='<%#DataBinder.Eval(Container.DataItem, "FinalMarksTotal")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblGrade" Text='<%#DataBinder.Eval(Container.DataItem, "Grade")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblPercentage" Text='<%#DataBinder.Eval(Container.DataItem, "Percentage")%>' runat="server"></asp:Label>
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
<div id="Div3" class="row-fluid" runat="server" visible="false">
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
<b class="center" style="text-align:left">Contact Type</b></th>
<th style="text-align:center">
Name
</th>
<th style="text-align:center">
Handphone1
</th>
<th style="text-align:center">
Handphone2
</th>
<th style="text-align:center">
LandLineNo
</th>
<th style="text-align:center">
Gender
</th>
<th style="text-align:center">
Email Id
</th>
<th style="text-align:center">
Occupation
</th>
<th style="text-align:center">
Organization
</th>
<th style="text-align:center">
Designation
</th>
<th style="text-align:center">
Office Phone
</th>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lblContactId" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Id")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblCon_type_id" Text='<%#DataBinder.Eval(Container.DataItem, "Con_type_id")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblCon_Type_desc" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Type_desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblName" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' runat="server"></asp:Label>
<asp:Label ID="lblConTitle" Text='<%#DataBinder.Eval(Container.DataItem, "Con_title")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblFName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Firstname")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblMName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_midname")%>' runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblLName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_lastname")%>' runat="server" Visible="false"></asp:Label>
</td>
<td>
<asp:Label ID="lblHandphone1" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone1")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblHandphone2" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone2")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblLandline" Text='<%#DataBinder.Eval(Container.DataItem, "Landline")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblGender" Text='<%#DataBinder.Eval(Container.DataItem, "Gender")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblEmailid" Text='<%#DataBinder.Eval(Container.DataItem, "Emailid")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblOccupation" Text='<%#DataBinder.Eval(Container.DataItem, "Occupation")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblOrganization" Text='<%#DataBinder.Eval(Container.DataItem, "Organization")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblDesignation" Text='<%#DataBinder.Eval(Container.DataItem, "Designation")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblOffice_phone" Text='<%#DataBinder.Eval(Container.DataItem, "Office_phone")%>' runat="server"></asp:Label>
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
</div>
<div class="widget-body">
<div class="widget-main">
<table class="table table-striped table-bordered table-advance table-hover">
<%--<thead>
                                                                                <tr>
                                                                                    <th colspan="6">
                                                                                        Basic Data
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>--%>
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
<%--<asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
</td>
<td width="20%">
<asp:DropDownList ID="ddlleadtypeadd" runat="server" Enabled="false" CssClass="chzn-select" ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead type">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlleadtypeadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Lead Type" InitialValue="Select" />
</td>
<td width="10%">
Lead Source
<%--<asp:Label ID="label4" runat="server" Enabled="false" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
</td>
<td width="20%">
<asp:DropDownList ID="ddlleadsourceadd" runat="server" CssClass="chzn-select" ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead Source" Enabled="false">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlleadsourceadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Lead Source" InitialValue="Select" />
</td>
<td width="10%">
Lead Status
<%--<asp:Label ID="label7" runat="server" Enabled="false" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
</td>
<td width="20%">
<asp:DropDownList ID="ddlleadstatusadd" Enabled="false" runat="server" CssClass="chzn-select" ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select lead Status">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="ddlleadstatusadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Lead Status" InitialValue="Select" />
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
<asp:TextBox ID="txtsourcedesc" runat="server" MaxLength="200" Width="91%" placeholder="Free Text"></asp:TextBox>
</td>
</tr>
<tr>
<td width="10%">
Course Interested In
</td>
<td width="20%">
<asp:TextBox ID="txtproductInterested" runat="server" placeholder="Course Interested" Width="205px" data-trigger="hover" data-placement="top" data-content="Enter Course Interested in" CssClass="uppercase"></asp:TextBox>
</td>
<td width="10%">
Expected Joining Acad. Year
<%--<asp:Label ID="label20" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
</td>
<td width="20%">
<asp:DropDownList ID="ddlacademicyear" runat="server" Width="215px" CssClass="chzn-select" ValidationGroup="Grplead" data-trigger="hover" data-placement="top" data-content="Select Expected Joining Academic Year" Enabled="false">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlacademicyear" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Expected Joining Current Academic Year" InitialValue="Select" />
</td>
<td width="10%">
Expected Joining Date
<%--<asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
</td>
<td width="20%">
<asp:TextBox ID="txtExpjoindate" placeholder="Expected Joining Date" runat="server" Width="205px" ValidationGroup="Grplead" Enabled="false"></asp:TextBox>
<CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtExpjoindate" DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
</CC1:CalendarExtender>
<asp:RequiredFieldValidator ID="RequiredFieldValidator32" ControlToValidate="txtExpjoindate" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Expected Join Date" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtExpjoindate" ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
<asp:Label ID="lbldateerror" runat="server" ForeColor="#FF3300"></asp:Label>
<%--  </td>
                                                                                <td width="10%" colspan="2">
                                                                                  
                                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="215px" CssClass="chzn-select"
                                                                                        TabIndex="4" Visible="false">
                                                                                    </asp:DropDownList>
                                                                                </td>--%>
<%--<td width="20%">                                                                    
                                                                     
                                                                </td>--%>
</tr>
<tr id="Tr1" runat="server" visible="false">
<td width="10%">
Examination Details
</td>
<td width="20%">
<asp:TextBox ID="txtexaminationdetails" runat="server" data-content="Enter Examination Details" data-placement="top" data-trigger="hover" Placeholder="Examination Details" ValidationGroup="Val4" Width="205px"></asp:TextBox>
</td>
<td width="10%">
Current Year of Education
</td>
<td width="20%">
<asp:DropDownList ID="ddlcurrentyeareducation" Width="215px" runat="server" CssClass="chzn-select">
</asp:DropDownList>
</td>
<td width="10%" colspan="2">
</td>
</tr>
<tr runat="server" id="trTest" visible="false">
<td width="10%">
Interested Discipline
</td>
<td width="20%">
<asp:DropDownList ID="ddldiscipline" Width="215px" runat="server" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddldiscipline_SelectedIndexChanged">
</asp:DropDownList>
</td>
<td width="10%">
Field Interested
</td>
<td width="20%">
<asp:DropDownList ID="ddlfieldint" Width="215px" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
</asp:DropDownList>
</td>
<td width="10%">
Competitive Exams
</td>
<td width="20%">
<asp:TextBox ID="txtcompetitiveexams" Width="215px" runat="server" ValidationGroup="Grplead2"></asp:TextBox>
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
Organization Assignments
</h5>
<asp:Label ID="Label9" runat="server" Visible="false"></asp:Label>
</div>
<div class="widget-body">
<div class="widget-main">
<table class="table table-striped table-bordered table-advance table-hover" id="tblorgassign" runat="server">
<%--<thead>
                                                                                <tr>
                                                                                    <th colspan="6">
                                                                                        Organization Assignments
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>--%>
<tr id="trSourcecompany" runat="server">
<td width="10%">
Source Company<asp:Label ID="label28" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlsourcecompanyadd" runat="server" AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlcompanyadd_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlsourcecompanyadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Company" InitialValue="Select" />
</td>
<td colspan="4">
</td>
</tr>
<tr id="tblrow1" runat="server">
<td width="10%">
Source Division
<asp:Label ID="label29" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlSourcedivisionadd" runat="server" AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlSourcedivisionadd_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="ddlSourcedivisionadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Division" InitialValue="Select" />
</td>
<td width="10%">
Source Area/Zone
<asp:Label ID="label30" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlSourcezoneadd" runat="server" AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddlSourcezoneadd_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="ddlSourcezoneadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Zone" InitialValue="Select" />
</td>
<td width="10%">
Source Center
<asp:Label ID="label31" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlSourcecenteradd" runat="server" CssClass="chzn-select" ValidationGroup="Grplead">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlSourcecenteradd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Center" InitialValue="Select" />
</td>
</tr>
<tr id="trtargetcompany" runat="server">
<td width="10%">
Target Company<asp:Label ID="label2" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddltargetcompanyadd" runat="server" AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddltargetcompanyadd_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddltargetcompanyadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Company" InitialValue="Select" />
</td>
<td colspan="4">
</td>
</tr>
<tr>
<td width="10%">
Target Division
<asp:Label ID="label32" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddltargetdivisionadd" runat="server" AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddltargetdivisionadd_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="ddltargetdivisionadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Division" InitialValue="Select" />
</td>
<td width="10%">
Target Area/Zone
<asp:Label ID="label33" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddltargetzoneadd" runat="server" AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead" OnSelectedIndexChanged="ddltargetzoneadd_SelectedIndexChanged">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="ddltargetzoneadd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Zone" InitialValue="Select" />
</td>
<td width="10%">
Target Center
<asp:Label ID="label34" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddltargetcenteradd" runat="server" CssClass="chzn-select" ValidationGroup="Grplead">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="ddltargetcenteradd" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Center" InitialValue="Select" />
</td>
</tr>
<tr id="tr11" runat="server" visible="false">
<%--<td width="10%">Role</td>
                                                <td width="20%"><asp:DropDownList ID="ddlrole" runat ="server" AutoPostBack ="true" Width="86%" ValidationGroup="Grplead" CssClass="chzn-select"></asp:DropDownList></td>--%>
<td width="10%">
Assigned To
</td>
<td width="20%">
<asp:TextBox ID="txtassignedto" runat="server" Width="86%" MaxLength="6" ValidationGroup="Grplead" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="txtassignedto" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Assign Contact to User" />
</td>
</tr>
</table>
</div>
</div>
</div>
</div>
</div>
<table id="Table1" class="table table-striped table-bordered table-advance table-hover" runat="server" visible="false">
<thead>
<tr>
<th colspan="6">
<asp:CheckBox ID="chkmaindevicedetails" runat="server" Checked="true" OnCheckedChanged="chkmaindevicedetails_CheckedChanged" AutoPostBack="true" /><span class="lbl"> <strong>Devices & Storage</strong>
</span>
</th>
</tr>
</thead>
</table>
<table class="table table-striped table-bordered table-advance table-hover" runat="server" id="tblrobodetails" visible="false">
<tr>
<td width="10%">
User Device
<asp:Label ID="label24" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddldevice" runat="server" TabIndex="21" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" Width="215px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddldevice" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device" InitialValue="Select" />
</td>
<td width="10%">
Provided by
<asp:Label ID="label26" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlprovidedby" runat="server" TabIndex="21" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" Width="215px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlprovidedby" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device Provided by" InitialValue="Select" />
</td>
<td width="10%">
Owned by
<asp:Label ID="label27" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlownedby" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" Width="215px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlownedby" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device Owned by" InitialValue="Select" />
</td>
</tr>
<tr>
<td width="10%">
Platform / OS
<asp:Label ID="label35" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlplatform" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" Width="215px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="ddlplatform" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device Platform" InitialValue="Select" />
</td>
<td width="10%">
Device Brand
<asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddldevicebrand" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" OnSelectedIndexChanged="ddldevicebrand_SelectedIndexChanged" Width="215px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="ddldevicebrand" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Device Brand" InitialValue="Select" />
</td>
<td width="10%">
Other Brand
<asp:Label ID="label39" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:TextBox ID="txtotherbrand" runat="server" placeholder="Other Brand" Enabled="false" ValidationGroup="Grplead" CssClass="input-large uppercase" Width="205px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator31" ControlToValidate="txtotherbrand" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Brand" Enabled="false" />
</td>
</tr>
<tr>
<td width="10%">
Device Model
<asp:Label ID="label41" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:TextBox ID="txtdevicemodel" runat="server" placeholder="Enter the model number" ValidationGroup="Grplead" Width="205px" CssClass="input-large uppercase"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator37" ControlToValidate="txtdevicemodel" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Device Model" />
</td>
<td width="10%">
Device Config
<asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%" colspan="3">
<asp:TextBox ID="txtdeviceconfig" runat="server" placeholder="Enter processor speed, RAM, Storage Capacity" ValidationGroup="Grplead" Width="90%" CssClass="uppercase"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="txtdeviceconfig" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Device Configuration" />
</td>
</tr>
<tr>
<td width="10%">
Access Mode
<asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlaccessmode" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" Width="215px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddlaccessmode" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Access Mode" InitialValue="Select" />
</td>
<td width="10%">
Storage Media Type
<asp:Label ID="label43" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlstoragemediatype" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" Width="215px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="ddlstoragemediatype" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Storage Media" InitialValue="Select" />
</td>
<td width="10%">
Capacity
<asp:Label ID="label44" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlcapacity" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" Width="215px">
<asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
<asp:ListItem Value="8" Text="8 GB"></asp:ListItem>
<asp:ListItem Value="16" Text="16 GB"></asp:ListItem>
<asp:ListItem Value="32" Text="32 GB"></asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="ddlcapacity" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Storage Capacity" InitialValue="0" />
</td>
</tr>
<tr>
<td width="10%">
HDD Free Space
<asp:Label ID="label45" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%" colspan="3">
<asp:TextBox ID="txthddfreespace" runat="server" placeholder="Enter Free Space required  in HDD for the product e.g. 40GB" ValidationGroup="Grplead" Width="90%" CssClass="uppercase"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="txthddfreespace" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Free Space Available on HDD" />
</td>
<td width="10%">
No. of Storage Media required
<%--<asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
</td>
<td width="20%">
<asp:DropDownList ID="ddlnoofstorage" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead" Width="215px">
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
<asp:TextBox ID="txtsi1" runat="server" placeholder="Special Instruction 1" ValidationGroup="Grplead" Width="90%" CssClass="uppercase"></asp:TextBox>
</td>
</tr>
<tr>
<td width="10%">
Special Instruction 2
</td>
<td width="20%" colspan="5">
<asp:TextBox ID="txtsi2" runat="server" placeholder="Special Instruction 2" ValidationGroup="Grplead" Width="90%" CssClass="uppercase"></asp:TextBox>
</td>
</tr>
<tr>
<td width="10%">
Special Instruction 3
</td>
<td width="20%" colspan="5">
<asp:TextBox ID="txtsi3" runat="server" placeholder="Special Instruction 3" ValidationGroup="Grplead" Width="90%" CssClass="uppercase"></asp:TextBox>
</td>
</tr>
</table>
<table class="table table-striped table-bordered table-advance table-hover" runat="server" id="tblrobodetails1" visible="false">
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
<asp:DropDownList ID="ddlinstallationlocation" runat="server" CssClass="chzn-select" ValidationGroup="Grplead" Width="215px">
<asp:ListItem Value="00" Text="Select" Selected="True"></asp:ListItem>
<asp:ListItem Value="01" Text="Home"></asp:ListItem>
<asp:ListItem Value="02" Text="Center"></asp:ListItem>
</asp:DropDownList>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="ddlinstallationlocation"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Installation Location"
                                                            InitialValue="00" />--%>
</td>
<td width="10%">
Appointment Date
<asp:Label ID="label48" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<%--<div class="row-fluid input-append date">--%>
<asp:TextBox ID="date_picker" Placeholder="Appointment Date" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
<CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker" DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
</CC1:CalendarExtender>
<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="date_picker" ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
<asp:Label ID="Label14" runat="server" ForeColor="#FF3300"></asp:Label>
<asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="date_picker" ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="date_picker" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Appointment Date" />
<%--</div>--%>
</td>
<td width="10%">
Appointment time
<asp:Label ID="label49" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<div class="input-append bootstrap-timepicker">
<input readonly="readonly" runat="server" class="timepicker span8" name="timepicker" id="timepicker1" placeholder="Select Time" data-placement="bottom" data-original-title="timepicker" validationgroup="Grplead" />
<span class="add-on"><i class="icon-time"></i></span>
<asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="timepicker1" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Appointment Time" />
</div>
</td>
</tr>
<tr>
<td width="10%">
Installation Date
<asp:Label ID="label50" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<%--<div class="row-fluid input-append date">--%>
<asp:TextBox ID="date_picker1" TabIndex="15" Placeholder="Installation Date" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
<CC1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker1" DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
</CC1:CalendarExtender>
<asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="date_picker1" ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
<asp:Label ID="Label16" runat="server" ForeColor="#FF3300"></asp:Label>
<asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ControlToValidate="date_picker1" ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="date_picker1" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Installation Date" />
<%-- </div>--%>
</td>
<td width="10%">
Installation time
<asp:Label ID="label52" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<%--<div class="input-append bootstrap-timepicker">--%>
<%--<input id="timepicker2" type="text" class="input-small" runat ="server" />--%>
<input readonly="readonly" runat="server" class="timepicker span8" name="timepicker" id="timepicker2" placeholder="Select Time" data-placement="bottom" data-original-title="timepicker" validationgroup="Grplead" />
<span class="add-on"><i class="icon-time"></i></span>
<asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="timepicker2" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Installation Time" />
<%--</div>--%>
</td>
<td width="10%">
Installation Status
<asp:Label ID="label51" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlinstallationstatus" runat="server" CssClass="chzn-select" ValidationGroup="Grplead" Width="215px">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="ddlinstallationstatus" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Installation Status" InitialValue="Select" />
</td>
</tr>
<tr>
<td width="10%">
Rescheduled Date
</td>
<td width="20%">
<%--<div class="row-fluid input-append date">--%>
<asp:TextBox ID="date_picker2" TabIndex="15" Placeholder="Rescheduled Date" runat="server" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
<CC1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker2" DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
</CC1:CalendarExtender>
<asp:RegularExpressionValidator ID="RegularExpressionValidator66" runat="server" ControlToValidate="date_picker2" ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
<asp:Label ID="Label22" runat="server" ForeColor="#FF3300"></asp:Label>
<asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server" ControlToValidate="date_picker2" ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
<%--</div>--%>
</td>
<td width="10%">
Rescheduled time
</td>
<td width="20%">
<%--<div class="input-append bootstrap-timepicker">--%>
<input readonly="readonly" runat="server" class="timepicker span8" name="timepicker" id="timepicker3" placeholder="Select Time" data-placement="bottom" data-original-title="timepicker" />
<%--<input id="timepicker3" type="text" class="input-small" runat ="server" />--%>
<span class="add-on"><i class="icon-time"></i></span>
<%--</div>--%>
</td>
<td width="10%">
Engineer Name
<asp:Label ID="label53" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:TextBox ID="txtengineername" runat="server" placeholder="Engineer Name" ValidationGroup="Grplead" CssClass="input-large uppercase" Width="205px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="txtengineername" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer Name" />
</td>
</tr>
<tr>
<td width="10%">
Contact Number
<asp:Label ID="label54" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:TextBox ID="txtengineercontactnumber" runat="server" placeholder="Contact number of Engineer" ValidationGroup="Grplead" CssClass="input-large uppercase" Width="205px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator47" ControlToValidate="txtengineercontactnumber" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer Contact Number" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator37" ControlToValidate="txtengineercontactnumber" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server" ControlToValidate="txtengineercontactnumber" ErrorMessage="Contact Number length must be between 7 to 18 characters" ValidationGroup="Grplead" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
</td>
<td width="10%">
Email Id
<%--<asp:Label ID="label55" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
</td>
<td width="20%">
<asp:TextBox ID="txtengineeremailid" runat="server" placeholder="Email id of Engineer " ValidationGroup="Grplead" CssClass="input-large uppercase" Width="205px"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server" ControlToValidate="txtengineeremailid" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Grplead" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
</td>
<td width="10%">
Company (Engineer)
<asp:Label ID="label56" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:TextBox ID="txtengineercompany" runat="server" placeholder="Company Engineer belongs to" ValidationGroup="Grplead" CssClass="input-large uppercase" Width="205px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="txtengineercompany" Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer's Company Name" />
<asp:Label ID="lblContactid" runat="server" Visible="false"></asp:Label>
</td>
</tr>
</table>
<div class="well" style="text-align:center;background-color:#F0F0F0">
<button class="btn btn-app btn-success btn-mini radius-4" id="btneditsubmit" runat="server" validationgroup="Grplead" onserverclick="btneditsubmit_ServerClick">
Save</button>
<%--<button class="btn btn-app btn-primary btn-mini radius-4" id="btnclear" runat="server"
                                                            onserverclick="btnclear_ServerClick">
                                                            Cancel</button>--%>
<button class="btn btn-app btn-primary btn-mini radius-4" id="btnclose" runat="server" onclick="javascript:window.close()">
Close</button>
</div>
<asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="Grplead" />
<div id="Div4" class="row-fluid" runat="server" visible="false">
<div class="span12">
<table class="table table-striped table-bordered table-advance table-hover">
<thead>
<tr>
<th>
Secondary Contact Details
</th>
<th width="20%">
<button type="button" class="btn btn-small btn-primary" id="btnaddcontact" runat="server" onserverclick="btnaddcontact_ServerClick">
<i class="icon-pencil"></i>Add Secondary Contact</button>
</th>
</tr>
</thead>
</table>
<asp:DataList ID="dlseccontact" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" OnItemCommand="dlseccontact_ItemCommand" OnItemDataBound="dlseccontact_ItemDataBound">
<HeaderTemplate>
<b>Type</b></th>
<th>
Name
</th>
<th>
Contact Details
</th>
<th>
Email Id
</th>
<th>
Institution
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
Action
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lblcontacttype" Text='<%#DataBinder.Eval(Container.DataItem, "Con_type_Desc")%>' runat="server"></asp:Label></td>
<td>
<asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "SecondaryName")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "handphone1")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "Emailid")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Board_Desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Standard_desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "Year_desc")%>' runat="server"></asp:Label>
</td>
<td>
<asp:LinkButton ID="lnkedit" runat="server" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Con_id")%>' class="btn btn-minier btn-primary icon-edit tooltip-info" data-rel="tooltip" data-placement="top" title="Edit"></asp:LinkButton>
</ItemTemplate>
</asp:DataList>
<div class="alert alert-danger" id="divseccontact" runat="server">
<strong>
<asp:Label ID="lblseccontact" runat="server"></asp:Label></strong>
</div>
</div>
</div>
<asp:Label ID="lblprimarycontactid" runat="server" Visible="false"></asp:Label>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<div class="row-fluid">
<HistoryPanel:HistoryPanel runat="server" ID="HistoryPanel1"></HistoryPanel:HistoryPanel>
</div>
<%--
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
<asp:Label ID="lblEvent_Description" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Description")%>' runat="server"></asp:Label>
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
<asp:Label ID="lblPhase" Text='<%#DataBinder.Eval(Container.DataItem, "Phase")%>' runat="server"></asp:Label></a> </td>
<td>
<asp:Label ID="lblusermailid" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_On")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lbluserid" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_With")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="lblusername" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_Relation")%>' runat="server"></asp:Label>
</td>
<td>
<asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Feedback")%>' runat="server" data-trigger="hover" data-placement="top" data-content='<%#DataBinder.Eval(Container.DataItem, "Feedback")%>'></asp:Label></a>
</td>
<td>
<asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "Nextfollowupdate")%>' runat="server"></asp:Label></a>
</td>
<td>
<asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Updated_By")%>' runat="server"></asp:Label></a>
</td>
</ItemTemplate>
</asp:DataList>
</div>
</div>
</div>
</div>
</div>
<div class="alert alert-danger" id="diverrormessagefeedback" runat="server">
<strong>
<asp:Label ID="lblerrrormessagefeedback" runat="server"></asp:Label></strong>
</div>--%>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="btneditsubmit" />
<%--<asp:PostBackTrigger ControlID="btnEditCon" />
                    <asp:PostBackTrigger ControlID="btnRefreshCon" />--%>
</Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpnlSecContact" runat="server">
<ContentTemplate>
<div class="row-fluid">
<div class="span12">
<div class="tabbable tabbable-custom tabbable-full-width">
<div class="tab-content">
<div id="Div5" class="tab-pane active">
<div class="row-fluid">
<div class="span12">
<div class="table-responsive">
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
<asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlseccontacttype2" Enabled="false" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Secondary Contact Type">
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1002" ControlToValidate="ddlseccontacttype2" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Contact Type" InitialValue="Select" />
</td>
<td width="10%">
Title
<asp:Label ID="label5" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlsectitle2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
<asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="1">Mr.</asp:ListItem>
<asp:ListItem Value="2">Ms.</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlsectitle2" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Title" InitialValue="Select" />
<asp:Label ID="lblprimaryconid" runat="server" Visible="false"></asp:Label>
</td>
</tr>
<tr>
<td width="10%">
First Name
<asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:TextBox ID="txtsecfname2" runat="server" Width="79%" ValidationGroup="Grplead2" placeholder="First Name"></asp:TextBox>
<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="txtsecfname2" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                --%>
<asp:RequiredFieldValidator ID="RequiredFiel45dValidator5" ControlToValidate="txtsecfname2" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Name" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtsecfname2" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
</td>
<td width="10%">
Middle Name
</td>
<td width="20%">
<asp:TextBox ID="txtsecmname2" runat="server" Width="79%" ValidationGroup="Grplead2" placeholder="Middle Name"></asp:TextBox>
<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="txtsecmname2" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                --%>
<asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="txtsecmname2" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
</td>
<td width="10%">
Last Name
</td>
<td width="20%">
<asp:TextBox ID="txtseclname2" runat="server" Width="79%" ValidationGroup="Grplead2" placeholder="Last Name"></asp:TextBox>
<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ControlToValidate="txtseclname2" ErrorMessage="Please input alphabets"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_]*$" />
                                                                --%><asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="txtseclname2" ErrorMessage="Please input alphabets" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
</td>
</tr>
<tr>
<td width="10%">
Handphone 1
</td>
<td width="20%">
<asp:TextBox ID="txtsechandphone12" runat="server" Width="79%" placeholder="Handphone 1" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator32" ControlToValidate="txtsechandphone12" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server" ControlToValidate="txtsechandphone12" ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
</td>
<td width="10%">
Handphone 2
</td>
<td width="20%">
<asp:TextBox ID="txtsechandphone22" runat="server" Width="79%" placeholder="Handphone 2" ValidationGroup="Grplead2" MaxLength="18" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator34" ControlToValidate="txtsechandphone22" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server" ControlToValidate="txtsechandphone22" ErrorMessage="Handphone length must be between 10 to 18 characters" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{10,18}$" />
</td>
<td width="10%">
Landline No.
</td>
<td width="20%">
<asp:TextBox ID="txtseclandline2" runat="server" Width="79%" placeholder="Landline No." ValidationGroup="Grplead2" MaxLength="18"></asp:TextBox>
<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator36" ControlToValidate ="txtseclandline2" Text ="#" runat ="server" ValidationGroup ="Grplead2" SetFocusOnError ="true" ErrorMessage ="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator37" runat="server" ControlToValidate="txtseclandline2" ErrorMessage="Handphone length must be between 7 to 18 characters"  ValidationGroup ="Grplead2" Text ="#" SetFocusOnError ="true"  ValidationExpression="^[0-9]{7,18}$" />
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
<tr>
<td width="10%">
Country Name
</td>
<td width="20%">
<asp:DropDownList ID="ddlseccountry2" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead2">
</asp:DropDownList>
</td>
<td width="10%">
State Name
</td>
<td width="20%">
<asp:DropDownList ID="ddlsecstate2" runat="server" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Grplead2">
</asp:DropDownList>
</td>
<td width="10%">
City Name
</td>
<td width="20%">
<asp:DropDownList ID="ddlseccity2" runat="server" AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead2">
</asp:DropDownList>
</td>
</tr>
<tr>
<td width="10%">
Location
</td>
<td width="20%">
<asp:DropDownList ID="ddlSeclocationedit" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
</asp:DropDownList>
</td>
<td width="10%">
Postal Code
</td>
<td width="20%">
<asp:TextBox ID="txtsecpincode2" runat="server" placeholder="Postal Code" MaxLength="10" ValidationGroup="Grplead2" Width="79%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator38" ControlToValidate="txtsecpincode2" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator39" ControlToValidate="txtsecpincode2" runat="server" ErrorMessage="Pincode length must be of 6-10 Character" ValidationGroup="Grplead2" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{6,10}$" />
</td>
</tr>
<tr>
<td width="10%">
Gender
<asp:Label ID="label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
</td>
<td width="20%">
<asp:DropDownList ID="ddlsecgender" TabIndex="14" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
<asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="1">Male</asp:ListItem>
<asp:ListItem Value="2">Female</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlsecgender" Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Gender" InitialValue="0" />
</td>
<td width="10%">
DOB
</td>
<td width="20%">
<asp:TextBox ID="txtsecdob" Placeholder="Date of Birth" runat="server" Width="79%" ValidationGroup="Grplead2"></asp:TextBox>
<CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtsecdob" DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
</CC1:CalendarExtender>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtsecdob" ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- ](0[1-9]|1[012])[- ](19|20)\d\d$"></asp:RegularExpressionValidator>
<asp:Label ID="Label13" runat="server" ForeColor="#FF3300"></asp:Label>
</td>
<td width="10%">
Email id
</td>
<td width="20%">
<asp:TextBox ID="txtsecemailid2" runat="server" Width="79%" placeholder="Email Id"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" ControlToValidate="txtsecemailid2" ErrorMessage="Email Address Not Valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Grplead2" SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
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
<asp:DropDownList ID="ddlinstitutiontype2" runat="server" AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Institution Type">
</asp:DropDownList>
</td>
<td width="10%">
Institution Name
</td>
<td width="20%">
<asp:TextBox ID="txtnameofinstitution2" runat="server" placeholder="Institution name" MaxLength="100" Width="79%" ValidationGroup="Grplead2" CssClass="popovers " data-trigger="hover" data-placement="top" data-content="Enter Institution Name"></asp:TextBox>
</td>
<td width="10%">
Board / University
</td>
<td width="20%">
<asp:DropDownList ID="ddlboard2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Board / University">
</asp:DropDownList>
</td>
</tr>
<tr>
<td width="10%">
Current Standard
</td>
<td width="20%">
<asp:DropDownList ID="ddlcurrentstudying2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2">
</asp:DropDownList>
</td>
<td width="10%">
Division / Section
</td>
<td width="20%">
<asp:DropDownList ID="ddlsection2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Division / Section / Grade">
</asp:DropDownList>
</td>
<td width="10%">
Year of Passing
</td>
<td width="20%">
<asp:DropDownList ID="ddlyearofpassing2" runat="server" CssClass="chzn-select" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Year of Passing">
</asp:DropDownList>
</td>
</tr>
<tr>
<td width="10%">
Notes, If Any
</td>
<td width="20%" colspan="5">
<asp:TextBox ID="txtadditiondesc2" runat="server" placeholder="Additional Information" Width="94%" MaxLength="100" CssClass="popovers " data-trigger="hover" data-placement="top" data-content="Enter Additional description (If Any)"></asp:TextBox>
</td>
</tr>
</table>
<div class="well" style="text-align:center;background-color:#F0F0F0">
<button class="btn btn-app btn-success btn-mini radius-4" id="btnSubmitSeccon" runat="server" validationgroup="Grplead2" onserverclick="btnSubmitSeccon_ServerClick">
Update <i class="m-icon-swapright m-icon-white"></i>
</button>
<button class="btn btn-app btn-primary btn-mini radius-4" id="btnclearSeccon" runat="server" onserverclick="btnclearSeccon_ServerClick">
Back <i class="m-icon-swapright m-icon-white"></i>
</button>
<asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ValidationGroup="Grplead2" ShowSummary="False" />
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="btnSubmitSeccon" />
<asp:PostBackTrigger ControlID="btnclearSeccon" />
<asp:PostBackTrigger ControlID="btnsearchlead" />
</Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>