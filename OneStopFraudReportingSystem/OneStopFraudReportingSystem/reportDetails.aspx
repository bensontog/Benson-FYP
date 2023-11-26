<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="reportDetails.aspx.cs" Inherits="OneStopFraudReportingSystem.reportDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <div class="container" style="width:1000px;">
        <div>
            <div class="row">
                <div class="col-md-7 mx-auto">
                    <div class="card-body" style="background-clip: border-box; border: 1px solid rgba(0,0,0,.125); border-radius: .25rem;">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/companyLogo.png" width="135" height="135"/>
                                    <h4>Cases Report</h4>
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
                                <asp:Label ID="lblVEmail" runat="server" Text="Email: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtEmail" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblCategory" runat="server" Text="Cases Category: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtCategory" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblBankName" runat="server" Text="Bank Name: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtBankName" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblCardNumber" runat="server" Text="Card Number: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtCardNumber" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblSenderPhone" runat="server" Text="Sender Phone Number: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtSenderPhone" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblReceivedDate" runat="server" Text="Received Date: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtReceivedDate" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblODate" runat="server" Text="Occurred Date: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtODate" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblRDetails" runat="server" Text="Report Details: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtRDetails" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblDepartment" runat="server" Text="In Charged By: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtDepartment" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblHandledBy" runat="server" Text="Handled By: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtHandledBy" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblStatus" runat="server" Text="Status: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtStatus" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblComment" runat="server" Text="Comment: " Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtComment" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="col">
                                <center>
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
                                </center>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <hr />

    <section class="ftco-section">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div>
                        <asp:Repeater ID="rptEvidence" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Evidence ID</th>
                                            <th>Evidence</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("EVIDENCE_ID")  %></td>
                                            <td><img src='<%# Eval("EVIDENCE") %>'' width="75" height="75" class="img-sm border" ></td>
                                            <td><a href="viewEvidence.aspx?id=<%# Eval("EVIDENCE_ID")%>" class="btn btn-primary">View</a></td>
                                            <td><a href="deleteEvidence.aspx?id=<%# Eval("EVIDENCE_ID")%>" class="btn btn-danger">Delete</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptViewEvidence" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Evidence ID</th>
                                            <th>Evidence</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("EVIDENCE_ID")  %></td>
                                            <td><img src='<%# Eval("EVIDENCE") %>'' width="75" height="75" class="img-sm border" ></td>
                                            <td><a href="viewEvidence.aspx?id=<%# Eval("EVIDENCE_ID")%>" class="btn btn-primary">View</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
