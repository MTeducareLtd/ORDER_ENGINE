<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Campaign_Detail.aspx.cs" Inherits="Campaign_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function openModalSms() {
            $('#DivsmsCampaignContact').modal({
                backdrop: 'static'
            })

            $('#DivsmsCampaignContact').modal('show');
        }

        function CloseModalSms() {
            $('#DivsmsCampaignContact').modal('hide');
        }

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
                    Manage Campaign-Admin<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn btn-app btn-success btn-mini radius-4  " runat="server" ID="BtnAdd"
                Text="Create Campaign" ToolTip="Create Campaign" OnClick="BtnAdd_Click" Width="125px" />
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
            <div id="DivAddPanel" runat="server" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="lblHeader_Add" runat="server" Text="Add Campaign Detail"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="upnl1" runat="server">
                                    <ContentTemplate>
                                        <table class="table table-striped table-bordered table-condensed">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Campaign Detail
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Labe15" CssClass="red">Campaign Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCampaignTypeAdd" Width="215px" data-placeholder="Select Campaignm Type"
                                                                    CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampaignTypeAdd_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label16" CssClass="red">Campaign Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtCampaignNameAdd" runat="server" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label17" CssClass="red">Campaign Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCampaignStatusAdd" Width="215px" data-placeholder="Select Campaign Status"
                                                                    CssClass="chzn-select" />
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
                                                                <asp:Label runat="server" ID="Label1" CssClass="red">Target Audience</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtTargetAudienceAdd" runat="server" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label12" CssClass="red">Campaign Sponsor</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCampaignSponsorAdd" Width="215px" data-placeholder="Select Campaign Sponsor"
                                                                    CssClass="chzn-select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label41" runat="server">Sponsor Description</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtSponsorDescAdd" runat="server" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label40" runat="server" CssClass="red">Expected Close Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; width: 60%;">
                                                                <input readonly="readonly" class="date-picker" id="txtExpectedCloseDate" runat="server"
                                                                    type="text" data-date-format="dd M yyyy" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label39" runat="server" CssClass="red">Target Size</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtTargetSizeAdd" runat="server" onkeypress="return NumberOnly(event);"
                                                                    Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label38" runat="server" CssClass="red">Campaign Owner</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCampaignOwnerAdd" Width="215px" data-placeholder="Select Campaign Owner"
                                                                    CssClass="chzn-select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Organizational Assignment
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label6" CssClass="red">Company</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCompanyAdd" Width="215px" ToolTip="Company"
                                                                    data-placeholder="Select Company" CssClass="chzn-select" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlCompanyAdd_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label7" CssClass="red">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlDivisionAdd" ToolTip="Division" SelectionMode="Multiple"
                                                                    data-placeholder="Division" CssClass="chzn-select" class="span12" Width="215px"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlDivisionAdd_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label8" CssClass="red">Zone</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlZoneAdd" ToolTip="Zone" SelectionMode="Multiple"
                                                                    data-placeholder="Zone" CssClass="chzn-select" class="span12" Width="215px" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddlZoneAdd_SelectedIndexChanged" />
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
                                                                <asp:Label runat="server" ID="Label9" CssClass="red">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlCenterAdd" ToolTip="Center" SelectionMode="Multiple"
                                                                    data-placeholder="Center" CssClass="chzn-select" class="span12" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label10" CssClass="red">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlRoleAdd" Width="215px" data-placeholder="Select Role"
                                                                    Visible="false" CssClass="chzn-select" />
                                                                <asp:DropDownList runat="server" ID="ddlAddAcadYear" Width="215px" data-placeholder="Select Acad Year"
                                                                    CssClass="chzn-select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label11" runat="server" CssClass="red">Assigned To</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlAssignedToAdd" ToolTip="Assigned To" SelectionMode="Multiple"
                                                                    data-placeholder="Assigned To" CssClass="chzn-select" class="span12" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Campaign Targets & Actuals
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label13" CssClass="red">Product(s)</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtProductAdd" runat="server" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label18" CssClass="red">Campaign Budget Cost</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtBudgetCoastAdd" runat="server" Width="205px" onkeypress="return NumberOnly(event);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label20" CssClass="red">Expected Response</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtExpectedResponseAdd" runat="server" Width="205px"></asp:TextBox>
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
                                                                <asp:Label runat="server" ID="Label21" CssClass="red">Expected Revenue(Rs.)</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtExpectedRevenueAdd" runat="server" Width="205px" onkeypress="return NumberOnly(event);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="red">Expected Sales Count</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtExpectedSalescountAdd" runat="server" Width="205px" onkeypress="return NumberOnly(event);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label24" runat="server" CssClass="red">Expected Response Count</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtExpectedResponseCountAdd" runat="server" onkeypress="return NumberOnly(event);"
                                                                    Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trCampActual">
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label19" CssClass="red">Campaign Actual Cost</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtActualCoastAdd" runat="server" Width="205px" onkeypress="return NumberOnly(event);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label23" runat="server" CssClass="red">Actual Sales Count</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtActualSalesCountAdd" runat="server" Width="205px" onkeypress="return NumberOnly(event);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="red">Actual Response Count</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtActualResponseCountAdd" runat="server" onkeypress="return NumberOnly(event);"
                                                                    Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label26" runat="server" CssClass="red">Expected ROI</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtExpectedROIAdd" runat="server" onkeypress="return NumberOnly(event);"
                                                                    Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table class="table-hover" style="border-style: none;" width="100%" runat="server"
                                                        id="tdCampActualROI">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label27" runat="server" CssClass="red">Actual ROI</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtActualROIAdd" runat="server" onkeypress="return NumberOnly(event);"
                                                                    Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnSaveCampaignDetail"
                                    runat="server" Text="Save" ValidationGroup="UcValidate" OnClick="btnSaveCampaignDetail_Click" />
                                <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnCloseAdd" Visible="true"
                                    runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivSearch" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label2" runat="server" Text="Search Campaign Detail"></asp:Label>
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
                                                                <asp:Label runat="server" ID="Label14" CssClass="red">Campaign Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCampaignTypeSearch" Width="215px" data-placeholder="Select Campaign Type"
                                                                    CssClass="chzn-select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                   <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" CssClass="red" ID="Label61">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList runat="server" ID="DDLAcadYear_seruch" Width="215px" data-placeholder="Select AcadYear"
                                                                    CssClass="chzn-select" />
                                                            </td>
                                                        </tr>
                                                    </table> 
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" CssClass="red" ID="Label65">Campaign Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList runat="server" ID="DDLCampaignStatus" Width="215px" data-placeholder="Select Status"
                                                                    CssClass="chzn-select" />
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
                                                                <asp:Label runat="server" ID="Label3">Campaign Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtCampaignNameSearch" runat="server" Width="205px"></asp:TextBox>
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
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSearch"
                                    Text="Search" ToolTip="Search" OnClick="btnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="true">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="btnExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" Visible="false" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:DataList ID="dlDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" OnItemCommand="dlDisplay_ItemCommand">
                    <HeaderTemplate>
                        <b>Campaign Type</b> </th>
                        <th align="left" style="width: 30%; text-align: left;">
                            Campaign Name
                        </th>
                        <th align="left" style="width: 15%; text-align: left;">
                            Campaign Status
                        </th>
                        <th align="left" style="width: 15%; text-align: left;">
                            Expected Close Date
                        </th>
                        <th align="left" style="width: 15%; text-align: left;">
                            Acad Year
                        </th>
                        <th align="left" style="width: 10%; text-align: center;">
                            Action
                        </th>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label28" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Camp_Type")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lblData_Source_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Camp_Name")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lblCampaign_Status" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Campaign_Status_Desc")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lblReference_Id" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ExpectedCloseDate")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lblAcadYear" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Acad_Year")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:LinkButton ID="lnkEditInfo" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>' runat="server"
                                CommandName="Edit" />
                            <asp:LinkButton ID="lnkAssign" ToolTip="Assign" class="btn-small btn-success icon-ok"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>' runat="server"
                                CommandName="Assign" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"AssignToCampaign") == 0 ? false : true %>' />
                            <asp:LinkButton ID="lnkRemoveCampaignContacts" ToolTip="Remove Campaign Contacts"
                                class="btn-small btn-danger icon-trash" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>'
                                runat="server" CommandName="RemoveCampaignContacts" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"AssignToCampaign") == 0 ? false : true %>' /><br />
                            <asp:LinkButton ID="lnkRemoveAssignUser" ToolTip="Reassign\Remove Contacts" class="btn-small btn-danger icon-remove"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>' runat="server"
                                CommandName="RemoveUserAssignment" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"AssignToCampaign") == 0 ? false : true %>' />
                            <asp:LinkButton ID="lnkCloseCampaign" ToolTip="Close Campaign" class="btn-small btn-warning icon-key"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>' runat="server"
                                CommandName="CloseCampaign" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"CampaignCloseFlag") == 1 ? false : true %>' />
                            <asp:LinkButton ID="lnkCampaignSMS" ToolTip="Send SMS" class="btn-small btn-warning icon-envelope-alt"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>' runat="server"
                                CommandName="CampaignSMS" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"AssignToCampaign") == 0 ? false : true %>' />
                            <asp:LinkButton ID="lnkCampaignEvent" ToolTip="Event" class="btn-small btn-success icon-calendar"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Campaign_Id")%>' runat="server"
                                CommandName="CampaignEvent" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"CampaignCloseFlag") == 1 ? false : true %>' >                 
                            </asp:LinkButton>
                        </td>
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList ID="dlExport" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="false">
                    <HeaderTemplate>
                        <b>Camp_Type</b> </th>
                        <th align="left" style="width: 5%; text-align: left;">
                            Campaign Name
                        </th>
                        <th align="left" style="width: 5%; text-align: left;">
                            Expected Close Date
                        </th>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCamp_Type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Camp_Type")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lblCamp_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Camp_Name")%>' />
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblExpectedCloseDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ExpectedCloseDate")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div id="DivAssignStudent" runat="server" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Assign Student To Campaign
                            <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
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
                                                                <asp:Label runat="server" ID="Label29">Campaign Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblCampaignType_Result" Text="SMS" CssClass="blue" />
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
                                                                <asp:Label runat="server" ID="lblCampaignName_Result" Text="Test" CssClass="blue" />
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
                                                                <asp:Label runat="server" ID="lblCampaignStatus_Result" Text="Test" CssClass="blue" />
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
                                                                <asp:Label ID="lblTargetAudience_Result" runat="server" class="blue">ABC</asp:Label>
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
                                                                <asp:Label ID="lblExpectedCloseDate_Result" runat="server" class="blue">12 Dec. 2015</asp:Label>
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
                                                                <asp:ListBox runat="server" ID="ddlUser_StudentAssign" ToolTip="Assigned To" SelectionMode="Multiple"
                                                                    data-placeholder="User/Agent" CssClass="chzn-select" class="span12" Width="215px" />
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
            <div id="DivRemoveUserAssignment" runat="server" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Remove\Reassign Contacts To Campaign
                        </h5>
                        <button id="btnCloseCriteria" runat="server" data-rel="tooltip" data-placement="left"
                            title="Search Criteria" onserverclick="btnCloseSearchCriteria_ServerClick">
                            <i class="icon-remove"></i>
                        </button>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label32">Campaign Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblCampaignTypeResult1" Text="SMS" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label34">Campaign Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblCampaignNameResult1" Text="Test" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label36">Campaign Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblCampaignStatusResult1" Text="Test" CssClass="blue" />
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
                                                                <asp:Label runat="server" ID="Label42">Target Audience</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignTargetAudienceResult1" runat="server" class="blue">ABC</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label44">Campaign Sponsor</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignSponsorResult1" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label49">Sponsor Description</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignSponsorDescResult1" runat="server" class="blue"></asp:Label>
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
                                                                <asp:Label runat="server" ID="Label51">Expected Close Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignExpectedCloseDateResult1" runat="server" class="blue">12 Dec. 2015</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label53">Already Assign Contact for Campaign</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignAssignedContactsResult1" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label5">Action</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlAction" runat="server" Width="215px" data-placeholder="Select"
                                                                    CssClass="chzn-select" ValidationGroup="Grplead2" AutoPostBack="true" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Assign Contacts</asp:ListItem>
                                                                    <asp:ListItem>Reassign</asp:ListItem>
                                                                    <asp:ListItem>Remove</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label35">Assigned User</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlAssignedCampUser" runat="server" Width="175px" data-placeholder="Select"
                                                                    CssClass="chzn-select" ValidationGroup="Grplead2" AutoPostBack="true" OnSelectedIndexChanged="ddlAssignedCampUser_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                &nbsp;
                                                                <button id="btnSearchAssignedContacts" runat="server" data-rel="tooltip" data-placement="left"
                                                                    title="Search Contacts" class="btn btn-mini btn-primary" onserverclick="btnSearchAssignedContacts_Click"
                                                                    validationgroup="Grplead2">
                                                                    <i class="icon-search"></i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr id="trReassignedUser" runat="server">
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label33">ReAssigned User</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlReassignedUser" runat="server" Width="175px" data-placeholder="Select"
                                                                    CssClass="chzn-select" ValidationGroup="Grplead2">
                                                                </asp:DropDownList>
                                                                <button id="btnSearchAssignedContacts1" runat="server" data-rel="tooltip" data-placement="left"
                                                                    title="Search Contacts" class="btn btn-mini btn-primary" onserverclick="btnSearchAssignedContacts_Click"
                                                                    validationgroup="Grplead2">
                                                                    <i class="icon-search"></i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="row-fluid" id="divRemoveReassignContactslist" runat="server">
                                            <div class="span12">
                                                <div class="row-fluid">
                                                    <asp:UpdatePanel ID="pnlAssignedContacts" runat="server">
                                                        <ContentTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td width="80%">
                                                                        <asp:Label ID="lblAssignedActualRecordCount" runat="server" CssClass="badge badge-inverse"></asp:Label>
                                                                        <button id="btnAssignedStud_NextRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                                            data-rel="tooltip" data-placement="right" title="Find Next Record" onserverclick="btnAssignedStud_NextRecord_ServerClick">
                                                                            <i class="icon-share-alt"></i>
                                                                        </button>
                                                                        <button id="btnAssignedStud_PrevRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                                            data-rel="tooltip" data-placement="right" title="Find Prev Record" onserverclick="btnAssignedStud_PrevRecord_ServerClick">
                                                                            <i class="icon-reply"></i>
                                                                        </button>
                                                                    </td>
                                                                    <td width="20%" align="right">
                                                                        <asp:Label ID="lblAssignedTotalContacts2" runat="server" CssClass="badge badge-inverse">Contacts Total No of Records: </asp:Label>
                                                                        &nbsp;
                                                                        <asp:Label ID="lblAssignedTotalContacts" runat="server" Visible="false" CssClass="badge badge-inverse"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnAssignedStud_NextRecord" />
                                                            <asp:PostBackTrigger ControlID="btnAssignedStud_PrevRecord" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="row-fluid">
                                                    <asp:DataList ID="dlAssignCampaignContacts" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                        <HeaderTemplate>
                                                            <b>
                                                                <asp:CheckBox ID="chkAllStud" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllAssignCampaignStud_CheckedChanged" />
                                                                <span class="lbl"></span></b></th>
                                                            <th style="text-align: center" width="50%">
                                                                Student Name
                                                            </th>
                                                            <th style="text-align: center" width="10%">
                                                                Mobile No
                                                            </th>
                                                            <th style="text-align: center" width="15%">
                                                                Email Id
                                                            </th>
                                                            <th style="text-align: center" width="25%">
                                                                Record Status
                                                            </th>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk1" runat="server" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ActivFlag") == 1 ? false : true %>' /><span
                                                                class="lbl"></span></td> </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblPKeyRecordId" Text='<%#DataBinder.Eval(Container.DataItem, "PKeyRecord_ID")%>'
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
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblRecordStatus" runat="server"></asp:Label>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                                <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                    <!--Button Area -->
                                                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnContactsRemove_Reassign"
                                                        Width="125px" runat="server" Text="Save" OnClick="btnContactsRemove_Reassign_Click" />
                                                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnContactsRemove_ReassignClose"
                                                        runat="server" Text="Close" Visible="false" />
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnSearchAssignedContacts" />
                                        <asp:PostBackTrigger ControlID="btnSearchAssignedContacts1" />
                                        <asp:PostBackTrigger ControlID="ddlAssignedCampUser" />
                                        <asp:PostBackTrigger ControlID="btnContactsRemove_Reassign" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivRemoveCampaignContacts" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Remove Campaign Contacts
                        </h5>
                        <button id="btnDCloseSearchCriteria" runat="server" data-rel="tooltip" data-placement="left"
                            title="Search Criteria" onserverclick="btnDCloseSearchCriteria_ServerClick">
                            <i class="icon-remove"></i>
                        </button>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label15">Campaign Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblCampaignTypeResult2" Text="SMS" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label48">Campaign Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblCampaignNameResult2" Text="Test" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label55">Campaign Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblCampaignStatusResult2" Text="Test" CssClass="blue" />
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
                                                                <asp:Label runat="server" ID="Label59">Target Audience</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignTargetAudienceResult2" runat="server" class="blue">ABC</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label63">Campaign Sponsor</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignSponsorResult2" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label67">Sponsor Description</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignSponsorDescResult2" runat="server" class="blue"></asp:Label>
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
                                                                <asp:Label runat="server" ID="Label69">Expected Close Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblCampaignExpectedCloseDateResult2" runat="server" class="blue">12 Dec. 2015</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label71">Total Campaign Contacts </asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblTotalCampaignContactsResult2" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label37">Pending Campaign Contacts</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblPendingCampaignContactsResult2" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label52">Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtstudentnamesearch" runat="server" Width="205px" placeholder="Search by Name"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label57">Handphone</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txthandphonesearch" runat="server" placeholder="Search by Handphone 1"
                                                                    Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center;">
                                                    <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSearchByNameHandphone"
                                                        Text="Search" ToolTip="Search by Name or Handphone" OnClick="btnSearchByNameHandphone_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="well well-small">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <button id="btnDeleteStud_NextRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                            data-rel="tooltip" data-placement="right" title="Find Next Records" onserverclick="btnDeleteStud_NextRecord_ServerClick">
                                                            <i class="icon-share-alt"></i>
                                                        </button>
                                                        &nbsp;
                                                        <asp:Label ID="lblDeleteRecPageNumber" runat="server" CssClass="badge badge-inverse"></asp:Label>
                                                        &nbsp;
                                                        <button id="btnDeleteStud_PrevRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                            data-rel="tooltip" data-placement="right" title="Find Prev Records" onserverclick="btnDeleteStud_PrevRecord_ServerClick">
                                                            <i class="icon-reply"></i>
                                                        </button>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="Label70" runat="server" CssClass="badge badge-inverse">Total Records: </asp:Label>
                                                        &nbsp;
                                                        <asp:Label ID="lblTotalDContacts" runat="server" CssClass="badge badge-inverse"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <asp:DataList ID="dlCampaignContacts" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                            <HeaderTemplate>
                                                <b>
                                                    <asp:CheckBox ID="chkAllCampaignStud" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllCampaignStud_CheckedChanged" />
                                                    <span class="lbl"></span></b></th>
                                                <th style="text-align: center" width="55%">
                                                    Student Name
                                                </th>
                                                <th style="text-align: center" width="20%">
                                                    Mobile No
                                                </th>
                                                <th style="text-align: center" width="20%">
                                                    Email Id
                                                </th>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk1" runat="server" /><span class="lbl"></span></td> </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                        runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblConId" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Id")%>'
                                                        runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem, "StudName")%>'
                                                        runat="server"></asp:Label>
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
                                        <div class="well" style="text-align: center; background-color: #F0F0F0">
                                            <!--Button Area -->
                                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnDeleteCampaignContacts"
                                                Width="125px" runat="server" Text="Delete" OnClick="btnDeleteCampaignContacts_Click" />
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnDeleteCampaignContacts" />
                                        <asp:PostBackTrigger ControlID="btnStud_NextRecord" />
                                        <asp:PostBackTrigger ControlID="btnStud_PrevRecord" />
                                        <asp:PostBackTrigger ControlID="btnSearchByNameHandphone" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivCampaignSMS" runat="server" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Send Campaign SMS
                        </h5>
                        <button id="btnCloseSmsMainDiv" runat="server" data-rel="tooltip" data-placement="left"
                            title="Search Criteria" onserverclick="btnCloseSearchCriteria_ServerClick">
                            <i class="icon-remove"></i>
                        </button>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label43">Campaign Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblSMSCampignType" Text="SMS" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label50">Campaign Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblSMSCampignName" Text="Test" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label54">Campaign Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblSMSCampignStatus" Text="Test" CssClass="blue" />
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
                                                                <asp:Label runat="server" ID="Label56">Target Audience</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblSMSCampignTargetAudience" runat="server" class="blue">ABC</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label58">Campaign Sponsor</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblSMSCampignSponsor" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label60">Sponsor Description</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblSMSCampignSponsorDesc" runat="server" class="blue"></asp:Label>
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
                                                                <asp:Label runat="server" ID="Label62">Expected Close Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblSMSCampignExpectedCloseDate" runat="server" class="blue">12 Dec. 2015</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label64"> Assigned Contacts </asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblSMSCampignAssignedContatcts" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label66">User/Agent</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblSMSCampignUser" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="row-fluid">
                                            <asp:DataList ID="dlStudContact_SMS" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                <HeaderTemplate>
                                                    <b>
                                                        <asp:CheckBox ID="chkAllStud_SMS" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllStud_SMS_CheckedChanged" />
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
                                                    <asp:CheckBox ID="chk1" runat="server" /><span class="lbl"></span></td> </td>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblConId" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Id")%>'
                                                            runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem, "StudName")%>'
                                                            runat="server"></asp:Label>
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
                                        </div>
                                        <div class="well" style="text-align: center; background-color: #F0F0F0">
                                            <!--Button Area -->
                                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnContactsSendSMS"
                                                runat="server" Text="SMS" OnClick="btnContactsSendSMS_Click" />
                                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnContactsSendSMSBack"
                                                runat="server" Text="Back" OnClick="btnContactsSendSMSBack_Click" Visible="false" />
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnContactsSendSMS" />
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
    <div class="modal hide fade" id="DivsmsCampaignContact" style="width: 80%; max-width: 700px;
        left: 43%; position: absolute; display: none; top: 50px" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel runat="server" ID="UpdatePaneSMSsend" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="row-fluid">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4 class="modal-title">
                                    Send SMS
                                </h4>
                            </div>
                            <!--<div class="modal-body" style="overflow:hidden;">  </div> -->
                            <!--Actaul Use Area -->
                            <div class="modal-body" style="overflow: hidden;">
                                <table width="100%" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td class="well ">
                                            <table>
                                                <tr>
                                                    <td width="20%">
                                                        Characters Left:
                                                    </td>
                                                    <td width="65%" colspan="3">
                                                        <label id="lblcount" style="background-color: #E2EEF1; color: Red; font-weight: bold;">
                                                            800</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Message Text
                                                    </td>
                                                    <td width="65%" colspan="3">
                                                        <asp:TextBox TextMode="multiline" runat="server" ID="txtsmsstd" class="autosize-transition span12"
                                                            Text="Dear " MaxLength="15" Style="overflow: hidden; word-wrap: break-word; resize: horizontal;
                                                            height: 100px;" onkeyup="LimtCharacters(this,800,'lblcount');" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <!--Footers Button Area -->
                                <asp:Label ID="lblSMSError" runat="server" Font-Bold="true" ForeColor="Red" Text="" />
                                <asp:Label ID="lblSMSSendFlag" runat="server" Visible="false" Text="" />
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSendsmsstd"
                                    OnClick="btnSendsmsstd_Click" Text="Send" /><!---->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="Button4"
                                    data-dismiss="modal" Text="Close" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
