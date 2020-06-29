<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="web1.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="assets/images/favicon.png" type="image/png" />
    <title>registration</title>
    <link href="assets/css/icons.css" rel="stylesheet" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/responsive.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <section class="login-section">
            <div class="container">
                <div class="row">
                    <div class="login-wrapper">
                        <div class="login-inner">
                            <h2 class="header-title text-center">欢迎注册</h2>
                            <div class="form-group">
                                <asp:TextBox ID="textBox1" runat="server" class="form-control" placeholder="账号"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="textBox2" runat="server" class="form-control" placeholder="密码"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <div class="pull-left">
                                    <div class="checkbox primary">
                                        <asp:CheckBox ID="checkbox1" runat="server" Text="记住我" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="注册" class="btn btn-primary btn-block" />

                            </div>
                            <div class="form-group text-center">
                                已经有账号?  <a href="login.aspx">登录</a>
                            </div>
                            <div class="copy-text">
                                <p class="m-0">2020 &copy; by 17123051 刘畅</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>

    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/plugins/moment/moment.js"></script>
    <script src="assets/js/jquery.slimscroll.js "></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/functions.js"></script>

</body>
</html>
