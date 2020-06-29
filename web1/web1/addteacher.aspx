﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addteacher.aspx.cs" Inherits="web1.addteacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="assets/images/favicon.png" type="image/png" />
    <title>addstu</title>
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
                    <li class="menu-list"><a href="home.aspx"><i class="icon-home"></i><span>学生信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="home.aspx">学生信息详情</a></li>
                            <li><a href="addstu.aspx">添加学生信息</a></li>
                        </ul>
                    </li>

                    <li class="menu-list nav-active"><a href="#"><i class="icon-layers"></i><span>教师信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="teacher.aspx">教师信息详情</a></li>
                            <li class="active"><a href="addteacher.aspx">添加教师信息</a></li>
                        </ul>
                    </li>

                    <li class="menu-list"><a href="#"><i class="icon-grid"></i><span>学生成绩管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="stugrade.aspx">学生成绩详情</a></li>
                            <li><a href="chanstugrade.aspx">学生成绩修改</a></li>
                        </ul>
                    </li>

                    <li class="menu-list"><a href="#"><i class="icon-envelope-open"></i><span>课程信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="course.aspx">课程信息详情</a></li>
                            <li><a href="chancourse.aspx">课程信息修改</a></li>
                        </ul>
                    </li>

                    <li class="menu-list"><a href="#"><i class="icon-loop"></i><span>教师授课管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="teach.aspx">教师授课详情</a></li>
                            <li><a href="addteach.aspx">添加教师授课信息</a></li>
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
                    <h4 class="page-title">教师信息管理</h4>
                    <ol class="breadcrumb">
                        <li>
                            <a href="#">教师信息管理</a>
                        </li>

                        <li class="active">增加教师信息
                        </li>
                    </ol>
                    <div class="clearfix"></div>
                </div>
                <!--End Page Title-->
                <div class="white-box">
                    <h2 class="header-title">添加教师信息</h2>

                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="工号" Width="35px"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Width="20%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="姓名" Width="35px"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" Width="20%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="性别" Width="35px"></asp:Label>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="男" Width="50px" GroupName="group2" />
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="女" Width="50px" GroupName="group2" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="出生日期"></asp:Label>
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" SelectedDate="1968-11-27">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="职称" Width="35px"></asp:Label>
                        <asp:TextBox ID="TextBox5" runat="server" Width="20%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="学院" Width="35px"></asp:Label>
                        <asp:TextBox ID="TextBox6" runat="server" Width="20%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="电话" Width="35px"></asp:Label>
                        <asp:TextBox ID="TextBox7" runat="server" Width="20%"></asp:TextBox>
                    </div>

                    <div class="button-wrap">
                        <asp:Button ID="Button3" runat="server" Text="确定" class="btn btn-primary" OnClick="Button3_Click" />
                        <asp:Button ID="Button4" runat="server" Text="取消" class="btn btn-default" OnClick="Button4_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!--Begin core plugin -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/plugins/moment/moment.js"></script>
    <script src="assets/js/jquery.slimscroll.js "></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/functions.js"></script>
    <!-- End core plugin -->

    <!--Begin Page Level Plugin-->
    <script src="assets/plugins/morris-chart/morris.js"></script>
    <script src="assets/plugins/morris-chart/raphael-min.js"></script>
    <script src="assets/plugins/jquery-sparkline/jquery.sparkline.min.js"></script>
    <script src="assets/pages/dashboard.js"></script>
    <!--End Page Level Plugin-->
</body>
</html>
