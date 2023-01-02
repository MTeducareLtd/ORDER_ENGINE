<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Registration_MPUC.aspx.cs" Inherits="Registration_MPUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function NumberOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
            event.returnValue = true;
        else
            event.returnValue = false;
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="row-fluid" style="text-align: Right;">
         <%--<a href="Default.aspx" class="btn btn-app btn-success btn-mini radius-4" >HOME</a>--%>
    </div>
    <div class="row-fluid" id="divSeminar" runat="server">
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
        <div id="divAdddNewStud" runat="server">
            <div class="widget-header widget-header-small header-color-dark">
                <h5 class="modal-title">
                    <asp:Label runat="server" ID="lblDivHead">Please Fill Following Information</asp:Label>
                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export to Excel" class="btn-small btn-warning icon-2x icon-angle-down"
                                        Height="25px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </h5>
            </div>
            <div class="row-fluid">
                <asp:UpdatePanel ID="upnlSearchInfo" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table runat="server" id="tblSearchDetail" cellpadding="3" class="table table-striped table-bordered table-condensed">
                            <tr>
                                <td class="span12" style="text-align: left">
                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                        <tr>
                                            <td style="border-style: none; text-align: left; width: 20%;">
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 30%;">
                                                <asp:Label runat="server" ID="Label2">Mobile No</asp:Label>
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 30%;">
                                                <div class="input-append">
                                                    <asp:TextBox runat="server" ID="txtSearchUID" ToolTip="UID" Width="240px" type="number" />
                                                    <asp:LinkButton ID="lnkSearchInfo" ToolTip="Search" runat="server" Height="20px"
                                                        class="btn btn-purple icon-search" CommandName="SearchInfo" OnClick="lnkSearchInfo_Click">                                                               

                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 20%;">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table runat="server" id="tblSearchInfo" visible="false" cellpadding="3" class="table table-striped table-bordered table-condensed">
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label3">Acad Year</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:DropDownList runat="server" ID="ddlacademicyear"  ToolTip="Acad Year" 
                                        Width="265px" ></asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="lbl4">First Name</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="Label1">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtFName" CssClass="uppercase" ToolTip="First Name"
                                        ValidationGroup="UcValidate" type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                        ControlToValidate="txtFName" CssClass="red" ErrorMessage="Please Input Alphabets"
                                        ValidationGroup="UcValidate" Text="" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="lbl3">Middle Name</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtMName" CssClass="uppercase" ToolTip="Middle Name"
                                        ValidationGroup="UcValidate" type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMName"
                                        CssClass="red" ErrorMessage="Please Input Alphabets" ValidationGroup="UcValidate"
                                        Text="" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label5">Last Name</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtLName" CssClass="uppercase" ValidationGroup="UcValidate"
                                        ToolTip="Last Name" type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLName"
                                        CssClass="red" ErrorMessage="Please Input Alphabets" ValidationGroup="UcValidate"
                                        Text="" SetFocusOnError="true" ValidationExpression="^[a-zA-Z]+[ a-zA-Z-_'.]*$" />
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label38">Date of Birth</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="Label39">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left;">
                                     <input readonly="readonly" class="span10 date-picker" id="txtDOB"
                                       runat="server" style="width: 260px;" type="text" data-date-format="dd M yyyy" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label11">Student Contact No</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="lbl2">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtContactNo" ToolTip="Contact Numbar" type="number"
                                        Width="265px" onkeypress="return NumberOnly()" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label9">Student Email Id</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="Label33">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtStudentEmailId" CssClass="uppercase" ValidationGroup="UcValidate"
                                        ToolTip="Student Email Address" type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                    <asp:RegularExpressionValidator ID="EmailIDValidation" runat="server" ControlToValidate="txtStudentEmailId"
                                        ErrorMessage="Invalid Student Email Id" CssClass="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="UcValidate" SetFocusOnError="True" Text=""></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Lbl1w">Address</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtAddress" CssClass="uppercase" ToolTip="Address"
                                        type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                             <tr>                  
                                <td style="border-style: none; text-align: left; width: 20%;">    
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                        
                                    <asp:Label runat="server" ID="Label42">City</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                     
                                   <asp:TextBox runat="server" ID="Txtcity"  
                                        type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                  
                                </td>         
                            </tr> 
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label7">Parent/Guradian Name</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="Label34">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtParentName" CssClass="uppercase" ToolTip="First Name"
                                        type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label8">Parent/Guradian Contact</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="lbl6">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtParentContact" ToolTip="Parent Contact" type="number"
                                        Width="265px" onkeypress="return NumberOnly()" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label10">Parent Email Id</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtParentEmailId" CssClass="uppercase" ToolTip="Parent Email Address"
                                        ValidationGroup="UcValidate" type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtParentEmailId"
                                        ErrorMessage="Invalid Parent Email Id" CssClass="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="UcValidate" SetFocusOnError="True" Text=""></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                             <tr>                  
                                <td style="border-style: none; text-align: left; width: 20%;">    
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                        
                                    <asp:Label runat="server" ID="Label40">School Name</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                     
                                    <asp:TextBox runat="server" ID="Txtschoolname" CssClass="uppercase" 
                                        type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                  
                                </td>         
                            </tr> 
                            <tr>                  
                                <td style="border-style: none; text-align: left; width: 20%;">    
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                        
                                    <asp:Label runat="server" ID="Label37">Borad</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                     
                                    <asp:DropDownList runat="server" ID="ddlBorad" Width="280px" 
                                        data-placeholder="Select Council" CssClass="chzn-select">
                                        <asp:ListItem>Select</asp:ListItem>
                                         <asp:ListItem>CBSE</asp:ListItem>
                                          <asp:ListItem>ICSE</asp:ListItem>
                                           <asp:ListItem>SSLC</asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                  
                                </td>         
                            </tr> 
                            <tr>                  
                                <td style="border-style: none; text-align: left; width: 20%;">    
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                        
                                    <asp:Label runat="server" ID="Label41">Percentage</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                     
                                   <asp:TextBox runat="server" ID="Txtpercentage"  
                                        type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                  
                                </td>         
                            </tr> 
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label12">Preffered Cente/Campus</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="Label30">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:DropDownList runat="server" ID="ddlCurrentSSCCenter" Width="280px" ToolTip="Current SSC Center"
                                        data-placeholder="Select Center" CssClass="chzn-select">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                           <%-- <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label22">Division</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="Label31">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:DropDownList runat="server" ID="ddlDivision" Width="280px" ToolTip="Division"
                                        data-placeholder="Select Division" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"
                                        CssClass="chzn-select">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>--%>
                           <%-- <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label13">Preffered Science Center</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="Label32">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:DropDownList runat="server" ID="ddlPrefferedScCenter" Width="280px" ToolTip="Preffered SSC Center"
                                        data-placeholder="Select Center" AutoPostBack="true" OnSelectedIndexChanged="ddlPrefferedScCenter_SelectedIndexChanged"
                                        CssClass="chzn-select">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label17">Product Interested In</asp:Label>
                                    <asp:Label runat="server" ID="Label18" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:ListBox  runat="server" ID="ddlProductName" Width="280px" ToolTip="Product"
                                        CssClass="chzn-select" data-placeholder="Select Product" SelectionMode="Multiple" AutoPostBack="true" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                       <asp:ListItem Value="01">English</asp:ListItem>
                                       <asp:ListItem Value="02">Kannada</asp:ListItem>
                                        <asp:ListItem Value="03">Hindi</asp:ListItem>
                                        <asp:ListItem Value="04">Sanskrit</asp:ListItem>
                                        <asp:ListItem Value="05">French</asp:ListItem>
                                       <asp:ListItem Value="06">PCMB</asp:ListItem>
                                       <asp:ListItem Value="07">PCMC</asp:ListItem>
                                       <asp:ListItem Value="08">PCME</asp:ListItem>
                                       <asp:ListItem Value="09">PCMS</asp:ListItem>

                                    </asp:ListBox>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label51">Product / Item Group Selection</asp:Label>
                                    <asp:Label runat="server" ID="Label4" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:DataList ID="dlselective" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                                        Height="20px">
                                        <HeaderTemplate>
                                            <b>Select</b></th>
                                            <th width="80%">
                                                Item
                                            </th>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ckhselect1" runat="server" /><span class="lbl"> </span>
                                            <td width="20%">
                                                <asp:Label ID="lblvoucherDesc" Text='<%#DataBinder.Eval(Container.DataItem, "SGR_DESC")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <asp:Label ID="lblmaterialcodeadd" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"SGR_Material")%>'></asp:Label>
                                            <asp:Label ID="lblvoucher_typ" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Typ")%>'></asp:Label>
                                            <asp:Label ID="lblvoucheramt" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Amount")%>'></asp:Label>
                                            <asp:Label ID="lblbaseuom" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "Uom_Base_Name")%>'></asp:Label>
                                            <asp:Label ID="lblbaseuomid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Uom")%>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>--%>

                            <tr>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label4"> Enquiry Status</asp:Label>
                                    <asp:Label runat="server" ID="Label13" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:DropDownList runat="server" ID="DDLStatus" Width="280px" ToolTip="Product"
                                        CssClass="chzn-select" data-placeholder="Select Status" AutoPostBack="true" OnSelectedIndexChanged="DDLStatus_SelectedIndexChanged" >
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                       <asp:ListItem Value="1">Confirmed</asp:ListItem>
                                       <asp:ListItem Value="2">Interested</asp:ListItem>
                                       <asp:ListItem Value="3">Not interested</asp:ListItem>
                                       </asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>

                             <tr id="trREMAKRS" runat="server" visible="false">                  
                                <td style="border-style: none; text-align: left; width: 20%;">    
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                        
                                    <asp:Label runat="server" ID="Label22">Remarks</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                     
                                    <asp:TextBox runat="server" ID="Txtremarks" CssClass="uppercase" 
                                        type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                  
                                </td>         
                            </tr> 

                             <tr id="trFOLLOEUP" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label31">Next Follow-up</asp:Label>
                                    <asp:Label runat="server" CssClass="red" ID="Label32">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left;">
                                     <input readonly="readonly" class="span10 date-picker" id="Txtfllowup"
                                       runat="server" style="width: 260px;" type="text" data-date-format="dd M yyyy" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>

                            <tr id="trHOSTEL" runat="server" visible="false">                
                                <td style="border-style: none; text-align: left; width: 20%;">    
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                        
                                    <asp:Label runat="server" ID="Label43">Hostel Facility</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">                                     
                                   <asp:DropDownList runat="server" ID="DDlHostel" Width="280px" ToolTip="Hostel Details"
                                        data-placeholder="Select" CssClass="chzn-select">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                  
                                </td>         
                            </tr> 
                            <tr id="trPAYMODE" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label23">Pay Mode</asp:Label>
                                    <asp:Label runat="server" ID="Label6" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:DropDownList runat="server" ID="ddlPayMode" Width="280px" ToolTip="Pay Mode"
                                        data-placeholder="Select Pay Mode" CssClass="chzn-select">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">FDP</asp:ListItem>
                                        <asp:ListItem Value="2">EMI</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                           <tr id="trPAYTYPE" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label14">Pay Type</asp:Label>
                                    <asp:Label runat="server" ID="Label24" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:DropDownList runat="server" ID="ddlPayType" Width="280px" ToolTip="Pay Type"
                                        data-placeholder="Select Pay Type" AutoPostBack="true" CssClass="chzn-select"
                                        OnSelectedIndexChanged="ddlPayType_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="04">Credit/Debit Card</asp:ListItem>
                                        <asp:ListItem Value="05">NEFT</asp:ListItem>
                                        <asp:ListItem Value="02">Demand Draft</asp:ListItem>
                                        <asp:ListItem Value="01">Cheque</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr id="trCCDCAmount" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label19">Amount</asp:Label>
                                    <asp:Label runat="server" ID="Label25" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtCCDCAmount" ToolTip="CCDC Amount" type="number"
                                        onkeypress="return NumberOnly()" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr id="trCCDCTransactionId" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label20">Transaction ID</asp:Label>
                                    <asp:Label runat="server" ID="Label26" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtCCDCTransctionId" ToolTip="CCDC Transaction Id"
                                        type="text" Width="265px" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr id="trChequeDate" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label35">Date</asp:Label>
                                    <asp:Label runat="server" ID="Label36" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <input readonly="readonly" class="date-picker" id="txtChequeDate" runat="server"
                                        type="text" data-date-format="dd M yyyy" style="width: 260px;" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr id="trChequeAmount" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label15">Amount</asp:Label>
                                    <asp:Label runat="server" ID="Label27" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtChequeAmount" ToolTip="Cheque Amount" type="number"
                                        Width="265px" onkeypress="return NumberOnly()" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            <tr id="trMICRCode" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label16">MICR Code</asp:Label>
                                    <asp:Label runat="server" ID="Label28" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtMICRCode" ToolTip="MICR Code" type="number" Width="265px"
                                        AutoPostBack="true" OnTextChanged="txtMICRCode_TextChanged" onkeypress="return NumberOnly()" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                    <asp:Label runat="server" ID="lblBankName"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trChequeNumber" runat="server" visible="false">
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:Label runat="server" ID="Label21">Number</asp:Label>
                                    <asp:Label runat="server" ID="Label29" CssClass="red">*</asp:Label>
                                </td>
                                <td style="border-style: none; text-align: left; width: 30%;">
                                    <asp:TextBox runat="server" ID="txtChequeNo" ToolTip="Cheque No" type="number" Width="265px"
                                        onkeypress="return NumberOnly()" MaxLength="6" />
                                </td>
                                <td style="border-style: none; text-align: left; width: 20%;">
                                </td>
                            </tr>
                            
                        </table>
                        <div class="row-fluid" style="text-align: center;">
                            <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="pnlSave">
                                <ProgressTemplate>
                                    <img alt="" src="WaitLoad.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel ID="pnlSave" runat="server">
                                <ContentTemplate>--%>
                                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSave" runat="server"
                                        Text="Save" ValidationGroup="UcValidate" OnClick="BtnSave_Click" Visible="false" />
                                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnClose" runat="server"
                                        Text="Close" OnClick="BtnClose_Click" Visible="false" />
                                    <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                        ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                               <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSearchInfo" />
                        <asp:AsyncPostBackTrigger ControlID="txtMICRCode" />
                        <asp:PostBackTrigger ControlID="BtnSave" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

