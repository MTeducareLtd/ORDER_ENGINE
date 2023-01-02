<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Fees_Deductions.aspx.cs" Inherits="Fees_Deductions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .rightside
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                <b>Dashboard </b><small><i class="icon-double-angle-right"></i>&nbsp;<b>Fees Deductions
                </b></small>
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
                            <i class="icon-book"></i>Fees Deductions</h4>
                    </div>
                    <div class="widget-body">
                        <asp:GridView ID="dlPendingAccountsummary" class="table-bordered" runat="server"
                            AutoGenerateColumns="False" OnRowCreated="dlPendingAccountsummary_RowCreated"
                            HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundField DataField="Stream" HeaderText="Stream" ItemStyle-Width="250" HeaderStyle-BackColor="Gray"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="False" HeaderStyle-ForeColor="White"
                                    HeaderStyle-CssClass="center" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle CssClass="left" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Predefined_Discounts_Students" HeaderText="Count" HeaderStyle-BackColor="Gray"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center"
                                    ItemStyle-CssClass="rightside" ItemStyle-Width="150">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle BackColor="LightSkyBlue" CssClass="rightside"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Predefined_Discounts" HeaderText="Amount" HeaderStyle-BackColor="Gray"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center"
                                    ItemStyle-CssClass="rightside" ItemStyle-Width="150">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle BackColor="LightSkyBlue" CssClass="rightside"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Other_Discount_Students" HeaderText="Count" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightGreen" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center"
                                    ItemStyle-CssClass="rightside">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightGreen" CssClass="rightside"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Other_Discount" HeaderText="Amount" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightGreen" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center"
                                    ItemStyle-CssClass="right">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightGreen" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Concessions_Students" HeaderText="Count" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightPink" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightPink" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Concessions" HeaderText="Amount" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightPink" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightPink" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Waivers_Students" HeaderText="Count" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightSalmon" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightSalmon" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Waivers" HeaderText="Amount" ItemStyle-Width="150" ItemStyle-BackColor="LightSalmon"
                                    HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightSalmon" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Additional_Discounts_Students" HeaderText="Count" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightSkyBlue" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightSkyBlue" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Additional_Discounts" HeaderText="Amount" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightSkyBlue" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightSkyBlue" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Additional_Concessions_Students" HeaderText="Count" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightSteelBlue" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightSteelBlue" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Additional_Concessions" HeaderText="Amount" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightSteelBlue" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightSteelBlue" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Total_Students" HeaderText="Count" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightCyan" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightCyan" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Total_Value" HeaderText="Amount" ItemStyle-Width="150"
                                    ItemStyle-BackColor="LightCyan" HeaderStyle-BackColor="Gray" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" BackColor="LightCyan" CssClass="right"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </div>
</asp:Content>
