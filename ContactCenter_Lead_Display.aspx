<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ContactCenter_Lead_Display.aspx.cs" Inherits="ContactCenter_Lead_Display" %>

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
            <%-- <button type="button" class="btn btn-danger btn-small dropdown-toggle" data-toggle="dropdown"
                data-hover="dropdown" data-delay="1000" data-close-others="true">
                <span>Actions </span><i class="fa fa-angle-down"></i>
            </button>--%>
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
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Lead Date
                                                                        </td>
                                                                        <td width="20%" colspan="5">
                                                                            <asp:TextBox ID="txt1" runat="server" CssClass="input-large uppercase" Enabled="false"></asp:TextBox>
                                                                            <asp:DropDownList ID="ddlcustomertype" runat="server" CssClass="chzn-select"
                                                                                    ValidationGroup="Grplead" Visible="false" />
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
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Course Interested In
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtproductInterested" runat="server" placeholder="Course Interested"
                                                                                Enabled="false" Width="205px" data-trigger="hover" data-placement="top" data-content="Enter Course Interested in"
                                                                                CssClass="uppercase"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Expected Joining Acad. Year
                                                                            <asp:Label ID="label20" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlacademicyear" runat="server" Width="215px" CssClass="chzn-select"
                                                                                Enabled="false" ValidationGroup="Grplead" data-trigger="hover" data-placement="top"
                                                                                data-content="Select Expected Joining Academic Year">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ControlToValidate="ddlacademicyear"
                                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Expected Joining Current Academic Year"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Expected Joining Date
                                                                            <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtExpjoindate" placeholder="Expected Joining Date" runat="server"
                                                                                Enabled="false" Width="205px" ValidationGroup="Grplead"></asp:TextBox>
                                                                            <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtExpjoindate"
                                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                            </CC1:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ControlToValidate="txtExpjoindate"
                                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Expected Join Date" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtExpjoindate"
                                                                                ValidationGroup="Grplead" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                            <asp:Label ID="lbldateerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <%-- <td width="10%" colspan="2">
                                                                                  
                                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="215px" CssClass="chzn-select"
                                                                                        TabIndex="4" Visible="false">
                                                                                    </asp:DropDownList>
                                                                                </td>--%>
                                                                        <%--<td width="20%">                                                                    
                                                                     
                                                                </td>--%>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="widget-box">
                                                <div class="widget-header">
                                                    <h5>
                                                        Organization Assignments
                                                    </h5>
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
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlsourcecompanyadd" Enabled="false" runat="server" AutoPostBack="true"
                                                                        ValidationGroup="Grplead" CssClass="chzn-select">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlsourcecompanyadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Company"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td colspan="4">
                                                                </td>
                                                            </tr>
                                                            <tr id="tblrow1" runat="server">
                                                                <td width="10%">
                                                                    Source Division
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlSourcedivisionadd" Enabled="false" runat="server" AutoPostBack="true"
                                                                        ValidationGroup="Grplead" CssClass="chzn-select">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="ddlSourcedivisionadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Division"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Source Area/Zone
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlSourcezoneadd" Enabled="false" runat="server" AutoPostBack="true"
                                                                        ValidationGroup="Grplead" CssClass="chzn-select">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="ddlSourcezoneadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Zone"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Source Center
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlSourcecenteradd" Enabled="false" runat="server" ValidationGroup="Grplead"
                                                                        CssClass="chzn-select">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlSourcecenteradd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Source Center"
                                                                        InitialValue="Select" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trtargetcompany" runat="server">
                                                                <td width="10%">
                                                                    Target Company
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddltargetcompanyadd" Enabled="false" runat="server" AutoPostBack="true"
                                                                        ValidationGroup="Grplead" CssClass="chzn-select">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddltargetcompanyadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Company"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td colspan="4">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="10%">
                                                                    Target Division
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddltargetdivisionadd" Enabled="false" runat="server" AutoPostBack="true"
                                                                        ValidationGroup="Grplead" CssClass="chzn-select">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="ddltargetdivisionadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Division"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Target Area/Zone
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddltargetzoneadd" Enabled="false" runat="server" AutoPostBack="true"
                                                                        ValidationGroup="Grplead" CssClass="chzn-select">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="ddltargetzoneadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Zone"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Target Center
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddltargetcenteradd" Enabled="false" runat="server" ValidationGroup="Grplead"
                                                                        CssClass="chzn-select">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="ddltargetcenteradd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Target Center"
                                                                        InitialValue="Select" />
                                                                </td>
                                                            </tr>
                                                            <tr id="tr11" runat="server" visible="false">
                                                                <%--<td width="10%">Role</td>
                                                <td width="20%"><asp:DropDownList ID="ddlrole" runat ="server" AutoPostBack ="true" Width="86%" ValidationGroup ="Grplead" CssClass="chzn-select"></asp:DropDownList></td>--%>
                                                                <td width="10%">
                                                                    Assigned To
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:TextBox ID="txtassignedto" runat="server" Width="79%" MaxLength="6" ValidationGroup="Grplead"
                                                                        onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="txtassignedto"
                                                                        Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Assign Contact to User" />
                                                                </td>
                                                                <td colspan="4">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:Label ID="lblprimarycontactid" runat="server" Visible="false"></asp:Label>
                                            <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                visible="false">
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
                                                id="tblrobodetails" visible="false">
                                                <tr>
                                                    <td width="10%">
                                                        User Device
                                                        <asp:Label ID="label24" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldevice" runat="server" TabIndex="21" CssClass="chzn-select"
                                                            AutoPostBack="true" ValidationGroup="Grplead" Enabled="false">
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
                                                        <asp:DropDownList ID="ddlprovidedby" runat="server" TabIndex="21" CssClass="chzn-select"
                                                            AutoPostBack="true" ValidationGroup="Grplead" Enabled="false">
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
                                                        <asp:DropDownList ID="ddlownedby" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead" Enabled="false">
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
                                                        <asp:DropDownList ID="ddlplatform" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead" Enabled="false">
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
                                                        <asp:DropDownList ID="ddldevicebrand" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead" OnSelectedIndexChanged="ddldevicebrand_SelectedIndexChanged"
                                                            Enabled="false">
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
                                                        <asp:TextBox ID="txtotherbrand" runat="server" placeholder="Other Brand" Enabled="false"
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtotherbrand"
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
                                                        <asp:TextBox ID="txtdevicemodel" runat="server" Enabled="false" placeholder="Enter the model number"
                                                            ValidationGroup="Grplead" Width="62%" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" ControlToValidate="txtdevicemodel"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Device Model" />
                                                    </td>
                                                    <td width="10%">
                                                        Device Config
                                                        <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan="3">
                                                        <asp:TextBox ID="txtdeviceconfig" runat="server" Enabled="false" placeholder="Enter processor speed, RAM, Storage Capacity"
                                                            ValidationGroup="Grplead" Width="85%" CssClass="uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtdeviceconfig"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Device Configuration" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Access Mode
                                                        <asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlaccessmode" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead" Enabled="false">
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
                                                        <asp:DropDownList ID="ddlstoragemediatype" runat="server" CssClass="chzn-select"
                                                            AutoPostBack="true" ValidationGroup="Grplead" Enabled="false">
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
                                                        <asp:DropDownList ID="ddlcapacity" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead" Enabled="false">
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
                                                            ValidationGroup="Grplead" Width="85%" CssClass="uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="txthddfreespace"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Free Space Available on HDD" />
                                                    </td>
                                                    <td width="10%">
                                                        No. of Storage Media required
                                                        <asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlnoofstorage" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                            ValidationGroup="Grplead" Enabled="false">
                                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" ControlToValidate="ddlnoofstorage"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Select Number of Storage"
                                                            InitialValue="0" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Special Instruction 1
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtsi1" runat="server" Enabled="false" placeholder="Special Instruction 1"
                                                            ValidationGroup="Grplead" Width="90%" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Special Instruction 2
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtsi2" runat="server" Enabled="false" placeholder="Special Instruction 2"
                                                            ValidationGroup="Grplead" Width="90%" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Special Instruction 3
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <asp:TextBox ID="txtsi3" runat="server" Enabled="false" placeholder="Special Instruction 3"
                                                            ValidationGroup="Grplead" Width="90%" CssClass="uppercase"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                                id="tblrobodetails1" visible="false">
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
                                                        <asp:DropDownList ID="ddlinstallationlocation" runat="server" CssClass="chzn-select"
                                                            ValidationGroup="Grplead" Enabled="false">
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
                                                        <%--<div class="row-fluid input-append date">--%>
                                                        <asp:TextBox ID="date_picker" Placeholder="Appointment Date" runat="server" Width="205px"
                                                            ValidationGroup="Grplead" Enabled="false"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                            ControlToValidate="date_picker" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                            ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="Label14" runat="server" ForeColor="#FF3300"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                            ControlToValidate="date_picker" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                            ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="date_picker"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Appointment Date" />
                                                        <%-- </div>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Appointment time
                                                        <asp:Label ID="label49" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <%--<div class="input-append bootstrap-timepicker">--%>
                                                        <input readonly="readonly" runat="server" class="timepicker span8" enabled="false"
                                                            name="timepicker" id="timepicker1" placeholder="Select Time" data-placement="bottom"
                                                            data-original-title="timepicker" validationgroup="Grplead" />
                                                        <span class="add-on"><i class="icon-time"></i></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="timepicker1"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Appointment Time" />
                                                        <%--</div>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Installation Date
                                                        <asp:Label ID="label50" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <%--<div class="row-fluid input-append date">--%>
                                                        <asp:TextBox ID="date_picker1" Placeholder="Installation Date" runat="server" Width="62%"
                                                            ValidationGroup="Grplead" Enabled="false"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker1"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                                            ControlToValidate="date_picker1" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                            ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="Label16" runat="server" ForeColor="#FF3300"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server"
                                                            ControlToValidate="date_picker1" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                            ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="date_picker1"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Installation Date" />
                                                        <%--</div>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Installation time
                                                        <asp:Label ID="label52" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <%--<div class="input-append bootstrap-timepicker">--%>
                                                        <%--<input id="timepicker2" type="text" class="input-small" runat ="server" />--%>
                                                        <input readonly="readonly" runat="server" enabled="false" class="timepicker span8"
                                                            name="timepicker" id="timepicker2" placeholder="Select Time" data-placement="bottom"
                                                            data-original-title="timepicker" validationgroup="Grplead" />
                                                        <span class="add-on"><i class="icon-time"></i></span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="timepicker2"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Installation Time" />
                                                        <%--</div>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Installation Status
                                                        <asp:Label ID="label51" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlinstallationstatus" Enabled="false" runat="server" CssClass="chzn-select"
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
                                                        <%--<div class="row-fluid input-append date">--%>
                                                        <asp:TextBox ID="date_picker2" Enabled="false" Placeholder="Rescheduled Date" runat="server"
                                                            Width="62%" ValidationGroup="Grplead"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="date_picker2"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator66" runat="server"
                                                            ControlToValidate="date_picker2" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                            ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                        <asp:Label ID="Label22" runat="server" ForeColor="#FF3300"></asp:Label>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server"
                                                            ControlToValidate="date_picker2" ValidationGroup="Grplead" Text="#" SetFocusOnError="True"
                                                            ErrorMessage="Please Enter a valid date" ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                        <%-- </div>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Rescheduled time
                                                    </td>
                                                    <td width="20%">
                                                        <%--<div class="input-append bootstrap-timepicker">--%>
                                                        <input readonly="readonly" runat="server" enabled="false" class="timepicker span8"
                                                            name="timepicker" id="timepicker3" placeholder="Select Time" data-placement="bottom"
                                                            data-original-title="timepicker" />
                                                        <%--<input id="timepicker3" type="text" class="input-small" runat ="server" />--%>
                                                        <span class="add-on"><i class="icon-time"></i></span>
                                                        <%--</div>--%>
                                                    </td>
                                                    <td width="10%">
                                                        Engineer Name
                                                        <asp:Label ID="label53" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtengineername" Enabled="false" runat="server" placeholder="Engineer Name"
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="txtengineername"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer Name" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Contact Number
                                                        <asp:Label ID="label54" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtengineercontactnumber" Enabled="false" runat="server" placeholder="Contact number of Engineer"
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" ControlToValidate="txtengineercontactnumber"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer Contact Number" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator37" ControlToValidate="txtengineercontactnumber"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server"
                                                            ControlToValidate="txtengineercontactnumber" ErrorMessage="Contact Number length must be between 7 to 18 characters"
                                                            ValidationGroup="Grplead" Text="#" SetFocusOnError="true" ValidationExpression="^[0-9]{7,18}$" />
                                                    </td>
                                                    <td width="10%">
                                                        Email Id
                                                        <asp:Label ID="label55" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtengineeremailid" Enabled="false" runat="server" placeholder="Email id of Engineer "
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server"
                                                            ControlToValidate="txtengineeremailid" ErrorMessage="Email Address Not Valid"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Grplead"
                                                            SetFocusOnError="True" Text="#"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td width="10%">
                                                        Company (Engineer)
                                                        <asp:Label ID="label56" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtengineercompany" Enabled="false" runat="server" placeholder="Company Engineer belongs to"
                                                            ValidationGroup="Grplead" CssClass="input-large uppercase"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="txtengineercompany"
                                                            Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="True" ErrorMessage="Enter Engineer's Company Name" />
                                                        <asp:Label ID="lblContactid" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclose" runat="server"
                                                    onclick="javascript:window.close()">
                                                    Close</button>
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
                    <%--<asp:PostBackTrigger ControlID="btnaddlead" />--%>
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR DISPLAY-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
