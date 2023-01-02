<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Blocked_Cheque_Details.aspx.cs" Inherits="Blocked_Cheque_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                <b>Dashboard </b><small><i class="icon-double-angle-right"></i>&nbsp;<b>Bounced Accounts</b></small>
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
                            <i class="icon-book"></i>Blocked Cheque Details</h4>
                    </div>
                    <div class="widget-body">
                        <div class="table-toolbar" id="divtoolbar" runat="server" visible="false">
                        </div>
                        <asp:Repeater ID="dlBLOCKEDCHEQUE" runat="server" >
                            <HeaderTemplate>
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>
                                                <b>CENTER</b>
                                            </th>
                                            <th style="text-align: center">
                                                <b>Student Name</b>
                                            </th>
                                            <th style="text-align: center">
                                                <b>SBEntryCode</b>
                                            </th>
                                            <th style="text-align: center">
                                                <b>Stream Name</b>
                                            </th>
                                             <th style="text-align: center">
                                                <b>Cheque No</b>
                                            </th>
                                            <th style="text-align: center">
                                                <b>Cheque Date</b>
                                            </th>
                                             <th style="text-align: center">
                                                <b>Amount</b>
                                            </th>
                                             <th style="text-align: center">
                                                <b>Remarks</b>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="odd gradeX">                                    
                                    <td style="text-align: left">
                                        <asp:Label ID="lblCenter" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSTUDENTNAME" Text='<%#DataBinder.Eval(Container.DataItem, "studentname")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:Label ID="lblSBENTRYCODE" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntryCode")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="lblSTREAMt" Text='<%#DataBinder.Eval(Container.DataItem, "stream")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                     <td style="text-align: right">
                                        <asp:Label ID="LblCHEQUE" Text='<%#DataBinder.Eval(Container.DataItem, "chequeno")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                           <td style="text-align: right">
                                        <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "chequedate")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                     <td style="text-align: right">
                                        <asp:Label ID="LblAMOUNT" Text='<%#DataBinder.Eval(Container.DataItem, "amount")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                      <td style="text-align: right">
                                        <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Remarks")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                                                    
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </div>
</asp:Content>

