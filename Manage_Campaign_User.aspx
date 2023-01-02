<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Manage_Campaign_User.aspx.cs" Inherits="Manage_Campaign_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 45 && AsciiValue <= 57))
                event.returnValue = true;
            else
                event.returnValue = false;
        }
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else
                event.returnValue = false;
        }

        function NumberandCharOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || AsciiValue == 40 || AsciiValue == 41 || AsciiValue == 45)
                event.returnValue = true;
            else
                event.returnValue = false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="#">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h5 class="smaller">
                    Manage Campaign <span class="divider"></span>
                </h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
         
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" ToolTip="Search" OnClick="BtnShowSearchPanel_Click" />
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <!--/page-header-->
        <div class="row-fluid">
            <!-- -->
            <!-- PAGE CONTENT BEGINS HERE -->
            <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                <contenttemplate>
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
                </contenttemplate>
            </asp:UpdatePanel>
            <div id="DivSearch" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label2" runat="server" Text="Search Campaign Detail"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <contenttemplate>
                                   
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3" CssClass="red">Campaign</asp:Label>
                                                               
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               
                                                                <asp:DropDownList runat="server" ID="ddlCampaign" Width="215px" data-placeholder="Select Campaign Type"
                                                                    CssClass="chzn-select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSearch"
                                    Text="Search" ToolTip="Search" OnClick="btnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" />
                                <asp:Label runat="server" ID="lblCampaignID" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <div class="span10" style="text-align: left;">
                            <h5 class="modal-title">
                                Campaign Detail
                                <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
                            </h5>
                        </div>
                        <div class="span2">
                            <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnRefreshCon"
                                runat="server" onserverclick="btnRefreshCon_ServerClick" data-rel="tooltip" data-placement="top"
                                title="Refresh">
                                <i class="icon-refresh"></i>
                            </button>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <div runat="server" id="divResultContact">
                                    <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label29">Campaign Type</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblCampaignType_Result" Text="SMS" CssClass="blue" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="LabelCampName">Campaign Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblCampaignName_Result" Text="Test" CssClass="blue" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label45">Campaign Status</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblCampaignStatus_Result" Text="Test" CssClass="blue" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Lbl43">Target Audience</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label ID="lblTargetAudience_Result" runat="server" class="blue">ABC</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label30">Campaign Sponsor</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label ID="lblCampSponsor_Result" runat="server" class="blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label46">Sponsor Description</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label ID="lblCampSponsoDesc_Result" runat="server" class="blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label31">Expected Close Date</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label ID="lblExpectedCloseDate_Result" runat="server" class="blue">12 Dec. 2015</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label47">Total contacts in campaign</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label ID="lblTotalAssignedCampaignContacts_Result" runat="server" class="blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label4">Total contacts Assign</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label ID="lblTotalAssignedContactsUser_Result" runat="server" class="blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label1">Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:TextBox ID="txtstudentnamesearch" runat="server" Width="205px" placeholder="Search by Name"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label5">Handphone</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:TextBox ID="txthandphonesearch" runat="server" placeholder="Search by Handphone 1"
                                                                Width="205px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="Label6">Institution Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                             <asp:TextBox ID="txtInstitutionName" runat="server" placeholder="Search by Institution Name"
                                                                Width="205px"></asp:TextBox>       
                                                                                                               
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style=" text-align: center; " >
                                                            <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSearchByNameHandphone"
                                                                         Text="Search" ToolTip="Search by Name or Handphone or Institution" OnClick="btnSearchByNameHandphone_Click" />                                     
                                            </td>
                                        </tr>
                                       
                                    </table>
                                    <div class="well well-small">
                                        <asp:UpdatePanel ID="pnlSave2" runat="server">
                                            <contenttemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblActualRecordCount" runat="server" CssClass="badge badge-inverse"></asp:Label>
                                                            <asp:Label ID="lblPageNumber" runat="server" Visible="false"></asp:Label>
                                                            <button id="btnStud_NextRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                                data-rel="tooltip" data-placement="right" title="Find Next Record" onserverclick="btnStud_NextRecord_ServerClick">
                                                                <i class="icon-share-alt"></i>
                                                            </button>
                                                            <button id="btnStud_PrevRecord" runat="server" class="btn btn-small btn-inverse radius-4"
                                                                data-rel="tooltip" data-placement="right" title="Find Prev Record" onserverclick="btnStud_PrevRecord_ServerClick">
                                                                <i class="icon-reply"></i>
                                                            </button>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblTotalContacts2" runat="server" CssClass="badge badge-inverse">Contacts Total No of Records: </asp:Label>
                                                            &nbsp;
                                                            <asp:Label ID="lblTotalContacts" runat="server" Visible="false" CssClass="badge badge-inverse"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </contenttemplate>
                                            <triggers>
                                                <asp:PostBackTrigger ControlID="btnStud_NextRecord" />
                                                <asp:PostBackTrigger ControlID="btnStud_PrevRecord" />
                                            </triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="row-fluid">
                                    <asp:UpdatePanel ID="pnltimer" runat="server" UpdateMode="Conditional">
                                            <contenttemplate>
                                            <asp:Timer runat="server" id="Timer1" Interval="30000" ontick="Timer1_Tick"></asp:Timer>
                                        <asp:DataList ID="dlStudContact" runat="server" Width="100%" CssClass="table table-striped table-bordered"
                                            OnItemDataBound="dlStudContact_ItemDataBound" OnItemCommand="dlStudContact_ItemCommand">
                                            <HeaderTemplate>
                                                <b>Student Name </b></th>
                                                <th style="text-align: center" width="15%">
                                                    Mobile No
                                                </th>
                                                <th style="text-align: center" width="10%">
                                                    Email Id
                                                </th>
                                                <th style="text-align: center" width="15%">
                                                    Institution
                                                </th>
                                                <th style="text-align: left" width="15%">
                                                    Last Interacted Desc
                                                </th>
                                                <th style="text-align: left" width="10%">
                                                    Contact Status
                                                </th>
                                                <th style="text-align: center" width="10%">
                                                    Action
                                                </th>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%--<tr class="<%#setClass(Convert.ToInt32(Eval("CallStatus")))%>">
                                                <td>--%>
                                                <asp:Label ID="lblConId" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Id")%>'
                                                    runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                <asp:Label ID="lblConCenterFlag" Text='<%#DataBinder.Eval(Container.DataItem, "ConCenter_Flag")%>'
                                                    runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                <asp:Label ID="lblRowNum" Text='<%#DataBinder.Eval(Container.DataItem, "RowNum")%>'
                                                    runat="server" CssClass="badge badge-inverse" Visible="false"></asp:Label>
                                                <asp:Label ID="lblStudName" Text='<%#DataBinder.Eval(Container.DataItem, "StudName")%>'
                                                    runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblMobileNo" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone1")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblEmailid" Text='<%#DataBinder.Eval(Container.DataItem, "Emailid")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblInstitutionName" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Name")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblLastInteractedDesc" Text='<%#DataBinder.Eval(Container.DataItem, "LastInteractionDesc")%>'
                                                        runat="server"></asp:Label>
                                                    <asp:Image ID="imgCallStatus24hour" runat="server" Width="20px" Height="20px" ImageUrl='~/Images/Called24hour.png'
                                                        Visible='<%# Convert.ToInt32( Eval("CallStatus")) == 1 ? true:false  %>' ToolTip="Recently Called" />
                                                    <asp:Image ID="imgCallStatus24to48hour" runat="server" Width="25px" Height="25px"
                                                        ImageUrl='~/Images/Called24to48hour.png' Visible='<%# Convert.ToInt32( Eval("CallStatus")) == 2 ? true:false  %>'
                                                        ToolTip="Called Before 24 hour's" />
                                                    <asp:Image ID="imgCallNot" runat="server" Width="20px" Height="20px" ImageUrl='~/Images/NotCall.png'
                                                        Visible='<%# Convert.ToInt32( Eval("CallStatus")) == 0 ? true:false  %>' ToolTip="Pending To Call" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblConatctStatus" Text='<%#DataBinder.Eval(Container.DataItem, "ContactStatus")%>'
                                                        runat="server" ></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblCampaignID" Text='<%#DataBinder.Eval(Container.DataItem, "Campaign_ID")%>'
                                                        runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblLead_Code" Text='<%#DataBinder.Eval(Container.DataItem, "Lead_Code")%>'
                                                        runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblOpp_Code" Text='<%#DataBinder.Eval(Container.DataItem, "Opp_Code")%>'
                                                        runat="server" Visible="false"></asp:Label>
                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Record_No","Campaign_Followup.aspx?&RecNo={0}") %>'
                                                        id="btnfollowup" runat="server" target="_blank" class="btn btn-minier btn-yellow icon-comments tooltip-info"
                                                        data-rel="tooltip" data-placement="top" title="Follow-up" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"AccountFlag") == 1 ? false : true %>'></a>
                                                    <%--<a href='<%#DataBinder.Eval(Container.DataItem,"Con_Id","Convert_Contact_To_Lead.aspx?&Con_id={0}") %>'
                                                                        id="btnConvertToLead" runat="server" target="_blank" class="btn btn-minier btn-pink  icon-exchange tooltip-success"
                                                                        data-rel="tooltip" data-placement="top" title="Assign To Lead"></a>--%>
                                                    <a id="btnConvertToLead" runat="server" target="_blank" class="btn btn-minier btn-pink  icon-exchange tooltip-success"
                                                        data-rel="tooltip" data-placement="top" title="Assign To Lead" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"LeadFlag") == 1 ? true : false %>'></a>
                                                    <a id="btnConvertToOpportunity" runat="server" target="_blank" class="btn btn-minier btn-primary icon-check tooltip-info"  
                                                        data-rel="tooltip" data-placement="top" title="Assign To Opportunity" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"OppFlag") == 1 ? true : false %>'></a>
                                                    <asp:LinkButton ID="lnkformsubmit" runat="server" class="btn btn-minier btn-success icon-download tooltip-success"
                                                                data-rel="tooltip" data-placement="top" title="Enroll" CommandName='Enroll'
                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Opp_Code")%>'
                                                                ToolTip="Enroll" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"EnrollFlag") == 1 ? true : false %>'></asp:LinkButton>
                                                    <a id="btnorder" runat="server" target="_blank" class="btn btn-minier btn-purple icon-asterisk tooltip-info"
                                                                    data-rel="tooltip" data-placement="top" title="Order" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"OrderFlag") == 1 ? true : false %>'></a>                                                    
                                                </td>
                                                <%-- </tr>--%>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        </contenttemplate>
                                        </asp:UpdatePanel>
                                        <%-- <asp:GridView ID="GridView1" runat="server"  OnRowDataBound = "OnRowDataBound" AutoGenerateColumns="false">
                                           <Columns>
                                                <asp:BoundField DataField="CallStatus" HeaderText="" Visible="true"/>
                                                <asp:BoundField DataField="StudName" HeaderText="Student Name"/>
                                                <asp:BoundField DataField="Handphone1" HeaderText="Mobile No"/>
                                            </Columns>
                                        </asp:GridView>--%>
                                    </div>
                                    <%--</div>--%>
                                    <%--<div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                                                            <!--Button Area -->
                                                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnContactsSave"
                                                                runat="server" Text="Save" onclick="btnContactsSave_Click" />
                                                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnContactsBack"
                                                                runat="server" Text="Back" OnClick="btnContactsBack_Click" Visible="false" />
                                                        </div>--%>
                                    <%--</div>
                                                        </div>--%>
                                </div>
                            </div>
                        </div>
                        <%--<div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnCloseAssign"
                                Visible="true" runat="server" Text="Close" OnClick="btnCloseAssign_Click" Visible="false" />
                        </div>--%>
                    </div>
                </div>
                <%--Add Design--%>
            </div>
        </div>
        <!--/row-->
    </div>

    <div class="modal fade" id="Div1" tabindex="-1" role="basic" aria-hidden="true" data-keyboard="false"
                        data-backdrop="static" data-keyboard="false" data-attention-animation="false">
                        <div class="modal-dialog modal-small blue">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <div class="scroller" data-always-visible="1" data-rail-visible1="1">
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <tr>
                                                <td width="10%">
                                                    Submission Date
                                                    <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <input readonly="readonly" class="span8 date-picker" id="txtappsubmitdate" runat="server"
                                                                                type="text" data-date-format="dd M yyyy" style="width:215px"/>                                                    
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator79" ControlToValidate="txtappsubmitdate"
                                                        Text="#" runat="server" ValidationGroup="Val20" SetFocusOnError="True" ErrorMessage="Enter Application Submit Date" />                                                    
                                                    
                                                    <asp:Label ID="lbldateerrorsubmit" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    <asp:Label ID="lbloppurid" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnyes"
                                        validationgroup="Val20" runat="server" onserverclick="btnyes_ServerClick">
                                        Yes</button>
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnno"
                                        runat="server" onserverclick="btnno_ServerClick">
                                        No</button>
                                    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Val20" ShowSummary="False" />
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
</asp:Content>
