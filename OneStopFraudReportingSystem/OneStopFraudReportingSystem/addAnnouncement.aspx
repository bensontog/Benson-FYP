<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="addAnnouncement.aspx.cs" Inherits="OneStopFraudReportingSystem.addAnnouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <style>
        .word{
            color:red;
        }

        .word1{
            font-family: "Times New Roman", Times, serif;
            font-size: 18px;
        }
    </style>

    <div class="container">
        <div>
            <div class="row">
                <div class="col-md-7 mx-auto">
                    <div class="card-body" style="background-clip: border-box; border: 1px solid rgba(0,0,0,.125); border-radius: .25rem;">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/announcement.png" width="135" height="135"/>
                                    <h4>Create New Announcement</h4>
                                </center>
                            </div>
                        </div>

                        <br />
                        <br />

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblATitle" runat="server" Text="Announcement Title" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtATitle" runat="server" placeholder="Announcement Title"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtATitle" Display="Dynamic" ErrorMessage="Please enter Announcement Title !" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblADate" runat="server" Text="Announcement Date" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="lblDate" runat="server" Text="" CssClass="word1"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblADetails" runat="server" Text="Announcement Details" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtADetails" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtADetails" Display="Dynamic" ErrorMessage="Please enter Announcement Details !" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblPostedBy" runat="server" Text="Posted By" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPostedBy" runat="server" ReadOnly="true"></asp:TextBox>
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
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-success btn-block btn-lg" ID="btnSubmit" runat="server" Text="Create" OnClick="btnSubmit_Click"/>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-danger btn-block btn-lg" ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="false"/>
                                        </div>
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