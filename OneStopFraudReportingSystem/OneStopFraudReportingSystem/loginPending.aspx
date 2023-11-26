<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="loginPending.aspx.cs" Inherits="OneStopFraudReportingSystem.loginPending" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container">
         <div class="row">
             <div class="col-md-6 mx-auto">
                 <div>
                     <div class="card-body" style="background-color: #fff; background-clip: border-box; border: 1px solid rgba(0,0,0,.125); border-radius: .25rem;">
                         <div class="row">
                             <div class="col">
                                 <center>
                                     <img src="Images/user.jpg" width="150" height="150"/>
                                     <img src="Images/uic.png" width="150" height="150"/>
                                     <img src="Images/admin.png" width="150" height="150"/>
                                     <br />
                                     <br />
                                 </center>
                             </div>
                         </div>

                         <div class="row">
                             <div class="col">
                                 <center>
                                     <h4>Welcome To One-Stop Fraud Reporting Platform !</h4>
                                 </center>
                             </div>
                         </div>

                         <div class="row">
                             <div class="col">
                                 <center>
                                     <h4><asp:Label ID="lblError" runat="server" Text=""></asp:Label></h4>
                                 </center>
                                 <hr />
                             </div>
                         </div>

                         <div class="row">
                             <div class="col">
                                 <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                 <div class="form-group">
                                     <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Please enter Username to login !" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 </div>

                                 <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>

                                 <div class="from-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Please enter Password to login !" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 </div>

                                 <div class="form-group">
                                     <asp:CheckBox ID="chkRememberMe" runat="server" />
                                     <asp:Label ID="lblRememberMe" runat="server" Text="Remember Me?"></asp:Label>
                                 </div>

                                 <div class="form-group">
                                     <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
                                 </div>

                                 <div class="form-group">
                                     <h5 style="text-align:center; font-size:16px;">
                                         <u>
                                             <a href="forgetPassword.aspx">Forget Password</a>
                                         </u>
                                     </h5>
                                 </div>
                             </div>
                         </div>

                         <div class="row">
                             <div class="col">
                                 <hr />
                             </div>
                         </div>

                         <div class="row">
                             <div class="col" style="text-align:center;">
                                 <a style="font-weight:400;">Still don't have an account?</a>
                                 <br />
                                 <a href="userRegistration.aspx">SIGN UP</a>
                             </div>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
    </div>
</asp:Content>