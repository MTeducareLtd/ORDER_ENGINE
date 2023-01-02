<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Manage_Seminar_Attendance.aspx.cs" Inherits="Manage_Seminar_Attendance" %>

<script runat="server">
    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">       
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="HomePage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Manage Seminar Attendance<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <!--/page-header-->
        <div class="row-fluid">
            <!-- -->
            <!-- PAGE CONTENT BEGINS HERE -->
            <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="alert alert-block alert-success" id="Msg_Success" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-ok"></i></strong>
                            <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                    <div class="alert alert-error" id="Msg_Error" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-remove"></i>Error!</strong>
                            <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="DivSearchPanel" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Search Options
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                Seminar Date
                                                                <asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                 <input readonly="readonly" class="span8 date-picker" id="txtSeminarDate123" runat="server"
                                                                                type="text" data-date-format="dd M yyyy" style="width:215px" />
                                                                <%--<asp:DropDownList ID="ddlSeminar" ValidationGroup="Validation10" runat="server" data-placeholder="Select"
                                                                    CssClass="chzn-select">
                                                                </asp:DropDownList>--%>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlSeminar"
                                                                    Text="#" runat="server" ValidationGroup="Validation10" SetFocusOnError="True"
                                                                    ErrorMessage="Select Seminar" InitialValue="Select" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    Text="Search" ToolTip="Search" ValidationGroup="Validation10" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                    ValidationGroup="Validation10" ShowSummary="False" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivAttendancePanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        
                            <table width="100%">
                                <tr>
                                    <td class="span12" style="text-align: left">
                                        <h5 class="modal-title">
                                            Seminar Attendance
                                        </h5>
                                    </td>
                                </tr>
                            </table>
                        
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DataList ID="dlSeminarAttendance" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                            OnItemCommand="dlSeminarAttendance_ItemCommand">
                                            <HeaderTemplate>
                                                <b class="center" style="text-align: center">Seminar Date</b></th>
                                                 <th align="center" style="text-align: center">
                                                    Student Name
                                                </th>
                                                <th align="center" style="text-align: center">
                                                    Mobile No
                                                </th>
                                                <th align="center" style="text-align: center">
                                                    EmailId
                                                </th>
                                                <th align="center" style="text-align: center">
                                                    <asp:CheckBox ID="chkAttendanceAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAttendanceAll_CheckedChanged" />
                                                    <span class="lbl"></span>&nbsp;&nbsp;Select All Attendance<br />
                                                </th>
                                                <th align="center" style="text-align: center">
                                                    Reason
                                                </th>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                 <asp:Label ID="lblSeminarDate" Text='<%#DataBinder.Eval(Container.DataItem, "SeminarDate")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                <asp:Label ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem, "StudName")%>'
                                                    runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblMobileNo" Text='<%#DataBinder.Eval(Container.DataItem, "MobileNo")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblEmailId" Text='<%#DataBinder.Eval(Container.DataItem, "EmailID")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td align="center" style="text-align: center">
                                                    <asp:CheckBox ID="chkStudent" runat="server" Checked='<%#(int)DataBinder.Eval(Container.DataItem,"StudentSelFlag") == 1 ? true : false %>' />
                                                    <span class="lbl"></span>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDLAbsentReasonID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AbsentReason")%>'
                                                        Visible="false" />
                                                    <asp:DropDownList runat="server" ID="ddlabsentreason" Width="215px" data-placeholder="Select Reason"
                                                        CssClass="chzn-select" AutoPostBack="True" Visible="true" />
                                                    <asp:Label ID="lblLeadId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LeadId")%>'
                                                        Visible="false" />
                                                    <asp:Label ID="lblSeminarDate12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SeminarDate")%>'
                                                        Visible="false" />
                                                    <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                        <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                            <i class="icon-bolt"></i>
                                                        </asp:Panel>
                                                    </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table cellpadding="3" class="table table-striped table-bordered table-condensed"
                                            runat="server" id="tblFooter">
                                            <tr>
                                                <td class="span3" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="Label54">Total Student</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: center; width: 40%;">
                                                                <asp:Label runat="server" class="blue" ID="lblSummary_TotalSeminarStudent" Font-Bold="True"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span3" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="Label1">Present Count</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: center; width: 40%;">
                                                                <asp:Label runat="server" class="blue" ID="lblSummary_PresentCount" Font-Bold="True"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span3" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="Label58">Absent Count</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: center; width: 40%;">
                                                                <asp:Label runat="server" class="blue" ID="lblSummary_AbsentCount" Font-Bold="True"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span3" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="Label62">Not Marked</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" class="blue" ID="lblSummary_NMCount" Font-Bold="True"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Label runat="server" ID="Label55" Text="" ForeColor="Red" />
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnSave" runat="server"
                                Text="Save" ValidationGroup="Val6" OnClick="btnSave_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnClose" Visible="true"
                                runat="server" Text="Close" OnClick="btnClose_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="Val6" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--/row-->
</asp:Content>
