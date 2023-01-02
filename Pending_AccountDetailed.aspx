<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Pending_AccountDetailed.aspx.cs" Inherits="Pending_AccountDetailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            
        </div>
        <div class="row-fluid" id="divsearchresults" runat="server">
            <div class="span12">
                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                <div class="widget-box">
                    <div class="widget-header widget-hea1der-small header-color-dark">
                        <h4 class="smaller">
                            <i class="icon-book"></i>Pending Accounts Detailed                            
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
                                            <asp:Label ID="lblTotalPendingAccounts" runat="server" Text="" CssClass="badge badge-inverse"></asp:Label>
                                        </b>
                                            &nbsp;
                                            &nbsp;
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
                                <asp:DataList ID="dlPendingAccountReasonwise" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%" >
                                    <HeaderTemplate>
                                        <b>Stream</b> </th>
                                        <th style="width: 20%; text-align: center;">
                                            Student Name
                                        </th>
                                        <th style="width: 5%; text-align: center;">
                                            Net Fees
                                        </th>
                                        <th style="width: 5%; text-align: center;">
                                            Outstanding
                                        </th>
                                        <th style="width: 14%; text-align: center;">
                                            Reason
                                        </th>
                                        <th style="width: 14%; text-align: center;">
                                            Expected Close Date
                                        </th>
                              
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStream" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                runat="server"></asp:Label>
                                           </td>
                                        <td>
                                            <asp:Label ID="lblStudentName" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: right;">
                                           <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Netfees")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Chqoutstanding")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                         <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Pending_ReasonId")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                         <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "ExpectedCloseDate")%>'
                                              data-date-format="dd M yyyy"  runat="server"></asp:Label>
                                                                                          
                                        </td>
                                       
                                    </ItemTemplate>
                                </asp:DataList>
                        
                            </ContentTemplate>
                            
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </div>
</asp:Content>

