<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ECS_Acknowledgement.aspx.cs" Inherits="ECS_Acknowledgement" %>

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
                            <asp:Label ID="lblpagetitle1" runat="server">ECS Acknowledgement</asp:Label>&nbsp;</b>
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
                    <i class="icon-dropup"></i>Back to ECS Search</button>
              
               
                                       
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
                                                                    ECS Acknowledgement Status
                                                                </td>
                                                                <td width="20%">
                                                                    <asp:DropDownList ID="ddlAcknowledgementstatus" runat="server" data-placeholder="Select"
                                                                        CssClass="chzn-select" Width="215px" AutoPostBack="true">
                                                                        <asp:ListItem Value="All" Selected="True">All</asp:ListItem>
                                                                        <asp:ListItem Value="0">ECS Pending</asp:ListItem>
                                                                        <asp:ListItem Value="1">ECS Completed</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="10%">
                                                                    Customer Number / SB Entry Code
                                                                </td>
                                                                <td width="20%" colspan="3">
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
                                                        <i class="icon-briefcase"></i>ECS Search Results</h4>
                                                </div>
                                                <div class="widget-body">
                                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table class="table table-striped table-bordered table-hover Table3">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            Division
                                                                        </th>
                                                                        <th>
                                                                            Center
                                                                        </th>
                                                                        <th>
                                                                            Student Name
                                                                        </th>
                                                                        <th>
                                                                            SBEntrycode
                                                                        </th>
                                                                        <th>
                                                                            Academic Year
                                                                        </th>
                                                                        <th>
                                                                            Product
                                                                        </th>
                                                                        <th>
                                                                            ECS Date
                                                                        </th>
                                                                        <th>
                                                                            ECS Amount
                                                                        </th>
                                                                        <th>
                                                                            Action
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr class="odd gradeX">
                                                                <td>
                                                                    <span id="iconDL_Acknowledged" runat="server" visible='<%#(int)DataBinder.Eval(Container.DataItem,"IsAcknowledge") == 0 ? false : true %>'
                                                                        class="btn btn-danger btn-mini tooltip-error" data-rel="tooltip" data-placement="right"
                                                                        title="ECS Acknowledged"><i class="icon-lock"></i></span>
                                                                    <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                        runat="server"></asp:Label>
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
                                                                <td style="text-align: center">
                                                                    <asp:LinkButton ID="lnkECSView" runat="server" CommandName="ECSView" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ECS_ID")%>'
                                                                        class="btn btn-minier btn-success icon-eye-open tooltip-success" data-rel="tooltip"
                                                                        data-placement="top" title="View ECS"></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkIsAcknowledge" runat="server" CommandName="IsAcknowledge"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ECS_ID")%>' class="btn btn-minier btn-danger icon-key"
                                                                        data-rel="tooltip" data-placement="top" title="Acknowledge" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"IsAcknowledge") == 0 ? true : false %>'></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkIsDeclined" runat="server" CommandName="IsDeclined"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ECS_ID")%>' class="btn btn-minier btn-info icon-ban-circle"
                                                                        data-rel="tooltip" data-placement="top" title="Decline" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"IsAcknowledge") == 0 ? true : false %>'></asp:LinkButton>
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
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                    <asp:PostBackTrigger ControlID="Repeater1" />
                </Triggers>
            </asp:UpdatePanel>
            <div id="DivECSDetail" runat="server">
                <div class="row-fluid">
                    <div class="widget-box">
                        <div class="widget-header widget-header-small header-color-dark">
                            <h5 class="modal-title">
                                <asp:Label ID="Label2" runat="server" Text="Student Detail"></asp:Label>
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-body-inner">
                                <div class="widget-main">
                                    <table class="table table-striped table-bordered table-advance table-hover">
                                        <tr>
                                            <td width="10%">
                                                Admission Date
                                            </td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtadmndate" Enabled="false" runat="server" Width="205px"></asp:TextBox>
                                            </td>
                                            <td width="10%">
                                                Student Name
                                            </td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtLstudentname" Enabled="false" runat="server" Width="205px"></asp:TextBox>
                                            </td>
                                            <td width="10%" rowspan="3" runat="server" id="td05" visible="false">
                                                <br />
                                                <br />
                                                Customer Photo
                                            </td>
                                            <td width="20%" rowspan="3" runat="server" id="td06" visible="false">
                                                <asp:Image ID="imgstudentphoto" runat="server" Width="150px" Height="100px" />
                                                <asp:TextBox ID="txtgender" Enabled="false" runat="server" Width="70%"></asp:TextBox>
                                            </td>
                                            <td width="10%" rowspan="6" align="justify" valign="middle">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                Product / Item Group
                                            </td>
                                            <td width="20%" rowspan="6">
                                                <asp:ListBox ID="lbsubjectgroup" Enabled="false" runat="server" Width="100%" Height="100%">
                                                </asp:ListBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                App. Form No
                                            </td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtLappno" Enabled="false" runat="server" Width="205px"></asp:TextBox>
                                            </td>
                                            <td width="10%">
                                                Opportunity Id
                                            </td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtopportunityid" Enabled="false" runat="server" Width="205px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                Account ID
                                            </td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtaccountid" Enabled="false" runat="server" Width="205px"></asp:TextBox>
                                            </td>
                                            <td width="10%">
                                                SBEntrycode
                                            </td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtcursbcode" Enabled="false" runat="server" Width="205px"></asp:TextBox>
                                                <asp:TextBox ID="txtSPID" Visible="false" runat="server" Width="205px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                Company
                                            </td>
                                            <td width="20%">
                                                <asp:DropDownList ID="ddllcompany" Enabled="false" runat="server" data-placeholder="Select"
                                                    Width="215px" CssClass="chzn-select">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="10%">
                                                Division
                                            </td>
                                            <td width="20%">
                                                <asp:DropDownList ID="ddlldivision" Enabled="false" runat="server" data-placeholder="Select"
                                                    Width="215px" CssClass="chzn-select">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                Center
                                            </td>
                                            <td width="20%">
                                                <asp:DropDownList ID="ddllcenter" Enabled="false" runat="server" data-placeholder="Select"
                                                    Width="215px" CssClass="chzn-select">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="10%">
                                                Academic Year
                                            </td>
                                            <td width="20%">
                                                <asp:DropDownList ID="ddllacadyear" Enabled="false" runat="server" data-placeholder="Select"
                                                    Width="215px" CssClass="chzn-select">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                Stream
                                            </td>
                                            <td width="20%">
                                                <asp:DropDownList ID="ddllstream" Enabled="false" runat="server" data-placeholder="Select"
                                                    Width="215px" CssClass="chzn-select">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="10%">
                                                Pay Plan
                                            </td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtpayplan" Enabled="false" runat="server" Width="205px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="widget-box">
                        <div class="widget-header widget-header-small header-color-dark">
                            <h5 class="modal-title">
                                <asp:Label ID="Label1" runat="server" Text="ECS Detail"></asp:Label>
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-body-inner">
                                <div class="widget-main">
                                    <table class="table table-striped table-bordered table-advance table-hover">
                                        <tr>
                                            <td width="10%">
                                                UMRN
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblUMRN" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                ECS Date
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblECSDate" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                Sponsor Bank Code
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblSponsorBankCode" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                Utility Code
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblUtilityCode" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                Company Name
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblCompanyName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                To Debit
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblToDebit" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                Bank A/c No
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblBankAcNo" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                Period
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblPeriod" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                MICR No
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblMICRNo" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                <asp:Label runat="server" ID="Label6">With Bank</asp:Label>
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblWithBank" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                IFSC Code
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblIFSCCode" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                Amount
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblAmount" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                Frequency
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblFrequency" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                Debit Type
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblDebitType" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                <asp:Label runat="server" ID="Label11">Reference1</asp:Label>
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblRef1" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                <asp:Label runat="server" ID="Label12">Phone no.</asp:Label>
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblPhoneNo" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                <asp:Label runat="server" ID="Label13">Reference2</asp:Label>
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblRef2" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td width="10%">
                                                <asp:Label runat="server" ID="Label14">EmailId</asp:Label>
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lblEmailID" runat="server" Text="" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="widget-main alert-block alert-info" style="text-align: center;">
                                    <!--Button Area -->
                                    <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnClose"
                                        Text="Close" ToolTip="Close" OnClick="btnClose_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END PAGE CONTENT FOR SEARCH-->
        </div>
    </div>
    <div class="modal fade" id="DivECSAcknowledge" style="left: 50% !important; top: 30% !important;
        display: none;" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="upnlECSAcknowledge" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                ECS Acknowledgement
                            </h4>
                        </div>
                        <div class="modal-body">
                            <!--Controls Area -->
                            <table cellpadding="2" class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <td class="span4" style="text-align: left">
                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 100%; font-weight: bold">
                                                    Are you sure...?
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <center />
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblPKey" runat="server" Text="" Font-Bold="true" Visible="false"></asp:Label>
                            <!--Button Area -->
                            <button type="button" class="btn btn-app  btn-success btn-mini radius-4" runat="server"
                                id="btnAckYes" onserverclick="btnAckYes_Click">
                                Yes
                            </button>
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                                ID="btnAckNo" ToolTip="No" runat="server" Text="No" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnAckYes" />
                        <asp:PostBackTrigger ControlID="btnAckNo" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <div class="modal fade" id="DivECSDecline" style="left: 50% !important; top: 30% !important;
        display: none;" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="upnlECSDecline" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                ECS Decline
                            </h4>
                        </div>
                        <div class="modal-body">
                            <!--Controls Area -->
                            <table cellpadding="2" class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <td class="span4" style="text-align: left">
                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 100%; font-weight: bold">
                                                    You are about to decline this ECS request. Are you sure...?
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="span4" style="text-align: left">
                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 100%; font-weight: bold">
                                                    <asp:TextBox ID="txtdeclinereason" runat="server" placeholder="Reason for Declining" TextMode="MultiLine" Width="75%" MaxLength="200"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <center />
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="Label3" runat="server" Text="" Font-Bold="true" Visible="false"></asp:Label>
                            <!--Button Area -->
                            <button type="button" class="btn btn-app  btn-success btn-mini radius-4" runat="server"
                                id="btndecYes" onserverclick="btndecYes_Click">
                                Yes
                            </button>
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                                ID="btndecno" ToolTip="No" runat="server" Text="No" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btndecYes" />
                        <asp:PostBackTrigger ControlID="btndecno" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <script type="text/javascript">
        function openModalECSAcknowledge() {
            $('#DivECSAcknowledge').modal({
                backdrop: 'static'
            })
            $('#DivECSAcknowledge').modal('show');
        };
    </script>
     <script type="text/javascript">
         function openModalDecline() {
             $('#DivECSDecline').modal({
                 backdrop: 'static'
             })
             $('#DivECSDecline').modal('show');
         };
    </script>
    <!-- END CONTENT -->
</asp:Content>
