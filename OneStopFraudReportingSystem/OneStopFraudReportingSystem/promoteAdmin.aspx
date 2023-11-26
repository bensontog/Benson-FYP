<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="promoteAdmin.aspx.cs" Inherits="OneStopFraudReportingSystem.promoteAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <style>
        .word{
            color:red;
        }
    </style>

    <div class="container">
        <div class="tab-content">
            <div class="row">
                <div class="col-md-7 mx-auto">
                    <div>
                        <div class="card-body rounded border">
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img src="Images/admin.png" width="150" height="150"/>
                                        <h4>Promote Admin</h4>
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
                                    <asp:Label ID="lblName" runat="server" Text="Name" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtName" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
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
                                    <asp:Label ID="lblPhone" runat="server" Text="Phone No" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblPosition" runat="server" Text="Position" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlPosition" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" ID="txtPosition"></asp:ListItem>
                                            <asp:ListItem>Middle-Level Admin</asp:ListItem>
                                            <asp:ListItem>High-Level Admin</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Please select the &lt;b&gt;Position&lt;/b&gt;" ControlToValidate="ddlPosition" Display="Dynamic" CssClass="word" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-8 mx-auto">
                                    <center>
                                        <div class="form-group">
                                            <asp:Button class="btn btn-success btn-block btn-lg" ID="btnPromote" runat="server" Text="Promote" OnClick="btnPromote_Click"/>
                                        </div>
                                        <div class="form-group">
                                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
                                        </div>
                                    </center>
                                </div>
                            </div>

                            <br />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>