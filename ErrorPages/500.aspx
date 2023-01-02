<%@ Page Language="VB" AutoEventWireup="false" CodeFile="500.aspx.vb" Inherits="ErrorPages_500" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->

<html xmlns="http://www.w3.org/1999/xhtml">
<!--<![endif]-->
<!-- BEGIN HEAD -->

<head runat="server">
        <meta charset="utf-8"/>
        <title>500 - Oops Something Went Wrong</title>
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
        <meta content="" name="description"/>
        <meta content="" name="author"/>
        <meta name="MobileOptimized" content="320">
        <!-- basic styles -->
		<link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
		<link href="../assets/css/bootstrap-responsive.min.css" rel="stylesheet" />

		<link rel="stylesheet" href="../assets/css/font-awesome.min.css" />
		<!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->
        <!-- page specific plugin styles -->
		<!-- ace styles -->
		<link rel="stylesheet" href="../assets/css/ace.min.css" />
		<link rel="stylesheet" href="../assets/css/ace-responsive.min.css" />
		<link rel="stylesheet" href="../assets/css/ace-skins.min.css" />
		<!--[if lt IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->
        <link rel="shortcut icon" href="favicon.ico"/>
        <!-- END HEAD -->
        <!-- BEGIN BODY -->
</head>
<body>
		<div class="navbar navbar-inverse">
		  <div class="navbar-inner">
		   <div class="container-fluid">



		   </div><!--/.container-fluid-->
		  </div><!--/.navbar-inner-->
		</div><!--/.navbar-->

		<div class="container-fluid" id="main-container">
			<a href="#" id="menu-toggler"><span></span></a><!-- menu toggler -->

			<%--<div id="sidebar">
				
				<div id="sidebar-shortcuts">
					<div id="sidebar-shortcuts-large">
						<button class="btn btn-small btn-success"><i class="icon-signal"></i></button>
						<button class="btn btn-small btn-info"><i class="icon-pencil"></i></button>
						<button class="btn btn-small btn-warning"><i class="icon-group"></i></button>
						<button class="btn btn-small btn-danger"><i class="icon-cogs"></i></button>
					</div>
					<div id="sidebar-shortcuts-mini">
						<span class="btn btn-success"></span>
						<span class="btn btn-info"></span>
						<span class="btn btn-warning"></span>
						<span class="btn btn-danger"></span>
					</div>
				</div><!-- #sidebar-shortcuts -->

				<ul class="nav nav-list">
					
					<li>
					  <a href="index.html">
						<i class="icon-dashboard"></i>
						<span>Dashboard</span>
						
					  </a>
					</li>

					
					<li>
					  <a href="typography.html">
						<i class="icon-text-width"></i>
						<span>Typography</span>
						
					  </a>
					</li>

					
					<li>
					  <a href="#" class="dropdown-toggle" >
						<i class="icon-desktop"></i>
						<span>UI Elements</span>
						<b class="arrow icon-angle-down"></b>
					  </a>
					  <ul class="submenu">
						<li><a href="elements.html"><i class="icon-double-angle-right"></i> Elements</a></li>
						<li><a href="buttons.html"><i class="icon-double-angle-right"></i> Buttons & Icons</a></li>
					  </ul>
					</li>

					
					<li>
					  <a href="tables.html">
						<i class="icon-list"></i>
						<span>Tables</span>
						
					  </a>
					</li>

					
					<li>
					  <a href="#" class="dropdown-toggle" >
						<i class="icon-edit"></i>
						<span>Forms</span>
						<b class="arrow icon-angle-down"></b>
					  </a>
					  <ul class="submenu">
						<li><a href="form-elements.html"><i class="icon-double-angle-right"></i> Form Elements</a></li>
						<li><a href="form-wizard.html"><i class="icon-double-angle-right"></i> Wizard & Validation</a></li>
					  </ul>
					</li>

					
					<li>
					  <a href="widgets.html">
						<i class="icon-list-alt"></i>
						<span>Widgets</span>
						
					  </a>
					</li>

					
					<li>
					  <a href="calendar.html">
						<i class="icon-calendar"></i>
						<span>Calendar</span>
						
					  </a>
					</li>

					
					<li>
					  <a href="gallery.html">
						<i class="icon-picture"></i>
						<span>Gallery</span>
						
					  </a>
					</li>

					
					<li>
					  <a href="grid.html">
						<i class="icon-th"></i>
						<span>Grid</span>
						
					  </a>
					</li>

					
					<li class="active open">
					  <a href="#" class="dropdown-toggle" >
						<i class="icon-file"></i>
						<span>Other Pages</span>
						<b class="arrow icon-angle-down"></b>
					  </a>
					  <ul class="submenu">
						<li><a href="pricing.html"><i class="icon-double-angle-right"></i> Pricing Tables</a></li>
						<li><a href="invoice.html"><i class="icon-double-angle-right"></i> Invoice</a></li>
						<li><a href="login.html"><i class="icon-double-angle-right"></i> Login & Register</a></li>
						<li><a href="error-404.html"><i class="icon-double-angle-right"></i> Error 404</a></li>
						<li class="active"><a href="error-500.html"><i class="icon-double-angle-right"></i> Error 500</a></li>
						<li><a href="blank.html"><i class="icon-double-angle-right"></i> Blank Page</a></li>
					  </ul>
					</li>

					
				</ul><!--/.nav-list-->

				<div id="sidebar-collapse"><i class="icon-double-angle-left"></i></div>


			</div><!--/#sidebar-->--%>

		
			<div id="main-content" class="clearfix">
				<div id="page-content" class="clearfix">
					<div class="row-fluid">
<!-- PAGE CONTENT BEGINS HERE -->

<div class="error-container">

<div class="well">
	<h1 class="grey lighter smaller">
		<span class="blue bigger-125"><i class="icon-random"></i> 500</span> Something Went Wrong
	</h1>
	<hr />
	<h3 class="lighter smaller"> But we are working <i class="icon-wrench icon-animated-wrench bigger-125"></i> on it! </h3>
	
	<div class="space"></div>
	<div>

		<h4 class="lighter smaller">Meanwhile, try one of the following:</h4>
		<ul class="unstyled spaced inline bigger-110">
			<li><i class="icon-hand-right blue"></i> Read the faq</li>
			<li><i class="icon-hand-right blue"></i> Give us more info on how this specific error occurred!</li>
		</ul>
	</div>
	
	<hr />
	<div class="space"></div>
	
	<div class="row-fluid">
		<div class="center">
			<%--<a href="#" class="btn btn-grey"><i class="icon-arrow-left"></i> Go Back</a>--%>
			<a href="../Homepage.aspx" class="btn btn-primary"><i class="icon-dashboard"></i> Dashboard</a>
		</div>
	</div>
</div>

</div>


<!-- PAGE CONTENT ENDS HERE -->
						 </div><!--/row-->
	
					</div><!--/#page-content-->
					  

			


			</div><!-- #main-content -->


		</div><!--/.fluid-container#main-container-->




		<a href="#" id="btn-scroll-up" class="btn btn-small btn-inverse">
			<i class="icon-double-angle-up icon-only"></i>
		</a>


		<!-- basic scripts -->
		<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
		<script type="text/javascript">
		    window.jQuery || document.write("<script src='assets/js/jquery-1.9.1.min.js'>\x3C/script>");
		</script>
		
		<script src="assets/js/bootstrap.min.js"></script>

		<!-- page specific plugin scripts -->
		

		<!-- ace scripts -->
		<script src="assets/js/ace-elements.min.js"></script>
		<script src="assets/js/ace.min.js"></script>


		<!-- inline scripts related to this page -->
		
		<script type="text/javascript">

		    $(function () {



		    })

		</script>

	</body>
<!-- END JAVASCRIPTS -->
<!-- END BODY -->
</html>
