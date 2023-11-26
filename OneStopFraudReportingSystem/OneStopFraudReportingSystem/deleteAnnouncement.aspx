<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="deleteAnnouncement.aspx.cs" Inherits="OneStopFraudReportingSystem.deleteAnnouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <div class="container" style="width:1000px;">
        <div>
            <div class="row">
                <div class="col-md-7 mx-auto">
                    <div class="card-body" style="background-clip: border-box; border: 1px solid rgba(0,0,0,.125); border-radius: .25rem;" id="print" runat="server">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/companyLogo.png" width="135" height="135"/>
                                    <h4>Announcement</h4>
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
                            <div class="col">
                                <asp:Label ID="lblAID" runat="server" Text="Announcement ID:" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtAID" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblATitle" runat="server" Text="Announcement Title:" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtATitle" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblADate" runat="server" Text="Announcement Date:" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtADate" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblADetails" runat="server" Text="Announcement Details:" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtADetails" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPostedBy" runat="server" Text="Posted By:" Font-Bold="true"></asp:Label>
                                &nbsp;
                                <asp:Label  ID="txtPostedBy" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPosition" runat="server" Text="Position:" Font-Bold="true"></asp:Label>
                                &nbsp;
                                <asp:Label  ID="txtPosition" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblDepartment" runat="server" Text="Department:" Font-Bold="true"></asp:Label>
                                &nbsp;
                                <asp:Label  ID="txtDepartment" runat="server"></asp:Label>
                            </div>
                        </div>

                        
                    </div>

                    <br />

                   <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-danger btn-block btn-lg" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"/>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
                                        </div>
                                    </div>
                                </center>
                            </div>
                        </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>