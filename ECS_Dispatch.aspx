<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ECS_Dispatch.aspx.cs" Inherits="ECS_Dispatch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- CODE CHECKED -->
    <script type="text/javascript" src="assets/js/jquery.gritter.min.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid hidden-print">
        <div id="breadcrumbs" class="position-relative">
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                    class="icon-angle-right"></i></span></li>
                <li>
                    <h5 class="smaller">
                        <b>
                            <asp:Label ID="lblpagetitle1" runat="server">ECS Dispatch</asp:Label>&nbsp;</b>
                        <small>
                            <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                    </h5>
                </li>
            </ul>
            <div id="nav-search">
                <!-- /btn-group -->
                <button type="button" class="btn btn-primary btn-small radius-4  btn-danger" id="btnback"
                    runat="server" onserverclick="btnback_ServerClick">
                    <i class="icon-reply"></i>Back</button>
                <button type="button" class="btn  btn-primary btn-small radius-4  btn-danger" id="btnsearchback"
                    runat="server" onserverclick="btnsearchback_ServerClick">
                    <i class="icon-reply"></i>Back to ECS Search</button>
            </div>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
    <!-- END PAGE HEADER-->
    <!-- BEGIN CONTENT -->
    <div id="page-content" class="clearfix">
        <div class="page-content">
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>
            <asp:UpdatePanel ID="upnlsearch" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div id="tab_1_31" class="row-fluid">
                                <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-header widget-hea1der-small header-color-dark">
                                                <h4 class="smaller">
                                                    <i class="icon-search"></i>Search Options</h4>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-body-inner">
                                                    <div class="widget-main">
                                                        <table class="table table-striped table-bordered table-condensed">
                                                            <tr>
                                                                <td width="10%">
                                                                    Company
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                        Width="215px" ValidationGroup="Grplead12" AutoPostBack="true" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="10%">
                                                                    Division
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                        Width="215px" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="10%">
                                                                    Zone/Area
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlzone" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                        Width="215px" AutoPostBack="true" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="10%">
                                                                    Location / Center
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                        Width="215px" AutoPostBack="true" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="10%">
                                                                    Academic Year
                                                                    <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlacademicyear" runat="server" ValidationGroup="Grplead12"
                                                                        Width="215px" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="ddlacademicyear"
                                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Academic Year"
                                                                        InitialValue="Select" />
                                                                </td>
                                                                <td width="10%">
                                                                    Product
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlstream" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                        Width="215px" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="10%">
                                                                    Customer Number / SB Entry Code
                                                                </td>
                                                                <td width="20%" colspan="5">
                                                                    <asp:TextBox ID="txtsbentrycode" runat="server" Width="205px" placeholder="Search by SBEntrycode"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="widget-main alert-block alert-info" style="text-align: center;">
                                                        <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" onserverclick="btnsearch_ServerClick"
                                                            validationgroup="Grplead12" runat="server">
                                                            Search
                                                        </button>
                                                        <asp:ValidationSummary ID="ValidationSummary17" runat="server" ShowMessageBox="True"
                                                            ValidationGroup="Grplead12" ShowSummary="False" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid" id="divsearchresults" runat="server">
                                    <div class="span12">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                            <div class="widget-body">
                                                <div class="widget-header widget-hea1der-small header-color-dark">
                                                    <h4 class="smaller">
                                                        <i class="icon-briefcase"></i>Acknowledged ECS Search Results</h4>
                                                </div>
                                                <div class="widget-body">
                                                   <%-- <br>--%>
                                                    <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                                                        runat="server" Width="100%">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="chkAll_CheckedChanged"
                                                                AutoPostBack="true" />
                                                            <span class="lbl"></span></th>
                                                            <th align="left">
                                                                Division
                                                            </th>
                                                            <th align="left">
                                                                Center
                                                            </th>
                                                            <th align="left">
                                                                Student Name
                                                            </th>
                                                            <th align="left">
                                                                SBEntryCode
                                                            </th>
                                                            <th align="left">
                                                                Academic Year
                                                            </th>
                                                            <th align="left">
                                                                Product
                                                            </th>
                                                            <th align="left">
                                                                ECS Date
                                                            </th>
                                                            <th align="left">
                                                            ECS Amount
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkCheck" runat="server" Checked="false" visible='<%#(int)DataBinder.Eval(Container.DataItem,"ISDispatchFlag") == 1 ? false : true %>'/>
                                                            <span class="lbl" ></span>                                                            
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDivision" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                    runat="server"></asp:Label>
                                                                <asp:Label ID="lblECS_Id" Text='<%#DataBinder.Eval(Container.DataItem, "ECS_ID")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcenter" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Name")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcustomername" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label43" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblacadyear" Text='<%#DataBinder.Eval(Container.DataItem, "Acadyear")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblproduct" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblECS_Date" Text='<%#DataBinder.Eval(Container.DataItem, "ECS_Date")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblECS_Amount" runat="server" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "ECS_Amount")%>'></asp:Label>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <div class="widget-main alert-block alert-info" style="text-align: center;">
                                                    <!--Button Area -->
                                                    <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnExcel"
                                                        Text="Dispatch" ToolTip="Dispatch" onclick="btnExcel_Click"  />
                                                </div>
                                                </div>
                                                
                                            </div>
                                            <!-- END EXAMPLE TABLE PORTLET-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                    <asp:PostBackTrigger ControlID="btnExcel" />
                    
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
