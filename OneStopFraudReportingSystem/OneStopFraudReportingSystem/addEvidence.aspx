<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="addEvidence.aspx.cs" Inherits="OneStopFraudReportingSystem.addEvidence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-7 mx-auto">
                <div>
                    <div class="card-body" style="background-clip:border-box; border:1px solid rgba(0,0,0,.125); border-radius:.25rem;">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/addReport.png" width="130" height="130"/>
                                    <h3>Add New Evidence</h3>
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
                                <asp:Label ID="lblReportID" runat="server" Text="Report ID: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtReportID" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblDate" runat="server" Text="Date: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtDate" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblVname" runat="server" Text="Name: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtVname" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblVPhone" runat="server" Text="Phone: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtPhone" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblEvidence" runat="server" Text="New Cases Evidence: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileEvidence" runat="server" Width="267px"/>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-success btn-block btn-lg" ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"/>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false"/>
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