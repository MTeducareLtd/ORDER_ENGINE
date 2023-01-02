<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Pending_Account_Ageing.aspx.cs" Inherits="Pending_Account_Ageing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                <b>Dashboard </b><small><i class="icon-double-angle-right"></i>&nbsp;<b>Pending Account
                    Ageing</b></small>
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
                            <i class="icon-book"></i>Pending Account Ageing (Center-Wise)</h4>
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
                        <asp:Repeater ID="dlPendingAccountsummary" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-striped table-bordered table-hover Table4">
                                    <thead>
                                        <tr>
                                            <th>
                                                Center
                                            </th>
                                            <th>
                                                Pending Reason
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
                                     <td>
                                        <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "PendingReasonDesc")%>'
                                            runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <%-- <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "[0-7 Days]")%>'
                                            runat="server"></asp:Label>--%>
                                        <asp:LinkButton ID="lnkbtn" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"[0-7 Days]")%>'
                                            CommandName="[0-7 Days]" Font-Underline="True">
                                            <asp:Label ID="Label12" Text='<%#DataBinder.Eval(Container.DataItem, "[0-7 Days]")%>'
                                                ForeColor="DarkBlue" runat="server" /></asp:LinkButton>
                                    </td>
                                    <td style="text-align: right">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"[8-30 Days]")%>'
                                            CommandName="[8-30 Days]" Font-Underline="True">
                                            <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "[8-30 Days]")%>'
                                                ForeColor="DarkBlue" runat="server" /></asp:LinkButton>
                                      </td>
                                    <td style="text-align: right">
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"[31-90 Days]")%>'
                                            CommandName="[31-90 Days]" Font-Underline="True">
                                            <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "[31-90 Days]")%>'
                                                ForeColor="DarkBlue" runat="server" /></asp:LinkButton>
                                    </td>
                                    <td style="text-align: right">
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"[More Than 90 Days]")%>'
                                            CommandName="[More Than 90 Days]" Font-Underline="True">
                                            <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "[More Than 90 Days]")%>'
                                                ForeColor="DarkBlue" runat="server" /></asp:LinkButton>
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
                <asp:DataList ID="DLPENDINGACOOUNTDETAILED" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="True">
                    <HeaderTemplate>
                    <%-- <th style="text-align: center;">
                            Center Name
                        </th>--%>
                       <b>Center</b>
                        <%--</th>--%>
                          <th style="text-align: center;">
                            Student Name
                        </th>
                        <th style="text-align: center;">
                            SBentryCode
                        </th>
                        <th style="text-align: center;">
                            Stream Name
                        </th>
                        <th style="text-align: center;">
                            Admission Date
                        </th>
                        <th style="text-align: center;">
                            Ageing days
                        </HeaderTemplate>
                    <ItemTemplate>
                       
                        <asp:Label ID="lblPremises" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Source_Center_Name")%>' />
                        </td>
                        <td style="width: 25%; text-align: left;">
                            <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                        </td>
                        <td style="width: 15%; text-align: left;">
                            <asp:Label ID="Label32" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' />
                        </td>
                        <td style="width: 25%; text-align: left;">
                            <asp:Label ID="Label33" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Stream_Sdesc")%>' />
                        </td>
                        <td style="width: 10%; text-align: left;">
                            <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Admission_Date")%>' />
                        </td>
                        <td style="width: 10%; text-align: left;">
                            <asp:Label ID="Label38" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ageing")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
