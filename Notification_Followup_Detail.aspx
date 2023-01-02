<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Notification_Followup_Detail.aspx.cs" Inherits="Notification_Followup_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
       

        function Showalert() {
            alert('Call JavaScript function from codebehind');
        }

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="#">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    <asp:Label ID="lblNotificationName" runat="server" Text="Followup Not done In Lead" /><span class="divider"></span></h4>
            </li>
        </ul>        
    </div>
    <div id="page-content" class="clearfix">
        <!--/page-header-->
        <div class="row-fluid">
            <!-- -->
            <!-- PAGE CONTENT BEGINS HERE -->
            <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="alert alert-block alert-success" id="Msg_Success" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-ok"></i></strong>
                            <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                        </p>
                    </div>
                    <div class="alert alert-error" id="Msg_Error" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-remove"></i>Error!</strong>
                            <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
           
          
            <div id="DivResult" runat="server" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">                       
                             <h5 class="modal-title">
                            <asp:Label ID="lblHeader_Add" runat="server" Text="Add Campaign Detail"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div id="divprimary1" runat="server">                                           
                                                    
                                                    <div class="row-fluid">
                                                        
                                                        <div class="row-fluid">
                                                            <h5>
                                                            </h5>
                                                        </div>
                                                        <div class="row-fluid">
                                                            <div class="well well-small">
                                                                <div class="row-fluid">
                                                                    
                                                                    <asp:UpdatePanel ID="pnlSave2" runat="server">
                                                                        <ContentTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblActualRecordCount" runat="server" CssClass="badge badge-inverse"></asp:Label>
                                                                                        <asp:Label ID="lblPageNumber" runat="server" Visible="false"></asp:Label>
                                                                                        <button id="btnStud_NextRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                                                            data-rel="tooltip" data-placement="right" title="Find Next Record" visible="false" onserverclick="btnStud_NextRecord_ServerClick">
                                                                                            <i class="icon-share-alt"></i>
                                                                                        </button>
                                                                                        <button id="btnStud_PrevRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                                                            data-rel="tooltip" data-placement="right" title="Find Prev Record" visible="false" onserverclick="btnStud_PrevRecord_ServerClick">
                                                                                            <i class="icon-reply"></i>
                                                                                        </button>
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <asp:Label ID="lblTotalContacts2" runat="server" CssClass="badge badge-inverse">Total No of Records: </asp:Label>
                                                                                        &nbsp;
                                                                                        <asp:Label ID="lblTotalContacts" runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="btnStud_NextRecord" />
                                                                            <asp:PostBackTrigger ControlID="btnStud_PrevRecord" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row-fluid">
                                                            <asp:DataList ID="dlFollowupNotDoneInLead" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                                <HeaderTemplate>
                                                                    <b>
                                                                        Contact Name</b>
                                                                    </th>
                                                                    <th style="text-align: center">
                                                                        Division
                                                                    </th>
                                                                    <th style="text-align: center" >
                                                                        Center
                                                                    </th>
                                                                    <th style="text-align: center" >
                                                                        Acad Year
                                                                    </th>
                                                                     <th style="text-align: center" >
                                                                        Lead Created By
                                                                    </th>
                                                                     <th style="text-align: center" >
                                                                       Lead Created On
                                                                    </th>
                                                                    <th>
                                                                       Action
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                     <asp:Label ID="lblConName" Text='<%#DataBinder.Eval(Container.DataItem, "Contact_Name")%>'
                                                                            runat="server"  ></asp:Label>
                                                                    </td> </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lbLeadId" Text='<%#DataBinder.Eval(Container.DataItem, "Lead_Code")%>'
                                                                            runat="server"  Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                                            runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblDiv" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblCenter" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblAcad_Year" Text='<%#DataBinder.Eval(Container.DataItem, "Acad_Year")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblLeadCreatedby" Text='<%#DataBinder.Eval(Container.DataItem, "LeadCreatedBy")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblLeadCretedOn" Text='<%#DataBinder.Eval(Container.DataItem, "LeadCreatedOn")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Display.aspx?&Lead_Code={0}") %>'
                                                                        id="btndisplay" runat="server" target="_blank" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                        data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Edit.aspx?&Lead_Code={0}") %>'
                                                                            id="btndedit" runat="server" target="_blank" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                                            data-rel="tooltip" data-placement="top" title="Edit"></a>
                                                                    <asp:LinkButton ID="lnkedit" runat="server" Visible="false" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Lead_Code")%>'> </asp:LinkButton>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Followup.aspx?&Lead_Code={0}") %>'
                                                                        id="btnfollowup" runat="server" target="_blank" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                                                        data-rel="tooltip" data-placement="top" title="Follow-up"></a>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Convert_Lead_To_Opportunity.aspx?&Lead_Code={0}") %>'
                                                                        id="lnkconvert" runat="server" target="_blank" class="btn btn-minier btn-primary icon-check tooltip-info"
                                                                        data-rel="tooltip" data-placement="top" title="Convert"></a>
                                                                    
                                                                    
                                                                    <td id="Td1" runat="server" visible="false">
                                                                        <asp:Label ID="lblleadno" Text='<%#DataBinder.Eval(Container.DataItem, "Lead_Code")%>'
                                                                            runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                             <asp:DataList ID="dlOverdueFollowupInLead" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                                <HeaderTemplate>
                                                                    <b>
                                                                        Contact Name</b>
                                                                    </th>
                                                                    <th style="text-align: center" width="10%">
                                                                        Division
                                                                    </th>
                                                                    <th style="text-align: center" width="10%">
                                                                        Center
                                                                    </th>
                                                                    <th style="text-align: center" width="10%">
                                                                        Acad Year
                                                                    </th>
                                                                     <th style="text-align: center" width="30%">
                                                                        Feedback
                                                                    </th>
                                                                     <th style="text-align: center" width="10%">
                                                                        Last Followed By
                                                                    </th>
                                                                     <th style="text-align: center" width="10%">
                                                                       Last Followup Date
                                                                    </th>
                                                                    <th style="text-align: center" width="10%">
                                                                       Action
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                     <asp:Label ID="lblConName" Text='<%#DataBinder.Eval(Container.DataItem, "Contact_Name")%>'
                                                                            runat="server"  ></asp:Label>
                                                                    </td> </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lbLeadId" Text='<%#DataBinder.Eval(Container.DataItem, "Lead_Code")%>'
                                                                            runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                                            runat="server"  Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblDiv" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblCenter" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblAcad_Year" Text='<%#DataBinder.Eval(Container.DataItem, "Acad_Year")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblFeedback" Text='<%#DataBinder.Eval(Container.DataItem, "Feedback")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblLastFollowedBy" Text='<%#DataBinder.Eval(Container.DataItem, "LastFollowedBy")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblOverDueDate" Text='<%#DataBinder.Eval(Container.DataItem, "OverDueDate")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Display.aspx?&Lead_Code={0}") %>'
                                                                        id="btndisplay" runat="server" target="_blank" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                        data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Edit.aspx?&Lead_Code={0}") %>'
                                                                            id="btndedit" runat="server" target="_blank" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                                            data-rel="tooltip" data-placement="top" title="Edit"></a>
                                                                    <asp:LinkButton ID="lnkedit" runat="server" Visible="false" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Lead_Code")%>'> </asp:LinkButton>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Followup.aspx?&Lead_Code={0}") %>'
                                                                        id="btnfollowup" runat="server" target="_blank" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                                                        data-rel="tooltip" data-placement="top" title="Follow-up"></a>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Convert_Lead_To_Opportunity.aspx?&Lead_Code={0}") %>'
                                                                        id="lnkconvert" runat="server" target="_blank" class="btn btn-minier btn-primary icon-check tooltip-info"
                                                                        data-rel="tooltip" data-placement="top" title="Convert"></a>
                                                                    
                                                                    
                                                                    <td id="Td1" runat="server" visible="false">
                                                                        <asp:Label ID="lblleadno" Text='<%#DataBinder.Eval(Container.DataItem, "Lead_Code")%>'
                                                                            runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                            <asp:DataList ID="dlFollowupNotDoneInOpportunity" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                                <HeaderTemplate>
                                                                    <b>
                                                                        Contact Name</b>
                                                                    </th>
                                                                    <th style="text-align: center">
                                                                        Division
                                                                    </th>
                                                                    <th style="text-align: center" >
                                                                        Center
                                                                    </th>
                                                                    <th style="text-align: center" >
                                                                        Acad Year
                                                                    </th>
                                                                     <th style="text-align: center" >
                                                                        Opportunity Created By
                                                                    </th>
                                                                     <th style="text-align: center" >
                                                                       Opportunity Created On
                                                                    </th>
                                                                     <th style="text-align: center" >
                                                                       Action
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                     <asp:Label ID="lblConName" Text='<%#DataBinder.Eval(Container.DataItem, "Contact_Name")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td> </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblOpportunity_ID" Text='<%#DataBinder.Eval(Container.DataItem, "Opportunity_Code")%>'
                                                                            runat="server"  Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                                            runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblDiv" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblCenter" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblAcad_Year" Text='<%#DataBinder.Eval(Container.DataItem, "Acad_Year")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblOppCreatedBy" Text='<%#DataBinder.Eval(Container.DataItem, "OppCreatedBy")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblOpportunityCreatedOn" Text='<%#DataBinder.Eval(Container.DataItem, "OpportunityCreatedOn")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                         <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Display.aspx?&Opportunity_Code={0}") %>'
                                                                            id="btndisplay" runat="server" target="_blank" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                            data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Edit.aspx?&Opportunity_Code={0}") %>'
                                                                            id="btndedit" runat="server" target="_blank" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                                            data-rel="tooltip" data-placement="top" title="Edit"></a>
                                                                        <asp:LinkButton ID="lnkedit" runat="server" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                            Visible="false"></asp:LinkButton>
                                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Followup.aspx?&Opportunity_Code={0}") %>'
                                                                            id="btnfollowup" runat="server" target="_blank" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                                                            data-rel="tooltip" data-placement="top" title="Follow-up"></a>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                             <asp:DataList ID="dlOverdueFollowupInOpportunity" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                                <HeaderTemplate>
                                                                    <b>
                                                                        Contact Name</b>
                                                                    </th>
                                                                   <th style="text-align: center" width="10%">
                                                                        Division
                                                                    </th>
                                                                    <th style="text-align: center" width="10%">
                                                                        Center
                                                                    </th>
                                                                    <th style="text-align: center" width="10%">
                                                                        Acad Year
                                                                    </th>
                                                                     <th style="text-align: center" width="30%">
                                                                        Feedback
                                                                    </th>
                                                                     <th style="text-align: center" width="10%">
                                                                        Last Followed By
                                                                    </th>
                                                                     <th style="text-align: center" width="10%">
                                                                       Last Followup Date
                                                                    </th>
                                                                    <th style="text-align: center" width="10%">
                                                                       Action
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                     <asp:Label ID="lblConName" Text='<%#DataBinder.Eval(Container.DataItem, "Contact_Name")%>'
                                                                            runat="server" ></asp:Label>
                                                                    </td> </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblOpportunity_ID" Text='<%#DataBinder.Eval(Container.DataItem, "Opportunity_Code")%>'
                                                                            runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                                            runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblDiv" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblCenter" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblAcad_Year" Text='<%#DataBinder.Eval(Container.DataItem, "Acad_Year")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblFeedback" Text='<%#DataBinder.Eval(Container.DataItem, "Feedback")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblLastFollowedBy" Text='<%#DataBinder.Eval(Container.DataItem, "LastFollowedBy")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblOverDueDate" Text='<%#DataBinder.Eval(Container.DataItem, "OverDueDate")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                         <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Display.aspx?&Opportunity_Code={0}") %>'
                                                                            id="btndisplay" runat="server" target="_blank" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                            data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Edit.aspx?&Opportunity_Code={0}") %>'
                                                                            id="btndedit" runat="server" target="_blank" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                                            data-rel="tooltip" data-placement="top" title="Edit"></a>
                                                                        <asp:LinkButton ID="lnkedit" runat="server" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code")%>'
                                                                            Visible="false"></asp:LinkButton>
                                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"Opportunity_Code","Opportunity_Followup.aspx?&Opportunity_Code={0}") %>'
                                                                            id="btnfollowup" runat="server" target="_blank" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                                                            data-rel="tooltip" data-placement="top" title="Follow-up"></a>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
