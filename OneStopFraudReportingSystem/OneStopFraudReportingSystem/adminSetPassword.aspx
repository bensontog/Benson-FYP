<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="adminSetPassword.aspx.cs" Inherits="OneStopFraudReportingSystem.adminSetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <div class="container">
        <ul class="nav nav-tabs" style="background-color:#F9F9F9;">
            <li>
                <asp:LinkButton ID="lnkAdminProfile" runat="server" OnClick="lnkAdminProfile_Click" CausesValidation="false"><i class="fa fa fa-user bigger-120"></i> Admin Profile</asp:LinkButton>
            </li>
            <li class="active">
                <asp:LinkButton ID="lnkAdminSetPass" runat="server" OnClick="lnkAdminSetPass_Click"><i class="fa fa fa-key bigger-120"></i> Set Password</asp:LinkButton>
            </li>
        </ul>

        <div class="tab-content" style="border: 1px solid #c5d0dc; padding: 30px 12px; position: relative;">
            <div class="row">
                <div class="col-md-7 mx-auto">
                    <div>
                        <div class="card-body rounded border">
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="Images/admin.png" width="150" height="150"/>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4>Admin Set Password</h4>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4>
                                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                        </h4>
                                    </center>
                                    <hr />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblACurPass" runat="server" Text="Current Password: " Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtACurPass" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtACurPass" CssClass="error" Display="Dynamic" ErrorMessage="*Please enter the &lt;b&gt;[current password]&lt;/b&gt;" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblANewPass" runat="server" Text="New Password: " Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtANewPass" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Please enter the &lt;b&gt;[new password]&lt;/b&gt;" ControlToValidate="txtANewPass" CssClass="error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*At least &lt;b&gt;1 uppercase alphabet&lt;/b&gt;, &lt;b&gt;1 lowercase alphabet&lt;/b&gt;, &lt;b&gt;1 numeric character [0-9]&lt;/b&gt;, and &lt;b&gt;1 special character&lt;/b&gt; and &lt;b&gt;at least 8 character&lt;/b&gt;" ControlToValidate="txtANewPass" CssClass="error" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&amp;])[A-Za-z\d@$!%*?&amp;]{8,}$" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAConPass" runat="server" Text="Confirm Password: " Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtAConPass" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Please enter the &lt;b&gt;[Confirm password]&lt;/b&gt;" ControlToValidate="txtAConPass" CssClass="error" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Comfirm password must same with &lt;b&gt;[new password]&lt;/b&gt;" ControlToCompare="txtANewPass" ControlToValidate="txtAConPass" CssClass="error" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>

                            <hr />

                            <div class="row" style="display: block; background-color: #F5F5F5; padding: 19px 0px 20px 140px">
                                <div>
                                    <div class="col-md-4" style="text-align: center; display: block;">
                                        <asp:LinkButton CssClass="btn btn-block btn-primary" ID="btlSave" runat="server" OnClick="btlSave_Click"><i class="fa fa fa-check bigger-11"></i> Save</asp:LinkButton>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:LinkButton CssClass="btn btn-block btn-secondary" ID="btlReset" runat="server" OnClick="btlReset_Click" CausesValidation="false"><i class="fa fa fa-undo bigger-11"></i> Reset</asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>