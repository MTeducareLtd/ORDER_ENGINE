<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Deposit_Slip_Details.aspx.cs" Inherits="Deposit_Slip_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid hidden-print">
        <div id="breadcrumbs" class="position-relative" style="height: 53px">
            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
            <ul class="breadcrumb" style="height: 15px">
                <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                    class="icon-angle-right"></i></span></li>
                <li>
                    <h4 class="blue">
                        <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname"
                            runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
                                <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                        <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                        <span class="divider"></span>
                    </h4>
                </li>
                <li id="li1" runat="server" visible="false"><a href="lead.aspx">
                    <asp:Label ID="Label13" runat="server"></asp:Label></a></li>
                <li id="li2" runat="server" visible="false"><i class="fa fa-angle-right"></i><a href="#">
                    <asp:Label ID="Label14" runat="server"></asp:Label></a></li>
            </ul>
            <%--<div id="nav-search">
                <button type="button" class="btn btn-app btn-primary btn-mini radius-4" data-toggle="dropdown"
                    data-hover="dropdown" data-delay="1000" data-close-others="true">
                    <span>Actions </span>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li><a id="btnmakeCMS" runat="server" onserverclick="btnmakeCMS_ServerClick">Make CMS</a>
                    </li>
                </ul>
            </div>--%>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
    <!-- END PAGE HEADER-->
    <div id="page-content" class="clearfix">
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
            <!--START PAGE CONTENT FOR VIEW CMS-->
            <asp:UpdatePanel ID="upnlviewcms" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="div5" runat="server">
                        <div class="span12">
                            <div id="Div6" class="tab-pane active">
                                <div class="row-fluid" id="Div7" runat="server">
                                    <div class="span12">
                                        <div class="portlet box blue">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-globe"></i>CMS Details
                                                </div>
                                            </div>
                                            <div class="portlet-body" style="height: 500px; overflow: Auto">
                                                <div class="table-responsive">
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <tr>
                                                            <td width="10%">
                                                                Deposit Slip No.
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtviewdepositslip" Enabled="false" runat="server" Width="95%" CssClass="popovers "
                                                                    data-trigger="hover" data-placement="top" data-content="Deposit Slip No."></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Deposit Date
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtviewdispatch" Enabled="false" runat="server" Width="95%" CssClass="popovers "
                                                                    data-trigger="hover" data-placement="top" data-content="Deposit Date"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Center
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtviewcenter" Enabled="false" runat="server" Width="95%" CssClass="popovers "
                                                                    data-trigger="hover" data-placement="top" data-content="Deposit Date"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:DataList ID="dlcmsdtls" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                        <HeaderTemplate>
                                                            <b>Mode</b></th>
                                                            <th>
                                                                Customer Name
                                                            </th>
                                                            <th>
                                                                Instrument No.
                                                            </th>
                                                            <th>
                                                                Dated
                                                            </th>
                                                            <th>
                                                                Amount
                                                            </th>
                                                            <th>
                                                                Bank Name
                                                            </th>
                                                            <th>
                                                            Product
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmode" Text='<%#DataBinder.Eval(Container.DataItem, "Mode")%>' runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblstudentname" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblinstrno" Text='<%#DataBinder.Eval(Container.DataItem, "chequeno")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblinstrdate" Text='<%#DataBinder.Eval(Container.DataItem, "ChequeDate")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblinstramt" Text='<%#DataBinder.Eval(Container.DataItem, "chequeAmt")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblbankname" Text='<%#DataBinder.Eval(Container.DataItem, "Bankname")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblstreamdec" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                                    runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
