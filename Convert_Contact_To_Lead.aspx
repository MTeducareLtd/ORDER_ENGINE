<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Convert_Contact_To_Lead.aspx.cs" Inherits="Convert_Contact_To_Lead" %>

<%@ Register TagPrefix="ContactInfoPanel" TagName="ContactInfoPanel" Src="~/UserControl/uc_Contact_Information.ascx" %>
<%@ Register TagPrefix="HistoryPanel" TagName="HistoryPanel" Src="~/UserControl/uc_Contact_FollowUp_History.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
    <script language="javascript" type="text/javascript">
// <![CDATA[       

// ]]>       
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname"
                        runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
                            <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                    <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                    <span class="divider"></span>
                </h5>
            </li>
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="Contacts.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
            <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
            </i><a href="#">
                <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
        </ul>
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
            
            <div class="row-fluid" runat="server" id="upnldisplay">
                <div class="span12">
                    <div id="Div3" class="row-fluid">
                        <div class="row-fluid">
                            <div class="span12">
                                
                                <!-- Secondary Contact Type  -->
                                <div class="row-fluid">
                                    <asp:Label ID="lblConId" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblCampaign_Id" runat="server" Visible="false"></asp:Label>
                                    <ContactInfoPanel:ContactInfoPanel runat="server" ID="ContactInfoPanel1"></ContactInfoPanel:ContactInfoPanel>
                                </div>
                                <div class="row-fluid">
                                    <div class="widget-box">
                                        <div class="widget-header widget-hea1der-small header-color-dark">
                                            <h5>
                                                Lead Basic Data
                                            </h5>
                                        </div>
                                        <div class="widget-body">
                                            <div class="widget-main">
                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                    <tr>
                                                        <td width="10%">
                                                            Lead Date
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txt1" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td width="20%" colspan="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Lead Type
                                                            <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            &nbsp; <span class="help-button ace-popover" data-trigger="hover" data-placement="right"
                                                                data-content="Type of the lead" title="Lead Type">?</span>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlleadtypeadd" runat="server" Width="215px" CssClass="chzn-select"
                                                                ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select lead type"
                                                                TabIndex="1">
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddlcustomertype" runat="server" Width="215px" CssClass="chzn-select"
                                                                Visible="false" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top"
                                                                data-content="Select lead type" TabIndex="1">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlleadtypeadd"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Lead Type"
                                                                InitialValue="Select" />
                                                        </td>
                                                        <td width="10%">
                                                            Lead Source
                                                            <%--<asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlleadsourceadd" runat="server" Width="215px" CssClass="chzn-select"
                                                                Enabled="false" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top"
                                                                data-content="Select lead Source" TabIndex="2">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ddlleadsourceadd"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Lead Source"
                                                                InitialValue="Select" />
                                                        </td>
                                                        <td width="10%">
                                                            Lead Status
                                                            <%--<asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlleadstatusadd" runat="server" Width="215px" CssClass="chzn-select"
                                                                Enabled="false" ValidationGroup="Grplead2" data-trigger="hover" data-placement="top"
                                                                data-content="Select lead Status" TabIndex="3">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="ddlleadstatusadd"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Lead Status"
                                                                InitialValue="Select" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%" id="td11" runat="server" visible="false">
                                                        </td>
                                                        <td width="20%" id="td12" runat="server" visible="false">
                                                        </td>
                                                        <td width="10%">
                                                            Source Description
                                                        </td>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="txtsourcedesc" runat="server" MaxLength="200" Width="90%" placeholder="Free Text"
                                                                TabIndex="5"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Course Interested In
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtproductInterested" runat="server" placeholder="Course Interested"
                                                                Width="205px" data-trigger="hover" data-placement="top" data-content="Enter Course Interested in"
                                                                CssClass="uppercase"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            Expected Joining Date
                                                            <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="20%">
                                                             <input readonly="readonly" class="span8 date-picker" id="txtExpjoindate" runat="server"
                                                                                type="text" data-date-format="dd M yyyy" style="width: 215px" />
                                                           <%-- <asp:TextBox ID="txtExpjoindate" placeholder="Expected Joining Date" runat="server"
                                                                Width="205px" ValidationGroup="Grplead2"></asp:TextBox>--%>
                                                            <%--<CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtExpjoindate"
                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                            </CC1:CalendarExtender>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ControlToValidate="txtExpjoindate"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Expected Join Date" />
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtExpjoindate"
                                                                ValidationGroup="Grplead2" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                            <asp:Label ID="lbldateerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="10%" colspan="2">
                                                            <%--Campaign ID--%>
                                                            <asp:DropDownList ID="ddlcampaignid" runat="server" Width="215px" CssClass="chzn-select"
                                                                TabIndex="4" Visible="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <%--<td width="20%">                                                                    
                                                                     
                                                                </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Examination Details
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtexaminationdetails" runat="server" data-content="Enter Examination Details"
                                                                data-placement="top" data-trigger="hover" Placeholder="Examination Details" ValidationGroup="Val4"
                                                                Width="205px"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            Expected Joining Acad. Year
                                                            <asp:Label ID="label1" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlacademicyear" runat="server" Width="215px" CssClass="chzn-select"
                                                                ValidationGroup="Grplead2" data-trigger="hover" data-placement="top" data-content="Select Expected Joining Academic Year">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="ddlacademicyear"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Expected Joining Current Academic Year"
                                                                InitialValue="Select" />
                                                        </td>
                                                        <td width="10%">
                                                            Current Year of Education
                                                            <asp:Label ID="label3" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlcurrentyeareducation" Width="215px" runat="server" ValidationGroup="Grplead2"
                                                                CssClass="chzn-select">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlcurrentyeareducation"
                                                                Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Current Year of Education"
                                                                InitialValue="Select" />
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trTest" visible="false">
                                                        <td width="10%">
                                                            Interested Discipline
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddldiscipline" Width="215px" runat="server" CssClass="chzn-select"
                                                                AutoPostBack="true" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddldiscipline_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Field Interested
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlfieldint" Width="215px" runat="server" CssClass="chzn-select"
                                                                ValidationGroup="Grplead2">
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
                                <div class="row-fluid">
                                    <asp:UpdatePanel ID="UpnlOrgAssignment" runat="server">
                                        <ContentTemplate>
                                            <div class="widget-box">
                                                <div class="widget-header widget-hea1der-small header-color-dark">
                                                    <h5>
                                                        Organization Assignments
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-main">
                                                        <table class="table table-striped table-bordered table-advance table-hover" id="tblorgassign"
                                                            runat="server">
                                                            <tr id="trSourcecompany" runat="server">
                                                                <td width="10%">
                                                                    Source Company<asp:Label ID="label28" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlsourcecompanyadd" Width="215px" runat="server" AutoPostBack="true"
                                                                        CssClass="chzn-select" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlcompanyadd_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlsourcecompanyadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Source Company"
                                                                        InitialValue="Select" />
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
                                                                    <asp:DropDownList ID="ddlSourcedivisionadd" Width="215px" runat="server" AutoPostBack="true"
                                                                        CssClass="chzn-select" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlSourcedivisionadd_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="ddlSourcedivisionadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Source Division"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Source Area/Zone
                                                                    <asp:Label ID="label30" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlSourcezoneadd" Width="215px" runat="server" AutoPostBack="true"
                                                                        CssClass="chzn-select" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddlSourcezoneadd_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="ddlSourcezoneadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Source Zone"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Source Center
                                                                    <asp:Label ID="label31" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlSourcecenteradd" Width="215px" runat="server" CssClass="chzn-select"
                                                                        ValidationGroup="Grplead2">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlSourcecenteradd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Source Center"
                                                                        InitialValue="Select" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trtargetcompany" runat="server">
                                                                <td width="10%">
                                                                    Target Company<asp:Label ID="label2" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddltargetcompanyadd" Width="215px" runat="server" AutoPostBack="true"
                                                                        CssClass="chzn-select" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddltargetcompanyadd_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddltargetcompanyadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Target Company"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td colspan="4">
                                                                </td>
                                                            </tr>
                                                            <tr id="trtargetrow2" runat="server">
                                                                <td width="10%">
                                                                    Target Division
                                                                    <asp:Label ID="label32" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddltargetdivisionadd" Width="215px" runat="server" AutoPostBack="true"
                                                                        CssClass="chzn-select" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddltargetdivisionadd_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="ddltargetdivisionadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Target Division"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Target Area/Zone
                                                                    <asp:Label ID="label33" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddltargetzoneadd" Width="215px" runat="server" AutoPostBack="true"
                                                                        CssClass="chzn-select" ValidationGroup="Grplead2" OnSelectedIndexChanged="ddltargetzoneadd_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="ddltargetzoneadd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Target Zone"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Target Center
                                                                    <asp:Label ID="label34" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddltargetcenteradd" Width="215px" runat="server" CssClass="chzn-select"
                                                                        ValidationGroup="Grplead2">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="ddltargetcenteradd"
                                                                        Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Target Center"
                                                                        InitialValue="Select" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="well" style="text-align: center; background-color: #F0F0F0">
                                    <!--Button Area -->
                                    <asp:Label runat="server" ID="Label55" Text="" ForeColor="Red" />
                                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnSaveConvertContactToLead"
                                        runat="server" OnClick="btnSaveConvertContactToLead_Click" Text="Save" ValidationGroup="Grplead2" />
                                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btnAssignLeadClose"
                                        runat="server" onclick="javascript:window.close()">
                                        Close</button>
                                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnCloseAll" runat="server"
                                        OnClick="btnCloseAll_Click" Text="Close" Visible="false" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Grplead2" ShowSummary="False" />
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">
                                        <HistoryPanel:HistoryPanel runat="server" ID="HistoryPanel1"></HistoryPanel:HistoryPanel>
                                    </div>
                                </div>
                            </div>
                          
                        </div>
                    </div>
                </div>
            </div>
          
            <div runat="server" id="DivMessage" class="row-fluid" visible="false">
                <div class="alert alert-success" id="div1" runat="server">
                    <strong>
                        <asp:Label ID="lblPKeyContactId" runat="server" Visible="false" />
                        <asp:Label ID="Label24" runat="server">Contact is successfully assign into Lead..! Do you want to convert into Opportunity?</asp:Label></strong>
                    &nbsp;&nbsp;
                    
                    <div class="btn-group" id="divConvertLeadToOpp" runat="server">
                        <a id="aConvertToOpp" runat="server" target="_blank" class="btn btn-app btn-primary btn-mini radius-4"
                            title="Convert To Opportunity">Yes</a>
                    </div>
                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btn_ConvertToOppNo"
                        ToolTip="NO" runat="server" OnClick="btn_ConvertToOppNo_Click" Text="No" Visible="false" />
                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btnclose" runat="server"
                        onclick="javascript:window.close()">
                        No</button>
                </div>
            </div>
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
