<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Dashboard_Center.aspx.cs" Inherits="Dashboard_Center" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="fusioncharts-n-xt-developer/js/fusioncharts.js" type="text/javascript"></script>
    <script src="fusioncharts-n-xt-developer/js/fusioncharts.charts.js" type="text/javascript"></script>
    <script src="fusioncharts-n-xt-developer/js/fusioncharts.widgets.js" type="text/javascript"></script>
    <script src="fusioncharts-n-xt-developer/js/fusioncharts.powercharts.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div id="page-content" class="clearfix">
        <div class="page-header position-relative">
            <h1>
                <b>Dashboard </b><small><i class="icon-double-angle-right"></i>&nbsp;<b>Overview & Stats</b></small>
                <div class="nav ace-nav pull-right">
                    <small style="font-size: 16px">Division</small>
                    <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp; <small style="font-size: 16px">Center</small>
                    <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp; <small style="font-size: 16px">Academic Year</small>
                    <asp:DropDownList ID="ddlAcadYear" runat="server" data-placeholder="Select" AutoPostBack="true"
                        Style="border-radius: 10; width: 200px" OnSelectedIndexChanged="ddlAcadYear_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </h1>
        </div>
       <div style="color: Maroon ">
       <b>      Note: </b>
       <br />
        <b>     1. Numbers are shown on the basis of Centers allotted to the User </b>
        <br />
        <b>     2. Dashborad Report for the Acad years : </b>&nbsp;&nbsp;<span runat="server" id="lblAcadyear"></span>
        <br />
        <b>     3. Dashborad Report Last updated : </b>&nbsp;&nbsp;<span runat="server" id="lbldate"></span>
         </div>

        <div class="page-header position-radius-4" >
            <h4>
                <b>Admission </b><small><i class="icon-double-angle-right" ></i></small>
                <br />

                <div class="row-fluid" style ="margin-top: 10px">
      
            <div class="span2 infobox-container" style="background-color: #0DA3E2">
                <a id="apendingaccount" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            Pending Admissions:
                           </div>
                            <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblpendingCount"></span>
                           </div>
                        
                    </div>
                </a>
            </div>
            <%--<div class="span2 infobox-container" style="background-color: #F06137">--%>
            <div class="span2 infobox-container" style="background-color: #0DA3E2">
                <a id="aPendingAccountsReasonwise" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                          Pending Admn Streamwise:
                        </div>
                        <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblpendingCount1"></span>
                           </div>
                    </div>
                </a>
            </div>
           <%-- <div class="span2 infobox-container" style="background-color: #634355">--%>
            <div class="span2 infobox-container" style="background-color: #0DA3E2">
                <a id="apendingaccountageing" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            Pending Admn Reasonwise:
                        </div>
                         <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblpendingCount2"></span>
                           </div>
                    </div>
                </a>
            </div>
           <%-- <div class="span2 infobox-container" style="background-color: #6C557C">--%>
            <div class="span2 infobox-container" style="background-color: #0DA3E2">
                <a id="acancelledaccount" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            Cancelled Admissions:
                        </div>
                        <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblcancelladm"></span>
                           </div>
                    </div>
                </a>
            </div>

            <%--<div class="span2 infobox-container" style="background-color: #FF9900">--%>
            <div class="span2 infobox-container" style="background-color: #0DA3E2">
                <a id="aAccountsCancellationStatus" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            Cancelled Admissions Log:
                        </div>
                         <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblcanelled"></span>
                           </div>
                    </div>
                </a>
            </div>
                      
        </div>
            </h4>
        </div>

        <div class="page-header position-relative">
            <h4>
                <b>Payments & Deductions </b><small><i class="icon-double-angle-right"></i></small>
                <div class="row-fluid" style ="margin-top: 10px">

            <%--<div class="span2 infobox-container" style="background-color: #009900">--%>
            <div class="span2 infobox-container" style="background-color: #CC3366">
                <a id="aecsdone" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            ECS Accepted
                        </div>
                         <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblECS"></span>
                           </div>
                    </div>
                </a>
            </div>
        <%--    <div class="span2 infobox-container" style="background-color: #B5651E">--%>
            <div class="span2 infobox-container" style="background-color: #CC3366">
                <a id="aecspendingstatus" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            ECS Status Log
                        </div>
                    </div>
                </a>
            </div>

            <div class="span2 infobox-container" style="background-color: #CC3366">
           <%-- <div class="span2 infobox-container" style="background-color: #CC3366">--%>
                <a id="aBlockedAccount" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                           Cheques Blocked
                        </div>
                        <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblblokedchque"></span>
                           </div>
                    </div>
                </a>
            </div>

            
            <div class="span2 infobox-container" style="background-color: #CC3366">
           <%-- <div class="span2 infobox-container" style="background-color: #CC3366">--%>
                <a id="aPayementdeposited" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                       Payments In Clearing
                        </div>
                        <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblDepositedchque"></span>
                           </div>
                    </div>
                </a>
            </div>
            
            <%--<div class="span2 infobox-container" style="background-color: #0EABD6">--%>
            <div class="span2 infobox-container" style="background-color: #CC3366">
                <a id="afeesdeductions" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            Fees Deductions (Discount, Concessions, Waivers etc)
                        </div>
                    </div>
                </a>
            </div>

                </div>
            </h4>
        </div>

        <%--<br />--%>
        <div class="page-header position-relative">
            <h4>
                <b>Recovery </b><small><i class="icon-double-angle-right"></i></small>
                <div class="row-fluid" style ="margin-top: 10px">
                       
         <%--   <div class="span2 infobox-container" style="background-color: #2c70bf">--%>
            <div class="span2 infobox-container" style="background-color: #EA4335">
                <a id="aBouncedPaymentRecoveryStatus" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            Bounced Payment Recovery Status
                        </div>

                          <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblbouce"></span>
                           </div>
                    </div>
                </a>
            </div>
            
           <%-- <div class="span2 infobox-container" style="background-color: #EA4335">--%>
            <div class="span2 infobox-container" style="background-color: #EA4335">
                <a id="aBouncedPaymentsAgeing" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                            Bounced Payments Log
                        </div>
                    </div>
                </a>
            </div>
            
            <%--<div class="span2 infobox-container" style="background-color: #6f6f3d">--%>
             <div class="span2 infobox-container" style="background-color: #EA4335">
                <a id="apendingapprovalstatus" runat="server" target="_blank">
                    <div class="infobox infobox-white" style="background-color: transparent!important;border-color: transparent!important;">
                        <div class="infobox-data" style="color: White">
                          Approval Pending Status
                        </div>
                        <div class="infobox-data" style="color: White">
                            <span runat="server" id="lblapprovals"></span>
                           </div>
                    </div>
                </a>
            </div>
            
            
        </div>
                    
                <%--</div>--%>
            </h4>
        </div>


        </div>
        
        <%--<br />--%>
        <div class="row-fluid">
            <div class="span12">
                <asp:Literal ID="Literal0" runat="server">
                </asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>
