<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Campaign_Events.aspx.cs" Inherits="Campaign_Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 45 && AsciiValue <= 57))
                event.returnValue = true;
            else
                event.returnValue = false;
        }

        function Showalert() {
            alert('Call JavaScript function from codebehind');
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
                    Manage Campaign-Events<span class="divider"></span></h5>
            </li>
        </ul>
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
            <div id="divCampaignDetail" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="lblEventDetail" runat="server" Text="Campaign Detail"></asp:Label>
                            <asp:Label ID="lblCampaignId" runat="server" class="blue" Visible="false"></asp:Label>
                        </h5>
                        <button id="btnCloseCampaignEvent" runat="server" data-rel="tooltip" data-placement="left"
                            title="Manage Campaign" onserverclick="btnCloseCampaignEvent_ServerClick">
                            <i class="icon-remove"></i>
                        </button>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                    <tr>
                                        <td class="span4" style="text-align: left">
                                            <table style="border-style: none;" class="table-hover" width="100%">
                                                <tr>
                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                        <asp:Label runat="server" ID="Label29">Campaign Type</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label runat="server" ID="lblCampaignType_Result" Text="" CssClass="blue" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="span4" style="text-align: left">
                                            <table style="border-style: none;" class="table-hover" width="100%">
                                                <tr>
                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                        <asp:Label runat="server" ID="LabelCampName">Campaign Name</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label runat="server" ID="lblCampaignName_Result" Text="" CssClass="blue" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="span4" style="text-align: left">
                                            <table style="border-style: none;" class="table-hover" width="100%">
                                                <tr>
                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                        <asp:Label runat="server" ID="Label45">Campaign Status</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label runat="server" ID="lblCampaignStatus_Result" Text="" CssClass="blue" />
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
                                                        <asp:Label runat="server" ID="Lbl43">Target Audience</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label ID="lblTargetAudience_Result" runat="server" class="blue"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="span4" style="text-align: left">
                                            <table style="border-style: none;" class="table-hover" width="100%">
                                                <tr>
                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                        <asp:Label runat="server" ID="Label30">Campaign Sponsor</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label ID="lblCampSponsor_Result" runat="server" class="blue"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="span4" style="text-align: left">
                                            <table style="border-style: none;" class="table-hover" width="100%">
                                                <tr>
                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                        <asp:Label runat="server" ID="Label46">Sponsor Description</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label ID="lblCampSponsoDesc_Result" runat="server" class="blue"></asp:Label>
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
                                                        <asp:Label runat="server" ID="Label31">Expected Close Date</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label ID="lblExpectedCloseDate_Result" runat="server" class="blue"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="span4" style="text-align: left">
                                            <table style="border-style: none;" class="table-hover" width="100%">
                                                <tr>
                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                        <asp:Label runat="server" ID="Label47">Already Assign Contact for Campaign</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label ID="lblCountCampaignContact_Result" runat="server" class="blue"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="span4" style="text-align: left">
                                            <table style="border-style: none;" class="table-hover" width="100%">
                                                <tr>
                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                        <asp:Label runat="server" ID="Label4">User/Agent</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:Label ID="lblCampaignUserAgent_Result" runat="server" class="blue"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divCampaignEventAllDetail" runat="server">
            <div id="divCampaignEventDetails" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="lblCampaignEventDetails" runat="server" Text="Campaign Event Detail"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <div class="row-fluid">
                                     <%--<asp:UpdatePanel ID="upnlsearch" runat="server">
                                        <ContentTemplate>--%>
                                    <asp:DataList ID="dlGridEvents" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%" OnItemCommand="dlGridEvents_ItemCommand">
                                        <HeaderTemplate>
                                            <b>Event Name</b> </th>
                                            <th style="width: 30%; text-align: center;">
                                                Event Period
                                            </th>
                                            <th style="width: 14%; text-align: center;">
                                                Attendance
                                            </th>
                                            <th style="width: 14%; text-align: center;">
                                                Feedback
                                            </th>
                                            <th style="width: 8%; text-align: center;">
                                                Action
                                            </th>
                                            <th style="width: 8%; text-align: center; vertical-align: middle;">
                                            </th>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCampaignEventId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCampaignEventName" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventName")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'>
                                            </asp:Label>
                                            <asp:TextBox ID="txtCampaignEventName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventName")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                                Width="95%" placeholder="Campaign Event Name" ToolTip="Campaign Event Name">
                                            </asp:TextBox>
                                            </td>
                                            <td>
                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span12" name="date-range-picker"
                                                    visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                                    value='<%#DataBinder.Eval(Container.DataItem,"CampaignEventPeriod")%>' id="txtCampaignEventPeriod"
                                                    placeholder="Campaign Event Period" data-placement="bottom" data-original-title="Date Range" />
                                                <asp:Label ID="lblDLCampaignEventPeriod" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventPeriodDesc")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:CheckBox ID="chkAttendance" runat="server" Checked='<%#(int)DataBinder.Eval(Container.DataItem,"AttendanceFlag") == 1 ? true : false%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>' />
                                                <span class="lbl"></span>
                                                <asp:Label ID="lblDLAttendance" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Attendance")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:CheckBox ID="chkFeedBack" runat="server" Checked='<%#(int)DataBinder.Eval(Container.DataItem,"FeedbackFlag") == 1 ? true : false%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>' />
                                                <span class="lbl"></span>
                                                <asp:Label ID="lblDLFeedBack" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Feedback")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton ID="lnkDLEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'
                                                    runat="server" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'
                                                    CommandName="Edit" Height="25px" />
                                                <asp:LinkButton ID="lnkDLSave" ToolTip="Save" class="btn-small btn-success icon-save"
                                                    runat="server" CommandName="Save" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>' />
                                                <%--<asp:LinkButton ID="lnkDLFeedback" ToolTip="Feedback" class="btn-small btn-danger icon-eye-open"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'
                                                    runat="server" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowFeedbackFlag") == 1 ? true : false%>'
                                                    CommandName="Edit" Height="25px" />--%>
                                                <asp:LinkButton ID="lnkDLAddStudent_Events" ToolTip="Assign Students from campaign to Event"
                                                    class="btn-small btn-success icon-ok" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'
                                                    runat="server" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'
                                                    CommandName="AddStudent_Event" Height="25px" />
                                            </td>
                                            <td style="text-align: center; vertical-align: middle;">
                                                <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                    <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                        <i class="icon-bolt"></i>
                                                    </asp:Panel>
                                                </a>
                                            </td>
                                        </ItemTemplate>
                                    </asp:DataList>
                                        <%--</ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dlGridEvents" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divCampaignEventFeedbackDetail" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label1" runat="server" Text="Campaign Event Feedback Detail"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <div class="row-fluid">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                    <asp:DataList ID="dlGridEvents_Feedback" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%" OnItemCommand="dlGridEvents_Feedback_ItemCommand">
                                        <HeaderTemplate>
                                            <b>Event Name</b> </th>
                                            <th style="width: 40%; text-align: center;">
                                                Feedback Header
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                Action
                                            </th>
                                            <th style="width: 10%; text-align: center; vertical-align: middle;">
                                            </th>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCampaignEventId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCampaignFeedbackId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"FeedbackId")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCampaignEventName" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventName")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'>
                                            </asp:Label>
                                            <asp:DropDownList runat="server" ID="ddlEvent" Width="215px" ToolTip="Event" data-placeholder="Select Event"
                                                CssClass="chzn-select" Visible="false" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCampaignEventFeedback" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventFeedback")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                                    Width="95%" placeholder="Campaign Event Feedback" ToolTip="Campaign Event Feedback" />
                                                <asp:Label ID="lblDLCampaignEventFeedback" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventFeedback")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton ID="lnkDLEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FeedbackId")%>' runat="server"
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'
                                                    CommandName="Edit" Height="25px" />
                                                <asp:LinkButton ID="lnkDLSave" ToolTip="Save" class="btn-small btn-success icon-save"
                                                    runat="server" CommandName="Save" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FeedbackId")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>' />
                                            </td>
                                            <td style="text-align: center; vertical-align: middle;">
                                                <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                    <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                        <i class="icon-bolt"></i>
                                                    </asp:Panel>
                                                </a>
                                            </td>
                                        </ItemTemplate>
                                    </asp:DataList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dlGridEvents_Feedback" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divCampaignEventFeedbackValue" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label2" runat="server" Text="Campaign Event Feedback Value"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <div class="row-fluid">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                    <asp:DataList ID="dlGridEvents_FeedbackValue" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%" OnItemCommand="dlGridEvents_FeedbackValue_ItemCommand">
                                        <HeaderTemplate>
                                            <b>Event Name</b> </th>
                                            <th style="width: 30%; text-align: center;">
                                                Feedback Header
                                            </th>
                                            <th style="width: 20%; text-align: center;">
                                                Feedback Value
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                Action
                                            </th>
                                            <th style="width: 10%; text-align: center; vertical-align: middle;">
                                            </th>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCampaignEventId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventId")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCampaignFeedbackValueId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"FeedbackValueId")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblCampaignEventName" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventName")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'>
                                            </asp:Label>
                                            <asp:DropDownList runat="server" ID="ddlEvent" Width="215px" ToolTip="Event" data-placeholder="Select Event"
                                                CssClass="chzn-select" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddlEvent_SelectedIndexChanged" />
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCampaignFeedbackId" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"FeedbackId")%>'></asp:Label>
                                                <asp:DropDownList runat="server" ID="ddlFeedBack" Width="215px" ToolTip="Event" data-placeholder="Select Event FeedBack"
                                                    CssClass="chzn-select" Visible="false" />
                                                <asp:Label ID="lblDLCampaignEventFeedback" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventFeedback")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>' />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCampaignEventFeedbackValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventFeedbackValue")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                                    Width="95%" placeholder="Campaign Event Feedback Value" ToolTip="Campaign Event Feedback Value" />
                                                <asp:Label ID="lblDLCampaignEventFeedbackValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CampaignEventFeedbackValue")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>' />
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton ID="lnkDLEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FeedbackValueId")%>'
                                                    runat="server" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'
                                                    CommandName="Edit" Height="25px" />
                                                <asp:LinkButton ID="lnkDLSave" ToolTip="Save" class="btn-small btn-success icon-save"
                                                    runat="server" CommandName="Save" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FeedbackValueId")%>'
                                                    Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>' />
                                            </td>
                                            <td style="text-align: center; vertical-align: middle;">
                                                <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                    <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                        <i class="icon-bolt"></i>
                                                    </asp:Panel>
                                                </a>
                                            </td>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="dlGridEvents_FeedbackValue" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
             <div id="DivAssignStudentForCampaignToEvent" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Assign Student For Campaign To Event
                            <asp:Label runat="server" ID="lblCampaignEventId" Visible="false"></asp:Label>
                        </h5>
                        <button id="btnCloseSearchCriteria" runat="server" data-rel="tooltip" data-placement="left"
                            title="Search Criteria" onserverclick="btnCloseSearchCriteria_ServerClick">
                            <i class="icon-remove"></i>
                        </button>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3">Event Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEventName" Text="" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label6">Event Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEventPeriod" Text="" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>    
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label5">Already Assigned Contacts for this</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <a href='Campaign_Detail.aspx'
                                                                    id="btnEventContacts" runat="server" target="_blank" 
                                                                    data-rel="tooltip" data-placement="top" title="Event Contacts">                                                               
                                                                    <asp:Label runat="server" ID="lblEventAssignedContacts" Text="" CssClass="blue" />
                                                                </a>                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                
                                            </tr>
                                        </table>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div id="divprimary1" runat="server">
                                                    <div class="row-fluid" runat="server" id="divSearchContact">
                                                        <div class="span4">
                                                            <div class="widget-box">
                                                                <div class="widget-body">
                                                                    <div class="widget-header widget-header-small header-color-dark">
                                                                        <h4 class="smaller">
                                                                            <i class="icon-search"></i>Search Criteria</h4>
                                                                    </div>
                                                                    <div class="widget-body">
                                                                        <table class="table table-striped table-bordered table-condensed">
                                                                            <tr>
                                                                                <td style="text-align: center">
                                                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                                                        <tr>
                                                                                            <td style="border-style: none; text-align: center; width: 20%;">
                                                                                            </td>
                                                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                                                <asp:Label ID="lblPKey_RowNumber" runat="server" Text='' Visible="false" />
                                                                                                <asp:DropDownList ID="ddlColumnNames" runat="server" Width="215px" data-placeholder="Select"
                                                                                                    CssClass="chzn-select" ValidationGroup="Grplead2" AutoPostBack="true" OnSelectedIndexChanged="ddlColumnNames_SelectedIndexChanged">
                                                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                                                    <asp:ListItem>Contacts</asp:ListItem>
                                                                                                    <asp:ListItem Value="Con_Firstname">FirstName</asp:ListItem>
                                                                                                    <asp:ListItem Value="Con_midname">Mid Name</asp:ListItem>
                                                                                                    <asp:ListItem Value="Con_lastname">Last Name</asp:ListItem>
                                                                                                    <asp:ListItem Value="Handphone1">Mobile</asp:ListItem>
                                                                                                    <asp:ListItem>EmailId</asp:ListItem>
                                                                                                    <asp:ListItem>Country</asp:ListItem>
                                                                                                    <asp:ListItem>State</asp:ListItem>
                                                                                                    <asp:ListItem>City</asp:ListItem>
                                                                                                    <asp:ListItem>Location</asp:ListItem>
                                                                                                    <asp:ListItem>Postal_Code</asp:ListItem>
                                                                                                    <asp:ListItem>Contact_Source</asp:ListItem>
                                                                                                    <asp:ListItem>Contact_Type</asp:ListItem>
                                                                                                    <asp:ListItem>Customer_Type</asp:ListItem>
                                                                                                    <asp:ListItem>Institution_Name</asp:ListItem>
                                                                                                    <asp:ListItem Value="Standard">Standard</asp:ListItem>
                                                                                                    <asp:ListItem>Year_Of_Passing</asp:ListItem>
                                                                                                    <asp:ListItem>Excel_Upload</asp:ListItem>
                                                                                                    <asp:ListItem>Current_Year</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlColumnNames"
                                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Column Name"
                                                                                                    InitialValue="Select" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="border-style: none; text-align: center; width: 20%;">
                                                                                            </td>
                                                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                                                <asp:DropDownList ID="ddlCondition" runat="server" Width="215px" data-placeholder="Select"
                                                                                                    CssClass="chzn-select" ValidationGroup="Grplead2">
                                                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                                                    <asp:ListItem>Is</asp:ListItem>
                                                                                                    <asp:ListItem>Is Not</asp:ListItem>
                                                                                                    <asp:ListItem>Contains</asp:ListItem>
                                                                                                    <asp:ListItem>Does Not Contains</asp:ListItem>
                                                                                                    <asp:ListItem>Starts with</asp:ListItem>
                                                                                                    <asp:ListItem>Ends With</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlCondition"
                                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Condition"
                                                                                                    InitialValue="Select" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="border-style: none; text-align: center; width: 20%;">
                                                                                            </td>
                                                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                                                <asp:DropDownList ID="ddlValue" runat="server" Width="215px" data-placeholder="Select"
                                                                                                    AutoPostBack="true" CssClass="chzn-select" ValidationGroup="Grplead2" Visible="false"
                                                                                                    OnSelectedIndexChanged="ddlValue_SelectedIndexChanged">
                                                                                                </asp:DropDownList>
                                                                                                <asp:TextBox ID="txtValue" runat="server" Width="205px"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlValue"
                                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Value"
                                                                                                    InitialValue="Select" />
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtValue"
                                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Enter Value" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr runat="server" id="trAcadYear">
                                                                                            <td style="border-style: none; text-align: center; width: 20%;">
                                                                                            </td>
                                                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                                                <asp:DropDownList ID="ddlAcadYear" runat="server" Width="215px" data-placeholder="Select"
                                                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlAcadYear_SelectedIndexChanged"
                                                                                                    CssClass="chzn-select" ValidationGroup="Grplead2">
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidfdator3df" ControlToValidate="ddlAcadYear"
                                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Acad Year"
                                                                                                    InitialValue="Select" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr runat="server" id="trDivision">
                                                                                            <td style="border-style: none; text-align: center; width: 20%;">
                                                                                            </td>
                                                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                                                <asp:DropDownList ID="ddlDivision" runat="server" Width="215px" data-placeholder="Select"
                                                                                                    CssClass="chzn-select" ValidationGroup="Grplead2" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlDivision"
                                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Division"
                                                                                                    InitialValue="Select" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr runat="server" id="trCenter">
                                                                                            <td style="border-style: none; text-align: center; width: 20%;">
                                                                                            </td>
                                                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                                                <asp:DropDownList ID="ddlCenter" runat="server" Width="215px" data-placeholder="Select"
                                                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged" CssClass="chzn-select"
                                                                                                    ValidationGroup="Grplead2">
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3scdsf" ControlToValidate="ddlCenter"
                                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                                                    InitialValue="Select" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr runat="server" id="trStream" visible="false">
                                                                                            <td style="border-style: none; text-align: center; width: 20%;">
                                                                                            </td>
                                                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                                                <asp:DropDownList ID="ddlStream" runat="server" Width="215px" data-placeholder="Select"
                                                                                                    CssClass="chzn-select" ValidationGroup="Grplead2">
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlStream"
                                                                                                    Text="#" runat="server" ValidationGroup="Grplead2" SetFocusOnError="True" ErrorMessage="Select Stream"
                                                                                                    InitialValue="Select" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="border-style: none; text-align: center; width: 100%;" colspan="2">
                                                                                                <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                                                                    <!--Button Area -->
                                                                                                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnAddStud" runat="server"
                                                                                                        Text="+ Add" ValidationGroup="Grplead2" OnClick="btnAddStud_Click" />
                                                                                                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnReset" runat="server"
                                                                                                        Text="Reset" OnClick="btnReset_Click" />
                                                                                                    <button id="Button1" runat="server" data-rel="tooltip" data-placement="left" title="Add Criteria"
                                                                                                        class="btn btn-mini btn-primary" onserverclick="btnAddStud_Click" validationgroup="Grplead2"
                                                                                                        visible="false">
                                                                                                        <i class="icon-plus"></i>
                                                                                                    </button>
                                                                                                    <button id="Button2" runat="server" data-rel="tooltip" data-placement="left" title="Reset Criteria"
                                                                                                        class="btn btn-mini btn-primary" onserverclick="btnReset_Click" visible="false">
                                                                                                        <i class="icon-remove"></i>
                                                                                                    </button>
                                                                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                                                                        ValidationGroup="Grplead2" ShowSummary="False" />
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="span8">
                                                            <div class="widget-box">
                                                                <div class="widget-body">
                                                                    <div class="widget-header widget-hea1der-small header-color-dark">
                                                                        <h4 class="smaller">
                                                                            <i class="icon-group"></i>Search for Contacts that Match</h4>
                                                                    </div>
                                                                    <div class="widget-body">
                                                                        <table class="table table-striped table-bordered table-condensed">
                                                                            <tr>
                                                                                <td style="text-align: left">
                                                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                                                        <tr>
                                                                                            <td style="border-style: none; text-align: left;">
                                                                                                <label>
                                                                                                    <asp:RadioButton ID="optAnyCriteria" runat="server" GroupName="Criteria" AutoPostBack="true"
                                                                                                        OnCheckedChanged="optAnyCriteria_CheckedChanged" /><span class="lbl"> <b>Any Criteria
                                                                                                        </b></span>
                                                                                                </label>
                                                                                            </td>
                                                                                            <td style="border-style: none; text-align: left;">
                                                                                                <label>
                                                                                                    <asp:RadioButton ID="optAllCriteria" runat="server" GroupName="Criteria" AutoPostBack="true"
                                                                                                        Checked="true" OnCheckedChanged="optAllCriteria_CheckedChanged" />
                                                                                                    <span class="lbl"><b>All Criteria </b></span>
                                                                                                </label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="border-style: none; text-align: left;" colspan="2">
                                                                                                <asp:DataList ID="dlFillData" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                                                    OnItemCommand="dlFillData_ItemCommand">
                                                                                                    <HeaderTemplate>
                                                                                                        <b class="center" style="text-align: left">Detail</b></th>
                                                                                                        <th style="text-align: center" width="10%">
                                                                                                            Action
                                                                                                        </th>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblOperator" Text='<%#DataBinder.Eval(Container.DataItem, "Operator")%>'
                                                                                                            runat="server" CssClass="badge badge-inverse"></asp:Label>
                                                                                                        &nbsp;
                                                                                                        <asp:Label ID="lblColName" Text='<%#DataBinder.Eval(Container.DataItem, "ColumnName")%>'
                                                                                                            runat="server"></asp:Label>
                                                                                                        &nbsp;
                                                                                                        <asp:Label ID="lblCondition" Text='<%#DataBinder.Eval(Container.DataItem, "Condition")%>'
                                                                                                            runat="server" Font-Bold="True"></asp:Label>
                                                                                                        &nbsp; '<asp:Label ID="lblValue" Text='<%#DataBinder.Eval(Container.DataItem, "Value")%>'
                                                                                                            runat="server"></asp:Label>'
                                                                                                        <asp:Label ID="lblRowNumber" Text='<%#DataBinder.Eval(Container.DataItem, "RowNumber")%>'
                                                                                                            runat="server" Visible="false"></asp:Label>
                                                                                                        <asp:Label ID="lblCenterCode" Text='<%#DataBinder.Eval(Container.DataItem, "CenterCode")%>'
                                                                                                            runat="server" Visible="false"></asp:Label>
                                                                                                        <asp:Label ID="lblDivisionCode" Text='<%#DataBinder.Eval(Container.DataItem, "Div_Code")%>'
                                                                                                            runat="server" Visible="false"></asp:Label>
                                                                                                        <asp:Label ID="lblStreamCode" Text='<%#DataBinder.Eval(Container.DataItem, "Stream_Code")%>'
                                                                                                            runat="server" Visible="false"></asp:Label>
                                                                                                        </td>
                                                                                                        <td style="text-align: center">
                                                                                                            <asp:LinkButton ID="lnkDLEdit" ToolTip="Edit" class="btn btn-mini btn-primary" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RowNumber")%>'
                                                                                                                runat="server" CommandName="Edit" Height="15px"><i class=" icon-info-sign"></i></asp:LinkButton>
                                                                                                            <asp:LinkButton ID="lnkDelete" ToolTip="Remove" runat="server" class="btn btn-mini btn-danger"
                                                                                                                CommandName="Remove" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"RowNumber")%>'><i class="icon-trash"></i></asp:LinkButton>
                                                                                                        </td>
                                                                                                    </ItemTemplate>
                                                                                                </asp:DataList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="border-style: none; text-align: left;" colspan="2">
                                                                                                <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="pnlSave">
                                                                                                        <ProgressTemplate>
                                                                                                            <img alt="" src="Images/Processing.gif" />
                                                                                                        </ProgressTemplate>
                                                                                                    </asp:UpdateProgress>
                                                                                                    <asp:UpdatePanel ID="pnlSave" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <!--Button Area -->
                                                                                                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnFindContacts"
                                                                                                                runat="server" Text="Find Contacts" Width="100px" OnClick="btnFindContacts_Click" />
                                                                                                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnClearAllCriteria"
                                                                                                                Visible="true" runat="server" Text="Clear All Criteria" Width="125px" OnClick="btnClearAllCriteria_Click" />
                                                                                                        </ContentTemplate>
                                                                                                        <Triggers>
                                                                                                            <asp:PostBackTrigger ControlID="btnFindContacts" />
                                                                                                            <asp:PostBackTrigger ControlID="btnClearAllCriteria" />
                                                                                                        </Triggers>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row-fluid" runat="server" id="divResultContact">
                                                        <div class="row-fluid">
                                                            <h5>
                                                            </h5>
                                                        </div>
                                                        <div class="row-fluid">
                                                            <div class="well well-small">
                                                                <div class="row-fluid">
                                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="pnlSave2">
                                                                        <ProgressTemplate>
                                                                            <img alt="" src="Images/Processing.gif" />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                    <asp:UpdatePanel ID="pnlSave2" runat="server">
                                                                        <ContentTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblActualRecordCount" runat="server" CssClass="badge badge-inverse"></asp:Label>
                                                                                        <asp:Label ID="lblPageNumber" runat="server" Visible="false"></asp:Label>
                                                                                        <button id="btnStud_NextRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                                                            data-rel="tooltip" data-placement="right" title="Find Next Record" onserverclick="btnStud_NextRecord_ServerClick">
                                                                                            <i class="icon-share-alt"></i>
                                                                                        </button>
                                                                                        <button id="btnStud_PrevRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                                                            data-rel="tooltip" data-placement="right" title="Find Prev Record" onserverclick="btnStud_PrevRecord_ServerClick">
                                                                                            <i class="icon-reply"></i>
                                                                                        </button>
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <asp:Label ID="lblTotalContacts2" runat="server" CssClass="badge badge-inverse">Contacts Total No of Records: </asp:Label>
                                                                                        &nbsp;
                                                                                        <asp:Label ID="lblTotalContacts" runat="server" Visible="false" CssClass="badge badge-inverse"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="btnStud_NextRecord" />
                                                                            <asp:PostBackTrigger ControlID="btnStud_PrevRecord" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row-fluid">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                                            <asp:DataList ID="dlStudContact" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                                <HeaderTemplate>
                                                                    <b>
                                                                        <asp:CheckBox ID="chkAllStud" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllStud_CheckedChanged" />
                                                                        <span class="lbl"></span></b></th>
                                                                    <th style="text-align: center" width="50%">
                                                                        Student Name
                                                                    </th>
                                                                    <th style="text-align: center" width="20%">
                                                                        Mobile No
                                                                    </th>
                                                                    <th style="text-align: center" width="25%">
                                                                        Email Id
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk1" runat="server" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ActivFlag") == 1 ? false : true %>' /><span
                                                                        class="lbl"></span></td> </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblRecord_No" Text='<%#DataBinder.Eval(Container.DataItem, "Record_No")%>'
                                                                            runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblConId" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Id")%>'
                                                                            runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                                            runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem, "StudName")%>'
                                                                            runat="server" CssClass='<%# (int)DataBinder.Eval(Container.DataItem,"ActivFlag") == 1 ? "label label-important ":"" %>'></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <asp:Label ID="lblMobileNo" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone1")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblEmailid" Text='<%#DataBinder.Eval(Container.DataItem, "Emailid")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                             </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="dlStudContact" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                        </div>
                                                        <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                            <!--Button Area -->
                                                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnContactsSave"
                                                                runat="server" Text="Save" OnClick="btnContactsSave_Click" />
                                                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnContactsBack"
                                                                runat="server" Text="Back" OnClick="btnContactsBack_Click" Visible="false" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnContactsSave" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
