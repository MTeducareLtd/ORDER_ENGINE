<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Contact_Information.ascx.cs"
    Inherits="UserControl_uc_Contact_Information" %>

<script type="text/javascript">
    function myFunction() {
        location.reload();
    }
</script>
<div class="row-fluid">
    <div class="span12">
        <div class="widget-box">
            <div class="widget-header widget-hea1der-small header-color-dark">
                <h5>
                    <i class="icon-comments"></i>Contact Information
                    <%--<asp:Label ID="lblContactId" runat="server" Visible="false"></asp:Label>--%>
                </h5>
                <div class="btn-group" id="divEditContatc" runat="server">
                    <a id="aedit" runat="server" target="_blank" class="btn btn-small btn-primary tooltip-info"
                        title="Edit Contact"><i class="icon-edit"></i></a>
                </div>
                <div class="btn-group" id="divRefreshContact" runat="server">
                    <button type="button" class="btn btn-small btn-primary tooltip-info" id="btnRefreshCon"
                        runat="server" onclick="myFunction()" data-rel="tooltip" data-placement="top"
                        title="Refresh Contact">
                        <i class="icon-refresh"></i>
                    </button>
                </div>
                &nbsp;&nbsp;
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <div class="row-fluid">
                        <asp:DataList ID="dlSec_Con_Info" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                            <HeaderTemplate>
                                <b class="center" style="text-align: left">Contact Type</b></th>
                                <th style="text-align: center">
                                    Name
                                </th>
                                <th style="text-align: center">
                                    Handphone1
                                </th>
                                <th style="text-align: center">
                                    Handphone2
                                </th>
                                <th style="text-align: center">
                                    LandLineNo
                                </th>
                                <th style="text-align: center">
                                    Gender
                                </th>
                                <th style="text-align: center">
                                    Email Id
                                </th>
                                <%--<th style="text-align: center">
                                                                                Occupation
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Organization
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Designation
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                Office Phone
                                                                            </th>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblContactId" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Id")%>'
                                    runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblCon_type_id" Text='<%#DataBinder.Eval(Container.DataItem, "Con_type_id")%>'
                                    runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblCon_Type_desc" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Type_desc")%>'
                                    runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblName" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblConTitle" Text='<%#DataBinder.Eval(Container.DataItem, "Con_title")%>'
                                        runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblFName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_Firstname")%>'
                                        runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblMName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_midname")%>'
                                        runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblLName" Text='<%#DataBinder.Eval(Container.DataItem, "Con_lastname")%>'
                                        runat="server" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHandphone1" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone1")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHandphone2" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone2")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLandline" Text='<%#DataBinder.Eval(Container.DataItem, "Landline")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblGender" Text='<%#DataBinder.Eval(Container.DataItem, "Gender")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEmailid" Text='<%#DataBinder.Eval(Container.DataItem, "Emailid")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <%--<td>
                                                                                <asp:Label ID="lblOccupation" Text='<%#DataBinder.Eval(Container.DataItem, "Occupation")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblOrganization" Text='<%#DataBinder.Eval(Container.DataItem, "Organization")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblDesignation" Text='<%#DataBinder.Eval(Container.DataItem, "Designation")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblOffice_phone" Text='<%#DataBinder.Eval(Container.DataItem, "Office_phone")%>'
                                                                                    runat="server"></asp:Label>
                                                                            </td>--%>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Label ID="lblSecConRecord" CssClass="red" Visible="False" runat="server" Font-Bold="True"></asp:Label>
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
                    Contact Academic Information
                </h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <asp:DataList ID="dlAcadInfo" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                        <HeaderTemplate>
                            <b class="center" style="text-align: left">Institution Type</b></th>
                            <th style="text-align: center">
                                Institution Name
                            </th>
                            <th style="text-align: center">
                                Board
                            </th>
                            <th style="text-align: center">
                                Standard
                            </th>
                            <th style="text-align: center">
                                Division
                            </th>
                            <th style="text-align: center">
                                Year Of Passing
                            </th>
                            <th style="text-align: center">
                                Additional Desc
                            </th>
                            <th style="text-align: center">
                                Examination Name
                            </th>
                            <th style="text-align: center">
                                Final Marks Obtained
                            </th>
                            <th style="text-align: center">
                                Final Marks Total
                            </th>
                            <th style="text-align: center">
                                Grade
                            </th>
                            <th style="text-align: center">
                                Percentage
                            </th>
                            <%--<th style="text-align: center">
                                                                            Action
                                                                        </th>--%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRowNumber" Text='<%#DataBinder.Eval(Container.DataItem, "Record_No")%>'
                                runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblInstitutionTypeCode" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Type_Id")%>'
                                runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblInstitutionType" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Type_Desc")%>'
                                runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblInstitutionName" Text='<%#DataBinder.Eval(Container.DataItem, "Institution_Description")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBoardId" Text='<%#DataBinder.Eval(Container.DataItem, "Board_Id")%>'
                                    runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblBoardName" Text='<%#DataBinder.Eval(Container.DataItem, "Board_Desc")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStandardCode" Text='<%#DataBinder.Eval(Container.DataItem, "Current_Standard_Id")%>'
                                    runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblStandardName" Text='<%#DataBinder.Eval(Container.DataItem, "Current_Standard_Desc")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDivisionCode" Text='<%#DataBinder.Eval(Container.DataItem, "Section_Id")%>'
                                    runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblDivisionName" Text='<%#DataBinder.Eval(Container.DataItem, "Section_Desc")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPassingYearCode" Text='<%#DataBinder.Eval(Container.DataItem, "Year_of_Passing_ID")%>'
                                    runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblPassingYearName" Text='<%#DataBinder.Eval(Container.DataItem, "Year_of_Passing_Desc")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAditionalDesc" Text='<%#DataBinder.Eval(Container.DataItem, "Additional_Desc")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblExamName" Text='<%#DataBinder.Eval(Container.DataItem, "ExamName")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFinalMarkObt" Text='<%#DataBinder.Eval(Container.DataItem, "FinalMarksObtained")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFinalMarkTotal" Text='<%#DataBinder.Eval(Container.DataItem, "FinalMarksTotal")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGrade" Text='<%#DataBinder.Eval(Container.DataItem, "Grade")%>'
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPercentage" Text='<%#DataBinder.Eval(Container.DataItem, "Percentage")%>'
                                    runat="server"></asp:Label>
                            </td>
                       
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblAcadInfoRecord" CssClass="red" Visible="False" runat="server" Font-Bold="True" Style="padding-left:14px"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row-fluid">
    <div class="span12">
        <div class="widget-box">
            <div class="widget-header widget-header-small header-color-dark">
                <h5>
                    Contact-Account History
                </h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <div class="row-fluid">
                        <asp:DataList ID="ddlContact_AccountHistory" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                            <HeaderTemplate>
                                <b class="center" style="text-align: left">Division</b></th>
                                <th style="text-align: center">
                                    Center
                                </th>
                                <th style="text-align: center">
                                    Acad Year
                                </th>
                                <th style="text-align: center">
                                    Product
                                </th>
                                <th style="text-align: center">
                                    Account Status
                                </th>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAccountId" Text='<%#DataBinder.Eval(Container.DataItem, "Account_id")%>'
                                    runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblSBEntryCode" Text='<%#DataBinder.Eval(Container.DataItem, "SbEntrycode")%>'
                                    runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblDivision" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                    runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCenter" Text='<%#DataBinder.Eval(Container.DataItem, "Center")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAcadYear" Text='<%#DataBinder.Eval(Container.DataItem, "AcadYear")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProductName" Text='<%#DataBinder.Eval(Container.DataItem, "ProductName")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAccountStatus" Text='<%#DataBinder.Eval(Container.DataItem, "AccountStatus")%>'
                                        runat="server"></asp:Label>
                                </td>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Label ID="lblAccountInfoRecord" CssClass="red" Visible="False" runat="server"
                            Font-Bold="True" style="padding-left:14px"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
