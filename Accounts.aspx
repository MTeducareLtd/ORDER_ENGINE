<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Accounts.aspx.cs" Inherits="Accounts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="assets/js/jquery.gritter.min.js"></script>
    <script type="text/javascript" language="javascript">        function ShowToolTip(a) { document.getElementById("div_img").style.visibility = "visible"; document.getElementById("img_tool").src = a.src; document.getElementById("div_img").style.left = event.clientX; document.getElementById("div_img").style.top = event.clientY; document.getElementById("div_img").style.zIndex = "0" } function hideToolTip() { document.getElementById("div_img").style.visibility = "hidden" }</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div class="row-fluid hidden-print">
        <div id="breadcrumbs" class="position-relative">
            <ul class="breadcrumb">
                <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                    class="icon-angle-right"></i></span></li>
                <li>
                    <h5 class="smaller">
                        <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b>
                            <asp:Label ID="lblstudentname" runat="server" ForeColor="DarkRed"></asp:Label></b><small>
                                &nbsp;
                                <asp:Image ID="imgstudentphotodisplay1" runat="server" Height="50px" Width="50px"
                                    Visible="false" onmouseover="ShowToolTip(this)" onmouseout="hideToolTip()" />
                                <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                        <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                        <img alt="" id="imgstudentphotodisplay" runat="server">
                        <span class="divider"></span>
                    </h5>
                </li>
                <li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
                    <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
                <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
                </i><a href="#">
                    <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a> < </li>
                <li class="btn-group" id="liregno" runat="server" visible="false">
                    <button type="button" class="btn purple dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                        data-delay="1000" data-close-others="true" visible="false">
                        <span>Actions </span><i class="fa fa-angle-down"></i>
                    </button>
                    <ul class="dropdown-menu pull-right" role="menu">
                        <li><a id="A2" runat="server" href="#" target="_blank">Manage Statutory Info.</a>
                        </li>
                    </ul>
                </li>
                <li class="btn-group"><a data-loading-text="Loading..." class="demo-loading-btn btn blue"
                    runat="server" visible="false" target="_blank" id="btnviewenrollment" style="margin-right: 197px;
                    position: relative"><i class="fa fa-bullhorn"></i>View Order</a>&nbsp; </li>
            </ul>
            <div id="nav-search">
                <span id="listudentstatus" runat="server"><span id="badgeError" runat="server" class="badge badge-important"
                    visible="false">Student Status : Pending</span> <span id="Span1" runat="server" class="badge badge-important"
                        visible="false">Student Status : Cancelled</span> <span id="badgeSuccess" runat="server"
                            class="badge badge-success" visible="false">Student Status : Confirmed</span>
                    <asp:Label ID="lblstdstaus" runat="server" Visible="false"></asp:Label>
                </span>
                <button type="button" class="btn btn-primary btn-small radius-4 btn-danger" id="btnback"
                    runat="server" onserverclick="btnback_ServerClick">
                    <i class="icon-reply"></i>Back</button>
                <button type="button" class="btn btn-primary btn-small radius-4 btn-danger" id="btnsearchback"
                    runat="server" onserverclick="btnsearchback_ServerClick">
                    <i class="icon-reply"></i>Back to Account Search</button>
                <button type="button" class="btn btn-danger btn-small dropdown-toggle" data-toggle="dropdown"
                    data-hover="dropdown" data-delay="1000" data-close-others="true">
                    Actions <span class="caret"></span>
                </button>
                <ul class="dropdown-menu dropdown-yellow pull-right dropdown-caret dropdown-close"
                    role="menu">
                    <li><a id="btnviewenv" runat="server" target="_blank" visible="false"><i class="fa fa-chain">
                    </i>View Enrollment</a></li>
                    <li><a id="A1" href="I_Card_Print.aspx" runat="server" target="_blank"><i class="icon-printer">
                    </i>I-Card Print</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div id="page-content" class="clearfix">
        <div class="page-content">
            <div id="div_img" style="height: 100px; width: 100px; position: absolute; visibility: hidden">
                <asp:Image ID="Image2" runat="server" class="image" />
            </div>
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-danger" id="divpendingreuesterror" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblpendingreuesterror" runat="server"></asp:Label></strong>
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
            <div class="alert alert-info" id="divLoanStatus" runat="server" visible="false">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblLoanStatus" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-danger" id="divECSStatus_ErrorMessage" runat="server" visible="false">
                <button type="button" class="close" data-dismiss="alert">
                    <i class="icon-remove"></i>
                </button>
                <strong>
                    <asp:Label ID="lblECSStatus_Message" runat="server"></asp:Label></strong>
            </div>
            <asp:UpdatePanel ID="upnlsearch" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div id="tab_1_31" class="row-fluid">
                                <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                    <div class="span12">
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Organization Assignment
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td width="10%">
                                                    Division
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                        Width="215px" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                        Visible="false" Width="215px" ValidationGroup="Grplead12" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Location / Center
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                        Width="215px" AutoPostBack="true" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                </td>
                                                <td width="20%">
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Stream Information
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
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
                                                    Product Category
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlproductcategory" runat="server" AutoPostBack="true" data-placeholder="Select"
                                                        Width="215px" CssClass="chzn-select">
                                                    </asp:DropDownList>
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
                                                    Status
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlorderstatus" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                        Width="215px" AutoPostBack="true">
                                                        <asp:ListItem Value="All" Selected="True">All</asp:ListItem>
                                                        <asp:ListItem Value="01">Pending</asp:ListItem>
                                                        <asp:ListItem Value="03">Confirmed</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Customer Number / SB Entry Code
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtsbentrycode" runat="server" Width="205px" placeholder="Search by SBEntrycode"></asp:TextBox>
                                                </td>
                                                <td width="10%" id="tdapplicationid" runat="server">
                                                    App. Form No
                                                </td>
                                                <td width="20%" id="tdapplicationid1" runat="server">
                                                    <asp:TextBox ID="txtapplicationno" runat="server" Width="205px" placeholder="Search by Application Form No."></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Customer Name
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtstudentname" runat="server" Width="205px" placeholder="Search by Name"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    Active
                                                </td>
                                                <td width="20%" colspan="3">
                                                    <input runat="server" id="Chkactive" name="switch-field-1" type="checkbox" class="ace-switch ace-switch-2"
                                                        checked="checked" />
                                                    <span class="lbl"></span>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:TextBox ID="txtcurrentout" Visible="false" runat="server"></asp:TextBox>
                                        <div class="well" style="text-align: center; background-color: #F0F0F0">
                                            <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" onserverclick="btnsearch_ServerClick"
                                                validationgroup="Grplead12" runat="server">
                                                Search
                                            </button>
                                            <asp:ValidationSummary ID="ValidationSummary17" runat="server" ShowMessageBox="True"
                                                ValidationGroup="Grplead12" ShowSummary="False" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid" id="divsearchresults" runat="server">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-body">
                                                <div class="widget-header widget-hea1der-small header-color-dark">
                                                    <h4 class="smaller">
                                                        <i class="icon-briefcase"></i>Account Search Results</h4>
                                                </div>
                                                <div class="widget-body">
                                                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
                                                        OnItemCommand="Repeater1_ItemCommand">
                                                        <HeaderTemplate>
                                                            <table class="table table-striped table-bordered table-hover Table3">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            Division
                                                                        </th>
                                                                        <th>
                                                                            Location / Center
                                                                        </th>
                                                                        <th>
                                                                            Date
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
                                                                            Cheque O/S
                                                                        </th>
                                                                        <th>
                                                                            Admission Status
                                                                        </th>
                                                                        <th>
                                                                            Photo
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
                                                                    <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblcenter" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Name")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbldate" Text='<%#DataBinder.Eval(Container.DataItem, "EventDate")%>'
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
                                                                    <asp:Label ID="Label43" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
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
                                                                    <asp:Label ID="lblchequeos" Text='<%#DataBinder.Eval(Container.DataItem, "Chqoutstanding")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbladmissionstatus" runat="server" Font-Bold="true"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImagePath")=="" ? "images/studentphoto/no_photo.jpg" : DataBinder.Eval(Container.DataItem, "ImagePath") %>'
                                                                        Width="50px" Height="50px" class="image" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label30" Text='<%#DataBinder.Eval(Container.DataItem, "Adm_Status")%>'
                                                                        runat="server" Visible="false"></asp:Label>&nbsp;
                                                                    <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblpromotedflag" Text='<%#DataBinder.Eval(Container.DataItem, "IsPromote")%>'
                                                                        runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lbladmnreasonid" Text='<%#DataBinder.Eval(Container.DataItem, "Account_Cancel_Reason_Id")%>'
                                                                        runat="server" Visible="false"></asp:Label>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Oppor_Id","Account_Display.aspx?&Oppur_ID={0}") %>'
                                                                        id="btndisplay" runat="server" target="_blank" visible="false" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                        data-rel="tooltip" data-placement="top" title="Display"></a><a href='<%#DataBinder.Eval(Container.DataItem,"Oppor_Id","Opportunity_Add.aspx?&Oppurtunity_code={0}") %>'
                                                                            id="btndisplayopp" runat="server" target="_blank" visible="false" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                                            data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" Visible="false" CommandName="Edit" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                                        data-rel="tooltip" data-placement="top" title="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>'></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkledger" runat="server" CommandName="Ledger" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>'
                                                                        class="btn btn-minier btn-success icon-eye-open tooltip-success" data-rel="tooltip"
                                                                        data-placement="top" title="View Ledger"></asp:LinkButton>
                                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Oppor_Id","Opportunity_Edit.aspx?&Opportunity_Code={0}") %>'
                                                                        id="btneditenroll" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                                        data-rel="tooltip" data-placement="top" title="Edit" runat="server" target="_blank">
                                                                    </a>
                                                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblsbentrycode" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                                        runat="server" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody> </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                    <asp:Label ID="lbloppurid" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblaccountid" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblpromoteflag" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="Upnlviewledger" runat="server" UpdateMode="Conditional">
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
                                <div class="row-fluid" id="div5" runat="server">
                                    <div class="span3">
                                        <div class="widget-box">
                                            <div class="widget-header widget-hea1der-small header-color-dark">
                                                <h5>
                                                    <i class="fa fa-globe"></i>Student Ledger
                                                </h5>
                                            </div>
                                            <div class="widget-body" style="height: 950px; overflow: Auto; overflow-y: hidden;
                                                overflow-x: hidden">
                                                <div class="widget-main">
                                                    <asp:DataList ID="dlstudentledger" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        Height="30">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_description")%>'
                                                                runat="server" class="tooltip-info" data-rel="tooltip" data-placement="left"
                                                                title='<%#DataBinder.Eval(Container.DataItem, "Tooltip")%>' Font-Bold='<%#DataBinder.Eval(Container.DataItem, "BoldFlag")%>'></asp:Label></td>
                                                            <td>
                                                                <div style="float: left; width: 99%; text-align: right">
                                                                    <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amt")%>'
                                                                        runat="server" Font-Bold='<%#DataBinder.Eval(Container.DataItem, "BoldFlag")%>'></asp:Label>
                                                                </div>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span9">
                                        <div class="widget-box">
                                            <div class="widget-header widget-hea1der-small header-color-dark">
                                                <h5>
                                                    <i class="fa fa-anchor"></i>
                                                    <asp:Label ID="lblheadertext" runat="server"></asp:Label>
                                                    <asp:Label ID="lblSubmitBankLoanFlag" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblECS_RequestCreateThenEventFlag" runat="server" Visible="false"></asp:Label>
                                                </h5>
                                                <div class="widget-toolbar">
                                                    <div class="btn-group" id="Div22" runat="server">
                                                        <asp:Image ID="Image3" runat="server" Width="50px" onmouseover="ShowToolTip(this)"
                                                            onmouseout="hideToolTip()" />
                                                    </div>
                                                      <%--<div class="btn-group" id="Div4" runat="server">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnprintRecptforevent"
                                                            runat="server" onserverclick="btnproceedprinteventrecciet_ServerClick" data-rel="tooltip"
                                                            data-placement="top" title="Print Old Receipts">
                                                            <i class="icon-printer"></i>
                                                        </button>
                                                    </div>--%>
                                                    <div class="btn-group" id="Div4" runat="server">
                                                        <a id="aprint2" runat="server" target="_blank" class="btn btn-small btn-primary tooltip-info"
                                                            data-rel="tooltip" data-placement="top"  title="Print old Receipt"><i class="icon-print">
                                                            </i></a>
                                                    </div>

                                                    <div class="btn-group" id="Div18" runat="server">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnadjustment"
                                                            runat="server" onserverclick="btnadjustment_ServerClick" data-rel="tooltip" data-placement="top"
                                                            title="Adjustment">
                                                            <i class="icon-adjust"></i>
                                                        </button>
                                                    </div>

                                                    <div class="btn-group" id="Div21" runat="server">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnuploadphoto"
                                                            runat="server" onserverclick="btnUploadpic_ServerClick" data-rel="tooltip" data-placement="top"
                                                            title="Upload Photo">
                                                            <i class="icon-picture"></i>
                                                        </button>
                                                    </div>
                                                    <div class="btn-group" id="Div10" runat="server">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnrefersh"
                                                            runat="server" onserverclick="btnrefersh_ServerClick" data-rel="tooltip" data-placement="top"
                                                            title="Refresh">
                                                            <i class="icon-refresh"></i>
                                                        </button>
                                                    </div>
                                                    <div class="btn-group" id="Div20" runat="server">
                                                        <a id="aprint" runat="server" target="_blank" class="btn btn-small btn-primary tooltip-info"
                                                            data-rel="tooltip" data-placement="top" title="Print Receipt"><i class="icon-print">
                                                            </i></a>
                                                    </div>
                                                    <div class="btn-group" id="Div17" runat="server">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnorderdtls"
                                                            runat="server" onserverclick="btnorderdtls_ServerClick" data-rel="tooltip" data-placement="top"
                                                            title="View Order">
                                                            <i class="icon-book"></i>
                                                        </button>
                                                    </div>
                                                    <div class="btn-group" id="btnpayment1" runat="server" visible="false">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnaddpayment"
                                                            runat="server" data-rel="tooltip" data-placement="top" title="Add Payment">
                                                            <i class="icon-credit-card"></i>
                                                        </button>
                                                    </div>
                                                    <div class="btn-group" id="btnproceedprint1" runat="server" visible="false">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnproceedprint"
                                                            runat="server" onserverclick="btnproceedprint_ServerClick" data-rel="tooltip"
                                                            data-placement="top" title="Proceed for Print">
                                                            <i class="icon-printer"></i>
                                                        </button>
                                                    </div>
                                                    <div class="btn-group" id="btnproceedECS" runat="server">
                                                        <a id="aEventECS" runat="server" target="_blank" class="btn btn-small btn-primary tooltip-info"
                                                            data-rel="tooltip" data-placement="top" title="ECS"><i class="icon-desktop"></i>
                                                        </a>
                                                    </div>
                                                    <div class="btn-group" id="Div23" runat="server">
                                                        <a id="aEventAfterCourseDuration" runat="server" target="_blank" class="btn btn-small btn-primary tooltip-info"
                                                            title="Event After Course Duration"><i class="icon-desktop"></i></a>
                                                    </div>
                                                    <div class="btn-group" id="btnEvent" runat="server">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" data-toggle="dropdown"
                                                            data-hover="dropdown" data-delay="1000" data-close-others="true" data-rel="tooltip"
                                                            data-placement="top" title="Events">
                                                            <i class="icon-flag"></i>
                                                        </button>
                                                        <ul class="dropdown-menu pull-right">
                                                            <li><a id="aaddsubject" runat="server" target="_blank">Add Product</a></li>
                                                            <li><a id="aremovesubject" runat="server" target="_blank">Remove Product</a></li>
                                                            <li><a id="achangeproduct" runat="server" target="_blank">Change Product</a></li>
                                                            <li><a id="astreamchange" runat="server" target="_blank">Stream Change</a></li>
                                                            <li><a id="apayplanchange" runat="server" target="_blank">Pay Plan Change</a></li>
                                                            <li><a id="atransfer" runat="server" target="_blank">Transfer</a></li>
                                                            <li><a id="apromotestudent" runat="server" onserverclick="apromotestudent_ServerClick">
                                                                Promote Student</a></li>
                                                            <li><a id="achangesubject" runat="server" onserverclick="achangesubject_ServerClick">
                                                                Change Product</a></li>
                                                        </ul>
                                                    </div>
                                                    <div class="btn-group" id="btnrequest" runat="server">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" data-toggle="dropdown"
                                                            data-hover="dropdown" data-delay="1000" data-close-others="true" data-rel="tooltip"
                                                            data-placement="top" title="Request">
                                                            <i class="icon-edit"></i>
                                                        </button>
                                                        <ul class="dropdown-menu pull-right">
                                                            <li><a id="adiscountreq" visible="true"  runat="server" onserverclick="adiscountreq_ServerClick"><i
                                                                class="fa fa-crop"></i>Discount Request</a></li>
                                                            <li><a id="aconcessionreq" visible="true" runat="server" onserverclick="aconcessionreq_ServerClick">
                                                                <i class="fa fa-pencil"></i>Concession Request</a></li>
                                                            <li><a id="awaiverreq" visible="true" runat="server" onserverclick="awaiverreq_ServerClick"><i class="fa fa-suitcase">
                                                            </i>Waiver Request</a></li>
                                                            <li><a id="acanceladdmission" visible="true" runat="server" onserverclick="acanceladdmission_ServerClick">
                                                                <i class="fa fa-clock-o"></i>Admission Cancellation</a></li>
                                                            <li><a id="aconfirmadmission" runat="server" onserverclick="aconfirmadmission_ServerClick">
                                                                <i class="fa fa-pencil"></i>Confirm Admission</a></li>
                                                            <li><a id="arefundrequest" runat="server" onserverclick="arefundrequest_ServerClick">
                                                                <i class="fa fa-chain-broken"></i>Refund Request</a></li>
                                                            <li><a id="abaddebtsrequest" runat="server" onserverclick="abaddebtsrequest_ServerClick">
                                                                <i class="fa fa-chain-broken"></i>Bad Debts Request</a></li>
                                                         <%--   <li><a id="achequereturnrequest" runat="server" onserverclick="aChequereturnrequest_ServerClick">
                                                                <i class="fa fa-clock-o"></i>Cheque Return Request</a></li>--%>
                                                                <li><a id="achequereturnrequest" runat="server">
                                                                <i class="fa fa-clock-o"></i></a></li>
                                                        </ul>
                                                    </div>
                                                    <div class="btn-group" id="btnLoan" runat="server" visible="true">
                                                        <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnBankLoan"
                                                            runat="server" onserverclick="btnBankLoan_ServerClick" data-rel="tooltip" data-placement="top"
                                                            title="Bank Loan">
                                                            <i class="icon-briefcase"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="widget-body" style="height: 950px; overflow: Auto; overflow-y: scroll;
                                                overflow-x: hidden" runat="server" id="divpaydtls">
                                                <div class="widget-main">
                                                    <div class="table-responsive">
                                                        <asp:DataList ID="dlpaymentreceipt" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                            OnItemDataBound="dlpaymentreceipt_ItemDataBound" OnItemCommand="dlpaymentreceipt_ItemCommand"
                                                            Height="20px">
                                                            <HeaderTemplate>
                                                                <b>
                                                                    <center>
Receipt Date</center>
                                                                </b></th>
                                                                <th align="center" style="text-align: center">
                                                                    Payee
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Mode
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Instrument Number
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
                                                                    <asp:LinkButton ID="lnkpayallocate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Instr_Amt")%>'
                                                                        CommandName="Payallocate" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Chequeidno")%>'
                                                                        data-trigger="hover" data-placement="left" data-content="Click here to View Receipt Allocation"></asp:LinkButton>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label361" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location_Description")%>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <asp:Label ID="lblchequestatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ins_Status")%>'></asp:Label></b>
                                                                    <td id="tdprint1" runat="server" visible="false">
                                                                        <asp:LinkButton ID="lnkprint" runat="server" class="btn btn-small btn-warning tooltip-warning"
                                                                            CommandName="Print" data-rel="tooltip" data-placement="top" title="Print" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Chequeidno")%>'><i class="icon-print"></i></asp:LinkButton>
                                                                    </td>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <table id="Table1" class="table table-striped table-bordered table-advance table-hover"
                                                            width="100%" runat="server" visible="false">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        Receipt Allocation
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                        </table>
                                                        <asp:DataList ID="dlallocationtable" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                            <HeaderTemplate>
                                                                <b>
                                                                    <center>
Product Header</center>
                                                                </b></th>
                                                                <th align="center" style="text-align: center">
                                                                    Net Value
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                    Total Received
                                                                </th>
                                                                <th align="center" style="text-align: center">
                                                                Balance
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblproductheader" Text='<%#DataBinder.Eval(Container.DataItem, "voucher_description")%>'
                                                                    runat="server"></asp:Label></td>
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
                                                                    <asp:Label ID="lblproductheadercode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"pricing_procedure_code")%>'
                                                                        Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <div class="span12" id="divpayment" runat="server">
                                                            <div class="table-responsive">
                                                                <asp:DataList ID="dlallocation" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                                                    <HeaderTemplate>
                                                                        <b style="text-align: center">Select</b></th>
                                                                        <th align="center">
                                                                            Product Header
                                                                        </th>
                                                                        <th align="center">
                                                                            Net Value
                                                                        </th>
                                                                        <th align="center">
                                                                            Total Received
                                                                        </th>
                                                                        <th align="center">
                                                                            Balance
                                                                        </th>
                                                                        <th align="center">
                                                                            Current Allocation
                                                                        </th>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk1" runat="server" AutoPostBack="true" /></td>
                                                                        <td>
                                                                            <asp:Label ID="lblproductheader" Text='<%#DataBinder.Eval(Container.DataItem, "voucher_description")%>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblproductvalue" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_amt")%>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lbltotalreceived" Text='<%#DataBinder.Eval(Container.DataItem, "amtreceived")%>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
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
                                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                                    <tr id="tr22" runat="server">
                                                                        <td width="10%">
                                                                            Amount Allocated
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtslipamt" Enabled="false" runat="server" Width="90%" Text="0"></asp:TextBox>
                                                                            <asp:CompareValidator ID="cmpval" runat="server" ControlToValidate="txtslipamt" ErrorMessage="Value is less than cheque value"
                                                                                ControlToCompare="txtchequeamt" Operator="LessThanEqual" ValidationGroup="Val6"
                                                                                SetFocusOnError="true" Text="#"></asp:CompareValidator>
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
                                                                                ErrorMessage="Value is less than cheque value" ControlToCompare="txtddamt" Operator="LessThanEqual"
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
                                                                                ErrorMessage="Value is less than cheque value" ControlToCompare="txtcashamt"
                                                                                Operator="LessThanEqual" ValidationGroup="Val6" SetFocusOnError="true" Text="#"></asp:CompareValidator>
                                                                        </td>
                                                                        <td width="60%">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosepayment"
                                                                    runat="server" onserverclick="btnclosepayment_ServerClick">
                                                                    Close</button>
                                                                <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                                                    id="btnsavepayment" validationgroup="Val6" onserverclick="btnsavepayment_ServerClick">
                                                                    Save
                                                                </button>
                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                                    ValidationGroup="Val6" ShowSummary="False" />
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
                                                                                AutoPostBack="true" ValidationGroup="Val6" OnSelectedIndexChanged="ddlpaymodeedit_SelectedIndexChanged">
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
                                                                                onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"
                                                                                OnTextChanged="txtmicrcodeedit_TextChanged"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtchqnoedit" runat="server" Width="84%" MaxLength="10" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtchequeamtedit" Enabled="false" runat="server" Width="84%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                            <asp:DropDownList ID="ddlpayeeedit" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                                AutoPostBack="true" ValidationGroup="Val60">
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
                                                                            <asp:TextBox ID="txtddnoedit" runat="server" Width="84%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                            <asp:TextBox ID="txtddamtedit" Enabled="false" runat="server" Width="84%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                            <asp:DropDownList ID="ddlpayeeddedit" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                                AutoPostBack="true" ValidationGroup="Val6">
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
                                                                            <asp:TextBox ID="txtcashamtedit" Enabled="false" runat="server" Width="84%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                            <asp:DropDownList ID="ddlpayeecashedit" runat="server" data-placeholder="Select"
                                                                                CssClass="chzn-select" AutoPostBack="true" ValidationGroup="Val6">
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
                                                                <table class="table table-striped table-bordered table-advance table-hover">
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
                                                                <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosepaymentedit"
                                                                    runat="server" onserverclick="btnclosepaymentedit_ServerClick">
                                                                    Close</button>
                                                                <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                                                    id="btnsavepaymentedit" validationgroup="Val60" onserverclick="btnsavepaymentedit_ServerClick">
                                                                    Save
                                                                </button>
                                                                <asp:ValidationSummary ID="ValidationSummary100" runat="server" ShowMessageBox="True"
                                                                    ValidationGroup="Val60" ShowSummary="False" />
                                                                <asp:Label ID="lblreceiptidedit" runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblchequeidno" runat="server" Visible="false"></asp:Label>
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
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="widget-body" style="height: 700px; overflow: Auto" runat="server" id="divorder">
                                                <div class="widget-main">
                                                    <div class="tabbable tabbable-custom tabbable-full-width">
                                                        <ul class="nav nav-tabs">
                                                            <li class="active"><a data-toggle="tab" href="#tab_2_2">Order - Summary</a> </li>
                                                            <li><a data-toggle="tab" href="#tab_1_3">Order - Detailed</a> </li>
                                                            <li class="pull-right"><a id="acloseorder" runat="server" onserverclick="acloseorder_ServerClick">
                                                                <i class="fa fa-chain-broken"></i>Close</a> </li>
                                                        </ul>
                                                        <div class="tab-content">
                                                            <div id="tab_2_2" class="tab-pane active">
                                                                <div class="table-responsive">
                                                                    <asp:DataList ID="dlselective1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                        Height="20px">
                                                                        <HeaderTemplate>
                                                                            <b>
                                                                                <center>
Item</center>
                                                                            </b></th>
                                                                            <th style="text-align: center" width="10%">
                                                                                Unit Price
                                                                            </th>
                                                                            <th style="text-align: center" width="10%">
                                                                                UOM
                                                                            </th>
                                                                            <th style="text-align: center" width="10%">
                                                                                Quantity
                                                                            </th>
                                                                            <th style="text-align: center" width="10%">
                                                                                Amount
                                                                            </th>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "SGR_DESC")%>'
                                                                                runat="server"></asp:Label></td>
                                                                            <td style="text-align: right" width="10%">
                                                                                <asp:Label ID="txtvoucheramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amt")%>'></asp:Label>
                                                                            </td>
                                                                            <td width="10%">
                                                                                <asp:Label ID="lbluomdesc" Text='<%#DataBinder.Eval(Container.DataItem, "Uomname")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: right" width="10%">
                                                                                <asp:Label ID="txtquantity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "qty")%>'></asp:Label>
                                                                            </td>
                                                                            <td align="right" style="text-align: right" width="10%">
                                                                                <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "amount")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </div>
                                                            </div>
                                                            <div id="tab_1_3" class="tab-pane">
                                                                <div class="table-responsive">
                                                                    <asp:DataList ID="dlselective2" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                        Height="20px">
                                                                        <HeaderTemplate>
                                                                            <b>
                                                                                <center>
Event Type</center>
                                                                            </b></th>
                                                                            <th style="text-align: center" width="10%">
                                                                                Event Date
                                                                            </th>
                                                                            <th style="text-align: center" width="40%">
                                                                                Item
                                                                            </th>
                                                                            <th style="text-align: center" width="10%">
                                                                                Unit Price
                                                                            </th>
                                                                            <th style="text-align: center" width="10%">
                                                                                UOM
                                                                            </th>
                                                                            <th style="text-align: center" width="10%">
                                                                                Quantity
                                                                            </th>
                                                                            <th style="text-align: center" width="10%">
                                                                                Amount
                                                                            </th>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label40" Text='<%#DataBinder.Eval(Container.DataItem, "Eventtype")%>'
                                                                                runat="server"></asp:Label>
                                                                            </td>
                                                                            <td width="10%">
                                                                                <asp:Label ID="Label39" Text='<%#DataBinder.Eval(Container.DataItem, "EventDate")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td width="40%">
                                                                                <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "SGR_DESC")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: right" width="10%">
                                                                                <asp:Label ID="txtvoucheramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amt")%>'></asp:Label>
                                                                            </td>
                                                                            <td width="10%">
                                                                                <asp:Label ID="lbluomdesc" Text='<%#DataBinder.Eval(Container.DataItem, "Uomname")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: right" width="10%">
                                                                                <asp:Label ID="txtquantity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "qty")%>'></asp:Label>
                                                                            </td>
                                                                            <td align="right" style="text-align: right" width="10%">
                                                                                <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "amount")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
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
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-header widget-hea1der-small header-color-dark">
                                                <h5>
                                                    <i class="fa fa-anchor"></i>Request Status : <b>
                                                        <asp:Label ID="lblstudentname1" runat="server" ForeColor="WhiteSmoke"></asp:Label></b>
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="table-responsive">
                                                        <asp:DataList ID="dlrequestdetails" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                            Height="20px" OnItemDataBound="dlrequestdetails_ItemDataBound" OnItemCommand="dlrequestdetails_ItemCommand">
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
                                                                    Remarks
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
                                                                    <div style="float: left; width: 99%; text-align: right">
                                                                        <asp:Label ID="lblinstramt" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'
                                                                            runat="server"></asp:Label></div>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblchequestatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"status")%>'></asp:Label>
                                                                    <td>
                                                                        <asp:Label ID="Label41" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"remark")%>'></asp:Label>
                                                                        <td>
                                                                            <asp:Label ID="Label20" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <div id="divreqaction" runat="server">
                                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Sbentrycode","View_Request_Details.aspx?&SBEntrycode={0}")%>&Req_id=<%#DataBinder.Eval(Container.DataItem,"Request_id")%>'
                                                                                    target="_blank" class="btn btn-minier btn-primary icon-edit tooltip-info"><i class="fa fa-eye">
                                                                                    </i></a>
                                                                            </div>
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
                                <div class="row-fluid" id="DivECSStatus" runat="server" visible="false">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-header widget-hea1der-small header-color-dark">
                                                <h5>
                                                    <i class="fa fa-anchor"></i>ECS Status : <b>
                                                        <asp:Label ID="lblstudentname2" runat="server" ForeColor="WhiteSmoke"></asp:Label></b>
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="table-responsive">
                                                        <asp:DataList ID="dlECSdetails" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                            Height="20px">
                                                            <HeaderTemplate>
                                                                <b>Date</b></th>
                                                                <th>
                                                                    Event Name
                                                                </th>
                                                                <th>
                                                                Event Description
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblECSDetaildate" Text='<%#DataBinder.Eval(Container.DataItem, "ECSDetail_date")%>'
                                                                    runat="server"></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblEventName" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Name")%>'
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblEvent_Desc" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Desc")%>'
                                                                        runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="well" style="text-align: center; background-color: #F0F0F0" id="panelclose"
                                    runat="server" visible="false">
                                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnCloseStudentAccount"
                                        runat="server" onserverclick="btnCloseStudentAccount_ServerClick">
                                        Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnCloseStudentAccount" />
                    <asp:PostBackTrigger ControlID="btnclosepayment" />
                    <asp:PostBackTrigger ControlID="btncloseremoverpt" />
                    <asp:PostBackTrigger ControlID="btnremovereceipt" />
                    <asp:PostBackTrigger ControlID="btnsavepayment" />
                    <asp:PostBackTrigger ControlID="btnproceedprint" />
                    <asp:PostBackTrigger ControlID="btnrefersh" />
                    <asp:PostBackTrigger ControlID="btnclosemodalProm" />
                    <asp:PostBackTrigger ControlID="btnclosemodalProm1" />
                    <asp:PostBackTrigger ControlID="apromotestudent" />
                    <asp:PostBackTrigger ControlID="btnSwapClose1" />
                    <asp:PostBackTrigger ControlID="btnSwapClose" />
                    <asp:PostBackTrigger ControlID="btnSaveswap" />
                    <asp:PostBackTrigger ControlID="btnaddprodclose1" />
                    <asp:PostBackTrigger ControlID="btnaddprodclose" />
                    <asp:PostBackTrigger ControlID="btnaddprodsave" />
                    <asp:PostBackTrigger ControlID="btnremoveclose1" />
                    <asp:PostBackTrigger ControlID="btnremoveclose" />
                    <asp:PostBackTrigger ControlID="btnremovesave" />
                    <asp:AsyncPostBackTrigger ControlID="aaddsubject" />
                    <asp:AsyncPostBackTrigger ControlID="aremovesubject" />
                    <asp:PostBackTrigger ControlID="btnclosepayallocate1" />
                    <asp:PostBackTrigger ControlID="btnclosepayallocate" />
                    <asp:AsyncPostBackTrigger ControlID="btnBankLoan" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="PromoteStudent" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" id="btnclosemodalProm1" runat="server">
                    </button>
                    <h4 class="modal-title">
                        Promote Student</h4>
                </div>
                <div class="modal-body" style="overflow: hidden">
                    <div class="scroller" style="height: 400px" data-always-visible="1" data-rail-visible1="1">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="table-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosemodalProm"
                        runat="server">
                        Close</button>
                    <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                        id="Button9" validationgroup="Val6">
                        Save
                    </button>
                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                        ValidationGroup="Val6" ShowSummary="False" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="swapcheque" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" id="btnSwapClose1" runat="server">
                    </button>
                    <h4 class="modal-title">
                        Swap Cheque</h4>
                </div>
                <div class="modal-body" style="overflow: hidden">
                    <div class="scroller" style="height: 400px" data-always-visible="1" data-rail-visible1="1">
                        <div class="row-fluid">
                            <div class="span12" style="overflow: 200px">
                                <div class="table-responsive">
                                    <asp:DataList ID="Dlpendingcheques" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                        Height="20px">
                                        <HeaderTemplate>
                                            <b>Receipt Date</b></th>
                                            <th>
                                                Instrument No.
                                            </th>
                                            <th>
                                                Instrument Date
                                            </th>
                                            <th>
                                                Instrument Amt.
                                            </th>
                                            <th>
                                            Status
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblrecptdate" Text='<%#DataBinder.Eval(Container.DataItem, "ReceiptDate")%>'
                                                runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblinsnum" Text='<%#DataBinder.Eval(Container.DataItem, "Pay_InsNum")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblinstrdate" Text='<%#DataBinder.Eval(Container.DataItem, "Pay_InstrDate")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblinstramt" Text='<%#DataBinder.Eval(Container.DataItem, "Instr_Amt")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblchequestatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ins_Status")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnSwapClose"
                        runat="server">
                        Close</button>
                    <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                        id="btnSaveswap" validationgroup="Val15">
                        Save
                    </button>
                    <asp:ValidationSummary ID="ValidationSummary8" runat="server" ShowMessageBox="True"
                        ValidationGroup="Val15" ShowSummary="False" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="Addproduct" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" id="btnaddprodclose1" runat="server" onserverclick="btnaddprodclose1_ServerClick">
                    </button>
                    <h4 class="modal-title">
                        Add Product</h4>
                </div>
                <div class="modal-body" style="overflow: hidden">
                    <div class="scroller" style="height: 350px; overflow: Auto" data-always-visible="1"
                        data-rail-visible1="1">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="table-responsive">
                                    <asp:DataList ID="dladdproduct" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                        Height="20px">
                                        <HeaderTemplate>
                                            <b>Select</b></th>
                                            <th>
                                                Product
                                            </th>
                                            <th>
                                            Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ckhselect1" runat="server" />
                                            <td>
                                                <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Material_Name")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <asp:Label ID="lblmaterialcodeadd" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Material_Code")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <div class="alert alert-danger" id="Divaddproderror" runat="server">
                                        <strong>
                                            <asp:Label ID="lbladdproderror" runat="server"></asp:Label></strong>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnaddprodclose"
                        runat="server" onserverclick="btnaddprodclose_ServerClick">
                        Close</button>
                    <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                        id="btnaddprodsave" validationgroup="Val26" onserverclick="btnaddprodsave_ServerClick">
                        Save
                    </button>
                    <asp:ValidationSummary ID="ValidationSummary10" runat="server" ShowMessageBox="True"
                        ValidationGroup="Val26" ShowSummary="False" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="payallocate" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" id="btnclosepayallocate1" runat="server" onserverclick="btnclosepayallocate1_ServerClick">
                    </button>
                    <h4 class="modal-title">
                        Receipt Allocation</h4>
                </div>
                <div class="modal-body" style="overflow: hidden">
                    <div class="scroller" data-always-visible="1" data-rail-visible1="1">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="table-responsive">
                                    <asp:DataList ID="dlpayallocation" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                        Height="20px">
                                        <HeaderTemplate>
                                            <b>
                                                <center>
Product Header</center>
                                            </b></th>
                                            <th style="text-align: center">
                                            Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "ppname")%>'
                                                runat="server"></asp:Label></td>
                                            <td align="right">
                                                <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "amountreceived")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosepayallocate"
                        runat="server" onserverclick="btnclosepayallocate_ServerClick">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="Removeproduct" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" id="btnremoveclose1" runat="server" onserverclick="btnremoveclose1_ServerClick">
                    </button>
                    <h4 class="modal-title">
                        Remove Product</h4>
                </div>
                <div class="modal-body" style="overflow: hidden">
                    <div class="scroller" style="height: 350px; overflow: Auto" data-always-visible="1"
                        data-rail-visible1="1">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="table-responsive">
                                    <asp:DataList ID="dlremoveproduct" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                        Height="20px">
                                        <HeaderTemplate>
                                            <b>Select</b></th>
                                            <th>
                                                Product
                                            </th>
                                            <th>
                                            Amount
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ckhselect1" runat="server" />
                                            <td>
                                                <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Material_Name")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <asp:Label ID="lblmaterialcodeadd" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Material_Code")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <div class="alert alert-danger" id="divremoveproderror" runat="server">
                                        <strong>
                                            <asp:Label ID="lblremoveproderror" runat="server"></asp:Label></strong>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnremoveclose"
                        runat="server" onserverclick="btnremoveclose_ServerClick">
                        Close</button>
                    <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                        id="btnremovesave" onserverclick="btnremovesave_ServerClick" validationgroup="val28">
                        Save
                    </button>
                    <asp:ValidationSummary ID="ValidationSummary11" runat="server" ShowMessageBox="True"
                        ValidationGroup="val28" ShowSummary="False" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="Removereceipt" tabindex="-1" role="basic" aria-hidden="true"
        style="display: none" data-keyboard="false" data-backdrop="static" data-keyboard="false"
        data-attention-animation="false">
        <div class="modal-dialog modal-small">
            <div class="modal-content">
                <div class="modal-body" style="overflow: hidden">
                    <div class="scroller" data-always-visible="1" data-rail-visible1="1">
                        <p>
                            <b>
                                <asp:Label ID="lblnote" runat="server" ForeColor="#FF3300"></asp:Label></b>
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btncloseremoverpt"
                        runat="server" onserverclick="btncloseremoverpt_ServerClick">
                        No</button>
                    <button type="button" class="btn btn-app btn-success btn-mini radius-4" id="btnremovereceipt"
                        runat="server" onserverclick="btnremovereceipt_ServerClick">
                        Yes</button>
                    <asp:ValidationSummary ID="ValidationSummary13" runat="server" ShowMessageBox="True"
                        ValidationGroup="Val8" ShowSummary="False" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="divadjustment" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" id="btncloseadjustment" runat="server" onserverclick="btncloseadjustment_ServerClick">
                            </button>
                            <h4 class="modal-title">
                                Adjustment Entry</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 75px; overflow: hidden" data-always-visible="1"
                                data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        Adjustment Amount
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtadjustmentamt" runat="server" Width="90%" ValidationGroup="Val30"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" ControlToValidate="txtadjustmentamt"
                                                            Text="#" runat="server" ValidationGroup="Val30" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator53" ControlToValidate="txtadjustmentamt"
                                                            Text="#" runat="server" ValidationGroup="Val30" SetFocusOnError="True" ErrorMessage="Field cannot be blank" />
                                                        <asp:Label ID="lbladjerror" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btncloseadjustment1"
                                runat="server" onserverclick="btncloseadjustment1_ServerClick">
                                Close</button>
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnsaveadjustment" validationgroup="Val30" onserverclick="btnsaveadjustment_ServerClick">
                                Save
                            </button>
                            <asp:ValidationSummary ID="ValidationSummary15" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val30" ShowSummary="False" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btncloseadjustment1" />
                    <asp:PostBackTrigger ControlID="btncloseadjustment" />
                    <asp:PostBackTrigger ControlID="btnsaveadjustment" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="Discountreq" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="upnldiscount" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" id="btnclosemodalDisc1" runat="server" onserverclick="btnclosemodalDisc1_ServerClick">
                            </button>
                            <h4 class="modal-title">
                                Discount Request</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 600px; overflow: hidden" data-always-visible="1"
                                data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        Discount Request Date
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtDiscrequestdate" runat="server" Width="90%" ValidationGroup="Val9"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Discount Reason
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddldiscountreason" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            ValidationGroup="Val9">
                                                        </asp:DropDownList>
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Product Header
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddlproductheaderdiscount" runat="server" AutoPostBack="true"
                                                            data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Val9" OnSelectedIndexChanged="ddlproductheaderdiscount_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="ddlproductheaderdiscount"
                                                            Text="#" runat="server" ValidationGroup="Val9" SetFocusOnError="True" ErrorMessage="Select Product Header"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Basic Course Fees
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtnetamountdiscount" runat="server" Width="90%" ValidationGroup="Val9"
                                                            Enabled="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator52" ControlToValidate="txtnetamountdiscount"
                                                            Text="#" runat="server" ValidationGroup="Val9" SetFocusOnError="True" ErrorMessage="Field cannot be blank" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Discount Type
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddldiscounttype" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            ValidationGroup="Val9">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddldiscounttype"
                                                            Text="#" runat="server" ValidationGroup="Val9" SetFocusOnError="True" ErrorMessage="Select Discount Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Discount Amount
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtdiscountamt" runat="server" Width="90%" ValidationGroup="Val9"
                                                            AutoPostBack="true" OnTextChanged="txtdiscountamt_TextChanged" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtdiscountamt"
                                                            Text="#" runat="server" ValidationGroup="Val9" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                            ErrorMessage="Enter only Numeric Value" ValidationGroup="Val9" Text="#" SetFocusOnError="true"
                                                            ControlToValidate="txtdiscountamt" ValidationExpression="^[0-9]{1,6}$" />
                                                        <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="txtdiscountamt"
                                                            Type="Integer" ValueToCompare="0" SetFocusOnError="true" ValidationGroup="Val9"
                                                            Operator="GreaterThan" ErrorMessage="Amount cannot be Zero" Text="#"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Discount Amount Excluding Service Tax
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtdiscountamtexcludingst" runat="server" Width="90%" ValidationGroup="Val9"
                                                            Enabled="false"></asp:TextBox>
                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtnetamountdiscount"
                                                            ControlToValidate="txtdiscountamtexcludingst" Type="Integer" SetFocusOnError="true"
                                                            ValidationGroup="Val9" Operator="LessThanEqual" ErrorMessage="Amount cannot be greater than Basic Fees"
                                                            Text="#"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td width="30%">
                                                        Center Remarks
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtDiscremarks" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtDiscremarks"
                                                            Text="#" runat="server" ValidationGroup="Val9" SetFocusOnError="True" ErrorMessage="1 Enter Remarks" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnsavediscreq" validationgroup="Val9" onserverclick="btnsavediscreq_ServerClick">
                                Save
                            </button>
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosemodalDisc"
                                runat="server" onserverclick="btnclosemodalDisc_ServerClick">
                                Close</button>
                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val9" ShowSummary="False" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnclosemodalDisc" />
                    <asp:PostBackTrigger ControlID="btnclosemodalDisc1" />
                    <asp:PostBackTrigger ControlID="btnsavediscreq" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="Concessionreq" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <div class="modal-content">
                <asp:UpdatePanel ID="upnlconcession" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" id="btnclosemodalconc1" runat="server" onserverclick="btnclosemodalconc1_ServerClick">
                            </button>
                            <h4 class="modal-title">
                                Concession Request</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 600px" data-always-visible="1" data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        Concession Request Date
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtconcessionreqdate" runat="server" Width="90%" ValidationGroup="Val8"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Product Header
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddlproductheaderconcession" runat="server" AutoPostBack="true"
                                                            data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Val8" OnSelectedIndexChanged="ddlproductheaderconcession_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="ddlproductheaderconcession"
                                                            Text="#" runat="server" ValidationGroup="Val8" SetFocusOnError="True" ErrorMessage="Select Product Header"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Basic Course Fees
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtnetamountconcession" runat="server" Width="90%" ValidationGroup="Val8"
                                                            Enabled="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator51" ControlToValidate="txtnetamountconcession"
                                                            Text="#" runat="server" ValidationGroup="Val8" SetFocusOnError="True" ErrorMessage="Field cannot be blank" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Concession Type
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddlconcessiontype" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select" ValidationGroup="Val8">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlconcessiontype"
                                                            Text="#" runat="server" ValidationGroup="Val8" SetFocusOnError="True" ErrorMessage="Select Concession Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Concession Amount
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtconcessionamt" runat="server" Width="90%" ValidationGroup="Val8"
                                                            OnTextChanged="txtConcessionamt_TextChanged" AutoPostBack="true" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtconcessionamt"
                                                            Text="#" runat="server" ValidationGroup="Val8" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                            ErrorMessage="Enter only Numeric Value" ValidationGroup="Val8" Text="#" SetFocusOnError="true"
                                                            ControlToValidate="txtconcessionamt" ValidationExpression="^[0-9]{1,6}$" />
                                                        <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtconcessionamt"
                                                            Type="Integer" ValueToCompare="0" SetFocusOnError="true" ValidationGroup="Val8"
                                                            Operator="GreaterThan" ErrorMessage="Amount cannot be Zero" Text="#"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Concession Amount Excluding Service Tax
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtConcessionamtexcludingst" runat="server" Width="90%" ValidationGroup="Val8"
                                                            Enabled="false"></asp:TextBox>
                                                        <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToCompare="txtnetamountconcession"
                                                            ControlToValidate="txtConcessionamtexcludingst" Type="Integer" SetFocusOnError="true"
                                                            ValidationGroup="Val8" Operator="LessThanEqual" ErrorMessage="Amount cannot be greater than Basic Fees"
                                                            Text="#"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Center Remarks
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtconceremarks" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtconceremarks"
                                                            Text="#" runat="server" ValidationGroup="Val8" SetFocusOnError="True" ErrorMessage="2 Enter Remarks" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosemodalconc"
                                runat="server" onserverclick="btnclosemodalconc_ServerClick">
                                Close</button>
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnsaveconcreq" validationgroup="Val8" onserverclick="btnsaveconcreq_ServerClick">
                                Save
                            </button>
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val8" ShowSummary="False" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnclosemodalconc" />
                        <asp:PostBackTrigger ControlID="btnclosemodalconc1" />
                        <asp:PostBackTrigger ControlID="btnsaveconcreq" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="Waiver" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" id="btnclosewaiver1" runat="server" onserverclick="btnclosewaiver1_ServerClick">
                            </button>
                            <h4 class="modal-title blue">
                                Waiver Request</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 300px" data-always-visible="1" data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        Waiver Request Date
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtwaiverrequestdate" runat="server" Width="90%" ValidationGroup="Val25"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Product Header
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddlproductheaderwaiver" runat="server" AutoPostBack="true"
                                                            data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Val25" OnSelectedIndexChanged="ddlproductheaderwaiver_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlproductheaderwaiver"
                                                            Text="#" runat="server" ValidationGroup="Val25" SetFocusOnError="True" ErrorMessage="Select Product Header"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trwaiver1" visible="false">
                                                    <td width="30%">
                                                        Net Amount
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtnetamountwaiver" runat="server" Width="90%" ValidationGroup="Val25"
                                                            Enabled="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator50" ControlToValidate="txtnetamountwaiver"
                                                            Text="#" runat="server" ValidationGroup="Val25" SetFocusOnError="True" ErrorMessage="Field cannot be blank" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Waiver Type
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddlwaivertype" AutoPostBack="true" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select" ValidationGroup="Val25" OnSelectedIndexChanged="ddlwaivertype_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="ddlwaivertype"
                                                            Text="#" runat="server" ValidationGroup="Val25" SetFocusOnError="True" ErrorMessage="Select Waiver Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Waiver Type Amount
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtwaivermaxamt" runat="server" Width="90%" ValidationGroup="Val25"
                                                            Enabled="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator56" ControlToValidate="txtwaivermaxamt"
                                                            Text="#" runat="server" ValidationGroup="Val25" SetFocusOnError="True" ErrorMessage="Field cannot be blank" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Waiver Amount
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtwaiveramt" runat="server" Width="90%" ValidationGroup="Val25"
                                                            onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="txtwaiveramt"
                                                            Text="#" runat="server" ValidationGroup="Val25" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                            ErrorMessage="Enter only Numeric Value" ValidationGroup="Val25" Text="#" SetFocusOnError="true"
                                                            ControlToValidate="txtwaiveramt" ValidationExpression="^[0-9]{1,10}$" />
                                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtwaivermaxamt"
                                                            Type="Integer" ControlToValidate="txtwaiveramt" SetFocusOnError="true" ValidationGroup="Val25"
                                                            Operator="LessThanEqual" ErrorMessage="Requested Amount cannot be greater than Waiver Type Amount"
                                                            Text="#"></asp:CompareValidator>
                                                        <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="txtwaivermaxamt"
                                                            Type="Integer" ValueToCompare="0" SetFocusOnError="true" ValidationGroup="Val25"
                                                            Operator="GreaterThan" ErrorMessage="Amount cannot be Zero" Text="#"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Center Remarks
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtwaiverremark" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="txtwaiverremark"
                                                            Text="#" runat="server" ValidationGroup="Val25" SetFocusOnError="True" ErrorMessage="Enter Remarks" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosewaiver"
                                runat="server" onserverclick="btnclosewaiver_ServerClick">
                                Close</button>
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnsavewaiver" validationgroup="Val25" onserverclick="btnsavewaiver_ServerClick">
                                Save
                            </button>
                            <asp:ValidationSummary ID="ValidationSummary12" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val25" ShowSummary="False" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnclosewaiver1" />
                    <asp:PostBackTrigger ControlID="btnclosewaiver" />
                    <asp:PostBackTrigger ControlID="btnsavewaiver" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="Baddebts" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header blue">
                            <button type="button" class="close" id="btnbaddebtsclose1" runat="server" onserverclick="btnbaddebtsclose1_ServerClick">
                            </button>
                            <h4 class="modal-title blue">
                                Bad Debts Request</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 300px" data-always-visible="1" data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        Bad Debts Request Date
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtbaddebtdate" runat="server" Width="90%" ValidationGroup="Val27"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Amount
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtamtbaddebts" runat="server" Width="90%" ValidationGroup="Val27"
                                                            onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="txtamtbaddebts"
                                                            Text="#" runat="server" ValidationGroup="Val27" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                                            ErrorMessage="Enter only Numeric Value" ValidationGroup="Val27" Text="#" SetFocusOnError="true"
                                                            ControlToValidate="txtamtbaddebts" ValidationExpression="^[0-9]{1,10}$" />
                                                        <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtamtbaddebts"
                                                            Type="Integer" ValueToCompare="0" SetFocusOnError="true" ValidationGroup="Val27"
                                                            Operator="GreaterThan" ErrorMessage="Amount cannot be Zero" Text="#"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Center Remarks
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtcenterremarksbaddebts" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="txtcenterremarksbaddebts"
                                                            Text="#" runat="server" ValidationGroup="Val27" SetFocusOnError="True" ErrorMessage="4 Enter Remarks" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnbaddebtsclose"
                                runat="server" onserverclick="btnbaddebtsclose_ServerClick">
                                Close</button>
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnbaddebtssave" validationgroup="Val27" onserverclick="btnbaddebtssave_ServerClick">
                                Save
                            </button>
                            <asp:ValidationSummary ID="ValidationSummary16" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val27" ShowSummary="False" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnbaddebtsclose1" />
                    <asp:PostBackTrigger ControlID="btnbaddebtsclose" />
                    <asp:PostBackTrigger ControlID="btnbaddebtssave" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="Refund" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" id="btnrefundclose1" runat="server" onserverclick="btnrefundclose1_ServerClick">
                            </button>
                            <h4 class="modal-title">
                                Refund Request</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 300px" data-always-visible="1" data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        Refund Request Date
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtrefunddate" runat="server" Width="90%" ValidationGroup="Val12"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Product Header
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddlproductheaderrefund" runat="server" AutoPostBack="true"
                                                            data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Val12" OnSelectedIndexChanged="ddlproductheaderrefund_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddlproductheaderrefund"
                                                            Text="#" runat="server" ValidationGroup="Val12" SetFocusOnError="True" ErrorMessage="Select Product Header"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Net Amount Cleared
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtnetamountrefund" runat="server" Width="90%" ValidationGroup="Val12"
                                                            Enabled="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator49" ControlToValidate="txtnetamountrefund"
                                                            Text="#" runat="server" ValidationGroup="Val12" SetFocusOnError="True" ErrorMessage="Field cannot be blank" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Refund Type
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="ddlrefundtype" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            ValidationGroup="Val12">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="ddlrefundtype"
                                                            Text="#" runat="server" ValidationGroup="Val12" SetFocusOnError="True" ErrorMessage="Select Refund Type"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Refund Amount
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtrefundamount" runat="server" Width="90%" ValidationGroup="Val12" Enabled="false"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                            ErrorMessage="Enter only Numeric Value" ValidationGroup="Val12" Text="#" SetFocusOnError="true"
                                                            ControlToValidate="txtrefundamount" ValidationExpression="^[0-9]{1,10}$" />
                                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="txtnetamountrefund"
                                                            ControlToValidate="txtrefundamount" Type="Integer" SetFocusOnError="true" ValidationGroup="Val12"
                                                            Operator="LessThanEqual" ErrorMessage="Amount cannot be greater than Net Value"
                                                            Text="#"></asp:CompareValidator>
                                                        <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtrefundamount"
                                                            Type="Integer" ValueToCompare="0" SetFocusOnError="false"  ValidationGroup="Val12"
                                                            Operator="GreaterThan" ErrorMessage="Amount cannot be Zero" Text="#"></asp:CompareValidator>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="txtrefundamount"
                                                            Text="#" runat="server" ValidationGroup="Val12" SetFocusOnError="True" ErrorMessage="Enter Amount" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Center Remarks
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtrefundcenter" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtrefundcenter"
                                                            Text="#" runat="server" ValidationGroup="Val12" SetFocusOnError="True" ErrorMessage="5 Enter Remarks" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnrefundclose"
                                runat="server" onserverclick="btnrefundclose_ServerClick">
                                Close</button>
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="Btnrefundsave" validationgroup="Val12" onserverclick="Btnrefundsave_ServerClick">
                                Save
                            </button>
                            <asp:ValidationSummary ID="ValidationSummary9" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val12" ShowSummary="False" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnrefundclose1" />
                    <asp:PostBackTrigger ControlID="btnrefundclose" />
                    <asp:PostBackTrigger ControlID="Btnrefundsave" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="AdmissionCancel" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="upnladmission" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" id="btncancelclose1" runat="server" onserverclick="btncancelclose1_ServerClick">
                            </button>
                            <h4 class="modal-title">
                                Admission Cancellation Request</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 600px" data-always-visible="1" data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        Cancel Request Date
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtcanceldate" runat="server" Width="90%" ValidationGroup="Val10"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                    <tr>
                                                    <td width="30%">
                                                        Cancellation Reason
                                                    </td>
                                                    <td width="70%">
                                                        <asp:DropDownList ID="DDLCancellationReson" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                            ValidationGroup="Val9">
                                                        </asp:DropDownList>
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Center Remarks
                                                    </td>
                                                    <td width="70%">
                                                        <asp:TextBox ID="txtcancelcenterremarks" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="txtcancelcenterremarks"
                                                            Text="#" runat="server" ValidationGroup="Val10" SetFocusOnError="True" ErrorMessage="6 Enter Remarks" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Components
                                                    </td>
                                                    <td width="70%">
                                                        <asp:CheckBox ID="chkcourseregistration" runat="server" /><span class="lbl"></span>
                                                        Remove Course Registration Fees<br />
                                                        <asp:CheckBox ID="CheckBox1" runat="server" /><span class="lbl"></span> Remove Content
                                                        Price
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%">
                                                        Cancellation Type
                                                    </td>
                                                    <td width="70%">
                                                          <asp:DropDownList ID="IsRefundApplicabale" runat="server" data-placeholder="Select"
                                                                        CssClass="chzn-select" AutoPostBack="true">
                                                                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">With refund</asp:ListItem>
                                                                        <asp:ListItem Value="2">Without refund</asp:ListItem>
                                                                         <asp:ListItem Value="3">Internal refund</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="IsRefundApplicabale"
                                                                        Text="#" runat="server" ValidationGroup="Val3" SetFocusOnError="True" ErrorMessage="Select Refund Status"
                                                                        InitialValue="0" />
                                                    </td>
                                                </tr>
                                                <%--<tr runat="server" id="IsInternalRefund" visible="false" >
                                                    <td width="30%">
                                                        Is Internal Refund
                                                    </td>
                                                    <td width="70%">
                                                          <asp:DropDownList ID="DDlISINTERNALREFUND" runat="server" data-placeholder="Select"
                                                                        CssClass="chzn-select" AutoPostBack="true">
                                                                        <asp:ListItem Value="-0" Selected="True">Select</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DDlISINTERNALREFUND"
                                                                        Text="#" runat="server" ValidationGroup="Val3" SetFocusOnError="True" ErrorMessage="Select Refund Type"
                                                                        InitialValue="0" />
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btncancelclose"
                                runat="server" data-dismiss="modal" onserverclick="btncancelclose_ServerClick">
                                Close</button>
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btncancelsave" validationgroup="Val10" onserverclick="btncancelsave_ServerClick">
                                Save
                            </button>
                            <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val10" ShowSummary="False" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btncancelclose1" />
                    <asp:PostBackTrigger ControlID="btncancelclose" />
                    <asp:PostBackTrigger ControlID="btncancelsave" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="message" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="upnlmessage" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" id="btnclosemessage1" runat="server" onserverclick="btnclosemessage1_ServerClick">
                            </button>
                            <h4 class="modal-title">
                                Message</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
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
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosemessage"
                                runat="server" onserverclick="btnclosemessage_ServerClick">
                                Close</button>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnclosemessage" />
                    <asp:PostBackTrigger ControlID="btnclosemessage1" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="Chequereturn" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header blue">
                            <button type="button" class="close" id="Button1" runat="server">
                            </button>
                            <h4 class="modal-title blue">
                                Cheque Return Request</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 400px" data-always-visible="1" data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="50%">
                                                        Cheque Return Request Date
                                                    </td>
                                                    <td width="50%">
                                                        <asp:TextBox ID="txtchequeretuendate" runat="server" Width="90%" ValidationGroup="Val35"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%">
                                                        Return Reason
                                                    </td>
                                                    <td width="50%">
                                                        <asp:DropDownList ID="ddlreturnreason" AutoPostBack="true" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select" ValidationGroup="Val25">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator59" ControlToValidate="ddlreturnreason"
                                                            Text="#" runat="server" ValidationGroup="Val35" SetFocusOnError="True" ErrorMessage="Select Return Reason"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%">
                                                        Cheque Number
                                                    </td>
                                                    <td width="50%">
                                                        <asp:DropDownList ID="ddlchequenumber" AutoPostBack="true" runat="server" data-placeholder="Select"
                                                            CssClass="chzn-select" ValidationGroup="Val25" OnSelectedIndexChanged="ddlchequenumber_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator57" ControlToValidate="ddlchequenumber"
                                                            Text="#" runat="server" ValidationGroup="Val35" SetFocusOnError="True" ErrorMessage="Select Cheque Number"
                                                            InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%">
                                                        Cheque Amount
                                                    </td>
                                                    <td width="50%">
                                                        <asp:TextBox ID="txtchequeamountreturn" runat="server" Width="90%" ValidationGroup="Val35"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%">
                                                        Center Remarks
                                                    </td>
                                                    <td width="50%">
                                                        <asp:TextBox ID="txtchequereturnremarks" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator58" ControlToValidate="txtchequereturnremarks"
                                                            Text="#" runat="server" ValidationGroup="Val35" SetFocusOnError="True" ErrorMessage="Enter Remarks" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnChequereturnrequest"
                                runat="server" onserverclick="btnChequereturnrequest_ServerClick">
                                Close</button>
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnChequereturnrequesssave" validationgroup="Val35" onserverclick="btnChequereturnrequesssave_ServerClick">
                                Save
                            </button>
                            <asp:ValidationSummary ID="ValidationSummary18" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val35" ShowSummary="False" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnChequereturnrequesssave" />
                    <asp:PostBackTrigger ControlID="btnChequereturnrequest" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="UploadPic" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" id="Button2" runat="server" onserverclick="btnclosemodalDisc1_ServerClick">
                            </button>
                            <h4 class="modal-title">
                                Photo Upload</h4>
                        </div>
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
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 100px; overflow: hidden" data-always-visible="1"
                                data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        <asp:Label runat="server" ID="Label44">Select File</asp:Label>&nbsp;<span class="help-button ace-popover"
                                                            data-trigger="hover" data-placement="right" data-content="Select a Image file using Browse button"
                                                            title="Select File">?</span>
                                                    </td>
                                                    <td width="70%">
                                                        <asp:FileUpload ID="fileContact" runat="server" Width="70%" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnsaveUploadpic" onserverclick="btnsaveUploadpic_ServerClick" validationgroup="Val60">
                                Save
                            </button>
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnCloseUploadpic"
                                runat="server" onserverclick="btnclosemodalUploadpic_ServerClick">
                                Close</button>
                            <asp:ValidationSummary ID="ValidationSummary19" runat="server" ShowMessageBox="True"
                                ValidationGroup="Val60" ShowSummary="False" />
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsaveUploadpic" />
                    <asp:PostBackTrigger ControlID="btnCloseUploadpic" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="DivBankLoan" style="left: 50%!important; top: 30%!important;
        display: none" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="upnlBankLoan" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                Bank Loan
                            </h4>
                        </div>
                        <div class="modal-body">
                            <table cellpadding="2" class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <td class="span4" style="text-align: left">
                                        <table cellpadding="0" style="border-style: none" class="table-hover" width="100%">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%">
                                                    <asp:Label runat="server" Font-Bold="false" ID="lbl1" Text="Apply For Bank Loan" />
                                                    <asp:Label runat="server" Font-Bold="false" ID="lblBankLoanFlag" Visible="false"
                                                        Text="" />
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%">
                                                    <label>
                                                        <input runat="server" id="chkLoanFlag" name="switch-field-1" type="checkbox" class="ace-switch ace-switch-2"
                                                            checked="checked" />
                                                        <span class="lbl"></span>
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%">
                                                    <asp:Label runat="server" Font-Bold="false" ID="Label45" Text="Date" />
                                                    <asp:Label runat="server" Font-Bold="false" ID="lblLoanDate" Visible="false" Text="" />
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%">
                                                    <input readonly="readonly" class="span2 date-picker" id="txtLoanDate" runat="server"
                                                        type="text" data-date-format="dd M yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator60" ControlToValidate="txtLoanDate"
                                                        Text="#" runat="server" ValidationGroup="ValBankLoan" SetFocusOnError="True"
                                                        ErrorMessage="Date Cannot be blank...!" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <center />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnLoanSave" validationgroup="ValBankLoan" onserverclick="btnLoanSave_Click">
                                Save
                            </button>
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                                ID="btnLoan_Close" ToolTip="Close" runat="server" Text="Close" OnClick="btnLoan_Close_Click" />
                            <asp:ValidationSummary ID="ValidationSummary20" runat="server" ShowMessageBox="True"
                                ValidationGroup="ValBankLoan" ShowSummary="False" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnLoanSave" />
                        <asp:PostBackTrigger ControlID="btnLoan_Close" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="Confirmadmission" tabindex="-1" role="basic" aria-hidden="true"
        data-keyboard="false" style="display: none">
        <div class="modal-dialog modal-small">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" id="btnclosemodalConfirmadmission1" runat="server"
                                onserverclick="btnclosemodalConfirmadmission1_ServerClick">
                            </button>
                            <h4 class="modal-title">
                                Confirm Admission</h4>
                        </div>
                        <div class="modal-body" style="overflow: hidden">
                            <div class="scroller" style="height: 50px" data-always-visible="1" data-rail-visible1="1">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="table-responsive">
                                            <asp:Label ID="lbltext" runat="server" CssClass="red" Font-Bold="true" Font-Size="Medium"><B>You are about to confirm the admission without all receipts.<br />
Click proceed to continue.<br />
</B>
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer" style="text-align: center">
                            <button type="button" class="btn btn-app btn-primary btn-mini radius-4" id="btnclosemodalConfirmadmission"
                                runat="server" onserverclick="btnclosemodalConfirmadmission_ServerClick">
                                Close</button>
                            <button type="button" class="btn btn-app btn-success btn-mini radius-4" runat="server"
                                id="btnsaveConfirmadmission" onserverclick="btnsaveConfirmadmission_ServerClick">
                                Proceed
                            </button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnclosemodalConfirmadmission" />
                        <asp:PostBackTrigger ControlID="btnclosemodalConfirmadmission" />
                        <asp:PostBackTrigger ControlID="btnsaveConfirmadmission" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">/*<![CDATA[*/function ShowpImagePreview(b){if(b.files&&b.files[0]){var a=new FileReader();a.onload=function(c){$("#ImgPrv").attr("src",c.target.result)};a.readAsDataURL(b.files[0])}}function openModalBankLoan(){$("#DivBankLoan").modal({backdrop:"static"});$("#DivBankLoan").modal("show")};/*]]>*/</script>
</asp:Content>
