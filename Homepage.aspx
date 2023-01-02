<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                Dashboard <small><i class="icon-double-angle-right"></i> Overview & Stats</small>
                 <div class="nav ace-nav pull-right">
                  <small> Academic Year</small> <asp:DropDownList ID="ddlAcadYear" runat="server" data-placeholder="Select" 
                         AutoPostBack="true" onselectedindexchanged="ddlAcadYear_SelectedIndexChanged">
                                                                </asp:DropDownList>
                </div>
            </h1>
               
        </div>
        <!--/page-header-->
        <div class="row-fluid">
            <!-- PAGE CONTENT BEGINS HERE -->
             <div class="alert alert-block alert-success">
            <button type="button" class="close" data-dismiss="alert"><i class="icon-remove"></i></button>
            <i class="icon-ok green"></i> Welcome to <strong class="green">Order Engine <small>(v2.8)</small></strong>,
            
        </div>
            <div class="space-6">
            </div>
            <div class="row-fluid">
                <div class="span7 infobox-container">
                    <div class="infobox infobox-green">
                        <div class="infobox-icon">
                            <i class="icon-book"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"><a href="Dashboard_Lead.aspx" target="_blank">
                                <asp:Label ID="lblleadcount" runat="server"></asp:Label></a></span> <span class="infobox-content">
                                    Pending Lead</span>
                        </div>
                        <!--<div class="stat stat-success">
                            8%</div>-->
                    </div>
                    <div class="infobox infobox-blue">
                        <div class="infobox-icon">
                            <i class="icon-group"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"><a id="Dashboard_Opportunity" target="_blank" runat="server">
                                <asp:Label ID="lblopportunitycount" runat="server"></asp:Label></a></span> <span
                                    class="infobox-content">Pending Opportunity</span>
                        </div>
                        <!--<div class="badge badge-success">
                            +32%</div>-->
                    </div>
                    <div class="infobox infobox-pink">
                        <div class="infobox-icon">
                            <i class="icon-shopping-cart"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"><a id="aadmission" target="_blank" runat="server">
                                <asp:Label ID="lblAccountCount" runat="server"></asp:Label></a></span> <span class="infobox-content">
                                    Admission</span>
                        </div>
                        <!--<div class="stat stat-important">
                            4%</div>-->
                    </div>

                    <div class="infobox infobox-red">
                        <div class="infobox-icon">
                            <i class="icon-beaker"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">
                                <asp:Label ID="lblconversion" runat="server" ></asp:Label></span> <span class="infobox-content">
                                    Conversion</span>
                        </div>
                    </div>
                    <div class="infobox infobox-orange2">
                        <div class="infobox-chart">
                            <span class="sparkline" data-values="196,128,202,177,154,94,100,170,224"></span>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"><a id="apendingadmission" target="_blank" runat="server">
                                <asp:Label ID="lblpendingaccount" runat="server"></asp:Label></a></span> <span class="infobox-content">
                                    Pending Admission</span>
                        </div>
                        <!--<div class="badge badge-success">
                            7.2% <i class="icon-arrow-up"></i>
                        </div>-->
                    </div>
                    <div class="infobox infobox-blue2">
                        <div class="infobox-progress">
                            <div class="easy-pie-chart percentage" id="divconfirmadmission" runat="server">
                                <span class="percent">
                                    <asp:Label ID="lblconfirmaccount" runat="server"></asp:Label></span>
                            </div>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-text">Confirm Admission</span> <span class="infobox-content"><span
                                class="approx">~</span>
                                <asp:Label ID="lblpendingacc" runat="server"></asp:Label>
                                remaining</span>
                        </div>
                    </div>
                  
                    <div class="infobox infobox-blue3">
                        <div class="infobox-icon">
                            <i class="icon-asterisk"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number">
                                <asp:Label ID="lblpendingfollowup" runat="server" ></asp:Label></span> <span class="infobox-content">
                                    Pending Lead Followup</span>
                        </div>
                    </div>
                    <div class="infobox infobox-red">
                        <div class="infobox-icon">
                            <i class="icon-file"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"><a href="" target="_blank">
                                <asp:Label ID="lbldiscountvalue" runat="server"></asp:Label></a></span> <span class="infobox-content">
                                    Discount</span>
                        </div>
                        <!--<div class="badge badge-success">
                            7.2% <i class="icon-arrow-up"></i>
                        </div>-->
                    </div>
                    <div class="infobox infobox-black">
                        <div class="infobox-progress">
                            <div class="easy-pie-chart percentage" data-percent="65" data-size="46">
                                <span class="percent">
                                    <asp:Label ID="lblApprovalPendingCount" runat="server"></asp:Label></span>
                            </div>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-text">Pending Approval</span> <span class="infobox-content"><span
                                class="approx"></span>
                            </span>
                        </div>
                    </div>

                      <div class="space-6">
                    </div>
                    <%--<div class="infobox infobox-small infobox-dark infobox-green">
                        <div class="infobox-progress">
                            <div class="easy-pie-chart percentage" data-size="39" id="divleadcount" runat="server">
                                <!--data-percent="10"-->
                                <span class="percent">
                                    <asp:Label ID="lblpendingfollowup" runat="server"></asp:Label></span>
                            </div>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-content"><b>Lead</b></span>
                            <br />
                            <span class="infobox-content">Followup</span>
                        </div>
                    </div>
                    <div class="infobox infobox-small infobox-dark infobox-blue">
                        <div class="infobox-chart">
                            <span class="sparkline" data-values="3,4,2,3,4,4,2,2"></span>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-content"><b>Discount</b></span>
                            <br />
                            <span class="infobox-content">
                                <asp:Label ID="lbldiscountvalue" runat="server"></asp:Label></span>
                        </div>
                    </div>
                    <div class="infobox infobox-small infobox-dark infobox-grey">
                        <div class="infobox-icon">
                            <i class="icon-download-alt"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-content"><b>Approval</b></span>
                            <br />
                            <span class="infobox-content">
                                <asp:Label ID="lblApprovalPendingCount" runat="server"></asp:Label></span>
                        </div>
                    </div>--%>
                </div>
                <div class="span5">
                    <div class="widget-box">
                        <div class="widget-header widget-header-flat widget-header-small">
                            <h5>
                                <i class="icon-signal"></i>Lead Status</h5>
                            <!--<div class="widget-toolbar no-border">
                                <button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">
                                    This Week <i class="icon-angle-down icon-on-right"></i>
                                </button>
                                <ul class="dropdown-menu dropdown-info pull-right dropdown-caret">
                                    <li class="active"><a href="#">This Week</a></li>
                                    <li><a href="#">Last Week</a></li>
                                    <li><a href="#">This Month</a></li>
                                    <li><a href="#">Last Month</a></li>
                                </ul>
                            </div>-->
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                <asp:Chart ID="Chart1" runat="server" Width="540px" Palette="Excel" 
                                    Height="200px" BackColor="LightBlue">
                                    <series>
                                        <asp:Series Name="Series1" Legend="Legend1"
                                            IsValueShownAsLabel="false" IsVisibleInLegend ="True" YValuesPerPoint="2">
                                        </asp:Series>
                                    </series>
                                    <chartareas>
                                        <asp:ChartArea Name="ChartArea1">
                                            
                                            <Area3DStyle Enable3D="True"></Area3DStyle>
                                        </asp:ChartArea>
                                    </chartareas>
                                    <legends>
                                        <asp:Legend Name="Legend1">
                                        </asp:Legend>
                                    </legends>
                                </asp:Chart>
                            </div>
                            <!--/widget-main-->
                        </div>
                       

                    </div>
                    <!--/widget-box-->
                </div>
                <!--/span-->
            </div>
            <!--/row-->
            <div class="hr hr32 hr-dotted">
            </div>
            <div class="row-fluid">
                <div class="span7">
                    <div class="widget-box">
                        <div class="widget-header widget-header-flat widget-header-small">
                            <h5>
                                <i class="icon-signal"></i>Sales Stage</h5>
                            <!--<div class="widget-toolbar no-border">
                                <button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">
                                    This Week <i class="icon-angle-down icon-on-right"></i>
                                </button>
                                <ul class="dropdown-menu dropdown-info pull-right dropdown-caret">
                                    <li class="active"><a href="#">This Week</a></li>
                                    <li><a href="#">Last Week</a></li>
                                    <li><a href="#">This Month</a></li>
                                    <li><a href="#">Last Month</a></li>
                                </ul>
                            </div>-->
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                <asp:Chart ID="Chart2" runat="server" Width="600" Palette="Excel" Height="200" BackColor="LightBlue">
                                    <series>
                                        <asp:Series Name="Series1" Legend="Legend1" 
                                            IsValueShownAsLabel="False" IsVisibleInLegend ="true" 
                                            ChartType="Funnel">
                                        </asp:Series>
                                    </series>
                                    <chartareas>
                                        <asp:ChartArea Name="ChartArea1">
                                            
                                            <Area3DStyle Enable3D="True"></Area3DStyle>
                                        </asp:ChartArea>
                                    </chartareas>
                                    <legends>
                                        <asp:Legend Name="Legend1">
                                        </asp:Legend>
                                    </legends>
                                </asp:Chart>
                            </div>
                            <!--/widget-main-->
                        </div>
                        <!--/widget-body-->
                    </div>
                    <!--/widget-box-->
                </div>
                <div class="span5">
                    <div class="widget-box">
                        <div class="widget-header widget-header-flat widget-header-small">
                            <h5>
                                <i class="icon-signal"></i>Total Pipeline by Sales Stage</h5>
                            <!--<div class="widget-toolbar no-border">
                                <button class="btn btn-minier btn-primary dropdown-toggle" data-toggle="dropdown">
                                    This Week <i class="icon-angle-down icon-on-right"></i>
                                </button>
                                <ul class="dropdown-menu dropdown-info pull-right dropdown-caret">
                                    <li class="active"><a href="#">This Week</a></li>
                                    <li><a href="#">Last Week</a></li>
                                    <li><a href="#">This Month</a></li>
                                    <li><a href="#">Last Month</a></li>
                                </ul>
                            </div>-->
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                <asp:Chart ID="Chart3" runat="server" Width="1000" Palette="Excel" Height="200" BackColor="LightBlue">
                                    <series>
                                        <asp:Series Name="Series1" Legend="Legend1" 
                                            IsValueShownAsLabel="False" IsVisibleInLegend ="true" 
                                            ChartType="FastLine">
                                        </asp:Series>
                                    </series>
                                    <chartareas>
                                        <asp:ChartArea Name="ChartArea1">
                                            
                                            <Area3DStyle Enable3D="True"></Area3DStyle>
                                        </asp:ChartArea>
                                    </chartareas>
                                    <legends>
                                        <asp:Legend Name="Legend1">
                                        </asp:Legend>
                                    </legends>
                                </asp:Chart>
                            </div>
                            <!--/widget-main-->
                        </div>
                        <!--/widget-body-->
                    </div>
                    <!--/widget-box-->
                </div>
            </div>
            <div class="vspace">
            </div>
        </div>
        <div class="row-fluid" runat="server" visible="false">
            <!-- BEGIN DASHBOARD STATS -->
            <!--START DASHBOARD STATS-->
            <div class="row-fluid">
                <div class="span12 infobox-container">
                    <div class="infobox infobox-green">
                        <div class="infobox-icon">
                            <i class="icon-bullhorn"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"></span><a class="more" href="#"><span class="infobox-content">
                                Lead</span></a>
                        </div>
                        <div class="badge badge-success">
                        </div>
                    </div>
                    <div class="infobox infobox-blue">
                        <div class="infobox-icon">
                            <i class="icon-user"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"></span><a class="more" href="#"><span class="infobox-content">
                                Opportunity</span></a>
                        </div>
                        <div class="badge badge-info">
                        </div>
                    </div>
                    <div class="infobox infobox-orange">
                        <div class="infobox-icon">
                            <i class="icon-book"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"></span><a class="more" href="#"><span class="infobox-content">
                                Account</span></a>
                        </div>
                        <div class="badge badge-warning">
                        </div>
                    </div>
                    <div class="infobox infobox-red">
                        <div class="infobox-icon">
                            <i class="icon-check"></i>
                        </div>
                        <div class="infobox-data">
                            <span class="infobox-data-number"></span><a class="more" href="#"><span class="infobox-content">
                                Conversion</span></a>
                        </div>
                        <div class="badge badge-important">
                        </div>
                    </div>
                </div>
            </div>
            <!-- END DASHBOARD STATS -->
            <div class="hr hr32 hr-dotted">
            </div>
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-header widget-hea1der-small">
                        <h4 class="lighter">
                            <i class="icon-bullhorn green"></i>Lead - Summary</h4>
                        <div class="widget-toolbar">
                            <button type="button" class="btn btn-success btn-mini radius-4 icon-download-alt"
                                title="Export" id="btnexport" runat="server">
                            </button>
                            <asp:DropDownList ID="ddlcompanyselect" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main">
                            <div class="widget-main no-padding" style="height: 240px; overflow-y: scroll; overflow-x: none;">
                                <div class="content">
                                    <asp:GridView ID="dlleadsummary" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="hr hr12">
            </div>
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-header widget-hea1der-small">
                        <h4 class="lighter">
                            <i class="icon-user blue"></i>Opportunity - Summary</h4>
                        <div class="widget-toolbar">
                            <button type="button" class="btn btn-primary btn-mini radius-4 icon-download-alt"
                                title="Export" id="btnexpopp" runat="server">
                            </button>
                            <asp:DropDownList ID="ddlcompanysearchopp" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main">
                            <div class="widget-main no-padding" style="height: 240px; overflow-y: scroll; overflow-x: none;">
                                <div class="content">
                                    <asp:GridView ID="dloppsummary" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
