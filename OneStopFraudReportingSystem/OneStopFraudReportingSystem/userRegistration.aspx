<%@ Page Title="User Registration" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userRegistration.aspx.cs" Inherits="OneStopFraudReportingSystem.userRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

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
                                        <img src="Images/user.jpg" width="150" height="150"/>
                                        <h4>User Registration</h4>
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
                                    <asp:Label ID="lblName" runat="server" Text="Name" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Please enter the &lt;b&gt;Name&lt;/b&gt;" CssClass="word" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Name cannot have &lt;b&gt;Special key and digit&lt;/b&gt;" CssClass="word" ValidationExpression='([A-z][A-Za-z]*\s+[A-Za-z]*)|([A-z][A-Za-z]*)' Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="lblUsername" runat="server" Text="Username" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUsername" ErrorMessage="*Please enter the &lt;b&gt;Username&lt;/b&gt;" CssClass="word" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="*Username Already Exist" OnServerValidate="CustomValidator1_ServerValidate" CssClass="word" Display="Dynamic" ControlToValidate="txtUsername" SetFocusOnError="true"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="lblIcNo" runat="server" Text="Ic No" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtIcNo" runat="server" placeholder="IC Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Please enter the &lt;b&gt;IC&lt;/b&gt;" ControlToValidate="txtIcNo" CssClass="word" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="**Please follow the format XXXXXX-XX-XXXX in digit" Display="Dynamic" CssClass="word" ControlToValidate="txtIcNo" ValidationExpression="\d{6}\-\d{2}\-\d{4}" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="lblGender" runat="server" Text="Gender" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:RadioButtonList ID="rblGender" runat="server" Height="34px" RepeatDirection="Horizontal" TextAlign="Left" Width="100%">
                                            <asp:ListItem Value="M">Male</asp:ListItem>
                                            <asp:ListItem Value="F">Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblGender" ErrorMessage="*Please select the &lt;b&gt;Gender&lt;/b&gt;" CssClass="word" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="lblEmail" runat="server" Text="Email" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Please enter the &lt;b&gt;Email&lt;/b&gt;" ControlToValidate="txtEmail" CssClass="word" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Enter a Valid Email" Display="Dynamic" CssClass="word" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="*Email Already Exist" OnServerValidate="CustomValidator2_ServerValidate" CssClass="word" Display="Dynamic" ControlToValidate="txtEmail" SetFocusOnError="true"></asp:CustomValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="lblPhone" runat="server" Text="Phone No" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server" placeholder="Phone Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Please enter the &lt;b&gt;Phone No&lt;/b&gt;" ControlToValidate="txtPhone" CssClass="word" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Please follow the format XXX-XXXXXXX or XXX-XXXXXXXX in digit" CssClass="word" Display="Dynamic" ValidationExpression="\d{3}\-\d{7,8}" ControlToValidate="txtPhone" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Phone Number Already Exist" ControlToValidate="txtPhone" OnServerValidate="CustomValidator3_ServerValidate" Display="Dynamic" CssClass="word" SetFocusOnError="true"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="lblPass" runat="server" Text="Password" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Please enter the &lt;b&gt;Password&lt;/b&gt;" ControlToValidate="txtPassword" CssClass="word" Display="Dynamic" TextMode="Password" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*At least &lt;b&gt;1 uppercase alphabet&lt;/b&gt;, &lt;b&gt;1 lowercase alphabet&lt;/b&gt;, &lt;b&gt;1 numeric character [0-9]&lt;/b&gt;, and &lt;b&gt;1 special character&lt;/b&gt; and &lt;b&gt;at least 8 character&lt;/b&gt;" Display="Dynamic" CssClass="word" ControlToValidate="txtPassword" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&amp;])[A-Za-z\d@$!%*?&amp;]{8,}$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="lblConPass" runat="server" Text="Confirm Password" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtConPass" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Please enter the &lt;b&gt;Confirm Password&lt;/b&gt;" ControlToValidate="txtConPass" CssClass="word" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Password Not Match" CssClass="word" ControlToValidate="txtConPass" Display="Dynamic" ControlToCompare="txtPassword"></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <asp:Label ID="lblAddress" runat="server" Text="Address" Font-Bold="true"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Please enter the &lt;b&gt;Address&lt;/b&gt;" ControlToValidate="txtAddress" CssClass="word" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-8 mx-auto">
                                    <center>
                                        <div class="form-group">
                                            <div class="col-md-6">
                                                <asp:Button class="btn btn-success btn-block btn-lg" ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click"/>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Button class="btn btn-danger btn-block btn-lg" ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="false"/>
                                            </div>
                                        </div>
                                    </center>
                                </div>
                            </div>

                            <hr />

                            <div class="row">
                                <div class="col" style="text-align:center;">
                                    <a style="font-weight:400;">Already have an account?</a>
                                    <br />
                                    <a href="userLogin.aspx"><u>SIGN IN</u></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>