<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Login - WORKFLOW APP sytem</title>
    <!-- Bootstrap core CSS-->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for login-->
    <link href="../assets/css/custom.css" rel="stylesheet">
    <script src="assets/js/jquery-1.12.4.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
          

</head>

<body class="bg-dark">
    
    <div class="container">     
        <div class="card card-login mx-auto mt-5">
            <div class="card-header">FORGOT PASSWORD</div>
            <div class="card-body">
                <form runat="server" id="formlogin">
                    <asp:Panel ID="pnl_warning" runat="server" Visible="false">
                    
                        <div class="alert alert-danger text-center py-5">
                        <asp:Label ID="lbl_warning" runat="server" Text="Label" CssClass="col-form-label text-center"></asp:Label>
                             <button type="button" class="close" data-dismiss="alert">
                                      <span>
                                          &times;
                                      </span>
                             </button>
                        </div>
                    
                    </asp:Panel>

                    <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqr_emil" runat="server" ErrorMessage="Enter email" ControlToValidate="txt_email" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <label for="exampleInputPassword1">Enter New Password</label>
                                <asp:TextBox ID="txt_pass" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqr_pass" runat="server" ErrorMessage="Enter password" ControlToValidate="txt_pass" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
             
                    <asp:Button ID="btn_register" runat="server" Text="Change Password" CssClass="btn btn-primary btn-block" OnClick="btn_register_Click" />

                    <div class="text-center">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/admin/login.aspx">Go Back</asp:HyperLink>
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

