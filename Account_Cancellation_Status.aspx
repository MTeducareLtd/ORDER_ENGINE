<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Account_Cancellation_Status.aspx.cs" Inherits="Account_Cancellation_Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                <b>Dashboard </b><small><i class="icon-double-angle-right"></i>&nbsp;<b>Accounts Cancellation Status</b></small>
                <div class="nav ace-nav pull-right">
                    <small style="font-size: 16px">Division</small>
                    <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp; <small style="font-size: 16px">Center</small>
                    <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp; <small style="font-size: 16px">Academic Year</small>
                    <asp:DropDownList ID="ddlAcadYear" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddlAcadYear_SelectedIndexChanged">
                    </asp:DropDownList>
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
                            <i class="icon-book"></i>Accounts Cancellation Status                            
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
                                <asp:DataList ID="dlAccountCancellationStatus" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%">
                                    <HeaderTemplate>
                                        <b>Request Date</b> </th>
                                        <th style="width: 20%; text-align: center;">
                                            Center Name
                                        </th>
                                        <th style="width: 14%; text-align: center;">
                                            Stream Name
                                        </th>
                                        <th style="width: 14%; text-align: center;">
                                            Student Name
                                        </th>
                                        <th style="width: 14%; text-align: center;">
                                            SBentry Code
                                        </th>
                                        <th style="width: 8%; text-align: center;">
                                            Request Type
                                        </th>
                                        <th style="width: 8%; text-align: center; vertical-align: middle;">
                                            Level No
                                        </th>
                                        <th style="width: 8%; text-align: center; vertical-align: middle;">
                                            Request Status
                                        </th>
                                        <th style="width: 8%; text-align: center; vertical-align: middle;">
                                            Approved By
                                        </th>
                                        <th style="width: 8%; text-align: center; vertical-align: middle;">
                                            Centre Remark
                                        </th>
                                        <th style="width: 8%; text-align: center; vertical-align: middle;">
                                            Approval Remark
                                        </th>
                                        <th style="width: 8%; text-align: center; vertical-align: middle;">
                                            TAT
                                        </th>
                                        <th style="width: 8%; text-align: center; vertical-align: middle;">
                                            Date of Approved
                                        </th>                                   
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRequest_Date" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Date")%>'
                                            runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCenter" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblStream" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Label ID="lblStudentName" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'
                                                runat="server">
                                            </asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblSbEntrycode" Text='<%#DataBinder.Eval(Container.DataItem, "SbEntrycode")%>'
                                                runat="server">
                                            </asp:Label>                                            
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblRequestType" Text='<%#DataBinder.Eval(Container.DataItem, "RequestType")%>'
                                                runat="server">
                                            </asp:Label>                                            
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblLevel_No" Text='<%#DataBinder.Eval(Container.DataItem, "Level_No")%>'
                                                runat="server">
                                            </asp:Label>                                            
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblRequestStatus" Text='<%#DataBinder.Eval(Container.DataItem, "RequestStatus")%>'
                                                runat="server">
                                            </asp:Label>                                            
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblApprovedby" Text='<%#DataBinder.Eval(Container.DataItem, "Approvedby")%>'
                                                runat="server">
                                            </asp:Label>                                            
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblCentre_Remark" Text='<%#DataBinder.Eval(Container.DataItem, "Centre_Remark")%>'
                                                runat="server">
                                            </asp:Label>                                            
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblApproval_Remark" Text='<%#DataBinder.Eval(Container.DataItem, "Approval_Remark")%>'
                                                runat="server">
                                            </asp:Label>                                            
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblTAT" Text='<%#DataBinder.Eval(Container.DataItem, "TAT")%>'
                                                runat="server">
                                            </asp:Label>                                            
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblDate_of_Approved" Text='<%#DataBinder.Eval(Container.DataItem, "Date_of_Approved")%>'
                                                runat="server">
                                            </asp:Label>
                                        </td>
                                    </ItemTemplate>
                                </asp:DataList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dlAccountCancellationStatus" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </div>
</asp:Content>
