<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="LoanDocumentDispatch.aspx.cs" Inherits="LoanDocumentDispatch" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
// <![CDATA[

        

// ]]>
        function openModalPrint() {
            $('#DivPrint').modal({
                backdrop: 'static'
            })

            $('#DivPrint').modal('show');
        };
       

    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
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
            <div id="nav-search">
                <button type="button" class="btn btn-app btn-primary btn-mini radius-4" data-toggle="dropdown" data-hover="dropdown"
                    data-delay="1000" data-close-others="true">
                    <span>Actions </span>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li><a id="btnmakeLDMS" runat="server" onserverclick="btnmakeLDMS_ServerClick">Make Dispatch
                        Loan</a> </li>
                    <li><a id="btnSearchLDMS" runat="server" onserverclick="btnSearchLDMS_ServerClick">Search Dispatch
                        Loan</a> </li>
                </ul>
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
            <div class="alert alert-danger" id="divmessage" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblmessage" runat="server"></asp:Label></strong>
            </div>
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">

                                    <div id="tab_1_3" class="tab-pane active">
                                        <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                            <div class="span12">
                                                <div class="table-responsive">
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <tr>
                                                            <td width="10%">
                                                                Company <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlcompany" runat="server" ValidationGroup ="Validation10" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlcompany_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlcompany"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Company"
                                                                InitialValue="Select" />
                                                            </td>
                                                            <td width="10%">
                                                                Division <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddldivision" ValidationGroup ="Validation10" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddldivision_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddldivision"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Divison"
                                                                InitialValue="Select" />
                                                            </td>
                                                            <td width="10%">
                                                                Zone / Area <asp:Label ID="label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlzone" ValidationGroup ="Validation10" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlzone_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlzone"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Zone / Area"
                                                                InitialValue="Select" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Center <asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlcenter" ValidationGroup ="Validation10" runat="server" data-placeholder="Select" CssClass="chzn-select">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlcenter"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                InitialValue="Select" />
                                                            </td>                                                            
                                                            <td width="10%">
                                                                Slip No.
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtslipnosearch" runat="server" ></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                               <%-- Payee <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                            </td>
                                                            <td width="20%">
                                                                <%--<asp:DropDownList ID="ddlpayee" ValidationGroup ="Validation10" runat="server" data-placeholder="Select" CssClass="chzn-select">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlpayee"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                InitialValue="Select" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                From Date
                                                            </td>
                                                            <td width="20%">
                                                                    <input readonly="readonly" class="span7 date-picker" id="txtfromdate" runat="server"
                                                                            type="text" data-date-format="dd M yyyy" />
                                                                <%--<asp:TextBox ID="txtfromdate" runat="server" Width="90%"></asp:TextBox>
                                                                <CC1:CalendarExtender ID="Calextender" runat="server" Format="dd-MM-yyyy" TargetControlID="txtfromdate"
                                                                    DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                </CC1:CalendarExtender>--%>
                                                            </td>
                                                            <td width="10%">
                                                                To Date
                                                            </td>
                                                            <td width="20%">
                                                                <input readonly="readonly" class="span7 date-picker" id="txttodate" runat="server"
                                                                            type="text" data-date-format="dd M yyyy" />
                                                                <%--<asp:TextBox ID="txttodate" runat="server" Width="90%"></asp:TextBox>
                                                                <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txttodate"
                                                                    DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                </CC1:CalendarExtender>--%>
                                                            </td>
                                                            <td width="10%">
                                                                
                                                            </td>
                                                            <td width="20%">
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" validationgroup ="Validation10" runat="server" onserverclick ="btnsearch_ServerClick">
                                                        Search
                                                    </button>
                                                    <button class="btn btn-app btn-grey btn-mini radius-4" id="btnClear"  runat="server" onserverclick ="btnClear_ServerClick">
                                                        Clear
                                                    </button>
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                    ValidationGroup ="Validation10" ShowSummary="False" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-fluid" id="divsearchresults" runat="server">
                                            <div class="span12">
                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            <i class="fa fa-chain "></i>Dispatch Slip Search Results
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound ="Repeater1_ItemDataBound" OnItemCommand ="Repeater1_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table class="table table-striped table-bordered table-hover Table2">
                                                                    <thead>
                                                                        <tr>
                                                                            <th align="center" style="text-align: center">
                                                                                Division
                                                                            </th>
                                                                            <th align="center" style="text-align: center">
                                                                                Center
                                                                            </th>
                                                                            <th align="center" style="text-align: center">
                                                                                Slip No.
                                                                            </th>
                                                                            <th align="center" style="text-align: center">
                                                                                Slip Date
                                                                            </th>
                                                                            <th align="center" style="text-align: center">
                                                                                Count
                                                                            </th>
                                                                            <th align="center" style="text-align: center">
                                                                                Action
                                                                            </th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr class="odd gradeX">
                                                                    <td>
                                                                        <asp:Label ID="lbldivision" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "slipno")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "SlipDate")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    
                                                                    <td>
                                                                        <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "Loan Count")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    
                                                                    <td>                                                                        
                                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"Slipno","LoanDispatch_View.aspx?&Slip_No={0}") %>'
                                                                            id="btndisplay" runat="server" target="_blank" class="btn btn-minier btn-primary icon-eye-open tooltip-info" data-rel="tooltip" data-placement="top" title="View">

                                                                        </a> 
                                                                        <asp:LinkButton ID="lnkPrint" runat="server" class="btn btn-minier btn-warning icon-print tooltip-warning" data-rel="tooltip" data-placement="top" title="Print" 
                                                                            CommandName="Print" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"slipno")%>'
                                                                            Visible="true"></asp:LinkButton>
                                                                        
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </tbody> </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        </div> 
                                                    </div>
                                                </div>
                                                <!-- END EXAMPLE TABLE PORTLET-->
                                            </div>
                                        </div>                                        
                                    </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="UpnladdCMS" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="div1" runat="server">
                        <div class="span12">

                                    <div id="Div2" class="tab-pane active">
                                        <div class="row-fluid" id="Div3" runat="server">
                                            <div class="span12">
                                                <div class="table-responsive">
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <tr>
                                                            <td width="10%">
                                                                Dispatch Slip No.
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtdepositslipno" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Dispatch Date
                                                                <asp:Label ID="label18" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">   
                                                                <%--<input readonly="readonly" class="span7 date-picker" id="txtdispatchDate1" runat="server"
                                                                            type="text" data-date-format="dd M yyyy"/> --%>                                                            
                                                                <asp:TextBox ID="txtdispatchDate" runat="server" ValidationGroup="Val1" Width ="60%" Enabled="false"></asp:TextBox>
                                                                <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdispatchDate"
                                                                    DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                </CC1:CalendarExtender>
                                                                <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="txtdispatchDate"
                                                                    ValidationGroup="Val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtdispatchDate"
                                                                    ValidationGroup="Val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date"
                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>                                                                
                                                                <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ControlToValidate="txtdispatchDate"
                                                                    Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Dispatch Date"
                                                                    InitialValue="Select" />

                                                            </td>
                                                            <td width="10%">
                                                                
                                                            </td>
                                                            <td width="20%">
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Division <asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlDivisionAdd" ValidationGroup ="Val1" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlDivisionAdd_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlDivisionAdd" CssClass="red"
                                                                Text="Select Divison" runat="server" ValidationGroup ="Val1" SetFocusOnError="True" ErrorMessage="Select Divison"
                                                                InitialValue="Select" />
                                                            </td>
                                                            <td width="10%">
                                                                Zone / Area <asp:Label ID="label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlZoneAdd" ValidationGroup ="Val1" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlZoneAdd_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlZoneAdd" CssClass="red"
                                                                Text="Select Zone" runat="server" ValidationGroup ="Val1" SetFocusOnError="True" ErrorMessage="Select Zone / Area"
                                                                InitialValue="Select" />
                                                            </td>
                                                            <td width="10%">
                                                                 Center
                                                                <asp:Label ID="label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlcenterSlip" ValidationGroup ="Val1" runat="server" data-placeholder="Select" CssClass="chzn-select" 
                                                                        AutoPostBack="true" OnSelectedIndexChanged ="ddlcenterSlip_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="ddlcenterSlip" CssClass="red"
                                                                Text="Select Center" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                InitialValue="Select" />
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-fluid" id="div4" runat="server">
                                            <div class="span12">
                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            <i class="fa fa-money"></i>Pending Loan Document for Dispatch
                                                        </h5>
                                                        <div class="widget-toolbar">
                                                            Total no. of records found:
                                                            <asp:Label ID="lblrecordcount" runat="server" Text="0"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                        <asp:DataList ID="dlreceipts" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                            <HeaderTemplate>
                                                                <b style="text-align: center">
                                                                    <center>
                                                                        Select</center>
                                                                </b></th>
                                                                    <th>
                                                                        Division
                                                                    </th>
                                                                    <th>
                                                                        Location / Center
                                                                    </th>
                                                                    <th>
                                                                        App. Form No.
                                                                    </th>
                                                                    <th>
                                                                        Customer Name
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
                                                                        OutStanding
                                                                    </th>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="checkpoint" runat="server" AutoPostBack="true" />
                                                                <span class="lbl"> </span>
                                                                </td>
                                                                <td>
                                                                <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcenter" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Name")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>                                                            
                                                            <td>
                                                                <asp:Label ID="Label38" Text='<%#DataBinder.Eval(Container.DataItem, "App_no")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcustomername" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSbEntryCode" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblacadyear" Text='<%#DataBinder.Eval(Container.DataItem, "acadyear")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblproduct" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblos" Text='<%#DataBinder.Eval(Container.DataItem, "outstanding")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <div class="alert alert-danger" id="divmakecmserror" runat="server">
                                                            <strong>
                                                                <asp:Label ID="lblmakecmserror" runat="server"></asp:Label></strong>
                                                        </div>
                                                       
                                                        </div> 

                                                    </div>
                                                </div>
                                                <div class="table-responsive">
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <tr>
                                                            <td width="10%">
                                                                No. of Records
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtnoofinstr" Enabled="false" runat="server" Width="40%" CssClass="popovers "
                                                                    data-trigger="hover" data-placement="top" data-content="Dispatch Slip No." data-original-title="Dispatch Slip No."></asp:TextBox>
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
                                                    </table>
                                                </div>
                                                <asp:Label ID="lblSumInstValue" runat="server"></asp:Label>
                                                <asp:Label ID="lblSum" runat="server"></asp:Label>
                                                <!-- END EXAMPLE TABLE PORTLET-->
                                                <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-success btn-mini radius-4" id="btnsave" runat="server" validationgroup="Val1" onserverclick ="btnsave_ServerClick">
                                                    Save
                                                </button>
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnCloseAdd" runat="server" onserverclick ="btnCloseAdd_ServerClick">
                                                    Close
                                                </button>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ValidationGroup="Val1" ShowSummary="False" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsave" />
                    <asp:PostBackTrigger ControlID ="btnCloseAdd" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
            <!--START PAGE CONTENT FOR VIEW Dispatch-->
            <asp:UpdatePanel ID="upnlviewcms" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="div5" runat="server">
                        <div class="span12">

                                    <div id="Div6" class="tab-pane active">
                                        <div class="row-fluid" id="Div7" runat="server">
                                            <div class="span12">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            Dispatch Details
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body" style="height: 500px; overflow: Auto">
                                                        <div class="widget-main">
                                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Dispatch Slip No.
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtviewdepositslip" Enabled="false" runat="server" Width="95%" CssClass="popovers "
                                                                            data-trigger="hover" data-placement="top" data-content="Dispatch Slip No."></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Dispatch Date
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtviewdispatch" Enabled="false" runat="server" Width="95%" CssClass="popovers "
                                                                            data-trigger="hover" data-placement="top" data-content="Dispatch Date"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Center
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtviewcenter" Enabled="false" runat="server" Width="95%" CssClass="popovers "
                                                                            data-trigger="hover" data-placement="top" data-content="Dispatch Date"></asp:TextBox>
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
                                                                    <asp:Label ID="lblmode" Text='<%#DataBinder.Eval(Container.DataItem, "Center_Name")%>'
                                                                        runat="server"></asp:Label></td>
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
                                                                    <td>
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

            <asp:UpdatePanel ID="UpnlprintCentre" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- BEGIN RECEIPT I PRINT-->
                    <div class="invoice">
                        <div id="divCentrePrint" class="invoice" runat="server" visible="false">
                        <table width="100%">
                            <thead align="center">
                                <tr>
                                    <td align="center" colspan="8">
                                        <b style="font-size: large">
                                            <asp:Label ID="lblBankname" runat="server" Text=""></asp:Label></b>
                                    </td>
                                </tr>
                            </thead>
                        </table>
                        <table width="100%">
                            <tr>
                                <td  align="left" width="40%" style="font-size: medium">
                                    Centre Name: <asp:Label ID="lblCentreName" runat="server"> </asp:Label>
                                    <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>
                                </td>    
                                <td align="left" width="40%" style="font-size: medium">
                                    &nbsp;&nbsp;&nbsp;Division : <asp:Label ID="lblDivisionName" runat="server"></asp:Label>
                                </td>
                                <td align="right" width="20%" style="font-size: medium">
                                    Date : <asp:Label ID="lblslipdate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            
                        </table>                                                                      
                        <div class="row-fluid">
                            <div class="col-xs-12">
                                <asp:DataList ID="dlLoanDisp" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                    <HeaderTemplate>
                                        <b>Sr.No</b></th>
                                        <th>
                                            Name Of the Student
                                        </th>
                                        <th>
                                            Name Of Applicant
                                        </th>
                                        <th>
                                            SB Entry Code
                                        </th>
                                        <th>
                                            Centre Name
                                        </th>
                                        <th>
                                            StreamName
                                         </th>
                                        <th>
                                            Total Fees(Amount)
                                        </th>
                                        <th>
                                            Down Payment Made(Amount)
                                      
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSrNo" Text='<%#Container.ItemIndex+1 %>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblstudentname" Text='<%#DataBinder.Eval(Container.DataItem, "NAME")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblApplicantname" Text='<%#DataBinder.Eval(Container.DataItem, "ApplicantName")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSBEntryCode" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblstudCentreName" Text='<%#DataBinder.Eval(Container.DataItem, "CentreName")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblStream" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalFee" Text='<%#DataBinder.Eval(Container.DataItem, "TotalFee")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDownPaymentAmount" Text='<%#DataBinder.Eval(Container.DataItem, "PaidFee")%>'
                                                runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:DataList>
                               
                            </div>
                        </div>
                        </div>
                        <div class="col-xs-7 invoice-block">                           
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpnlPrintStudent" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- BEGIN RECEIPT I PRINT-->
                    <div class="invoice">
                        <div id="div8" class="invoice" runat="server" visible="false">
                        <table width="100%">
                            <thead align="center">
                                <tr>
                                    <td align="center" colspan="8">
                                        <b style="font-size: large">
                                            
                                    </td>
                                </tr>
                            </thead>
                        </table>
                        <table width="100%">
                            <tr>
                                <td  align="left" width="100%" style="font-size: medium">
                                    <asp:Label ID="lblSBEntryCode" Text='' runat="server"></asp:Label>
                                    <asp:Label ID="lblDivision" Text='' runat="server"></asp:Label>
                                    <asp:Label ID="lblStudName" Text='' runat="server"></asp:Label>
                                    <asp:Label ID="lblDate" Text='' runat="server"></asp:Label>
                                    <asp:Label ID="lblStudCentreName" Text='' runat="server"></asp:Label>
                                    <asp:Label ID="lblStreamName" Text='' runat="server"></asp:Label>
                                    <asp:Label ID="lblAddress" Text='' runat="server"></asp:Label>                                    
                                    <asp:Label ID="lblTotalAmtInWord" Text='' runat="server"></asp:Label>                                    
                                </td>
                            </tr>
                            <tr>
                                <td  align="left" width="100%" style="font-size: medium">
                                      <asp:DataList ID="rptReceiptDetail" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                             <HeaderTemplate>
                                                    <b>Date</b></th>
                                                    <th>
                                                        Receipt No
                                                    </th>
                                                    <th>
                                                        Amount
                                                    </th>
                                                    <th>
                                                        Instr No
                                                    </th>
                                                    <th>
                                                        Bank/Branch
                                                    
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                                <asp:Label ID="lblReceiptDate" Text='<%#DataBinder.Eval(Container.DataItem, "Receipt_Date")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblReceiptNum" Text='<%#DataBinder.Eval(Container.DataItem, "Receipt_Num")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblReceiptAmount" Text='<%#DataBinder.Eval(Container.DataItem, "Receipt_amt")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInstNo" Text='<%#DataBinder.Eval(Container.DataItem, "Instrument_No")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBankName" Text='<%#DataBinder.Eval(Container.DataItem, "Bank_Name")%>'
                                                                    runat="server"></asp:Label>
                                                          
                                                    </ItemTemplate>
                                                 </asp:DataList>

                                     <asp:DataList ID="rptStudTotal" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                <HeaderTemplate>                                                     
                                                    <b>Field</b></th>
                                                    <th>
                                                    <th>    
                                                        Grossfees
                                                    </th>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>                                                        
                                                                <asp:Label ID="lblField" Text='<%#DataBinder.Eval(Container.DataItem, "Field")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td style="text-align: right;border-left: 1px solid rgb(205, 205, 205);">
                                                                <asp:Label ID="lblGrossFees" Text='<%#DataBinder.Eval(Container.DataItem, "Grossfees")%>'
                                                                    runat="server"></asp:Label>
                                                            
                                                       
                                                    </ItemTemplate>
                                                   
                                             </asp:DataList>
                                </td>                                    
                            </tr>                            
                        </table>                                                                      
                       
                        </div>
                        <div class="col-xs-7 invoice-block">                           
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!-- END CONTENT -->

     <div class="modal fade" id="DivPrint" style="left: 50% !important; top: 10% !important; height : 80%;
                display: none;" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                       <asp:UpdatePanel ID="upnlPrint" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                Print Document 
                            </h4>
                        </div>
                        <div class="modal-body">
                            <!--Controls Area -->
                            <table cellpadding="2" class="table table-striped table-bordered table-advance table-hover">
                                 <tr>
                                    <td class="span4" style="text-align: left" >  
                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label runat="server" Font-Bold="true"  ID="lbl1"
                                                            Text="Bank Dispatch Slip" />    
                                                    <asp:Label runat="server" Font-Bold="false"  ID="lblSlipNo"
                                                            Text="" Visible = "false" />                                                 
                                                    <asp:CheckBox ID="checkCentre" runat="server" AutoPostBack="true" />
                                                                <span class="lbl"> </span> 
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 100%;">
                                                    <asp:Label runat="server" Font-Bold="true"  ID="Label3"
                                                            Text="Student Slip" />    
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 100%;">
                                                    <asp:DataList ID="dlPrintStudent" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                            <HeaderTemplate>
                                                                <b style="text-align: center">
                                                                    <center>
                                                                        Select</center>
                                                                </b></th>                                                                    
                                                                    <th>
                                                                        Student Name
                                                                    </th>
                                                                    <th>
                                                                        SBEntrycode
                                                                    </th>                                                                    
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="checkStudent" runat="server" AutoPostBack="true" />
                                                                <span class="lbl"> </span>
                                                                </td>                                                                
                                                            <td>
                                                                <asp:Label ID="lblcustomername" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSbEntryCode" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>                                                            
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                </td>                                               
                                            </tr>
                                        </table>  
                                    </td>                                    
                                 </tr>                                
                            </table>
                           
                            <center />
                        </div>
                        <div class="modal-footer">
                            <!--Button Area -->                    
                            

                               <%-- <button type="button" class="btn btn-app  btn-success btn-mini radius-4" runat="server"
                                id="btnPrintOK" validationgroup="ValPrint" onserverclick="btnbtnPrintOK_Click">
                                Print
                            </button>--%>
                            <asp:Button class="btn btn-app  btn-warning btn-mini radius-4" ID="btnPrintOK"
                                ToolTip="Print" runat="server" Text="Print" onclick="btnbtnPrintOK_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                                ID="btnPrint_Close" ToolTip="Close" runat="server" Text="Close" />

                            <asp:Button class="btn btn-app  btn-warning btn-mini radius-4" ID="btnPrintTest" Visible="false"
                                ToolTip="PrintTest" runat="server" Text="PrintTest" onclick="btnPrintTest_Click" />
                            <asp:ValidationSummary ID="ValidationSummary20" runat="server" ShowMessageBox="True"
                                ValidationGroup="ValPrint" ShowSummary="False" />
                        </div>
                      </ContentTemplate>
                    <Triggers>                        
                        <asp:PostBackTrigger ControlID="btnPrintOK" />
                        <asp:PostBackTrigger ControlID="btnPrint_Close" />
                        <asp:PostBackTrigger ControlID="btnPrintTest" />
                    </Triggers>
                </asp:UpdatePanel>
                    </div>
                    <!-- /.modal-content -->
                </div>
            <!-- /.modal-dialog -->
          </div>

</asp:Content>
