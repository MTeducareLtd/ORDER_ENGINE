<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Cheque_Management.aspx.cs" Inherits="Cheque_Management" %>

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
                    Cheque Management<span class="divider"></span></h4>
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
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                Period <asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span12" name="date-range-picker"
                                                                    id="id_date_range_picker_1" placeholder="Date Search" data-placement="bottom" style="width: 215px;"
                                                                    data-original-title="Date Range" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                PayMode <asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlpaymode" ValidationGroup ="Validation10" runat="server" Width="215px"
                                                                    data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlpaymode_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlpaymode"
                                                                Text="#" runat="server" ValidationGroup ="Validation10" SetFocusOnError="True" ErrorMessage="Select Paymode"
                                                                InitialValue="Select" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                 
                                            </tr>    
                                            <tr runat="server" id="trChequeTransaction" visible="false">
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label ID="lblChTrNo" runat="server" Text="Cheque No"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtChTrNo" runat="server" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblChTrStatus" runat="server" Text="Cheque Status"></asp:Label>
                                                                <asp:Label ID="Label1" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="ddlChTrStatus"  data-placeholder="Select Status"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="true"></asp:ListBox>
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
                                <td class="span12">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>                               
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%">
                    <HeaderTemplate>                        
                            <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="chkAll_CheckedChanged"
                                                        AutoPostBack="true" />
                                                    <span class="lbl"></span>
                        </th>
                        <th align="left">
                            Student Name
                        </th>
                        <th align="left">
                            SBEntrycode
                        </th>
                        <th align="left">
                            Center Name
                        </th>
                        <th align="left">
                            Product
                        </th>
                        <th align="left">
                            Pay Mode
                        </th>
                        <th align="left">
                            Cheque/DD/Transaction No
                        </th>
                        <th align="left">
                            Instrument Date 
                        </th>
                        <th align="left">
                            Instrument Status 
                        </th>
                        <th align="left">
                            Action
                        </th>
                        <th align="left">
                            ErrorSaveMessage
                    </HeaderTemplate>
                    <ItemTemplate>
                            <asp:CheckBox ID="chkCheck" runat="server"  Checked="false" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"CheckBoxVisibility") == 1 ? true : false%>'
                                    OnCheckedChanged="chkCheck_CheckedChanged" AutoPostBack="true"/>
                            <span class="lbl"></span> 
                        </td>
                        <td>                            
                            <asp:Label ID="lblStudentName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                            <asp:Label ID="lblRowNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RowNum")%>' Visible="false" />
                            
                        </td>
                         <td style="text-align: left;">
                            <asp:Label ID="lblSBEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>'/>
                        </td>
                         <td style="text-align: left;">
                            <asp:Label ID="lblcentername" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CenterName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblProduct" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Product")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblPayMode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PayMode")%>' />                           
                            <asp:Label ID="lblPayModeCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pay_Mode_Code")%>' Visible="false"/>                           
                        </td>
                        <td style="text-align: left;">
                             <asp:Label ID="lblIns_No" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ins_No")%>' />
                             <asp:Label ID="lblReceipt_Num" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Receipt_Num")%>' Visible="false" />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblInstrumentDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InstrumentDate")%>' />
                        </td>  
                        <td style="text-align: left;">
                            <asp:Label ID="lblStatusDesc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StatusDesc")%>' />
                            <asp:Label ID="lblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StatusCode")%>' Visible="false"/>
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlAction" runat="server" Width="215px"
                                data-placeholder="Select" CssClass="chzn-select" Visible="false">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblErrorSaveMessage" runat="server" Text='' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>

                <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                    <!--Button Area -->                           
                    <div class="row-fluid">
                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnSave" runat="server"
                            Text="Save" OnClick="btnSave_Click" />
                    </div>              
                </div>           
           
        </div>
    </div>
     <!--/row-->
</asp:Content>
