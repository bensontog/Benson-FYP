<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="passwordRecover.aspx.cs" Inherits="OneStopFraudReportingSystem.passwordRecover" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Reset New Password</h2>
            <hr />

            <h3><asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label></h3>

            <div class="form-group">
                <asp:Label ID="lblPassword" CssClass="col-md-2 control-label" runat="server" Text="New Password" Visible="false"></asp:Label>
                &nbsp;
                <div class="col-md-3">
                    <asp:TextBox ID="txtNewPass" CssClass="form-control" TextMode="Password" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div class="col-md-5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Please enter the &lt;b&gt;[new password]&lt;/b&gt;" ControlToValidate="txtNewPass" CssClass="error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*At least &lt;b&gt;1 uppercase alphabet&lt;/b&gt;, &lt;b&gt;1 lowercase alphabet&lt;/b&gt;, &lt;b&gt;1 numeric character [0-9]&lt;/b&gt;, and &lt;b&gt;1 special character&lt;/b&gt; and &lt;b&gt;at least 8 character&lt;/b&gt;" ControlToValidate="txtNewPass" CssClass="error" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&amp;])[A-Za-z\d@$!%*?&amp;]{8,}$" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblConfirmPassword" CssClass="col-md-2 control-label" runat="server" Text="Confirm Password" Visible="false"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" TextMode="Password" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div class="col-md-5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Please enter the &lt;b&gt;[Confirm password]&lt;/b&gt;" ControlToValidate="txtConfirmPassword" CssClass="error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Confirm password must same with &lt;b&gt;[new password]&lt;/b&gt;" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPassword" CssClass="error" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-2">

                </div>
                <div class="col-md-6">
                    <asp:Button ID="btnPassRec" CssClass="btn btn-default" runat="server" Text="Reset" Visible="false" OnClick="btnPassRec_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>