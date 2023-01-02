<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="New_Bulkstreamchange_Science.aspx.cs" Inherits="New_Bulkstreamchange_Science" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="UserDashboard.aspx">Home</a><span class="divider">
                <i class="icon-angle-right"></i></span></li>
            <li>Stream<span class="divider"> <i class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Bulk stream change<span class="divider"></span></h5>
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
                                        <table cellpadding="6" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <%--<td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" CssClass="red" ID="Label2">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddldivision" Width="215px" data-placeholder="Select Division"
                                                                    CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <i class="icon-calendar"></i>
                                                                <asp:Label runat="server" ID="Label29">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span9" name="date-range-picker"
                                                                    id="id_date_range_picker_1" placeholder="Date Search" data-placement="bottom"
                                                                    data-original-title="Date Range" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label1">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlCenters" ToolTip="Center(s)" data-placeholder="Select Center(s)"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" OnSelectedIndexChanged="ddlCenters_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    OnClick="BtnSearch_Click" Text="Get" ToolTip="Search" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                    <asp:CheckBox ID="chkStudentAllHidden_Sel" runat="server" Visible="False" /></h5>
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" OnClick="btnexporttoexcel_Click" />
                                    <asp:LinkButton runat="server" Visible="false" ID="btnEmail" ToolTip="Email" class="btn-small btn-danger icon-2x icon-envelope-alt"
                                        Height="25px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="DivResult" runat="server">
                   <%-- <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                    <div class="tabbable">
                        <ul class="nav nav-tabs" id="Ul1">
                        </ul>
                        <div class="tab-content" style="border: 1px solid #DDDDDD; overflow: hidden">
                            <div id="streamchange" class="tab-pane in active">
                                <div class="widget-main no-padding" style="height: 800px; overflow-y: none; overflow-x: scroll;">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-bordered table-hover Table1" border="1" style="border-collapse: collapse;
                                                overflow: auto overflow-y: scroll; overflow-x: scroll;">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <asp:CheckBox ID="chkStudentAll" runat="server" AutoPostBack="True" OnCheckedChanged="All_Student_ChkBox_Selected_Sel" />
                                                            <span class="lbl"></span>
                                                        </th>
                                                        <th style="text-align: center">
                                                            sbentrycode
                                                        </th>
                                                        <th style="text-align: center; white-space: nowrap">
                                                            Opp_ID
                                                        </th>
                                                        <th style="text-align: center; white-space: nowrap">
                                                            old streamcode
                                                        </th>
                                                        <th style="text-align: center; white-space: nowrap">
                                                            New streamcode
                                                        </th>
                                                        <th style="text-align: center; white-space: nowrap">
                                                            old subjectCode
                                                        </th>
                                                        <th style="text-align: center; white-space: nowrap">
                                                            Discount
                                                        </th>
                                                        <th style="text-align: center; white-space: nowrap">
                                                            Consessesion
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                            <td>
                                                                    <asp:CheckBox ID="chkStudent" runat="server" />
                                                                    <span class="lbl"></span></span>
                                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblsbentrycode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblOppID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>' />
                                                    <asp:Label ID="LBLCENTERCODE" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Center_Code")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblOldstream" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Source_Stream_Code")%>' />
                                                     <asp:Label ID="LBLPAYPALN" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pay_Type")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblnewstream" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Destination_Stream_Code")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblSubjectCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Source_Material_Code")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lbldiscount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Discount_Value")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblconessesion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Concession_Value")%>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                     <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                        <%--<button class="btn btn-app btn-primary  btn-small radius-4"  onserverclick="btnstartsync_ServerClick"
                                                            runat="server">
                                                            Process
                                                        </button>--%>
                                                        <asp:Button ID="btncreateaccount" runat="server" Text="Process" OnClick="btnstartsync_ServerClick" CssClass="btn btn-success btn-small radius-4 " TabIndex="-1" UseSubmitBehavior="false" OnClientClick="this.disabled=true;" />
                                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                <%--    </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
