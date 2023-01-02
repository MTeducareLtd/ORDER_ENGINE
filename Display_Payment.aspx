<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Display_Payment.aspx.cs" Inherits="Display_Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE HEADER--> 
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
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="Manage_payments.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
            <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
            </i><a href="#">
                <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
        </ul>
        <div id="nav-search">
            <span id="listudentstatus" runat="server">
                <span id="badgeError" runat="server" class="badge badge-important" visible ="false">Student Status : Pending</span>
                <span id="badgeSuccess" runat="server" class="badge badge-success" visible ="false" >Student Status : Confirmed</span>
                <span id="Span1" runat="server" class="badge badge-important" visible ="false">Student Status : Cancelled</span>
                <asp:Label ID="lblstdstaus" runat="server" Visible ="false" ></asp:Label>
            </span>
            <!-- /btn-group -->
            <!--<button type="button" class="btn btn-app btn-primary btn-mini radius-4 dropdown-toggle"
                data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                <span>Actions </span><i class="fa fa-angle-down"></i>
            </button>
            <ul class="dropdown-menu pull-right" role="menu">
                <li><a id="btnregistrationno" runat="server" visible="false" href="Series.aspx" target="_blank" onserverclick ="btnregistrationno_ServerClick">
                    Manage Statutory Info.</a></li>
                <li><a data-loading-text="Loading..." class="demo-loading-btn btn blue" runat="server"
                    target="_blank" id="btnviewenrollment" style="margin-right: 205px"><i class="fa fa-bullhorn">
                    </i>View Enrollment</a></li>
            </ul>-->
        </div>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
    <!-- END PAGE HEADER-->
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
            <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
    </div>
            <!-- BEGIN PAGE CONTENT FOR VIEW LEDGER-->
            <asp:UpdatePanel ID="Upnlviewledger" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="div1" runat="server">
                        <div class="span12">
                            <div id="Div2">
                                <div class="row-fluid" id="Div3" runat="server">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <tr>
                                                    <td width="10%">
                                                        Gender
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtgender" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Student Name
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtLstudentname" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%" rowspan="3" runat="server" id="td05" visible="false">
                                                        <br />
                                                        <br />
                                                        Customer Photo
                                                    </td>
                                                    <td width="20%" rowspan="3" runat="server" id="td06" visible="false">
                                                        <asp:Image ID="imgstudentphoto" runat="server" Width="150px" Height="100px" />
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
                                                        <asp:TextBox ID="txtShowReceiptAllocation" Enabled="false" runat="server" Width="90%" Visible ="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        App. Form No
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtLappno" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        Opportunity Id
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtopportunityid" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Account ID
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtaccountid" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td width="10%">
                                                        SBEntrycode
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtcursbcode" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Company
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllcompany" Enabled="false" runat="server" Width="95%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Division
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlldivision" Enabled="false" runat="server" Width="95%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Center
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllcenter" Enabled="false" runat="server" Width="95%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Academic Year
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllacadyear" Enabled="false" runat="server" Width="95%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Stream
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddllstream" Enabled="false" runat="server" Width="95%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Pay Plan
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtpayplan" Enabled="false" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Label ID="lblreceiptid" runat="server" Visible="false"></asp:Label>
                                            <table class="table table-striped table-bordered table-advance table-hover">
                                              <tr>
                                                    <td width="10%">
                                                        Remarks :
                                                    </td>
                                                    
                                                    <td>
                                                       <asp:Label ID="lblremarksupdated" Width="95%" runat="server" Enabled="false"></asp:Label>
                                                    </td>
                                                    
                                                </tr>
                                             </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid" id="div5" runat="server">
                                    <div class="span3">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                            <div class="widget-header">
                                                <h5>
                                                    Student Ledger
                                                </h5>
                                            </div>
                                            <div class="widget-body" style="height: 950px; overflow: Auto; overflow-y:hidden; overflow-x:hidden;">
                                                <div class="widget-main">
                                                <asp:DataList ID="dlstudentledger" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                    Height="30">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_description")%>'
                                                            runat="server" class="tooltip-info"  data-rel="tooltip" data-placement="left" title='<%#DataBinder.Eval(Container.DataItem, "Tooltip")%>'
                                                            Font-Bold='<%#DataBinder.Eval(Container.DataItem, "BoldFlag")%>'></asp:Label></td>
                                                        <td>
                                                            <div style="float: left; width: 99%; text-align: right;">
                                                                <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amt")%>'
                                                                    runat="server" Font-Bold='<%#DataBinder.Eval(Container.DataItem, "BoldFlag")%>'></asp:Label></div>
                                                        </td>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                </div> 
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span9">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                            <div class="widget-header">
                                                <h5>
                                                    Payment
                                                </h5>
                                                <div class="widget-toolbar">
                                                    <div class="btn-group">
                                                    </div>
                                                    <div class="btn-group">
                                                        <button type="button" class="btn btn-app btn-success btn-mini radius-4" id="btnaddpayment" runat="server" onserverclick="btnaddpayment_ServerClick" visible ="false" >
                                                            Add</button>
                                                    </div>
                                                    <div class="btn-group" id="divevents" runat="server" visible="false">
                                                        <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnproceedprint" runat="server" onserverclick ="btnproceedprint_ServerClick">
                                                            Print</button>
                                                    </div>

                                                    
                                                </div>
                                            </div>
                                            <div class="widget-body" style="height: 950px; overflow: Auto">
                                                <div class="widget-main">
                                                    <asp:DataList ID="dlpaymentreceipt" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        Height="20px" OnItemDataBound ="dlpaymentreceipt_ItemDataBound" OnItemCommand ="dlpaymentreceipt_ItemCommand">
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
                                                            <%--<th>Action--%>
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
                                                                <asp:Label ID="Label36" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location_Description")%>'></asp:Label>
                                                            </td> 
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="lblchequestatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ins_Status")%>'></asp:Label></b>
                                                            </td> 
                                                            <td id="td16" runat="server" visible="false">
                                                                <asp:LinkButton ID="lnkedit" runat="server" class="btn default btn-xs green" CommandName="Edit"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Chequeidno")%>'><i class="fa fa-eye"></i> Edit</asp:LinkButton>
                                                                <asp:LinkButton ID="lnkblock" runat="server" class="btn default btn-xs black" CommandName="Remove"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Chequeidno")%>'><i class="fa fa-trash-o"></i> Remove</asp:LinkButton>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <asp:Label ID="txtcurrentout" runat="server" Visible="false"></asp:Label>
                                                    <div class="span12" id="divpayment" runat="server">
                                                        <div class="table-responsive">
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                                <tr id="tr20" runat="server" visible="false">
                                                                    <td width="10%">
                                                                        Pay Head
                                                                        <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayhead" runat="server" AutoPostBack="true" Width="84%"
                                                                            ValidationGroup="Val6" CssClass="chzn-select" OnSelectedIndexChanged="ddlpayhead_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="ddlpayhead"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Pay Head"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Pay Head Fee
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtpayheadfee" runat="server" Width="84%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr21" runat="server" visible="false">
                                                                    <td width="10%">
                                                                        Receipt / Collection
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtreceipt" runat="server" Width="84%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Amount To Be Collected
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txttobecollected" runat="server" Width="84%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Payment Date
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtpaydate" runat="server" Width="84%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Pay Mode
                                                                        <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpaymode" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                            ValidationGroup="Val6" OnSelectedIndexChanged="ddlpaymode_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ControlToValidate="ddlpaymode"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Pay Mode"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblbankdetails" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        MICR Code
                                                                        <asp:Label ID="label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtmicrcode" runat="server" AutoPostBack="true" Width="79%" OnTextChanged="txtmicrcode_TextChanged"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtmicrcode"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter MICR No." />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtmicrcode"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Bank Name
                                                                        <asp:Label ID="label12" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtbankname" runat="server" Width="84%" Enabled="false"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtbankname"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Bank Name Required" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Branch Name
                                                                    </td>
                                                                    <td width="20%" colspan="3">
                                                                        <asp:TextBox ID="txtbranchname" runat="server" Width="94%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblcheque" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Instrument Number
                                                                        <asp:Label ID="label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtchqno" runat="server" Width="79%" MaxLength="10"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtchqno"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cheque Number" />
                                                                        <asp:RegularExpressionValidator ID="redquiredexpression5" ControlToValidate="txtchqno"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                                            ErrorMessage="Cheque should be between 6-20" ValidationGroup="Val6" Text="#"
                                                                            SetFocusOnError="true" ControlToValidate="txtchqno" ValidationExpression="^[0-9]{6,20}$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Instrument Date
                                                                        <asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtchqdate" runat="server" Width="84%"></asp:TextBox>
                                                                        <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtchqdate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtchqdate"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cheque Date" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtchqdate"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -](0[1-9]|1[012])[- -](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Amount
                                                                        <asp:Label ID="label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtchequeamt" runat="server" Width="79%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtchequeamt"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cheque Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid Amount"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="true" ControlToValidate="txtchequeamt"
                                                                            ValidationExpression="^\d+(\.\d{2})?$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Payee
                                                                        <asp:Label ID="label21" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayee" runat="server" Width="79%" AutoPostBack="true" ValidationGroup="Val6"
                                                                            OnSelectedIndexChanged="ddlpayee_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="ddlpayee"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblDD" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        DD Number
                                                                        <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtddno" runat="server" Width="84%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtddno"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="DD no. should be between 6-20"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="true" ControlToValidate="txtddno"
                                                                            ValidationExpression="^[0-9]{6,20}$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        DD Date
                                                                        <asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtdddate" runat="server" Width="84%"></asp:TextBox>
                                                                        <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdddate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtdddate"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Date" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtdddate"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        DD Amount
                                                                        <asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtddamt" runat="server" Width="84%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtddamt"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Enter Valid Amount"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="true" ControlToValidate="txtddamt"
                                                                            ValidationExpression="^\d+(\.\d{2})?$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Payee
                                                                        <asp:Label ID="label22" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayeedd" runat="server" Width="84%" AutoPostBack="true"
                                                                            ValidationGroup="Val6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" ControlToValidate="ddlpayeedd"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblcash" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Cash Amount
                                                                        <asp:Label ID="label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtcashamt" runat="server" Width="84%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtcashamt"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cash Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter Valid Amount"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="true" ControlToValidate="txtcashamt"
                                                                            ValidationExpression="^\d+(\.\d{2})?$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Payee
                                                                        <asp:Label ID="label23" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayeecash" runat="server" Width="84%" AutoPostBack="true"
                                                                            ValidationGroup="Val6" OnSelectedIndexChanged ="ddlpayeecash_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="ddlpayeecash"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:DataList ID="dlallocation" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
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
                                                            <table class="table table-striped table-bordered table-advance table-hover" id="tblAllocationAdd" runat="server">
                                                                <tr id="tr22" runat="server">
                                                                    <td width="10%">
                                                                        Amount Allocated
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtslipamt" Enabled="false" runat="server" Width="90%" Text="0"></asp:TextBox>
                                                                        <asp:CompareValidator ID="cmpval" runat="server" ControlToValidate="txtslipamt" ErrorMessage="Amount Mismatch. Kindly Verify"
                                                                            ControlToCompare="txtchequeamt" Operator="Equal" ValidationGroup="Val6" SetFocusOnError="true"
                                                                            Text="#"></asp:CompareValidator>
                                                                    </td>
                                                                    <td width="60%">
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr23" runat="server">
                                                                    <td width="10%">
                                                                        Amount Allocated
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtddalloca" Enabled="false" runat="server" Width="90%" Text="0"></asp:TextBox>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtddalloca"
                                                                            ErrorMessage="Amount Mismatch. Kindly Verify" ControlToCompare="txtddamt" Operator="Equal"
                                                                            ValidationGroup="Val6" SetFocusOnError="true" Text="#"></asp:CompareValidator>
                                                                    </td>
                                                                    <td width="60%">
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr24" runat="server">
                                                                    <td width="10%">
                                                                        Amount Allocated
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtcashalloca" Enabled="false" runat="server" Width="90%" Text="0"></asp:TextBox>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtcashalloca"
                                                                            ErrorMessage="Amount Mismatch. Kindly Verify" ControlToCompare="txtcashamt" Operator="Equal"
                                                                            ValidationGroup="Val6" SetFocusOnError="true" Text="#"></asp:CompareValidator>
                                                                    </td>
                                                                    <td width="60%">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosepayment" runat="server" onserverclick="btnclosepayment_ServerClick">
                                                                Close</button>
                                                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server" id="btnsavepayment" validationgroup="Val6"
                                                                onserverclick="btnsavepayment_ServerClick">
                                                                Save
                                                            </button>
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                                ValidationGroup="Val6" ShowSummary="False" />
                                                            </div> 
                                                        </div>
                                                    </div>
                                                    <div class="span12" id="diveditpayemnt" runat="server">
                                                        <div class="table-responsive">
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Payment Date
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtpaymentdateedit" runat="server" Width="84%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Pay Mode
                                                                        <asp:Label ID="label25" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpaymodeedit" Enabled="false" runat="server" Width="84%"
                                                                            AutoPostBack="true" ValidationGroup="Val6" OnSelectedIndexChanged ="ddlpaymodeedit_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" ControlToValidate="ddlpaymodeedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Pay Mode"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblbankdetailsedit" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        MICR Code
                                                                        <asp:Label ID="label26" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtmicrcodeedit" runat="server" AutoPostBack="true" Width="84%"
                                                                            onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;" OnTextChanged ="txtmicrcodeedit_TextChanged" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" ControlToValidate="txtmicrcodeedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter MICR No." />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txtmicrcodeedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Bank Name
                                                                        <asp:Label ID="label27" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtbanknameedit" runat="server" Width="84%" Enabled="false"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" ControlToValidate="txtbanknameedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Bank Name Required" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Branch Name
                                                                    </td>
                                                                    <td width="20%" colspan="3">
                                                                        <asp:TextBox ID="txtbranchnameedit" runat="server" Width="94%" Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblchequeedit" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Instrument Date
                                                                        <asp:Label ID="label28" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtchqdateedit" runat="server" Width="84%"></asp:TextBox>
                                                                        <CC1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtchqdateedit"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" ControlToValidate="txtchqdateedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cheque Date" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                                                            ControlToValidate="txtchqdateedit" ValidationGroup="Val6" Text="#" SetFocusOnError="True"
                                                                            ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -](0[1-9]|1[012])[- -](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td width="10%">
                                                                        Instrument Number
                                                                        <asp:Label ID="label29" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtchqnoedit" runat="server" Width="84%" MaxLength="10" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="txtchqnoedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cheque Number" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" ControlToValidate="txtchqnoedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                                                                            ErrorMessage="Cheque should be between 6-10" ValidationGroup="Val6" Text="#"
                                                                            SetFocusOnError="true" ControlToValidate="txtchqnoedit" ValidationExpression="^[0-9]{6,10}$" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Amount
                                                                        <asp:Label ID="label31" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtchequeamtedit" Enabled="false" runat="server" Width="84%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="txtchequeamtedit"
                                                                            Text="#" runat="server" ValidationGroup="Val60" SetFocusOnError="True" ErrorMessage="Enter Cheque Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                                                            ErrorMessage="Enter Valid Amount" ValidationGroup="Val60" Text="#" SetFocusOnError="true"
                                                                            ControlToValidate="txtchequeamtedit" ValidationExpression="^\d+(\.\d{2})?$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Payee
                                                                        <asp:Label ID="label32" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayeeedit" runat="server" Width="84%" AutoPostBack="true"
                                                                            ValidationGroup="Val60">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="ddlpayeeedit"
                                                                            Text="#" runat="server" ValidationGroup="Val60" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblddedit" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        DD Date
                                                                        <asp:Label ID="label33" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtdddateedit" runat="server" Width="84%"></asp:TextBox>
                                                                        <CC1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdddateedit"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="txtdddateedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Date" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server"
                                                                            ControlToValidate="txtdddate" ValidationGroup="Val6" Text="#" SetFocusOnError="True"
                                                                            ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td width="10%">
                                                                        DD Number
                                                                        <asp:Label ID="label34" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtddnoedit" runat="server" Width="84%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="txtddnoedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                                            ErrorMessage="DD no. should be between 6-10" ValidationGroup="Val6" Text="#"
                                                                            SetFocusOnError="true" ControlToValidate="txtddnoedit" ValidationExpression="^[0-9]{6,10}$" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        DD Amount
                                                                        <asp:Label ID="label35" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtddamtedit" Enabled="false" runat="server" Width="84%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator66" ControlToValidate="txtddamtedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator67" runat="server"
                                                                            ErrorMessage="Enter Valid Amount" ValidationGroup="Val6" Text="#" SetFocusOnError="true"
                                                                            ControlToValidate="txtddamtedit" ValidationExpression="^\d+(\.\d{2})?$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Payee
                                                                        <asp:Label ID="label99" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayeeddedit" runat="server" Width="84%" AutoPostBack="true" OnSelectedIndexChanged ="ddlpayeedd_SelectedIndexChanged"
                                                                            ValidationGroup="Val6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator68" ControlToValidate="ddlpayeeddedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblcashedit" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Cash Amount
                                                                        <asp:Label ID="label101" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtcashamtedit" Enabled="false" runat="server" Width="84%" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1003" ControlToValidate="txtcashamtedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Cash Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1006" runat="server"
                                                                            ErrorMessage="Enter Valid Amount" ValidationGroup="Val6" Text="#" SetFocusOnError="true"
                                                                            ControlToValidate="txtcashamtedit" ValidationExpression="^\d+(\.\d{2})?$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Payee
                                                                        <asp:Label ID="label230" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayeecashedit" runat="server" Width="84%" AutoPostBack="true"
                                                                            ValidationGroup="Val6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1029" ControlToValidate="ddlpayeecashedit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="30%">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:DataList ID="dlallocationedit" runat="server" Enabled="true" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                                <HeaderTemplate>
                                                                    <b>Select</b></th>
                                                                    <th>
                                                                        Product Header
                                                                    </th>
                                                                    <th>
                                                                        Net Value
                                                                    </th>
                                                                    <th>
                                                                        Total Received
                                                                    </th>
                                                                    <th>
                                                                        Balance
                                                                    </th>
                                                                    <th>
                                                                        Current Allocation
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chk1" runat="server" AutoPostBack="true" /></td>
                                                                    <td>
                                                                        <asp:Label ID="lblproductheader" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_description")%>'
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
                                                                    <td align="right">
                                                                        <asp:TextBox ID="txtcurrentallocation" Text='<%#DataBinder.Eval(Container.DataItem, "lastamt")%>'
                                                                            runat="server" Enabled="false" AutoPostBack="true" Width="90%" MaxLength="10"
                                                                            ValidationGroup="Val6"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                                            ErrorMessage="Enter only Numeric Value" ValidationGroup="Val6" Text="#" SetFocusOnError="true"
                                                                            ControlToValidate="txtcurrentallocation" ValidationExpression="^[0-9]{1,10}$" />
                                                                        <asp:Label ID="lblproductheadercode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"pricing_procedure_code")%>'
                                                                            Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                            <table class="table table-striped table-bordered table-advance table-hover" id="tblallocation" runat="server" visible="false">
                                                                <tr id="tr29" runat="server" visible="false">
                                                                    <td width="10%">
                                                                        Amount Allocated
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtslipamtedit" Visible="false" Enabled="false" runat="server" Width="90%"
                                                                            Text="0"></asp:TextBox>
                                                                        <asp:CompareValidator ID="cmpval1" runat="server" ControlToValidate="txtslipamtedit"
                                                                            ErrorMessage="Value is less than cheque value" ControlToCompare="txtchequeamtedit"
                                                                            Operator="GreaterThanEqual" ValidationGroup="Val60" SetFocusOnError="true" Text="#"></asp:CompareValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr30" runat="server" visible="false">
                                                                    <td width="10%">
                                                                        Amount Allocated
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtddallocaedit" Visible="false" Enabled="false" runat="server"
                                                                            Width="90%" Text="0"></asp:TextBox>
                                                                        <asp:CompareValidator ID="CompareValidator103" runat="server" ControlToValidate="txtddallocaedit"
                                                                            ErrorMessage="Value is less than cheque value" ControlToCompare="txtchequeamtedit"
                                                                            Operator="GreaterThanEqual" ValidationGroup="Val60" SetFocusOnError="true" Text="#"></asp:CompareValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr31" runat="server" visible="false">
                                                                    <td width="10%">
                                                                        Amount Allocated
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtcashallocaedit" Visible="false" Enabled="false" runat="server"
                                                                            Width="90%" Text="0"></asp:TextBox>
                                                                        <asp:CompareValidator ID="CompareValidator10021" runat="server" ControlToValidate="txtcashallocaedit"
                                                                            ErrorMessage="Value is less than cheque value" ControlToCompare="txtchequeamtedit"
                                                                            Operator="GreaterThanEqual" ValidationGroup="Val60" SetFocusOnError="true" Text="#"></asp:CompareValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosepaymentedit" runat="server" onserverclick ="btnclosepaymentedit_ServerClick">
                                                                Close</button>
                                                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server" id="btnsavepaymentedit" validationgroup="Val60" onserverclick ="btnsavepaymentedit_ServerClick">
                                                                Save
                                                            </button>
                                                            <asp:ValidationSummary ID="ValidationSummary100" runat="server" ShowMessageBox="True"
                                                                ValidationGroup="Val60" ShowSummary="False" />
                                                            <asp:Label ID="lblreceiptidedit" runat="server" Visible="false"></asp:Label>
                                                            </div> 
                                                        </div>
                                                    </div>
                                                    <div class="alert alert-danger" id="diverrorPayment" runat="server">
                                                        <strong>
                                                            <asp:Label ID="lblerrorPayment" runat="server"></asp:Label></strong>
                                                    </div>
                                                    <div class="alert alert-success" id="divSuccessPayment" runat="server">
                                                        <strong>
                                                            <asp:Label ID="lblsuccessPayment" runat="server"></asp:Label></strong>
                                                            <asp:Label ID="lblchequeidno" runat="server" Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="row-fluid" id="divrequest" runat="server" visible="false">
                                    <div class="span12">
                                        <div class="portlet box blue">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-anchor"></i>Request Status : <b>
                                                        <asp:Label ID="lblstudentname1" runat="server" ForeColor="WhiteSmoke"></asp:Label></b>
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <div class="table-responsive">
                                                    <asp:DataList ID="dlrequestdetails" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        Height="20px">
                                                        <HeaderTemplate>
                                                            <b>Date</b></th>
                                                            <th>
                                                                Request Type
                                                            </th>
                                                            <th>
                                                                Notes
                                                            </th>
                                                            <th>
                                                                Requested Amount
                                                            </th>
                                                            <th>
                                                                Status
                                                            </th>
                                                            <th>
                                                                Open (Days)
                                                            </th>
                                                            <th>
                                                            Action
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrecptdate" Text='<%#DataBinder.Eval(Container.DataItem, "request_date")%>'
                                                                runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblinsnum" Text='<%#DataBinder.Eval(Container.DataItem, "request_type")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblinstrdate" Text='<%#DataBinder.Eval(Container.DataItem, "Notes")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <div style="float: left; width: 99%; text-align: right;">
                                                                    <asp:Label ID="lblinstramt" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'
                                                                        runat="server"></asp:Label></div>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblchequestatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"status")%>'></asp:Label>
                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Sbentrycode","View_Request_Details.aspx?&SBEntrycode={0}")%>&Req_id=<%#DataBinder.Eval(Container.DataItem,"Request_id")%>'
                                                                        target="_blank" class="btn default btn-xs green"><i class="fa fa-eye"></i>View Details</a>
                                                                    <%--<asp:LinkButton ID="lblviewdetails" runat="server" class="btn default btn-xs green" CommandName ="Viewdetails" CommandArgument ='<%#DataBinder.Eval(Container.DataItem,"Request_id")%>'><i class="fa fa-eye"></i> View Details</asp:LinkButton>
                                                        <a href='<%#DataBinder.Eval(Container.DataItem,"Sbentrycode","View_Request_Details.aspx?&SBEntrycode={0}") & DataBinder.Eval(Container.DataItem,"Request_id","Request_Id={0}")%>' target ="_blank"   class="btn default btn-xs green"><i class="fa fa-eye"></i> View Details</a> 
                                                                    --%>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                                <div class="alert alert-danger" id="div12" runat="server">
                                                    <strong>
                                                        <asp:Label ID="Label2" runat="server"></asp:Label></strong>
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
                    <asp:AsyncPostBackTrigger ControlID="txtmicrcode" />
                    <asp:PostBackTrigger ControlID="btnclosepayment" />
                    <%--<asp:PostBackTrigger ControlID="btncloseremoverpt" />--%>
                    <%--<asp:PostBackTrigger ControlID="btnremovereceipt" />--%>
                    <%-- <asp:PostBackTrigger ControlID ="btnclosemodal" />
                        <asp:PostBackTrigger ControlID ="btnclosemodal1" />--%>
                    <asp:PostBackTrigger ControlID="btnsavepayment" />
                    <asp:PostBackTrigger ControlID="btnproceedprint" />
                    <%--<asp:PostBackTrigger ControlID="btnclosemodalProm" />--%>
                    <%--<asp:PostBackTrigger ControlID="btnclosemodalProm1" />--%>
                    <%--<asp:PostBackTrigger ControlID="apromotestudent" />--%>
                    <%--<asp:PostBackTrigger ControlID="btnSwapClose1" />--%>
                    <%--<asp:PostBackTrigger ControlID="btnSwapClose" />--%>
                    <%--<asp:PostBackTrigger ControlID="btnSaveswap" />--%>
                   <%-- <asp:PostBackTrigger ControlID="btnaddprodclose1" />
                    <asp:PostBackTrigger ControlID="btnaddprodclose" />
                    <asp:PostBackTrigger ControlID="btnaddprodsave" />
                    <asp:PostBackTrigger ControlID="btnremoveclose1" />
                    <asp:PostBackTrigger ControlID="btnremoveclose" />
                    <asp:PostBackTrigger ControlID="btnremovesave" />--%>
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR VIEW LEDGER-->

    <div class="modal fade" id="message" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none;">
        <div class="modal-dialog modal-small blue">
            <asp:UpdatePanel ID="upnlmessage" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" id="btnclosemessage1" runat="server">
                            </button>
                            <h4 class="modal-title">
                                Message</h4>
                        </div>
                        <div class="modal-body">
                            <div class="scroller" style="height: 75px" data-always-visible="1" data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="alert alert-danger" id="divreqerrmessage1" runat="server">
                                            <strong>
                                                <asp:Label ID="lblerrorreq1" runat="server"></asp:Label></strong>
                                        </div>
                                        <div class="alert alert-success" id="divreqsucmessage1" runat="server">
                                            <strong>
                                                <asp:Label ID="lblsuccessreq1" runat="server"></asp:Label></strong>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn default" id="btnclosemessage" runat="server">
                                Close</button>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnclosemessage" />
                    <asp:PostBackTrigger ControlID="btnclosemessage1" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <asp:UpdatePanel ID="Upnlprintreceipt" runat="server">
        <ContentTemplate>
            <!-- BEGIN RECEIPT I PRINT-->
            <div class="invoice">
                <div class="row invoice-logo">
                    <div class="col-xs-6 invoice-logo-space">
                        <%--<img src="assets/img/PUCollege/logo.jpg" width ="300px" height ="83px" alt=""/>--%>
                    </div>
                    <div class="col-xs-6">
                        <p>
                            <span class="muted">#<asp:Label ID="lblprintappno" runat="server"></asp:Label>/
                                <asp:Label ID="lblprintdate" runat="server"></asp:Label></span></p>
                    </div>
                </div>
                <hr />
                <div class="row-fluid">
                    <div class="col-xs-4">
                        <h4>
                            Student Name:</h4>
                        <ul class="list-unstyled">
                            <li>
                                <asp:Label ID="lblprintstudentname" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblprintaddress1" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblprintaddress2" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblprintstate" runat="server"></asp:Label></li>
                            <li>
                                <asp:Label ID="lblprintcountry" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblprintpincode"
                                    runat="server"></asp:Label>
                            </li>
                        </ul>
                    </div>
                    <div class="col-xs-4">
                        <h4>
                            <strong>Fee Receipt</strong></h4>
                    </div>
                    <div class="col-xs-4 invoice-payment">
                        <h4>
                            Other Details:</h4>
                        <ul class="list-unstyled">
                            <li><strong>Class:</strong>
                                <asp:Label ID="lblstreamname" runat="server"></asp:Label></li>
                            <li><strong>Subject:</strong> PCMB</li>
                            <li><strong>Academic Year:</strong>
                                <asp:Label ID="lblprintacademicyear" runat="server"></asp:Label></li>
                            <li><strong>SBEntrycode:</strong>
                                <asp:Label ID="lblprintsbentrycode" runat="server"></asp:Label></li>
                            <li><strong>Account code:</strong>
                                <asp:Label ID="lblprintaccid" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-xs-12">
                        <%--<table class="table table-striped table-hover">
						    <thead>
						        <tr>
							        <th>#</th>
							        <th>Particulars</th>
							        <th>Amount</th>
						        </tr>
						    </thead>
						<tbody>
						<tr>
							<td>1</td>
							<td>Tution Fees</td>
							<td>150.00</td>
						</tr>
                        <tr>
							<td>2</td>
							<td>Registration Fees</td>
							<td>21.00</td>
						</tr>
                        <tr>
							<td>3</td>
							<td>Admission Fees</td>
							<td>30.00</td>
						</tr>
                        <tr>
							<td>4</td>
							<td>Sports Fees</td>
							<td>70.00</td>
						</tr>
                        <tr>
							<td>5</td>
							<td>Library & Reading Fees</td>
							<td>150.00</td>
						</tr>
						<tr>
							<td>6</td>
							<td>Cultural Activities</td>
							<td>56.00</td>
						</tr>
                        <tr>
							<td>7</td>
							<td>TWF</td>
							<td>21.00</td>
						</tr>
						</tbody>
						</table>--%>
                        <asp:DataList ID="ddlprintfeereceipt" runat="server" Width="100%" CssClass="table table-striped table-hover"
                            RepeatColumns="2">
                            <HeaderTemplate>
                                <b>#</b></th>
                                <th>
                                    Particulars
                                </th>
                                <th>
                                Amount
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#Container.ItemIndex+1 %></td>
                                <td>
                                    <asp:Label ID="lblparticulars" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblamt" Text='<%#DataBinder.Eval(Container.DataItem, "Bankname")%>'
                                        runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <div class="row-fluid">
                    <%--<div class="col-xs-5">
						<div class="well">
							<address>
							<strong>Mahesh PU College,</strong><br/>
							Kottara Chowki, <br/>
							Ashok Nagar Post,<br/>
                            Mangalore - 575 006<br />
							<abbr title="Phone">P:</abbr> +91 0824 - 2881000 / 2881011 / 2881012 </address>
							<address>
							<strong>Email Name</strong><br/>
							<a href="mailto:#">info@maheshpucmangalaore.com</a><br />
                            

							</address>
						</div>
					</div>--%>
                    <div class="col-xs-7 invoice-block">
                        <ul class="list-unstyled amounts">
                            <li><strong>Sub - Total amount:</strong> 2100.00 </li>
                            <li><strong>Discount:</strong> NA </li>
                            <li><strong>Grand Total:</strong> 2100.00 </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- END RECEIPT I PRINT-->
            <h1>
            </h1>
            <!-- BEGIN RECEIPT II PRINT-->
            <div class="invoice">
                <div class="row invoice-logo">
                    <div class="col-xs-6 invoice-logo-space">
                        <%--<img src="assets/img/PUCollege/logo.jpg" width ="300px" height ="83px" alt=""/>--%>
                    </div>
                    <div class="col-xs-6">
                        <p>
                            <span class="muted">#App No. 14501 / 03 Mar 2014</span></p>
                    </div>
                </div>
                <hr />
                <div class="row-fluid">
                    <div class="col-xs-4">
                        <h4>
                            Student Name:</h4>
                        <ul class="list-unstyled">
                            <li>Vinit S</li>
                            <li>Address 1</li>
                            <li>Address 2</li>
                            <li>State</li>
                            <li>Country </li>
                        </ul>
                    </div>
                    <div class="col-xs-4">
                        <h4>
                            <strong>Hostel Receipt</strong></h4>
                    </div>
                    <div class="col-xs-4 invoice-payment">
                        <h4>
                            Other Details:</h4>
                        <ul class="list-unstyled">
                            <li><strong>Class:</strong> PU-I</li>
                            <li><strong>Subject:</strong> PCMB</li>
                            <li><strong>Admission Date:</strong> 01 March 2014</li>
                            <li><strong>Academic Year:</strong> 2014-2015</li>
                            <li><strong>SBEntrycode:</strong> 0S0012014000001</li>
                            <li><strong>Account code:</strong> 45454DEMO545DEMO</li>
                        </ul>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-xs-12">
                        <table class="table table-striped table-hover">
                            <thead>
                                <tr>
                                    <th>
                                        #
                                    </th>
                                    <th>
                                        Particulars
                                    </th>
                                    <th>
                                        Amount
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        1
                                    </td>
                                    <td>
                                        Caution Deposit
                                    </td>
                                    <td>
                                        10000.00
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        2
                                    </td>
                                    <td>
                                        Hostel Fee
                                    </td>
                                    <td>
                                        25000.00
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-xs-5">
                        <div class="well">
                            <address>
                                <strong>Mahesh PU College,</strong><br />
                                Kottara Chowki,
                                <br />
                                Ashok Nagar Post,<br />
                                Mangalore - 575 006<br />
                                <abbr title="Phone">
                                    P:</abbr>
                                +91 0824 - 2881000 / 2881011 / 2881012
                            </address>
                            <address>
                                <strong>Email Name</strong><br />
                                <a href="mailto:#">info@maheshpucmangalaore.com</a><br />
                                <a href="mailto:#">mangalore@maheshpucollege.com</a>
                            </address>
                        </div>
                    </div>
                    <div class="col-xs-7 invoice-block">
                        <ul class="list-unstyled amounts">
                            <li><strong>Sub - Total amount:</strong> 35000.00 </li>
                            <li><strong>Discount:</strong> NA </li>
                            <li><strong>ST:</strong> ----- </li>
                            <li><strong>Grand Total:</strong> 35000.00 </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- END RECEIPT II PRINT-->
            <h1>
            </h1>
            <!-- BEGIN RECEIPT III PRINT-->
            <div class="invoice">
                <div class="row invoice-logo">
                    <div class="col-xs-6 invoice-logo-space">
                        <%--<img src="assets/img/PUCollege/logo.jpg" width ="300px" height ="83px" alt=""/>--%>
                    </div>
                    <div class="col-xs-6">
                        <p>
                            <span class="muted">#App No. 14501 / 03 Mar 2014</span></p>
                    </div>
                </div>
                <hr />
                <div class="row-fluid">
                    <div class="col-xs-4">
                        <h4>
                            Student Name:</h4>
                        <ul class="list-unstyled">
                            <li>Vinit S</li>
                            <li>Address 1</li>
                            <li>Address 2</li>
                            <li>State</li>
                            <li>Country </li>
                        </ul>
                    </div>
                    <div class="col-xs-4">
                        <h4>
                            <strong>Miscellaneous Receipt</strong></h4>
                    </div>
                    <div class="col-xs-4 invoice-payment">
                        <h4>
                            Other Details:</h4>
                        <ul class="list-unstyled">
                            <li><strong>Class:</strong> PU-I</li>
                            <li><strong>Subject:</strong> PCMB</li>
                            <li><strong>Admission Date:</strong> 01 March 2014</li>
                            <li><strong>Academic Year:</strong> 2014-2015</li>
                            <li><strong>SBEntrycode:</strong> 0S0012014000001</li>
                            <li><strong>Account code:</strong> 45454DEMO545DEMO</li>
                        </ul>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-xs-12">
                        <table class="table table-striped table-hover">
                            <thead>
                                <tr>
                                    <th>
                                        #
                                    </th>
                                    <th>
                                        Particulars
                                    </th>
                                    <th>
                                        Amount
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        1
                                    </td>
                                    <td>
                                        TC / Study Certificates / Conduct Cerificates fees
                                    </td>
                                    <td>
                                        3500.00
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        2
                                    </td>
                                    <td>
                                        Miscellaneous Fees
                                    </td>
                                    <td>
                                        40000.00
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-xs-5">
                        <div class="well">
                            <address>
                                <strong>Mahesh PU College,</strong><br />
                                Kottara Chowki,
                                <br />
                                Ashok Nagar Post,<br />
                                Mangalore - 575 006<br />
                                <abbr title="Phone">
                                    P:</abbr>
                                +91 0824 - 2881000 / 2881011 / 2881012
                            </address>
                            <address>
                                <strong>Email Name</strong><br />
                                <a href="mailto:#">info@maheshpucmangalaore.com</a><br />
                                <a href="mailto:#">mangalore@maheshpucollege.com</a>
                            </address>
                        </div>
                    </div>
                    <div class="col-xs-7 invoice-block">
                        <ul class="list-unstyled amounts">
                            <li><strong>Sub - Total amount:</strong> 43500.00 </li>
                            <li><strong>Discount:</strong> NA </li>
                            <li><strong>ST:</strong> ----- </li>
                            <li><strong>Grand Total:</strong> 43500.00 </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- END RECEIPT III PRINT-->
            <h1>
            </h1>
            <!-- BEGIN RECEIPT IV PRINT-->
            <div class="invoice">
                <div class="row invoice-logo">
                    <div class="col-xs-6 invoice-logo-space">
                        <%--<img src="assets/img/PUCollege/logo.jpg" width ="300px" height ="83px" alt=""/>--%>
                    </div>
                    <div class="col-xs-6">
                        <p>
                            <span class="muted">#App No. 14501 / 03 Mar 2014</span></p>
                    </div>
                </div>
                <hr />
                <div class="row-fluid">
                    <div class="col-xs-4">
                        <h4>
                            Student Name:</h4>
                        <ul class="list-unstyled">
                            <li>Vinit S</li>
                            <li>Address 1</li>
                            <li>Address 2</li>
                            <li>State</li>
                            <li>Country </li>
                        </ul>
                    </div>
                    <div class="col-xs-4">
                        <h4>
                            <strong>Books & Uniform Receipt</strong></h4>
                    </div>
                    <div class="col-xs-4 invoice-payment">
                        <h4>
                            Other Details:</h4>
                        <ul class="list-unstyled">
                            <li><strong>Class:</strong> PU-I</li>
                            <li><strong>Subject:</strong> PCMB</li>
                            <li><strong>Admission Date:</strong> 01 March 2014</li>
                            <li><strong>Academic Year:</strong> 2014-2015</li>
                            <li><strong>SBEntrycode:</strong> 0S0012014000001</li>
                            <li><strong>Account code:</strong> 45454DEMO545DEMO</li>
                        </ul>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-xs-12">
                        <table class="table table-striped table-hover">
                            <thead>
                                <tr>
                                    <th>
                                        #
                                    </th>
                                    <th>
                                        Particulars
                                    </th>
                                    <th>
                                        Amount
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        1
                                    </td>
                                    <td>
                                        Uniform
                                    </td>
                                    <td>
                                        5000.00
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        2
                                    </td>
                                    <td>
                                        Books Fees
                                    </td>
                                    <td>
                                        10000.00
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="col-xs-5">
                        <div class="well">
                            <address>
                                <strong>Mahesh PU College,</strong><br />
                                Kottara Chowki,
                                <br />
                                Ashok Nagar Post,<br />
                                Mangalore - 575 006<br />
                                <abbr title="Phone">
                                    P:</abbr>
                                +91 0824 - 2881000 / 2881011 / 2881012
                            </address>
                            <address>
                                <strong>Email Name</strong><br />
                                <a href="mailto:#">info@maheshpucmangalaore.com</a><br />
                                <a href="mailto:#">mangalore@maheshpucollege.com</a>
                            </address>
                        </div>
                    </div>
                    <div class="col-xs-7 invoice-block">
                        <ul class="list-unstyled amounts">
                            <li><strong>Sub - Total amount:</strong> 15000.00 </li>
                            <li><strong>Discount:</strong> NA </li>
                            <li><strong>ST:</strong> ----- </li>
                            <li><strong>Grand Total:</strong> 15000.00 </li>
                        </ul>
                        <br />
                        <a class="btn btn-lg blue hidden-print" onclick="javascript:window.print();">Print <i
                            class="fa fa-print"></i></a><a class="btn btn-lg green hidden-print">Mail Receipt <i
                                class="fa fa-check"></i></a>
                    </div>
                </div>
            </div>
            <!-- END RECEIPT IV PRINT-->
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- END PAGE CONTENT FOR PRINT RECEIPT-->

</asp:Content>
