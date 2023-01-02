<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ECS_Deposit.aspx.cs" Inherits="ECS_Deposit" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid hidden-print">
        <div id="breadcrumbs" class="position-relative">
            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
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
                <li id="li1" runat="server" visible="false"><a href="lead.aspx">
                    <asp:Label ID="Label13" runat="server"></asp:Label></a></li>
                <li id="li2" runat="server" visible="false"><i class="fa fa-angle-right"></i><a href="#">
                    <asp:Label ID="Label14" runat="server"></asp:Label></a></li>    
            </ul>
            <div id="nav-search">
                <button type="button" class="btn btn-app btn-primary btn-mini radius-4" data-toggle="dropdown" data-hover="dropdown"
                    data-delay="1000" data-close-others="true" id="btnmakeCMSButton" runat="server">
                    <span>Actions </span>
                </button>
                <ul class="dropdown-menu pull-right" role="menu">
                    <li><a id="btnmakeCMS" runat="server" onserverclick="btnmakeCMS_ServerClick">Make ECS Dispatch Slip</a> </li>
                     <li><a id="btnBackECSSearch" runat="server" onserverclick="btnBackECSSearch_ServerClick" visible="false">Back to ECS Search</a> </li>
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
                <button class="close" data-close="alert">
                </button>
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <button class="close" data-close="alert">
                </button>
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong></div>
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">

                                    <div id="tab_1_3" class="tab-pane active">
                                        <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                         <div class="widget-box">
                                                    <div class="widget-header widget-header-small header-color-dark">
                                                        <h5>
                                                            <i class="fa fa-chain "></i>ECS Dispatch Slip Search Criteria
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                        <div class="row-fluid" >
                                            <div class="span12">
                                                <div class="table-responsive">
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <tr>
                                                            
                                                            <td width="10%">
                                                                Division <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddldivision" ValidationGroup ="Validation10" runat="server" data-placeholder="Select" CssClass="chzn-select">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddldivision"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Divison"
                                                                InitialValue="Select" />
                                                            </td>
                                                            <%--<td width="10%">
                                                                Zone / Area <asp:Label ID="label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlzone" ValidationGroup ="Validation10" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlzone_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlzone"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Zone / Area"
                                                                InitialValue="Select" />
                                                            </td>--%>
                                                            <%--<td width="10%">
                                                                Center <asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlcenter" ValidationGroup ="Validation10" runat="server" data-placeholder="Select" CssClass="chzn-select">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlcenter"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                InitialValue="Select" />
                                                            </td>--%>
                                                            <td colspan="4"></td>
                                                        </tr>
                                                        <tr>    
                                                            
                                                            <td width="10%">
                                                                Slip No.
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtslipnosearch" runat="server" ></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                From Date
                                                            </td>
                                                            <td width="20%">
                                                                <input readonly="readonly" class="span7 date-picker" id="txtfromdate" runat="server"
                                                                            type="text" data-date-format="dd M yyyy"/> 
                                                                <%--<asp:TextBox ID="txtfromdate" runat="server"></asp:TextBox>
                                                                <CC1:CalendarExtender ID="Calextender" runat="server" Format="dd-MM-yyyy" TargetControlID="txtfromdate"
                                                                    DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                </CC1:CalendarExtender>--%>
                                                            </td>
                                                            <td width="10%">
                                                                To Date
                                                            </td>
                                                            <td width="20%">
                                                                <input readonly="readonly" class="span7 date-picker" id="txttodate" runat="server"
                                                                            type="text" data-date-format="dd M yyyy"/> 
                                                                <%--<asp:TextBox ID="txttodate" runat="server"></asp:TextBox>
                                                                <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txttodate"
                                                                    DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                </CC1:CalendarExtender>--%>
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                                    <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" validationgroup ="Validation10" runat="server" onserverclick ="btnsearch_ServerClick">
                                                        Search
                                                    </button>
                                                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btnClear" runat="server" onserverclick ="btnClear_ServerClick">
                                                        Clear
                                                    </button>
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                    ValidationGroup ="Validation10" ShowSummary="False" />
                                                    </div>
                                                </div>
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
                                                    <div class="widget-header widget-header-small header-color-dark">
                                                        <h5>
                                                            <i class="fa fa-chain "></i>ECS Dispatch Slip Search Results
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand ="Repeater1_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table class="table table-striped table-bordered table-hover Table2">
                                                                    <thead>
                                                                        <tr>
                                                                            <th align="center" style="text-align: center">
                                                                                Division
                                                                            </th>
                                                                            <%--<th align="center" style="text-align: center">
                                                                                Center
                                                                            </th>--%>
                                                                            <th align="center" style="text-align: center">
                                                                                Slip No.
                                                                            </th>
                                                                            <th align="center" style="text-align: center">
                                                                                Slip Date
                                                                            </th>
                                                                           <%-- <th align="center" style="text-align: center">
                                                                                Payee
                                                                            </th>--%>
                                                                            <th align="center" style="text-align: center">
                                                                                Count
                                                                            </th>
                                                                            <th align="center" style="text-align: center">
                                                                                Slip Value
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
                                                                   <%-- <td>
                                                                        <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>--%>
                                                                    <td>
                                                                        <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "slipno")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "SlipDate")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <%--<td>
                                                                        <asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "Payee")%>' runat="server"></asp:Label>
                                                                    </td>--%>
                                                                    <td>
                                                                        <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "Cheque Count")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: center">
                                                                        <asp:LinkButton ID="lnkviewdetails" runat="server" class="btn btn-minier btn-primary icon-eye-open tooltip-info" data-rel="tooltip" data-placement="top" title="View" 
                                                                            CommandName="Viewdetails" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"slipno")%>'
                                                                            Visible="false"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkExcelUpload" runat="server" class="btn btn-minier btn-warning icon-2x icon-download-alt tooltip-warning" data-rel="tooltip" data-placement="top" title="Excel Upload" 
                                                                            CommandName="ExcelUpload" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"slipno")%>'
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
                    <asp:PostBackTrigger ControlID="btnsearch" />   
                    <asp:PostBackTrigger ControlID="btnClear" />                                       
                    <asp:PostBackTrigger ControlID="Repeater1" />      
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="UpnladdCMS" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="div1" runat="server">
                        <div class="span12">
                                <div class="widget-box">
                                                    <div class="widget-header widget-header-small header-color-dark">
                                                        <h5>
                                                            <i class="fa fa-chain "></i>Add ECS Dispatch Slip
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
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
                                                                <input readonly="readonly" class="span7 date-picker" id="txtdispatchDate" runat="server"
                                                                            type="text" data-date-format="dd-mm-yyyy"/> 
                                                               
                                                               <%-- <asp:TextBox ID="txtdispatchDate" runat="server" ValidationGroup="Val1" Width ="60%"></asp:TextBox>
                                                                <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdispatchDate"
                                                                    DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                </CC1:CalendarExtender>
                                                                <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="txtdispatchDate"
                                                                    ValidationGroup="Val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtdispatchDate"
                                                                    ValidationGroup="Val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date"
                                                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])-(0[13578]|1[02])-((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)-(0[13456789]|1[012])-((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])-02-((19|[2-9]\d)\d{2}))|(29-02-((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                                                --%>
                                                                <asp:Label ID="lbldateerrordob" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ControlToValidate="txtdispatchDate"
                                                                    Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Dispatch Date"
                                                                    InitialValue="Select" />
                                                            </td>                                                            
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Division
                                                                <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:ListBox runat="server" ID="ddlAddSlipDivisionNew" Width="142px" ToolTip="Division" data-placeholder="Select Division"
                                                                    SelectionMode="Multiple" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlAddSlipDivisionNew_SelectedIndexChanged" />
                                                                <%--<asp:DropDownList ID="ddlAddSlipDivision" ValidationGroup ="Val1" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlAddSlipDivision_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlAddSlipDivision"
                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Division"
                                                                InitialValue="Select" />--%>
                                                            </td>
                                                            <td width="10%" colspan="2">
                                                                <%--Center
                                                                <asp:Label ID="label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>--%>
                                                            </td>
                                                            <%--<td width="20%">
                                                                <asp:DropDownList ID="ddlcenterSlip" ValidationGroup ="Val1" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlcenterSlip_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="ddlcenterSlip"
                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                InitialValue="Select" />
                                                            </td>--%>
                                                        </tr>
                                                        <tr>
                                                            <%--<td width="10%">
                                                                Pay Mode
                                                                <asp:Label ID="label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlpaymode" ValidationGroup ="Val1" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlpaymode_SelectedIndexChanged">
                                                                    <asp:ListItem Value="04">Select</asp:ListItem>
                                                                    <asp:ListItem Value="05">Instruments</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlpaymode"
                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Pay Mode"
                                                                InitialValue="04" />
                                                            </td>
                                                            <td width="10%">
                                                                Payee
                                                                <asp:Label ID="label12" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td width="20%">
                                                                <asp:DropDownList ID="ddlpayeeadd" ValidationGroup ="Val1" runat="server" data-placeholder="Select" CssClass="chzn-select">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlpayeeadd"
                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                InitialValue="Select" />
                                                            </td>--%>
                                                            <td width="10%" colspan="4" style="text-align: center">
                                                                 <button class="btn btn-app btn-success btn-mini radius-4" id="btngetrecords" runat="server" validationgroup="Val1" 
                                                                    onserverclick ="btngetrecords_ServerClick">
                                                                    Get
                                                                </button>
                                                            </td>
                                                            <%--<td width="20%">
                                                                
                                                            </td>--%>
                                                        </tr>
                                                    </table>
                                                    <%--<form class="form-inline" action="#">
									        <button class="btn blue btn-block margin-top-20" id="Button1" runat ="server">Get <i class="m-icon-swapright m-icon-white"></i></button>
									    </form>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-fluid" id="div4" runat="server">
                                            <div class="span12">
                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            <i class="fa fa-money"></i>Pending Instruments
                                                        </h5>
                                                        <div class="widget-toolbar">
                                                            Total no. of records found:
                                                            <asp:Label ID="lblrecordcount" runat="server" Text="0"></asp:Label>
                                                             <asp:CheckBox ID="chkStudentAllHidden_Sel" runat="server" Visible="False" />
                                                        </div>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                        <asp:DataList ID="dlreceipts" runat="server" Width="100%" DataKeyField="Studno" CssClass="table table-striped table-bordered table-hover">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkStudentAll" runat="server" AutoPostBack="True" OnCheckedChanged="All_Student_ChkBox_Selected_Sel" />
                                                                                        <span class="lbl"></span></b>
                                                                </th>
                                                                
                                                                <th align="center" style="text-align: center">
                                                                    Payee
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Center
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Instrument No.
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Instrument Date
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Amount
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Bank Name
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Customer Name
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    SBEntrycode
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                Product
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="checkpoint" runat="server" />
                                                                <span class="lbl"> </span>

                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Payee")%>' runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblcentername" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_name")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblinstrno" Text='<%#DataBinder.Eval(Container.DataItem, "Instrumentno")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblinstrdate" Text='<%#DataBinder.Eval(Container.DataItem, "InstrumentDate")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblinstramt" Text='<%#DataBinder.Eval(Container.DataItem, "InstrumentAmount")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblbankname" Text='<%#DataBinder.Eval(Container.DataItem, "BankName")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblstudentname" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                 <td>
                                                                    <asp:Label ID="Label19" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntrycode")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblstreamdec" Text='<%#DataBinder.Eval(Container.DataItem, "Stream_sdesc")%>'
                                                                        runat="server"></asp:Label>
                                                                    <asp:Label ID="lblDivisionCode" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "DivisionCode")%>'
                                                                        runat="server"></asp:Label>
                                                                    <asp:Label ID="lblCenterCode" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "Center_Code")%>'
                                                                        runat="server"></asp:Label>
                                                                    <asp:Label ID="lblAcadyear" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "Acad_Year")%>'
                                                                        runat="server"></asp:Label>
                                                                    <asp:Label ID="lblChequeidno" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "ChequeIDno")%>'
                                                                        runat="server"></asp:Label>
                                                                    <asp:Label ID="lblsbentrycode" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "SBEntrycode")%>'
                                                                        runat="server"></asp:Label>
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
                                                                Total Slip Amount
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtslipamt" Enabled="false" runat="server" Width="40%" CssClass="popovers "
                                                                    data-trigger="hover" data-placement="top" data-content="Dispatch Date" data-original-title="Dispatch Slip Date"></asp:TextBox>
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
                                                    <asp:Label ID="lblECSDate" runat="server" Visible="false"></asp:Label>
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
                                    </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsave" />
                    <asp:PostBackTrigger ControlID ="btnCloseAdd" />
                    <asp:PostBackTrigger ControlID="btngetrecords" />
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
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
