<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="forgetPassword.aspx.cs" Inherits="OneStopFraudReportingSystem.forgetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Password Recovery</h2>
            <hr />
            <h3>Please enter your email address. We will send the instruction to reset your password.</h3>
            <br />
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" CssClass="col-md-2" Text="Your Email:"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-6">
                    <asp:Button ID="btnPasswordReset" runat="server" CssClass="btn btn-default" Text="Send" OnClick="btnPasswordReset_Click"/>
                    <asp:Label ID="lblPasswordReset" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>