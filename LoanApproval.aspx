<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="LoanApproval.aspx.cs" Inherits="LoanApproval" %>

<script runat="server">
    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">       
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="server">

    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">      

        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="HomePage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Loan Approval<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <%--<asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />--%>
            <span id="listudentstatus" runat="server">
                <span id="badgeError" runat="server" class="badge badge-important" visible ="false">Student Status : Pending</span>
                <span id="badgeSuccess" runat="server" class="badge badge-success" visible ="false" >Student Status : Confirmed</span>
                <span id="Span1" runat="server" class="badge badge-important" visible ="false">Student Status : Cancelled</span>
                <asp:Label ID="lblstdstaus" runat="server" Visible ="false" ></asp:Label>
            </span>
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />
        </div>
        <!--#nav-search-->
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
                            <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>
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
            <div id="DivSearchPanel" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Search Options
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                Company <asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlcompany" runat="server" ValidationGroup ="Validation10" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlcompany_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlcompany"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Company"
                                                                InitialValue="Select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                Division <asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddldivision" ValidationGroup ="Validation10" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddldivision"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Divison"
                                                                InitialValue="Select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                 <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                Status <asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlStatus" Width="215px" data-placeholder="Select Status"
                                                                    CssClass="chzn-select">                                                                
                                                                    <asp:ListItem>All</asp:ListItem>
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                   
                                            </tr>                                           
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    Text="Search" ToolTip="Search" ValidationGroup="Validation10" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" onclick="BtnClearSearch_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                    ValidationGroup ="Validation10" ShowSummary="False" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <%--<asp:LinkButton runat="server" ID="HLExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" onclick="HLExport_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                    <tr>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        
                                        <asp:Label runat="server" ID="Label9">Company</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        
                                        <asp:Label runat="server" ID="lblCompany_Result" Text="MT" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        
                                        <asp:Label runat="server" ID="Label10">Division</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        
                                        <asp:Label runat="server" ID="lblDivision_Result" Text="" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label11">Status</asp:Label>    
                                        
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                           <asp:Label runat="server" ID="lblStatus_Result" class="blue"></asp:Label>
                                                                                     
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>                    
                </table>
                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" OnItemCommand="dlGridDisplay_ItemCommand" >
                    <HeaderTemplate>
                        <b>Centre</b> </th>
                        <th align="left">
                            ClassRoom Product
                        </th>
                        <th align="left">
                            SBEntryCode
                        </th>
                        <th align="left">
                            Student Name
                        </th>
                        <th align="left">
                            Loan Dispatch Date
                        </th>                                               
                        <th style="width: 100px; text-align: center;" >
                        Action
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCentre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Center")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblClassRoomProduct" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ClassRoomProduct")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblSBEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntryCode")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblStudentName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblLoanDispatchDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"LoanDispatchDate")%>' />
                        </td>                                          
                        <td style="width: 100px; text-align: center;">
                            <asp:LinkButton ID="lnkOpen" runat="server" class="btn btn-minier btn-primary icon-eye-open tooltip-info" data-rel="tooltip" data-placement="top" title="Open" 
                                    CommandName="Open" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SBEntryCode")%>' Visible="true"></asp:LinkButton>
                        </td>
                    </ItemTemplate>
                </asp:DataList>

              
            </div>           
            <div id="DivEditPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Loan Approval Details
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                             <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                
                                                                <asp:Label runat="server" ID="Label15">Centre</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                
                                                                <asp:Label runat="server" ID="lblCentre_Result1" Text="" CssClass="blue" />
                                                                <asp:Label runat="server" ID="lblPkey" Text="" CssClass="blue" Visible="false" />
                                                                <asp:Label ID="lblreceiptid" runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label19">ClassRoom Product</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblClassRoomProduct_Result1" Text="" CssClass="blue" />
                                                                <asp:Label runat="server" ID="lblDivCode_Result1" Text="" CssClass="blue" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td> 
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label1">SBEntryCode</asp:Label>
                                                                <asp:TextBox ID="txtShowReceiptAllocation" Enabled="false" runat="server" Width="90%" Visible ="false"></asp:TextBox>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblSBEntryCodet_Result1" Text="" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>    
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label44">Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblStudName_Result1" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>  
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label24">Net Fees</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">                                                                      
                                                                <asp:Label runat="server" ID="lblNetFees_Result1" Text="" CssClass="blue"></asp:Label>                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label2">Amount Received</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">                                                                      
                                                                <asp:Label runat="server" ID="lblAmountRec_Result1" Text="" CssClass="blue"></asp:Label>                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label64">PDC In Hand</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblPDCInHand_Result1" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>       
                                                 <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label21">Balance Amount</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblBalanceAmount_Result1" runat="server" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>   
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label3">Loan Dispatch Date</asp:Label>
                                                                <asp:Label ID="txtcurrentout" runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblLoanDispatchDate_Result1" runat="server" class="blue"></asp:Label>
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left;">                                                                
                                                                <asp:Label runat="server" ID="Label23">Loan Application Status</asp:Label>
                                                                <asp:Label ID="label57" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left;">
                                                                <asp:DropDownList runat="server" ID="ddlLoanAppStatus" ToolTip="Select Loan Application Status"
                                                                    data-placeholder="Select Loan Application Status" CssClass="chzn-select" 
                                                                    Width="215px" onselectedindexchanged="ddlLoanAppStatus_SelectedIndexChanged" AutoPostBack="true" >                                                                
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left;">
                                                                <asp:Label runat="server" ID="lblLOanAmount">Loan Amount Approved</asp:Label>
                                                                <asp:Label ID="label56" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left;">
                                                                <asp:TextBox ID="txtLoanApproveAmount" runat="server" Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <%--<asp:TextBox ID="txtLoanApproveAmount" runat="server" Width="205px" placeholder="Loan Amount"></asp:TextBox>--%>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtLoanApproveAmount"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Loan Approve Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter Valid Amount"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="true" ControlToValidate="txtLoanApproveAmount"
                                                                            ValidationExpression="^\d+(\.\d{2})?$" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>                                           
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left;">
                                                                <asp:Label runat="server" ID="Label5">Date</asp:Label>
                                                                <asp:Label ID="label58" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left;">
                                                                <asp:TextBox ID="txtpaydate" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>                                                   
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left;">
                                                                <asp:Label runat="server" ID="Label8">Pay Mode</asp:Label>
                                                                <asp:Label ID="label59" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left;">
                                                                <asp:DropDownList ID="ddlpaymode" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                            ValidationGroup="Val6" Width="215px" OnSelectedIndexChanged="ddlpaymode_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ControlToValidate="ddlpaymode"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Pay Mode"
                                                                            InitialValue="Select" />
                                                            </td>
                                                        </tr>
                                                    </table>                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left;">
                                                                <asp:Label runat="server" ID="Label43">Remark</asp:Label>                                                                
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left;">
                                                                <asp:TextBox ID="txtRemark" runat="server" Width="205px"></asp:TextBox>
                                                                <asp:Label runat="server" ID="lblRemark"></asp:Label>                                                                
                                                            </td>
                                                        </tr>
                                                    </table>                                                   
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                       
                                                    </table>                                                   
                                                </td>
                                            </tr>
                                        </table>
                                        
                                                <table cellpadding="0" class="table table-striped table-bordered table-condensed" width="100%" id="tblbankdetails" runat="server" visible="false">
                                                <tr>
                                                    <td class="span6" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                            <tr>
                                                                <td class="span2" style="border-style: none; text-align: left;">
                                                                    <asp:Label runat="server" ID="Label12">MICR Code</asp:Label>
                                                                    <asp:Label ID="label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td class="span4" style="border-style: none; text-align: left;">
                                                                    <asp:TextBox ID="txtmicrcode" runat="server" AutoPostBack="true" Width="205px" OnTextChanged="txtmicrcode_TextChanged"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtmicrcode"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter MICR No." />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtmicrcode"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>                                                   
                                                    </td>
                                                    <td class="span6" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                            <tr>
                                                                <td class="span2" style="border-style: none; text-align: left;">
                                                                    <asp:Label runat="server" ID="Label13">Bank Name</asp:Label>
                                                                    <asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                </td>
                                                                <td class="span4" style="border-style: none; text-align: left;">
                                                                    <asp:TextBox ID="txtbankname" runat="server" Width="84%" Enabled="false"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtbankname"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Bank Name Required" />
                                                                </td>
                                                            </tr>
                                                        </table>                                                   
                                                    </td>
                                                </tr>
                                                <tr>
                                                        <td class="span6" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                            <tr>
                                                                <td class="span2" style="border-style: none; text-align: left;">
                                                                    <asp:Label runat="server" ID="Label17">Branch Name</asp:Label>
                                                                    <asp:Label ID="label60" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    
                                                                </td>
                                                                <td class="span4" style="border-style: none; text-align: left;">
                                                                    <asp:TextBox ID="txtbranchname" runat="server" Width="94%" Enabled="false"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>                                                   
                                                    </td>
                                                    <td class="span6" style="text-align: left">
                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">                                                           
                                                        </table>                                                   
                                                    </td>
                                                </tr>
                                                </table>
                                               
                                                    <table cellpadding="0" class="table table-striped table-bordered table-condensed" width="100%" id="tblcheque" runat="server" visible="false">
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label18">Instrument Number</asp:Label>
                                                                            <asp:Label ID="label20" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <asp:TextBox ID="txtchqno" runat="server" Width="205px" MaxLength="10"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtchqno"
                                                                                    Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cheque Number" />
                                                                                <asp:RegularExpressionValidator ID="redquiredexpression5" ControlToValidate="txtchqno"
                                                                                    Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                                                    ErrorMessage="Cheque should be between 6-20" ValidationGroup="Val6" Text="#"
                                                                                    SetFocusOnError="true" ControlToValidate="txtchqno" ValidationExpression="^[0-9]{6,20}$" />
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label22">Instrument Date</asp:Label>
                                                                            <asp:Label ID="label61" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            
                                                                            <input readonly="readonly" class="span7 date-picker" id="txtchqdate" runat="server"
                                                                                    type="text" data-date-format="dd M yyyy" />
                                                                                    <%--<asp:TextBox ID="txtchqdate" runat="server" Width="84%"></asp:TextBox>--%>
                                                                        <%--<CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtchqdate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>--%>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtchqdate"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cheque Date" />
                                                                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtchqdate"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -](0[1-9]|1[012])[- -](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                       </tr>
                                                       <tr>
                                                             <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label27">Payee</asp:Label>
                                                                            <asp:Label ID="label62" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <asp:DropDownList ID="ddlpayee" runat="server" Width="215px" AutoPostBack="true" ValidationGroup="Val6" OnSelectedIndexChanged="ddlpayee_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="ddlpayee"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                                InitialValue="Select" />                                                                            
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                   
                                                                </table>                                                   
                                                            </td>
                                                           
                                                       </tr>
                                                    </table>
                                                
                                                    <table cellpadding="0" class="table table-striped table-bordered table-condensed" width="100%" id="tblDD" runat="server" visible="false">
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label28">DD Number</asp:Label>
                                                                            <asp:Label ID="label29" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <asp:TextBox ID="txtddno" runat="server" Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtddno"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Amount" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="DD no. should be between 6-20"
                                                                                ValidationGroup="Val6" Text="#" SetFocusOnError="true" ControlToValidate="txtddno"
                                                                                ValidationExpression="^[0-9]{6,20}$" />
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label30"> DD Date</asp:Label>
                                                                            <asp:Label ID="label34" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">                                                                            
                                                                            <input readonly="readonly" class="span7 date-picker" id="txtdddate" runat="server"
                                                                                    type="text" data-date-format="dd M yyyy" />                                                                                    
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtdddate"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Date" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtdddate"
                                                                                ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                       </tr>
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label33">Payee</asp:Label>
                                                                            <asp:Label ID="label63" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                           <asp:DropDownList ID="ddlpayeedd" runat="server" Width="215px" AutoPostBack="true"
                                                                            ValidationGroup="Val6">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" ControlToValidate="ddlpayeedd"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                                InitialValue="Select" />                                                                       
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    
                                                                </table>                                                   
                                                            </td>
                                                            
                                                       </tr>
                                                    </table>
                                                
                                                    <table cellpadding="0" class="table table-striped table-bordered table-condensed" width="100%" id="tblcash" runat="server" visible="false">
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label37">Payee</asp:Label>
                                                                            <asp:Label ID="label38" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">                                                                            
                                                                            <asp:DropDownList ID="ddlpayeecash" runat="server" Width="215px" AutoPostBack="true"
                                                                            ValidationGroup="Val6" OnSelectedIndexChanged ="ddlpayeecash_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="ddlpayeecash"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                   
                                                                </table>                                                   
                                                            </td>
                                                            
                                                       </tr>                                                       
                                                    </table>
                                               

                                                    <table cellpadding="0"  class="table table-striped table-bordered table-condensed" width="100%" id="tblccdc" runat="server" visible="false">
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label39">Transaction Id</asp:Label>
                                                                            <asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <asp:TextBox ID="txttransid" runat="server" Width="205px" MaxLength="15"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ControlToValidate="txttransid"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Transaction Id" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server"
                                                                                ErrorMessage="Transaction Id should be of 14 digits" ValidationGroup="Val6" Text="#"
                                                                                SetFocusOnError="true" ControlToValidate="txttransid" ValidationExpression="^[A-Z0-9]{14,14}$" />
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label41">Transaction Date</asp:Label>
                                                                            <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">                                                                            
                                                                            <input readonly="readonly" class="span7 date-picker" id="txttrandate" runat="server"
                                                                                type="text" data-date-format="dd M yyyy" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="txttrandate"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Transaction Date" />
                                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txttrandate"
                                                                                ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -](0[1-9]|1[012])[- -](19|20)\d\d$"></asp:RegularExpressionValidator>--%>

                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                       </tr>                                                       
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label47">Payee</asp:Label>
                                                                            <asp:Label ID="label48" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">                                                                            
                                                                            <asp:DropDownList ID="ddlpayeetrans" runat="server" Width="215px" AutoPostBack="true" ValidationGroup="Val6" >
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="ddlpayeetrans"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                   
                                                                </table>                                                   
                                                            </td>
                                                            
                                                       </tr>                                                       
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label49">Card Type</asp:Label>
                                                                            <asp:Label ID="label50" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <asp:DropDownList ID="ddlcardtype" runat="server" Width="215px" AutoPostBack="true" ValidationGroup="Val6">
                                                                            
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" ControlToValidate="ddlcardtype"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label51"> Card Holder</asp:Label>
                                                                            <asp:Label ID="label52" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">                                                                            
                                                                            <asp:TextBox ID="txtcardholder" runat="server" Width="205px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                       </tr>                                                       
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label53">last 4 Digit</asp:Label>
                                                                            <asp:Label ID="label54" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <asp:TextBox ID="txtlast4digit" runat="server" Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="txtlast4digit"
                                                                                    Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Last 4 Digit on Card" />
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator26" ControlToValidate="txtlast4digit"
                                                                                    Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                                                    ErrorMessage="Enter Last 4 digit on card" ValidationGroup="Val6" Text="#"
                                                                                    SetFocusOnError="true" ControlToValidate="txtlast4digit" ValidationExpression="^[0-9]{4,4}$" />
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    
                                                                </table>                                                   
                                                            </td>
                                                       </tr>                                                       
                                                    </table>

                                                    <table cellpadding="0" class="table table-striped table-bordered table-condensed" width="100%" id="tblNEFT" runat="server" visible="false">
                                                       <tr>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label25">Reference Number</asp:Label>
                                                                            <asp:Label ID="label26" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <asp:TextBox ID="txtNeftRefNo" runat="server" Width="205px" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtNeftRefNo"
                                                                                    Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Reference Number" />
                                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtNeftRefNo"
                                                                                    Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                                                    ErrorMessage="Cheque should be between 6-20" ValidationGroup="Val6" Text="#"
                                                                                    SetFocusOnError="true" ControlToValidate="txtNeftRefNo" ValidationExpression="^[0-9]{6,20}$" />--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label31">Date</asp:Label>
                                                                            <asp:Label ID="label32" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <input readonly="readonly" class="span7 date-picker" id="txtNeftDate" runat="server"
                                                                                type="text" data-date-format="dd M yyyy"/>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtNeftDate"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Transaction Date" />
                                                                            <%--<asp:TextBox ID="txtNeftDate" runat="server" Width="205px" Enabled="false"></asp:TextBox>--%>
                                                                            <%--<input readonly="readonly" class="span7 date-picker" id="txtNeftDate" runat="server"
                                                                                    type="text" data-date-format="dd M yyyy" disabled="disabled"/>--%>
                                                                                    <%--<asp:TextBox ID="txtchqdate" runat="server" Width="84%"></asp:TextBox>--%>
                                                                        <%--<CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtchqdate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>--%>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtchqdate"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cheque Date" />--%>
                                                                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtchqdate"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -](0[1-9]|1[012])[- -](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                       </tr>
                                                       <tr>
                                                             <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left;">
                                                                            <asp:Label runat="server" ID="Label35">Payee</asp:Label>
                                                                            <asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                            
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left;">
                                                                            <asp:DropDownList ID="ddlNeftPayee" runat="server" Width="215px" AutoPostBack="true" ValidationGroup="Val6">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ddlNeftPayee"
                                                                                Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                                InitialValue="Select" />                                                                            
                                                                        </td>
                                                                    </tr>
                                                                </table>                                                   
                                                            </td>
                                                            <td class="span6" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                   
                                                                </table>                                                   
                                                            </td>
                                                           
                                                       </tr>
                                                    </table>
                                                    <asp:DataList ID="dlallocation" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" Visible="false">
                                                                <HeaderTemplate>
                                                                    <b class="center" style="text-align: center">Select</b></th>
                                                                    <th align="center" style="text-align: center">
                                                                        Product Header
                                                                    </th>
                                                                    <th align="center" style="text-align: center">
                                                                        Net Value
                                                                    </th>
                                                                    <th align="center" style="text-align: center">
                                                                        Received
                                                                    </th>
                                                                    <th align="center" style="text-align: center">
                                                                        Balance
                                                                    </th>
                                                                    <th align="center" style="text-align: center">
                                                                        Current Allocation
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk1" runat="server" AutoPostBack="true" /><span class="lbl"></span></td>
                                                                    <td>
                                                                        <asp:Label ID="lblproductheader" Text='<%#DataBinder.Eval(Container.DataItem, "voucher_description")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblproductvalue" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_amt")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lbltotalreceived" Text='<%#DataBinder.Eval(Container.DataItem, "amtreceived")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblamtallocated" Text='<%#DataBinder.Eval(Container.DataItem, "AmtAllocated")%>'
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtcurrentallocation" runat="server" AutoPostBack="true" Width="90%"
                                                                            MaxLength="10" ValidationGroup="Val6"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                                            ErrorMessage="Enter only Numeric Value" ValidationGroup="Val6" Text="#" SetFocusOnError="true"
                                                                            ControlToValidate="txtcurrentallocation" ValidationExpression="^[0-9]{1,10}$" />
                                                                        <asp:Label ID="lblproductheadercode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"pricing_procedure_code")%>'
                                                                            Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:DataList>

                                                            <asp:DataList ID="dlpaymentreceipt" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        Height="20px" OnItemDataBound ="dlpaymentreceipt_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <b class="center" style="text-align: center">Receipt Date</b></th>
                                                            <th align="center" style="text-align: center">
                                                                Payee
                                                            </th>
                                                            <th align="center" style="text-align: center">
                                                                Mode
                                                            </th>
                                                            <th align="center" style="text-align: center">
                                                                Instr #
                                                            </th>
                                                            <th align="center" style="text-align: center">
                                                                Dated
                                                            </th>
                                                            <th align="center" style="text-align: center">
                                                                Amount
                                                            </th>
                                                            <th align="center" style="text-align: center">
                                                                Location
                                                            </th>
                                                            <th align="center" style="text-align: center">
                                                                Status
                                                            </th>
                                                            <%--<th align="center" style="text-align: center">
                                                                Action
                                                            </th>--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrecptdate" Text='<%#DataBinder.Eval(Container.DataItem, "ReceiptDate")%>'
                                                                runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label24" Text='<%#DataBinder.Eval(Container.DataItem, "Payee_name")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "Paymode")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblinsnum" Text='<%#DataBinder.Eval(Container.DataItem, "Pay_InsNum")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblinstrdate" Text='<%#DataBinder.Eval(Container.DataItem, "Pay_InstrDate")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblinstramt" Text='<%#DataBinder.Eval(Container.DataItem, "Instr_Amt")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location_Description")%>'></asp:Label>
                                                            </td> 
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="lblchequestatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ins_Status")%>'></asp:Label></b>
                                                            </td> 
                                                            <td id="td16" runat="server" align="center" style="text-align: center" visible="false">
                                                                <asp:LinkButton ID="lnkedit" runat="server" class="btn default btn-xs green" CommandName="Edit" Visible="false"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Chequeidno")%>'><i class="fa fa-eye"></i> Edit</asp:LinkButton>
                                                                <asp:LinkButton ID="lnkblock" runat="server" class="btn btn-mini btn-danger" CommandName="Remove" Visible="false"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Chequeidno")%>'><i class="icon-trash"></i></asp:LinkButton>                                                                
                                                                <asp:Label ID="lblAction" runat="server" Visible="true">
                                                                    <span class="label label-success arrowed-in arrowed-in-right">No Action</span>
                                                                </asp:Label>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Label runat="server" ID="Label55" Text="" ForeColor="Red" />
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnSave" runat="server"
                                Text="Save" ValidationGroup="Val6" onclick="btnSave_Click"/>
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnClose"
                                Visible="true" runat="server" Text="Close" onclick="btnClose_Click"/>
                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="Val6" runat="server" />
                        </div>
                    </div>
                </div>
            </div>     

        </div>
    </div>
     <!--/row-->
</asp:Content>
