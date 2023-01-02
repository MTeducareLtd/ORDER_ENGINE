<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Dashboard_Account.aspx.cs" Inherits="Dashboard_Account" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                Pending Admission <small><i class="icon-double-angle-right"></i> Overview & Stats</small>
                 <div class="nav ace-nav pull-right">
                  <small> Academic Year</small> <asp:DropDownList ID="ddlAcadYear" runat="server" data-placeholder="Select" 
                         AutoPostBack="true" onselectedindexchanged="ddlAcadYear_SelectedIndexChanged">
                                                                </asp:DropDownList>
                </div>
            </h1>
               
        </div>
        <div class="page-content">
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <button class="close" data-close="alert">
                </button>
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <button class="close" data-close="alert">
                </button>
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-danger" id="divmessage" runat="server">
                <strong>
                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                </strong>
            </div>
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="divsearchresults" runat="server">
                        <div class="span12">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="widget-box">
                                <div class="widget-header widget-hea1der-small header-color-dark">
                                    <h4 class="smaller">
                                        <i class="icon-book"></i>Pending Account (Center-Wise)</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="table-toolbar" id="divtoolbar" runat="server" visible="false">
                                    </div>
                                    <div id="OrgSerchCode" runat="server" visible="false">
                                        <asp:Label ID="lblTargetCompCode" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblTargetDivCode" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblTargetZoanCode" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblTargetCentreCode" runat="server" Text=""></asp:Label>
                                    </div>
                                    
                                            <asp:Repeater ID="dlPendingAccountsummary" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-striped table-bordered table-hover Table4">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    Center
                                                                </th>
                                                                <th style="text-align: center">
                                                                    [0-7 Days]
                                                                </th>
                                                                <th style="text-align: center">
                                                                    [8-30 Days]
                                                                </th>
                                                                <th style="text-align: center">
                                                                    [31-90 Days]
                                                                </th>
                                                                <th style="text-align: center">
                                                                    [More Than 90 Days]
                                                                </th>
                                                                <th style="text-align: center">
                                                                    [Total]
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="odd gradeX">
                                                        <td>
                                                            <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "[0-7 Days]")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "[8-30 Days]")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "[31-90 Days]")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "[More Than 90 Days]")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "Total")%>' runat="server"></asp:Label>
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
                    <div class="row-fluid" id="div1" runat="server">
                        <div class="span12">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="widget-box">
                                <div class="widget-header widget-hea1der-small header-color-dark">
                                    <h4 class="smaller">
                                        <i class="icon-book"></i>Pending Account (Detail)</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="table-toolbar" id="div2" runat="server" visible="false">
                                    </div>
                                    <div id="Div3" runat="server" visible="false">
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-bordered table-hover Table2">
                                                <thead>
                                                    <tr>
                                                        <th style="text-align: center">
                                                            Company
                                                        </th>
                                                        <th style="text-align: center">
                                                            Division
                                                        </th>
                                                        <th style="text-align: center">
                                                            Zone
                                                        </th>
                                                        <th style="text-align: center">
                                                            Center
                                                        </th>
                                                        <th style="text-align: center">
                                                            SBEntrycode
                                                        </th>
                                                        <th style="text-align: center">
                                                            Product
                                                        </th>
                                                        <th style="text-align: center">
                                                            Student Name
                                                        </th>
                                                        <th style="text-align: center">
                                                            Admission Date
                                                        </th>
                                                        <th style="text-align: center">
                                                            Ageing
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Company_Name")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Division_ShortDesc")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "Zone_Name")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Name")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label11" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntrycode")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label13" Text='<%#DataBinder.Eval(Container.DataItem, "Stream_Sdesc")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "Admission_Date")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label12" Text='<%#DataBinder.Eval(Container.DataItem, "Ageing")%>'
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
