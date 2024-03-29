﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Receive_Payment.aspx.cs" Inherits="Receive_Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

 <script type="text/javascript">
     function NumberOnly() {
         var AsciiValue = event.keyCode
         if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
             event.returnValue = true;
         else
             event.returnValue = false;
     };
 
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <ul class="breadcrumb">
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
            <li id="limidbreadcrumb" runat="server" visible="false"><a href="Manage_payments.aspx">
                <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
            <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
            </i><a href="#">
                <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
        </ul>
        <div id="nav-search">
            <span id="listudentstatus" runat="server"><span id="badgeError" runat="server" class="badge badge-important"
                visible="true">Student Status : Pending</span> <span id="badgeSuccess" runat="server"
                    class="badge badge-success" visible="false">Student Status : Confirmed</span>
                <span id="Span1" runat="server" class="badge badge-important" visible="true">Student
                    Status : Cancelled</span>
                <asp:Label ID="lblstdstaus" runat="server" Visible="false"></asp:Label>
            </span>
        </div>
    </div>
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
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                <div class="span12">
                                    <div class="table-responsive">
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
                                                    Company
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcompany" runat="server" Width="90%" ValidationGroup="Grplead12"
                                                        OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Division
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddldivision" runat="server" Width="90%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Zone/Area
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlzone" runat="server" Width="90%" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Location / Center
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcenter" runat="server" Width="90%" AutoPostBack="true" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Customer Information
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td width="10%">
                                                    Customer Type
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcustomertypesearch" runat="server" Width="95%" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Institution Type
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlinstitutionsearch" runat="server" Width="95%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlinstitutionsearch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Board
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlboardsearch" runat="server" Width="95%" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Standard
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlstandardsearch" runat="server" Width="95%" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Student Name
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtstudentname" runat="server" Width="90%" placeholder="Search by Name"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    Handphone
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txthandphonesearch" runat="server" Width="90%" placeholder="Search by Handphone 1"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">
                                                        Customer Residential Information
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td width="10%">
                                                    Country
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcountrysearch" runat="server" Width="90%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlcountrysearch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    State
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlstatesearch" runat="server" Width="90%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlstatesearch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    City
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcitysearch" runat="server" Width="90%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlcitysearch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Location
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddllocationsearch" runat="server" Width="90%" AutoPostBack="true">
                                                    </asp:DropDownList>
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
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlacademicyear" runat="server" Width="90%" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Product Category
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlproductcategory" runat="server" AutoPostBack="true" Width="90%">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Product
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlstream" runat="server" Width="90%" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Event
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlevent" runat="server" Width="90%" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    From
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txteventdatefrom" runat="server" Width="90%"></asp:TextBox>
                                                    <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txteventdatefrom"
                                                        DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                    </CC1:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txteventdatefrom"
                                                        ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                        ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td width="10%">
                                                    To
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txteventdateto" runat="server" Width="90%"></asp:TextBox>
                                                    <CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txteventdateto"
                                                        DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                    </CC1:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txteventdateto"
                                                        ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                        ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Order Status
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlorderstatus" runat="server" Width="90%" AutoPostBack="true">
                                                        <asp:ListItem Value="All" Selected="True">All</asp:ListItem>
                                                        <asp:ListItem Value="03">Pending</asp:ListItem>
                                                        <asp:ListItem Value="01">Confirmed</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">
                                                    Account Code (SBEntrycode)
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txtsbentrycode" runat="server" Width="90%" placeholder="Search by Account Code"></asp:TextBox>
                                                </td>
                                                <td width="10%">
                                                    Active
                                                </td>
                                                <td width="20%">
                                                    <asp:CheckBox ID="Chkactive" runat="server" Checked="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">
                                                    Show Only Promoted
                                                </td>
                                                <td width="20%">
                                                    <asp:CheckBox ID="chkpromoted" runat="server" />
                                                </td>
                                            </tr>
                                            <tr id="tr69" runat="server" visible="false">
                                                <td width="10%" id="tdapplicationid" runat="server">
                                                    App. No
                                                </td>
                                                <td width="20%" id="tdapplicationid1" runat="server">
                                                    <asp:TextBox ID="txtapplicationno" runat="server" Width="90%" placeholder="Search by Application No."></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" onserverclick="btnsearch_ServerClick"
                                            validationgroup="Grplead12" runat="server">
                                            Search
                                        </button>
                                        <%--<asp:ValidationSummary ID="ValidationSummary8" runat="server" ShowMessageBox="True" Validationgroup="Grplead12" ShowSummary="False" />--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid" id="divsearchresults" runat="server">
                                <div class="span12">
                                    <div class="widget-box">
                                        <div class="widget-header">
                                            <h5>
                                                Account Search Results
                                            </h5>
                                        </div>
                                        <div class="widget-body">
                                            <div class="widget-main">
                                                <asp:DataList ID="dlsearch" runat="server" Width="100%" DataKeyField="Cur_sb_code"
                                                    CssClass="table table-striped table-bordered table-hover" OnItemDataBound="dlsearch_ItemDataBound"
                                                    OnItemCommand="dlsearch_ItemCommand">
                                                    <HeaderTemplate>
                                                        <b>Event</b></th>
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
                                                            Customer Name
                                                        </th>
                                                        <th>
                                                            Product
                                                        </th>
                                                        <th>
                                                            Net Amount
                                                        </th>
                                                        <th>
                                                            Cheque O/S
                                                        </th>
                                                        <%--<th>Adm. Status</th>--%>
                                                        <th>
                                                            Action
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldivision" Text='<%#DataBinder.Eval(Container.DataItem, "Event_Description")%>'
                                                            runat="server"></asp:Label></td>
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
                                                            <asp:Label ID="lblcustomername" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblproduct" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                                runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <div style="float: left; width: 99%; text-align: right">
                                                                <asp:Label ID="lblnetamt" Text='<%#DataBinder.Eval(Container.DataItem, "Netamt")%>'
                                                                    runat="server"></asp:Label></div>
                                                        </td>
                                                        <td>
                                                            <div style="float: left; width: 99%; text-align: right">
                                                                <asp:Label ID="lblchequeos" CssClass="rightAlign" Text='<%#DataBinder.Eval(Container.DataItem, "Chqoutstanding")%>'
                                                                    runat="server"></asp:Label></div>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label30" Text='<%#DataBinder.Eval(Container.DataItem, "Adm_Status")%>'
                                                                runat="server" Visible="false"></asp:Label>&nbsp;
                                                            <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
                                                            <asp:Label ID="Label6" runat="server"></asp:Label>
                                                            <asp:Label ID="lblpromotedflag" Text='<%#DataBinder.Eval(Container.DataItem, "IsPromote")%>'
                                                                runat="server" Visible="false"></asp:Label>
                                                            <a href='<%#DataBinder.Eval(Container.DataItem,"Oppor_Id","Account_Display.aspx?&Oppur_ID={0}") %>'
                                                                id="btndisplay" runat="server" target="_blank" class="btn default btn-xs green"
                                                                visible="false"><i class="fa fa-eye"></i>Display</a> <a href='<%#DataBinder.Eval(Container.DataItem,"Oppor_Id","Account_Edit.aspx?&Oppur_ID={0}") %>'
                                                                    id="btneditenroll" runat="server" target="_blank" class="btn default btn-xs purple"
                                                                    visible="false"><i class="fa fa-edit"></i>Edit</a>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" Visible="false" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>'></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkledger" runat="server" class="btn default btn-xs green" CommandName="Ledger"
                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>'><i class="fa fa-eye"></i> Receive</asp:LinkButton>
                                                        <td id="Td1" runat="server" visible="false">
                                                            <asp:Label ID="lblsbentrycode" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                                runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <asp:Label ID="lbloppurid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblaccountid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblpromoteflag" runat="server" Visible="false"></asp:Label>
                                                <div class="pagination">
                                                    <div class="results">
                                                        <asp:Label ID="lbl1" runat="server"></asp:Label>
                                                        <asp:Button ID="btnprevious" runat="server" Text="Prev" class="button" OnClick="btnprevious_Click" />&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="Btnnext" runat="server" Text="Next" class="button" OnClick="Btnnext_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="alert alert-danger" id="divmessage" runat="server">
                                <strong>
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID ="Exporttoexcel" />--%>
                </Triggers>
            </asp:UpdatePanel>
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
                                                        Admission Date
                                                    </td>
                                                    <td width="20%">
                                                        <asp:TextBox ID="txtadmndate" Enabled="false" runat="server" Width="90%"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtShowReceiptAllocation" Enabled="false" runat="server" Width="90%"
                                                            Visible="false"></asp:TextBox>
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
                                        <div class="widget-box">
                                            <div class="widget-header">
                                                <h5>
                                                    Student Ledger
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
                                                                        runat="server" Font-Bold='<%#DataBinder.Eval(Container.DataItem, "BoldFlag")%>'></asp:Label></div>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span9">
                                        <div class="widget-box">
                                            <div class="widget-header">
                                                <h5>
                                                    Payment
                                                </h5>
                                                <div class="widget-toolbar">
                                                    <div class="btn-group">
                                                    </div>
                                                    <div class="btn-group" id="divpaymentremarks" visible="false">
                                                        <button type="button" class="btn btn-minier btn-alert-danger icon-plus tooltip-alert-danger"
                                                            data-rel="tooltip" data-placement="top" title="Add Remarks" id="Btnpayremarks"
                                                            runat="server" onserverclick="btnaddremarks_ServerClick">
                                                        </button>
                                                    </div>
                                                    <div class="btn-group">
                                                        <button type="button" class="btn btn-minier btn-success icon-plus tooltip-success"
                                                            data-rel="tooltip" data-placement="top" title="Add" id="btnaddpayment" runat="server"
                                                            onserverclick="btnaddpayment_ServerClick">
                                                        </button>
                                                    </div>
                                                    <div class="btn-group" id="divevents" runat="server" visible="false">
                                                        <button type="button" class="btn btn-minier btn-primary icon-printer tooltip-info"
                                                            data-rel="tooltip" data-placement="top" title="Print" id="btnproceedprint" runat="server">
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="widget-body" style="height: 950px; overflow: Auto">
                                                <div class="widget-main">
                                                    <asp:DataList ID="dlpaymentreceipt" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        Height="20px" OnItemDataBound="dlpaymentreceipt_ItemDataBound" OnItemCommand="dlpaymentreceipt_ItemCommand">
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
                                                            <th align="center" style="text-align: center">
                                                                Action
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
                                                                <asp:Label ID="lblinstramt" Text='<%#DataBinder.Eval(Container.DataItem, "Instr_Amt")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location_Description")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>
                                                                    <asp:Label ID="lblchequestatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Ins_Status")%>'
                                                                        ToolTip='<%#DataBinder.Eval(Container.DataItem,"Remark")%>'></asp:Label></b>
                                                            </td>
                                                            <td id="td16" runat="server" align="center" style="text-align: center">
                                                                <asp:LinkButton ID="lnkedit" runat="server" class="btn default btn-xs green" CommandName="Edit"
                                                                    Visible="false" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Chequeidno")%>'><i class="fa fa-eye"></i> Edit</asp:LinkButton>
                                                                <asp:LinkButton ID="lnkblock" runat="server" class="btn btn-mini btn-danger" CommandName="Remove"
                                                                    Visible="false" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Chequeidno")%>'><i class="icon-trash"></i></asp:LinkButton>
                                                                <asp:Label ID="lblT005_Populate_Flag" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"T005_Populate_Flag")%>'> </asp:Label>
                                                                <asp:Label ID="lblAction" runat="server" Visible="true">
<span class="label label-success arrowed-in arrowed-in-right">No Action</span>
                                                                </asp:Label>
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
                                                                        <asp:TextBox ID="txtmicrcode" runat="server" AutoPostBack="true" Width="84%" OnTextChanged="txtmicrcode_TextChanged"></asp:TextBox>
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
                                                                        <asp:TextBox ID="txtchqno" runat="server" Width="84%" MaxLength="10"></asp:TextBox>
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
                                                                        <input readonly="readonly" class="span10 date-picker" id="txtchqdate" runat="server"
                                                                            type="text" data-date-format="dd M yyyy" style="width: 84%" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Amount
                                                                        <asp:Label ID="label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtchequeamt" runat="server" Width="84%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                        <asp:DropDownList ID="ddlpayee" runat="server" Width="84%" AutoPostBack="true" ValidationGroup="Val6"
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
                                                                        <asp:TextBox ID="txtddno" runat="server" Width="84%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                        <input readonly="readonly" class="span10 date-picker" id="txtdddate" runat="server"
                                                                            type="text" data-date-format="dd M yyyy" />
                                                                        <%--<asp:TextBox ID="txtdddate" runat="server" Width="84%"></asp:TextBox>
                                                                        <CC1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtdddate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtdddate"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter DD Date" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtdddate"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        DD Amount
                                                                        <asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtddamt" runat="server" Width="84%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                        <asp:TextBox ID="txtcashamt" runat="server" Width="84%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
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
                                                                            ValidationGroup="Val6" OnSelectedIndexChanged="ddlpayeecash_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="ddlpayeecash"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblccdc" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        Transaction Id
                                                                        <asp:Label ID="label37" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txttransid" runat="server" Width="70%" MaxLength="15"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ControlToValidate="txttransid"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Transaction Id" />
                                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator22" ControlToValidate="txttransid"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server"
                                                                            ErrorMessage="Transaction Id should be of 14 digits" ValidationGroup="Val6" Text="#"
                                                                            SetFocusOnError="true" ControlToValidate="txttransid" ValidationExpression="^[A-Z0-9]{14,14}$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Transaction Date
                                                                        <asp:Label ID="label38" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <input readonly="readonly" class="span10 date-picker" id="txttrandate" runat="server"
                                                                            type="text" data-date-format="dd M yyyy" />
                                                                        <%--<asp:TextBox ID="txttrandate" runat="server" Width="70%"></asp:TextBox>
                                                                        <CC1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="txttrandate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="txttrandate"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Transaction Date" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txttrandate"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -](0[1-9]|1[012])[- -](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Amount
                                                                        <asp:Label ID="label39" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txttransamt" runat="server" Width="70%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="txttransamt"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Transaction Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server"
                                                                            ErrorMessage="Enter Valid Amount" ValidationGroup="Val6" Text="#" SetFocusOnError="true"
                                                                            ControlToValidate="txttransamt" ValidationExpression="^\d+(\.\d{2})?$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Payee
                                                                        <asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayeetrans" runat="server" Width="70%" AutoPostBack="true"
                                                                            ValidationGroup="Val6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="ddlpayeetrans"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Card Type
                                                                        <asp:Label ID="label41" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlcardtype" runat="server" Width="70%" AutoPostBack="true"
                                                                            ValidationGroup="Val6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" ControlToValidate="ddlcardtype"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Select Payee"
                                                                            InitialValue="Select" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Card Holder
                                                                        <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtcardholder" runat="server" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        last 4 Digit
                                                                        <asp:Label ID="label43" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtlast4digit" runat="server" Width="70%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="txtlast4digit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Last 4 Digit on Card" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator26" ControlToValidate="txtlast4digit"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                                            ErrorMessage="Enter Last 4 digit on card" ValidationGroup="Val6" Text="#" SetFocusOnError="true"
                                                                            ControlToValidate="txtlast4digit" ValidationExpression="^[0-9]{4,4}$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                    </td>
                                                                    <td width="20%">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-striped table-bordered table-advance table-hover" width="100%"
                                                                id="tblNeft" runat="server">
                                                                <tr>
                                                                    <td width="10%">
                                                                        UTR No.
                                                                        <asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtNeft_UTRNo" runat="server" Width="70%" MaxLength="30"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtNeft_UTRNo"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter UTR No." />
                                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator22" ControlToValidate="txttransid"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                            ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="UTR No. cannot be greater than 30 Character's"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="true" ControlToValidate="txtNeft_UTRNo"
                                                                            ValidationExpression="^[a-zA-Z0-9]{0,30}$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Date
                                                                        <asp:Label ID="label44" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <input readonly="readonly" class="span10 date-picker" id="txtNeft_trandate" runat="server"
                                                                            type="text" data-date-format="dd M yyyy" />
                                                                        <%--<asp:TextBox ID="txttrandate" runat="server" Width="70%"></asp:TextBox>
                                                                        <CC1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="txttrandate"
                                                                            DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                        </CC1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="txttrandate"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Transaction Date" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txttrandate"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -](0[1-9]|1[012])[- -](19|20)\d\d$"></asp:RegularExpressionValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="10%">
                                                                        Amount
                                                                        <asp:Label ID="label45" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:TextBox ID="txtNeftAmount" runat="server" Width="70%" onKeypress="if(event.keyCode&lt;44||event.keyCode&gt;57||event.keyCode==45||event.keyCode==47)event.returnValue=false"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtNeftAmount"
                                                                            Text="#" runat="server" ValidationGroup="Val6" SetFocusOnError="True" ErrorMessage="Enter Amount" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter Valid Amount"
                                                                            ValidationGroup="Val6" Text="#" SetFocusOnError="true" ControlToValidate="txtNeftAmount"
                                                                            ValidationExpression="^\d+(\.\d{2})?$" />
                                                                    </td>
                                                                    <td width="10%">
                                                                        Payee
                                                                        <asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                    </td>
                                                                    <td width="20%">
                                                                        <asp:DropDownList ID="ddlpayee_Neft" runat="server" Width="70%" AutoPostBack="true"
                                                                            ValidationGroup="Val6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="ddlpayee_Neft"
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
                                                            <table class="table table-striped table-bordered table-advance table-hover" id="tblAllocationAdd"
                                                                runat="server">
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
                                                                        <asp:DropDownList ID="ddlpayeeddedit" runat="server" Width="84%" AutoPostBack="true"
                                                                            OnSelectedIndexChanged="ddlpayeedd_SelectedIndexChanged" ValidationGroup="Val6">
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
                                                            <table class="table table-striped table-bordered table-advance table-hover" id="tblallocation"
                                                                runat="server" visible="false">
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
                                                                <div style="float: left; width: 99%; text-align: right">
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
<a href='<%#DataBinder.Eval(Container.DataItem,"Sbentrycode","View_Request_Details.aspx?&SBEntrycode={0}") & DataBinder.Eval(Container.DataItem,"Request_id","Request_Id={0}")%>' target="_blank" class="btn default btn-xs green"><i class="fa fa-eye"></i> View Details</a>
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
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtmicrcode" />
                    <asp:PostBackTrigger ControlID="btnclosepayment" />
                    <asp:PostBackTrigger ControlID="btncloseremoverpt" />
                    <asp:PostBackTrigger ControlID="btnremovereceipt" />
                    <asp:PostBackTrigger ControlID="btnsavepayment" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="Removereceipt" tabindex="-1" role="basic" aria-hidden="true"
        style="display: none" data-keyboard="false" data-backdrop="static" data-keyboard="false"
        data-attention-animation="false">
        <div class="modal-dialog modal-small blue">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="scroller" data-always-visible="1" data-rail-visible1="1">
                        <p>
                            <b>
                                <asp:Label ID="lblnote" runat="server" ForeColor="#FF3300"></asp:Label></b>
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn default" id="btncloseremoverpt" runat="server" onserverclick="btncloseremoverpt_ServerClick">
                        No</button>
                    <button type="button" class="btn blue" id="btnremovereceipt" runat="server" onserverclick="btnremovereceipt_ServerClick">
                        Yes</button>
                    <asp:ValidationSummary ID="ValidationSummary13" runat="server" ShowMessageBox="True"
                        ValidationGroup="Val8" ShowSummary="False" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="DivRemoveCheque" style="left: 50%!important; top: 30%!important;
        display: none" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="upnlRemoveCheque" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                Remove Cheque
                            </h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <td align="center">
                                        <asp:Label runat="server" ID="lblChequeidno1" Text="" Font-Bold="True" Visible="false" />
                                        Are You Sure you want to Remove this Cheque ?
                                    </td>
                                </tr>
                                <%--<tr>
                                                    <td width="50%">
                                                        Center Remarks
                                                    </td>
                                                    <td width="50%">
                                                        <asp:TextBox ID="txtchequereturnremarks" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator58" ControlToValidate="txtchequereturnremarks"
                                                            Text="#" runat="server" ValidationGroup="Val35" SetFocusOnError="True" ErrorMessage="Enter Remarks" />
                                                    </td>
                                                </tr>--%>
                            </table>
                            <center />
                        </div>
                        <div class="modal-footer">
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btn_DeleteYes"
                                ToolTip="Yes" runat="server" Text="Yes" OnClick="btn_DeleteYes_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btn_DeleteNo" ToolTip="NO"
                                runat="server" Text="NO" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btn_DeleteYes" />
                        <asp:PostBackTrigger ControlID="btn_DeleteNo" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="DivAddremrks" style="left: 50%!important; top: 30%!important;
        display: none" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                Add Offered Fees
                            </h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <td width="20%">
                                        OFFERED FEES
                                    </td>
                                    <td width="30%">
                                        <asp:TextBox ID="txtpendingremarks" onkeypress="return NumberOnly(event);" runat="server" Width="90%"></asp:TextBox>
                                        <asp:Label runat="server" ID="lblpendingremarks" Text="" Font-Bold="True" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <center />
                        </div>
                        <div class="modal-footer">
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="Btnsavepndingremarksyes"
                                ToolTip="Save" runat="server" Text="Save" OnClick="btn_saveYes_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnsavepndingremarksNo"
                                ToolTip="Close" runat="server" Text="Close" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Btnsavepndingremarksyes" />
                        <asp:PostBackTrigger ControlID="BtnsavepndingremarksNo" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="DivAddPayment" style="left: 50%!important; top: 30%!important;
        display: none" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                Add Payment
                            </h4>
                        </div>
                        <div class="modal-body">
                            <table class="table table-striped table-bordered table-advance table-hover">
                                <tr>
                                    <td align="center">
                                        <asp:Label runat="server" ID="Label13" Text="" Font-Bold="True" Visible="false" />
                                        Record Saved Successfully.Do you want to add another payment ?
                                    </td>
                                </tr>
                            </table>
                            <center />
                        </div>
                        <div class="modal-footer">
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="Btnpayemtyes" ToolTip="Yes"
                                runat="server" Text="Yes" OnClick="btn_AddpaymnetnYes_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="Btnpayemtno" ToolTip="NO"
                                runat="server" Text="NO" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Btnpayemtyes" />
                        <asp:PostBackTrigger ControlID="Btnpayemtno" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">        function openModalDelete() { $("#DivRemoveCheque").modal({ backdrop: "static" }); $("#DivRemoveCheque").modal("show") };</script>
    <script type="text/javascript">        function openModalAddremarks() { $("#DivAddremrks").modal({ backdrop: "static" }); $("#DivAddremrks").modal("show") };</script>
    <script type="text/javascript">        function openModalAddpayemtnewclick() { $("#DivAddPayment").modal({ backdrop: "static" }); $("#DivAddPayment").modal("show") };</script>
</asp:Content>
