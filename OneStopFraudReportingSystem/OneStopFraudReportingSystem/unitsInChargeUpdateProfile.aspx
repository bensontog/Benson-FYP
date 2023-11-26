<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="unitsInChargeUpdateProfile.aspx.cs" Inherits="OneStopFraudReportingSystem.unitsInChargeUpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
    <style>
        .word{
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/uic.png" width="150" height="150"/>
                                    <h4>Update Profile</h4>
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
                                <asp:Label ID="lblAID" runat="server" Text="Unit Staff ID" Font-Bold="true" Font-Strikeout="False"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtUID" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                             </div>

                             <div class="col-md-6">
                                <asp:Label ID="lblUsername" runat="server" Text="Username" Font-Bold="true" Font-Strikeout="false"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Field Cannot Empty" ControlToValidate="txtUsername" CssClass="word" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                             </div>
                         </div>

                         <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblName" runat="server" Text="Name" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Field Cannot Empty" ControlToValidate="txtName" CssClass="word" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                    <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Please enter the &lt;b&gt;Phone No&lt;/b&gt;" ControlToValidate="txtPhone" CssClass="word" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Please follow the format XXX-XXXXXXX or XXX-XXXXXXXX in digit" CssClass="word" Display="Dynamic" ValidationExpression="\d{3}\-\d{7,8}" ControlToValidate="txtPhone" SetFocusOnError="true"></asp:RegularExpressionValidator>
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
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Please enter the &lt;b&gt;Email&lt;/b&gt;" ControlToValidate="txtEmail" CssClass="word" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter a Valid Email" Display="Dynamic" CssClass="word" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblPosition" runat="server" Text="Position" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPosition" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                         </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblDepartment" runat="server" Text="Department" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtDepartment" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Please enter the &lt;b&gt;Address&lt;/b&gt;" ControlToValidate="txtAddress" CssClass="word" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                         </div>

                         <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="btnEdit" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
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
