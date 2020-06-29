<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chancourse.aspx.cs" Inherits="web1.chancourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="assets/images/favicon.png" type="image/png" />
    <title>chancourse</title>
    <link href="assets/plugins/morris-chart/morris.css" rel="stylesheet" />
    <link href="assets/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link href="assets/css/icons.css" rel="stylesheet" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/responsive.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="left-side sticky-left-side">

            <!--logo-->
            <div class="logo">
                <a href="home.aspx">
                    <img src="assets/images/logo.png" alt="" /></a>
            </div>
            <div class="logo-icon text-center">
                <a href="home.aspx">
                    <img src="assets/images/logo-icon.png" alt="" /></a>
            </div>
            <!--logo-->

            <div class="left-side-inner">
                <!--Sidebar nav-->
                <ul class="nav nav-pills nav-stacked custom-nav">
                    <li class="menu-lis"><a href="home.aspx"><i class="icon-home"></i><span>学生信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="home.aspx">学生信息详情</a></li>
                            <li><a href="chanstu.aspx">学生信息修改</a></li>
                        </ul>
                    </li>

                    <li class="menu-list"><a href="#"><i class="icon-layers"></i><span>教师信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="teacher.aspx">教师信息详情</a></li>
                            <li><a href="chanteacher.aspx">教师信息修改</a></li>
                        </ul>
                    </li>

                    <li class="menu-list"><a href="#"><i class="icon-grid"></i><span>学生成绩管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="stugrade.aspx">学生成绩详情</a></li>
                            <li><a href="chanstugrade.aspx">学生成绩修改</a></li>
                        </ul>
                    </li>

                    <li class="menu-list nav-active"><a href="#"><i class="icon-envelope-open"></i><span>课程信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="course.aspx">课程信息详情</a></li>
                            <li><a href="chancourse.aspx">课程信息修改</a></li>
                        </ul>
                    </li>

                    <li class="menu-listt"><a href="#"><i class="icon-loop"></i><span>教师授课管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="form-basic.aspx">教师授课详情</a></li>
                            <li><a href="form-element.aspx">教师授课修改</a></li>
                        </ul>
                    </li>

                </ul>
                <!--End sidebar nav-->

            </div>
        </div>
        <div class="main-content">
            <div class="header-section">
                <a class="toggle-btn"><i class="fa fa-bars"></i></a>
                <!--user menu start -->
                <div class="menu-right">
                    <ul class="notification-menu">
                        <li>
                            <a href="#" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                <img src="assets/images/users/avatar-6.jpg" alt="" />
                                <asp:Label ID="CurrentUser" runat="server" Text=""></asp:Label>
                                <span class="caret"></span>
                            </a>
                            <ul class="dropdown-menu dropdown-menu-usermenu pull-right">
                                <li><a href="manage.aspx"><i class="fa fa-wrench"></i>Settings </a></li>
                                <li><a href="profile.aspx"><i class="fa fa-user"></i>Profile </a></li>
                                <li><a href="login.aspx"><i class="fa fa-lock"></i>Logout </a></li>
                            </ul>
                        </li>

                    </ul>
                </div>
                <!--user menu end -->
            </div>
            <div class="wrapper">
                <!--Start Page Title-->
                <div class="page-title-box">
                    <h4 class="page-title">课程信息</h4>
                    <ol class="breadcrumb">
                        <li>
                            <a href="#">课程信息管理</a>
                        </li>

                        <li class="active">课程信息修改
                        </li>
                    </ol>
                    <div class="clearfix"></div>
                </div>
                <!--End Page Title-->

                <!--Start row-->

                <div class="white-box">
                    <h2 class="header-title">课程信息</h2>

                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="课程号"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" ReadOnly="True" Width="20%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="课程名"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" Width="20%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="学时"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" class="form-control" Width="20%"></asp:TextBox>
                    </div>
                </div>
                <div class="button-wrap">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" class="btn btn-primary" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="取消" class="btn btn-default" />
                </div>
            </div>
        </div>
    </form>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/plugins/moment/moment.js"></script>
    <script src="assets/js/jquery.slimscroll.js "></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/functions.js"></script>
</body>
</html>
