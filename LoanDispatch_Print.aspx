<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="LoanDispatch_Print.aspx.cs" Inherits="LoanDispatch_Print" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link rel="stylesheet" href="assets/plugins/data-tables/DT_bootstrap.css" />
    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <style type="text/css">
        @media print
        {
            h1
            {
                page-break-before: always;
            }
        }
        thead
        {
            display: table-header-group;
        }
        tfoot
        {
            display: table-footer-group;
        }
    </style>
    <script type="text/javascript">
//        window.onload = function () { window.print(); }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContainer" runat="Server">
    <!-- BEGIN CONTENT -->
    <asp:ScriptManager ID="script1" runat="server">
            </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-content">
            
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>

            <asp:UpdatePanel ID="UpnlprintCentre" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- BEGIN RECEIPT I PRINT-->
                    <div class="invoice">
                        <div id="divCentrePrint" class="invoice" runat="server">
                        <table width="100%">
                            <thead align="center">
                                <tr>
                                    <td align="center" colspan="8">
                                        <b style="font-size: large">
                                            <asp:Label ID="lblZoraBankname" runat="server" Text="Zoroastrian Bank Education Loan"></asp:Label></b>
                                    </td>
                                </tr>
                            </thead>
                        </table>
                        <table width="100%">
                            <tr>
                                <td  align="left" width="40%" style="font-size: medium">
                                    Centre Name: <asp:Label ID="lblCentreName" runat="server"> </asp:Label>
                                    <asp:Label ID="lblslipno" runat="server" Visible="false"></asp:Label>
                                </td>    
                                <td align="left" width="40%" style="font-size: medium">
                                    &nbsp;&nbsp;&nbsp;Division : <asp:Label ID="lblDivisionName" runat="server"></asp:Label>
                                </td>
                                <td align="right" width="20%" style="font-size: medium">
                                    Date : <asp:Label ID="lblslipdate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="7" align="right" width="90%" style="font-size: medium">
                                    Date:
                                </td>
                                <td align="right" width="10%" style="font-size: medium">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: medium">
                                    To,
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: medium">
                                    The Manager,
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: medium">
                                    <asp:Label ID="lblbankname" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: medium">
                                    
                                </td>
                            </tr>--%>
                        </table>                                                                      
                        <div class="row-fluid">
                            <div class="col-xs-12">
                                <asp:DataList ID="dlLoanDisp" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                    <HeaderTemplate>
                                        <b>Sr.No</b></th>
                                        <th>
                                            Name Of the Student
                                        </th>
                                        <th>
                                            Name Of Applicant
                                        </th>
                                        <th>
                                            SB Entry Code
                                        </th>
                                        <th>
                                            Centre Name
                                        </th>
                                        <th>
                                            StreamName
                                         </th>
                                        <th>
                                            Total Fees(Amount)
                                        </th>
                                        <th>
                                            Down Payment Made(Amount)
                                       <%-- </th>
                                        <th>
                                        Amount--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#Container.ItemIndex+1 %></td>
                                        <td>
                                            <asp:Label ID="lblstudentname" Text='<%#DataBinder.Eval(Container.DataItem, "NAME")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "ApplicantName")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblrecbankname" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblchequeno" Text='<%#DataBinder.Eval(Container.DataItem, "CentreName")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblchqdate" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalFee" Text='<%#DataBinder.Eval(Container.DataItem, "TotalFee")%>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDownPaymentAmount" Text='<%#DataBinder.Eval(Container.DataItem, "PaidFee")%>'
                                                runat="server"></asp:Label>
                                       <%-- </td>
                                        <td align="right">
                                            <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "chequeAmt")%>'
                                                runat="server"></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:DataList>
                                <%--<table class="table table-striped table-bordered table-hover" width="100%">
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td width="20%" style="font-size: medium; font-weight: bolder">
                                            Total Count
                                        </td>
                                        <td width="20%" style="font-size: medium; font-weight: bolder">
                                            Total Value
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td width="20%" align="right">
                                            <asp:Label ID="lblchqcount" runat="server"></asp:Label>
                                        </td>
                                        <td width="20%" align="right">
                                            <asp:Label ID="lbltotalamt" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr>
                                        <td style="font-size: medium">
                                            Thanks & Regards
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: medium">
                                            For
                                            <asp:Label ID="lblpayeecentername1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td style="font-size: medium">
                                            Authorised Signatory
                                        </td>
                                    </tr>
                                </table>--%>
                            </div>
                        </div>
                        </div>
                        <div class="col-xs-7 invoice-block">
                            <a class="btn btn-lg blue hidden-print" onclick="javascript:window.print();">Print <i
                                class="fa fa-print"></i></a>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <!-- END CONTENT -->
</asp:Content>


