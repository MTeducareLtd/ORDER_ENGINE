<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Request_ECS.aspx.cs" Inherits="Request_ECS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">      

        function NumberandCharOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || AsciiValue == 40 || AsciiValue == 41 || AsciiValue == 45)
                event.returnValue = true;
            else
                event.returnValue = false;
        }

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else
                event.returnValue = false;
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
                    ECS Request <span class="divider"></span>
                    <asp:Label ID="lblstudentname" runat="server" ForeColor="DarkRed">- Digambar</asp:Label>
                </h4>
            </li>
        </ul>
        <div id="nav-search">
            <span id="listudentstatus" runat="server"><span id="spanPending" runat="server" class="badge badge-important"
                visible="false">Student Status : Pending</span> <span id="spanCancel" runat="server"
                    class="badge badge-important" visible="false">Student Status : Cancelled</span>
                <span id="spanConfirm" runat="server" class="badge badge-success" visible="false">Student
                    Status : Confirmed</span> </span>
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
            <div id="DivStudent" runat="server">
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
            <%--Ecs Detail--%>
            <div id="DivECSDetail" runat="server" class="row-fluid">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="lblEcsHeader" runat="server" Text="ECS Detail"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <div class="alert alert-error" id="DivEcsError" visible="false" runat="server">
                                    <button type="button" class="close" data-dismiss="alert">
                                        <i class="icon-remove"></i>
                                    </button>
                                    <p>
                                        <strong><i class="icon-remove"></i>Error!</strong>
                                        <asp:Label ID="lblEcsError" runat="server" Text="Label"></asp:Label>
                                    </p>
                                </div>
                                <asp:UpdatePanel ID="UpnladdECSReq" runat="server">
                                    <ContentTemplate>
                                        <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                            id="tblEcsDetail">
                                            <tr>
                                                <td width="10%">
                                                    UMRN
                                                    <%--<asp:Label runat="server" ID="Label4" CssClass="red">*</asp:Label>--%>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtUMRN" runat="server" Width="205px" MaxLength="20" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    ECS Date
                                                </td>
                                                <td width="20%">
                                                    <asp:Label ID="lblECSDate" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td width="10%">
                                                    Sponsor Bank Code
                                                </td>
                                                <td width="20%">
                                                    <asp:Label ID="lblSponsorBankCode" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Utility Code
                                                </td>
                                                <td width="20%">
                                                    <asp:Label ID="lblUtilityCode" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td width="10%">
                                                    Company Name
                                                </td>
                                                <td width="20%">
                                                    <asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td width="10%">
                                                    To Debit
                                                    <asp:Label runat="server" ID="Label3" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlToDebit" runat="server" data-placeholder="Select" Width="215px"
                                                        CssClass="chzn-select">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>SB</asp:ListItem>
                                                        <asp:ListItem>CA</asp:ListItem>
                                                        <asp:ListItem>CC</asp:ListItem>
                                                        <asp:ListItem>SB-NRE</asp:ListItem>
                                                        <asp:ListItem>SB-NRO</asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Period
                                                    <asp:Label runat="server" ID="Label15" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <input readonly="readonly" runat="server" class="id_date_range_picker_1" name="date-range-picker"
                                                        id="txtPeriod" placeholder="Period" data-placement="bottom" data-original-title="Date Range"
                                                        style="width: 205px" />
                                                </td>
                                                <td width="10%">
                                                    Bank A/c No
                                                    <asp:Label runat="server" ID="Label16" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtBankAcNo" runat="server" Width="205px"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    A/c Holder Type
                                                    <asp:Label runat="server" ID="Label18" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlAcountHolderType" runat="server" data-placeholder="Select"
                                                        Width="215px" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlAcountHolderType_SelectedIndexChanged">
                                                        <asp:ListItem>Single</asp:ListItem>
                                                        <asp:ListItem>Joint</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    A/c Holder1 Name
                                                    <asp:Label runat="server" ID="Label4" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtAcountHolderName1" runat="server" Width="205px"></asp:TextBox>
                                                </td>
                                                <td  width="10%" runat="server" visible="false" id="tdAcHld2">
                                                    A/c Holder2 Name
                                                                <asp:Label runat="server" ID="lblAchld2Star" CssClass="red">*</asp:Label>
                                                   
                                                </td>
                                                <td width="20%" runat="server" visible="false" id="tdAcHld2A">
                                                    <asp:TextBox ID="txtAcountHolderName2" runat="server" Width="205px"></asp:TextBox>
                                        </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    MICR No
                                                    <asp:Label runat="server" ID="Label5" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtMICRNo" runat="server" Width="205px" AutoPostBack="true" OnTextChanged="txtMICRNo_TextChanged"
                                                        onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    <asp:Label runat="server" ID="Label6">With Bank</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtWithBank" Enabled="false" runat="server" Width="205px"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    IFSC Code
                                                    <asp:Label runat="server" ID="Label7" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtIFSCCode" runat="server" MaxLength="11" Width="205px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Amount
                                                    <asp:Label runat="server" ID="Label8" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtAmount" runat="server" Width="205px" onkeypress="return NumberOnly(event);"  ></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    Frequency
                                                    <asp:Label runat="server" ID="Label9" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlFrequency" runat="server" data-placeholder="Select" Width="215px"
                                                        CssClass="chzn-select" Enabled="false">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Mthly</asp:ListItem>
                                                        <asp:ListItem>Qtly</asp:ListItem>
                                                        <asp:ListItem>H-Yrly</asp:ListItem>
                                                        <asp:ListItem>Yrly</asp:ListItem>
                                                        <asp:ListItem>As & when presented</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Debit Type
                                                    <asp:Label runat="server" ID="Label10" CssClass="red">*</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlDebitType" runat="server" data-placeholder="Select" Width="215px"
                                                        CssClass="chzn-select" Enabled="false">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Fixed Amount</asp:ListItem>
                                                        <asp:ListItem>Maximum Amount</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    <asp:Label runat="server" ID="Label11">Reference1</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <%--<asp:TextBox ID="txtReference1" runat="server" Width="205px" Enabled="false"></asp:TextBox>--%>
                                                    <asp:Label runat="server" ID="txtReference1"></asp:Label>
                                                </td>
                                                <td width="10%">
                                                    <asp:Label runat="server" ID="Label12">Phone no.</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtPhoneno" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    <asp:Label runat="server" ID="Label13">Reference2</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <%--<asp:TextBox ID="txtReference2" runat="server" Width="205px" Enabled="false"></asp:TextBox>--%>
                                                    <asp:Label runat="server" ID="txtReference2"></asp:Label>
                                                </td>
                                                <td width="10%">
                                                    <asp:Label runat="server" ID="Label14">EmailId</asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtEmailID" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Label runat="server" ID="lblECSID" Visible="false"></asp:Label>
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSave"
                                    Text="Save" ToolTip="Save" OnClick="btnSave_Click" />
                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnEcsRequestClose"
                                        runat="server" ToolTip="Close" onclick="javascript:window.close()">
                                        Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/row-->
    </div>
</asp:Content>
