<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Petty_Cash_Entry.aspx.cs" Inherits="Petty_Cash_Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function openModalDelete() {
        $('#DivDelete').modal({
            backdrop: 'static'
        })

        $('#DivDelete').modal('show');
    };

    function NumberOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 45 && AsciiValue <= 57))
            event.returnValue = true;
        else
            event.returnValue = false;
    }

    function NumberandCharOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || AsciiValue == 32 || AsciiValue == 95 || AsciiValue == 45 || (AsciiValue >= 48 && AsciiValue <= 57))
            event.returnValue = true;
        else
            event.returnValue = false;
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Petty Cash<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
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
                   <%--   <button runat="server" class="icon-external-share" onclick="Btn_approve_Click" ><i class="icon-share-alt"></i>Send For Approval</button> 
                                    &nbsp;&nbsp;&nbsp;&nbsp;--%>
                                    <asp:Button class="btn btn-small btn-danger" ID="Button1" Visible="true"
                                    runat="server" Text="Send For Approval" OnClick="Btn_approve_Click" />
                               
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
                                                                <asp:Label runat="server" ID="Label15" CssClass="red">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlDivision" Width="215px" ToolTip="Division"
                                                                    data-placeholder="Select Division" CssClass="chzn-select" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label17" CssClass="red">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCenter" Width="215px" ToolTip="Center" data-placeholder="Select Center"
                                                                    CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label1" CssClass="red">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlPeriod" Width="215px" ToolTip="Period" data-placeholder="Select Period"
                                                                    CssClass="chzn-select" AutoPostBack="True" />
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
                                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="btnExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                         Height="25px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
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
                                        <asp:Label runat="server" ID="Label10">Division</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblDivision_Result" class="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label2">Center Name</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblCenter_Result" class="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label3">Period</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblPeriod_Result" class="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                <tr runat="server" id="QuGrid">
                    <td colspan="3" class="span12" style="text-align: left">
                        <asp:UpdatePanel ID="updatepanneladd" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DataList ID="dlGridDisplay" AutoPostBack="true" CssClass="table table-striped table-bordered table-hover"
                                    runat="server" Width="100%" OnItemCommand="dlGridDisplay_ItemCommand" OnSelectedIndexChanged="dlGridDisplay_SelectedIndexChanged"
                                    OnItemDataBound="dlGridDisplay_ItemDataBound">
                                    <HeaderTemplate>
                                        <b>Date </b></th>
                                        <th style="width: 10%; text-align: center;">
                                            Voucher No.
                                        </th>
                                        <th style="width: 15%; text-align: center;">
                                            Expense Type
                                        </th>
                                        <th style="width: 15%; text-align: center;">
                                            Narration
                                        </th>
                                        <th style="width: 15%; text-align: center;">
                                            Name of the person
                                        </th>
                                        <th style="width: 15%; text-align: center;">
                                            Quantity/Description
                                        </th>
                                        <th style="width: 10%; text-align: center; vertical-align: middle;">
                                            Amount
                                        </th>
                                          <th style="width: 30px; text-align: center;">
                                            Action
                                        </th>
                                        <th style="width: 30px; text-align: center; vertical-align: middle;">
                                        </th>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    
                                        <asp:TextBox runat="server" class="span2.5 date-picker" name="date-range-picker"
                                            Text='<%#DataBinder.Eval(Container.DataItem,"TransDate")%>' Width="85%" ID="txttransdate"
                                            Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                            placeholder="Date" data-placement="bottom" data-original-title="Date" />
                                        <asp:Label ID="LBLtxttransdate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"TransDate")%>'
                                            Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'></asp:Label> 
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDLVoucherNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"voucher_no")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                                Width="75%" MaxLength="100" onkeypress="return NumberandCharOnly(event);" />
                                            <asp:Label ID="lblDLVoucherNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"voucher_no")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'></asp:Label> 
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="txtDLExpenseID" Width="15%" data-placeholder="Select"
                                                CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="txtDLExpenseID_SelectedIndexChanged"
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'>
                                            </asp:DropDownList>
                                            <asp:Label ID="txtDLExpenseID1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Expense_Type_ID")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'></asp:Label> 
                                        </td>
                                        <td>
                                            <%--<asp:DropDownList runat="server" ID="lblDLExpenceNarration" Width="200px" data-placeholder="Select"
                                                AutoPostBack="true" 
                                                Enabled="false">
                                            </asp:DropDownList>--%>
                                            <asp:Label ID="lblDLExpenceNarration" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Expense_Narration")%>'
                                                ></asp:Label> 
                                        </td>
                                        
                                        <td style="width: 6%; text-align: center;">
                                            <asp:TextBox ID="txtDLExpenceDoneBy" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Expense_Done_By")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                                Width="85%" />
                                            <asp:Label ID="lblDLExpenceDoneBY" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Expense_Done_By")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'></asp:Label> 
                                        </td>
                                        <td style="width: 6%; text-align: center;">
                                            <asp:TextBox ID="txtDLDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Description")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                                Width="85%" />
                                            <asp:Label ID="lblDLDescription" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Description")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'></asp:Label> 
                                        </td>
                                        <td style="width: 5%; text-align: center;">
                                            <asp:TextBox ID="txtDLAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"amount")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'
                                                Width="85%" onkeypress="return NumberOnly(event);" />
                                            <asp:Label ID="lblDLAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"amount")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'></asp:Label> 
                                        </td>
                            
                                        <td style="text-align: center;">
                                            <asp:LinkButton ID="lnkDLEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Transaction_ID")%>' runat="server"
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowEditButtonFlag") == 1 ? true : false%>'
                                                CommandName="Edit" Height="25px"></asp:LinkButton> 
                                            <asp:LinkButton ID="lnkDLSave" ToolTip="Save" class="btn-small btn-success icon-save"
                                                runat="server" CommandName="Save" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Transaction_ID")%>'
                                                Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowSaveButtonFlag") == 1 ? true : false%>'></asp:LinkButton> 
                                        </td>
                                        <td style="width: 30px; text-align: center; vertical-align: middle;">
                                            <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                    <i class="icon-bolt"></i>
                                                </asp:Panel>
                                            </a>
                                        </td>
                                    </ItemTemplate>
                                </asp:DataList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                </table>
            </div>
               <div id="DivApproval" runat="server" class="dataTables_wrapper" visible="true">

                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="Lblcount" Text="0" />
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
                                        <asp:Label runat="server" ID="lbldivision1">Division</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="Lblresult2_division" class="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="lblcenter2">Center Name</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblresult2_center" class="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="lblperiod2">Period</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblreslut_period2" class="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:DataList ID="dlItemListAuthorise" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" >
                    <HeaderTemplate>
                      
                        <b>Division </b></th>
                        <th>
                            Center
                        </th>
                        <th>
                          Period
                        </th>
                        <th>
                           Amount
                        </th>
                        <th>
                            Approval Status
                        </th>
                              
                    </HeaderTemplate>
                    <ItemTemplate>
                      
                        <asp:Label ID="lbldivision" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"division")%>' />
                        <asp:Label ID="lbldivisioncode" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Divisioncode")%>' />
                        </td>
                        <td  style="width: 20%; text-align: left;">
                            <asp:Label ID="lblcenter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"centername")%>' />
                            <asp:Label ID="lblcentercode" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Center_Code")%>' />
                        </td>
                       <td style="width: 20%; text-align: left;">
                            <asp:Label ID="lblperiod" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"period")%>' /> 
                             <asp:Label ID="lblperiodid" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Period_Id")%>' /> 
                        </td>
                        <td  style="width: 20%; text-align: left;">
                            <asp:Label ID="lblamount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"amount")%>' />
                            <asp:Label ID="Lblvouchertype" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"VOUCHERTYPE")%>' />
                        </td>
                        <td style="width: 25%; text-align: left;">
                            <asp:Label ID="lblstatus" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Approvalstatus")%>' />
                        </td>
                                      
                    </ItemTemplate>
                </asp:DataList>
                 <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="Btnsave2"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="BtnSaveapproval_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="Btnclose3" Visible="true"
                                    runat="server" Text="Close" OnClick="BtnClose_Click" />
                                <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                            </div>
                
            </div>
        </div>
    </div>
</asp:Content>

