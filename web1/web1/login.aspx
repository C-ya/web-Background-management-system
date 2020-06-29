<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="web1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="assets/images/favicon.png" type="image/png" />
    <title>login</title>
    <link href="assets/css/icons.css" rel="stylesheet" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/responsive.css" rel="stylesheet" />

</head>
<body class="sticky-header">
    <form id="form1" runat="server">
        <!--Start login Section-->
        <section class="login-section">
            <div class="container">
                <div class="row">
                    <div class="login-wrapper">
                        <div class="login-inner">
                            <h2 class="header-title text-center">欢迎登录</h2>
                            <div class="form-group">
                                <asp:TextBox ID="textBox1" runat="server" class="form-control" placeholder="账号"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="textBox2" runat="server" class="form-control" placeholder="密码"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <div class="pull-left">
                                    <div class="checkbox primary">
                                        <asp:CheckBox ID="checkbox2" runat="server" Text="记住我" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="登录" class="btn btn-primary btn-block" />
                            </div>
                            <div class="form-group text-center">
                                没有账号？  <a href="registration.aspx">注册</a>
                            </div>
                            <div class="copy-text">
                                <p class="m-0">2020 &copy; by 17123051 刘畅</p>
                            </div>

                        </div>
                    </div>

                </div>
            </div>

        </section>
        <!--End login Section-->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
