<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=yes">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Login - WORKFLOW APP sytem</title>
    <link href="../assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Bootstrap core CSS-->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for login-->
    <link href="../assets/css/custom.css" rel="stylesheet">

<link href="../js/msgbox%20css/jquery-ui-1.8.16.custom.css" rel="stylesheet" />
<script src="../js/jquery-1.6.2.min.js"></script>
<script src="../js/jquery-ui-1.8.16.custom.min.js"></script>
<script src="../js/jquery.msgBox.v1.js"></script>


    <script type="text/javascript">
        $(function() {
            $(".btn btn-primary btn-block").confirmLink();
        });
    </script>


</head>

<body class="bg-dark">
    <div class="container">
        <div class="card card-login mx-auto m-5 w-50">
            <div class="card-header small text-white text-center" id="login" style="background-color:black;">LOGIN
                <h4><span class="text-white" style="letter-spacing:4px;font-weight: 300;"><b>WORKFLOW APP</b></span></h4>
            </div>
            <div class="card-body" style="background-color:#FF6500;">
                <form runat="server" id="formlogin">
                    <asp:Panel ID="pnl_warning" runat="server" Visible="false">
                    <div class="form-group card-header text-center">
                        <div class="alert alert-danger text-center">
                        <asp:Label ID="lbl_warning" runat="server" Text="Label" CssClass="col-form-label text-center"></asp:Label>
                         <button type="button" class="close" data-dismiss="alert">
                           <span>
                               &times;
                           </span>
                         </button>
                        </div>
                    </div>
                    </asp:Panel>
                    <div class="form-group w-100">
                        <i class="fa fa-fw fa-user"></i>
                        <label for="exampleInputEmail1" class="text-white"><b>Email address</b></label>
                        <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Enter email" style="color:#FF6500;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_emil" runat="server" ErrorMessage="Please fill in your email !!!" ControlToValidate="txt_email" Display="Dynamic" ForeColor="#a90404"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <div class="form-row">
                            <div class="w-100">
                                <i class="fa fa-fw fa-tag"></i>
                                <label for="exampleInputPassword1" class="text-white"><b>Password</b></label>
                                <asp:TextBox ID="txt_pass" runat="server" style="color:#FF6500;" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqr_pass" runat="server" ErrorMessage="Please fill in your password !!!" ControlToValidate="txt_pass" Display="Dynamic" ForeColor="#a90404"></asp:RequiredFieldValidator>
                            </div>
                           <asp:TextBox ID="txtLoggedIN" runat="server" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtroleid" runat="server" Visible="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-check">
                            <label class="form-check-label text-white">
                                <asp:CheckBox ID="chk_remember" runat="server" CssClass="form-check-input remembermecustom" />
                                <b>Remember Password</b></label>
                        </div>
                    </div>

                    <%--CssClass="btn btn-primary btn-block"--%>
                  
                    <strong><asp:Button ID="btnlogin" runat="server" Text="Log In" OnClick="btnlogin_Click" /></strong>
                    <div class="text-center">
                        <a class="d-block small mt-2 mb-1 text-light" href="../signup.aspx">Sign-Up</a>
                    </div>

                    <div class="text-center">
                        <a class="d-block small text-light" href="../ForgotPassword.aspx">Forgot Password?</a>
                    </div>
    
                </form>

            </div>
        </div>
    </div>


    <!-- Bootstrap core JavaScript-->
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/bootstrap.bundle.min.js"></script>
        <script src="../assets/js/custom.js"></script>
</body>

</html>
