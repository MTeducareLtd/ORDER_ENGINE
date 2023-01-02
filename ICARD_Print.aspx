<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ICARD_Print.aspx.cs" Inherits="ICARD_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

/* RESET */
html,body,div,span,applet,object,iframe,h1,h2,h3,h4,h5,h6,p,blockquote,pre,a,abbr,acronym,address,big,cite,code,del,dfn,em,img,ins,kbd,q,s,samp,small,strike,strong,sub,sup,tt,var,b,u,i,center,dl,dt,dd,ol,ul,li,fieldset,form,label,legend,table,caption,tbody,tfoot,thead,tr,th,td,article,aside,canvas,details,embed,figure,figcaption,footer,header,hgroup,menu,nav,output,ruby,section,summary,time,mark,audio,video{border:0;font-size:100%;font:inherit;vertical-align:baseline;margin:0;padding:0}article,aside,details,figcaption,figure,footer,header,hgroup,menu,nav,section{display:block}body{line-height:1}ol,ul{list-style:none}blockquote,q{quotes:none}blockquote:before,blockquote:after,q:before,q:after{content:none}table{border-collapse:collapse;border-spacing:0}
/* RESET END */



.outer_wrapper{
  /*padding-top: 202px;*/
}

.wrapper{
  width: 31cm;
  height: 20cm;
  /*border: 1px solid black;*/
  margin: 0;
  
  /*-webkit-transform: rotate(90deg);
    -moz-transform: rotate(90deg);
    -o-transform: rotate(90deg);
    -ms-transform: rotate(90deg);
    transform: rotate(90deg);
	
	-ms-transform-origin: left center;
	-webkit-transform-origin: left center;
	transform-origin: left center;*/


}

.id_card{

  width: 6cm;
  height: 10cm;
  border: 1px solid rgb(255, 140, 140);
  /*background-image: url(marks2.jpg);
    background-size: 6cm 10cm;*/
  float:left;
}

.head{
	height: 1.5cm;
	  background-image: url(border_centre.jpg);
  background-size: 6cm;
  background-repeat: repeat-y;

}

.logo{
  display: block;
  width: 1.16cm;
  float: right;
  margin: 0.1cm 0.6cm 0 0;
}

.roll{
  text-align: center;
  font-weight: bold;
  font-size: 8pt;
}

.course{
  text-align: center;
  font-weight: bold;
   font-size: 8pt;

}

.first_name{
text-align: center;
  font-weight: bold;
  font-size: 15pt;
  margin-top: 0.1cm;
}

.last_name{
text-align: center;
  font-weight: bold;
  font-size: 12pt;
  margin-top: 0.1cm;
}

.image{
   display: block;
  width: 2.57cm;
  height: 2.84cm;
  margin: 0.3cm auto;
}

.content{
  height: 6.5cm;
  background-image: url(border_centre.jpg);
  background-size: 6cm;
  background-repeat: repeat-y;
  }

.details{
  margin: 0 auto;
  width: 78%;
  font-size: 8pt;
  }

.details td{
    padding-bottom: 0.1cm;
}

.details td:first-child{
  width: 1.1cm;
}

.details td:last-child{
    padding-left: 0.1cm;
}

.footer{
  border-top: 1px solid black;
    background-image: url(border_centre.jpg);
  background-size: 6cm;
  background-repeat: repeat-y;

}

.line1{
font-size: 6pt;
  text-align: center;
  margin: 0.1cm 0 0.1cm 0;
  text-decoration: underline;
  font-weight: bold;
  }

.line2{
  text-align: center;
  font-size: 7pt;
}

.mark_top{
width:6cm;
}

.mark_bottom{
width:6cm;
}


@media print {

* {-webkit-print-color-adjust:exact;}

.head {
  background-image: url(border_centre.jpg);
  background-size: 6cm;
  background-repeat: repeat-y;
}

.content {
  background-image: url(border_centre.jpg);
  background-size: 6cm;
  background-repeat: repeat-y;
}

.footer {
  background-image: url(border_centre.jpg);
  background-size: 6cm;
  background-repeat: repeat-y;
}

}


</style>
    <script type="text/javascript">
        window.onload = function () { window.print(); }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="outer_wrapper">
        <div class="wrapper">
            <asp:DataList ID="dlstudentidcard" runat="server" CellPadding="3" CellSpacing="2"
                RepeatColumns="5" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="id_card">
                        <div class="head">
                            <img src="images/sb/mark_top.jpg" class="mark_top" />
                            <img src="images/sb/logo.png" class="logo" />
                        </div>
                        <div class="content">
                            <p class="roll">
                                <asp:Label ID="lblSBEntrycode" runat="server" Text='<%# Bind("Student_RFID") %>'></asp:Label>
                            </p>
                            <p class="course">
                                <asp:Label ID="lblStreamSDesc" runat="server" Text='<%# Bind("Stream_SDesc") %>'></asp:Label>
                            </p>
                            <p class="first_name">
                                <asp:Label ID="lblFirstname" runat="server" Text='<%# Bind("Firstname") %>'></asp:Label>
                            </p>
                            <p class="last_name">
                                <asp:Label ID="lblLASTNAME" runat="server" Text='<%# Bind("LAST_NAME") %>'></asp:Label>
                            </p>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Stud_Image") %>' class="image" />
                            <table class="details">
                                <!--<tr>
                                    <td>
                                        College :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblInstitution_Description" runat="server" Text='<%# Bind("Institution_Description") %>'></asp:Label>
                                    </td>
                                </tr>-->
                                <tr>
                                    <td>
                                        Address :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFlatno" runat="server" Text='<%# Bind("Flatno") %>'></asp:Label>,
                                        <asp:Label ID="lblStreetName" runat="server" Text='<%# Bind("StreetName") %>'> </asp:Label>,
                                        <asp:Label ID="lblCity_Name" runat="server" Text='<%# Bind("City_Name") %>'> </asp:Label>,
                                        Pin-<asp:Label ID="lblPincode" runat="server" Text='<%# Bind("Pincode") %>'> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="footer">
                            <p class="line1">
                                IF FOUND PLEASE RETURN TO
                            </p>
                            <p class="line2">
                                <asp:Label ID="lblBranchAddress" runat="server" Text='<%# Bind("BranchAddress") %>'></asp:Label>
                            </p>
                        </div>
                        <img src="images/sb/mark_bottom.jpg" class="mark_bottom" />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    </form>
</body>
</html>
