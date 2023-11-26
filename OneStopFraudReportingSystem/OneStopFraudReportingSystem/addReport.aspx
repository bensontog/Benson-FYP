<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="addReport.aspx.cs" Inherits="OneStopFraudReportingSystem.addReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <style>
        .word{
            color:red;
        }

        .word1{
            font-family: 'Times New Roman', Times, serif;
            font-size: 18px;
        }
    </style>

    <div class="container">
        <div class="row">
            <div class="col-md-7 mx-auto">
                <div>
                    <div class="card-body" style="background-clip:border-box; border:1px solid rgba(0,0,0,.125); border-radius: .25rem;">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/addReport.png" width="130" height="120"/>
                                    <h3>Cases Reporting Form</h3>
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
                                <asp:Label ID="lblReportID" runat="server" Text="Report ID" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtReportID" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblDate" runat="server" Text="Date" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="lblSDate" runat="server" Text="" CssClass="word1"></asp:Label>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblVname" runat="server" Text="Name" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtVname" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblVEmail" runat="server" Text="Email" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtVEmail" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblTitle" runat="server" Text="Cases Category" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="600px" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_Changed">
                                       
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategory" Display="Dynamic" ErrorMessage="Please select fraud category !" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblBankName" runat="server" Text="Bank Name" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtBankName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblCardNumber" runat="server" Text="Card Number" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtCardNumber" runat="server"></asp:TextBox>
                                </div>                     
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblSenderPhone" runat="server" Text="Sender Phone Number" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtSenderPhone" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblReceivedDate" runat="server" Text="Received Date" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtReceivedDate" runat="server"></asp:TextBox>
                                </div>                     
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblOccurredDate" runat="server" Text="Cases Occurred Date" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtOccurredDate" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblDetails" runat="server" Text="Report Details" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtRDetails" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRDetails" Display="Dynamic" ErrorMessage="Please enter cases details !" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblEvidence" runat="server" Text="Cases Evidence" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileEvidence" runat="server" width="267px"/>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-success btn-block btn-lg" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-danger btn-block btn-lg" ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="false"/>
                                        </div>
                                    </div>
                                </center>
                            </div>
                        </div>

                        <hr />

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>