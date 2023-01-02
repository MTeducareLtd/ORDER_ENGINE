<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Event_Remove.aspx.cs" Inherits="Event_Remove" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
     <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid hidden-print">
                <div id="breadcrumbs" class="position-relative" style="height: 53px">
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
                        <li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
                            <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
                        <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
                        </i><a href="#">
                            <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
                        
                        
                        
                    </ul>
                    <!-- END PAGE TITLE & BREADCRUMB-->
                </div>
            </div>
    
    <!-- END PAGE HEADER-->
    <div id="page-content" class="clearfix">
        <div class="row-fluid">
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
            <!-- BEGIN PAGE CONTENT FOR SEARCH-->
            <div id="upnlconvert" runat="server">
                <div class="row-fluid" id="div2" runat="server">
                    <div class="span12">

                                <div id="Div3" class="tab-pane active">
                                    <div class="row-fluid" id="div4" runat="server">
                                        <div class="span8" id="divpersonalinfo" runat="server">
                                            <div class="table-responsive">
                                                <table class="table table-striped table-bordered table-advance table-hover">
                                                    <tr>
                                                        <td width="10%">
                                                            App. No.
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtConapp" runat="server" Enabled="false" Width="70%"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            App. Entry Date
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtconAppentrydate" runat="server" Enabled="false" Width="70%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            App. Submit Date
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtconappsubdate" runat="server" Enabled="false" Width="70%"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            Customer Name
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtconstdname" runat="server" Enabled="false" Width="70%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td width="10%">
                                                            Company
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlconCompany" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true"
                                                                ValidationGroup="val2"  data-trigger="hover" data-placement="top"
                                                                data-content="Select Company" data-original-title="Company">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Division
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlcondivision" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                AutoPostBack="true" ValidationGroup="val2"  data-trigger="hover"
                                                                data-placement="top" data-content="Select Division" data-original-title="Division">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr67" runat="server" visible="false">
                                                        <td width="10%">
                                                            Stay Preference
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlstay" runat="server" Enabled="false" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Val4"
                                                                 data-trigger="hover" data-placement="top" data-content="Select Student Current Stay"
                                                                data-original-title="Stay">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Passing Year
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlconyearofpassing" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                ValidationGroup="Grplead1"  data-trigger="hover" data-placement="top"
                                                                data-content="Select Year of Passing" data-original-title="Year of Passing">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Center
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlconcenter" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true"
                                                                ValidationGroup="val2"  data-trigger="hover" data-placement="top"
                                                                data-content="Select Center" data-original-title="Center">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Academic Year
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlconacademicyear" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                AutoPostBack="true" ValidationGroup="val2"  data-trigger="hover"
                                                                data-placement="top" data-content="Select Academic Year" data-original-title="Academic Year">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Product
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlconstream" Enabled ="false"  runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true"
                                                                ValidationGroup="val2"  data-trigger="hover" data-placement="top"
                                                                data-content="Select Stream" data-original-title="Stream" >
                                                            </asp:DropDownList>
                                                            <br />
                                                            <strong><asp:Label ID="lblcoursedurationover" runat ="server" CssClass="error" ForeColor="Red" ></asp:Label></strong>
                                                            <strong><asp:Label ID="lblconstreamerror" runat ="server" CssClass="error" ForeColor="Red" ></asp:Label></strong>
                                                        </td>
                                                         <td width="10%">
                                                           Opportunity Code
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtopportunitycode" runat="server" Enabled="false" Width="70%"></asp:TextBox>
                                                        </td>
                                                        <td id="Td1" width="10%" runat="server" visible="false">
                                                            Transportation
                                                            <asp:Label ID="label18" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                        </td>
                                                        <td id="Td2" width="20%" runat="server" visible="false">
                                                            <asp:DropDownList ID="ddltransport" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true"
                                                                ValidationGroup="val2"  data-trigger="hover" data-placement="top"
                                                                data-content="Select Transportation required" >
                                                                <asp:ListItem Value="00" Selected="True">Select</asp:ListItem>
                                                                <asp:ListItem Value="02">Yes</asp:ListItem>
                                                                <asp:ListItem Value="01">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ControlToValidate="ddltransport"
                                                                Text="#" runat="server" ValidationGroup="val2" SetFocusOnError="True" ErrorMessage="Select Transportation"
                                                                InitialValue="Select" />
                                                        </td>
                                                        
                                                    </tr>
                                                </table>
                                                <table id="tbladditionalinfoCollege" runat ="server" visible ="false">
                                                <tr>
                                                        <td width="10%">
                                                            Medium of Instruction
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlConmediumofinstr" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                ValidationGroup="Val4"  data-trigger="hover" data-placement="top"
                                                                data-content="Select Medium of Instruction" data-original-title="Medium of Instruction">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Nationality
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlnationality" Enabled="false" Placeholder="Nationality" runat="server"
                                                               data-placeholder="Select" CssClass="chzn-select" ValidationGroup="val1"  data-trigger="hover"
                                                                data-placement="top" data-content="Enter Student Nationality" data-original-title="Student Nationality">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Mother Tongue
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlmothertongue" Enabled="false" Placeholder="Mother Tongue"
                                                                runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="val1"  data-trigger="hover"
                                                                data-placement="top" data-content="Enter Student Mother tongue" data-original-title="Student Mother Tongue">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Religion
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlreligion" Enabled="false" Placeholder="Student Religion"
                                                                runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" ValidationGroup="val1" 
                                                                data-trigger="hover" data-placement="top" data-content="Select Student Religion"
                                                                data-original-title="Student Religion">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Caste
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlcaste" Enabled="false" runat="server" Placeholder="Student Caste"
                                                                data-placeholder="Select" CssClass="chzn-select" ValidationGroup="val1"  data-trigger="hover"
                                                                data-placement="top" data-content="Enter Student Caste" data-original-title="Student Caste">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Sub Caste
                                                        </td>
                                                        <td width="20%">
                                                            <asp:TextBox ID="txtconsubcaste" Enabled="false" runat="server" Width="88%"></asp:TextBox>
                                                        </td>
                                                        <td width="10%">
                                                            Category
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlgroup" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="val1"
                                                                 data-trigger="hover" data-placement="top" data-content="Select Category"
                                                                data-original-title="Select Category">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Student From
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlstudentfrom" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                ValidationGroup="val1"  data-trigger="hover" data-placement="top"
                                                                data-content="Select student from" data-original-title="Student From">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="10%">
                                                            Physically
                                                            <br />
                                                            Challenged
                                                        </td>
                                                        <td width="20%">
                                                            <asp:DropDownList ID="ddlphysicalchallenged" Enabled="false" runat="server" data-placeholder="Select" CssClass="chzn-select"
                                                                ValidationGroup="val1"  data-trigger="hover" data-placement="top"
                                                                data-content="Select whether student is physicaly challenged" data-original-title="Physically Challenged">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblcursbcode" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <!-- static -->
                                        <div class="span4">
                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                            <div class ="widget-box">
                                                <div class="widget-header">
                                                    <h5>
                                                        <i class="fa fa-globe"></i>Compulsory Fee Items
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-main">
                                                    <asp:DataList ID="dlproductHeader" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                        Height="30">
                                                        <HeaderTemplate>
                                                            <b>Description</b></th>
                                                            <th>
                                                                UOM
                                                            </th>
                                                            <th>
                                                                Qty
                                                            </th>
                                                            <th>
                                                            Amount
                                                            </th>
                                                            <th>
                                                            Calc Type
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_description")%>'
                                                                runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbluom" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UOM_Name")%>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblqty" Text='<%#DataBinder.Eval(Container.DataItem, "min_order_Qty")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amt")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblCalcType" Text='<%#DataBinder.Eval(Container.DataItem, "Value_Type")%>'
                                                                    runat="server"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    </div> 
                                                </div>
                                            </div>
                                        </div>
                                       
                                    </div>
                                    <div class="row-fluid" id="div5" runat="server">
                                        
                                        <asp:UpdatePanel ID="upnl1" runat="server">
                                            <ContentTemplate>
                                                <div class="span12">
                                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                    <div class="widget-box">
                                                        <div class="widget-header">
                                                            <h5>
                                                                Product / Item Group Selection
                                                            </h5>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main">
                                                                <table class="table table-striped table-bordered table-advance table-hover" width="100%">
                                                                    <tr id="tr14" runat="server" visible="false">
                                                                        <td width="10%">
                                                                            Pay Plan
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddlpayplan" runat="server"  AutoPostBack="True"
                                                                                ValidationGroup="Val5" data-placeholder="Select" CssClass="chzn-select">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ControlToValidate="ddlpayplan"
                                                                                Text="*" runat="server" ValidationGroup="Val5" SetFocusOnError="True" ErrorMessage="Select Pay Plan"
                                                                                InitialValue="Select" />
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
                                                                    <tr id="tr19" runat="server" visible="false">
                                                                        <td width="10%">
                                                                            Opt. Product
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:DropDownList ID="ddllanguage" runat="server"  AutoPostBack="True"
                                                                                ValidationGroup="Val5" data-placeholder="Select" CssClass="chzn-select">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ControlToValidate="ddllanguage"
                                                                                Text="*" runat="server" ValidationGroup="Val5" SetFocusOnError="True" ErrorMessage="Select Optional Subject"
                                                                                InitialValue="Select" />
                                                                        </td>
                                                                        <td width="10%">
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtLangvalue" runat="server"  Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                        </td>
                                                                        <td width="20%">
                                                                        </td>
                                                                        <td width="10%">
                                                                            Comp. Subject
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtmandateSubjects" runat="server"  Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td width="10%">
                                                                        </td>
                                                                        <td id="td3" runat="server" visible="false">
                                                                            <asp:Label ID="lblmaterialcode" runat="server" Visible="false"></asp:Label>
                                                                        </td>
                                                                        <td width="20%">
                                                                            <asp:TextBox ID="txtvalue" runat="server"  Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <asp:DataList ID="dlselective" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                                    Height="20px">
                                                                    <HeaderTemplate>
                                                                        <b></b></th>
                                                                        <th width="20%" align="center">
                                                                            Item
                                                                        </th>
                                                                        <th width="10%" align="center">
                                                                            Unit Price
                                                                        </th>
                                                                        <th width="5%" align="center">
                                                                            Unit
                                                                        </th>
                                                                        <th width="10%" align="center">
                                                                            Available Qty
                                                                        </th>
                                                                        <th width="10%" align="center">
                                                                            Total value
                                                                        </th>
                                                                        <th width="10%" align="center">
                                                                            Qty
                                                                        </th>
                                                                        <th width="10%" align="center">
                                                                            Amount
                                                                        </th>
                                                                        <th width="30%" align="center">
                                                                            Remarks
                                                                        </th>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ckhselect1" runat="server" AutoPostBack="true" /><span class="lbl"> </span>
                                                                        <td width="20%">
                                                                            <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "SGR_DESC")%>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="10%">
                                                                            <asp:TextBox ID="txtvoucheramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Amt")%>'
                                                                                Width="75%" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td width="5%">
                                                                            <asp:Label ID="lbluomdesc" Text='<%#DataBinder.Eval(Container.DataItem, "Uomname")%>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="15%">
                                                                            <asp:TextBox ID="txtquantity" runat="server" AutoPostBack="true" Width="40%" Enabled="false"
                                                                                Text='<%#DataBinder.Eval(Container.DataItem, "qty")%>'></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator26" ControlToValidate="txtquantity"
                                                                                Text="#" runat="server" ValidationGroup="Val5" SetFocusOnError="true" ErrorMessage="Invalid amount entered"
                                                                                ValidationExpression="^[0-9]\d{0,9}(\.\d{1,2})?%?$"></asp:RegularExpressionValidator>
                                                                            <asp:RegularExpressionValidator ID="RegExp1" runat="server" ControlToValidate="txtquantity"
                                                                                ErrorMessage="Quantity cannot be more than 100" ValidationGroup="Val5" Text="#"
                                                                                SetFocusOnError="true" ValidationExpression="^[0-9]{1,3}$" />
                                                                            <asp:RequiredFieldValidator ID="r2" ControlToValidate="txtquantity" Text="#" runat="server"
                                                                                ValidationGroup="Val5" SetFocusOnError="True" ErrorMessage="Enter Quantity" />
                                                                        </td>
                                                                        <td width="10%" align="right">
                                                                            <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "amount")%>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="10%" id="td11" runat="server" visible="false">
                                                                            <asp:Label ID="lblbaseuomid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UOM")%>'></asp:Label>
                                                                            <asp:Label ID="lbluomid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Unit")%>'
                                                                                Visible="false"></asp:Label>
                                                                        </td>
                                                                        <td width="10%">
                                                                            <asp:TextBox ID="txtnewqty" runat="server" Width="40%" AutoPostBack="true"></asp:TextBox>
                                                                            <asp:CompareValidator ID="cmp1" runat="server" ControlToCompare="txtquantity" ControlToValidate="txtnewqty"
                                                                                Type="Integer" Operator="LessThanEqual" ErrorMessage="Invalid Quantity. Please Verify"
                                                                                Text="#" ValidationGroup="Val5" SetFocusOnError="true"></asp:CompareValidator>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtnewqty"
                                                                                Text="#" runat="server" ValidationGroup="Val5" SetFocusOnError="True" ErrorMessage="Enter Quantity" />
                                                                            <%--<asp:CompareValidator ID="CompareValidator1" runat ="server"  ControlToValidate="txtnewqty" Type ="Integer" ValueToCompare ="0" Operator ="GreaterThan"   ErrorMessage ="Invalid Quantity. Please Verify" Text="#" ValidationGroup ="Val5" SetFocusOnError ="true"></asp:CompareValidator>
                                                                            --%>
                                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtnewqty"
                                                                                Type="Integer" ValueToCompare="0" SetFocusOnError="true" ValidationGroup="Val5"
                                                                                Operator="GreaterThan" ErrorMessage="Enter Quantity" Text="#"></asp:CompareValidator>
                                                                            <asp:Label ID="lblqtyerror" runat="server" ForeColor="#FF3300"></asp:Label>
                                                                        </td>
                                                                        <td width="10%">
                                                                            <asp:TextBox ID="txttotalvalue" runat="server" Enabled="false" Width="60%"></asp:TextBox>
                                                                        </td>
                                                                        <td width="30%">
                                                                            <asp:TextBox ID="txtremark" runat="server" Width="90%"></asp:TextBox>
                                                                        </td>
                                                                        <asp:Label ID="lblmaterialcodeadd" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"MaterialCode")%>'></asp:Label>
                                                                        <asp:Label ID="lblvoucher_mode" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblvoucher_typ" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Typ")%>'></asp:Label>
                                                                        <asp:Label ID="lblselgroup" runat="server" Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                                <asp:Label ID="lblOrderid" runat="server" Visible="false"></asp:Label>
                                                            
                                                            <div class="alert alert-danger" id="diverrorsubject" runat="server">
                                                                <strong>
                                                                    <asp:Label ID="lblerrorsub" runat="server"></asp:Label></strong>
                                                            </div>
                                                            <div class="alert alert-success" id="divSuccessrsubject" runat="server">
                                                                <strong>
                                                                    <asp:Label ID="lblsuccesssub" runat="server"></asp:Label></strong>
                                                            </div>
                                                            <div id="Div6" class="well" style="text-align: center; background-color: #F0F0F0" runat="server">
                                                                <div class="col-md-offset-4 col-md-8">
                                                                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btncontinue" runat="server" validationgroup="Val5" onserverclick ="btncontinue_ServerClick">
                                                                        Continue
                                                                    </button>
                                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                                        ValidationGroup="Val5" ShowSummary="False" />
                                                                </div>
                                                            </div>
                                                            <div id="Divreselect" class="well" style="text-align: center; background-color: #F0F0F0" runat="server">
                                                                <div class="col-md-offset-4 col-md-8">
                                                                    <button class="btn btn-app btn-primary btn-mini radius-4" id="btnreselect" runat="server" onserverclick ="btnreselect_ServerClick">
                                                                        Undo
                                                                    </button>
                                                                </div>
                                                            </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btncontinue" />
                                                <asp:PostBackTrigger ControlID="btnreselect" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12" id="divfeedetails" runat="server">
                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                            <div class="widget-box">
                                                <div class="widget-header">
                                                    <h5>
                                                        <i class="fa fa-bitcoin"></i>Order Summary
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-main">
                                                    <div class="table-responsive">
                                                      
                                                        <asp:DataList ID="dlppheader" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                                            Height="20px">
                                                            <HeaderTemplate>
                                                                <b>Header (Fees Group)</b></th>
                                                                <th>Voucher Type</th>
                                                                <th>Voucher Description</th>
                                                                <th>Amount
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Pricing_Procedure_name")%>'
                                                                    runat="server"></asp:Label></td>
                                                                 <td> <asp:Label ID="Label11" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Type")%>'
                                                                    runat="server"></asp:Label></td>
                                                                <td> <asp:Label ID="Label8" Text='<%#DataBinder.Eval(Container.DataItem, "Voucher_Description")%>'
                                                                    runat="server"></asp:Label></td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblvoucherAmt" Text='<%#DataBinder.Eval(Container.DataItem, "Final_Voucher_Amount")%>'
                                                                        runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <div id="divcreatebutton" class="well" style="text-align: center; background-color: #F0F0F0" runat="server">

                                                                <button class="btn btn-success btn-small radius-4 " id="btncreateaccount" runat="server" validationgroup="Val6" onserverclick ="btncreateaccount_ServerClick">
                                                                    Confirm Order
                                                                </button>
                                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                                    ValidationGroup="Val6" ShowSummary="False" />

                                                        </div>
                                                        <div id="divbtnexit" class="well" style="text-align: center; background-color: #F0F0F0" runat="server">
                                                            <div class="col-md-offset-4 col-md-8">
                                                                <button class="btn btn-primary btn-mini radius-4" id="btnclose" runat="server" onserverclick ="btnclose_ServerClick">
                                                                    Close
                                                                </button>
                                                            </div>
                                                        </div>
                                                        <asp:Label ID="lbloppid" runat="server" Visible="False"></asp:Label>
                                                    </div>
                                                    </div> 
                                                </div>
                                            </div>
                                        </div>
                                    </div> 
                    </div>
                    <!--end tabbable-->
                </div>
            </div>
        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>
