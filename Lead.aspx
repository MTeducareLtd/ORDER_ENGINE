<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Lead.aspx.cs" Inherits="Lead" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AjaxFrameworkMode="Enabled">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
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
                    <li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
                        <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
                    <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
                    </i><a href="#">
                        <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
                </ul>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="nav-search">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <button type="button" class="btn btn-primary btn-small radius-4  btn-danger" id="btnback"
                        runat="server" onserverclick="btnback_ServerClick" visible="false">
                        <i class="icon-reply"></i>Back</button>
                    <button type="button" class="btn  btn-primary btn-small radius-4  btn-danger" id="btnsearchback"
                        runat="server" onserverclick="btnsearchback_ServerClick" visible="false">
                        <i class="icon-reply"></i>Back to Lead Search</button>
                    </ul>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnback" />
                    <asp:PostBackTrigger ControlID="btnsearchback" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <!--#nav-search-->
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
            <div class="alert alert-danger" id="divmessage" runat="server">
                <strong>
                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                </strong>
            </div>
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
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
                                            Target Division
                                            <asp:DropDownList ID="ddlcompany" runat="server" CssClass="chzn-select" Width="215px"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged"
                                                Visible="false">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlsourcedivision" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlsourcedivision_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                       
                                        <td width="10%">
                                            Target Center
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlsourcecenter" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
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
                                                Lead Basic Data
                                            </th>
                                        </tr>
                                    </thead>
                                    <tr>
                                        <td width="10%">
                                            Acad Year
                                            <asp:Label ID="label18" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlacadyear" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true" ValidationGroup="Grplead1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlacadyear"
                                                Text="#" runat="server" ValidationGroup="Grplead1" SetFocusOnError="True" ErrorMessage="Select Acad Year"
                                                InitialValue="Select" />
                                        </td>
                                        <td width="10%">
                                            Lead Name
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtstudentname" runat="server" Width="205px" placeholder="Search by Name"></asp:TextBox>
                                        </td>
                                        <td width="10%">
                                            Handphone1
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtstudentnHandphone1" runat="server" Width="205px" placeholder="Search by Handphone1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Lead Type
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlleadtype" Width="215px" runat="server" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Lead Source
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlleadsource" Width="215px" runat="server" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Lead Status
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlleadstatus" Width="215px" runat="server" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Lead Created From
                                        </td>
                                        <td width="20%">
                                            <input readonly="readonly" class="span8 date-picker" id="txtfromdate" runat="server"
                                                type="text" data-date-format="dd M yyyy" style="width: 215px" />
                                        </td>
                                        <td width="10%">
                                            Lead Created To
                                        </td>
                                        <td width="20%">
                                            <input readonly="readonly" class="span8 date-picker" id="txttodate" runat="server"
                                                type="text" data-date-format="dd M yyyy" style="width: 215px" />
                                        </td>
                                        <td width="10%">
                                            Gender
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlgender" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                                <asp:ListItem Value="Both">All</asp:ListItem>
                                                <asp:ListItem Value="Male">Male</asp:ListItem>
                                                <asp:ListItem Value="Female">Female</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Age From
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtagefrom" runat="server" Width="205px" placeholder="Age From"></asp:TextBox>
                                        </td>
                                        <td width="10%">
                                            To
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtageto" runat="server" Width="205px" placeholder="Age To"></asp:TextBox>
                                        </td>
                                        <td width="10%">
                                        </td>
                                        <td width="20%">
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                    visible="false">
                                    <thead>
                                        <tr>
                                            <th colspan="6">
                                                Lead Contact Information & Academic Information
                                            </th>
                                        </tr>
                                    </thead>
                                    <tr>
                                        <td width="10%">
                                            Country
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlcountrysearch" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            State
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlstatesearch" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            City
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlcitysearch" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Location
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddllocationsearch" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Year of Education
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlyeareducation" runat="server" Width="215px" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                        </td>
                                        <td width="20%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Customer Type
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlstudenttype" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Institution Type
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlinstitutiontype1" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Board / University
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlboard1" runat="server" Width="215px" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Standard
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlstandard1" runat="server" Width="215px" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Year
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlyear1" runat="server" Width="215px" CssClass="chzn-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Course Interested
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtcourseinterestedin" runat="server" Width="205px" placeholder="Search by Course interested in"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="tr1" runat="server" visible="false">
                                        <td width="10%">
                                            Target Company
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddltargetcompany" runat="server" Width="205px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Target Division
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddltargetdivision" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Target Zone/Area
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddltargetzone" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Target Center
                                        </td>
                                        <td width="20%" colspan="5">
                                            <asp:DropDownList ID="ddltargetcenter" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-striped table-bordered table-advance table-hover" runat="server"
                                    visible="false">
                                    <thead>
                                        <tr>
                                            <th colspan="6">
                                                Follow-Up & Other Information
                                            </th>
                                        </tr>
                                    </thead>
                                    <tr>
                                        <td width="10%">
                                            Follow-up From
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtfollowupfrm" runat="server" Width="205px"></asp:TextBox>
                                            <CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtfollowupfrm"
                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                            </CC1:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtfollowupfrm"
                                                ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="10%">
                                            Follow-up To
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtfollowupto" runat="server" Width="205px"></asp:TextBox>
                                            <CC1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtfollowupto"
                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                            </CC1:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtfollowupto"
                                                ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="10%">
                                            Overdue Follow-up
                                        </td>
                                        <td width="20%">
                                            <%--<asp:CheckBox ID="chkfollowup" runat="server" /><span class="lbl"></span>--%>
                                            <input runat="server" id="chkfollowup" name="switch-field-1" type="checkbox" class="ace-switch ace-switch-2" />
                                            <span class="lbl"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Blocked Status
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlblocked" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Include Blocked</asp:ListItem>
                                                <asp:ListItem Value="2">Only Blocked</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Examination Details
                                        </td>
                                        <td width="20%" colspan="3">
                                            <asp:TextBox ID="txtexamdtls" runat="server" Width="205px" placeholder="Examination Details"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Score Type
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlscoretype" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Condition
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlcondition" runat="server" Width="215px" CssClass="chzn-select"
                                                AutoPostBack="true">
                                                <asp:ListItem Value="0" Selected="True">All</asp:ListItem>
                                                <asp:ListItem Value="1"><</asp:ListItem>
                                                <asp:ListItem Value="2"><=</asp:ListItem>
                                                <asp:ListItem Value="3">>=</asp:ListItem>
                                                <asp:ListItem Value="4">></asp:ListItem>
                                                <asp:ListItem Value="5">=</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            Score
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtscore" runat="server" Width="205px" placeholder="Search by Score"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div class="well" style="text-align: center; background-color: #F0F0F0">
                                    <button class="btn btn-app btn-primary btn-mini radius-4 btn-block" id="btnsearch"
                                        runat="server" onserverclick="btnsearch_ServerClick" validationgroup="Grplead1">
                                        Search <i class="m-icon-swapright m-icon-white"></i>
                                    </button>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Grplead1" ShowSummary="False" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid" id="divsearchresults" runat="server">
                        <div class="span12">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="widget-box ">
                                <div class="widget-header widget-hea1der-small header-color-dark">
                                    <h4 class="smaller">
                                        <i class="icon-book"></i>Lead Search Results</h4>
                                    <div class="widget-toolbar">
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div class="table-toolbar" id="divtoolbar" runat="server" visible="false">
                                        <div class="btn-group">
                                        </div>
                                    </div>
                                    <div id="OrgSerchCode" runat="server" visible="false">
                                        <asp:Label ID="lblTargetCompCode" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblTargetDivCode" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblTargetZoanCode" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblTargetCentreCode" runat="server" Text=""></asp:Label>
                                    </div>
                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                                        OnItemDataBound="Repeater1_ItemDataBound">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-bordered table-hover Table2">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            Target Location
                                                        </th>
                                                        <th>
                                                            Student
                                                        </th>
                                                        <th>
                                                            Contact No.
                                                        </th>
                                                        <th>
                                                            Course Interested In
                                                        </th>
                                                        <th>
                                                            Lead Status
                                                        </th>
                                                        <th>
                                                            Lead Source
                                                        </th>
                                                        <th>
                                                            Interacted On
                                                        </th>
                                                        <th>
                                                            Follow-up Date
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
                                                    <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "CentreName")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Studentname")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone1")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" Text='<%#DataBinder.Eval(Container.DataItem, "Prod_Interest")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "Lead_Status_Desc")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" Text='<%#DataBinder.Eval(Container.DataItem, "Lead_Source_Desc")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" Text='<%#DataBinder.Eval(Container.DataItem, "InteractedOn")%>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "NextFollowupdate")%>'
                                                        runat="server"></asp:Label><b><asp:Label ID="label8" runat="server" Text="   (!)"
                                                            ForeColor="#FF3300"></asp:Label></b>
                                                </td>
                                                <td>
                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Display.aspx?&Lead_Code={0}") %>'
                                                        id="btndisplay" runat="server" target="_blank" class="btn btn-minier btn-success icon-eye-open tooltip-success"
                                                        data-rel="tooltip" data-placement="top" title="Display"></a>&nbsp;
                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Edit.aspx?&Lead_Code={0}") %>'
                                                            id="btndedit" runat="server" target="_blank" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                                            data-rel="tooltip" data-placement="top" title="Edit"></a>&nbsp;
                                                   
                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Lead_Followup.aspx?&Lead_Code={0}") %>'
                                                        id="btnfollowup" runat="server" target="_blank" class="btn btn-minier btn-primary icon-comments tooltip-info"
                                                        data-rel="tooltip" data-placement="top" title="Follow-up"></a>&nbsp;
                                                    <a href='<%#DataBinder.Eval(Container.DataItem,"Lead_Code","Convert_Lead_To_Opportunity.aspx?&Lead_Code={0}") %>'
                                                            id="lnkconvert" runat="server" target="_blank" class="btn btn-minier btn-primary icon-check tooltip-info"
                                                            data-rel="tooltip" data-placement="top" title="Convert"></a>&nbsp;
                                                    <asp:LinkButton ID="lnkblock" runat="server" class="btn btn-minier btn-danger icon-ban-circle tooltip-Danger"
                                                        data-rel="tooltip" data-placement="top" title="Block" CommandName="Block" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Lead_Code")%>'></asp:LinkButton>&nbsp;
                                                    <asp:LinkButton ID="lnkunblock" runat="server" class="btn btn-minier btn-primary icon-unlock tooltip-info"
                                                        data-rel="tooltip" data-placement="top" title="Unblock" CommandName="UnBlock"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Lead_Code")%>'></asp:LinkButton>&nbsp;
                                                    <asp:Label ID="lblisactive" Text='<%#DataBinder.Eval(Container.DataItem, "isactive")%>'
                                                        runat="server" Visible="false"></asp:Label>
                                                    <td id="Td1" runat="server" visible="false">
                                                        <asp:Label ID="lblleadno" Text='<%#DataBinder.Eval(Container.DataItem, "Lead_Code")%>'
                                                            runat="server" Visible="false"></asp:Label>
                                                         <asp:LinkButton ID="lnkedit" runat="server" Visible="false" CommandName="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Lead_Code")%>'> </asp:LinkButton>
                                                    </td>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:Label ID="lblleadid" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <!-- END EXAMPLE TABLE PORTLET-->
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                </Triggers>
            </asp:UpdatePanel>
            <!-- END PAGE CONTENT FOR SEARCH-->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="modal fade" id="Blocklead" tabindex="-1" role="basic" aria-hidden="true"
                        data-keyboard="false" data-backdrop="static" data-keyboard="false" data-attention-animation="false">
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
                                    <button type="button" class="btn green" id="btncloseleadblock" runat="server" onserverclick="btncloseleadblock_ServerClick">
                                        No</button>
                                    <button type="button" class="btn green" id="btnblocklead" runat="server" onserverclick="btnblocklead_ServerClick">
                                        Yes</button>
                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Val8" ShowSummary="False" />
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <div class="modal fade" id="UnBlocklead" tabindex="-1" role="basic" aria-hidden="true"
                        data-keyboard="false" data-backdrop="static" data-keyboard="false" data-attention-animation="false">
                        <div class="modal-dialog modal-small blue">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <div class="scroller" data-always-visible="1" data-rail-visible1="1">
                                        <p>
                                            <b>
                                                <asp:Label ID="lblnote1" runat="server" ForeColor="#FF3300"></asp:Label></b>
                                        </p>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn green" id="btnunblockno" runat="server" onserverclick="btnunblockno_ServerClick">
                                        No</button>
                                    <button type="button" class="btn green" id="btnunblockyes" runat="server" onserverclick="btnunblockyes_ServerClick">
                                        Yes</button>
                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                        ValidationGroup="Val8" ShowSummary="False" />
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <!--BEGIN PAGE CONTENT  FOR CONVERT-->
                    <div id="divconvert" runat="server">
                        <div id="divleadbasicinfo" runat="server">
                            <div class="widget-box">
                                <div class="widget-body">
                                    <div class="widget-header widget-hea1der-small header-color-dark">
                                        <h4 class="smaller">
                                            Lead Basic Information</h4>
                                    </div>
                                    <div class="widget-body">
                                        <div class="widget-body-inner">
                                            <div class="widget-main">
                                                <div class="row-fluid">
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <tr>
                                                            <td width="10%">
                                                                Lead Type
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtleadtype" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Lead Source
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtleadsource" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Lead Status
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtleadstatus" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                Student Name
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtconstdname" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Handphone 1
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtconstdhand1" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                                            </td>
                                                            <td width="10%">
                                                                Landline
                                                            </td>
                                                            <td width="20%">
                                                                <asp:TextBox ID="txtconstdlandline" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="row-fluid">
                                                    <div class="widget-box">
                                                        <div class="widget-body">
                                                            <div class="widget-header">
                                                                <h4>
                                                                    Convert</h4>
                                                            </div>
                                                            <div class="widget-body">
                                                                <table class="table table-striped table-bordered table-advance table-hover" id="tblconvertOpp"
                                                                    runat="server" width="100%">
                                                                    <thead>
                                                                        <th colspan="6">
                                                                            Opportunity Details
                                                                        </th>
                                                                    </thead>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Product Category
                                                                            <asp:Label ID="label13" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlproductcategory" runat="server" CssClass="chzn-select" ValidationGroup="Val1"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="ddlproductcategory"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Product Category"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Sales Stage
                                                                            <asp:Label ID="label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlsalesstage" runat="server" CssClass="chzn-select" ValidationGroup="Val1"
                                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlsalesstage_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="ddlsalesstage"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Sales Stage"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%" id="tdapplicationno" runat="server">
                                                                            App. Form No.
                                                                            <asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%" id="tdapplicationno1" runat="server">
                                                                            <asp:TextBox ID="txtappno" runat="server" Width="205px" ValidationGroup="Val1" MaxLength="7"
                                                                                onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtappno"
                                                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            <asp:Label ID="lblappnoerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Company
                                                                            <asp:Label ID="label39" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlconvertcompany" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertcompany_SelectedIndexChanged"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" ControlToValidate="ddlconvertcompany"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Company"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Division
                                                                            <asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlconvertdivision" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertdivision_SelectedIndexChanged"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="ddlconvertdivision"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Division"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Zone / Area
                                                                            <asp:Label ID="label41" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlconvertzone" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertzone_SelectedIndexChanged"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="ddlconvertzone"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Zone/Area"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Center
                                                                            <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlconvertcenter" AutoPostBack="true" runat="server" CssClass="chzn-select"
                                                                                Enabled="false" ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertcenter_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="ddlconvertcenter"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Acad. Year
                                                                            <asp:Label ID="label43" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlConacademicyear" AutoPostBack="true" runat="server" CssClass="chzn-select"
                                                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlConacademicyear_SelectedIndexChanged"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="ddlConacademicyear"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Academic Year"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Product Name
                                                                            <asp:Label ID="label44" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlproduct" runat="server" CssClass="chzn-select" ValidationGroup="Val1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="ddlproduct"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Product"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Discount offered
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtdiscount" runat="server" Width="205px" ValidationGroup="Val1"
                                                                                MaxLength="10" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="redquiredexpression5" ControlToValidate="txtdiscount"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Discount Notes
                                                                        </td>
                                                                        <td width="70%" colspan="4">
                                                                            <asp:TextBox ID="txtdiscountnotes" runat="server" Width="675px" ValidationGroup="Val1"
                                                                                placeholder="Free Text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Expected DoJ
                                                                            <asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtjoindate" runat="server" Width="205px" ValidationGroup="Val1"></asp:TextBox>
                                                                            <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtjoindate"
                                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                            </CC1:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="txtjoindate"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter Join Date" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtjoindate"
                                                                                ValidationGroup="Val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                            <asp:Label ID="lbldateerrorJoindate" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Exp. Closure date
                                                                            <asp:Label ID="label37" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtexpectedclosedate" runat="server" Width="205px" ValidationGroup="Val1"></asp:TextBox>
                                                                            <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexpectedclosedate"
                                                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                                            </CC1:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="txtexpectedclosedate"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Expected Closure Date" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtexpectedclosedate"
                                                                                ValidationGroup="Val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                                            <asp:Label ID="lbldateerrorexp" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Converted Date
                                                                            <asp:Label ID="label35" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtconverteddate" runat="server" Width="205px" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%">
                                                                            Probability %
                                                                            <asp:Label ID="label38" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtprobabilitypercent" runat="server" MaxLength="2" Width="205px"
                                                                                ValidationGroup="Val1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="txtprobabilitypercent"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Probability Percent of Conversion" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtprobabilitypercent"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                                                ValidationExpression="^(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td width="10%">
                                                                            Contact Source
                                                                            <asp:Label ID="label22" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlsaleschannel" runat="server" CssClass="chzn-select" ValidationGroup="Val1"
                                                                                Enabled="false">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="ddlsaleschannel"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Contact Source"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="tr7" runat="server" visible="false">
                                                                        <td width="10%">
                                                                            Assigned To
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Width="88%" ValidationGroup="Val1" ToolTip="Enter User ID"
                                                                                MaxLength="6" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="txtassignedto"
                                                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Assign Lead" />
                                                                        </td>
                                                                        <td width="10%">
                                                                            Search User
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtusername" runat="server" Width="88%"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                            <asp:Button ID="btnseacrhbyusername" runat="server" Text="Search" CssClass="btn btn-small green" />
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlOppstatus" runat="server" Width="88%" Visible="false">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table class="table table-striped table-bordered table-advance table-hover" width="80% !important">
                                                                    <tr>
                                                                        <th colspan="6">
                                                                            <asp:CheckBox ID="ckhBranchTopper" runat="server" AutoPostBack="true" OnCheckedChanged="ckhBranchTopper_CheckedChanged" />
                                                                            <span class="lbl"></span>Branch Topper for Standard X
                                                                        </th>
                                                                    </tr>
                                                                    <tr id="trBranchTopper" runat="server" visible="false">
                                                                        <td align="left" style="text-align: left">
                                                                            Division
                                                                            <asp:Label ID="label10" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="text-align: left">
                                                                            <asp:DropDownList ID="ddlbranchtopperdivision" runat="server" CssClass="chzn-select"
                                                                                AutoPostBack="True" ValidationGroup="Val1" OnSelectedIndexChanged="ddlbranchtopperdivision_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFifgdeldValidator2" ControlToValidate="ddlbranchtopperdivision"
                                                                                Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Branch Division"
                                                                                InitialValue="Select" Display="None" />
                                                                        </td>
                                                                        <td align="left" style="text-align: left">
                                                                            Center
                                                                            <asp:Label ID="label11" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="text-align: left" colspan="3">
                                                                            <asp:DropDownList ID="ddlbranchtopperCenter" runat="server" CssClass="chzn-select"
                                                                                AutoPostBack="True" ValidationGroup="Val1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlbranchtopperCenter"
                                                                                Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Center"
                                                                                InitialValue="Select" Display="None" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th colspan="6">
                                                                            <asp:CheckBox ID="chkSchoolRanker" runat="server" AutoPostBack="true" OnCheckedChanged="chkSchoolRanker_CheckedChanged" />
                                                                            <span class="lbl"></span>School Ranker for Standard X
                                                                        </th>
                                                                    </tr>
                                                                    <tr runat="server" visible="false" id="trSchoolRanker">
                                                                        <td align="left" style="text-align: left">
                                                                            School Name
                                                                            <asp:Label ID="label12" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="text-align: left">
                                                                            <asp:DropDownList ID="ddlschoolranker" runat="server" CssClass="chzn-select" ValidationGroup="Val1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlschoolranker"
                                                                                Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select School"
                                                                                InitialValue="Select" Display="None" />
                                                                        </td>
                                                                        <td align="left" style="text-align: left">
                                                                            School Division
                                                                            <asp:Label ID="label15" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="text-align: left">
                                                                            <asp:TextBox ID="txtschooldivision" runat="server" Width="205px" ValidationGroup="Val1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtschooldivision"
                                                                                Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter School Division"
                                                                                InitialValue="" Display="None" />
                                                                        </td>
                                                                        <td align="left" style="text-align: left">
                                                                            Rank
                                                                            <asp:Label ID="label16" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="text-align: left">
                                                                            <asp:TextBox ID="txtschoolrank" runat="server" Width="205px" ValidationGroup="Val1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtschoolrank"
                                                                                Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter Rank"
                                                                                InitialValue="" Display="None" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th colspan="6">
                                                                            <asp:CheckBox ID="ckhRankerAdditional" runat="server" AutoPostBack="true" OnCheckedChanged="ckhRankerAdditional_CheckedChanged" />
                                                                            <span class="lbl"></span>Additional Pre-Defined Conditions
                                                                        </th>
                                                                    </tr>
                                                                    <tr runat="server" visible="false" id="trDiscount">
                                                                        <td align="left" style="text-align: left">
                                                                            Discount Condition
                                                                            <asp:Label ID="label17" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="text-align: left" colspan="5">
                                                                            <asp:DropDownList ID="ddldiscountconditions" runat="server" CssClass="chzn-select"
                                                                                AutoPostBack="True" ValidationGroup="Val1">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddldiscountconditions"
                                                                                Text="*" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Discount Condition"
                                                                                InitialValue="Select" Display="None" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                                            <button class="btn btn-app btn-success btn-mini radius-4" id="btnopportunitysubmit"
                                                runat="server" validationgroup="Val1" onserverclick="btnopportunitysubmit_ServerClick">
                                                Save
                                            </button>
                                            <%--<button class="btn btn-app btn-primary btn-mini radius-4 " id="btnopportunitycancel" runat="server" onserverclick ="btnopportunitycancel_ServerClick">
                                                                Close
                                                            </button>--%>
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                ValidationGroup="Val1" ShowSummary="False" />
                                            <!--Button Area -->
                                            <%--<asp:Label runat="server" ID="lblErrorBatch" Text="" ForeColor="Red" />
                                                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveAdd" runat="server"
                                                            Text="Save" ValidationGroup="UcValidate" onclick="BtnSaveAdd_Click"/>
                                                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnCloseAdd" Visible="true"
                                                            runat="server" Text="Close" onclick="BtnCloseAdd_Click" />
                                                        <asp:ValidationSummary ID="ValidationSummary2" ShowSummary="false" DisplayMode="List"
                                                            ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--
                        <div class="portlet box  blue" >
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-reorder"></i>Lead Basic Information
                                </div>
                            </div>
                            <div class="portlet-body form">
                                <table class="table table-striped table-bordered table-advance table-hover">
                                    <tr>
                                        <td width="10%">
                                            Lead Type
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtleadtype" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                        </td>
                                        <td width="10%">
                                            Lead Source
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtleadsource" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                        </td>
                                        <td width="10%">
                                            Lead Status
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtleadstatus" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Student Name
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtconstdname" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                        </td>
                                        <td width="10%">
                                            Handphone 1
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtconstdhand1" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                        </td>
                                        <td width="10%">
                                            Landline
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtconstdlandline" runat="server" Enabled="false" Width="79%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>--%>
                            <%--
                        <div class="portlet box">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-reorder"></i>Convert
                                </div>
                            </div>
                            <div class="portlet-body form">
                                <table class="table table-striped table-bordered table-advance table-hover" id="tblconvertOpp"
                                    runat="server" width="100%">
                                    <thead>
                                        <th colspan="6">
                                            Opportunity Details
                                        </th>
                                    </thead>
                                    <tr>
                                        <td width="10%">
                                            Product Category
                                            <asp:Label ID="label13" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlproductcategory" runat="server" CssClass ="chzn-select" ValidationGroup="Val1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="ddlproductcategory"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Product Category"
                                                InitialValue="Select" />
                                        </td>
                                        <td width="10%">
                                            Sales Stage
                                            <asp:Label ID="label14" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlsalesstage" runat="server" CssClass ="chzn-select" ValidationGroup="Val1"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlsalesstage_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="ddlsalesstage"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Sales Stage"
                                                InitialValue="Select" />
                                        </td>
                                        <td width="10%" id="tdapplicationno" runat="server">
                                            App. Form No.
                                            <asp:Label ID="label46" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%" id="tdapplicationno1" runat="server">
                                            <asp:TextBox ID="txtappno" runat="server" Width="79%" ValidationGroup="Val1" MaxLength="7"
                                                onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtappno"
                                                Text="#" runat="server" ValidationGroup="Grplead" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                            <asp:Label ID="lblappnoerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Company
                                            <asp:Label ID="label39" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlconvertcompany" runat="server" CssClass ="chzn-select" AutoPostBack="true"
                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertcompany_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" ControlToValidate="ddlconvertcompany"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Company"
                                                InitialValue="Select" />
                                        </td>
                                        <td width="10%">
                                            Division
                                            <asp:Label ID="label40" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlconvertdivision" runat="server" CssClass ="chzn-select" AutoPostBack="true"
                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertdivision_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ControlToValidate="ddlconvertdivision"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Division"
                                                InitialValue="Select" />
                                        </td>
                                        <td width="10%">
                                            Zone / Area
                                            <asp:Label ID="label41" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlconvertzone" runat="server" CssClass ="chzn-select" AutoPostBack="true"
                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertzone_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="ddlconvertzone"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Zone/Area"
                                                InitialValue="Select" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Center
                                            <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlconvertcenter" AutoPostBack="true" runat="server" CssClass ="chzn-select"
                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlconvertcenter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="ddlconvertcenter"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Center"
                                                InitialValue="Select" />
                                        </td>
                                        <td width="10%">
                                            Acad. Year
                                            <asp:Label ID="label43" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlConacademicyear" AutoPostBack="true" runat="server" CssClass ="chzn-select"
                                                ValidationGroup="Val1" OnSelectedIndexChanged="ddlConacademicyear_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="ddlConacademicyear"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Academic Year"
                                                InitialValue="Select" />
                                        </td>
                                        <td width="10%">
                                            Product Name
                                            <asp:Label ID="label44" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlproduct" runat="server" CssClass ="chzn-select" ValidationGroup="Val1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="ddlproduct"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Product"
                                                InitialValue="Select" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Discount offered
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtdiscount" runat="server" Width="79%" ValidationGroup="Val1" MaxLength="10"
                                                onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="redquiredexpression5" ControlToValidate="txtdiscount"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                ValidationExpression="^[0-9]*\.?[0-9]+$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="10%">
                                            Discount Notes
                                        </td>
                                        <td width="70%" colspan="4">
                                            <asp:TextBox ID="txtdiscountnotes" runat="server" Width="94%" ValidationGroup="Val1"
                                                placeholder="Free Text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Expected DoJ
                                            <asp:Label ID="label36" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtjoindate" runat="server" Width="79%" ValidationGroup="Val1"></asp:TextBox>
                                            <CC1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtjoindate"
                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                            </CC1:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="txtjoindate"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Enter Join Date" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtjoindate"
                                                ValidationGroup="Val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                            <asp:Label ID="lbldateerrorJoindate" runat="server" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="10%">
                                            Exp. Closure date
                                            <asp:Label ID="label37" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtexpectedclosedate" runat="server" Width="79%" ValidationGroup="Val1"></asp:TextBox>
                                            <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexpectedclosedate"
                                                DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                            </CC1:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="txtexpectedclosedate"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Expected Closure Date" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtexpectedclosedate"
                                                ValidationGroup="Val1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                            <asp:Label ID="lbldateerrorexp" runat="server" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="10%">
                                            Converted Date
                                            <asp:Label ID="label35" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtconverteddate" runat="server" Width="79%" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="10%">
                                            Probability %
                                            <asp:Label ID="label38" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtprobabilitypercent" runat="server" MaxLength="2" Width="79%"
                                                ValidationGroup="Val1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="txtprobabilitypercent"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Probability Percent of Conversion" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtprobabilitypercent"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="true" ErrorMessage="Please Enter Only Numbers"
                                                ValidationExpression="^(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td width="10%">
                                            Contact Source
                                            <asp:Label ID="label22" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlsaleschannel" runat="server" CssClass ="chzn-select" ValidationGroup="Val1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="ddlsaleschannel"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Select Contact Source"
                                                InitialValue="Select" />
                                        </td>
                                    </tr>
                                    <tr id="tr7" runat="server" visible="false">
                                        <td width="10%">
                                            Assigned To
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="TextBox1" runat="server" Width="88%" ValidationGroup="Val1" ToolTip="Enter User ID"
                                                MaxLength="6" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="txtassignedto"
                                                Text="#" runat="server" ValidationGroup="Val1" SetFocusOnError="True" ErrorMessage="Assign Lead" />
                                        </td>
                                        <td width="10%">
                                            Search User
                                        </td>
                                        <td width="20%">
                                            <asp:TextBox ID="txtusername" runat="server" Width="88%"></asp:TextBox>
                                        </td>
                                        <td width="10%">
                                            <asp:Button ID="btnseacrhbyusername" runat="server" Text="Search" CssClass="btn btn-small green" />
                                        </td>
                                        <td width="20%">
                                            <asp:DropDownList ID="ddlOppstatus" runat="server" Width="88%" Visible="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <div class="form-actions fluid" id="divconvertoppbuttons" runat="server">
                                    <div class="col-md-offset-4 col-md-7">
                                        <button class="btn blue " id="btnopportunitysubmit" runat="server" validationgroup="Val1" onserverclick ="btnopportunitysubmit_ServerClick">
                                            Save
                                        </button>
                                        <button class="btn default " id="btnopportunitycancel" runat="server" onserverclick ="btnopportunitycancel_ServerClick">
                                            Close
                                        </button>
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ValidationGroup="Val1" ShowSummary="False" />
                                    </div>
                                </div>
                            </div>
                        </div>
                            --%>
                        </div>
                    </div>
                    <!--END PAGE CONTENT FOR CONVERT-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnopportunitysubmit" />
                    <%--<asp:PostBackTrigger ControlID="btnadd2" />--%>
                    <%--<asp:PostBackTrigger ControlID="btnaddlead" />--%>
                    <asp:PostBackTrigger ControlID="btncloseleadblock" />
                    <asp:PostBackTrigger ControlID="btnblocklead" />
                    <%--<asp:PostBackTrigger ControlID="btnsearchlead" />--%>
                    <%--<asp:AsyncPostBackTrigger ControlID ="btnsearch" />--%>
                    <asp:PostBackTrigger ControlID="btnunblockno" />
                    <asp:PostBackTrigger ControlID="btnunblockyes" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
