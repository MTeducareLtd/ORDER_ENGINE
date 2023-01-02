<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Manage_CampaignEvents_AttendanceFeedback.aspx.cs" Inherits="Manage_CampaignEvents_AttendanceFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 45 && AsciiValue <= 57))
                event.returnValue = true;
            else
                event.returnValue = false;
        }
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else
                event.returnValue = false;
        }

        function NumberandCharOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || AsciiValue == 40 || AsciiValue == 41 || AsciiValue == 45)
                event.returnValue = true;
            else
                event.returnValue = false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Manage Campaign Events Attendance Feedback <span class="divider"></span>
                </h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" ToolTip="Search" OnClick="BtnShowSearchPanel_Click" />
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
                            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
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
            <div id="DivSearch" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label2" runat="server" Text="Search Campaign Events Detail"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                      <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label8" CssClass="red">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlAcadYear" Width="215px" data-placeholder="Select Acad Year"
                                                                    CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlAcadYear_SelectedIndexChanged"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                          <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3" CssClass="red">Campaign</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCampaign" Width="215px" data-placeholder="Select Campaign Type"
                                                                    CssClass="chzn-select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSearch"
                                    Text="Search" ToolTip="Search" OnClick="btnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                                <asp:Label runat="server" ID="lblCampaignID" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <div class="span12" style="text-align: left;">
                            <h5 class="modal-title">
                                Campaign Detail
                            </h5>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main">
                            <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                <tr>
                                    <td class="span4" style="text-align: left">
                                        <table style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" ID="Label7">Campaign Type</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:Label runat="server" ID="lblCampaignType_Result1" Text="SMS" CssClass="blue" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="span4" style="text-align: left">
                                        <table style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" ID="Label9">Campaign Name</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:Label runat="server" ID="lblCampaignName_Result1" Text="Test" CssClass="blue" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="span4" style="text-align: left">
                                        <table style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" ID="Label10">Campaign Status</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:Label runat="server" ID="lblCampaignStatus_Result1" Text="Test" CssClass="blue" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="span4" style="text-align: left">
                                        <table style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" ID="Label11">Target Audience</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:Label ID="lblTargetAudience_Result1" runat="server" class="blue">ABC</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="span4" style="text-align: left">
                                        <table style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" ID="Label12">Campaign Sponsor</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:Label ID="lblCampSponsor_Result1" runat="server" class="blue"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="span4" style="text-align: left">
                                        <table style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" ID="Label13">Sponsor Description</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:Label ID="lblCampSponsoDesc_Result1" runat="server" class="blue"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="span4" style="text-align: left">
                                        <table style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" ID="Label14">Expected Close Date</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:Label ID="lblExpectedCloseDate_Result1" runat="server" class="blue">12 Dec. 2015</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="span4" style="text-align: left">
                                        <table style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" ID="Label15">Total contacts in campaign</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:Label ID="lblTotalAssignedCampaignContacts_Result1" runat="server" class="blue"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="span4" style="text-align: left">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div id="divEventDetail" runat="server">
                    <div class="widget-box">
                        <div class="widget-header widget-header-small header-color-dark">
                            <div class="span12" style="text-align: left;">
                                <h5 class="modal-title">
                                    Campaign Event Detail
                                </h5>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="widget-body-inner">
                                <div class="widget-main">
                                    <asp:DataList ID="dlCampaignEvents" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%" OnItemCommand="dlCampaignEvents_ItemCommand">
                                        <HeaderTemplate>
                                            <b>Event Name</b> </th>
                                            <th style="width: 50%; text-align: center;">
                                                Event Period
                                            </th>
                                            <th style="width: 8%; text-align: center;">
                                                Action
                                            </th>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCampaignEventId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCampaignId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCampaignEventName" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventName")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDLCampaignEventPeriod" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventPeriodDesc")%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton ID="lnkDLEvents_Attendance" ToolTip="Manage Event Attendance" class="btn-small btn-success icon-ok"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'
                                                    runat="server" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"AttendanceFlag") == 1 ? true : false%>'
                                                    CommandName="Event_Attendance" Height="25px" />
                                                <asp:LinkButton ID="lnkDLEvent_Feedback" ToolTip="Manage Event Feedback" class="btn-small btn-primary icon-group"
                                                    runat="server" CommandName="Event_Feedback" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"FeedbackFlag") == 1 ? true : false%>' />
                                            </td>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="divEventAttendance" runat="server">
                    <div class="widget-box">
                        <div class="widget-header widget-header-small header-color-dark">
                            <div class="span12" style="text-align: left;">
                                <h5 class="modal-title">
                                    Campaign Event Attendance
                                </h5>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="widget-body-inner">
                                <div class="widget-main">
                                    <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                        <tr>
                                            <td class="span6" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label1" CssClass="red">Event Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblCampaignEventName" CssClass="blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span6" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label4" CssClass="red">Event Period</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblCampaignEventPeriod" CssClass="blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                    <asp:DataList ID="dlEventAttendance" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%">
                                        <HeaderTemplate>
                                            <b>Student</b> </th>
                                            <th style="width: 50%; text-align: center;">
                                                <asp:CheckBox ID="chkAttendanceAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAttendanceAll_CheckedChanged" />
                                                <span class="lbl"></span>&nbsp;&nbsp;Select All Attendance<br />
                                            </th>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCampaignEventId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCampaignId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCon_Id" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Con_Id")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem,"StudName")%>'></asp:Label>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:CheckBox ID="chkStudent" runat="server" Checked='<%#(int)DataBinder.Eval(Container.DataItem,"AttendStatus") == 1 ? true : false %>' />
                                                <span class="lbl"></span>
                                            </td>
                                        </ItemTemplate>
                                    </asp:DataList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dlEventAttendance" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="well" style="text-align: center; background-color: #F0F0F0">
                                        <!--Button Area -->
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                        <asp:Button class="btn btn-app  btn-success btn-mini radius-4" ID="btnAllStudAttend_Save"
                                            ToolTip="Save" runat="server" Text="Save" OnClick="btnAllStudAttend_Save_Click" />
                                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnCloseAttendance"
                                            runat="server" Text="Close" OnClick="BtnCloseAttendance_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnAllStudAttend_Save" />
                                            <asp:PostBackTrigger ControlID="BtnCloseAttendance" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="divEventFeedback" runat="server">
                    <div class="widget-box">
                        <div class="widget-header widget-header-small header-color-dark">
                            <div class="span12" style="text-align: left;">
                                <h5 class="modal-title">
                                    Campaign Event Feedback
                                </h5>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="widget-body-inner">
                                <div class="widget-main">
                                    <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                        <tr>
                                            <td class="span6" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label5" CssClass="red">Event Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblCampaignEventName1" CssClass="blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span6" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label6" CssClass="red">Event Period</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblCampaignEventPeriod1" CssClass="blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:UpdatePanel ID="upnlsearch" runat="server">
                                        <ContentTemplate>
                                            <asp:DataList ID="dlEventFeedback" CssClass="table table-striped table-bordered table-hover"
                                                runat="server" Width="100%">
                                                <HeaderTemplate>
                                                    <b>Student</b> </th>
                                                    <th style="width: 20%; text-align: center;">
                                                        Feedback 1
                                                    </th>
                                                    <th style="width: 20%; text-align: center;">
                                                        Feedback 2
                                                    </th>
                                                    <th style="width: 20%; text-align: center;">
                                                        Feedback 3
                                                    </th>
                                                   <%-- <th style="width: 10%; text-align: center; vertical-align: middle;">
                                                    </th>--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblCampaignEventId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lblCampaignId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lblCon_Id" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Con_Id")%>'></asp:Label>
                                                    <asp:Label runat="server" ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem,"StudName")%>'></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:Label runat="server" ID="lblCampaignFeedback1" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedback1")%>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblCampaignFeedbackID1" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedbackID1")%>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblCampaignFeedbackValue1" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedbackValue1")%>'></asp:Label>
                                                        <asp:DropDownList runat="server" ID="ddlFeedBackValue1" Width="215px" ToolTip="Feedback Value 1"
                                                            data-placeholder="Select FeedBack Value 1" CssClass="chzn-select"  />
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:Label runat="server" ID="lblCampaignFeedback2" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedback2")%>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblCampaignFeedbackID2" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedbackID2")%>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblCampaignFeedbackValue2" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedbackValue2")%>'></asp:Label>
                                                        <asp:DropDownList runat="server" ID="ddlFeedBackValue2" Width="215px" ToolTip="Feedback Value 2"
                                                            data-placeholder="Select FeedBack Value 2" CssClass="chzn-select"  />
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:Label runat="server" ID="lblCampaignFeedback3" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedback3")%>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblCampaignFeedbackID3" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedbackID3")%>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblCampaignFeedbackValue3" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignFeedbackValue3")%>'></asp:Label>
                                                        <asp:DropDownList runat="server" ID="ddlFeedBackValue3" Width="215px" ToolTip="Feedback Value 3"
                                                            data-placeholder="Select FeedBack Value 3" CssClass="chzn-select"  />
                                                    </td>
                                                    <%--<td style="text-align: center; vertical-align: middle;">
                                                        <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                            <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                                <i class="icon-bolt"></i>
                                                            </asp:Panel>
                                                        </a>
                                                    </td>--%>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dlEventFeedback" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="well" style="text-align: center; background-color: #F0F0F0">
                                        <!--Button Area -->
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        <asp:Button class="btn btn-app  btn-success btn-mini radius-4" ID="btnAllStudFeed_Save"
                                            ToolTip="Save" runat="server" Text="Save" OnClick="btnAllStudFeed_Save_Click" />
                                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnCloseFeedback"
                                            runat="server" Text="Close" OnClick="BtnCloseFeedback_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnAllStudFeed_Save" />
                                            <asp:PostBackTrigger ControlID="BtnCloseFeedback" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
