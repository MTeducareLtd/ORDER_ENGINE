<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Manage_Request.aspx.cs" Inherits="Manage_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
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
                                <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname"
                                    runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
                                        <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                                <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                                <span class="divider"></span>
                            </h5>
                        </li>
                        <li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
                            <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
                        <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
                        </i><a href="#">
                            <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
                        
                        
                        
                    </ul>

                    <div id="nav-search" >
                        <button type="button" class="btn  btn-primary btn-small radius-4  btn-danger" id="btnsearchback"
                                                                    runat="server" onserverclick="btnsearchback_ServerClick" visible="false">
                                                                    <i class="icon-reply"></i>Back to Request Search</button>
                    </div>
                    <!-- END PAGE TITLE & BREADCRUMB-->
                </div>
            </div>

    <!-- END PAGE HEADER-->
    <!-- BEGIN CONTENT -->
    <div id="page-content" class="clearfix">
        <div class="page-content">
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div id="tab_1_3">
                                <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Organizational Assignment
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    
                                                    <td width="10%">
                                                        Division
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                         <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" Visible="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Center
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                      
                                                    </td>
                                                    <td width="20%">
                                                       
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Customer Information
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Academic Year
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlacademicyear" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Product
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlstreamname" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Customer Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtname" runat="server" placeholder="Search by Name"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Customer Number / SB Entry Code
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtsbentrycode" runat="server" placeholder="Search by SBEntrycode"></asp:TextBox>
                                                    </td>
                                                    <td width="10%" id="tdapplicationid" runat="server">
                                                        App. Form No
                                                    </td>
                                                    <td width="20%" id="tdapplicationid1" runat="server">
                                                        <asp:TextBox ID="txtapplicationno" runat="server" placeholder="Search by Application Form No."></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Request Type
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlrequesttype" runat="server" data-placeholder="Select" CssClass="chzn-select">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Request Status
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlrequeststatus" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select">
                                                            <asp:ListItem Value="All" Selected="true">All</asp:ListItem>
                                                            <asp:ListItem Value="0">Pending</asp:ListItem>
                                                            <asp:ListItem Value="1">Approved</asp:ListItem>
                                                            <asp:ListItem Value="2">Declined</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        
                                                    </td>
                                                    <td width="20%">
                                                        
                                                    </td>
                                                    <td width="10%">
                                                        
                                                    </td>
                                                    <td width="20%">
                                                        
                                                    </td>
                                                </tr>
                                                <tr id="tr11" runat="server" visible="false">
                                                    <td width="10%">
                                                        Request Date
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtrequestdate" runat="server" placeholder="Search by Date"></asp:TextBox>
                                                        <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtrequestdate"
                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                        </CC1:CalendarExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" runat="server"
                                                    onserverclick="btnsearch_ServerClick">
                                                    Search
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid" id="divsearchresults" runat="server">
                                    <div class="span12">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                            <div class="widget-header widget-header-small header-color-dark">
                                                <h5>
                                                    <i class="fa fa-globe"></i>Manage Request - Status
                                                </h5>
                                                
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                
                                                     <asp:Repeater id="Repeater1" runat ="server"  OnItemDataBound ="Repeater1_ItemDataBound"  >
                                                        <HeaderTemplate>
                                                            <table class="table table-striped table-bordered table-hover Table2">
							                                <thead>
							                                <tr>
                                                                <th></th>
                                                                <th style="text-align: center">Acad Year</th>
                                                                <th style="text-align: center">Date</th>
                                                                <th style="text-align: center">Center / Location</th>
                                                                <th style="text-align: center">Request Type</th>
                                                                <th style="text-align: center">Name</th>
                                                                <th style="text-align: center">Product</th>
                                                                <th style="text-align: center">Requested Amount</th>
                                                                <th style="text-align: center">Status</th>
                                                                <th style="text-align: center">Open (Days)</th>
                                                                <th style="text-align: center">Action</th>
                                                            </tr>
							                                </thead>
							                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr class="odd gradeX">
								                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "Acad_year")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Date")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblrequesttype" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Type")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Student_Name")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "Stream_Sdesc")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            
                                                                <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Amount")%>'
                                                                    runat="server"></asp:Label></div>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "Request_Status")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label10" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='<%#DataBinder.Eval(Container.DataItem,"Sbentrycode","View_Request_Details.aspx?&SBEntrycode={0}")%>&Req_id=<%#DataBinder.Eval(Container.DataItem,"Request_id")%>'
                                                                target="_blank" class="btn btn-minier btn-primary icon-eye-open tooltip-info" data-rel="tooltip" data-placement="top" title="View Details"></a>
                                                        </td>
                                                         <td id="Td1" width="2%" runat="server" visible="false">
                                                            <asp:Label ID="lblsbentrycode" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntrycode")%>'
                                                                runat="server" Visible="false"></asp:Label>
                                                        </td>
							                                </tr>
                                                            
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                                        </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div> 
                                            </div>
                                        </div>
                                        <!-- END EXAMPLE TABLE PORTLET-->
                                    </div>
                                </div>
                                <div class="alert alert-danger" id="divmessage" runat="server">
                                    <strong>
                                        <asp:Label ID="lblmessage" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    
                    <asp:PostBackTrigger ControlID ="btnsearch" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
        </div>
    </div>
    <!-- END CONTENT -->
    <!-- END CONTAINER -->
</asp:Content>
