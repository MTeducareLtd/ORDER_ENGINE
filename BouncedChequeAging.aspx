<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="BouncedChequeAging.aspx.cs" Inherits="BouncedChequeAging" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                <b>Dashboard </b><small><i class="icon-double-angle-right"></i>&nbsp;<b>Bounced Cheque Ageing</b></small>
                <div class="nav ace-nav pull-right">
                    <small style="font-size: 16px">Division</small>
                    <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp; <small style="font-size: 16px">Center</small>
                    <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                    </asp:DropDownList>
                    <%--&nbsp; <small style="font-size: 16px">Academic Year</small>
                    <asp:DropDownList ID="ddlAcadYear" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddlAcadYear_SelectedIndexChanged">
                    </asp:DropDownList>--%>
                </div>
            </h1>
        </div>
        <div class="alert alert-danger" id="divErrormessage" runat="server">
            <strong>
                <asp:Label ID="lblerrormessage" runat="server"> No Records Found !!</asp:Label></strong>
        </div>
        <div class="row-fluid" id="divsearchresults" runat="server">
            <div class="span12">
                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                <div class="widget-box">
                    <div class="widget-header widget-hea1der-small header-color-dark">
                        <h4 class="smaller">
                            <i class="icon-book"></i>Bounced Cheque Ageing
                        </h4>
                    </div>
                    <div class="widget-body">
                        <div class="table-toolbar" id="divtoolbar" runat="server" visible="false">
                        </div>
                        <%--<div id="OrgSerchCode" runat="server" visible="false">
                            <asp:Label ID="lblTargetCompCode" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblTargetDivCode" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblTargetZoanCode" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblTargetCentreCode" runat="server" Text=""></asp:Label>
                        </div>--%>
                        <asp:UpdatePanel ID="pnlSave2" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <h4>
                                                <b>
                                                    <asp:Label ID="lblActualRecordCount" runat="server" CssClass="badge badge-inverse"></asp:Label>
                                                </b>
                                                <asp:Label ID="lblPageNumber" runat="server" Visible="false"></asp:Label>
                                                <button id="btnStud_NextRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                    data-rel="tooltip" data-placement="right" title="Find Next Record" onserverclick="btnStud_NextRecord_ServerClick">
                                                    <i class="icon-share-alt"></i>
                                                </button>
                                                <button id="btnStud_PrevRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                    data-rel="tooltip" data-placement="right" title="Find Prev Record" onserverclick="btnStud_PrevRecord_ServerClick">
                                                    <i class="icon-reply"></i>
                                                </button>
                                            </h4>
                                        </td>
                                        <td align="right">
                                            <b>
                                                <asp:Label ID="lblTotalPendingAccounts2" runat="server" CssClass="badge badge-inverse">Total No of Records: </asp:Label>
                                                &nbsp;
                                                <asp:Label ID="lblCancellationStatus" runat="server" Text="" CssClass="badge badge-inverse"></asp:Label>
                                            </b>&nbsp; &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnStud_NextRecord" />
                                <asp:PostBackTrigger ControlID="btnStud_PrevRecord" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dlbouncechequeaging" runat="server" OnRowDataBound="dlStudentStatus_RowDataBound" ItemStyle-HorizontalAlign="Right">
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dlbouncechequeaging" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </div>
</asp:Content>
