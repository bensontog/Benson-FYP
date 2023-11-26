<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="adminProfile.aspx.cs" Inherits="OneStopFraudReportingSystem.adminProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <div class="container">
        <ul class="nav nav-tabs" style="background-color: #F9F9F9;">
            <li class="active">
                <asp:LinkButton ID="lnkAdminProfile" runat="server" OnClick="lnkAdmProfile_Click"><i class="fa fa fa-user bigger-120"></i> Admin Profile</asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lnkAdminSetPass" runat="server" OnClick="lnkAdmSetPass_Click"><i class="fa fa fa-key bigger-120"></i> Set Password</asp:LinkButton>
            </li>
        </ul>

        <div class="tab-content" style="border: 1px solid #c5d0dc; padding: 30px 12px; position: relative;">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card-body rounded border">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/admin.png" width="150" height="150"/>
                                    <h3>Your Profile</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblAID" runat="server" Text="Admin ID" Font-Bold="true" Font-Strikeout="False"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAID" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblUsername" runat="server" Text="Username" Font-Bold="true" Font-Strikeout="false"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblName" runat="server" Text="Name" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtName" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblIC"  runat="server" Text="IC No" Font-Bold="True"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtIcNo" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblPhone" runat="server" Text="Phone No" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="col-md-6">
                                <asp:Label ID="lblGender"  runat="server" Text="Gender" Font-Bold="True"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtGender" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblEmail" runat="server" Text="Email" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblDepartment" runat="server" Text="Department" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtDepartment" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPosition" runat="server" Text="Position" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPosition" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnEdit" runat="server" Text="Update" OnClick="btnEdit_Click"/>
                                    </div>
                                </center>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>