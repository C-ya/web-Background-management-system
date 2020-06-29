﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="web1.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="assets/images/favicon.png" type="image/png" />
    <title>home</title>
    <link href="assets/plugins/morris-chart/morris.css" rel="stylesheet" />
    <link href="assets/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link href="assets/css/icons.css" rel="stylesheet" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/responsive.css" rel="stylesheet" />
</head>
<body class="sticky-header">
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
                    <li class="menu-list nav-active"><a href="home.aspx"><i class="icon-home"></i><span>学生信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li class="active"><a href="home.aspx">学生信息详情</a></li>
                            <li><a href="addstu.aspx">添加学生信息</a></li>
                        </ul>
                    </li>

                    <li class="menu-list"><a href="#"><i class="icon-layers"></i><span>教师信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="teacher.aspx">教师信息详情</a></li>
                            <li><a href="addteacher.aspx">添加教师信息</a></li>
                        </ul>
                    </li>

                    <li class="menu-list"><a href="#"><i class="icon-grid"></i><span>学生成绩管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="stugrade.aspx">学生成绩详情</a></li>
                            <li><a href="addstugrade.aspx">添加学生成绩</a></li>
                        </ul>
                    </li>

                    <li class="menu-list"><a href="#"><i class="icon-envelope-open"></i><span>课程信息管理</span></a>
                        <ul class="sub-menu-list">
                            <li><a href="course.aspx">课程信息详情</a></li>
                            <li><a href="addcourse.aspx">添加课程信息</a></li>
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
                <div class="searchform">
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Search here..."></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" class="btn btn-primary round" Text="查找" OnClick="Button1_Click" Width="68px" />

                </div>
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
                    <h4 class="page-title">学生信息管理</h4>
                    <ol class="breadcrumb">
                        <li>
                            <a href="#">学生信息管理</a>
                        </li>

                        <li class="active">学生信息
                        </li>
                    </ol>
                    <div class="clearfix"></div>
                </div>
                <!--End Page Title-->
                <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView_OnRowCommand" AllowPaging="True" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="4" DataKeyNames="学号" DataSourceID="SqlDataSource2" ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" Width="98%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="学号" HeaderText="学号" ReadOnly="True" SortExpression="学号" />
                        <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" />
                        <asp:BoundField DataField="性别" HeaderText="性别" SortExpression="性别" />
                        <asp:BoundField DataField="生日" HeaderText="生日" SortExpression="生日" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" />
                        <asp:BoundField DataField="籍贯" HeaderText="籍贯" SortExpression="籍贯" />
                        <asp:BoundField DataField="学院号" HeaderText="学院号" SortExpression="学院号" />
                        <asp:BoundField DataField="学院名称" HeaderText="学院名称" SortExpression="学院名称" />
                        <asp:BoundField DataField="班级" HeaderText="班级" SortExpression="班级" />
                        <asp:ButtonField CommandName="edit" HeaderText="操作" ShowHeader="True" Text="编辑" />
                        <asp:ButtonField CommandName="Del" HeaderText="操作" ShowHeader="True" Text="删除" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:jxglConnectionString %>" SelectCommand="SELECT S.S# AS 学号, S.SNAME AS 姓名, S.SSEX AS 性别, S.SBIRTHIN AS 生日, S.PLACEOFB AS 籍贯, S.SCODE# AS 学院号, SS.SSNAME AS 学院名称, S.CLASS AS 班级 FROM S INNER JOIN SS ON S.SCODE# = SS.SCODE#"></asp:SqlDataSource>
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