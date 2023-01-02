<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ECS_Acknowledge.aspx.cs" Inherits="ECS_Acknowledge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                <b>Dashboard </b><small><i class="icon-double-angle-right"></i>&nbsp;<b>ECS Acknowledged</b></small>
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
                        <div class="span9" style="text-align: left">
                            <h4 class="smaller">
                                <i class="icon-book"></i>ECS Acknowledged</h4>
                        </div>
                        <div class="span3">
                            <button type="button" class="btn btn-primary btn-small radius-4  btn-danger" id="btnback"
                                runat="server" onserverclick="btnback_ServerClick">
                                <i class="icon-reply"></i>Back</button>
                        </div>
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
                                                Division
                                            </th>
                                            <th style="text-align: center">
                                                Center
                                            </th>
                                            <th style="text-align: center">
                                                Stream
                                            </th>
                                            <th style="text-align: center">
                                                Student Name
                                            </th>
                                            <th style="text-align: center">
                                                ECS Creted On
                                            </th>
                                            <th style="text-align: center">
                                                Description
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="odd gradeX">
                                    <td>
                                        <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Name")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "ECS_DATE")%>' runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Description")%>'
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
