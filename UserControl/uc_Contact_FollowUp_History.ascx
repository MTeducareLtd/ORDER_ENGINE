<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Contact_FollowUp_History.ascx.cs"
    Inherits="UserControl_uc_Contact_FollowUp_History" %>
<div class="row-fluid" id="divfeedbackhistory" runat="server">
    <div class="span12">
        <!-- BEGIN EXAMPLE TABLE PORTLET-->
        <div class="widget-box">
            <div class="widget-header widget-header-small header-color-dark">
                <h5>
                    <i class="icon-calendar"></i>Follow up History
                </h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <asp:DataList ID="dlfeedbackhistory" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                        <HeaderTemplate>
                            <b>Phase</b></th>
                            <th>
                                Interacted On
                            </th>
                            <th>
                                Interacted With
                            </th>
                            <th>
                                Relation
                            </th>
                     
                            <th>
                                Feedback
                            </th>
                            <th>
                                Next Follow-up
                            </th>
                            <th>
                                Agent
                            </th>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPhase" Text='<%#DataBinder.Eval(Container.DataItem, "Phase")%>'
                                runat="server"></asp:Label></a> </td>
                            <td>
                                <asp:Label ID="lblusermailid" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_On")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbluserid" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_With")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblusername" Text='<%#DataBinder.Eval(Container.DataItem, "Interacted_Relation")%>'
                                    runat="server"></asp:Label>
                            </td>
        
                            <td>
                                <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Feedback")%>'
                                    runat="server" data-trigger="hover" data-placement="top" data-content='<%#DataBinder.Eval(Container.DataItem, "Feedback")%>'></asp:Label></a>
                            </td>
                            <td>
                                <asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "Nextfollowupdate")%>'
                                    runat="server"></asp:Label></a>
                            </td>
                            <td>
                                <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Updated_By")%>'
                                    runat="server"></asp:Label></a>
                            </td>
                        </ItemTemplate>
                    </asp:DataList>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="alert alert-danger" id="diverrormessagefeedback" runat="server">
                                <strong>
                                    <asp:Label ID="lblerrrormessagefeedback" runat="server">No Follow up history found !!!</asp:Label></strong>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END EXAMPLE TABLE PORTLET-->
    </div>
</div>
<div class="row-fluid" id="divCallHoistory" runat="server">
    <div class="span12">
        <!-- BEGIN EXAMPLE TABLE PORTLET-->
        <div class="widget-box">
            <div class="widget-header widget-hea1der-small header-color-dark">
                <h5>
                    <i class="icon-calendar"></i>Call History
                </h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <asp:DataList ID="dlCallhistory" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                        <HeaderTemplate>
                            <b>Phase</b></th>
                             <th>
                                Calling Mode
                            </th>
                            <th>
                                Calling Date
                            </th>
                            <th>
                                Contact Type
                            </th>
                            <th>
                                Contact Number
                            </th>
                            <th>
                                Call Status
                            </th>
                            <th>
                                Call Duration
                            </th>
                            <th>
                                Call Recording
                            </th>
                        </HeaderTemplate>
                        <ItemTemplate>
                             <asp:Label ID="lblphase" Text='<%#DataBinder.Eval(Container.DataItem, "phase")%>'
                                runat="server"></asp:Label></a> 
                            </td>
                            <td>
                            <asp:Label ID="lblCallingMode" Text='<%#DataBinder.Eval(Container.DataItem, "CallingMode")%>'
                                runat="server"></asp:Label></a> </td>
                            <td>
                                <asp:Label ID="lblCallingDate" Text='<%#DataBinder.Eval(Container.DataItem, "CallingDate")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblContactType" Text='<%#DataBinder.Eval(Container.DataItem, "ContactType")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblContactNumber" Text='<%#DataBinder.Eval(Container.DataItem, "ContactNumber")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCallStatus" Text='<%#DataBinder.Eval(Container.DataItem, "CallStatus")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCallDuration" Text='<%#DataBinder.Eval(Container.DataItem, "CallDuration")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td align="center">
                                <a href='<%#DataBinder.Eval(Container.DataItem, "CallRecording")%>' id="btnCallRecording"
                                    runat="server" target="_blank" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                    data-rel="tooltip" data-placement="top" title="Record"></a>
                            </td>
                        </ItemTemplate>
                    </asp:DataList>
                    <div class="alert alert-danger" id="diverrormessageCallHistory" runat="server">
                        <strong>
                            <asp:Label ID="lblerrrormessageCallHistory" runat="server">No records found..!</asp:Label></strong>
                    </div>
                </div>
            </div>
        </div>
        <!-- END EXAMPLE TABLE PORTLET-->
    </div>
</div>
<div class="row-fluid">
    <div class="span12">
        <div class="widget-box">
            <div class="widget-header widget-hea1der-small header-color-dark">
                <h5>
                    Contact History
                </h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <div class="row-fluid">
                        <asp:DataList ID="dlConHistory" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                            <HeaderTemplate>
                                <b class="center" style="text-align: left">Event Name</b></th>
                                <th style="text-align: center">
                                    Event Description
                                </th>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEvent_Name" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Name")%>'
                                    runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEvent_Description" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Description")%>'
                                        runat="server"></asp:Label>
                                </td>
                            </ItemTemplate>
                        </asp:DataList>
                        <div class="alert alert-danger" id="diverrormessageContactHistory" runat="server">
                            <strong>
                                <asp:Label ID="lblCon_History"  runat="server">No records found..!</asp:Label>
                            </strong>
                        </div>                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
